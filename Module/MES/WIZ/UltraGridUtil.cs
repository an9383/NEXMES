using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using Infragistics.Win.UltraWinMaskedEdit;
using Infragistics.Win.UltraWinScrollBar;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WIZ
{
    public class UltraGridUtil
    {
        public static int bandIndex = 0;

        public void InitializeGrid(UltraGrid ultraGrid)
        {
            ultraGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromArgb(207, 250, 250);
            InitializeGrid(ultraGrid, true, true, true, "", false);
        }

        public void InitializeGrid(UltraGrid ultraGrid, bool addContextMenu, bool allowEditable, bool extendLastCol, string gridCaption, bool activeRowWhiteColor)
        {
            ultraGrid.DisplayLayout.ClearGroupByColumns();
            ultraGrid.UseFlatMode = DefaultableBoolean.True;
            if (gridCaption == "")
            {
                ultraGrid.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            }
            else
            {
                ultraGrid.DisplayLayout.CaptionVisible = DefaultableBoolean.True;
                ultraGrid.Text = gridCaption;
            }
            ultraGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            if (extendLastCol)
            {
                ultraGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            }
            ultraGrid.DisplayLayout.Appearance.BorderColor = Color.Black;
            ultraGrid.DisplayLayout.ColumnChooserEnabled = DefaultableBoolean.True;
            ultraGrid.DisplayLayout.CaptionAppearance.BackColor = Color.Red;
            ultraGrid.DisplayLayout.BorderStyle = UIElementBorderStyle.Rounded1;
            ultraGrid.DisplayLayout.BorderStyleCaption = UIElementBorderStyle.Solid;
            ultraGrid.DisplayLayout.GroupByBox.Hidden = true;
            ultraGrid.DisplayLayout.InterBandSpacing = 10;
            ultraGrid.DisplayLayout.LoadStyle = LoadStyle.LoadOnDemand;
            ultraGrid.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            ultraGrid.DisplayLayout.ScrollBarLook.ViewStyle = ScrollBarViewStyle.WindowsVista;
            ultraGrid.DisplayLayout.TabNavigation = TabNavigation.NextCell;
            ultraGrid.DisplayLayout.ViewStyle = ViewStyle.MultiBand;
            ultraGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            ultraGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            ultraGrid.DisplayLayout.Override.AllowGroupMoving = AllowGroupMoving.WithinBand;
            ultraGrid.DisplayLayout.Override.AllowRowSummaries = AllowRowSummaries.False;
            ultraGrid.DisplayLayout.Override.AllowColMoving = AllowColMoving.WithinBand;
            ultraGrid.DisplayLayout.Override.ButtonStyle = UIElementButtonStyle.WindowsXPCommandButton;
            ultraGrid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dashed;
            ultraGrid.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dashed;
            ultraGrid.DisplayLayout.Override.BorderStyleRowSelector = UIElementBorderStyle.Dashed;
            ultraGrid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Dashed;
            ultraGrid.DisplayLayout.Override.BorderStyleFilterCell = UIElementBorderStyle.Dashed;
            ultraGrid.DisplayLayout.Override.BorderStyleFilterOperator = UIElementBorderStyle.Dashed;
            ultraGrid.DisplayLayout.Override.BorderStyleFilterRow = UIElementBorderStyle.Dashed;
            ultraGrid.DisplayLayout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.Dashed;
            ultraGrid.DisplayLayout.Override.BorderStyleSummaryFooter = UIElementBorderStyle.Dashed;
            ultraGrid.DisplayLayout.Override.BorderStyleSummaryFooterCaption = UIElementBorderStyle.Dashed;
            ultraGrid.DisplayLayout.Override.BorderStyleSummaryValue = UIElementBorderStyle.Dashed;
            ultraGrid.DisplayLayout.Override.BorderStyleTemplateAddRow = UIElementBorderStyle.Dashed;
            ultraGrid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            ultraGrid.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.False;
            ultraGrid.DisplayLayout.Override.CellAppearance.TextVAlign = VAlign.Middle;
            ultraGrid.DisplayLayout.Override.CellButtonAppearance.TextVAlign = VAlign.Middle;
            ultraGrid.DisplayLayout.Override.DefaultRowHeight = 30;
            ultraGrid.DisplayLayout.Override.ExpansionIndicator = ShowExpansionIndicator.Default;
            ultraGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            ultraGrid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard;
            ultraGrid.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;
            ultraGrid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;
            ultraGrid.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = HAlign.Left;
            ultraGrid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            ultraGrid.DisplayLayout.Override.RowSelectorStyle = HeaderStyle.WindowsVista;
            ultraGrid.DisplayLayout.Override.TipStyleCell = TipStyle.Show;
            ultraGrid.DisplayLayout.Override.TipStyleHeader = TipStyle.Show;
            ultraGrid.DisplayLayout.Override.TipStyleScroll = TipStyle.Show;
            ultraGrid.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True;
            ultraGrid.DisplayLayout.MaxColScrollRegions = 2;
            ultraGrid.DisplayLayout.MaxRowScrollRegions = 2;
            ultraGrid.DisplayLayout.SplitterBarHorizontalAppearance.BackColor = Color.DarkBlue;
            ultraGrid.DisplayLayout.SplitterBarVerticalAppearance.BackColor = Color.DarkBlue;
            ultraGrid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            ultraGrid.DisplayLayout.Override.RowSelectorWidth = 40;
            ultraGrid.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = HAlign.Center;
            ultraGrid.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = VAlign.Middle;
            ultraGrid.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
            ultraGrid.DisplayLayout.UseFixedHeaders = true;
            ultraGrid.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free;
            if (allowEditable)
            {
                ultraGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
                ultraGrid.DisplayLayout.Override.SelectTypeCell = SelectType.ExtendedAutoDrag;
            }
            ultraGrid.DisplayLayout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsOnly;
            ultraGrid.DisplayLayout.Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True;

            if (!addContextMenu)
            {
                ultraGrid.ContextMenuStrip = null;
            }

        }

        public void SetSummaryColumns(UltraGrid Grid, string Title, int TitlePos, string[] sumColumns, SummaryType sumType = SummaryType.Sum, SummaryDisplayAreas sumPos = SummaryDisplayAreas.Top, string SumFormat = "#,##0.##", SummaryDisplayAreas SumDisplayPos = SummaryDisplayAreas.Top, Color? SumBack = null, Color? SumFore = null)
        {
            UltraGridBand ultraGridBand = Grid.DisplayLayout.Bands[0];
            string text = (Common.Lang == "KO") ? Title : Common.getLangText(Title);
            if (ultraGridBand.Summaries.Count <= 0)
            {
                ultraGridBand.Summaries.Add(text, SummaryType.Custom, new FakeCaptionSummary(), ultraGridBand.Columns[TitlePos], SummaryPosition.UseSummaryPositionColumn, ultraGridBand.Columns[TitlePos]);
            }
            int num = 0;
            foreach (UltraGridColumn column in ultraGridBand.Columns.Cast<UltraGridColumn>())
            {
                int num2 = Array.FindIndex(sumColumns, (string item) => item == column.Key.ToUpper());
                if (num2 >= 0)
                {
                    SummarySettings summarySettings = ultraGridBand.Summaries.Add("SUM([" + column + "])", SummaryType.Custom, new FakeCaptionSummary(), ultraGridBand.Columns[num], SummaryPosition.UseSummaryPositionColumn, ultraGridBand.Columns[num]);
                    summarySettings.SourceColumn = ultraGridBand.Columns[num];
                    summarySettings.DisplayFormat = "{0:" + SumFormat + "}";
                    summarySettings.SourceColumn.Format = SumFormat;
                    summarySettings.SummaryPositionColumn.Format = SumFormat;
                    summarySettings.SummaryType = sumType;
                    summarySettings.SummaryDisplayArea = SumDisplayPos;
                    summarySettings.Appearance.TextHAlign = HAlign.Right;
                    summarySettings.Appearance.FontData.Bold = DefaultableBoolean.True;
                    summarySettings.Appearance.BackColor = (SumBack ?? Color.Empty);
                    summarySettings.Appearance.ForeColor = (SumFore ?? Color.Black);
                }
                else if (num == TitlePos)
                {
                    ultraGridBand.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
                    ultraGridBand.Override.SummaryFooterAppearance.FontData.SizeInPoints = Grid.DisplayLayout.Appearance.FontData.SizeInPoints;
                    Grid.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
                    ultraGridBand.Summaries[0].DisplayFormat = text;
                    ultraGridBand.Summaries[0].Appearance.TextHAlign = HAlign.Center;
                    ultraGridBand.Summaries[0].SummaryDisplayArea = SumDisplayPos;
                    ultraGridBand.Summaries[0].Appearance.FontData.Bold = DefaultableBoolean.True;
                    ultraGridBand.Summaries[0].Appearance.BackColor = (SumBack ?? Color.Empty);
                    ultraGridBand.Summaries[0].Appearance.ForeColor = (SumFore ?? Color.Black);
                }
                num++;
            }
        }

        public void GridHeaderMerge(UltraGrid Grid, string GroupKey, string GroupCaption, string[] MergeColumns, string[] Columns = null, HAlign AlignHeader = HAlign.Center)
        {
            UltraGridBand ultraGridBand = Grid.DisplayLayout.Bands[0];
            Grid.DisplayLayout.Bands[0].RowLayoutStyle = RowLayoutStyle.GroupLayout;
            int num = 0;
            for (num = 0; num < MergeColumns.Length; num++)
            {
                MergeColumns[num] = MergeColumns[num].ToUpper();
            }
            UltraGridGroup ultraGridGroup = null;
            foreach (UltraGridColumn column in ultraGridBand.Columns.Cast<UltraGridColumn>())
            {
                int num2 = Array.FindIndex(MergeColumns, (string item) => item == column.Key.ToUpper());
                if (num2 >= 0)
                {
                    if (num2 == 0)
                    {
                        ultraGridGroup = ultraGridBand.Groups.Add(GroupKey, (Common.Lang == "KO") ? GroupCaption : Common.getLangText(GroupCaption));
                    }
                    ultraGridBand.Columns[column.Key].RowLayoutColumnInfo.OriginX = 2 * num2;
                    ultraGridBand.Columns[column.Key].RowLayoutColumnInfo.SpanX = 2;
                    ultraGridBand.Columns[column.Key].RowLayoutColumnInfo.SpanY = 2;
                    if (ultraGridGroup != null)
                    {
                        ultraGridBand.Columns[column.Key].RowLayoutColumnInfo.ParentGroup = ultraGridGroup;
                        if (ultraGridBand.Columns[column.Key].RowLayoutColumnInfo.ParentGroup.RowLayoutGroupInfo.OriginX == -1)
                        {
                            ultraGridBand.Columns[column.Key].RowLayoutColumnInfo.ParentGroup.RowLayoutGroupInfo.OriginX = Convert.ToInt32(num * 2);
                            ultraGridBand.Groups[ultraGridGroup.Key].Header.Appearance.TextHAlign = AlignHeader;
                        }
                    }
                }
                else if (ultraGridBand.Columns[column.Key].RowLayoutColumnInfo.ParentGroup == null)
                {
                    ultraGridBand.Columns[column.Key].RowLayoutColumnInfo.OriginX = 2 * num;
                    ultraGridBand.Columns[column.Key].RowLayoutColumnInfo.SpanX = 2;
                    ultraGridBand.Columns[column.Key].RowLayoutColumnInfo.SpanY = 4;
                }
                num++;
            }
        }

        public void GridHeaderMergeVertical(UltraGrid Grid, string[] Columns, int nFirst, int nLast, HAlign AlignHeader = HAlign.Center)
        {
            UltraGridBand ultraGridBand = Grid.DisplayLayout.Bands[0];
            Grid.DisplayLayout.Bands[0].RowLayoutStyle = RowLayoutStyle.GroupLayout;
            for (int i = nFirst; i <= nLast; i++)
            {
                Columns[i] = Columns[i].ToUpper();
                ultraGridBand.Columns[Columns[i]].RowLayoutColumnInfo.OriginX = i * 2;
                ultraGridBand.Columns[Columns[i]].RowLayoutColumnInfo.OriginY = 0;
                ultraGridBand.Columns[Columns[i]].RowLayoutColumnInfo.SpanX = 2;
                ultraGridBand.Columns[Columns[i]].RowLayoutColumnInfo.SpanY = 4;
                ultraGridBand.Columns[Columns[i]].RowLayoutColumnInfo.LabelSpan = 4;
                ultraGridBand.Columns[Columns[i]].Header.Appearance.TextHAlign = AlignHeader;
            }
        }

        public void GridHeaderMergeVertical(UltraGrid Grid, int nFirst, int nLast, HAlign AlignHeader = HAlign.Center)
        {
            UltraGridBand ultraGridBand = Grid.DisplayLayout.Bands[0];
            Grid.DisplayLayout.Bands[0].RowLayoutStyle = RowLayoutStyle.GroupLayout;
            int num = 0;
            foreach (UltraGridColumn item in ultraGridBand.Columns.Cast<UltraGridColumn>())
            {
                if (num >= nFirst && num <= nLast)
                {
                    ultraGridBand.Columns[item.Key].RowLayoutColumnInfo.OriginX = num * 2;
                    ultraGridBand.Columns[item.Key].RowLayoutColumnInfo.OriginY = 0;
                    ultraGridBand.Columns[item.Key].RowLayoutColumnInfo.SpanX = 2;
                    ultraGridBand.Columns[item.Key].RowLayoutColumnInfo.SpanY = 4;
                    ultraGridBand.Columns[item.Key].RowLayoutColumnInfo.LabelSpan = 4;
                    ultraGridBand.Columns[item.Key].Header.Appearance.TextHAlign = AlignHeader;
                }
                num++;
            }
        }

        public void InitColumnUltraGrid(UltraGrid ultraGrid, string columnName, string caption, bool colNotNullable = false, GridColDataType_emu colDataType = GridColDataType_emu.VarChar, int columnWidth = 100, int maxLength = 0, HAlign HAlign = HAlign.Default, bool visible = true, bool editable = false, string formatString = "", string editMask = "", string maxValue = "", string minValue = "", string regexPattern = "")
        {
            try
            {
                columnName = columnName.ToUpper();
                if (caption != null)
                {
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns.Add(columnName, Common.getLangText(caption));
                }
                else
                {
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns.Add(columnName, columnName);
                }
                ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Hidden = !visible;
                ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MergedCellStyle = MergedCellStyle.Never;
                ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskClipMode = MaskMode.IncludeLiterals;
                ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskDisplayMode = MaskMode.IncludeLiterals;
                ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskDataMode = MaskMode.IncludeLiterals;
                if (ultraGrid.DisplayLayout.Override.AllowUpdate != DefaultableBoolean.True)
                {
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].CellActivation = Activation.NoEdit;
                }
                else if (!editable)
                {
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].CellActivation = Activation.NoEdit;
                }
                else
                {
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].CellActivation = Activation.AllowEdit;
                }
                SetUserDataGrid(ultraGrid, columnName, colNotNullable, colDataType, HAlign, caption, columnWidth, maxLength, formatString, editMask, maxValue, minValue, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "[" + ultraGrid.Name + "] " + columnName, "Grid Initiallizing Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void InitColumnUltraGrid(UltraGrid ultraGrid, string columnName, string caption, bool colNotNullable, GridColDataType_emu colDataType, int columnWidth, bool visible, bool editable)
        {
            InitColumnUltraGrid(ultraGrid, columnName, caption, colNotNullable, colDataType, columnWidth, 0, HAlign.Center, visible, editable);
        }

        public void SetUserDataGrid(UltraGrid ultraGrid, string columnName, bool colNotNullable, GridColDataType_emu colDataType, HAlign HAlign, string caption, int columnWidth, int maxLength, string formatString, string editMask, string maxValue, string minValue, string regexPattern)
        {
            if (formatString == null)
            {
                formatString = "";
            }
            if (editMask == null)
            {
                editMask = "";
            }
            if (maxValue == null)
            {
                maxValue = "";
            }
            if (minValue == null)
            {
                minValue = "";
            }
            switch (colDataType)
            {
                case GridColDataType_emu.DateTime24:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(DateTime);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "yyyy-mm-dd hh:mm:ss";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "yyyy-MM-dd HH:mm:ss";
                    break;
                case GridColDataType_emu.DateTime:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(DateTime);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "yyyy-mm-dd hh:mm:ss";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "yyyy-MM-dd tt hh:mm:ss";
                    break;
                case GridColDataType_emu.YearMonthDay:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(DateTime);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "yyyy-mm-dd";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "d";
                    break;
                case GridColDataType_emu.YearMonth:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(DateTime);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "yyyy-mm";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "yyyy-MM";
                    break;
                case GridColDataType_emu.Year:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(short);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "nnnn";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "yyyy";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaxLength = 4;
                    break;
                case GridColDataType_emu.VarChar:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(string);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
                    break;
                case GridColDataType_emu.Currency:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(decimal);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "c";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "-n,nnn,nnn,nnn,nnn,nnn,nnn,nnn,nnn,nnn";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaxLength = 29;
                    break;
                case GridColDataType_emu.CurrencyNonNegative:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(decimal);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CurrencyNonNegative;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "c";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "n,nnn,nnn,nnn,nnn,nnn,nnn,nnn,nnn,nnn";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaxLength = 29;
                    break;
                case GridColDataType_emu.CurrencyPositive:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(decimal);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CurrencyPositive;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "c";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "n,nnn,nnn,nnn,nnn,nnn,nnn,nnn,nnn,nnn";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaxLength = 29;
                    break;
                case GridColDataType_emu.Double:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(double);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Double;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "#,###,##0.#####";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "#,###,##0.#####";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaxLength = 29;
                    break;
                case GridColDataType_emu.DoubleNonNegative:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(double);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoubleNonNegative;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "#,###,##0.#####";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "#,###,##0.#####";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaxLength = 29;
                    break;
                case GridColDataType_emu.DoublePositive:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(double);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "#,###,##0.#####";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "#,###,##0.#####";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaxLength = 29;
                    break;
                case GridColDataType_emu.Integer:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(int);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "#,###,###";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaxLength = 29;
                    break;
                case GridColDataType_emu.IntegerNonNegative:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(int);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegative;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "#,###,###";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaxLength = 29;
                    break;
                case GridColDataType_emu.IntegerPositive:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(int);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerPositive;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "#,###,###";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaxLength = 29;
                    break;
                case GridColDataType_emu.CheckBox:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(bool);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    UltraGridColumn ultraGridColumn = ultraGrid.DisplayLayout.Bands[0].Columns[columnName];
                    ultraGridColumn.Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;
                    break;
                case GridColDataType_emu.Image:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(Bitmap);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(byte[]);
                    break;
                case GridColDataType_emu.Button:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(string);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].CellAppearance.TextHAlign = HAlign.Center;
                    break;
                case GridColDataType_emu.Color:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(Color);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Color;
                    break;
                case GridColDataType_emu.Font:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(string);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Font;
                    break;
                case GridColDataType_emu.TimeWithSpin:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(DateTime);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.TimeWithSpin;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "hh:mm:ss";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "tt hh:mm:ss";
                    break;
                case GridColDataType_emu.Time24WithSpin:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(DateTime);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.TimeWithSpin;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "hh:mm:ss";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = "HH:mm:ss";
                    break;
                case GridColDataType_emu.URL:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(string);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.URL;
                    break;
                case GridColDataType_emu.TrackBar:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(int);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.TrackBar;
                    break;
                case GridColDataType_emu.Phone:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(string);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "(###) ###-####";
                    break;
                case GridColDataType_emu.HandPhone:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(string);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "###-####-####";
                    break;
                case GridColDataType_emu.IPv4Address:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(string);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "nnn\\.nnn\\.nnn\\.nnn";
                    break;
                case GridColDataType_emu.Explain:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(string);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
                    break;
                case GridColDataType_emu.Float:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].DataType = typeof(float);
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Double;
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = "n,nnn,nnn,nnn,nnn,nnn,nnn,nnn.nnnnnn";
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaxLength = 29;
                    break;
            }

            if (formatString != "")
            {
                ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Format = formatString;
            }
            if (maxLength != -1)
            {
                ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaxLength = maxLength;
            }
            if (editMask != "")
            {
                ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaskInput = editMask;
            }
            if (maxValue != "")
            {
                ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MaxValue = maxValue;
            }
            if (minValue != "")
            {
                ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].MinValue = minValue;
            }

            switch (columnWidth)
            {
                case 0:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Hidden = true;
                    break;
                default:
                    ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Width = columnWidth;
                    break;
                case -1:
                    break;
            }


            ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Header.Appearance.TextHAlign = HAlign.Center;
            ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].CellAppearance.TextHAlign = HAlign;

            string tag = columnName + "|" + (colNotNullable ? "NN" : "") + "|" + colDataType.ToString() + "|" + maxLength + "|" + maxValue + "|" + minValue + "|" + caption + "|" + columnWidth.ToString();
            ultraGrid.DisplayLayout.Bands[bandIndex].Columns[columnName].Tag = tag;
        }

        public void InitColumnUltraTreeGrid(UltraGrid ultraGrid, string columnName, string caption, int bandIdx, bool visible, bool editable, int columnWidth, HAlign dataAlign)
        {
            if (ultraGrid.DisplayLayout.Bands.Count <= bandIdx)
            {
                throw new Exception(Common.getLangText("bandIdx는 bandCount보다 같거나 클 수 없습니다"));
            }
            if (ultraGrid.DisplayLayout.Bands[bandIdx].Columns[columnName] == null)
            {
                throw new Exception(Common.getLangText("존재하지 않는 컬럼명입니다"));
            }
            ultraGrid.DisplayLayout.Bands[bandIdx].Columns[columnName].Header.Caption = caption;
            ultraGrid.DisplayLayout.Bands[bandIdx].Columns[columnName].Header.Appearance.TextHAlign = HAlign.Center;
            ultraGrid.DisplayLayout.Bands[bandIdx].Columns[columnName].Hidden = !visible;
            if (editable)
            {
                ultraGrid.DisplayLayout.Bands[bandIdx].Columns[columnName].CellActivation = Activation.AllowEdit;
            }
            else
            {
                ultraGrid.DisplayLayout.Bands[bandIdx].Columns[columnName].CellActivation = Activation.NoEdit;
            }
            switch (columnWidth)
            {
                case 0:
                    ultraGrid.DisplayLayout.Bands[bandIdx].Columns[columnName].Hidden = true;
                    break;
                default:
                    ultraGrid.DisplayLayout.Bands[bandIdx].Columns[columnName].Width = columnWidth;
                    break;
                case -1:
                    break;
            }
            ultraGrid.DisplayLayout.Bands[bandIdx].Columns[columnName].CellAppearance.TextHAlign = dataAlign;
        }

        public void SetColumnTextHAlign(UltraGrid ultraGrid, string columnName, HAlign hAlign)
        {
            string[] array = columnName.Split(',');
            string text = "";
            if (array.Length != 0)
            {
                foreach (UltraGridBand band in ultraGrid.DisplayLayout.Bands)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        text = array[i].ToString();
                        if (band.Columns.Exists(text))
                        {
                            band.Columns[text].CellAppearance.TextHAlign = hAlign;
                        }
                    }
                }
            }
        }

        public void SetInitUltraGridBind(UltraGrid ultraGrid)
        {
            DataTable dataTable = new DataTable("temptable");
            for (int i = 0; i < ultraGrid.DisplayLayout.Bands[bandIndex].Columns.Count; i++)
            {
                dataTable.Columns.Add(ultraGrid.DisplayLayout.Bands[bandIndex].Columns[i].Key.ToString(), ultraGrid.DisplayLayout.Bands[bandIndex].Columns[i].DataType);
            }
            ultraGrid.DataSource = dataTable;
            SetGridDataCopy(ultraGrid);
            try
            {
                MethodInfo method = ultraGrid.GetType().GetMethod("setUserColumn");
                method.Invoke(ultraGrid, null);
            }
            catch
            {
            }
        }

        public static void SetGridDataCopy(UltraGrid ultraGrid)
        {
            ultraGrid.DisplayLayout.Override.AllowMultiCellOperations = (AllowMultiCellOperation.Copy | AllowMultiCellOperation.Cut | AllowMultiCellOperation.Paste);
        }

        public void ExportExcel(UltraGrid ultraGrid)
        {
            UltraGridExcelExporter ultraGridExcelExporter = new UltraGridExcelExporter();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "Excel Files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ultraGridExcelExporter.Export(ultraGrid, saveFileDialog.FileName);
            }
        }

        public void ColumnHeaderGroup(UltraGrid ultraGrid, string groupKey, string groupCaption, string columnNames)
        {
            if (!ultraGrid.DisplayLayout.Bands[bandIndex].Groups.Exists(groupKey))
            {
                ultraGrid.DisplayLayout.Bands[bandIndex].Groups.Add(groupKey, groupCaption);
            }
            ultraGrid.DisplayLayout.Bands[bandIndex].Groups[groupKey].Header.Appearance.TextHAlign = HAlign.Center;
            ultraGrid.DisplayLayout.Bands[bandIndex].GroupHeadersVisible = true;
            string[] array = columnNames.Split(',');
            if (array.Length == 0)
            {
                return;
            }
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i].Trim();
                if (text != "" && text != null && ultraGrid.DisplayLayout.Bands[bandIndex].Columns.Exists(text))
                {
                    ultraGrid.DisplayLayout.Bands[bandIndex].Groups[groupKey].Columns.Add(ultraGrid.DisplayLayout.Bands[bandIndex].Columns[text]);
                }
            }
        }

        public void SetColumnMerge(Form form, UltraGrid ultraGrid, string columnName)
        {
            ultraGrid.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.Always;
            ultraGrid.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
            ultraGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            ultraGrid.DisplayLayout.Override.MergedCellAppearance.BackColor = Color.LightYellow;
            string[] array = columnName.Split(',');
            string text = "";
            if (array.Length != 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    text = array[i].ToString();
                    foreach (UltraGridBand band in ultraGrid.DisplayLayout.Bands)
                    {
                        if (band.Columns.Exists(text))
                        {
                            band.Columns[text].MergedCellStyle = MergedCellStyle.Always;
                        }
                    }
                }
            }
        }

        public static DataColumnCollection GetColumns(Form form, DataTable dtData)
        {
            return dtData.Columns;
        }

        public int AddRow(UltraGrid ultraGrid, DataTable dtTable = null, bool bNewLine = false)
        {
            int num = 0;
            if (dtTable == null)
            {
                if (ultraGrid.DataSource.GetType().Name.ToUpper() == "DATATABLE")
                {
                    dtTable = (DataTable)ultraGrid.DataSource;
                }
                else
                {
                    num = ((DataSet)ultraGrid.DataSource).Tables.Count - 1;
                    dtTable = ((DataSet)ultraGrid.DataSource).Tables[num];
                }
            }
            int num2 = 0;
            int num3 = 0;
            if (bNewLine)
            {
                num2 = ultraGrid.Rows.Count;
            }
            else if (ultraGrid.ActiveRow == null || ultraGrid.Rows.Count == 0)
            {
                num2 = 0;
                num3 = 0;
            }
            else
            {
                num2 = ultraGrid.ActiveRow.Index + 1;
                if (num == 0)
                {
                    num3 = num2;
                }
                else
                {
                    string b = ultraGrid.ActiveRow.Cells["ROWSEQ"].Value.ToString();
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        if (dtTable.Rows[i]["ROWSEQ"].ToString() == b)
                        {
                            num3 = i + 1;
                            break;
                        }
                    }
                }
            }
            DataRow dataRow = dtTable.NewRow();
            try
            {
                MethodInfo method = ultraGrid.GetType().GetMethod("GetLastRow");
                dataRow["rowSeq"] = method.Invoke(ultraGrid, null);
                if (ultraGrid.ActiveRow != null)
                {
                    method = ultraGrid.GetType().GetMethod("SetNewRow");
                    method.Invoke(ultraGrid, new object[2]
                    {
                        ultraGrid.ActiveRow,
                        dataRow
                    });
                }
                dtTable.Rows.InsertAt(dataRow, num3);
                if (num == 0)
                {
                    foreach (UltraGridRow row in ultraGrid.Rows)
                    {
                        if (row.Cells["rowSeq"].Value.ToString() == dataRow["rowSeq"].ToString())
                        {
                            ultraGrid.ActiveRow = row;
                            break;
                        }
                    }
                }
                else
                {
                    method = ultraGrid.GetType().GetMethod("GetUltraGridRow");
                    ultraGrid.ActiveRow = (UltraGridRow)method.Invoke(ultraGrid, new object[1]
                    {
                        num3
                    });
                }
            }
            catch
            {
            }
            return num3;
        }

        public static void DeleteCurrentRowGrid(Form form, UltraGrid ultraGrid, DataTable dtTable)
        {
            if (ultraGrid.ActiveRow != null)
            {
                ultraGrid.ActiveRow.Appearance.BackColor = Color.Red;
            }
        }

        public static void DataRowDelete(UltraGrid ultraGrid)
        {
            for (int i = 0; i < ultraGrid.Rows.Count; i++)
            {
                if (ultraGrid.Rows[i].Appearance.BackColor == Color.Red)
                {
                    ultraGrid.Rows[i].Delete(displayPrompt: false);
                    i--;
                }
            }
        }

        public static void GridRowDelete(UltraGrid ultraGrid, int iRow)
        {
            ultraGrid.Rows[iRow].Delete(displayPrompt: false);
        }

        public static void ActivationAllowEdit(UltraGrid ultraGrid, string ColumnName, int dtRowNum = -1)
        {
            UltraGridRow ultraGridRow = null;
            if (dtRowNum == -1)
            {
                ultraGridRow = ultraGrid.ActiveRow;
            }
            else
            {
                MethodInfo method = ultraGrid.GetType().GetMethod("GetUltraGridRow");
                ultraGridRow = (UltraGridRow)method.Invoke(ultraGrid, new object[1]
                {
                    dtRowNum
                });
            }
            if (ultraGridRow != null)
            {
                ultraGridRow.Cells[ColumnName].IgnoreRowColActivation = true;
                ultraGridRow.Cells[ColumnName].Activation = Activation.AllowEdit;
            }
        }

        public static void SetComboUltraGrid(UltraGrid ultraGrid, string columnName, object dtInData, string valueFieldName, string displayFieldName)
        {
            ValueList valueList = ultraGrid.DisplayLayout.ValueLists.Add();
            DataTable dataTable = (DataTable)dtInData;
            try
            {
                if (dataTable.Rows.Count != 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        valueList.ValueListItems.Add(dataTable.Rows[i][valueFieldName].ToString(), dataTable.Rows[i][displayFieldName].ToString());
                    }
                    foreach (UltraGridBand band in ultraGrid.DisplayLayout.Bands)
                    {
                        if (band.Columns.Exists(columnName))
                        {
                            ultraGrid.DisplayLayout.Bands[band.Index].Columns[columnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnRowActivate;
                            ultraGrid.DisplayLayout.Bands[band.Index].Columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                            ultraGrid.DisplayLayout.Bands[band.Index].Columns[columnName].ValueList = valueList;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Common.getLangText("{0}에 Combo 데이타 구성중 오류가 발생 하였습니다."), columnName), Common.getLangText("확인"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static DataTable SetSubTotalUltraGrid(UltraGrid objectGrid, DataTable SetDatatable, string ColunmGroupKey, string TitleName, string TitleColumn, string SubTotalColumn, string calculationType)
        {
            DataTable dataTable = SetDatatable.Clone();

            try
            {
                DataTable dataTable2 = SetDatatable.DefaultView.ToTable(true, ColunmGroupKey);
                DataTable[] array = new DataTable[dataTable2.Rows.Count];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = SetDatatable.Clone();
                }
                for (int j = 0; j < dataTable2.Rows.Count; j++)
                {
                    DataRow dataRow = array[j].NewRow();
                    for (int k = 0; k < SetDatatable.Rows.Count; k++)
                    {
                        dataRow = array[j].NewRow();
                        if (dataTable2.Rows[j][ColunmGroupKey].ToString() == SetDatatable.Rows[k][ColunmGroupKey].ToString())
                        {
                            array[j].ImportRow(SetDatatable.Rows[k]);
                        }
                    }
                    dataRow = array[j].NewRow();
                    dataRow[TitleColumn] = TitleName;
                    string[] array2 = SubTotalColumn.ToString().Trim().Split(',');
                    string[] array3 = calculationType.ToString().Trim().Split(',');
                    for (int l = 0; l < array2.Length; l++)
                    {
                        dataRow[array2[l]] = array[j].Compute(array3[l] + "(" + array2[l] + ")", string.Empty);
                    }
                    array[j].Rows.Add(dataRow);
                }
                for (int m = 0; m < array.Length; m++)
                {
                    for (int l = 0; l < array[m].Rows.Count; l++)
                    {
                        dataTable.ImportRow(array[m].Rows[l]);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dataTable;
        }



        public static DataTable SetSubTotalUltraGrid_UP(UltraGrid objectGrid, DataTable SetDatatable, string ColunmGroupKey, string TitleName, string TitleColumn, string SubTotalColumn, string calculationType)
        {
            DataTable dataTable = SetDatatable.Clone();
            DataTable dataTable2 = SetDatatable.DefaultView.ToTable(true, ColunmGroupKey);
            DataTable[] array = new DataTable[dataTable2.Rows.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = SetDatatable.Clone();
            }
            for (int j = 0; j < dataTable2.Rows.Count; j++)
            {
                DataRow dataRow = array[j].NewRow();
                for (int k = 0; k < SetDatatable.Rows.Count; k++)
                {
                    dataRow = array[j].NewRow();
                    if (dataTable2.Rows[j][ColunmGroupKey].ToString() == SetDatatable.Rows[k][ColunmGroupKey].ToString())
                    {
                        array[j].ImportRow(SetDatatable.Rows[k]);
                    }
                }
                dataRow = array[j].NewRow();
                dataRow[TitleColumn] = TitleName;
                string[] array2 = SubTotalColumn.ToString().Trim().Split(',');
                string[] array3 = calculationType.ToString().Trim().Split(',');
                for (int l = 0; l < array2.Length; l++)
                {
                    dataRow[array2[l]] = array[j].Compute(array3[l] + "(" + array2[l] + ")", string.Empty);
                }
                array[j].Rows.InsertAt(dataRow, 0);
            }
            for (int m = 0; m < array.Length; m++)
            {
                for (int l = 0; l < array[m].Rows.Count; l++)
                {
                    dataTable.ImportRow(array[m].Rows[l]);
                }
            }
            return dataTable;
        }

        public static bool CheckSearchDataGrid(Form form, UltraGrid ultraGrid, DataTable dtTable = null, bool messageDisplay = false)
        {
            bool flag = false;
            ultraGrid.EndUpdate();
            if (dtTable == null)
            {
                if (ultraGrid.DataSource.GetType().Name.ToUpper() == "DATATABLE")
                {
                    dtTable = (DataTable)ultraGrid.DataSource;
                }
                else
                {
                    int index = ((DataSet)ultraGrid.DataSource).Tables.Count - 1;
                    dtTable = ((DataSet)ultraGrid.DataSource).Tables[index];
                }
            }
            RemoveGarbageRowsGrid(form, ultraGrid, dtTable);
            ((CurrencyManager)form.BindingContext[ultraGrid.DataSource, ultraGrid.DataMember]).EndCurrentEdit();
            DataTable changes = dtTable.GetChanges();
            flag = FindDeleteFlagRow(ultraGrid);
            if (changes == null && !flag)
            {
                return false;
            }
            return true;
        }

        public static bool CheckSaveDataGrid(Form form, UltraGrid ultraGrid, DataTable dtTable = null, bool messageDisplay = true)
        {
            bool flag = false;
            ultraGrid.EndUpdate();
            if (dtTable == null)
            {
                if (ultraGrid.DataSource.GetType().Name.ToUpper() == "DATATABLE")
                {
                    dtTable = (DataTable)ultraGrid.DataSource;
                }
                else
                {
                    int index = ((DataSet)ultraGrid.DataSource).Tables.Count - 1;
                    dtTable = ((DataSet)ultraGrid.DataSource).Tables[index];
                }
            }
            RemoveGarbageRowsGrid(form, ultraGrid, dtTable);
            ((CurrencyManager)form.BindingContext[ultraGrid.DataSource, ultraGrid.DataMember]).EndCurrentEdit();
            DataTable changes = dtTable.GetChanges();
            flag = FindDeleteFlagRow(ultraGrid);
            if (changes == null && !flag)
            {
                return false;
            }
            if (!flag || changes != null)
            {
                int num = -1;
                int num2 = -1;
                foreach (DataRow row in changes.Rows)
                {
                    num++;
                    if (row.RowState != DataRowState.Deleted)
                    {
                        foreach (DataColumn column in changes.Columns)
                        {
                            num2++;
                            object obj = row[column.ColumnName];
                            if (ultraGrid.DisplayLayout.Bands[bandIndex].Columns[column.ColumnName].Tag.ToString() != "" && !CheckNullGrid(ultraGrid, row, column))
                            {
                                ultraGrid.Rows[num].Selected = true;
                                ultraGrid.Rows[num].Cells[num2].Selected = true;
                                ultraGrid.Focus();
                                return false;
                            }
                            if (!CheckDataValidationGrid(ultraGrid, row, column))
                            {
                                ultraGrid.Rows[num].Selected = true;
                                ultraGrid.Rows[num].Cells[num2].Selected = true;
                                ultraGrid.Focus();
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public static void RemoveGarbageRowsGrid(Form form, UltraGrid ultraGrid, DataTable dtTable = null)
        {
            ultraGrid.EndUpdate();
            if (dtTable == null)
            {
                if (ultraGrid.DataSource.GetType().Name.ToUpper() == "DATATABLE")
                {
                    dtTable = (DataTable)ultraGrid.DataSource;
                }
                else
                {
                    int index = ((DataSet)ultraGrid.DataSource).Tables.Count - 1;
                    dtTable = ((DataSet)ultraGrid.DataSource).Tables[index];
                }
            }
            ((CurrencyManager)form.BindingContext[ultraGrid.DataSource, ultraGrid.DataMember]).EndCurrentEdit();
            int num = 0;
            for (int num2 = ultraGrid.Rows.Count - 1; num2 >= 0; num2--)
            {
                num = ultraGrid.Rows[num2].ListIndex;
                if (num >= 0 && dtTable.Rows[num].RowState == DataRowState.Detached && (GetRowHeaderFlag(ultraGrid, num2) == "" || GetRowHeaderFlag(ultraGrid, num2) == GridBase.RowHeaderFlag.MARK_DELETE))
                {
                    dtTable.Rows[num].Delete();
                }
            }
        }

        private static bool FindDeleteFlagRow(UltraGrid ultraGrid)
        {
            int num = 0;
            for (int i = 0; i < ultraGrid.Rows.Count; i++)
            {
                if (ultraGrid.Rows[i].Tag != null && ultraGrid.Rows[i].Tag.ToString() == GridBase.RowHeaderFlag.MARK_DELETE)
                {
                    num++;
                }
            }
            if (num == 0)
            {
                return false;
            }
            return true;
        }

        private static bool CheckNullGrid(UltraGrid ultraGrid, DataRow curRow, DataColumn curColumn)
        {
            if (!GetUserDataNotNullString(ultraGrid.DisplayLayout.Bands[bandIndex].Columns[curColumn.ColumnName].Tag.ToString()).ToString().ToUpper().Equals("NN") || (!curRow[curColumn.ColumnName].Equals(null) && !curRow[curColumn.ColumnName].Equals(DBNull.Value) && !curRow[curColumn.ColumnName].ToString().Equals("")))
            {
                return true;
            }
            MessageBox.Show(string.Format(Common.getLangText("[ {0} ] 항목은 필수입력 항목 입니다."), ultraGrid.DisplayLayout.Bands[bandIndex].Columns[curColumn.ColumnName].Header.Caption), Common.getLangText("필수항목"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return false;
        }

        private static bool CheckDataValidationGrid(UltraGrid ultraGrid, DataRow curRow, DataColumn curColumn)
        {
            string[] array = ultraGrid.DisplayLayout.Bands[bandIndex].Columns[curColumn.ColumnName].Tag.ToString().Split('|');
            string caption = curColumn.Caption;
            if (array.Length > 1)
            {
                object obj = curRow[curColumn.ColumnName];
                array[1].ToString().ToUpper();
                string text = array[2].ToUpper();
                int maxLength = int.Parse(array[3].ToString());
                object obj2 = array[4];
                object obj3 = array[5];
                switch (text)
                {
                    case "DATE":
                        {
                            string text3 = ((DateTime)obj).ToString("yyyyMMdd");
                            if (FnUtil.isDate(text3))
                            {
                                if (!FnUtil.isDate(obj3.ToString()))
                                {
                                    MessageBox.Show(string.Format(Common.getLangText("설정된 최소값 [{0}] 이 올바른 날짜 형식이 아닙니다."), obj3), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                                if (!obj3.ToString().Equals("") && !FnUtil.CheckDateMinValue(text3, obj3.ToString()))
                                {
                                    MessageBox.Show(string.Format(Common.getLangText("[{0}] 의 최소값은 [{1}] 이어야 합니다.\r\n☞입력값 [{2}]"), caption, obj3.ToString(), text3.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                                if (!FnUtil.isDate(obj2.ToString()))
                                {
                                    MessageBox.Show(string.Format(Common.getLangText("설정된 최대값 [{0}] 이 올바른 날짜 형식이 아닙니다."), obj2), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                                if (obj2.ToString().Equals("") || FnUtil.CheckDateMaxValue(text3, obj2.ToString()))
                                {
                                    break;
                                }
                                MessageBox.Show(string.Format(Common.getLangText("[{0}] 의 최대값은 [{1}] 이어야 합니다.\r\n☞입력값 [{2}]"), caption, obj2.ToString(), text3.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                            MessageBox.Show(string.Format(Common.getLangText("[{0}] 는 올바른 날짜 형식이 아닙니다.\r\n☞입력값 [{1}]"), caption, text3.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    case "YEARMONTH":
                        {
                            string text4 = ((DateTime)obj).ToString("yyyyMM");
                            string date2 = ((DateTime)obj).ToString("yyyyMM") + "01";
                            if (FnUtil.isDate(date2))
                            {
                                if (!FnUtil.isDate(obj3.ToString() + "01"))
                                {
                                    MessageBox.Show(string.Format(Common.getLangText("설정된 최소값 [{0}] 이 올바른 날짜 형식이 아닙니다."), obj3), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                                if (!obj3.ToString().Equals("") && !FnUtil.CheckDateMinValue(date2, obj3.ToString()))
                                {
                                    MessageBox.Show(string.Format(Common.getLangText("[{0}] 의 최소값은 [{1}] 이어야 합니다.\r\n☞입력값 [{2}]"), caption, obj3.ToString(), text4.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                                if (!FnUtil.isDate(obj2.ToString() + "01"))
                                {
                                    MessageBox.Show(string.Format(Common.getLangText("설정된 최대값 [{0}] 이 올바른 날짜 형식이 아닙니다."), obj2), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                                if (obj2.ToString().Equals("") || FnUtil.CheckDateMaxValue(date2, obj2.ToString()))
                                {
                                    break;
                                }
                                MessageBox.Show(string.Format(Common.getLangText("[{0}] 의 최대값은 [{1}] 이어야 합니다.\r\n☞입력값 [{2}]"), caption, obj2.ToString(), text4.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                            MessageBox.Show(string.Format(Common.getLangText("[{0}] 는 올바른 날짜 형식이 아닙니다.\r\n☞입력값 [{1}]"), caption, text4.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    case "YEAR":
                        {
                            string text2 = ((DateTime)obj).ToString("yyyy");
                            string date = ((DateTime)obj).ToString("yyyy") + "0101";
                            if (FnUtil.isDate(date))
                            {
                                if (!FnUtil.isDate(obj3.ToString() + "0101"))
                                {
                                    MessageBox.Show(string.Format(Common.getLangText("설정된 최소값 [{0}] 이 올바른 날짜 형식이 아닙니다."), obj3), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                                if (!obj3.ToString().Equals("") && !FnUtil.CheckDateMinValue(date, obj3.ToString()))
                                {
                                    MessageBox.Show(string.Format(Common.getLangText("[{0}] 의 최소값은 [{1}] 이어야 합니다.\r\n☞입력값 [{2}]"), caption, obj3.ToString(), text2.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                                if (!FnUtil.isDate(obj2.ToString() + "0101"))
                                {
                                    MessageBox.Show(string.Format(Common.getLangText("설정된 최대값 [{0}] 이 올바른 날짜 형식이 아닙니다."), obj2), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                                if (obj2.ToString().Equals("") || FnUtil.CheckDateMaxValue(date, obj2.ToString()))
                                {
                                    break;
                                }
                                MessageBox.Show(string.Format(Common.getLangText("[{0}] 의 최대값은 [{1}] 이어야 합니다.\r\n☞입력값 [{2}]"), caption, obj2.ToString(), text2.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                            MessageBox.Show(string.Format(Common.getLangText("[{0}] 는 올바른 날짜 형식이 아닙니다.\r\n☞입력값 [{1}]"), caption, text2.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    case "VARCHAR":
                        if (!(maxLength.ToString() != "") || int.Parse(maxLength.ToString()) <= 0 || FnUtil.ChekcStringMaxLength(obj.ToString(), maxLength))
                        {
                            break;
                        }
                        MessageBox.Show(string.Format(Common.getLangText("[{0}]의 데이터 길이는 {1}를 초과할 수 없습니다.\r\n☞입력값 [{2}]"), curColumn.Caption, maxLength.ToString(), obj.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    case "NUMBER":
                        if (FnUtil.isInt(obj.ToString()))
                        {
                            if (maxLength.ToString() != "" && int.Parse(maxLength.ToString()) > 0 && !FnUtil.ChekcStringMaxLength(obj.ToString(), maxLength))
                            {
                                MessageBox.Show(string.Format(Common.getLangText("[{0}]의 데이터 길이는 {1}를 초과할 수 없습니다.\r\n☞입력값 [{2}]"), curColumn.Caption, maxLength.ToString(), obj.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                            if (obj3.ToString() != "" && !FnUtil.CheckDataMinValue(obj.ToString(), obj3.ToString()))
                            {
                                MessageBox.Show(string.Format(Common.getLangText("[{0}]의 데이터는 {1}와 같거나 커야 합니다.\r\n☞입력값 [{2}]"), curColumn.Caption, obj3.ToString(), obj.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                            if (!(obj2.ToString() != "") || FnUtil.CheckDataMaxValue(obj.ToString(), obj2.ToString()))
                            {
                                break;
                            }
                            MessageBox.Show(string.Format(Common.getLangText("[{0}]의 데이터는{1}를 초과할 수 없습니다.\r\n☞입력값 [{2}]"), curColumn.Caption, obj2.ToString(), obj.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                        MessageBox.Show(string.Format(Common.getLangText("[{0}]의 데이터는 정수만을 허용합니다.\r\n☞입력값 [{1}]"), curColumn.Caption, obj.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    case "DECIMAL":
                        if (FnUtil.isDecimal(obj.ToString()))
                        {
                            if (maxLength.ToString() != "" && int.Parse(maxLength.ToString()) > 0 && !FnUtil.ChekcStringMaxLength(obj.ToString(), maxLength))
                            {
                                MessageBox.Show(string.Format(Common.getLangText("[{0}]의 데이터 길이는 {1}를 초과할 수 없습니다.\r\n☞입력값 [{2}]"), curColumn.Caption, maxLength.ToString(), obj.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                            if (obj3.ToString() != "" && !FnUtil.CheckDataMinValue(obj.ToString(), obj3.ToString()))
                            {
                                MessageBox.Show(string.Format(Common.getLangText("[{0}]의 데이터는 {1}와 같거나 커야 합니다.\r\n☞입력값 [{2}]"), curColumn.Caption, obj3.ToString(), obj.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                            if (obj2.ToString() != "" && !FnUtil.CheckDataMaxValue(obj.ToString(), obj2.ToString()))
                            {
                                MessageBox.Show(string.Format(Common.getLangText("[{0}]의 데이터는 {1}를 초과할 수 없습니다.\r\n☞입력값 [{2}]"), curColumn.Caption, obj2.ToString(), obj.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                            break;
                        }
                        MessageBox.Show(string.Format(Common.getLangText("[{0}]의 데이터는 Decimal 형식을 허용합니다.\r\n☞입력값 [{1}]"), curColumn.Caption, obj.ToString()), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                }
            }
            return true;
        }

        public static string GetRowHeaderFlag(UltraGrid ultraGrid, int rowIndex)
        {
            if (ultraGrid.Rows.Count > 0)
            {
                if (ultraGrid.ActiveRow == null)
                {
                    return "";
                }
                if (ultraGrid.Rows[rowIndex].Tag != null && !(ultraGrid.Rows[rowIndex].Tag.ToString() == ""))
                {
                    return ultraGrid.Rows[rowIndex].Tag.ToString();
                }
            }
            return "";
        }

        private static string GetUserDataNotNullString(string userData)
        {
            try
            {
                string[] array = userData.Split('|');
                if (array.Length == 0)
                {
                    return "";
                }
                return array[1].Trim();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void ColumnHeaderVisible(UltraGrid ultraGrid, bool visible)
        {
            foreach (UltraGridBand band in ultraGrid.DisplayLayout.Bands)
            {
                if (band.Index > 0)
                {
                    band.ColHeadersVisible = visible;
                }
            }
        }

        public void Grid_Clear(UltraGrid gGrid)
        {
            DataTable dataTable = null;
            dataTable = (DataTable)gGrid.DataSource;
            if (dataTable != null)
            {
                dataTable.Clear();
            }
            gGrid.DataSource = dataTable;
            gGrid.DataBind();
        }

        public void SetHeadForeColor(UltraGrid ultraGrid, string ColunmName, Color HeadForeColor)
        {
            ultraGrid.DisplayLayout.Bands[0].Columns[ColunmName].Header.Appearance.ForeColor = HeadForeColor;
        }

        public void SetHeadColumnBold(UltraGrid ultraGrid, string ColumnHeadName)
        {
            ultraGrid.DisplayLayout.Bands[0].Columns[ColumnHeadName].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
        }
    }
}

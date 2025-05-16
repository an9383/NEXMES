namespace WIZ.PP
{
    partial class TT1060
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement1 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
            Infragistics.UltraChart.Resources.Appearance.GradientEffect gradientEffect1 = new Infragistics.UltraChart.Resources.Appearance.GradientEffect();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            this.CboStartdate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblDate = new WIZ.Control.SLabel();
            this.CboEnddate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.sLabel1 = new WIZ.Control.SLabel();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.chart = new WIZ.Control.Chart(this.components);
            this.lblPlc = new WIZ.Control.SLabel();
            this.lblPlc2 = new WIZ.Control.SLabel();
            this.sLabel4 = new WIZ.Control.SLabel();
            this.lblResult = new WIZ.Control.SLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.cbo_plc2 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbo_plc = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbo_result = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartdate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEnddate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_plc2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_plc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_result)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cbo_result);
            this.gbxHeader.Controls.Add(this.cbo_plc2);
            this.gbxHeader.Controls.Add(this.cbo_plc);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.button1);
            this.gbxHeader.Controls.Add(this.lblResult);
            this.gbxHeader.Controls.Add(this.sLabel4);
            this.gbxHeader.Controls.Add(this.lblPlc2);
            this.gbxHeader.Controls.Add(this.lblPlc);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Controls.Add(this.CboStartdate_H);
            this.gbxHeader.Controls.Add(this.lblDate);
            this.gbxHeader.Controls.Add(this.CboEnddate_H);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Size = new System.Drawing.Size(1275, 90);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboEnddate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboStartdate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlc, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlc2, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel4, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblResult, 0);
            this.gbxHeader.Controls.SetChildIndex(this.button1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_plc, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_plc2, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_result, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Controls.Add(this.ultraSplitter1);
            this.gbxBody.Controls.Add(this.chart);
            this.gbxBody.Location = new System.Drawing.Point(0, 90);
            this.gbxBody.Size = new System.Drawing.Size(1275, 735);
            this.gbxBody.TabIndex = 0;
            // 
            // CboStartdate_H
            // 
            this.CboStartdate_H.DateButtons.Add(dateButton1);
            this.CboStartdate_H.Location = new System.Drawing.Point(146, 50);
            this.CboStartdate_H.Name = "CboStartdate_H";
            this.CboStartdate_H.NonAutoSizeHeight = 26;
            this.CboStartdate_H.Size = new System.Drawing.Size(123, 26);
            this.CboStartdate_H.TabIndex = 3;
            this.CboStartdate_H.Value = new System.DateTime(2013, 12, 26, 0, 0, 0, 0);
            // 
            // lblDate
            // 
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance1;
            this.lblDate.DbField = "cboUseFlag";
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(51, 51);
            this.lblDate.Name = "lblDate";
            this.lblDate.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDate.Size = new System.Drawing.Size(90, 25);
            this.lblDate.TabIndex = 149;
            this.lblDate.Text = "생산일자";
            // 
            // CboEnddate_H
            // 
            this.CboEnddate_H.DateButtons.Add(dateButton2);
            this.CboEnddate_H.Location = new System.Drawing.Point(298, 50);
            this.CboEnddate_H.Name = "CboEnddate_H";
            this.CboEnddate_H.NonAutoSizeHeight = 26;
            this.CboEnddate_H.Size = new System.Drawing.Size(121, 26);
            this.CboEnddate_H.TabIndex = 4;
            this.CboEnddate_H.Value = new System.DateTime(2013, 12, 26, 0, 0, 0, 0);
            // 
            // sLabel1
            // 
            appearance6.TextHAlignAsString = "Right";
            appearance6.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance6;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(274, 52);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(16, 23);
            this.sLabel1.TabIndex = 152;
            this.sLabel1.Text = "~";
            // 
            // lblPlantCode
            // 
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance4;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(51, 15);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(90, 25);
            this.lblPlantCode.TabIndex = 239;
            this.lblPlantCode.Text = "공장";
            // 
            // ultraSplitter1
            // 
            this.ultraSplitter1.BackColor = System.Drawing.Color.White;
            this.ultraSplitter1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button;
            this.ultraSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraSplitter1.Location = new System.Drawing.Point(6, 252);
            this.ultraSplitter1.Name = "ultraSplitter1";
            this.ultraSplitter1.RestoreExtent = 453;
            this.ultraSplitter1.Size = new System.Drawing.Size(1263, 14);
            this.ultraSplitter1.TabIndex = 4;
            // 
            // grid1
            // 
            this.grid1.AutoResizeColumn = true;
            this.grid1.AutoUserColumn = true;
            this.grid1.ContextMenuCopyEnabled = true;
            this.grid1.ContextMenuDeleteEnabled = true;
            this.grid1.ContextMenuExcelEnabled = true;
            this.grid1.ContextMenuInsertEnabled = true;
            this.grid1.ContextMenuPasteEnabled = true;
            this.grid1.DeleteButtonEnable = true;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance2;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance14;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance16;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance15.BackColor2 = System.Drawing.SystemColors.Control;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance15;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            appearance21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance21;
            appearance17.BackColor = System.Drawing.SystemColors.Highlight;
            appearance17.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance17;
            this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
            this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance24.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance24;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance20;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance18.BackColor = System.Drawing.SystemColors.Control;
            appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance18.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance18;
            appearance19.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance19;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance22;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance23;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 266);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1263, 463);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // chart
            // 
            this.chart.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
            paintElement1.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.chart.Axis.PE = paintElement1;
            this.chart.Axis.X.Extent = 18;
            this.chart.Axis.X.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray;
            this.chart.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chart.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.chart.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.chart.Axis.X.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.chart.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chart.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.X.LineThickness = 1;
            this.chart.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chart.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.X.MajorGridLines.Visible = true;
            this.chart.Axis.X.Margin.Far.Value = 0.70422535211267612D;
            this.chart.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chart.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.X.MinorGridLines.Visible = true;
            this.chart.Axis.X.TickmarkIntervalType = Infragistics.UltraChart.Shared.Styles.AxisIntervalType.Weeks;
            this.chart.Axis.X.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chart.Axis.X.Visible = true;
            this.chart.Axis.X2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray;
            this.chart.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.chart.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.chart.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.chart.Axis.X2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.chart.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chart.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.X2.Labels.Visible = false;
            this.chart.Axis.X2.LineThickness = 1;
            this.chart.Axis.X2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chart.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.X2.MajorGridLines.Visible = true;
            this.chart.Axis.X2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chart.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.X2.MinorGridLines.Visible = false;
            this.chart.Axis.X2.TickmarkIntervalType = Infragistics.UltraChart.Shared.Styles.AxisIntervalType.Weeks;
            this.chart.Axis.X2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chart.Axis.X2.Visible = false;
            this.chart.Axis.Y.Extent = 23;
            this.chart.Axis.Y.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray;
            this.chart.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.chart.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.chart.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chart.Axis.Y.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.Y.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.chart.Axis.Y.Labels.SeriesLabels.FormatString = "";
            this.chart.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.chart.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.chart.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.Y.LineThickness = 1;
            this.chart.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chart.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.Y.MajorGridLines.Visible = true;
            this.chart.Axis.Y.Margin.Far.Value = 0.68027210884353739D;
            this.chart.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chart.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.Y.MinorGridLines.Visible = false;
            this.chart.Axis.Y.TickmarkInterval = 40D;
            this.chart.Axis.Y.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chart.Axis.Y.Visible = true;
            this.chart.Axis.Y2.Extent = 59;
            this.chart.Axis.Y2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray;
            this.chart.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chart.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.chart.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chart.Axis.Y2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.chart.Axis.Y2.Labels.SeriesLabels.FormatString = "";
            this.chart.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chart.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.chart.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.Y2.Labels.Visible = false;
            this.chart.Axis.Y2.LineThickness = 1;
            this.chart.Axis.Y2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chart.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.Y2.MajorGridLines.Visible = true;
            this.chart.Axis.Y2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chart.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.Y2.MinorGridLines.Visible = false;
            this.chart.Axis.Y2.TickmarkInterval = 40D;
            this.chart.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chart.Axis.Y2.Visible = false;
            this.chart.Axis.Z.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray;
            this.chart.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chart.Axis.Z.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.chart.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chart.Axis.Z.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.chart.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chart.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chart.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.Z.Labels.Visible = false;
            this.chart.Axis.Z.LineThickness = 1;
            this.chart.Axis.Z.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chart.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.Z.MajorGridLines.Visible = true;
            this.chart.Axis.Z.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chart.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.Z.MinorGridLines.Visible = false;
            this.chart.Axis.Z.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chart.Axis.Z.Visible = false;
            this.chart.Axis.Z2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray;
            this.chart.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chart.Axis.Z2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.chart.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chart.Axis.Z2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.chart.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chart.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chart.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.Z2.Labels.Visible = false;
            this.chart.Axis.Z2.LineThickness = 1;
            this.chart.Axis.Z2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chart.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.Z2.MajorGridLines.Visible = true;
            this.chart.Axis.Z2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chart.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.Z2.MinorGridLines.Visible = false;
            this.chart.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chart.Axis.Z2.Visible = false;
            this.chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chart.ColorModel.AlphaLevel = ((byte)(150));
            this.chart.ColorModel.ColorBegin = System.Drawing.Color.Pink;
            this.chart.ColorModel.ColorEnd = System.Drawing.Color.DarkRed;
            this.chart.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
            this.chart.Dock = System.Windows.Forms.DockStyle.Top;
            this.chart.Effects.Effects.Add(gradientEffect1);
            this.chart.Legend.AlphaLevel = ((byte)(53));
            this.chart.Legend.BackgroundColor = System.Drawing.Color.Gold;
            this.chart.Legend.BorderStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.DashDotDot;
            this.chart.Legend.Location = Infragistics.UltraChart.Shared.Styles.LegendLocation.Left;
            this.chart.Legend.SpanPercentage = 9;
            this.chart.Legend.Visible = true;
            this.chart.Location = new System.Drawing.Point(6, 6);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1263, 246);
            this.chart.TabIndex = 3;
            this.chart.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray;
            this.chart.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray;
            // 
            // lblPlc
            // 
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.lblPlc.Appearance = appearance5;
            this.lblPlc.DbField = null;
            this.lblPlc.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlc.Location = new System.Drawing.Point(542, 15);
            this.lblPlc.Name = "lblPlc";
            this.lblPlc.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlc.Size = new System.Drawing.Size(90, 25);
            this.lblPlc.TabIndex = 242;
            this.lblPlc.Text = "검사기";
            // 
            // lblPlc2
            // 
            appearance7.TextHAlignAsString = "Right";
            appearance7.TextVAlignAsString = "Middle";
            this.lblPlc2.Appearance = appearance7;
            this.lblPlc2.DbField = null;
            this.lblPlc2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlc2.Location = new System.Drawing.Point(542, 50);
            this.lblPlc2.Name = "lblPlc2";
            this.lblPlc2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlc2.Size = new System.Drawing.Size(90, 25);
            this.lblPlc2.TabIndex = 244;
            this.lblPlc2.Text = "검사기";
            // 
            // sLabel4
            // 
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.sLabel4.Appearance = appearance3;
            this.sLabel4.DbField = null;
            this.sLabel4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel4.Location = new System.Drawing.Point(603, 34);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel4.Size = new System.Drawing.Size(15, 23);
            this.sLabel4.TabIndex = 245;
            this.sLabel4.Text = "~";
            // 
            // lblResult
            // 
            appearance85.TextHAlignAsString = "Right";
            appearance85.TextVAlignAsString = "Middle";
            this.lblResult.Appearance = appearance85;
            this.lblResult.DbField = null;
            this.lblResult.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblResult.Location = new System.Drawing.Point(929, 15);
            this.lblResult.Name = "lblResult";
            this.lblResult.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblResult.Size = new System.Drawing.Size(90, 25);
            this.lblResult.TabIndex = 247;
            this.lblResult.Text = "결과";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 30);
            this.button1.TabIndex = 248;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbo_plc2
            // 
            this.cbo_plc2.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbo_plc2.Location = new System.Drawing.Point(637, 48);
            this.cbo_plc2.Name = "cbo_plc2";
            this.cbo_plc2.Size = new System.Drawing.Size(144, 27);
            this.cbo_plc2.TabIndex = 5;
            // 
            // cbo_plc
            // 
            this.cbo_plc.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbo_plc.Location = new System.Drawing.Point(637, 13);
            this.cbo_plc.Name = "cbo_plc";
            this.cbo_plc.Size = new System.Drawing.Size(144, 27);
            this.cbo_plc.TabIndex = 1;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 13);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(123, 27);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // cbo_result
            // 
            this.cbo_result.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbo_result.Location = new System.Drawing.Point(1024, 13);
            this.cbo_result.Name = "cbo_result";
            this.cbo_result.Size = new System.Drawing.Size(144, 27);
            this.cbo_result.TabIndex = 2;
            // 
            // TT1060
            // 
            this.ClientSize = new System.Drawing.Size(1275, 825);
            this.Name = "TT1060";
            this.Text = "기밀검사기 누설량 데이터 조회";
            this.Load += new System.EventHandler(this.TT1060_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CboStartdate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEnddate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_plc2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_plc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_result)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboStartdate_H;
        private Control.SLabel lblDate;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboEnddate_H;
        private Control.SLabel sLabel1;
        private Control.SLabel lblPlantCode;
        private Control.Grid grid1;
        private Infragistics.Win.Misc.UltraSplitter ultraSplitter1;
        private WIZ.Control.Chart chart;
        private Control.SLabel lblPlc;
        private Control.SLabel sLabel4;
        private Control.SLabel lblPlc2;
        private Control.SLabel lblResult;
        private System.Windows.Forms.Button button1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_plc;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_plc2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_result;
    }
}

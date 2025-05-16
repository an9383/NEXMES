namespace WIZ.PP
{
    partial class PT0500
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
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement2 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
            Infragistics.UltraChart.Resources.Appearance.GradientEffect gradientEffect2 = new Infragistics.UltraChart.Resources.Appearance.GradientEffect();
            Infragistics.UltraChart.Resources.Appearance.View3DAppearance view3DAppearance2 = new Infragistics.UltraChart.Resources.Appearance.View3DAppearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement1 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
            Infragistics.UltraChart.Resources.Appearance.GradientEffect gradientEffect1 = new Infragistics.UltraChart.Resources.Appearance.GradientEffect();
            Infragistics.UltraChart.Resources.Appearance.View3DAppearance view3DAppearance1 = new Infragistics.UltraChart.Resources.Appearance.View3DAppearance();
            this.CboStartdate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.CboEnddate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.ultraChart1 = new WIZ.Control.Chart(this.components);
            this.lblDate = new WIZ.Control.SLabel();
            this.sLabel1 = new WIZ.Control.SLabel();
            this.txtOPCode = new System.Windows.Forms.TextBox();
            this.txtOPName = new System.Windows.Forms.TextBox();
            this.txtWorkCenterCode = new System.Windows.Forms.TextBox();
            this.txtWorkCenterName = new System.Windows.Forms.TextBox();
            this.lblOPCode = new WIZ.Control.SLabel();
            this.lblWorkCenterCode = new WIZ.Control.SLabel();
            this.txtLineCode = new System.Windows.Forms.TextBox();
            this.txtLineName = new System.Windows.Forms.TextBox();
            this.lblLineCode = new WIZ.Control.SLabel();
            this.lblPlantCode1 = new WIZ.Control.SLabel();
            this.lblPlantCode2 = new WIZ.Control.SLabel();
            this.ultraChart2 = new WIZ.Control.Chart(this.components);
            this.cboPlantCode_H2 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboPlantCode_H1 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartdate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEnddate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.lblLineCode);
            this.gbxHeader.Controls.Add(this.txtLineCode);
            this.gbxHeader.Controls.Add(this.txtLineName);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H2);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H1);
            this.gbxHeader.Controls.Add(this.txtOPCode);
            this.gbxHeader.Controls.Add(this.txtOPName);
            this.gbxHeader.Controls.Add(this.txtWorkCenterCode);
            this.gbxHeader.Controls.Add(this.txtWorkCenterName);
            this.gbxHeader.Controls.Add(this.lblOPCode);
            this.gbxHeader.Controls.Add(this.lblWorkCenterCode);
            this.gbxHeader.Controls.Add(this.CboStartdate_H);
            this.gbxHeader.Controls.Add(this.lblDate);
            this.gbxHeader.Controls.Add(this.CboEnddate_H);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.lblPlantCode1);
            this.gbxHeader.Controls.Add(this.lblPlantCode2);
            this.gbxHeader.Size = new System.Drawing.Size(1178, 90);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode2, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboEnddate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboStartdate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblWorkCenterCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblOPCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkCenterName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkCenterCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtOPName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtOPCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H2, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtLineName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtLineCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblLineCode, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.ultraChart2);
            this.gbxBody.Controls.Add(this.ultraChart1);
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbxBody.Location = new System.Drawing.Point(0, 90);
            this.gbxBody.Size = new System.Drawing.Size(1178, 735);
            this.gbxBody.TabIndex = 1;
            // 
            // CboStartdate_H
            // 
            this.CboStartdate_H.DateButtons.Add(dateButton1);
            this.CboStartdate_H.Location = new System.Drawing.Point(146, 14);
            this.CboStartdate_H.Name = "CboStartdate_H";
            this.CboStartdate_H.NonAutoSizeHeight = 26;
            this.CboStartdate_H.Size = new System.Drawing.Size(121, 26);
            this.CboStartdate_H.TabIndex = 0;
            // 
            // CboEnddate_H
            // 
            this.CboEnddate_H.DateButtons.Add(dateButton2);
            this.CboEnddate_H.Location = new System.Drawing.Point(295, 14);
            this.CboEnddate_H.Name = "CboEnddate_H";
            this.CboEnddate_H.NonAutoSizeHeight = 26;
            this.CboEnddate_H.Size = new System.Drawing.Size(121, 26);
            this.CboEnddate_H.TabIndex = 1;
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
            appearance3.BackColor = System.Drawing.SystemColors.Window;
            appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance3;
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
            appearance5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance5;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 0);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(591, 387);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
//			'Chart' properties's serialization: Since 'ChartType' changes the way axes look,
//			'ChartType' must be persisted ahead of any Axes change made in design time.
//		
            this.ultraChart1.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.ColumnChart3D;
            // 
            // ultraChart1
            // 
            this.ultraChart1.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            paintElement2.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
            paintElement2.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.ultraChart1.Axis.PE = paintElement2;
            this.ultraChart1.Axis.X.Extent = 38;
            this.ultraChart1.Axis.X.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart1.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart1.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.FormatString = "";
            this.ultraChart1.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.X.LineThickness = 1;
            this.ultraChart1.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart1.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.X.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.X.Margin.Far.Value = 5D;
            this.ultraChart1.Axis.X.Margin.Near.Value = 5D;
            this.ultraChart1.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart1.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.X.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.X.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart1.Axis.X.Visible = true;
            this.ultraChart1.Axis.X2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart1.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart1.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart1.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.FormatString = "";
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.X2.Labels.Visible = false;
            this.ultraChart1.Axis.X2.LineThickness = 1;
            this.ultraChart1.Axis.X2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart1.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.X2.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.X2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart1.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.X2.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.X2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart1.Axis.X2.Visible = false;
            this.ultraChart1.Axis.Y.Extent = 42;
            this.ultraChart1.Axis.Y.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart1.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.ultraChart1.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.FormatString = "";
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Y.LineThickness = 1;
            this.ultraChart1.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart1.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Y.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart1.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Y.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.Y.TickmarkInterval = 50D;
            this.ultraChart1.Axis.Y.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart1.Axis.Y.Visible = true;
            this.ultraChart1.Axis.Y2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart1.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart1.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.ultraChart1.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.FormatString = "";
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Y2.Labels.Visible = false;
            this.ultraChart1.Axis.Y2.LineThickness = 1;
            this.ultraChart1.Axis.Y2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart1.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Y2.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.Y2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart1.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Y2.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.Y2.TickmarkInterval = 50D;
            this.ultraChart1.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart1.Axis.Y2.Visible = false;
            this.ultraChart1.Axis.Z.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart1.Axis.Z.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart1.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Z.LineThickness = 1;
            this.ultraChart1.Axis.Z.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart1.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Z.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.Z.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart1.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Z.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.Z.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart1.Axis.Z.Visible = true;
            this.ultraChart1.Axis.Z2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart1.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart1.Axis.Z2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart1.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart1.Axis.Z2.Labels.Visible = false;
            this.ultraChart1.Axis.Z2.LineThickness = 1;
            this.ultraChart1.Axis.Z2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart1.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Z2.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.Z2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart1.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart1.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart1.Axis.Z2.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart1.Axis.Z2.Visible = false;
            this.ultraChart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ultraChart1.ColorModel.AlphaLevel = ((byte)(255));
            this.ultraChart1.ColorModel.ColorBegin = System.Drawing.Color.Pink;
            this.ultraChart1.ColorModel.ColorEnd = System.Drawing.Color.DarkRed;
            this.ultraChart1.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
            this.ultraChart1.Effects.Effects.Add(gradientEffect2);
            this.ultraChart1.Location = new System.Drawing.Point(599, 0);
            this.ultraChart1.Name = "ultraChart1";
            this.ultraChart1.Size = new System.Drawing.Size(577, 387);
            this.ultraChart1.TabIndex = 11;
            this.ultraChart1.TitleTop.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.ultraChart1.TitleTop.Text = "공장별 불량발생 TOP 10 (공장1)";
            this.ultraChart1.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray;
            this.ultraChart1.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray;
            view3DAppearance2.XRotation = 130F;
            view3DAppearance2.YRotation = 10F;
            this.ultraChart1.Transform3D = view3DAppearance2;
            // 
            // lblDate
            // 
            appearance47.FontData.BoldAsString = "False";
            appearance47.FontData.UnderlineAsString = "False";
            appearance47.ForeColor = System.Drawing.Color.Black;
            appearance47.TextHAlignAsString = "Right";
            appearance47.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance47;
            this.lblDate.DbField = "cboUseFlag";
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(51, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDate.Size = new System.Drawing.Size(90, 25);
            this.lblDate.TabIndex = 167;
            this.lblDate.Text = "생산일자";
            // 
            // sLabel1
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance1;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(273, 16);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(16, 26);
            this.sLabel1.TabIndex = 170;
            this.sLabel1.Text = "~";
            // 
            // txtOPCode
            // 
            this.txtOPCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtOPCode.Location = new System.Drawing.Point(146, 51);
            this.txtOPCode.Name = "txtOPCode";
            this.txtOPCode.Size = new System.Drawing.Size(119, 25);
            this.txtOPCode.TabIndex = 359;
            this.txtOPCode.Visible = false;
            this.txtOPCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOPCode_KeyDown);
            this.txtOPCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOPCode_KeyPress);
            this.txtOPCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtOPCode_MouseDoubleClick);
            // 
            // txtOPName
            // 
            this.txtOPName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtOPName.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtOPName.Location = new System.Drawing.Point(265, 51);
            this.txtOPName.MaxLength = 30;
            this.txtOPName.Name = "txtOPName";
            this.txtOPName.Size = new System.Drawing.Size(199, 25);
            this.txtOPName.TabIndex = 360;
            this.txtOPName.Visible = false;
            this.txtOPName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOPNAME_KeyDown);
            this.txtOPName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOPName_KeyPress);
            this.txtOPName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtOPName_MouseDoubleClick);
            // 
            // txtWorkCenterCode
            // 
            this.txtWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWorkCenterCode.Location = new System.Drawing.Point(558, 51);
            this.txtWorkCenterCode.Name = "txtWorkCenterCode";
            this.txtWorkCenterCode.Size = new System.Drawing.Size(144, 25);
            this.txtWorkCenterCode.TabIndex = 357;
            this.txtWorkCenterCode.Visible = false;
            this.txtWorkCenterCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWorkCenterCode_KeyDown);
            this.txtWorkCenterCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWorkCenterCode_KeyPress);
            this.txtWorkCenterCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtWorkCenterCode_MouseDoubleClick);
            // 
            // txtWorkCenterName
            // 
            this.txtWorkCenterName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtWorkCenterName.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWorkCenterName.Location = new System.Drawing.Point(702, 51);
            this.txtWorkCenterName.MaxLength = 30;
            this.txtWorkCenterName.Name = "txtWorkCenterName";
            this.txtWorkCenterName.Size = new System.Drawing.Size(199, 25);
            this.txtWorkCenterName.TabIndex = 358;
            this.txtWorkCenterName.Visible = false;
            this.txtWorkCenterName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWorkCenterName_KeyDown);
            this.txtWorkCenterName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWorkCenterName_KeyPress);
            this.txtWorkCenterName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtWorkCenterName_MouseDoubleClick);
            // 
            // lblOPCode
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.Name = "맑은 고딕";
            appearance4.FontData.SizeInPoints = 9F;
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.lblOPCode.Appearance = appearance4;
            this.lblOPCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblOPCode.DbField = null;
            this.lblOPCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOPCode.Location = new System.Drawing.Point(51, 51);
            this.lblOPCode.Name = "lblOPCode";
            this.lblOPCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblOPCode.Size = new System.Drawing.Size(90, 25);
            this.lblOPCode.TabIndex = 356;
            this.lblOPCode.Text = "작업장";
            this.lblOPCode.Visible = false;
            // 
            // lblWorkCenterCode
            // 
            appearance69.FontData.BoldAsString = "False";
            appearance69.FontData.Name = "맑은 고딕";
            appearance69.FontData.SizeInPoints = 9F;
            appearance69.FontData.UnderlineAsString = "False";
            appearance69.ForeColor = System.Drawing.Color.Black;
            appearance69.TextHAlignAsString = "Right";
            appearance69.TextVAlignAsString = "Middle";
            this.lblWorkCenterCode.Appearance = appearance69;
            this.lblWorkCenterCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWorkCenterCode.DbField = null;
            this.lblWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkCenterCode.Location = new System.Drawing.Point(463, 51);
            this.lblWorkCenterCode.Name = "lblWorkCenterCode";
            this.lblWorkCenterCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWorkCenterCode.Size = new System.Drawing.Size(90, 25);
            this.lblWorkCenterCode.TabIndex = 355;
            this.lblWorkCenterCode.Text = "작업라인";
            this.lblWorkCenterCode.Visible = false;
            // 
            // txtLineCode
            // 
            this.txtLineCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLineCode.Location = new System.Drawing.Point(558, 11);
            this.txtLineCode.Name = "txtLineCode";
            this.txtLineCode.Size = new System.Drawing.Size(144, 25);
            this.txtLineCode.TabIndex = 362;
            this.txtLineCode.Visible = false;
            this.txtLineCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLineCode_KeyDown);
            this.txtLineCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLineCode_KeyPress);
            this.txtLineCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtWorkCenterCode_MouseDoubleClick);
            // 
            // txtLineName
            // 
            this.txtLineName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtLineName.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLineName.Location = new System.Drawing.Point(702, 11);
            this.txtLineName.MaxLength = 30;
            this.txtLineName.Name = "txtLineName";
            this.txtLineName.Size = new System.Drawing.Size(199, 25);
            this.txtLineName.TabIndex = 363;
            this.txtLineName.Visible = false;
            this.txtLineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOPNAME_KeyDown);
            this.txtLineName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOPName_KeyPress);
            this.txtLineName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtWorkCenterName_MouseDoubleClick);
            // 
            // lblLineCode
            // 
            appearance23.FontData.BoldAsString = "False";
            appearance23.FontData.Name = "맑은 고딕";
            appearance23.FontData.SizeInPoints = 9F;
            appearance23.FontData.UnderlineAsString = "False";
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextHAlignAsString = "Right";
            appearance23.TextVAlignAsString = "Middle";
            this.lblLineCode.Appearance = appearance23;
            this.lblLineCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblLineCode.DbField = null;
            this.lblLineCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLineCode.Location = new System.Drawing.Point(463, 12);
            this.lblLineCode.Name = "lblLineCode";
            this.lblLineCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblLineCode.Size = new System.Drawing.Size(90, 25);
            this.lblLineCode.TabIndex = 361;
            this.lblLineCode.Text = "라인";
            this.lblLineCode.Visible = false;
            // 
            // lblPlantCode1
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblPlantCode1.Appearance = appearance2;
            this.lblPlantCode1.DbField = null;
            this.lblPlantCode1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode1.Location = new System.Drawing.Point(892, 12);
            this.lblPlantCode1.Name = "lblPlantCode1";
            this.lblPlantCode1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode1.Size = new System.Drawing.Size(90, 25);
            this.lblPlantCode1.TabIndex = 362;
            this.lblPlantCode1.Text = "공장1";
            // 
            // lblPlantCode2
            // 
            appearance85.FontData.BoldAsString = "False";
            appearance85.FontData.UnderlineAsString = "False";
            appearance85.ForeColor = System.Drawing.Color.Black;
            appearance85.TextHAlignAsString = "Right";
            appearance85.TextVAlignAsString = "Middle";
            this.lblPlantCode2.Appearance = appearance85;
            this.lblPlantCode2.DbField = null;
            this.lblPlantCode2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode2.Location = new System.Drawing.Point(893, 51);
            this.lblPlantCode2.Name = "lblPlantCode2";
            this.lblPlantCode2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode2.Size = new System.Drawing.Size(90, 25);
            this.lblPlantCode2.TabIndex = 364;
            this.lblPlantCode2.Text = "공장2";
            // 
//			'Chart' properties's serialization: Since 'ChartType' changes the way axes look,
//			'ChartType' must be persisted ahead of any Axes change made in design time.
//		
            this.ultraChart2.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.ColumnChart3D;
            // 
            // ultraChart2
            // 
            this.ultraChart2.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
            paintElement1.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.ultraChart2.Axis.PE = paintElement1;
            this.ultraChart2.Axis.X.Extent = 38;
            this.ultraChart2.Axis.X.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart2.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart2.Axis.X.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Axis.X.Labels.SeriesLabels.FormatString = "";
            this.ultraChart2.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart2.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.X.LineThickness = 1;
            this.ultraChart2.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart2.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.X.MajorGridLines.Visible = true;
            this.ultraChart2.Axis.X.Margin.Far.Value = 5D;
            this.ultraChart2.Axis.X.Margin.Near.Value = 5D;
            this.ultraChart2.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart2.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.X.MinorGridLines.Visible = false;
            this.ultraChart2.Axis.X.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart2.Axis.X.Visible = true;
            this.ultraChart2.Axis.X2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart2.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart2.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart2.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.FormatString = "";
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.ultraChart2.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.X2.Labels.Visible = false;
            this.ultraChart2.Axis.X2.LineThickness = 1;
            this.ultraChart2.Axis.X2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart2.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.X2.MajorGridLines.Visible = true;
            this.ultraChart2.Axis.X2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart2.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.X2.MinorGridLines.Visible = false;
            this.ultraChart2.Axis.X2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart2.Axis.X2.Visible = false;
            this.ultraChart2.Axis.Y.Extent = 42;
            this.ultraChart2.Axis.Y.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart2.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.ultraChart2.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.FormatString = "";
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Y.LineThickness = 1;
            this.ultraChart2.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart2.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Y.MajorGridLines.Visible = true;
            this.ultraChart2.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart2.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Y.MinorGridLines.Visible = false;
            this.ultraChart2.Axis.Y.TickmarkInterval = 50D;
            this.ultraChart2.Axis.Y.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart2.Axis.Y.Visible = true;
            this.ultraChart2.Axis.Y2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart2.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.ultraChart2.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.FormatString = "";
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Y2.Labels.Visible = false;
            this.ultraChart2.Axis.Y2.LineThickness = 1;
            this.ultraChart2.Axis.Y2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart2.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Y2.MajorGridLines.Visible = true;
            this.ultraChart2.Axis.Y2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart2.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Y2.MinorGridLines.Visible = false;
            this.ultraChart2.Axis.Y2.TickmarkInterval = 50D;
            this.ultraChart2.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart2.Axis.Y2.Visible = false;
            this.ultraChart2.Axis.Z.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart2.Axis.Z.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart2.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Z.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.ultraChart2.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Z.LineThickness = 1;
            this.ultraChart2.Axis.Z.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart2.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Z.MajorGridLines.Visible = true;
            this.ultraChart2.Axis.Z.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart2.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Z.MinorGridLines.Visible = false;
            this.ultraChart2.Axis.Z.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart2.Axis.Z.Visible = true;
            this.ultraChart2.Axis.Z2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart2.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.Z2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart2.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Z2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.ultraChart2.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.ultraChart2.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.ultraChart2.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.ultraChart2.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.ultraChart2.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.ultraChart2.Axis.Z2.Labels.Visible = false;
            this.ultraChart2.Axis.Z2.LineThickness = 1;
            this.ultraChart2.Axis.Z2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.ultraChart2.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Z2.MajorGridLines.Visible = true;
            this.ultraChart2.Axis.Z2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.ultraChart2.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.ultraChart2.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.ultraChart2.Axis.Z2.MinorGridLines.Visible = false;
            this.ultraChart2.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.ultraChart2.Axis.Z2.Visible = false;
            this.ultraChart2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ultraChart2.ColorModel.AlphaLevel = ((byte)(255));
            this.ultraChart2.ColorModel.ColorBegin = System.Drawing.Color.Pink;
            this.ultraChart2.ColorModel.ColorEnd = System.Drawing.Color.DarkRed;
            this.ultraChart2.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
            this.ultraChart2.Effects.Effects.Add(gradientEffect1);
            this.ultraChart2.Location = new System.Drawing.Point(599, 389);
            this.ultraChart2.Name = "ultraChart2";
            this.ultraChart2.Size = new System.Drawing.Size(577, 377);
            this.ultraChart2.TabIndex = 11;
            this.ultraChart2.TitleTop.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold);
            this.ultraChart2.TitleTop.Text = "공장별 불량발생 TOP 10 (공장2)";
            this.ultraChart2.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray;
            this.ultraChart2.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray;
            view3DAppearance1.XRotation = 130F;
            view3DAppearance1.YRotation = 10F;
            this.ultraChart2.Transform3D = view3DAppearance1;
            // 
            // cboPlantCode_H2
            // 
            this.cboPlantCode_H2.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H2.Location = new System.Drawing.Point(988, 50);
            this.cboPlantCode_H2.Name = "cboPlantCode_H2";
            this.cboPlantCode_H2.Size = new System.Drawing.Size(144, 27);
            this.cboPlantCode_H2.TabIndex = 3;
            // 
            // cboPlantCode_H1
            // 
            this.cboPlantCode_H1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H1.Location = new System.Drawing.Point(987, 11);
            this.cboPlantCode_H1.Name = "cboPlantCode_H1";
            this.cboPlantCode_H1.Size = new System.Drawing.Size(144, 27);
            this.cboPlantCode_H1.TabIndex = 2;
            // 
            // PT0500
            // 
            this.ClientSize = new System.Drawing.Size(1178, 825);
            this.Name = "PT0500";
            this.Text = "불량 WorkCenter별 Top 10";
            this.Load += new System.EventHandler(this.PT0500_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CboStartdate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEnddate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraChart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboStartdate_H;
        private Control.SLabel lblDate;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboEnddate_H;
        private Control.SLabel sLabel1;
        private Control.Grid grid1;
        private WIZ.Control.Chart ultraChart1;
        private System.Windows.Forms.TextBox txtOPCode;
        private System.Windows.Forms.TextBox txtOPName;
        private System.Windows.Forms.TextBox txtWorkCenterCode;
        private System.Windows.Forms.TextBox txtWorkCenterName;
        private Control.SLabel lblOPCode;
        private Control.SLabel lblWorkCenterCode;
        private System.Windows.Forms.TextBox txtLineCode;
        private System.Windows.Forms.TextBox txtLineName;
        private Control.SLabel lblLineCode;
        private Control.SLabel lblPlantCode2;
        private Control.SLabel lblPlantCode1;
        private WIZ.Control.Chart ultraChart2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H2;
    }
}

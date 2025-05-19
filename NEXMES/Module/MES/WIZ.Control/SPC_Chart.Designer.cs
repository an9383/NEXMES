namespace WIZ.Control
{
    partial class SPC_Chart
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.UltraChart.Resources.Appearance.GradientEffect gradientEffect1 = new Infragistics.UltraChart.Resources.Appearance.GradientEffect();
            Infragistics.UltraChart.Resources.Appearance.LineChartAppearance lineChartAppearance1 = new Infragistics.UltraChart.Resources.Appearance.LineChartAppearance();
            Infragistics.UltraChart.Resources.Appearance.ChartTextAppearance chartTextAppearance1 = new Infragistics.UltraChart.Resources.Appearance.ChartTextAppearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chart = new Infragistics.Win.UltraWinChart.UltraChart();
            this.grid = new WIZ.Control.Grid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(682, 570);
            this.splitContainer1.SplitterDistance = 116;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chart);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grid);
            this.splitContainer2.Size = new System.Drawing.Size(682, 450);
            this.splitContainer2.SplitterDistance = 323;
            this.splitContainer2.TabIndex = 0;
            // 
//			'UltraChart' properties's serialization: Since 'ChartType' changes the way axes look,
//			'ChartType' must be persisted ahead of any Axes change made in design time.
//		
            this.chart.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.LineChart;
            // 
            // chart
            // 
            this.chart.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.chart.Axis.X.Extent = 50;
            this.chart.Axis.X.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray;
            this.chart.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chart.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.chart.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chart.Axis.X.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.chart.Axis.X.Labels.SeriesLabels.FormatString = "";
            this.chart.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chart.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.chart.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.X.LineThickness = 1;
            this.chart.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chart.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.X.MajorGridLines.Visible = true;
            this.chart.Axis.X.Margin.Near.Value = 2.6086956521739131D;
            this.chart.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chart.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.X.MinorGridLines.Visible = false;
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
            this.chart.Axis.X2.Labels.SeriesLabels.FormatString = "";
            this.chart.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.chart.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chart.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
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
            this.chart.Axis.X2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chart.Axis.X2.Visible = false;
            this.chart.Axis.Y.Extent = 33;
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
            this.chart.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chart.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chart.Axis.Y.LineThickness = 1;
            this.chart.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chart.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.Y.MajorGridLines.Visible = true;
            this.chart.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chart.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.Y.MinorGridLines.Visible = false;
            this.chart.Axis.Y.TickmarkInterval = 40D;
            this.chart.Axis.Y.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chart.Axis.Y.Visible = true;
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
            this.chart.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
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
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Effects.Effects.Add(gradientEffect1);
            this.chart.Legend.Location = Infragistics.UltraChart.Shared.Styles.LegendLocation.Left;
            chartTextAppearance1.ChartTextFont = new System.Drawing.Font("Arial", 7F);
            chartTextAppearance1.ClipText = false;
            chartTextAppearance1.Column = -2;
            chartTextAppearance1.ItemFormatString = "<DATA_VALUE:00.00>";
            chartTextAppearance1.Row = -2;
            chartTextAppearance1.Visible = true;
            lineChartAppearance1.ChartText.Add(chartTextAppearance1);
            this.chart.LineChart = lineChartAppearance1;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(682, 323);
            this.chart.TabIndex = 0;
            this.chart.TitleBottom.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chart.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray;
            this.chart.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray;
            this.chart.Tooltips.TooltipControl = null;
            // 
            // grid
            // 
            this.grid.AutoResizeColumn = true;
            this.grid.AutoUserColumn = true;
            this.grid.ContextMenuCopyEnabled = true;
            this.grid.ContextMenuDeleteEnabled = true;
            this.grid.ContextMenuExcelEnabled = true;
            this.grid.ContextMenuInsertEnabled = true;
            this.grid.ContextMenuPasteEnabled = true;
            this.grid.DeleteButtonEnable = true;
            appearance54.BackColor = System.Drawing.SystemColors.Window;
            appearance54.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid.DisplayLayout.Appearance = appearance54;
            this.grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance55.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance55.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance55.BorderColor = System.Drawing.SystemColors.Window;
            this.grid.DisplayLayout.GroupByBox.Appearance = appearance55;
            appearance56.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance56;
            this.grid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid.DisplayLayout.GroupByBox.Hidden = true;
            appearance57.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance57.BackColor2 = System.Drawing.SystemColors.Control;
            appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance57.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid.DisplayLayout.GroupByBox.PromptAppearance = appearance57;
            this.grid.DisplayLayout.MaxColScrollRegions = 1;
            this.grid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance59.BackColor = System.Drawing.SystemColors.Window;
            appearance59.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid.DisplayLayout.Override.ActiveCellAppearance = appearance59;
            appearance60.BackColor = System.Drawing.SystemColors.Highlight;
            appearance60.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid.DisplayLayout.Override.ActiveRowAppearance = appearance60;
            this.grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grid.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
            this.grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance61.BackColor = System.Drawing.SystemColors.Window;
            this.grid.DisplayLayout.Override.CardAreaAppearance = appearance61;
            appearance62.BorderColor = System.Drawing.Color.Silver;
            appearance62.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid.DisplayLayout.Override.CellAppearance = appearance62;
            this.grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid.DisplayLayout.Override.CellPadding = 0;
            appearance63.BackColor = System.Drawing.SystemColors.Control;
            appearance63.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance63.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance63.BorderColor = System.Drawing.SystemColors.Window;
            this.grid.DisplayLayout.Override.GroupByRowAppearance = appearance63;
            this.grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance64.BackColor = System.Drawing.SystemColors.Window;
            appearance64.BorderColor = System.Drawing.Color.Silver;
            this.grid.DisplayLayout.Override.RowAppearance = appearance64;
            this.grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance65.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid.DisplayLayout.Override.TemplateAddRowAppearance = appearance65;
            this.grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EnterNextRowEnable = true;
            this.grid.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Margin = new System.Windows.Forms.Padding(0);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(682, 123);
            this.grid.TabIndex = 7;
            this.grid.TabStop = false;
            this.grid.Text = "grid2";
            this.grid.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // SPC_Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SPC_Chart";
            this.Size = new System.Drawing.Size(682, 570);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public Grid grid;
        private Infragistics.Win.UltraWinChart.UltraChart chart;
    }
}

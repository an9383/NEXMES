namespace WIZ.CM
{
    partial class CM0410
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement1 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
            Infragistics.UltraChart.Resources.Appearance.GradientEffect gradientEffect1 = new Infragistics.UltraChart.Resources.Appearance.GradientEffect();
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
            this.lblDate = new WIZ.Control.SLabel();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.cbo_date = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chart = new WIZ.Control.Chart(this.components);
            this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPlantcode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantcode)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboPlantcode);
            this.gbxHeader.Controls.Add(this.panel3);
            this.gbxHeader.Controls.Add(this.cbo_date);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Controls.Add(this.lblDate);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 57);
            this.gbxHeader.Controls.SetChildIndex(this.lblDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_date, 0);
            this.gbxHeader.Controls.SetChildIndex(this.panel3, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantcode, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Controls.Add(this.ultraSplitter1);
            this.gbxBody.Controls.Add(this.splitContainer1);
            this.gbxBody.Location = new System.Drawing.Point(0, 57);
            this.gbxBody.Size = new System.Drawing.Size(1136, 721);
            // 
            // lblDate
            // 
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance1;
            this.lblDate.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblDate.DbField = null;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(358, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDate.Size = new System.Drawing.Size(90, 25);
            this.lblDate.TabIndex = 199;
            this.lblDate.Text = "일자";
            // 
            // lblPlantCode
            // 
            appearance85.TextHAlignAsString = "Right";
            appearance85.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance85;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(51, 15);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(90, 25);
            this.lblPlantCode.TabIndex = 242;
            this.lblPlantCode.Text = "공장";
            // 
            // cbo_date
            // 
            appearance3.FontData.SizeInPoints = 10F;
            this.cbo_date.Appearance = appearance3;
            this.cbo_date.DateButtons.Add(dateButton1);
            this.cbo_date.Format = "yyyy";
            this.cbo_date.Location = new System.Drawing.Point(453, 15);
            this.cbo_date.Name = "cbo_date";
            this.cbo_date.NonAutoSizeHeight = 26;
            this.cbo_date.Size = new System.Drawing.Size(120, 24);
            this.cbo_date.SpinButtonIncrement = Infragistics.Win.UltraWinSchedule.SpinIncrementUnit.Years;
            this.cbo_date.SpinButtonsVisible = true;
            this.cbo_date.TabIndex = 1;
            this.cbo_date.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cbo_date.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbo_date.Value = new System.DateTime(2013, 1, 21, 0, 0, 0, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(6, 6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart);
            this.splitContainer1.Size = new System.Drawing.Size(1124, 389);
            this.splitContainer1.SplitterDistance = 38;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(37, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "<>";
            this.label1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(790, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 38);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "실적";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(39, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 21);
            this.label7.TabIndex = 25;
            this.label7.Text = "--+--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "계획";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGreen;
            this.panel5.Location = new System.Drawing.Point(204, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(54, 16);
            this.panel5.TabIndex = 18;
            // 
            // chart
            // 
            this.chart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chart.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
            paintElement1.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.chart.Axis.PE = paintElement1;
            this.chart.Axis.X.Extent = 50;
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
            this.chart.Axis.X.LogBase = 20D;
            this.chart.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chart.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chart.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chart.Axis.X.MajorGridLines.Visible = true;
            this.chart.Axis.X.Margin.Far.MarginType = Infragistics.UltraChart.Shared.Styles.LocationType.Pixels;
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
            this.chart.Axis.X2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chart.Axis.X2.Visible = false;
            this.chart.Axis.Y.Extent = 11;
            this.chart.Axis.Y.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chart.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray;
            this.chart.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.chart.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:0.##>";
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
            this.chart.Axis.Z.Labels.ItemFormatString = "";
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
            this.chart.Axis.Z2.Labels.ItemFormatString = "";
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
            this.chart.Border.Color = System.Drawing.Color.Transparent;
            this.chart.Border.Thickness = 0;
            this.chart.ColorModel.AlphaLevel = ((byte)(150));
            this.chart.ColorModel.ColorBegin = System.Drawing.Color.Pink;
            this.chart.ColorModel.ColorEnd = System.Drawing.Color.DarkRed;
            this.chart.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Effects.Effects.Add(gradientEffect1);
            this.chart.EmptyChartText = "";
            this.chart.Legend.Visible = true;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Margin = new System.Windows.Forms.Padding(0);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1124, 347);
            this.chart.TabIndex = 225;
            this.chart.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray;
            this.chart.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray;
            // 
            // ultraSplitter1
            // 
            this.ultraSplitter1.BackColor = System.Drawing.Color.White;
            this.ultraSplitter1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button;
            this.ultraSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraSplitter1.Location = new System.Drawing.Point(6, 395);
            this.ultraSplitter1.Name = "ultraSplitter1";
            this.ultraSplitter1.RestoreExtent = 246;
            this.ultraSplitter1.Size = new System.Drawing.Size(1124, 14);
            this.ultraSplitter1.TabIndex = 238;
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
            this.grid1.Location = new System.Drawing.Point(6, 409);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1124, 306);
            this.grid1.TabIndex = 1;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(964, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(168, 49);
            this.panel3.TabIndex = 250;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(107, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 250;
            this.label5.Text = "단위 : EA";
            // 
            // cboPlantcode
            // 
            this.cboPlantcode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantcode.Location = new System.Drawing.Point(146, 15);
            this.cboPlantcode.Name = "cboPlantcode";
            this.cboPlantcode.Size = new System.Drawing.Size(119, 27);
            this.cboPlantcode.TabIndex = 0;
            // 
            // CM0410
            // 
            this.ClientSize = new System.Drawing.Size(1136, 778);
            this.Name = "CM0410";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.CM0410_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbo_date)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.SLabel lblDate;
        private Control.SLabel lblPlantCode;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cbo_date;
        private Control.Grid grid1;
        private Infragistics.Win.Misc.UltraSplitter ultraSplitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private WIZ.Control.Chart chart;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantcode;
    }
}

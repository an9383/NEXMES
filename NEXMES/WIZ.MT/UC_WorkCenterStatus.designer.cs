namespace WIZ.MT
{
    partial class UC_WorkCenterStatus
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement1 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
            Infragistics.UltraChart.Resources.Appearance.BarChartAppearance barChartAppearance1 = new Infragistics.UltraChart.Resources.Appearance.BarChartAppearance();
            Infragistics.UltraChart.Resources.Appearance.GradientEffect gradientEffect1 = new Infragistics.UltraChart.Resources.Appearance.GradientEffect();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpDetail = new System.Windows.Forms.TableLayoutPanel();
            this.lblLastLineTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLineStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblProdQty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOrdQty = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.lblItemCode_H = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWorkCenterCode = new System.Windows.Forms.Label();
            this.crtStatus = new Infragistics.Win.UltraWinChart.UltraChart();
            this.pnlMain.SuspendLayout();
            this.tlpDetail.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.tlpDetail);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(244, 124);
            this.pnlMain.TabIndex = 0;
            // 
            // tlpDetail
            // 
            this.tlpDetail.AutoSize = true;
            this.tlpDetail.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpDetail.ColumnCount = 4;
            this.tlpDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpDetail.Controls.Add(this.lblLastLineTime, 3, 2);
            this.tlpDetail.Controls.Add(this.label7, 2, 2);
            this.tlpDetail.Controls.Add(this.lblLineStatus, 1, 2);
            this.tlpDetail.Controls.Add(this.label6, 0, 2);
            this.tlpDetail.Controls.Add(this.lblProdQty, 3, 1);
            this.tlpDetail.Controls.Add(this.label3, 2, 1);
            this.tlpDetail.Controls.Add(this.lblItemName, 1, 1);
            this.tlpDetail.Controls.Add(this.label2, 0, 1);
            this.tlpDetail.Controls.Add(this.lblOrdQty, 3, 0);
            this.tlpDetail.Controls.Add(this.label5, 2, 0);
            this.tlpDetail.Controls.Add(this.lblItemCode, 1, 0);
            this.tlpDetail.Controls.Add(this.lblItemCode_H, 0, 0);
            this.tlpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDetail.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tlpDetail.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpDetail.Location = new System.Drawing.Point(0, 40);
            this.tlpDetail.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDetail.Name = "tlpDetail";
            this.tlpDetail.RowCount = 3;
            this.tlpDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDetail.Size = new System.Drawing.Size(244, 84);
            this.tlpDetail.TabIndex = 10;
            // 
            // lblLastLineTime
            // 
            this.lblLastLineTime.BackColor = System.Drawing.Color.Gainsboro;
            this.lblLastLineTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastLineTime.Font = new System.Drawing.Font("맑은 고딕", 7F, System.Drawing.FontStyle.Bold);
            this.lblLastLineTime.ForeColor = System.Drawing.Color.Black;
            this.lblLastLineTime.Location = new System.Drawing.Point(145, 55);
            this.lblLastLineTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblLastLineTime.Name = "lblLastLineTime";
            this.lblLastLineTime.Size = new System.Drawing.Size(98, 28);
            this.lblLastLineTime.TabIndex = 26;
            this.lblLastLineTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(121, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 28);
            this.label7.TabIndex = 25;
            this.label7.Text = "갱신\r\n일자";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLineStatus
            // 
            this.lblLineStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.lblLineStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLineStatus.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lblLineStatus.ForeColor = System.Drawing.Color.Black;
            this.lblLineStatus.Location = new System.Drawing.Point(25, 55);
            this.lblLineStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblLineStatus.Name = "lblLineStatus";
            this.lblLineStatus.Size = new System.Drawing.Size(95, 28);
            this.lblLineStatus.TabIndex = 24;
            this.lblLineStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 28);
            this.label6.TabIndex = 23;
            this.label6.Text = "상태";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProdQty
            // 
            this.lblProdQty.BackColor = System.Drawing.Color.Gainsboro;
            this.lblProdQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProdQty.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lblProdQty.ForeColor = System.Drawing.Color.Black;
            this.lblProdQty.Location = new System.Drawing.Point(145, 28);
            this.lblProdQty.Margin = new System.Windows.Forms.Padding(0);
            this.lblProdQty.Name = "lblProdQty";
            this.lblProdQty.Size = new System.Drawing.Size(98, 26);
            this.lblProdQty.TabIndex = 22;
            this.lblProdQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(121, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 26);
            this.label3.TabIndex = 21;
            this.label3.Text = "생산";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemName
            // 
            this.lblItemName.BackColor = System.Drawing.Color.Gainsboro;
            this.lblItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemName.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lblItemName.ForeColor = System.Drawing.Color.Black;
            this.lblItemName.Location = new System.Drawing.Point(25, 28);
            this.lblItemName.Margin = new System.Windows.Forms.Padding(0);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(95, 26);
            this.lblItemName.TabIndex = 20;
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 26);
            this.label2.TabIndex = 19;
            this.label2.Text = "품명";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrdQty
            // 
            this.lblOrdQty.BackColor = System.Drawing.Color.Gainsboro;
            this.lblOrdQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrdQty.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lblOrdQty.ForeColor = System.Drawing.Color.Black;
            this.lblOrdQty.Location = new System.Drawing.Point(145, 1);
            this.lblOrdQty.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrdQty.Name = "lblOrdQty";
            this.lblOrdQty.Size = new System.Drawing.Size(98, 26);
            this.lblOrdQty.TabIndex = 18;
            this.lblOrdQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(121, 1);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 26);
            this.label5.TabIndex = 17;
            this.label5.Text = "지시";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemCode
            // 
            this.lblItemCode.BackColor = System.Drawing.Color.Gainsboro;
            this.lblItemCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemCode.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lblItemCode.ForeColor = System.Drawing.Color.Black;
            this.lblItemCode.Location = new System.Drawing.Point(25, 1);
            this.lblItemCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemCode.Size = new System.Drawing.Size(95, 26);
            this.lblItemCode.TabIndex = 13;
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemCode_H
            // 
            this.lblItemCode_H.BackColor = System.Drawing.Color.White;
            this.lblItemCode_H.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemCode_H.Font = new System.Drawing.Font("맑은 고딕", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemCode_H.ForeColor = System.Drawing.Color.Black;
            this.lblItemCode_H.Location = new System.Drawing.Point(1, 1);
            this.lblItemCode_H.Margin = new System.Windows.Forms.Padding(0);
            this.lblItemCode_H.Name = "lblItemCode_H";
            this.lblItemCode_H.Size = new System.Drawing.Size(23, 26);
            this.lblItemCode_H.TabIndex = 12;
            this.lblItemCode_H.Text = "품목";
            this.lblItemCode_H.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Silver;
            this.pnlHeader.Controls.Add(this.lblWorkCenterCode);
            this.pnlHeader.Controls.Add(this.crtStatus);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.ForeColor = System.Drawing.Color.Black;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(244, 40);
            this.pnlHeader.TabIndex = 9;
            // 
            // lblWorkCenterCode
            // 
            this.lblWorkCenterCode.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkCenterCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblWorkCenterCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWorkCenterCode.Location = new System.Drawing.Point(0, 15);
            this.lblWorkCenterCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblWorkCenterCode.Name = "lblWorkCenterCode";
            this.lblWorkCenterCode.Size = new System.Drawing.Size(244, 25);
            this.lblWorkCenterCode.TabIndex = 13;
            this.lblWorkCenterCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
//			'UltraChart' properties's serialization: Since 'ChartType' changes the way axes look,
//			'ChartType' must be persisted ahead of any Axes change made in design time.
//		
            this.crtStatus.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.BarChart;
            // 
            // crtStatus
            // 
            this.crtStatus.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
            paintElement1.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.crtStatus.Axis.PE = paintElement1;
            this.crtStatus.Axis.X.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.crtStatus.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray;
            this.crtStatus.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.crtStatus.Axis.X.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.crtStatus.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.crtStatus.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.crtStatus.Axis.X.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.crtStatus.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.crtStatus.Axis.X.Labels.SeriesLabels.FormatString = "";
            this.crtStatus.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.crtStatus.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.crtStatus.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.crtStatus.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.X.Labels.Visible = false;
            this.crtStatus.Axis.X.LineThickness = 1;
            this.crtStatus.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.crtStatus.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.crtStatus.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.crtStatus.Axis.X.MajorGridLines.Visible = false;
            this.crtStatus.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
            this.crtStatus.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.crtStatus.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.crtStatus.Axis.X.MinorGridLines.Visible = false;
            this.crtStatus.Axis.X.TickmarkInterval = 50D;
            this.crtStatus.Axis.X.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.crtStatus.Axis.X.Visible = false;
            this.crtStatus.Axis.X2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.crtStatus.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray;
            this.crtStatus.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.crtStatus.Axis.X2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.crtStatus.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.crtStatus.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.crtStatus.Axis.X2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.crtStatus.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.crtStatus.Axis.X2.Labels.SeriesLabels.FormatString = "";
            this.crtStatus.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.crtStatus.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.crtStatus.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.crtStatus.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.X2.Labels.Visible = false;
            this.crtStatus.Axis.X2.LineThickness = 1;
            this.crtStatus.Axis.X2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.crtStatus.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.crtStatus.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.crtStatus.Axis.X2.MajorGridLines.Visible = true;
            this.crtStatus.Axis.X2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.crtStatus.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.crtStatus.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.crtStatus.Axis.X2.MinorGridLines.Visible = false;
            this.crtStatus.Axis.X2.TickmarkInterval = 50D;
            this.crtStatus.Axis.X2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.crtStatus.Axis.X2.Visible = false;
            this.crtStatus.Axis.Y.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.crtStatus.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray;
            this.crtStatus.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.crtStatus.Axis.Y.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.crtStatus.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.crtStatus.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.crtStatus.Axis.Y.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.crtStatus.Axis.Y.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.crtStatus.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.crtStatus.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.crtStatus.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.Y.Labels.Visible = false;
            this.crtStatus.Axis.Y.LineThickness = 1;
            this.crtStatus.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
            this.crtStatus.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.crtStatus.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.crtStatus.Axis.Y.MajorGridLines.Visible = false;
            this.crtStatus.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
            this.crtStatus.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.crtStatus.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.crtStatus.Axis.Y.MinorGridLines.Visible = false;
            this.crtStatus.Axis.Y.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.crtStatus.Axis.Y.Visible = false;
            this.crtStatus.Axis.Y2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.crtStatus.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray;
            this.crtStatus.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.crtStatus.Axis.Y2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.crtStatus.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.crtStatus.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.crtStatus.Axis.Y2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.crtStatus.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.crtStatus.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.crtStatus.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.crtStatus.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.Y2.Labels.Visible = false;
            this.crtStatus.Axis.Y2.LineThickness = 1;
            this.crtStatus.Axis.Y2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.crtStatus.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.crtStatus.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.crtStatus.Axis.Y2.MajorGridLines.Visible = true;
            this.crtStatus.Axis.Y2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.crtStatus.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.crtStatus.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.crtStatus.Axis.Y2.MinorGridLines.Visible = false;
            this.crtStatus.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.crtStatus.Axis.Y2.Visible = false;
            this.crtStatus.Axis.Z.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.crtStatus.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray;
            this.crtStatus.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.crtStatus.Axis.Z.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.crtStatus.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.crtStatus.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.crtStatus.Axis.Z.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.crtStatus.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.crtStatus.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.crtStatus.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.crtStatus.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.crtStatus.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.Z.Labels.Visible = false;
            this.crtStatus.Axis.Z.LineThickness = 1;
            this.crtStatus.Axis.Z.MajorGridLines.AlphaLevel = ((byte)(255));
            this.crtStatus.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.crtStatus.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.crtStatus.Axis.Z.MajorGridLines.Visible = true;
            this.crtStatus.Axis.Z.MinorGridLines.AlphaLevel = ((byte)(255));
            this.crtStatus.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.crtStatus.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.crtStatus.Axis.Z.MinorGridLines.Visible = false;
            this.crtStatus.Axis.Z.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.crtStatus.Axis.Z.Visible = false;
            this.crtStatus.Axis.Z2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.crtStatus.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray;
            this.crtStatus.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.crtStatus.Axis.Z2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.crtStatus.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.crtStatus.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.crtStatus.Axis.Z2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.crtStatus.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.crtStatus.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.crtStatus.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.crtStatus.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.crtStatus.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.crtStatus.Axis.Z2.Labels.Visible = false;
            this.crtStatus.Axis.Z2.LineThickness = 1;
            this.crtStatus.Axis.Z2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.crtStatus.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.crtStatus.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.crtStatus.Axis.Z2.MajorGridLines.Visible = true;
            this.crtStatus.Axis.Z2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.crtStatus.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.crtStatus.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.crtStatus.Axis.Z2.MinorGridLines.Visible = false;
            this.crtStatus.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.crtStatus.Axis.Z2.Visible = false;
            this.crtStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            barChartAppearance1.SeriesSpacing = 0;
            this.crtStatus.BarChart = barChartAppearance1;
            this.crtStatus.Border.Thickness = 0;
            this.crtStatus.ColorModel.AlphaLevel = ((byte)(150));
            this.crtStatus.ColorModel.ColorBegin = System.Drawing.Color.Pink;
            this.crtStatus.ColorModel.ColorEnd = System.Drawing.Color.DarkRed;
            this.crtStatus.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
            this.crtStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.crtStatus.Effects.Effects.Add(gradientEffect1);
            this.crtStatus.Location = new System.Drawing.Point(0, 0);
            this.crtStatus.Margin = new System.Windows.Forms.Padding(0);
            this.crtStatus.Name = "crtStatus";
            this.crtStatus.Size = new System.Drawing.Size(244, 15);
            this.crtStatus.TabIndex = 12;
            this.crtStatus.TitleBottom.Margins.Bottom = 0;
            this.crtStatus.TitleBottom.Margins.Left = 0;
            this.crtStatus.TitleBottom.Margins.Right = 0;
            this.crtStatus.TitleBottom.Margins.Top = 0;
            this.crtStatus.TitleBottom.Visible = false;
            this.crtStatus.TitleTop.Margins.Bottom = 0;
            this.crtStatus.TitleTop.Margins.Left = 0;
            this.crtStatus.TitleTop.Margins.Right = 0;
            this.crtStatus.TitleTop.Margins.Top = 0;
            this.crtStatus.TitleTop.Visible = false;
            this.crtStatus.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray;
            this.crtStatus.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray;
            // 
            // UC_WorkCenterStatus
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_WorkCenterStatus";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(250, 130);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.tlpDetail.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.crtStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tlpDetail;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblItemCode_H;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblOrdQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProdQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLineStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLastLineTime;
        private System.Windows.Forms.Label lblWorkCenterCode;
        private Infragistics.Win.UltraWinChart.UltraChart crtStatus;
    }
}

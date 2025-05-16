namespace WIZ.MT
{
    partial class MT0010_UC
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.UltraGauge.Resources.LinearGauge linearGauge1 = new Infragistics.UltraGauge.Resources.LinearGauge();
            Infragistics.UltraGauge.Resources.SolidFillBrushElement solidFillBrushElement1 = new Infragistics.UltraGauge.Resources.SolidFillBrushElement();
            Infragistics.UltraGauge.Resources.LinearGaugeScale linearGaugeScale1 = new Infragistics.UltraGauge.Resources.LinearGaugeScale();
            Infragistics.UltraGauge.Resources.NumericAxis numericAxis1 = new Infragistics.UltraGauge.Resources.NumericAxis();
            Infragistics.UltraGauge.Resources.LinearGaugeBarMarker linearGaugeBarMarker1 = new Infragistics.UltraGauge.Resources.LinearGaugeBarMarker();
            Infragistics.UltraGauge.Resources.SolidFillBrushElement solidFillBrushElement2 = new Infragistics.UltraGauge.Resources.SolidFillBrushElement();
            Infragistics.UltraGauge.Resources.StrokeElement strokeElement1 = new Infragistics.UltraGauge.Resources.StrokeElement();
            Infragistics.UltraGauge.Resources.StrokeElement strokeElement2 = new Infragistics.UltraGauge.Resources.StrokeElement();
            Infragistics.UltraGauge.Resources.SolidFillBrushElement solidFillBrushElement3 = new Infragistics.UltraGauge.Resources.SolidFillBrushElement();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picItemName = new System.Windows.Forms.PictureBox();
            this.lblLastLineTime = new Infragistics.Win.Misc.UltraLabel();
            this.lblProdQty = new Infragistics.Win.Misc.UltraLabel();
            this.lblLineStatus = new Infragistics.Win.Misc.UltraLabel();
            this.lblItemName = new Infragistics.Win.Misc.UltraLabel();
            this.lblWorkCenterName = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGauge1 = new Infragistics.Win.UltraWinGauge.UltraGauge();
            this.picWcName = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItemName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWcName)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.Controls.Add(this.picItemName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLastLineTime, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblProdQty, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblLineStatus, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblItemName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblWorkCenterName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ultraGauge1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.picWcName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(188, 200);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // picItemName
            // 
            this.picItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picItemName.Location = new System.Drawing.Point(3, 43);
            this.picItemName.Name = "picItemName";
            this.picItemName.Size = new System.Drawing.Size(28, 34);
            this.picItemName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picItemName.TabIndex = 11;
            this.picItemName.TabStop = false;
            // 
            // lblLastLineTime
            // 
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.Name = "한글누리";
            appearance1.FontData.SizeInPoints = 9F;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblLastLineTime.Appearance = appearance1;
            this.tableLayoutPanel1.SetColumnSpan(this.lblLastLineTime, 2);
            this.lblLastLineTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastLineTime.Location = new System.Drawing.Point(3, 187);
            this.lblLastLineTime.Name = "lblLastLineTime";
            this.lblLastLineTime.Size = new System.Drawing.Size(147, 10);
            this.lblLastLineTime.TabIndex = 8;
            this.lblLastLineTime.UseAppStyling = false;
            // 
            // lblProdQty
            // 
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.Name = "한글누리";
            appearance2.FontData.SizeInPoints = 18F;
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblProdQty.Appearance = appearance2;
            this.tableLayoutPanel1.SetColumnSpan(this.lblProdQty, 2);
            this.lblProdQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProdQty.Location = new System.Drawing.Point(3, 143);
            this.lblProdQty.Name = "lblProdQty";
            this.lblProdQty.Size = new System.Drawing.Size(147, 38);
            this.lblProdQty.TabIndex = 7;
            this.lblProdQty.UseAppStyling = false;
            // 
            // lblLineStatus
            // 
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.Name = "한글누리";
            appearance3.FontData.SizeInPoints = 18F;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblLineStatus.Appearance = appearance3;
            this.tableLayoutPanel1.SetColumnSpan(this.lblLineStatus, 2);
            this.lblLineStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLineStatus.Location = new System.Drawing.Point(0, 96);
            this.lblLineStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblLineStatus.Name = "lblLineStatus";
            this.lblLineStatus.Size = new System.Drawing.Size(153, 44);
            this.lblLineStatus.TabIndex = 6;
            this.lblLineStatus.UseAppStyling = false;
            // 
            // lblItemName
            // 
            appearance4.FontData.BoldAsString = "True";
            appearance4.FontData.Name = "한글누리";
            appearance4.FontData.SizeInPoints = 12F;
            appearance4.ForeColor = System.Drawing.Color.White;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.lblItemName.Appearance = appearance4;
            this.lblItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemName.Location = new System.Drawing.Point(37, 43);
            this.lblItemName.Name = "lblItemName";
            this.tableLayoutPanel1.SetRowSpan(this.lblItemName, 2);
            this.lblItemName.Size = new System.Drawing.Size(113, 50);
            this.lblItemName.TabIndex = 4;
            this.lblItemName.UseAppStyling = false;
            // 
            // lblWorkCenterName
            // 
            appearance5.FontData.BoldAsString = "True";
            appearance5.FontData.Name = "한글누리";
            appearance5.FontData.SizeInPoints = 12F;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.lblWorkCenterName.Appearance = appearance5;
            this.lblWorkCenterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkCenterName.Location = new System.Drawing.Point(37, 3);
            this.lblWorkCenterName.Name = "lblWorkCenterName";
            this.lblWorkCenterName.Size = new System.Drawing.Size(113, 34);
            this.lblWorkCenterName.TabIndex = 3;
            this.lblWorkCenterName.UseAppStyling = false;
            // 
            // ultraGauge1
            // 
            this.ultraGauge1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGauge1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGauge1.ForeColor = System.Drawing.SystemColors.ControlText;
            solidFillBrushElement1.Color = System.Drawing.Color.Black;
            linearGauge1.BrushElements.Add(solidFillBrushElement1);
            linearGauge1.Margin = new Infragistics.UltraGauge.Resources.Margin(2D, 0D, 2D, 2D, Infragistics.UltraGauge.Resources.Measure.Pixels);
            linearGauge1.Orientation = Infragistics.UltraGauge.Resources.LinearOrientation.Vertical;
            numericAxis1.EndValue = 100D;
            numericAxis1.TickmarkInterval = 10D;
            linearGaugeScale1.Axes.Add(numericAxis1);
            linearGaugeScale1.Labels.Extent = 90D;
            linearGaugeScale1.Labels.Font = new System.Drawing.Font("맑은 고딕", 8F);
            linearGaugeScale1.MajorTickmarks.EndExtent = 75D;
            linearGaugeScale1.MajorTickmarks.EndWidth = 0;
            linearGaugeScale1.MajorTickmarks.StartExtent = 75D;
            linearGaugeScale1.MajorTickmarks.StartWidth = 0;
            linearGaugeScale1.MajorTickmarks.StrokeElement.Color = System.Drawing.Color.Black;
            linearGaugeScale1.MajorTickmarks.StrokeElement.Thickness = 0D;
            solidFillBrushElement2.Color = System.Drawing.Color.White;
            linearGaugeBarMarker1.BrushElements.Add(solidFillBrushElement2);
            linearGaugeBarMarker1.InnerExtent = 0D;
            linearGaugeBarMarker1.OuterExtent = 100D;
            linearGaugeBarMarker1.Precision = 0D;
            linearGaugeBarMarker1.Value = 100D;
            linearGaugeScale1.Markers.Add(linearGaugeBarMarker1);
            linearGaugeScale1.MinorTickmarks.EndExtent = 75D;
            linearGaugeScale1.MinorTickmarks.EndWidth = 0;
            linearGaugeScale1.MinorTickmarks.Frequency = 0.5D;
            linearGaugeScale1.MinorTickmarks.StartExtent = 65D;
            linearGaugeScale1.MinorTickmarks.StartWidth = 0;
            strokeElement1.Thickness = 0D;
            linearGaugeScale1.StrokeElement = strokeElement1;
            linearGauge1.Scales.Add(linearGaugeScale1);
            solidFillBrushElement3.Color = System.Drawing.Color.Black;
            strokeElement2.BrushElements.Add(solidFillBrushElement3);
            strokeElement2.Thickness = 0D;
            linearGauge1.StrokeElement = strokeElement2;
            this.ultraGauge1.Gauges.Add(linearGauge1);
            this.ultraGauge1.Location = new System.Drawing.Point(153, 0);
            this.ultraGauge1.Margin = new System.Windows.Forms.Padding(0);
            this.ultraGauge1.Name = "ultraGauge1";
            this.tableLayoutPanel1.SetRowSpan(this.ultraGauge1, 6);
            this.ultraGauge1.Size = new System.Drawing.Size(35, 200);
            this.ultraGauge1.TabIndex = 9;
            // 
            // picWcName
            // 
            this.picWcName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picWcName.Location = new System.Drawing.Point(3, 3);
            this.picWcName.Name = "picWcName";
            this.picWcName.Size = new System.Drawing.Size(28, 34);
            this.picWcName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWcName.TabIndex = 10;
            this.picWcName.TabStop = false;
            // 
            // MT0010_UC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MT0010_UC";
            this.Size = new System.Drawing.Size(188, 200);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picItemName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWcName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private TableLayout_Custom tableLayoutPanel1;
        new System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Infragistics.Win.Misc.UltraLabel lblItemName;
        private Infragistics.Win.Misc.UltraLabel lblWorkCenterName;
        private Infragistics.Win.Misc.UltraLabel lblLineStatus;
        private Infragistics.Win.Misc.UltraLabel lblProdQty;
        private Infragistics.Win.Misc.UltraLabel lblLastLineTime;
        private Infragistics.Win.UltraWinGauge.UltraGauge ultraGauge1;
        private System.Windows.Forms.PictureBox picItemName;
        private System.Windows.Forms.PictureBox picWcName;
    }
}

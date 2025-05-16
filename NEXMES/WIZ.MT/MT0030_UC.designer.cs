namespace WIZ.MT
{
    partial class MT0030_UC
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
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MT0030_UC));
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.lblWorkcenter = new Infragistics.Win.Misc.UltraLabel();
			this.lblQty = new Infragistics.Win.Misc.UltraLabel();
			this.picIcon = new System.Windows.Forms.PictureBox();
			this.tlpMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 2;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
			this.tlpMain.Controls.Add(this.lblWorkcenter, 0, 1);
			this.tlpMain.Controls.Add(this.lblQty, 1, 0);
			this.tlpMain.Controls.Add(this.picIcon, 0, 0);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.RowCount = 2;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpMain.Size = new System.Drawing.Size(107, 72);
			this.tlpMain.TabIndex = 0;
			// 
			// lblWorkcenter
			// 
			appearance5.FontData.BoldAsString = "False";
			appearance5.FontData.Name = "한글누리";
			appearance5.FontData.SizeInPoints = 11F;
			appearance5.ForeColor = System.Drawing.Color.Black;
			appearance5.TextHAlignAsString = "Center";
			appearance5.TextVAlignAsString = "Middle";
			this.lblWorkcenter.Appearance = appearance5;
			this.tlpMain.SetColumnSpan(this.lblWorkcenter, 2);
			this.lblWorkcenter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblWorkcenter.Location = new System.Drawing.Point(0, 36);
			this.lblWorkcenter.Margin = new System.Windows.Forms.Padding(0);
			this.lblWorkcenter.Name = "lblWorkcenter";
			this.lblWorkcenter.Size = new System.Drawing.Size(107, 36);
			this.lblWorkcenter.TabIndex = 5;
			this.lblWorkcenter.Text = "부스바 가공기";
			this.lblWorkcenter.UseAppStyling = false;
			// 
			// lblQty
			// 
			appearance1.FontData.BoldAsString = "False";
			appearance1.FontData.Name = "한글누리";
			appearance1.FontData.SizeInPoints = 16F;
			appearance1.ForeColor = System.Drawing.Color.Black;
			appearance1.TextHAlignAsString = "Center";
			appearance1.TextVAlignAsString = "Middle";
			this.lblQty.Appearance = appearance1;
			this.lblQty.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblQty.Location = new System.Drawing.Point(44, 0);
			this.lblQty.Margin = new System.Windows.Forms.Padding(0);
			this.lblQty.Name = "lblQty";
			this.lblQty.Size = new System.Drawing.Size(63, 36);
			this.lblQty.TabIndex = 4;
			this.lblQty.UseAppStyling = false;
			// 
			// picIcon
			// 
			this.picIcon.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picIcon.Location = new System.Drawing.Point(0, 0);
			this.picIcon.Margin = new System.Windows.Forms.Padding(0);
			this.picIcon.Name = "picIcon";
			this.picIcon.Size = new System.Drawing.Size(44, 36);
			this.picIcon.TabIndex = 0;
			this.picIcon.TabStop = false;
			this.picIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picIcon_MouseDown);
			this.picIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picIcon_MouseMove);
			this.picIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picIcon_MouseUp);
			// 
			// MT0030_UC
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Controls.Add(this.tlpMain);
			this.DoubleBuffered = true;
			this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.Name = "MT0030_UC";
			this.Size = new System.Drawing.Size(107, 72);
			this.tlpMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.PictureBox picIcon;
		private Infragistics.Win.Misc.UltraLabel lblWorkcenter;
		public Infragistics.Win.Misc.UltraLabel lblQty;
	}
}

using WIZ.Control;

namespace WIZ.MT
{
    partial class MT0030
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
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MT0030));
			this.pnlLoading = new System.Windows.Forms.Panel();
			this.pnlSetting = new System.Windows.Forms.Panel();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.lblOutCnt = new Infragistics.Win.Misc.UltraLabel();
			this.lblInCnt = new Infragistics.Win.Misc.UltraLabel();
			this.lblNotice = new Infragistics.Win.Misc.UltraLabel();
			this.lblStopCCnt = new Infragistics.Win.Misc.UltraLabel();
			this.lblStopBCnt = new Infragistics.Win.Misc.UltraLabel();
			this.lblStopACnt = new Infragistics.Win.Misc.UltraLabel();
			this.lblStopWC = new Infragistics.Win.Misc.UltraLabel();
			this.lblRunWC = new Infragistics.Win.Misc.UltraLabel();
			this.lblStopCnt = new Infragistics.Win.Misc.UltraLabel();
			this.lblRunCnt = new Infragistics.Win.Misc.UltraLabel();
			this.lblTime = new Infragistics.Win.Misc.UltraLabel();
			this.picTitle = new System.Windows.Forms.PictureBox();
			this.picSetting = new System.Windows.Forms.PictureBox();
			this.picLoading = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
			this.gbxBody.SuspendLayout();
			this.pnlLoading.SuspendLayout();
			this.pnlSetting.SuspendLayout();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picSetting)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
			this.SuspendLayout();
			// 
			// gbxHeader
			// 
			this.gbxHeader.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
			this.gbxHeader.ContentPadding.Bottom = 2;
			this.gbxHeader.ContentPadding.Left = 2;
			this.gbxHeader.ContentPadding.Right = 2;
			this.gbxHeader.ContentPadding.Top = 4;
			this.gbxHeader.Margin = new System.Windows.Forms.Padding(0);
			this.gbxHeader.Size = new System.Drawing.Size(1920, 0);
			this.gbxHeader.TabIndex = 0;
			this.gbxHeader.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Default;
			// 
			// gbxBody
			// 
			this.gbxBody.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
			this.gbxBody.Controls.Add(this.pnlMain);
			this.gbxBody.Controls.Add(this.pnlSetting);
			this.gbxBody.Controls.Add(this.pnlLoading);
			this.gbxBody.Location = new System.Drawing.Point(0, 0);
			this.gbxBody.Margin = new System.Windows.Forms.Padding(0);
			this.gbxBody.Size = new System.Drawing.Size(1920, 1080);
			this.gbxBody.TabIndex = 1;
			this.gbxBody.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Default;
			// 
			// pnlLoading
			// 
			this.pnlLoading.BackColor = System.Drawing.Color.Transparent;
			this.pnlLoading.BackgroundImage = global::WIZ.MT.Properties.Resources.MT0030_009;
			this.pnlLoading.Controls.Add(this.picLoading);
			this.pnlLoading.Location = new System.Drawing.Point(680, 0);
			this.pnlLoading.Margin = new System.Windows.Forms.Padding(0);
			this.pnlLoading.Name = "pnlLoading";
			this.pnlLoading.Size = new System.Drawing.Size(1239, 984);
			this.pnlLoading.TabIndex = 29;
			this.pnlLoading.Visible = false;
			// 
			// pnlSetting
			// 
			this.pnlSetting.BackColor = System.Drawing.Color.Transparent;
			this.pnlSetting.Controls.Add(this.picSetting);
			this.pnlSetting.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlSetting.Location = new System.Drawing.Point(1, 0);
			this.pnlSetting.Margin = new System.Windows.Forms.Padding(0);
			this.pnlSetting.Name = "pnlSetting";
			this.pnlSetting.Size = new System.Drawing.Size(1918, 1079);
			this.pnlSetting.TabIndex = 31;
			this.pnlSetting.Visible = false;
			// 
			// pnlMain
			// 
			this.pnlMain.BackgroundImage = global::WIZ.MT.Properties.Resources.MT0030_000;
			this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pnlMain.Controls.Add(this.lblOutCnt);
			this.pnlMain.Controls.Add(this.lblInCnt);
			this.pnlMain.Controls.Add(this.lblNotice);
			this.pnlMain.Controls.Add(this.lblStopCCnt);
			this.pnlMain.Controls.Add(this.lblStopBCnt);
			this.pnlMain.Controls.Add(this.lblStopACnt);
			this.pnlMain.Controls.Add(this.lblStopWC);
			this.pnlMain.Controls.Add(this.lblRunWC);
			this.pnlMain.Controls.Add(this.lblStopCnt);
			this.pnlMain.Controls.Add(this.lblRunCnt);
			this.pnlMain.Controls.Add(this.lblTime);
			this.pnlMain.Controls.Add(this.picTitle);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(1, 0);
			this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(1918, 1079);
			this.pnlMain.TabIndex = 0;
			this.pnlMain.DoubleClick += new System.EventHandler(this.pnlMain_DoubleClick);
			// 
			// lblOutCnt
			// 
			appearance8.BackColor = System.Drawing.Color.Transparent;
			appearance8.FontData.SizeInPoints = 35F;
			appearance8.ForeColor = System.Drawing.Color.Black;
			appearance8.TextHAlignAsString = "Center";
			appearance8.TextVAlignAsString = "Middle";
			this.lblOutCnt.Appearance = appearance8;
			this.lblOutCnt.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblOutCnt.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
			this.lblOutCnt.Font = new System.Drawing.Font("한글누리", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblOutCnt.Location = new System.Drawing.Point(469, 904);
			this.lblOutCnt.Margin = new System.Windows.Forms.Padding(0);
			this.lblOutCnt.Name = "lblOutCnt";
			this.lblOutCnt.Size = new System.Drawing.Size(173, 60);
			this.lblOutCnt.TabIndex = 28;
			this.lblOutCnt.Text = "0";
			this.lblOutCnt.UseAppStyling = false;
			// 
			// lblInCnt
			// 
			appearance15.BackColor = System.Drawing.Color.Transparent;
			appearance15.FontData.SizeInPoints = 35F;
			appearance15.ForeColor = System.Drawing.Color.Black;
			appearance15.TextHAlignAsString = "Center";
			appearance15.TextVAlignAsString = "Middle";
			this.lblInCnt.Appearance = appearance15;
			this.lblInCnt.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblInCnt.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
			this.lblInCnt.Font = new System.Drawing.Font("한글누리", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblInCnt.Location = new System.Drawing.Point(161, 904);
			this.lblInCnt.Margin = new System.Windows.Forms.Padding(0);
			this.lblInCnt.Name = "lblInCnt";
			this.lblInCnt.Size = new System.Drawing.Size(173, 60);
			this.lblInCnt.TabIndex = 27;
			this.lblInCnt.Text = "0";
			this.lblInCnt.UseAppStyling = false;
			// 
			// lblNotice
			// 
			appearance27.AlphaLevel = ((short)(255));
			appearance27.BackColor = System.Drawing.Color.Transparent;
			appearance27.FontData.SizeInPoints = 35F;
			appearance27.ForeColor = System.Drawing.Color.Gold;
			appearance27.TextHAlignAsString = "Left";
			appearance27.TextVAlignAsString = "Middle";
			this.lblNotice.Appearance = appearance27;
			this.lblNotice.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblNotice.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
			this.lblNotice.Font = new System.Drawing.Font("둥근모꼴", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblNotice.ImageSize = new System.Drawing.Size(0, 0);
			this.lblNotice.Location = new System.Drawing.Point(133, 992);
			this.lblNotice.Margin = new System.Windows.Forms.Padding(0);
			this.lblNotice.Name = "lblNotice";
			this.lblNotice.Size = new System.Drawing.Size(1755, 65);
			this.lblNotice.TabIndex = 24;
			this.lblNotice.Text = "공지사항";
			this.lblNotice.UseAppStyling = false;
			// 
			// lblStopCCnt
			// 
			appearance3.BackColor = System.Drawing.Color.Transparent;
			appearance3.FontData.SizeInPoints = 35F;
			appearance3.ForeColor = System.Drawing.Color.White;
			appearance3.TextHAlignAsString = "Center";
			appearance3.TextVAlignAsString = "Middle";
			this.lblStopCCnt.Appearance = appearance3;
			this.lblStopCCnt.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblStopCCnt.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
			this.lblStopCCnt.Font = new System.Drawing.Font("한글누리", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblStopCCnt.Location = new System.Drawing.Point(536, 478);
			this.lblStopCCnt.Margin = new System.Windows.Forms.Padding(0);
			this.lblStopCCnt.Name = "lblStopCCnt";
			this.lblStopCCnt.Size = new System.Drawing.Size(102, 50);
			this.lblStopCCnt.TabIndex = 18;
			this.lblStopCCnt.Text = "0";
			this.lblStopCCnt.UseAppStyling = false;
			// 
			// lblStopBCnt
			// 
			appearance24.BackColor = System.Drawing.Color.Transparent;
			appearance24.FontData.SizeInPoints = 35F;
			appearance24.ForeColor = System.Drawing.Color.White;
			appearance24.TextHAlignAsString = "Center";
			appearance24.TextVAlignAsString = "Middle";
			this.lblStopBCnt.Appearance = appearance24;
			this.lblStopBCnt.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblStopBCnt.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
			this.lblStopBCnt.Font = new System.Drawing.Font("한글누리", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblStopBCnt.Location = new System.Drawing.Point(326, 478);
			this.lblStopBCnt.Margin = new System.Windows.Forms.Padding(0);
			this.lblStopBCnt.Name = "lblStopBCnt";
			this.lblStopBCnt.Size = new System.Drawing.Size(102, 50);
			this.lblStopBCnt.TabIndex = 17;
			this.lblStopBCnt.Text = "0";
			this.lblStopBCnt.UseAppStyling = false;
			// 
			// lblStopACnt
			// 
			appearance26.BackColor = System.Drawing.Color.Transparent;
			appearance26.FontData.SizeInPoints = 35F;
			appearance26.ForeColor = System.Drawing.Color.White;
			appearance26.TextHAlignAsString = "Center";
			appearance26.TextVAlignAsString = "Middle";
			this.lblStopACnt.Appearance = appearance26;
			this.lblStopACnt.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblStopACnt.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
			this.lblStopACnt.Font = new System.Drawing.Font("한글누리", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblStopACnt.Location = new System.Drawing.Point(116, 478);
			this.lblStopACnt.Margin = new System.Windows.Forms.Padding(0);
			this.lblStopACnt.Name = "lblStopACnt";
			this.lblStopACnt.Size = new System.Drawing.Size(102, 50);
			this.lblStopACnt.TabIndex = 16;
			this.lblStopACnt.Text = "0";
			this.lblStopACnt.UseAppStyling = false;
			// 
			// lblStopWC
			// 
			appearance16.BackColor = System.Drawing.Color.Transparent;
			appearance16.FontData.SizeInPoints = 23F;
			appearance16.ForeColor = System.Drawing.Color.White;
			appearance16.TextHAlignAsString = "Center";
			appearance16.TextVAlignAsString = "Middle";
			this.lblStopWC.Appearance = appearance16;
			this.lblStopWC.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblStopWC.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
			this.lblStopWC.Font = new System.Drawing.Font("한글누리", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblStopWC.Location = new System.Drawing.Point(302, 371);
			this.lblStopWC.Margin = new System.Windows.Forms.Padding(0);
			this.lblStopWC.Name = "lblStopWC";
			this.lblStopWC.Size = new System.Drawing.Size(173, 50);
			this.lblStopWC.TabIndex = 15;
			this.lblStopWC.Text = "(0 / 0)";
			this.lblStopWC.UseAppStyling = false;
			// 
			// lblRunWC
			// 
			appearance4.BackColor = System.Drawing.Color.Transparent;
			appearance4.FontData.SizeInPoints = 23F;
			appearance4.ForeColor = System.Drawing.Color.White;
			appearance4.TextHAlignAsString = "Center";
			appearance4.TextVAlignAsString = "Middle";
			this.lblRunWC.Appearance = appearance4;
			this.lblRunWC.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblRunWC.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
			this.lblRunWC.Font = new System.Drawing.Font("한글누리", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblRunWC.Location = new System.Drawing.Point(302, 221);
			this.lblRunWC.Margin = new System.Windows.Forms.Padding(0);
			this.lblRunWC.Name = "lblRunWC";
			this.lblRunWC.Size = new System.Drawing.Size(173, 50);
			this.lblRunWC.TabIndex = 14;
			this.lblRunWC.Text = "(0 / 0)";
			this.lblRunWC.UseAppStyling = false;
			// 
			// lblStopCnt
			// 
			appearance25.BackColor = System.Drawing.Color.Transparent;
			appearance25.FontData.SizeInPoints = 60F;
			appearance25.ForeColor = System.Drawing.Color.Black;
			appearance25.TextHAlignAsString = "Center";
			appearance25.TextVAlignAsString = "Middle";
			this.lblStopCnt.Appearance = appearance25;
			this.lblStopCnt.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblStopCnt.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
			this.lblStopCnt.Font = new System.Drawing.Font("한글누리", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblStopCnt.Location = new System.Drawing.Point(507, 321);
			this.lblStopCnt.Margin = new System.Windows.Forms.Padding(0);
			this.lblStopCnt.Name = "lblStopCnt";
			this.lblStopCnt.Size = new System.Drawing.Size(135, 100);
			this.lblStopCnt.TabIndex = 11;
			this.lblStopCnt.Text = "0";
			this.lblStopCnt.UseAppStyling = false;
			// 
			// lblRunCnt
			// 
			appearance51.BackColor = System.Drawing.Color.Transparent;
			appearance51.FontData.SizeInPoints = 60F;
			appearance51.ForeColor = System.Drawing.Color.Black;
			appearance51.TextHAlignAsString = "Center";
			appearance51.TextVAlignAsString = "Middle";
			this.lblRunCnt.Appearance = appearance51;
			this.lblRunCnt.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblRunCnt.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
			this.lblRunCnt.Font = new System.Drawing.Font("한글누리", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblRunCnt.Location = new System.Drawing.Point(507, 171);
			this.lblRunCnt.Margin = new System.Windows.Forms.Padding(0);
			this.lblRunCnt.Name = "lblRunCnt";
			this.lblRunCnt.Size = new System.Drawing.Size(135, 100);
			this.lblRunCnt.TabIndex = 10;
			this.lblRunCnt.Text = "0";
			this.lblRunCnt.UseAppStyling = false;
			// 
			// lblTime
			// 
			appearance6.BackColor = System.Drawing.Color.Transparent;
			appearance6.FontData.SizeInPoints = 20F;
			appearance6.ForeColor = System.Drawing.Color.Black;
			appearance6.TextHAlignAsString = "Center";
			appearance6.TextVAlignAsString = "Middle";
			this.lblTime.Appearance = appearance6;
			this.lblTime.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblTime.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
			this.lblTime.Font = new System.Drawing.Font("한글누리", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblTime.Location = new System.Drawing.Point(238, 70);
			this.lblTime.Margin = new System.Windows.Forms.Padding(0);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(320, 35);
			this.lblTime.TabIndex = 9;
			this.lblTime.Text = "0000-00-00 00:00:00";
			this.lblTime.UseAppStyling = false;
			// 
			// picTitle
			// 
			this.picTitle.BackColor = System.Drawing.Color.Transparent;
			this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
			this.picTitle.Location = new System.Drawing.Point(27, 10);
			this.picTitle.Margin = new System.Windows.Forms.Padding(0);
			this.picTitle.Name = "picTitle";
			this.picTitle.Size = new System.Drawing.Size(91, 91);
			this.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picTitle.TabIndex = 0;
			this.picTitle.TabStop = false;
			// 
			// picSetting
			// 
			this.picSetting.Location = new System.Drawing.Point(832, 310);
			this.picSetting.Margin = new System.Windows.Forms.Padding(0);
			this.picSetting.Name = "picSetting";
			this.picSetting.Size = new System.Drawing.Size(256, 256);
			this.picSetting.TabIndex = 0;
			this.picSetting.TabStop = false;
			// 
			// picLoading
			// 
			this.picLoading.Location = new System.Drawing.Point(491, 260);
			this.picLoading.Margin = new System.Windows.Forms.Padding(0);
			this.picLoading.Name = "picLoading";
			this.picLoading.Size = new System.Drawing.Size(256, 256);
			this.picLoading.TabIndex = 1;
			this.picLoading.TabStop = false;
			// 
			// MT0030
			// 
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(1920, 1080);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MT0030";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MT0030_Load);
			((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
			this.gbxBody.ResumeLayout(false);
			this.pnlLoading.ResumeLayout(false);
			this.pnlSetting.ResumeLayout(false);
			this.pnlMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picSetting)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.PictureBox picTitle;
		private Infragistics.Win.Misc.UltraLabel lblStopCnt;
		private Infragistics.Win.Misc.UltraLabel lblRunCnt;
		private Infragistics.Win.Misc.UltraLabel lblTime;
		private Infragistics.Win.Misc.UltraLabel lblNotice;
		private Infragistics.Win.Misc.UltraLabel lblStopCCnt;
		private Infragistics.Win.Misc.UltraLabel lblStopBCnt;
		private Infragistics.Win.Misc.UltraLabel lblStopACnt;
		private Infragistics.Win.Misc.UltraLabel lblStopWC;
		private Infragistics.Win.Misc.UltraLabel lblRunWC;
        private Infragistics.Win.Misc.UltraLabel lblOutCnt;
        private Infragistics.Win.Misc.UltraLabel lblInCnt;
		private MT0030_UC MT0030_UC36;
		private MT0030_UC MT0030_UC35;
		private MT0030_UC MT0030_UC34;
		private MT0030_UC MT0030_UC33;
		private MT0030_UC MT0030_UC31;
		private MT0030_UC MT0030_UC32;
		private MT0030_UC MT0030_UC25;
		private MT0030_UC MT0030_UC30;
		private MT0030_UC MT0030_UC29;
		private MT0030_UC MT0030_UC28;
		private MT0030_UC MT0030_UC26;
		private MT0030_UC MT0030_UC27;
		private MT0030_UC MT0030_UC24;
		private MT0030_UC MT0030_UC23;
		private MT0030_UC MT0030_UC22;
		private MT0030_UC MT0030_UC18;
		private MT0030_UC MT0030_UC19;
		private MT0030_UC MT0030_UC20;
		private MT0030_UC MT0030_UC21;
		private MT0030_UC MT0030_UC17;
		private MT0030_UC MT0030_UC16;
		private MT0030_UC MT0030_UC15;
		private MT0030_UC MT0030_UC14;
		private MT0030_UC MT0030_UC10;
		private MT0030_UC MT0030_UC11;
		private MT0030_UC MT0030_UC12;
		private MT0030_UC MT0030_UC13;
		private MT0030_UC MT0030_UC7;
		private MT0030_UC MT0030_UC8;
		private MT0030_UC MT0030_UC9;
		private MT0030_UC MT0030_UC6;
		private MT0030_UC MT0030_UC5;
		private MT0030_UC MT0030_UC4;
		private MT0030_UC MT0030_UC3;
		private MT0030_UC MT0030_UC2;
		private MT0030_UC MT0030_UC1;
		private System.Windows.Forms.Panel pnlSetting;
		private System.Windows.Forms.Panel pnlLoading;
		private System.Windows.Forms.PictureBox picSetting;
		private System.Windows.Forms.PictureBox picLoading;
	}
}

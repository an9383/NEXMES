namespace WIZ.MT
{
    partial class MT0010
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.lblHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.pnlHeader);
            this.gbxHeader.Margin = new System.Windows.Forms.Padding(0);
            this.gbxHeader.Size = new System.Drawing.Size(1700, 50);
            this.gbxHeader.Controls.SetChildIndex(this.pnlHeader, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.gbxBody.Controls.Add(this.pnlMain);
            this.gbxBody.Location = new System.Drawing.Point(0, 50);
            this.gbxBody.Margin = new System.Windows.Forms.Padding(0);
            this.gbxBody.Size = new System.Drawing.Size(1700, 991);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(196, 77);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1698, 990);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.DoubleClick += new System.EventHandler(this.pnlMain_DoubleClick);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackgroundImage = global::WIZ.MT.Properties.Resources.pattern2;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.ultraLabel4);
            this.pnlHeader.Controls.Add(this.ultraLabel3);
            this.pnlHeader.Controls.Add(this.ultraLabel2);
            this.pnlHeader.Controls.Add(this.ultraLabel1);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1920, 50);
            this.pnlHeader.TabIndex = 3;
            // 
            // ultraLabel4
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(127)))), ((int)(((byte)(23)))));
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.Name = "한글누리";
            appearance1.FontData.SizeInPoints = 15F;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance1;
            this.ultraLabel4.Location = new System.Drawing.Point(1522, 7);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(372, 33);
            this.ultraLabel4.TabIndex = 4;
            this.ultraLabel4.Text = "기타";
            this.ultraLabel4.UseAppStyling = false;
            // 
            // ultraLabel3
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            appearance4.FontData.BoldAsString = "True";
            appearance4.FontData.Name = "한글누리";
            appearance4.FontData.SizeInPoints = 15F;
            appearance4.ForeColor = System.Drawing.Color.White;
            appearance4.TextHAlignAsString = "Center";
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance4;
            this.ultraLabel3.Location = new System.Drawing.Point(1134, 7);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(372, 33);
            this.ultraLabel3.TabIndex = 3;
            this.ultraLabel3.Text = "장비/설비";
            this.ultraLabel3.UseAppStyling = false;
            // 
            // ultraLabel2
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.Name = "한글누리";
            appearance3.FontData.SizeInPoints = 15F;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance3;
            this.ultraLabel2.Location = new System.Drawing.Point(746, 7);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(372, 33);
            this.ultraLabel2.TabIndex = 2;
            this.ultraLabel2.Text = "계획정지";
            this.ultraLabel2.UseAppStyling = false;
            // 
            // ultraLabel1
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.Name = "한글누리";
            appearance2.FontData.SizeInPoints = 15F;
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance2;
            this.ultraLabel1.Location = new System.Drawing.Point(358, 7);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(372, 33);
            this.ultraLabel1.TabIndex = 1;
            this.ultraLabel1.Text = "가동";
            this.ultraLabel1.UseAppStyling = false;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("한글누리", 25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.lblHeader.Size = new System.Drawing.Size(1918, 48);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "작업장별 생산현황";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.DoubleClick += new System.EventHandler(this.lblHeader_DoubleClick);
            // 
            // MT0010
            // 
            this.ClientSize = new System.Drawing.Size(1700, 1041);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MT0010";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "작업장별 가동현황";
            this.Activated += new System.EventHandler(this.MT0010_Activated);
            this.Deactivate += new System.EventHandler(this.MT0010_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MT0010_FormClosing);
            this.Load += new System.EventHandler(this.MT0010_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
    }
}

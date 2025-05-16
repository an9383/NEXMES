namespace NEXMES
{
    partial class ZZ0200
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
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.pnlMain = new Infragistics.Win.Misc.UltraPanel();
            this.btnLicense = new Infragistics.Win.Misc.UltraButton();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnSave = new Infragistics.Win.Misc.UltraButton();
            this.grbDB = new Infragistics.Win.Misc.UltraGroupBox();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.sLabel1 = new WIZ.Control.SLabel();
            this.txtConn = new WIZ.Control.STextBox(this.components);
            this.btnTest = new Infragistics.Win.Misc.UltraButton();
            this.grbLicense = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtKey = new WIZ.Control.STextBox(this.components);
            this.lblKey_H = new WIZ.Control.SLabel();
            this.txtMAC = new WIZ.Control.STextBox(this.components);
            this.lblMAC_H = new WIZ.Control.SLabel();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblType_H = new WIZ.Control.SLabel();
            this.pnlMain.ClientArea.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbDB)).BeginInit();
            this.grbDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbLicense)).BeginInit();
            this.grbLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAC)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BorderColor = System.Drawing.Color.LightGray;
            this.pnlMain.Appearance = appearance1;
            this.pnlMain.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlMain.ClientArea
            // 
            this.pnlMain.ClientArea.Controls.Add(this.btnLicense);
            this.pnlMain.ClientArea.Controls.Add(this.btnClose);
            this.pnlMain.ClientArea.Controls.Add(this.btnSave);
            this.pnlMain.ClientArea.Controls.Add(this.grbDB);
            this.pnlMain.ClientArea.Controls.Add(this.grbLicense);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(344, 331);
            this.pnlMain.TabIndex = 4;
            // 
            // btnLicense
            // 
            this.btnLicense.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnLicense.Location = new System.Drawing.Point(13, 278);
            this.btnLicense.Name = "btnLicense";
            this.btnLicense.Size = new System.Drawing.Size(100, 45);
            this.btnLicense.TabIndex = 21;
            this.btnLicense.Text = "라이센스";
            this.btnLicense.Click += new System.EventHandler(this.btnLicense_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnClose.Location = new System.Drawing.Point(229, 278);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 45);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "닫기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnSave.Location = new System.Drawing.Point(121, 278);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 45);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "저장";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grbDB
            // 
            this.grbDB.Controls.Add(this.cboCompany);
            this.grbDB.Controls.Add(this.sLabel1);
            this.grbDB.Controls.Add(this.txtConn);
            this.grbDB.Controls.Add(this.btnTest);
            this.grbDB.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grbDB.Location = new System.Drawing.Point(1, 11);
            this.grbDB.Name = "grbDB";
            this.grbDB.Size = new System.Drawing.Size(340, 261);
            this.grbDB.TabIndex = 0;
            this.grbDB.Text = "Database Setting";
            // 
            // cboCompany
            // 
            this.cboCompany.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(130, 24);
            this.cboCompany.Margin = new System.Windows.Forms.Padding(0);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(200, 27);
            this.cboCompany.TabIndex = 1018;
            this.cboCompany.SelectedValueChanged += new System.EventHandler(this.cboCompany_SelectedValueChanged);
            // 
            // sLabel1
            // 
            appearance46.BackColor = System.Drawing.Color.SkyBlue;
            appearance46.FontData.BoldAsString = "False";
            appearance46.FontData.UnderlineAsString = "False";
            appearance46.ForeColor = System.Drawing.Color.Black;
            appearance46.TextHAlignAsString = "Center";
            appearance46.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance46;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(10, 24);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.Padding = new System.Drawing.Size(10, 0);
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(120, 27);
            this.sLabel1.TabIndex = 1017;
            this.sLabel1.Text = "Company";
            this.sLabel1.Click += new System.EventHandler(this.sLabel1_Click);
            // 
            // txtConn
            // 
            appearance13.FontData.Name = "맑은 고딕";
            appearance13.FontData.SizeInPoints = 10F;
            this.txtConn.Appearance = appearance13;
            this.txtConn.AutoSize = false;
            this.txtConn.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.txtConn.Location = new System.Drawing.Point(13, 57);
            this.txtConn.MaxLength = 0;
            this.txtConn.Multiline = true;
            this.txtConn.Name = "txtConn";
            this.txtConn.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtConn.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtConn.Size = new System.Drawing.Size(314, 161);
            this.txtConn.TabIndex = 24;
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnTest.Location = new System.Drawing.Point(10, 224);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(317, 27);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "연결테스트";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // grbLicense
            // 
            this.grbLicense.Controls.Add(this.txtKey);
            this.grbLicense.Controls.Add(this.lblKey_H);
            this.grbLicense.Controls.Add(this.txtMAC);
            this.grbLicense.Controls.Add(this.lblMAC_H);
            this.grbLicense.Controls.Add(this.cboType);
            this.grbLicense.Controls.Add(this.lblType_H);
            this.grbLicense.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grbLicense.Location = new System.Drawing.Point(1, 11);
            this.grbLicense.Name = "grbLicense";
            this.grbLicense.Size = new System.Drawing.Size(340, 225);
            this.grbLicense.TabIndex = 5;
            this.grbLicense.Text = "License Setting";
            // 
            // txtKey
            // 
            appearance22.FontData.Name = "맑은 고딕";
            appearance22.FontData.SizeInPoints = 10F;
            this.txtKey.Appearance = appearance22;
            this.txtKey.AutoSize = false;
            this.txtKey.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtKey.Location = new System.Drawing.Point(10, 123);
            this.txtKey.Name = "txtKey";
            this.txtKey.PasswordChar = '*';
            this.txtKey.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtKey.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtKey.Size = new System.Drawing.Size(320, 95);
            this.txtKey.TabIndex = 1020;
            // 
            // lblKey_H
            // 
            appearance23.BackColor = System.Drawing.Color.SkyBlue;
            appearance23.FontData.BoldAsString = "False";
            appearance23.FontData.UnderlineAsString = "False";
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextHAlignAsString = "Center";
            appearance23.TextVAlignAsString = "Middle";
            this.lblKey_H.Appearance = appearance23;
            this.lblKey_H.DbField = null;
            this.lblKey_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblKey_H.Location = new System.Drawing.Point(10, 96);
            this.lblKey_H.Name = "lblKey_H";
            this.lblKey_H.Padding = new System.Drawing.Size(10, 0);
            this.lblKey_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblKey_H.Size = new System.Drawing.Size(320, 27);
            this.lblKey_H.TabIndex = 1019;
            this.lblKey_H.Text = "License-Key";
            // 
            // txtMAC
            // 
            appearance19.FontData.Name = "맑은 고딕";
            appearance19.FontData.SizeInPoints = 10F;
            this.txtMAC.Appearance = appearance19;
            this.txtMAC.AutoSize = false;
            this.txtMAC.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtMAC.Location = new System.Drawing.Point(130, 61);
            this.txtMAC.Name = "txtMAC";
            this.txtMAC.PasswordChar = '*';
            this.txtMAC.ReadOnly = true;
            this.txtMAC.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtMAC.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtMAC.Size = new System.Drawing.Size(200, 27);
            this.txtMAC.TabIndex = 1018;
            // 
            // lblMAC_H
            // 
            appearance45.BackColor = System.Drawing.Color.SkyBlue;
            appearance45.FontData.BoldAsString = "False";
            appearance45.FontData.UnderlineAsString = "False";
            appearance45.ForeColor = System.Drawing.Color.Black;
            appearance45.TextHAlignAsString = "Center";
            appearance45.TextVAlignAsString = "Middle";
            this.lblMAC_H.Appearance = appearance45;
            this.lblMAC_H.DbField = null;
            this.lblMAC_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMAC_H.Location = new System.Drawing.Point(10, 61);
            this.lblMAC_H.Name = "lblMAC_H";
            this.lblMAC_H.Padding = new System.Drawing.Size(10, 0);
            this.lblMAC_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblMAC_H.Size = new System.Drawing.Size(120, 27);
            this.lblMAC_H.TabIndex = 1017;
            this.lblMAC_H.Text = "MAC Address";
            // 
            // cboType
            // 
            this.cboType.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(130, 26);
            this.cboType.Margin = new System.Windows.Forms.Padding(0);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(200, 27);
            this.cboType.TabIndex = 1016;
            // 
            // lblType_H
            // 
            appearance2.BackColor = System.Drawing.Color.SkyBlue;
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblType_H.Appearance = appearance2;
            this.lblType_H.DbField = null;
            this.lblType_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblType_H.Location = new System.Drawing.Point(10, 26);
            this.lblType_H.Name = "lblType_H";
            this.lblType_H.Padding = new System.Drawing.Size(10, 0);
            this.lblType_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblType_H.Size = new System.Drawing.Size(120, 27);
            this.lblType_H.TabIndex = 27;
            this.lblType_H.Text = "License Type";
            // 
            // ZZ0200
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(344, 331);
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZZ0200";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ZZ0200_Load);
            this.pnlMain.ClientArea.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbDB)).EndInit();
            this.grbDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtConn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbLicense)).EndInit();
            this.grbLicense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraPanel pnlMain;
        private Infragistics.Win.Misc.UltraGroupBox grbDB;
        private Infragistics.Win.Misc.UltraButton btnTest;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnSave;
        private WIZ.Control.STextBox txtConn;
		private Infragistics.Win.Misc.UltraGroupBox grbLicense;
		private Infragistics.Win.Misc.UltraButton btnLicense;
		private WIZ.Control.SLabel lblType_H;
		private WIZ.Control.STextBox txtKey;
		private WIZ.Control.SLabel lblKey_H;
		private WIZ.Control.STextBox txtMAC;
		private WIZ.Control.SLabel lblMAC_H;
		private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.ComboBox cboCompany;
        private WIZ.Control.SLabel sLabel1;
    }
}


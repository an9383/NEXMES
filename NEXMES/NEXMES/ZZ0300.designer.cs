namespace NEXMES
{
    partial class ZZ0300
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
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            this.pnlSplash = new Infragistics.Win.Misc.UltraPanel();
            this.txtPwdChg = new WIZ.Control.STextBox(this.components);
            this.txtPWDChk = new WIZ.Control.STextBox(this.components);
            this.sLabel3 = new WIZ.Control.SLabel();
            this.txtID = new WIZ.Control.STextBox(this.components);
            this.sLabel2 = new WIZ.Control.SLabel();
            this.sLabel4 = new WIZ.Control.SLabel();
            this.txtPwdNow = new WIZ.Control.STextBox(this.components);
            this.sLabel5 = new WIZ.Control.SLabel();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnSave = new Infragistics.Win.Misc.UltraButton();
            this.pnlSplash.ClientArea.SuspendLayout();
            this.pnlSplash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdChg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPWDChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdNow)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSplash
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BorderColor = System.Drawing.Color.LightGray;
            this.pnlSplash.Appearance = appearance1;
            this.pnlSplash.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlSplash.ClientArea
            // 
            this.pnlSplash.ClientArea.Controls.Add(this.txtPwdChg);
            this.pnlSplash.ClientArea.Controls.Add(this.txtPWDChk);
            this.pnlSplash.ClientArea.Controls.Add(this.sLabel3);
            this.pnlSplash.ClientArea.Controls.Add(this.txtID);
            this.pnlSplash.ClientArea.Controls.Add(this.sLabel2);
            this.pnlSplash.ClientArea.Controls.Add(this.sLabel4);
            this.pnlSplash.ClientArea.Controls.Add(this.txtPwdNow);
            this.pnlSplash.ClientArea.Controls.Add(this.sLabel5);
            this.pnlSplash.ClientArea.Controls.Add(this.btnClose);
            this.pnlSplash.ClientArea.Controls.Add(this.btnSave);
            this.pnlSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSplash.Location = new System.Drawing.Point(0, 0);
            this.pnlSplash.Name = "pnlSplash";
            this.pnlSplash.Size = new System.Drawing.Size(361, 228);
            this.pnlSplash.TabIndex = 4;
            this.pnlSplash.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlSplash_MouseDown);
            this.pnlSplash.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlSplash_MouseMove);
            this.pnlSplash.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlSplash_MouseUp);
            // 
            // txtPwdChg
            // 
            appearance22.FontData.BoldAsString = "False";
            appearance22.FontData.Name = "맑은 고딕";
            appearance22.FontData.SizeInPoints = 10F;
            appearance22.FontData.UnderlineAsString = "False";
            appearance22.ForeColor = System.Drawing.Color.Black;
            this.txtPwdChg.Appearance = appearance22;
            this.txtPwdChg.AutoSize = false;
            this.txtPwdChg.Location = new System.Drawing.Point(132, 79);
            this.txtPwdChg.Name = "txtPwdChg";
            this.txtPwdChg.PasswordChar = '*';
            this.txtPwdChg.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtPwdChg.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtPwdChg.Size = new System.Drawing.Size(213, 27);
            this.txtPwdChg.TabIndex = 2;
            // 
            // txtPWDChk
            // 
            appearance14.FontData.BoldAsString = "False";
            appearance14.FontData.Name = "맑은 고딕";
            appearance14.FontData.SizeInPoints = 10F;
            appearance14.FontData.UnderlineAsString = "False";
            appearance14.ForeColor = System.Drawing.Color.Black;
            this.txtPWDChk.Appearance = appearance14;
            this.txtPWDChk.AutoSize = false;
            this.txtPWDChk.Location = new System.Drawing.Point(132, 114);
            this.txtPWDChk.Name = "txtPWDChk";
            this.txtPWDChk.PasswordChar = '*';
            this.txtPWDChk.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtPWDChk.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtPWDChk.Size = new System.Drawing.Size(213, 27);
            this.txtPWDChk.TabIndex = 3;
            // 
            // sLabel3
            // 
            appearance15.BackColor = System.Drawing.Color.SkyBlue;
            appearance15.FontData.BoldAsString = "False";
            appearance15.FontData.UnderlineAsString = "False";
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.sLabel3.Appearance = appearance15;
            this.sLabel3.DbField = null;
            this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel3.Location = new System.Drawing.Point(12, 114);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Padding = new System.Drawing.Size(10, 0);
            this.sLabel3.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(120, 27);
            this.sLabel3.TabIndex = 29;
            this.sLabel3.Text = "비밀번호 확인";
            // 
            // txtID
            // 
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.Name = "맑은 고딕";
            appearance17.FontData.SizeInPoints = 10F;
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            this.txtID.Appearance = appearance17;
            this.txtID.AutoSize = false;
            this.txtID.Location = new System.Drawing.Point(132, 9);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtID.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtID.Size = new System.Drawing.Size(213, 27);
            this.txtID.TabIndex = 0;
            // 
            // sLabel2
            // 
            appearance19.BackColor = System.Drawing.Color.SkyBlue;
            appearance19.FontData.BoldAsString = "False";
            appearance19.FontData.StrikeoutAsString = "False";
            appearance19.FontData.UnderlineAsString = "False";
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextHAlignAsString = "Right";
            appearance19.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance19;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(12, 9);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.Padding = new System.Drawing.Size(10, 0);
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(120, 27);
            this.sLabel2.TabIndex = 23;
            this.sLabel2.Text = "사용자 ID";
            // 
            // sLabel4
            // 
            appearance21.BackColor = System.Drawing.Color.SkyBlue;
            appearance21.FontData.BoldAsString = "False";
            appearance21.FontData.UnderlineAsString = "False";
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Right";
            appearance21.TextVAlignAsString = "Middle";
            this.sLabel4.Appearance = appearance21;
            this.sLabel4.DbField = null;
            this.sLabel4.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel4.Location = new System.Drawing.Point(12, 79);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.Padding = new System.Drawing.Size(10, 0);
            this.sLabel4.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel4.Size = new System.Drawing.Size(120, 27);
            this.sLabel4.TabIndex = 27;
            this.sLabel4.Text = "변경 비밀번호";
            // 
            // txtPwdNow
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.Name = "맑은 고딕";
            appearance2.FontData.SizeInPoints = 10F;
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.txtPwdNow.Appearance = appearance2;
            this.txtPwdNow.AutoSize = false;
            this.txtPwdNow.Location = new System.Drawing.Point(132, 44);
            this.txtPwdNow.Name = "txtPwdNow";
            this.txtPwdNow.PasswordChar = '*';
            this.txtPwdNow.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtPwdNow.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtPwdNow.Size = new System.Drawing.Size(213, 27);
            this.txtPwdNow.TabIndex = 1;
            // 
            // sLabel5
            // 
            appearance23.BackColor = System.Drawing.Color.SkyBlue;
            appearance23.FontData.BoldAsString = "False";
            appearance23.FontData.UnderlineAsString = "False";
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextHAlignAsString = "Right";
            appearance23.TextVAlignAsString = "Middle";
            this.sLabel5.Appearance = appearance23;
            this.sLabel5.DbField = null;
            this.sLabel5.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel5.Location = new System.Drawing.Point(12, 44);
            this.sLabel5.Name = "sLabel5";
            this.sLabel5.Padding = new System.Drawing.Size(10, 0);
            this.sLabel5.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel5.Size = new System.Drawing.Size(120, 27);
            this.sLabel5.TabIndex = 25;
            this.sLabel5.Text = "현재 비밀번호";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(195, 157);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 40);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "닫기";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnSave.Location = new System.Drawing.Point(12, 158);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "저장";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ZZ0300
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(361, 228);
            this.Controls.Add(this.pnlSplash);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZZ0300";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlSplash.ClientArea.ResumeLayout(false);
            this.pnlSplash.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdChg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPWDChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdNow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraPanel pnlSplash;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnSave;
        private WIZ.Control.STextBox txtPWDChk;
        private WIZ.Control.SLabel sLabel3;
        private WIZ.Control.STextBox txtID;
        private WIZ.Control.SLabel sLabel2;
        private WIZ.Control.SLabel sLabel4;
        private WIZ.Control.STextBox txtPwdNow;
        private WIZ.Control.SLabel sLabel5;
        private WIZ.Control.STextBox txtPwdChg;
    }
}


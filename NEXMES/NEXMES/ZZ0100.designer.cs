namespace NEXMES
{
    partial class ZZ0100
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZZ0100));
            this.pnlSplash = new Infragistics.Win.Misc.UltraPanel();
            this.pnlUpdate_M = new System.Windows.Forms.Panel();
            this.picUpdate = new System.Windows.Forms.PictureBox();
            this.txtLogo = new System.Windows.Forms.RichTextBox();
            this.pnlUpdate_T = new System.Windows.Forms.Panel();
            this.pnlSplash.ClientArea.SuspendLayout();
            this.pnlSplash.SuspendLayout();
            this.pnlUpdate_M.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSplash
            // 
            appearance3.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlSplash.Appearance = appearance3;
            this.pnlSplash.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlSplash.ClientArea
            // 
            this.pnlSplash.ClientArea.Controls.Add(this.pnlUpdate_M);
            this.pnlSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSplash.Location = new System.Drawing.Point(0, 0);
            this.pnlSplash.Name = "pnlSplash";
            this.pnlSplash.Size = new System.Drawing.Size(585, 190);
            this.pnlSplash.TabIndex = 3;
            // 
            // pnlUpdate_M
            // 
            this.pnlUpdate_M.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpdate_M.Controls.Add(this.picUpdate);
            this.pnlUpdate_M.Controls.Add(this.txtLogo);
            this.pnlUpdate_M.Location = new System.Drawing.Point(5, 55);
            this.pnlUpdate_M.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUpdate_M.Name = "pnlUpdate_M";
            this.pnlUpdate_M.Size = new System.Drawing.Size(573, 128);
            this.pnlUpdate_M.TabIndex = 26;
            // 
            // picUpdate
            // 
            this.picUpdate.BackColor = System.Drawing.Color.White;
            this.picUpdate.Image = global::NEXMES.Properties.Resources.Update;
            this.picUpdate.Location = new System.Drawing.Point(2, 2);
            this.picUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.picUpdate.Name = "picUpdate";
            this.picUpdate.Size = new System.Drawing.Size(125, 122);
            this.picUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUpdate.TabIndex = 25;
            this.picUpdate.TabStop = false;
            // 
            // txtLogo
            // 
            this.txtLogo.BackColor = System.Drawing.Color.White;
            this.txtLogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLogo.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLogo.ForeColor = System.Drawing.Color.Orange;
            this.txtLogo.Location = new System.Drawing.Point(143, 4);
            this.txtLogo.Name = "txtLogo";
            this.txtLogo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtLogo.Size = new System.Drawing.Size(424, 118);
            this.txtLogo.TabIndex = 26;
            this.txtLogo.Text = "";
            this.txtLogo.WordWrap = false;
            // 
            // pnlUpdate_T
            // 
            this.pnlUpdate_T.BackColor = System.Drawing.Color.White;
            this.pnlUpdate_T.BackgroundImage = global::NEXMES.Properties.Resources.Update_T;
            this.pnlUpdate_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlUpdate_T.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdate_T.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdate_T.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUpdate_T.Name = "pnlUpdate_T";
            this.pnlUpdate_T.Size = new System.Drawing.Size(585, 50);
            this.pnlUpdate_T.TabIndex = 26;
            // 
            // ZZ0100
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(585, 190);
            this.Controls.Add(this.pnlUpdate_T);
            this.Controls.Add(this.pnlSplash);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ZZ0100";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPLASH";
            this.Load += new System.EventHandler(this.ZZ0100_Load);
            this.pnlSplash.ClientArea.ResumeLayout(false);
            this.pnlSplash.ResumeLayout(false);
            this.pnlUpdate_M.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private Infragistics.Win.Misc.UltraPanel pnlSplash;
        private System.Windows.Forms.Panel pnlUpdate_T;
        private System.Windows.Forms.Panel pnlUpdate_M;
        private System.Windows.Forms.PictureBox picUpdate;
        private System.Windows.Forms.RichTextBox txtLogo;
    }
}


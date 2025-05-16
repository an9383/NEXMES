namespace WIZ.PopUp
{
    partial class BM0071_POP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BM0071_POP));
            this.pnlImage = new Infragistics.Win.Misc.UltraPanel();
            this.pnlControl = new Infragistics.Win.Misc.UltraPanel();
            this.btnDownload = new Infragistics.Win.Misc.UltraButton();
            this.btnLoad = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.lblTotPage = new Infragistics.Win.Misc.UltraLabel();
            this.lblCurPage = new Infragistics.Win.Misc.UltraLabel();
            this.btnNext = new Infragistics.Win.Misc.UltraButton();
            this.btnPre = new Infragistics.Win.Misc.UltraButton();
            this.btnSave = new Infragistics.Win.Misc.UltraButton();
            this.btnDelete = new Infragistics.Win.Misc.UltraButton();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.picMachImage = new System.Windows.Forms.PictureBox();
            this.pnlImage.ClientArea.SuspendLayout();
            this.pnlImage.SuspendLayout();
            this.pnlControl.ClientArea.SuspendLayout();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMachImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlImage
            // 
            // 
            // pnlImage.ClientArea
            // 
            this.pnlImage.ClientArea.Controls.Add(this.picMachImage);
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImage.Location = new System.Drawing.Point(0, 0);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(1920, 1080);
            this.pnlImage.TabIndex = 0;
            // 
            // pnlControl
            // 
            // 
            // pnlControl.ClientArea
            // 
            this.pnlControl.ClientArea.Controls.Add(this.btnDownload);
            this.pnlControl.ClientArea.Controls.Add(this.btnLoad);
            this.pnlControl.ClientArea.Controls.Add(this.ultraLabel1);
            this.pnlControl.ClientArea.Controls.Add(this.lblTotPage);
            this.pnlControl.ClientArea.Controls.Add(this.lblCurPage);
            this.pnlControl.ClientArea.Controls.Add(this.btnNext);
            this.pnlControl.ClientArea.Controls.Add(this.btnPre);
            this.pnlControl.ClientArea.Controls.Add(this.btnSave);
            this.pnlControl.ClientArea.Controls.Add(this.btnDelete);
            this.pnlControl.ClientArea.Controls.Add(this.btnClose);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControl.Location = new System.Drawing.Point(1920, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(60, 1080);
            this.pnlControl.TabIndex = 1;
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnDownload.Location = new System.Drawing.Point(3, 458);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(55, 52);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.Text = "다운로드";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnLoad.Location = new System.Drawing.Point(3, 272);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(55, 52);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "열기";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ultraLabel1
            // 
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.SizeInPoints = 10F;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.Location = new System.Drawing.Point(20, 161);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(23, 23);
            this.ultraLabel1.TabIndex = 8;
            this.ultraLabel1.Text = "/";
            // 
            // lblTotPage
            // 
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.SizeInPoints = 10F;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblTotPage.Appearance = appearance2;
            this.lblTotPage.Location = new System.Drawing.Point(20, 187);
            this.lblTotPage.Name = "lblTotPage";
            this.lblTotPage.Size = new System.Drawing.Size(23, 23);
            this.lblTotPage.TabIndex = 7;
            this.lblTotPage.Text = "0";
            // 
            // lblCurPage
            // 
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.SizeInPoints = 10F;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblCurPage.Appearance = appearance3;
            this.lblCurPage.Location = new System.Drawing.Point(20, 135);
            this.lblCurPage.Name = "lblCurPage";
            this.lblCurPage.Size = new System.Drawing.Size(23, 23);
            this.lblCurPage.TabIndex = 6;
            this.lblCurPage.Text = "0";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnNext.Location = new System.Drawing.Point(3, 210);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(55, 52);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = ">>>";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnPre.Location = new System.Drawing.Point(3, 81);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(55, 52);
            this.btnPre.TabIndex = 4;
            this.btnPre.Text = "<<<";
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(3, 334);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 52);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "저장";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(3, 396);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 52);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "삭제";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(3, 520);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 52);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picMachImage
            // 
            this.picMachImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMachImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMachImage.InitialImage = global::WIZ.PopUp.Properties.Resources.Default_Image2;
            this.picMachImage.Location = new System.Drawing.Point(0, 0);
            this.picMachImage.Name = "picMachImage";
            this.picMachImage.Size = new System.Drawing.Size(1920, 1080);
            this.picMachImage.TabIndex = 0;
            this.picMachImage.TabStop = false;
            // 
            // BM0071_POP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1980, 1080);
            this.Controls.Add(this.pnlImage);
            this.Controls.Add(this.pnlControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BM0071_POP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "설비 이미지 POP-UP";
            this.pnlImage.ClientArea.ResumeLayout(false);
            this.pnlImage.ResumeLayout(false);
            this.pnlControl.ClientArea.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMachImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraPanel pnlImage;
        private Infragistics.Win.Misc.UltraPanel pnlControl;
        private Infragistics.Win.Misc.UltraButton btnLoad;
        private Infragistics.Win.Misc.UltraButton btnSave;
        private Infragistics.Win.Misc.UltraButton btnDelete;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnNext;
        private Infragistics.Win.Misc.UltraButton btnPre;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel lblTotPage;
        private Infragistics.Win.Misc.UltraLabel lblCurPage;
        private System.Windows.Forms.PictureBox picMachImage;
        private Infragistics.Win.Misc.UltraButton btnDownload;
    }
}
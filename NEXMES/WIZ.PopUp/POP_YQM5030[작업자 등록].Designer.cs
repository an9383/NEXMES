namespace WIZ.PopUp
{
    partial class POP_YQM5030
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POP_YQM5030));
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.lblSabeon = new WIZ.Control.SLabel();
            this.tSabeon = new System.Windows.Forms.TextBox();
            this.tName = new System.Windows.Forms.TextBox();
            this.lblName = new WIZ.Control.SLabel();
            this.tDept_Name = new System.Windows.Forms.TextBox();
            this.lblDept_Name = new WIZ.Control.SLabel();
            this.lblladmin = new WIZ.Control.SLabel();
            this.INITAIL = new WIZ.Control.SLabel();
            this.BtnWrite = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.lblSection = new WIZ.Control.SLabel();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboSection = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboIadmin = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboAlpha = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboIadmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlpha)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlantCode
            // 
            appearance6.FontData.BoldAsString = "False";
            appearance6.FontData.SizeInPoints = 9.75F;
            appearance6.FontData.UnderlineAsString = "False";
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance6;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = "cboUseFlag";
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(13, 13);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(154, 26);
            this.lblPlantCode.TabIndex = 0;
            this.lblPlantCode.Text = "사업장";
            // 
            // lblSabeon
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.SizeInPoints = 9.75F;
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.lblSabeon.Appearance = appearance3;
            this.lblSabeon.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblSabeon.DbField = "cboUseFlag";
            this.lblSabeon.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSabeon.Location = new System.Drawing.Point(13, 73);
            this.lblSabeon.Name = "lblSabeon";
            this.lblSabeon.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblSabeon.Size = new System.Drawing.Size(154, 26);
            this.lblSabeon.TabIndex = 0;
            this.lblSabeon.Text = "사번";
            // 
            // tSabeon
            // 
            this.tSabeon.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tSabeon.Location = new System.Drawing.Point(13, 98);
            this.tSabeon.Name = "tSabeon";
            this.tSabeon.Size = new System.Drawing.Size(155, 25);
            this.tSabeon.TabIndex = 3;
            this.tSabeon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tName
            // 
            this.tName.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tName.Location = new System.Drawing.Point(191, 98);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(155, 25);
            this.tName.TabIndex = 4;
            this.tName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblName
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.SizeInPoints = 9.75F;
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.lblName.Appearance = appearance4;
            this.lblName.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblName.DbField = "cboUseFlag";
            this.lblName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblName.Location = new System.Drawing.Point(191, 73);
            this.lblName.Name = "lblName";
            this.lblName.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblName.Size = new System.Drawing.Size(155, 26);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "이름";
            // 
            // tDept_Name
            // 
            this.tDept_Name.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tDept_Name.Location = new System.Drawing.Point(12, 158);
            this.tDept_Name.Name = "tDept_Name";
            this.tDept_Name.Size = new System.Drawing.Size(155, 25);
            this.tDept_Name.TabIndex = 5;
            this.tDept_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDept_Name
            // 
            appearance12.FontData.BoldAsString = "False";
            appearance12.FontData.SizeInPoints = 9.75F;
            appearance12.FontData.UnderlineAsString = "False";
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.lblDept_Name.Appearance = appearance12;
            this.lblDept_Name.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblDept_Name.DbField = "cboUseFlag";
            this.lblDept_Name.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDept_Name.Location = new System.Drawing.Point(13, 133);
            this.lblDept_Name.Name = "lblDept_Name";
            this.lblDept_Name.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDept_Name.Size = new System.Drawing.Size(155, 26);
            this.lblDept_Name.TabIndex = 0;
            this.lblDept_Name.Text = "부서명";
            // 
            // lblladmin
            // 
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.SizeInPoints = 9.75F;
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.lblladmin.Appearance = appearance5;
            this.lblladmin.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblladmin.DbField = "cboUseFlag";
            this.lblladmin.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblladmin.Location = new System.Drawing.Point(191, 133);
            this.lblladmin.Name = "lblladmin";
            this.lblladmin.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblladmin.Size = new System.Drawing.Size(155, 26);
            this.lblladmin.TabIndex = 0;
            this.lblladmin.Text = "확인자";
            // 
            // INITAIL
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.SizeInPoints = 9.75F;
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.INITAIL.Appearance = appearance1;
            this.INITAIL.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.INITAIL.DbField = "cboUseFlag";
            this.INITAIL.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.INITAIL.Location = new System.Drawing.Point(13, 193);
            this.INITAIL.Name = "INITAIL";
            this.INITAIL.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.INITAIL.Size = new System.Drawing.Size(154, 26);
            this.INITAIL.TabIndex = 0;
            this.INITAIL.Text = "Init";
            // 
            // BtnWrite
            // 
            this.BtnWrite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnWrite.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnWrite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnWrite.Location = new System.Drawing.Point(13, 263);
            this.BtnWrite.Name = "BtnWrite";
            this.BtnWrite.Size = new System.Drawing.Size(104, 41);
            this.BtnWrite.TabIndex = 8;
            this.BtnWrite.Text = "저장";
            this.BtnWrite.UseVisualStyleBackColor = true;
            this.BtnWrite.Click += new System.EventHandler(this.BtnWrite_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDelete.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDelete.Location = new System.Drawing.Point(128, 263);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(104, 41);
            this.BtnDelete.TabIndex = 9;
            this.BtnDelete.Text = "삭제";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClose.Location = new System.Drawing.Point(242, 263);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(104, 41);
            this.BtnClose.TabIndex = 10;
            this.BtnClose.Text = "닫기";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblSection
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.SizeInPoints = 9.75F;
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lblSection.Appearance = appearance2;
            this.lblSection.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblSection.DbField = "cboUseFlag";
            this.lblSection.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSection.Location = new System.Drawing.Point(191, 13);
            this.lblSection.Name = "lblSection";
            this.lblSection.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblSection.Size = new System.Drawing.Size(157, 26);
            this.lblSection.TabIndex = 0;
            this.lblSection.Text = "구분";
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboPlantCode_H.Location = new System.Drawing.Point(13, 38);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(157, 26);
            this.cboPlantCode_H.TabIndex = 1;
            // 
            // cboSection
            // 
            this.cboSection.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboSection.Location = new System.Drawing.Point(191, 38);
            this.cboSection.Name = "cboSection";
            this.cboSection.Size = new System.Drawing.Size(157, 26);
            this.cboSection.TabIndex = 2;
            // 
            // cboIadmin
            // 
            this.cboIadmin.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboIadmin.Location = new System.Drawing.Point(191, 157);
            this.cboIadmin.Name = "cboIadmin";
            this.cboIadmin.Size = new System.Drawing.Size(157, 26);
            this.cboIadmin.TabIndex = 6;
            // 
            // cboAlpha
            // 
            this.cboAlpha.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboAlpha.Location = new System.Drawing.Point(13, 218);
            this.cboAlpha.Name = "cboAlpha";
            this.cboAlpha.Size = new System.Drawing.Size(157, 26);
            this.cboAlpha.TabIndex = 7;
            // 
            // POP_YQM5030
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(366, 314);
            this.Controls.Add(this.cboAlpha);
            this.Controls.Add(this.cboIadmin);
            this.Controls.Add(this.cboSection);
            this.Controls.Add(this.cboPlantCode_H);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnWrite);
            this.Controls.Add(this.INITAIL);
            this.Controls.Add(this.lblladmin);
            this.Controls.Add(this.tDept_Name);
            this.Controls.Add(this.lblDept_Name);
            this.Controls.Add(this.tName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tSabeon);
            this.Controls.Add(this.lblSabeon);
            this.Controls.Add(this.lblPlantCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "POP_YQM5030";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "작업자 등록";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.POP_YQM5030_FormClosing);
            this.Load += new System.EventHandler(this.POP_YQM5030_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboIadmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlpha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.SLabel lblPlantCode;
        private Control.SLabel lblSabeon;
        private System.Windows.Forms.TextBox tSabeon;
        private System.Windows.Forms.TextBox tName;
        private Control.SLabel lblName;
        private System.Windows.Forms.TextBox tDept_Name;
        private Control.SLabel lblDept_Name;
        private Control.SLabel lblladmin;
        private Control.SLabel INITAIL;
        internal System.Windows.Forms.Button BtnWrite;
        internal System.Windows.Forms.Button BtnDelete;
        internal System.Windows.Forms.Button BtnClose;
        private Control.SLabel lblSection;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboSection;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboIadmin;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboAlpha;
    }
}

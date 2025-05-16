namespace WIZ.PopUp
{
    partial class POP_MM9900
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POP_MM9900));
            this.cboCloseYear = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnEndDate = new System.Windows.Forms.Button();
            this.lblCloseYear = new WIZ.Control.SLabel();
            this.cboDeptCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblDeptCode = new WIZ.Control.SLabel();
            this.lblMsg = new WIZ.Control.SLabel();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPlantCode = new WIZ.Control.SLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cboCloseYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDeptCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCloseYear
            // 
            this.cboCloseYear.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboCloseYear.Location = new System.Drawing.Point(61, 86);
            this.cboCloseYear.Name = "cboCloseYear";
            this.cboCloseYear.Size = new System.Drawing.Size(135, 27);
            this.cboCloseYear.TabIndex = 77;
            // 
            // btnEndDate
            // 
            this.btnEndDate.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEndDate.Location = new System.Drawing.Point(223, 22);
            this.btnEndDate.Name = "btnEndDate";
            this.btnEndDate.Size = new System.Drawing.Size(117, 91);
            this.btnEndDate.TabIndex = 76;
            this.btnEndDate.Text = "생성";
            this.btnEndDate.UseVisualStyleBackColor = true;
            this.btnEndDate.Click += new System.EventHandler(this.btnEndDate_Click);
            // 
            // lblCloseYear
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblCloseYear.Appearance = appearance1;
            this.lblCloseYear.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblCloseYear.DbField = null;
            this.lblCloseYear.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCloseYear.Location = new System.Drawing.Point(0, 86);
            this.lblCloseYear.Name = "lblCloseYear";
            this.lblCloseYear.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblCloseYear.Size = new System.Drawing.Size(55, 25);
            this.lblCloseYear.TabIndex = 75;
            this.lblCloseYear.Text = "년도";
            // 
            // cboDeptCode
            // 
            this.cboDeptCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboDeptCode.Location = new System.Drawing.Point(61, 53);
            this.cboDeptCode.Name = "cboDeptCode";
            this.cboDeptCode.Size = new System.Drawing.Size(135, 27);
            this.cboDeptCode.TabIndex = 73;
            // 
            // lblDeptCode
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.lblDeptCode.Appearance = appearance4;
            this.lblDeptCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblDeptCode.DbField = null;
            this.lblDeptCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDeptCode.Location = new System.Drawing.Point(0, 55);
            this.lblDeptCode.Name = "lblDeptCode";
            this.lblDeptCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDeptCode.Size = new System.Drawing.Size(55, 25);
            this.lblDeptCode.TabIndex = 74;
            this.lblDeptCode.Text = "업무";
            // 
            // lblMsg
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Red;
            this.lblMsg.Appearance = appearance2;
            this.lblMsg.DbField = null;
            this.lblMsg.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMsg.Location = new System.Drawing.Point(21, 139);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblMsg.Size = new System.Drawing.Size(340, 34);
            this.lblMsg.TabIndex = 78;
            this.lblMsg.Text = "※ 년도 선택 후 생성시 1년치 마감일자(월별 마지막 일자)가 \r\n자동 생성 됩니다.";
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(61, 22);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(135, 27);
            this.cboPlantCode_H.TabIndex = 79;
            // 
            // lblPlantCode
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance3;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(0, 24);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(55, 25);
            this.lblPlantCode.TabIndex = 80;
            this.lblPlantCode.Text = "공장";
            // 
            // POP_MM9900
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 201);
            this.Controls.Add(this.cboPlantCode_H);
            this.Controls.Add(this.lblPlantCode);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.cboCloseYear);
            this.Controls.Add(this.btnEndDate);
            this.Controls.Add(this.lblCloseYear);
            this.Controls.Add(this.cboDeptCode);
            this.Controls.Add(this.lblDeptCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "POP_MM9900";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "월 마감일자 생성";
            this.Load += new System.EventHandler(this.POP_MM9900_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboCloseYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDeptCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboCloseYear;
        private System.Windows.Forms.Button btnEndDate;
        private Control.SLabel lblCloseYear;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboDeptCode;
        private Control.SLabel lblDeptCode;
        private Control.SLabel lblMsg;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Control.SLabel lblPlantCode;
    }
}
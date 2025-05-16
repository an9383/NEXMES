namespace WIZ.WM
{
    partial class WM0900
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
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPlanInput = new Infragistics.Win.Misc.UltraButton();
            this.sLabel4 = new WIZ.Control.SLabel();
            this.sLabel2 = new WIZ.Control.SLabel();
            this.cboCloseMonth = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.sLabel1 = new WIZ.Control.SLabel();
            this.txtCloseDay = new System.Windows.Forms.TextBox();
            this.txtStdMonth = new System.Windows.Forms.TextBox();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtPrcFlag = new System.Windows.Forms.TextBox();
            this.lblPoNo = new WIZ.Control.SLabel();
            this.sLabel3 = new WIZ.Control.SLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCloseMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.panel1);
            this.gbxHeader.Controls.Add(this.ultraLabel4);
            this.gbxHeader.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.gbxHeader.Size = new System.Drawing.Size(1167, 65);
            this.gbxHeader.Controls.SetChildIndex(this.ultraLabel4, 0);
            this.gbxHeader.Controls.SetChildIndex(this.panel1, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.panel2);
            this.gbxBody.Location = new System.Drawing.Point(0, 65);
            this.gbxBody.Size = new System.Drawing.Size(1167, 681);
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ultraLabel4.Location = new System.Drawing.Point(824, 24);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(13, 18);
            this.ultraLabel4.TabIndex = 18;
            this.ultraLabel4.Text = "~";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(46, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1117, 57);
            this.panel1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(46, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 50);
            this.label1.TabIndex = 22;
            this.label1.Text = "월 재고 이월 처리";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPlanInput);
            this.panel2.Controls.Add(this.sLabel4);
            this.panel2.Controls.Add(this.sLabel2);
            this.panel2.Controls.Add(this.cboCloseMonth);
            this.panel2.Controls.Add(this.sLabel1);
            this.panel2.Controls.Add(this.txtCloseDay);
            this.panel2.Controls.Add(this.txtStdMonth);
            this.panel2.Controls.Add(this.cboPlantCode_H);
            this.panel2.Controls.Add(this.txtPrcFlag);
            this.panel2.Controls.Add(this.lblPoNo);
            this.panel2.Controls.Add(this.sLabel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1155, 669);
            this.panel2.TabIndex = 542;
            // 
            // btnPlanInput
            // 
            this.btnPlanInput.Font = new System.Drawing.Font("맑은 고딕", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPlanInput.Location = new System.Drawing.Point(39, 229);
            this.btnPlanInput.Name = "btnPlanInput";
            this.btnPlanInput.Size = new System.Drawing.Size(250, 45);
            this.btnPlanInput.TabIndex = 552;
            this.btnPlanInput.Text = "CLEAR";
            this.btnPlanInput.Click += new System.EventHandler(this.btnPlanInput_Click);
            // 
            // sLabel4
            // 
            appearance70.FontData.BoldAsString = "False";
            appearance70.FontData.UnderlineAsString = "False";
            appearance70.ForeColor = System.Drawing.Color.Black;
            appearance70.TextHAlignAsString = "Right";
            appearance70.TextVAlignAsString = "Middle";
            this.sLabel4.Appearance = appearance70;
            this.sLabel4.DbField = "cboUseFlag";
            this.sLabel4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel4.Location = new System.Drawing.Point(23, 103);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel4.Size = new System.Drawing.Size(108, 25);
            this.sLabel4.TabIndex = 551;
            this.sLabel4.Text = "최근 기준월";
            // 
            // sLabel2
            // 
            appearance14.FontData.BoldAsString = "False";
            appearance14.FontData.UnderlineAsString = "False";
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Right";
            appearance14.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance14;
            this.sLabel2.DbField = "cboUseFlag";
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(23, 144);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(108, 25);
            this.sLabel2.TabIndex = 550;
            this.sLabel2.Text = "월마감 기준일";
            // 
            // cboCloseMonth
            // 
            appearance3.FontData.Name = "맑은고딕";
            appearance3.FontData.SizeInPoints = 11F;
            this.cboCloseMonth.Appearance = appearance3;
            this.cboCloseMonth.DateButtons.Add(dateButton1);
            this.cboCloseMonth.Format = "yyyy-MM";
            this.cboCloseMonth.Location = new System.Drawing.Point(137, 185);
            this.cboCloseMonth.Name = "cboCloseMonth";
            this.cboCloseMonth.NonAutoSizeHeight = 26;
            this.cboCloseMonth.Size = new System.Drawing.Size(152, 26);
            this.cboCloseMonth.SpinButtonIncrement = Infragistics.Win.UltraWinSchedule.SpinIncrementUnit.Months;
            this.cboCloseMonth.SpinButtonsVisible = true;
            this.cboCloseMonth.TabIndex = 549;
            this.cboCloseMonth.Value = new System.DateTime(2015, 11, 24, 0, 0, 0, 0);
            // 
            // sLabel1
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance1;
            this.sLabel1.DbField = "cboUseFlag";
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(23, 185);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(108, 25);
            this.sLabel1.TabIndex = 548;
            this.sLabel1.Text = "이월 기준월";
            // 
            // txtCloseDay
            // 
            this.txtCloseDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCloseDay.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtCloseDay.Location = new System.Drawing.Point(137, 144);
            this.txtCloseDay.Name = "txtCloseDay";
            this.txtCloseDay.Size = new System.Drawing.Size(152, 25);
            this.txtCloseDay.TabIndex = 547;
            // 
            // txtStdMonth
            // 
            this.txtStdMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStdMonth.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtStdMonth.Location = new System.Drawing.Point(137, 103);
            this.txtStdMonth.Name = "txtStdMonth";
            this.txtStdMonth.Size = new System.Drawing.Size(152, 25);
            this.txtStdMonth.TabIndex = 546;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Location = new System.Drawing.Point(137, 21);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(152, 29);
            this.cboPlantCode_H.TabIndex = 542;
            this.cboPlantCode_H.Text = "cboPlantCode_H";
            // 
            // txtPrcFlag
            // 
            this.txtPrcFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrcFlag.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtPrcFlag.Location = new System.Drawing.Point(137, 62);
            this.txtPrcFlag.Name = "txtPrcFlag";
            this.txtPrcFlag.ReadOnly = true;
            this.txtPrcFlag.Size = new System.Drawing.Size(152, 25);
            this.txtPrcFlag.TabIndex = 543;
            this.txtPrcFlag.Text = "[MM] 자재업무";
            // 
            // lblPoNo
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblPoNo.Appearance = appearance2;
            this.lblPoNo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPoNo.DbField = null;
            this.lblPoNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPoNo.Location = new System.Drawing.Point(23, 62);
            this.lblPoNo.Name = "lblPoNo";
            this.lblPoNo.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPoNo.Size = new System.Drawing.Size(108, 25);
            this.lblPoNo.TabIndex = 545;
            this.lblPoNo.Text = "업무구분";
            // 
            // sLabel3
            // 
            appearance32.FontData.BoldAsString = "False";
            appearance32.FontData.UnderlineAsString = "False";
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.TextHAlignAsString = "Right";
            appearance32.TextVAlignAsString = "Middle";
            this.sLabel3.Appearance = appearance32;
            this.sLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel3.DbField = null;
            this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel3.Location = new System.Drawing.Point(23, 21);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(108, 25);
            this.sLabel3.TabIndex = 544;
            this.sLabel3.Text = "사업장";
            // 
            // WM0900
            // 
            this.ClientSize = new System.Drawing.Size(1167, 746);
            this.Name = "WM0900";
            this.Text = "월재고 이월";
            this.Load += new System.EventHandler(this.MM0900_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCloseMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private Infragistics.Win.Misc.UltraButton btnPlanInput;
        private Control.SLabel sLabel4;
        private Control.SLabel sLabel2;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboCloseMonth;
        private Control.SLabel sLabel1;
        private System.Windows.Forms.TextBox txtCloseDay;
        private System.Windows.Forms.TextBox txtStdMonth;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private System.Windows.Forms.TextBox txtPrcFlag;
        private Control.SLabel lblPoNo;
        private Control.SLabel sLabel3;
    }
}

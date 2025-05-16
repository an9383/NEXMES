namespace WIZ.MM
{
    partial class MM0900
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
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("dTable1", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ItemCode");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ItemName");
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            this.cboItemCode = new WIZ.Control.ScboGetItemCode();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.cboItemCode)).BeginInit();
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
            this.gbxHeader.Controls.Add(this.cboItemCode);
            this.gbxHeader.Controls.Add(this.ultraLabel4);
            this.gbxHeader.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.gbxHeader.Location = new System.Drawing.Point(3, 3);
            this.gbxHeader.Size = new System.Drawing.Size(1161, 65);
            this.gbxHeader.Visible = false;
            this.gbxHeader.Controls.SetChildIndex(this.ultraLabel4, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.panel1, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.label1);
            this.gbxBody.Controls.Add(this.btnPlanInput);
            this.gbxBody.Controls.Add(this.sLabel4);
            this.gbxBody.Controls.Add(this.sLabel2);
            this.gbxBody.Controls.Add(this.cboCloseMonth);
            this.gbxBody.Controls.Add(this.sLabel1);
            this.gbxBody.Controls.Add(this.txtCloseDay);
            this.gbxBody.Controls.Add(this.txtStdMonth);
            this.gbxBody.Controls.Add(this.cboPlantCode_H);
            this.gbxBody.Controls.Add(this.txtPrcFlag);
            this.gbxBody.Controls.Add(this.lblPoNo);
            this.gbxBody.Controls.Add(this.sLabel3);
            this.gbxBody.Location = new System.Drawing.Point(3, 68);
            this.gbxBody.Size = new System.Drawing.Size(1161, 675);
            // 
            // cboItemCode
            // 
            this.cboItemCode.AutoSize = false;
            this.cboItemCode.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            this.cboItemCode.DataMember = "dTable1";
            this.cboItemCode.DbConfig = null;
            this.cboItemCode.DefaultValue = "";
            appearance41.BackColor = System.Drawing.SystemColors.Window;
            appearance41.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboItemCode.DisplayLayout.Appearance = appearance41;
            this.cboItemCode.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.cboItemCode.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cboItemCode.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboItemCode.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance56.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance56.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance56.BorderColor = System.Drawing.SystemColors.Window;
            this.cboItemCode.DisplayLayout.GroupByBox.Appearance = appearance56;
            appearance57.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboItemCode.DisplayLayout.GroupByBox.BandLabelAppearance = appearance57;
            this.cboItemCode.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance58.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance58.BackColor2 = System.Drawing.SystemColors.Control;
            appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance58.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboItemCode.DisplayLayout.GroupByBox.PromptAppearance = appearance58;
            this.cboItemCode.DisplayLayout.MaxColScrollRegions = 1;
            this.cboItemCode.DisplayLayout.MaxRowScrollRegions = 1;
            appearance59.BackColor = System.Drawing.SystemColors.Window;
            appearance59.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboItemCode.DisplayLayout.Override.ActiveCellAppearance = appearance59;
            appearance60.BackColor = System.Drawing.SystemColors.Highlight;
            appearance60.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cboItemCode.DisplayLayout.Override.ActiveRowAppearance = appearance60;
            this.cboItemCode.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cboItemCode.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance61.BackColor = System.Drawing.SystemColors.Window;
            this.cboItemCode.DisplayLayout.Override.CardAreaAppearance = appearance61;
            appearance62.BorderColor = System.Drawing.Color.Silver;
            appearance62.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cboItemCode.DisplayLayout.Override.CellAppearance = appearance62;
            this.cboItemCode.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cboItemCode.DisplayLayout.Override.CellPadding = 0;
            appearance63.BackColor = System.Drawing.SystemColors.Control;
            appearance63.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance63.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance63.BorderColor = System.Drawing.SystemColors.Window;
            this.cboItemCode.DisplayLayout.Override.GroupByRowAppearance = appearance63;
            appearance65.TextHAlignAsString = "Left";
            this.cboItemCode.DisplayLayout.Override.HeaderAppearance = appearance65;
            this.cboItemCode.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cboItemCode.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance66.BackColor = System.Drawing.SystemColors.Window;
            appearance66.BorderColor = System.Drawing.Color.Silver;
            this.cboItemCode.DisplayLayout.Override.RowAppearance = appearance66;
            this.cboItemCode.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance67.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboItemCode.DisplayLayout.Override.TemplateAddRowAppearance = appearance67;
            this.cboItemCode.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cboItemCode.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cboItemCode.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cboItemCode.DisplayMember = "ItemName";
            this.cboItemCode.ItemType = null;
            this.cboItemCode.Location = new System.Drawing.Point(716, 830);
            this.cboItemCode.Name = "cboItemCode";
            this.cboItemCode.PlantCode = null;
            this.cboItemCode.ShowDefaultValue = false;
            this.cboItemCode.Size = new System.Drawing.Size(165, 26);
            this.cboItemCode.TabIndex = 20;
            this.cboItemCode.ValueMember = "ItemCode";
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(46, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 57);
            this.panel1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 50);
            this.label1.TabIndex = 22;
            this.label1.Text = "월 재고 이월 처리";
            // 
            // btnPlanInput
            // 
            this.btnPlanInput.Font = new System.Drawing.Font("맑은 고딕", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPlanInput.Location = new System.Drawing.Point(23, 314);
            this.btnPlanInput.Name = "btnPlanInput";
            this.btnPlanInput.Size = new System.Drawing.Size(234, 45);
            this.btnPlanInput.TabIndex = 557;
            this.btnPlanInput.Text = "CLEAR";
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
            this.sLabel4.Location = new System.Drawing.Point(23, 171);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel4.Size = new System.Drawing.Size(83, 23);
            this.sLabel4.TabIndex = 562;
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
            this.sLabel2.Location = new System.Drawing.Point(23, 219);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(83, 23);
            this.sLabel2.TabIndex = 561;
            this.sLabel2.Text = "월마감 기준일";
            // 
            // cboCloseMonth
            // 
            appearance3.FontData.Name = "맑은고딕";
            appearance3.FontData.SizeInPoints = 11F;
            this.cboCloseMonth.Appearance = appearance3;
            this.cboCloseMonth.DateButtons.Add(dateButton1);
            this.cboCloseMonth.Format = "yyyy-MM";
            this.cboCloseMonth.Location = new System.Drawing.Point(112, 265);
            this.cboCloseMonth.Name = "cboCloseMonth";
            this.cboCloseMonth.NonAutoSizeHeight = 26;
            this.cboCloseMonth.Size = new System.Drawing.Size(145, 26);
            this.cboCloseMonth.SpinButtonIncrement = Infragistics.Win.UltraWinSchedule.SpinIncrementUnit.Months;
            this.cboCloseMonth.SpinButtonsVisible = true;
            this.cboCloseMonth.TabIndex = 556;
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
            this.sLabel1.Location = new System.Drawing.Point(23, 267);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(83, 23);
            this.sLabel1.TabIndex = 560;
            this.sLabel1.Text = "이월 기준월";
            // 
            // txtCloseDay
            // 
            this.txtCloseDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCloseDay.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtCloseDay.Location = new System.Drawing.Point(112, 217);
            this.txtCloseDay.Name = "txtCloseDay";
            this.txtCloseDay.Size = new System.Drawing.Size(145, 25);
            this.txtCloseDay.TabIndex = 555;
            // 
            // txtStdMonth
            // 
            this.txtStdMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStdMonth.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtStdMonth.Location = new System.Drawing.Point(112, 169);
            this.txtStdMonth.Name = "txtStdMonth";
            this.txtStdMonth.Size = new System.Drawing.Size(145, 25);
            this.txtStdMonth.TabIndex = 554;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(112, 69);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(145, 29);
            this.cboPlantCode_H.TabIndex = 552;
            this.cboPlantCode_H.Text = "cboPlantCode_H";
            // 
            // txtPrcFlag
            // 
            this.txtPrcFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrcFlag.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtPrcFlag.Location = new System.Drawing.Point(112, 121);
            this.txtPrcFlag.Name = "txtPrcFlag";
            this.txtPrcFlag.ReadOnly = true;
            this.txtPrcFlag.Size = new System.Drawing.Size(145, 25);
            this.txtPrcFlag.TabIndex = 553;
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
            this.lblPoNo.Location = new System.Drawing.Point(23, 123);
            this.lblPoNo.Name = "lblPoNo";
            this.lblPoNo.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPoNo.Size = new System.Drawing.Size(83, 23);
            this.lblPoNo.TabIndex = 559;
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
            this.sLabel3.Location = new System.Drawing.Point(23, 71);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(83, 23);
            this.sLabel3.TabIndex = 558;
            this.sLabel3.Text = "사업장";
            // 
            // MM0900
            // 
            this.ClientSize = new System.Drawing.Size(1167, 746);
            this.Name = "MM0900";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "월재고 이월";
            this.Load += new System.EventHandler(this.MM0900_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            this.gbxBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCloseMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.ScboGetItemCode cboItemCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
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

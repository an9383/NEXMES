namespace WIZ.MD
{
    partial class MD1130
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
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.CboStartDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cboEndDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblDate = new WIZ.Control.SLabel();
            this.txtMoldCode = new System.Windows.Forms.TextBox();
            this.txtMoldName = new System.Windows.Forms.TextBox();
            this.lblItemCode = new WIZ.Control.SLabel();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.lblInspWorker = new WIZ.Control.SLabel();
            this.txtInspWorker = new System.Windows.Forms.TextBox();
            this.InspWorker = new System.Windows.Forms.TextBox();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartDate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.lblInspWorker);
            this.gbxHeader.Controls.Add(this.txtInspWorker);
            this.gbxHeader.Controls.Add(this.InspWorker);
            this.gbxHeader.Controls.Add(this.ultraLabel4);
            this.gbxHeader.Controls.Add(this.CboStartDate_H);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Controls.Add(this.cboEndDate_H);
            this.gbxHeader.Controls.Add(this.lblItemCode);
            this.gbxHeader.Controls.Add(this.lblDate);
            this.gbxHeader.Controls.Add(this.txtMoldName);
            this.gbxHeader.Controls.Add(this.txtMoldCode);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 90);
            this.gbxHeader.TabIndex = 0;
            this.gbxHeader.Controls.SetChildIndex(this.txtMoldCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtMoldName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboEndDate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboStartDate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.ultraLabel4, 0);
            this.gbxHeader.Controls.SetChildIndex(this.InspWorker, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtInspWorker, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblInspWorker, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 90);
            this.gbxBody.Size = new System.Drawing.Size(1136, 735);
            this.gbxBody.TabIndex = 1;
            // 
            // ultraLabel4
            // 
            appearance14.TextHAlignAsString = "Center";
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance14;
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ultraLabel4.Location = new System.Drawing.Point(779, 19);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(13, 18);
            this.ultraLabel4.TabIndex = 7;
            this.ultraLabel4.Text = "~";
            // 
            // CboStartDate_H
            // 
            appearance15.FontData.Name = "맑은 고딕";
            appearance15.FontData.SizeInPoints = 9F;
            this.CboStartDate_H.Appearance = appearance15;
            this.CboStartDate_H.AutoSize = false;
            this.CboStartDate_H.DateButtons.Add(dateButton1);
            this.CboStartDate_H.Location = new System.Drawing.Point(653, 14);
            this.CboStartDate_H.Name = "CboStartDate_H";
            this.CboStartDate_H.NonAutoSizeHeight = 26;
            this.CboStartDate_H.Size = new System.Drawing.Size(120, 26);
            this.CboStartDate_H.TabIndex = 1;
            // 
            // cboEndDate_H
            // 
            appearance9.FontData.Name = "맑은 고딕";
            appearance9.FontData.SizeInPoints = 9F;
            this.cboEndDate_H.Appearance = appearance9;
            this.cboEndDate_H.AutoSize = false;
            this.cboEndDate_H.DateButtons.Add(dateButton2);
            this.cboEndDate_H.Location = new System.Drawing.Point(798, 15);
            this.cboEndDate_H.Name = "cboEndDate_H";
            this.cboEndDate_H.NonAutoSizeHeight = 26;
            this.cboEndDate_H.Size = new System.Drawing.Size(120, 26);
            this.cboEndDate_H.TabIndex = 2;
            // 
            // lblDate
            // 
            appearance4.FontData.Name = "맑은 고딕";
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance4;
            this.lblDate.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblDate.DbField = null;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(558, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDate.Size = new System.Drawing.Size(90, 25);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "점검일";
            // 
            // txtMoldCode
            // 
            this.txtMoldCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMoldCode.Location = new System.Drawing.Point(146, 51);
            this.txtMoldCode.Name = "txtMoldCode";
            this.txtMoldCode.Size = new System.Drawing.Size(124, 25);
            this.txtMoldCode.TabIndex = 3;
            // 
            // txtMoldName
            // 
            this.txtMoldName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtMoldName.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMoldName.Location = new System.Drawing.Point(270, 51);
            this.txtMoldName.MaxLength = 30;
            this.txtMoldName.Name = "txtMoldName";
            this.txtMoldName.Size = new System.Drawing.Size(199, 25);
            this.txtMoldName.TabIndex = 4;
            // 
            // lblItemCode
            // 
            appearance1.FontData.Name = "맑은 고딕";
            appearance1.FontData.SizeInPoints = 9F;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblItemCode.Appearance = appearance1;
            this.lblItemCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblItemCode.DbField = null;
            this.lblItemCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemCode.Location = new System.Drawing.Point(51, 51);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemCode.Size = new System.Drawing.Size(90, 25);
            this.lblItemCode.TabIndex = 2;
            this.lblItemCode.Text = "금형";
            // 
            // lblPlantCode
            // 
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance5;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(51, 15);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(90, 25);
            this.lblPlantCode.TabIndex = 0;
            this.lblPlantCode.Text = "사업장";
            // 
            // lblInspWorker
            // 
            appearance2.FontData.Name = "맑은 고딕";
            appearance2.FontData.SizeInPoints = 9F;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblInspWorker.Appearance = appearance2;
            this.lblInspWorker.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblInspWorker.DbField = null;
            this.lblInspWorker.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInspWorker.Location = new System.Drawing.Point(558, 51);
            this.lblInspWorker.Name = "lblInspWorker";
            this.lblInspWorker.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblInspWorker.Size = new System.Drawing.Size(90, 25);
            this.lblInspWorker.TabIndex = 9;
            this.lblInspWorker.Text = "점검자";
            // 
            // txtInspWorker
            // 
            this.txtInspWorker.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtInspWorker.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtInspWorker.Location = new System.Drawing.Point(772, 51);
            this.txtInspWorker.MaxLength = 30;
            this.txtInspWorker.Name = "txtInspWorker";
            this.txtInspWorker.Size = new System.Drawing.Size(199, 25);
            this.txtInspWorker.TabIndex = 6;
            // 
            // InspWorker
            // 
            this.InspWorker.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.InspWorker.Location = new System.Drawing.Point(653, 51);
            this.InspWorker.Name = "InspWorker";
            this.InspWorker.Size = new System.Drawing.Size(119, 25);
            this.InspWorker.TabIndex = 5;
            // 
            // grid1
            // 
            this.grid1.AutoResizeColumn = true;
            this.grid1.AutoUserColumn = true;
            this.grid1.ContextMenuCopyEnabled = true;
            this.grid1.ContextMenuDeleteEnabled = true;
            this.grid1.ContextMenuExcelEnabled = true;
            this.grid1.ContextMenuInsertEnabled = true;
            this.grid1.ContextMenuPasteEnabled = true;
            this.grid1.DeleteButtonEnable = true;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            appearance18.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance18;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance45.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance45;
            appearance47.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance47;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance46.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance46.BackColor2 = System.Drawing.SystemColors.Control;
            appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance46.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance46;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance52.BackColor = System.Drawing.SystemColors.Window;
            appearance52.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance52;
            appearance48.BackColor = System.Drawing.SystemColors.Highlight;
            appearance48.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance48;
            this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
            this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance55.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance55;
            appearance51.BorderColor = System.Drawing.Color.Silver;
            appearance51.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance51;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance49.BackColor = System.Drawing.SystemColors.Control;
            appearance49.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance49.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance49.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance49;
            appearance50.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance50;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance53.BackColor = System.Drawing.SystemColors.Window;
            appearance53.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance53;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance54.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance54;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1124, 723);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 14);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(124, 26);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // MD1130
            // 
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Name = "MD1130";
            this.Load += new System.EventHandler(this.MD1130_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CboStartDate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboStartDate_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboEndDate_H;
        private Control.SLabel lblDate;
        private System.Windows.Forms.TextBox txtMoldCode;
        private System.Windows.Forms.TextBox txtMoldName;
        private Control.SLabel lblItemCode;
        private Control.SLabel lblPlantCode;
        private Control.SLabel lblInspWorker;
        private System.Windows.Forms.TextBox txtInspWorker;
        private System.Windows.Forms.TextBox InspWorker;
        private Control.Grid grid1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
    }
}

namespace WIZ.MD
{
    partial class MD1110
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
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.lblUseFlag = new WIZ.Control.SLabel();
            this.txtMoldCode = new System.Windows.Forms.TextBox();
            this.txtMoldName = new System.Windows.Forms.TextBox();
            this.lblItemCode = new WIZ.Control.SLabel();
            this.InspWorker = new System.Windows.Forms.TextBox();
            this.txtInspWorker = new System.Windows.Forms.TextBox();
            this.lblInspWorker = new WIZ.Control.SLabel();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.cboEndDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.CboStartDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartDate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboEndDate_H);
            this.gbxHeader.Controls.Add(this.CboStartDate_H);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.ultraLabel4);
            this.gbxHeader.Controls.Add(this.InspWorker);
            this.gbxHeader.Controls.Add(this.txtInspWorker);
            this.gbxHeader.Controls.Add(this.lblInspWorker);
            this.gbxHeader.Controls.Add(this.txtMoldCode);
            this.gbxHeader.Controls.Add(this.txtMoldName);
            this.gbxHeader.Controls.Add(this.lblItemCode);
            this.gbxHeader.Controls.Add(this.lblUseFlag);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 90);
            this.gbxHeader.TabIndex = 0;
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblUseFlag, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtMoldName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtMoldCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblInspWorker, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtInspWorker, 0);
            this.gbxHeader.Controls.SetChildIndex(this.InspWorker, 0);
            this.gbxHeader.Controls.SetChildIndex(this.ultraLabel4, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboStartDate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboEndDate_H, 0);
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
            // 
            // lblPlantCode
            // 
            appearance85.TextHAlignAsString = "Right";
            appearance85.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance85;
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
            // lblUseFlag
            // 
            appearance63.FontData.Name = "맑은 고딕";
            appearance63.TextHAlignAsString = "Right";
            appearance63.TextVAlignAsString = "Middle";
            this.lblUseFlag.Appearance = appearance63;
            this.lblUseFlag.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblUseFlag.DbField = null;
            this.lblUseFlag.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUseFlag.Location = new System.Drawing.Point(610, 15);
            this.lblUseFlag.Name = "lblUseFlag";
            this.lblUseFlag.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblUseFlag.Size = new System.Drawing.Size(90, 25);
            this.lblUseFlag.TabIndex = 5;
            this.lblUseFlag.Text = "점검일";
            // 
            // txtMoldCode
            // 
            this.txtMoldCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMoldCode.Location = new System.Drawing.Point(146, 51);
            this.txtMoldCode.Name = "txtMoldCode";
            this.txtMoldCode.Size = new System.Drawing.Size(119, 25);
            this.txtMoldCode.TabIndex = 3;
            // 
            // txtMoldName
            // 
            this.txtMoldName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtMoldName.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMoldName.Location = new System.Drawing.Point(265, 51);
            this.txtMoldName.MaxLength = 30;
            this.txtMoldName.Name = "txtMoldName";
            this.txtMoldName.Size = new System.Drawing.Size(199, 25);
            this.txtMoldName.TabIndex = 4;
            // 
            // lblItemCode
            // 
            appearance4.FontData.Name = "맑은 고딕";
            appearance4.FontData.SizeInPoints = 9F;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.lblItemCode.Appearance = appearance4;
            this.lblItemCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblItemCode.DbField = null;
            this.lblItemCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblItemCode.Location = new System.Drawing.Point(51, 51);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemCode.Size = new System.Drawing.Size(90, 25);
            this.lblItemCode.TabIndex = 2;
            this.lblItemCode.Text = "금형";
            // 
            // InspWorker
            // 
            this.InspWorker.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.InspWorker.Location = new System.Drawing.Point(705, 51);
            this.InspWorker.Name = "InspWorker";
            this.InspWorker.Size = new System.Drawing.Size(119, 25);
            this.InspWorker.TabIndex = 5;
            // 
            // txtInspWorker
            // 
            this.txtInspWorker.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtInspWorker.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtInspWorker.Location = new System.Drawing.Point(824, 51);
            this.txtInspWorker.MaxLength = 30;
            this.txtInspWorker.Name = "txtInspWorker";
            this.txtInspWorker.Size = new System.Drawing.Size(199, 25);
            this.txtInspWorker.TabIndex = 6;
            // 
            // lblInspWorker
            // 
            appearance44.FontData.Name = "맑은 고딕";
            appearance44.FontData.SizeInPoints = 9F;
            appearance44.TextHAlignAsString = "Right";
            appearance44.TextVAlignAsString = "Middle";
            this.lblInspWorker.Appearance = appearance44;
            this.lblInspWorker.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblInspWorker.DbField = null;
            this.lblInspWorker.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblInspWorker.Location = new System.Drawing.Point(610, 51);
            this.lblInspWorker.Name = "lblInspWorker";
            this.lblInspWorker.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblInspWorker.Size = new System.Drawing.Size(90, 25);
            this.lblInspWorker.TabIndex = 8;
            this.lblInspWorker.Text = "점검자";
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
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance1;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance10;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance6;
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
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance13;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance9;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance7.BackColor = System.Drawing.SystemColors.Control;
            appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance7.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance7;
            appearance8.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance8;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance11;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
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
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraLabel4
            // 
            appearance14.TextHAlignAsString = "Center";
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance14;
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ultraLabel4.Location = new System.Drawing.Point(831, 18);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(13, 18);
            this.ultraLabel4.TabIndex = 409;
            this.ultraLabel4.Text = "~";
            // 
            // cboEndDate_H
            // 
            this.cboEndDate_H.DateButtons.Add(dateButton1);
            this.cboEndDate_H.Location = new System.Drawing.Point(848, 14);
            this.cboEndDate_H.Name = "cboEndDate_H";
            this.cboEndDate_H.NonAutoSizeHeight = 26;
            this.cboEndDate_H.Size = new System.Drawing.Size(121, 26);
            this.cboEndDate_H.TabIndex = 2;
            // 
            // CboStartDate_H
            // 
            this.CboStartDate_H.DateButtons.Add(dateButton2);
            this.CboStartDate_H.Location = new System.Drawing.Point(705, 14);
            this.CboStartDate_H.Name = "CboStartDate_H";
            this.CboStartDate_H.NonAutoSizeHeight = 26;
            this.CboStartDate_H.Size = new System.Drawing.Size(122, 26);
            this.CboStartDate_H.TabIndex = 1;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 14);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(124, 26);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // MD1110
            // 
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Name = "MD1110";
            this.Text = "금형점검이력";
            this.Load += new System.EventHandler(this.MD1110_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartDate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.SLabel lblPlantCode;
        private Control.SLabel lblUseFlag;
        private System.Windows.Forms.TextBox InspWorker;
        private System.Windows.Forms.TextBox txtInspWorker;
        private Control.SLabel lblInspWorker;
        private System.Windows.Forms.TextBox txtMoldCode;
        private System.Windows.Forms.TextBox txtMoldName;
        private Control.SLabel lblItemCode;
        private Control.Grid grid1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboEndDate_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboStartDate_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
    }
}

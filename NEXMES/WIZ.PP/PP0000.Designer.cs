namespace WIZ.PP
{
    partial class PP0000
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton3 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.dtpEDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lbl = new WIZ.Control.SLabel();
            this.dtpSDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblDate = new WIZ.Control.SLabel();
            this.cboOrderType_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblOrderType = new WIZ.Control.SLabel();
            this.txtItemName_H = new WIZ.Control.STextBox(this.components);
            this.txtItemCode_H = new WIZ.Control.SBtnTextEditor();
            this.lblItemCode = new WIZ.Control.SLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEDate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSDate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOrderType_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboOrderType_H);
            this.gbxHeader.Controls.Add(this.lblOrderType);
            this.gbxHeader.Controls.Add(this.txtItemName_H);
            this.gbxHeader.Controls.Add(this.txtItemCode_H);
            this.gbxHeader.Controls.Add(this.lblItemCode);
            this.gbxHeader.Controls.Add(this.dtpEDate_H);
            this.gbxHeader.Controls.Add(this.lbl);
            this.gbxHeader.Controls.Add(this.dtpSDate_H);
            this.gbxHeader.Controls.Add(this.lblDate);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Size = new System.Drawing.Size(1263, 90);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.dtpSDate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl, 0);
            this.gbxHeader.Controls.SetChildIndex(this.dtpEDate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemName_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblOrderType, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboOrderType_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.gbxBody.Location = new System.Drawing.Point(0, 90);
            this.gbxBody.Size = new System.Drawing.Size(1263, 507);
            // 
            // lblPlantCode
            // 
            appearance6.FontData.BoldAsString = "False";
            appearance6.FontData.Name = "맑은 고딕";
            appearance6.FontData.SizeInPoints = 9F;
            appearance6.FontData.UnderlineAsString = "False";
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Right";
            appearance6.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance6;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(50, 15);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(90, 25);
            this.lblPlantCode.TabIndex = 194;
            this.lblPlantCode.Text = "사업장";
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
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance7;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance8.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance8;
            appearance10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance10;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance9.BackColor2 = System.Drawing.SystemColors.Control;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance9;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance19;
            appearance11.BackColor = System.Drawing.SystemColors.Highlight;
            appearance11.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance11;
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
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance18;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance20;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance21.BackColor = System.Drawing.SystemColors.Control;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance21;
            appearance22.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.grid1.DisplayLayout.Override.MinRowHeight = 30;
            appearance16.BackColor = System.Drawing.SystemColors.Window;
            appearance16.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance16;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance17.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance17;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1251, 495);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "작업장";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(142, 14);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(145, 27);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // dtpEDate_H
            // 
            this.dtpEDate_H.DateButtons.Add(dateButton1);
            this.dtpEDate_H.DateButtons.Add(dateButton2);
            this.dtpEDate_H.Location = new System.Drawing.Point(1021, 14);
            this.dtpEDate_H.Name = "dtpEDate_H";
            this.dtpEDate_H.NonAutoSizeHeight = 26;
            this.dtpEDate_H.Size = new System.Drawing.Size(145, 26);
            this.dtpEDate_H.TabIndex = 663;
            this.dtpEDate_H.Value = new System.DateTime(2017, 1, 10, 0, 0, 0, 0);
            // 
            // lbl
            // 
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Center";
            appearance5.TextVAlignAsString = "Middle";
            this.lbl.Appearance = appearance5;
            this.lbl.DbField = null;
            this.lbl.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl.Location = new System.Drawing.Point(1001, 14);
            this.lbl.Name = "lbl";
            this.lbl.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl.Size = new System.Drawing.Size(20, 26);
            this.lbl.TabIndex = 664;
            this.lbl.Text = "~";
            // 
            // dtpSDate_H
            // 
            this.dtpSDate_H.DateButtons.Add(dateButton3);
            this.dtpSDate_H.Location = new System.Drawing.Point(856, 14);
            this.dtpSDate_H.Name = "dtpSDate_H";
            this.dtpSDate_H.NonAutoSizeHeight = 26;
            this.dtpSDate_H.Size = new System.Drawing.Size(145, 26);
            this.dtpSDate_H.TabIndex = 661;
            this.dtpSDate_H.Value = new System.DateTime(2017, 1, 10, 0, 0, 0, 0);
            // 
            // lblDate
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance2;
            this.lblDate.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblDate.DbField = null;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblDate.Location = new System.Drawing.Point(764, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDate.Size = new System.Drawing.Size(90, 25);
            this.lblDate.TabIndex = 662;
            this.lblDate.Text = "작업지시 일자";
            // 
            // cboOrderType_H
            // 
            this.cboOrderType_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboOrderType_H.Location = new System.Drawing.Point(856, 49);
            this.cboOrderType_H.Name = "cboOrderType_H";
            this.cboOrderType_H.Size = new System.Drawing.Size(145, 27);
            this.cboOrderType_H.TabIndex = 670;
            // 
            // lblOrderType
            // 
            appearance58.FontData.BoldAsString = "False";
            appearance58.FontData.UnderlineAsString = "False";
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextHAlignAsString = "Right";
            appearance58.TextVAlignAsString = "Middle";
            this.lblOrderType.Appearance = appearance58;
            this.lblOrderType.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblOrderType.DbField = "cboUseFlag";
            this.lblOrderType.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderType.Location = new System.Drawing.Point(764, 50);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblOrderType.Size = new System.Drawing.Size(90, 25);
            this.lblOrderType.TabIndex = 671;
            this.lblOrderType.Text = "작지구분";
            // 
            // txtItemName_H
            // 
            appearance59.FontData.BoldAsString = "False";
            appearance59.FontData.UnderlineAsString = "False";
            appearance59.ForeColor = System.Drawing.Color.Black;
            this.txtItemName_H.Appearance = appearance59;
            this.txtItemName_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemName_H.Location = new System.Drawing.Point(287, 49);
            this.txtItemName_H.Name = "txtItemName_H";
            this.txtItemName_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtItemName_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtItemName_H.Size = new System.Drawing.Size(300, 27);
            this.txtItemName_H.TabIndex = 669;
            // 
            // txtItemCode_H
            // 
            appearance24.FontData.BoldAsString = "False";
            appearance24.FontData.Name = "맑은 고딕";
            appearance24.FontData.SizeInPoints = 10F;
            appearance24.FontData.UnderlineAsString = "False";
            appearance24.ForeColor = System.Drawing.Color.Black;
            this.txtItemCode_H.Appearance = appearance24;
            this.txtItemCode_H.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txtItemCode_H.btnWidth = 26;
            this.txtItemCode_H.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItemCode_H.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtItemCode_H.Location = new System.Drawing.Point(142, 49);
            this.txtItemCode_H.Name = "txtItemCode_H";
            this.txtItemCode_H.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtItemCode_H.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtItemCode_H.Size = new System.Drawing.Size(145, 27);
            this.txtItemCode_H.TabIndex = 668;
            // 
            // lblItemCode
            // 
            appearance60.FontData.BoldAsString = "False";
            appearance60.FontData.UnderlineAsString = "False";
            appearance60.ForeColor = System.Drawing.Color.Black;
            appearance60.TextHAlignAsString = "Right";
            appearance60.TextVAlignAsString = "Middle";
            this.lblItemCode.Appearance = appearance60;
            this.lblItemCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblItemCode.DbField = null;
            this.lblItemCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemCode.Location = new System.Drawing.Point(50, 50);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemCode.Size = new System.Drawing.Size(90, 25);
            this.lblItemCode.TabIndex = 667;
            this.lblItemCode.Text = "품목";
            // 
            // PP0000
            // 
            this.ClientSize = new System.Drawing.Size(1263, 597);
            this.Name = "PP0000";
            this.Text = "작업지시별 진척현황";
            this.Load += new System.EventHandler(this.PP0000_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEDate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSDate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOrderType_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.Grid grid1;
        private Control.SLabel lblPlantCode;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo dtpEDate_H;
        private Control.SLabel lbl;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo dtpSDate_H;
        private Control.SLabel lblDate;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboOrderType_H;
        private Control.SLabel lblOrderType;
        private Control.STextBox txtItemName_H;
        private Control.SBtnTextEditor txtItemCode_H;
        private Control.SLabel lblItemCode;
    }
}

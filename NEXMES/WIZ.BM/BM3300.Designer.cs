namespace WIZ.BM
{
    partial class BM3300
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
            Infragistics.Win.Appearance appearance167 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            this.lblToolCode = new WIZ.Control.SLabel();
            this.lblUseFlag_H = new Infragistics.Win.Misc.UltraLabel();
            this.lblStopCode_H = new Infragistics.Win.Misc.UltraLabel();
            this.lbltxtPlantCodeR = new WIZ.Control.SLabel();
            this.lblWorkCenterCode = new Infragistics.Win.Misc.UltraLabel();
            this.txtWorkCenterCode = new System.Windows.Forms.TextBox();
            this.txtWorkCenterName = new System.Windows.Forms.TextBox();
            this.txtMachCode = new System.Windows.Forms.TextBox();
            this.txtMachName = new System.Windows.Forms.TextBox();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.cboUseFlag_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboStopClass_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseFlag_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStopClass_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboUseFlag_H);
            this.gbxHeader.Controls.Add(this.cboStopClass_H);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.txtMachCode);
            this.gbxHeader.Controls.Add(this.txtMachName);
            this.gbxHeader.Controls.Add(this.txtWorkCenterCode);
            this.gbxHeader.Controls.Add(this.txtWorkCenterName);
            this.gbxHeader.Controls.Add(this.lblWorkCenterCode);
            this.gbxHeader.Controls.Add(this.lbltxtPlantCodeR);
            this.gbxHeader.Controls.Add(this.lblUseFlag_H);
            this.gbxHeader.Controls.Add(this.lblStopCode_H);
            this.gbxHeader.Controls.Add(this.lblToolCode);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 90);
            this.gbxHeader.Controls.SetChildIndex(this.lblToolCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblStopCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblUseFlag_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbltxtPlantCodeR, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblWorkCenterCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkCenterName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkCenterCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtMachName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtMachCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboStopClass_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboUseFlag_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 90);
            this.gbxBody.Size = new System.Drawing.Size(1136, 688);
            // 
            // lblToolCode
            // 
            appearance167.FontData.BoldAsString = "False";
            appearance167.FontData.UnderlineAsString = "False";
            appearance167.ForeColor = System.Drawing.Color.Black;
            appearance167.TextHAlignAsString = "Right";
            appearance167.TextVAlignAsString = "Middle";
            this.lblToolCode.Appearance = appearance167;
            this.lblToolCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblToolCode.DbField = "cboUseFlag";
            this.lblToolCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblToolCode.Location = new System.Drawing.Point(331, 51);
            this.lblToolCode.Name = "lblToolCode";
            this.lblToolCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblToolCode.Size = new System.Drawing.Size(90, 25);
            this.lblToolCode.TabIndex = 71;
            this.lblToolCode.Text = "설비";
            // 
            // lblUseFlag_H
            // 
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.lblUseFlag_H.Appearance = appearance8;
            this.lblUseFlag_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblUseFlag_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUseFlag_H.Location = new System.Drawing.Point(818, 15);
            this.lblUseFlag_H.Name = "lblUseFlag_H";
            this.lblUseFlag_H.Size = new System.Drawing.Size(90, 25);
            this.lblUseFlag_H.TabIndex = 73;
            this.lblUseFlag_H.Text = "사용여부";
            // 
            // lblStopCode_H
            // 
            appearance54.TextHAlignAsString = "Right";
            appearance54.TextVAlignAsString = "Middle";
            this.lblStopCode_H.Appearance = appearance54;
            this.lblStopCode_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblStopCode_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStopCode_H.Location = new System.Drawing.Point(51, 51);
            this.lblStopCode_H.Name = "lblStopCode_H";
            this.lblStopCode_H.Size = new System.Drawing.Size(90, 25);
            this.lblStopCode_H.TabIndex = 74;
            this.lblStopCode_H.Text = "비가동유형";
            // 
            // lbltxtPlantCodeR
            // 
            appearance141.FontData.BoldAsString = "False";
            appearance141.FontData.UnderlineAsString = "False";
            appearance141.ForeColor = System.Drawing.Color.Black;
            appearance141.TextHAlignAsString = "Right";
            appearance141.TextVAlignAsString = "Middle";
            this.lbltxtPlantCodeR.Appearance = appearance141;
            this.lbltxtPlantCodeR.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbltxtPlantCodeR.DbField = "cboUseFlag";
            this.lbltxtPlantCodeR.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbltxtPlantCodeR.Location = new System.Drawing.Point(51, 15);
            this.lbltxtPlantCodeR.Name = "lbltxtPlantCodeR";
            this.lbltxtPlantCodeR.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbltxtPlantCodeR.Size = new System.Drawing.Size(90, 25);
            this.lbltxtPlantCodeR.TabIndex = 204;
            this.lbltxtPlantCodeR.Text = "공장";
            // 
            // lblWorkCenterCode
            // 
            appearance45.TextHAlignAsString = "Right";
            appearance45.TextVAlignAsString = "Middle";
            this.lblWorkCenterCode.Appearance = appearance45;
            this.lblWorkCenterCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkCenterCode.Location = new System.Drawing.Point(331, 15);
            this.lblWorkCenterCode.Name = "lblWorkCenterCode";
            this.lblWorkCenterCode.Size = new System.Drawing.Size(90, 25);
            this.lblWorkCenterCode.TabIndex = 207;
            this.lblWorkCenterCode.Text = "작업장";
            // 
            // txtWorkCenterCode
            // 
            this.txtWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkCenterCode.Location = new System.Drawing.Point(426, 14);
            this.txtWorkCenterCode.Name = "txtWorkCenterCode";
            this.txtWorkCenterCode.Size = new System.Drawing.Size(144, 25);
            this.txtWorkCenterCode.TabIndex = 1;
            // 
            // txtWorkCenterName
            // 
            this.txtWorkCenterName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtWorkCenterName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkCenterName.Location = new System.Drawing.Point(570, 14);
            this.txtWorkCenterName.MaxLength = 30;
            this.txtWorkCenterName.Name = "txtWorkCenterName";
            this.txtWorkCenterName.Size = new System.Drawing.Size(199, 25);
            this.txtWorkCenterName.TabIndex = 2;
            // 
            // txtMachCode
            // 
            this.txtMachCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtMachCode.Location = new System.Drawing.Point(426, 51);
            this.txtMachCode.Name = "txtMachCode";
            this.txtMachCode.Size = new System.Drawing.Size(144, 25);
            this.txtMachCode.TabIndex = 3;
            // 
            // txtMachName
            // 
            this.txtMachName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtMachName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtMachName.Location = new System.Drawing.Point(570, 51);
            this.txtMachName.MaxLength = 30;
            this.txtMachName.Name = "txtMachName";
            this.txtMachName.Size = new System.Drawing.Size(199, 25);
            this.txtMachName.TabIndex = 4;
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
            appearance115.BackColor = System.Drawing.SystemColors.Window;
            appearance115.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance115;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance74.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance74;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance75.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance75.BackColor2 = System.Drawing.SystemColors.Control;
            appearance75.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance75.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance75;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance76.BackColor = System.Drawing.SystemColors.Window;
            appearance76.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance76;
            appearance77.BackColor = System.Drawing.SystemColors.Highlight;
            appearance77.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance77;
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
            appearance78.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance78;
            appearance79.BorderColor = System.Drawing.Color.Silver;
            appearance79.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance79;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance80.BackColor = System.Drawing.SystemColors.Control;
            appearance80.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance80.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance80.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance80.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance80;
            appearance81.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance81;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance82.BackColor = System.Drawing.SystemColors.Window;
            appearance82.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance82;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance83.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance83;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1124, 676);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // cboUseFlag_H
            // 
            this.cboUseFlag_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboUseFlag_H.Location = new System.Drawing.Point(913, 13);
            this.cboUseFlag_H.Name = "cboUseFlag_H";
            this.cboUseFlag_H.Size = new System.Drawing.Size(144, 27);
            this.cboUseFlag_H.TabIndex = 6;
            // 
            // cboStopClass_H
            // 
            this.cboStopClass_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboStopClass_H.Location = new System.Drawing.Point(146, 50);
            this.cboStopClass_H.Name = "cboStopClass_H";
            this.cboStopClass_H.Size = new System.Drawing.Size(144, 27);
            this.cboStopClass_H.TabIndex = 5;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 14);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(144, 27);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // BM3300
            // 
            this.ClientSize = new System.Drawing.Size(1136, 778);
            this.Name = "BM3300";
            this.Text = "설비별 비가동 내역      ";
            this.Load += new System.EventHandler(this.BM3300_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseFlag_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStopClass_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.SLabel lblToolCode;
        private Infragistics.Win.Misc.UltraLabel lblUseFlag_H;
        private Infragistics.Win.Misc.UltraLabel lblStopCode_H;
        private Control.SLabel lbltxtPlantCodeR;
        private Infragistics.Win.Misc.UltraLabel lblWorkCenterCode;
        private System.Windows.Forms.TextBox txtMachCode;
        private System.Windows.Forms.TextBox txtMachName;
        private System.Windows.Forms.TextBox txtWorkCenterCode;
        private System.Windows.Forms.TextBox txtWorkCenterName;
        private Control.Grid grid1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboStopClass_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboUseFlag_H;
    }
}

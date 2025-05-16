namespace WIZ.BM
{
    partial class BM3670
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
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance205 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance206 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance207 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance208 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance209 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance210 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance211 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance212 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance217 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance218 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.txtMachCode = new System.Windows.Forms.TextBox();
            this.txtMachName = new System.Windows.Forms.TextBox();
            this.lblMachCode = new WIZ.Control.SLabel();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtInspCode = new System.Windows.Forms.TextBox();
            this.txtInspCodeNM = new System.Windows.Forms.TextBox();
            this.lblInspCode = new WIZ.Control.SLabel();
            this.cboUseFlag_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblUseFlag = new WIZ.Control.SLabel();
            this.lblPlantCode = new WIZ.Control.SLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseFlag_H)).BeginInit();
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
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.lblUseFlag);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Controls.Add(this.txtInspCode);
            this.gbxHeader.Controls.Add(this.txtInspCodeNM);
            this.gbxHeader.Controls.Add(this.lblInspCode);
            this.gbxHeader.Controls.Add(this.btnCopy);
            this.gbxHeader.Controls.Add(this.txtMachCode);
            this.gbxHeader.Controls.Add(this.txtMachName);
            this.gbxHeader.Controls.Add(this.lblMachCode);
            this.gbxHeader.Size = new System.Drawing.Size(991, 90);
            this.gbxHeader.Controls.SetChildIndex(this.lblMachCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtMachName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtMachCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.btnCopy, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblInspCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtInspCodeNM, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtInspCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblUseFlag, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
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
            this.gbxBody.Size = new System.Drawing.Size(991, 656);
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
            appearance205.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance205;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance206.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance206.BackColor2 = System.Drawing.SystemColors.Control;
            appearance206.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance206.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance206;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance207.BackColor = System.Drawing.SystemColors.Window;
            appearance207.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance207;
            appearance208.BackColor = System.Drawing.SystemColors.Highlight;
            appearance208.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance208;
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
            appearance209.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance209;
            appearance210.BorderColor = System.Drawing.Color.Silver;
            appearance210.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance210;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance211.BackColor = System.Drawing.SystemColors.Control;
            appearance211.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance211.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance211.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance211.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance211;
            appearance212.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance212;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance217.BackColor = System.Drawing.SystemColors.Window;
            appearance217.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance217;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance218.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance218;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(979, 644);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtMachCode
            // 
            this.txtMachCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMachCode.Location = new System.Drawing.Point(146, 51);
            this.txtMachCode.Name = "txtMachCode";
            this.txtMachCode.Size = new System.Drawing.Size(144, 25);
            this.txtMachCode.TabIndex = 2;
            this.txtMachCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMachCode_KeyDown);
            this.txtMachCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMachCode_KeyPress);
            this.txtMachCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtMachCode_MouseDoubleClick);
            // 
            // txtMachName
            // 
            this.txtMachName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtMachName.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMachName.Location = new System.Drawing.Point(290, 51);
            this.txtMachName.Name = "txtMachName";
            this.txtMachName.Size = new System.Drawing.Size(168, 25);
            this.txtMachName.TabIndex = 3;
            this.txtMachName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMachName_KeyDown);
            this.txtMachName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMachName_KeyPress);
            this.txtMachName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtMachName_MouseDoubleClick);
            // 
            // lblMachCode
            // 
            appearance13.TextHAlignAsString = "Right";
            appearance13.TextVAlignAsString = "Middle";
            this.lblMachCode.Appearance = appearance13;
            this.lblMachCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblMachCode.DbField = null;
            this.lblMachCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMachCode.Location = new System.Drawing.Point(51, 51);
            this.lblMachCode.Name = "lblMachCode";
            this.lblMachCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblMachCode.Size = new System.Drawing.Size(90, 25);
            this.lblMachCode.TabIndex = 77;
            this.lblMachCode.Text = "설비";
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCopy.Location = new System.Drawing.Point(756, 11);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(145, 27);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "복 사";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btn3671_Click);
            // 
            // txtInspCode
            // 
            this.txtInspCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtInspCode.Location = new System.Drawing.Point(579, 50);
            this.txtInspCode.Name = "txtInspCode";
            this.txtInspCode.Size = new System.Drawing.Size(144, 25);
            this.txtInspCode.TabIndex = 4;
            this.txtInspCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInspCode_KeyDown);
            this.txtInspCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInspCode_KeyPress);
            this.txtInspCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtInspCode_MouseDoubleClick);
            // 
            // txtInspCodeNM
            // 
            this.txtInspCodeNM.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtInspCodeNM.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtInspCodeNM.Location = new System.Drawing.Point(723, 50);
            this.txtInspCodeNM.Name = "txtInspCodeNM";
            this.txtInspCodeNM.Size = new System.Drawing.Size(178, 25);
            this.txtInspCodeNM.TabIndex = 5;
            this.txtInspCodeNM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInspCodeNM_KeyDown);
            this.txtInspCodeNM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInspCodeNM_KeyPress);
            this.txtInspCodeNM.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtInspCodeNM_MouseDoubleClick);
            // 
            // lblInspCode
            // 
            appearance86.TextHAlignAsString = "Right";
            appearance86.TextVAlignAsString = "Middle";
            this.lblInspCode.Appearance = appearance86;
            this.lblInspCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblInspCode.DbField = null;
            this.lblInspCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInspCode.Location = new System.Drawing.Point(484, 51);
            this.lblInspCode.Name = "lblInspCode";
            this.lblInspCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblInspCode.Size = new System.Drawing.Size(90, 25);
            this.lblInspCode.TabIndex = 204;
            this.lblInspCode.Text = "검사항목";
            // 
            // cboUseFlag_H
            // 
            this.cboUseFlag_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboUseFlag_H.Location = new System.Drawing.Point(579, 13);
            this.cboUseFlag_H.Name = "cboUseFlag_H";
            this.cboUseFlag_H.Size = new System.Drawing.Size(144, 26);
            this.cboUseFlag_H.TabIndex = 1;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 14);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(144, 26);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // lblUseFlag
            // 
            appearance27.TextHAlignAsString = "Right";
            appearance27.TextVAlignAsString = "Middle";
            this.lblUseFlag.Appearance = appearance27;
            this.lblUseFlag.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblUseFlag.DbField = null;
            this.lblUseFlag.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUseFlag.Location = new System.Drawing.Point(484, 15);
            this.lblUseFlag.Name = "lblUseFlag";
            this.lblUseFlag.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblUseFlag.Size = new System.Drawing.Size(90, 25);
            this.lblUseFlag.TabIndex = 313;
            this.lblUseFlag.Text = "사용여부";
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
            this.lblPlantCode.TabIndex = 312;
            this.lblPlantCode.Text = "공장";
            // 
            // BM3670
            // 
            this.ClientSize = new System.Drawing.Size(991, 746);
            this.Name = "BM3670";
            this.Text = "설비정검항목 작업장별 스펙 관리";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.BM3670_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseFlag_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.Grid grid1;
        private System.Windows.Forms.TextBox txtMachCode;
        private System.Windows.Forms.TextBox txtMachName;
        private Control.SLabel lblMachCode;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtInspCode;
        private System.Windows.Forms.TextBox txtInspCodeNM;
        private Control.SLabel lblInspCode;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboUseFlag_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Control.SLabel lblUseFlag;
        private Control.SLabel lblPlantCode;

    }
}

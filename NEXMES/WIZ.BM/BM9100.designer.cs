namespace WIZ.BM
{
    partial class BM9100
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.lblITtype = new WIZ.Control.SLabel();
            this.lbltxtPlantCodeR = new WIZ.Control.SLabel();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.lblUseFlag = new WIZ.Control.SLabel();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboUseFlag_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboITType_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblTerminalID = new WIZ.Control.SLabel();
            this.txtTerminalID = new WIZ.Control.STextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseFlag_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboITType_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerminalID)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.txtTerminalID);
            this.gbxHeader.Controls.Add(this.lblTerminalID);
            this.gbxHeader.Controls.Add(this.cboITType_H);
            this.gbxHeader.Controls.Add(this.cboUseFlag_H);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.lblUseFlag);
            this.gbxHeader.Controls.Add(this.lbltxtPlantCodeR);
            this.gbxHeader.Controls.Add(this.lblITtype);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 73);
            this.gbxHeader.Controls.SetChildIndex(this.lblITtype, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbltxtPlantCodeR, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblUseFlag, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboUseFlag_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboITType_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblTerminalID, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtTerminalID, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 73);
            this.gbxBody.Size = new System.Drawing.Size(1136, 705);
            // 
            // lblITtype
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.lblITtype.Appearance = appearance4;
            this.lblITtype.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblITtype.DbField = "cboUseFlag";
            this.lblITtype.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblITtype.Location = new System.Drawing.Point(340, 9);
            this.lblITtype.Name = "lblITtype";
            this.lblITtype.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblITtype.Size = new System.Drawing.Size(145, 23);
            this.lblITtype.TabIndex = 42;
            this.lblITtype.Text = "장비유형";
            // 
            // lbltxtPlantCodeR
            // 
            appearance7.FontData.BoldAsString = "False";
            appearance7.FontData.UnderlineAsString = "False";
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.lbltxtPlantCodeR.Appearance = appearance7;
            this.lbltxtPlantCodeR.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbltxtPlantCodeR.DbField = "cboUseFlag";
            this.lbltxtPlantCodeR.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbltxtPlantCodeR.Location = new System.Drawing.Point(112, 9);
            this.lbltxtPlantCodeR.Name = "lbltxtPlantCodeR";
            this.lbltxtPlantCodeR.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbltxtPlantCodeR.Size = new System.Drawing.Size(145, 25);
            this.lbltxtPlantCodeR.TabIndex = 189;
            this.lbltxtPlantCodeR.Text = "사업장";
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
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance2;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance14;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance16;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance15.BackColor2 = System.Drawing.SystemColors.Control;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance15;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            appearance21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance21;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance8;
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
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance20;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance19.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance19;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance22;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance23;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1124, 693);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.AfterCellListCloseUp += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grid1_AfterCellListCloseUp);
            // 
            // lblUseFlag
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.lblUseFlag.Appearance = appearance3;
            this.lblUseFlag.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblUseFlag.DbField = "cboUseFlag";
            this.lblUseFlag.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.lblUseFlag.Location = new System.Drawing.Point(766, 9);
            this.lblUseFlag.Name = "lblUseFlag";
            this.lblUseFlag.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblUseFlag.Size = new System.Drawing.Size(145, 25);
            this.lblUseFlag.TabIndex = 276;
            this.lblUseFlag.Text = "사용여부";
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.AutoSize = false;
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(112, 31);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(160, 27);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // cboUseFlag_H
            // 
            this.cboUseFlag_H.AutoSize = false;
            this.cboUseFlag_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboUseFlag_H.Location = new System.Drawing.Point(766, 31);
            this.cboUseFlag_H.Name = "cboUseFlag_H";
            this.cboUseFlag_H.Size = new System.Drawing.Size(145, 27);
            this.cboUseFlag_H.TabIndex = 3;
            // 
            // cboITType_H
            // 
            this.cboITType_H.AutoSize = false;
            this.cboITType_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboITType_H.Location = new System.Drawing.Point(340, 31);
            this.cboITType_H.Name = "cboITType_H";
            this.cboITType_H.Size = new System.Drawing.Size(145, 27);
            this.cboITType_H.TabIndex = 1;
            // 
            // lblTerminalID
            // 
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.lblTerminalID.Appearance = appearance5;
            this.lblTerminalID.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblTerminalID.DbField = null;
            this.lblTerminalID.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTerminalID.Location = new System.Drawing.Point(553, 9);
            this.lblTerminalID.Name = "lblTerminalID";
            this.lblTerminalID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblTerminalID.Size = new System.Drawing.Size(145, 25);
            this.lblTerminalID.TabIndex = 278;
            this.lblTerminalID.Text = "장비ID";
            // 
            // txtTerminalID
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.txtTerminalID.Appearance = appearance1;
            this.txtTerminalID.AutoSize = false;
            this.txtTerminalID.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTerminalID.Location = new System.Drawing.Point(553, 31);
            this.txtTerminalID.Name = "txtTerminalID";
            this.txtTerminalID.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtTerminalID.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtTerminalID.Size = new System.Drawing.Size(145, 27);
            this.txtTerminalID.TabIndex = 279;
            // 
            // BM9100
            // 
            this.ClientSize = new System.Drawing.Size(1136, 778);
            this.Name = "BM9100";
            this.Text = "현장장비관리";
            this.Load += new System.EventHandler(this.BM9100_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseFlag_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboITType_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerminalID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.SLabel lblITtype;
        private Control.SLabel lbltxtPlantCodeR;
        private Control.Grid grid1;
        private Control.SLabel lblUseFlag;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboITType_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboUseFlag_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Control.SLabel lblTerminalID;
        private Control.STextBox txtTerminalID;
    }
}

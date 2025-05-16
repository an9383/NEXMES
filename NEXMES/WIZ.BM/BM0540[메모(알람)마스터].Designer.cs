namespace WIZ.BM
{
    partial class BM0540
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
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.txt_WORKCENTERNAME_H = new WIZ.Control.STextBox(this.components);
            this.txt_WORKCENTERCODE_H = new WIZ.Control.SBtnTextEditor();
            this.lbl_WORKCENTERCODE_H = new WIZ.Control.SLabel();
            this.txt_MEMOID_H = new WIZ.Control.STextBox(this.components);
            this.lbl_MEMOID_H = new WIZ.Control.SLabel();
            this.cbo_USEFLAG_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbl_USEFLAG_H = new WIZ.Control.SLabel();
            this.cbo_PLANTCODE_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbl_PLANTCODE_H = new WIZ.Control.SLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WORKCENTERNAME_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WORKCENTERCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MEMOID_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_USEFLAG_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.txt_WORKCENTERNAME_H);
            this.gbxHeader.Controls.Add(this.txt_WORKCENTERCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_WORKCENTERCODE_H);
            this.gbxHeader.Controls.Add(this.cbo_USEFLAG_H);
            this.gbxHeader.Controls.Add(this.lbl_USEFLAG_H);
            this.gbxHeader.Controls.Add(this.cbo_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.txt_MEMOID_H);
            this.gbxHeader.Controls.Add(this.lbl_MEMOID_H);
            this.gbxHeader.Margin = new System.Windows.Forms.Padding(0);
            this.gbxHeader.Size = new System.Drawing.Size(1637, 73);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_MEMOID_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_MEMOID_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_USEFLAG_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_USEFLAG_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_WORKCENTERCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_WORKCENTERCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_WORKCENTERNAME_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 2;
            this.gbxBody.ContentPadding.Left = 2;
            this.gbxBody.ContentPadding.Right = 2;
            this.gbxBody.ContentPadding.Top = 4;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 73);
            this.gbxBody.Margin = new System.Windows.Forms.Padding(0);
            this.gbxBody.Size = new System.Drawing.Size(1637, 789);
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
            appearance29.BackColor = System.Drawing.SystemColors.Window;
            appearance29.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance29;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance33.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance33.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance33;
            appearance34.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance34;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance35.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance35.BackColor2 = System.Drawing.SystemColors.Control;
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance35.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance35;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            appearance36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance36;
            appearance43.BackColor = System.Drawing.SystemColors.Highlight;
            appearance43.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance43;
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
            appearance44.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance44;
            appearance57.BorderColor = System.Drawing.Color.Silver;
            appearance57.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance57;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance58.BackColor = System.Drawing.SystemColors.Control;
            appearance58.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance58.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance58.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance58;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance59.BackColor = System.Drawing.SystemColors.Window;
            appearance59.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance59;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance61.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance61;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(4, 4);
            this.grid1.Margin = new System.Windows.Forms.Padding(0);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1629, 781);
            this.grid1.TabIndex = 5;
            this.grid1.TabStop = false;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txt_WORKCENTERNAME_H
            // 
            appearance74.FontData.BoldAsString = "False";
            appearance74.FontData.UnderlineAsString = "False";
            appearance74.ForeColor = System.Drawing.Color.Black;
            this.txt_WORKCENTERNAME_H.Appearance = appearance74;
            this.txt_WORKCENTERNAME_H.AutoSize = false;
            this.txt_WORKCENTERNAME_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_WORKCENTERNAME_H.Location = new System.Drawing.Point(674, 32);
            this.txt_WORKCENTERNAME_H.Name = "txt_WORKCENTERNAME_H";
            this.txt_WORKCENTERNAME_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_WORKCENTERNAME_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_WORKCENTERNAME_H.Size = new System.Drawing.Size(200, 27);
            this.txt_WORKCENTERNAME_H.TabIndex = 270;
            // 
            // txt_WORKCENTERCODE_H
            // 
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.Name = "맑은 고딕";
            appearance17.FontData.SizeInPoints = 10F;
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            this.txt_WORKCENTERCODE_H.Appearance = appearance17;
            this.txt_WORKCENTERCODE_H.AutoSize = false;
            this.txt_WORKCENTERCODE_H.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txt_WORKCENTERCODE_H.btnWidth = 26;
            this.txt_WORKCENTERCODE_H.Location = new System.Drawing.Point(530, 32);
            this.txt_WORKCENTERCODE_H.Name = "txt_WORKCENTERCODE_H";
            this.txt_WORKCENTERCODE_H.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_WORKCENTERCODE_H.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_WORKCENTERCODE_H.Size = new System.Drawing.Size(145, 27);
            this.txt_WORKCENTERCODE_H.TabIndex = 268;
            // 
            // lbl_WORKCENTERCODE_H
            // 
            appearance25.FontData.BoldAsString = "False";
            appearance25.FontData.UnderlineAsString = "False";
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.TextHAlignAsString = "Left";
            appearance25.TextVAlignAsString = "Middle";
            this.lbl_WORKCENTERCODE_H.Appearance = appearance25;
            this.lbl_WORKCENTERCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_WORKCENTERCODE_H.DbField = null;
            this.lbl_WORKCENTERCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_WORKCENTERCODE_H.Location = new System.Drawing.Point(530, 10);
            this.lbl_WORKCENTERCODE_H.Name = "lbl_WORKCENTERCODE_H";
            this.lbl_WORKCENTERCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_WORKCENTERCODE_H.Size = new System.Drawing.Size(345, 25);
            this.lbl_WORKCENTERCODE_H.TabIndex = 272;
            this.lbl_WORKCENTERCODE_H.Text = "작업장";
            // 
            // txt_MEMOID_H
            // 
            appearance51.FontData.BoldAsString = "False";
            appearance51.FontData.UnderlineAsString = "False";
            appearance51.ForeColor = System.Drawing.Color.Black;
            this.txt_MEMOID_H.Appearance = appearance51;
            this.txt_MEMOID_H.AutoSize = false;
            this.txt_MEMOID_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_MEMOID_H.Location = new System.Drawing.Point(320, 32);
            this.txt_MEMOID_H.Name = "txt_MEMOID_H";
            this.txt_MEMOID_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_MEMOID_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_MEMOID_H.Size = new System.Drawing.Size(160, 27);
            this.txt_MEMOID_H.TabIndex = 266;
            // 
            // lbl_MEMOID_H
            // 
            appearance53.FontData.BoldAsString = "False";
            appearance53.FontData.UnderlineAsString = "False";
            appearance53.ForeColor = System.Drawing.Color.Black;
            appearance53.TextHAlignAsString = "Left";
            appearance53.TextVAlignAsString = "Middle";
            this.lbl_MEMOID_H.Appearance = appearance53;
            this.lbl_MEMOID_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_MEMOID_H.DbField = null;
            this.lbl_MEMOID_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_MEMOID_H.Location = new System.Drawing.Point(320, 10);
            this.lbl_MEMOID_H.Name = "lbl_MEMOID_H";
            this.lbl_MEMOID_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_MEMOID_H.Size = new System.Drawing.Size(145, 25);
            this.lbl_MEMOID_H.TabIndex = 267;
            this.lbl_MEMOID_H.Text = "메모 ID";
            // 
            // cbo_USEFLAG_H
            // 
            this.cbo_USEFLAG_H.AutoSize = false;
            this.cbo_USEFLAG_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbo_USEFLAG_H.Location = new System.Drawing.Point(924, 32);
            this.cbo_USEFLAG_H.Name = "cbo_USEFLAG_H";
            this.cbo_USEFLAG_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_USEFLAG_H.TabIndex = 263;
            // 
            // lbl_USEFLAG_H
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.lbl_USEFLAG_H.Appearance = appearance3;
            this.lbl_USEFLAG_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_USEFLAG_H.DbField = null;
            this.lbl_USEFLAG_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lbl_USEFLAG_H.Location = new System.Drawing.Point(924, 10);
            this.lbl_USEFLAG_H.Name = "lbl_USEFLAG_H";
            this.lbl_USEFLAG_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_USEFLAG_H.Size = new System.Drawing.Size(160, 25);
            this.lbl_USEFLAG_H.TabIndex = 264;
            this.lbl_USEFLAG_H.Text = "사용여부";
            // 
            // cbo_PLANTCODE_H
            // 
            this.cbo_PLANTCODE_H.AutoSize = false;
            this.cbo_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbo_PLANTCODE_H.Location = new System.Drawing.Point(110, 32);
            this.cbo_PLANTCODE_H.Name = "cbo_PLANTCODE_H";
            this.cbo_PLANTCODE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_PLANTCODE_H.TabIndex = 261;
            // 
            // lbl_PLANTCODE_H
            // 
            appearance40.FontData.BoldAsString = "False";
            appearance40.FontData.UnderlineAsString = "False";
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextHAlignAsString = "Left";
            appearance40.TextVAlignAsString = "Middle";
            this.lbl_PLANTCODE_H.Appearance = appearance40;
            this.lbl_PLANTCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_PLANTCODE_H.DbField = null;
            this.lbl_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lbl_PLANTCODE_H.Location = new System.Drawing.Point(110, 10);
            this.lbl_PLANTCODE_H.Name = "lbl_PLANTCODE_H";
            this.lbl_PLANTCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_PLANTCODE_H.Size = new System.Drawing.Size(160, 25);
            this.lbl_PLANTCODE_H.TabIndex = 262;
            this.lbl_PLANTCODE_H.Text = "사업장";
            // 
            // BM0540
            // 
            this.ClientSize = new System.Drawing.Size(1637, 862);
            this.Name = "BM0540";
            this.Text = "메모마스터";
            this.Load += new System.EventHandler(this.BM0540_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WORKCENTERNAME_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WORKCENTERCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MEMOID_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_USEFLAG_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Control.Grid grid1;
        private Control.STextBox txt_WORKCENTERNAME_H;
        private Control.SBtnTextEditor txt_WORKCENTERCODE_H;
        private Control.SLabel lbl_WORKCENTERCODE_H;
        private Control.STextBox txt_MEMOID_H;
        private Control.SLabel lbl_MEMOID_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_USEFLAG_H;
        private Control.SLabel lbl_USEFLAG_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_PLANTCODE_H;
        private Control.SLabel lbl_PLANTCODE_H;
    }
}

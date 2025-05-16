namespace WIZ.BM
{
    partial class DG0200
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private new System.ComponentModel.IContainer components = null;

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
        private new void InitializeComponent()
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.Grid1 = new WIZ.Control.Grid(this.components);
            this.lbl_PLANTCODE_H = new WIZ.Control.SLabel();
            this.Cbo_PLANTCODE_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.Cbo_TypeNo_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbl_TypeNo_H = new WIZ.Control.SLabel();
            this.Cbo_DataType_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbl_DataType_H = new WIZ.Control.SLabel();
            this.Cbo_SpecCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbl_SpecCode_H = new WIZ.Control.SLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cbo_PLANTCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cbo_TypeNo_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cbo_DataType_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cbo_SpecCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.Cbo_SpecCode_H);
            this.gbxHeader.Controls.Add(this.lbl_SpecCode_H);
            this.gbxHeader.Controls.Add(this.Cbo_DataType_H);
            this.gbxHeader.Controls.Add(this.lbl_DataType_H);
            this.gbxHeader.Controls.Add(this.Cbo_TypeNo_H);
            this.gbxHeader.Controls.Add(this.lbl_TypeNo_H);
            this.gbxHeader.Controls.Add(this.Cbo_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_PLANTCODE_H);
            this.gbxHeader.Margin = new System.Windows.Forms.Padding(0);
            this.gbxHeader.Size = new System.Drawing.Size(1637, 72);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.Cbo_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_TypeNo_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.Cbo_TypeNo_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_DataType_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.Cbo_DataType_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_SpecCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.Cbo_SpecCode_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 2;
            this.gbxBody.ContentPadding.Left = 2;
            this.gbxBody.ContentPadding.Right = 2;
            this.gbxBody.ContentPadding.Top = 4;
            this.gbxBody.Controls.Add(this.Grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 72);
            this.gbxBody.Margin = new System.Windows.Forms.Padding(0);
            this.gbxBody.Size = new System.Drawing.Size(1637, 790);
            // 
            // Grid1
            // 
            this.Grid1.AutoResizeColumn = true;
            this.Grid1.AutoUserColumn = true;
            this.Grid1.ContextMenuCopyEnabled = true;
            this.Grid1.ContextMenuDeleteEnabled = true;
            this.Grid1.ContextMenuExcelEnabled = true;
            this.Grid1.ContextMenuInsertEnabled = true;
            this.Grid1.ContextMenuPasteEnabled = true;
            this.Grid1.DeleteButtonEnable = true;
            appearance29.BackColor = System.Drawing.SystemColors.Window;
            appearance29.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.Grid1.DisplayLayout.Appearance = appearance29;
            this.Grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.Grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.Grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance33.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance33.BorderColor = System.Drawing.SystemColors.Window;
            this.Grid1.DisplayLayout.GroupByBox.Appearance = appearance33;
            appearance34.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance34;
            this.Grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.Grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance35.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance35.BackColor2 = System.Drawing.SystemColors.Control;
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance35.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance35;
            this.Grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.Grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            appearance36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Grid1.DisplayLayout.Override.ActiveCellAppearance = appearance36;
            appearance43.BackColor = System.Drawing.SystemColors.Highlight;
            appearance43.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Grid1.DisplayLayout.Override.ActiveRowAppearance = appearance43;
            this.Grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.Grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
            this.Grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.Grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance44.BackColor = System.Drawing.SystemColors.Window;
            this.Grid1.DisplayLayout.Override.CardAreaAppearance = appearance44;
            appearance57.BorderColor = System.Drawing.Color.Silver;
            appearance57.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.Grid1.DisplayLayout.Override.CellAppearance = appearance57;
            this.Grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.Grid1.DisplayLayout.Override.CellPadding = 0;
            appearance58.BackColor = System.Drawing.SystemColors.Control;
            appearance58.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance58.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance58.BorderColor = System.Drawing.SystemColors.Window;
            this.Grid1.DisplayLayout.Override.GroupByRowAppearance = appearance58;
            this.Grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.Grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance59.BackColor = System.Drawing.SystemColors.Window;
            appearance59.BorderColor = System.Drawing.Color.Silver;
            this.Grid1.DisplayLayout.Override.RowAppearance = appearance59;
            this.Grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance61.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance61;
            this.Grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.Grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid1.EnterNextRowEnable = true;
            this.Grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Grid1.Location = new System.Drawing.Point(4, 4);
            this.Grid1.Margin = new System.Windows.Forms.Padding(0);
            this.Grid1.Name = "Grid1";
            this.Grid1.Size = new System.Drawing.Size(1629, 782);
            this.Grid1.TabIndex = 5;
            this.Grid1.TabStop = false;
            this.Grid1.Text = "grid1";
            this.Grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.Grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.Grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.Grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Grid1.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Grid1_AfterCellUpdate);
            // 
            // lbl_PLANTCODE_H
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.lbl_PLANTCODE_H.Appearance = appearance1;
            this.lbl_PLANTCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_PLANTCODE_H.DbField = null;
            this.lbl_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lbl_PLANTCODE_H.Location = new System.Drawing.Point(110, 10);
            this.lbl_PLANTCODE_H.Name = "lbl_PLANTCODE_H";
            this.lbl_PLANTCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_PLANTCODE_H.Size = new System.Drawing.Size(160, 25);
            this.lbl_PLANTCODE_H.TabIndex = 230;
            this.lbl_PLANTCODE_H.Text = "사업장";
            // 
            // Cbo_PLANTCODE_H
            // 
            this.Cbo_PLANTCODE_H.AutoSize = false;
            this.Cbo_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Cbo_PLANTCODE_H.Location = new System.Drawing.Point(110, 32);
            this.Cbo_PLANTCODE_H.Name = "Cbo_PLANTCODE_H";
            this.Cbo_PLANTCODE_H.Size = new System.Drawing.Size(160, 27);
            this.Cbo_PLANTCODE_H.TabIndex = 229;
            // 
            // Cbo_TypeNo_H
            // 
            this.Cbo_TypeNo_H.AutoSize = false;
            this.Cbo_TypeNo_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Cbo_TypeNo_H.Location = new System.Drawing.Point(317, 34);
            this.Cbo_TypeNo_H.Name = "Cbo_TypeNo_H";
            this.Cbo_TypeNo_H.Size = new System.Drawing.Size(307, 27);
            this.Cbo_TypeNo_H.TabIndex = 231;
            // 
            // lbl_TypeNo_H
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lbl_TypeNo_H.Appearance = appearance2;
            this.lbl_TypeNo_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_TypeNo_H.DbField = null;
            this.lbl_TypeNo_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lbl_TypeNo_H.Location = new System.Drawing.Point(317, 12);
            this.lbl_TypeNo_H.Name = "lbl_TypeNo_H";
            this.lbl_TypeNo_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_TypeNo_H.Size = new System.Drawing.Size(160, 25);
            this.lbl_TypeNo_H.TabIndex = 232;
            this.lbl_TypeNo_H.Text = "분류 No";
            // 
            // Cbo_DataType_H
            // 
            this.Cbo_DataType_H.AutoSize = false;
            this.Cbo_DataType_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Cbo_DataType_H.Location = new System.Drawing.Point(636, 34);
            this.Cbo_DataType_H.Name = "Cbo_DataType_H";
            this.Cbo_DataType_H.Size = new System.Drawing.Size(265, 27);
            this.Cbo_DataType_H.TabIndex = 233;
            // 
            // lbl_DataType_H
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.lbl_DataType_H.Appearance = appearance3;
            this.lbl_DataType_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_DataType_H.DbField = null;
            this.lbl_DataType_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lbl_DataType_H.Location = new System.Drawing.Point(636, 12);
            this.lbl_DataType_H.Name = "lbl_DataType_H";
            this.lbl_DataType_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_DataType_H.Size = new System.Drawing.Size(160, 25);
            this.lbl_DataType_H.TabIndex = 234;
            this.lbl_DataType_H.Text = "데이터 타입";
            // 
            // Cbo_SpecCode_H
            // 
            this.Cbo_SpecCode_H.AutoSize = false;
            this.Cbo_SpecCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Cbo_SpecCode_H.Location = new System.Drawing.Point(912, 34);
            this.Cbo_SpecCode_H.Name = "Cbo_SpecCode_H";
            this.Cbo_SpecCode_H.Size = new System.Drawing.Size(325, 27);
            this.Cbo_SpecCode_H.TabIndex = 235;
            // 
            // lbl_SpecCode_H
            // 
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.lbl_SpecCode_H.Appearance = appearance5;
            this.lbl_SpecCode_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_SpecCode_H.DbField = null;
            this.lbl_SpecCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lbl_SpecCode_H.Location = new System.Drawing.Point(912, 12);
            this.lbl_SpecCode_H.Name = "lbl_SpecCode_H";
            this.lbl_SpecCode_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_SpecCode_H.Size = new System.Drawing.Size(160, 25);
            this.lbl_SpecCode_H.TabIndex = 236;
            this.lbl_SpecCode_H.Text = "규격코드(컬럼명)";
            // 
            // DG0200
            // 
            this.ClientSize = new System.Drawing.Size(1637, 862);
            this.Name = "DG0200";
            this.Text = "설비 인터페이스 포맷";
            this.Activated += new System.EventHandler(this.DG0200_Activated);
            this.Load += new System.EventHandler(this.DG0200_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cbo_PLANTCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cbo_TypeNo_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cbo_DataType_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cbo_SpecCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Control.Grid Grid1;
        private Control.SLabel lbl_PLANTCODE_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor Cbo_PLANTCODE_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor Cbo_TypeNo_H;
        private Control.SLabel lbl_TypeNo_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor Cbo_DataType_H;
        private Control.SLabel lbl_DataType_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor Cbo_SpecCode_H;
        private Control.SLabel lbl_SpecCode_H;
    }
}

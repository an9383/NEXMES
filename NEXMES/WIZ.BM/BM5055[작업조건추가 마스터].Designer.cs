namespace WIZ.BM
{
    partial class BM5055
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.cbo_PLANTCODE_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbl_PLANTCODE_H = new WIZ.Control.SLabel();
            this.sLabel1 = new WIZ.Control.SLabel();
            this.txt_MethodName_H = new WIZ.Control.STextBox(this.components);
            this.txt_MethodCode_H = new WIZ.Control.SBtnTextEditor();
            this.sLabel2 = new WIZ.Control.SLabel();
            this.cbo_ConditionCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MethodName_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MethodCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ConditionCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cbo_ConditionCode_H);
            this.gbxHeader.Controls.Add(this.sLabel2);
            this.gbxHeader.Controls.Add(this.txt_MethodName_H);
            this.gbxHeader.Controls.Add(this.txt_MethodCode_H);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.cbo_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_PLANTCODE_H);
            this.gbxHeader.Margin = new System.Windows.Forms.Padding(0);
            this.gbxHeader.Size = new System.Drawing.Size(1639, 88);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_MethodCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_MethodName_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel2, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_ConditionCode_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 2;
            this.gbxBody.ContentPadding.Left = 2;
            this.gbxBody.ContentPadding.Right = 2;
            this.gbxBody.ContentPadding.Top = 4;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 88);
            this.gbxBody.Margin = new System.Windows.Forms.Padding(0);
            this.gbxBody.Size = new System.Drawing.Size(1639, 782);
            // 
            // grid1
            // 
            this.grid1.AllowDrop = true;
            this.grid1.AutoResizeColumn = true;
            this.grid1.AutoUserColumn = true;
            this.grid1.ContextMenuCopyEnabled = true;
            this.grid1.ContextMenuDeleteEnabled = true;
            this.grid1.ContextMenuExcelEnabled = true;
            this.grid1.ContextMenuInsertEnabled = true;
            this.grid1.ContextMenuPasteEnabled = true;
            this.grid1.DeleteButtonEnable = true;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance6;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance16.BackColor2 = System.Drawing.SystemColors.Control;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance16;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance28.BackColor = System.Drawing.SystemColors.Window;
            appearance28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance28;
            appearance18.BackColor = System.Drawing.SystemColors.Highlight;
            appearance18.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance18;
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
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance19;
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
            appearance22.TextHAlignAsString = "Center";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance23.BackColor = System.Drawing.SystemColors.Window;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance23;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance24.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance24;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(4, 4);
            this.grid1.Margin = new System.Windows.Forms.Padding(0);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1631, 774);
            this.grid1.TabIndex = 6;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // cbo_PLANTCODE_H
            // 
            this.cbo_PLANTCODE_H.AutoSize = false;
            this.cbo_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbo_PLANTCODE_H.Location = new System.Drawing.Point(94, 41);
            this.cbo_PLANTCODE_H.Name = "cbo_PLANTCODE_H";
            this.cbo_PLANTCODE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_PLANTCODE_H.TabIndex = 655;
            // 
            // lbl_PLANTCODE_H
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.SizeInPoints = 9.75F;
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.lbl_PLANTCODE_H.Appearance = appearance1;
            this.lbl_PLANTCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_PLANTCODE_H.DbField = null;
            this.lbl_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_PLANTCODE_H.Location = new System.Drawing.Point(94, 10);
            this.lbl_PLANTCODE_H.Name = "lbl_PLANTCODE_H";
            this.lbl_PLANTCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_PLANTCODE_H.Size = new System.Drawing.Size(90, 25);
            this.lbl_PLANTCODE_H.TabIndex = 656;
            this.lbl_PLANTCODE_H.Text = "사업장";
            // 
            // sLabel1
            // 
            appearance7.FontData.BoldAsString = "False";
            appearance7.FontData.UnderlineAsString = "False";
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance7;
            this.sLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(260, 12);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(160, 25);
            this.sLabel1.TabIndex = 662;
            this.sLabel1.Text = "작업조건코드";
            // 
            // txt_MethodName_H
            // 
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.txt_MethodName_H.Appearance = appearance5;
            this.txt_MethodName_H.AutoSize = false;
            this.txt_MethodName_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_MethodName_H.Location = new System.Drawing.Point(404, 41);
            this.txt_MethodName_H.Name = "txt_MethodName_H";
            this.txt_MethodName_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_MethodName_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_MethodName_H.Size = new System.Drawing.Size(200, 27);
            this.txt_MethodName_H.TabIndex = 664;
            this.txt_MethodName_H.ValueChanged += new System.EventHandler(this.txt_ITEMNAME_H_ValueChanged);
            // 
            // txt_MethodCode_H
            // 
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.Name = "맑은 고딕";
            appearance17.FontData.SizeInPoints = 10F;
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            this.txt_MethodCode_H.Appearance = appearance17;
            this.txt_MethodCode_H.AutoSize = false;
            this.txt_MethodCode_H.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txt_MethodCode_H.btnWidth = 26;
            this.txt_MethodCode_H.Location = new System.Drawing.Point(260, 41);
            this.txt_MethodCode_H.Name = "txt_MethodCode_H";
            this.txt_MethodCode_H.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_MethodCode_H.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_MethodCode_H.Size = new System.Drawing.Size(145, 27);
            this.txt_MethodCode_H.TabIndex = 663;
            this.txt_MethodCode_H.ValueChanged += new System.EventHandler(this.txt_MethodCode_H_ValueChanged);
            // 
            // sLabel2
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance4;
            this.sLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(631, 12);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(160, 25);
            this.sLabel2.TabIndex = 666;
            this.sLabel2.Text = "선택한 작업조건코드";
            // 
            // cbo_ConditionCode_H
            // 
            this.cbo_ConditionCode_H.AutoSize = false;
            this.cbo_ConditionCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbo_ConditionCode_H.Location = new System.Drawing.Point(631, 41);
            this.cbo_ConditionCode_H.Name = "cbo_ConditionCode_H";
            this.cbo_ConditionCode_H.Size = new System.Drawing.Size(240, 27);
            this.cbo_ConditionCode_H.TabIndex = 667;
            // 
            // BM5055
            // 
            this.ClientSize = new System.Drawing.Size(1639, 870);
            this.Name = "BM5055";
            this.Text = "작업조건추가 마스터";
            this.Load += new System.EventHandler(this.BM5055_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MethodName_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MethodCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ConditionCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Control.Grid grid1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_PLANTCODE_H;
        private Control.SLabel lbl_PLANTCODE_H;
        private Control.SLabel sLabel1;
        private Control.STextBox txt_MethodName_H;
        private Control.SBtnTextEditor txt_MethodCode_H;
        private Control.SLabel sLabel2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_ConditionCode_H;
    }
}

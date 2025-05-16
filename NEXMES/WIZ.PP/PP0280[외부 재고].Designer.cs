namespace WIZ.PP
{
    partial class PP0280
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
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            this.lbl_PLANTCODE_H = new WIZ.Control.SLabel();
            this.lbl_ITEMCODE_H = new WIZ.Control.SLabel();
            this.cbo_PLANTCODE_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbo_ENDDATE_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cbo_STARTDATE_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.sLabel4 = new WIZ.Control.SLabel();
            this.lbl_DATE_H = new WIZ.Control.SLabel();
            this.txt_ITEMNAME_H = new WIZ.Control.STextBox(this.components);
            this.txt_ITEMCODE_H = new WIZ.Control.SBtnTextEditor();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.txt_CUSTCODE_H = new WIZ.Control.SBtnTextEditor();
            this.txt_CUSTNAME_H = new WIZ.Control.STextBox(this.components);
            this.lbl_CUSTCODE_H = new WIZ.Control.SLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ENDDATE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STARTDATE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMNAME_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CUSTCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CUSTNAME_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.txt_CUSTCODE_H);
            this.gbxHeader.Controls.Add(this.txt_CUSTNAME_H);
            this.gbxHeader.Controls.Add(this.lbl_CUSTCODE_H);
            this.gbxHeader.Controls.Add(this.cbo_STARTDATE_H);
            this.gbxHeader.Controls.Add(this.cbo_ENDDATE_H);
            this.gbxHeader.Controls.Add(this.cbo_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.txt_ITEMNAME_H);
            this.gbxHeader.Controls.Add(this.txt_ITEMCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_DATE_H);
            this.gbxHeader.Controls.Add(this.lbl_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_ITEMCODE_H);
            this.gbxHeader.Controls.Add(this.sLabel4);
            this.gbxHeader.Margin = new System.Windows.Forms.Padding(0);
            this.gbxHeader.Size = new System.Drawing.Size(1639, 127);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel4, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_ITEMCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_DATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_ITEMCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_ITEMNAME_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_ENDDATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_STARTDATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_CUSTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_CUSTNAME_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_CUSTCODE_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 2;
            this.gbxBody.ContentPadding.Left = 2;
            this.gbxBody.ContentPadding.Right = 2;
            this.gbxBody.ContentPadding.Top = 4;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 127);
            this.gbxBody.Margin = new System.Windows.Forms.Padding(0);
            this.gbxBody.Size = new System.Drawing.Size(1639, 743);
            // 
            // lbl_PLANTCODE_H
            // 
            appearance51.FontData.BoldAsString = "False";
            appearance51.FontData.UnderlineAsString = "False";
            appearance51.ForeColor = System.Drawing.Color.Black;
            appearance51.TextHAlignAsString = "Left";
            appearance51.TextVAlignAsString = "Middle";
            this.lbl_PLANTCODE_H.Appearance = appearance51;
            this.lbl_PLANTCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_PLANTCODE_H.DbField = null;
            this.lbl_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_PLANTCODE_H.Location = new System.Drawing.Point(110, 10);
            this.lbl_PLANTCODE_H.Name = "lbl_PLANTCODE_H";
            this.lbl_PLANTCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_PLANTCODE_H.Size = new System.Drawing.Size(90, 25);
            this.lbl_PLANTCODE_H.TabIndex = 230;
            this.lbl_PLANTCODE_H.Text = "사업장";
            // 
            // lbl_ITEMCODE_H
            // 
            appearance48.FontData.BoldAsString = "False";
            appearance48.FontData.UnderlineAsString = "False";
            appearance48.ForeColor = System.Drawing.Color.Black;
            appearance48.TextHAlignAsString = "Left";
            appearance48.TextVAlignAsString = "Middle";
            this.lbl_ITEMCODE_H.Appearance = appearance48;
            this.lbl_ITEMCODE_H.DbField = "cboUseFlag";
            this.lbl_ITEMCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_ITEMCODE_H.Location = new System.Drawing.Point(110, 67);
            this.lbl_ITEMCODE_H.Name = "lbl_ITEMCODE_H";
            this.lbl_ITEMCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_ITEMCODE_H.Size = new System.Drawing.Size(90, 25);
            this.lbl_ITEMCODE_H.TabIndex = 229;
            this.lbl_ITEMCODE_H.Text = "품목";
            // 
            // cbo_PLANTCODE_H
            // 
            this.cbo_PLANTCODE_H.AutoSize = false;
            this.cbo_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbo_PLANTCODE_H.Location = new System.Drawing.Point(110, 32);
            this.cbo_PLANTCODE_H.Name = "cbo_PLANTCODE_H";
            this.cbo_PLANTCODE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_PLANTCODE_H.TabIndex = 0;
            // 
            // cbo_ENDDATE_H
            // 
            this.cbo_ENDDATE_H.AutoSize = false;
            this.cbo_ENDDATE_H.DateButtons.Add(dateButton2);
            this.cbo_ENDDATE_H.Location = new System.Drawing.Point(516, 32);
            this.cbo_ENDDATE_H.Name = "cbo_ENDDATE_H";
            this.cbo_ENDDATE_H.NonAutoSizeHeight = 26;
            this.cbo_ENDDATE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_ENDDATE_H.TabIndex = 2;
            this.cbo_ENDDATE_H.Value = new System.DateTime(2020, 5, 4, 0, 0, 0, 0);
            // 
            // cbo_STARTDATE_H
            // 
            this.cbo_STARTDATE_H.AutoSize = false;
            this.cbo_STARTDATE_H.DateButtons.Add(dateButton1);
            this.cbo_STARTDATE_H.Location = new System.Drawing.Point(320, 32);
            this.cbo_STARTDATE_H.Name = "cbo_STARTDATE_H";
            this.cbo_STARTDATE_H.NonAutoSizeHeight = 26;
            this.cbo_STARTDATE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_STARTDATE_H.TabIndex = 1;
            this.cbo_STARTDATE_H.Value = new System.DateTime(2020, 5, 4, 0, 0, 0, 0);
            // 
            // sLabel4
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.sLabel4.Appearance = appearance3;
            this.sLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel4.DbField = null;
            this.sLabel4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel4.Location = new System.Drawing.Point(480, 32);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel4.Size = new System.Drawing.Size(36, 27);
            this.sLabel4.TabIndex = 242;
            this.sLabel4.Text = "~";
            // 
            // lbl_DATE_H
            // 
            appearance14.FontData.BoldAsString = "False";
            appearance14.FontData.UnderlineAsString = "False";
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            this.lbl_DATE_H.Appearance = appearance14;
            this.lbl_DATE_H.DbField = null;
            this.lbl_DATE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_DATE_H.Location = new System.Drawing.Point(320, 10);
            this.lbl_DATE_H.Name = "lbl_DATE_H";
            this.lbl_DATE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_DATE_H.Size = new System.Drawing.Size(90, 25);
            this.lbl_DATE_H.TabIndex = 240;
            this.lbl_DATE_H.Text = "등록 일자";
            // 
            // txt_ITEMNAME_H
            // 
            appearance52.FontData.BoldAsString = "False";
            appearance52.FontData.UnderlineAsString = "False";
            appearance52.ForeColor = System.Drawing.Color.Black;
            this.txt_ITEMNAME_H.Appearance = appearance52;
            this.txt_ITEMNAME_H.AutoSize = false;
            this.txt_ITEMNAME_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_ITEMNAME_H.Location = new System.Drawing.Point(254, 89);
            this.txt_ITEMNAME_H.Name = "txt_ITEMNAME_H";
            this.txt_ITEMNAME_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_ITEMNAME_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_ITEMNAME_H.Size = new System.Drawing.Size(200, 27);
            this.txt_ITEMNAME_H.TabIndex = 258;
            // 
            // txt_ITEMCODE_H
            // 
            appearance60.FontData.BoldAsString = "False";
            appearance60.FontData.Name = "맑은 고딕";
            appearance60.FontData.SizeInPoints = 10F;
            appearance60.FontData.UnderlineAsString = "False";
            appearance60.ForeColor = System.Drawing.Color.Black;
            this.txt_ITEMCODE_H.Appearance = appearance60;
            this.txt_ITEMCODE_H.AutoSize = false;
            this.txt_ITEMCODE_H.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txt_ITEMCODE_H.btnWidth = 26;
            this.txt_ITEMCODE_H.Location = new System.Drawing.Point(110, 89);
            this.txt_ITEMCODE_H.Name = "txt_ITEMCODE_H";
            this.txt_ITEMCODE_H.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_ITEMCODE_H.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_ITEMCODE_H.Size = new System.Drawing.Size(145, 27);
            this.txt_ITEMCODE_H.TabIndex = 257;
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
            appearance57.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance57.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance57.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance57;
            appearance58.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance58;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance1;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance7;
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
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance9;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance56.BackColor = System.Drawing.SystemColors.Window;
            appearance56.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance56;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance15;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(4, 4);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1631, 735);
            this.grid1.TabIndex = 11;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txt_CUSTCODE_H
            // 
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.Name = "맑은 고딕";
            appearance17.FontData.SizeInPoints = 10F;
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            this.txt_CUSTCODE_H.Appearance = appearance17;
            this.txt_CUSTCODE_H.AutoSize = false;
            this.txt_CUSTCODE_H.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txt_CUSTCODE_H.btnWidth = 26;
            this.txt_CUSTCODE_H.Location = new System.Drawing.Point(516, 89);
            this.txt_CUSTCODE_H.Name = "txt_CUSTCODE_H";
            this.txt_CUSTCODE_H.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_CUSTCODE_H.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_CUSTCODE_H.Size = new System.Drawing.Size(145, 27);
            this.txt_CUSTCODE_H.TabIndex = 261;
            // 
            // txt_CUSTNAME_H
            // 
            appearance74.FontData.BoldAsString = "False";
            appearance74.FontData.UnderlineAsString = "False";
            appearance74.ForeColor = System.Drawing.Color.Black;
            this.txt_CUSTNAME_H.Appearance = appearance74;
            this.txt_CUSTNAME_H.AutoSize = false;
            this.txt_CUSTNAME_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_CUSTNAME_H.Location = new System.Drawing.Point(660, 89);
            this.txt_CUSTNAME_H.Name = "txt_CUSTNAME_H";
            this.txt_CUSTNAME_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_CUSTNAME_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_CUSTNAME_H.Size = new System.Drawing.Size(200, 27);
            this.txt_CUSTNAME_H.TabIndex = 259;
            // 
            // lbl_CUSTCODE_H
            // 
            appearance25.FontData.BoldAsString = "False";
            appearance25.FontData.UnderlineAsString = "False";
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.TextHAlignAsString = "Left";
            appearance25.TextVAlignAsString = "Middle";
            this.lbl_CUSTCODE_H.Appearance = appearance25;
            this.lbl_CUSTCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_CUSTCODE_H.DbField = null;
            this.lbl_CUSTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_CUSTCODE_H.Location = new System.Drawing.Point(516, 67);
            this.lbl_CUSTCODE_H.Name = "lbl_CUSTCODE_H";
            this.lbl_CUSTCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_CUSTCODE_H.Size = new System.Drawing.Size(345, 25);
            this.lbl_CUSTCODE_H.TabIndex = 260;
            this.lbl_CUSTCODE_H.Text = "거래처";
            // 
            // PP0280
            // 
            this.ClientSize = new System.Drawing.Size(1639, 870);
            this.Name = "PP0280";
            this.Text = "외부 재고";
            this.Load += new System.EventHandler(this.PP0280_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ENDDATE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STARTDATE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMNAME_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CUSTCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CUSTNAME_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Control.SLabel lbl_PLANTCODE_H;
        private Control.SLabel lbl_ITEMCODE_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_PLANTCODE_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cbo_ENDDATE_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cbo_STARTDATE_H;
        private Control.SLabel sLabel4;
        private Control.SLabel lbl_DATE_H;
        private Control.STextBox txt_ITEMNAME_H;
        private Control.SBtnTextEditor txt_ITEMCODE_H;
        private Control.Grid grid1;
        private Control.SBtnTextEditor txt_CUSTCODE_H;
        private Control.STextBox txt_CUSTNAME_H;
        private Control.SLabel lbl_CUSTCODE_H;
    }
}

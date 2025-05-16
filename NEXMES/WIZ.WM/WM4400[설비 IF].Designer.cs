namespace WIZ.WM
{
    partial class WM4400
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
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton3 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.gbx_LEFT_B = new Infragistics.Win.Misc.UltraGroupBox();
            this.lbl_PLANTCODE_H = new WIZ.Control.SLabel();
            this.cbo_PLANTCODE_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbo_STARTDATE_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cbo_ENDDATE_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.txt_ITEMNAME_H = new WIZ.Control.STextBox(this.components);
            this.txt_ITEMCODE_H = new WIZ.Control.SBtnTextEditor();
            this.lbl_DATE_H = new WIZ.Control.SLabel();
            this.lbl_ITEMCODE_H = new WIZ.Control.SLabel();
            this.lbl = new WIZ.Control.SLabel();
            this.sLabel1 = new WIZ.Control.SLabel();
            this.Time2 = new System.Windows.Forms.DateTimePicker();
            this.Time1 = new System.Windows.Forms.DateTimePicker();
            this.ultraTimeSpanEditor1 = new Infragistics.Win.UltraWinEditors.UltraTimeSpanEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbx_LEFT_B)).BeginInit();
            this.gbx_LEFT_B.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STARTDATE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ENDDATE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMNAME_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTimeSpanEditor1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.ultraTimeSpanEditor1);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.Time2);
            this.gbxHeader.Controls.Add(this.Time1);
            this.gbxHeader.Controls.Add(this.cbo_STARTDATE_H);
            this.gbxHeader.Controls.Add(this.cbo_ENDDATE_H);
            this.gbxHeader.Controls.Add(this.txt_ITEMNAME_H);
            this.gbxHeader.Controls.Add(this.txt_ITEMCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_DATE_H);
            this.gbxHeader.Controls.Add(this.lbl_ITEMCODE_H);
            this.gbxHeader.Controls.Add(this.lbl);
            this.gbxHeader.Controls.Add(this.cbo_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_PLANTCODE_H);
            this.gbxHeader.Margin = new System.Windows.Forms.Padding(0);
            this.gbxHeader.Size = new System.Drawing.Size(1639, 124);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_ITEMCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_DATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_ITEMCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_ITEMNAME_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_ENDDATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_STARTDATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.Time1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.Time2, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.ultraTimeSpanEditor1, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 2;
            this.gbxBody.ContentPadding.Left = 2;
            this.gbxBody.ContentPadding.Right = 2;
            this.gbxBody.ContentPadding.Top = 4;
            this.gbxBody.Controls.Add(this.gbx_LEFT_B);
            this.gbxBody.Location = new System.Drawing.Point(0, 124);
            this.gbxBody.Margin = new System.Windows.Forms.Padding(0);
            this.gbxBody.Size = new System.Drawing.Size(1639, 746);
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
            appearance19.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance19.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance19;
            appearance20.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance20;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance21.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance21.BackColor2 = System.Drawing.SystemColors.Control;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance21;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance22;
            appearance23.BackColor = System.Drawing.SystemColors.Highlight;
            appearance23.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance23;
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
            appearance25.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance25;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance8;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            this.grid1.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            appearance26.BackColor = System.Drawing.SystemColors.Control;
            appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance26.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance26.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance26;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance51.BackColor = System.Drawing.SystemColors.Window;
            appearance51.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance51;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance80.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance80;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(3, 24);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1625, 711);
            this.grid1.TabIndex = 10;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // gbx_LEFT_B
            // 
            this.gbx_LEFT_B.Controls.Add(this.grid1);
            this.gbx_LEFT_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_LEFT_B.Location = new System.Drawing.Point(4, 4);
            this.gbx_LEFT_B.Margin = new System.Windows.Forms.Padding(0);
            this.gbx_LEFT_B.Name = "gbx_LEFT_B";
            this.gbx_LEFT_B.Size = new System.Drawing.Size(1631, 738);
            this.gbx_LEFT_B.TabIndex = 0;
            this.gbx_LEFT_B.Text = "목표";
            // 
            // lbl_PLANTCODE_H
            // 
            appearance14.FontData.BoldAsString = "False";
            appearance14.FontData.SizeInPoints = 10F;
            appearance14.FontData.UnderlineAsString = "False";
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            this.lbl_PLANTCODE_H.Appearance = appearance14;
            this.lbl_PLANTCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_PLANTCODE_H.DbField = null;
            this.lbl_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_PLANTCODE_H.Location = new System.Drawing.Point(1146, 2);
            this.lbl_PLANTCODE_H.Name = "lbl_PLANTCODE_H";
            this.lbl_PLANTCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_PLANTCODE_H.Size = new System.Drawing.Size(90, 25);
            this.lbl_PLANTCODE_H.TabIndex = 702;
            this.lbl_PLANTCODE_H.Text = "사업장";
            this.lbl_PLANTCODE_H.Visible = false;
            // 
            // cbo_PLANTCODE_H
            // 
            this.cbo_PLANTCODE_H.AutoSize = false;
            this.cbo_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbo_PLANTCODE_H.Location = new System.Drawing.Point(1146, 24);
            this.cbo_PLANTCODE_H.Name = "cbo_PLANTCODE_H";
            this.cbo_PLANTCODE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_PLANTCODE_H.TabIndex = 714;
            this.cbo_PLANTCODE_H.Visible = false;
            // 
            // cbo_STARTDATE_H
            // 
            appearance4.FontData.SizeInPoints = 11F;
            this.cbo_STARTDATE_H.Appearance = appearance4;
            this.cbo_STARTDATE_H.AutoSize = false;
            this.cbo_STARTDATE_H.DateButtons.Add(dateButton1);
            this.cbo_STARTDATE_H.Location = new System.Drawing.Point(116, 38);
            this.cbo_STARTDATE_H.Name = "cbo_STARTDATE_H";
            this.cbo_STARTDATE_H.NonAutoSizeHeight = 26;
            this.cbo_STARTDATE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_STARTDATE_H.TabIndex = 718;
            this.cbo_STARTDATE_H.Value = new System.DateTime(2017, 1, 10, 0, 0, 0, 0);
            // 
            // cbo_ENDDATE_H
            // 
            appearance7.FontData.SizeInPoints = 11F;
            this.cbo_ENDDATE_H.Appearance = appearance7;
            this.cbo_ENDDATE_H.AutoSize = false;
            this.cbo_ENDDATE_H.DateButtons.Add(dateButton2);
            this.cbo_ENDDATE_H.DateButtons.Add(dateButton3);
            this.cbo_ENDDATE_H.Location = new System.Drawing.Point(312, 38);
            this.cbo_ENDDATE_H.Name = "cbo_ENDDATE_H";
            this.cbo_ENDDATE_H.NonAutoSizeHeight = 26;
            this.cbo_ENDDATE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_ENDDATE_H.TabIndex = 720;
            this.cbo_ENDDATE_H.Value = new System.DateTime(2017, 1, 10, 0, 0, 0, 0);
            // 
            // txt_ITEMNAME_H
            // 
            appearance59.FontData.BoldAsString = "False";
            appearance59.FontData.UnderlineAsString = "False";
            appearance59.ForeColor = System.Drawing.Color.Black;
            this.txt_ITEMNAME_H.Appearance = appearance59;
            this.txt_ITEMNAME_H.AutoSize = false;
            this.txt_ITEMNAME_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_ITEMNAME_H.Location = new System.Drawing.Point(666, 38);
            this.txt_ITEMNAME_H.Name = "txt_ITEMNAME_H";
            this.txt_ITEMNAME_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_ITEMNAME_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_ITEMNAME_H.Size = new System.Drawing.Size(200, 27);
            this.txt_ITEMNAME_H.TabIndex = 717;
            this.txt_ITEMNAME_H.Visible = false;
            // 
            // txt_ITEMCODE_H
            // 
            appearance24.FontData.BoldAsString = "False";
            appearance24.FontData.Name = "맑은 고딕";
            appearance24.FontData.SizeInPoints = 10F;
            appearance24.FontData.UnderlineAsString = "False";
            appearance24.ForeColor = System.Drawing.Color.Black;
            this.txt_ITEMCODE_H.Appearance = appearance24;
            this.txt_ITEMCODE_H.AutoSize = false;
            this.txt_ITEMCODE_H.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txt_ITEMCODE_H.btnWidth = 26;
            this.txt_ITEMCODE_H.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ITEMCODE_H.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_ITEMCODE_H.Location = new System.Drawing.Point(522, 38);
            this.txt_ITEMCODE_H.Name = "txt_ITEMCODE_H";
            this.txt_ITEMCODE_H.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_ITEMCODE_H.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_ITEMCODE_H.Size = new System.Drawing.Size(145, 27);
            this.txt_ITEMCODE_H.TabIndex = 716;
            this.txt_ITEMCODE_H.Visible = false;
            // 
            // lbl_DATE_H
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lbl_DATE_H.Appearance = appearance2;
            this.lbl_DATE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_DATE_H.DbField = null;
            this.lbl_DATE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.lbl_DATE_H.Location = new System.Drawing.Point(116, 16);
            this.lbl_DATE_H.Name = "lbl_DATE_H";
            this.lbl_DATE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_DATE_H.Size = new System.Drawing.Size(310, 25);
            this.lbl_DATE_H.TabIndex = 719;
            this.lbl_DATE_H.Text = "I/F 일자";
            // 
            // lbl_ITEMCODE_H
            // 
            appearance60.FontData.BoldAsString = "False";
            appearance60.FontData.UnderlineAsString = "False";
            appearance60.ForeColor = System.Drawing.Color.Black;
            appearance60.TextHAlignAsString = "Left";
            appearance60.TextVAlignAsString = "Middle";
            this.lbl_ITEMCODE_H.Appearance = appearance60;
            this.lbl_ITEMCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_ITEMCODE_H.DbField = null;
            this.lbl_ITEMCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_ITEMCODE_H.Location = new System.Drawing.Point(522, 16);
            this.lbl_ITEMCODE_H.Name = "lbl_ITEMCODE_H";
            this.lbl_ITEMCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_ITEMCODE_H.Size = new System.Drawing.Size(145, 25);
            this.lbl_ITEMCODE_H.TabIndex = 715;
            this.lbl_ITEMCODE_H.Text = "품목";
            this.lbl_ITEMCODE_H.Visible = false;
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
            this.lbl.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.lbl.Location = new System.Drawing.Point(276, 38);
            this.lbl.Name = "lbl";
            this.lbl.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl.Size = new System.Drawing.Size(36, 27);
            this.lbl.TabIndex = 721;
            this.lbl.Text = "~";
            // 
            // sLabel1
            // 
            appearance40.FontData.BoldAsString = "False";
            appearance40.FontData.UnderlineAsString = "False";
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextHAlignAsString = "Center";
            appearance40.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance40;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(276, 69);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(36, 27);
            this.sLabel1.TabIndex = 724;
            this.sLabel1.Text = "~";
            this.sLabel1.Visible = false;
            // 
            // Time2
            // 
            this.Time2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.Time2.Location = new System.Drawing.Point(314, 71);
            this.Time2.Name = "Time2";
            this.Time2.ShowUpDown = true;
            this.Time2.Size = new System.Drawing.Size(158, 27);
            this.Time2.TabIndex = 723;
            this.Time2.Visible = false;
            // 
            // Time1
            // 
            this.Time1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.Time1.Location = new System.Drawing.Point(116, 69);
            this.Time1.Name = "Time1";
            this.Time1.ShowUpDown = true;
            this.Time1.Size = new System.Drawing.Size(158, 27);
            this.Time1.TabIndex = 722;
            this.Time1.Visible = false;
            // 
            // ultraTimeSpanEditor1
            // 
            this.ultraTimeSpanEditor1.Location = new System.Drawing.Point(897, 38);
            this.ultraTimeSpanEditor1.Name = "ultraTimeSpanEditor1";
            this.ultraTimeSpanEditor1.Size = new System.Drawing.Size(192, 29);
            this.ultraTimeSpanEditor1.TabIndex = 727;
            this.ultraTimeSpanEditor1.Visible = false;
            // 
            // WM4400
            // 
            this.ClientSize = new System.Drawing.Size(1639, 870);
            this.Name = "WM4400";
            this.Text = "점검/조치항목";
            this.Load += new System.EventHandler(this.WM4400_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbx_LEFT_B)).EndInit();
            this.gbx_LEFT_B.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STARTDATE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ENDDATE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMNAME_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTimeSpanEditor1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Control.Grid grid1;
        private Infragistics.Win.Misc.UltraGroupBox gbx_LEFT_B;
        private Control.SLabel lbl_PLANTCODE_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_PLANTCODE_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cbo_STARTDATE_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cbo_ENDDATE_H;
        private Control.STextBox txt_ITEMNAME_H;
        private Control.SBtnTextEditor txt_ITEMCODE_H;
        private Control.SLabel lbl_DATE_H;
        private Control.SLabel lbl_ITEMCODE_H;
        private Control.SLabel lbl;
        private Control.SLabel sLabel1;
        private System.Windows.Forms.DateTimePicker Time2;
        private System.Windows.Forms.DateTimePicker Time1;
        private Infragistics.Win.UltraWinEditors.UltraTimeSpanEditor ultraTimeSpanEditor1;
    }
}

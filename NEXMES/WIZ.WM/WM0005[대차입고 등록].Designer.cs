namespace WIZ.WM
{
    partial class WM0005
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.lbl_PLANTCODE_H = new WIZ.Control.SLabel();
            this.cbo_PLANTCODE_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbo_ENDDATE_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cbo_STARTDATE_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.sLabel1 = new WIZ.Control.SLabel();
            this.lbl_DATE_H = new WIZ.Control.SLabel();
            this.txtLOTNO = new WIZ.Control.STextBox(this.components);
            this.lbl_LOTNO_H = new WIZ.Control.SLabel();
            this.txt_ITEMNAME_H = new WIZ.Control.STextBox(this.components);
            this.txt_ITEMCODE_H = new WIZ.Control.SBtnTextEditor();
            this.lbl_ITEMCODE_H = new WIZ.Control.SLabel();
            this.btnBoxIn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_ZBPRINT_B = new System.Windows.Forms.RadioButton();
            this.btn_PRINT_H = new System.Windows.Forms.Button();
            this.txtFrameNo = new WIZ.Control.STextBox(this.components);
            this.sLabel2 = new WIZ.Control.SLabel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ENDDATE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STARTDATE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMNAME_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMCODE_H)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrameNo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.txtFrameNo);
            this.gbxHeader.Controls.Add(this.sLabel2);
            this.gbxHeader.Controls.Add(this.groupBox1);
            this.gbxHeader.Controls.Add(this.btn_PRINT_H);
            this.gbxHeader.Controls.Add(this.btnBoxIn);
            this.gbxHeader.Controls.Add(this.txt_ITEMNAME_H);
            this.gbxHeader.Controls.Add(this.txt_ITEMCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_ITEMCODE_H);
            this.gbxHeader.Controls.Add(this.txtLOTNO);
            this.gbxHeader.Controls.Add(this.lbl_LOTNO_H);
            this.gbxHeader.Controls.Add(this.cbo_ENDDATE_H);
            this.gbxHeader.Controls.Add(this.cbo_STARTDATE_H);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.lbl_DATE_H);
            this.gbxHeader.Controls.Add(this.cbo_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_PLANTCODE_H);
            this.gbxHeader.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.gbxHeader.Size = new System.Drawing.Size(1639, 73);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_DATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_STARTDATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_ENDDATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_LOTNO_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtLOTNO, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_ITEMCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_ITEMCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_ITEMNAME_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.btnBoxIn, 0);
            this.gbxHeader.Controls.SetChildIndex(this.btn_PRINT_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.groupBox1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel2, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtFrameNo, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 2;
            this.gbxBody.ContentPadding.Left = 2;
            this.gbxBody.ContentPadding.Right = 2;
            this.gbxBody.ContentPadding.Top = 4;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 73);
            this.gbxBody.Size = new System.Drawing.Size(1639, 797);
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
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance5;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance6;
            appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance8;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.Control;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance7;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance13;
            appearance9.BackColor = System.Drawing.SystemColors.Highlight;
            appearance9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance9;
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
            appearance16.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance16;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            appearance14.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance14;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance1.BackColor = System.Drawing.SystemColors.Control;
            appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance1.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance1.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance1;
            appearance11.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance68.BackColor = System.Drawing.SystemColors.Window;
            appearance68.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance68;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance64.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance64;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(4, 4);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1631, 789);
            this.grid1.TabIndex = 10;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lbl_PLANTCODE_H
            // 
            appearance32.FontData.BoldAsString = "False";
            appearance32.FontData.UnderlineAsString = "False";
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.TextHAlignAsString = "Left";
            appearance32.TextVAlignAsString = "Middle";
            this.lbl_PLANTCODE_H.Appearance = appearance32;
            this.lbl_PLANTCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_PLANTCODE_H.DbField = null;
            this.lbl_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_PLANTCODE_H.Location = new System.Drawing.Point(110, 10);
            this.lbl_PLANTCODE_H.Name = "lbl_PLANTCODE_H";
            this.lbl_PLANTCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_PLANTCODE_H.Size = new System.Drawing.Size(145, 25);
            this.lbl_PLANTCODE_H.TabIndex = 117;
            this.lbl_PLANTCODE_H.Text = "사업장";
            // 
            // cbo_PLANTCODE_H
            // 
            this.cbo_PLANTCODE_H.AutoSize = false;
            this.cbo_PLANTCODE_H.Location = new System.Drawing.Point(110, 32);
            this.cbo_PLANTCODE_H.Name = "cbo_PLANTCODE_H";
            this.cbo_PLANTCODE_H.Size = new System.Drawing.Size(134, 27);
            this.cbo_PLANTCODE_H.TabIndex = 0;
            // 
            // cbo_ENDDATE_H
            // 
            appearance77.FontData.Name = "맑은 고딕";
            appearance77.FontData.SizeInPoints = 11F;
            this.cbo_ENDDATE_H.Appearance = appearance77;
            this.cbo_ENDDATE_H.AutoSize = false;
            this.cbo_ENDDATE_H.DateButtons.Add(dateButton1);
            this.cbo_ENDDATE_H.Location = new System.Drawing.Point(419, 32);
            this.cbo_ENDDATE_H.Name = "cbo_ENDDATE_H";
            this.cbo_ENDDATE_H.NonAutoSizeHeight = 26;
            this.cbo_ENDDATE_H.Size = new System.Drawing.Size(118, 27);
            this.cbo_ENDDATE_H.TabIndex = 635;
            this.cbo_ENDDATE_H.Value = new System.DateTime(2018, 4, 10, 0, 0, 0, 0);
            // 
            // cbo_STARTDATE_H
            // 
            appearance70.FontData.Name = "맑은 고딕";
            appearance70.FontData.SizeInPoints = 11F;
            this.cbo_STARTDATE_H.Appearance = appearance70;
            this.cbo_STARTDATE_H.AutoSize = false;
            this.cbo_STARTDATE_H.DateButtons.Add(dateButton2);
            this.cbo_STARTDATE_H.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbo_STARTDATE_H.Location = new System.Drawing.Point(259, 32);
            this.cbo_STARTDATE_H.Name = "cbo_STARTDATE_H";
            this.cbo_STARTDATE_H.NonAutoSizeHeight = 26;
            this.cbo_STARTDATE_H.Size = new System.Drawing.Size(118, 27);
            this.cbo_STARTDATE_H.TabIndex = 634;
            this.cbo_STARTDATE_H.Value = new System.DateTime(2018, 4, 10, 0, 0, 0, 0);
            // 
            // sLabel1
            // 
            appearance38.FontData.BoldAsString = "False";
            appearance38.FontData.UnderlineAsString = "False";
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.TextHAlignAsString = "Center";
            appearance38.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance38;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(379, 32);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(36, 27);
            this.sLabel1.TabIndex = 637;
            this.sLabel1.Text = "~";
            // 
            // lbl_DATE_H
            // 
            appearance63.FontData.BoldAsString = "False";
            appearance63.FontData.Name = "맑은 고딕";
            appearance63.FontData.SizeInPoints = 9.75F;
            appearance63.FontData.UnderlineAsString = "False";
            appearance63.ForeColor = System.Drawing.Color.Black;
            appearance63.TextHAlignAsString = "Left";
            appearance63.TextVAlignAsString = "Middle";
            this.lbl_DATE_H.Appearance = appearance63;
            this.lbl_DATE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_DATE_H.DbField = null;
            this.lbl_DATE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_DATE_H.Location = new System.Drawing.Point(259, 10);
            this.lbl_DATE_H.Name = "lbl_DATE_H";
            this.lbl_DATE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_DATE_H.Size = new System.Drawing.Size(90, 25);
            this.lbl_DATE_H.TabIndex = 636;
            this.lbl_DATE_H.Text = "생산일자";
            // 
            // txtLOTNO
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.txtLOTNO.Appearance = appearance2;
            this.txtLOTNO.AutoSize = false;
            this.txtLOTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLOTNO.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLOTNO.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLOTNO.Location = new System.Drawing.Point(864, 32);
            this.txtLOTNO.Name = "txtLOTNO";
            this.txtLOTNO.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtLOTNO.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtLOTNO.Size = new System.Drawing.Size(160, 27);
            this.txtLOTNO.TabIndex = 643;
            // 
            // lbl_LOTNO_H
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.lbl_LOTNO_H.Appearance = appearance3;
            this.lbl_LOTNO_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_LOTNO_H.DbField = null;
            this.lbl_LOTNO_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_LOTNO_H.Location = new System.Drawing.Point(864, 10);
            this.lbl_LOTNO_H.Name = "lbl_LOTNO_H";
            this.lbl_LOTNO_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_LOTNO_H.Size = new System.Drawing.Size(161, 25);
            this.lbl_LOTNO_H.TabIndex = 641;
            this.lbl_LOTNO_H.Text = "LOTNO";
            // 
            // txt_ITEMNAME_H
            // 
            appearance74.FontData.BoldAsString = "False";
            appearance74.FontData.UnderlineAsString = "False";
            appearance74.ForeColor = System.Drawing.Color.Black;
            this.txt_ITEMNAME_H.Appearance = appearance74;
            this.txt_ITEMNAME_H.AutoSize = false;
            this.txt_ITEMNAME_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_ITEMNAME_H.Location = new System.Drawing.Point(674, 32);
            this.txt_ITEMNAME_H.Name = "txt_ITEMNAME_H";
            this.txt_ITEMNAME_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_ITEMNAME_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_ITEMNAME_H.Size = new System.Drawing.Size(167, 27);
            this.txt_ITEMNAME_H.TabIndex = 645;
            // 
            // txt_ITEMCODE_H
            // 
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.Name = "맑은 고딕";
            appearance17.FontData.SizeInPoints = 10F;
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            this.txt_ITEMCODE_H.Appearance = appearance17;
            this.txt_ITEMCODE_H.AutoSize = false;
            this.txt_ITEMCODE_H.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txt_ITEMCODE_H.btnWidth = 26;
            this.txt_ITEMCODE_H.Location = new System.Drawing.Point(564, 32);
            this.txt_ITEMCODE_H.Name = "txt_ITEMCODE_H";
            this.txt_ITEMCODE_H.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_ITEMCODE_H.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_ITEMCODE_H.Size = new System.Drawing.Size(111, 27);
            this.txt_ITEMCODE_H.TabIndex = 644;
            // 
            // lbl_ITEMCODE_H
            // 
            appearance25.FontData.BoldAsString = "False";
            appearance25.FontData.UnderlineAsString = "False";
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.TextHAlignAsString = "Left";
            appearance25.TextVAlignAsString = "Middle";
            this.lbl_ITEMCODE_H.Appearance = appearance25;
            this.lbl_ITEMCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_ITEMCODE_H.DbField = null;
            this.lbl_ITEMCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_ITEMCODE_H.Location = new System.Drawing.Point(564, 10);
            this.lbl_ITEMCODE_H.Name = "lbl_ITEMCODE_H";
            this.lbl_ITEMCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_ITEMCODE_H.Size = new System.Drawing.Size(282, 25);
            this.lbl_ITEMCODE_H.TabIndex = 646;
            this.lbl_ITEMCODE_H.Text = "품목";
            // 
            // btnBoxIn
            // 
            this.btnBoxIn.BackColor = System.Drawing.Color.DimGray;
            this.btnBoxIn.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBoxIn.ForeColor = System.Drawing.Color.Gold;
            this.btnBoxIn.Location = new System.Drawing.Point(1031, 30);
            this.btnBoxIn.Name = "btnBoxIn";
            this.btnBoxIn.Size = new System.Drawing.Size(101, 30);
            this.btnBoxIn.TabIndex = 648;
            this.btnBoxIn.Text = "프레임입고";
            this.btnBoxIn.UseVisualStyleBackColor = false;
            this.btnBoxIn.Click += new System.EventHandler(this.btnBoxIn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_ZBPRINT_B);
            this.groupBox1.Location = new System.Drawing.Point(1268, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 56);
            this.groupBox1.TabIndex = 650;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "프린터 유형";
            // 
            // rb_ZBPRINT_B
            // 
            this.rb_ZBPRINT_B.AutoSize = true;
            this.rb_ZBPRINT_B.Checked = true;
            this.rb_ZBPRINT_B.Location = new System.Drawing.Point(4, 23);
            this.rb_ZBPRINT_B.Name = "rb_ZBPRINT_B";
            this.rb_ZBPRINT_B.Size = new System.Drawing.Size(108, 23);
            this.rb_ZBPRINT_B.TabIndex = 579;
            this.rb_ZBPRINT_B.TabStop = true;
            this.rb_ZBPRINT_B.Text = "Zebra Printer";
            this.rb_ZBPRINT_B.UseVisualStyleBackColor = true;
            // 
            // btn_PRINT_H
            // 
            this.btn_PRINT_H.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_PRINT_H.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_PRINT_H.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_PRINT_H.Location = new System.Drawing.Point(1540, 4);
            this.btn_PRINT_H.Name = "btn_PRINT_H";
            this.btn_PRINT_H.Size = new System.Drawing.Size(94, 64);
            this.btn_PRINT_H.TabIndex = 649;
            this.btn_PRINT_H.Text = "발행";
            this.btn_PRINT_H.UseVisualStyleBackColor = false;
            this.btn_PRINT_H.Click += new System.EventHandler(this.btn_PRINT_H_Click);
            // 
            // txtFrameNo
            // 
            appearance12.FontData.BoldAsString = "False";
            appearance12.FontData.UnderlineAsString = "False";
            appearance12.ForeColor = System.Drawing.Color.Black;
            this.txtFrameNo.Appearance = appearance12;
            this.txtFrameNo.AutoSize = false;
            this.txtFrameNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFrameNo.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtFrameNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFrameNo.Location = new System.Drawing.Point(1401, 33);
            this.txtFrameNo.Name = "txtFrameNo";
            this.txtFrameNo.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtFrameNo.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtFrameNo.Size = new System.Drawing.Size(136, 27);
            this.txtFrameNo.TabIndex = 652;
            // 
            // sLabel2
            // 
            appearance20.FontData.BoldAsString = "False";
            appearance20.FontData.UnderlineAsString = "False";
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextHAlignAsString = "Left";
            appearance20.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance20;
            this.sLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(1401, 4);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(136, 25);
            this.sLabel2.TabIndex = 651;
            this.sLabel2.Text = "프레임수주번호";
            // 
            // WM0005
            // 
            this.ClientSize = new System.Drawing.Size(1639, 870);
            this.Name = "WM0005";
            this.Text = "대차입고 등록";
            this.Load += new System.EventHandler(this.WM0005_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ENDDATE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STARTDATE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMNAME_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMCODE_H)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrameNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Control.Grid grid1;
        private Control.SLabel lbl_PLANTCODE_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_PLANTCODE_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cbo_ENDDATE_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cbo_STARTDATE_H;
        private Control.SLabel sLabel1;
        private Control.SLabel lbl_DATE_H;
        private Control.STextBox txtLOTNO;
        private Control.SLabel lbl_LOTNO_H;
        private Control.STextBox txt_ITEMNAME_H;
        private Control.SBtnTextEditor txt_ITEMCODE_H;
        private Control.SLabel lbl_ITEMCODE_H;
        private System.Windows.Forms.Button btnBoxIn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_ZBPRINT_B;
        private System.Windows.Forms.Button btn_PRINT_H;
        private Control.STextBox txtFrameNo;
        private Control.SLabel sLabel2;
        private System.IO.Ports.SerialPort serialPort1;
    }
}
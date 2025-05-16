namespace WIZ.MM
{
    partial class MM0015
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
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            this.lbl_PLANTCODE_H = new WIZ.Control.SLabel();
            this.cbo_PLANTCODE_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.txt_ITEMNAME_H = new WIZ.Control.STextBox(this.components);
            this.txt_ITEMCODE_H = new WIZ.Control.SBtnTextEditor();
            this.chk_LOTNO_H = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblChkLotno = new WIZ.Control.SLabel();
            this.btn_PRINT_H = new System.Windows.Forms.Button();
            this.lbl_LOTNO_H = new WIZ.Control.SLabel();
            this.lbl_ITEMCODE_H = new WIZ.Control.SLabel();
            this.cbo_ENDDATE_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cbo_STARTDATE_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lbl_DATE_H = new WIZ.Control.SLabel();
            this.sLabel2 = new WIZ.Control.SLabel();
            this.txt_LOTNO_H = new WIZ.Control.STextBox(this.components);
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_ZBPRINT_B = new System.Windows.Forms.RadioButton();
            this.rb_NMPRINT_B = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMNAME_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_LOTNO_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ENDDATE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STARTDATE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LOTNO_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.groupBox1);
            this.gbxHeader.Controls.Add(this.txt_LOTNO_H);
            this.gbxHeader.Controls.Add(this.btn_PRINT_H);
            this.gbxHeader.Controls.Add(this.chk_LOTNO_H);
            this.gbxHeader.Controls.Add(this.cbo_STARTDATE_H);
            this.gbxHeader.Controls.Add(this.lblChkLotno);
            this.gbxHeader.Controls.Add(this.txt_ITEMNAME_H);
            this.gbxHeader.Controls.Add(this.txt_ITEMCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_LOTNO_H);
            this.gbxHeader.Controls.Add(this.cbo_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_DATE_H);
            this.gbxHeader.Controls.Add(this.cbo_ENDDATE_H);
            this.gbxHeader.Controls.Add(this.lbl_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_ITEMCODE_H);
            this.gbxHeader.Controls.Add(this.sLabel2);
            this.gbxHeader.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.gbxHeader.Margin = new System.Windows.Forms.Padding(0);
            this.gbxHeader.Size = new System.Drawing.Size(1637, 146);
            this.gbxHeader.TabIndex = 0;
            this.gbxHeader.Controls.SetChildIndex(this.sLabel2, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_ITEMCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_ENDDATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_DATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_LOTNO_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_ITEMCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_ITEMNAME_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblChkLotno, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_STARTDATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.chk_LOTNO_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.btn_PRINT_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_LOTNO_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.groupBox1, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 2;
            this.gbxBody.ContentPadding.Left = 2;
            this.gbxBody.ContentPadding.Right = 2;
            this.gbxBody.ContentPadding.Top = 4;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 146);
            this.gbxBody.Margin = new System.Windows.Forms.Padding(0);
            this.gbxBody.Size = new System.Drawing.Size(1637, 716);
            // 
            // lbl_PLANTCODE_H
            // 
            appearance57.FontData.BoldAsString = "False";
            appearance57.FontData.UnderlineAsString = "False";
            appearance57.ForeColor = System.Drawing.Color.Black;
            appearance57.TextHAlignAsString = "Left";
            appearance57.TextVAlignAsString = "Middle";
            this.lbl_PLANTCODE_H.Appearance = appearance57;
            this.lbl_PLANTCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_PLANTCODE_H.DbField = null;
            this.lbl_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_PLANTCODE_H.Location = new System.Drawing.Point(106, 36);
            this.lbl_PLANTCODE_H.Name = "lbl_PLANTCODE_H";
            this.lbl_PLANTCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_PLANTCODE_H.Size = new System.Drawing.Size(145, 25);
            this.lbl_PLANTCODE_H.TabIndex = 73;
            this.lbl_PLANTCODE_H.Text = "사업장";
            // 
            // cbo_PLANTCODE_H
            // 
            this.cbo_PLANTCODE_H.AutoSize = false;
            this.cbo_PLANTCODE_H.Location = new System.Drawing.Point(106, 58);
            this.cbo_PLANTCODE_H.Name = "cbo_PLANTCODE_H";
            this.cbo_PLANTCODE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_PLANTCODE_H.TabIndex = 0;
            // 
            // txt_ITEMNAME_H
            // 
            appearance13.FontData.BoldAsString = "False";
            appearance13.FontData.UnderlineAsString = "False";
            appearance13.ForeColor = System.Drawing.Color.Black;
            this.txt_ITEMNAME_H.Appearance = appearance13;
            this.txt_ITEMNAME_H.AutoSize = false;
            this.txt_ITEMNAME_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_ITEMNAME_H.Location = new System.Drawing.Point(854, 58);
            this.txt_ITEMNAME_H.Name = "txt_ITEMNAME_H";
            this.txt_ITEMNAME_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_ITEMNAME_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_ITEMNAME_H.Size = new System.Drawing.Size(200, 27);
            this.txt_ITEMNAME_H.TabIndex = 273;
            // 
            // txt_ITEMCODE_H
            // 
            appearance14.FontData.BoldAsString = "False";
            appearance14.FontData.Name = "맑은 고딕";
            appearance14.FontData.SizeInPoints = 10F;
            appearance14.FontData.UnderlineAsString = "False";
            appearance14.ForeColor = System.Drawing.Color.Black;
            this.txt_ITEMCODE_H.Appearance = appearance14;
            this.txt_ITEMCODE_H.AutoSize = false;
            this.txt_ITEMCODE_H.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txt_ITEMCODE_H.btnWidth = 26;
            this.txt_ITEMCODE_H.Location = new System.Drawing.Point(710, 58);
            this.txt_ITEMCODE_H.Name = "txt_ITEMCODE_H";
            this.txt_ITEMCODE_H.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_ITEMCODE_H.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_ITEMCODE_H.Size = new System.Drawing.Size(145, 27);
            this.txt_ITEMCODE_H.TabIndex = 272;
            // 
            // chk_LOTNO_H
            // 
            this.chk_LOTNO_H.Location = new System.Drawing.Point(1339, 45);
            this.chk_LOTNO_H.Name = "chk_LOTNO_H";
            this.chk_LOTNO_H.Size = new System.Drawing.Size(86, 27);
            this.chk_LOTNO_H.TabIndex = 261;
            this.chk_LOTNO_H.Text = "LOTNO";
            // 
            // lblChkLotno
            // 
            appearance52.BorderColor = System.Drawing.Color.Black;
            appearance52.FontData.BoldAsString = "False";
            appearance52.FontData.UnderlineAsString = "False";
            appearance52.ForeColor = System.Drawing.Color.Black;
            appearance52.TextHAlignAsString = "Left";
            appearance52.TextVAlignAsString = "Middle";
            this.lblChkLotno.Appearance = appearance52;
            this.lblChkLotno.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblChkLotno.DbField = null;
            this.lblChkLotno.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblChkLotno.Location = new System.Drawing.Point(1339, 23);
            this.lblChkLotno.Name = "lblChkLotno";
            this.lblChkLotno.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblChkLotno.Size = new System.Drawing.Size(77, 25);
            this.lblChkLotno.TabIndex = 269;
            this.lblChkLotno.Text = "조회조건";
            // 
            // btn_PRINT_H
            // 
            this.btn_PRINT_H.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_PRINT_H.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_PRINT_H.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_PRINT_H.Location = new System.Drawing.Point(1487, 4);
            this.btn_PRINT_H.Name = "btn_PRINT_H";
            this.btn_PRINT_H.Size = new System.Drawing.Size(145, 137);
            this.btn_PRINT_H.TabIndex = 260;
            this.btn_PRINT_H.Text = "합격라벨발행";
            this.btn_PRINT_H.UseVisualStyleBackColor = false;
            this.btn_PRINT_H.Click += new System.EventHandler(this.btn_PRINT_Click);
            // 
            // lbl_LOTNO_H
            // 
            appearance58.FontData.BoldAsString = "False";
            appearance58.FontData.UnderlineAsString = "False";
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextHAlignAsString = "Left";
            appearance58.TextVAlignAsString = "Middle";
            this.lbl_LOTNO_H.Appearance = appearance58;
            this.lbl_LOTNO_H.DbField = null;
            this.lbl_LOTNO_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_LOTNO_H.Location = new System.Drawing.Point(1129, 21);
            this.lbl_LOTNO_H.Name = "lbl_LOTNO_H";
            this.lbl_LOTNO_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_LOTNO_H.Size = new System.Drawing.Size(145, 25);
            this.lbl_LOTNO_H.TabIndex = 266;
            this.lbl_LOTNO_H.Text = "LOTNO";
            // 
            // lbl_ITEMCODE_H
            // 
            appearance20.FontData.BoldAsString = "False";
            appearance20.FontData.UnderlineAsString = "False";
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextHAlignAsString = "Left";
            appearance20.TextVAlignAsString = "Middle";
            this.lbl_ITEMCODE_H.Appearance = appearance20;
            this.lbl_ITEMCODE_H.DbField = null;
            this.lbl_ITEMCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_ITEMCODE_H.Location = new System.Drawing.Point(710, 36);
            this.lbl_ITEMCODE_H.Name = "lbl_ITEMCODE_H";
            this.lbl_ITEMCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_ITEMCODE_H.Size = new System.Drawing.Size(145, 25);
            this.lbl_ITEMCODE_H.TabIndex = 265;
            this.lbl_ITEMCODE_H.Text = "품목";
            // 
            // cbo_ENDDATE_H
            // 
            appearance19.FontData.SizeInPoints = 10F;
            this.cbo_ENDDATE_H.Appearance = appearance19;
            this.cbo_ENDDATE_H.AutoSize = false;
            this.cbo_ENDDATE_H.DateButtons.Add(dateButton2);
            this.cbo_ENDDATE_H.Location = new System.Drawing.Point(512, 58);
            this.cbo_ENDDATE_H.Name = "cbo_ENDDATE_H";
            this.cbo_ENDDATE_H.NonAutoSizeHeight = 26;
            this.cbo_ENDDATE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_ENDDATE_H.TabIndex = 256;
            this.cbo_ENDDATE_H.Value = new System.DateTime(2020, 7, 3, 0, 0, 0, 0);
            // 
            // cbo_STARTDATE_H
            // 
            appearance1.FontData.SizeInPoints = 10F;
            this.cbo_STARTDATE_H.Appearance = appearance1;
            this.cbo_STARTDATE_H.AutoSize = false;
            this.cbo_STARTDATE_H.DateButtons.Add(dateButton1);
            this.cbo_STARTDATE_H.Location = new System.Drawing.Point(316, 58);
            this.cbo_STARTDATE_H.Name = "cbo_STARTDATE_H";
            this.cbo_STARTDATE_H.NonAutoSizeHeight = 26;
            this.cbo_STARTDATE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_STARTDATE_H.TabIndex = 255;
            this.cbo_STARTDATE_H.Value = new System.DateTime(2020, 7, 3, 0, 0, 0, 0);
            this.cbo_STARTDATE_H.TextChanged += new System.EventHandler(this.dtStart_H_TextChanged);
            // 
            // lbl_DATE_H
            // 
            appearance16.FontData.BoldAsString = "False";
            appearance16.FontData.UnderlineAsString = "False";
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.lbl_DATE_H.Appearance = appearance16;
            this.lbl_DATE_H.DbField = null;
            this.lbl_DATE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_DATE_H.Location = new System.Drawing.Point(316, 36);
            this.lbl_DATE_H.Name = "lbl_DATE_H";
            this.lbl_DATE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_DATE_H.Size = new System.Drawing.Size(145, 25);
            this.lbl_DATE_H.TabIndex = 262;
            this.lbl_DATE_H.Text = "가입고일자";
            // 
            // sLabel2
            // 
            appearance21.FontData.BoldAsString = "False";
            appearance21.FontData.UnderlineAsString = "False";
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Center";
            appearance21.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance21;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(476, 58);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(36, 27);
            this.sLabel2.TabIndex = 263;
            this.sLabel2.Text = "~";
            // 
            // txt_LOTNO_H
            // 
            appearance27.FontData.BoldAsString = "False";
            appearance27.FontData.UnderlineAsString = "False";
            appearance27.ForeColor = System.Drawing.Color.Black;
            this.txt_LOTNO_H.Appearance = appearance27;
            this.txt_LOTNO_H.AutoSize = false;
            this.txt_LOTNO_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_LOTNO_H.Location = new System.Drawing.Point(1129, 43);
            this.txt_LOTNO_H.Name = "txt_LOTNO_H";
            this.txt_LOTNO_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_LOTNO_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_LOTNO_H.Size = new System.Drawing.Size(160, 27);
            this.txt_LOTNO_H.TabIndex = 275;
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
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance18;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance6;
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
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance12;
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
            this.grid1.Size = new System.Drawing.Size(1629, 708);
            this.grid1.TabIndex = 11;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.AfterCellListCloseUp += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grid1_AfterCellListCloseUp);
            this.grid1.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(this.grid1_ClickCell);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_ZBPRINT_B);
            this.groupBox1.Controls.Add(this.rb_NMPRINT_B);
            this.groupBox1.Location = new System.Drawing.Point(1129, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 50);
            this.groupBox1.TabIndex = 582;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "프린터 유형";
            // 
            // rb_ZBPRINT_B
            // 
            this.rb_ZBPRINT_B.AutoSize = true;
            this.rb_ZBPRINT_B.Checked = true;
            this.rb_ZBPRINT_B.Location = new System.Drawing.Point(156, 23);
            this.rb_ZBPRINT_B.Name = "rb_ZBPRINT_B";
            this.rb_ZBPRINT_B.Size = new System.Drawing.Size(108, 23);
            this.rb_ZBPRINT_B.TabIndex = 579;
            this.rb_ZBPRINT_B.TabStop = true;
            this.rb_ZBPRINT_B.Text = "Zebra Printer";
            this.rb_ZBPRINT_B.UseVisualStyleBackColor = true;
            // 
            // rb_NMPRINT_B
            // 
            this.rb_NMPRINT_B.AutoSize = true;
            this.rb_NMPRINT_B.Location = new System.Drawing.Point(8, 23);
            this.rb_NMPRINT_B.Name = "rb_NMPRINT_B";
            this.rb_NMPRINT_B.Size = new System.Drawing.Size(114, 23);
            this.rb_NMPRINT_B.TabIndex = 580;
            this.rb_NMPRINT_B.Text = "Nomal Printer";
            this.rb_NMPRINT_B.UseVisualStyleBackColor = true;
            // 
            // MM0015
            // 
            this.ClientSize = new System.Drawing.Size(1637, 862);
            this.Name = "MM0015";
            this.Text = "자재 유효기간 설정";
            this.Load += new System.EventHandler(this.MM0015_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMNAME_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_LOTNO_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ENDDATE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STARTDATE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LOTNO_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Control.SLabel lbl_PLANTCODE_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_PLANTCODE_H;
        private System.IO.Ports.SerialPort serialPort1;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cbo_STARTDATE_H;
        private Control.SLabel sLabel2;
        private Control.SLabel lbl_DATE_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cbo_ENDDATE_H;
        private Control.STextBox txt_ITEMNAME_H;
        private Control.SBtnTextEditor txt_ITEMCODE_H;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chk_LOTNO_H;
        private Control.SLabel lblChkLotno;
        private System.Windows.Forms.Button btn_PRINT_H;
        private Control.SLabel lbl_LOTNO_H;
        private Control.SLabel lbl_ITEMCODE_H;
        private Control.STextBox txt_LOTNO_H;
        private Control.Grid grid1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_ZBPRINT_B;
        private System.Windows.Forms.RadioButton rb_NMPRINT_B;
    }
}

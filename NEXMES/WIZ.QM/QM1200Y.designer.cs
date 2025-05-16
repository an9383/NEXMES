namespace WIZ.QM
{
    partial class QM1200Y
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.cboPlanIndate2_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cboPlanIndate1_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblDate = new WIZ.Control.SLabel();
            this.sLabel2 = new WIZ.Control.SLabel();
            this.lblCustCode = new WIZ.Control.SLabel();
            this.txtLOTNO_H = new System.Windows.Forms.TextBox();
            this.lblLotNo = new WIZ.Control.SLabel();
            this.lblItemName = new WIZ.Control.SLabel();
            this.btnMM0010 = new System.Windows.Forms.Button();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.chkLotno_H = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblChkLotNo = new WIZ.Control.SLabel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.txtItemName = new WIZ.Control.STextBox(this.components);
            this.txtItemCode = new WIZ.Control.SBtnTextEditor();
            this.txtCustName = new WIZ.Control.STextBox(this.components);
            this.txtCustCode = new WIZ.Control.SBtnTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanIndate2_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanIndate1_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLotno_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustCode)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.txtCustName);
            this.gbxHeader.Controls.Add(this.txtCustCode);
            this.gbxHeader.Controls.Add(this.txtItemName);
            this.gbxHeader.Controls.Add(this.txtItemCode);
            this.gbxHeader.Controls.Add(this.chkLotno_H);
            this.gbxHeader.Controls.Add(this.lblChkLotNo);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Controls.Add(this.btnMM0010);
            this.gbxHeader.Controls.Add(this.txtLOTNO_H);
            this.gbxHeader.Controls.Add(this.lblLotNo);
            this.gbxHeader.Controls.Add(this.lblItemName);
            this.gbxHeader.Controls.Add(this.lblCustCode);
            this.gbxHeader.Controls.Add(this.cboPlanIndate2_H);
            this.gbxHeader.Controls.Add(this.cboPlanIndate1_H);
            this.gbxHeader.Controls.Add(this.lblDate);
            this.gbxHeader.Controls.Add(this.sLabel2);
            this.gbxHeader.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.gbxHeader.Location = new System.Drawing.Point(3, 3);
            this.gbxHeader.Size = new System.Drawing.Size(1130, 120);
            this.gbxHeader.TabIndex = 0;
            this.gbxHeader.Controls.SetChildIndex(this.sLabel2, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlanIndate1_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlanIndate2_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblCustCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblItemName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblLotNo, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtLOTNO_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.btnMM0010, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblChkLotNo, 0);
            this.gbxHeader.Controls.SetChildIndex(this.chkLotno_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtCustCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtCustName, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(3, 123);
            this.gbxBody.Size = new System.Drawing.Size(1130, 699);
            // 
            // cboPlanIndate2_H
            // 
            appearance1.FontData.SizeInPoints = 10F;
            this.cboPlanIndate2_H.Appearance = appearance1;
            this.cboPlanIndate2_H.DateButtons.Add(dateButton1);
            this.cboPlanIndate2_H.Location = new System.Drawing.Point(857, 12);
            this.cboPlanIndate2_H.Name = "cboPlanIndate2_H";
            this.cboPlanIndate2_H.NonAutoSizeHeight = 26;
            this.cboPlanIndate2_H.Size = new System.Drawing.Size(145, 24);
            this.cboPlanIndate2_H.TabIndex = 2;
            this.cboPlanIndate2_H.Value = new System.DateTime(2015, 11, 24, 0, 0, 0, 0);
            this.cboPlanIndate2_H.TextChanged += new System.EventHandler(this.dtStart_H_TextChanged);
            // 
            // cboPlanIndate1_H
            // 
            appearance3.FontData.SizeInPoints = 10F;
            this.cboPlanIndate1_H.Appearance = appearance3;
            this.cboPlanIndate1_H.DateButtons.Add(dateButton2);
            this.cboPlanIndate1_H.Location = new System.Drawing.Point(672, 12);
            this.cboPlanIndate1_H.Name = "cboPlanIndate1_H";
            this.cboPlanIndate1_H.NonAutoSizeHeight = 26;
            this.cboPlanIndate1_H.Size = new System.Drawing.Size(145, 24);
            this.cboPlanIndate1_H.TabIndex = 1;
            this.cboPlanIndate1_H.Value = new System.DateTime(2015, 11, 24, 0, 0, 0, 0);
            this.cboPlanIndate1_H.TextChanged += new System.EventHandler(this.dtStart_H_TextChanged);
            // 
            // lblDate
            // 
            appearance23.FontData.BoldAsString = "False";
            appearance23.FontData.UnderlineAsString = "False";
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextHAlignAsString = "Right";
            appearance23.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance23;
            this.lblDate.DbField = null;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(577, 12);
            this.lblDate.Name = "lblDate";
            this.lblDate.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDate.Size = new System.Drawing.Size(90, 25);
            this.lblDate.TabIndex = 60;
            this.lblDate.Text = "라벨 발행일";
            // 
            // sLabel2
            // 
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Center";
            appearance5.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance5;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(796, 11);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(80, 25);
            this.sLabel2.TabIndex = 61;
            this.sLabel2.Text = "~";
            // 
            // lblCustCode
            // 
            appearance22.FontData.BoldAsString = "False";
            appearance22.FontData.UnderlineAsString = "False";
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.TextHAlignAsString = "Right";
            appearance22.TextVAlignAsString = "Middle";
            this.lblCustCode.Appearance = appearance22;
            this.lblCustCode.DbField = null;
            this.lblCustCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCustCode.Location = new System.Drawing.Point(51, 48);
            this.lblCustCode.Name = "lblCustCode";
            this.lblCustCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblCustCode.Size = new System.Drawing.Size(90, 25);
            this.lblCustCode.TabIndex = 64;
            this.lblCustCode.Text = "업체";
            // 
            // txtLOTNO_H
            // 
            this.txtLOTNO_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtLOTNO_H.Location = new System.Drawing.Point(672, 48);
            this.txtLOTNO_H.Name = "txtLOTNO_H";
            this.txtLOTNO_H.Size = new System.Drawing.Size(329, 25);
            this.txtLOTNO_H.TabIndex = 5;
            // 
            // lblLotNo
            // 
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.lblLotNo.Appearance = appearance17;
            this.lblLotNo.DbField = null;
            this.lblLotNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLotNo.Location = new System.Drawing.Point(577, 48);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblLotNo.Size = new System.Drawing.Size(90, 25);
            this.lblLotNo.TabIndex = 71;
            this.lblLotNo.Text = "LOT No.";
            // 
            // lblItemName
            // 
            appearance21.FontData.BoldAsString = "False";
            appearance21.FontData.UnderlineAsString = "False";
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Right";
            appearance21.TextVAlignAsString = "Middle";
            this.lblItemName.Appearance = appearance21;
            this.lblItemName.DbField = null;
            this.lblItemName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemName.Location = new System.Drawing.Point(51, 84);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemName.Size = new System.Drawing.Size(90, 25);
            this.lblItemName.TabIndex = 68;
            this.lblItemName.Text = "품목";
            // 
            // btnMM0010
            // 
            this.btnMM0010.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnMM0010.Location = new System.Drawing.Point(857, 82);
            this.btnMM0010.Name = "btnMM0010";
            this.btnMM0010.Size = new System.Drawing.Size(145, 27);
            this.btnMM0010.TabIndex = 9;
            this.btnMM0010.Text = "재발행";
            this.btnMM0010.UseVisualStyleBackColor = true;
            this.btnMM0010.Click += new System.EventHandler(this.btnMM0010_Click);
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
            appearance76.BackColor = System.Drawing.SystemColors.Window;
            appearance76.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance76;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance78.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance78.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance78.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance78.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance78;
            appearance79.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance79;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance80.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance80.BackColor2 = System.Drawing.SystemColors.Control;
            appearance80.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance80.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance80;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance81.BackColor = System.Drawing.SystemColors.Window;
            appearance81.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance81;
            appearance82.BackColor = System.Drawing.SystemColors.Highlight;
            appearance82.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance82;
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
            appearance83.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance83;
            appearance84.BorderColor = System.Drawing.Color.Silver;
            appearance84.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance84;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance85.BackColor = System.Drawing.SystemColors.Control;
            appearance85.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance85.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance85.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance85.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance85;
            appearance86.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance86;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance87.BackColor = System.Drawing.SystemColors.Window;
            appearance87.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance87;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance92.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance92;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1118, 687);
            this.grid1.TabIndex = 10;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblPlantCode
            // 
            appearance32.FontData.BoldAsString = "False";
            appearance32.FontData.UnderlineAsString = "False";
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.TextHAlignAsString = "Right";
            appearance32.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance32;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(51, 12);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(90, 25);
            this.lblPlantCode.TabIndex = 73;
            this.lblPlantCode.Text = "사업장";
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 11);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(145, 27);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // chkLotno_H
            // 
            this.chkLotno_H.Location = new System.Drawing.Point(672, 86);
            this.chkLotno_H.Name = "chkLotno_H";
            this.chkLotno_H.Size = new System.Drawing.Size(99, 20);
            this.chkLotno_H.TabIndex = 8;
            this.chkLotno_H.Text = "LOT No.";
            // 
            // lblChkLotNo
            // 
            appearance44.BorderColor = System.Drawing.Color.Black;
            appearance44.FontData.BoldAsString = "False";
            appearance44.FontData.UnderlineAsString = "False";
            appearance44.ForeColor = System.Drawing.Color.Black;
            appearance44.TextHAlignAsString = "Right";
            appearance44.TextVAlignAsString = "Middle";
            this.lblChkLotNo.Appearance = appearance44;
            this.lblChkLotNo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblChkLotNo.DbField = null;
            this.lblChkLotNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblChkLotNo.Location = new System.Drawing.Point(577, 84);
            this.lblChkLotNo.Name = "lblChkLotNo";
            this.lblChkLotNo.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblChkLotNo.Size = new System.Drawing.Size(90, 25);
            this.lblChkLotNo.TabIndex = 250;
            this.lblChkLotNo.Text = "조회조건";
            // 
            // txtItemName
            // 
            appearance7.FontData.BoldAsString = "False";
            appearance7.FontData.UnderlineAsString = "False";
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.txtItemName.Appearance = appearance7;
            this.txtItemName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemName.Location = new System.Drawing.Point(291, 83);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtItemName.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtItemName.Size = new System.Drawing.Size(200, 25);
            this.txtItemName.TabIndex = 7;
            // 
            // txtItemCode
            // 
            appearance8.FontData.BoldAsString = "False";
            appearance8.FontData.Name = "맑은 고딕";
            appearance8.FontData.SizeInPoints = 10F;
            appearance8.FontData.UnderlineAsString = "False";
            appearance8.ForeColor = System.Drawing.Color.Black;
            this.txtItemCode.Appearance = appearance8;
            this.txtItemCode.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txtItemCode.btnWidth = 26;
            this.txtItemCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemCode.Location = new System.Drawing.Point(146, 82);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtItemCode.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtItemCode.Size = new System.Drawing.Size(145, 27);
            this.txtItemCode.TabIndex = 6;
            this.txtItemCode.ButtonClick += new System.EventHandler(this.txtItemCode_ButtonClick);
            this.txtItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemCode_KeyPress);
            // 
            // txtCustName
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.txtCustName.Appearance = appearance4;
            this.txtCustName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCustName.Location = new System.Drawing.Point(291, 48);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.txtCustName.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtCustName.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtCustName.Size = new System.Drawing.Size(200, 25);
            this.txtCustName.TabIndex = 4;
            // 
            // txtCustCode
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.Name = "맑은 고딕";
            appearance2.FontData.SizeInPoints = 10F;
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.txtCustCode.Appearance = appearance2;
            this.txtCustCode.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txtCustCode.btnWidth = 26;
            this.txtCustCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCustCode.Location = new System.Drawing.Point(146, 47);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtCustCode.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtCustCode.Size = new System.Drawing.Size(145, 27);
            this.txtCustCode.TabIndex = 3;
            this.txtCustCode.ButtonClick += new System.EventHandler(this.txtCustCode_ButtonClick);
            this.txtCustCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustCode_KeyPress);
            // 
            // QM1200Y
            // 
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Name = "QM1200Y";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "재사용 불량 라벨 발행";
            this.Load += new System.EventHandler(this.QM1200Y_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanIndate2_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanIndate1_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLotno_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.Grid grid1;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboPlanIndate2_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboPlanIndate1_H;
        private Control.SLabel lblDate;
        private Control.SLabel sLabel2;
        private Control.SLabel lblCustCode;
        private System.Windows.Forms.TextBox txtLOTNO_H;
        private Control.SLabel lblLotNo;
        private Control.SLabel lblItemName;
        private System.Windows.Forms.Button btnMM0010;
        private Control.SLabel lblPlantCode;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkLotno_H;
        private Control.SLabel lblChkLotNo;
        private System.IO.Ports.SerialPort serialPort1;
        private Control.STextBox txtItemName;
        private Control.SBtnTextEditor txtItemCode;
        private Control.STextBox txtCustName;
        private Control.SBtnTextEditor txtCustCode;
    }
}

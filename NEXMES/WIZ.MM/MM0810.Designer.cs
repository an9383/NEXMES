namespace WIZ.MM
{
    partial class MM0810
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
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.lblLotNo = new WIZ.Control.SLabel();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtTotInspQty = new System.Windows.Forms.TextBox();
            this.lblTotInspQty = new WIZ.Control.SLabel();
            this.lblItemName = new WIZ.Control.SLabel();
            this.cboEndDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cboStartDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblInspResult = new Infragistics.Win.Misc.UltraLabel();
            this.lblInspDate = new Infragistics.Win.Misc.UltraLabel();
            this.txtTSampleQty = new System.Windows.Forms.TextBox();
            this.lblTSampleQty = new WIZ.Control.SLabel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.sLabel2 = new WIZ.Control.SLabel();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboInspResult_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.grid1 = new WIZ.Control.Grid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInspResult_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboInspResult_H);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.BtnClose);
            this.gbxHeader.Controls.Add(this.BtnSearch);
            this.gbxHeader.Controls.Add(this.BtnSave);
            this.gbxHeader.Controls.Add(this.txtTSampleQty);
            this.gbxHeader.Controls.Add(this.sLabel2);
            this.gbxHeader.Controls.Add(this.txtLotNo);
            this.gbxHeader.Controls.Add(this.cboEndDate);
            this.gbxHeader.Controls.Add(this.lblLotNo);
            this.gbxHeader.Controls.Add(this.cboStartDate);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Controls.Add(this.lblInspResult);
            this.gbxHeader.Controls.Add(this.txtItemCode);
            this.gbxHeader.Controls.Add(this.txtItemName);
            this.gbxHeader.Controls.Add(this.lblInspDate);
            this.gbxHeader.Controls.Add(this.txtTotInspQty);
            this.gbxHeader.Controls.Add(this.lblTotInspQty);
            this.gbxHeader.Controls.Add(this.lblItemName);
            this.gbxHeader.Controls.Add(this.lblTSampleQty);
            this.gbxHeader.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.gbxHeader.Size = new System.Drawing.Size(1234, 90);
            this.gbxHeader.Controls.SetChildIndex(this.lblTSampleQty, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblItemName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblTotInspQty, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtTotInspQty, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblInspDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblInspResult, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboStartDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblLotNo, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboEndDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtLotNo, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel2, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtTSampleQty, 0);
            this.gbxHeader.Controls.SetChildIndex(this.BtnSave, 0);
            this.gbxHeader.Controls.SetChildIndex(this.BtnSearch, 0);
            this.gbxHeader.Controls.SetChildIndex(this.BtnClose, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboInspResult_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 90);
            this.gbxBody.Size = new System.Drawing.Size(1234, 656);
            // 
            // txtLotNo
            // 
            this.txtLotNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtLotNo.Location = new System.Drawing.Point(146, 51);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(135, 25);
            this.txtLotNo.TabIndex = 6;
            this.txtLotNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLotNo
            // 
            appearance20.FontData.BoldAsString = "False";
            appearance20.FontData.UnderlineAsString = "False";
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextHAlignAsString = "Right";
            appearance20.TextVAlignAsString = "Middle";
            this.lblLotNo.Appearance = appearance20;
            this.lblLotNo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblLotNo.DbField = null;
            this.lblLotNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLotNo.Location = new System.Drawing.Point(51, 51);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblLotNo.Size = new System.Drawing.Size(90, 25);
            this.lblLotNo.TabIndex = 111;
            this.lblLotNo.Text = "Lot No";
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
            this.lblPlantCode.Location = new System.Drawing.Point(51, 15);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(90, 25);
            this.lblPlantCode.TabIndex = 108;
            this.lblPlantCode.Text = "사업장";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemCode.Location = new System.Drawing.Point(396, 14);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(114, 25);
            this.txtItemCode.TabIndex = 1;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtItemName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemName.Location = new System.Drawing.Point(510, 14);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(178, 25);
            this.txtItemName.TabIndex = 2;
            // 
            // txtTotInspQty
            // 
            this.txtTotInspQty.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtTotInspQty.Location = new System.Drawing.Point(396, 51);
            this.txtTotInspQty.Name = "txtTotInspQty";
            this.txtTotInspQty.Size = new System.Drawing.Size(114, 25);
            this.txtTotInspQty.TabIndex = 7;
            // 
            // lblTotInspQty
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lblTotInspQty.Appearance = appearance3;
            this.lblTotInspQty.DbField = "cboUseFlag";
            this.lblTotInspQty.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotInspQty.Location = new System.Drawing.Point(301, 51);
            this.lblTotInspQty.Name = "lblTotInspQty";
            this.lblTotInspQty.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblTotInspQty.Size = new System.Drawing.Size(90, 25);
            this.lblTotInspQty.TabIndex = 103;
            this.lblTotInspQty.Text = "검사대기수";
            // 
            // lblItemName
            // 
            appearance18.FontData.BoldAsString = "False";
            appearance18.FontData.UnderlineAsString = "False";
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextHAlignAsString = "Right";
            appearance18.TextVAlignAsString = "Middle";
            this.lblItemName.Appearance = appearance18;
            this.lblItemName.DbField = "cboUseFlag";
            this.lblItemName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemName.Location = new System.Drawing.Point(301, 15);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemName.Size = new System.Drawing.Size(90, 25);
            this.lblItemName.TabIndex = 102;
            this.lblItemName.Text = "품목";
            // 
            // cboEndDate
            // 
            this.cboEndDate.DateButtons.Add(dateButton1);
            this.cboEndDate.Location = new System.Drawing.Point(926, 16);
            this.cboEndDate.Name = "cboEndDate";
            this.cboEndDate.NonAutoSizeHeight = 26;
            this.cboEndDate.Size = new System.Drawing.Size(120, 24);
            this.cboEndDate.TabIndex = 5;
            // 
            // cboStartDate
            // 
            this.cboStartDate.DateButtons.Add(dateButton2);
            this.cboStartDate.Location = new System.Drawing.Point(788, 15);
            this.cboStartDate.Name = "cboStartDate";
            this.cboStartDate.NonAutoSizeHeight = 26;
            this.cboStartDate.Size = new System.Drawing.Size(120, 24);
            this.cboStartDate.TabIndex = 3;
            // 
            // lblInspResult
            // 
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblInspResult.Appearance = appearance2;
            this.lblInspResult.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInspResult.Location = new System.Drawing.Point(693, 51);
            this.lblInspResult.Name = "lblInspResult";
            this.lblInspResult.Size = new System.Drawing.Size(90, 25);
            this.lblInspResult.TabIndex = 112;
            this.lblInspResult.Text = "판정";
            // 
            // lblInspDate
            // 
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblInspDate.Appearance = appearance1;
            this.lblInspDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInspDate.Location = new System.Drawing.Point(693, 15);
            this.lblInspDate.Name = "lblInspDate";
            this.lblInspDate.Size = new System.Drawing.Size(90, 25);
            this.lblInspDate.TabIndex = 113;
            this.lblInspDate.Text = "대기일";
            // 
            // txtTSampleQty
            // 
            this.txtTSampleQty.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtTSampleQty.Location = new System.Drawing.Point(574, 52);
            this.txtTSampleQty.Name = "txtTSampleQty";
            this.txtTSampleQty.Size = new System.Drawing.Size(114, 25);
            this.txtTSampleQty.TabIndex = 8;
            // 
            // lblTSampleQty
            // 
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.lblTSampleQty.Appearance = appearance17;
            this.lblTSampleQty.DbField = "cboUseFlag";
            this.lblTSampleQty.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTSampleQty.Location = new System.Drawing.Point(510, 51);
            this.lblTSampleQty.Name = "lblTSampleQty";
            this.lblTSampleQty.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblTSampleQty.Size = new System.Drawing.Size(59, 27);
            this.lblTSampleQty.TabIndex = 117;
            this.lblTSampleQty.Text = "샘플수";
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnSave.Location = new System.Drawing.Point(1117, 19);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(50, 55);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "실적등록";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnClose.Location = new System.Drawing.Point(1170, 19);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 55);
            this.BtnClose.TabIndex = 11;
            this.BtnClose.Text = "닫기";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // sLabel2
            // 
            appearance16.FontData.BoldAsString = "False";
            appearance16.FontData.UnderlineAsString = "False";
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance16;
            this.sLabel2.DbField = "cboUseFlag";
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(910, 15);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(13, 27);
            this.sLabel2.TabIndex = 117;
            this.sLabel2.Text = "~";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnSearch.Location = new System.Drawing.Point(1064, 20);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(50, 55);
            this.BtnSearch.TabIndex = 9;
            this.BtnSearch.Text = "조회";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 13);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(135, 27);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // cboInspResult_H
            // 
            this.cboInspResult_H.Location = new System.Drawing.Point(788, 50);
            this.cboInspResult_H.Name = "cboInspResult_H";
            this.cboInspResult_H.Size = new System.Drawing.Size(120, 27);
            this.cboInspResult_H.TabIndex = 8;
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
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance4;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance5;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance7;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BackColor2 = System.Drawing.SystemColors.Control;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance12;
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
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance11;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Center";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance13;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1222, 644);
            this.grid1.TabIndex = 1;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // MM0810
            // 
            this.ClientSize = new System.Drawing.Size(1234, 746);
            this.Name = "MM0810";
            this.Text = "수입검사실적등록";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MM0810_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInspResult_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLotNo;
        private Control.SLabel lblLotNo;
        private Control.SLabel lblPlantCode;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtTotInspQty;
        private Control.SLabel lblTotInspQty;
        private Control.SLabel lblItemName;
        private System.Windows.Forms.TextBox txtTSampleQty;
        private Control.SLabel lblTSampleQty;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboEndDate;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboStartDate;
        private Infragistics.Win.Misc.UltraLabel lblInspResult;
        private Infragistics.Win.Misc.UltraLabel lblInspDate;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnClose;
        private Control.SLabel sLabel2;
        private System.Windows.Forms.Button BtnSearch;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboInspResult_H;
        private Control.Grid grid1;
    }
}

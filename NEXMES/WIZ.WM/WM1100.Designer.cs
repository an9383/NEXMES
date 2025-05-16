namespace WIZ.WM
{
    partial class WM1100
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
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.lblPoNo = new WIZ.Control.SLabel();
            this.sLabel3 = new WIZ.Control.SLabel();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new WIZ.Control.SLabel();
            this.cboEndDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cboStartDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblInspResult = new Infragistics.Win.Misc.UltraLabel();
            this.lblInspDate = new Infragistics.Win.Misc.UltraLabel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.sLabel2 = new WIZ.Control.SLabel();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.lblCustCode = new WIZ.Control.SLabel();
            this.txtTotInspQty = new System.Windows.Forms.TextBox();
            this.sLabel1 = new WIZ.Control.SLabel();
            this.txtTSampleQty = new System.Windows.Forms.TextBox();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.cboInspResult_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInspResult_H)).BeginInit();
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
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.txtLotNo);
            this.gbxHeader.Controls.Add(this.cboEndDate);
            this.gbxHeader.Controls.Add(this.lblPoNo);
            this.gbxHeader.Controls.Add(this.cboStartDate);
            this.gbxHeader.Controls.Add(this.sLabel3);
            this.gbxHeader.Controls.Add(this.lblInspResult);
            this.gbxHeader.Controls.Add(this.txtItemCode);
            this.gbxHeader.Controls.Add(this.txtItemName);
            this.gbxHeader.Controls.Add(this.lblInspDate);
            this.gbxHeader.Controls.Add(this.txtTotInspQty);
            this.gbxHeader.Controls.Add(this.lblCustCode);
            this.gbxHeader.Controls.Add(this.lblItemName);
            this.gbxHeader.Controls.SetChildIndex(this.lblItemName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblCustCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtTotInspQty, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblInspDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblInspResult, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel3, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboStartDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPoNo, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboEndDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtLotNo, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel1, 0);
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
            this.gbxBody.Size = new System.Drawing.Size(1136, 709);
            // 
            // txtLotNo
            // 
            this.txtLotNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtLotNo.Location = new System.Drawing.Point(93, 38);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(135, 25);
            this.txtLotNo.TabIndex = 5;
            this.txtLotNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPoNo
            // 
            appearance20.TextHAlignAsString = "Right";
            appearance20.TextVAlignAsString = "Middle";
            this.lblPoNo.Appearance = appearance20;
            this.lblPoNo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPoNo.DbField = null;
            this.lblPoNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPoNo.Location = new System.Drawing.Point(22, 36);
            this.lblPoNo.Name = "lblPoNo";
            this.lblPoNo.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPoNo.Size = new System.Drawing.Size(65, 25);
            this.lblPoNo.TabIndex = 111;
            this.lblPoNo.Text = "Lot No";
            // 
            // sLabel3
            // 
            appearance32.TextHAlignAsString = "Right";
            appearance32.TextVAlignAsString = "Middle";
            this.sLabel3.Appearance = appearance32;
            this.sLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel3.DbField = null;
            this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel3.Location = new System.Drawing.Point(7, 7);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(80, 25);
            this.sLabel3.TabIndex = 108;
            this.sLabel3.Text = "사업장";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemCode.Location = new System.Drawing.Point(321, 7);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(114, 25);
            this.txtItemCode.TabIndex = 1;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtItemName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemName.Location = new System.Drawing.Point(441, 8);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(178, 25);
            this.txtItemName.TabIndex = 2;
            // 
            // lblItemName
            // 
            appearance19.TextHAlignAsString = "Right";
            appearance19.TextVAlignAsString = "Middle";
            this.lblItemName.Appearance = appearance19;
            this.lblItemName.DbField = "cboUseFlag";
            this.lblItemName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemName.Location = new System.Drawing.Point(265, 5);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemName.Size = new System.Drawing.Size(47, 27);
            this.lblItemName.TabIndex = 102;
            this.lblItemName.Text = "품목";
            // 
            // cboEndDate
            // 
            this.cboEndDate.DateButtons.Add(dateButton1);
            this.cboEndDate.Location = new System.Drawing.Point(853, 9);
            this.cboEndDate.Name = "cboEndDate";
            this.cboEndDate.NonAutoSizeHeight = 26;
            this.cboEndDate.Size = new System.Drawing.Size(120, 26);
            this.cboEndDate.TabIndex = 4;
            // 
            // cboStartDate
            // 
            this.cboStartDate.DateButtons.Add(dateButton2);
            this.cboStartDate.Location = new System.Drawing.Point(710, 9);
            this.cboStartDate.Name = "cboStartDate";
            this.cboStartDate.NonAutoSizeHeight = 26;
            this.cboStartDate.Size = new System.Drawing.Size(120, 26);
            this.cboStartDate.TabIndex = 3;
            // 
            // lblInspResult
            // 
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.lblInspResult.Appearance = appearance16;
            this.lblInspResult.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInspResult.Location = new System.Drawing.Point(625, 36);
            this.lblInspResult.Name = "lblInspResult";
            this.lblInspResult.Size = new System.Drawing.Size(79, 27);
            this.lblInspResult.TabIndex = 112;
            this.lblInspResult.Text = "판정";
            // 
            // lblInspDate
            // 
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.lblInspDate.Appearance = appearance17;
            this.lblInspDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInspDate.Location = new System.Drawing.Point(625, 8);
            this.lblInspDate.Name = "lblInspDate";
            this.lblInspDate.Size = new System.Drawing.Size(79, 27);
            this.lblInspDate.TabIndex = 113;
            this.lblInspDate.Text = "대기일";
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnSave.Location = new System.Drawing.Point(1031, 6);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(50, 55);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "등록";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnClose.Location = new System.Drawing.Point(1084, 6);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 55);
            this.BtnClose.TabIndex = 11;
            this.BtnClose.Text = "닫기";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // sLabel2
            // 
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance15;
            this.sLabel2.DbField = "cboUseFlag";
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(836, 8);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(13, 27);
            this.sLabel2.TabIndex = 117;
            this.sLabel2.Text = "~";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnSearch.Location = new System.Drawing.Point(978, 6);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(50, 55);
            this.BtnSearch.TabIndex = 9;
            this.BtnSearch.Text = "조회";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // lblCustCode
            // 
            appearance18.TextHAlignAsString = "Right";
            appearance18.TextVAlignAsString = "Middle";
            this.lblCustCode.Appearance = appearance18;
            this.lblCustCode.DbField = "cboUseFlag";
            this.lblCustCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCustCode.Location = new System.Drawing.Point(234, 36);
            this.lblCustCode.Name = "lblCustCode";
            this.lblCustCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblCustCode.Size = new System.Drawing.Size(78, 27);
            this.lblCustCode.TabIndex = 103;
            this.lblCustCode.Text = "검사대기수";
            this.lblCustCode.Visible = false;
            // 
            // txtTotInspQty
            // 
            this.txtTotInspQty.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtTotInspQty.Location = new System.Drawing.Point(321, 38);
            this.txtTotInspQty.Name = "txtTotInspQty";
            this.txtTotInspQty.Size = new System.Drawing.Size(114, 25);
            this.txtTotInspQty.TabIndex = 6;
            this.txtTotInspQty.Visible = false;
            // 
            // sLabel1
            // 
            appearance14.TextHAlignAsString = "Right";
            appearance14.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance14;
            this.sLabel1.DbField = "cboUseFlag";
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(437, 36);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(59, 27);
            this.sLabel1.TabIndex = 117;
            this.sLabel1.Text = "샘플수";
            this.sLabel1.Visible = false;
            // 
            // txtTSampleQty
            // 
            this.txtTSampleQty.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtTSampleQty.Location = new System.Drawing.Point(505, 38);
            this.txtTSampleQty.Name = "txtTSampleQty";
            this.txtTSampleQty.Size = new System.Drawing.Size(114, 25);
            this.txtTSampleQty.TabIndex = 7;
            this.txtTSampleQty.Visible = false;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(93, 6);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(135, 27);
            this.cboPlantCode_H.TabIndex = 0;
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
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance1;
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
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance6;
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
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance8;
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
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance11;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1124, 697);
            this.grid1.TabIndex = 5;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // cboInspResult_H
            // 
            this.cboInspResult_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboInspResult_H.Location = new System.Drawing.Point(710, 38);
            this.cboInspResult_H.Name = "cboInspResult_H";
            this.cboInspResult_H.Size = new System.Drawing.Size(120, 27);
            this.cboInspResult_H.TabIndex = 8;
            // 
            // WM1100
            // 
            this.ClientSize = new System.Drawing.Size(1136, 778);
            this.Name = "WM1100";
            this.Load += new System.EventHandler(this.WM1100_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInspResult_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLotNo;
        private Control.SLabel lblPoNo;
        private Control.SLabel sLabel3;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.TextBox txtItemName;
        private Control.SLabel lblItemName;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboEndDate;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboStartDate;
        private Infragistics.Win.Misc.UltraLabel lblInspResult;
        private Infragistics.Win.Misc.UltraLabel lblInspDate;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnClose;
        private Control.SLabel sLabel2;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox txtTSampleQty;
        private Control.SLabel sLabel1;
        private System.Windows.Forms.TextBox txtTotInspQty;
        private Control.SLabel lblCustCode;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Control.Grid grid1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboInspResult_H;
    }
}

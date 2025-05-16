namespace WIZ.PP
{
    partial class PP6300
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
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.txtInspCode = new System.Windows.Forms.TextBox();
            this.txtInspName = new System.Windows.Forms.TextBox();
            this.lblInspCode = new WIZ.Control.SLabel();
            this.txtWorkCenterCode = new System.Windows.Forms.TextBox();
            this.txtWorkCenterName = new System.Windows.Forms.TextBox();
            this.lblWorkCenterCode = new WIZ.Control.SLabel();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.lblDate = new WIZ.Control.SLabel();
            this.sLabel1 = new WIZ.Control.SLabel();
            this.lblDayNight = new WIZ.Control.SLabel();
            this.lblResult = new WIZ.Control.SLabel();
            this.txtMachCode = new System.Windows.Forms.TextBox();
            this.txtMachName = new System.Windows.Forms.TextBox();
            this.lblMachCode = new WIZ.Control.SLabel();
            this.CboStartdate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.CboEnddate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblQType = new WIZ.Control.SLabel();
            this.txtWorkerID = new System.Windows.Forms.TextBox();
            this.lblWorkerID = new WIZ.Control.SLabel();
            this.txtWorkerName = new System.Windows.Forms.TextBox();
            this.cboResult = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboDayNight = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboQType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartdate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEnddate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDayNight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboResult);
            this.gbxHeader.Controls.Add(this.cboDayNight);
            this.gbxHeader.Controls.Add(this.cboQType);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.txtWorkerName);
            this.gbxHeader.Controls.Add(this.txtWorkerID);
            this.gbxHeader.Controls.Add(this.lblWorkerID);
            this.gbxHeader.Controls.Add(this.lblQType);
            this.gbxHeader.Controls.Add(this.CboStartdate_H);
            this.gbxHeader.Controls.Add(this.CboEnddate_H);
            this.gbxHeader.Controls.Add(this.txtMachCode);
            this.gbxHeader.Controls.Add(this.txtMachName);
            this.gbxHeader.Controls.Add(this.lblMachCode);
            this.gbxHeader.Controls.Add(this.lblResult);
            this.gbxHeader.Controls.Add(this.lblDayNight);
            this.gbxHeader.Controls.Add(this.lblDate);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.txtInspCode);
            this.gbxHeader.Controls.Add(this.txtInspName);
            this.gbxHeader.Controls.Add(this.lblInspCode);
            this.gbxHeader.Controls.Add(this.txtWorkCenterCode);
            this.gbxHeader.Controls.Add(this.txtWorkCenterName);
            this.gbxHeader.Controls.Add(this.lblWorkCenterCode);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 155);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblWorkCenterCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkCenterName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkCenterCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblInspCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtInspName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtInspCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblDayNight, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblResult, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblMachCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtMachName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtMachCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboEnddate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboStartdate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblQType, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblWorkerID, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkerID, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkerName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboQType, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboDayNight, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboResult, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 155);
            this.gbxBody.Size = new System.Drawing.Size(1136, 670);
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
            appearance25.BackColor = System.Drawing.SystemColors.Window;
            appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance25;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance1.BackColor2 = System.Drawing.SystemColors.Control;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance1;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance5;
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
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance8;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance10;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1124, 658);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.AfterEnterEditMode += new System.EventHandler(this.grid1_AfterEnterEditMode);
            this.grid1.AfterExitEditMode += new System.EventHandler(this.grid1_AfterExitEditMode);
            this.grid1.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(this.grid1_ClickCell);
            // 
            // txtInspCode
            // 
            this.txtInspCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtInspCode.Location = new System.Drawing.Point(654, 84);
            this.txtInspCode.Name = "txtInspCode";
            this.txtInspCode.Size = new System.Drawing.Size(119, 25);
            this.txtInspCode.TabIndex = 9;
            // 
            // txtInspName
            // 
            this.txtInspName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtInspName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtInspName.Location = new System.Drawing.Point(779, 84);
            this.txtInspName.Name = "txtInspName";
            this.txtInspName.Size = new System.Drawing.Size(232, 25);
            this.txtInspName.TabIndex = 10;
            // 
            // lblInspCode
            // 
            appearance86.FontData.BoldAsString = "False";
            appearance86.FontData.UnderlineAsString = "False";
            appearance86.ForeColor = System.Drawing.Color.Black;
            appearance86.TextHAlignAsString = "Right";
            appearance86.TextVAlignAsString = "Middle";
            this.lblInspCode.Appearance = appearance86;
            this.lblInspCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblInspCode.DbField = null;
            this.lblInspCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInspCode.Location = new System.Drawing.Point(559, 84);
            this.lblInspCode.Name = "lblInspCode";
            this.lblInspCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblInspCode.Size = new System.Drawing.Size(90, 25);
            this.lblInspCode.TabIndex = 211;
            this.lblInspCode.Text = "검사항목";
            // 
            // txtWorkCenterCode
            // 
            this.txtWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkCenterCode.Location = new System.Drawing.Point(146, 48);
            this.txtWorkCenterCode.Name = "txtWorkCenterCode";
            this.txtWorkCenterCode.Size = new System.Drawing.Size(119, 25);
            this.txtWorkCenterCode.TabIndex = 3;
            // 
            // txtWorkCenterName
            // 
            this.txtWorkCenterName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtWorkCenterName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkCenterName.Location = new System.Drawing.Point(265, 48);
            this.txtWorkCenterName.MaxLength = 30;
            this.txtWorkCenterName.Name = "txtWorkCenterName";
            this.txtWorkCenterName.Size = new System.Drawing.Size(199, 25);
            this.txtWorkCenterName.TabIndex = 4;
            // 
            // lblWorkCenterCode
            // 
            appearance14.FontData.BoldAsString = "False";
            appearance14.FontData.UnderlineAsString = "False";
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Right";
            appearance14.TextVAlignAsString = "Middle";
            this.lblWorkCenterCode.Appearance = appearance14;
            this.lblWorkCenterCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWorkCenterCode.DbField = null;
            this.lblWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkCenterCode.Location = new System.Drawing.Point(51, 48);
            this.lblWorkCenterCode.Name = "lblWorkCenterCode";
            this.lblWorkCenterCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWorkCenterCode.Size = new System.Drawing.Size(90, 25);
            this.lblWorkCenterCode.TabIndex = 207;
            this.lblWorkCenterCode.Text = "작업장";
            // 
            // lblPlantCode
            // 
            appearance85.FontData.BoldAsString = "False";
            appearance85.FontData.UnderlineAsString = "False";
            appearance85.ForeColor = System.Drawing.Color.Black;
            appearance85.TextHAlignAsString = "Right";
            appearance85.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance85;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(51, 12);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(90, 25);
            this.lblPlantCode.TabIndex = 204;
            this.lblPlantCode.Text = "사업장";
            // 
            // lblDate
            // 
            appearance47.FontData.BoldAsString = "False";
            appearance47.FontData.UnderlineAsString = "False";
            appearance47.ForeColor = System.Drawing.Color.Black;
            appearance47.TextHAlignAsString = "Right";
            appearance47.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance47;
            this.lblDate.DbField = "cboUseFlag";
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(559, 12);
            this.lblDate.Name = "lblDate";
            this.lblDate.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDate.Size = new System.Drawing.Size(90, 25);
            this.lblDate.TabIndex = 214;
            this.lblDate.Text = "작업일자";
            // 
            // sLabel1
            // 
            appearance20.FontData.BoldAsString = "False";
            appearance20.FontData.UnderlineAsString = "False";
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextHAlignAsString = "Center";
            appearance20.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance20;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(828, 11);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(16, 23);
            this.sLabel1.TabIndex = 217;
            this.sLabel1.Text = "~";
            // 
            // lblDayNight
            // 
            appearance15.FontData.BoldAsString = "False";
            appearance15.FontData.UnderlineAsString = "False";
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.lblDayNight.Appearance = appearance15;
            this.lblDayNight.DbField = "cboUseFlag";
            this.lblDayNight.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDayNight.Location = new System.Drawing.Point(559, 48);
            this.lblDayNight.Name = "lblDayNight";
            this.lblDayNight.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDayNight.Size = new System.Drawing.Size(90, 25);
            this.lblDayNight.TabIndex = 221;
            this.lblDayNight.Text = "주/야 구분";
            // 
            // lblResult
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lblResult.Appearance = appearance3;
            this.lblResult.DbField = "cboUseFlag";
            this.lblResult.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblResult.Location = new System.Drawing.Point(807, 48);
            this.lblResult.Name = "lblResult";
            this.lblResult.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblResult.Size = new System.Drawing.Size(55, 27);
            this.lblResult.TabIndex = 223;
            this.lblResult.Text = "검사결과";
            // 
            // txtMachCode
            // 
            this.txtMachCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtMachCode.Location = new System.Drawing.Point(146, 84);
            this.txtMachCode.Name = "txtMachCode";
            this.txtMachCode.Size = new System.Drawing.Size(119, 25);
            this.txtMachCode.TabIndex = 7;
            // 
            // txtMachName
            // 
            this.txtMachName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtMachName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtMachName.Location = new System.Drawing.Point(265, 84);
            this.txtMachName.Name = "txtMachName";
            this.txtMachName.Size = new System.Drawing.Size(199, 25);
            this.txtMachName.TabIndex = 8;
            // 
            // lblMachCode
            // 
            appearance16.FontData.BoldAsString = "False";
            appearance16.FontData.UnderlineAsString = "False";
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.lblMachCode.Appearance = appearance16;
            this.lblMachCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblMachCode.DbField = null;
            this.lblMachCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMachCode.Location = new System.Drawing.Point(51, 84);
            this.lblMachCode.Name = "lblMachCode";
            this.lblMachCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblMachCode.Size = new System.Drawing.Size(90, 25);
            this.lblMachCode.TabIndex = 226;
            this.lblMachCode.Text = "설비";
            // 
            // CboStartdate_H
            // 
            this.CboStartdate_H.DateButtons.Add(dateButton1);
            this.CboStartdate_H.Location = new System.Drawing.Point(654, 10);
            this.CboStartdate_H.Name = "CboStartdate_H";
            this.CboStartdate_H.NonAutoSizeHeight = 26;
            this.CboStartdate_H.Size = new System.Drawing.Size(120, 26);
            this.CboStartdate_H.TabIndex = 1;
            // 
            // CboEnddate_H
            // 
            this.CboEnddate_H.DateButtons.Add(dateButton2);
            this.CboEnddate_H.Location = new System.Drawing.Point(891, 10);
            this.CboEnddate_H.Name = "CboEnddate_H";
            this.CboEnddate_H.NonAutoSizeHeight = 26;
            this.CboEnddate_H.Size = new System.Drawing.Size(120, 26);
            this.CboEnddate_H.TabIndex = 2;
            // 
            // lblQType
            // 
            appearance31.FontData.BoldAsString = "False";
            appearance31.FontData.UnderlineAsString = "False";
            appearance31.ForeColor = System.Drawing.Color.Black;
            appearance31.TextHAlignAsString = "Right";
            appearance31.TextVAlignAsString = "Middle";
            this.lblQType.Appearance = appearance31;
            this.lblQType.DbField = "cboUseFlag";
            this.lblQType.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblQType.Location = new System.Drawing.Point(51, 120);
            this.lblQType.Name = "lblQType";
            this.lblQType.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblQType.Size = new System.Drawing.Size(90, 25);
            this.lblQType.TabIndex = 232;
            this.lblQType.Text = "조회구분";
            // 
            // txtWorkerID
            // 
            this.txtWorkerID.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkerID.Location = new System.Drawing.Point(654, 119);
            this.txtWorkerID.Name = "txtWorkerID";
            this.txtWorkerID.Size = new System.Drawing.Size(119, 25);
            this.txtWorkerID.TabIndex = 12;
            // 
            // lblWorkerID
            // 
            appearance13.FontData.BoldAsString = "False";
            appearance13.FontData.UnderlineAsString = "False";
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Right";
            appearance13.TextVAlignAsString = "Middle";
            this.lblWorkerID.Appearance = appearance13;
            this.lblWorkerID.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWorkerID.DbField = null;
            this.lblWorkerID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkerID.Location = new System.Drawing.Point(559, 120);
            this.lblWorkerID.Name = "lblWorkerID";
            this.lblWorkerID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWorkerID.Size = new System.Drawing.Size(90, 25);
            this.lblWorkerID.TabIndex = 235;
            this.lblWorkerID.Text = "선택 작업자";
            // 
            // txtWorkerName
            // 
            this.txtWorkerName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtWorkerName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkerName.Location = new System.Drawing.Point(779, 119);
            this.txtWorkerName.Name = "txtWorkerName";
            this.txtWorkerName.Size = new System.Drawing.Size(232, 25);
            this.txtWorkerName.TabIndex = 13;
            // 
            // cboResult
            // 
            this.cboResult.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboResult.Location = new System.Drawing.Point(867, 48);
            this.cboResult.Name = "cboResult";
            this.cboResult.Size = new System.Drawing.Size(144, 27);
            this.cboResult.TabIndex = 6;
            // 
            // cboDayNight
            // 
            this.cboDayNight.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboDayNight.Location = new System.Drawing.Point(654, 48);
            this.cboDayNight.Name = "cboDayNight";
            this.cboDayNight.Size = new System.Drawing.Size(120, 27);
            this.cboDayNight.TabIndex = 5;
            // 
            // cboQType
            // 
            this.cboQType.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboQType.Location = new System.Drawing.Point(146, 118);
            this.cboQType.Name = "cboQType";
            this.cboQType.Size = new System.Drawing.Size(119, 27);
            this.cboQType.TabIndex = 11;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 11);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(119, 27);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // PP6300
            // 
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Name = "PP6300";
            this.Text = "일상점검 체크시트 조회";
            this.Load += new System.EventHandler(this.PP6300_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartdate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEnddate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDayNight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.Grid grid1;
        private System.Windows.Forms.TextBox txtInspCode;
        private System.Windows.Forms.TextBox txtInspName;
        private Control.SLabel lblInspCode;
        private System.Windows.Forms.TextBox txtWorkCenterCode;
        private System.Windows.Forms.TextBox txtWorkCenterName;
        private Control.SLabel lblWorkCenterCode;
        private Control.SLabel lblPlantCode;
        private Control.SLabel lblDate;
        private Control.SLabel sLabel1;
        private Control.SLabel lblDayNight;
        private Control.SLabel lblResult;
        private System.Windows.Forms.TextBox txtMachCode;
        private System.Windows.Forms.TextBox txtMachName;
        private Control.SLabel lblMachCode;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboStartdate_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboEnddate_H;
        private Control.SLabel lblQType;
        private System.Windows.Forms.TextBox txtWorkerID;
        private Control.SLabel lblWorkerID;
        private System.Windows.Forms.TextBox txtWorkerName;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboQType;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboDayNight;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboResult;
    }
}

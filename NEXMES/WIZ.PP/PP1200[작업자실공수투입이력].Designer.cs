namespace WIZ.PP
{
    partial class PP1200
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
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.txtWorkerID = new System.Windows.Forms.TextBox();
            this.txtWorkerName = new System.Windows.Forms.TextBox();
            this.lblWorkerID = new WIZ.Control.SLabel();
            this.txtLineCode = new System.Windows.Forms.TextBox();
            this.txtLineName = new System.Windows.Forms.TextBox();
            this.txtOPCode = new System.Windows.Forms.TextBox();
            this.txtOPName = new System.Windows.Forms.TextBox();
            this.txtWorkCenterCode = new System.Windows.Forms.TextBox();
            this.txtWorkCenterName = new System.Windows.Forms.TextBox();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.CboStartdate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.CboEnddate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.lblLineCode = new WIZ.Control.SLabel();
            this.lblOPCode = new WIZ.Control.SLabel();
            this.lblWorkCenterCode = new WIZ.Control.SLabel();
            this.lblDate = new WIZ.Control.SLabel();
            this.lblDeptCode = new WIZ.Control.SLabel();
            this.cboDeptCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartdate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEnddate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDeptCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboDeptCode);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.lblDeptCode);
            this.gbxHeader.Controls.Add(this.txtWorkerID);
            this.gbxHeader.Controls.Add(this.txtWorkerName);
            this.gbxHeader.Controls.Add(this.lblWorkerID);
            this.gbxHeader.Controls.Add(this.txtLineCode);
            this.gbxHeader.Controls.Add(this.txtLineName);
            this.gbxHeader.Controls.Add(this.txtOPCode);
            this.gbxHeader.Controls.Add(this.txtOPName);
            this.gbxHeader.Controls.Add(this.txtWorkCenterCode);
            this.gbxHeader.Controls.Add(this.txtWorkCenterName);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Controls.Add(this.CboStartdate_H);
            this.gbxHeader.Controls.Add(this.CboEnddate_H);
            this.gbxHeader.Controls.Add(this.ultraLabel4);
            this.gbxHeader.Controls.Add(this.lblLineCode);
            this.gbxHeader.Controls.Add(this.lblOPCode);
            this.gbxHeader.Controls.Add(this.lblWorkCenterCode);
            this.gbxHeader.Controls.Add(this.lblDate);
            this.gbxHeader.Size = new System.Drawing.Size(1230, 120);
            this.gbxHeader.Controls.SetChildIndex(this.lblDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblWorkCenterCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblOPCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblLineCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.ultraLabel4, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboEnddate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboStartdate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkCenterName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkCenterCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtOPName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtOPCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtLineName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtLineCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblWorkerID, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkerName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkerID, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblDeptCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboDeptCode, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 120);
            this.gbxBody.Size = new System.Drawing.Size(1230, 705);
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
            appearance32.BackColor = System.Drawing.SystemColors.Window;
            appearance32.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance32;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance13;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance21.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance21.BackColor2 = System.Drawing.SystemColors.Control;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance21;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance37.BackColor = System.Drawing.SystemColors.Highlight;
            appearance37.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance37;
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
            appearance14.BorderColor = System.Drawing.Color.Silver;
            appearance14.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance14;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance38.BackColor = System.Drawing.SystemColors.Control;
            appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance38.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance38.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance38;
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
            this.grid1.Size = new System.Drawing.Size(1218, 693);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtWorkerID
            // 
            this.txtWorkerID.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkerID.Location = new System.Drawing.Point(146, 84);
            this.txtWorkerID.Name = "txtWorkerID";
            this.txtWorkerID.Size = new System.Drawing.Size(119, 25);
            this.txtWorkerID.TabIndex = 6;
            // 
            // txtWorkerName
            // 
            this.txtWorkerName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtWorkerName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkerName.Location = new System.Drawing.Point(265, 84);
            this.txtWorkerName.MaxLength = 30;
            this.txtWorkerName.Name = "txtWorkerName";
            this.txtWorkerName.Size = new System.Drawing.Size(199, 25);
            this.txtWorkerName.TabIndex = 7;
            // 
            // lblWorkerID
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.Name = "맑은 고딕";
            appearance1.FontData.SizeInPoints = 9F;
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblWorkerID.Appearance = appearance1;
            this.lblWorkerID.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWorkerID.DbField = null;
            this.lblWorkerID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkerID.Location = new System.Drawing.Point(51, 84);
            this.lblWorkerID.Name = "lblWorkerID";
            this.lblWorkerID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWorkerID.Size = new System.Drawing.Size(90, 25);
            this.lblWorkerID.TabIndex = 313;
            this.lblWorkerID.Text = "작업자";
            // 
            // txtLineCode
            // 
            this.txtLineCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtLineCode.Location = new System.Drawing.Point(533, 12);
            this.txtLineCode.Name = "txtLineCode";
            this.txtLineCode.Size = new System.Drawing.Size(119, 25);
            this.txtLineCode.TabIndex = 10;
            this.txtLineCode.Visible = false;
            // 
            // txtLineName
            // 
            this.txtLineName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtLineName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtLineName.Location = new System.Drawing.Point(652, 12);
            this.txtLineName.MaxLength = 30;
            this.txtLineName.Name = "txtLineName";
            this.txtLineName.Size = new System.Drawing.Size(199, 25);
            this.txtLineName.TabIndex = 11;
            this.txtLineName.Visible = false;
            // 
            // txtOPCode
            // 
            this.txtOPCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtOPCode.Location = new System.Drawing.Point(533, 48);
            this.txtOPCode.Name = "txtOPCode";
            this.txtOPCode.Size = new System.Drawing.Size(119, 25);
            this.txtOPCode.TabIndex = 4;
            // 
            // txtOPName
            // 
            this.txtOPName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtOPName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtOPName.Location = new System.Drawing.Point(652, 48);
            this.txtOPName.MaxLength = 30;
            this.txtOPName.Name = "txtOPName";
            this.txtOPName.Size = new System.Drawing.Size(199, 25);
            this.txtOPName.TabIndex = 5;
            // 
            // txtWorkCenterCode
            // 
            this.txtWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkCenterCode.Location = new System.Drawing.Point(533, 84);
            this.txtWorkCenterCode.Name = "txtWorkCenterCode";
            this.txtWorkCenterCode.Size = new System.Drawing.Size(119, 25);
            this.txtWorkCenterCode.TabIndex = 8;
            // 
            // txtWorkCenterName
            // 
            this.txtWorkCenterName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtWorkCenterName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkCenterName.Location = new System.Drawing.Point(652, 84);
            this.txtWorkCenterName.MaxLength = 30;
            this.txtWorkCenterName.Name = "txtWorkCenterName";
            this.txtWorkCenterName.Size = new System.Drawing.Size(199, 25);
            this.txtWorkCenterName.TabIndex = 9;
            // 
            // lblPlantCode
            // 
            appearance58.FontData.BoldAsString = "False";
            appearance58.FontData.Name = "맑은 고딕";
            appearance58.FontData.SizeInPoints = 9F;
            appearance58.FontData.UnderlineAsString = "False";
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextHAlignAsString = "Right";
            appearance58.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance58;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(51, 12);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(90, 25);
            this.lblPlantCode.TabIndex = 305;
            this.lblPlantCode.Text = "사업장";
            // 
            // CboStartdate_H
            // 
            appearance70.FontData.Name = "맑은 고딕";
            appearance70.FontData.SizeInPoints = 9F;
            this.CboStartdate_H.Appearance = appearance70;
            this.CboStartdate_H.AutoSize = false;
            this.CboStartdate_H.DateButtons.Add(dateButton1);
            this.CboStartdate_H.Location = new System.Drawing.Point(941, 11);
            this.CboStartdate_H.Name = "CboStartdate_H";
            this.CboStartdate_H.NonAutoSizeHeight = 26;
            this.CboStartdate_H.Size = new System.Drawing.Size(120, 26);
            this.CboStartdate_H.TabIndex = 1;
            // 
            // CboEnddate_H
            // 
            appearance77.FontData.Name = "맑은 고딕";
            appearance77.FontData.SizeInPoints = 9F;
            this.CboEnddate_H.Appearance = appearance77;
            this.CboEnddate_H.AutoSize = false;
            this.CboEnddate_H.DateButtons.Add(dateButton2);
            this.CboEnddate_H.Location = new System.Drawing.Point(1084, 11);
            this.CboEnddate_H.Name = "CboEnddate_H";
            this.CboEnddate_H.NonAutoSizeHeight = 26;
            this.CboEnddate_H.Size = new System.Drawing.Size(120, 26);
            this.CboEnddate_H.TabIndex = 2;
            // 
            // ultraLabel4
            // 
            appearance78.TextHAlignAsString = "Center";
            appearance78.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance78;
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ultraLabel4.Location = new System.Drawing.Point(1066, 15);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(13, 18);
            this.ultraLabel4.TabIndex = 302;
            this.ultraLabel4.Text = "~";
            // 
            // lblLineCode
            // 
            appearance23.FontData.BoldAsString = "False";
            appearance23.FontData.Name = "맑은 고딕";
            appearance23.FontData.SizeInPoints = 9F;
            appearance23.FontData.UnderlineAsString = "False";
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextHAlignAsString = "Right";
            appearance23.TextVAlignAsString = "Middle";
            this.lblLineCode.Appearance = appearance23;
            this.lblLineCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblLineCode.DbField = null;
            this.lblLineCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLineCode.Location = new System.Drawing.Point(438, 12);
            this.lblLineCode.Name = "lblLineCode";
            this.lblLineCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblLineCode.Size = new System.Drawing.Size(90, 25);
            this.lblLineCode.TabIndex = 301;
            this.lblLineCode.Text = "라인";
            this.lblLineCode.Visible = false;
            // 
            // lblOPCode
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.Name = "맑은 고딕";
            appearance2.FontData.SizeInPoints = 9F;
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblOPCode.Appearance = appearance2;
            this.lblOPCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblOPCode.DbField = null;
            this.lblOPCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOPCode.Location = new System.Drawing.Point(438, 48);
            this.lblOPCode.Name = "lblOPCode";
            this.lblOPCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblOPCode.Size = new System.Drawing.Size(90, 25);
            this.lblOPCode.TabIndex = 300;
            this.lblOPCode.Text = "공정";
            // 
            // lblWorkCenterCode
            // 
            appearance69.FontData.BoldAsString = "False";
            appearance69.FontData.Name = "맑은 고딕";
            appearance69.FontData.SizeInPoints = 9F;
            appearance69.FontData.UnderlineAsString = "False";
            appearance69.ForeColor = System.Drawing.Color.Black;
            appearance69.TextHAlignAsString = "Right";
            appearance69.TextVAlignAsString = "Middle";
            this.lblWorkCenterCode.Appearance = appearance69;
            this.lblWorkCenterCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWorkCenterCode.DbField = null;
            this.lblWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkCenterCode.Location = new System.Drawing.Point(438, 84);
            this.lblWorkCenterCode.Name = "lblWorkCenterCode";
            this.lblWorkCenterCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWorkCenterCode.Size = new System.Drawing.Size(90, 25);
            this.lblWorkCenterCode.TabIndex = 299;
            this.lblWorkCenterCode.Text = "작업장";
            // 
            // lblDate
            // 
            appearance63.FontData.BoldAsString = "False";
            appearance63.FontData.Name = "맑은 고딕";
            appearance63.FontData.UnderlineAsString = "False";
            appearance63.ForeColor = System.Drawing.Color.Black;
            appearance63.TextHAlignAsString = "Right";
            appearance63.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance63;
            this.lblDate.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblDate.DbField = null;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(846, 12);
            this.lblDate.Name = "lblDate";
            this.lblDate.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDate.Size = new System.Drawing.Size(90, 25);
            this.lblDate.TabIndex = 298;
            this.lblDate.Text = "작업일자";
            // 
            // lblDeptCode
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lblDeptCode.Appearance = appearance3;
            this.lblDeptCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblDeptCode.DbField = "cboUseFlag";
            this.lblDeptCode.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblDeptCode.Location = new System.Drawing.Point(51, 48);
            this.lblDeptCode.Name = "lblDeptCode";
            this.lblDeptCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDeptCode.Size = new System.Drawing.Size(90, 25);
            this.lblDeptCode.TabIndex = 317;
            this.lblDeptCode.Text = "팀구분";
            // 
            // cboDeptCode
            // 
            this.cboDeptCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboDeptCode.Location = new System.Drawing.Point(146, 47);
            this.cboDeptCode.Name = "cboDeptCode";
            this.cboDeptCode.Size = new System.Drawing.Size(119, 27);
            this.cboDeptCode.TabIndex = 3;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 11);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(119, 27);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // PP1200
            // 
            this.ClientSize = new System.Drawing.Size(1230, 825);
            this.Name = "PP1200";
            this.Text = "작업자 실공수 투입 이력";
            this.Load += new System.EventHandler(this.PP1200_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartdate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEnddate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDeptCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.Grid grid1;
        private System.Windows.Forms.TextBox txtWorkerID;
        private System.Windows.Forms.TextBox txtWorkerName;
        private Control.SLabel lblWorkerID;
        private System.Windows.Forms.TextBox txtLineCode;
        private System.Windows.Forms.TextBox txtLineName;
        private System.Windows.Forms.TextBox txtOPCode;
        private System.Windows.Forms.TextBox txtOPName;
        private System.Windows.Forms.TextBox txtWorkCenterCode;
        private System.Windows.Forms.TextBox txtWorkCenterName;
        private Control.SLabel lblPlantCode;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboStartdate_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboEnddate_H;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Control.SLabel lblLineCode;
        private Control.SLabel lblOPCode;
        private Control.SLabel lblWorkCenterCode;
        private Control.SLabel lblDate;
        private Control.SLabel lblDeptCode;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboDeptCode;
    }
}

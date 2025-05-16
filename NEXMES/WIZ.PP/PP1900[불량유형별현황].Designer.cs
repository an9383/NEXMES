namespace WIZ.PP
{
    partial class PP1900
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
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            this.lblErrorType = new WIZ.Control.SLabel();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.txtLineCode = new System.Windows.Forms.TextBox();
            this.txtLineName = new System.Windows.Forms.TextBox();
            this.txtOPCode = new System.Windows.Forms.TextBox();
            this.txtOPName = new System.Windows.Forms.TextBox();
            this.txtWorkCenterCode = new System.Windows.Forms.TextBox();
            this.txtWorkCenterName = new System.Windows.Forms.TextBox();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.lblLineCode = new WIZ.Control.SLabel();
            this.lblOPCode = new WIZ.Control.SLabel();
            this.lblWorkCenterCode = new WIZ.Control.SLabel();
            this.lblDate = new WIZ.Control.SLabel();
            this.lblErrorClass = new WIZ.Control.SLabel();
            this.sLabel1 = new WIZ.Control.SLabel();
            this.cboEndDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.CboStartDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cboErrorClass_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboErrorType_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartDate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErrorClass_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErrorType_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboErrorClass_H);
            this.gbxHeader.Controls.Add(this.lblErrorClass);
            this.gbxHeader.Controls.Add(this.cboErrorType_H);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Controls.Add(this.lblErrorType);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.cboEndDate_H);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.lblOPCode);
            this.gbxHeader.Controls.Add(this.lblDate);
            this.gbxHeader.Controls.Add(this.CboStartDate_H);
            this.gbxHeader.Controls.Add(this.txtOPName);
            this.gbxHeader.Controls.Add(this.txtOPCode);
            this.gbxHeader.Controls.Add(this.lblWorkCenterCode);
            this.gbxHeader.Controls.Add(this.txtWorkCenterCode);
            this.gbxHeader.Controls.Add(this.lblLineCode);
            this.gbxHeader.Controls.Add(this.txtLineCode);
            this.gbxHeader.Controls.Add(this.txtWorkCenterName);
            this.gbxHeader.Controls.Add(this.txtLineName);
            this.gbxHeader.Size = new System.Drawing.Size(1493, 135);
            this.gbxHeader.Controls.SetChildIndex(this.txtLineName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkCenterName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtLineCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblLineCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkCenterCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblWorkCenterCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtOPCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtOPName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboStartDate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblOPCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboEndDate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblErrorType, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboErrorType_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblErrorClass, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboErrorClass_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 135);
            this.gbxBody.Size = new System.Drawing.Size(1493, 690);
            // 
            // lblErrorType
            // 
            appearance50.FontData.BoldAsString = "False";
            appearance50.FontData.SizeInPoints = 9.75F;
            appearance50.FontData.UnderlineAsString = "False";
            appearance50.ForeColor = System.Drawing.Color.Black;
            appearance50.TextHAlignAsString = "Left";
            appearance50.TextVAlignAsString = "Middle";
            this.lblErrorType.Appearance = appearance50;
            this.lblErrorType.DbField = "cboUseFlag";
            this.lblErrorType.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblErrorType.Location = new System.Drawing.Point(437, 69);
            this.lblErrorType.Name = "lblErrorType";
            this.lblErrorType.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblErrorType.Size = new System.Drawing.Size(122, 25);
            this.lblErrorType.TabIndex = 171;
            this.lblErrorType.Text = "불량구분";
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
            appearance22.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance22;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance21.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance21.BackColor2 = System.Drawing.SystemColors.Control;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance21;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance27.BackColor = System.Drawing.SystemColors.Window;
            appearance27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance27;
            appearance20.BackColor = System.Drawing.SystemColors.Highlight;
            appearance20.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance20;
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
            appearance30.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance30;
            appearance26.BorderColor = System.Drawing.Color.Silver;
            appearance26.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance26;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance24.BackColor = System.Drawing.SystemColors.Control;
            appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance24.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance24.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance24;
            appearance25.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance25;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance28.BackColor = System.Drawing.SystemColors.Window;
            appearance28.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance28;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance29.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance29;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1481, 678);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtLineCode
            // 
            this.txtLineCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtLineCode.Location = new System.Drawing.Point(112, 94);
            this.txtLineCode.Name = "txtLineCode";
            this.txtLineCode.Size = new System.Drawing.Size(122, 25);
            this.txtLineCode.TabIndex = 7;
            // 
            // txtLineName
            // 
            this.txtLineName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtLineName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtLineName.Location = new System.Drawing.Point(234, 94);
            this.txtLineName.MaxLength = 30;
            this.txtLineName.Name = "txtLineName";
            this.txtLineName.Size = new System.Drawing.Size(184, 25);
            this.txtLineName.TabIndex = 8;
            // 
            // txtOPCode
            // 
            this.txtOPCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtOPCode.Location = new System.Drawing.Point(437, 34);
            this.txtOPCode.Name = "txtOPCode";
            this.txtOPCode.Size = new System.Drawing.Size(122, 25);
            this.txtOPCode.TabIndex = 3;
            // 
            // txtOPName
            // 
            this.txtOPName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtOPName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtOPName.Location = new System.Drawing.Point(559, 34);
            this.txtOPName.MaxLength = 30;
            this.txtOPName.Name = "txtOPName";
            this.txtOPName.Size = new System.Drawing.Size(193, 25);
            this.txtOPName.TabIndex = 4;
            // 
            // txtWorkCenterCode
            // 
            this.txtWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkCenterCode.Location = new System.Drawing.Point(783, 34);
            this.txtWorkCenterCode.Name = "txtWorkCenterCode";
            this.txtWorkCenterCode.Size = new System.Drawing.Size(122, 25);
            this.txtWorkCenterCode.TabIndex = 5;
            // 
            // txtWorkCenterName
            // 
            this.txtWorkCenterName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtWorkCenterName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkCenterName.Location = new System.Drawing.Point(905, 34);
            this.txtWorkCenterName.MaxLength = 30;
            this.txtWorkCenterName.Name = "txtWorkCenterName";
            this.txtWorkCenterName.Size = new System.Drawing.Size(209, 25);
            this.txtWorkCenterName.TabIndex = 6;
            // 
            // lblPlantCode
            // 
            appearance58.FontData.BoldAsString = "False";
            appearance58.FontData.Name = "맑은 고딕";
            appearance58.FontData.SizeInPoints = 9.75F;
            appearance58.FontData.UnderlineAsString = "False";
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextHAlignAsString = "Left";
            appearance58.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance58;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(112, 9);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(156, 25);
            this.lblPlantCode.TabIndex = 349;
            this.lblPlantCode.Text = "사업장";
            // 
            // lblLineCode
            // 
            appearance23.FontData.BoldAsString = "False";
            appearance23.FontData.Name = "맑은 고딕";
            appearance23.FontData.SizeInPoints = 9.75F;
            appearance23.FontData.UnderlineAsString = "False";
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextHAlignAsString = "Left";
            appearance23.TextVAlignAsString = "Middle";
            this.lblLineCode.Appearance = appearance23;
            this.lblLineCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblLineCode.DbField = null;
            this.lblLineCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLineCode.Location = new System.Drawing.Point(112, 69);
            this.lblLineCode.Name = "lblLineCode";
            this.lblLineCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblLineCode.Size = new System.Drawing.Size(122, 25);
            this.lblLineCode.TabIndex = 346;
            this.lblLineCode.Text = "라인";
            // 
            // lblOPCode
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.Name = "맑은 고딕";
            appearance2.FontData.SizeInPoints = 9.75F;
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lblOPCode.Appearance = appearance2;
            this.lblOPCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblOPCode.DbField = null;
            this.lblOPCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOPCode.Location = new System.Drawing.Point(437, 9);
            this.lblOPCode.Name = "lblOPCode";
            this.lblOPCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblOPCode.Size = new System.Drawing.Size(122, 25);
            this.lblOPCode.TabIndex = 345;
            this.lblOPCode.Text = "공정";
            // 
            // lblWorkCenterCode
            // 
            appearance69.FontData.BoldAsString = "False";
            appearance69.FontData.Name = "맑은 고딕";
            appearance69.FontData.SizeInPoints = 9.75F;
            appearance69.FontData.UnderlineAsString = "False";
            appearance69.ForeColor = System.Drawing.Color.Black;
            appearance69.TextHAlignAsString = "Left";
            appearance69.TextVAlignAsString = "Middle";
            this.lblWorkCenterCode.Appearance = appearance69;
            this.lblWorkCenterCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWorkCenterCode.DbField = null;
            this.lblWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkCenterCode.Location = new System.Drawing.Point(783, 9);
            this.lblWorkCenterCode.Name = "lblWorkCenterCode";
            this.lblWorkCenterCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWorkCenterCode.Size = new System.Drawing.Size(122, 25);
            this.lblWorkCenterCode.TabIndex = 344;
            this.lblWorkCenterCode.Text = "작업장";
            // 
            // lblDate
            // 
            appearance63.FontData.BoldAsString = "False";
            appearance63.FontData.Name = "맑은 고딕";
            appearance63.FontData.SizeInPoints = 9.75F;
            appearance63.FontData.UnderlineAsString = "False";
            appearance63.ForeColor = System.Drawing.Color.Black;
            appearance63.TextHAlignAsString = "Left";
            appearance63.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance63;
            this.lblDate.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblDate.DbField = null;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(1142, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDate.Size = new System.Drawing.Size(122, 25);
            this.lblDate.TabIndex = 343;
            this.lblDate.Text = "작업일자";
            // 
            // lblErrorClass
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.SizeInPoints = 9.75F;
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.lblErrorClass.Appearance = appearance4;
            this.lblErrorClass.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblErrorClass.DbField = "cboUseFlag";
            this.lblErrorClass.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblErrorClass.Location = new System.Drawing.Point(783, 69);
            this.lblErrorClass.Name = "lblErrorClass";
            this.lblErrorClass.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblErrorClass.Size = new System.Drawing.Size(144, 25);
            this.lblErrorClass.TabIndex = 359;
            this.lblErrorClass.Text = "불량유형";
            // 
            // sLabel1
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance1;
            this.sLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(1266, 34);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(13, 25);
            this.sLabel1.TabIndex = 363;
            this.sLabel1.Text = "~";
            // 
            // cboEndDate_H
            // 
            this.cboEndDate_H.DateButtons.Add(dateButton1);
            this.cboEndDate_H.Location = new System.Drawing.Point(1283, 34);
            this.cboEndDate_H.Name = "cboEndDate_H";
            this.cboEndDate_H.NonAutoSizeHeight = 26;
            this.cboEndDate_H.Size = new System.Drawing.Size(121, 26);
            this.cboEndDate_H.TabIndex = 2;
            // 
            // CboStartDate_H
            // 
            this.CboStartDate_H.DateButtons.Add(dateButton2);
            this.CboStartDate_H.Location = new System.Drawing.Point(1142, 34);
            this.CboStartDate_H.Name = "CboStartDate_H";
            this.CboStartDate_H.NonAutoSizeHeight = 26;
            this.CboStartDate_H.Size = new System.Drawing.Size(122, 26);
            this.CboStartDate_H.TabIndex = 1;
            // 
            // cboErrorClass_H
            // 
            this.cboErrorClass_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboErrorClass_H.Location = new System.Drawing.Point(783, 94);
            this.cboErrorClass_H.Name = "cboErrorClass_H";
            this.cboErrorClass_H.Size = new System.Drawing.Size(144, 27);
            this.cboErrorClass_H.TabIndex = 10;
            // 
            // cboErrorType_H
            // 
            this.cboErrorType_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboErrorType_H.Location = new System.Drawing.Point(437, 94);
            this.cboErrorType_H.Name = "cboErrorType_H";
            this.cboErrorType_H.Size = new System.Drawing.Size(122, 27);
            this.cboErrorType_H.TabIndex = 9;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(112, 34);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(156, 27);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // PP1900
            // 
            this.ClientSize = new System.Drawing.Size(1493, 825);
            this.Name = "PP1900";
            this.Text = "불량 유형별 현황";
            this.Load += new System.EventHandler(this.PP1900_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartDate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErrorClass_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErrorType_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.SLabel lblErrorType;
        private Control.Grid grid1;
        private System.Windows.Forms.TextBox txtLineCode;
        private System.Windows.Forms.TextBox txtLineName;
        private System.Windows.Forms.TextBox txtOPCode;
        private System.Windows.Forms.TextBox txtOPName;
        private System.Windows.Forms.TextBox txtWorkCenterCode;
        private System.Windows.Forms.TextBox txtWorkCenterName;
        private Control.SLabel lblPlantCode;
        private Control.SLabel lblLineCode;
        private Control.SLabel lblOPCode;
        private Control.SLabel lblWorkCenterCode;
        private Control.SLabel lblDate;
        private Control.SLabel lblErrorClass;
        private Control.SLabel sLabel1;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboEndDate_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboStartDate_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboErrorType_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboErrorClass_H;
    }
}

namespace WIZ.WM
{
    partial class WM0200
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
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
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
            this.sLabel10 = new WIZ.Control.SLabel();
            this.uccRecDateEnd = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.uccRecDateStart = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.sLabel9 = new WIZ.Control.SLabel();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemCode = new WIZ.Control.SLabel();
            this.txtWHCode = new System.Windows.Forms.TextBox();
            this.txtWHName = new System.Windows.Forms.TextBox();
            this.lblWHCode = new WIZ.Control.SLabel();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.txtStartLot = new System.Windows.Forms.TextBox();
            this.sLabel1 = new WIZ.Control.SLabel();
            this.txtEndLot = new System.Windows.Forms.TextBox();
            this.sLabel2 = new WIZ.Control.SLabel();
            this.ultraOptionSet1 = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.cboPlantCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.grid1 = new WIZ.Control.Grid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uccRecDateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccRecDateStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboPlantCode);
            this.gbxHeader.Controls.Add(this.ultraOptionSet1);
            this.gbxHeader.Controls.Add(this.sLabel2);
            this.gbxHeader.Controls.Add(this.txtEndLot);
            this.gbxHeader.Controls.Add(this.txtStartLot);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.sLabel10);
            this.gbxHeader.Controls.Add(this.uccRecDateEnd);
            this.gbxHeader.Controls.Add(this.uccRecDateStart);
            this.gbxHeader.Controls.Add(this.sLabel9);
            this.gbxHeader.Controls.Add(this.txtItemCode);
            this.gbxHeader.Controls.Add(this.txtItemName);
            this.gbxHeader.Controls.Add(this.lblItemCode);
            this.gbxHeader.Controls.Add(this.txtWHCode);
            this.gbxHeader.Controls.Add(this.txtWHName);
            this.gbxHeader.Controls.Add(this.lblWHCode);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 110);
            this.gbxHeader.TabIndex = 0;
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblWHCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWHName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWHCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel9, 0);
            this.gbxHeader.Controls.SetChildIndex(this.uccRecDateStart, 0);
            this.gbxHeader.Controls.SetChildIndex(this.uccRecDateEnd, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel10, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtStartLot, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtEndLot, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel2, 0);
            this.gbxHeader.Controls.SetChildIndex(this.ultraOptionSet1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 110);
            this.gbxBody.Size = new System.Drawing.Size(1136, 715);
            // 
            // sLabel10
            // 
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.sLabel10.Appearance = appearance17;
            this.sLabel10.DbField = "cboUseFlag";
            this.sLabel10.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel10.Location = new System.Drawing.Point(706, 6);
            this.sLabel10.Name = "sLabel10";
            this.sLabel10.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel10.Size = new System.Drawing.Size(10, 27);
            this.sLabel10.TabIndex = 2;
            this.sLabel10.Text = "~";
            // 
            // uccRecDateEnd
            // 
            this.uccRecDateEnd.DateButtons.Add(dateButton1);
            this.uccRecDateEnd.Location = new System.Drawing.Point(718, 6);
            this.uccRecDateEnd.Name = "uccRecDateEnd";
            this.uccRecDateEnd.NonAutoSizeHeight = 26;
            this.uccRecDateEnd.Size = new System.Drawing.Size(119, 26);
            this.uccRecDateEnd.TabIndex = 2;
            this.uccRecDateEnd.Value = new System.DateTime(2014, 4, 24, 23, 59, 59, 0);
            // 
            // uccRecDateStart
            // 
            this.uccRecDateStart.DateButtons.Add(dateButton2);
            this.uccRecDateStart.Location = new System.Drawing.Point(581, 6);
            this.uccRecDateStart.Name = "uccRecDateStart";
            this.uccRecDateStart.NonAutoSizeHeight = 26;
            this.uccRecDateStart.Size = new System.Drawing.Size(119, 26);
            this.uccRecDateStart.TabIndex = 1;
            this.uccRecDateStart.Value = new System.DateTime(2013, 1, 14, 21, 14, 2, 0);
            // 
            // sLabel9
            // 
            appearance27.TextHAlignAsString = "Right";
            appearance27.TextVAlignAsString = "Middle";
            this.sLabel9.Appearance = appearance27;
            this.sLabel9.DbField = "cboUseFlag";
            this.sLabel9.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel9.Location = new System.Drawing.Point(483, 6);
            this.sLabel9.Name = "sLabel9";
            this.sLabel9.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel9.Size = new System.Drawing.Size(92, 27);
            this.sLabel9.TabIndex = 304;
            this.sLabel9.Text = "입고일자";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemCode.Location = new System.Drawing.Point(110, 70);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(119, 25);
            this.txtItemCode.TabIndex = 7;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtItemName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemName.Location = new System.Drawing.Point(235, 69);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(239, 25);
            this.txtItemName.TabIndex = 8;
            // 
            // lblItemCode
            // 
            appearance28.TextHAlignAsString = "Right";
            appearance28.TextVAlignAsString = "Middle";
            this.lblItemCode.Appearance = appearance28;
            this.lblItemCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblItemCode.DbField = null;
            this.lblItemCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemCode.Location = new System.Drawing.Point(12, 71);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemCode.Size = new System.Drawing.Size(92, 25);
            this.lblItemCode.TabIndex = 303;
            this.lblItemCode.Text = "품  목";
            // 
            // txtWHCode
            // 
            this.txtWHCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWHCode.Location = new System.Drawing.Point(110, 39);
            this.txtWHCode.Name = "txtWHCode";
            this.txtWHCode.Size = new System.Drawing.Size(119, 25);
            this.txtWHCode.TabIndex = 3;
            // 
            // txtWHName
            // 
            this.txtWHName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtWHName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWHName.Location = new System.Drawing.Point(235, 39);
            this.txtWHName.MaxLength = 30;
            this.txtWHName.Name = "txtWHName";
            this.txtWHName.Size = new System.Drawing.Size(239, 25);
            this.txtWHName.TabIndex = 4;
            // 
            // lblWHCode
            // 
            appearance18.TextHAlignAsString = "Right";
            appearance18.TextVAlignAsString = "Middle";
            this.lblWHCode.Appearance = appearance18;
            this.lblWHCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWHCode.DbField = null;
            this.lblWHCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWHCode.Location = new System.Drawing.Point(12, 38);
            this.lblWHCode.Name = "lblWHCode";
            this.lblWHCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWHCode.Size = new System.Drawing.Size(92, 25);
            this.lblWHCode.TabIndex = 300;
            this.lblWHCode.Text = "창  고";
            // 
            // lblPlantCode
            // 
            appearance19.TextHAlignAsString = "Right";
            appearance19.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance19;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(12, 7);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(92, 25);
            this.lblPlantCode.TabIndex = 297;
            this.lblPlantCode.Text = "사업장";
            // 
            // txtStartLot
            // 
            this.txtStartLot.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtStartLot.Location = new System.Drawing.Point(581, 39);
            this.txtStartLot.Name = "txtStartLot";
            this.txtStartLot.Size = new System.Drawing.Size(119, 25);
            this.txtStartLot.TabIndex = 5;
            // 
            // sLabel1
            // 
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance16;
            this.sLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(483, 38);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(92, 25);
            this.sLabel1.TabIndex = 310;
            this.sLabel1.Text = "Lot No";
            // 
            // txtEndLot
            // 
            this.txtEndLot.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtEndLot.Location = new System.Drawing.Point(718, 39);
            this.txtEndLot.Name = "txtEndLot";
            this.txtEndLot.Size = new System.Drawing.Size(119, 25);
            this.txtEndLot.TabIndex = 6;
            // 
            // sLabel2
            // 
            appearance26.TextHAlignAsString = "Right";
            appearance26.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance26;
            this.sLabel2.DbField = "cboUseFlag";
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(706, 37);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(10, 27);
            this.sLabel2.TabIndex = 312;
            this.sLabel2.Text = "~";
            // 
            // ultraOptionSet1
            // 
            this.ultraOptionSet1.CheckedIndex = 0;
            this.ultraOptionSet1.ItemOrigin = new System.Drawing.Point(5, 0);
            valueListItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem1.DataValue = "Lot";
            valueListItem1.DisplayText = "Lot별    ";
            valueListItem1.Tag = "L";
            valueListItem2.DataValue = "Item";
            valueListItem2.DisplayText = "품목별  ";
            valueListItem2.Tag = "I";
            valueListItem3.DataValue = "Group";
            valueListItem3.DisplayText = "그룹별  ";
            valueListItem3.Tag = "G";
            this.ultraOptionSet1.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.ultraOptionSet1.ItemSpacingHorizontal = 1;
            this.ultraOptionSet1.ItemSpacingVertical = 3;
            this.ultraOptionSet1.Location = new System.Drawing.Point(581, 69);
            this.ultraOptionSet1.Name = "ultraOptionSet1";
            this.ultraOptionSet1.Size = new System.Drawing.Size(256, 27);
            this.ultraOptionSet1.TabIndex = 9;
            this.ultraOptionSet1.Text = "Lot별    ";
            this.ultraOptionSet1.ValueChanged += new System.EventHandler(this.ultraOptionSet1_ValueChanged);
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode.Location = new System.Drawing.Point(110, 6);
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.Size = new System.Drawing.Size(119, 27);
            this.cboPlantCode.TabIndex = 0;
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
            this.grid1.Size = new System.Drawing.Size(1124, 703);
            this.grid1.TabIndex = 5;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // WM0200
            // 
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Name = "WM0200";
            this.Load += new System.EventHandler(this.WM0200_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uccRecDateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccRecDateStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.SLabel sLabel2;
        private System.Windows.Forms.TextBox txtEndLot;
        private System.Windows.Forms.TextBox txtStartLot;
        private Control.SLabel sLabel1;
        private Control.SLabel sLabel10;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccRecDateEnd;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccRecDateStart;
        private Control.SLabel sLabel9;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.TextBox txtItemName;
        private Control.SLabel lblItemCode;
        private System.Windows.Forms.TextBox txtWHCode;
        private System.Windows.Forms.TextBox txtWHName;
        private Control.SLabel lblWHCode;
        private Control.SLabel lblPlantCode;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode;
        private Control.Grid grid1;



    }
}

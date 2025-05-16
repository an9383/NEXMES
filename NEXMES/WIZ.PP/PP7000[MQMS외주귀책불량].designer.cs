namespace WIZ.PP
{
    partial class PP7000
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
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.CboStartDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblDate = new WIZ.Control.SLabel();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemCode = new WIZ.Control.SLabel();
            this.cboEndDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.sLabel1 = new WIZ.Control.SLabel();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.txtOPName = new System.Windows.Forms.TextBox();
            this.txtOPCode = new System.Windows.Forms.TextBox();
            this.lblOPCode = new WIZ.Control.SLabel();
            this.lbldeptcode = new WIZ.Control.SLabel();
            this.lblProcFlag_H = new WIZ.Control.SLabel();
            this.lbldaynight = new WIZ.Control.SLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboProcFlag_all = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.button1 = new System.Windows.Forms.Button();
            this.lblProcFlag_all = new WIZ.Control.SLabel();
            this.cbodaynight = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbodeptcode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboProcFlag_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartDate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProcFlag_all)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbodaynight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbodeptcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProcFlag_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cbodaynight);
            this.gbxHeader.Controls.Add(this.cbodeptcode);
            this.gbxHeader.Controls.Add(this.cboProcFlag_H);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.groupBox1);
            this.gbxHeader.Controls.Add(this.lbldaynight);
            this.gbxHeader.Controls.Add(this.txtOPName);
            this.gbxHeader.Controls.Add(this.txtOPCode);
            this.gbxHeader.Controls.Add(this.lblOPCode);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.cboEndDate_H);
            this.gbxHeader.Controls.Add(this.CboStartDate_H);
            this.gbxHeader.Controls.Add(this.lblDate);
            this.gbxHeader.Controls.Add(this.lblProcFlag_H);
            this.gbxHeader.Controls.Add(this.lbldeptcode);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Controls.Add(this.txtItemCode);
            this.gbxHeader.Controls.Add(this.txtItemName);
            this.gbxHeader.Controls.Add(this.lblItemCode);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 155);
            this.gbxHeader.Controls.SetChildIndex(this.lblItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbldeptcode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblProcFlag_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboStartDate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboEndDate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblOPCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtOPCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtOPName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbldaynight, 0);
            this.gbxHeader.Controls.SetChildIndex(this.groupBox1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboProcFlag_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbodeptcode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbodaynight, 0);
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
            // CboStartDate_H
            // 
            this.CboStartDate_H.DateButtons.Add(dateButton2);
            this.CboStartDate_H.Location = new System.Drawing.Point(726, 11);
            this.CboStartDate_H.Name = "CboStartDate_H";
            this.CboStartDate_H.NonAutoSizeHeight = 26;
            this.CboStartDate_H.Size = new System.Drawing.Size(144, 26);
            this.CboStartDate_H.TabIndex = 1;
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
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblDate.Location = new System.Drawing.Point(631, 12);
            this.lblDate.Name = "lblDate";
            this.lblDate.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDate.Size = new System.Drawing.Size(90, 25);
            this.lblDate.TabIndex = 224;
            this.lblDate.Text = "작업일자";
            // 
            // lblPlantCode
            // 
            appearance6.FontData.BoldAsString = "False";
            appearance6.FontData.UnderlineAsString = "False";
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Right";
            appearance6.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance6;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(51, 12);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(90, 25);
            this.lblPlantCode.TabIndex = 219;
            this.lblPlantCode.Text = "사업장";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemCode.Location = new System.Drawing.Point(146, 84);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(121, 25);
            this.txtItemCode.TabIndex = 6;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtItemName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemName.Location = new System.Drawing.Point(267, 84);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(199, 25);
            this.txtItemName.TabIndex = 7;
            // 
            // lblItemCode
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.lblItemCode.Appearance = appearance4;
            this.lblItemCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblItemCode.DbField = null;
            this.lblItemCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemCode.Location = new System.Drawing.Point(51, 84);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemCode.Size = new System.Drawing.Size(90, 25);
            this.lblItemCode.TabIndex = 217;
            this.lblItemCode.Text = "품목";
            // 
            // cboEndDate_H
            // 
            this.cboEndDate_H.DateButtons.Add(dateButton1);
            this.cboEndDate_H.Location = new System.Drawing.Point(920, 11);
            this.cboEndDate_H.Name = "cboEndDate_H";
            this.cboEndDate_H.NonAutoSizeHeight = 26;
            this.cboEndDate_H.Size = new System.Drawing.Size(144, 26);
            this.cboEndDate_H.TabIndex = 2;
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
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.sLabel1.Location = new System.Drawing.Point(891, 12);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(13, 25);
            this.sLabel1.TabIndex = 227;
            this.sLabel1.Text = "~";
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
            appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance14;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance16;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance15.BackColor2 = System.Drawing.SystemColors.Control;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance15;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            appearance21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance21;
            appearance17.BackColor = System.Drawing.SystemColors.Highlight;
            appearance17.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance17;
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
            appearance24.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance24;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance20;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance18.BackColor = System.Drawing.SystemColors.Control;
            appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance18.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance18;
            appearance19.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance19;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance22;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance23;
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
            // 
            // txtOPName
            // 
            this.txtOPName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtOPName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtOPName.Location = new System.Drawing.Point(267, 48);
            this.txtOPName.MaxLength = 0;
            this.txtOPName.Name = "txtOPName";
            this.txtOPName.Size = new System.Drawing.Size(199, 25);
            this.txtOPName.TabIndex = 4;
            // 
            // txtOPCode
            // 
            this.txtOPCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtOPCode.Location = new System.Drawing.Point(146, 48);
            this.txtOPCode.Name = "txtOPCode";
            this.txtOPCode.Size = new System.Drawing.Size(121, 25);
            this.txtOPCode.TabIndex = 3;
            // 
            // lblOPCode
            // 
            appearance82.FontData.BoldAsString = "False";
            appearance82.FontData.UnderlineAsString = "False";
            appearance82.ForeColor = System.Drawing.Color.Black;
            appearance82.TextHAlignAsString = "Right";
            appearance82.TextVAlignAsString = "Middle";
            this.lblOPCode.Appearance = appearance82;
            this.lblOPCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblOPCode.DbField = "";
            this.lblOPCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOPCode.Location = new System.Drawing.Point(51, 48);
            this.lblOPCode.Name = "lblOPCode";
            this.lblOPCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblOPCode.Size = new System.Drawing.Size(90, 25);
            this.lblOPCode.TabIndex = 229;
            this.lblOPCode.Text = "공정";
            // 
            // lbldeptcode
            // 
            appearance7.FontData.BoldAsString = "False";
            appearance7.FontData.UnderlineAsString = "False";
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Right";
            appearance7.TextVAlignAsString = "Middle";
            this.lbldeptcode.Appearance = appearance7;
            this.lbldeptcode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbldeptcode.DbField = null;
            this.lbldeptcode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbldeptcode.Location = new System.Drawing.Point(631, 48);
            this.lbldeptcode.Name = "lbldeptcode";
            this.lbldeptcode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbldeptcode.Size = new System.Drawing.Size(90, 25);
            this.lbldeptcode.TabIndex = 219;
            this.lbldeptcode.Text = "팀구분";
            // 
            // lblProcFlag_H
            // 
            appearance8.FontData.BoldAsString = "False";
            appearance8.FontData.UnderlineAsString = "False";
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.lblProcFlag_H.Appearance = appearance8;
            this.lblProcFlag_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblProcFlag_H.DbField = null;
            this.lblProcFlag_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProcFlag_H.Location = new System.Drawing.Point(51, 120);
            this.lblProcFlag_H.Name = "lblProcFlag_H";
            this.lblProcFlag_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblProcFlag_H.Size = new System.Drawing.Size(90, 25);
            this.lblProcFlag_H.TabIndex = 219;
            this.lblProcFlag_H.Text = "I/F상태";
            // 
            // lbldaynight
            // 
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.lbldaynight.Appearance = appearance5;
            this.lbldaynight.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbldaynight.DbField = null;
            this.lbldaynight.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbldaynight.Location = new System.Drawing.Point(631, 84);
            this.lbldaynight.Name = "lbldaynight";
            this.lbldaynight.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbldaynight.Size = new System.Drawing.Size(90, 25);
            this.lbldaynight.TabIndex = 231;
            this.lbldaynight.Text = "주야구분";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboProcFlag_all);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lblProcFlag_all);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(658, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 49);
            this.groupBox1.TabIndex = 235;
            this.groupBox1.TabStop = false;
            // 
            // cboProcFlag_all
            // 
            this.cboProcFlag_all.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboProcFlag_all.Location = new System.Drawing.Point(68, 13);
            this.cboProcFlag_all.Name = "cboProcFlag_all";
            this.cboProcFlag_all.Size = new System.Drawing.Size(144, 27);
            this.cboProcFlag_all.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.button1.Location = new System.Drawing.Point(218, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "적용";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblProcFlag_all
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lblProcFlag_all.Appearance = appearance3;
            this.lblProcFlag_all.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblProcFlag_all.DbField = null;
            this.lblProcFlag_all.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProcFlag_all.Location = new System.Drawing.Point(7, 13);
            this.lblProcFlag_all.Name = "lblProcFlag_all";
            this.lblProcFlag_all.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblProcFlag_all.Size = new System.Drawing.Size(56, 27);
            this.lblProcFlag_all.TabIndex = 235;
            this.lblProcFlag_all.Text = "I/F상태";
            // 
            // cbodaynight
            // 
            this.cbodaynight.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbodaynight.Location = new System.Drawing.Point(726, 83);
            this.cbodaynight.Name = "cbodaynight";
            this.cbodaynight.Size = new System.Drawing.Size(144, 27);
            this.cbodaynight.TabIndex = 8;
            // 
            // cbodeptcode
            // 
            this.cbodeptcode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbodeptcode.Location = new System.Drawing.Point(726, 47);
            this.cbodeptcode.Name = "cbodeptcode";
            this.cbodeptcode.Size = new System.Drawing.Size(144, 27);
            this.cbodeptcode.TabIndex = 5;
            // 
            // cboProcFlag_H
            // 
            this.cboProcFlag_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboProcFlag_H.Location = new System.Drawing.Point(146, 119);
            this.cboProcFlag_H.Name = "cboProcFlag_H";
            this.cboProcFlag_H.Size = new System.Drawing.Size(121, 27);
            this.cboProcFlag_H.TabIndex = 9;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 11);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(121, 27);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // PP7000
            // 
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Name = "PP7000";
            this.Text = "MQMS외주 귀책 불량 I/F조회";
            this.Load += new System.EventHandler(this.PP7000_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CboStartDate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProcFlag_all)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbodaynight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbodeptcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProcFlag_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboStartDate_H;
        private Control.SLabel lblDate;
        private Control.SLabel lblPlantCode;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.TextBox txtItemName;
        private Control.SLabel lblItemCode;
        private Control.SLabel sLabel1;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboEndDate_H;
        private Control.Grid grid1;
        private System.Windows.Forms.TextBox txtOPName;
        private System.Windows.Forms.TextBox txtOPCode;
        private Control.SLabel lblOPCode;
        private Control.SLabel lblProcFlag_H;
        private Control.SLabel lbldeptcode;
        private Control.SLabel lbldaynight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private Control.SLabel lblProcFlag_all;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboProcFlag_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbodeptcode;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbodaynight;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboProcFlag_all;
    }
}

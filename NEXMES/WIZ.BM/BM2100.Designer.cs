namespace WIZ.BM
{
    partial class BM2100
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
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
            this.lblcboUseFlag = new WIZ.Control.SLabel();
            this.lblWorkerID = new WIZ.Control.SLabel();
            this.lblLineCode = new WIZ.Control.SLabel();
            this.cboWorkerID_H = new WIZ.Control.SCodeComboBox();
            this.lbltxtPlantCodeR = new WIZ.Control.SLabel();
            this.txtLineCode = new System.Windows.Forms.TextBox();
            this.txtLineName = new System.Windows.Forms.TextBox();
            this.txtWorkerName = new System.Windows.Forms.TextBox();
            this.txtWorkerID = new System.Windows.Forms.TextBox();
            this.cboUseFlag_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.grid1 = new WIZ.Control.Grid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkerID_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseFlag_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.cboUseFlag_H);
            this.gbxHeader.Controls.Add(this.txtWorkerName);
            this.gbxHeader.Controls.Add(this.txtWorkerID);
            this.gbxHeader.Controls.Add(this.txtLineCode);
            this.gbxHeader.Controls.Add(this.txtLineName);
            this.gbxHeader.Controls.Add(this.lbltxtPlantCodeR);
            this.gbxHeader.Controls.Add(this.lblcboUseFlag);
            this.gbxHeader.Controls.Add(this.lblLineCode);
            this.gbxHeader.Controls.Add(this.lblWorkerID);
            this.gbxHeader.Controls.Add(this.cboWorkerID_H);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 90);
            this.gbxHeader.TabIndex = 0;
            this.gbxHeader.Controls.SetChildIndex(this.cboWorkerID_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblWorkerID, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblLineCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblcboUseFlag, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbltxtPlantCodeR, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtLineName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtLineCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkerID, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkerName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboUseFlag_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 90);
            this.gbxBody.Size = new System.Drawing.Size(1136, 688);
            // 
            // lblcboUseFlag
            // 
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblcboUseFlag.Appearance = appearance1;
            this.lblcboUseFlag.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblcboUseFlag.DbField = "cboUseFlag";
            this.lblcboUseFlag.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcboUseFlag.Location = new System.Drawing.Point(586, 51);
            this.lblcboUseFlag.Name = "lblcboUseFlag";
            this.lblcboUseFlag.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblcboUseFlag.Size = new System.Drawing.Size(90, 25);
            this.lblcboUseFlag.TabIndex = 35;
            this.lblcboUseFlag.Text = "사용여부";
            // 
            // lblWorkerID
            // 
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblWorkerID.Appearance = appearance2;
            this.lblWorkerID.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWorkerID.DbField = "WorkerID";
            this.lblWorkerID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkerID.Location = new System.Drawing.Point(586, 15);
            this.lblWorkerID.Name = "lblWorkerID";
            this.lblWorkerID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWorkerID.Size = new System.Drawing.Size(90, 25);
            this.lblWorkerID.TabIndex = 34;
            this.lblWorkerID.Text = "작업자명";
            // 
            // lblLineCode
            // 
            appearance45.TextHAlignAsString = "Right";
            appearance45.TextVAlignAsString = "Middle";
            this.lblLineCode.Appearance = appearance45;
            this.lblLineCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblLineCode.DbField = "WorkCenterCode";
            this.lblLineCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLineCode.Location = new System.Drawing.Point(51, 51);
            this.lblLineCode.Name = "lblLineCode";
            this.lblLineCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblLineCode.Size = new System.Drawing.Size(90, 25);
            this.lblLineCode.TabIndex = 33;
            this.lblLineCode.Text = "라인";
            // 
            // cboWorkerID_H
            // 
            this.cboWorkerID_H.AutoSize = false;
            this.cboWorkerID_H.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboWorkerID_H.ComboDataType = WIZ.Control.ComboDataType.All;
            this.cboWorkerID_H.DbConfig = null;
            this.cboWorkerID_H.DefaultValue = "";
            appearance43.BackColor = System.Drawing.SystemColors.Window;
            appearance43.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboWorkerID_H.DisplayLayout.Appearance = appearance43;
            this.cboWorkerID_H.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.cboWorkerID_H.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboWorkerID_H.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance47.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance47.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance47.BorderColor = System.Drawing.SystemColors.Window;
            this.cboWorkerID_H.DisplayLayout.GroupByBox.Appearance = appearance47;
            appearance48.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboWorkerID_H.DisplayLayout.GroupByBox.BandLabelAppearance = appearance48;
            this.cboWorkerID_H.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance53.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance53.BackColor2 = System.Drawing.SystemColors.Control;
            appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance53.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboWorkerID_H.DisplayLayout.GroupByBox.PromptAppearance = appearance53;
            this.cboWorkerID_H.DisplayLayout.MaxColScrollRegions = 1;
            this.cboWorkerID_H.DisplayLayout.MaxRowScrollRegions = 1;
            appearance62.BackColor = System.Drawing.SystemColors.Window;
            appearance62.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboWorkerID_H.DisplayLayout.Override.ActiveCellAppearance = appearance62;
            appearance63.BackColor = System.Drawing.SystemColors.Highlight;
            appearance63.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cboWorkerID_H.DisplayLayout.Override.ActiveRowAppearance = appearance63;
            this.cboWorkerID_H.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cboWorkerID_H.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cboWorkerID_H.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            appearance65.BackColor = System.Drawing.SystemColors.Window;
            this.cboWorkerID_H.DisplayLayout.Override.CardAreaAppearance = appearance65;
            appearance66.BorderColor = System.Drawing.Color.Silver;
            appearance66.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cboWorkerID_H.DisplayLayout.Override.CellAppearance = appearance66;
            this.cboWorkerID_H.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cboWorkerID_H.DisplayLayout.Override.CellPadding = 0;
            appearance67.BackColor = System.Drawing.SystemColors.Control;
            appearance67.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance67.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance67.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance67.BorderColor = System.Drawing.SystemColors.Window;
            this.cboWorkerID_H.DisplayLayout.Override.GroupByRowAppearance = appearance67;
            appearance72.TextHAlignAsString = "Left";
            this.cboWorkerID_H.DisplayLayout.Override.HeaderAppearance = appearance72;
            this.cboWorkerID_H.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cboWorkerID_H.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance77.BackColor = System.Drawing.SystemColors.Window;
            appearance77.BorderColor = System.Drawing.Color.Silver;
            this.cboWorkerID_H.DisplayLayout.Override.RowAppearance = appearance77;
            this.cboWorkerID_H.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(133)))), ((int)(((byte)(188)))));
            this.cboWorkerID_H.DisplayLayout.Override.SelectedRowAppearance = appearance78;
            appearance79.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboWorkerID_H.DisplayLayout.Override.TemplateAddRowAppearance = appearance79;
            this.cboWorkerID_H.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cboWorkerID_H.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cboWorkerID_H.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.cboWorkerID_H.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cboWorkerID_H.DisplayMember = "CodeName";
            this.cboWorkerID_H.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cboWorkerID_H.EmptyFlag = WIZ.Control.ComboDataTypeYN.Yes;
            this.cboWorkerID_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboWorkerID_H.Location = new System.Drawing.Point(426, 318);
            this.cboWorkerID_H.MajorCode = null;
            this.cboWorkerID_H.Name = "cboWorkerID_H";
            this.cboWorkerID_H.ShowDefaultValue = false;
            this.cboWorkerID_H.Size = new System.Drawing.Size(184, 26);
            this.cboWorkerID_H.TabIndex = 31;
            this.cboWorkerID_H.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cboWorkerID_H.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cboWorkerID_H.ValueMember = "MinorCode";
            // 
            // lbltxtPlantCodeR
            // 
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lbltxtPlantCodeR.Appearance = appearance3;
            this.lbltxtPlantCodeR.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbltxtPlantCodeR.DbField = "cboUseFlag";
            this.lbltxtPlantCodeR.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbltxtPlantCodeR.Location = new System.Drawing.Point(51, 15);
            this.lbltxtPlantCodeR.Name = "lbltxtPlantCodeR";
            this.lbltxtPlantCodeR.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbltxtPlantCodeR.Size = new System.Drawing.Size(90, 25);
            this.lbltxtPlantCodeR.TabIndex = 193;
            this.lbltxtPlantCodeR.Text = "공장";
            // 
            // txtLineCode
            // 
            this.txtLineCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLineCode.Location = new System.Drawing.Point(146, 51);
            this.txtLineCode.Name = "txtLineCode";
            this.txtLineCode.Size = new System.Drawing.Size(147, 25);
            this.txtLineCode.TabIndex = 3;
            // 
            // txtLineName
            // 
            this.txtLineName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtLineName.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLineName.Location = new System.Drawing.Point(293, 51);
            this.txtLineName.MaxLength = 30;
            this.txtLineName.Name = "txtLineName";
            this.txtLineName.Size = new System.Drawing.Size(199, 25);
            this.txtLineName.TabIndex = 4;
            // 
            // txtWorkerName
            // 
            this.txtWorkerName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtWorkerName.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.txtWorkerName.Location = new System.Drawing.Point(829, 14);
            this.txtWorkerName.MaxLength = 30;
            this.txtWorkerName.Name = "txtWorkerName";
            this.txtWorkerName.Size = new System.Drawing.Size(199, 27);
            this.txtWorkerName.TabIndex = 2;
            // 
            // txtWorkerID
            // 
            this.txtWorkerID.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.txtWorkerID.Location = new System.Drawing.Point(681, 14);
            this.txtWorkerID.Name = "txtWorkerID";
            this.txtWorkerID.Size = new System.Drawing.Size(148, 27);
            this.txtWorkerID.TabIndex = 1;
            // 
            // cboUseFlag_H
            // 
            this.cboUseFlag_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboUseFlag_H.Location = new System.Drawing.Point(681, 50);
            this.cboUseFlag_H.Name = "cboUseFlag_H";
            this.cboUseFlag_H.Size = new System.Drawing.Size(148, 26);
            this.cboUseFlag_H.TabIndex = 5;
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 15);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(147, 26);
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
            this.grid1.Size = new System.Drawing.Size(1124, 676);
            this.grid1.TabIndex = 1;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // BM2100
            // 
            this.ClientSize = new System.Drawing.Size(1136, 778);
            this.Name = "BM2100";
            this.Text = "라인 기본 작업자";
            this.Load += new System.EventHandler(this.BM2100_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkerID_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseFlag_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.SLabel lblcboUseFlag;
        private Control.SLabel lblLineCode;
        private Control.SLabel lblWorkerID;
        private Control.SCodeComboBox cboWorkerID_H;
        private Control.SLabel lbltxtPlantCodeR;
        private System.Windows.Forms.TextBox txtLineCode;
        private System.Windows.Forms.TextBox txtLineName;
        private System.Windows.Forms.TextBox txtWorkerName;
        private System.Windows.Forms.TextBox txtWorkerID;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboUseFlag_H;
        private Control.Grid grid1;

    }
}

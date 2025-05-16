namespace WIZ.MM
{
    partial class MM1600
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            this.btnMM1600 = new System.Windows.Forms.Button();
            this.lblLotQty = new WIZ.Control.SLabel();
            this.lblItemCode2 = new WIZ.Control.SLabel();
            this.lblLotNo = new WIZ.Control.SLabel();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.txtLotQty = new System.Windows.Forms.TextBox();
            this.txtDivLotCount = new System.Windows.Forms.TextBox();
            this.txtItemCode2 = new System.Windows.Forms.TextBox();
            this.txtItemName2 = new System.Windows.Forms.TextBox();
            this.lblDivLotCount = new WIZ.Control.SLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtMatLotNo = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.lblItemName = new WIZ.Control.SLabel();
            this.lblMatLotNo = new WIZ.Control.SLabel();
            this.cboItemCode_H1 = new WIZ.Control.ScboGetItemCode();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grid1 = new WIZ.Control.Grid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemCode_H1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.gbxHeader.Controls.Add(this.txtMatLotNo);
            this.gbxHeader.Controls.Add(this.txtItemName);
            this.gbxHeader.Controls.Add(this.txtItemCode);
            this.gbxHeader.Controls.Add(this.lblMatLotNo);
            this.gbxHeader.Controls.Add(this.lblItemName);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 55);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblItemName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblMatLotNo, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtMatLotNo, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxBody.Location = new System.Drawing.Point(0, 155);
            this.gbxBody.Size = new System.Drawing.Size(1136, 670);
            // 
            // btnMM1600
            // 
            this.btnMM1600.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMM1600.Location = new System.Drawing.Point(930, 50);
            this.btnMM1600.Name = "btnMM1600";
            this.btnMM1600.Size = new System.Drawing.Size(178, 32);
            this.btnMM1600.TabIndex = 5;
            this.btnMM1600.Text = "LOT 분할";
            this.btnMM1600.UseVisualStyleBackColor = true;
            this.btnMM1600.Click += new System.EventHandler(this.btnMM1600_Click);
            // 
            // lblLotQty
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lblLotQty.Appearance = appearance3;
            this.lblLotQty.DbField = "cboUseFlag";
            this.lblLotQty.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLotQty.Location = new System.Drawing.Point(68, 57);
            this.lblLotQty.Name = "lblLotQty";
            this.lblLotQty.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblLotQty.Size = new System.Drawing.Size(100, 25);
            this.lblLotQty.TabIndex = 97;
            this.lblLotQty.Text = "원 LOT 재고수량";
            // 
            // lblItemCode2
            // 
            appearance105.FontData.BoldAsString = "False";
            appearance105.FontData.UnderlineAsString = "False";
            appearance105.ForeColor = System.Drawing.Color.Black;
            appearance105.TextHAlignAsString = "Right";
            appearance105.TextVAlignAsString = "Middle";
            this.lblItemCode2.Appearance = appearance105;
            this.lblItemCode2.DbField = "cboUseFlag";
            this.lblItemCode2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemCode2.Location = new System.Drawing.Point(434, 23);
            this.lblItemCode2.Name = "lblItemCode2";
            this.lblItemCode2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemCode2.Size = new System.Drawing.Size(90, 25);
            this.lblItemCode2.TabIndex = 93;
            this.lblItemCode2.Text = "품목";
            // 
            // lblLotNo
            // 
            appearance15.FontData.BoldAsString = "False";
            appearance15.FontData.UnderlineAsString = "False";
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.lblLotNo.Appearance = appearance15;
            this.lblLotNo.DbField = "cboUseFlag";
            this.lblLotNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLotNo.Location = new System.Drawing.Point(78, 23);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblLotNo.Size = new System.Drawing.Size(90, 25);
            this.lblLotNo.TabIndex = 91;
            this.lblLotNo.Text = "원 LOT NO.";
            // 
            // txtLotNo
            // 
            this.txtLotNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtLotNo.Location = new System.Drawing.Point(173, 23);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(178, 25);
            this.txtLotNo.TabIndex = 0;
            // 
            // txtLotQty
            // 
            this.txtLotQty.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtLotQty.Location = new System.Drawing.Point(173, 57);
            this.txtLotQty.Name = "txtLotQty";
            this.txtLotQty.Size = new System.Drawing.Size(178, 25);
            this.txtLotQty.TabIndex = 3;
            // 
            // txtDivLotCount
            // 
            this.txtDivLotCount.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtDivLotCount.Location = new System.Drawing.Point(529, 57);
            this.txtDivLotCount.Name = "txtDivLotCount";
            this.txtDivLotCount.Size = new System.Drawing.Size(114, 25);
            this.txtDivLotCount.TabIndex = 4;
            // 
            // txtItemCode2
            // 
            this.txtItemCode2.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemCode2.Location = new System.Drawing.Point(529, 22);
            this.txtItemCode2.Name = "txtItemCode2";
            this.txtItemCode2.Size = new System.Drawing.Size(114, 25);
            this.txtItemCode2.TabIndex = 1;
            // 
            // txtItemName2
            // 
            this.txtItemName2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtItemName2.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemName2.Location = new System.Drawing.Point(643, 22);
            this.txtItemName2.Name = "txtItemName2";
            this.txtItemName2.Size = new System.Drawing.Size(178, 25);
            this.txtItemName2.TabIndex = 2;
            // 
            // lblDivLotCount
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblDivLotCount.Appearance = appearance1;
            this.lblDivLotCount.DbField = "cboUseFlag";
            this.lblDivLotCount.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDivLotCount.Location = new System.Drawing.Point(434, 57);
            this.lblDivLotCount.Name = "lblDivLotCount";
            this.lblDivLotCount.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDivLotCount.Size = new System.Drawing.Size(90, 25);
            this.lblDivLotCount.TabIndex = 103;
            this.lblDivLotCount.Text = "분할 LOT 수";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLotNo);
            this.groupBox1.Controls.Add(this.txtLotQty);
            this.groupBox1.Controls.Add(this.lblLotNo);
            this.groupBox1.Controls.Add(this.txtDivLotCount);
            this.groupBox1.Controls.Add(this.lblItemCode2);
            this.groupBox1.Controls.Add(this.txtItemCode2);
            this.groupBox1.Controls.Add(this.lblLotQty);
            this.groupBox1.Controls.Add(this.txtItemName2);
            this.groupBox1.Controls.Add(this.btnMM1600);
            this.groupBox1.Controls.Add(this.lblDivLotCount);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1136, 95);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "분할LOT 정보등록";
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 12);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(135, 29);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // txtMatLotNo
            // 
            this.txtMatLotNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtMatLotNo.Location = new System.Drawing.Point(862, 15);
            this.txtMatLotNo.Name = "txtMatLotNo";
            this.txtMatLotNo.Size = new System.Drawing.Size(178, 25);
            this.txtMatLotNo.TabIndex = 3;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemCode.Location = new System.Drawing.Point(412, 15);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(114, 25);
            this.txtItemCode.TabIndex = 1;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtItemName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemName.Location = new System.Drawing.Point(526, 15);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(178, 25);
            this.txtItemName.TabIndex = 2;
            // 
            // lblPlantCode
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance2;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(51, 15);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(90, 25);
            this.lblPlantCode.TabIndex = 120;
            this.lblPlantCode.Text = "사업장";
            // 
            // lblItemName
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.lblItemName.Appearance = appearance4;
            this.lblItemName.DbField = "cboUseFlag";
            this.lblItemName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemName.Location = new System.Drawing.Point(317, 15);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemName.Size = new System.Drawing.Size(90, 25);
            this.lblItemName.TabIndex = 119;
            this.lblItemName.Text = "품목";
            // 
            // lblMatLotNo
            // 
            appearance16.FontData.BoldAsString = "False";
            appearance16.FontData.UnderlineAsString = "False";
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.lblMatLotNo.Appearance = appearance16;
            this.lblMatLotNo.DbField = "cboUseFlag";
            this.lblMatLotNo.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblMatLotNo.Location = new System.Drawing.Point(767, 15);
            this.lblMatLotNo.Name = "lblMatLotNo";
            this.lblMatLotNo.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblMatLotNo.Size = new System.Drawing.Size(90, 25);
            this.lblMatLotNo.TabIndex = 114;
            this.lblMatLotNo.Text = "LOT NO.";
            // 
            // cboItemCode_H1
            // 
            this.cboItemCode_H1.ComboDataType = WIZ.Control.ComboDataType.All;
            this.cboItemCode_H1.DataMember = "dTable1";
            this.cboItemCode_H1.DbConfig = null;
            this.cboItemCode_H1.DefaultValue = "";
            appearance63.BackColor = System.Drawing.SystemColors.Window;
            appearance63.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboItemCode_H1.DisplayLayout.Appearance = appearance63;
            this.cboItemCode_H1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.cboItemCode_H1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboItemCode_H1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance64.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance64.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance64.BorderColor = System.Drawing.SystemColors.Window;
            this.cboItemCode_H1.DisplayLayout.GroupByBox.Appearance = appearance64;
            appearance65.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboItemCode_H1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance65;
            this.cboItemCode_H1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance66.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance66.BackColor2 = System.Drawing.SystemColors.Control;
            appearance66.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance66.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboItemCode_H1.DisplayLayout.GroupByBox.PromptAppearance = appearance66;
            this.cboItemCode_H1.DisplayLayout.MaxColScrollRegions = 1;
            this.cboItemCode_H1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance67.BackColor = System.Drawing.SystemColors.Window;
            appearance67.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboItemCode_H1.DisplayLayout.Override.ActiveCellAppearance = appearance67;
            appearance68.BackColor = System.Drawing.SystemColors.Highlight;
            appearance68.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cboItemCode_H1.DisplayLayout.Override.ActiveRowAppearance = appearance68;
            this.cboItemCode_H1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cboItemCode_H1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance69.BackColor = System.Drawing.SystemColors.Window;
            this.cboItemCode_H1.DisplayLayout.Override.CardAreaAppearance = appearance69;
            appearance70.BorderColor = System.Drawing.Color.Silver;
            appearance70.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cboItemCode_H1.DisplayLayout.Override.CellAppearance = appearance70;
            this.cboItemCode_H1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cboItemCode_H1.DisplayLayout.Override.CellPadding = 0;
            appearance71.BackColor = System.Drawing.SystemColors.Control;
            appearance71.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance71.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance71.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance71.BorderColor = System.Drawing.SystemColors.Window;
            this.cboItemCode_H1.DisplayLayout.Override.GroupByRowAppearance = appearance71;
            appearance72.TextHAlignAsString = "Left";
            this.cboItemCode_H1.DisplayLayout.Override.HeaderAppearance = appearance72;
            this.cboItemCode_H1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cboItemCode_H1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance73.BackColor = System.Drawing.SystemColors.Window;
            appearance73.BorderColor = System.Drawing.Color.Silver;
            this.cboItemCode_H1.DisplayLayout.Override.RowAppearance = appearance73;
            this.cboItemCode_H1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboItemCode_H1.DisplayLayout.Override.TemplateAddRowAppearance = appearance8;
            this.cboItemCode_H1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cboItemCode_H1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cboItemCode_H1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cboItemCode_H1.DisplayMember = "ItemName";
            this.cboItemCode_H1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboItemCode_H1.ItemType = null;
            this.cboItemCode_H1.Location = new System.Drawing.Point(142, 22);
            this.cboItemCode_H1.Name = "cboItemCode_H1";
            this.cboItemCode_H1.PlantCode = null;
            this.cboItemCode_H1.ShowDefaultValue = false;
            this.cboItemCode_H1.Size = new System.Drawing.Size(160, 28);
            this.cboItemCode_H1.TabIndex = 95;
            this.cboItemCode_H1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cboItemCode_H1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cboItemCode_H1.ValueMember = "ItemCode";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1136, 95);
            this.panel1.TabIndex = 3;
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
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            appearance21.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance21;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance22.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance22.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance22;
            appearance23.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance23;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance24.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance24.BackColor2 = System.Drawing.SystemColors.Control;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance24.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance24;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance25.BackColor = System.Drawing.SystemColors.Window;
            appearance25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance25;
            appearance26.BackColor = System.Drawing.SystemColors.Highlight;
            appearance26.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance26;
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
            appearance27.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance27;
            appearance28.BorderColor = System.Drawing.Color.Silver;
            appearance28.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance28;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance29.BackColor = System.Drawing.SystemColors.Control;
            appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance29.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance29.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance29;
            appearance32.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance32;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance38.BackColor = System.Drawing.SystemColors.Window;
            appearance38.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance38;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance41.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance41;
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
            this.grid1.TabIndex = 3;
            this.grid1.Text = "grid6";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // MM1600
            // 
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Controls.Add(this.panel1);
            this.Name = "MM1600";
            this.Text = "자재 LOT 분할 관리";
            this.Load += new System.EventHandler(this.MM1600_Load);
            this.Controls.SetChildIndex(this.gbxHeader, 0);
            this.Controls.SetChildIndex(this.gbxBody, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemCode_H1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMM1600;
        private Control.SLabel lblLotQty;
        private Control.SLabel lblItemCode2;
        private Control.SLabel lblLotNo;
        private Control.SLabel lblDivLotCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private Control.ScboGetItemCode cboItemCode_H1;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.TextBox txtItemName;
        private Control.SLabel lblPlantCode;
        private Control.SLabel lblItemName;
        private Control.SLabel lblMatLotNo;
        private System.Windows.Forms.TextBox txtItemCode2;
        private System.Windows.Forms.TextBox txtItemName2;
        private System.Windows.Forms.TextBox txtMatLotNo;
        private System.Windows.Forms.TextBox txtDivLotCount;
        private System.Windows.Forms.TextBox txtLotNo;
        private System.Windows.Forms.TextBox txtLotQty;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private System.Windows.Forms.Panel panel1;
        private Control.Grid grid1;
    }
}

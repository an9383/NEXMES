namespace WIZ.PopUp
{
    partial class POP_MM0510
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POP_MM0510));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cboWhCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboStorageLocCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblWhCode = new WIZ.Control.SLabel();
            this.lblStorageLocCode = new WIZ.Control.SLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.cboPlantCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtUnitCode = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblUnitCode = new WIZ.Control.SLabel();
            this.lblStorageLocCode_H = new WIZ.Control.SLabel();
            this.lblItemCode = new WIZ.Control.SLabel();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.lblQty = new WIZ.Control.SLabel();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.lblLotNo = new WIZ.Control.SLabel();
            this.lblWhCode_H = new WIZ.Control.SLabel();
            this.txtWhCode = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtStorageLocCode = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboWhCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStorageLocCode)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 463);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 56);
            this.panel1.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.btnPrint.Location = new System.Drawing.Point(546, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(102, 46);
            this.btnPrint.TabIndex = 558;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "바코드 발행";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.btnClose.Location = new System.Drawing.Point(762, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 46);
            this.btnClose.TabIndex = 557;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.btnSave.Location = new System.Drawing.Point(654, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 46);
            this.btnSave.TabIndex = 556;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "병합 등록";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grid1);
            this.panel2.Controls.Add(this.ultraGroupBox1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(876, 463);
            this.panel2.TabIndex = 1;
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
            appearance20.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance20;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance21.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance21.BackColor2 = System.Drawing.SystemColors.Control;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance21;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance22;
            appearance23.BackColor = System.Drawing.SystemColors.Highlight;
            appearance23.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance23;
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
            appearance25.BorderColor = System.Drawing.Color.Silver;
            appearance25.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance25;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance26.BackColor = System.Drawing.SystemColors.Control;
            appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance26.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance26.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance26;
            appearance27.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance27;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance51.BackColor = System.Drawing.SystemColors.Window;
            appearance51.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance51;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance80.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance80;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(0, 234);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(876, 229);
            this.grid1.TabIndex = 2;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.cboWhCode);
            this.ultraGroupBox1.Controls.Add(this.cboStorageLocCode);
            this.ultraGroupBox1.Controls.Add(this.lblWhCode);
            this.ultraGroupBox1.Controls.Add(this.lblStorageLocCode);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 152);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(876, 82);
            this.ultraGroupBox1.TabIndex = 3;
            this.ultraGroupBox1.Text = "필수 입력";
            // 
            // cboWhCode
            // 
            this.cboWhCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboWhCode.Location = new System.Drawing.Point(13, 47);
            this.cboWhCode.Name = "cboWhCode";
            this.cboWhCode.Size = new System.Drawing.Size(189, 27);
            this.cboWhCode.TabIndex = 234;
            this.cboWhCode.ValueChanged += new System.EventHandler(this.cboWhCode_B_ValueChanged);
            // 
            // cboStorageLocCode
            // 
            this.cboStorageLocCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboStorageLocCode.Location = new System.Drawing.Point(231, 47);
            this.cboStorageLocCode.Name = "cboStorageLocCode";
            this.cboStorageLocCode.Size = new System.Drawing.Size(168, 27);
            this.cboStorageLocCode.TabIndex = 236;
            // 
            // lblWhCode
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.SizeInPoints = 9.75F;
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lblWhCode.Appearance = appearance2;
            this.lblWhCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWhCode.DbField = null;
            this.lblWhCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWhCode.Location = new System.Drawing.Point(13, 21);
            this.lblWhCode.Name = "lblWhCode";
            this.lblWhCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWhCode.Size = new System.Drawing.Size(189, 25);
            this.lblWhCode.TabIndex = 233;
            this.lblWhCode.Text = "창고";
            // 
            // lblStorageLocCode
            // 
            appearance16.BackColor = System.Drawing.Color.Transparent;
            appearance16.FontData.BoldAsString = "False";
            appearance16.FontData.SizeInPoints = 9.75F;
            appearance16.FontData.UnderlineAsString = "False";
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.lblStorageLocCode.Appearance = appearance16;
            this.lblStorageLocCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblStorageLocCode.DbField = null;
            this.lblStorageLocCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStorageLocCode.Location = new System.Drawing.Point(231, 21);
            this.lblStorageLocCode.Name = "lblStorageLocCode";
            this.lblStorageLocCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblStorageLocCode.Size = new System.Drawing.Size(168, 25);
            this.lblStorageLocCode.TabIndex = 235;
            this.lblStorageLocCode.Text = "저장위치";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ultraGroupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(876, 152);
            this.panel3.TabIndex = 0;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.chkPrint);
            this.ultraGroupBox2.Controls.Add(this.cboPlantCode);
            this.ultraGroupBox2.Controls.Add(this.txtUnitCode);
            this.ultraGroupBox2.Controls.Add(this.txtQty);
            this.ultraGroupBox2.Controls.Add(this.lblUnitCode);
            this.ultraGroupBox2.Controls.Add(this.lblStorageLocCode_H);
            this.ultraGroupBox2.Controls.Add(this.lblItemCode);
            this.ultraGroupBox2.Controls.Add(this.txtLotNo);
            this.ultraGroupBox2.Controls.Add(this.lblQty);
            this.ultraGroupBox2.Controls.Add(this.lblPlantCode);
            this.ultraGroupBox2.Controls.Add(this.lblLotNo);
            this.ultraGroupBox2.Controls.Add(this.lblWhCode_H);
            this.ultraGroupBox2.Controls.Add(this.txtWhCode);
            this.ultraGroupBox2.Controls.Add(this.txtItemName);
            this.ultraGroupBox2.Controls.Add(this.txtStorageLocCode);
            this.ultraGroupBox2.Controls.Add(this.txtItemCode);
            this.ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(876, 152);
            this.ultraGroupBox2.TabIndex = 0;
            this.ultraGroupBox2.Text = "LOT 정보";
            // 
            // chkPrint
            // 
            this.chkPrint.BackColor = System.Drawing.Color.Transparent;
            this.chkPrint.Checked = true;
            this.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrint.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkPrint.Location = new System.Drawing.Point(663, 107);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(115, 22);
            this.chkPrint.TabIndex = 231;
            this.chkPrint.Text = "등록동시발행";
            this.chkPrint.UseVisualStyleBackColor = false;
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.Enabled = false;
            this.cboPlantCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode.Location = new System.Drawing.Point(13, 47);
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.ReadOnly = true;
            this.cboPlantCode.Size = new System.Drawing.Size(168, 27);
            this.cboPlantCode.TabIndex = 232;
            // 
            // txtUnitCode
            // 
            this.txtUnitCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtUnitCode.Location = new System.Drawing.Point(546, 107);
            this.txtUnitCode.MaxLength = 100;
            this.txtUnitCode.Name = "txtUnitCode";
            this.txtUnitCode.ReadOnly = true;
            this.txtUnitCode.Size = new System.Drawing.Size(91, 25);
            this.txtUnitCode.TabIndex = 113;
            // 
            // txtQty
            // 
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtQty.Location = new System.Drawing.Point(441, 107);
            this.txtQty.MaxLength = 100;
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Size = new System.Drawing.Size(99, 25);
            this.txtQty.TabIndex = 114;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblUnitCode
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.SizeInPoints = 9.75F;
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.lblUnitCode.Appearance = appearance3;
            this.lblUnitCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblUnitCode.DbField = null;
            this.lblUnitCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUnitCode.Location = new System.Drawing.Point(546, 82);
            this.lblUnitCode.Name = "lblUnitCode";
            this.lblUnitCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblUnitCode.Size = new System.Drawing.Size(91, 25);
            this.lblUnitCode.TabIndex = 108;
            this.lblUnitCode.Text = "단위";
            // 
            // lblStorageLocCode_H
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.SizeInPoints = 9.75F;
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.lblStorageLocCode_H.Appearance = appearance1;
            this.lblStorageLocCode_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblStorageLocCode_H.DbField = null;
            this.lblStorageLocCode_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStorageLocCode_H.Location = new System.Drawing.Point(441, 22);
            this.lblStorageLocCode_H.Name = "lblStorageLocCode_H";
            this.lblStorageLocCode_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblStorageLocCode_H.Size = new System.Drawing.Size(196, 25);
            this.lblStorageLocCode_H.TabIndex = 93;
            this.lblStorageLocCode_H.Text = "위치코드";
            // 
            // lblItemCode
            // 
            appearance10.BackColor = System.Drawing.Color.Transparent;
            appearance10.FontData.BoldAsString = "False";
            appearance10.FontData.SizeInPoints = 9.75F;
            appearance10.FontData.UnderlineAsString = "False";
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.lblItemCode.Appearance = appearance10;
            this.lblItemCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblItemCode.DbField = null;
            this.lblItemCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemCode.Location = new System.Drawing.Point(13, 82);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemCode.Size = new System.Drawing.Size(397, 25);
            this.lblItemCode.TabIndex = 94;
            this.lblItemCode.Text = "품목";
            // 
            // txtLotNo
            // 
            this.txtLotNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLotNo.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLotNo.Location = new System.Drawing.Point(663, 47);
            this.txtLotNo.MaxLength = 100;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.ReadOnly = true;
            this.txtLotNo.Size = new System.Drawing.Size(168, 25);
            this.txtLotNo.TabIndex = 100;
            // 
            // lblQty
            // 
            appearance17.BackColor = System.Drawing.Color.Transparent;
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.SizeInPoints = 9.75F;
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Left";
            appearance17.TextVAlignAsString = "Middle";
            this.lblQty.Appearance = appearance17;
            this.lblQty.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblQty.DbField = null;
            this.lblQty.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblQty.Location = new System.Drawing.Point(441, 82);
            this.lblQty.Name = "lblQty";
            this.lblQty.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblQty.Size = new System.Drawing.Size(99, 25);
            this.lblQty.TabIndex = 109;
            this.lblQty.Text = "병합 수량";
            // 
            // lblPlantCode
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.SizeInPoints = 9.75F;
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance5;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(13, 22);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(168, 25);
            this.lblPlantCode.TabIndex = 92;
            this.lblPlantCode.Text = "공장";
            // 
            // lblLotNo
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.FontData.BoldAsString = "False";
            appearance9.FontData.SizeInPoints = 9.75F;
            appearance9.FontData.UnderlineAsString = "False";
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.lblLotNo.Appearance = appearance9;
            this.lblLotNo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblLotNo.DbField = null;
            this.lblLotNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLotNo.Location = new System.Drawing.Point(663, 22);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblLotNo.Size = new System.Drawing.Size(168, 25);
            this.lblLotNo.TabIndex = 95;
            this.lblLotNo.Text = "병합LOT NO";
            // 
            // lblWhCode_H
            // 
            appearance14.BackColor = System.Drawing.Color.Transparent;
            appearance14.FontData.BoldAsString = "False";
            appearance14.FontData.SizeInPoints = 9.75F;
            appearance14.FontData.UnderlineAsString = "False";
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            this.lblWhCode_H.Appearance = appearance14;
            this.lblWhCode_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWhCode_H.DbField = null;
            this.lblWhCode_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWhCode_H.Location = new System.Drawing.Point(206, 22);
            this.lblWhCode_H.Name = "lblWhCode_H";
            this.lblWhCode_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWhCode_H.Size = new System.Drawing.Size(204, 25);
            this.lblWhCode_H.TabIndex = 104;
            this.lblWhCode_H.Text = "창고코드";
            // 
            // txtWhCode
            // 
            this.txtWhCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWhCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWhCode.Location = new System.Drawing.Point(206, 47);
            this.txtWhCode.MaxLength = 100;
            this.txtWhCode.Name = "txtWhCode";
            this.txtWhCode.ReadOnly = true;
            this.txtWhCode.Size = new System.Drawing.Size(204, 25);
            this.txtWhCode.TabIndex = 103;
            // 
            // txtItemName
            // 
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemName.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemName.Location = new System.Drawing.Point(175, 107);
            this.txtItemName.MaxLength = 100;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(235, 25);
            this.txtItemName.TabIndex = 111;
            // 
            // txtStorageLocCode
            // 
            this.txtStorageLocCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStorageLocCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtStorageLocCode.Location = new System.Drawing.Point(441, 47);
            this.txtStorageLocCode.MaxLength = 100;
            this.txtStorageLocCode.Name = "txtStorageLocCode";
            this.txtStorageLocCode.ReadOnly = true;
            this.txtStorageLocCode.Size = new System.Drawing.Size(196, 25);
            this.txtStorageLocCode.TabIndex = 98;
            // 
            // txtItemCode
            // 
            this.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemCode.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemCode.Location = new System.Drawing.Point(13, 107);
            this.txtItemCode.MaxLength = 100;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.ReadOnly = true;
            this.txtItemCode.Size = new System.Drawing.Size(156, 25);
            this.txtItemCode.TabIndex = 99;
            // 
            // POP_MM0510
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 519);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "POP_MM0510";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOT 병합";
            this.Load += new System.EventHandler(this.POP_MM0510_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboWhCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStorageLocCode)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox txtQty;
        public System.Windows.Forms.TextBox txtUnitCode;
        public System.Windows.Forms.TextBox txtItemName;
        private Control.SLabel lblQty;
        private Control.SLabel lblUnitCode;
        private Control.SLabel lblWhCode_H;
        public System.Windows.Forms.TextBox txtWhCode;
        public System.Windows.Forms.TextBox txtLotNo;
        public System.Windows.Forms.TextBox txtItemCode;
        public System.Windows.Forms.TextBox txtStorageLocCode;
        private Control.SLabel lblLotNo;
        private Control.SLabel lblItemCode;
        private Control.SLabel lblStorageLocCode_H;
        private Control.SLabel lblPlantCode;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private Control.Grid grid1;
        private System.Windows.Forms.CheckBox chkPrint;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboStorageLocCode;
        private Control.SLabel lblStorageLocCode;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboWhCode;
        private Control.SLabel lblWhCode;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private System.IO.Ports.SerialPort serialPort1;
    }
}
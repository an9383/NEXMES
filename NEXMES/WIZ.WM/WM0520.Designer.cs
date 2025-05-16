namespace WIZ.WM
{
    partial class WM0520
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
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.lblLotNo = new WIZ.Control.SLabel();
            this.cboPlantCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnPrint = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.btnPoInfo_H = new Infragistics.Win.Misc.UltraButton();
            this.cboIndate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.sLabel7 = new WIZ.Control.SLabel();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new WIZ.Control.SLabel();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.txtItemCode_H = new System.Windows.Forms.TextBox();
            this.txtItemName_H = new System.Windows.Forms.TextBox();
            this.lblPrint = new WIZ.Control.SLabel();
            this.txtUnitCode = new System.Windows.Forms.TextBox();
            this.lblItemName = new WIZ.Control.SLabel();
            this.cboStoreageLocCodeI = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblStoreageLocCodeI = new WIZ.Control.SLabel();
            this.txtWorkerID = new System.Windows.Forms.TextBox();
            this.txtWorkerNM = new System.Windows.Forms.TextBox();
            this.txtWorkCenterCode = new System.Windows.Forms.TextBox();
            this.txtWorkCenterName = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new WIZ.Control.SLabel();
            this.cboWhCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblUnitCode = new WIZ.Control.SLabel();
            this.lblWorkerID = new WIZ.Control.SLabel();
            this.lblWorkCenterCode = new WIZ.Control.SLabel();
            this.lblWhCode = new WIZ.Control.SLabel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboIndate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStoreageLocCodeI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWhCode)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 0);
            this.gbxHeader.Visible = false;
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.tableLayoutPanel2);
            this.gbxBody.Location = new System.Drawing.Point(0, 0);
            this.gbxBody.Size = new System.Drawing.Size(1136, 778);
            // 
            // txtLotNo
            // 
            this.txtLotNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtLotNo.Location = new System.Drawing.Point(144, 114);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.ReadOnly = true;
            this.txtLotNo.Size = new System.Drawing.Size(299, 25);
            this.txtLotNo.TabIndex = 237;
            // 
            // lblLotNo
            // 
            appearance22.FontData.BoldAsString = "False";
            appearance22.FontData.UnderlineAsString = "False";
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.TextHAlignAsString = "Right";
            appearance22.TextVAlignAsString = "Middle";
            this.lblLotNo.Appearance = appearance22;
            this.lblLotNo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblLotNo.DbField = null;
            this.lblLotNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLotNo.Location = new System.Drawing.Point(41, 113);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblLotNo.Size = new System.Drawing.Size(100, 25);
            this.lblLotNo.TabIndex = 238;
            this.lblLotNo.Text = " LOT NO.";
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode.Location = new System.Drawing.Point(78, 77);
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.Size = new System.Drawing.Size(150, 27);
            this.cboPlantCode.TabIndex = 1;
            this.cboPlantCode.Text = "cboPlantCode";
            // 
            // lblPlantCode
            // 
            appearance24.FontData.BoldAsString = "False";
            appearance24.FontData.UnderlineAsString = "False";
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.TextHAlignAsString = "Right";
            appearance24.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance24;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(6, 78);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(67, 25);
            this.lblPlantCode.TabIndex = 231;
            this.lblPlantCode.Text = "사업장";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.ultraGroupBox3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ultraGroupBox2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1124, 766);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // ultraGroupBox3
            // 
            appearance16.BackColor = System.Drawing.Color.Snow;
            this.ultraGroupBox3.Appearance = appearance16;
            this.ultraGroupBox3.Controls.Add(this.txtLotNo);
            this.ultraGroupBox3.Controls.Add(this.lblLotNo);
            this.ultraGroupBox3.Controls.Add(this.btnPrint);
            this.ultraGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox3.Location = new System.Drawing.Point(3, 386);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(1118, 377);
            this.ultraGroupBox3.TabIndex = 10;
            this.ultraGroupBox3.Text = "LOT 생성 정보";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrint.Location = new System.Drawing.Point(458, 110);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(67, 34);
            this.btnPrint.TabIndex = 590;
            this.btnPrint.Text = "발행";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.ultraButton1);
            this.ultraGroupBox2.Controls.Add(this.btnPoInfo_H);
            this.ultraGroupBox2.Controls.Add(this.cboIndate_H);
            this.ultraGroupBox2.Controls.Add(this.sLabel7);
            this.ultraGroupBox2.Controls.Add(this.txtOrderNo);
            this.ultraGroupBox2.Controls.Add(this.lblOrderNo);
            this.ultraGroupBox2.Controls.Add(this.chkPrint);
            this.ultraGroupBox2.Controls.Add(this.txtItemCode_H);
            this.ultraGroupBox2.Controls.Add(this.txtItemName_H);
            this.ultraGroupBox2.Controls.Add(this.lblPrint);
            this.ultraGroupBox2.Controls.Add(this.txtUnitCode);
            this.ultraGroupBox2.Controls.Add(this.lblItemName);
            this.ultraGroupBox2.Controls.Add(this.cboStoreageLocCodeI);
            this.ultraGroupBox2.Controls.Add(this.lblStoreageLocCodeI);
            this.ultraGroupBox2.Controls.Add(this.txtWorkerID);
            this.ultraGroupBox2.Controls.Add(this.txtWorkerNM);
            this.ultraGroupBox2.Controls.Add(this.txtWorkCenterCode);
            this.ultraGroupBox2.Controls.Add(this.cboPlantCode);
            this.ultraGroupBox2.Controls.Add(this.txtWorkCenterName);
            this.ultraGroupBox2.Controls.Add(this.txtQty);
            this.ultraGroupBox2.Controls.Add(this.lblQty);
            this.ultraGroupBox2.Controls.Add(this.cboWhCode);
            this.ultraGroupBox2.Controls.Add(this.lblUnitCode);
            this.ultraGroupBox2.Controls.Add(this.lblWorkerID);
            this.ultraGroupBox2.Controls.Add(this.lblWorkCenterCode);
            this.ultraGroupBox2.Controls.Add(this.lblPlantCode);
            this.ultraGroupBox2.Controls.Add(this.lblWhCode);
            this.ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox2.Location = new System.Drawing.Point(3, 3);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(1118, 377);
            this.ultraGroupBox2.TabIndex = 8;
            this.ultraGroupBox2.Text = "LOT 입력 정보";
            // 
            // ultraButton1
            // 
            this.ultraButton1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ultraButton1.Location = new System.Drawing.Point(553, 262);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(152, 34);
            this.ultraButton1.TabIndex = 621;
            this.ultraButton1.Text = "초기화";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click_1);
            // 
            // btnPoInfo_H
            // 
            this.btnPoInfo_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPoInfo_H.Location = new System.Drawing.Point(707, 76);
            this.btnPoInfo_H.Name = "btnPoInfo_H";
            this.btnPoInfo_H.Size = new System.Drawing.Size(195, 28);
            this.btnPoInfo_H.TabIndex = 591;
            this.btnPoInfo_H.Text = "작업 지시 가져오기";
            this.btnPoInfo_H.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // cboIndate_H
            // 
            this.cboIndate_H.DateButtons.Add(dateButton1);
            this.cboIndate_H.Location = new System.Drawing.Point(311, 77);
            this.cboIndate_H.Name = "cboIndate_H";
            this.cboIndate_H.NonAutoSizeHeight = 26;
            this.cboIndate_H.Size = new System.Drawing.Size(116, 26);
            this.cboIndate_H.TabIndex = 50;
            // 
            // sLabel7
            // 
            appearance82.FontData.BoldAsString = "False";
            appearance82.FontData.UnderlineAsString = "False";
            appearance82.ForeColor = System.Drawing.Color.Black;
            appearance82.TextHAlignAsString = "Right";
            appearance82.TextVAlignAsString = "Middle";
            this.sLabel7.Appearance = appearance82;
            this.sLabel7.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel7.DbField = null;
            this.sLabel7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel7.Location = new System.Drawing.Point(236, 78);
            this.sLabel7.Name = "sLabel7";
            this.sLabel7.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel7.Size = new System.Drawing.Size(70, 25);
            this.sLabel7.TabIndex = 51;
            this.sLabel7.Text = "입고일";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Location = new System.Drawing.Point(553, 76);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.ReadOnly = true;
            this.txtOrderNo.Size = new System.Drawing.Size(148, 27);
            this.txtOrderNo.TabIndex = 619;
            // 
            // lblOrderNo
            // 
            appearance13.FontData.BoldAsString = "False";
            appearance13.FontData.UnderlineAsString = "False";
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Right";
            appearance13.TextVAlignAsString = "Middle";
            this.lblOrderNo.Appearance = appearance13;
            this.lblOrderNo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblOrderNo.DbField = null;
            this.lblOrderNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderNo.Location = new System.Drawing.Point(458, 78);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblOrderNo.Size = new System.Drawing.Size(90, 25);
            this.lblOrderNo.TabIndex = 620;
            this.lblOrderNo.Text = "작업지시";
            // 
            // chkPrint
            // 
            this.chkPrint.BackColor = System.Drawing.Color.Transparent;
            this.chkPrint.Checked = true;
            this.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrint.Location = new System.Drawing.Point(553, 224);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(20, 22);
            this.chkPrint.TabIndex = 233;
            this.chkPrint.UseVisualStyleBackColor = false;
            // 
            // txtItemCode_H
            // 
            this.txtItemCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemCode_H.Location = new System.Drawing.Point(553, 113);
            this.txtItemCode_H.Name = "txtItemCode_H";
            this.txtItemCode_H.Size = new System.Drawing.Size(150, 25);
            this.txtItemCode_H.TabIndex = 617;
            this.txtItemCode_H.TextChanged += new System.EventHandler(this.txtItemCode_H_TextChanged);
            // 
            // txtItemName_H
            // 
            this.txtItemName_H.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtItemName_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemName_H.Location = new System.Drawing.Point(703, 113);
            this.txtItemName_H.Name = "txtItemName_H";
            this.txtItemName_H.ReadOnly = true;
            this.txtItemName_H.Size = new System.Drawing.Size(199, 25);
            this.txtItemName_H.TabIndex = 618;
            // 
            // lblPrint
            // 
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.FontData.BoldAsString = "False";
            appearance15.FontData.UnderlineAsString = "False";
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.lblPrint.Appearance = appearance15;
            this.lblPrint.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPrint.DbField = null;
            this.lblPrint.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPrint.Location = new System.Drawing.Point(458, 222);
            this.lblPrint.Name = "lblPrint";
            this.lblPrint.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPrint.Size = new System.Drawing.Size(90, 25);
            this.lblPrint.TabIndex = 232;
            this.lblPrint.Text = "등록동시발행";
            // 
            // txtUnitCode
            // 
            this.txtUnitCode.Location = new System.Drawing.Point(78, 150);
            this.txtUnitCode.Name = "txtUnitCode";
            this.txtUnitCode.Size = new System.Drawing.Size(148, 27);
            this.txtUnitCode.TabIndex = 615;
            this.txtUnitCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnitCode_KeyPress);
            this.txtUnitCode.Leave += new System.EventHandler(this.txtUnitCode_Leave);
            // 
            // lblItemName
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblItemName.Appearance = appearance2;
            this.lblItemName.DbField = "cboUseFlag";
            this.lblItemName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemName.Location = new System.Drawing.Point(458, 114);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemName.Size = new System.Drawing.Size(90, 25);
            this.lblItemName.TabIndex = 125;
            this.lblItemName.Text = "품목";
            // 
            // cboStoreageLocCodeI
            // 
            this.cboStoreageLocCodeI.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboStoreageLocCodeI.Location = new System.Drawing.Point(553, 186);
            this.cboStoreageLocCodeI.Name = "cboStoreageLocCodeI";
            this.cboStoreageLocCodeI.Size = new System.Drawing.Size(148, 27);
            this.cboStoreageLocCodeI.TabIndex = 611;
            // 
            // lblStoreageLocCodeI
            // 
            appearance32.FontData.BoldAsString = "False";
            appearance32.FontData.UnderlineAsString = "False";
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.TextHAlignAsString = "Right";
            appearance32.TextVAlignAsString = "Middle";
            this.lblStoreageLocCodeI.Appearance = appearance32;
            this.lblStoreageLocCodeI.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblStoreageLocCodeI.DbField = null;
            this.lblStoreageLocCodeI.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStoreageLocCodeI.Location = new System.Drawing.Point(458, 186);
            this.lblStoreageLocCodeI.Name = "lblStoreageLocCodeI";
            this.lblStoreageLocCodeI.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblStoreageLocCodeI.Size = new System.Drawing.Size(90, 25);
            this.lblStoreageLocCodeI.TabIndex = 610;
            this.lblStoreageLocCodeI.Text = "저장 위치";
            // 
            // txtWorkerID
            // 
            this.txtWorkerID.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkerID.Location = new System.Drawing.Point(78, 222);
            this.txtWorkerID.Name = "txtWorkerID";
            this.txtWorkerID.Size = new System.Drawing.Size(150, 25);
            this.txtWorkerID.TabIndex = 607;
            // 
            // txtWorkerNM
            // 
            this.txtWorkerNM.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtWorkerNM.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkerNM.Location = new System.Drawing.Point(228, 222);
            this.txtWorkerNM.Name = "txtWorkerNM";
            this.txtWorkerNM.ReadOnly = true;
            this.txtWorkerNM.Size = new System.Drawing.Size(199, 25);
            this.txtWorkerNM.TabIndex = 608;
            // 
            // txtWorkCenterCode
            // 
            this.txtWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkCenterCode.Location = new System.Drawing.Point(78, 113);
            this.txtWorkCenterCode.Name = "txtWorkCenterCode";
            this.txtWorkCenterCode.Size = new System.Drawing.Size(150, 25);
            this.txtWorkCenterCode.TabIndex = 604;
            this.txtWorkCenterCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWorkCenterCode_KeyPress);
            // 
            // txtWorkCenterName
            // 
            this.txtWorkCenterName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtWorkCenterName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkCenterName.Location = new System.Drawing.Point(228, 113);
            this.txtWorkCenterName.Name = "txtWorkCenterName";
            this.txtWorkCenterName.ReadOnly = true;
            this.txtWorkCenterName.Size = new System.Drawing.Size(199, 25);
            this.txtWorkCenterName.TabIndex = 605;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(553, 149);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(150, 27);
            this.txtQty.TabIndex = 584;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInQty_KeyPress);
            // 
            // lblQty
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblQty.Appearance = appearance1;
            this.lblQty.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblQty.DbField = null;
            this.lblQty.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblQty.Location = new System.Drawing.Point(458, 150);
            this.lblQty.Name = "lblQty";
            this.lblQty.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblQty.Size = new System.Drawing.Size(90, 25);
            this.lblQty.TabIndex = 585;
            this.lblQty.Text = "수량";
            // 
            // cboWhCode
            // 
            this.cboWhCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboWhCode.Location = new System.Drawing.Point(78, 186);
            this.cboWhCode.Name = "cboWhCode";
            this.cboWhCode.Size = new System.Drawing.Size(150, 27);
            this.cboWhCode.TabIndex = 227;
            this.cboWhCode.ValueChanged += new System.EventHandler(this.cboWhCodeI_ValueChanged);
            // 
            // lblUnitCode
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lblUnitCode.Appearance = appearance3;
            this.lblUnitCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblUnitCode.DbField = null;
            this.lblUnitCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUnitCode.Location = new System.Drawing.Point(6, 150);
            this.lblUnitCode.Name = "lblUnitCode";
            this.lblUnitCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblUnitCode.Size = new System.Drawing.Size(67, 25);
            this.lblUnitCode.TabIndex = 616;
            this.lblUnitCode.Text = "단위";
            // 
            // lblWorkerID
            // 
            appearance20.FontData.BoldAsString = "False";
            appearance20.FontData.UnderlineAsString = "False";
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextHAlignAsString = "Right";
            appearance20.TextVAlignAsString = "Middle";
            this.lblWorkerID.Appearance = appearance20;
            this.lblWorkerID.DbField = "cboUseFlag";
            this.lblWorkerID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkerID.Location = new System.Drawing.Point(6, 222);
            this.lblWorkerID.Name = "lblWorkerID";
            this.lblWorkerID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWorkerID.Size = new System.Drawing.Size(67, 25);
            this.lblWorkerID.TabIndex = 609;
            this.lblWorkerID.Text = "생성자";
            // 
            // lblWorkCenterCode
            // 
            appearance19.FontData.BoldAsString = "False";
            appearance19.FontData.UnderlineAsString = "False";
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextHAlignAsString = "Right";
            appearance19.TextVAlignAsString = "Middle";
            this.lblWorkCenterCode.Appearance = appearance19;
            this.lblWorkCenterCode.DbField = "cboUseFlag";
            this.lblWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkCenterCode.Location = new System.Drawing.Point(6, 114);
            this.lblWorkCenterCode.Name = "lblWorkCenterCode";
            this.lblWorkCenterCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWorkCenterCode.Size = new System.Drawing.Size(67, 25);
            this.lblWorkCenterCode.TabIndex = 606;
            this.lblWorkCenterCode.Text = "작업장";
            // 
            // lblWhCode
            // 
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.lblWhCode.Appearance = appearance17;
            this.lblWhCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWhCode.DbField = null;
            this.lblWhCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWhCode.Location = new System.Drawing.Point(6, 186);
            this.lblWhCode.Name = "lblWhCode";
            this.lblWhCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWhCode.Size = new System.Drawing.Size(67, 25);
            this.lblWhCode.TabIndex = 232;
            this.lblWhCode.Text = "창고";
            // 
            // WM0520
            // 
            this.ClientSize = new System.Drawing.Size(1136, 778);
            this.Name = "WM0520";
            this.Text = "신규 LOT 생성 (식별표 포함)";
            this.Load += new System.EventHandler(this.WM0520_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            this.ultraGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboIndate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStoreageLocCodeI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWhCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLotNo;
        private Control.SLabel lblLotNo;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode;
        private Control.SLabel lblPlantCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
        private System.Windows.Forms.TextBox txtWorkCenterCode;
        private System.Windows.Forms.TextBox txtWorkCenterName;
        private Control.SLabel lblWorkCenterCode;
        private Infragistics.Win.Misc.UltraButton btnPrint;
        private System.Windows.Forms.TextBox txtQty;
        private Control.SLabel lblQty;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboWhCode;
        private Control.SLabel lblWhCode;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private System.Windows.Forms.TextBox txtWorkerID;
        private System.Windows.Forms.TextBox txtWorkerNM;
        private Control.SLabel lblWorkerID;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboStoreageLocCodeI;
        private Control.SLabel lblStoreageLocCodeI;
        private Control.SLabel lblItemName;
        private System.Windows.Forms.CheckBox chkPrint;
        private Control.SLabel lblPrint;
        private System.Windows.Forms.TextBox txtUnitCode;
        private Control.SLabel lblUnitCode;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox txtItemCode_H;
        private System.Windows.Forms.TextBox txtItemName_H;
        private System.Windows.Forms.TextBox txtOrderNo;
        private Control.SLabel lblOrderNo;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboIndate_H;
        private Control.SLabel sLabel7;
        private Infragistics.Win.Misc.UltraButton btnPoInfo_H;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
    }
}

using WIZ.Control;

namespace WIZ.QM
{
    partial class QM3210
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            this.gbxMAS = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnConfirm = new Infragistics.Win.Misc.UltraButton();
            this.nupSearchTime = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.rdbAuto = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.rdbManual = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lbltxtToolCodeR = new WIZ.Control.SLabel();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.sLabel38 = new WIZ.Control.SLabel();
            this.txtItemCode_H = new WIZ.Control.SBtnTextEditor();
            this.txtItemName_H = new WIZ.Control.STextBox(this.components);
            this.cboEndDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cboStartDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblDate = new WIZ.Control.SLabel();
            this.btnPrevious = new Infragistics.Win.Misc.UltraButton();
            this.btnNext = new Infragistics.Win.Misc.UltraButton();
            this.lblCnt = new WIZ.Control.SLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.tvInsp = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sLabel15 = new WIZ.Control.SLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxMAS)).BeginInit();
            this.gbxMAS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupSearchTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbAuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbManual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStartDate_H)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.lblCnt);
            this.gbxHeader.Controls.Add(this.btnNext);
            this.gbxHeader.Controls.Add(this.btnPrevious);
            this.gbxHeader.Controls.Add(this.gbxMAS);
            this.gbxHeader.Controls.Add(this.cboStartDate_H);
            this.gbxHeader.Controls.Add(this.cboEndDate_H);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.lblDate);
            this.gbxHeader.Controls.Add(this.txtItemCode_H);
            this.gbxHeader.Controls.Add(this.txtItemName_H);
            this.gbxHeader.Controls.Add(this.lbltxtToolCodeR);
            this.gbxHeader.Controls.Add(this.sLabel38);
            this.gbxHeader.Controls.Add(this.sLabel15);
            this.gbxHeader.Size = new System.Drawing.Size(1594, 73);
            this.gbxHeader.TabIndex = 0;
            this.gbxHeader.Controls.SetChildIndex(this.sLabel15, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel38, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbltxtToolCodeR, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemName_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboEndDate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboStartDate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.gbxMAS, 0);
            this.gbxHeader.Controls.SetChildIndex(this.btnPrevious, 0);
            this.gbxHeader.Controls.SetChildIndex(this.btnNext, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblCnt, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.panel2);
            this.gbxBody.Location = new System.Drawing.Point(0, 73);
            this.gbxBody.Size = new System.Drawing.Size(1594, 526);
            this.gbxBody.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(386, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 514);
            this.panel1.TabIndex = 20;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // ultraSplitter1
            // 
            this.ultraSplitter1.BackColor = System.Drawing.Color.White;
            this.ultraSplitter1.Location = new System.Drawing.Point(371, 0);
            this.ultraSplitter1.Name = "ultraSplitter1";
            this.ultraSplitter1.RestoreExtent = 435;
            this.ultraSplitter1.Size = new System.Drawing.Size(15, 514);
            this.ultraSplitter1.TabIndex = 20;
            this.ultraSplitter1.Click += new System.EventHandler(this.ultraSplitter1_Click);
            this.ultraSplitter1.Move += new System.EventHandler(this.ultraSplitter1_Move);
            // 
            // gbxMAS
            // 
            this.gbxMAS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxMAS.BackColorInternal = System.Drawing.Color.Transparent;
            this.gbxMAS.Controls.Add(this.btnConfirm);
            this.gbxMAS.Controls.Add(this.nupSearchTime);
            this.gbxMAS.Controls.Add(this.rdbAuto);
            this.gbxMAS.Controls.Add(this.rdbManual);
            this.gbxMAS.Location = new System.Drawing.Point(1164, 10);
            this.gbxMAS.Name = "gbxMAS";
            this.gbxMAS.Size = new System.Drawing.Size(238, 53);
            this.gbxMAS.TabIndex = 655;
            this.gbxMAS.Visible = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(146, 12);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(80, 31);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "(분)적용";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // nupSearchTime
            // 
            this.nupSearchTime.Location = new System.Drawing.Point(78, 13);
            this.nupSearchTime.MaskInput = "nnnn";
            this.nupSearchTime.MinValue = 0;
            this.nupSearchTime.Name = "nupSearchTime";
            this.nupSearchTime.Size = new System.Drawing.Size(60, 29);
            this.nupSearchTime.TabIndex = 1;
            this.nupSearchTime.TabStop = false;
            this.nupSearchTime.Value = 1;
            // 
            // rdbAuto
            // 
            this.rdbAuto.BackColor = System.Drawing.Color.Transparent;
            this.rdbAuto.BackColorInternal = System.Drawing.Color.Transparent;
            this.rdbAuto.Checked = true;
            this.rdbAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rdbAuto.Location = new System.Drawing.Point(15, 27);
            this.rdbAuto.Name = "rdbAuto";
            this.rdbAuto.Size = new System.Drawing.Size(57, 24);
            this.rdbAuto.TabIndex = 0;
            this.rdbAuto.Text = "자동";
            this.rdbAuto.CheckedChanged += new System.EventHandler(this.rdbAuto_CheckedChanged);
            // 
            // rdbManual
            // 
            this.rdbManual.Location = new System.Drawing.Point(15, 6);
            this.rdbManual.Name = "rdbManual";
            this.rdbManual.Size = new System.Drawing.Size(57, 24);
            this.rdbManual.TabIndex = 0;
            this.rdbManual.Text = "수동";
            this.rdbManual.CheckedChanged += new System.EventHandler(this.rdbManual_CheckedChanged);
            // 
            // lbltxtToolCodeR
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.SizeInPoints = 9.75F;
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lbltxtToolCodeR.Appearance = appearance2;
            this.lbltxtToolCodeR.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbltxtToolCodeR.DbField = "cboUseFlag";
            this.lbltxtToolCodeR.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbltxtToolCodeR.Location = new System.Drawing.Point(112, 9);
            this.lbltxtToolCodeR.Name = "lbltxtToolCodeR";
            this.lbltxtToolCodeR.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbltxtToolCodeR.Size = new System.Drawing.Size(145, 25);
            this.lbltxtToolCodeR.TabIndex = 647;
            this.lbltxtToolCodeR.Text = "사업장";
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.AutoSize = false;
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(112, 31);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(160, 27);
            this.cboPlantCode_H.TabIndex = 646;
            // 
            // sLabel38
            // 
            appearance33.FontData.BoldAsString = "False";
            appearance33.FontData.SizeInPoints = 9.75F;
            appearance33.FontData.UnderlineAsString = "False";
            appearance33.ForeColor = System.Drawing.Color.Black;
            appearance33.TextHAlignAsString = "Left";
            appearance33.TextVAlignAsString = "Middle";
            this.sLabel38.Appearance = appearance33;
            this.sLabel38.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel38.DbField = null;
            this.sLabel38.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.sLabel38.Location = new System.Drawing.Point(340, 9);
            this.sLabel38.Name = "sLabel38";
            this.sLabel38.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel38.Size = new System.Drawing.Size(145, 25);
            this.sLabel38.TabIndex = 650;
            this.sLabel38.Text = "품목";
            // 
            // txtItemCode_H
            // 
            appearance13.FontData.BoldAsString = "False";
            appearance13.FontData.Name = "맑은 고딕";
            appearance13.FontData.SizeInPoints = 10F;
            appearance13.FontData.UnderlineAsString = "False";
            appearance13.ForeColor = System.Drawing.Color.Black;
            this.txtItemCode_H.Appearance = appearance13;
            this.txtItemCode_H.AutoSize = false;
            this.txtItemCode_H.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txtItemCode_H.btnWidth = 26;
            this.txtItemCode_H.Location = new System.Drawing.Point(340, 31);
            this.txtItemCode_H.Name = "txtItemCode_H";
            this.txtItemCode_H.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtItemCode_H.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtItemCode_H.Size = new System.Drawing.Size(145, 27);
            this.txtItemCode_H.TabIndex = 648;
            // 
            // txtItemName_H
            // 
            appearance29.FontData.BoldAsString = "False";
            appearance29.FontData.UnderlineAsString = "False";
            appearance29.ForeColor = System.Drawing.Color.Black;
            this.txtItemName_H.Appearance = appearance29;
            this.txtItemName_H.AutoSize = false;
            this.txtItemName_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemName_H.Location = new System.Drawing.Point(484, 31);
            this.txtItemName_H.Name = "txtItemName_H";
            this.txtItemName_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtItemName_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtItemName_H.Size = new System.Drawing.Size(200, 27);
            this.txtItemName_H.TabIndex = 649;
            // 
            // cboEndDate_H
            // 
            this.cboEndDate_H.AutoSize = false;
            this.cboEndDate_H.DateButtons.Add(dateButton2);
            this.cboEndDate_H.Location = new System.Drawing.Point(951, 31);
            this.cboEndDate_H.Name = "cboEndDate_H";
            this.cboEndDate_H.NonAutoSizeHeight = 26;
            this.cboEndDate_H.Size = new System.Drawing.Size(145, 27);
            this.cboEndDate_H.TabIndex = 653;
            this.cboEndDate_H.Value = new System.DateTime(2017, 1, 23, 0, 0, 0, 0);
            this.cboEndDate_H.ValueChanged += new System.EventHandler(this.cboEndDate_H_ValueChanged);
            // 
            // cboStartDate_H
            // 
            this.cboStartDate_H.AutoSize = false;
            this.cboStartDate_H.DateButtons.Add(dateButton1);
            this.cboStartDate_H.Location = new System.Drawing.Point(752, 31);
            this.cboStartDate_H.Name = "cboStartDate_H";
            this.cboStartDate_H.NonAutoSizeHeight = 26;
            this.cboStartDate_H.Size = new System.Drawing.Size(145, 27);
            this.cboStartDate_H.TabIndex = 652;
            this.cboStartDate_H.Value = new System.DateTime(2017, 6, 15, 0, 0, 0, 0);
            this.cboStartDate_H.ValueChanged += new System.EventHandler(this.cboStartDate_H_ValueChanged);
            // 
            // lblDate
            // 
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.FontData.BoldAsString = "False";
            appearance15.FontData.SizeInPoints = 9.75F;
            appearance15.FontData.UnderlineAsString = "False";
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance15;
            this.lblDate.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblDate.DbField = "cboUseFlag";
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            appearance16.BackColor = System.Drawing.Color.White;
            appearance16.ForeColor = System.Drawing.Color.White;
            this.lblDate.HotTrackAppearance = appearance16;
            this.lblDate.Location = new System.Drawing.Point(752, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDate.Size = new System.Drawing.Size(145, 25);
            this.lblDate.TabIndex = 651;
            this.lblDate.Text = "일자";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.BackColorInternal = System.Drawing.Color.Transparent;
            this.btnPrevious.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrevious.Location = new System.Drawing.Point(1471, 34);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(36, 27);
            this.btnPrevious.TabIndex = 656;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColorInternal = System.Drawing.Color.Transparent;
            this.btnNext.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNext.Location = new System.Drawing.Point(1506, 34);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(36, 27);
            this.btnNext.TabIndex = 657;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblCnt
            // 
            this.lblCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance76.BackColor = System.Drawing.Color.Transparent;
            appearance76.FontData.BoldAsString = "False";
            appearance76.FontData.SizeInPoints = 9.75F;
            appearance76.FontData.UnderlineAsString = "False";
            appearance76.ForeColor = System.Drawing.Color.Black;
            appearance76.TextHAlignAsString = "Left";
            appearance76.TextVAlignAsString = "Middle";
            this.lblCnt.Appearance = appearance76;
            this.lblCnt.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblCnt.DbField = "cboUseFlag";
            this.lblCnt.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            appearance77.BackColor = System.Drawing.Color.White;
            appearance77.ForeColor = System.Drawing.Color.White;
            this.lblCnt.HotTrackAppearance = appearance77;
            this.lblCnt.Location = new System.Drawing.Point(1471, 9);
            this.lblCnt.Name = "lblCnt";
            this.lblCnt.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblCnt.Size = new System.Drawing.Size(71, 25);
            this.lblCnt.TabIndex = 658;
            this.lblCnt.Text = "1/1";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(371, 514);
            this.panel3.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvInsp);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 514);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "품목별 측정항목";
            // 
            // tvInsp
            // 
            this.tvInsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvInsp.Location = new System.Drawing.Point(3, 24);
            this.tvInsp.Name = "tvInsp";
            this.tvInsp.Size = new System.Drawing.Size(365, 487);
            this.tvInsp.TabIndex = 1;
            this.tvInsp.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvInsp_NodeMouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.ultraSplitter1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1582, 514);
            this.panel2.TabIndex = 0;
            // 
            // sLabel15
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Center";
            appearance4.TextVAlignAsString = "Middle";
            this.sLabel15.Appearance = appearance4;
            this.sLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel15.DbField = null;
            this.sLabel15.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.sLabel15.Location = new System.Drawing.Point(896, 31);
            this.sLabel15.Name = "sLabel15";
            this.sLabel15.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel15.Size = new System.Drawing.Size(55, 26);
            this.sLabel15.TabIndex = 659;
            this.sLabel15.Text = "~";
            // 
            // QM3210
            // 
            this.ClientSize = new System.Drawing.Size(1594, 599);
            this.Name = "QM3210";
            this.Text = "3차원SPC분석";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QM3200_FormClosing);
            this.Load += new System.EventHandler(this.QM3210_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxMAS)).EndInit();
            this.gbxMAS.ResumeLayout(false);
            this.gbxMAS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupSearchTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbAuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbManual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStartDate_H)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Infragistics.Win.Misc.UltraGroupBox gbxMAS;
        private Infragistics.Win.Misc.UltraButton btnConfirm;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor nupSearchTime;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor rdbAuto;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor rdbManual;
        private SLabel lbltxtToolCodeR;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private SLabel sLabel38;
        private SBtnTextEditor txtItemCode_H;
        private WIZ.Control.STextBox txtItemName_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboStartDate_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboEndDate_H;
        private SLabel lblDate;
        private Infragistics.Win.Misc.UltraButton btnPrevious;
        private SLabel lblCnt;
        private Infragistics.Win.Misc.UltraButton btnNext;
        private Infragistics.Win.Misc.UltraSplitter ultraSplitter1;
        private System.Windows.Forms.Panel panel3;
        private Infragistics.Win.Misc.UltraGroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView tvInsp;
        private SLabel sLabel15;
    }
}

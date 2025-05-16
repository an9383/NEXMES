using WIZ.Control;

namespace WIZ.QM
{
    partial class QM0040
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
            this.pnl_MAIN_B = new System.Windows.Forms.Panel();
            this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            this.gbx_MAS_H = new Infragistics.Win.Misc.UltraGroupBox();
            this.btn_CONFIRM_H = new Infragistics.Win.Misc.UltraButton();
            this.nup_SEARCHTIME_H = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.chk_AUTO_H = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chk_MANUAL_H = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lbl_PLANTCODE_H = new WIZ.Control.SLabel();
            this.cbo_PLANTCODE_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbl_ITEMCODE_H = new WIZ.Control.SLabel();
            this.txt_ITEMCODE_H = new WIZ.Control.SBtnTextEditor();
            this.txt_ITEMNAME_H = new WIZ.Control.STextBox(this.components);
            this.cbo_ENDDATE_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cbo_STARTDATE_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lbl_INSPDATE_H = new WIZ.Control.SLabel();
            this.btn_PREVIOUS_H = new Infragistics.Win.Misc.UltraButton();
            this.btn_NEXT_H = new Infragistics.Win.Misc.UltraButton();
            this.lbl_CNT_H = new WIZ.Control.SLabel();
            this.pnl_LEFT_B = new System.Windows.Forms.Panel();
            this.gbx_INSPLIST_B = new Infragistics.Win.Misc.UltraGroupBox();
            this.tv_INSPLIST_B = new System.Windows.Forms.TreeView();
            this.pnl_ALL_B = new System.Windows.Forms.Panel();
            this.sLabel15 = new WIZ.Control.SLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbx_MAS_H)).BeginInit();
            this.gbx_MAS_H.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_SEARCHTIME_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_AUTO_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_MANUAL_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMNAME_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ENDDATE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STARTDATE_H)).BeginInit();
            this.pnl_LEFT_B.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbx_INSPLIST_B)).BeginInit();
            this.gbx_INSPLIST_B.SuspendLayout();
            this.pnl_ALL_B.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.lbl_CNT_H);
            this.gbxHeader.Controls.Add(this.btn_NEXT_H);
            this.gbxHeader.Controls.Add(this.btn_PREVIOUS_H);
            this.gbxHeader.Controls.Add(this.gbx_MAS_H);
            this.gbxHeader.Controls.Add(this.cbo_STARTDATE_H);
            this.gbxHeader.Controls.Add(this.cbo_ENDDATE_H);
            this.gbxHeader.Controls.Add(this.cbo_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.txt_ITEMCODE_H);
            this.gbxHeader.Controls.Add(this.txt_ITEMNAME_H);
            this.gbxHeader.Controls.Add(this.lbl_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_ITEMCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_INSPDATE_H);
            this.gbxHeader.Controls.Add(this.sLabel15);
            this.gbxHeader.Size = new System.Drawing.Size(1639, 73);
            this.gbxHeader.TabIndex = 0;
            this.gbxHeader.Controls.SetChildIndex(this.sLabel15, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_INSPDATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_ITEMCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_ITEMNAME_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_ITEMCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_ENDDATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_STARTDATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.gbx_MAS_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.btn_PREVIOUS_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.btn_NEXT_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_CNT_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 2;
            this.gbxBody.ContentPadding.Left = 2;
            this.gbxBody.ContentPadding.Right = 2;
            this.gbxBody.ContentPadding.Top = 4;
            this.gbxBody.Controls.Add(this.pnl_ALL_B);
            this.gbxBody.Location = new System.Drawing.Point(0, 73);
            this.gbxBody.Size = new System.Drawing.Size(1639, 797);
            this.gbxBody.TabIndex = 1;
            // 
            // pnl_MAIN_B
            // 
            this.pnl_MAIN_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_MAIN_B.Location = new System.Drawing.Point(386, 0);
            this.pnl_MAIN_B.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_MAIN_B.Name = "pnl_MAIN_B";
            this.pnl_MAIN_B.Size = new System.Drawing.Size(1245, 789);
            this.pnl_MAIN_B.TabIndex = 20;
            this.pnl_MAIN_B.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // ultraSplitter1
            // 
            this.ultraSplitter1.BackColor = System.Drawing.Color.White;
            this.ultraSplitter1.Location = new System.Drawing.Point(371, 0);
            this.ultraSplitter1.Name = "ultraSplitter1";
            this.ultraSplitter1.RestoreExtent = 435;
            this.ultraSplitter1.Size = new System.Drawing.Size(15, 789);
            this.ultraSplitter1.TabIndex = 20;
            this.ultraSplitter1.Click += new System.EventHandler(this.ultraSplitter1_Click);
            this.ultraSplitter1.Move += new System.EventHandler(this.ultraSplitter1_Move);
            // 
            // gbx_MAS_H
            // 
            this.gbx_MAS_H.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_MAS_H.BackColorInternal = System.Drawing.Color.Transparent;
            this.gbx_MAS_H.Controls.Add(this.btn_CONFIRM_H);
            this.gbx_MAS_H.Controls.Add(this.nup_SEARCHTIME_H);
            this.gbx_MAS_H.Controls.Add(this.chk_AUTO_H);
            this.gbx_MAS_H.Controls.Add(this.chk_MANUAL_H);
            this.gbx_MAS_H.Location = new System.Drawing.Point(1209, 10);
            this.gbx_MAS_H.Name = "gbx_MAS_H";
            this.gbx_MAS_H.Size = new System.Drawing.Size(238, 53);
            this.gbx_MAS_H.TabIndex = 655;
            this.gbx_MAS_H.Visible = false;
            // 
            // btn_CONFIRM_H
            // 
            this.btn_CONFIRM_H.Location = new System.Drawing.Point(146, 12);
            this.btn_CONFIRM_H.Name = "btn_CONFIRM_H";
            this.btn_CONFIRM_H.Size = new System.Drawing.Size(80, 31);
            this.btn_CONFIRM_H.TabIndex = 2;
            this.btn_CONFIRM_H.TabStop = false;
            this.btn_CONFIRM_H.Text = "(분)적용";
            this.btn_CONFIRM_H.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // nup_SEARCHTIME_H
            // 
            this.nup_SEARCHTIME_H.Location = new System.Drawing.Point(78, 13);
            this.nup_SEARCHTIME_H.MaskInput = "nnnn";
            this.nup_SEARCHTIME_H.MinValue = 0;
            this.nup_SEARCHTIME_H.Name = "nup_SEARCHTIME_H";
            this.nup_SEARCHTIME_H.Size = new System.Drawing.Size(60, 29);
            this.nup_SEARCHTIME_H.TabIndex = 1;
            this.nup_SEARCHTIME_H.TabStop = false;
            this.nup_SEARCHTIME_H.Value = 10;
            // 
            // chk_AUTO_H
            // 
            this.chk_AUTO_H.BackColor = System.Drawing.Color.Transparent;
            this.chk_AUTO_H.BackColorInternal = System.Drawing.Color.Transparent;
            this.chk_AUTO_H.Location = new System.Drawing.Point(15, 27);
            this.chk_AUTO_H.Name = "chk_AUTO_H";
            this.chk_AUTO_H.Size = new System.Drawing.Size(57, 24);
            this.chk_AUTO_H.TabIndex = 0;
            this.chk_AUTO_H.Text = "자동";
            this.chk_AUTO_H.CheckedChanged += new System.EventHandler(this.rdbAuto_CheckedChanged);
            // 
            // chk_MANUAL_H
            // 
            this.chk_MANUAL_H.Checked = true;
            this.chk_MANUAL_H.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_MANUAL_H.Location = new System.Drawing.Point(15, 6);
            this.chk_MANUAL_H.Name = "chk_MANUAL_H";
            this.chk_MANUAL_H.Size = new System.Drawing.Size(57, 24);
            this.chk_MANUAL_H.TabIndex = 0;
            this.chk_MANUAL_H.Text = "수동";
            this.chk_MANUAL_H.CheckedChanged += new System.EventHandler(this.rdbManual_CheckedChanged);
            // 
            // lbl_PLANTCODE_H
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.SizeInPoints = 9.75F;
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lbl_PLANTCODE_H.Appearance = appearance2;
            this.lbl_PLANTCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_PLANTCODE_H.DbField = "cboUseFlag";
            this.lbl_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_PLANTCODE_H.Location = new System.Drawing.Point(110, 10);
            this.lbl_PLANTCODE_H.Name = "lbl_PLANTCODE_H";
            this.lbl_PLANTCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_PLANTCODE_H.Size = new System.Drawing.Size(145, 25);
            this.lbl_PLANTCODE_H.TabIndex = 647;
            this.lbl_PLANTCODE_H.Text = "사업장";
            // 
            // cbo_PLANTCODE_H
            // 
            this.cbo_PLANTCODE_H.AutoSize = false;
            this.cbo_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbo_PLANTCODE_H.Location = new System.Drawing.Point(110, 32);
            this.cbo_PLANTCODE_H.Name = "cbo_PLANTCODE_H";
            this.cbo_PLANTCODE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_PLANTCODE_H.TabIndex = 646;
            // 
            // lbl_ITEMCODE_H
            // 
            appearance33.FontData.BoldAsString = "False";
            appearance33.FontData.SizeInPoints = 9.75F;
            appearance33.FontData.UnderlineAsString = "False";
            appearance33.ForeColor = System.Drawing.Color.Black;
            appearance33.TextHAlignAsString = "Left";
            appearance33.TextVAlignAsString = "Middle";
            this.lbl_ITEMCODE_H.Appearance = appearance33;
            this.lbl_ITEMCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_ITEMCODE_H.DbField = null;
            this.lbl_ITEMCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.lbl_ITEMCODE_H.Location = new System.Drawing.Point(726, 10);
            this.lbl_ITEMCODE_H.Name = "lbl_ITEMCODE_H";
            this.lbl_ITEMCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_ITEMCODE_H.Size = new System.Drawing.Size(344, 25);
            this.lbl_ITEMCODE_H.TabIndex = 650;
            this.lbl_ITEMCODE_H.Text = "품목";
            // 
            // txt_ITEMCODE_H
            // 
            appearance13.FontData.BoldAsString = "False";
            appearance13.FontData.Name = "맑은 고딕";
            appearance13.FontData.SizeInPoints = 10F;
            appearance13.FontData.UnderlineAsString = "False";
            appearance13.ForeColor = System.Drawing.Color.Black;
            this.txt_ITEMCODE_H.Appearance = appearance13;
            this.txt_ITEMCODE_H.AutoSize = false;
            this.txt_ITEMCODE_H.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txt_ITEMCODE_H.btnWidth = 26;
            this.txt_ITEMCODE_H.Location = new System.Drawing.Point(726, 32);
            this.txt_ITEMCODE_H.Name = "txt_ITEMCODE_H";
            this.txt_ITEMCODE_H.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_ITEMCODE_H.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_ITEMCODE_H.Size = new System.Drawing.Size(145, 27);
            this.txt_ITEMCODE_H.TabIndex = 648;
            // 
            // txt_ITEMNAME_H
            // 
            appearance29.FontData.BoldAsString = "False";
            appearance29.FontData.UnderlineAsString = "False";
            appearance29.ForeColor = System.Drawing.Color.Black;
            this.txt_ITEMNAME_H.Appearance = appearance29;
            this.txt_ITEMNAME_H.AutoSize = false;
            this.txt_ITEMNAME_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_ITEMNAME_H.Location = new System.Drawing.Point(870, 32);
            this.txt_ITEMNAME_H.Name = "txt_ITEMNAME_H";
            this.txt_ITEMNAME_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_ITEMNAME_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_ITEMNAME_H.Size = new System.Drawing.Size(200, 27);
            this.txt_ITEMNAME_H.TabIndex = 649;
            // 
            // cbo_ENDDATE_H
            // 
            this.cbo_ENDDATE_H.AutoSize = false;
            this.cbo_ENDDATE_H.DateButtons.Add(dateButton2);
            this.cbo_ENDDATE_H.Location = new System.Drawing.Point(516, 32);
            this.cbo_ENDDATE_H.Name = "cbo_ENDDATE_H";
            this.cbo_ENDDATE_H.NonAutoSizeHeight = 26;
            this.cbo_ENDDATE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_ENDDATE_H.TabIndex = 653;
            this.cbo_ENDDATE_H.Value = new System.DateTime(2017, 1, 23, 0, 0, 0, 0);
            this.cbo_ENDDATE_H.ValueChanged += new System.EventHandler(this.cboEndDate_H_ValueChanged);
            // 
            // cbo_STARTDATE_H
            // 
            this.cbo_STARTDATE_H.AutoSize = false;
            this.cbo_STARTDATE_H.DateButtons.Add(dateButton1);
            this.cbo_STARTDATE_H.Location = new System.Drawing.Point(320, 32);
            this.cbo_STARTDATE_H.Name = "cbo_STARTDATE_H";
            this.cbo_STARTDATE_H.NonAutoSizeHeight = 26;
            this.cbo_STARTDATE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_STARTDATE_H.TabIndex = 652;
            this.cbo_STARTDATE_H.Value = new System.DateTime(2017, 6, 15, 0, 0, 0, 0);
            this.cbo_STARTDATE_H.ValueChanged += new System.EventHandler(this.cboStartDate_H_ValueChanged);
            // 
            // lbl_INSPDATE_H
            // 
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.FontData.BoldAsString = "False";
            appearance15.FontData.SizeInPoints = 9.75F;
            appearance15.FontData.UnderlineAsString = "False";
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.lbl_INSPDATE_H.Appearance = appearance15;
            this.lbl_INSPDATE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_INSPDATE_H.DbField = "cboUseFlag";
            this.lbl_INSPDATE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            appearance16.BackColor = System.Drawing.Color.White;
            appearance16.ForeColor = System.Drawing.Color.White;
            this.lbl_INSPDATE_H.HotTrackAppearance = appearance16;
            this.lbl_INSPDATE_H.Location = new System.Drawing.Point(320, 10);
            this.lbl_INSPDATE_H.Name = "lbl_INSPDATE_H";
            this.lbl_INSPDATE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_INSPDATE_H.Size = new System.Drawing.Size(356, 25);
            this.lbl_INSPDATE_H.TabIndex = 651;
            this.lbl_INSPDATE_H.Text = "검사일자";
            // 
            // btn_PREVIOUS_H
            // 
            this.btn_PREVIOUS_H.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PREVIOUS_H.BackColorInternal = System.Drawing.Color.Transparent;
            this.btn_PREVIOUS_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_PREVIOUS_H.Location = new System.Drawing.Point(1516, 34);
            this.btn_PREVIOUS_H.Name = "btn_PREVIOUS_H";
            this.btn_PREVIOUS_H.Size = new System.Drawing.Size(36, 27);
            this.btn_PREVIOUS_H.TabIndex = 656;
            this.btn_PREVIOUS_H.Text = "<";
            this.btn_PREVIOUS_H.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btn_NEXT_H
            // 
            this.btn_NEXT_H.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NEXT_H.BackColorInternal = System.Drawing.Color.Transparent;
            this.btn_NEXT_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_NEXT_H.Location = new System.Drawing.Point(1551, 34);
            this.btn_NEXT_H.Name = "btn_NEXT_H";
            this.btn_NEXT_H.Size = new System.Drawing.Size(36, 27);
            this.btn_NEXT_H.TabIndex = 657;
            this.btn_NEXT_H.Text = ">";
            this.btn_NEXT_H.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbl_CNT_H
            // 
            this.lbl_CNT_H.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance76.BackColor = System.Drawing.Color.Transparent;
            appearance76.FontData.BoldAsString = "False";
            appearance76.FontData.SizeInPoints = 9.75F;
            appearance76.FontData.UnderlineAsString = "False";
            appearance76.ForeColor = System.Drawing.Color.Black;
            appearance76.TextHAlignAsString = "Left";
            appearance76.TextVAlignAsString = "Middle";
            this.lbl_CNT_H.Appearance = appearance76;
            this.lbl_CNT_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_CNT_H.DbField = "cboUseFlag";
            this.lbl_CNT_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            appearance77.BackColor = System.Drawing.Color.White;
            appearance77.ForeColor = System.Drawing.Color.White;
            this.lbl_CNT_H.HotTrackAppearance = appearance77;
            this.lbl_CNT_H.Location = new System.Drawing.Point(1516, 9);
            this.lbl_CNT_H.Name = "lbl_CNT_H";
            this.lbl_CNT_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_CNT_H.Size = new System.Drawing.Size(71, 25);
            this.lbl_CNT_H.TabIndex = 658;
            this.lbl_CNT_H.Text = "1/1";
            // 
            // pnl_LEFT_B
            // 
            this.pnl_LEFT_B.AutoScroll = true;
            this.pnl_LEFT_B.Controls.Add(this.gbx_INSPLIST_B);
            this.pnl_LEFT_B.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_LEFT_B.Location = new System.Drawing.Point(0, 0);
            this.pnl_LEFT_B.Name = "pnl_LEFT_B";
            this.pnl_LEFT_B.Size = new System.Drawing.Size(371, 789);
            this.pnl_LEFT_B.TabIndex = 22;
            // 
            // gbx_INSPLIST_B
            // 
            this.gbx_INSPLIST_B.Controls.Add(this.tv_INSPLIST_B);
            this.gbx_INSPLIST_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_INSPLIST_B.Location = new System.Drawing.Point(0, 0);
            this.gbx_INSPLIST_B.Name = "gbx_INSPLIST_B";
            this.gbx_INSPLIST_B.Size = new System.Drawing.Size(371, 789);
            this.gbx_INSPLIST_B.TabIndex = 0;
            this.gbx_INSPLIST_B.Text = "품목별 자주검사항목";
            // 
            // tv_INSPLIST_B
            // 
            this.tv_INSPLIST_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_INSPLIST_B.Location = new System.Drawing.Point(3, 24);
            this.tv_INSPLIST_B.Name = "tv_INSPLIST_B";
            this.tv_INSPLIST_B.Size = new System.Drawing.Size(365, 762);
            this.tv_INSPLIST_B.TabIndex = 1;
            this.tv_INSPLIST_B.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMesr_NodeMouseDoubleClick);
            // 
            // pnl_ALL_B
            // 
            this.pnl_ALL_B.Controls.Add(this.pnl_MAIN_B);
            this.pnl_ALL_B.Controls.Add(this.ultraSplitter1);
            this.pnl_ALL_B.Controls.Add(this.pnl_LEFT_B);
            this.pnl_ALL_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_ALL_B.Location = new System.Drawing.Point(4, 4);
            this.pnl_ALL_B.Name = "pnl_ALL_B";
            this.pnl_ALL_B.Size = new System.Drawing.Size(1631, 789);
            this.pnl_ALL_B.TabIndex = 0;
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
            this.sLabel15.Location = new System.Drawing.Point(483, 32);
            this.sLabel15.Name = "sLabel15";
            this.sLabel15.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel15.Size = new System.Drawing.Size(30, 26);
            this.sLabel15.TabIndex = 659;
            this.sLabel15.Text = "~";
            // 
            // QM0040
            // 
            this.ClientSize = new System.Drawing.Size(1639, 870);
            this.Name = "QM0040";
            this.Text = "자주검사SPC분석";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QM3200_FormClosing);
            this.Load += new System.EventHandler(this.QM3200_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbx_MAS_H)).EndInit();
            this.gbx_MAS_H.ResumeLayout(false);
            this.gbx_MAS_H.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_SEARCHTIME_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_AUTO_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_MANUAL_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMNAME_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ENDDATE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STARTDATE_H)).EndInit();
            this.pnl_LEFT_B.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbx_INSPLIST_B)).EndInit();
            this.gbx_INSPLIST_B.ResumeLayout(false);
            this.pnl_ALL_B.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_MAIN_B;
        private Infragistics.Win.Misc.UltraGroupBox gbx_MAS_H;
        private Infragistics.Win.Misc.UltraButton btn_CONFIRM_H;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor nup_SEARCHTIME_H;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chk_AUTO_H;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chk_MANUAL_H;
        private SLabel lbl_PLANTCODE_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_PLANTCODE_H;
        private SLabel lbl_ITEMCODE_H;
        private SBtnTextEditor txt_ITEMCODE_H;
        private WIZ.Control.STextBox txt_ITEMNAME_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cbo_STARTDATE_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cbo_ENDDATE_H;
        private SLabel lbl_INSPDATE_H;
        private Infragistics.Win.Misc.UltraButton btn_PREVIOUS_H;
        private SLabel lbl_CNT_H;
        private Infragistics.Win.Misc.UltraButton btn_NEXT_H;
        private Infragistics.Win.Misc.UltraSplitter ultraSplitter1;
        private System.Windows.Forms.Panel pnl_LEFT_B;
        private Infragistics.Win.Misc.UltraGroupBox gbx_INSPLIST_B;
        private System.Windows.Forms.Panel pnl_ALL_B;
        private System.Windows.Forms.TreeView tv_INSPLIST_B;
        private SLabel sLabel15;
    }
}

using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.Forms;

namespace WIZ.SY
{
    public class POP_SY0101 : BasePopupForm
    {
        private string PlantCode = string.Empty;

        private string GRPID = string.Empty;

        public string ProgramID = string.Empty;

        public string ProgramNM = string.Empty;

        public string UidNM = string.Empty;

        public string MenuType = string.Empty;

        public string ProgType = string.Empty;

        public string NameSpace = string.Empty;

        public string FileID = string.Empty;

        public int chk_inq = 0;

        public int chk_new = 0;

        public int chk_del = 0;

        public int chk_save = 0;

        public int chk_prn = 0;

        public int chk_excel = 0;

        public bool Cancel = false;

        public int menuid = 0;

        public int parmenuid = 0;

        public int sort = 0;

        public string FILEID = string.Empty;

        public string NAMESPACE = string.Empty;

        private DataTable DtTemp = new DataTable();

        private DataTable DtGrid1 = new DataTable();

        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private Common _Com = new Common();

        public Binding INQFLAG = null;

        public Binding DELFLAG = null;

        public Binding PRNFLAG = null;

        public Binding NEWFLAG = null;

        public Binding SAVEFLAG = null;

        public Binding EXCELFLAG = null;

        private IContainer components = null;

        private UltraGroupBox gbxHeader;

        private UltraButton btnClose;

        private UltraButton btnCheck;

        private SLabel lblProgramID;

        private UltraGroupBox ultraGroupBox2;

        private UltraGroupBox gbxProgramInfor;

        private UltraTextEditor txtUidName;

        private SLabel lblUidName;

        private SLabel lblMenuType;

        private UltraTextEditor txtFileID;

        private UltraTextEditor txtNameSpace;

        private SLabel lblNameSpace;

        private SLabel lblFileID;

        private SLabel sLabel3;

        private WIZ.Control.Grid grid1;

        private UltraCheckEditor uceInqFlag;

        private UltraCheckEditor uceNewFlag;

        private UltraCheckEditor uceDelFlag;

        private UltraCheckEditor uceSaveFlag;

        private UltraCheckEditor ucePrnFlag;

        private UltraCheckEditor uceExcelFlag;

        private UltraButton btnInquire;

        private SLabel lblProgramNM;

        private UltraComboEditor UseFlag;

        private UltraComboEditor cboMenuType;

        private WIZ.Control.STextBox txtProgramID_H;

        private WIZ.Control.STextBox txtProgramName_H;

        public POP_SY0101(string grpid)
        {
            InitializeComponent();
            GRPID = grpid;
        }

        private void btnInquire_Click(object sender, EventArgs e)
        {
            try
            {
                DtTemp.Rows.Clear();
                DtGrid1.Rows.Clear();
                DtTemp = USP_SY0101_S2(GRPID);
                grid1.DataSource = DtTemp;
                grid1.DataBind();
                DtGrid1 = DtTemp;
                Binding();
            }
            catch (Exception ex)
            {
                MessageForm messageForm = new MessageForm(ex);
                messageForm.ShowDialog();
            }
        }

        private void grid1_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count != 0)
            {
                txtProgramID_H.Text = grid1.ActiveRow.Cells["PROGRAMID"].Value.ToString();
                txtProgramName_H.Text = grid1.ActiveRow.Cells["MENUNAME"].Value.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Cancel = true;
            Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count != 0)
            {
                string text2 = ProgramID = (txtProgramID_H.Text = Convert.ToString(grid1.ActiveRow.Cells["PROGRAMID"].Value));
                text2 = (ProgramNM = (txtProgramName_H.Text = Convert.ToString(grid1.ActiveRow.Cells["MENUNAME"].Value)));
                NameSpace = Convert.ToString(grid1.ActiveRow.Cells["NAMESPACE"].Value);
                FileID = Convert.ToString(grid1.ActiveRow.Cells["FILEID"].Value);
                MenuType = Convert.ToString(grid1.ActiveRow.Cells["MENUTYPE"].Value);
                ProgType = Convert.ToString(grid1.ActiveRow.Cells["PROGTYPE"].Value);
                menuid = Convert.ToInt32(grid1.ActiveRow.Cells["MENUID"].Value);
                parmenuid = Convert.ToInt32(grid1.ActiveRow.Cells["PARMENUID"].Value);
                sort = Convert.ToInt32(grid1.ActiveRow.Cells["SORT"].Value);
                chk_inq = (((bool)uceInqFlag.CheckedValue) ? 1 : 0);
                chk_new = (((bool)uceNewFlag.CheckedValue) ? 1 : 0);
                chk_del = (((bool)uceDelFlag.CheckedValue) ? 1 : 0);
                chk_save = (((bool)uceSaveFlag.CheckedValue) ? 1 : 0);
                chk_prn = (((bool)ucePrnFlag.CheckedValue) ? 1 : 0);
                chk_excel = (((bool)uceExcelFlag.CheckedValue) ? 1 : 0);
            }
            Close();
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (grid1.Rows.Count != 0)
            {
                string text2 = ProgramID = (txtProgramID_H.Text = Convert.ToString(grid1.ActiveRow.Cells["PROGRAMID"].Value));
                text2 = (ProgramNM = (txtProgramName_H.Text = Convert.ToString(grid1.ActiveRow.Cells["MENUNAME"].Value)));
                NameSpace = Convert.ToString(grid1.ActiveRow.Cells["NAMESPACE"].Value);
                FileID = Convert.ToString(grid1.ActiveRow.Cells["FILEID"].Value);
                MenuType = Convert.ToString(grid1.ActiveRow.Cells["MENUTYPE"].Value);
                ProgType = Convert.ToString(grid1.ActiveRow.Cells["PROGTYPE"].Value);
                menuid = Convert.ToInt32(grid1.ActiveRow.Cells["MENUID"].Value);
                parmenuid = Convert.ToInt32(grid1.ActiveRow.Cells["PARMENUID"].Value);
                sort = Convert.ToInt32(grid1.ActiveRow.Cells["SORT"].Value);
                chk_inq = (((bool)uceInqFlag.CheckedValue) ? 1 : 0);
                chk_new = (((bool)uceNewFlag.CheckedValue) ? 1 : 0);
                chk_del = (((bool)uceDelFlag.CheckedValue) ? 1 : 0);
                chk_save = (((bool)uceSaveFlag.CheckedValue) ? 1 : 0);
                chk_prn = (((bool)ucePrnFlag.CheckedValue) ? 1 : 0);
                chk_excel = (((bool)uceExcelFlag.CheckedValue) ? 1 : 0);
            }
            Close();
        }

        private void POP_SY0101_Load(object sender, EventArgs e)
        {
            GridInit();
            DtTemp = USP_SY0101_S2(GRPID);
            grid1.DataSource = DtTemp;
            grid1.DataBind();
            DtGrid1 = DtTemp;
            Binding();
        }

        private void GridInit()
        {
            _GridUtil.InitializeGrid(grid1, true, true, false, "", activeRowWhiteColor: true);
            _GridUtil.InitColumnUltraGrid(grid1, "PROGRAMID", "프로그램ID", true, GridColDataType_emu.VarChar, 130, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MENUNAME", "프로그램명", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MENUID", "MENUID", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PARMENUID", "PARMENUID", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SORT", "SORT", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UIDNAME", "다국어명", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MENUTYPE", "메뉴유형", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PROGTYPE", "PROGTYPE", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INQFLAG", "조회", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NEWFLAG", "추가", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SAVEFLAG", "저장", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DELFLAG", "삭제", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EXCELFLAG", "엑셀", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRNFLAG", "출력", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NAMESPACE", "NAMESPACE", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FILEID", "파일ID", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 120, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 180, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 120, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 180, 100, HAlign.Center, false, false, null, null, null, null, null);
            for (int i = 0; i < grid1.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                grid1.DisplayLayout.Bands[0].Columns[i].CellClickAction = CellClickAction.RowSelect;
                grid1.DisplayLayout.Bands[0].Columns[i].CellActivation = Activation.NoEdit;
            }
            _GridUtil.SetInitUltraGridBind(grid1);
            DtGrid1 = (DataTable)grid1.DataSource;
        }

        private DataTable USP_SY0101_S2(string sGrpID)
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                return dBHelper.FillTable("USP_SY0101_POP", CommandType.StoredProcedure, dBHelper.CreateParameter("AS_GRPID", sGrpID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_LANG", Common.Lang, DbType.String, ParameterDirection.Input));
            }
            catch (Exception ex)
            {
                MessageForm messageForm = new MessageForm(ex);
                messageForm.ShowDialog();
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        private void Binding()
        {
            cboMenuType.DataBindings.Clear();
            cboMenuType.DataBindings.Add("Value", DtGrid1, "MENUTYPE");
            UseFlag.DataBindings.Clear();
            UseFlag.DataBindings.Add("Value", DtGrid1, "USEFLAG");
            txtUidName.DataBindings.Clear();
            txtUidName.DataBindings.Add("Value", DtGrid1, "MENUNAME");
            INQFLAG = new Binding("Checked", DtGrid1, "INQFLAG");
            DELFLAG = new Binding("Checked", DtGrid1, "DELFLAG");
            PRNFLAG = new Binding("Checked", DtGrid1, "PRNFLAG");
            NEWFLAG = new Binding("Checked", DtGrid1, "NEWFLAG");
            SAVEFLAG = new Binding("Checked", DtGrid1, "SAVEFLAG");
            EXCELFLAG = new Binding("Checked", DtGrid1, "EXCELFLAG");
            INQFLAG.Format += ComboBind;
            DELFLAG.Format += ComboBind;
            PRNFLAG.Format += ComboBind;
            NEWFLAG.Format += ComboBind;
            SAVEFLAG.Format += ComboBind;
            EXCELFLAG.Format += ComboBind;
            uceInqFlag.DataBindings.Clear();
            uceInqFlag.DataBindings.Add(INQFLAG);
            uceDelFlag.DataBindings.Clear();
            uceDelFlag.DataBindings.Add(DELFLAG);
            ucePrnFlag.DataBindings.Clear();
            ucePrnFlag.DataBindings.Add(PRNFLAG);
            uceNewFlag.DataBindings.Clear();
            uceNewFlag.DataBindings.Add(NEWFLAG);
            uceSaveFlag.DataBindings.Clear();
            uceSaveFlag.DataBindings.Add(SAVEFLAG);
            uceExcelFlag.DataBindings.Clear();
            uceExcelFlag.DataBindings.Add(EXCELFLAG);
            txtNameSpace.DataBindings.Clear();
            txtNameSpace.DataBindings.Add("Value", DtGrid1, "NAMESPACE");
            txtFileID.DataBindings.Clear();
            txtFileID.DataBindings.Add("Value", DtGrid1, "FILEID");
        }

        private void ComboBind(object send, ConvertEventArgs e)
        {
            if (e.Value == DBNull.Value)
            {
                e.Value = false;
            }
            e.Value = (Convert.ToString(e.Value) != "0" && (Convert.ToString(e.Value) == "1" || Convert.ToBoolean(e.Value)));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            gbxHeader = new Infragistics.Win.Misc.UltraGroupBox();
            btnClose = new Infragistics.Win.Misc.UltraButton();
            btnInquire = new Infragistics.Win.Misc.UltraButton();
            btnCheck = new Infragistics.Win.Misc.UltraButton();
            lblProgramNM = new WIZ.Control.SLabel();
            lblProgramID = new WIZ.Control.SLabel();
            ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            gbxProgramInfor = new Infragistics.Win.Misc.UltraGroupBox();
            UseFlag = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            cboMenuType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            uceSaveFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            ucePrnFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            uceExcelFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            uceInqFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            uceNewFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            uceDelFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            txtUidName = new WIZ.Control.STextBox();
            lblUidName = new WIZ.Control.SLabel();
            lblMenuType = new WIZ.Control.SLabel();
            txtFileID = new WIZ.Control.STextBox();
            txtNameSpace = new WIZ.Control.STextBox();
            lblNameSpace = new WIZ.Control.SLabel();
            lblFileID = new WIZ.Control.SLabel();
            sLabel3 = new WIZ.Control.SLabel();
            grid1 = new WIZ.Control.Grid(components);
            txtProgramID_H = new WIZ.Control.STextBox(components);
            txtProgramName_H = new WIZ.Control.STextBox(components);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).BeginInit();
            gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ultraGroupBox2).BeginInit();
            ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gbxProgramInfor).BeginInit();
            gbxProgramInfor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UseFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboMenuType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uceSaveFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucePrnFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uceExcelFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uceInqFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uceNewFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uceDelFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUidName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFileID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNameSpace).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProgramID_H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProgramName_H).BeginInit();
            SuspendLayout();
            gbxHeader.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            gbxHeader.Controls.Add(txtProgramName_H);
            gbxHeader.Controls.Add(txtProgramID_H);
            gbxHeader.Controls.Add(btnClose);
            gbxHeader.Controls.Add(btnInquire);
            gbxHeader.Controls.Add(btnCheck);
            gbxHeader.Controls.Add(lblProgramNM);
            gbxHeader.Controls.Add(lblProgramID);
            gbxHeader.Location = new System.Drawing.Point(1, 1);
            gbxHeader.Margin = new System.Windows.Forms.Padding(0);
            gbxHeader.Name = "gbxHeader";
            gbxHeader.Size = new System.Drawing.Size(627, 68);
            gbxHeader.TabIndex = 0;
            btnClose.Location = new System.Drawing.Point(543, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(75, 54);
            btnClose.TabIndex = 5;
            btnClose.Text = "취 소";
            btnClose.Click += new System.EventHandler(btnClose_Click);
            btnInquire.Location = new System.Drawing.Point(379, 5);
            btnInquire.Name = "btnInquire";
            btnInquire.Size = new System.Drawing.Size(75, 54);
            btnInquire.TabIndex = 3;
            btnInquire.Text = "조 회";
            btnInquire.Click += new System.EventHandler(btnInquire_Click);
            btnCheck.Location = new System.Drawing.Point(462, 5);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new System.Drawing.Size(75, 54);
            btnCheck.TabIndex = 4;
            btnCheck.Text = "확 인";
            btnCheck.Click += new System.EventHandler(btnCheck_Click);
            appearance.FontData.BoldAsString = "False";
            appearance.FontData.UnderlineAsString = "False";
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextHAlignAsString = "Right";
            appearance.TextVAlignAsString = "Middle";
            lblProgramNM.Appearance = appearance;
            lblProgramNM.DbField = null;
            lblProgramNM.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblProgramNM.Location = new System.Drawing.Point(8, 38);
            lblProgramNM.Name = "lblProgramNM";
            lblProgramNM.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblProgramNM.Size = new System.Drawing.Size(84, 21);
            lblProgramNM.TabIndex = 0;
            lblProgramNM.Text = "프로그램명";
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            lblProgramID.Appearance = appearance2;
            lblProgramID.DbField = null;
            lblProgramID.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblProgramID.Location = new System.Drawing.Point(8, 11);
            lblProgramID.Name = "lblProgramID";
            lblProgramID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblProgramID.Size = new System.Drawing.Size(84, 21);
            lblProgramID.TabIndex = 0;
            lblProgramID.Text = "프로그램ID";
            ultraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            ultraGroupBox2.Controls.Add(gbxProgramInfor);
            ultraGroupBox2.Controls.Add(grid1);
            ultraGroupBox2.Location = new System.Drawing.Point(1, 69);
            ultraGroupBox2.Margin = new System.Windows.Forms.Padding(0);
            ultraGroupBox2.Name = "ultraGroupBox2";
            ultraGroupBox2.Size = new System.Drawing.Size(627, 399);
            ultraGroupBox2.TabIndex = 1;
            gbxProgramInfor.Controls.Add(UseFlag);
            gbxProgramInfor.Controls.Add(cboMenuType);
            gbxProgramInfor.Controls.Add(uceSaveFlag);
            gbxProgramInfor.Controls.Add(ucePrnFlag);
            gbxProgramInfor.Controls.Add(uceExcelFlag);
            gbxProgramInfor.Controls.Add(uceInqFlag);
            gbxProgramInfor.Controls.Add(uceNewFlag);
            gbxProgramInfor.Controls.Add(uceDelFlag);
            gbxProgramInfor.Controls.Add(txtUidName);
            gbxProgramInfor.Controls.Add(lblUidName);
            gbxProgramInfor.Controls.Add(lblMenuType);
            gbxProgramInfor.Controls.Add(txtFileID);
            gbxProgramInfor.Controls.Add(txtNameSpace);
            gbxProgramInfor.Controls.Add(lblNameSpace);
            gbxProgramInfor.Controls.Add(lblFileID);
            gbxProgramInfor.Controls.Add(sLabel3);
            gbxProgramInfor.Location = new System.Drawing.Point(362, 10);
            gbxProgramInfor.Name = "gbxProgramInfor";
            gbxProgramInfor.Size = new System.Drawing.Size(261, 384);
            gbxProgramInfor.TabIndex = 1;
            gbxProgramInfor.Text = "프로그램 정보";
            UseFlag.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            UseFlag.Location = new System.Drawing.Point(6, 160);
            UseFlag.Name = "UseFlag";
            UseFlag.Size = new System.Drawing.Size(248, 26);
            UseFlag.TabIndex = 3;
            cboMenuType.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            cboMenuType.Location = new System.Drawing.Point(6, 107);
            cboMenuType.Name = "cboMenuType";
            cboMenuType.Size = new System.Drawing.Size(248, 26);
            cboMenuType.TabIndex = 2;
            uceSaveFlag.Location = new System.Drawing.Point(26, 233);
            uceSaveFlag.Name = "uceSaveFlag";
            uceSaveFlag.Size = new System.Drawing.Size(71, 30);
            uceSaveFlag.TabIndex = 7;
            uceSaveFlag.Text = "저장";
            ucePrnFlag.Location = new System.Drawing.Point(104, 233);
            ucePrnFlag.Name = "ucePrnFlag";
            ucePrnFlag.Size = new System.Drawing.Size(71, 30);
            ucePrnFlag.TabIndex = 8;
            ucePrnFlag.Text = "출력";
            uceExcelFlag.Location = new System.Drawing.Point(182, 233);
            uceExcelFlag.Name = "uceExcelFlag";
            uceExcelFlag.Size = new System.Drawing.Size(71, 30);
            uceExcelFlag.TabIndex = 9;
            uceExcelFlag.Text = "엑셀";
            uceInqFlag.Location = new System.Drawing.Point(26, 195);
            uceInqFlag.Name = "uceInqFlag";
            uceInqFlag.Size = new System.Drawing.Size(71, 30);
            uceInqFlag.TabIndex = 4;
            uceInqFlag.Text = "조회";
            uceNewFlag.Location = new System.Drawing.Point(104, 195);
            uceNewFlag.Name = "uceNewFlag";
            uceNewFlag.Size = new System.Drawing.Size(71, 30);
            uceNewFlag.TabIndex = 5;
            uceNewFlag.Text = "추가";
            uceDelFlag.Location = new System.Drawing.Point(182, 195);
            uceDelFlag.Name = "uceDelFlag";
            uceDelFlag.Size = new System.Drawing.Size(71, 30);
            uceDelFlag.TabIndex = 6;
            uceDelFlag.Text = "삭제";
            txtUidName.AutoSize = false;
            txtUidName.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtUidName.Location = new System.Drawing.Point(6, 50);
            txtUidName.Name = "txtUidName";
            txtUidName.ReadOnly = true;
            txtUidName.Size = new System.Drawing.Size(248, 27);
            txtUidName.TabIndex = 1;
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.SizeInPoints = 8f;
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Bottom";
            lblUidName.Appearance = appearance3;
            lblUidName.DbField = null;
            lblUidName.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblUidName.Location = new System.Drawing.Point(6, 21);
            lblUidName.Name = "lblUidName";
            lblUidName.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblUidName.Size = new System.Drawing.Size(100, 23);
            lblUidName.TabIndex = 0;
            lblUidName.Text = "다국어";
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.SizeInPoints = 8f;
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Bottom";
            lblMenuType.Appearance = appearance4;
            lblMenuType.DbField = null;
            lblMenuType.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblMenuType.Location = new System.Drawing.Point(6, 72);
            lblMenuType.Name = "lblMenuType";
            lblMenuType.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblMenuType.Size = new System.Drawing.Size(100, 29);
            lblMenuType.TabIndex = 0;
            lblMenuType.Text = "메뉴유형";
            txtFileID.AutoSize = false;
            txtFileID.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtFileID.Location = new System.Drawing.Point(6, 349);
            txtFileID.Name = "txtFileID";
            txtFileID.ReadOnly = true;
            txtFileID.Size = new System.Drawing.Size(248, 27);
            txtFileID.TabIndex = 11;
            txtNameSpace.AutoSize = false;
            txtNameSpace.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtNameSpace.Location = new System.Drawing.Point(6, 296);
            txtNameSpace.Name = "txtNameSpace";
            txtNameSpace.ReadOnly = true;
            txtNameSpace.Size = new System.Drawing.Size(248, 27);
            txtNameSpace.TabIndex = 10;
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.SizeInPoints = 8f;
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Bottom";
            lblNameSpace.Appearance = appearance5;
            lblNameSpace.DbField = null;
            lblNameSpace.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblNameSpace.Location = new System.Drawing.Point(6, 267);
            lblNameSpace.Name = "lblNameSpace";
            lblNameSpace.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblNameSpace.Size = new System.Drawing.Size(100, 23);
            lblNameSpace.TabIndex = 0;
            lblNameSpace.Text = "네임스페이스";
            appearance6.FontData.BoldAsString = "False";
            appearance6.FontData.SizeInPoints = 8f;
            appearance6.FontData.UnderlineAsString = "False";
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Bottom";
            lblFileID.Appearance = appearance6;
            lblFileID.DbField = null;
            lblFileID.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblFileID.Location = new System.Drawing.Point(6, 320);
            lblFileID.Name = "lblFileID";
            lblFileID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblFileID.Size = new System.Drawing.Size(100, 23);
            lblFileID.TabIndex = 0;
            lblFileID.Text = "파일";
            appearance7.FontData.BoldAsString = "False";
            appearance7.FontData.SizeInPoints = 8f;
            appearance7.FontData.UnderlineAsString = "False";
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Bottom";
            sLabel3.Appearance = appearance7;
            sLabel3.DbField = null;
            sLabel3.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            sLabel3.Location = new System.Drawing.Point(6, 127);
            sLabel3.Name = "sLabel3";
            sLabel3.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            sLabel3.Size = new System.Drawing.Size(100, 27);
            sLabel3.TabIndex = 0;
            sLabel3.Text = "사용구분";
            grid1.AutoResizeColumn = true;
            grid1.AutoUserColumn = true;
            grid1.ContextMenuCopyEnabled = true;
            grid1.ContextMenuDeleteEnabled = true;
            grid1.ContextMenuExcelEnabled = true;
            grid1.ContextMenuInsertEnabled = true;
            grid1.ContextMenuPasteEnabled = true;
            grid1.DeleteButtonEnable = true;
            appearance8.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            grid1.DisplayLayout.Appearance = appearance8;
            grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance9.BackColor = System.Drawing.Color.Gray;
            grid1.DisplayLayout.CaptionAppearance = appearance9;
            grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            grid1.DisplayLayout.GroupByBox.Hidden = true;
            grid1.DisplayLayout.InterBandSpacing = 2;
            grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance10.BackColor = System.Drawing.Color.RoyalBlue;
            appearance10.FontData.BoldAsString = "True";
            appearance10.ForeColor = System.Drawing.Color.White;
            grid1.DisplayLayout.Override.ActiveRowAppearance = appearance10;
            grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All;
            grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance11.BackColor = System.Drawing.Color.DimGray;
            appearance11.BackColor2 = System.Drawing.Color.Silver;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.BorderColor = System.Drawing.Color.White;
            appearance11.FontData.BoldAsString = "True";
            appearance11.ForeColor = System.Drawing.Color.White;
            grid1.DisplayLayout.Override.HeaderAppearance = appearance11;
            grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance12.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            appearance12.BackColor2 = System.Drawing.Color.Gray;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            grid1.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance12;
            grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            grid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            grid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            grid1.EnterNextRowEnable = true;
            grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75f);
            grid1.Location = new System.Drawing.Point(5, 3);
            grid1.Name = "grid1";
            grid1.Size = new System.Drawing.Size(351, 391);
            grid1.TabIndex = 0;
            grid1.Text = "grid1";
            grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            grid1.Click += new System.EventHandler(grid1_Click);
            grid1.DoubleClick += new System.EventHandler(grid1_DoubleClick);
            appearance13.FontData.BoldAsString = "False";
            appearance13.FontData.UnderlineAsString = "False";
            appearance13.ForeColor = System.Drawing.Color.Black;
            txtProgramID_H.Appearance = appearance13;
            txtProgramID_H.AutoSize = false;
            txtProgramID_H.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtProgramID_H.Location = new System.Drawing.Point(98, 11);
            txtProgramID_H.Name = "txtProgramID_H";
            txtProgramID_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtProgramID_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtProgramID_H.Size = new System.Drawing.Size(258, 21);
            txtProgramID_H.TabIndex = 246;
            appearance14.FontData.BoldAsString = "False";
            appearance14.FontData.UnderlineAsString = "False";
            appearance14.ForeColor = System.Drawing.Color.Black;
            txtProgramName_H.Appearance = appearance14;
            txtProgramName_H.AutoSize = false;
            txtProgramName_H.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtProgramName_H.Location = new System.Drawing.Point(98, 38);
            txtProgramName_H.Name = "txtProgramName_H";
            txtProgramName_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtProgramName_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtProgramName_H.Size = new System.Drawing.Size(258, 21);
            txtProgramName_H.TabIndex = 247;
            base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
            base.ClientSize = new System.Drawing.Size(629, 470);
            base.Controls.Add(ultraGroupBox2);
            base.Controls.Add(gbxHeader);
            base.Name = "POP_SY0101";
            Text = "프로그램 관리";
            base.Load += new System.EventHandler(POP_SY0101_Load);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).EndInit();
            gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ultraGroupBox2).EndInit();
            ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gbxProgramInfor).EndInit();
            gbxProgramInfor.ResumeLayout(false);
            gbxProgramInfor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UseFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboMenuType).EndInit();
            ((System.ComponentModel.ISupportInitialize)uceSaveFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)ucePrnFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)uceExcelFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)uceInqFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)uceNewFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)uceDelFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUidName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFileID).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNameSpace).EndInit();
            ((System.ComponentModel.ISupportInitialize)grid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProgramID_H).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProgramName_H).EndInit();
            ResumeLayout(false);
        }
    }
}

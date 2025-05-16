using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class POP_TSY0101 : WIZ.Forms.BasePopupForm
    {
        #region <MEMBER AREA>
        // 변수나 Form에서 사용될 Class를 정의
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
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Com = new Common();

        public Binding INQFLAG = null;
        public Binding DELFLAG = null;
        public Binding PRNFLAG = null;
        public Binding NEWFLAG = null;
        public Binding SAVEFLAG = null;
        public Binding EXCELFLAG = null;
        #endregion

        public POP_TSY0101(string grpid)
        {
            InitializeComponent();

            this.GRPID = grpid;
        }

        #region < Event >
        private void btnInquire_Click(object sender, EventArgs e)
        {
            try
            {
                DtTemp.Rows.Clear();
                DtGrid1.Rows.Clear();
                DtTemp = USP_SY0710_S2(this.GRPID);

                this.grid1.DataSource = DtTemp;
                this.grid1.DataBind();
                DtGrid1 = DtTemp;
                this.Binding();
            }
            catch (Exception ex)
            {
                WIZ.Forms.MessageForm message = new WIZ.Forms.MessageForm(ex);
                message.ShowDialog();
            }
        }

        private void grid1_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count != 0)
            {
                this.txtProgramID_H.Text = this.grid1.ActiveRow.Cells["PROGRAMID"].Value.ToString();
                this.txtProgramName_H.Text = this.grid1.ActiveRow.Cells["MENUNAME"].Value.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Cancel = true;
            this.Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count != 0)
            {
                this.ProgramID = this.txtProgramID_H.Text = Convert.ToString(this.grid1.ActiveRow.Cells["PROGRAMID"].Value);
                this.ProgramNM = this.txtProgramName_H.Text = Convert.ToString(this.grid1.ActiveRow.Cells["MENUNAME"].Value);
                this.NameSpace = Convert.ToString(this.grid1.ActiveRow.Cells["NAMESPACE"].Value);
                this.FileID = Convert.ToString(this.grid1.ActiveRow.Cells["FILEID"].Value);
                this.MenuType = Convert.ToString(this.grid1.ActiveRow.Cells["MENUTYPE"].Value);
                this.ProgType = Convert.ToString(this.grid1.ActiveRow.Cells["PROGTYPE"].Value);
                this.menuid = Convert.ToInt32(this.grid1.ActiveRow.Cells["MENUID"].Value);
                this.parmenuid = Convert.ToInt32(this.grid1.ActiveRow.Cells["PARMENUID"].Value);
                this.sort = Convert.ToInt32(this.grid1.ActiveRow.Cells["SORT"].Value);
                this.chk_inq = (bool)this.uceInqFlag.CheckedValue == true ? 1 : 0;
                this.chk_new = (bool)this.uceNewFlag.CheckedValue == true ? 1 : 0;
                this.chk_del = (bool)this.uceDelFlag.CheckedValue == true ? 1 : 0;
                this.chk_save = (bool)this.uceSaveFlag.CheckedValue == true ? 1 : 0;
                this.chk_prn = (bool)this.ucePrnFlag.CheckedValue == true ? 1 : 0;
                this.chk_excel = (bool)this.uceExcelFlag.CheckedValue == true ? 1 : 0;
            }

            this.Close();
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count != 0)
            {
                this.ProgramID = this.txtProgramID_H.Text = Convert.ToString(this.grid1.ActiveRow.Cells["PROGRAMID"].Value);
                this.ProgramNM = this.txtProgramName_H.Text = Convert.ToString(this.grid1.ActiveRow.Cells["MENUNAME"].Value);
                this.NameSpace = Convert.ToString(this.grid1.ActiveRow.Cells["NAMESPACE"].Value);
                this.FileID = Convert.ToString(this.grid1.ActiveRow.Cells["FILEID"].Value);
                this.MenuType = Convert.ToString(this.grid1.ActiveRow.Cells["MENUTYPE"].Value);
                this.ProgType = Convert.ToString(this.grid1.ActiveRow.Cells["PROGTYPE"].Value);
                this.menuid = Convert.ToInt32(this.grid1.ActiveRow.Cells["MENUID"].Value);
                this.parmenuid = Convert.ToInt32(this.grid1.ActiveRow.Cells["PARMENUID"].Value);
                this.sort = Convert.ToInt32(this.grid1.ActiveRow.Cells["SORT"].Value);
                this.chk_inq = (bool)this.uceInqFlag.CheckedValue == true ? 1 : 0;
                this.chk_new = (bool)this.uceNewFlag.CheckedValue == true ? 1 : 0;
                this.chk_del = (bool)this.uceDelFlag.CheckedValue == true ? 1 : 0;
                this.chk_save = (bool)this.uceSaveFlag.CheckedValue == true ? 1 : 0;
                this.chk_prn = (bool)this.ucePrnFlag.CheckedValue == true ? 1 : 0;
                this.chk_excel = (bool)this.uceExcelFlag.CheckedValue == true ? 1 : 0;
            }

            this.Close();
        }
        #endregion

        #region < Form Load >
        private void SY0710_Load(object sender, EventArgs e)
        {
            GridInit();

            DtTemp = USP_SY0710_S2(this.GRPID);

            this.grid1.DataSource = DtTemp;
            this.grid1.DataBind();
            DtGrid1 = DtTemp;
            this.Binding();
        }
        #endregion

        #region GRID SETTING
        private void GridInit()
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);

            // InitColumnUltraGrid 
            _GridUtil.InitColumnUltraGrid(grid1, "PROGRAMID", "프로그램ID", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MENUNAME", "프로그램명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MENUID", "MENUID", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PARMENUID", "PARMENUID", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SORT", "SORT", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UIDNAME", "다국어명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MENUTYPE", "메뉴유형", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PROGTYPE", "PROGTYPE", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INQFLAG", "조회", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NEWFLAG", "추가", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SAVEFLAG", "저장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DELFLAG", "삭제", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EXCELFLAG", "엑셀", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRNFLAG", "출력", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NAMESPACE", "NAMESPACE", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FILEID", "파일ID", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            for (int i = 0; i < this.grid1.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this.grid1.DisplayLayout.Bands[0].Columns[i].CellClickAction = CellClickAction.RowSelect;
                this.grid1.DisplayLayout.Bands[0].Columns[i].CellActivation = Activation.NoEdit;
            }

            //데이터 머지 된 상태에서 그리드 컬럼 소트 기능 막기     
            //  grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            _GridUtil.SetInitUltraGridBind(grid1);

            DtGrid1 = (DataTable)this.grid1.DataSource;
            #endregion
        }
        #endregion

        #region 그룹 ID 조회
        /// <summary>
        /// 공통코드
        /// </summary>
        /// <param name="sMajorCD"></param>
        /// <param name="sUseFlag"></param>
        /// <returns></returns>
        private DataTable USP_SY0710_S2(string sGrpID)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                return helper.FillTable("USP_SY0101_POP", CommandType.StoredProcedure
                                                , helper.CreateParameter("AS_GRPID", sGrpID, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_LANG", WIZ.Common.Lang, DbType.String, ParameterDirection.Input));

            }
            catch (Exception ex)
            {
                WIZ.Forms.MessageForm msgform = new WIZ.Forms.MessageForm(ex);
                msgform.ShowDialog();
                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        private void Binding()
        {
            #region 컨트롤 바인딩 (메뉴정보)

            cboMenuType.DataBindings.Clear();
            cboMenuType.DataBindings.Add("Value", DtGrid1, "MENUTYPE");
            UseFlag.DataBindings.Clear();
            UseFlag.DataBindings.Add("Value", DtGrid1, "USEFLAG");
            txtUidName.DataBindings.Clear();
            txtUidName.DataBindings.Add("Value", DtGrid1, "MENUNAME");
            #endregion

            #region 프로그램정보

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

            this.uceInqFlag.DataBindings.Clear();
            this.uceInqFlag.DataBindings.Add(INQFLAG);
            this.uceDelFlag.DataBindings.Clear();
            this.uceDelFlag.DataBindings.Add(DELFLAG);
            this.ucePrnFlag.DataBindings.Clear();
            this.ucePrnFlag.DataBindings.Add(PRNFLAG);
            this.uceNewFlag.DataBindings.Clear();
            this.uceNewFlag.DataBindings.Add(NEWFLAG);
            this.uceSaveFlag.DataBindings.Clear();
            this.uceSaveFlag.DataBindings.Add(SAVEFLAG);
            this.uceExcelFlag.DataBindings.Clear();
            this.uceExcelFlag.DataBindings.Add(EXCELFLAG);

            txtNameSpace.DataBindings.Clear();
            txtNameSpace.DataBindings.Add("Value", DtGrid1, "NAMESPACE");

            txtFileID.DataBindings.Clear();
            txtFileID.DataBindings.Add("Value", DtGrid1, "FILEID");
            #endregion
        }

        private void ComboBind(object send, ConvertEventArgs e)
        {
            if (e.Value == DBNull.Value) e.Value = false;
            e.Value = (Convert.ToString(e.Value) != "0" && (Convert.ToString(e.Value) == "1" || Convert.ToBoolean(e.Value)));
        }
    }
}

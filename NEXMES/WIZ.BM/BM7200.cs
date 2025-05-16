#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;


#endregion

namespace WIZ.BM
{
    public partial class BM7200 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        private string PlantCode = string.Empty;
        private DataTable DtGrid1 = new DataTable();
        private DataTable DtGrid2 = new DataTable();
        private DataTable DtGrid3 = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        private bool StatusCheck = false;   //DoSearch 시점에 상태값 변경 하기 위해 사용
        #endregion

        #region < CONSTRUCTOR >
        public BM7200()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager gridManager = new BizGridManager(grid1);

            btbManager.PopUpAdd(txtLineCode, txtLineName, "TBM0500", new object[] { "", "" });
            gridManager.PopUpAdd("LineCode", "LineName", "TBM0500", new string[] { "", "" });   //라인

            this.PlantCode = CModule.GetAppSetting("SITE", "10");
        }
        #endregion

        #region <TOOL BAR AREA >
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(this.grid1);
            string rbtn = "";
            if (rbtnALL.Checked == true)
            {
                rbtn = "1";
            }
            else if (rbtnOver.Checked == true)
            {
                rbtn = "2";
            }
            else if (rbtnZero.Checked == true)
            {
                rbtn = "3";
            }

            base.DoInquire();

            string linecode = (string)this.txtLineCode.Text;
            if (linecode == null)
                linecode = "";

            rtnDtTemp = this.USP_BM7200_S1(this.PlantCode
                                       , linecode
                                       , rbtn);
            if (rtnDtTemp.Rows.Count > 0)
            {
                DtGrid1 = rtnDtTemp;
                grid1.DataSource = rtnDtTemp;
                this.grid1.DataBind();
            }
            else
            {

                this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

        }

        public override void DoNew()
        {
            if (this.grid1.Rows.Count > 0)
            {
                base.DoNew();
                if (this.grid1.ActiveRow.Cells["LineCode"].Value.ToString() == "")
                {
                }
                if (this.grid2.IsActivate)
                {
                    this.grid2.InsertRow();

                    this.txtWorkerID_H.Text = "";
                    this.txtWorkerName.Text = "";

                    this.grid2.ActiveRow.Cells["WorkerID"].Value = this.txtWorkerID_H.Text.ToString();
                    this.grid2.ActiveRow.Cells["WorkerName"].Value = this.txtWorkerName.Text.ToString();
                    this.grid2.ActiveRow.Cells["MailID"].Value = this.MailID.Text.ToString();
                    this.grid2.ActiveRow.Cells["PhoneNO"].Value = this.PhoneNo.Text.ToString();

                    this.grid2.ActiveRow.Cells["PlantCode"].Value = this.PlantCode;
                    this.grid2.ActiveRow.Cells["OPCode"].Value = "*";
                    this.grid2.ActiveRow.Cells["UseFlag"].Value = "Y";
                    this.grid2.ActiveRow.Cells["LineCode"].Value = this.grid1.ActiveRow.Cells["LineCode"].Value.ToString();
                    return;
                }
                if (this.grid3.IsActivate)
                {
                    if (this.grid3.Rows.Count == 1)
                        return;
                    this.grid3.InsertRow();

                    this.grid3.ActiveRow.Cells["PlantCode"].Value = this.PlantCode;
                    this.grid3.ActiveRow.Cells["LineCode"].Value = this.grid1.ActiveRow.Cells["LineCode"].Value.ToString();
                    this.grid3.ActiveRow.Cells["OPCode"].Value = "*";
                    this.grid3.ActiveRow.Cells["MACHID"].Value = "*";
                    this.grid3.ActiveRow.Cells["Remarks"].Value = "";
                    this.grid3.ActiveRow.Cells["UseFlag"].Value = "Y";

                    string criticalno = string.Empty;
                    for (int i = 0; i < 15; i++)
                    {
                        criticalno = "Critical" + (101 + i).ToString().Substring(1, 2);
                        this.grid3.ActiveRow.Cells[criticalno].Value = "N";
                    }
                }

            }
            else return;
        }

        public override void DoDelete()
        {
            base.DoDelete();

            if (this.grid3.IsActivate)
            {
                this.grid3.DeleteRow();
                return;
            }
            if (this.grid2.IsActivate)
            {
                this.grid2.DeleteRow();
            }
        }

        public override void DoSave()
        {
            try
            {
                base.DoSave();

                this.grid2.SetRow();

                this.grid2.PerformAction(UltraGridAction.DeactivateCell);
                this.grid3.PerformAction(UltraGridAction.DeactivateCell);

                if (UltraGridUtil.CheckSaveDataGrid(this, this.grid2, DtGrid2, true) == true)
                {
                    USP_BM7200_CRUD_2(DtGrid2, this.WorkerID);
                }
                if (UltraGridUtil.CheckSaveDataGrid(this, this.grid3, DtGrid3, true) == true)
                {
                    USP_BM7200_CRUD_3(DtGrid3, this.WorkerID);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region < EVENT AREA >

        // 라인코드 수정시 텍스트 박스 삭제
        private void txtLineCode_H_ValueChanged(object sender, EventArgs e)
        {
            this.txtLineName.Text = string.Empty;
        }

        // 그리드1 클릭
        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {
            string enter = e.KeyCode.ToString();
            if (enter == "Return")
            {
                Infragistics.Win.UltraWinGrid.GridKeyActionMapping KeyMapping1 = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Tab, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0);
                this.grid1.KeyActionMappings.Add(KeyMapping1);
                this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
            }
        }

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            _GridUtil.Grid_Clear(this.grid2);
            _GridUtil.Grid_Clear(this.grid3);
            rtnDtTemp = this.USP_BM7200_S2(this.grid1.ActiveRow.Cells["PlantCode"].Value.ToString()
                              , this.grid1.ActiveRow.Cells["LineCode"].Value.ToString()
                              );
            if (rtnDtTemp.Rows.Count > 0)
            {
                DtGrid2 = rtnDtTemp;
                this.grid2.DataSource = rtnDtTemp;
                this.grid2.DataBind();
            }

            rtnDtTemp = this.USP_BM7200_S3(this.grid1.ActiveRow.Cells["PlantCode"].Value.ToString()
                              , this.grid1.ActiveRow.Cells["LineCode"].Value.ToString()
                              );
            if (rtnDtTemp.Rows.Count > 0)
            {
                DtGrid3 = rtnDtTemp;
                this.grid3.DataSource = rtnDtTemp;
                this.grid3.DataBind();
            }
        }

        private void grid2_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
        }
        #endregion

        #region LOAD
        private void BM7200_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "Org Code", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USRCNT", "사용자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.SetColumnMerge(this, grid1, "LINECODE");

            DtGrid1 = (DataTable)this.grid1.DataSource;
            #endregion

            #region Grid2 셋팅
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", true);

            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "Org Code", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKERID", "ID", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKERNAME", "담당자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAILID", "MAIL", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PHONENO", "PHONE", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LINECODE", "LINE", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OPCODE", "공정", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARKS", "비고", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용유무", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.SetColumnMerge(this, grid2, "LINECODE");
            //사용여부
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("USEYN");
            UltraGridUtil.SetComboUltraGrid(this.grid2, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            DtGrid2 = (DataTable)this.grid2.DataSource;
            #endregion

            #region Grid3 셋팅
            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", true);

            // InitColumnUltraGrid 
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "Org Code", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LINECODE", "LINE", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LineName", "라인명", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "OPCODE", "공정", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "OPName", "공정명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MACHID", "설비", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "Machname", "설비명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "USEFLAG", "사용유무", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL01", "관리이탈", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL02", "런(RUN)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL03", "경향", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL04", "진동", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL05", "영역경보(3SIGMA)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL06", "영역경보(2SIGMA)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL07", "영역경보(1SIGMA01)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL08", "영역경보(1SIGMA01)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL09", "", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL10", "", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL11", "", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL12", "", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL13", "", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL14", "", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CRITICAL15", "", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "REMARKS", "사용비고", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKEDATE", "등록일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITDATE", "수정일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid3);

            _GridUtil.SetColumnMerge(this, grid3, "LINECODE");
            //사용여부
            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부            
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL01", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL02", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL03", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL04", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL05", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL06", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL07", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL08", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL09", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL10", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL11", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL12", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL13", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL14", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "CRITICAL15", rtnDtTemp, "CODE_ID", "CODE_NAME");

            DtGrid3 = (DataTable)this.grid3.DataSource;
            #endregion
        }
        #endregion

        #region grid1 조회
        private DataTable USP_BM7200_S1(string AS_PLANTCODE, string AS_LINECODE, string AS_USEFLAG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_BM7200_S1N", CommandType.StoredProcedure
                                                                      , helper.CreateParameter("PLANTCODE", AS_PLANTCODE, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("LINECODE", AS_LINECODE, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("BTNCHECK", AS_USEFLAG, DbType.String, ParameterDirection.Input));

                return rtnDtTemp;
            }
            catch (Exception ex)
            {

                WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm(ex.ToString());
                checkform.ShowDialog();

                return new DataTable();
            }
            finally
            {

                helper.Close();
            }
        }
        #endregion

        #region grid2 조회
        private DataTable USP_BM7200_S2(string AS_PLANTCODE, string AS_LINECODE)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_BM7200_S2N", CommandType.StoredProcedure
                                                                      , helper.CreateParameter("PLANTCODE", AS_PLANTCODE, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("LINECODE", AS_LINECODE, DbType.String, ParameterDirection.Input));

                return rtnDtTemp;
            }
            catch (Exception ex)
            {

                WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm(ex.ToString());

                checkform.ShowDialog();

                return new DataTable();
            }
            finally
            {

                helper.Close();
            }
        }
        #endregion

        #region grid3 조회
        private DataTable USP_BM7200_S3(string AS_PLANTCODE, string AS_LINECODE)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_BM7200_S3N", CommandType.StoredProcedure
                                                                      , helper.CreateParameter("PLANTCODE", AS_PLANTCODE, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("LINECODE", AS_LINECODE, DbType.String, ParameterDirection.Input));



                return rtnDtTemp;
            }
            catch (Exception ex)
            {

                WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm(ex.ToString());
                checkform.ShowDialog();

                return new DataTable();
            }
            finally
            {

                helper.Close();
            }
        }
        #endregion

        #region GRID2 저장/수정/삭제
        public void USP_BM7200_CRUD_2(DataTable DtChange, string USER_ID)
        {
            DataTable dt = grid2.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper(false);

            try
            {

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PLANTCODE"].ToString().Trim() == "")
                        {
                            grid2.SetRowError(drRow, "사업장 코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM7200_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("WORKERID", Convert.ToString(drRow["WORKERID"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LINECODE", Convert.ToString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM7200_I1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LINECODE", Convert.ToString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCODE", Convert.ToString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKERID", Convert.ToString(drRow["WORKERID"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REMARKS", Convert.ToString(drRow["REMARKS"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKER", USER_ID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM7200_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LINECODE", Convert.ToString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCODE", Convert.ToString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKERID", Convert.ToString(drRow["WORKERID"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REMARKS", Convert.ToString(drRow["REMARKS"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EDITOR", USER_ID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid2.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid2.SetAcceptChanges("PLANTCODE");

                helper.Commit();
            }
            catch (Exception ex)
            {

                helper.Rollback();


                WIZ.Forms.CheckForm checkform = new Forms.CheckForm(ex.ToString());
                checkform.ShowDialog();
            }
            finally
            {

                helper.Close();
            }
        }
        #endregion

        #region GRID3 저장/수정/삭제
        public void USP_BM7200_CRUD_3(DataTable DtChange, string USER_ID)
        {
            DataTable dt = grid3.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);
            try
            {

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PLANTCODE"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "사업장 코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM7200_D3N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LINECODE", Convert.ToString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM7200_I3N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LINECODE", DBHelper.nvlString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCODE", DBHelper.nvlString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MACHID", DBHelper.nvlString(drRow["MACHID"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL01", DBHelper.nvlString(drRow["CRITICAL01"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL02", DBHelper.nvlString(drRow["CRITICAL02"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL03", DBHelper.nvlString(drRow["CRITICAL03"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL04", DBHelper.nvlString(drRow["CRITICAL04"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL05", DBHelper.nvlString(drRow["CRITICAL05"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL06", DBHelper.nvlString(drRow["CRITICAL06"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL07", DBHelper.nvlString(drRow["CRITICAL07"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL08", DBHelper.nvlString(drRow["CRITICAL08"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL09", DBHelper.nvlString(drRow["CRITICAL09"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL10", DBHelper.nvlString(drRow["CRITICAL10"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL11", DBHelper.nvlString(drRow["CRITICAL11"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL12", DBHelper.nvlString(drRow["CRITICAL12"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL13", DBHelper.nvlString(drRow["CRITICAL13"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL14", DBHelper.nvlString(drRow["CRITICAL14"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL15", DBHelper.nvlString(drRow["CRITICAL15"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REMARKS", DBHelper.nvlString(drRow["REMARKS"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKER", USER_ID, DbType.String, ParameterDirection.Input));

                            /* , helper.CreateParameter("PLANTCODE",  helper.nvlString(drRow["PLANTCODE"]),  DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("LINECODE",   helper.nvlString(drRow["LINECODE"]),   DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("OPCODE",     helper.nvlString(drRow["OPCODE"]),     DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("MACHID",     helper.nvlString(drRow["MACHID"]),     DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL01", helper.nvlString(drRow["CRITICAL01"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL02", helper.nvlString(drRow["CRITICAL02"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL03", helper.nvlString(drRow["CRITICAL03"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL04", helper.nvlString(drRow["CRITICAL04"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL05", helper.nvlString(drRow["CRITICAL05"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL06", helper.nvlString(drRow["CRITICAL06"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL07", helper.nvlString(drRow["CRITICAL07"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL08", helper.nvlString(drRow["CRITICAL08"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL09", helper.nvlString(drRow["CRITICAL09"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL10", helper.nvlString(drRow["CRITICAL10"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL11", helper.nvlString(drRow["CRITICAL11"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL12", helper.nvlString(drRow["CRITICAL12"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL13", helper.nvlString(drRow["CRITICAL13"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL14", helper.nvlString(drRow["CRITICAL14"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("CRITICAL15", helper.nvlString(drRow["CRITICAL15"]), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("REMARKS",    helper.nvlString(drRow["REMARKS"]),    DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("USEFLAG",    helper.nvlString(drRow["USEFLAG"]),    DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("MAKER",      USER_ID,                               DbType.String, ParameterDirection.Input));*/

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM7200_U3N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LINECODE", Convert.ToString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCODE", Convert.ToString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MACHID", Convert.ToString(drRow["MACHID"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL01", Convert.ToString(drRow["CRITICAL01"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL02", Convert.ToString(drRow["CRITICAL02"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL03", Convert.ToString(drRow["CRITICAL03"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL04", Convert.ToString(drRow["CRITICAL04"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL05", Convert.ToString(drRow["CRITICAL05"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL06", Convert.ToString(drRow["CRITICAL06"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL07", Convert.ToString(drRow["CRITICAL07"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL08", Convert.ToString(drRow["CRITICAL08"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL09", Convert.ToString(drRow["CRITICAL09"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL10", Convert.ToString(drRow["CRITICAL10"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL11", Convert.ToString(drRow["CRITICAL11"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL12", Convert.ToString(drRow["CRITICAL12"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL13", Convert.ToString(drRow["CRITICAL13"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL14", Convert.ToString(drRow["CRITICAL14"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CRITICAL15", Convert.ToString(drRow["CRITICAL15"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REMARKS", Convert.ToString(drRow["REMARKS"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EDITOR", USER_ID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PLANTCODE");

                helper.Commit();
            }
            catch (Exception ex)
            {

                helper.Rollback();


                WIZ.Forms.CheckForm checkform = new Forms.CheckForm(ex.ToString());
                checkform.ShowDialog();
            }
            finally
            {

                helper.Close();
            }
        }
        #endregion 
    }
}

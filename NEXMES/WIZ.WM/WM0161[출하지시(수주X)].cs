#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0161
//   Form Name    : 출하지시조회 - 수주현황 없이
//   Name Space   : WIZ.WM
//   Created Date : 2020-07-07
//   Made By      : JEJUN
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Text;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0161 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;
        BizGridManager bizGridManager2;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();

        DataTable dtGrid;
        DataTable dtGrid2;
        /// <summary>
        /// 생성시 그리드 컬럼 숫자
        /// </summary>
        public int grid3Count = 0;
        #endregion

        #region < CONSTRUCTOR >
        public WM0161()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void WM0161_Load(object sender, EventArgs e)
        {
            GridInitialize();

        }

        private void GridInitialize()
        {
            try
            {
                //grid2
                _GridUtil.InitializeGrid(grid2, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTSEQ", "수주순번", false, GridColDataType_emu.VarChar, 130, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SELOUTNO", "출하지시번호", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "RECDATE", "출하계획일자", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ENDDATE", "출하완료날짜", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTCODE", "고객번호", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.SetInitUltraGridBind(grid2);

                //gird3
                _GridUtil.InitializeGrid(grid3, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "SELOUTNO", "출하지시번호", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 250, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANQTY", "계획수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "SHIPQTY", "실제수량", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.SetInitUltraGridBind(grid3);

                #region --- Combobox & Popup Setting ---
                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;
                cbo_NEWORDERDATE_H.Value = DateTime.Now;

                rtnDtTemp = _Common.GET_BM0130_CODE("Y");
                UltraGridUtil.SetComboUltraGrid(this.grid3, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

                //거래처
                btbManager.PopUpAdd(txt_CUSTCODE_H, txt_CUSTNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "", "", "Y" });
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "1", "" });

                bizGridManager = new BizGridManager(this.grid2);
                bizGridManager.PopUpAdd("CustCode", "CustName", "BM0030", new string[] { "PlantCode", "", "Y" });

                bizGridManager2 = new BizGridManager(this.grid3);
                bizGridManager2.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "1", "Y" });
                bizGridManager2.PopUpClosed += BizGridManager2_PopUpClosed;
                #endregion
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }

        private void BizGridManager2_PopUpClosed(Control.Grid grid, string sCode, string sName, bool bFindOK)
        {
            DBHelper helper = new DBHelper(false);

            string sPlantCode = CModule.ToString(grid.ActiveRow.Cells["PLANTCODE"].Value);
            string sSelOutNo = CModule.ToString(grid.ActiveRow.Cells["SELOUTNO"].Value);

            DataSet ds = helper.FillDataSet("USP_AP0160_S4", CommandType.StoredProcedure
                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("AS_ITEMCODE", sCode, DbType.String, ParameterDirection.Input));

            if (ds.Tables.Count >= 1)
            {
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    grid.ActiveRow.Cells["UNITCODE"].Value = CModule.ToString(ds.Tables[0].Rows[0]["UNITCODE"]);
                }
            }

            if (ds.Tables.Count >= 2)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    if (CModule.ToString(ds.Tables[1].Rows[i]["SELOUTNO"]) == sSelOutNo && CModule.ToString(ds.Tables[1].Rows[i]["ITEMCODE"]) == sCode)
                    {
                        grid.ActiveRow.Cells["SHIPQTY"].Value = string.Format("{0:#,##0}", CModule.ToDouble(ds.Tables[1].Rows[i]["OUTQTY"]));
                        break;
                    }
                }
            };
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            bNew = false;

            DBHelper helper = new DBHelper(false);

            if (!CheckData())
            {
                return;
            }

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sLotNO = DBHelper.nvlString(txt_LOTNO_H.Text);

                _GridUtil.Grid_Clear(grid2);
                _GridUtil.Grid_Clear(grid3);

                base.DoInquire();

                dtGrid = helper.FillTable("USP_WM0160_S1", CommandType.StoredProcedure
                           , helper.CreateParameter("AS_CLOSEFLAG", DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_CONTRACTNO", "", DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_CONTRACTSEQ", "", DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ITEMCODE", txt_ITEMCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ITEMNAME", txt_ITEMNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_SELOUTNO", sLotNO, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_STARTDATE", sSDate, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ENDDATE", sEDate, DbType.String, ParameterDirection.Input));

                grid2.DataSource = dtGrid;
                grid2.DataBinds(dtGrid);
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();

                helper.Close();
            }
        }

        public override void DoNew()
        {
            base.DoNew();

            DBHelper helper = new DBHelper(false);

            try
            {
                if (grid2.IsActivate)
                {

                    bNew = true;

                    this.grid2.InsertRow();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid2.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                    this.grid2.ActiveRow.Cells["SELOUTNO"].Value = "[ NEW SHIP ]";
                    this.grid2.ActiveRow.Cells["RECDATE"].Value = string.Format("{0:yyyy-MM-dd}", this.cbo_NEWORDERDATE_H.Value);

                    //사용자 입력 필요한 부분 기본 세팅
                    //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                    grid2.ActiveRow.Cells["PLANTCODE"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["CONTRACTNO"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["CONTRACTSEQ"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["SELOUTNO"].Activation = Activation.NoEdit;

                    _GridUtil.Grid_Clear(grid3);
                }
                else if (grid3.IsActivate)
                {
                    if (this.grid2.ActiveRow.Cells["SELOUTNO"].Value.ToString() == "")
                    {
                        return;
                    }

                    this.grid3.InsertRow();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid3.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                    this.grid3.ActiveRow.Cells["SELOUTNO"].Value = this.grid2.ActiveRow.Cells["SELOUTNO"].Value;

                    grid3.ActiveRow.Cells["PLANTCODE"].Activation = Activation.NoEdit;
                    grid3.ActiveRow.Cells["SELOUTNO"].Activation = Activation.NoEdit;
                    grid3.ActiveRow.Cells["SHIPQTY"].Activation = Activation.NoEdit;
                    grid3.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoDelete()
        {
            DBHelper helper = new DBHelper("", true);
            if (grid2.IsActivate)
            {
                //this.grid2.DeleteRow();
                DataRow dr = null;
                dr = (grid2.ActiveRow.ListObject as DataRowView).Row;

                if (dr != null)
                {
                    string sPlantCode = string.Empty;
                    string sSoNoDate = string.Empty;
                    string sCustcode = string.Empty;
                    string sSelOutNo = string.Empty;
                    string sItemCode = string.Empty;
                    string sPlanQty = string.Empty;
                    string sShipQty = string.Empty;
                    string sUser = LoginInfo.UserID;

                    #region --- 삭제 ---
                    sSelOutNo = DBHelper.nvlString(dr["SELOUTNO"]);
                    sCustcode = DBHelper.nvlString(dr["CUSTCODE"]);
                    sSoNoDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWORDERDATE_H.Value);
                    sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);

                    helper.ExecuteNoneQuery("USP_WM0161_D1", CommandType.StoredProcedure
                  , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_PLANQTY", sPlanQty, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));
                    #endregion
                    if (helper.RSCODE != "S")
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                        helper.Rollback();
                        return;
                    }
                    else
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                        helper.Commit();
                    }
                }
            }

            if (grid3.IsActivate)
            {
                //this.grid3.DeleteRow();
                DataRow dr = null;
                dr = (grid3.ActiveRow.ListObject as DataRowView).Row;

                if (dr != null)
                {

                    string sPlantCode = string.Empty;
                    string sSoNoDate = string.Empty;
                    string sCustcode = string.Empty;
                    string sSelOutNo = string.Empty;
                    string sItemCode = string.Empty;
                    string sPlanQty = string.Empty;
                    string sShipQty = string.Empty;
                    string sUser = LoginInfo.UserID;


                    #region --- 삭제 ---
                    sSelOutNo = DBHelper.nvlString(dr["SELOUTNO"]);

                    sSoNoDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWORDERDATE_H.Value);
                    sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                    sItemCode = DBHelper.nvlString(dr["ITEMCODE"]);
                    sPlanQty = DBHelper.nvlString(dr["PLANQTY"]);
                    sShipQty = DBHelper.nvlString(dr["SHIPQTY"]);

                    double sS;

                    if (sShipQty != "")
                    {
                        sS = Convert.ToDouble(sShipQty);

                        if (sS != 0)
                        {
                            this.ShowDialog("출하수량이 있으면 삭제가 되지 않습니다.", Forms.DialogForm.DialogType.OK);

                            return;
                        }
                    }

                    helper.ExecuteNoneQuery("USP_WM0161_D1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANQTY", sPlanQty, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE != "S")
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                        helper.Rollback();
                        return;
                    }
                    else
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                        helper.Commit();
                    }
                    #endregion
                }

            }
            helper.Close();
            DoInquire();
        }

        public override void DoSave()
        {

            DataTable dtChange = grid2.chkChange();
            DataTable dtChange2 = grid3.chkChange();
            if (dtChange == null && dtChange2 == null)
                return;


            string sPlantCode = string.Empty;
            string sSoNoDate = string.Empty;
            string sCustcode = string.Empty;
            string sSelOutNo = string.Empty;
            string sItemCode = string.Empty;
            string sPlanQty = string.Empty;
            string sShipQty = string.Empty;
            string sRT_SelOutNo = "";

            string sUser = LoginInfo.UserID;

            //double dOrderQty;

            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();
                if (dtChange != null)
                {
                    foreach (DataRow drChange in dtChange.Rows)
                    {
                        switch (drChange.RowState)
                        {
                            case DataRowState.Deleted:
                                #region --- 삭제 ---

                                #endregion
                                break;
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                #region --- 추가/수정 --
                                sSelOutNo = DBHelper.nvlString(drChange["SELOUTNO"]);
                                sCustcode = DBHelper.nvlString(drChange["CUSTCODE"]);
                                sSoNoDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWORDERDATE_H.Value);
                                sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);

                                helper.ExecuteNoneQuery("USP_WM0160_I1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTNO", DBHelper.nvlString(drChange["CONTRACTNO"]), DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTSEQ", DBHelper.nvlString(drChange["CONTRACTSEQ"]), DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CUSTOMERCODE", sCustcode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_SONODATE", sSoNoDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    throw new Exception(helper.RSMSG);
                                }

                                if (helper.RSMSG.StartsWith("CONNO"))
                                {
                                    sRT_SelOutNo = helper.RSMSG.Split('|')[1];
                                }

                                #endregion
                                break;
                        }
                    }
                }

                if (dtChange2 != null)
                {

                    foreach (DataRow drChange2 in dtChange2.Rows)
                    {
                        switch (drChange2.RowState)
                        {
                            case DataRowState.Deleted:
                                #region --- 삭제 ---

                                #endregion
                                break;
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                #region -- 추가/수정 --
                                sSelOutNo = sRT_SelOutNo == "" ? DBHelper.nvlString(grid2.ActiveRow.Cells["SELOUTNO"].Value) : sRT_SelOutNo;
                                sSoNoDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWORDERDATE_H.Value);
                                sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                                sPlanQty = DBHelper.nvlString(drChange2["PLANQTY"]);
                                sShipQty = DBHelper.nvlString(drChange2["SHIPQTY"]);
                                sItemCode = DBHelper.nvlString(drChange2["ITEMCODE"]);

                                double sP;
                                double sS;

                                sP = DBHelper.nvlDouble(sPlanQty);
                                sS = DBHelper.nvlDouble(sShipQty);

                                if (sP < sS)
                                {
                                    this.ShowDialog("계획수량 출하수량보다 작으면 안됩니다.", Forms.DialogForm.DialogType.OK);

                                    return;
                                }

                                helper.ExecuteNoneQuery("USP_WM0160_I1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTNO", "", DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTSEQ", "", DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_PLANQTY", sPlanQty, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CUSTOMERCODE", "", DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                                #endregion
                                break;
                        }
                        if (helper.RSCODE != "S")
                        {
                            this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                            return;
                        }
                    }
                }

                helper.Commit();

                DoInquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();

                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();

                ClosePrgFormNew();
            }
        }
        #endregion

        #region < EVENT AREA >
        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (grid2.ActiveCell == null)
            {
                this.ShowDialog("셀 선택을 정확하게 하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            DBHelper helper;
            helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                string sSeloutNo = DBHelper.nvlString(grid2.ActiveRow.Cells["SELOUTNO"].Value);

                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("exec USP_CALLPRINT_I1 ");
                sSQL.Append("  @AS_PLANTCODE = '" + sPlantCode + "'");
                sSQL.Append(", @AS_LOTNO = '" + sSeloutNo + "' ");
                sSQL.Append(", @AS_WORKCENTERCODE = '" + "AP0030" + "' ");
                sSQL.Append(", @AS_CIP = '' ");
                sSQL.Append(", @AS_REISSUE = '' ");

                helper.ExecuteNoneQuery(sSQL.ToString());
            }

            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
        }

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (grid2.ActiveCell == null)
            {
                this.ShowDialog("셀 선택을 정확하게 하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            try
            {
                if (bNew)
                {
                    //this.ShowDialog("추가 중인 출하지시가 있습니다.", WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                _GridUtil.Grid_Clear(grid3);

                DBHelper helper;
                helper = new DBHelper(false);

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sSelOutNo = this.grid2.ActiveRow.Cells["SELOUTNO"].Value.ToString();
                string sITEAMCODE = DBHelper.nvlString(txt_ITEMCODE_H.Value);

                dtGrid2 = helper.FillTable("USP_WM0160_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_CLOSEFLAG", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CONTRACTNO", "", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CONTRACTSEQ", "", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_STARTDATE", "", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ENDDATE", "", DbType.String, ParameterDirection.Input));

                if (dtGrid2.Rows.Count > 0)
                {
                    grid3.DataSource = dtGrid2;
                    grid3.DataBinds(dtGrid2);
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
        }

        private bool CheckData()
        {
            int sStDate = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_STARTDATE_H.Value));
            int sEnDate = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_ENDDATE_H.Value));
            if (sStDate > sEnDate)
            {
                this.ShowDialog("시작일자를 종료일자보다 이전으로 선택해주십시오.", Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }
        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }


        #endregion

        #region < METHOD AREA >

        #endregion


    }//CLASS

}//NAMESPACE

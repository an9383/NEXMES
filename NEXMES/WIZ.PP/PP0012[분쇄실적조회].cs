#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0012
//   Form Name    : 분쇄실적조회
//   Name Space   : WIZ.PP
//   Created Date : 2020-03-27
//   Made By      : kjm
//   Description  : 유진하이텍만 사용하는 화면
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using WIZ.Control;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0012 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();
        DataTable rtnDtTemp3 = new DataTable();
        DataTable rtnDtTemp4 = new DataTable();

        DataTable dtGrid;
        DataTable dtGrid2;
        DataTable dtGrid3;
        DataTable dtGrid4;
        /// <summary>
        /// 생성시 그리드 컬럼 숫자
        /// </summary>
        public int grid3Count = 0;
        #endregion

        #region < CONSTRUCTOR >
        public PP0012()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PP0012_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;
            Time1.Value = DateTime.Parse(string.Format("00:00:00"));
            Time2.Value = DateTime.Parse(string.Format("23:59:59"));
            //Time1.Value = DateTime.Now.ToString("hh:mm:ss");
            //cbo_NEWORDERDATE_H.Value = DateTime.Now.AddDays(1);  ToString("yyyy/MM/dd hh:mm:ss")

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;


            rtnDtTemp = _Common.GET_BM0060_CODE("");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            UltraGridUtil.SetComboUltraGrid(this.grid2, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            UltraGridUtil.SetComboUltraGrid(this.grid3, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            //작업장명
            btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });


            btbManager.PopUpClosed += BtbManager_PopUpClosed;

            //bizGridManager = new BizGridManager(grid1);
            //bizGridManager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "", "Y" });
            #endregion
        }

        private void BtbManager_PopUpClosed(object tCode, object tName, bool bFindOK)
        {
            SBtnTextEditor sCode = tCode as SBtnTextEditor;
            SBtnTextEditor sName = tName as SBtnTextEditor;

            if (tCode != null)
            {
                if (sCode.Name == "txt_ITEMCODE_S")
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("Select BACKCOLOR FROM BM0010 with (NOLOCK) where ITEMCODE = '" + sCode.Text.Trim() + "' ");

                    DBHelper db = new DBHelper();

                    DataTable dt = db.FillTable(sSQL.ToString());

                    sCode.Appearance.BackColor = Color.White;
                    sName.Appearance.BackColor = Color.White;

                    if (dt.Rows.Count == 1)
                    {
                        string sBackColor = DBHelper.nvlString(dt.Rows[0]["BACKCOLOR"]);
                        Color _color = ColorTranslator.FromHtml(sBackColor);

                        sCode.Appearance.BackColor = _color;
                        sName.Appearance.BackColor = _color;
                    }
                }
            }
        }

        private void GridInitialize()
        {
            try
            {
                //grid1
                _GridUtil.InitializeGrid(grid1, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 250, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "분쇄재_LOT", false, GridColDataType_emu.VarChar, 180, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INLOTNO", "런너_LOT", false, GridColDataType_emu.VarChar, 180, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INCOUNT", "런너_수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INDATE", "발행일시", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODDATE", "생산일시", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "잔여수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CIP", "IP", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, false, false);

                _GridUtil.SetInitUltraGridBind(grid1);


                _GridUtil.InitializeGrid(grid2, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CLEARCODE", "청소코드", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "RECDATE", "청소날짜", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INDATE", "청소시간", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Right, true, false);


                _GridUtil.SetInitUltraGridBind(grid2);


                _GridUtil.InitializeGrid(grid3, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 250, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "LOTNO", "분쇄재_LOT", false, GridColDataType_emu.VarChar, 180, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "INDATE", "발행일시", false, GridColDataType_emu.DateTime, 150, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "PRODDATE", "생산일시", false, GridColDataType_emu.DateTime, 150, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "PRODQTY", "생산량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "NOWQTY", "잔여수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "CIP", "IP", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, false, false);

                _GridUtil.SetInitUltraGridBind(grid3);


            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            bNew = false;

            string sTabIdx = string.Empty;
            if (tabControl1.SelectedTab.Index == 0)
            {
                sTabIdx = "TAB1";
            }
            else sTabIdx = "TAB2";

            DBHelper helper = new DBHelper(false);


            try
            {

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sWorkcenterCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());
                //string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value) + string.Format("{0: HH:mm:ss}", Time1.Value);
                //string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value) + string.Format("{0: HH:mm:ss}", Time2.Value);

                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string SLotNO = DBHelper.nvlString(txt_LOTNO_H.Text.Trim());

                if (sTabIdx == "TAB1")
                {
                    _GridUtil.Grid_Clear(grid1);
                    _GridUtil.Grid_Clear(grid2);

                    base.DoInquire();

                    dtGrid = helper.FillTable("USP_PP0012_S1", CommandType.StoredProcedure
                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_LOTNO", SLotNO, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_TABIDX", sTabIdx, DbType.String, ParameterDirection.Input));


                    dtGrid2 = helper.FillTable("USP_PP0012_S2", CommandType.StoredProcedure
                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input));



                    // grid1.DataSource = UltraGridUtil.SetSubTotalUltraGrid(grid1, dtGrid, "ORDERDATE", Common.getLangText("[일자별 합계]","TEXT"), "ORDERDATE", "ORDERQTY,PRODQTY", "SUM,SUM");
                    if (dtGrid.Rows.Count > 0 || dtGrid2.Rows.Count > 0)
                    {
                        grid1.DataSource = dtGrid;
                        grid1.DataBinds(dtGrid);

                        grid2.DataSource = dtGrid2;
                        grid2.DataBinds(dtGrid2);
                    }

                }
                if (sTabIdx == "TAB2")
                {
                    _GridUtil.Grid_Clear(grid2);
                    _GridUtil.Grid_Clear(grid3);

                    base.DoInquire();

                    dtGrid = helper.FillTable("USP_PP0012_S1", CommandType.StoredProcedure
                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_LOTNO", SLotNO, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_TABIDX", sTabIdx, DbType.String, ParameterDirection.Input));


                    // grid1.DataSource = UltraGridUtil.SetSubTotalUltraGrid(grid1, dtGrid, "ORDERDATE", Common.getLangText("[일자별 합계]","TEXT"), "ORDERDATE", "ORDERQTY,PRODQTY", "SUM,SUM");
                    if (dtGrid.Rows.Count > 0)
                    {
                        grid3.DataSource = dtGrid;
                        grid3.DataBinds(dtGrid);
                    }

                }

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
            base.DoDelete();


        }

        public override void DoSave()
        {

            DataTable dtChange = grid3.chkChange();

            if (dtChange == null)
                return;

            string sPlantCode = string.Empty;
            string sWorkCenterCode = string.Empty;
            string sItemCode = string.Empty;
            string sLotNo = string.Empty;
            string sInLotNo = string.Empty;
            string sUser = LoginInfo.UserID;
            double sProdQty = 0;

            //double dOrderQty;

            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();

                foreach (DataRow drChange in dtChange.Rows)
                {
                    switch (drChange.RowState)
                    {
                        case DataRowState.Deleted:
                            #region --- 삭제 ---

                            #endregion
                            break;
                        case DataRowState.Added:
                            break;
                        case DataRowState.Modified:
                            #region --- 수정 ---

                            sPlantCode = DBHelper.nvlString(drChange["PLANTCODE"]);
                            sWorkCenterCode = DBHelper.nvlString(drChange["WORKCENTERCODE"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);
                            sLotNo = DBHelper.nvlString(drChange["LOTNO"]);
                            //sInLotNo = DBHelper.nvlString(drChange["INLOTNO"]);
                            sProdQty = DBHelper.nvlDouble(drChange["PRODQTY"]);

                            helper.ExecuteNoneQuery("USP_PP0012_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                             , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PROQTY", sProdQty, DbType.Double, ParameterDirection.Input));

                            if (helper.RSCODE == "S")
                            {
                                helper.Commit();
                                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                            }
                            else
                            {
                                helper.Rollback();
                                this.ShowDialog(helper.RSMSG);
                                return;
                            }
                            #endregion
                            break;
                    }
                    if (helper.RSCODE != "S")
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                        return;
                    }
                }



                helper.Commit();

                // DoInquire();
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
            if (tabControl1.SelectedTab.Index != 0)
            {
                this.ShowDialog("탭 선택을 다시 하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            if (grid1.ActiveCell == null)
            {
                this.ShowDialog("셀 선택을 정확하게 하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }


            DBHelper helper;
            helper = new DBHelper(false);

            try
            {

                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sLotNO = DBHelper.nvlString(grid1.ActiveRow.Cells["LOTNO"].Value);
                string sWorkcenterCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string CIP = DBHelper.nvlString(grid1.ActiveRow.Cells["CIP"].Value);
                string sReissue = "R";


                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("exec USP_CALLPRINT_I1 ");
                sSQL.Append("  @AS_PLANTCODE = '" + sPlantCode + "'");
                sSQL.Append(", @AS_LOTNO = '" + sLotNO + "' ");
                sSQL.Append(", @AS_WORKCENTERCODE = '" + sWorkcenterCode + "' ");
                sSQL.Append(", @AS_CIP = '" + CIP + "' ");
                sSQL.Append(", @AS_REISSUE = '" + sReissue + "' ");

                helper.ExecuteNoneQuery(sSQL.ToString());


            }

            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (grid1.ActiveCell == null)
            {
                this.ShowDialog("셀 선택을 정확하게 하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            try
            {
                _GridUtil.Grid_Clear(grid2);

                DBHelper helper;
                helper = new DBHelper(false);

                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sWorkcenterCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                dtGrid2 = helper.FillTable("USP_PP0012_S2", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input));

                if (dtGrid2.Rows.Count > 0)
                {
                    grid2.DataSource = dtGrid2;
                    grid2.DataBinds(dtGrid2);
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
        }

        private void grid3_BeforeEnterEditMode(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (true)
                {
                    string PRODQTY = DBHelper.nvlString(grid3.ActiveRow.Cells["PRODQTY"].Value);
                    string NOWQTY = DBHelper.nvlString(grid3.ActiveRow.Cells["NOWQTY"].Value);

                    e.Cancel = (NOWQTY != PRODQTY);
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
        }

        #endregion

        #region < METHOD AREA >

        #endregion


    }
}

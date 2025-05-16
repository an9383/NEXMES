#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM0120
//   Form Name    : 부적합 처리
//   Name Space   : WIZ.QM
//   Created Date : 2020-03-06
//   Made By      : IFS팀 최문준
//   Description  : 부적합 처리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.QM
{
    public partial class QM0120 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public QM0120()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void QM0120_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-120);
            cbo_ENDDATE_H.Value = DateTime.Now;

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("COMPLETE_FLAG");
            Common.FillComboboxMaster(this.cbo_CLOSEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "CLOSEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("INCONCAUSETYPE");
            Common.FillComboboxMaster(this.cbo_CLOSEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "INCONCAUSE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

            bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "", "Y" });
            bizGridManager.PopUpAdd("ErrorCode", "ErrorDesc", "BM0100", new string[] { "PlantCode", "", "Y" });
            #endregion

            dtGrid = (DataTable)grid1.DataSource;
        }

        private void GridInitialize()
        {
            try
            {
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSEFLAG", "완료여부", false, GridColDataType_emu.VarChar, 80, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY", "불량수량", false, GridColDataType_emu.VarChar, 80, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORCODE", "불량항목", false, GridColDataType_emu.VarChar, 90, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORDESC", "불량명", false, GridColDataType_emu.VarChar, 120, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", false, GridColDataType_emu.VarChar, 80, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "작업LOTNO", false, GridColDataType_emu.VarChar, 130, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "LOT상태", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", false, GridColDataType_emu.VarChar, 110, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "현재수량", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITINFO", "단위", false, GridColDataType_emu.VarChar, 50, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INCONCAUSE", "부적합구분", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSEDATE", "완료일자", false, GridColDataType_emu.YearMonthDay, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSER", "완료자", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생성일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 150, true, true);

                _GridUtil.SetColumnTextHAlign(grid1, "ERRORQTY", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "ERRORCODE", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "ERRORDESC", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "PRODQTY", Infragistics.Win.HAlign.Center);

                grid1.Columns["PRODQTY"].Format = "#,##0";

                grid1.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Fixed = true;

                _GridUtil.SetInitUltraGridBind(grid1);

                string[] arrMerCol1 = { "CLOSEFLAG", "ERRORQTY", "ERRORCODE", "ERRORDESC" };

                _GridUtil.GridHeaderMerge(grid1, "A1", "부적합 불량 등록", new string[] { "CLOSEFLAG", "ERRORQTY", "ERRORCODE", "ERRORDESC" }, arrMerCol1);

                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
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

            DBHelper helper = new DBHelper(false);

            grid1.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ERRORQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ERRORCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ERRORDESC"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["CLOSEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["REMARK"].Header.Appearance.ForeColor = Color.LightSkyBlue;

            try
            {
                _GridUtil.Grid_Clear(grid1);

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sCloseFlag = Convert.ToString(cbo_CLOSEFLAG_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();

                base.DoInquire();

                dtGrid = helper.FillTable("USP_QM0120_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                //grid1.DataSource = dtGrid;
                //grid1.DataBind();

                this.ClosePrgFormNew();

                // 2020 - 10 - 28 EDIT: 신효철
                if (dtGrid.Rows.Count > 0)               //if (rtnDtTemp.Rows.Count > 0)
                {
                    //2020-10-28 REM : 신효철
                    grid1.DataSource = dtGrid;
                    grid1.DataBind();
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["CLOSEFLAG"].Value) == "N")
                    {
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.BackColor = Color.LightPink;
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.ForeColor = Color.Black;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["CLOSEFLAG"].Value) == "Y")
                    {
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.BackColor = Color.LightGreen;
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.ForeColor = Color.Black;
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

            this.grid1.DeleteRow();
        }

        public override void DoSave()
        {
            DataTable dtChange = grid1.chkChange();

            if (dtChange == null)
                return;

            string sPlantCode = LoginInfo.PlantCode.Trim();
            string sWorkcenterCode = string.Empty;
            string sLotNo = string.Empty;
            string sItemCode = string.Empty;
            string sErrorCode = string.Empty;
            string sCloseDate = string.Empty;
            string sCloseFlag = string.Empty;
            string sCloser = string.Empty;
            string sRemark = string.Empty;
            string sUser = LoginInfo.UserID;

            double? dErrorQty = null;

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
                            #region --- 추가 ---                            

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region --- 수정 ---
                            sWorkcenterCode = Convert.ToString(drChange["WORKCENTERCODE"]);
                            sLotNo = Convert.ToString(drChange["LOTNO"]);
                            sItemCode = Convert.ToString(drChange["ITEMCODE"]);
                            dErrorQty = DBHelper.nvlDouble(drChange["ERRORQTY"]);
                            sErrorCode = Convert.ToString(drChange["ERRORCODE"]);
                            sCloseDate = string.Format("{0:yyyy-MM-dd}", drChange["CLOSEDATE"]);
                            sCloseFlag = Convert.ToString(drChange["CLOSEFLAG"]);
                            sCloser = Convert.ToString(drChange["CLOSER"]);
                            sRemark = Convert.ToString(drChange["REMARK"]);

                            if (dErrorQty.HasValue && sErrorCode != "")
                            {
                                helper.ExecuteNoneQuery("USP_QM0120_I1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AF_ERRORQTY", dErrorQty, DbType.Double, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ERRORCODE", sErrorCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                                helper.ExecuteNoneQuery("USP_QM0120_U1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AF_ERRORQTY", dErrorQty, DbType.Double, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));
                            }

                            helper.ExecuteNoneQuery("USP_QM0120_U2", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CLOSEDATE", sCloseDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CLOSER", sCloser, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
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

                grid1.SetAcceptChanges();

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

        #endregion

        #region < METHOD AREA >

        #endregion

    }
}

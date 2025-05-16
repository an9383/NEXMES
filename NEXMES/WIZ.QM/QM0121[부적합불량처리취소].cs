#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM0121
//   Form Name    : 부적합 불량 처리 취소
//   Name Space   : WIZ.QM
//   Created Date : 2020-03-06
//   Made By      : IFS팀 최문준
//   Description  : 부적합 불량 처리 취소
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
    public partial class QM0121 : WIZ.Forms.BaseMDIChildForm
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
        public QM0121()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void QM0121_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-365);
            cbo_ENDDATE_H.Value = DateTime.Now;

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

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

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 180, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INCONERRNO", "부적합불량번호", false, GridColDataType_emu.VarChar, 130, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "작업LOTNO", false, GridColDataType_emu.VarChar, 150, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "LOT상태", false, GridColDataType_emu.VarChar, 150, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", false, GridColDataType_emu.VarChar, 150, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "현재수량", false, GridColDataType_emu.VarChar, 150, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITINFO", "단위", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY", "불량수량", false, GridColDataType_emu.VarChar, 150, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORCODE", "불량항목", false, GridColDataType_emu.VarChar, 90, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORDESC", "불량명", false, GridColDataType_emu.VarChar, 150, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생성일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 140, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 140, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 500, true, true);

                _GridUtil.SetColumnTextHAlign(grid1, "ERRORQTY", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(grid1, "ERRORCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "ERRORDESC", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "PRODQTY", Infragistics.Win.HAlign.Right);

                grid1.Columns["PRODQTY"].Format = "#,##0";

                _GridUtil.SetInitUltraGridBind(grid1);

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

            grid1.DisplayLayout.Bands[0].Columns["REMARK"].Header.Appearance.ForeColor = Color.LightSkyBlue;

            try
            {
                _GridUtil.Grid_Clear(grid1);

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();

                base.DoInquire();

                dtGrid = helper.FillTable("USP_QM0121_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                //2020-10-28 ADD : 신효철
                grid1.DataSource = dtGrid;
                grid1.DataBinds(dtGrid);

                this.ClosePrgFormNew();

                //2020-10-28 EDIT : 신효철                
                if (grid1.Rows.Count <= 0)               //if (rtnDtTemp.Rows.Count > 0)
                {
                    //2020-10-28 REM : 신효철
                    //grid1.DataSource = dtGrid;
                    //grid1.DataBinds(dtGrid);

                    _GridUtil.Grid_Clear(grid1);

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
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
            string sInconerrNo = string.Empty;
            string sLotNo = string.Empty;
            string sRemark = string.Empty;
            string sUser = LoginInfo.UserID;

            double dErrorQty;

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
                            drChange.RejectChanges();

                            sWorkcenterCode = Convert.ToString(drChange["WORKCENTERCODE"]);
                            sInconerrNo = Convert.ToString(drChange["INCONERRNO"]);
                            sLotNo = Convert.ToString(drChange["LOTNO"]);
                            dErrorQty = DBHelper.nvlDouble(drChange["ERRORQTY"]);

                            helper.ExecuteNoneQuery("USP_QM0121_U1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AF_ERRORQTY", dErrorQty, DbType.Double, ParameterDirection.Input)
                          , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                            helper.ExecuteNoneQuery("USP_QM0121_D1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_INCONERRNO", sInconerrNo, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region --- 추가 ---                            

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region --- 수정 ---
                            sWorkcenterCode = Convert.ToString(drChange["WORKCENTERCODE"]);
                            sInconerrNo = Convert.ToString(drChange["INCONERRNO"]);
                            sLotNo = Convert.ToString(drChange["LOTNO"]);
                            sRemark = Convert.ToString(drChange["REMARK"]);

                            helper.ExecuteNoneQuery("USP_QM0121_U2", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_INCONERRNO", sInconerrNo, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
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

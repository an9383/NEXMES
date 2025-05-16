#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0170
//   Form Name    : 출하지시조회
//   Name Space   : WIZ.WM
//   Created Date : 2020-05-19
//   Made By      : kjm
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0170 : WIZ.Forms.BaseMDIChildForm
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
        public WM0170()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void WM0170_Load(object sender, EventArgs e)
        {
            GridInitialize();

        }

        private void GridInitialize()
        {
            try
            {
                //grid1
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTSEQ", "수주순번", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SELOUTNO", "출하지시번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "출하지시일자", false, GridColDataType_emu.YearMonthDay, 130, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "고객번호", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "고객사", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE", "완료일자", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, false);


                _GridUtil.SetInitUltraGridBind(grid1);
                //grid2
                _GridUtil.InitializeGrid(grid2, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SELOUTNO", "출하지시번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 250, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANQTY", "출하계획수량", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SHIPQTY", "출하수량", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CHECK2", "출하검사", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, true);


                _GridUtil.SetInitUltraGridBind(grid2);

                #region --- Combobox & Popup Setting ---
                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;
                cbo_NEWORDERDATE_H.Value = DateTime.Now;

                rtnDtTemp = _Common.GET_BM0000_CODE("YESNO"); //사용여부               
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "CHECK2", rtnDtTemp, "CODE_ID", "CODE_NAME");



                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

                //거래처
                btbManager.PopUpAdd(txt_CUSTCODE_H, txt_CUSTNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "", "", "Y" });
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "1", "" });

                bizGridManager = new BizGridManager(this.grid1);
                bizGridManager.PopUpAdd("CustCode", "CustName", "BM0030", new string[] { "PlantCode", "", "Y" });


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
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text);
                string sSeloutno = DBHelper.nvlString(txt_SELOUTNO_H.Text); ;
                string sCustCode = DBHelper.nvlString(txt_CUSTCODE_H.Text); ;

                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid2);

                base.DoInquire();

                dtGrid = helper.FillTable("USP_WM0170_S1", CommandType.StoredProcedure
                      , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_SELOUTNO", sSeloutno, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input));

                grid1.DataSource = dtGrid;
                grid1.DataBinds(dtGrid);

                dtGrid2 = helper.FillTable("USP_WM0170_S1", CommandType.StoredProcedure
                      , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_SELOUTNO", sSeloutno, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                grid2.DataSource = dtGrid2;
                grid2.DataBinds(dtGrid2);
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
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }

        public override void DoSave()
        {
            DataTable dtChange = grid2.chkChange();

            if (dtChange == null) return;

            string sPlantCode = string.Empty;
            string sSoNoDate = string.Empty;
            string sItemCode = string.Empty;
            string sSelOutNo = string.Empty;


            string sCheckFlag = string.Empty;

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
                                sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                                sSelOutNo = DBHelper.nvlString(drChange["SELOUTNO"]);
                                sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);
                                sCheckFlag = DBHelper.nvlString(drChange["CHECK2"]);

                                helper.ExecuteNoneQuery("USP_WM0170_I1", CommandType.StoredProcedure
                                 , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("AS_CHECKFLAG", sCheckFlag, DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    throw new Exception(helper.RSMSG);
                                }

                                #endregion
                                break;
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


        #region < EVENT AREA >


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

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value).Trim();
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value).Trim();
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value).Trim();
                string sSelOutNo = DBHelper.nvlString(this.grid1.ActiveRow.Cells["SELOUTNO"].Value);
                string sItemcode = DBHelper.nvlString(txt_ITEMCODE_H.Value).Trim();


                dtGrid2 = helper.FillTable("USP_WM0170_S1", CommandType.StoredProcedure
                                     , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                                     , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                     , helper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
                                     , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                                     , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                                     , helper.CreateParameter("AS_CUSTCODE", "", DbType.String, ParameterDirection.Input)
                                     , helper.CreateParameter("AS_ITEMCODE", sItemcode, DbType.String, ParameterDirection.Input));



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


    }

    #endregion
}

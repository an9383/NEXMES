#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0165
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
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0165 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();

        DataTable dtGrid;
        DataTable dtGrid2;
        #endregion

        #region < CONSTRUCTOR >
        public WM0165()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void WM0165_Load(object sender, EventArgs e)
        {
            GridInitialize();

        }

        private void GridInitialize()
        {
            try
            {
                //grid1
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SELOUTNO", "출하지시번호", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SHIPDATE", "출하일자", false, GridColDataType_emu.VarChar, 90, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SHIPTYPE", "출하종류", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "고객번호", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "고객사", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANQTY", "계획수량", false, GridColDataType_emu.Double, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SHIPQTY", "출하수량", false, GridColDataType_emu.Double, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INQTY", "적재수량", false, GridColDataType_emu.Double, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 140, 0, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SHIPNO", "출하지시번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "SELOUTNO", "출하지시번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "BARCODE", "BOX번호", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PACKQTY", "적재수량", false, GridColDataType_emu.Double, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CARNO", "차량번호", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "BLNO", "BL번호", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "WORKERID", "작업자ID", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "WORKERNAME", "작업자명", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);

                #region --- Combobox & Popup Setting ---
                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;

                rtnDtTemp = _Common.GET_BM0130_CODE("Y");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //UltraGridUtil.SetComboUltraGrid(this.grid3, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("SHIPTYPE");
                Common.FillComboboxMaster(this.cbo_ShipType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "SHIPTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //거래처
                btbManager.PopUpAdd(txt_CUSTCODE_H, txt_CUSTNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "", "", "Y" });
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "1", "" });

                #endregion
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

            if (!CheckData())
            {
                return;
            }

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                string sLotNO = DBHelper.nvlString(txt_SelOutNo_H.Text);

                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid2);

                base.DoInquire();

                dtGrid = helper.FillTable("USP_WM0165_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SELOUTNO", txt_SelOutNo_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", txt_ITEMCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMNAME", txt_ITEMNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SHIPTYPE", CModule.ToString(cbo_ShipType.Value), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKERID", txtWorkerID.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKERNAME", txtWorkerName.Text.Trim(), DbType.String, ParameterDirection.Input)
                    );

                grid1.DataSource = dtGrid;
                grid1.DataBinds(dtGrid);
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

        public override void DoDelete()
        {
            if (grid2.Selected.Rows.Count == 0)
            {
                return;
            }

            if (this.ShowDialog(Common.getLangText("선택한 항목을 해당 출하지시에서 삭제하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoDelete();

                string sSelOutNo = CModule.ToString(grid1.ActiveRow.Cells["SelOutNo"].Value);
                string sPlantCode = CModule.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);

                foreach (UltraGridRow row in grid2.Selected.Rows)
                {
                    string sBarcode = CModule.ToString(row.Cells["BARCODE"].Value);

                    helper.ExecuteNoneQuery("USP_WM0165_I1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PCODE", "D1", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_BARCODE", sBarcode, DbType.String, ParameterDirection.Input)
                    );

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
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
                DoInquire2();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
        }

        private void DoInquire2()
        {
            //if (grid1.ActiveRow == null)
            //{
            //    this.ShowDialog("셀 선택을 정확하게 하세요.", WIZ.Forms.DialogForm.DialogType.OK);
            //    return;
            //}
            try
            {
                DBHelper helper;
                helper = new DBHelper(false);

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sSelOutNo = this.grid1.ActiveRow.Cells["SELOUTNO"].Value.ToString();
                string sItemCode = this.grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();

                //this.ShowDialog("추가 중인 출하지시가 있습니다.", WIZ.Forms.DialogForm.DialogType.OK);
                _GridUtil.Grid_Clear(grid2);

                dtGrid2 = helper.FillTable("USP_WM0165_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                        //, helper.CreateParameter("AS_WORKERID", txtWorkerID.Text.Trim(), DbType.String, ParameterDirection.Input)
                        //, helper.CreateParameter("AS_WORKERNAME", txtWorkerName.Text.Trim(), DbType.String, ParameterDirection.Input)
                        );

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

        private void grid1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up) || e.KeyCode.Equals(Keys.Down))
            {
                DoInquire2();
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

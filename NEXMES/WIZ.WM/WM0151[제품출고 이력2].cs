// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0151
//   Form Name    : 제품출고 이력2
//   Name Space   : WIZ.WM
//   Created Date : 2017-01-01
//   Made By      :
//   Description  :
// *---------------------------------------------------------------------------------------------*

using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

namespace WIZ.WM
{

    //PDA 전용 출하계기

    public partial class WM0151 : WIZ.Forms.BaseMDIChildForm
    {
        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();

        string UserID = DBHelper.nvlString(WIZ.LoginInfo.UserID);

        string PCODE = "";
        string PLANTCODE = "";
        string CONTRACTNO = "";
        string ITEMCODE = "";
        string ITEMNAME = "";
        string CUSTOMER = "";
        string CUSTNAME = "";
        string STARTDATE = "";
        string ENDDATE = "";
        string BOXSTART = "";
        string BOXEND = "";
        string btnTag = "";
        string SHIPNO = "";
        string SHIPDATE = "";

        public WM0151()
        {
            InitializeComponent();
        }

        private void WM0151_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            //---------------------------------
            btnCANCEL.Tag = "I2_C1"; //출하취소
            btnRESTORE.Tag = "I2_R1"; //복구
            btnDELETE.Tag = "I2_D1"; //폐기
            //---------------------------------
            rtnDtTemp2 = _Common.GET_BM0000_CODE("SHIPSTATE");     //사용여부
            Common.FillComboboxMaster(this.cbo_SHIPSTATE_H, rtnDtTemp2, rtnDtTemp2.Columns["CODE_ID"].ColumnName, rtnDtTemp2.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            //rtnDtTemp = _Common.GET_BM0000_CODE("ORDERTYPE");
            //Common.FillComboboxMaster(this.cbo_ORDERTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_BM0000_CODE("ORDERSTATUS");
            //UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_BM0130_CODE("Y");
            //UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITINFO", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_BM0060_CODE("");
            //UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });
            btbManager.PopUpAdd(txt_CUSTCODE_H, txt_CUSTNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "CT", "", "Y" });

            bizGridManager = new BizGridManager(this.grid2);

            //btbManager.PopUpClosed += BtbManager_PopUpClosed;
            #endregion
        }
        private void GridInitialize()
        {
            try
            {
                //grid1
                _GridUtil.InitializeGrid(grid1, true, false, true, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "RESULT", "출하상태", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SHIPNO", "출하번호", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SHIPDATE", "출하일자", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "수주업체", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 230, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PACKQTY", "출하수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.SetInitUltraGridBind(grid1);

                //grid2
                _GridUtil.InitializeGrid(grid2, true, false, true, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "RESULT", "출하상태", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 250, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PACKNO", "박스번호", false, GridColDataType_emu.VarChar, 300, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PACKQTY", "출하수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.SetInitUltraGridBind(grid2);
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {

            //, @AS_PLANTCODE nvarchar(20)
            //, @AS_SHIPNO nvarchar(50)
            //, @AS_CONTRACTNO nvarchar(50)
            //, @AS_ITEMCODE nvarchar(30)
            //, @AS_ITEMNAME nvarchar(100)
            //, @AS_STARTDATE nvarchar(10)
            //, @AS_ENDDATE nvarchar(10)
            //, @AS_LOTNO nvarchar(50)
            //, @AS_PACKNO nvarchar(50)

            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid2);

            DBHelper db = new DBHelper();
            try
            {
                DataTable dtGrid = db.FillTable("USP_WM0150_S1", CommandType.StoredProcedure
                    , db.CreateParameter("PCODE", "S1", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(cbo_PLANTCODE_H.Value), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_SHIPNO", txtShipNo.Text, DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_CONTRACTNO", "", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_ITEMCODE", txt_ITEMCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_ITEMNAME", txt_ITEMNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_STARTDATE", string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_ENDDATE", string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_LOTNO", txtLotNo.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_PACKNO", txtBoxNo.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_RESULT", DBHelper.nvlString(cbo_SHIPSTATE_H.Value), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input));

                grid1.DataSource = dtGrid;
                grid1.DataBinds();
                grid1.IsActivate = false;

                dtGrid = db.FillTable("USP_WM0150_S1", CommandType.StoredProcedure
                    , db.CreateParameter("PCODE", "S3", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_PLANTCODE", Convert.ToString(cbo_PLANTCODE_H.Value), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_SHIPNO", txtShipNo.Text, DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_CONTRACTNO", "", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_ITEMCODE", txt_ITEMCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_ITEMNAME", txt_ITEMNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_STARTDATE", string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_ENDDATE", string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_LOTNO", txtLotNo.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_PACKNO", txtBoxNo.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_RESULT", DBHelper.nvlString(cbo_SHIPSTATE_H.Value), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input));

                grid2.DataSource = dtGrid;
                grid2.DataBinds();
                grid2.IsActivate = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                db.Close();
                this.ClosePrgFormNew();
            }


        }

        public override void DoNew()
        {
        }

        public override void DoDelete()
        {
            //base.DoDelete();

            //this.grid3.DeleteRow();
        }

        public override void DoSave()
        {

        }
        #endregion

        #region < EVENT AREA >
        private void grid_ClickCell(object sender, ClickCellEventArgs e)
        {
            Control.Grid grid = sender as Control.Grid;

            if (grid == null) return;

            if (e.Cell.Row.Index < 0) return;

            DBHelper db = new DBHelper();
            try
            {
                string sShipNO = "";

                if (grid1.ActiveRow != null)
                {
                    sShipNO = CModule.ToString(grid1.ActiveRow.Cells["SHIPNO"].Value);
                }

                DataTable dtGrid = db.FillTable("USP_WM0150_S1", CommandType.StoredProcedure
                    , db.CreateParameter("PCODE", "S2", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(e.Cell.Row.Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_SHIPNO", sShipNO, DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_CONTRACTNO", "", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(e.Cell.Row.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_STARTDATE", "", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_ENDDATE", "", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_LOTNO", "", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_PACKNO", "", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_RESULT", DBHelper.nvlString(cbo_SHIPSTATE_H.Value), DbType.String, ParameterDirection.Input));

                grid2.DataSource = dtGrid;
                grid2.DataBinds();
                grid2.IsActivate = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                db.Close();
                this.ClosePrgFormNew();
            }

        }


        private void btn_click_event(object sender, EventArgs e)
        {
            Button buffer = (Button)sender;
            btnTag = buffer.Tag.ToString();

            DBHelper helper = new DBHelper("", true);
            PLANTCODE = DBHelper.nvlString(cbo_PLANTCODE_H.Value);

            switch (btnTag)
            {

                case "I2_C1": // 출하취소
                    try
                    {
                        SHIPNO = grid1.ActiveRow.Cells["SHIPNO"].Text;
                        helper.ExecuteNoneQuery("USP_WM0140_I4", CommandType.StoredProcedure
                            , helper.CreateParameter("PCODE", btnTag.Replace("I2_", ""), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SELOUTNO", "", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHIPDATE", "", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "S")
                        {
                            helper.Commit();

                        }
                        else
                        {
                            throw new Exception(helper.RSMSG);
                        }
                        DoInquire();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        MessageBox.Show(ex.ToString());

                    }
                    break;
                case "I2_R1": // 복구
                    try
                    {
                        SHIPNO = grid1.ActiveRow.Cells["SHIPNO"].Text;
                        helper.ExecuteNoneQuery("USP_WM0140_I4", CommandType.StoredProcedure
                            , helper.CreateParameter("PCODE", btnTag.Replace("I2_", ""), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SELOUTNO", "", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHIPDATE", "", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "S")
                        {
                            helper.Commit();

                        }
                        else
                        {
                            throw new Exception(helper.RSMSG);
                        }
                        DoInquire();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        MessageBox.Show(ex.ToString());

                    }
                    break;
                case "I2_D1": // 폐기
                    try
                    {
                        SHIPNO = grid1.ActiveRow.Cells["SHIPNO"].Text;
                        helper.ExecuteNoneQuery("USP_WM0140_I4", CommandType.StoredProcedure
                            , helper.CreateParameter("PCODE", btnTag.Replace("I2_", ""), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SELOUTNO", "", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHIPDATE", "", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "S")
                        {
                            helper.Commit();

                        }
                        else
                        {
                            throw new Exception(helper.RSMSG);
                        }
                        DoInquire();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        MessageBox.Show(ex.ToString());

                    }
                    break;
            }


        }
        #endregion
    }
}

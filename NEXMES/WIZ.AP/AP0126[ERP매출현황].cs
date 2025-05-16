// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0126
//   Form Name    : 제품출고 등록2
//   Name Space   : WIZ.AP
//   Created Date : 2017-01-01
//   Made By      :
//   Description  :
// *---------------------------------------------------------------------------------------------*

using Infragistics.Win.UltraWinGrid;
using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

namespace WIZ.AP
{
    public partial class AP0126 : WIZ.Forms.BaseMDIChildForm
    {
        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;
        bool bPop2 = false;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();

        DataTable dtGrid;
        DBHelper helper = new DBHelper(false);
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
        //string BOXSTART = "";
        //string BOXEND = "";
        //string btnTag = "";
        string SHIPNO = "";
        //string SHIPDATE = "";



        public AP0126()
        {
            InitializeComponent();
        }

        private void AP0126_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("CURNM"); //통화유형
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CURNM", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "CURNM", rtnDtTemp, "CODE_ID", "CODE_NAME");

            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

            //btbManager.PopUpClosed += BtbManager_PopUpClosed;

            bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "", "Y" });
            #endregion
        }
        private void GridInitialize()
        {
            try
            {
                //grid1
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SELOUTNO", "출하번호", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "수주업체코드", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "수주업체", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTQTY", "수주수량", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DUEDATE", "매출일자", false, GridColDataType_emu.YearMonthDay, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CURNM", "통화코드", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SHIPQTY", "출하수량", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "재공수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.SetInitUltraGridBind(grid1);

                //grid2
                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "Result", "상태", false, GridColDataType_emu.VarChar, 50, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SHIPNO", "출하번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SHIPQTY", "출하수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.SetInitUltraGridBind(grid2);

                //grid3
                _GridUtil.InitializeGrid(grid3, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "Result", "상태", false, GridColDataType_emu.VarChar, 50, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "SHIPNO", "출하번호", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "PACKNO", "박스번호", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "PACKDT", "포장일자", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "PACKQTY", "출하수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.SetInitUltraGridBind(grid3);

                //grid4
                _GridUtil.InitializeGrid(grid4, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid4, "SAVEBUTTON", "삭제", true, GridColDataType_emu.Button, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "SHIPNO", "출하번호", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid4, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "CONTRACTQTY", "수주수량", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid4, "DUEDATE", "매출일자", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "PACKQTY", "출하수량", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid4, "CURNM", "통화단위", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "COST", "매출단가", false, GridColDataType_emu.Float, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "TOTALCOST", "매출금액", false, GridColDataType_emu.Double, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "VAT", "부가세", false, GridColDataType_emu.Float, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "MONEYDUEDATE", "회수예정일", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "INCOMEDATE", "회수일", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "PONO", "구매번호", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "BLNO", "BL번호", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);

                grid4.DisplayLayout.Bands[0].Columns["COST"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid4.DisplayLayout.Bands[0].Columns["DUEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid4.DisplayLayout.Bands[0].Columns["MONEYDUEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid4.DisplayLayout.Bands[0].Columns["INCOMEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;

                _GridUtil.SetInitUltraGridBind(grid4);

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid2);
            _GridUtil.Grid_Clear(grid3);
            _GridUtil.Grid_Clear(grid4);

            Grid_data(grid1);
            Grid_data(grid4);

        }
        public void Grid_data(Control.Grid grid)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                switch (grid.Name.ToUpper())
                {
                    case "GRID1":
                        PCODE = "S1";
                        break;
                    case "GRID4":
                        PCODE = "S7";
                        break;
                    case "":
                        break;
                }

                PLANTCODE = Convert.ToString(cbo_PLANTCODE_H.Value);
                CONTRACTNO = "";
                SHIPNO = "";
                ITEMCODE = txt_ITEMCODE_H.Text.Trim();
                ITEMNAME = txt_ITEMNAME_H.Text.Trim();
                CUSTOMER = "";
                CUSTNAME = "";
                STARTDATE = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                ENDDATE = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                dtGrid = helper.FillTable("USP_WM0140_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("PCODE", PCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMNAME", ITEMNAME, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTOMER", CUSTOMER, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTNAME", CUSTNAME, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_STARTDATE", STARTDATE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ENDDATE", ENDDATE, DbType.String, ParameterDirection.Input));

                grid.DataSource = dtGrid;
                grid.DataBinds();
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
                _GridUtil.Grid_Clear(grid4);

                if (grid1.IsActivate || grid2.IsActivate || grid3.IsActivate || grid4.IsActivate)
                {

                    string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    //string sItemName = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
                    //string sUnitCode = DBHelper.nvlString(grid1.ActiveRow.Cells["UNITCODE"].Value);
                    string sPackQty = DBHelper.nvlString(grid2.ActiveRow.Cells["SHIPQTY"].Value);
                    string sContractNo = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
                    string sContractQty = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTQTY"].Value);
                    string sCurNm = DBHelper.nvlString(grid1.ActiveRow.Cells["CURNM"].Value);
                    string sShipNo = DBHelper.nvlString(grid2.ActiveRow.Cells["SHIPNO"].Value);
                    //string sMaskID = DBHelper.nvlString(grid1.ActiveRow.Cells["MASKID"].Value);

                    this.grid4.InsertRow();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid4.ActiveRow.Cells["CONTRACTNO"].Value = sContractNo;
                    this.grid4.ActiveRow.Cells["ITEMCODE"].Value = sItemCode;
                    this.grid4.ActiveRow.Cells["PACKQTY"].Value = sPackQty;
                    this.grid4.ActiveRow.Cells["CONTRACTQTY"].Value = sContractQty;
                    this.grid4.ActiveRow.Cells["SHIPNO"].Value = sShipNo;
                    this.grid4.ActiveRow.Cells["CURNM"].Value = sCurNm;
                    this.grid4.ActiveRow.Cells["MONEYDUEDATE"].Value = DateTime.Now.AddDays(30);
                    this.grid4.ActiveRow.Cells["INCOMEDATE"].Value = DateTime.Now.AddDays(30);
                    this.grid4.ActiveRow.Cells["DUEDATE"].Value = DateTime.Now.AddDays(-1);

                    this.grid4.ActiveRow.Cells["COST"].Value = "";
                    this.grid4.ActiveRow.Cells["PONO"].Value = "";
                    this.grid4.ActiveRow.Cells["SAVEBUTTON"].Value = "삭제";

                    this.grid4.ActiveRow.Cells["CONTRACTNO"].Activation = Activation.NoEdit;
                    this.grid4.ActiveRow.Cells["SHIPNO"].Activation = Activation.NoEdit;
                    this.grid4.ActiveRow.Cells["ITEMCODE"].Activation = Activation.NoEdit;
                    this.grid4.ActiveRow.Cells["PACKQTY"].Activation = Activation.NoEdit;
                    this.grid4.ActiveRow.Cells["TOTALCOST"].Activation = Activation.NoEdit;
                    this.grid4.ActiveRow.Cells["CURNM"].Activation = Activation.NoEdit;
                    this.grid4.ActiveRow.Cells["COST"].Activation = Activation.AllowEdit;
                    this.grid4.ActiveRow.Cells["PONO"].Activation = Activation.AllowEdit;
                    this.grid4.ActiveRow.Cells["DUEDATE"].Activation = Activation.AllowEdit;
                    this.grid4.ActiveRow.Cells["SAVEBUTTON"].Activation = Activation.NoEdit;

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
            base.DoDelete();

            this.grid4.DeleteRow();
        }

        public override void DoSave()
        {
            DataTable dtChange = grid4.chkChange();

            if (dtChange == null)
                return;

            string sContractNo = string.Empty;
            string sShipNo = string.Empty;
            string sItemCode = string.Empty;
            string sBlno = string.Empty;
            string sPackQty = string.Empty;
            string sCost = string.Empty;
            string sPoNo = string.Empty;
            string sMoneyDueDate = string.Empty;
            string sIncomeDate = string.Empty;

            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();
                int iR = 0;
                foreach (DataRow drChange in dtChange.Rows)
                {
                    switch (drChange.RowState)
                    {
                        case DataRowState.Deleted:

                            //drChange.RejectChanges();

                            //sContractNo = DBHelper.nvlString(drChange["CONTRACTNO"]);
                            //sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);
                            //sItemName = DBHelper.nvlString(drChange["ITEMNAME"]);
                            //sPackQty = DBHelper.nvlString(drChange["PACKQTY"]);
                            //sShipNo = DBHelper.nvlString(drChange["SHIPNO"]);
                            //sShipNo = DBHelper.nvlString(drChange["SHIPNO"]);


                            //helper.ExecuteNoneQuery("USP_SA0000_D1", CommandType.StoredProcedure
                            ////, helper.CreateParameter("AS_PLANTCODE", "10", DbType.String, ParameterDirection.Input)
                            //, helper.CreateParameter("AS_CONTRACTNO", sContractNo, DbType.String, ParameterDirection.Input)
                            //, helper.CreateParameter("AS_SHIPNO", sShipNo, DbType.String, ParameterDirection.Input)
                            //, helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

                            break;

                        case DataRowState.Added:
                        case DataRowState.Modified:
                            #region --- 추가/수정/삭제 ---
                            sPackQty = "0";

                            sContractNo = DBHelper.nvlString(drChange["CONTRACTNO"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);
                            sBlno = DBHelper.nvlString(drChange["BLNO"]);
                            sPackQty = DBHelper.nvlString(drChange["PACKQTY"]);
                            sShipNo = DBHelper.nvlString(drChange["SHIPNO"]);
                            sCost = DBHelper.nvlString(drChange["COST"]);
                            sPoNo = DBHelper.nvlString(drChange["PONO"]);
                            sMoneyDueDate = DBHelper.nvlString(drChange["MONEYDUEDATE"]);
                            sIncomeDate = DBHelper.nvlString(drChange["INCOMEDATE"]);

                            if (drChange.RowState == DataRowState.Deleted || sPackQty == "0")
                            {
                                sPackQty = "";
                            }

                            helper.ExecuteNoneQuery("USP_SA0000_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", "10", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CONTRACTNO", sContractNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHIPNO", sShipNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PACKQTY", sPackQty, DbType.Decimal, ParameterDirection.Input)
                            , helper.CreateParameter("AF_COST", sCost, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_BLNO", sBlno, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MONEYDUEDATE", sMoneyDueDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_INCOMEDATE", sIncomeDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                    }
                    iR++;
                    if (helper.RSCODE != "S")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }

                grid4.SetAcceptChanges();

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

                DoInquire();
            }
        }
        #endregion

        #region < EVENT AREA >

        private void grid_ClickCell(object sender, ClickCellEventArgs e)
        {
            Control.Grid grid = sender as Control.Grid;

            if (grid == null) return;

            if (e.Cell.Row.Index < 0) return;

            switch (grid.Name.ToUpper())
            {
                case "GRID1":
                    _GridUtil.Grid_Clear(grid2);
                    _GridUtil.Grid_Clear(grid3);
                    _GridUtil.Grid_Clear(grid4);

                    PCODE = "S2";
                    CONTRACTNO = grid1.ActiveRow.Cells["CONTRACTNO"].Text;
                    SHIPNO = "";
                    ITEMCODE = grid1.ActiveRow.Cells["ITEMCODE"].Text;
                    ITEMNAME = grid1.ActiveRow.Cells["ITEMNAME"].Text;
                    CUSTOMER = "";
                    CUSTNAME = "";
                    STARTDATE = "";
                    ENDDATE = "";

                    grid = grid2;
                    break;
                case "GRID2":
                    _GridUtil.Grid_Clear(grid3);
                    _GridUtil.Grid_Clear(grid4);

                    PCODE = "S3";
                    CONTRACTNO = grid1.ActiveRow.Cells["CONTRACTNO"].Text;
                    SHIPNO = grid2.ActiveRow.Cells["SHIPNO"].Text;
                    ITEMCODE = grid2.ActiveRow.Cells["ITEMCODE"].Text;
                    ITEMNAME = grid2.ActiveRow.Cells["ITEMNAME"].Text;
                    CUSTOMER = "";
                    CUSTNAME = "";
                    STARTDATE = "";
                    ENDDATE = "";

                    grid = grid3;
                    break;

                case "GRID3":
                    _GridUtil.Grid_Clear(grid4);

                    PCODE = "S4";
                    CONTRACTNO = grid1.ActiveRow.Cells["CONTRACTNO"].Text;
                    SHIPNO = grid3.ActiveRow.Cells["SHIPNO"].Text;
                    ITEMCODE = grid1.ActiveRow.Cells["ITEMCODE"].Text;
                    ITEMNAME = grid1.ActiveRow.Cells["ITEMNAME"].Text;
                    CUSTOMER = "";
                    CUSTNAME = "";
                    STARTDATE = "";
                    ENDDATE = "";

                    grid = grid4;
                    break;
            }
            try
            {
                dtGrid = helper.FillTable("USP_WM0140_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("PCODE", PCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMNAME", ITEMNAME, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTOMER", CUSTOMER, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTNAME", CUSTNAME, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_STARTDATE", STARTDATE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ENDDATE", ENDDATE, DbType.String, ParameterDirection.Input));

                grid.DataSource = dtGrid;
                grid.DataBinds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }

        }

        private void grid4_ClickCellButton(object sender, CellEventArgs e)
        {
            //string sFinishFlag = string.Empty;
            string sShipNo = string.Empty;
            string sItemCode = string.Empty;

            try
            {
                

                if (e.Cell.Column.ToString() == "SAVEBUTTON")
                {

                    sShipNo = Convert.ToString(e.Cell.Row.Cells["SHIPNO"].Value);

                    DataTable dtTarget = ((DataTable)this.grid4.DataSource);
                    DataRow[] drRow = dtTarget.Select("SHIPNO = '" + sShipNo + "'");


                    AP0126_POP ap0126_pop = new AP0126_POP(drRow[0], sShipNo);
                    ap0126_pop.ShowDialog();


                    this.DoInquire();
                    
                }


            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
            }
        }


        #endregion
    }
}

// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0129
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
using WIZ.Control;

namespace WIZ.AP
{
    public partial class AP0129 : WIZ.Forms.BaseMDIChildForm
    {
        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

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
        string DUEDATE = "";
        string CURNM = "";
        string CUSTOMER = "";
        string CUSTNAME = "";
        string STARTDATE = "";
        string ENDDATE = "";
        string SHIPNO = "";


        public AP0129()
        {
            InitializeComponent();
        }

        private void AP0129_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now.AddDays(7);

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("CURNM"); //통화유형
            WIZ.Common.FillComboboxMaster(this.cbo_CURNM_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CURNM", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "CURNM", rtnDtTemp, "CODE_ID", "CODE_NAME");

            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "1", "Y" });

            //거래처
            btbManager.PopUpAdd(txt_CUSTCODE_H, txt_CUSTNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "", "", "" });

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
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 230, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "업체코드", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "발주업체", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTQTY", "수주수량", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DUEDATE", "출하지시일자", false, GridColDataType_emu.YearMonthDay, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CURNM", "통화코드", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "RELCODE1", "환율", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SHIPQTY", "출하수량", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Result", "상태", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CARNO", "차량번호", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "BLNO", "BL번호", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "TERM", "대금회수기간", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "재공수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.SetInitUltraGridBind(grid1);

                //grid2
                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "SAVEBUTTON", "삭제", true, GridColDataType_emu.Button, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SHIPNO", "출하번호", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTQTY", "수주수량", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid2, "DUEDATE", "기준환율일자", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, true);

                //_GridUtil.InitColumnUltraGrid(grid2, "DUEDATE", "기준환율일자", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "DUEDATE", "기준환율일자", false, GridColDataType_emu.YearMonthDay, 120, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PACKQTY", "출하수량", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid2, "CURNM", "통화단위", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "RATE", "환율", false, GridColDataType_emu.Float, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "COST", "매출단가", false, GridColDataType_emu.Float, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "TOTALCOST", "매출금액(외화)", false, GridColDataType_emu.Double, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "TOTALCOST2", "매출금액(원화)", false, GridColDataType_emu.Double, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "VAT", "부가세", false, GridColDataType_emu.Float, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MONEYDUEDATE", "회수예정일", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "INCOMEDATE", "회수일", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "MONEYDUEDATE", "회수예정일", false, GridColDataType_emu.YearMonthDay, 110, 0, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "INCOMEDATE", "회수일", false, GridColDataType_emu.YearMonthDay, 110, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PONO", "구매번호", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "BLNO", "BL번호", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CERTI", "신고필증", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PHOTO", "포토", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PHOTO2", "포토(원화)", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MASK", "마스크", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MASK2", "마스크(원화)", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "FRAME", "프레임", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "FRAME2", "프레임(원화)", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "COATING", "코팅", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "COATING2", "코팅(원화)", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CLEANSING", "세정", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CLEANSING2", "세정(원화)", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ETC", "기타", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ETC2", "기타(원화)", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);

                grid2.DisplayLayout.Bands[0].Columns["COST"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["PONO"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["BLNO"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["CERTI"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["PHOTO"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["MASK"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["FRAME"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["COATING"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["CLEANSING"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["ETC"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["DUEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["MONEYDUEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["INCOMEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;

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
            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid2);

            Grid_data(grid1);
            Grid_data(grid2);

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
                    case "GRID2":
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
                DUEDATE = "";
                CURNM = DBHelper.nvlString(cbo_CURNM_H.Value);
                CUSTOMER = txt_CUSTCODE_H.Text.Trim();
                CUSTNAME = txt_CUSTNAME_H.Text.Trim();
                STARTDATE = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                ENDDATE = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                dtGrid = helper.FillTable("USP_AP0129_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("PCODE", PCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMNAME", ITEMNAME, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DUEDATE", DUEDATE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CURNM", CURNM, DbType.String, ParameterDirection.Input)
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
                _GridUtil.Grid_Clear(grid2);

                if (grid1.IsActivate || grid2.IsActivate )
                {

                    string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    string sContractNo = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
                    string sContractQty = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTQTY"].Value);
                    string sPackQty = DBHelper.nvlString(grid1.ActiveRow.Cells["SHIPQTY"].Value);
                    string sCurNm = DBHelper.nvlString(grid1.ActiveRow.Cells["CURNM"].Value);
                    string sRate = DBHelper.nvlString(grid1.ActiveRow.Cells["RELCODE1"].Value);
                    string sDuedate = DBHelper.nvlString(grid1.ActiveRow.Cells["DUEDATE"].Value);
                    string sShipNo = DBHelper.nvlString(grid1.ActiveRow.Cells["SELOUTNO"].Value);
                    string sBlNo = DBHelper.nvlString(grid1.ActiveRow.Cells["BLNO"].Value);
                    double dTerm = DBHelper.nvlDouble(grid1.ActiveRow.Cells["TERM"].Value);

                    this.grid2.InsertRow();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid2.ActiveRow.Cells["CONTRACTNO"].Value = sContractNo;
                    this.grid2.ActiveRow.Cells["ITEMCODE"].Value = sItemCode;
                    this.grid2.ActiveRow.Cells["CONTRACTQTY"].Value = sContractQty;
                    this.grid2.ActiveRow.Cells["PACKQTY"].Value = sPackQty;
                    this.grid2.ActiveRow.Cells["SHIPNO"].Value = sShipNo;
                    this.grid2.ActiveRow.Cells["BLNO"].Value = sBlNo;
                    this.grid2.ActiveRow.Cells["DUEDATE"].Value = sDuedate;
                    this.grid2.ActiveRow.Cells["CURNM"].Value = sCurNm;
                    this.grid2.ActiveRow.Cells["RATE"].Value = sRate;
                    this.grid2.ActiveRow.Cells["MONEYDUEDATE"].Value = string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(dTerm));
                    this.grid2.ActiveRow.Cells["INCOMEDATE"].Value = string.Format("{0:yyyy-MM-dd}", DateTime.Now.AddDays(30)); 

                    this.grid2.ActiveRow.Cells["SAVEBUTTON"].Value = "삭제";
                    this.grid2.ActiveRow.Cells["COST"].Value = "1";
                    this.grid2.ActiveRow.Cells["PONO"].Value = "1";
                    this.grid2.ActiveRow.Cells["CERTI"].Value = "1";
                    this.grid2.ActiveRow.Cells["PHOTO"].Value = "1";
                    this.grid2.ActiveRow.Cells["MASK"].Value = "1";
                    this.grid2.ActiveRow.Cells["FRAME"].Value = "1";
                    this.grid2.ActiveRow.Cells["COATING"].Value = "1";
                    this.grid2.ActiveRow.Cells["CLEANSING"].Value = "1";
                    this.grid2.ActiveRow.Cells["ETC"].Value = "1";                    

                    this.grid2.ActiveRow.Cells["CONTRACTNO"].Activation = Activation.NoEdit;
                    this.grid2.ActiveRow.Cells["SHIPNO"].Activation = Activation.NoEdit;
                    this.grid2.ActiveRow.Cells["ITEMCODE"].Activation = Activation.NoEdit;
                    this.grid2.ActiveRow.Cells["PACKQTY"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["TOTALCOST"].Activation = Activation.NoEdit;
                    this.grid2.ActiveRow.Cells["CURNM"].Activation = Activation.NoEdit;
                    this.grid2.ActiveRow.Cells["DUEDATE"].Activation = Activation.NoEdit;
                    this.grid2.ActiveRow.Cells["RATE"].Activation = Activation.NoEdit;
                    this.grid2.ActiveRow.Cells["COST"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["PONO"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["CERTI"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["PHOTO"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["PHOTO2"].Activation = Activation.NoEdit;
                    this.grid2.ActiveRow.Cells["MASK"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["MASK2"].Activation = Activation.NoEdit;
                    this.grid2.ActiveRow.Cells["FRAME"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["FRAME2"].Activation = Activation.NoEdit;
                    this.grid2.ActiveRow.Cells["COATING"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["COATING2"].Activation = Activation.NoEdit;
                    this.grid2.ActiveRow.Cells["CLEANSING"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["CLEANSING2"].Activation = Activation.NoEdit;
                    this.grid2.ActiveRow.Cells["ETC"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["ETC2"].Activation = Activation.NoEdit;
                    this.grid2.ActiveRow.Cells["SAVEBUTTON"].Activation = Activation.NoEdit;
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

            this.grid2.DeleteRow();
        }

        public override void DoSave()
        {
            DataTable dtChange = grid2.chkChange();

            if (dtChange == null)
                return;

            string sContractNo = string.Empty;
            string sShipNo = string.Empty;
            string sItemCode = string.Empty;
            string sCurCode = string.Empty;
            string sDueDate = string.Empty;
            string sBlno = string.Empty;
            string sCerti = string.Empty;
            string sRate = string.Empty;
            string sPackQty = string.Empty;
            string sCost = string.Empty;
            string sPoNo = string.Empty;
            string sPhoto = string.Empty;
            string sMask = string.Empty;
            string sFrame = string.Empty;
            string sCoating = string.Empty;
            string sCleansing = string.Empty;
            string sEtc = string.Empty;
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
                        case DataRowState.Added:
                        case DataRowState.Modified:
                            #region --- 추가/수정/삭제 ---
                            sPackQty = "0";

                            sContractNo = DBHelper.nvlString(drChange["CONTRACTNO"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);
                            sCurCode = DBHelper.nvlString(drChange["CURNM"]);
                            sDueDate = DBHelper.nvlString(drChange["DUEDATE"]);
                            sBlno = DBHelper.nvlString(drChange["BLNO"]);
                            sPackQty = DBHelper.nvlString(drChange["PACKQTY"]);
                            sShipNo = DBHelper.nvlString(drChange["SHIPNO"]);
                            sRate = DBHelper.nvlString(drChange["RATE"]);
                            sCost = DBHelper.nvlString(drChange["COST"]);
                            sPoNo = DBHelper.nvlString(drChange["PONO"]);
                            sCerti = DBHelper.nvlString(drChange["CERTI"]);
                            sPhoto = DBHelper.nvlString(drChange["PHOTO"]);
                            sMask = DBHelper.nvlString(drChange["MASK"]);
                            sFrame = DBHelper.nvlString(drChange["FRAME"]);
                            sCoating = DBHelper.nvlString(drChange["COATING"]);
                            sCleansing = DBHelper.nvlString(drChange["CLEANSING"]);
                            sEtc = DBHelper.nvlString(drChange["ETC"]);
                            sMoneyDueDate = DBHelper.nvlString(drChange["MONEYDUEDATE"]);
                            sIncomeDate = DBHelper.nvlString(drChange["INCOMEDATE"]);

                            if (drChange.RowState == DataRowState.Deleted || sPackQty == "0")
                            {
                                sPackQty = "";
                            }

                            helper.ExecuteNoneQuery("USP_SA0000_I2", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", "10", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CONTRACTNO", sContractNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHIPNO", sShipNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_DUEDATE", sDueDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CURNM", sCurCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PACKQTY", sPackQty, DbType.Decimal, ParameterDirection.Input)
                            , helper.CreateParameter("AF_RATE", sRate, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_COST", sCost, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_BLNO", sBlno, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CERTI", sCerti, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AF_PHOTO", sPhoto, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_MASK", sMask, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_FRAME", sFrame, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_COATING", sCoating, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_CLEANSING", sCleansing, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_ETC", sEtc, DbType.Double, ParameterDirection.Input)
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

                grid2.SetAcceptChanges();

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

        public override void DoImportExcel()
        {
            base.DoImportExcel();

            AP0129_EXCEL AP0129_excel = new AP0129_EXCEL();
            AP0129_excel.ShowDialog();

            base.DoInquire();
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


                    PCODE = "S4";
                    CONTRACTNO = grid1.ActiveRow.Cells["CONTRACTNO"].Text;
                    SHIPNO = grid1.ActiveRow.Cells["SELOUTNO"].Text;
                    ITEMCODE = grid1.ActiveRow.Cells["ITEMCODE"].Text;
                    ITEMNAME = grid1.ActiveRow.Cells["ITEMNAME"].Text;
                    DUEDATE = grid1.ActiveRow.Cells["DUEDATE"].Text;
                    CURNM = grid1.ActiveRow.Cells["CURNM"].Text;
                    CUSTOMER = "";
                    CUSTNAME = "";
                    STARTDATE = "";
                    ENDDATE = "";

                    grid = grid2;
                    break;

            }
            try
            {
                dtGrid = helper.FillTable("USP_AP0129_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("PCODE", PCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMNAME", ITEMNAME, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DUEDATE", DUEDATE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CURNM", CURNM, DbType.String, ParameterDirection.Input)
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

                    DataTable dtTarget = ((DataTable)this.grid2.DataSource);
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

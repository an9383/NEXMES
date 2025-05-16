#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0128
//   Form Name    : 작업지시 생성 및 확정
//   Name Space   : WIZ.AP
//   Created Date : 2017-01-01
//   Made By      :
//   Description  :
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP0128 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
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
        string CUSTOMER = "";
        string CUSTNAME = "";
        string STARTDATE = "";
        string ENDDATE = "";
        string SHIPNO = "";

        #endregion

        #region < CONSTRUCTOR >
        public AP0128()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP0128_Load(object sender, EventArgs e)
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
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "CURNM", rtnDtTemp, "CODE_ID", "CODE_NAME");

            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

            //btbManager.PopUpClosed += BtbManager_PopUpClosed;

            bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "", "Y" });
            #endregion
        }

        /// <summary>
        /// SetSubData 는 SetGridHead 이후에 실행
        /// </summary>
        //protected override void SetSubData()
        //{
        //    //btnLink.Enabled = (((WIZ.MAIN.ZA0003)this.MdiParent).GetToolBarStatus("NewFunc"));
        //    DataRow dr = subData["METHOD_TYPE", "BASE"];

        //    splitContainer2.Panel2Collapsed = true;

        //    if (dr != null)
        //    {
        //        sMethodCode1 = CModule.ToString(dr["RELCODE1"]) == "LINK" ? EnumMethod.LINK : EnumMethod.NONE;
        //        sMethodCode2 = CModule.ToString(dr["RELCODE2"]) == "ITEMCODE" ? EnumMethod.ITEMCODE : EnumMethod.NONE;
        //        //sMethodCode3 = CModule.ToString(dr["RELCODE3"]) == "N" ? EnumMethod.NOTLINK_OPCODE : EnumMethod.NONE;

        //        if (sMethodCode1 == EnumMethod.LINK)
        //        {
        //            splitContainer2.Panel2Collapsed = false;

        //            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");
        //            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "RELCODE2", rtnDtTemp, "CODE_ID", "CODE_NAME");

        //            grid2.Columns["REMARK"].CellActivation = Activation.NoEdit;

        //            //GridExtendUtil.SetLink(splitContainer2.Panel2, grid2, null, "ROW_STATUS");
        //        }

        //    }

        //    dr = subData["METHOD_TYPE", "INIT_WC"];

        //    if (dr != null)
        //    {
        //        sDef_WC = CModule.ToString(dr["RELCODE1"]);
        //    }
        //}

        //private void BtbManager_PopUpClosed(object tCode, object tName, bool bFindOK)
        //{
        //    SBtnTextEditor sCode = tCode as SBtnTextEditor;
        //    SBtnTextEditor sName = tName as SBtnTextEditor;

        //    if (tCode != null)
        //    {
        //        if (sCode.Name == "txt_ITEMCODE_S")
        //        {
        //            StringBuilder sSQL = new StringBuilder();
        //            sSQL.Append("Select BACKCOLOR FROM BM0010 with (NOLOCK) where ITEMCODE = '" + sCode.Text.Trim() + "' ");

        //            DBHelper db = new DBHelper();

        //            DataTable dt = db.FillTable(sSQL.ToString());

        //            sCode.Appearance.BackColor = Color.White;
        //            sName.Appearance.BackColor = Color.White;

        //            if (dt.Rows.Count == 1)
        //            {
        //                string sBackColor = DBHelper.nvlString(dt.Rows[0]["BACKCOLOR"]);
        //                Color _color = ColorTranslator.FromHtml(sBackColor);

        //                sCode.Appearance.BackColor = _color;
        //                sName.Appearance.BackColor = _color;
        //            }
        //        }
        //    }
        //}

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
                _GridUtil.InitColumnUltraGrid(grid2, "SAVEBUTTON", "삭제", true, GridColDataType_emu.Button, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SHIPNO", "출하번호", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTQTY", "수주수량", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid2, "DUEDATE", "매출일자", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PACKQTY", "출하수량", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid2, "CURNM", "통화단위", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "COST", "매출단가", false, GridColDataType_emu.Float, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "TOTALCOST", "매출금액", false, GridColDataType_emu.Double, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "VAT", "부가세", false, GridColDataType_emu.Float, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MONEYDUEDATE", "회수예정일", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "INCOMEDATE", "회수일", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PONO", "구매번호", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "BLNO", "BL번호", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);

                grid2.DisplayLayout.Bands[0].Columns["COST"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["DUEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["MONEYDUEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["INCOMEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;

                grid2.DisplayLayout.Bands[0].Columns["ORDERQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                //grid2.DisplayLayout.Bands[0].Columns["FRAMEID"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                //grid2.DisplayLayout.Bands[0].Columns["MASKID"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["PRIORITY1"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["PRIORITY2"].Header.Appearance.ForeColor = Color.LightSkyBlue;

                _GridUtil.SetInitUltraGridBind(grid2);

                #region --- Combobox & Popup Setting ---

                cbo_STARTDATE_H.Value = DateTime.Now;
                cbo_ENDDATE_H.Value = DateTime.Now.AddDays(7);

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                //2109.11.20 추가로 함
                rtnDtTemp = _Common.GET_BM0130_CODE("Y");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                bizGridManager = new BizGridManager(grid2);
                bizGridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "", "", "Y" });
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

                //GridExtendUtil.SetLink(null, grid1, Grid_Search);
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
                _GridUtil.Grid_Clear(grid2);
                if (grid1.IsActivate || grid2.IsActivate)
                {
                    if (grid1.ActiveRow == null)
                    {
                        this.ShowDialog(Common.getLangText("편성할 품목을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }

                    string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    //string sItemName = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
                    //string sUnitCode = DBHelper.nvlString(grid1.ActiveRow.Cells["UNITCODE"].Value);
                    //string sItemCode2 = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    string sContractNO = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
                    string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    string sFrameID = DBHelper.nvlString(grid1.ActiveRow.Cells["FRAMEID"].Value);
                    string sMaskID = DBHelper.nvlString(grid1.ActiveRow.Cells["MASKID"].Value);
                    string sFrameNo = DBHelper.nvlString(grid1.ActiveRow.Cells["FRAMENO"].Value);
                    string sSheetNo = DBHelper.nvlString(grid1.ActiveRow.Cells["SHEETNO"].Value);
                    //string sOrderqty = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANQTY"].Value);

                    this.grid2.InsertRow();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid2.ActiveRow.Cells["PLANTCODE"].Value = sPlantCode;
                    this.grid2.ActiveRow.Cells["ITEMCODE2"].Value = sItemCode;
                    //this.grid2.ActiveRow.Cells["ITEMCODE2"].Value = sItemCode2;
                    //this.grid2.ActiveRow.Cells["ITEMNAME"].Value = sItemName;
                    //this.grid2.ActiveRow.Cells["UNITCODE"].Value = sUnitCode;
                    this.grid2.ActiveRow.Cells["CONTRACTNO"].Value = sContractNO;
                    this.grid2.ActiveRow.Cells["WORKCENTERCODE"].Value = "WC0006";
                    this.grid2.ActiveRow.Cells["WORKCENTERNAME"].Value = "노광작업장";
                    this.grid2.ActiveRow.Cells["ORDERNO"].Value = "";
                    this.grid2.ActiveRow.Cells["ORDERDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                    //this.grid2.ActiveRow.Cells["OPCODE"].Value = DBHelper.nvlString(grid1.ActiveRow.Cells["OPCODE"].Value);
                    this.grid2.ActiveRow.Cells["ORDERQTY"].Value = "1";
                    this.grid2.ActiveRow.Cells["LOTQTY"].Value = "";
                    this.grid2.ActiveRow.Cells["FRAMEID"].Value = sFrameID;
                    this.grid2.ActiveRow.Cells["MASKID"].Value = sMaskID;
                    this.grid2.ActiveRow.Cells["FRAMENO"].Value = sFrameNo;
                    this.grid2.ActiveRow.Cells["SHEETNO"].Value = sSheetNo;

                    grid2.ActiveRow.Cells["PLANTCODE"].Activation = Activation.NoEdit;
                    //grid2.ActiveRow.Cells["ITEMCODE"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["ITEMCODE2"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["ITEMNAME"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["CONTRACTNO"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["ORDERNO"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["LOTQTY"].Activation = Activation.NoEdit;
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "WORKCENTERCODE");
                    //UltraGridUtil.ActivationAllowEdit(this.grid2, "ITEMCODE2");
                    //UltraGridUtil.ActivationAllowEdit(this.grid2, "ORDERQTY");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "FRAMEID");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "MASKID");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "ORDERDATE");

                    //this.grid2.ActiveRow.Cells["REMARK"].Activation = splitContainer2.Panel2Collapsed ? Activation.AllowEdit : Activation.NoEdit;

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

            string sPlantCode = string.Empty;
            string sOrderNo = string.Empty;
            string sItemCode = string.Empty;
            string sOrderDate = string.Empty;
            string sUser = LoginInfo.UserID;
            string sWCCD = string.Empty;
            string sContractNo = "";
            string sFrameID = "";
            string sMaskID = "";
            double dPriority1 ;
            double dPriority2;
            string sFrameNo = "";
            string sSheetNo = "";

            //double dOrderQty;

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

                            drChange.RejectChanges();

                            sPlantCode = DBHelper.nvlString(drChange["PLANTCODE"]);
                            sContractNo = DBHelper.nvlString(drChange["CONTRACTNO"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE2"]);
                            sOrderDate = DBHelper.nvlString(drChange["ORDERDATE"]);
                            sWCCD = DBHelper.nvlString(drChange["WORKCENTERCODE"]);
                            sOrderNo = DBHelper.nvlString(drChange["ORDERNO"]);
                            sFrameID = DBHelper.nvlString(drChange["FRAMEID"]);
                            sMaskID = DBHelper.nvlString(drChange["MASKID"]);
                            sFrameNo = DBHelper.nvlString(drChange["FRAMENO"]);
                            sSheetNo = DBHelper.nvlString(drChange["SHEETNO"]);

                            helper.ExecuteNoneQuery("USP_AP0128_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", sWCCD, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CONTRACTNO", sContractNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", sUser, DbType.String, ParameterDirection.Input));

                            break;

                        case DataRowState.Added:
                        case DataRowState.Modified:
                            #region --- 추가/수정/삭제 ---
                            string sPlanQty = "0";

                            sPlanQty = Convert.ToString(drChange["ORDERQTY"]);
                            sFrameID = Convert.ToString(drChange["FRAMEID"]);
                            sMaskID = Convert.ToString(drChange["MASKID"]);
                            dPriority1 = Convert.ToDouble(drChange["PRIORITY1"]);
                            dPriority2 = Convert.ToDouble(drChange["PRIORITY2"]);
                            sFrameNo = Convert.ToString(drChange["FRAMENO"]);
                            sSheetNo = Convert.ToString(drChange["SHEETNO"]);

                            if (drChange.RowState == DataRowState.Deleted || sPlanQty == "0")
                            {
                                sPlanQty = "";
                            }

                            sPlantCode = DBHelper.nvlString(drChange["PLANTCODE"]);
                            sContractNo = DBHelper.nvlString(drChange["CONTRACTNO"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE2"]);
                            sOrderDate = DBHelper.nvlString(drChange["ORDERDATE"]);
                            sWCCD = DBHelper.nvlString(drChange["WORKCENTERCODE"]);
                            sOrderNo = DBHelper.nvlString(drChange["ORDERNO"]);

                            if (sWCCD == "")
                            {
                                throw new Exception("작업장코드가 없는 항목이 있습니다.");
                            }

                            helper.ExecuteNoneQuery("USP_AP0128_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", sWCCD, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CONTRACTNO", sContractNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ORDERDATE", sOrderDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SETQTY", sPlanQty, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_FRAMEID", sFrameID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MASKID", sMaskID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AF_PRIORITY1", dPriority1, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_PRIORITY2", dPriority2, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AS_FRAMENO", sFrameNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHEETNO", sSheetNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", sUser, DbType.String, ParameterDirection.Input));

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
        #endregion

        #region < EVENT AREA >

        #endregion

        #region < METHOD AREA >

        #endregion

        private void grid_ClickCell(object sender, ClickCellEventArgs e)
        {
            Control.Grid grid = sender as Control.Grid;

            if (grid == null) return;

            if (e.Cell.Row.Index < 0) return;

            switch (grid.Name.ToUpper())
            {
                case "GRID1":
                    _GridUtil.Grid_Clear(grid2);


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
                //case "GRID2":
                //    _GridUtil.Grid_Clear(grid3);
                //    _GridUtil.Grid_Clear(grid4);

                //    PCODE = "S3";
                //    CONTRACTNO = grid1.ActiveRow.Cells["CONTRACTNO"].Text;
                //    SHIPNO = grid2.ActiveRow.Cells["SHIPNO"].Text;
                //    ITEMCODE = grid2.ActiveRow.Cells["ITEMCODE"].Text;
                //    ITEMNAME = grid2.ActiveRow.Cells["ITEMNAME"].Text;
                //    CUSTOMER = "";
                //    CUSTNAME = "";
                //    STARTDATE = "";
                //    ENDDATE = "";

                //    grid = grid3;
                //    break;

                //case "GRID3":
                //    _GridUtil.Grid_Clear(grid4);

                //    PCODE = "S4";
                //    CONTRACTNO = grid1.ActiveRow.Cells["CONTRACTNO"].Text;
                //    SHIPNO = grid3.ActiveRow.Cells["SHIPNO"].Text;
                //    ITEMCODE = grid1.ActiveRow.Cells["ITEMCODE"].Text;
                //    ITEMNAME = grid1.ActiveRow.Cells["ITEMNAME"].Text;
                //    CUSTOMER = "";
                //    CUSTNAME = "";
                //    STARTDATE = "";
                //    ENDDATE = "";

                //    grid = grid4;
                //    break;
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




    }
}

// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0141
//   Form Name    : 제품출고 등록2
//   Name Space   : WIZ.WM
//   Created Date : 2017-01-01
//   Made By      :
//   Description  :
// *---------------------------------------------------------------------------------------------*

using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

namespace WIZ.WM
{
    public partial class WM0141 : WIZ.Forms.BaseMDIChildForm
    {
        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        List<string> BoxList = new List<string>();
        DataTable dtGrid;
        DataTable dtGrid2;
        DataTable dtGrid3;
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
        string BOXSTART = "";
        string BOXEND = "";
        string btnTag = "";
        string cbxTag = "";
        string SHIPNO = "";
        string SHIPDATE = "";
        string BOXSEQ = "";



        public WM0141()
        {
            InitializeComponent();
        }

        private void WM0141_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = System.DateTime.Now.ToString("yyyy-01-01");
            cbo_ENDDATE_H.Value = DateTime.Now;

            cbo_STARTDATE2_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE2_H.Value = DateTime.Now;

            cbo_SHIPDATE_H.Value = DateTime.Now;

            btnAdd.Enabled = false;
            //---------------------------------

            //---------------------------------
            btnOUT.Tag = "I1_I2"; //출하
            btnDELETE.Tag = "I2_D1"; //폐기
            btnSelect.Tag = "S2_S2";
            btnAdd.Tag = "A1_I1";
            btnclear.Tag = "C1_C1"; //초기화
            cbx1.Tag = "S1_C2";
            cbx2.Tag = "S1_C3";
            //---------------------------------


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
                _GridUtil.InitializeGrid(grid1, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTSEQ", "수주순번", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "수주업체코드", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "수주업체", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTQTY", "수주수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SHIPQTY", "출하수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WMQTY", "재고수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "재공수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DUEDATE", "마감일자", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.SetInitUltraGridBind(grid1);

                //grid2
                _GridUtil.InitializeGrid(grid2, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PACKNO", "박스번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SHIPNO", "출하번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PACKQTY", "포장수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "RESULT", "상태", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);

                grid2.DisplayLayout.Override.SelectTypeCell = SelectType.ExtendedAutoDrag;
                grid2.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;


                //grid3
                _GridUtil.InitializeGrid(this.grid3, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "PACKNO", "박스번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "SHIPNO", "출하번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "PACKQTY", "포장수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "RESULT", "상태", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.SetInitUltraGridBind(grid3);

                grid3.DisplayLayout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;
                grid3.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;

                //grid4
                _GridUtil.InitializeGrid(this.grid4, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid4, "BOXSEQ", "BOXSEQ", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "BOXNAME", "박스번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "PACKQTY", "포장수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.SetInitUltraGridBind(grid4);

                //grid5
                _GridUtil.InitializeGrid(grid5, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid5, "CUSTCODE", "고객사", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid5, "CUSTNAME", "고객사", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid5, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid5, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid5, "PACKQTY", "포장단위", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid5, "SELSUM", "합계수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid5, "SELCOUNT", "박스수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.SetInitUltraGridBind(grid5);

                //grid6
                _GridUtil.InitializeGrid(grid6, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid6, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid6, "SELOUTNO", "출하지시번호", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid6, "SHIPNO", "출하번호", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid6, "RECDATE", "출하날짜", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid6, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid6, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid6, "PLANQTY", "지시수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid6, "SHIPQTY", "출하수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid6, "BOXCOUNT", "박스수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid6, "CUSTCODE", "고객사", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid6, "CUSTNAME", "고객사명", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid6, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid6, "CONTRACTSEQ", "수주순번", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid6);

                btbManager.PopUpAdd(txt_CUSTCODE2_H, txt_CUSTNAME2_H, "BM0030", new object[] { cbo_PLANTCODE_H, "", "", "Y" });
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
            _GridUtil.Grid_Clear(grid6);

            _GridUtil.Grid_Clear(grid2);
            _GridUtil.Grid_Clear(grid3);
            Data_SEQ();

            txtCONTRACTNO.Text = "";
            txtSHIPNO.Text = "";
            Grid_data(grid1);
            Grid_data(grid6);

            btnAdd.Enabled = false;
        }

        public void Data_SEQ()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                PLANTCODE = Convert.ToString(cbo_PLANTCODE_H.Value);
                SHIPNO = txtSHIPNO.Text.Trim();

                string sItemCode = DBHelper.nvlString(cmbItem.SelectedValue);

                dtGrid3 = helper.FillTable("USP_WM0141_S2", CommandType.StoredProcedure
                         , helper.CreateParameter("PCODE", "S10", DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_BOXSEQ", BOXSEQ, DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_ETC1", sItemCode, DbType.String, ParameterDirection.Input));

                //cbx1.Items.Clear();
                //cbx2.Items.Clear();

                //if (dtGrid3.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dtGrid3.Rows.Count; i++)
                //    {
                //        cbx1.Items.Add(DBHelper.nvlString(dtGrid3.Rows[i]["BOXSEQ"]));
                //        cbx2.Items.Add(DBHelper.nvlString(dtGrid3.Rows[i]["BOXSEQ"]));
                //    }


                //}
                cbx1.SuspendLayout();
                cbx2.SuspendLayout();


                Common.FillComboboxMaster(cbx1, dtGrid3, "BOXSEQ", "BOXNAME", "", "");
                Common.FillComboboxMaster(cbx2, dtGrid3, "BOXSEQ", "BOXNAME", "", "");

                this.cbx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cbx2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

                cbx1.ResumeLayout(false);
                cbx2.ResumeLayout(false);
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

        public void Grid_data(Control.Grid grid)
        {
            DBHelper helper = new DBHelper(false);

            btnAdd.Enabled = false;

            try
            {
                switch (grid.Name.ToUpper())
                {
                    case "GRID1":
                        PCODE = "S1";
                        break;
                    case "GRID6":
                        PCODE = "S6";
                        break;

                    case "":
                        break;
                }

                PLANTCODE = Convert.ToString(cbo_PLANTCODE_H.Value);
                CONTRACTNO = "";
                SHIPNO = "";
                ITEMCODE = txt_ITEMCODE_H.Text.Trim();
                ITEMNAME = txt_ITEMNAME_H.Text.Trim();
                CUSTOMER = txt_CUSTCODE2_H.Text.Trim();
                CUSTNAME = "";

                if (grid.Name.ToUpper() == "GRID1")
                {
                    STARTDATE = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                    ENDDATE = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                }

                if (grid.Name.ToUpper() == "GRID6")
                {
                    STARTDATE = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE2_H.Value);
                    ENDDATE = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE2_H.Value);
                }


                BOXSTART = "";
                BOXEND = "";

                dtGrid = helper.FillTable("USP_WM0141_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("PCODE", PCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMNAME", ITEMNAME, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTOMER", CUSTOMER, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_BOXSTART", BOXSTART, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_BOXEND", BOXEND, DbType.String, ParameterDirection.Input)
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

        public void Grid_data2(Control.Grid grid)
        {
            DBHelper helper = new DBHelper(false);
            string sItemCode = "";
            try
            {
                switch (grid.Name.ToUpper())
                {
                    case "GRID4":
                        PCODE = "S1";
                        break;
                    case "GRID2":
                        PCODE = "S2";
                        BOXSEQ = DBHelper.nvlString(cbx1.SelectedValue);
                        sItemCode = CModule.ToString(cmbItem.SelectedValue);

                        break;
                    case "GRID3":
                        PCODE = "S2";
                        BOXSEQ = DBHelper.nvlString(cbx2.SelectedValue);
                        sItemCode = CModule.ToString(cmbItem.SelectedValue);
                        break;
                    case "":
                        break;
                }

                _GridUtil.Grid_Clear(grid);

                PLANTCODE = Convert.ToString(cbo_PLANTCODE_H.Value);
                SHIPNO = txtSHIPNO.Text.Trim();

                if (BOXSEQ == "-1")
                {
                    return;
                }

                DataSet ds = helper.FillDataSet("USP_WM0141_S2", CommandType.StoredProcedure
                        , helper.CreateParameter("PCODE", PCODE, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_BOXSEQ", BOXSEQ, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ETC1", sItemCode, DbType.String, ParameterDirection.Input));

                if (ds.Tables.Count > 0)
                {
                    grid.DataSource = ds.Tables[0];
                    grid.DataBinds();

                    if (ds.Tables.Count >= 2 && grid.Name.ToUpper() == "GRID4")
                    {
                        cmbItem.SuspendLayout();
                        Common.FillComboboxMaster(cmbItem, ds.Tables[1], "ITEMCODE", "ITEMNAME", null, null);
                        this.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        cmbItem.ResumeLayout(false);
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
        }

        public override void DoDelete()
        {
            base.DoDelete();

            this.grid6.DeleteRow();

        }

        public override void DoSave()
        {
            DBHelper helper = new DBHelper("", true);

            DataTable dtChange = grid6.chkChange();


            if (dtChange == null)
                return;

            base.DoSave();

            try
            {
                foreach (DataRow drChange in dtChange.Rows)
                {
                    switch (drChange.RowState)
                    {
                        case DataRowState.Deleted:
                            #region --- 삭제 ---

                            string sPlantCode = string.Empty;
                            string sSelOutNo = string.Empty;
                            string sCustcode = string.Empty;
                            string sItemCode = string.Empty;
                            string sShipNo = string.Empty;
                            string sUser = LoginInfo.UserID;

                            #region --- 삭제 ---

                            if (this.ShowDialog(Common.getLangText("출하삭제 하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.YESNO) == System.Windows.Forms.DialogResult.OK)
                            {
                                drChange.RejectChanges();
                                sPlantCode = DBHelper.nvlString(drChange["PLANTCODE"]);
                                sSelOutNo = DBHelper.nvlString(drChange["SELOUTNO"]);
                                sShipNo = DBHelper.nvlString(drChange["SHIPNO"]);
                                sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);


                                if (sSelOutNo != "" || sShipNo != "")
                                {

                                    helper.ExecuteNoneQuery("USP_WM0141_D1", CommandType.StoredProcedure
                                  , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                  , helper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
                                  , helper.CreateParameter("AS_SHIPNO", sShipNo, DbType.String, ParameterDirection.Input)
                                  , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));
                                    #endregion
                                    if (helper.RSCODE != "S")
                                    {
                                        throw new Exception(helper.RSMSG);
                                    }
                                    else
                                    {
                                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                                        helper.Commit();
                                        Grid_data(grid6);
                                        Clear_01();
                                    }
                                }
                            }

                            #endregion
                            break;
                        case DataRowState.Added:
                        case DataRowState.Modified:
                            #region --- 추가/수정 --



                            #endregion
                            break;
                    }
                }
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
        //초기화
        private void Clear_01()
        {
            //txtCONTRACTNO.Text = string.Empty;
            //txtSHIPNO.Text = string.Empty;

            txtBOXSTART.Text = string.Empty;
            txtBOXEND.Text = string.Empty;

            _GridUtil.Grid_Clear(grid2); //아래 상세조회(왼쪽) 그리드
            _GridUtil.Grid_Clear(grid3); //아래 상세조회(오릔쪽) 그리드
            _GridUtil.Grid_Clear(grid4); //아래 BOXLIST 그리드
            _GridUtil.Grid_Clear(grid5); //고객사 그리드

            Grid_data2(grid4);

            Data_SEQ(); //박스 SEQ



        }

        private void btn_ROWINSERT_B_Click(object sender, EventArgs e)
        {
            Infragistics.Win.Misc.UltraButton btn = sender as Infragistics.Win.Misc.UltraButton;

            if (btn != null)
            {
                switch (btn.Name)
                {
                    case "btn_ROWINSERT_B":
                        // 포장처리
                        Box(grid2, cbx2);
                        break;
                    case "btn_ROWDELETE_B":
                        // 포장취소
                        Box(grid3, cbx1);
                        break;
                }
            }
        }

        private void Box(Control.Grid grid, ComboBox toCBox)
        {
            // 포장처리
            if (grid.Rows.Count > 0 && grid.ActiveRow != null)
            {
                string sShipNo = "";

                for (int i = 0; i < grid.Selected.Rows.Count; i++)
                {
                    string sPackNo = DBHelper.nvlString(grid.Selected.Rows[i].Cells["PACKNO"].Value);
                    sShipNo = DBHelper.nvlString(grid.Selected.Rows[i].Cells["SHIPNO"].Value);

                    if (sPackNo != "")
                    {
                        BoXListAdd(sPackNo);
                    }
                    else
                    {
                        this.ShowDialog("PACKNO 정확하게 선택하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }

                DBHelper helper = new DBHelper("", true);

                foreach (string vPackno in BoxList)
                {
                    try
                    {
                        PLANTCODE = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                        //BOXSEQ = DBHelper.nvlString(Boxseq.Key);
                        BOXSEQ = "";
                        string sPackno = DBHelper.nvlString(vPackno.ToString());
                        string sNextBoxSeq = DBHelper.nvlString(toCBox.SelectedValue);

                        //if (sShipNo == "")
                        //{
                        //    sShipNo = txtSHIPNO.Text.Trim();
                        //}

                        helper.ExecuteNoneQuery("USP_WM0141_U1", CommandType.StoredProcedure
                                , helper.CreateParameter("PCODE", "U1", DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_BOXSEQ", BOXSEQ, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_NEXTBOXSEQ", sNextBoxSeq, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_PACKNO", sPackno, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_SHIPNO", sShipNo, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "E")
                        {
                            throw new Exception(helper.RSMSG);
                        }

                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }

                helper.Commit();
                Grid_data2(grid2);
                Grid_data2(grid3);
                Grid_data2(grid4);
                BoxList.Clear();
            }
        }

        private void BoXListAdd(string value)
        {
            if (!this.BoxList.Contains(value))
            {
                this.BoxList.Add(value);
            }
        }

        private void btnDeleteRight_Click(object sender, EventArgs e)
        {
            Infragistics.Win.Misc.UltraButton btn = sender as Infragistics.Win.Misc.UltraButton;

            if (btn != null)
            {
                switch (btn.Name)
                {
                    case "btnDeleteLeft":
                        // 포장처리
                        BoxRemove(grid2);
                        break;
                    case "btnDeleteRight":
                        // 포장취소
                        BoxRemove(grid3);
                        break;
                }
            }
        }

        private void BoxRemove(Control.Grid grid)
        {
            // 포장처리
            if (grid.Rows.Count > 0 && grid.ActiveRow != null)
            {
                string sShipNo = "";

                for (int i = 0; i < grid.Selected.Rows.Count; i++)
                {
                    string sPackNo = DBHelper.nvlString(grid.Selected.Rows[i].Cells["PACKNO"].Value);
                    sShipNo = DBHelper.nvlString(grid.Selected.Rows[i].Cells["SHIPNO"].Value);

                    if (sPackNo != "")
                    {
                        BoXListAdd(sPackNo);
                    }
                    else
                    {
                        this.ShowDialog("PACKNO 정확하게 선택하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }

                DBHelper helper = new DBHelper("", true);

                foreach (string vPackno in BoxList)
                {
                    try
                    {
                        PLANTCODE = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                        //BOXSEQ = DBHelper.nvlString(Boxseq.Key);
                        BOXSEQ = "";
                        string sPackno = DBHelper.nvlString(vPackno.ToString());

                        if (sShipNo == "")
                        {
                            sShipNo = txtSHIPNO.Text.Trim();
                        }

                        helper.ExecuteNoneQuery("USP_WM0141_U1", CommandType.StoredProcedure
                                , helper.CreateParameter("PCODE", "D1", DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_BOXSEQ", "", DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_NEXTBOXSEQ", "", DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_PACKNO", sPackno, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_SHIPNO", sShipNo, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "E")
                        {
                            throw new Exception(helper.RSMSG);
                        }
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }

                helper.Commit();
                Grid_data2(grid2);
                Grid_data2(grid3);
                Grid_data2(grid4);
                BoxList.Clear();
            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data_SEQ();
        }

        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox buffer = (ComboBox)sender;
            cbxTag = buffer.Tag.ToString();
            string select = "";
            string select2 = "";

            switch (cbxTag)
            {
                case "S1_C2": // 초기화
                case "S1_C3": // 초기화
                    select = DBHelper.nvlString(cbx1.Text);
                    select2 = DBHelper.nvlString(cbx2.Text);

                    if (select != "" && select2 != "")
                    {
                        if (select == select2)
                        {
                            if (cbxTag == "S1_C2")
                            {
                                cbx1.SelectedIndex = -1;
                            }
                            else
                            {
                                cbx2.SelectedIndex = -1;
                            }
                            MessageBox.Show("같은 박스 SEQ 사용 할 수 없습니다.");
                            return;
                        }
                    }

                    if (cbxTag == "S1_C2")
                    {
                        Grid_data2(grid2);
                    }

                    if (cbxTag == "S1_C3")
                    {
                        Grid_data2(grid3);
                    }
                    break;
            }
        }

        private void grid_ClickCell(object sender, ClickCellEventArgs e)
        {
            Control.Grid grid = sender as Control.Grid;

            if (grid == null) return;

            if (e.Cell.Row.Index < 0) return;

            switch (grid.Name.ToUpper())
            {
                case "GRID1":

                    if (grid1.ActiveCell == null)
                    {
                        this.ShowDialog("셀 선택을 정확하게 하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }

                    txtCONTRACTNO.Text = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
                    txtSeq.Text = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTSEQ"].Value);
                    txtCust.Tag = DBHelper.nvlString(grid1.ActiveRow.Cells["CUSTCODE"].Value);
                    txtCust.Text = DBHelper.nvlString(grid1.ActiveRow.Cells["CUSTNAME"].Value);

                    DBHelper helper2 = new DBHelper(false);

                    PLANTCODE = Convert.ToString(cbo_PLANTCODE_H.Value);
                    CONTRACTNO = "";
                    SHIPNO = "";
                    ITEMCODE = txt_ITEMCODE_H.Text.Trim();
                    ITEMNAME = txt_ITEMNAME_H.Text.Trim();
                    CUSTNAME = "";
                    STARTDATE = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                    ENDDATE = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                    PCODE = "S2";

                    BOXSTART = txtBOXSTART.Text.Trim();
                    BOXEND = txtBOXEND.Text.Trim();

                    dtGrid2 = helper2.FillTable("USP_WM0141_S1", CommandType.StoredProcedure
                        , helper2.CreateParameter("PCODE", PCODE, DbType.String, ParameterDirection.Input)
                        , helper2.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                        , helper2.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
                        , helper2.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                        , helper2.CreateParameter("AS_ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                        , helper2.CreateParameter("AS_ITEMNAME", ITEMNAME, DbType.String, ParameterDirection.Input)
                        , helper2.CreateParameter("AS_CUSTOMER", "", DbType.String, ParameterDirection.Input)
                        , helper2.CreateParameter("AS_CUSTNAME", "", DbType.String, ParameterDirection.Input)
                        , helper2.CreateParameter("AS_STARTDATE", STARTDATE, DbType.String, ParameterDirection.Input)
                        , helper2.CreateParameter("AS_BOXSTART", BOXSTART, DbType.String, ParameterDirection.Input)
                        , helper2.CreateParameter("AS_BOXEND", BOXEND, DbType.String, ParameterDirection.Input)
                        , helper2.CreateParameter("AS_ENDDATE", ENDDATE, DbType.String, ParameterDirection.Input));

                    grid5.DataSource = dtGrid2;
                    grid5.DataBinds();

                    break;

                case "GRID6":
                    txtSHIPNO.Text = DBHelper.nvlString(grid6.ActiveRow.Cells["SHIPNO"].Value);
                    txtCONTRACTNO.Text = DBHelper.nvlString(grid6.ActiveRow.Cells["CONTRACTNO"].Value);
                    txtSeq.Text = DBHelper.nvlString(grid6.ActiveRow.Cells["CONTRACTSEQ"].Value);

                    txtCust.Tag = DBHelper.nvlString(grid6.ActiveRow.Cells["CUSTCODE"].Value);
                    txtCust.Text = DBHelper.nvlString(grid6.ActiveRow.Cells["CUSTNAME"].Value);

                    cbo_SHIPDATE_H.Text = DBHelper.nvlString(string.Format("{0:yyyy-MM-dd}", cbo_SHIPDATE_H.Value));

                    _GridUtil.Grid_Clear(grid2);
                    _GridUtil.Grid_Clear(grid3);
                    _GridUtil.Grid_Clear(grid4);

                    Grid_data2(grid2);
                    Grid_data2(grid3);
                    Grid_data2(grid4);

                    Data_SEQ();

                    break;
            }
            try
            {

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

        private void btn_click_event(object sender, EventArgs e)
        {
            Button buffer = (Button)sender;
            btnTag = buffer.Tag.ToString();

            DBHelper helper = new DBHelper("", true);

            btnAdd.Enabled = false;

            switch (btnTag)
            {
                case "A1_I1": // 박스추가
                    try
                    {
                        CONTRACTNO = txtCONTRACTNO.Text.Trim();

                        //if (btnTag == "A1_I1" && txtSHIPNO.Text.Length == 0)
                        //{
                        //    this.ShowDialog("처리번호 미입력", Forms.DialogForm.DialogType.OK);
                        //    return;
                        //}
                        //else
                        //{
                        SHIPNO = txtSHIPNO.Text.Trim();
                        //}
                        BOXSTART = txtBOXSTART.Text.Trim();
                        BOXEND = txtBOXEND.Text.Trim();
                        SHIPDATE = string.Format("{0:yyyy-MM-dd}", cbo_SHIPDATE_H.Value);
                        CUSTOMER = DBHelper.nvlString(txtCust.Tag);

                        if (txtBOXSTART.Text.Length == 0 || txtBOXEND.Text.Length == 0)
                        {
                            this.ShowDialog("처리번호 미입력", Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        helper.ExecuteNoneQuery("USP_WM0141_I1", CommandType.StoredProcedure
                                , helper.CreateParameter("PCODE", btnTag.Replace("A1_", ""), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_SHIPDATE", SHIPDATE, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_BOXSTART", BOXSTART, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_BOXEND", BOXEND, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_CUSTOMER", CUSTOMER, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));


                        if (helper.RSCODE == "S")
                        {
                            helper.Commit();

                            Clear_01();
                            DoInquire();
                        }
                        else
                        {
                            helper.Rollback();
                            throw new Exception(helper.RSMSG);
                        }

                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        MessageBox.Show(ex.ToString());

                    }
                    break;

                case "I1_I2": //출하처리
                    try
                    {
                        if (txtCONTRACTNO.Text.Length == 0)
                        {
                            this.ShowDialog("수주번호 미입력", Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (txtCust.Text.Length == 0)
                        {
                            this.ShowDialog("고객사번호 미입력", Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (txtSHIPNO.Text.Length == 0)
                        {
                            this.ShowDialog("출하번호 미입력", Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (cbo_SHIPDATE_H.Text.Length == 0)
                        {
                            this.ShowDialog("출하날짜 미입력", Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        PLANTCODE = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                        SHIPNO = DBHelper.nvlString(txtSHIPNO.Text.Trim());
                        SHIPDATE = DBHelper.nvlString(cbo_SHIPDATE_H.Text.Trim());
                        CUSTOMER = DBHelper.nvlString(txtCust.Tag);

                        if (this.ShowDialog(Common.getLangText("출하처리 하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.YESNO) == System.Windows.Forms.DialogResult.OK)
                        {

                            helper.ExecuteNoneQuery("USP_WM0141_I5", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_SHIPDATE", SHIPDATE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_CUSTCODE", CUSTOMER, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));


                            if (helper.RSCODE == "S")
                            {
                                helper.Commit();
                                this.ShowDialog("출하처리 되었습니다.", Forms.DialogForm.DialogType.OK);

                                txtSHIPNO.Text = string.Empty;
                                txtCust.Text = string.Empty;
                                txtCONTRACTNO.Text = string.Empty;
                                cbo_SHIPDATE_H.Value = DateTime.Now;
                                Data_SEQ();
                            }
                            else
                            {
                                helper.Rollback();
                                throw new Exception(helper.RSMSG);
                            }
                            DoInquire();
                        }
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        MessageBox.Show(ex.ToString());

                    }
                    break;
                case "S2_S2": // 박스합계조회
                    try
                    {
                        DBHelper helper2 = new DBHelper(false);

                        PLANTCODE = Convert.ToString(cbo_PLANTCODE_H.Value);
                        CONTRACTNO = "";
                        SHIPNO = "";
                        ITEMCODE = txt_ITEMCODE_H.Text.Trim();
                        ITEMNAME = txt_ITEMNAME_H.Text.Trim();
                        CUSTNAME = "";
                        CUSTOMER = DBHelper.nvlString(txtCust.Tag);
                        STARTDATE = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                        ENDDATE = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                        PCODE = "S2";

                        BOXSTART = txtBOXSTART.Text.Trim();
                        BOXEND = txtBOXEND.Text.Trim();

                        dtGrid2 = helper2.FillTable("USP_WM0141_S1", CommandType.StoredProcedure
                            , helper2.CreateParameter("PCODE", PCODE, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_ITEMNAME", ITEMNAME, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_CUSTOMER", CUSTOMER, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_CUSTNAME", CUSTNAME, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_STARTDATE", STARTDATE, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_BOXSTART", BOXSTART, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_BOXEND", BOXEND, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_ENDDATE", ENDDATE, DbType.String, ParameterDirection.Input));

                        if (helper2.RSCODE == "E")
                        {
                            MessageBox.Show(helper2.RSMSG, "출하처리오류");
                            return;
                        }

                        btnAdd.Enabled = true;

                        grid5.DataSource = dtGrid2;
                        grid5.DataBinds();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;
                case "C1_C1": // 초기화
                    txtCONTRACTNO.Text = "";
                    txtSeq.Text = "";
                    txtSHIPNO.Text = "";
                    txtCust.Text = "";
                    txtCust.Tag = "";

                    txtBOXSTART.Text = string.Empty;
                    txtBOXEND.Text = string.Empty;

                    _GridUtil.Grid_Clear(grid5);
                    _GridUtil.Grid_Clear(grid2);
                    _GridUtil.Grid_Clear(grid3);
                    _GridUtil.Grid_Clear(grid4);


                    break;
                case "I2_D1": // 폐기
                    if (DBHelper.nvlString(cbx1.SelectedValue) == "999")
                    {
                        Box_Disposal(grid2, cbx1);
                    }

                    if (DBHelper.nvlString(cbx2.SelectedValue) == "999")
                    {
                        Box_Disposal(grid3, cbx2);
                    }
                    break;
            }
        }

        private void Box_Disposal(Control.Grid grid, ComboBox toCBox)
        {
            // 포장처리
            if (grid.Rows.Count > 0 && grid.ActiveRow != null)
            {
                string sShipNo = "";
                DBHelper helper = new DBHelper("", true);
                PLANTCODE = DBHelper.nvlString(cbo_PLANTCODE_H.Value);

                for (int i = 0; i < grid.Selected.Rows.Count; i++)
                {
                    sShipNo = DBHelper.nvlString(grid.Selected.Rows[i].Cells["SHIPNO"].Value);

                    try
                    {

                        helper.ExecuteNoneQuery("USP_WM0140_I2", CommandType.StoredProcedure
                            , helper.CreateParameter("PCODE", "D1", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHIPNO", sShipNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));


                        if (helper.RSCODE != "S")
                        {
                            throw new Exception(helper.RSMSG);
                        }
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        MessageBox.Show(ex.ToString());
                    }

                }

                helper.Commit();
                BoxRemove(grid);

                Grid_data2(grid2);
                Grid_data2(grid3);
                Grid_data2(grid4);

            }
        }
        #endregion

    }
}

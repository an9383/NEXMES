// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0140
//   Form Name    : 제품출고 등록2
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
    public partial class WM0140 : WIZ.Forms.BaseMDIChildForm
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
        string CUSTOMER = "";
        string CUSTNAME = "";
        string STARTDATE = "";
        string ENDDATE = "";
        string BOXSTART = "";
        string BOXEND = "";
        string btnTag = "";
        string SHIPNO = "";
        string SHIPDATE = "";



        public WM0140()
        {
            InitializeComponent();
        }

        private void WM0140_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;
            cbo_SHIPDATE_H.Value = DateTime.Now;

            //---------------------------------
            btnCANCEL.Tag = "I2_C1"; //출하취소
            btnRESTORE.Tag = "I2_R1"; //복구
            btnDELETE.Tag = "I2_D1"; //폐기
            //---------------------------------
            btnOUT.Tag = "I1_I1"; //출하
            //btnOUT.Tag = "I1_I2"; //재발행
            btnDELETE2.Tag = "I1_D1"; //폐기
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
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
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
                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "Result", "상태", false, GridColDataType_emu.VarChar, 50, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SHIPNO", "출하번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SHIPQTY", "출하수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.SetInitUltraGridBind(grid2);

                //grid3
                _GridUtil.InitializeGrid(grid3, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "Result", "상태", false, GridColDataType_emu.VarChar, 50, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "PACKNO", "박스번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "PACKDT", "포장일자", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "PACKQTY", "출하수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.SetInitUltraGridBind(grid3);

                //grid4
                _GridUtil.InitializeGrid(grid4, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid4, "CHK", "", true, GridColDataType_emu.CheckBox, 50, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "PACKNO", "박스번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "PACKQTY", "포장수량", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 0, Infragistics.Win.HAlign.Left, true, false);
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

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            Control.Grid grid = sender as Control.Grid;

            if (grid == null) return;

            if (e.Cell.Row.Index < 0) return;

            switch (grid.Name.ToUpper())
            {
                case "GRID1":
                    _GridUtil.Grid_Clear(grid2);
                    _GridUtil.Grid_Clear(grid3);

                    txtCONTRACTNO.Text = grid1.ActiveRow.Cells["CONTRACTNO"].Text; //출하에 사용

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

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0) return;

            _GridUtil.Grid_Clear(grid3);

            try
            {
                PCODE = "S3";
                CONTRACTNO = grid1.ActiveRow.Cells["CONTRACTNO"].Text;
                SHIPNO = grid2.ActiveRow.Cells["SHIPNO"].Text;
                ITEMCODE = grid2.ActiveRow.Cells["ITEMCODE"].Text;
                ITEMNAME = grid2.ActiveRow.Cells["ITEMNAME"].Text;
                CUSTOMER = "";
                CUSTNAME = "";
                STARTDATE = "";
                ENDDATE = "";

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

                grid3.DataSource = dtGrid;
                grid3.DataBinds();
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

            switch (btnTag)
            {
                case "I2_C1": // 출하취소
                case "I2_R1": // 복구
                case "I2_D1": // 폐기
                    try
                    {
                        SHIPNO = grid2.ActiveRow.Cells["SHIPNO"].Text;
                        helper.ExecuteNoneQuery("USP_WM0140_I2", CommandType.StoredProcedure
                            , helper.CreateParameter("PCODE", btnTag.Replace("I2_", ""), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
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

                case "I1_I1": // 출하
                case "I1_D1": // 폐기

                    CONTRACTNO = txtCONTRACTNO.Text;

                    //if (btnTag == "I1_I1" && txtSHIPNO.Text.Length == 0)
                    //{
                    //    this.ShowDialog("처리번호 미입력", Forms.DialogForm.DialogType.OK);
                    //    return;
                    //}
                    //else
                    //{
                    SHIPNO = txtSHIPNO.Text;
                    //}

                    SHIPDATE = string.Format("{0:yyyy-MM-dd}", cbo_SHIPDATE_H.Value);

                    string sBoxList = "";
                    string sTag = btnTag.Replace("I1_", "");
                    int iChk = 0;

                    for (int i = 0; i < grid4.Rows.Count; i++)
                    {
                        if (DBHelper.nvlString(grid4.Rows[i].Cells["CHK"].Value) == "1")
                        {
                            iChk++;
                        }
                    }

                    if (iChk > 0)
                    {
                        string sMes = "";

                        if (sTag == "I1")
                        {
                            //if (txtSHIPNO.Text.Trim() == "")
                            //{
                            //    this.ShowDialog("출하번호가 없습니다.", Forms.DialogForm.DialogType.OK);
                            //    return;
                            //}

                            //if (txtCONTRACTNO.Text.Trim() == "")
                            //{
                            //    this.ShowDialog("선택한 수주번호가 없습니다.", Forms.DialogForm.DialogType.OK);
                            //    return;
                            //}

                            sMes = iChk.ToString() + "개의 박스를 출고 처리하겠습니까?";
                        }
                        else
                        {
                            sMes = iChk.ToString() + "개의 박스를 폐기 처리하겠습니까?";
                        }

                        if (this.ShowDialog(Common.getLangText(sMes, "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                        {
                            CancelProcess = true;
                            return;
                        }
                    }
                    else
                    {
                        this.ShowDialog("선택된 박스가 없습니다.", Forms.DialogForm.DialogType.OK);
                        return;
                    }

                    try
                    {
                        if (sTag == "I1")
                        {
                            for (int i = 0; i < grid4.Rows.Count; i++)
                            {
                                string sBox = "";

                                if (DBHelper.nvlString(grid4.Rows[i].Cells["CHK"].Value) == "1")
                                {
                                    sBox = DBHelper.nvlString(grid4.Rows[i].Cells["PACKNO"].Value);

                                    if (sBoxList.Length + sBox.Length + 3 >= 4000)
                                    {
                                        helper.ExecuteNoneQuery("USP_WM0140_I3", CommandType.StoredProcedure
                                                , helper.CreateParameter("PCODE", "I0", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_SHIPDATE", SHIPDATE, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_BOXLIST", sBoxList, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

                                        if (helper.RSCODE == "E")
                                        {
                                            throw new Exception(helper.RSMSG);
                                        }

                                        if (helper.RSMSG != "")
                                        {
                                            string[] sArr = helper.RSMSG.Split(',');
                                            CONTRACTNO = sArr[0];
                                            SHIPNO = sArr[1];
                                        }

                                        helper.ExecuteNoneQuery("USP_WM0140_I3", CommandType.StoredProcedure
                                            , helper.CreateParameter("PCODE", btnTag.Replace("I1_", ""), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_SHIPDATE", SHIPDATE, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_BOXLIST", sBoxList, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

                                        if (helper.RSCODE == "E")
                                        {
                                            throw new Exception(helper.RSMSG);
                                        }

                                        sBoxList = "";
                                    }

                                    if (sBoxList == "")
                                    {
                                        sBoxList = sBox;
                                    }
                                    else
                                    {
                                        sBoxList += "|" + sBox;
                                    }
                                }
                            }

                            if (sBoxList != "")
                            {
                                helper.ExecuteNoneQuery("USP_WM0140_I3", CommandType.StoredProcedure
                                    , helper.CreateParameter("PCODE", "I0", DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_SHIPDATE", SHIPDATE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_BOXLIST", sBoxList, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    throw new Exception(helper.RSMSG);
                                }

                                if (helper.RSMSG != "")
                                {
                                    string[] sArr = helper.RSMSG.Split(',');
                                    CONTRACTNO = sArr[0];
                                    SHIPNO = sArr[1];
                                }

                                helper.ExecuteNoneQuery("USP_WM0140_I3", CommandType.StoredProcedure
                                    , helper.CreateParameter("PCODE", btnTag.Replace("I1_", ""), DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_SHIPDATE", SHIPDATE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_BOXLIST", sBoxList, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "S")
                                {
                                    helper.Commit();

                                    DoInquire();
                                }
                                else
                                {
                                    throw new Exception(helper.RSMSG);
                                }
                            }
                            else
                            {
                                helper.Commit();

                                Grid_data(grid4);
                            }
                        }
                        else
                        {
                            // 폐기 처리일 경우 처리
                            helper.Commit();

                            Grid_data(grid4);
                        }
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        MessageBox.Show(ex.ToString());

                    }
                    break;
            }
        }

        private void btnOUT_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}

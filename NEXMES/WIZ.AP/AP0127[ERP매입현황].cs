// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0127
//   Form Name    : 제품출고 등록2
//   Name Space   : WIZ.AP
//   Created Date : 2017-01-01
//   Made By      :
//   Description  :
// *---------------------------------------------------------------------------------------------*

using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;

namespace WIZ.AP
{
    public partial class AP0127 : WIZ.Forms.BaseMDIChildForm
    {
        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;
        bool bPop2 = false;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();

        DataTable dtGrid;
        DataTable dtGrid2;
        DBHelper helper = new DBHelper(false);
        private string UserID = DBHelper.nvlString(WIZ.LoginInfo.UserID);

        public AP0127()
        {
            InitializeComponent();
        }

        private void AP0127_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-30);
            cbo_ENDDATE_H.Value = DateTime.Now;


            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            ////업체별 
            //DataRow[] dArr = rtnDtTemp.Select("CODE_NAME_ORG = '위즈코어' "); //대화산업
            //if (dArr.Length == 1)
            //{
            //    Common.PLANTNAME = DBHelper.nvlString(dArr[0]["CODE_NAME_ORG"]);
            //}

            rtnDtTemp = _Common.GET_BM0000_CODE("STATUS");
            WIZ.Common.FillComboboxMaster(this.cbo_FINISHFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FINISHFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "FINISHFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE");
            //WIZ.Common.FillComboboxMaster(this.cbo_FINISHFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            BizGridManager bizGridManager;
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "4", "" });
            btbManager.PopUpAdd(txt_CUSTCODE_H, txt_CUSTNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "VD", "", "" });

            // grid 입력용 POPUP
            bizGridManager = new BizGridManager(grid1);
            //bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "4", "" });
            //bizGridManager.PopUpAdd("CUSTCODE", "CUSTNAME", "BM0030", new string[] { "PLANTCODE", "VD", "" });
            bizGridManager.PopUpAdd("CUSTCODE2", "CUSTNAME2", "BM0030", new string[] { "PLANTCODE", "VD", "" });

            if (this.subData["METHOD_TYPE", "POPUP_TYPE"] is null)
            {
                bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "4", "" });
                bizGridManager.PopUpAdd("CUSTCODE", "CUSTNAME", "BM0030", new string[] { "PLANTCODE", "VD", "" });
            }
            else
            {
                PopUp_Common.SetPop(new object[] { grid1, "PLANTCODE", "ITEMCODE", "ITEMNAME", "CUSTCODE", "CUSTNAME" }, "MM0000_POP", new object[] { grid1, "CUSTCODE", "CUSTNAME", "ITEMCODE", "ITEMNAME" });
            }

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-15);
            cbo_ENDDATE_H.Value = DateTime.Now;

            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            #endregion
        }
        private void GridInitialize()
        {
            try
            {
                //grid1
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "SAVEBUTTON", "가입고", true, GridColDataType_emu.Button, 70, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "POSEQNO", "발주순번", true, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PODATE", "발주일", true, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANINDATE", "입고예정일", true, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목유형", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPENAME", "품목유형", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPFLAG", "검사구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "POQTY", "발주량(ⓐ)", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCOST", "매입단가", true, GridColDataType_emu.Float, 90, 100, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, true);

                //2020-07-07 이후 개발 예정
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMSPEC", "규격", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INQTY", "입고량", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "TMPINQTY", "가입고량(ⓑ)", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REINQTY", "입고잔량(ⓐ-ⓑ)", true, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, true);

                //2021-06-15 최문석 금액부분 추가
                _GridUtil.InitColumnUltraGrid(grid1, "FINISHFLAG", "진행여부", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["PODATE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["PLANINDATE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["CUSTNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid1.DisplayLayout.Bands[0].Columns["CUSTCODE2"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid1.DisplayLayout.Bands[0].Columns["CUSTNAME2"].Header.Appearance.ForeColor   = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["POQTY"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["USEFLAG"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["UNITCOST"].Header.Appearance.ForeColor = Color.SkyBlue;

                //grid1.Columns["POQTY"].Format = "#,##0";
                //grid1.Columns["INQTY"].Format = "#,##0";
                //grid1.Columns["TMPINQTY"].Format = "#,##0";
                //grid1.Columns["REINQTY"].Format = "#,##0";

                _GridUtil.SetInitUltraGridBind(grid1);

                //grid2
                _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PONO", "발주번호", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "POSEQNO", "발주순번", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "TMPINDATE", "가입고일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "TMPINGROUPNO", "발행그룹번호", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "BAL_CNT", "LOT수량", true, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "BAL_QTY", "수량", true, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "TEMP_CNT", "LOT수량", true, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "TEMP_QTY", "수량", true, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INSP_WA_CNT", "LOT수량", true, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INSP_WA_QTY", "수량", true, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "TOTINQTY_CNT", "LOT수량", true, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "TOTINQTY_QTY", "수량", true, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INSP_NG_CNT", "LOT수량", true, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INSP_NG_QTY", "수량", true, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Right, true, false);
                //string[] arrMerCol1 = { "BAL_CNT",      "BAL_QTY"      };
                string[] arrMerCol2 = { "TEMP_CNT", "TEMP_QTY" };
                string[] arrMerCol3 = { "INSP_WA_CNT", "INSP_WA_QTY" };
                string[] arrMerCol4 = { "INSP_NG_CNT", "INSP_NG_QTY" };
                string[] arrMerCol5 = { "TOTINQTY_CNT", "TOTINQTY_QTY" };

                //_GridUtil.GridHeaderMerge(grid2, "A", "발행", arrMerCol1, null);
                _GridUtil.GridHeaderMerge(grid2, "B", "가입고", arrMerCol2, null);
                _GridUtil.GridHeaderMerge(grid2, "C", "수입검사대기", arrMerCol3, null);
                _GridUtil.GridHeaderMerge(grid2, "D", "검사판정 불합격", arrMerCol4, null);
                _GridUtil.GridHeaderMerge(grid2, "E", "입고", arrMerCol5, null);
                _GridUtil.SetInitUltraGridBind(grid2);

                //grid3
                _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "LOTQTY", "수량", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "TMPINDATE", "가입고일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "INSPDATE", "수입검사일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "INSPRESULT", "판정결과", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "INDATE", "입고일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "LOTSTATUS", "LOT 상태", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                //grid3.Columns["LOTQTY"].Format = "#,##0";
                string[] arrMerCol6 = { "INSPDATE", "INSPRESULT" };
                _GridUtil.GridHeaderMerge(grid3, "A", "수입검사", arrMerCol6, null);
                _GridUtil.SetInitUltraGridBind(grid3);

                //grid4
                _GridUtil.InitializeGrid(grid4, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid4, "SAVEBUTTON", "삭제", true, GridColDataType_emu.Button, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "PONO", "발주번호", true, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "PODATE", "발주일", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid4, "SHIPNO", "출하번호", true, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid4, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "COST", "매입단가", true, GridColDataType_emu.Double, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "POQTY", "발주수량", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
                //_GridUtil.InitColumnUltraGrid(grid5, "PACKQTY", "출하수량", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid4, "INQTY", "입고수량", true, GridColDataType_emu.Double, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "BLNO", "BL번호", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "TOTALCOST", "매입금액", true, GridColDataType_emu.Double, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "FINISHFLAG", "계산서마감", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "MONEYDUEDATE", "지급예정일", true, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid4, "INCOMEDATE", "지급일", true, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.SetInitUltraGridBind(grid4);

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }

        protected override void SetSubData()
        {
            string sMethodText = subData["METHOD_TYPE"];

            if (sMethodText == "POP2")
            {
                bPop2 = true;
            }
        }

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid2);
            _GridUtil.Grid_Clear(grid3);
            _GridUtil.Grid_Clear(grid4);

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(this.cbo_PLANTCODE_H.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sItemName = txt_ITEMNAME_H.Text.Trim();
                string sCustCode = txt_CUSTCODE_H.Text.Trim();
                string sCustName = txt_CUSTNAME_H.Text.Trim();
                string sPoNo = txt_PONO_H.Text.Trim();
                string sFinishFlag = DBHelper.nvlString(cbo_FINISHFLAG_H.Value);


                rtnDtTemp = helper.FillTable("USP_AP0127_S1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_CUSTNAME", sCustName, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_FINISHFLAG", sFinishFlag, DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();

                rtnDtTemp2 = helper.FillTable("USP_AP0127_S2"
                            , CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input));

                grid4.DataSource = rtnDtTemp2;
                grid4.DataBinds();

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    string sFFlag = Convert.ToString(grid1.Rows[i].Cells["FINISHFLAG"].Value);

                    if (sFFlag == "F" || sFFlag == "I")
                    {
                        if (sFFlag == "F")
                            grid1.Rows[i].Cells["SAVEBUTTON"].Activation = Activation.NoEdit;
                        grid1.Rows[i].Cells["UNITBUTTON"].Activation = Activation.NoEdit;

                        grid1.Rows[i].Activation = Activation.NoEdit;
                    }
                    else
                    {
                        grid1.Rows[i].Cells["SAVEBUTTON"].Activation = Activation.AllowEdit;
                        grid1.Rows[i].Cells["UNITBUTTON"].Activation = Activation.AllowEdit;
                        grid1.Rows[i].Activation = Activation.AllowEdit;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
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

                if (grid1.IsActivate || grid2.IsActivate || grid3.IsActivate)
                {
                    //if (grid1.ActiveRow == null)
                    //{
                    //    this.ShowDialog(Common.getLangText("편성할 수주번호을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    //    return;
                    //}
                    string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    string sPoNo = DBHelper.nvlString(grid1.ActiveRow.Cells["PONO"].Value);
                    string sPoDate = DBHelper.nvlString(grid1.ActiveRow.Cells["PODATE"].Value);
                    string sPoQty = DBHelper.nvlString(grid1.ActiveRow.Cells["POQTY"].Value);
                    string sInQty = DBHelper.nvlString(grid1.ActiveRow.Cells["INQTY"].Value);
                    string sUnitCost = DBHelper.nvlString(grid1.ActiveRow.Cells["UNITCOST"].Value);

                    //string sItemName = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
                    //string sUnitCode = DBHelper.nvlString(grid1.ActiveRow.Cells["UNITCODE"].Value);
                    //string sPackQty = DBHelper.nvlString(grid2.ActiveRow.Cells["SHIPQTY"].Value);
                    //string sContractNo = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
                    //string sContractQty = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTQTY"].Value);
                    //string sDueDate = DBHelper.nvlString(grid1.ActiveRow.Cells["DUEDATE"].Value);
                    //string sShipNo = DBHelper.nvlString(grid2.ActiveRow.Cells["SHIPNO"].Value);
                    //string sMaskID = DBHelper.nvlString(grid1.ActiveRow.Cells["MASKID"].Value);

                    this.grid4.InsertRow();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid4.ActiveRow.Cells["PONO"].Value = sPoNo;
                    this.grid4.ActiveRow.Cells["PODATE"].Value = sPoDate;
                    this.grid4.ActiveRow.Cells["ITEMCODE"].Value = sItemCode;
                    this.grid4.ActiveRow.Cells["POQTY"].Value = sPoQty;
                    this.grid4.ActiveRow.Cells["INQTY"].Value = sInQty;
                    //this.grid5.ActiveRow.Cells["SHIPNO"].Value = sShipNo;
                    this.grid4.ActiveRow.Cells["MONEYDUEDATE"].Value = DateTime.Today.AddDays(30);
                    //this.grid5.ActiveRow.Cells["INCOMEDATE"].Value = "";

                    this.grid4.ActiveRow.Cells["COST"].Value = sUnitCost;
                    //this.grid5.ActiveRow.Cells["PONO"].Value = "";
                    this.grid4.ActiveRow.Cells["SAVEBUTTON"].Value = "삭제";
                    //this.grid4.ActiveRow.Cells["WORKCENTERNAME"].Value = "";
                    //this.grid4.ActiveRow.Cells["ORDERNO"].Value = "";
                    //this.grid4.ActiveRow.Cells["ORDERDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                    //this.grid4.ActiveRow.Cells["OPCODE"].Value = DBHelper.nvlString(grid1.ActiveRow.Cells["OPCODE"].Value);
                    //this.grid4.ActiveRow.Cells["ORDERQTY"].Value = "1";
                    //this.grid4.ActiveRow.Cells["LOTQTY"].Value = "";
                    //this.grid4.ActiveRow.Cells["FRAMEID"].Value = sFrameID;
                    //this.grid4.ActiveRow.Cells["MASKID"].Value = sMaskID;
                    //this.grid5.ActiveRow.Cells["CONTRACTNO"].Activation = Activation.NoEdit;
                    //this.grid5.ActiveRow.Cells["SHIPNO"].Activation = Activation.NoEdit;
                    this.grid4.ActiveRow.Cells["ITEMCODE"].Activation = Activation.NoEdit;
                    //this.grid5.ActiveRow.Cells["PACKQTY"].Activation = Activation.NoEdit;
                    this.grid4.ActiveRow.Cells["TOTALCOST"].Activation = Activation.NoEdit;
                    this.grid4.ActiveRow.Cells["COST"].Activation = Activation.AllowEdit;
                    this.grid4.ActiveRow.Cells["PONO"].Activation = Activation.NoEdit;
                    this.grid4.ActiveRow.Cells["SAVEBUTTON"].Activation = Activation.NoEdit;
                    //grid4.ActiveRow.Cells["CONTRACTNO"].Activation = Activation.NoEdit;
                    //grid4.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;
                    //grid4.ActiveRow.Cells["ORDERNO"].Activation = Activation.NoEdit;
                    //grid4.ActiveRow.Cells["LOTQTY"].Activation = Activation.NoEdit;
                    //grid4.ActiveRow.Cells["OPCODE"].Activation = Activation.NoEdit;
                    //UltraGridUtil.ActivationAllowEdit(this.grid4, "WORKCENTERCODE");
                    //UltraGridUtil.ActivationAllowEdit(this.grid4, "ITEMCODE2");
                    //UltraGridUtil.ActivationAllowEdit(this.grid4, "ORDERQTY");
                    //UltraGridUtil.ActivationAllowEdit(this.grid4, "FRAMEID");
                    //UltraGridUtil.ActivationAllowEdit(this.grid4, "MASKID");
                    //UltraGridUtil.ActivationAllowEdit(this.grid4, "ORDERDATE");
                    //this.grid4.ActiveRow.Cells["REMARK"].Activation = splitContainer2.Panel2Collapsed ? Activation.AllowEdit : Activation.NoEdit;
                    //this.grid4.ActiveRow.Cells["WORKCENTERCODE"].Value = sDef_WC;
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

            //string sPlantCode = string.Empty;
            //string sOrderNO = string.Empty;
            //string sContractNo = string.Empty;
            string sPoNo = string.Empty;
            string sPoDate = string.Empty;
            string sShipNo = string.Empty;
            string sItemCode = string.Empty;
            string sBlno = string.Empty;
            string sPoQty = string.Empty;
            string sInQty = string.Empty;
            string sCost = string.Empty;

            string sMoneyDueDate = string.Empty;
            string sIncomeDate = string.Empty;
            string sFinshFlag = string.Empty;
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
                            sPoQty = "0";

                            sPoNo = DBHelper.nvlString(drChange["PONO"]);
                            sPoDate = DBHelper.nvlString(drChange["PODATE"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);
                            sBlno = DBHelper.nvlString(drChange["BLNO"]);
                            sCost = DBHelper.nvlString(drChange["COST"]);
                            sPoQty = DBHelper.nvlString(drChange["POQTY"]);
                            sInQty = DBHelper.nvlString(drChange["INQTY"]);
                            sFinshFlag = DBHelper.nvlString(drChange["FINISHFLAG"]);

                            sMoneyDueDate = DBHelper.nvlString(drChange["MONEYDUEDATE"]);
                            sIncomeDate = DBHelper.nvlString(drChange["INCOMEDATE"]);

                            if (drChange.RowState == DataRowState.Deleted || sInQty == "0")
                            {
                                sPoQty = "";
                            }

                            //sPlantCode = DBHelper.nvlString(drChange["PLANTCODE"]);
                            //sContractNo = DBHelper.nvlString(drChange["CONTRACTNO"]);
                            //sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);
                            //sItemName = DBHelper.nvlString(drChange["ITEMNAME"]);
                            //sPackQty = DBHelper.nvlString(drChange["PACKQTY"]);
                            //sShipNo = DBHelper.nvlString(drChange["SHIPNO"]);

                            //if (sWCCD == "")
                            //{
                            //    throw new Exception("작업장코드가 없는 항목이 있습니다.");
                            //}

                            helper.ExecuteNoneQuery("USP_AP0127_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", "10", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PODATE", string.Format("{0:yyyy-MM-dd}", sPoDate), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_POQTY", sPoQty, DbType.Decimal, ParameterDirection.Input)
                            , helper.CreateParameter("AS_INQTY", sInQty, DbType.Decimal, ParameterDirection.Input)
                            , helper.CreateParameter("AF_COST", sCost, DbType.Decimal, ParameterDirection.Input)
                            , helper.CreateParameter("AS_BLNO", sBlno, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_FINISHFLAG", sFinshFlag, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MONEYDUEDATE", string.Format("{0:yyyy-MM-dd}", sMoneyDueDate).Substring(0, 10), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_INCOMEDATE", string.Format("{0:yyyy-MM-dd}", sIncomeDate), DbType.String, ParameterDirection.Input)
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

        private void grid1_ClickCell(object sender, EventArgs e)
        {

            if (grid1.Rows.Count <= 0)
                return;

            _GridUtil.Grid_Clear(grid2);
            _GridUtil.Grid_Clear(grid3);


            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sPoNo = DBHelper.nvlString(grid1.ActiveRow.Cells["PONO"].Value);

                int iPoSeqNo = DBHelper.nvlInt(grid1.ActiveRow.Cells["POSEQNO"].Value);

                rtnDtTemp = helper.FillTable("USP_MM0000_S2"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AI_POSEQNO", iPoSeqNo, DbType.String, ParameterDirection.Input));


                grid2.DataSource = rtnDtTemp;
                grid2.DataBinds(rtnDtTemp);

                string sPlantCode2 = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sPoNo2 = DBHelper.nvlString(grid1.ActiveRow.Cells["PONO"].Value);
                //string sPreInGroupno = DBHelper.nvlString(grid2.ActiveRow.Cells["TMPINGROUPNO"].Value);

                //string sInspFlag     = DBHelper.nvlString(grid1.ActiveRow.Cells["INSPFLAG"].Value);               

                int iPoSeqNo2 = DBHelper.nvlInt(grid1.ActiveRow.Cells["POSEQNO"].Value);

                rtnDtTemp2 = helper.FillTable("USP_MM0000_S3"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode2, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_PONO", sPoNo2, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AI_POSEQNO", iPoSeqNo2, DbType.String, ParameterDirection.Input));

                grid3.DataSource = rtnDtTemp2;
                grid3.DataBinds(rtnDtTemp2);

                //string sPlantCode3 = Convert.ToString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value).Trim();
                //string sLotNo = Convert.ToString(this.grid3.ActiveRow.Cells["LOTNO"].Value);
                //string sItemCode = Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value).Trim();

                //if (sPlantCode3 == string.Empty || sLotNo == string.Empty)
                //    return;

                //dtGrid2 = helper.FillTable("USP_MM0002_S2", CommandType.StoredProcedure
                //       , helper.CreateParameter("AS_PLANTCODE", sPlantCode3, DbType.String, ParameterDirection.Input)
                //       , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                //       //, helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                //       );

                //grid4.DataSource = dtGrid2;
                //grid4.DataBinds(dtGrid2);
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        //private void grid2_ClickCell(object sender, EventArgs e)
        //{
        //    _GridUtil.Grid_Clear(grid3);

        //    DBHelper helper = new DBHelper(false);

        //    try
        //    {
        //        string sPlantCode    = DBHelper.nvlString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
        //        string sPoNo         = DBHelper.nvlString(grid2.ActiveRow.Cells["PONO"].Value);
        //        string sPreInGroupno = DBHelper.nvlString(grid2.ActiveRow.Cells["TMPINGROUPNO"].Value);

        //        //string sInspFlag     = DBHelper.nvlString(grid1.ActiveRow.Cells["INSPFLAG"].Value);               

        //        int iPoSeqNo = DBHelper.nvlInt(grid2.ActiveRow.Cells["POSEQNO"].Value);

        //        rtnDtTemp = helper.FillTable("USP_MM0000_S3"
        //                                    , CommandType.StoredProcedure
        //                                    , helper.CreateParameter("AS_PLANTCODE",    sPlantCode,    DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("AS_PONO",         sPoNo,         DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("AI_POSEQNO",      iPoSeqNo,      DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("AS_TMPINGROUPNO", sPreInGroupno, DbType.String, ParameterDirection.Input));


        //        if (rtnDtTemp.Rows.Count > 0)
        //        {
        //            //if (sInspFlag == "I")
        //            //{
        //            //    grid3.Columns["INSPRESULT"].Hidden = false;
        //            //    grid3.Columns["INSPDATE"].Hidden = false;

        //            //}
        //            //else
        //            //{
        //            //    grid3.Columns["INSPRESULT"].Hidden = true;
        //            //    grid3.Columns["INSPDATE"].Hidden = true;

        //            //    string[] arrMerCol7 = { "" };

        //            //    _GridUtil.GridHeaderMerge(grid3, "", "", arrMerCol7, null);
        //            //    //grid1.DisplayLayout.header
        //            //}

        //            grid3.DataSource = rtnDtTemp;
        //            grid3.DataBinds();
        //        }                 
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
        //    }
        //    finally
        //    {
        //        this.ClosePrgFormNew();
        //        helper.Close();
        //    }
        //}

        private void grid2_ClickCell(object sender, EventArgs e)
        {
            _GridUtil.Grid_Clear(grid3);

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sPoNo = DBHelper.nvlString(grid1.ActiveRow.Cells["PONO"].Value);
                //string sPreInGroupno = DBHelper.nvlString(grid2.ActiveRow.Cells["TMPINGROUPNO"].Value);

                //string sInspFlag     = DBHelper.nvlString(grid1.ActiveRow.Cells["INSPFLAG"].Value);               

                int iPoSeqNo = DBHelper.nvlInt(grid1.ActiveRow.Cells["POSEQNO"].Value);

                rtnDtTemp2 = helper.FillTable("USP_MM0000_S3"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AI_POSEQNO", iPoSeqNo, DbType.String, ParameterDirection.Input));
                //, helper.CreateParameter("AS_TMPINGROUPNO", sPreInGroupno, DbType.String, ParameterDirection.Input));

                //if (sInspFlag == "I")
                //{
                //    grid3.Columns["INSPRESULT"].Hidden = false;
                //    grid3.Columns["INSPDATE"].Hidden = false;

                //}
                //else
                //{
                //    grid3.Columns["INSPRESULT"].Hidden = true;
                //    grid3.Columns["INSPDATE"].Hidden = true;

                //    string[] arrMerCol7 = { "" };

                //    _GridUtil.GridHeaderMerge(grid3, "", "", arrMerCol7, null);
                //    //grid1.DisplayLayout.header
                //}

                grid3.DataSource = rtnDtTemp2;
                grid3.DataBinds(rtnDtTemp2);

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        private void grid4_ClickCellButton(object sender, CellEventArgs e)
        {
            //string sFinishFlag = string.Empty;
            string sPoNo = string.Empty;
            string sItemCode = string.Empty;

            try
            {
                //sFinishFlag = Convert.ToString(e.Cell.Row.Cells["FINISHFLAG"].Value);

                if (e.Cell.Column.ToString() == "SAVEBUTTON")
                {
                    //if (sFinishFlag == "D" || sFinishFlag == "I")
                    //{
                    sPoNo = Convert.ToString(e.Cell.Row.Cells["PONO"].Value);

                    DataTable dtTarget = ((DataTable)this.grid4.DataSource);
                    DataRow[] drRow = dtTarget.Select("PONO = '" + sPoNo + "'");

                    //if (bPop2)
                    //{
                    AP0127_POP ap0127_pop = new AP0127_POP(drRow[0], sPoNo);
                    ap0127_pop.ShowDialog();
                    //}
                    //else
                    //{
                    //    MM0000_POP mm0000_pop = new MM0000_POP(drRow[0]);
                    //    mm0000_pop.ShowDialog();
                    //}

                    this.DoInquire();
                    //}
                }

                //string strQty = string.Empty;
                //if (e.Cell.Column.ToString() == "UNITBUTTON")
                //{
                //    if (sFinishFlag == "")
                //    {
                //        sItemCode = Convert.ToString(e.Cell.Row.Cells["ITEMCODE"].Value);
                //        DataTable dtTarget = ((DataTable)this.grid1.DataSource);
                //        DataRow[] drRow = dtTarget.Select("ITEMCODE = '" + sItemCode + "'");

                //        if (string.IsNullOrEmpty(sItemCode))
                //        {
                //            this.ShowDialog(Common.getLangText("품목을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                //            return;
                //        }

                //        MM0000_POP_UNIT mm0000_pop_unit = new MM0000_POP_UNIT(drRow[0]);
                //        mm0000_pop_unit.ShowDialog();
                //        strQty = mm0000_pop_unit.m_strQty;
                //        e.Cell.Row.Cells["POQTY"].Value = strQty;
                //    }
                //}
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
            }
        }


        //private void btn_click_event(object sender, EventArgs e)
        //{
        //    Button buffer = (Button)sender;
        //    btnTag = buffer.Tag.ToString();

        //    DBHelper helper = new DBHelper("", true);

        //    switch (btnTag)
        //    {
        //        case "I2_C1": // 출하취소
        //        case "I2_R1": // 복구
        //        case "I2_D1": // 폐기
        //            try
        //            {
        //                SHIPNO = grid2.ActiveRow.Cells["SHIPNO"].Text;
        //                helper.ExecuteNoneQuery("USP_WM0140_I2", CommandType.StoredProcedure
        //                    , helper.CreateParameter("PCODE", btnTag.Replace("I2_", ""), DbType.String, ParameterDirection.Input)
        //                    , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
        //                    , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
        //                    , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

        //                if (helper.RSCODE == "S")
        //                {
        //                    helper.Commit();

        //                }
        //                else
        //                {
        //                    throw new Exception(helper.RSMSG);
        //                }
        //                DoInquire();
        //            }
        //            catch (Exception ex)
        //            {
        //                helper.Rollback();
        //                MessageBox.Show(ex.ToString());

        //            }
        //            break;

        //        case "I1_I1": // 출하
        //        case "I1_D1": // 폐기


        //            //if (btnTag == "I1_I1" && txtSHIPNO.Text.Length == 0)
        //            //{
        //            //    this.ShowDialog("처리번호 미입력", Forms.DialogForm.DialogType.OK);
        //            //    return;
        //            //}
        //            //else
        //            //{
        //            //}


        //            string sBoxList = "";
        //            string sTag = btnTag.Replace("I1_", "");
        //            int iChk = 0;

        //            for (int i = 0; i < grid4.Rows.Count;i++)
        //            {
        //                if (DBHelper.nvlString(grid4.Rows[i].Cells["CHK"].Value) == "1")
        //                {
        //                    iChk++;
        //                }
        //            }

        //            if ( iChk > 0 )
        //            {
        //                string sMes = "";

        //                if (sTag == "I1")
        //                {
        //                    //if (txtSHIPNO.Text.Trim() == "")
        //                    //{
        //                    //    this.ShowDialog("출하번호가 없습니다.", Forms.DialogForm.DialogType.OK);
        //                    //    return;
        //                    //}

        //                    //if (txtCONTRACTNO.Text.Trim() == "")
        //                    //{
        //                    //    this.ShowDialog("선택한 수주번호가 없습니다.", Forms.DialogForm.DialogType.OK);
        //                    //    return;
        //                    //}

        //                    sMes = iChk.ToString() + "개의 박스를 출고 처리하겠습니까?";
        //                }
        //                else
        //                {
        //                    sMes = iChk.ToString() + "개의 박스를 폐기 처리하겠습니까?";
        //                }

        //                if (this.ShowDialog(Common.getLangText(sMes, "MSG")) == System.Windows.Forms.DialogResult.Cancel)
        //                {
        //                    CancelProcess = true;
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                this.ShowDialog("선택된 박스가 없습니다.", Forms.DialogForm.DialogType.OK);
        //                return;
        //            }

        //            try
        //            {
        //                if (sTag == "I1")
        //                {
        //                    for (int i = 0; i < grid4.Rows.Count; i++)
        //                    {
        //                        string sBox = "";

        //                        if (DBHelper.nvlString(grid4.Rows[i].Cells["CHK"].Value) == "1")
        //                        {
        //                            sBox = DBHelper.nvlString(grid4.Rows[i].Cells["PACKNO"].Value);

        //                            if (sBoxList.Length + sBox.Length + 3 >= 4000)
        //                            {
        //                                helper.ExecuteNoneQuery("USP_WM0140_I3", CommandType.StoredProcedure
        //                                        , helper.CreateParameter("PCODE", "I0", DbType.String, ParameterDirection.Input)
        //                                        , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
        //                                        , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
        //                                        , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
        //                                        , helper.CreateParameter("AS_SHIPDATE", SHIPDATE, DbType.String, ParameterDirection.Input)
        //                                        , helper.CreateParameter("AS_BOXLIST", sBoxList, DbType.String, ParameterDirection.Input)
        //                                        , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

        //                                if (helper.RSCODE == "E")
        //                                {
        //                                    throw new Exception(helper.RSMSG);
        //                                }

        //                                if (helper.RSMSG != "")
        //                                {
        //                                    string[] sArr = helper.RSMSG.Split(',');
        //                                    CONTRACTNO = sArr[0];
        //                                    SHIPNO = sArr[1];
        //                                }

        //                                helper.ExecuteNoneQuery("USP_WM0140_I3", CommandType.StoredProcedure
        //                                    , helper.CreateParameter("PCODE", btnTag.Replace("I1_", ""), DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("AS_SHIPDATE", SHIPDATE, DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("AS_BOXLIST", sBoxList, DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

        //                                if (helper.RSCODE == "E")
        //                                {
        //                                    throw new Exception(helper.RSMSG);
        //                                }

        //                                sBoxList = "";
        //                            }

        //                            if (sBoxList == "")
        //                            {
        //                                sBoxList = sBox;
        //                            }
        //                            else
        //                            {
        //                                sBoxList += "|" + sBox;
        //                            }
        //                        }
        //                    }

        //                    if (sBoxList != "")
        //                    {
        //                        helper.ExecuteNoneQuery("USP_WM0140_I3", CommandType.StoredProcedure
        //                            , helper.CreateParameter("PCODE", "I0", DbType.String, ParameterDirection.Input)
        //                            , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
        //                            , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
        //                            , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
        //                            , helper.CreateParameter("AS_SHIPDATE", SHIPDATE, DbType.String, ParameterDirection.Input)
        //                            , helper.CreateParameter("AS_BOXLIST", sBoxList, DbType.String, ParameterDirection.Input)
        //                            , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

        //                        if (helper.RSCODE == "E")
        //                        {
        //                            throw new Exception(helper.RSMSG);
        //                        }

        //                        if (helper.RSMSG != "")
        //                        {
        //                            string[] sArr = helper.RSMSG.Split(',');
        //                            CONTRACTNO = sArr[0];
        //                            SHIPNO = sArr[1];
        //                        }

        //                        helper.ExecuteNoneQuery("USP_WM0140_I3", CommandType.StoredProcedure
        //                            , helper.CreateParameter("PCODE", btnTag.Replace("I1_", ""), DbType.String, ParameterDirection.Input)
        //                            , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
        //                            , helper.CreateParameter("AS_CONTRACTNO", CONTRACTNO, DbType.String, ParameterDirection.Input)
        //                            , helper.CreateParameter("AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input)
        //                            , helper.CreateParameter("AS_SHIPDATE", SHIPDATE, DbType.String, ParameterDirection.Input)
        //                            , helper.CreateParameter("AS_BOXLIST", sBoxList, DbType.String, ParameterDirection.Input)
        //                            , helper.CreateParameter("AS_MAKER", UserID, DbType.String, ParameterDirection.Input));

        //                        if (helper.RSCODE == "S")
        //                        {
        //                            helper.Commit();

        //                            DoInquire();
        //                        }
        //                        else
        //                        {
        //                            throw new Exception(helper.RSMSG);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        helper.Commit();

        //                        Grid_data(grid4);
        //                    }
        //                }
        //                else
        //                {
        //                    // 폐기 처리일 경우 처리
        //                    helper.Commit();

        //                    Grid_data(grid4);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                helper.Rollback();
        //                MessageBox.Show(ex.ToString());

        //            }
        //            break;
        //    }
        //}
        #endregion



        private void grid5_ClickCellButton(object sender, CellEventArgs e)
        {
            //string sFinishFlag = string.Empty;
            string sShipNo = string.Empty;
            string sItemCode = string.Empty;

            try
            {
                //sFinishFlag = Convert.ToString(e.Cell.Row.Cells["FINISHFLAG"].Value);

                if (e.Cell.Column.ToString() == "SAVEBUTTON")
                {
                    //if (sFinishFlag == "D" || sFinishFlag == "I")
                    //{
                    sShipNo = Convert.ToString(e.Cell.Row.Cells["SHIPNO"].Value);

                    DataTable dtTarget = ((DataTable)this.grid4.DataSource);
                    DataRow[] drRow = dtTarget.Select("SHIPNO = '" + sShipNo + "'");

                    //if (bPop2)
                    //{
                    AP0127_POP AP0127_pop = new AP0127_POP(drRow[0], sShipNo);
                    AP0127_pop.ShowDialog();
                    //}
                    //else
                    //{
                    //    MM0000_POP mm0000_pop = new MM0000_POP(drRow[0]);
                    //    mm0000_pop.ShowDialog();
                    //}

                    this.DoInquire();
                    //}
                }

                //string strQty = string.Empty;
                //if (e.Cell.Column.ToString() == "UNITBUTTON")
                //{
                //    if (sFinishFlag == "")
                //    {
                //        sItemCode = Convert.ToString(e.Cell.Row.Cells["ITEMCODE"].Value);
                //        DataTable dtTarget = ((DataTable)this.grid1.DataSource);
                //        DataRow[] drRow = dtTarget.Select("ITEMCODE = '" + sItemCode + "'");

                //        if (string.IsNullOrEmpty(sItemCode))
                //        {
                //            this.ShowDialog(Common.getLangText("품목을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                //            return;
                //        }

                //        MM0000_POP_UNIT mm0000_pop_unit = new MM0000_POP_UNIT(drRow[0]);
                //        mm0000_pop_unit.ShowDialog();
                //        strQty = mm0000_pop_unit.m_strQty;
                //        e.Cell.Row.Cells["POQTY"].Value = strQty;
                //    }
                //}
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

#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0003
//   Form Name    : 발주정보 등록
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-19
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : 발주정보 관리 및 식별표 발행
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM0003 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        bool bPop2 = false;
        #endregion

        #region < CONSTRUCTOR >
        public MM0003()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM EVENT >

        #region Init
        private void MM0003_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            DBHelper helper = new DBHelper(true);

            bool Colvisible_DS = false;
            if (helper.DBConnect.Database.ToString() == "P2001")
            {
                Colvisible_DS = true;
            }

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "SAVEBUTTON", "가입고", true, GridColDataType_emu.Button, 70, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "POSEQNO", "발주순번", true, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PODATE", "발주일", true, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANINDATE", "입고예정일", true, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true);

            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE2", "거래처2", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, Colvisible_DS, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME2", "거래처명2", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, Colvisible_DS, true);

            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목유형", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPENAME", "품목유형", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPFLAG", "검사구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "POQTY", "발주량(ⓐ)", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCOST", "매입단가", true, GridColDataType_emu.Float, 90, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, true);

            //2020-07-07 이후 개발 예정
            _GridUtil.InitColumnUltraGrid(grid1, "UNITBUTTON", "단위량계산", true, GridColDataType_emu.Button, 90, 100, Infragistics.Win.HAlign.Center, Colvisible_DS, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MATERIALGRADE", "재질", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMSPEC", "규격", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INQTY", "입고량", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TMPINQTY", "가입고량(ⓑ)", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REINQTY", "입고잔량\r\n(ⓐ-ⓑ)", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, true);

            //2021-06-15 최문석 금액부분 추가
            _GridUtil.InitColumnUltraGrid(grid1, "FINISHFLAG", "진행여부", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime24, 160, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime24, 160, 100, Infragistics.Win.HAlign.Center, true, false);

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

            ////grid2.Columns["BAL_CNT"].Format = "#,##0";
            ////grid2.Columns["BAL_QTY"].Format = "#,##0";
            //grid2.Columns["TEMP_CNT"].Format = "#,##0";
            //grid2.Columns["TEMP_QTY"].Format = "#,##0";
            //grid2.Columns["INSP_WA_CNT"].Format = "#,##0";
            //grid2.Columns["INSP_WA_QTY"].Format = "#,##0";
            //grid2.Columns["INSP_NG_CNT"].Format = "#,##0";
            //grid2.Columns["INSP_NG_QTY"].Format = "#,##0";
            //grid2.Columns["TOTINQTY_CNT"].Format = "#,##0";
            //grid2.Columns["TOTINQTY_QTY"].Format = "#,##0";

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

            #endregion

            #region < COMBOBOX SETTING >

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

            //rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE");
            //WIZ.Common.FillComboboxMaster(this.cbo_FINISHFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region < POP-UP SETTING >

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
                PopUp_Common.SetPop(new object[] { grid1, "PLANTCODE", "ITEMCODE", "ITEMNAME", "CUSTCODE", "CUSTNAME" }, "MM0003_POP", new object[] { grid1, "CUSTCODE", "CUSTNAME", "ITEMCODE", "ITEMNAME" });
            }

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-5);
            cbo_ENDDATE_H.Value = DateTime.Now;

            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            #endregion
        }
        #endregion

        #region 보조 데이터 확인
        protected override void SetSubData()
        {
            string sMethodText = subData["METHOD_TYPE"];

            if (sMethodText == "POP2")
            {
                bPop2 = true;
            }
        }
        #endregion

        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid2);
            _GridUtil.Grid_Clear(grid3);

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


                rtnDtTemp = helper.FillTable("USP_MM0000_S10"
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

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();

                grid1.InsertRow();

                grid1.ActiveRow.Cells["PLANTCODE"].Value = Convert.ToString(this.cbo_PLANTCODE_H.Value);
                grid1.ActiveRow.Cells["PODATE"].Value = DateTime.Now;
                grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
                grid1.ActiveRow.Cells["UNITBUTTON"].Value = "단위량계산";

                grid1.ActiveRow.Cells["SAVEBUTTON"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["PONO"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["POSEQNO"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MATERIALGRADE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["ITEMSPEC"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["ITEMTYPE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["ITEMTYPENAME"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["TMPINQTY"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["INQTY"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["REINQTY"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["FINISHFLAG"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            if (grid1.ActiveRow == null)
                return;

            string sFinishFlag = Convert.ToString(grid1.ActiveRow.Cells["FINISHFLAG"].Value);

            if (sFinishFlag != "D" && sFinishFlag != string.Empty)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(Common.getLangText("발주정보 상태가 대기가 아닙니다. 삭제할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            this.grid1.DeleteRow();
            _GridUtil.Grid_Clear(grid2);
            _GridUtil.Grid_Clear(grid3);
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            rtnDtTemp = grid1.chkChange();
            if (rtnDtTemp == null)
                return;

            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoSave();


                string ssub = subData["RELCODE1"];

                string sPoDate = string.Empty;
                string sPlanInDate = string.Empty;
                string sFinishFlag = string.Empty;

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PLANTCODE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("사업장을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow["PODATE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("발주일자를 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow["PLANINDATE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("입고예정일을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (drRow["ITEMCODE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("품목을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow["CUSTCODE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("거래처를 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow["POQTY"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("발주수량을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (drRow["ITEMTYPE"].ToString().Trim() == "1" && drRow["ITEMTYPE"].ToString().Trim() == "2")
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("완제품 및 반제품은 발주정보를 등록 할수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                    }
                }

                this.ClosePrgFormNew();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            sFinishFlag = DBHelper.nvlString(drRow["FINISHFLAG"]);

                            if (sFinishFlag != "D")
                            {
                                this.ClosePrgFormNew();
                                throw new Exception(Common.getLangText("발주정보 상태가 대기가 아닙니다. 삭제 할 수 없습니다.", "MSG"));
                            }

                            helper.ExecuteNoneQuery("USP_MM0000_D1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PONO", DBHelper.nvlString(drRow["PONO"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AI_POSEQNO", DBHelper.nvlInt(drRow["POSEQNO"]), DbType.Int32, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            sPoDate = DBHelper.nvlString(drRow["PODATE"]).Substring(0, 10);
                            sPlanInDate = DBHelper.nvlString(drRow["PLANINDATE"]).Substring(0, 10);

                            string sValue = "";

                            if (ssub == "M_CURRECNY")
                            {
                                sValue = DBHelper.nvlString(drRow["CURRENCY"]);
                            }

                            helper.ExecuteNoneQuery("USP_MM0000_I1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PODATE", sPoDate, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PLANINDATE", sPlanInDate, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_CUSTCODE", DBHelper.nvlString(drRow["CUSTCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_CUSTCODE2", DBHelper.nvlString(drRow["CUSTCODE2"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_POQTY", DBHelper.nvlDouble(drRow["POQTY"]), DbType.Double, ParameterDirection.Input)
                                                   // 2021-06-15 최문석 금액부분 추가
                                                   , helper.CreateParameter("AS_UNITCOST", DBHelper.nvlDouble(drRow["UNITCOST"]), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                   //, helper.CreateParameter("AS_COST",         sValue,                                 DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            sFinishFlag = DBHelper.nvlString(drRow["FINISHFLAG"]);

                            if (sFinishFlag != "D")
                            {
                                this.ClosePrgFormNew();
                                throw new Exception(Common.getLangText("발주정보 상태가 대기가 아닙니다. 수정 할 수 없습니다.", "MSG"));
                            }

                            sPoDate = DBHelper.nvlString(drRow["PODATE"]).Substring(0, 10);
                            sPlanInDate = DBHelper.nvlString(drRow["PLANINDATE"]).Substring(0, 10);

                            helper.ExecuteNoneQuery("USP_MM0000_U1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PONO", DBHelper.nvlString(drRow["PONO"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AI_POSEQNO", DBHelper.nvlInt(drRow["POSEQNO"]), DbType.Int32, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PODATE", sPoDate, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PLANINDATE", sPlanInDate, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_CUSTCODE", DBHelper.nvlString(drRow["CUSTCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_CUSTCODE2", DBHelper.nvlString(drRow["CUSTCODE2"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_POQTY", DBHelper.nvlDouble(drRow["POQTY"]), DbType.Double, ParameterDirection.Input)
                                                   // 2021-06-15 최문석 금액부분 추가
                                                   , helper.CreateParameter("AS_COST", DBHelper.nvlDouble(drRow["COST"]), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }

                this.ClosePrgFormNew();
                helper.Commit();
                DoInquire(); //성공적으로 수행되었을 경우에만 조회
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoImportExcel()
        {
            base.DoImportExcel();

            MM0000_EXCEL MM0003_excel = new MM0000_EXCEL();
            MM0003_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >
        private void grid1_ClickCell(object sender, EventArgs e)
        {
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

        private void grid1_ClickCellButton(object sender, CellEventArgs e)
        {
            string sFinishFlag = string.Empty;
            string sPoNo = string.Empty;
            string sItemCode = string.Empty;

            try
            {
                sFinishFlag = Convert.ToString(e.Cell.Row.Cells["FINISHFLAG"].Value);

                if (e.Cell.Column.ToString() == "SAVEBUTTON")
                {
                    if (sFinishFlag == "D" || sFinishFlag == "I")
                    {
                        sPoNo = Convert.ToString(e.Cell.Row.Cells["PONO"].Value);

                        DataTable dtTarget = ((DataTable)this.grid1.DataSource);
                        DataRow[] drRow = dtTarget.Select("PONO = '" + sPoNo + "'");

                        if (bPop2)
                        {
                            MM0000_POP2 MM0003_pop = new MM0000_POP2(drRow[0], subData["RELCODE1"] != "", subData["RELCODE2"]);
                            MM0003_pop.ShowDialog();
                        }
                        else
                        {
                            MM0000_POP MM0003_pop = new MM0000_POP(drRow[0]);
                            MM0003_pop.ShowDialog();
                        }

                        this.DoInquire();
                    }
                }

                string strQty = string.Empty;
                if (e.Cell.Column.ToString() == "UNITBUTTON")
                {
                    if (sFinishFlag == "")
                    {
                        sItemCode = Convert.ToString(e.Cell.Row.Cells["ITEMCODE"].Value);
                        DataTable dtTarget = ((DataTable)this.grid1.DataSource);
                        DataRow[] drRow = dtTarget.Select("ITEMCODE = '" + sItemCode + "'");

                        if (string.IsNullOrEmpty(sItemCode))
                        {
                            this.ShowDialog(Common.getLangText("품목을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        MM0000_POP_UNIT MM0003_pop_unit = new MM0000_POP_UNIT(drRow[0]);
                        MM0003_pop_unit.ShowDialog();
                        strQty = MM0003_pop_unit.m_strQty;
                        e.Cell.Row.Cells["POQTY"].Value = strQty;
                    }
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

        private void grid1_AfterCellListCloseUp(object sender, CellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString() == "PLANINDATE")
                {
                    //입고예정일 선택일 경우..
                    if (Convert.ToString(e.Cell.Row.Cells["PODATE"].Value) == string.Empty)
                    {
                        //발주일자가 없을 경우..현재 일자를 셋팅해준다.
                        e.Cell.Row.Cells["PODATE"].Value = DateTime.Now;
                    }
                    else
                    {
                        //발주일자가 있을 경우..
                        //발주일자보다 빠른일자를 선택하였을 경우..
                        string sPoOrderDate = Convert.ToString(e.Cell.Row.Cells["PODATE"].Text).Replace("-", "");
                        string sPlanInDate = e.Cell.Text.Replace("-", "");

                        if (sPlanInDate == "________") return;

                        if (Convert.ToInt32(sPoOrderDate) > Convert.ToInt32(sPlanInDate))
                        {
                            this.ShowDialog(Common.getLangText("발주일자 이전의 날짜를 선택 할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            e.Cell.Value = e.Cell.OriginalValue;

                        }
                    }
                }
                else if (e.Cell.Column.ToString() == "PODATE")
                {
                    //발주일자 선택일 경우..
                    if (Convert.ToString(e.Cell.Row.Cells["PLANINDATE"].Value) == string.Empty)
                        return;
                    else
                    {
                        string sPoOrderDate = e.Cell.Text.Replace("-", "");
                        string sPlanInDate = Convert.ToString(e.Cell.Row.Cells["PLANINDATE"].Text).Replace("-", "");

                        if (sPoOrderDate == "________") return;

                        if (Convert.ToInt32(sPoOrderDate) > Convert.ToInt32(sPlanInDate))
                        {
                            this.ShowDialog(Common.getLangText("입고예정일자 이후의 날짜를 선택 할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            e.Cell.Value = e.Cell.OriginalValue;
                            e.Cell.Row.Cells["PLANINDATE"].Value = e.Cell.Value;


                        }
                    }

                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.ToString() != "ITEMCODE")
            {
                return;
            }

            grid1.ActiveRow.Cells["ITEMTYPE"].Value = string.Empty;

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);

                rtnDtTemp = helper.FillTable("USP_MM0000_S4", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));


                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.ActiveRow.Cells["ITEMTYPE"].Value = rtnDtTemp.Rows[0]["ITEMTYPE"].ToString();
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
        #endregion

    }
}
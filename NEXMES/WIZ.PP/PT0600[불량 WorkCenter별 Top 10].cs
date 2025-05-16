#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  PT0600
//   Form Name    : 불량 작업장별 TOP10 정보 조회
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PT0600 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        DataTable rtnDtTemp = new DataTable();      // return DataTable 공통
        DataTable rtnDtTemp2 = new DataTable();     // return DataTable 공통
        PopUp_Biz _biz = new PopUp_Biz();           //비지니스 로직 객체 생성
        #endregion

        #region<CONSTRUCTOR>
        public PT0600()
        {
            InitializeComponent();
        }
        #endregion

        #region PT0600_Load
        private void PT0600_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPTYPE", "비가동", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Center, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPDESC", "비가동명", false, GridColDataType_emu.Integer, 110, 100, Infragistics.Win.HAlign.Center, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUSTIME", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Center, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPTYPE2", "비가동", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPDESC2", "비가동시간", false, GridColDataType_emu.Integer, 110, 100, Infragistics.Win.HAlign.Center, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUSTIME2", "비가동시간", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Center, true, false, "#,0", null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            string[] sMergeColumn = { "PlantCode1" };
            string[] sMergeColumn1 = { "STOPTYPE", "STOPDESC", "STATUSTIME" };
            string[] sMergeColumn2 = { "STOPTYPE2", "STOPDESC2", "STATUSTIME2" };
            string[] sHeadColumn = { "STOPTYPE", "STOPDESC", "STATUSTIME", "STOPTYPE2", "STOPDESC2", "STATUSTIME2" };


            //그리드 머지
            _GridUtil.GridHeaderMerge(grid1, "G1", "사업장(공장)1", sMergeColumn1, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G2", "사업장(공장)2", sMergeColumn2, sHeadColumn);

            //_GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, -1, -1);

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H1, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode1", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp2 = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H2, rtnDtTemp, rtnDtTemp2.Columns["CODE_ID"].ColumnName, rtnDtTemp2.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode2", rtnDtTemp2, "CODE_ID", "CODE_NAME");

            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;
            this.ultraChart2.EmptyChartText = string.Empty;
        }
        #endregion PT0600_Load

        #region DoBaseSum
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "STATUSTIME" });
        }
        #endregion

        #region 조회
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode1 = Convert.ToString(cboPlantCode_H1.Value);                                           // 사업장(공장)
                string sPlantCode2 = Convert.ToString(cboPlantCode_H2.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);
                string sWorkCenterCode = this.txtWorkCenterCode.Text.Trim();                                            // 작업장 코드
                string sOPCode = this.txtOPCode.Text.Trim();                                                            // 공정 코드
                string sLineCode = this.txtLineCode.Text.Trim();                                                        // 라인 코드

                grid1.DataSource = helper.FillTable("USP_PT0600_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode1", sPlantCode1, DbType.String, ParameterDirection.Input)            // 사업장(공장)    
                                                                   , helper.CreateParameter("PlantCode2", sPlantCode2, DbType.String, ParameterDirection.Input)            // 사업장(공장)    
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)              // 생산시작일자    
                                                                    , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input));                // 생산시작일자    

                grid1.DataBinds();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();

                    NumericSeries series = new NumericSeries();
                    series.Data.DataSource = rtnDtTemp;
                    series.Data.LabelColumn = "STOPDESC";
                    series.Data.ValueColumn = "STATUSTIME";
                    series.DataBind();

                    ultraChart1.Series.Add(series);
                    ultraChart1.Data.DataBind();
                }

                if (rtnDtTemp.Rows.Count > 0)
                {
                    ultraChart2.Series.Clear();

                    NumericSeries series = new NumericSeries();
                    series.Data.DataSource = rtnDtTemp;
                    series.Data.LabelColumn = "STOPDESC2";
                    series.Data.ValueColumn = "STATUSTIME2";
                    series.DataBind();

                    ultraChart2.Series.Add(series);
                    ultraChart2.Data.DataBind();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion 조회

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의
        #region 텍스트 박스에서 팝업창에서 값 가져오기

        private void Search_Pop_Item()
        {
            //임시로 사용할 데이터테이블 생성
            DataTable _DtTemp = new DataTable();
            string sitem_cd = "";// this.txtItemCode.Text.Trim();    // 품목
            string sitem_name = ""; // this.txtItemName.Text.Trim();  // 품목명
            string sPlantCode = DBHelper.nvlString(cboPlantCode_H1.Value.ToString());
            string sPlantCode2 = DBHelper.nvlString(cboPlantCode_H2.Value.ToString());
            // string splantcd = "820";
            string sitemtype = "";


            try
            {

                _DtTemp = _biz.SEL_BM0010(sPlantCode, sitem_cd, sitem_name, sitemtype, "");

                if (_DtTemp.Rows.Count > 1)
                {
                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    _DtTemp = pu.OpenPopUp("Item", new string[] { sPlantCode, sitemtype, sitem_cd, sitem_name }); // 품목 조회 POP-UP창 Parameter(비가동코드, 비가동명, 비가동그룹)

                    if (_DtTemp != null && _DtTemp.Rows.Count > 0)
                    {
                        //txtItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
                        //txtItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
                    }
                }
                else
                {
                    if (_DtTemp.Rows.Count == 1)
                    {
                        //txtItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
                        //txtItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
                    }
                    else
                    {
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                        // txtItemCode.Text = string.Empty;
                        //txtItemName.Text = string.Empty;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion
        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            //  this.txtItemName.Text = string.Empty;
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            //this.txtItemCode.Text = string.Empty;
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        #region 텍스트 박스에서 팝업창에서 값 가져오기
        //////////////////     
        private void Search_Pop_TBM0400()
        {

            string sPlantCode = string.Empty;             //사업장코드
            string sPlantCode2 = string.Empty;
            string sOPCode = txtOPCode.Text.Trim();       //공정코드
            string sOPName = txtOPName.Text.Trim();       //공정명 
            string sUseFlag = string.Empty;               //사용여부         


            if (this.cboPlantCode_H1.Value != null)
                sPlantCode = cboPlantCode_H1.Value.ToString() == "ALL" ? "" : cboPlantCode_H1.Value.ToString();         ///사업장코드 
                                                                                                                        ///
            if (this.cboPlantCode_H2.Value != null)
                sPlantCode2 = cboPlantCode_H2.Value.ToString() == "ALL" ? "" : cboPlantCode_H2.Value.ToString();         ///사업장코드 


            //            if (this.cboUseFlag_H.Value != null)
            //                sUseFlag = cboUseFlag_H.Value.ToString() == "ALL" ? "" : cboUseFlag_H.Value.ToString();                 // 사용여부

            sUseFlag = "";                 // 사용여부

            try
            {
                _biz.BM0040_POP(sPlantCode, sOPCode, sOPName, sUseFlag, "", txtOPName, "");

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion        //공정(작업장)
        private void txtOPCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtOPName.Text = string.Empty;
        }

        private void txtOPNAME_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtOPCode.Text = string.Empty;
        }

        private void txtOPCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0400();
            }
        }



        private void txtOPName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0400();
            }

        }

        #region 라인 (TBM0500) 팝업창에서 값 가져오기
        private void Search_Pop_TBM0500()
        {

            string sPlantCode = string.Empty;                             //사업장코드
            string sPlantCode2 = string.Empty;                             //사업장코드
            string sLineCode = txtLineCode.Text.Trim();                   //라인코드
            string sLineName = txtLineName.Text.Trim();                   //라인명명 
            string sUseFlag = string.Empty;                              //사용여부      


            if (this.cboPlantCode_H1.Value != null)
                sPlantCode = cboPlantCode_H1.Value.ToString() == "ALL" ? "" : cboPlantCode_H1.Value.ToString();         ///사업장코드 
                                                                                                                        ///
            if (this.cboPlantCode_H2.Value != null)
                sPlantCode2 = cboPlantCode_H2.Value.ToString() == "ALL" ? "" : cboPlantCode_H2.Value.ToString();         ///사업장코드 

            //            if (this.cboUseFlag_H.Value != null)
            //                sUseFlag = cboUseFlag_H.Value.ToString() == "ALL" ? "" : cboUseFlag_H.Value.ToString();                 // 사용여부

            sUseFlag = "";                 // 사용여부

            try
            {
                _biz.BM0050_POP(sPlantCode, "", sLineCode, sLineName, sUseFlag, txtLineCode, txtLineName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion 라인 (TBM0500) 팝업창에서 값 가져오기

        private void txtLineName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtLineCode.Text = string.Empty;
        }


        private void txtLineCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0500();
            }
        }

        private void txtLineCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0500();
        }



        private void txtLineName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0500();
            }
        }

        private void txtLineName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0500();
        }



        #region 작업장(TBM0600) 팝업창에서 값 가져오기
        //////////////////     
        private void Search_Pop_TBM0600()
        {

            string sPlantCode = string.Empty;                             //사업장코드
            string sPlantCode2 = string.Empty;                            //사업장코드
            string sOPCode = txtOPCode.Text.Trim();                       //공정코드
            string sOPName = txtOPName.Text.Trim();                       //공정명 
            string sLineCode = string.Empty;                              //라인코드
            string sWORKCENTERCODE = txtWorkCenterCode.Text.Trim();       //작업호기(라인)코드
            string sWorkCenterName = txtWorkCenterName.Text.Trim();       //작업호기(라인)명 
            string sUseFlag = string.Empty;                               //사용여부         


            if (this.cboPlantCode_H1.Value != null)
                sPlantCode = cboPlantCode_H1.Value.ToString() == "ALL" ? "" : cboPlantCode_H1.Value.ToString();         ///사업장코드 
                                                                                                                        ///
            if (this.cboPlantCode_H2.Value != null)
                sPlantCode2 = cboPlantCode_H2.Value.ToString() == "ALL" ? "" : cboPlantCode_H2.Value.ToString();         ///사업장코드 

            //if (this.cboUseFlag_H.Value != null)
            //    sUseFlag = cboUseFlag_H.Value.ToString() == "ALL" ? "" : cboUseFlag_H.Value.ToString();                 // 사용여부
            sUseFlag = "";                 // 사용여부: 전체


            try
            {
                _biz.BM0060_POP(sPlantCode, sWORKCENTERCODE, sWorkCenterName, sOPCode, sLineCode, sUseFlag, txtWorkCenterCode, txtWorkCenterName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion

        private void txtWorkCenterCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtWorkCenterName.Text = string.Empty;
        }

        private void txtWorkCenterName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtWorkCenterCode.Text = string.Empty;
        }

        private void txtWorkCenterCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0600();
            }
        }

        private void txtWorkCenterCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0600();
        }



        private void txtWorkCenterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0600();
            }
        }

        private void txtWorkCenterName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0600();
        }
        private void txtOPCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0400();
        }

        private void txtOPName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0400();
        }

        private void txtLineCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtLineName.Text = string.Empty;
        }

        #endregion
    }
}

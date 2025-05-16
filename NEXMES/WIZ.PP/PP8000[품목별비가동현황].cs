#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP8000
//   Form Name    : 퓸목별 비가동 현황
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using WIZ.PopUp;

#endregion

namespace WIZ.PP
{
    public partial class PP8000 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        string sPlantCode = string.Empty;
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        #endregion

        #region<CONSTRUCTOR>
        public PP8000()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();

            //            * TBM0400 : 공정(작업장) 
            //*          - 1 : OPCode, 2 : OPName, param[0] : PlantCode, param[1] : UseFlag
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0040", new object[] { cboPlantCode_H, "" });

            //            * TBM0600 : 작업라인
            //*          - 1 : WorkCenterCode, 2 : WorkCenterName, param[0] : PlantCode, param[1] : OPcode
            //*          , param[2] : LineCode, param[4] : UseFlag
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "BM0060", new object[] { txtWorkCenterCode, txt_ITEMCODE_H, "", "" });
        }
        #endregion

        #region<TOOL BAR AREA>
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);                                                   // 사업장(공장)
                string sStartDate = DBHelper.nvlDateTime(CboStartdate_H.Value).ToString("yyyy-MM-dd");                             // 생산시작일자
                string sEndDate = DBHelper.nvlDateTime(CboEnddate_H.Value).ToString("yyyy-MM-dd");                                 // 생산  끝일자
                string sWorkCenterCode = this.txtWorkCenterCode.Text.Trim();                                                       // 작업장 코드
                //string sOPCode = this.txtOPCode.Text.Trim();                                                                       // 공정 코드

                grid1.DataSource = helper.FillTable("USP_PP8000_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input));
                                                                   //, helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();


                if (grid1.Rows.Count > 0)
                {


                    ultraChart1.Series.Clear();
                    //ultraChart1.Visible = true;

                    NumericSeries series = new NumericSeries();
                    series.Data.DataSource = grid1.DataSource;
                    series.Data.LabelColumn = "ItemCode";
                    series.Data.ValueColumn = "StopAmt";
                    ultraChart1.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;
                    ultraChart1.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                    series.DataBind();
                    ultraChart1.Series.Add(series);
                    ultraChart1.Data.DataBind();

                }
                else
                {
                    ultraChart1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region 폼 로더
        private void PP8000_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StatusTime", "비가동시간(분)", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StopAmt", "비가동금액", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            sPlantCode = CModule.GetAppSetting("Site", "10");

            cboPlantCode_H.Value = sPlantCode;

            #endregion

            #region Grid MERGE

            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE

            this.ultraChart1.EmptyChartText = string.Empty;
        }
        #endregion

        //#region <METHOD AREA>
        //// Form에서 사용할 함수나 메소드를 정의
        //#region 텍스트 박스에서 팝업창에서 값 가져오기

        //private void Search_Pop_Item()
        //{
        //    string sitem_cd = "";// this.txtItemCode.Text.Trim();    // 품목
        //    string sitem_name = ""; // this.txtItemName.Text.Trim();  // 품목명
        //    string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value.ToString());
        //    // string splantcd = "820";
        //    string sitemtype = "";


        //    try
        //    {

        //        _DtTemp = _biz.SEL_TBM0100(sPlantCode, sitem_cd, sitem_name, sitemtype);

        //        if (_DtTemp.Rows.Count > 1)
        //        {
        //            // 품목 POP-UP 창 처리
        //            PopUpManager pu = new PopUpManager();
        //            _DtTemp = pu.OpenPopUp("Item", new string[] { sPlantCode, sitemtype, sitem_cd, sitem_name }); // 품목 조회 POP-UP창 Parameter(비가동코드, 비가동명, 비가동그룹)

        //            if (_DtTemp != null && _DtTemp.Rows.Count > 0)
        //            {
        //                //txtItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
        //                //txtItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
        //            }
        //        }
        //        else
        //        {
        //            if (_DtTemp.Rows.Count == 1)
        //            {
        //                //txtItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
        //                //txtItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
        //            }
        //            else
        //            {
        //                MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
        //                // txtItemCode.Text = string.Empty;
        //                //txtItemName.Text = string.Empty;
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR", ex.Message);
        //    }

        //}
        //#endregion
        //private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //  this.txtItemName.Text = string.Empty;
        //}

        //private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //}

        //private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //this.txtItemCode.Text = string.Empty;
        //}

        //private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //}

        //#region 텍스트 박스에서 팝업창에서 값 가져오기
        ////////////////////     
        //private void Search_Pop_TBM0400()
        //{

        //    string sPlantCode = string.Empty;             //사업장코드
        //    string sOPCode = txtOPCode.Text.Trim();       //공정코드
        //    string sOPName = txtOPName.Text.Trim();       //공정명 
        //    string sUseFlag = string.Empty;               //사용여부         


        //    if (this.cboPlantCode_H.Value != null)
        //        sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();         ///사업장코드 

        //    //            if (this.cboUseFlag_H.Value != null)
        //    //                sUseFlag = cboUseFlag_H.Value.ToString() == "ALL" ? "" : cboUseFlag_H.Value.ToString();                 // 사용여부

        //    sUseFlag = "";                 // 사용여부

        //    try
        //    {
        //        _biz.TBM0400_POP(sPlantCode, sOPCode, sOPName, sUseFlag, txtOPCode, txtOPName);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR", ex.Message);
        //    }

        //}
        //#endregion        //공정(작업장)
        //private void txtOPCode_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.txtOPName.Text = string.Empty;
        //}

        //private void txtOPNAME_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.txtOPCode.Text = string.Empty;
        //}

        //private void txtOPCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        Search_Pop_TBM0400();
        //    }
        //}



        //private void txtOPName_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        Search_Pop_TBM0400();
        //    }

        //}

        ////#region 라인 (TBM0500) 팝업창에서 값 가져오기
        ////private void Search_Pop_TBM0500()
        ////{

        ////    string sPlantCode = string.Empty;                             //사업장코드
        ////    string sLineCode = txtLineCode.Text.Trim();                   //라인코드
        ////    string sLineName = txtLineName.Text.Trim();                   //라인명명 
        ////    string sUseFlag = string.Empty;                              //사용여부      


        ////    if (this.cboPlantCode_H.Value != null)
        ////        sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();         ///사업장코드 

        ////    //            if (this.cboUseFlag_H.Value != null)
        ////    //                sUseFlag = cboUseFlag_H.Value.ToString() == "ALL" ? "" : cboUseFlag_H.Value.ToString();                 // 사용여부

        ////    sUseFlag = "";                 // 사용여부

        ////    try
        ////    {
        ////        _biz.TBM0500_POP(sPlantCode, sLineCode, sLineName, sUseFlag, txtLineCode, txtLineName);

        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        MessageBox.Show("ERROR", ex.Message);
        ////    }

        ////}
        ////#endregion 라인 (TBM0500) 팝업창에서 값 가져오기

        ////private void txtLineName_KeyDown(object sender, KeyEventArgs e)
        ////{
        ////    this.txtLineCode.Text = string.Empty;
        ////}


        ////private void txtLineCode_KeyPress(object sender, KeyPressEventArgs e)
        ////{
        ////    if (e.KeyChar == (char)Keys.Enter)
        ////    {
        ////        Search_Pop_TBM0500();
        ////    }
        ////}

        ////private void txtLineCode_MouseDoubleClick(object sender, MouseEventArgs e)
        ////{
        ////    Search_Pop_TBM0500();
        ////}



        ////private void txtLineName_KeyPress(object sender, KeyPressEventArgs e)
        ////{
        ////    if (e.KeyChar == (char)Keys.Enter)
        ////    {
        ////        Search_Pop_TBM0500();
        ////    }
        ////}

        ////private void txtLineName_MouseDoubleClick(object sender, MouseEventArgs e)
        ////{
        ////    Search_Pop_TBM0500();
        ////}



        //#region 작업장(TBM0600) 팝업창에서 값 가져오기
        ////////////////////     
        //private void Search_Pop_TBM0600()
        //{

        //    string sPlantCode = string.Empty;                             //사업장코드
        //    string sOPCode = txtOPCode.Text.Trim();                       //공정코드
        //    string sOPName = txtOPName.Text.Trim();                       //공정명 
        //    string sLineCode = string.Empty;                              //라인코드
        //    string sWORKCENTERCODE = txtWorkCenterCode.Text.Trim();       //작업호기(라인)코드
        //    string sWorkCenterName = txtWorkCenterName.Text.Trim();       //작업호기(라인)명 
        //    string sUseFlag = string.Empty;                               //사용여부         


        //    if (this.cboPlantCode_H.Value != null)
        //        sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();         ///사업장코드 

        //    //if (this.cboUseFlag_H.Value != null)
        //    //    sUseFlag = cboUseFlag_H.Value.ToString() == "ALL" ? "" : cboUseFlag_H.Value.ToString();                 // 사용여부
        //    sUseFlag = "";                 // 사용여부: 전체


        //    try
        //    {
        //        _biz.TBM0600_POP(sPlantCode, sWORKCENTERCODE, sWorkCenterName, sOPCode, sLineCode, sUseFlag, txtWorkCenterCode, txtWorkCenterName);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR", ex.Message);
        //    }

        //}
        //#endregion

        //private void txtWorkCenterCode_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.txtWorkCenterName.Text = string.Empty;
        //}

        //private void txtWorkCenterName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.txtWorkCenterCode.Text = string.Empty;
        //}

        //private void txtWorkCenterCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        Search_Pop_TBM0600();
        //    }
        //}

        //private void txtWorkCenterCode_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Search_Pop_TBM0600();
        //}



        //private void txtWorkCenterName_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        Search_Pop_TBM0600();
        //    }
        //}

        //private void txtWorkCenterName_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Search_Pop_TBM0600();
        //}


        //#endregion

        //private void txtOPCode_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Search_Pop_TBM0400();
        //}

        //private void txtOPName_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Search_Pop_TBM0400();
        //}

        ////private void txtLineCode_KeyDown(object sender, KeyEventArgs e)
        ////{
        ////    this.txtLineName.Text = string.Empty;
        ////}


        //public override void DoBaseSum()
        //{
        //    base.DoBaseSum();

        //    UltraGridRow ugr = grid1.DoSummaries(new string[] { "ErrorQty" });

        //}
    }
}

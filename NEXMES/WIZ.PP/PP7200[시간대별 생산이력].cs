#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  PP7200
//   Form Name    :  작업장별 시간대별 생산이력
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP7200 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        PopUp_Biz _biz = new PopUp_Biz();
        #endregion < MEMBER AREA >

        #region < CONSTRUCTOR >

        public PP7200()
        {
            InitializeComponent();
        }

        #endregion < CONSTRUCTOR >

        #region < FORM LOAD >

        private void PP7200_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "공정", false, GridColDataType_emu.VarChar, 75, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "공정명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineCode", "라인", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineName", "라인명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RecDate", "일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdDate", "생산일시", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "HourCase", "시간대", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdQty", "생산실적", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorQty", "불량수량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UPH", "UPH", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CycleTime", "C/T", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #region Grid MERGE

            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["RecDate"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["RecDate"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["RecDate"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["OPCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["OPCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["OPCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["OPName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["OPName"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["OPName"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["WorkCenterCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["WorkCenterCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["WorkCenterCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["WorkCenterName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["WorkCenterName"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["WorkCenterName"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion
        }

        #endregion < FORM LOAD >

        #region < TOOL BAR AREA >

        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                                             // 사업장(공장)
                string sStartDate = Convert.ToDateTime(CboStartdate_H.Value).ToString("yyyy-MM-dd");                    // 생산시작일자
                string sEndDate = Convert.ToDateTime(CboEnddate_H.Value).ToString("yyyy-MM-dd");                        // 생산  끝일자
                string sWorkCenterCode = this.txtWorkCenterCode.Text.Trim();                                            // 작업장 코드
                string sOPCode = this.txtOPCode.Text.Trim();                                                            // 공정 코드

                //     string sLineCode = this.txtLineCode.Text.Trim();                                                // 라인 코드

                /* 
                  @PlantCode             VARCHAR(10)   -- 공장
                 ,@StartDate             VARCHAR(10)   -- 생산시작일자
                 ,@EndDate               VARCHAR(10)   -- 생산  끝일자
                 ,@WorkCenterCode        VARCHAR(10)   -- 작업장 코드
                 ,@OPCode                VARCHAR(10)   -- 공정 코드
                */
                grid1.DataSource = helper.FillTable("USP_PP7200_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)             // 사업장(공장)    
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)             // 생산시작일자    
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)                 // 생산  끝일자    
                                                                   , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)   // 작업장 코드     
                                                                   , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input));                 // 공정 코드       
                grid1.DataBinds();
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

        #endregion < TOOL BAR AREA >

        #region < METHOD AREA >
        // Form에서 사용할 함수나 메소드를 정의
        #region 텍스트 박스에서 팝업창에서 값 가져오기

        private void Search_Pop_Item()
        {
            DataTable _DtTemp = new DataTable();
            string sitem_cd = "";// this.txtItemCode.Text.Trim();    // 품목
            string sitem_name = ""; // this.txtItemName.Text.Trim();  // 품목명
            string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value.ToString());
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

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {

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
            string sOPCode = txtOPCode.Text.Trim();       //공정코드
            string sOPName = txtOPName.Text.Trim();       //공정명 
            string sUseFlag = string.Empty;               //사용여부         


            if (this.cboPlantCode_H.Value != null)
                sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();         ///사업장코드 

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

        //#region 라인 (TBM0500) 팝업창에서 값 가져오기
        //private void Search_Pop_TBM0500()
        //{

        //    string sPlantCode = string.Empty;                             //사업장코드
        //    string sLineCode = txtLineCode.Text.Trim();                   //라인코드
        //    string sLineName = txtLineName.Text.Trim();                   //라인명명 
        //    string sUseFlag = string.Empty;                              //사용여부      


        //    if (this.cboPlantCode_H.Value != null)
        //        sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();         ///사업장코드 

        //    //            if (this.cboUseFlag_H.Value != null)
        //    //                sUseFlag = cboUseFlag_H.Value.ToString() == "ALL" ? "" : cboUseFlag_H.Value.ToString();                 // 사용여부

        //    sUseFlag = "";                 // 사용여부

        //    try
        //    {
        //        _biz.TBM0500_POP(sPlantCode, sLineCode, sLineName, sUseFlag, txtLineCode, txtLineName);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR", ex.Message);
        //    }

        //}
        //#endregion 라인 (TBM0500) 팝업창에서 값 가져오기

        //private void txtLineName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.txtLineCode.Text = string.Empty;
        //}


        //private void txtLineCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        Search_Pop_TBM0500();
        //    }
        //}

        //private void txtLineCode_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Search_Pop_TBM0500();
        //}



        //private void txtLineName_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        Search_Pop_TBM0500();
        //    }
        //}

        //private void txtLineName_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Search_Pop_TBM0500();
        //}



        #region 작업장(TBM0600) 팝업창에서 값 가져오기
        //////////////////     
        private void Search_Pop_TBM0600()
        {

            string sPlantCode = string.Empty;                             //사업장코드
            string sOPCode = txtOPCode.Text.Trim();                       //공정코드
            string sOPName = txtOPName.Text.Trim();                       //공정명 
            string sLineCode = string.Empty;                              //라인코드
            string sWORKCENTERCODE = txtWorkCenterCode.Text.Trim();       //작업호기(라인)코드
            string sWorkCenterName = txtWorkCenterName.Text.Trim();       //작업호기(라인)명 
            string sUseFlag = string.Empty;                               //사용여부         


            if (this.cboPlantCode_H.Value != null)
                sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();         ///사업장코드 

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

        //private void txtLineCode_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.txtLineName.Text = string.Empty;
        //}


        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "ErrorQty" });
        }

        #endregion
    }
}

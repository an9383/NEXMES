#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MT1300
//   Form Name    : 작업장별 시간별 생산현황
//   Name Space   : WIZ.MT
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.UltraChart.Resources.Appearance;
//using PopManager;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MT
{


    public partial class MT1300 : WIZ.Forms.BaseMDIChildForm
    {
        #region<Member Area>
        DataTable rtnDtTemp2 = new DataTable();  //return DataTable 공통(시간생산현황)
        PopUp_Biz _biz = new PopUp_Biz(); //비지니스 로직 객체 생성
        #endregion

        #region<CONSTRUCTOR>
        public MT1300()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });

            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });
        }
        #endregion

        #region MT1300_Load
        private void MT1300_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            // 라인가동 현황
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1);//                                                   

            _GridUtil.InitColumnUltraGrid(grid1, "StartDate", "시작", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EndDate", "종료", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Status", "상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "내역", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            //생산현황
            _GridUtil.InitializeGrid(this.grid2);//                                                   

            _GridUtil.InitColumnUltraGrid(grid2, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemName", "품명", false, GridColDataType_emu.VarChar, 255, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ProdQty", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ErrorQty", "불량수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable();  // return DataTable 공통(라인가동상태)
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");


            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;  //시간대별 생산 현황
        }
        #endregion MT1300_Load

        #region 조회
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = cboPlantCode_H.Value.ToString();                                               // 사업장(공장)
                string sRecDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);
                string sWorkCenterCode = this.txtWorkCenterCode.Text.Trim();                                       // 작업장 코드
                string sOPCode = this.txtOPCode.Text.Trim();                                                       // 공정 코드

                grid1.DataSource = helper.FillTable("USP_MT1300_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                // 사업장(공장)    
                                                            , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)                      // 공정 코드       
                                                            , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)      // 작업장 코드     
                                                            , helper.CreateParameter("RecDate", sRecDate, DbType.String, ParameterDirection.Input));                  // 생산시작일자    





                grid1.DataBind();
                grid2.DataSource = helper.FillTable("USP_MT1300_S2", CommandType.StoredProcedure
                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                            // 사업장(공장)    
                                            , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)                                  // 공정 코드       
                                            , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)                  // 작업장 코드     
                                            , helper.CreateParameter("RecDate", sRecDate, DbType.String, ParameterDirection.Input));                              // 생산시작일자    




                grid2.DataBind();

                rtnDtTemp2 = helper.FillTable("USP_MT1300_S3", CommandType.StoredProcedure
                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                            // 사업장(공장)    
                                            , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)                                  // 공정 코드       
                                            , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)                  // 작업장 코드     
                                            , helper.CreateParameter("RecDate", sRecDate, DbType.String, ParameterDirection.Input));                              // 생산시작일자    

                if (rtnDtTemp2.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();

                    NumericSeries series = new NumericSeries();
                    series.Data.DataSource = rtnDtTemp2;
                    series.Data.LabelColumn = "HourCase";
                    series.Data.ValueColumn = "ProdQty";
                    series.DataBind();

                    ultraChart1.Series.Add(series);
                    ultraChart1.Data.DataBind();


                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                //if (SqlDBHelper._sConn != null) { SqlDBHelper._sConn.Close(); }
                //if (param != null) { param = null; }
            }
        }
        #endregion 조회

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의
        #region 텍스트 박스에서 팝업창에서 값 가져오기

        //////////////////     
        private void Search_Pop_TBM0400()
        {

            string sPlantCode = string.Empty;                 //사업장코드
            string sOPCode = txtOPCode.Text.Trim();        //공정코드
            string sOPName = txtOPName.Text.Trim();        //공정명 
            string sUseFlag = string.Empty;                 //사용여부         


            if (this.cboPlantCode_H.Value != null)
                sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();                           //사업장코드 

            //            if (this.cboUseFlag_H.SelectedValue != null)
            //                sUseFlag = cboUseFlag_H.SelectedValue.ToString() == "ALL" ? "" : cboUseFlag_H.SelectedValue.ToString();                   // 사용여부

            sUseFlag = "";                 // 사용여부

            try
            {
                _biz.BM0040_POP(sOPCode, sOPName, sPlantCode, "", sUseFlag, txtOPCode, txtOPName);

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


        #region 작업장(TBM0600) 팝업창에서 값 가져오기
        //////////////////     
        private void Search_Pop_TBM0600()
        {

            string sPlantCode = string.Empty;                                 //사업장코드
            string sOPCode = txtOPCode.Text.Trim();                        //공정코드
            string sOPName = txtOPName.Text.Trim();                        //공정명 
            string sLineCode = string.Empty;                                 //라인코드
            string sWORKCENTERCODE = txtWorkCenterCode.Text.Trim();                //작업호기(라인)코드
            string sWorkCenterName = txtWorkCenterName.Text.Trim();                //작업호기(라인)명 
            string sUseFlag = string.Empty;                                 //사용여부         


            if (this.cboPlantCode_H.Value != null)
                sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();         ///사업장코드 

            //if (this.cboUseFlag_H.SelectedValue != null)
            //    sUseFlag = cboUseFlag_H.SelectedValue.ToString() == "ALL" ? "" : cboUseFlag_H.SelectedValue.ToString();                 // 사용여부
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

        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "ErrorQty" });

        }

        #endregion
    }
}

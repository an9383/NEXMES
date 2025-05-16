#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID        :  QM0900
//   Form Name    : 수입검사 불합격 유형별 내역 
//   Name Space   : WIZ.QM
//   Created Date  : 
//   Made By       : WIZCORE
//   Description    : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.UltraChart.Resources.Appearance;
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.QM
{
    public partial class QM0900 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        #endregion

        #region<CONSTRUCTOR>

        public QM0900()
        {
            InitializeComponent();
        }
        #endregion

        #region QM0900_Load
        private void QM0900_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅

            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1);// 82 110 139 100                                                    

            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "검사항목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "항목명", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDesc", "항목상세", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorQty", "불합격수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;
            this.ultraChart2.EmptyChartText = string.Empty;
        }
        #endregion QM0900_Load

        #region <DoInquire>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);                                                               // 사업장(공장)
                DateTime sStartDate = Convert.ToDateTime(((DateTime)this.CboStartdate_H.Value).ToString("yyyy-MM-dd") + " 00:00:00.00");    // 검사일자(시) 
                DateTime sEndDate = Convert.ToDateTime(((DateTime)this.CboEnddate_H.Value).ToString("yyyy-MM-dd") + " 23:59:59.99");        // 검사일자(종) 
                string sCustCode = txtCustCode.Text.Trim();                                                                                 // 거래선코드

                grid1.DataSource = helper.FillTable("USP_QM0900_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)     // 사업장(공장)    
                                                                    , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)     // 생산시작일자    
                                                                    , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)         // 생산  끝일자    
                                                                    , helper.CreateParameter("CustCode", sCustCode, DbType.String, ParameterDirection.Input));     // 작업장 코드     
                grid1.DataBinds();


                if (grid1.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();
                    ultraChart2.Series.Clear();

                    NumericSeries series = new NumericSeries();
                    series.Data.DataSource = grid1.DataSource;
                    series.Data.LabelColumn = "InspCode";
                    series.Data.ValueColumn = "ErrorQty";
                    series.DataBind();

                    ultraChart1.Series.Add(series);
                    ultraChart1.Data.DataBind();

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

        #region 작업장(TBM0300) 팝업창에서 값 가져오기
        //////////////////     
        private void Search_Pop_TBM0300()
        {
            string sPlantCode = string.Empty;                             //사업장코드
            string sCustCode = txtCustCode.Text.Trim(); ;                 //공정코드
            string sCustName = txtCustName.Text.Trim();                   //공정명 
            string sCustType = string.Empty;                              //라인코드
            string sUseFlag = string.Empty;                               //사용여부         

            if (this.cboPlantCode_H.SelectedValue != null)
                sPlantCode = cboPlantCode_H.SelectedValue.ToString() == "ALL" ? "" : cboPlantCode_H.SelectedValue.ToString();         ///사업장코드 

            sUseFlag = "";


            try
            {
                //_biz.TBM0300_POP(sCustCode,sCustName, sCustType, sUseFlag, txtCustCode ,txtCustName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtCustName.Text = string.Empty;
        }
        private void txtCustName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtCustCode.Text = string.Empty;
        }
        private void txtCustCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0300();
        }
        private void txtCustName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0300();
        }
        #endregion
    }
}

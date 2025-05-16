#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM1300  
//   Form Name    : 공정검사 불합격 유형별 내역
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.UltraChart.Resources.Appearance;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.QM
{
    public partial class QM1300 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        #endregion

        #region < CONSTRUCTOR >
        public QM1300()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { "", "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();
                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);                                                  // 사업장(공장)
                string sStartDate = DBHelper.nvlDateTime(CboStartdate_H.Value).ToString("yyyy-MM-dd");                         // 생산시작일자
                string sEndDate = DBHelper.nvlDateTime(CboEnddate_H.Value).ToString("yyyy-MM-dd");                             // 생산  끝일자
                string sOPCode = this.txtOPCode.Text.Trim();                                                                   // 공정 코드
                string sLineCode = "";                                                                                         // 라인 코드
                string sWorkCenterCode = DBHelper.nvlString(this.txtWorkCenterCode.Text.Trim());                               // 작업장 코드
                string sItemCode = this.txtItemCode.Text.Trim();                                                               // 품목

                grid1.DataSource = helper.FillTable("USP_QM1300_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)             // 사업장(공장)    
                                                                    , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)             // 생산시작일자    
                                                                    , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)                 // 생산  끝일자    
                                                                    , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)                   // 공정 코드       
                                                                    , helper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input)               // 라인 코드       
                                                                    , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)   // 작업장 코드     
                                                                    , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input));             // 품목                    
                grid1.DataBinds();

                if (grid1.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();
                    ultraChart2.Series.Clear();

                    NumericSeries series = new NumericSeries();
                    series.Data.DataSource = grid1.DataSource;
                    series.Data.LabelColumn = "InspName";
                    series.Data.ValueColumn = "SampleQty";
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
        #endregion

        #region 폼 로더
        private void QM1300_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅

            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1);//100 80 120 80 

            _GridUtil.InitColumnUltraGrid(grid1, "InspCase", "검사구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "검사항목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "항목명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SampleQty", "불합격수량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("INSPCASE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspCase", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;
            this.ultraChart2.EmptyChartText = string.Empty;
        }
        #endregion
    }
}

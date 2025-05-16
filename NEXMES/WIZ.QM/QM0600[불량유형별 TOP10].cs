#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  QM0600
//   Form Name    : 불량유형별별 TOP10 정보 조회
//   Name Space   : WIZ.QM
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
#endregion

namespace WIZ.QM
{
    public partial class QM0600 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        #endregion

        #region < CONSTRUCTOR >
        public QM0600()
        {
            InitializeComponent();
        }
        #endregion

        #region QM0600_Load
        private void QM0600_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorType", "불량구분", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorClass", "불량유형", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorCode", "불량코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorDesc", "불량내역", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorQty", "불량수량", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorPPM", "불량율(PPM)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DISPLAYNO", "NO", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ERRORCLASS");
            WIZ.Common.FillComboboxMaster(this.cboErrorClass, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            #endregion

            #region Grid MERGE

            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ErrorClass"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["ErrorClass"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["ErrorClass"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE

            this.ultraChart1.EmptyChartText = string.Empty;
            this.ultraChart2.EmptyChartText = string.Empty;
        }
        #endregion QM0600_Load

        #region 조회
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);                                                                            // 사업장(공장)
                string sStartDate = Convert.ToDateTime(CboStartdate_H.Value).ToString("yyyy-MM-dd");
                string sEndDate = Convert.ToDateTime(CboEnddate_H.Value).ToString("yyyy-MM-dd");
                string sWorkCenterCode = string.Empty;                                                                                                   // 작업장 코드
                string sOPCode = string.Empty;                                                                                                           // 공정 코드
                string sLineCode = string.Empty;                                                                                                         // 라인 코드
                string sErrorClass = DBHelper.nvlString(cboErrorClass.Value);

                grid1.DataSource = helper.FillTable("USP_QM0600_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)            // 사업장(공장)    
                                                                    , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)            // 생산시작일자    
                                                                    , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)                // 생산  끝일자    
                                                                    , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)  // 작업장 코드     
                                                                    , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)                  // 공정 코드       
                                                                    , helper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input)              // 라인 코드       
                                                                    , helper.CreateParameter("ErrorClass", sErrorClass, DbType.String, ParameterDirection.Input)          // 라인 코드       
                                                                    , helper.CreateParameter("Param1", DBNull.Value, DbType.String, ParameterDirection.Input)             // 라인 코드       
                                                                    , helper.CreateParameter("Param2", DBNull.Value, DbType.String, ParameterDirection.Input)             // 라인 코드       
                                                                    , helper.CreateParameter("Param3", DBNull.Value, DbType.String, ParameterDirection.Input));           // 라인 코드       
                grid1.DataBinds();

                if (grid1.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();
                    ultraChart2.Series.Clear();

                    NumericSeries series = new NumericSeries();
                    series.Data.DataSource = grid1.DataSource;
                    series.Data.LabelColumn = "ErrorDesc";
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

        #region<METHOD AREA>
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "ErrorQty", "ErrorPPM" });
        }

        private void gbxHeader_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}

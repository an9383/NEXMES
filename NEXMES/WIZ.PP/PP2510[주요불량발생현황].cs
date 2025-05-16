#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP2510
//   Form Name    : 주요 불량 발생현황
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP2510 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        #endregion

        #region < CONSTRUCTOR >
        public PP2510()
        {
            InitializeComponent();
        }
        #endregion

        #region < PP2510_Load >
        private void PP2510_Load(object sender, EventArgs e)
        {
            #region --- Grid 셋팅 ---
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorCode", "불량", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorDesc", "불량명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorType", "불량구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorClass", "불량유형", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorQty", "불량수량", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region --- ComboBox Setting ---
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("ErrorType");  //불량구분
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ErrorType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("ErrorClass"); //불량유형
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ErrorClass", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #region --- POP-Up Setting ---
            //팝업 매니저
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });
            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;
            this.ultraChart2.EmptyChartText = string.Empty;
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                            // 사업장(공장)
                string sStartDate = Convert.ToDateTime(CboStartdate_H.Value).ToString("yyyy-MM-dd");   // 생산시작일자
                string sEndDate = Convert.ToDateTime(CboEnddate_H.Value).ToString("yyyy-MM-dd");       // 생산  끝일자
                string sWorkCenterCode = this.txtWorkCenterCode.Text.Trim();                           // 작업장 코드
                string sOPCode = this.txtOPCode.Text.Trim();                                           // 공정 코드

                grid1.DataSource = helper.FillTable("USP_PP2510_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)             // 사업장(공장)    
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)             // 생산시작일자    
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)                 // 생산  끝일자    
                                                                   , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)   // 작업장 코드     
                                                                   , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input));                 // 공정 코드       


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
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < METHOD AREA >
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "ErrorQty" });
        }
        #endregion
    }
}

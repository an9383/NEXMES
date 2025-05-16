#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  QM0500
//   Form Name    :  작업자별 TOP10 정보 조회
//   Name Space   : WIZ.QM
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
    public partial class QM0500 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>

        #endregion

        #region<CONSTRUCTOR>
        public QM0500()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtLineCode, txtLineName, "TBM0500", new object[] { "", "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });
        }
        #endregion

        #region  QM0500_Load
        private void QM0500_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1);// 90 109 97 100 114 100                                                   
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerId", "작업자ID", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerName", "작업자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorQty", "불량수량", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;
            this.ultraChart2.EmptyChartText = string.Empty;
        }
        #endregion  QM0500_Load

        #region 조회
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);                                      // 사업장(공장)
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);
                string sWorkCenterCode = this.txtWorkCenterCode.Text.Trim();                                       // 작업장 코드
                string sOPCode = this.txtOPCode.Text.Trim();                                                       // 공정 코드
                string sLineCode = this.txtLineCode.Text.Trim();                                                   // 라인 코드

                grid1.DataSource = helper.FillTable("USP_QM0500_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)            // 사업장(공장)    
                                                                    , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)            // 생산시작일자    
                                                                    , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)                // 생산  끝일자    
                                                                    , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)  // 작업장 코드     
                                                                    , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)                  // 공정 코드       
                                                                    , helper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input));            // 라인 코드       

                grid1.DataBinds();


                if (grid1.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();
                    ultraChart2.Series.Clear();

                    NumericSeries series = new NumericSeries();
                    series.Data.DataSource = grid1.DataSource;
                    series.Data.LabelColumn = "WorkerName";
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
    }
}

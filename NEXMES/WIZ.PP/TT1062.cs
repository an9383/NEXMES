using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System;
using System.Data;
using System.Windows.Forms;


namespace WIZ.PP
{
    public partial class TT1062 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        #endregion

        #region <CONSTRUCTOR>
        public TT1062()
        {
            InitializeComponent();

        }
        #endregion

        #region TT1062_Load
        private void TT1062_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "inspdate", "측정일", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "plccode", "항목", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "plcvalue", "각도", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLCResult", "결과", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLCPCount", "작업수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            //PLCPCount,Etc1,etc2

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            grid1.Columns["inspdate"].Format = "yyyy-MM-dd HH:mm:ss";

            #region 콤보박스 셋팅
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLCCODE");

            DataRow[] DR = rtnDtTemp.Select("CODE_ID = 'PLC1'");

            DataTable dt = new DataTable();
            dt.Columns.Add("CODE_ID", typeof(string));
            dt.Columns.Add("CODE_NAME", typeof(string));
            dt.Columns.Add("DisplayNo", typeof(int));

            foreach (DataRow dr in DR)
            {
                dt.Rows.Add(dr["CODE_ID"], dr["CODE_NAME"], dr["DisplayNo"]);
            }
            DataTable DTSORT = new DataTable();
            DTSORT = dt.Select("", "DisplayNo").CopyToDataTable<DataRow>();

            WIZ.Common.FillComboboxMaster(this.cbo_plc, DTSORT, DTSORT.Columns["CODE_ID"].ColumnName, DTSORT.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "plccode", DTSORT, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLCResult");
            WIZ.Common.FillComboboxMaster(this.cbo_result, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLCResult", rtnDtTemp, "CODE_ID", "CODE_NAME");


            #endregion 콤보박스 셋팅

            this.chart.EmptyChartText = string.Empty;
        }

        #endregion TT1062_Load

        #region<METHOD AREA>
        public override void DoInquire()
        {


            DBHelper helper = new DBHelper(false);


            DateTime dtStart = Convert.ToDateTime(CboStartdate_H.Value);
            DateTime dtEnd = Convert.ToDateTime(CboEnddate_H.Value);
            string sPlantCode = Convert.ToString(cboPlantCode_H.Value);          //사업장코드
            string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);
            string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);
            string sPlccode = Convert.ToString(cbo_plc.Value);                  //사업장코드
            string sResult = Convert.ToString(cbo_result.Value);

            try
            {
                base.DoInquire();

                grid1.DataSource = helper.FillTable("USP_TT1062_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("pPLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pStartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pEndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pPlcCode", sPlccode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("sResult", sResult, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();

                DoGraph();

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

        private void DoGraph()
        {
            try
            {
                string sPlcCode;
                chart.Series.Clear();

                int idx = 0;
                chart.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL:HH:mm:ss>";

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    sPlcCode = DBHelper.nvlString(grid1.Rows[i].Cells["plccode"].Value);

                    idx = GetSeriesIndex(sPlcCode);

                    NumericTimeSeries n = (NumericTimeSeries)chart.Series[idx];
                    n.Points.Add(new NumericTimeDataPoint(DBHelper.nvlDateTime(grid1.Rows[i].Cells["inspdate"].Value)
                                , DBHelper.nvlDouble(grid1.Rows[i].Cells["plcvalue"].Value), "", true));

                }

                chart.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;
                chart.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message);
            }
        }

        private int GetSeriesIndex(string sKey)
        {
            for (int i = 0; i < chart.Series.Count; i++)
            {
                if (chart.Series[i].Key == sKey)
                {
                    return i;
                }
            }

            NumericTimeSeries s = new NumericTimeSeries();
            s.Key = sKey;
            s.Label = sKey;
            chart.Series.Add(s);

            return chart.Series.Count - 1;
        }

        private void ugExcelExporter_CellExported(object sender, CellExportedEventArgs e)
        {
            int latestColIndex = -1;
            int latestRowIndex = -1;
            if (e.CurrentRowIndex > latestRowIndex)
            { latestRowIndex = e.CurrentRowIndex; }
            if (e.CurrentColumnIndex > latestColIndex) latestColIndex = e.CurrentColumnIndex;

        }
        #endregion
    }
}


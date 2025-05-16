#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : TT1060
//   Form Name    : 기밀검사기 데이터 조회
//   Name Space   : WIZ.PP
//   Created Date : 2012-03-19
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.UltraChart.Core.Layers;
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.UltraChart.Shared.Styles;
using System;
using System.Data;
#endregion


namespace WIZ.PP
{
    public partial class TT1060 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        #endregion

        #region < CONSTRUCTOR >
        public TT1060()
        {
            InitializeComponent();
        }
        #endregion

        #region < TT1060_Load >
        private void TT1060_Load(object sender, EventArgs e)
        {
            #region --- Grid 셋팅 ---
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "inspdate", "측정일", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "plccode", "검사기", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotNo", "LotNo", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "plcvalue", "누설량", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLCResult", "결과", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLCPCount", "카운트(PLC)", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Etc1", "WORK NO", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "etc2", "FILL", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.Columns["inspdate"].Format = "yyyy-MM-dd HH:mm:ss";
            #endregion

            #region --- 콤보박스 셋팅 ---

            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLCCODE");

            DataRow[] DR = rtnDtTemp.Select("CODE_ID <> 'PLC1' AND CODE_ID <> 'PLC2'");

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
            WIZ.Common.FillComboboxMaster(this.cbo_plc2, DTSORT, DTSORT.Columns["CODE_ID"].ColumnName, DTSORT.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "plccode", DTSORT, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLCResult");
            WIZ.Common.FillComboboxMaster(this.cbo_result, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLCResult", rtnDtTemp, "CODE_ID", "CODE_NAME");

            this.chart.EmptyChartText = string.Empty;
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            DateTime dtStart = DBHelper.nvlDateTime(CboStartdate_H.Value);
            DateTime dtEnd = DBHelper.nvlDateTime(CboEnddate_H.Value);
            string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
            string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value) + " 00:00:00";
            string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value) + " 23:59:59";
            string sPlccode = DBHelper.nvlString(cbo_plc.Value);
            string sPlccode2 = DBHelper.nvlString(cbo_plc2.Value);
            string sResult = DBHelper.nvlString(cbo_result.Value);
            string etc1 = "";
            string etc2 = "";
            string etc3 = "";

            try
            {
                base.DoInquire();

                grid1.DataSource = helper.FillTable("USP_TT1060_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PlcCode", sPlccode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PlcCode2", sPlccode2, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("Result", sResult, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ETC1", etc1, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ETC2", etc2, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ETC3", etc3, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();

                DoGraph();
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

        #region < EVENT AREA >
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("col1", typeof(Int32));
            dt.Columns.Add("col2", typeof(Int32));
            dt.Columns.Add("col3", typeof(Int32));
            dt.Columns.Add("col4", typeof(String));

            dt.Rows.Add(new object[] { 2, 14, 12, "H1" });
            dt.Rows.Add(new object[] { 1, 11, 10, "H2" });
            dt.Rows.Add(new object[] { 1, 9, 11, "H3" });
            dt.Rows.Add(new object[] { 1, 10, 11, "H4" });
            dt.Rows.Add(new object[] { 4, 12, 9, "H5" });
            dt.Rows.Add(new object[] { 1, 11, 10, "H6" });
            dt.Rows.Add(new object[] { 1, 8, 7, "H7" });
            dt.Rows.Add(new object[] { 2, 10, 10, "H8" });

            this.chart.ChartType = ChartType.Composite;
            ChartArea area = new ChartArea();
            this.chart.CompositeChart.ChartAreas.Add(area);
            AxisItem xAxisColumn = new AxisItem(this.chart, AxisNumber.X_Axis);
            AxisItem xAxisLine = new AxisItem(this.chart, AxisNumber.X_Axis);
            AxisItem yAxis = new AxisItem(this.chart, AxisNumber.Y_Axis);
            xAxisColumn.DataType = AxisDataType.String;
            xAxisColumn.SetLabelAxisType = SetLabelAxisType.GroupBySeries;
            xAxisColumn.Labels.ItemFormat = AxisItemLabelFormat.ItemLabel;
            xAxisLine.DataType = AxisDataType.String;
            xAxisLine.SetLabelAxisType = SetLabelAxisType.ContinuousData;
            yAxis.DataType = AxisDataType.Numeric;
            yAxis.Labels.ItemFormat = AxisItemLabelFormat.DataValue;
            area.Axes.Add(xAxisColumn);
            area.Axes.Add(xAxisLine);
            area.Axes.Add(yAxis);

            NumericSeries seriesColumn = new NumericSeries();
            seriesColumn.Data.DataSource = dt;
            seriesColumn.Data.LabelColumn = "col4";
            seriesColumn.Data.ValueColumn = "col2";

            NumericSeries seriesColumn2 = new NumericSeries();
            seriesColumn2.Data.DataSource = dt;
            seriesColumn2.Data.LabelColumn = "col4";
            seriesColumn2.Data.ValueColumn = "col3";

            NumericSeries seriesLine = new NumericSeries();
            seriesLine.Data.DataSource = dt;
            seriesLine.Data.LabelColumn = "col4";
            seriesLine.Data.ValueColumn = "col1";

            this.chart.Series.AddRange(new Infragistics.UltraChart.Data.Series.ISeries[] { seriesLine, seriesColumn, seriesColumn2 });

            ChartLayerAppearance columnLayer = new ChartLayerAppearance();
            columnLayer.AxisX = xAxisColumn;
            columnLayer.AxisY = yAxis;
            columnLayer.ChartArea = area;
            columnLayer.ChartType = ChartType.ColumnChart;
            columnLayer.Series.Add(seriesColumn);
            columnLayer.Series.Add(seriesColumn2);
            columnLayer.SwapRowsAndColumns = true;

            ChartLayerAppearance lineLayer = new ChartLayerAppearance();
            lineLayer.AxisX = xAxisLine;
            lineLayer.AxisY = yAxis;
            lineLayer.ChartArea = area;
            lineLayer.ChartType = ChartType.LineChart;
            lineLayer.Series.Add(seriesLine);

            this.chart.CompositeChart.ChartLayers.Add(columnLayer);
            this.chart.CompositeChart.ChartLayers.Add(lineLayer);
            this.chart.ColumnChart.SeriesSpacing = 1;
        }
        #endregion

        #region < METHD AREA >
        private void DoGraph()
        {
            try
            {
                DBHelper helper = new DBHelper(false);

                string sPlcCode;
                chart.Series.Clear();
                //chart.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;

                this.chart.ChartType = ChartType.LineChart;

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
                //chart.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
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
        #endregion
    }
}


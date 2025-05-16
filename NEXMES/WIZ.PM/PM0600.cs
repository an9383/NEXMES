#region <USING AREA>
using Infragistics.UltraChart.Core.Layers;
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.UltraChart.Shared.Styles;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PM
{
    public partial class PM0600 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>

        #endregion

        #region<CONSTRUCTOR>
        public PM0600()
        {
            InitializeComponent();
            BizGridManager BIZPOP = new BizGridManager(grid1);
            BIZPOP.PopUpAdd("WorkCenterCode", "WorkCenterName", "TPM0600", new string[] { "", "23302-04", "2013-01" });
        }
        #endregion

        #region<METHOD AREA>
        public override void DoInquire()
        {
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            DBHelper helper = new DBHelper(false);
            System.Data.Common.DbParameter[] param = new System.Data.Common.DbParameter[10];

            string sRecDate = CboStartdate_H.Value.ToString().Substring(0, 7);
            string sPlantCode = cboPlantCode_H.Value.ToString();
            string sWorkcentercode = txtWorkCenterCode.Text.Trim();
            string sItemcode = txtItemCode.Text.Trim();
            string sErrorCode = "";

            try
            {
                base.DoInquire();

                param[0] = helper.CreateParameter("@etc1", "", DbType.String, ParameterDirection.Input);
                param[1] = helper.CreateParameter("@etc2", "", DbType.String, ParameterDirection.Input);
                param[2] = helper.CreateParameter("@etc3", "", DbType.String, ParameterDirection.Input);
                param[3] = helper.CreateParameter("@PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input);
                param[4] = helper.CreateParameter("@WorkCenterCode", sWorkcentercode, DbType.String, ParameterDirection.Input);
                param[5] = helper.CreateParameter("@ItemCode", sItemcode, DbType.String, ParameterDirection.Input);
                param[6] = helper.CreateParameter("@RecDate", sRecDate, DbType.String, ParameterDirection.Input);
                param[7] = helper.CreateParameter("@ErrorCode", sErrorCode, DbType.String, ParameterDirection.Input);
                param[8] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                param[9] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                rtnDtTemp = helper.FillTable("USP_PM0600_S1", CommandType.StoredProcedure, param);
                if (param[8].Value.ToString() == "E") throw new Exception(param[9].Value.ToString());

                if (rtnDtTemp.Rows.Count > 0)
                {
                    int result_Tm1 = 0;
                    int result_Tm2 = 0;
                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    {
                        result_Tm1 = result_Tm1 + DBHelper.nvlInt(rtnDtTemp.Rows[i]["ErrorQty"]);
                        result_Tm2 = result_Tm2 + DBHelper.nvlInt(rtnDtTemp.Rows[i]["SUMQty"]);

                        rtnDtTemp.Rows[i]["ErrorSQTY"] = (result_Tm1).ToString();
                    }

                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    {
                        rtnDtTemp.Rows[i]["ErrorAl"] = Convert.ToInt16((DBHelper.nvlDouble(rtnDtTemp.Rows[i]["ErrorQty"]) / result_Tm1) * 100);
                        rtnDtTemp.Rows[i]["ErrorSAL"] = Convert.ToInt16((DBHelper.nvlDouble(rtnDtTemp.Rows[i]["ErrorSQTY"]) / result_Tm1) * 100);
                        rtnDtTemp.Rows[i]["ERRORALL"] = Convert.ToInt16((DBHelper.nvlDouble(rtnDtTemp.Rows[i]["ErrorQty"]) / result_Tm2) * 1000000);
                    }

                }

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();


                if (rtnDtTemp.Rows.Count > 0)
                {
                    DataTable mainDt = new DataTable();
                    mainDt.Columns.Add("작업장", typeof(string));
                    mainDt.Columns.Add("불량수", typeof(double));
                    mainDt.Columns.Add("누적점유율", typeof(double));

                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    {
                        mainDt.Rows.Add(new object[] {DBHelper.nvlString(rtnDtTemp.Rows[i]["workcentercode"]),
                            DBHelper.nvlDouble(rtnDtTemp.Rows[i]["ErrorQty"]),
                            DBHelper.nvlDouble(rtnDtTemp.Rows[i]["ErrorSAL"])});
                    }

                    WIZ.Control.Chart chart = new WIZ.Control.Chart();
                    chart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                    chart.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
                    Infragistics.UltraChart.Resources.Appearance.GradientEffect gradientEffect1 = new Infragistics.UltraChart.Resources.Appearance.GradientEffect();
                    chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                    chart.ColorModel.AlphaLevel = ((byte)(150));
                    chart.ColorModel.ColorBegin = System.Drawing.Color.Pink;
                    chart.ColorModel.ColorEnd = System.Drawing.Color.DarkRed;
                    chart.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
                    chart.Dock = System.Windows.Forms.DockStyle.Top;
                    chart.Effects.Effects.Add(gradientEffect1);
                    chart.EmptyChartText = "";
                    chart.Legend.Visible = true;
                    chart.Location = new System.Drawing.Point(6, 6);
                    chart.Margin = new System.Windows.Forms.Padding(0);
                    chart.Name = "chart";
                    chart.Size = new System.Drawing.Size(1129, 332);

                    chart.TabIndex = 224;
                    chart.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray;
                    chart.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray;

                    this.gbxBody.SuspendLayout();
                    for (int i = 0; i < gbxBody.Controls.Count; i++)
                    {
                        System.Windows.Forms.Control con = gbxBody.Controls[i];

                        if (con.Name == chart.Name)
                        {
                            gbxBody.Controls.Remove(con);
                            i--;
                        }
                    }
                    this.gbxBody.Controls.Add(chart);
                    this.gbxBody.ResumeLayout(false);

                    chart.ChartType = ChartType.Composite;
                    ChartArea area = new ChartArea();
                    chart.CompositeChart.ChartAreas.Add(area);
                    AxisItem xAxisColumn = new AxisItem(chart, AxisNumber.X_Axis);
                    AxisItem xAxisLine = new AxisItem(chart, AxisNumber.X_Axis);
                    AxisItem yAxis = new AxisItem(chart, AxisNumber.Y_Axis);
                    xAxisColumn.DataType = AxisDataType.String;
                    xAxisColumn.SetLabelAxisType = SetLabelAxisType.GroupBySeries;
                    xAxisColumn.Labels.ItemFormat = AxisItemLabelFormat.ItemLabel;
                    xAxisLine.DataType = AxisDataType.String;
                    xAxisLine.SetLabelAxisType = SetLabelAxisType.ContinuousData;
                    yAxis.DataType = AxisDataType.Numeric;
                    yAxis.Labels.ItemFormat = AxisItemLabelFormat.DataValue;
                    //chart.Margin = new System.Windows.Forms.Padding(25,25,25, 25);
                    area.Axes.Add(xAxisColumn);
                    area.Axes.Add(xAxisLine);
                    area.Axes.Add(yAxis);


                    NumericSeries seriesColumn3 = new NumericSeries();
                    seriesColumn3.Data.DataSource = mainDt;
                    seriesColumn3.Data.LabelColumn = "작업장";
                    seriesColumn3.Data.ValueColumn = "불량수";

                    NumericSeries seriesLine2 = new NumericSeries();
                    seriesLine2.Data.DataSource = mainDt;
                    //  seriesLine2.Data.LabelColumn = "목적";
                    seriesLine2.Data.ValueColumn = "누적점유율";

                    chart.Series.AddRange(new Infragistics.UltraChart.Data.Series.ISeries[] { seriesColumn3, seriesLine2 });

                    ChartLayerAppearance columnLayer = new ChartLayerAppearance();
                    columnLayer.AxisX = xAxisColumn;
                    columnLayer.AxisX.ScrollScale.Visible = true;
                    columnLayer.AxisY = yAxis;
                    columnLayer.AxisY.ScrollScale.Visible = true;
                    columnLayer.ChartArea = area;
                    columnLayer.ChartType = ChartType.ColumnChart;
                    columnLayer.Series.Add(seriesColumn3);
                    columnLayer.SwapRowsAndColumns = true;


                    ChartLayerAppearance lineLayer = new ChartLayerAppearance();
                    lineLayer.AxisX = xAxisLine;
                    lineLayer.AxisY = yAxis;
                    lineLayer.AxisY.TickmarkStyle = AxisTickStyle.Smart;

                    lineLayer.ChartArea = area;
                    lineLayer.ChartType = ChartType.LineChart;
                    lineLayer.Series.Add(seriesLine2);

                    chart.CompositeChart.ChartLayers.Add(columnLayer);
                    chart.CompositeChart.ChartLayers.Add(lineLayer);
                    chart.ColumnChart.SeriesSpacing = 1;
                    columnLayer.AxisX.Extent = 30;
                    columnLayer.AxisY.Extent = 40;

                    lineLayer.AxisX.Extent = 30;
                    lineLayer.AxisY.Extent = 40;
                }
                //_Common.Grid_Column_Width(this.grid1); //grid 정리용   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                if (param != null) { param = null; }
            }
        }

        #region 폼 로더
        private void PM0600_Load(object sender, EventArgs e)
        {

            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "workcentername", "작업장명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SUMQty", "총생산수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdQty", "양품수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorQty", "불량수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorPPM", "불량률(PPM)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorAl", "점유율(%)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorSQTY", "누적 불량수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorSAL", "누적 점유율(%)", false, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Right, true, false, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORALL", "점유 불량률", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###", null, null, null, null);

            string[] sMergeColumn = { "WorkCenterCode", "workcentername", "SUMQty", "ProdQty", };
            string[] sMergeColumn2 = { "ErrorQty", "ErrorPPM", "ErrorAl", "ErrorSQTY", "ErrorSAL" };
            string[] sMergeColumn3 = { "ERRORALL" };
            string[] sHeadColumn = { "WorkCenterCode", "workcentername", "SUMQty", "ProdQty", "ErrorQty", "ErrorPPM", "ErrorAl", "ErrorSQTY", "ErrorSAL", "ERRORALL" };

            _GridUtil.SetInitUltraGridBind(grid1);

            //AUTO 사이즈
            grid1.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;


            //그리드 머지
            _GridUtil.GridHeaderMerge(grid1, "G2", "불량 현황", sMergeColumn2, sHeadColumn);


            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 0, 3);
            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 9, 9);

            grid1.Columns["G2"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;


            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            BizTextBoxManager btbManager = new BizTextBoxManager();

            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });


            #endregion

        }

        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "SUMQty", "ProdQty", "ErrorQty", "ErrorAl" });

            if (ugr != null)
            {
                double dResult = DBHelper.nvlDouble(ugr.Cells["ProdQty"].Value);
                double dError = DBHelper.nvlDouble(ugr.Cells["ErrorQty"].Value);


                ugr.Cells["ErrorPPM"].Value = dError / (dResult + dError) * 1000000;

            }
        }
        #endregion

        private void grid1_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            //if (grid1.ActiveRow.Cells["WorkCenterCode"].Value.ToString() != string.Empty)
            //{
            //    string sworkcentercode = grid1.ActiveRow.Cells["WorkCenterCode"].Value.ToString();
            //    string sworkcentername = grid1.ActiveRow.Cells["workcentername"].Value.ToString();
            //    string sPlantcode = cboPlantCode_H.Value.ToString();
            //    string sRecdate = CboStartdate_H.Value.ToString().Substring(0, 7);

            //    Form frm = new POP_TPM0600(new string[] { sPlantcode, sworkcentercode, sworkcentername, sRecdate });
            //    frm.Show();
            //}
        }
        #endregion
    }
}
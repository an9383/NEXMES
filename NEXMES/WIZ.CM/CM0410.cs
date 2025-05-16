#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : 
//   Form Name    : 
//   Name Space   : 
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.UltraChart.Core.Layers;
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.UltraChart.Shared.Styles;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.CM
{
    public partial class CM0410 : WIZ.Forms.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        public string sYear = string.Empty;
        //임시로 사용할 데이터테이블 생성
        #endregion

        #region < CONSTRUCTOR >

        public CM0410()
        {
            InitializeComponent();
        }

        private void CM0410_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            //A.PLANTCODE , C.Value2 AS LASTYEAR,
            //     [01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12] from

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTNAME", "사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GOALTYPE", "구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GOALTYPENAME", "구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "total", "계", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,#", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M01", "1월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, "#,#", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M02", "2월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, "#,#", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M03", "3월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, "#,#", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M04", "4월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, "#,#", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M05", "5월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, "#,#", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M06", "6월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, "#,#", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M07", "7월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, "#,#", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M08", "8월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, "#,#", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M09", "9월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, "#,#", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M10", "10월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, "#,#", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M11", "11월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, "#,#", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M12", "12월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, "#,#", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DISPLAYNO", "DISPLAYNO", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);


            //그리드 라인 색깔 해제
            grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.Override.SelectTypeCell = SelectType.None;

            //데이터 머지 된 상태에서 그리드 컬럼 소트 기능 막기     
            grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            _GridUtil.SetInitUltraGridBind(grid1);
            #region Grid MERGE
            grid1.Columns["PLANTNAME"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PLANTNAME"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PLANTNAME"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantcode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");

            rtnDtTemp = _Common.GET_BM0000_CODE("GOALTYPE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "GOALTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion
        }

        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            string stype = DBHelper.nvlString(cboPlantcode.Text);

            try
            {
                base.DoInquire();
                sYear = Convert.ToDateTime(cbo_date.Value).Year.ToString();
                string sPlantcode = cboPlantcode.SelectedText.ToString();
                label1.Text = "<" + cbo_date.Text + "년도 " + this.Text + ">";
                DataTable rtnDtTemp = helper.FillTable("USP_CM0410_S1", CommandType.StoredProcedure
                                                                      , helper.CreateParameter("PLANTCODE", sPlantcode, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("YEAR", sYear, DbType.String, ParameterDirection.Input));
                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();


                label1.Visible = true;
                groupBox1.Visible = true;

                Hashtable hash = new Hashtable();

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    hash.Add(DBHelper.gGetCode(drRow["PLANTCODE"]) + "|" + DBHelper.gGetCode(drRow["GOALTYPE"]), drRow);
                }

                for (int i2 = 0; i2 < grid1.Rows.Count; i2++)
                {
                    for (int i = rtnDtTemp.Columns.IndexOf("total"); i < rtnDtTemp.Columns.Count - 1; i++)
                    {
                        if (grid1.Rows[i2].Cells["GOALTYPE"].Value.ToString() == "GL" || grid1.Rows[i2].Cells["GOALTYPE"].Value.ToString() == "PR")
                        {
                            string qPLANTCODE = grid1.Rows[i2].Cells["PLANTCODE"].Value.ToString();

                            double sGL = 0;
                            double sPR = 0;
                            Double.TryParse(Convert.ToString(DBHelper.nvlDouble(((DataRow)hash[qPLANTCODE + "|" + "GL"])[i])), out sGL);
                            Double.TryParse(Convert.ToString(DBHelper.nvlDouble(((DataRow)hash[qPLANTCODE + "|" + "PR"])[i])), out sPR);

                            if (sGL == 0)
                            {
                                ((DataRow)hash[qPLANTCODE + "|" + "SM"])[i] = 0;
                            }
                            else
                            {
                                ((DataRow)hash[qPLANTCODE + "|" + "SM"])[i] = (sPR / sGL) * 100;
                            }
                        }
                    }
                }

                double ssGL = 0;
                for (int i2 = 0; i2 < grid1.Rows.Count; i2++)
                {
                    string qPLANTCODE = grid1.Rows[i2].Cells["PLANTCODE"].Value.ToString();

                    if (grid1.Rows[i2].Cells["GOALTYPE"].Value.ToString() == "GL")
                    {
                        ssGL = 0;
                        for (int i = rtnDtTemp.Columns.IndexOf("M01"); i < rtnDtTemp.Columns.Count - 1; i++)
                        {
                            double sGL = DBHelper.nvlDouble(((DataRow)hash[qPLANTCODE + "|" + "GL"])["total"]);
                            double sPR = DBHelper.nvlDouble(((DataRow)hash[qPLANTCODE + "|" + "PR"])[i]);

                            ssGL += sPR;

                            if (ssGL == 0)
                            {
                                ((DataRow)hash[qPLANTCODE + "|" + "AR"])[i] = 0;

                            }
                            else
                            {
                                if (sPR == 0)
                                {
                                    ((DataRow)hash[qPLANTCODE + "|" + "AR"])[i] = 0;
                                }
                                else
                                {
                                    ((DataRow)hash[qPLANTCODE + "|" + "AR"])[i] = ((ssGL / sGL) * 100);
                                }
                            }
                        }
                    }

                }

                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable srcDt = (DataTable)grid1.DataSource;

                dt.Columns.Add("Month");
                foreach (DataRow dr in srcDt.Rows)
                {
                    dt.Columns.Add(DBHelper.nvlString(dr["GOALTYPE"]));
                }

                for (int i = 0; i < srcDt.Columns.Count; i++)
                {
                    if (srcDt.Columns[i].ColumnName.Substring(0, 1) == "M")
                    {
                        DataRow tdr = dt.NewRow();

                        tdr[0] = i - 4 + "월";

                        for (int j = 0; j < srcDt.Rows.Count; j++)
                        {
                            tdr[j + 1] = srcDt.Rows[j][i];
                        }

                        dt.Rows.Add(tdr);
                    }
                }

                #region [차트 재생성]

                chart.ChartType = ChartType.Composite;
                ChartArea area = new ChartArea();
                chart.CompositeChart.ChartAreas.Add(area);
                area.Border.Color = Color.White;
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

                #endregion

                #region [차트 바인딩]

                area.Axes.Add(xAxisColumn);
                area.Axes.Add(xAxisLine);
                area.Axes.Add(yAxis);

                NumericSeries seriesColumn = new NumericSeries();
                seriesColumn.Data.DataSource = dt;
                seriesColumn.Data.LabelColumn = "Month";
                seriesColumn.Data.ValueColumn = "PR";

                NumericSeries seriesLine2 = new NumericSeries();
                seriesLine2.Data.DataSource = dt;
                seriesLine2.Data.ValueColumn = "GL";

                chart.Series.AddRange(new Infragistics.UltraChart.Data.Series.ISeries[] { seriesLine2, seriesColumn });

                ChartLayerAppearance columnLayer = new ChartLayerAppearance();
                columnLayer.AxisX = xAxisColumn;

                columnLayer.AxisX.ScrollScale.Visible = true;
                columnLayer.AxisY = yAxis;
                columnLayer.AxisY.ScrollScale.Visible = true;
                columnLayer.ChartArea = area;
                columnLayer.ChartType = ChartType.ColumnChart;
                columnLayer.Series.Add(seriesColumn);

                columnLayer.SwapRowsAndColumns = true;

                Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement3 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
                Infragistics.UltraChart.Resources.Appearance.CompositeLegend compositeLegend1 = new Infragistics.UltraChart.Resources.Appearance.CompositeLegend();
                paintElement3.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.Gradient;
                paintElement3.FillGradientStyle = Infragistics.UltraChart.Shared.Styles.GradientStyle.BackwardDiagonal;
                compositeLegend1.PE = paintElement3;


                ChartLayerAppearance lineLayer = new ChartLayerAppearance();
                lineLayer.AxisX = xAxisLine;
                lineLayer.AxisY = yAxis;
                lineLayer.AxisY.TickmarkStyle = AxisTickStyle.Smart;

                lineLayer.ChartArea = area;
                lineLayer.ChartType = ChartType.LineChart;

                lineLayer.Series.Add(seriesLine2);
                chart.CompositeChart.ChartLayers.Clear();

                chart.CompositeChart.ChartLayers.Add(columnLayer);
                chart.CompositeChart.Legends.Add(compositeLegend1);

                chart.CompositeChart.ChartLayers.Add(lineLayer);
                seriesLine2.PEs.Add(new PaintElement(Color.Blue));

                chart.ColumnChart.SeriesSpacing = 1;

                columnLayer.AxisX.Extent = 30;
                columnLayer.AxisY.Extent = 40;

                lineLayer.AxisX.Extent = 30;
                lineLayer.AxisY.Extent = 40;
                chart.LineChart.NullHandling = Infragistics.UltraChart.Shared.Styles.NullHandling.DontPlot;

                #endregion
            }


            catch (SqlException)
            {
                //this.ShowDialog(""+e, Windows.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {


        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {

        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;

            DBHelper helper = new DBHelper(false);
            System.Data.Common.DbParameter[] param = null;


            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PLANTCODE"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "사업장 코드 error!");
                            continue;
                        }
                    }
                    if (drRow["GOALTYPE"].ToString() == "GL" || drRow["GOALTYPE"].ToString() == "PR")
                    {

                        switch (drRow.RowState)
                        {
                            case DataRowState.Modified:
                                #region 수정
                                param = new System.Data.Common.DbParameter[16];

                                param[0] = helper.CreateParameter("@PLANTCODE", DBHelper.gGetCode(drRow["PlantCode"]), DbType.String, ParameterDirection.Input);
                                param[1] = helper.CreateParameter("@GOALYEAR", sYear, DbType.String, ParameterDirection.Input);
                                param[2] = helper.CreateParameter("@M01", DBHelper.gGetCode(drRow["M01"]), DbType.String, ParameterDirection.Input);
                                param[3] = helper.CreateParameter("@M02", DBHelper.gGetCode(drRow["M02"]), DbType.String, ParameterDirection.Input);
                                param[4] = helper.CreateParameter("@M03", DBHelper.gGetCode(drRow["M03"]), DbType.String, ParameterDirection.Input);
                                param[5] = helper.CreateParameter("@M04", DBHelper.gGetCode(drRow["M04"]), DbType.String, ParameterDirection.Input);
                                param[6] = helper.CreateParameter("@M05", DBHelper.gGetCode(drRow["M05"]), DbType.String, ParameterDirection.Input);
                                param[7] = helper.CreateParameter("@M06", DBHelper.gGetCode(drRow["M06"]), DbType.String, ParameterDirection.Input);
                                param[8] = helper.CreateParameter("@M07", DBHelper.gGetCode(drRow["M07"]), DbType.String, ParameterDirection.Input);
                                param[9] = helper.CreateParameter("@M08", DBHelper.gGetCode(drRow["M08"]), DbType.String, ParameterDirection.Input);
                                param[10] = helper.CreateParameter("@M09", DBHelper.gGetCode(drRow["M09"]), DbType.String, ParameterDirection.Input);
                                param[11] = helper.CreateParameter("@M10", DBHelper.gGetCode(drRow["M10"]), DbType.String, ParameterDirection.Input);
                                param[12] = helper.CreateParameter("@M11", DBHelper.gGetCode(drRow["M11"]), DbType.String, ParameterDirection.Input);
                                param[13] = helper.CreateParameter("@M12", DBHelper.gGetCode(drRow["M12"]), DbType.String, ParameterDirection.Input);
                                param[14] = helper.CreateParameter("@GOALTYPE", DBHelper.gGetCode(drRow["GOALTYPE"]), DbType.String, ParameterDirection.Input);
                                param[15] = helper.CreateParameter("@USER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input);

                                helper.ExecuteNoneQuery("USP_CM0410_U1", CommandType.StoredProcedure, param);

                                #endregion
                                break;
                        }
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PLANTCODE");
                helper.Commit();

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                if (param != null) { param = null; }
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
                    sPlcCode = DBHelper.nvlString(grid1.Rows[i].Cells["PLANTCODE"].Value);

                    idx = GetSeriesIndex(sPlcCode);

                    NumericTimeSeries n = (NumericTimeSeries)chart.Series[idx];
                    n.Points.Add(new NumericTimeDataPoint(DBHelper.nvlDateTime(grid1.Rows[i].Cells["01"].Value)
                                , DBHelper.nvlDouble(grid1.Rows[i].Cells["PLANTCODE"].Value), "", true));

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
        #endregion

        #region < EVENT AREA >
        /// <summary>
        /// Form이 Close 되기전에 발생
        /// e.Cancel을 true로 설정 하면, Form이 close되지 않음
        /// 수정 내역이 있는지를 확인 후 저장여부를 물어보고 저장, 저장하지 않기, 또는 화면 닫기를 Cancel 함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

        }
        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Modified)
            {
                e.Command.Parameters["@Editor"].Value = this.WorkerID;
                return;
            }

            if (e.Row.RowState == DataRowState.Added)
            {
                e.Command.Parameters["@Maker"].Value = this.WorkerID;
                return;
            }
        }

        /// <summary>
        /// 저장처리시 오류가 발생한 경우 오류 메세지에 대한 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Errors == null) return;

            switch (((SqlException)e.Errors).Number)
            {
                // 중복
                case 2627:
                    e.Row.RowError = "설비코드가 있습니다.";
                    throw (new SException("S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion

        #region < METHOD AREA >

        #endregion
    }
}

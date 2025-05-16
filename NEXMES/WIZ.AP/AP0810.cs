#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0810
//   Form Name    : 춸별 품목별 생산계획 추이
//   Name Space   : WIZ.AP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.UltraChart.Core.Layers;
using Infragistics.UltraChart.Core.Primitives;
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.UltraChart.Shared.Styles;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion
namespace WIZ.AP
{
    public partial class AP0810 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        Common _Common = new Common();
        #endregion

        #region<CONSTRUCTOR>
        public AP0810()
        {
            InitializeComponent();
            this.InitChart();
            BizTextBoxManager btbManager = new BizTextBoxManager();

            // TBM0100 : 품목
            // 1 : 품목, 2 : 품목명, param[0] : PlantCode, param[1] : ItemType
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
        }
        #endregion

        #region AP0810_Load
        private void AP0810_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅

            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);


            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "작업장", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "작업장명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TotQty", "합 계", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M01", "1 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M02", "2 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M03", "3 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M04", "4 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M05", "5 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M06", "6 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M07", "7 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M08", "8 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M09", "9 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M10", "10 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M11", "11 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M12", "12 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  // 사용유무, , MES적용유무
            WIZ.Common.FillComboboxMaster(this.cboYesNo, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");


            rtnDtTemp = _Common.GET_BM0000_CODE("DeptCode");  //팀구분
            WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DeptCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;
        }
        #endregion AP0810_Load

        #region<FUNCTION>
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "TotQty", "M01", "M02", "MO3", "M04", "MO5", "M06", "MO7", "M08", "M09", "M10", "M11", "M12" });
        }

        private ChartLayerAppearance lineLayer = new ChartLayerAppearance();

        public void InitChart()
        {

            ChartArea iChartArea = new ChartArea();

            // Create an X axis
            AxisItem xAxis = new AxisItem();
            xAxis.DataType = AxisDataType.String;
            xAxis.SetLabelAxisType = SetLabelAxisType.ContinuousData;
            xAxis.Labels.ItemFormatString = "<ITEM_LABEL>";
            xAxis.Margin.Far.Value = 2D;
            xAxis.ScrollScale.Visible = true;
            xAxis.Margin.Near.Value = 1.5D;
            xAxis.LineThickness = 1;
            xAxis.Extent = 70;

            // Create an Y axis
            AxisItem yAxis = new AxisItem();
            yAxis.axisNumber = AxisNumber.Y_Axis;
            yAxis.DataType = AxisDataType.Numeric;
            yAxis.Labels.ItemFormatString = "<DATA_VALUE:0.##>";
            yAxis.TickmarkStyle = AxisTickStyle.Smart;
            yAxis.ScrollScale.Visible = true;
            yAxis.LineThickness = 1;
            yAxis.Extent = 50;

            // Add the axes to the first ChartArea
            iChartArea.Axes.Add(xAxis);
            iChartArea.Axes.Add(yAxis);

            this.lineLayer.ChartArea = iChartArea;
            this.lineLayer.ChartType = ChartType.LineChart;
            this.lineLayer.AxisX = xAxis;
            this.lineLayer.AxisY = yAxis;


            this.ultraChart1.CompositeChart.ChartAreas.Add(iChartArea);
            this.ultraChart1.CompositeChart.ChartLayers.Add(this.lineLayer);

        }


        #region 조회

        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            Dictionary<string, NumericSeries> SeriesDict;

            try
            {
                this.lineLayer.Series.Clear();
                base.DoInquire();
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string SYyyy = string.Format("{0:yyyy}", cboYear_H.Value);
                string sItemCode = this.txtItemCode.Text.Trim();                                                     // 품목
                string sOpCode = this.txtOPCode.Text.Trim();
                string sYesNo = Convert.ToString(cboYesNo.Value);
                string sDeptCode = Convert.ToString(cboDeptCode.Value);

                rtnDtTemp = helper.FillTable("USP_AP0810_S1N"
                                             , CommandType.StoredProcedure
                                             , helper.CreateParameter("@PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("@Yyyy", SYyyy, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("@OPCode", sOpCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("@ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("@YesNo", sYesNo, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("@Param1", sDeptCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("@Param2", DBNull.Value, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("@Param3", DBNull.Value, DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();




                if (rtnDtTemp.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();
                    //----------------------------
                    DataTable dt = new DataTable();

                    dt.Columns.Add("OpCode", typeof(System.String));
                    dt.Columns.Add("OpName", typeof(System.String));
                    dt.Columns.Add("1월", typeof(System.Double));
                    dt.Columns.Add("2월", typeof(System.Double));
                    dt.Columns.Add("3월", typeof(System.Double));
                    dt.Columns.Add("4월", typeof(System.Double));
                    dt.Columns.Add("5월", typeof(System.Double));
                    dt.Columns.Add("6월", typeof(System.Double));
                    dt.Columns.Add("7월", typeof(System.Double));
                    dt.Columns.Add("8월", typeof(System.Double));
                    dt.Columns.Add("9월", typeof(System.Double));
                    dt.Columns.Add("10월", typeof(System.Double));
                    dt.Columns.Add("11월", typeof(System.Double));
                    dt.Columns.Add("12월", typeof(System.String));

                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    {
                        dt.Rows.Add(new object[] {
                              rtnDtTemp.Rows[i]["OpCode"].ToString(),
                              rtnDtTemp.Rows[i]["OpName"].ToString(),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["M01"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["M02"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["M03"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["M04"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["M05"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["M06"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["M07"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["M08"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["M09"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["M10"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["M11"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["M12"])
                          });
                    }


                    //********************** 시리즈 선언 **************************************************
                    SeriesDict = new Dictionary<string, NumericSeries>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SeriesDict.Add(dt.Rows[i]["OpCode"].ToString() + dt.Rows[i]["OpName"].ToString()
                                      , new NumericSeries());
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        this.lineLayer.Series.Add(SeriesDict[dt.Rows[i]["OpCode"].ToString() + dt.Rows[i]["OpName"].ToString()]);
                    }

                    this.ultraChart1.CompositeChart.ChartLayers.Add(this.lineLayer);

                    //********************** 시리즈 값 입력 **************************************************

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 2; j < dt.Columns.Count; j++)
                        {
                            SeriesDict[dt.Rows[i]["OpCode"].ToString() + dt.Rows[i]["OpName"].ToString()].Points.Add
                            (new NumericDataPoint(Convert.ToDouble((dt.Rows[i][j].ToString())), Convert.ToString(j - 1) + "월", false));
                            SeriesDict[dt.Rows[i]["OpCode"].ToString() + dt.Rows[i]["OpName"].ToString()].Label = dt.Rows[i]["OpCode"].ToString();
                        }
                    }
                    //********************** 범례  **************************************************
                    CompositeLegend myLegend = new CompositeLegend();
                    myLegend.ChartLayers.Add(this.lineLayer);
                    myLegend.Bounds = new Rectangle(3, 79, 97, 20);
                    myLegend.BoundsMeasureType = MeasureType.Percentage;
                    //myLegend.ChartComponent.Series.Add(); 
                    myLegend.LabelStyle.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    myLegend.PE.ElementType = PaintElementType.Gradient;
                    myLegend.PE.FillGradientStyle = Infragistics.UltraChart.Shared.Styles.GradientStyle.ForwardDiagonal;
                    myLegend.PE.Fill = Color.Azure;
                    myLegend.PE.FillStopColor = Color.Transparent;
                    myLegend.Border.CornerRadius = 10;
                    myLegend.Border.Thickness = 0;
                    this.ultraChart1.CompositeChart.Legends.Add(myLegend);

                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                helper.Close();
            }
        }
        #endregion 조회

        private void ultraChart1_ChartDrawItem(object sender, Infragistics.UltraChart.Shared.Events.ChartDrawItemEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Primitive.Path) || e.Primitive.Path.EndsWith("Legend") == false)
            {
                return;
            }

            Polyline polyline = e.Primitive as Polyline;
            if (polyline == null)
            {
                return;
            }

            polyline.PE.StrokeWidth = 10;
        }

        private void cboPlantCode_H_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPlantCode_H.Value != string.Empty)
            {
                rtnDtTemp = _Common.GET_BM0000_CODE("DEPTCODE", new string[] { "RELCODE1", cboPlantCode_H.Value.ToString() }); //사업장
                WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName,
                                                rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            }
            else
            {
                rtnDtTemp = _Common.GET_BM0000_CODE("DEPTCODE");  //사업장
                WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            }
        }
        #endregion
    }
}

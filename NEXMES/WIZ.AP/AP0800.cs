#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0800
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
    public partial class AP0800 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        #endregion

        #region<CONSTRUCTOR>
        public AP0800()
        {
            InitializeComponent();
            this.InitChart();
            BizTextBoxManager btbManager = new BizTextBoxManager();

            // TBM0100 : 품목
            // 1 : 품목, 2 : 품목명, param[0] : PlantCode, param[1] : ItemType
            btbManager.PopUpAdd(txtItemCode1, txtItemName1, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode2, txtItemName2, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode3, txtItemName3, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode4, txtItemName4, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode5, txtItemName5, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode6, txtItemName6, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode7, txtItemName7, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode8, txtItemName8, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode9, txtItemName9, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtItemCode10, txtItemName10, "TBM0100", new object[] { cboPlantCode_H, "" });

        }
        #endregion

        #region<FUNCTION>
        #region AP0800_Load
        private void AP0800_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TotQty", "합 계", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "jan", "1 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "feb", "2 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "mar", "3 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "apr", "4 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "may", "5 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "jun", "6 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "jul", "7 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "aug", "8 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "sep", "9 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "oct", "10 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "nov", "11 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "decs", "12 월", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  // 사용유무, , MES적용유무
            WIZ.Common.FillComboboxMaster(this.cboYesNo, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;
        }
        #endregion AP0800_Load

        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "TotQty", "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "decs" });
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
            try
            {
                this.lineLayer.Series.Clear();
                Dictionary<string, NumericSeries> SeriesDict;

                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string SYyyy = string.Format("{0:yyyy}", cboYear_H.Value);
                string sItemCode1 = this.txtItemCode1.Text.Trim();                                                    // 품목
                string sItemCode2 = this.txtItemCode2.Text.Trim();                                                    // 품목
                string sItemCode3 = this.txtItemCode3.Text.Trim();                                                    // 품목
                string sItemCode4 = this.txtItemCode4.Text.Trim();                                                    // 품목
                string sItemCode5 = this.txtItemCode5.Text.Trim();                                                    // 품목
                string sItemCode6 = this.txtItemCode6.Text.Trim();                                                    // 품목
                string sItemCode7 = this.txtItemCode7.Text.Trim();                                                    // 품목
                string sItemCode8 = this.txtItemCode8.Text.Trim();                                                    // 품목
                string sItemCode9 = this.txtItemCode9.Text.Trim();                                                    // 품목
                string sItemCode10 = this.txtItemCode10.Text.Trim();                                                  // 품목

                string sYesNo = Convert.ToString(cboYesNo.Value);
                rtnDtTemp = helper.FillTable("USP_AP0800_S1N", CommandType.StoredProcedure
                , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("YEAR", SYyyy, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("ITEMCODE1", sItemCode1, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("ITEMCODE2", sItemCode2, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("ITEMCODE3", sItemCode3, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("ITEMCODE4", sItemCode4, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("ITEMCODE5", sItemCode5, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("ITEMCODE6", sItemCode6, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("ITEMCODE7", sItemCode7, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("ITEMCODE8", sItemCode8, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("ITEMCODE9", sItemCode9, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("ITEMCODE10", sItemCode10, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("YesNo", sYesNo, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("Param1", DBNull.Value, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("Param2", DBNull.Value, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("Param3", DBNull.Value, DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();
                    //----------------------------
                    DataTable dt = new DataTable();

                    dt.Columns.Add("ItemCode", typeof(System.String));
                    dt.Columns.Add("ItemName", typeof(System.String));
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
                              rtnDtTemp.Rows[i]["ItemCode"].ToString(),
                              rtnDtTemp.Rows[i]["ItemName"].ToString(),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["jan"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["feb"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["mar"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["apr"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["may"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["jun"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["jul"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["aug"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["sep"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["oct"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["nov"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["decs"])
                          });
                    }


                    //********************** 시리즈 선언 **************************************************
                    SeriesDict = new Dictionary<string, NumericSeries>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SeriesDict.Add(dt.Rows[i]["ItemCode"].ToString() + dt.Rows[i]["ItemName"].ToString()
                                      , new NumericSeries());
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        this.lineLayer.Series.Add(SeriesDict[dt.Rows[i]["ItemCode"].ToString() + dt.Rows[i]["ItemName"].ToString()]);
                    }

                    this.ultraChart1.CompositeChart.ChartLayers.Add(this.lineLayer);

                    //********************** 시리즈 값 입력 **************************************************

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 2; j < dt.Columns.Count; j++)
                        {
                            SeriesDict[dt.Rows[i]["ItemCode"].ToString() + dt.Rows[i]["ItemName"].ToString()].Points.Add
                            (new NumericDataPoint(Convert.ToDouble((dt.Rows[i][j].ToString())), Convert.ToString(j - 1) + "월", false));
                            SeriesDict[dt.Rows[i]["ItemCode"].ToString() + dt.Rows[i]["ItemName"].ToString()].Label = dt.Rows[i]["ItemCode"].ToString();
                        }
                    }
                    //********************** 범례  **************************************************
                    CompositeLegend myLegend = new CompositeLegend();
                    myLegend.ChartLayers.Add(this.lineLayer);
                    myLegend.Bounds = new Rectangle(3, 79, 97, 20);
                    myLegend.BoundsMeasureType = MeasureType.Percentage;

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
        #endregion
    }
}

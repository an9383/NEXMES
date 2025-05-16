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
using Infragistics.Win.UltraWinChart;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.PM
{
    public partial class PM0100 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private string sChkCell = "first";
        private string save_plantcode = "820";
        private string save_Y00 = "2013";
        #endregion

        #region < CONSTRUCTOR >

        public PM0100()
        {
            InitializeComponent();
        }

        private void PM0100_Load(object sender, EventArgs e)
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

            _GridUtil.InitColumnUltraGrid(grid1, "MINORCODE", "팀코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CODENAME", "팀구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MONPRODNAME", "공수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MONPRODEFFECT", "공수코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LASTAVG", "전년도평균(%)", false, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,##0.0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "THISAVG", "이번년평균(%)", false, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,##0.0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "01", "1월", false, GridColDataType_emu.Double, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,##0.0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "02", "2월", false, GridColDataType_emu.Double, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,##0.0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "03", "3월", false, GridColDataType_emu.Double, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,##0.0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "04", "4월", false, GridColDataType_emu.Double, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,##0.0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "05", "5월", false, GridColDataType_emu.Double, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,##0.0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "06", "6월", false, GridColDataType_emu.Double, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,##0.0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "07", "7월", false, GridColDataType_emu.Double, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,##0.0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "08", "8월", false, GridColDataType_emu.Double, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,##0.0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "09", "9월", false, GridColDataType_emu.Double, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,##0.0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "10", "10월", false, GridColDataType_emu.Double, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,##0.0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "11", "11월", false, GridColDataType_emu.Double, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,##0.0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "12", "12월", false, GridColDataType_emu.Double, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,##0.0", null, null, null, null);


            //그리드 라인 색깔 해제
            //grid1.UseAppStyling = false;
            grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.Override.SelectTypeCell = SelectType.None;

            //데이터 머지 된 상태에서 그리드 컬럼 소트 기능 막기     
            grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            string[] sMergeColumn = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
            string[] sMergeColumn2 = { "MINORCODE", "CODENAME", "MONPRODNAME", "MONPRODEFFECT", "LASTAVG", "THISAVG" };
            string[] sMergeColumn3 = { "CODENAME", "MONPRODNAME" };
            string[] sMergeColumn4 = { "LASTAVG", "THISAVG" };
            string[] sHeadColumn = { "MINORCODE", "CODENAME", "MONPRODNAME", "MONPRODEFFECT", "LASTAVG", "THISAVG", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };

            _GridUtil.SetInitUltraGridBind(grid1);

            cbo_plantcode.Value = "820";

            #region Grid MERGE
            grid1.Columns["CODENAME"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["CODENAME"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["CODENAME"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE


            //그리드 머지
            _GridUtil.GridHeaderMerge(grid1, "G1", "년도", sMergeColumn, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G2", "", sMergeColumn2, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G3", "구분", sMergeColumn3, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G4", "평균", sMergeColumn4, sHeadColumn);


            #endregion

            #region Grid2 셋팅
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            //A.PLANTCODE , C.Value2 AS LASTYEAR,
            //     [01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12] from

            _GridUtil.InitColumnUltraGrid(grid2, "M00NAME", "구분", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "M00", "구분코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "problemremark", "문제점", false, GridColDataType_emu.VarChar, 300, 8000, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "analyremark", "원인분석", false, GridColDataType_emu.VarChar, 300, 8000, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "measureremark", "대책", false, GridColDataType_emu.VarChar, 300, 8000, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "deptremark", "담당부서", false, GridColDataType_emu.VarChar, 100, 1000, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "resultremark", "조치결과", false, GridColDataType_emu.VarChar, 100, 1000, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);


            grid2.DisplayLayout.Bands[0].Columns["problemremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            grid2.DisplayLayout.Bands[0].Columns["analyremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            grid2.DisplayLayout.Bands[0].Columns["measureremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            grid2.DisplayLayout.Bands[0].Columns["deptremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            grid2.DisplayLayout.Bands[0].Columns["resultremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;

            grid2.DisplayLayout.Override.DefaultRowHeight = 150;
            grid2.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;
            grid2.DisplayLayout.Bands[0].Columns["problemremark"].VertScrollBar = true;
            grid2.DisplayLayout.Bands[0].Columns["analyremark"].VertScrollBar = true;
            grid2.DisplayLayout.Bands[0].Columns["measureremark"].VertScrollBar = true;

            //그리드 라인 색깔 해제
            //grid2.UseAppStyling = false;
            grid2.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            grid2.DisplayLayout.Override.SelectTypeCell = SelectType.None;

            grid2.EnterNextRowEnable = false;

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_plantcode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion
        }

        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
            DBHelper helper = new DBHelper(false);

            try
            {
                sChkCell = "first";
                base.DoInquire();
                string sDtp_date = cbo_date.Value.ToString().Substring(0, 4);

                rtnDsTemp = helper.FillDataSet("USP_PM0100_S1", CommandType.StoredProcedure
                                                              , helper.CreateParameter("etc1", "", DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("etc2", "", DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("etc3", "", DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("Date", sDtp_date, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("Plantcode", cbo_plantcode.Value.ToString(), DbType.String, ParameterDirection.Input));

                string steamcode = rtnDsTemp.Tables[1].Rows[0]["Minorcode"].ToString();
                string steamcode2 = rtnDsTemp.Tables[1].Rows[1]["Minorcode"].ToString();


                int lastrow = rtnDsTemp.Tables[0].Rows.Count - 1;

                Hashtable hash = new Hashtable();

                foreach (DataRow drRow in rtnDsTemp.Tables[0].Rows)
                {
                    hash.Add(DBHelper.gGetCode(drRow["MINORCODE"]) + "|" + DBHelper.gGetCode(drRow["MONPRODEFFECT"]), drRow);
                }

                if (rtnDsTemp.Tables[0].Rows.Count > 0)
                {

                    DataTable rtnDtTemp2 = new DataTable();
                    rtnDtTemp2.Columns.Add("M00NAME", typeof(string));
                    rtnDtTemp2.Columns.Add("M00", typeof(string));
                    rtnDtTemp2.Columns.Add("problemremark", typeof(string));
                    rtnDtTemp2.Columns.Add("analyremark", typeof(string));
                    rtnDtTemp2.Columns.Add("measureremark", typeof(string));
                    rtnDtTemp2.Columns.Add("deptremark", typeof(string));
                    rtnDtTemp2.Columns.Add("resultremark", typeof(string));

                    rtnDtTemp2.Rows.Add(new object[] { "", "", "", "", "", "", "" });
                    grid2.DataSource = rtnDtTemp2;
                    grid2.DataBinds();

                    for (int i = rtnDsTemp.Tables[0].Columns.IndexOf("LASTAVG"); i < rtnDsTemp.Tables[0].Columns.Count; i++)
                    {
                        double result_Tm1 = Convert.ToDouble(Convert.ToDouble(((DataRow)hash[steamcode + "|" + "MonthST"])[i].ToString())); //오류
                        double result2_Tm1 = Convert.ToDouble(Convert.ToDouble(((DataRow)hash[steamcode + "|" + "MonthIN"])[i].ToString()));
                        double result_Tm2 = Convert.ToDouble(Convert.ToDouble(((DataRow)hash[steamcode2 + "|" + "MonthST"])[i].ToString()));
                        double result2_Tm2 = Convert.ToDouble(((DataRow)hash[steamcode2 + "|" + "MonthIN"])[i]);
                        ((DataRow)hash[steamcode + "|" + "MonthSUM"])[i] = (result_Tm1 == 0 || result2_Tm1 == 0) ? 0 : Convert.ToDouble((result_Tm1 / result2_Tm1) * 100);
                        ((DataRow)hash[steamcode2 + "|" + "MonthSUM"])[i] = (result_Tm2 == 0 || result2_Tm2 == 0) ? 0 : Convert.ToDouble((result_Tm2 / result2_Tm2) * 100);
                        rtnDsTemp.Tables[0].Rows[lastrow][i] = (result_Tm1 == 0 || result2_Tm2 == 0) ? 0 : Convert.ToDouble((((result_Tm1 / result2_Tm1) + (result_Tm2 / result2_Tm2)) / 2) * 100);

                    }
                    grid1.DataSource = rtnDsTemp.Tables[0];
                    grid1.DataBinds();



                    for (int i = grid1.Columns.IndexOf("LASTAVG"); i < grid1.Columns.Count; i++)
                    {

                        grid1.DisplayLayout.Rows[((DataRow)hash[steamcode + "|" + "MonthSUM"]).Table.Rows.IndexOf(((DataRow)hash[steamcode + "|" + "MonthSUM"]))].Cells[i].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        grid1.DisplayLayout.Rows[((DataRow)hash[steamcode2 + "|" + "MonthSUM"]).Table.Rows.IndexOf(((DataRow)hash[steamcode2 + "|" + "MonthSUM"]))].Cells[i].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                        if (grid1.Rows[0].Cells[1].Value.ToString() == "목  표")
                        {
                            grid1.DisplayLayout.Rows[0].Appearance.BackColor = Color.Blue;
                            grid1.DisplayLayout.Rows[0].Appearance.ForeColor = Color.White;
                            grid1.DisplayLayout.Rows[0].Appearance.FontData.SizeInPoints = 10;
                            grid1.DisplayLayout.Rows[0].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            grid1.Rows[0].Activation = Activation.NoEdit;
                        }

                        grid1.DisplayLayout.Rows[lastrow].Appearance.BackColor = Color.Red;
                        grid1.DisplayLayout.Rows[lastrow].Appearance.ForeColor = Color.White;
                        grid1.DisplayLayout.Rows[lastrow].Appearance.FontData.SizeInPoints = 10;
                        grid1.DisplayLayout.Rows[lastrow].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                        grid1.Rows[((DataRow)hash[steamcode + "|" + "MonthSUM"]).Table.Rows.IndexOf(((DataRow)hash[steamcode + "|" + "MonthSUM"]))].Activation = Activation.NoEdit;
                        grid1.Rows[((DataRow)hash[steamcode2 + "|" + "MonthSUM"]).Table.Rows.IndexOf(((DataRow)hash[steamcode2 + "|" + "MonthSUM"]))].Activation = Activation.NoEdit;
                        grid1.Rows[lastrow].Activation = Activation.NoEdit;
                    }
                }

                save_plantcode = cbo_plantcode.Value.ToString();
                save_Y00 = cbo_date.Value.ToString().Substring(0, 4);
                grid1.Columns["G1"].Header.Caption = cbo_date.Text + "년도";
                grid1.Columns["LASTAVG"].Header.Caption = Convert.ToInt16(cbo_date.Text) - 1 + "년도평균(%)";
                grid1.Columns["THISAVG"].Header.Caption = cbo_date.Text + "년도평균(%)";

                if (rtnDsTemp.Tables[0].Rows.Count > 0)
                {

                    DataTable mainDt = new DataTable();
                    mainDt.Columns.Add("월", typeof(string));
                    mainDt.Columns.Add("1팀", typeof(double));
                    mainDt.Columns.Add("2팀", typeof(double));
                    mainDt.Columns.Add("목적", typeof(double));
                    mainDt.Columns.Add("추이", typeof(double));

                    if (grid1.Rows.Count != 0)
                    {

                        mainDt.Rows.Add(new object[] {"전년도",
                            grid1.Rows[((DataRow)hash[steamcode + "|" + "MonthSUM"]).Table.Rows.IndexOf(((DataRow)hash[steamcode + "|" + "MonthSUM"]))].Cells["LASTAVG"].Value.ToString(),
                            grid1.Rows[((DataRow)hash[steamcode2 + "|" + "MonthSUM"]).Table.Rows.IndexOf(((DataRow)hash[steamcode2 + "|" + "MonthSUM"]))].Cells["LASTAVG"].Value.ToString(),

                            grid1.Rows[0].Cells[1].Value.ToString() == "목  표"  ? grid1.Rows[0].Cells["LASTAVG"].Value : 0 ,
                            grid1.Rows[lastrow].Cells["LASTAVG"].Value.ToString()});


                        mainDt.Rows.Add(new object[] {"현재",
                            grid1.Rows[((DataRow)hash[steamcode + "|" + "MonthSUM"]).Table.Rows.IndexOf(((DataRow)hash[steamcode + "|" + "MonthSUM"]))].Cells["THISAVG"].Value.ToString(),
                            grid1.Rows[((DataRow)hash[steamcode2 + "|" + "MonthSUM"]).Table.Rows.IndexOf(((DataRow)hash[steamcode2 + "|" + "MonthSUM"]))].Cells["THISAVG"].Value.ToString(),

                            grid1.Rows[0].Cells[1].Value.ToString() == "목  표"  ? grid1.Rows[0].Cells["THISAVG"].Value : 0 ,

                            grid1.Rows[lastrow].Cells["THISAVG"].Value.ToString()});


                        for (int i = 1; i < 13; i++)
                        {
                            mainDt.Rows.Add(new object[] {i+"월",grid1.Rows[((DataRow)hash[steamcode + "|" + "MonthSUM"]).Table.Rows.IndexOf(((DataRow)hash[steamcode + "|" + "MonthSUM"]))].Cells[i+5].Value.ToString(),
                                grid1.Rows[((DataRow)hash[steamcode2 + "|" + "MonthSUM"]).Table.Rows.IndexOf(((DataRow)hash[steamcode2 + "|" + "MonthSUM"]))].Cells[i+5].Value.ToString(),

                                grid1.Rows[0].Cells[1].Value.ToString() == "목  표"  ? grid1.Rows[0].Cells[i+5].Value : 0 ,
                                grid1.Rows[lastrow].Cells[i+5].Value.ToString()});
                        }
                    }

                    #region [차트 재생성]

                    UltraChart chart = new WIZ.Control.Chart();
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
                    chart.Size = new System.Drawing.Size(1124, 261);

                    chart.TabIndex = 232;
                    chart.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray;
                    chart.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray;
                    // chart.Margin = new System.Windows.Forms.Padding(50, 25, 50, 25);


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
                    //chart.Size = new System.Drawing.Size(1124, 300);
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
                    #endregion

                    #region [차트 바인딩]

                    area.Axes.Add(xAxisColumn);
                    area.Axes.Add(xAxisLine);
                    area.Axes.Add(yAxis);

                    NumericSeries seriesColumn = new NumericSeries();
                    seriesColumn.Data.DataSource = mainDt;
                    seriesColumn.Data.LabelColumn = "월";
                    seriesColumn.Data.ValueColumn = "1팀";

                    NumericSeries seriesColumn2 = new NumericSeries();
                    seriesColumn2.Data.DataSource = mainDt;
                    seriesColumn2.Data.LabelColumn = "월";
                    seriesColumn2.Data.ValueColumn = "2팀";

                    NumericSeries seriesLine = new NumericSeries();
                    seriesLine.Data.DataSource = mainDt;
                    // seriesLine.Data.LabelColumn = "추이";
                    seriesLine.Data.ValueColumn = "추이";

                    NumericSeries seriesLine2 = new NumericSeries();
                    seriesLine2.Data.DataSource = mainDt;
                    //  seriesLine2.Data.LabelColumn = "목적";
                    seriesLine2.Data.ValueColumn = "목적";

                    chart.Series.AddRange(new Infragistics.UltraChart.Data.Series.ISeries[] { seriesLine, seriesLine2, seriesColumn, seriesColumn2 });

                    ChartLayerAppearance columnLayer = new ChartLayerAppearance();
                    columnLayer.AxisX = xAxisColumn;
                    columnLayer.AxisX.ScrollScale.Visible = true;
                    columnLayer.AxisY = yAxis;

                    columnLayer.AxisY.ScrollScale.Visible = true;

                    columnLayer.ChartArea = area;
                    columnLayer.ChartType = ChartType.ColumnChart;
                    columnLayer.Series.Add(seriesColumn);
                    columnLayer.Series.Add(seriesColumn2);
                    columnLayer.SwapRowsAndColumns = true;


                    ChartLayerAppearance lineLayer = new ChartLayerAppearance();
                    lineLayer.AxisX = xAxisLine;
                    lineLayer.AxisY = yAxis;
                    lineLayer.AxisY.TickmarkStyle = AxisTickStyle.Smart;

                    lineLayer.ChartArea = area;
                    lineLayer.ChartType = ChartType.LineChart;
                    lineLayer.Series.Add(seriesLine);
                    lineLayer.Series.Add(seriesLine2);

                    chart.CompositeChart.ChartLayers.Add(columnLayer);
                    chart.CompositeChart.ChartLayers.Add(lineLayer);
                    chart.ColumnChart.SeriesSpacing = 1;

                    columnLayer.AxisX.Extent = 30;
                    columnLayer.AxisY.Extent = 40;

                    lineLayer.AxisX.Extent = 30;
                    lineLayer.AxisY.Extent = 40;


                    #endregion
                }
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
        /// 



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
            this.Focus();

            if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                return;

            base.DoSave();



            foreach (DataRow drRow in dt.Rows)
            {
                if (drRow.RowState != DataRowState.Deleted)
                {
                    if (drRow["MINORCODE"].ToString().Trim() == "")
                    {
                        grid1.SetRowError(drRow, "팀코드 error!");
                        continue;
                    }
                }
                switch (drRow.RowState)
                {
                    case DataRowState.Modified:

                        #region 수정

                        if (Convert.ToString(drRow["MONPRODEFFECT"]) == "MonthSUM")
                        {
                            continue;
                        }

                        for (int i = 6; i < 18; i++)
                        {

                            if (Convert.ToString(drRow[i]) != string.Empty)
                            {

                                DBHelper helper = new DBHelper(false);

                                try
                                {


                                    helper.ExecuteNoneQuery("USP_PM0100_I1", CommandType.StoredProcedure
                                                                           , helper.CreateParameter("plantcode", save_plantcode, DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("deptcode", Convert.ToString(drRow["MINORCODE"]), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("Monprodeffect", Convert.ToString(drRow["MONPRODEFFECT"]), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("Y00", save_Y00, DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("M00", grid1.Columns[i].Key, DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("RstValue", Convert.ToString(drRow[i]), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("USER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                                    helper.Commit();
                                }
                                catch (Exception ex)
                                {
                                    helper.Rollback();
                                    MessageBox.Show(ex.ToString());
                                }
                                finally
                                {
                                    helper.Close();
                                }

                            }
                        }
                        break;
                        #endregion
                }

            }

            this.grid2.UpdateGridData();
            if (grid2.Rows.Count >= 1)
            {
                if (grid2.Rows[0].Cells["problemRemark"].Value.ToString().Trim() == string.Empty &&
                    grid2.Rows[0].Cells["analyremark"].Value.ToString().Trim() == string.Empty &&
                    grid2.Rows[0].Cells["measureremark"].Value.ToString().Trim() == string.Empty &&
                    grid2.Rows[0].Cells["deptremark"].Value.ToString().Trim() == string.Empty &&
                    grid2.Rows[0].Cells["resultremark"].Value.ToString().Trim() == string.Empty
                    )
                {
                    return;
                }

                if (grid2.Rows[0].Cells["M00"].Value.ToString() != string.Empty)
                {

                    DBHelper helper = new DBHelper(false);

                    try
                    {

                        helper.ExecuteNoneQuery("USP_PM0100_I2", CommandType.StoredProcedure
                                                               , helper.CreateParameter("plantcode", save_plantcode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("targetclass", "CL01", DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("Y00", save_Y00, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("M00", Convert.ToString(grid2.Rows[0].Cells["M00"].Value.ToString()), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("problemRemark", Convert.ToString(grid2.Rows[0].Cells["problemremark"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("analyremark", Convert.ToString(grid2.Rows[0].Cells["analyremark"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("measureremark", Convert.ToString(grid2.Rows[0].Cells["measureremark"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("deptremark", Convert.ToString(grid2.Rows[0].Cells["deptremark"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("resultremark", Convert.ToString(grid2.Rows[0].Cells["resultremark"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("USER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                        grid1.SetAcceptChanges("PlanNo");
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        helper.Close();
                    }
                }
            }
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
                e.Command.Parameters["Editor"].Value = this.WorkerID;
                return;
            }

            if (e.Row.RowState == DataRowState.Added)
            {
                e.Command.Parameters["Maker"].Value = this.WorkerID;
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
        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {

            if (e.Cell.Column.Header.Column.ToString().Trim().Length > 3)
            {
                return;
            }

            if (sChkCell == e.Cell.Column.Header.Column.ToString())
            {
                return;
            }


            if (e.Cell.Column.Header.Column.ToString() != "")
            {
                string sM00 = e.Cell.Column.Header.Column.ToString();
                string sM00NAME = e.Cell.Column.Header.Caption.ToString();

                DBHelper helper = new DBHelper(false);

                try
                {
                    DataTable rtnDtTemp = helper.FillTable("USP_PM0100_S2", CommandType.StoredProcedure
                                                                , helper.CreateParameter("etc1", "", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("etc2", "", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("etc3", "", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("plantcode", save_plantcode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("targetclass", "CL01", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("Y00", save_Y00, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("M00", sM00, DbType.String, ParameterDirection.Input));
                    if (rtnDtTemp.Rows.Count == 0)
                    {
                        rtnDtTemp.Rows.Add(new object[] { sM00NAME, sM00, "", "", "", "", "" });
                    }
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds();
                }

                catch (Exception ex)
                {
                    // helper.Rollback();
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    helper.Close();
                    sChkCell = e.Cell.Column.Header.Column.ToString();
                }
            }
        }
        #endregion
    }
}


#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PT0300
//   Form Name    : 생산 계획 대비 실적(품목별)
//   Name Space   : WIZ.AP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.UltraChart.Shared.Styles;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
#endregion

namespace WIZ.PP
{
    using WIZ.Forms;

    public partial class PT0300 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        private NumericSeries seriesQ = new NumericSeries();
        #endregion

        #region<CONSTRUCTOR>

        public PT0300()
        {
            InitializeComponent();
        }
        #endregion

        #region<METHOD AREA>
        private void InitChart()
        {

        }

        private ChartLayerAppearance lineLayer = new ChartLayerAppearance();

        private void DoChart()
        {

            if (rtnDtTemp.Rows.Count > 0)
            {

                NumericSeries series = new NumericSeries();
                DataTable table = new DataTable();

                table.Columns.Add("공장", typeof(string));
                table.Columns.Add("생산실적", typeof(double));
                table.Columns.Add("불량실적", typeof(double));
                if (grid1.Rows.Count != 0)
                {
                    for (int i = 0; i < this.rtnDtTemp.Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] {
                              rtnDtTemp.Rows[i]["PLANTCODE"].ToString(),
                               rtnDtTemp.Rows[i]["ProdQty"].ToString(),
                              rtnDtTemp.Rows[i]["ErrorQty"].ToString()
                     });
                    }
                }

                ultraChart1.Visible = true;

                ultraChart1.Data.DataSource = table;
                ultraChart1.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;
                ultraChart1.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                series.DataBind();

                //그래프 최대값 조절 소스
                double MaxRange = 0;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    double worktime = Convert.ToDouble(table.Rows[i]["생산실적"]);
                    double nonworktime = Convert.ToDouble(table.Rows[i]["불량실적"]);

                    MaxRange = MaxRange > worktime ? MaxRange : worktime; //참이면 왼쪽꺼 거짓이면 오른쪽 꺼
                    MaxRange = MaxRange > nonworktime ? MaxRange : nonworktime;
                }

                if (ultraChart1.Axis.Y.RangeType != AxisRangeType.Custom)
                    ultraChart1.Axis.Y.RangeType = AxisRangeType.Custom;

                ultraChart1.Axis.Y.RangeMax = MaxRange * 1.25;

                ultraChart1.Data.DataBind();

                ////************************   컬럼 차트 데이터 값 표시 *********************************

                //for (int k = 0; k < table.Rows.Count; k++)
                //{
                //    ChartTextAppearance PlantValue = new ChartTextAppearance();
                //    ChartTextAppearance ResultValue = new ChartTextAppearance();

                //    PlantValue.Row = k;
                //    PlantValue.Column = k;
                //    ResultValue.Row = k;
                //    ResultValue.Column = k;


                //    PlantValue.ItemFormatString = table.Rows[k]["계획량"].ToString();
                //    PlantValue.ItemFormatString = "<DATA_VALUE:0.#>";
                //    PlantValue.VerticalAlign = StringAlignment.Far;
                //    PlantValue.Visible = true;

                //    ResultValue.ItemFormatString = table.Rows[k]["생산량"].ToString();
                //    ResultValue.ItemFormatString = "<DATA_VALUE:0.#>";
                //    ResultValue.VerticalAlign = StringAlignment.Far;
                //    ResultValue.Visible = true;


                //    this.ultraChart1.ColumnChart.ChartText.Add(PlantValue);
                //    this.ultraChart1.ColumnChart.ChartText.Add(ResultValue);

                //    PlantValue.ChartTextFont = new Font("맑은고딕", 10f);
                //    PlantValue.FontColor = Color.Black;
                //    ResultValue.ChartTextFont = new Font("맑은고딕", 10f);
                //    ResultValue.FontColor = Color.Black;
                //}
            }
            else
            {
                ultraChart1.Series.Clear();
                ultraChart1.Visible = false;
            }
        }

        private void PT0300_Load(object sender, EventArgs e)
        {
            DoChart();

            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            _GridUtil.InitColumnUltraGrid(grid1, "RecDate", "일자", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdQty", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorQty", "불량수량", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ResultValue", "양품률(%)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "TimeEffect", "가동률", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목",            false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명",           false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "PlanQty", "계획량",            false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,###", null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "ProdQty", "생산량",            false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,###", null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위",             false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "Rate", "달성률",              false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion
        }

        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "PlanQty", "ProdQty" });

            if (ugr != null)
            {
                ugr.Cells["Rate"].Value = Math.Round(DBHelper.nvlDouble(ugr.Cells["ProdQty"].Value) / DBHelper.nvlDouble(ugr.Cells["PlanQty"].Value) * 100.0, 1).ToString() + "%";
            }
        }

        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);                                            // 시작 일자
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);                                                // 종료 일자                           // 년도 

                rtnDtTemp = helper.FillTable("USP_PT0300_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input));



                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();
                //_Common.Grid_Column_Width(this.grid1); //grid 정리용   

                DoChart();

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void cboPlantCode_H_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboPlantCode_H.Value != "")
            //{
            //    rtnDtTemp = _Common.GET_TBM0000_CODE("DEPTCODE", new string[] { "RELCODE1", cboPlantCode_H.Value.ToString() }); //사업장
            //    WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName,
            //                                    rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //    WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //}
            //else
            //{
            //    rtnDtTemp = _Common.GET_TBM0000_CODE("DEPTCODE", @"ISNULL(RELCODE1, '') != '' ");  //사업장
            //    WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //    WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //}
        }
        #endregion
    }
}
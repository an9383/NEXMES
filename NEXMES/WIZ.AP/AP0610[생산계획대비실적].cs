#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0610
//   Form Name    : 생산 계획 대비 실적(공정별)
//   Name Space   : WIZ.AP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.UltraChart.Resources.Appearance;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP0610 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable dtTemp = new DataTable();
        DataTable rtnDtTemp = new DataTable();

        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        #endregion

        #region< CONSTRUCTOR >
        public AP0610()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });

            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });
            gridManager.PopUpAdd("OPCode", "OPName", "TBM0400", new string[] { "PlantCode", "" });
        }

        //private ChartLayerAppearance lineLayer = new ChartLayerAppearance();
        #endregion

        #region<FUNCTION>
        private void DoChart()
        {
            if (dtTemp.Rows.Count > 0)
            {

                NumericSeries series = new NumericSeries();

                DataTable table = new DataTable();

                table.Columns.Add("공정", typeof(string));
                table.Columns.Add("계획량", typeof(double));
                table.Columns.Add("생산량", typeof(double));

                if (grid1.Rows.Count != 0)
                {
                    for (int i = 0; i < this.dtTemp.Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] {
                                                     dtTemp.Rows[i]["OPNAME"].ToString(),
                                                     dtTemp.Rows[i]["PLANQTY"].ToString(),
                                                     dtTemp.Rows[i]["PRODQTY"].ToString()
                                                    });
                    }
                }

                ultraChart1.Visible = true;

                ultraChart1.Data.DataSource = table;
                ultraChart1.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;
                ultraChart1.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                series.DataBind();

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

        private void AP0610_Load(object sender, EventArgs e)
        {
            DoChart();

            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLAN_TYPE", "긴급여부", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANQTY", "계획량", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", "nnn,nnn,nnn", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산량", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", "nnn,nnn,nnn", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RATE", "계획대비(%)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            radioBtn2.Checked = true;
        }

        public override void DoBaseSum()
        {
            //base.DoBaseSum();

            //UltraGridRow ugr = grid1.DoSummaries(new string[] { "PlanQty", "ProdQty" });

            //if (ugr != null)
            //{
            //    ugr.Cells["Rate"].Value = Math.Round(Convert.ToDouble(ugr.Cells["ProdQty"].Value) / Convert.ToDouble(ugr.Cells["PlanQty"].Value) * 100.0, 1).ToString() + "%";
            //}
        }

        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);
                string sOPCode = this.txtOPCode.Text.Trim();
                string sParam1 = string.Empty;

                if (radioBtn1.Checked == true)
                    sParam1 = "Y";
                else
                    sParam1 = "N";

                dtTemp = helper.FillTable("USP_AP0610_S1N", CommandType.StoredProcedure
                                                          , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("OPCODE", sOPCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("PARAM1", sParam1, DbType.String, ParameterDirection.Input));

                grid1.DataSource = dtTemp;
                grid1.DataBinds();

                DoChart();
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion
    }
}
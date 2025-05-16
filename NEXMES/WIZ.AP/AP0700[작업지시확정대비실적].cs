#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0700
//   Form Name    : 지시할당 대비 실적
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
    public partial class AP0700 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable dtTemp = new DataTable();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        #endregion

        #region< CONSTRUCTOR >
        public AP0700()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, txtOPCode, "", "" });

            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });
            gridManager.PopUpAdd("OPCode", "OPName", "TBM0400", new string[] { "PlantCode", "" });
            gridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "TBM0600", new string[] { "PLANTCODE", "OPCODE", "", "" });
        }
        private ChartLayerAppearance lineLayer = new ChartLayerAppearance();
        #endregion

        #region<FUNCTION>
        private void DoChart()
        {
            if (dtTemp.Rows.Count > 0)
            {
                NumericSeries series = new NumericSeries();
                DataTable table = new DataTable();

                table.Columns.Add("품목명", typeof(string));
                table.Columns.Add("지시량", typeof(double));
                table.Columns.Add("생산량", typeof(double));

                if (grid1.Rows.Count != 0)
                {
                    for (int i = 0; i < this.dtTemp.Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] {
                                                    dtTemp.Rows[i]["ItemName"].ToString(),
                                                    dtTemp.Rows[i]["OrderQty"].ToString(),
                                                    dtTemp.Rows[i]["ProdQty"].ToString()
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

        private void AP0700_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "지시일자", false, GridColDataType_emu.YearMonthDay, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FASTORDERFLAG", "긴급여부", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CARTYPE", "차종", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시량", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###", "nnn,nnn,nnn", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산량", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###", "nnn,nnn,nnn", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANPRODQTY", "계획대비(%)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("CARTYPE");
            WIZ.Common.FillComboboxMaster(this.cboCarType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CARTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion
        }

        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sStartDate = string.Format("{0:yyyy-MM-dd}", this.CboStartdate_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", this.CboEnddate_H.Value);
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value) == "ALL" ? "" : Convert.ToString(this.cboPlantCode_H.Value);  // 공장코드                           
                string sOPCode = txtOPCode.Text.Trim();
                string sLineCode = "";
                string sItemCode = txtItemCode.Text.Trim();
                string sWorkCenterCode = txtLineCode.Text.Trim();
                string sCarType = Convert.ToString(cboCarType.Value);

                dtTemp = helper.FillTable("USP_AP0700_S2N", CommandType.StoredProcedure
                                                          , helper.CreateParameter("STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("OPCODE", sOPCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("LINECODE", sLineCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("CARTYPE", sCarType, DbType.String, ParameterDirection.Input)
                                                          );

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
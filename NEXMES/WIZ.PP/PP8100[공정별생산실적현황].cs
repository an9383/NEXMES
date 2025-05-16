#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP8100
//   Form Name    : 생산실적 조회
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.UltraChart.Resources.Appearance;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP8100 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        #endregion

        #region<METHOD AREA>
        public PP8100()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            //품목
            btbManager.PopUpAdd(txtItemCode, txtItemName, "BM0010", new object[] { cboPlantCode_H, "", "Y" });
            //작업장
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "BM0060", new object[] { cboPlantCode_H, "", "", "" });
            //공정
            btbManager.PopUpAdd(txtOPCode, txtOPName, "BM0040", new object[] { cboPlantCode_H, "", "" });

            CboStartdate_H.Value = DateTime.Now.AddDays(-3);
            CboEnddate_H.Value = DateTime.Now;

        }
        private ChartLayerAppearance lineLayer = new ChartLayerAppearance();

        private void DoChart()
        {

            if (rtnDtTemp.Rows.Count > 0)
            {

                NumericSeries series = new NumericSeries();
                DataTable table = new DataTable();

                table.Columns.Add("공정", typeof(string));
                table.Columns.Add("지시량", typeof(double));
                table.Columns.Add("생산량", typeof(double));
                if (grid1.Rows.Count != 0)
                {
                    for (int i = 0; i < this.rtnDtTemp.Rows.Count; i++)
                    {
                        table.Rows.Add(new object[]
                              {
                              rtnDtTemp.Rows[i]["OPNAME"].ToString(),
                              rtnDtTemp.Rows[i]["ORDERQTY"].ToString(),
                              rtnDtTemp.Rows[i]["PRODQTY"].ToString()
                              });
                    }
                }

                ultraChart1.Visible = true;
                ultraChart1.Data.DataSource = table;
                ultraChart1.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;
                ultraChart1.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                series.DataBind();
                ultraChart1.Data.DataBind();

            }
            else
            {
                ultraChart1.Series.Clear();
                ultraChart1.Visible = false;
            }
        }

        private void PP8100_Load(object sender, EventArgs e)
        {
            DoChart();

            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "지시일자", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "LOT NO.", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명명", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시계획량", false, GridColDataType_emu.IntegerPositive, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산량", false, GridColDataType_emu.IntegerPositive, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RATE", "생산률", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MANHR", "투입공수", false, GridColDataType_emu.IntegerPositive, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스

            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion
        }

        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();                  // 사업장(공장)
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);                                            // 시작 일자
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);                                                // 종료 일자                           
                string sOPCode = this.txtOPCode.Text.Trim();                                                                          // 품목
                string sWorkCenterCode = this.txtWorkCenterCode.Text.Trim();
                string sItemCode = this.txtItemCode.Text.Trim();

                rtnDtTemp = helper.FillTable("USP_PP8100_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("OPCODE", sOPCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));
                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds(rtnDtTemp);

                DoChart();

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
        #endregion
    }
}

#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0710
//   Form Name    : 작업호기(WorkCenter)별  실적 정보 조회
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0710 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMEBER AREA >
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region < CONSTRUCTOR >
        public PP0710()
        {
            InitializeComponent();
        }
        #endregion

        #region < PP0710_Load >
        private void PP0710_Load(object sender, EventArgs e)
        {
            DoChart();

            #region --- Grid Setting ---
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "작업장", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "작업장명", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업라인", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업라인명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHT", "주야구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHTNM", "주야", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODDATE", "생산일시", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비코드", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "설비카운트", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "Lot No", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CAVITY", "Cavity", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SHIFTGB", "조구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERID", "작업자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SOURCEINFO", "소스정보", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTALFLAG", "집계여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region --- ComboBox Setting ---
            Common _Common = new Common();
            //DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            CboStartdate_H.Value = DateTime.Now.AddDays(-7);
            CboEnddate_H.Value = DateTime.Now;
            #endregion

            #region --- POP-Up Setting ---
            //팝업 매니저
            BizTextBoxManager btbManager = new BizTextBoxManager();
            //공정
            btbManager.PopUpAdd(txtOPCode, txtOPName, "BM0040", new object[] { cboPlantCode_H, "", "" });
            //작업장
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "BM0060", new object[] { cboPlantCode_H, "", "", "" });
            //품목
            btbManager.PopUpAdd(txtItemCode, txtItemName, "BM0010", new object[] { cboPlantCode_H, "", "Y" });

            //btbManager.PopUpAdd(txtOPCode, txtOPName, "BM0040", new object[] { cboPlantCode_H, "" });
            //btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });
            //btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
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
            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);              // 사업장(공장)
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);      // 생산시작일자
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);          // 생산  끝일자
                string sWorkCenterCode = this.txtWorkCenterCode.Text.Trim();                    // 작업장 코드
                string sOPCode = this.txtOPCode.Text.Trim();                                    // 공정 코드
                string sLineCode = string.Empty;                                                // 라인 코드
                string sItemCode = this.txtItemCode.Text.Trim();                                // 품목
                string sDayNight = string.Empty;                                                // 주야 구분
                string sShiftGb = string.Empty;                                                 // 근무 
                string sLotNo = string.Empty;                                                   // LOT No
                string sDeptCode = string.Empty;                                                //팀구분

                rtnDtTemp = helper.FillTable("USP_PP0710_S2N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCODE", sOPCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LINECODE", sLineCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DAYNIGHT", sDayNight, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("SHIFTGB", sShiftGb, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DEPTCODE", sDeptCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PARAM1", DBNull.Value, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PARAM2", DBNull.Value, DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds(rtnDtTemp);
                DoChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region <METHOD AREA>
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "PRODQTY" });
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

        #endregion
    }
}
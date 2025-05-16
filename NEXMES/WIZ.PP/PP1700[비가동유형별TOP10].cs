#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP1700
//   Form Name    : 비가동 유형별 TOP10
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
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP1700 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        #endregion

        #region<CONSTRUCTOR>
        public PP1700()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtOPCode, txtOPName, "BM0040", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "BM0060", new object[] { cboPlantCode_H, "", "", "" });

        }
        #endregion

        #region PP1700_Load
        private void PP1700_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCLASS", "비가동유형", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCLASSNM", "비가동\n\r유형명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPTYPE", "비가동구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPTYPENM", "비가동\n\r구분명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCODE", "비가동", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPDESC", "비가동명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUSTIME", "소요시간(H)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스 셋팅
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("STOPCLASS");  //비가동 유형
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STOPCLASS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("STOPTYPE");  //비가동 타입
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STOPTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            CboStartdate_H.Value = DateTime.Now.AddDays(-365);
            CboEnddate_H.Value = DateTime.Now;
            #endregion 콤보박스 셋팅

            this.ultraChart1.EmptyChartText = string.Empty;
            this.ultraChart2.EmptyChartText = string.Empty;
        }
        #endregion PP1700_Load

        #region<Event>
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "STATUSTIME" });
        }

        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);          //사업장코드
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);
                string sWorkcenterCode = txtWorkCenterCode.Text.Trim();
                string sOPCode = txtOPCode.Text.Trim();

                grid1.DataSource = helper.FillTable("USP_PP1700_S1", CommandType.StoredProcedure
                                            , helper.CreateParameter("STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("OPCODE", sOPCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();

                if (grid1.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();

                    NumericSeries series = new NumericSeries();
                    series.Data.DataSource = grid1.DataSource;
                    series.Data.LabelColumn = "STOPDESC";
                    series.Data.ValueColumn = "STATUSTIME";
                    ultraChart1.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;
                    ultraChart1.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                    series.DataBind();

                    ultraChart1.Series.Add(series);
                    ultraChart1.Data.DataBind();

                    ultraChart2.Series.Add(series);
                    ultraChart2.Data.DataBind();
                }
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
        #endregion

    }
}

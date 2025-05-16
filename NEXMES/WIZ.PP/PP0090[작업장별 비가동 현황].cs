#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0090
//   Form Name    : 작업장별 비가동 현황
//   Name Space   : WIZ.PP
//   Created Date : 2018-01-24
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 작업장별 비가동 현황 조회
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0090 : WIZ.Forms.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataSet rtnDsTemp = new DataSet();      // return DataSet 공통
        DataTable rtnDtTemp = new DataTable();  // return DataTable 공통
        DataTable _DtTemp = new DataTable();

        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        BizTextBoxManager btbManager = new BizTextBoxManager();

        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        int iCnt = 0;
        #endregion

        #region < CONSTRUCTOR >
        public PP0090()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PP0090_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 작업장별 비가동 현황 (전체)
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STOPCNT", "비가동건수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STATUSTIME", "비가동시간(분)", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false);

                grid1.Columns["STOPCNT"].Format = "#,##0";
                grid1.Columns["STATUSTIME"].Format = "#,##0.00";

                grid1.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
                grid1.DisplayLayout.Bands[0].Summaries.Add("합계", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"]);
                grid1.DisplayLayout.Bands[0].Summaries[0].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"];
                grid1.DisplayLayout.Bands[0].Summaries[0].DisplayFormat = "합계";
                grid1.DisplayLayout.Bands[0].Summaries[0].Key = "WORKCENTERCODE";
                grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.TextHAlign = HAlign.Center;
                grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.FontData.SizeInPoints = 9;
                grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.BackColor = Color.FromArgb(140, 190, 230);
                grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.ForeColor = Color.Black;
                grid1.DisplayLayout.Bands[0].Summaries[0].SummaryDisplayArea = SummaryDisplayAreas.Bottom;

                grid1.DisplayLayout.Bands[0].Summaries.Add("SUM([STOPCNT])", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["STOPCNT"]);
                grid1.DisplayLayout.Bands[0].Summaries[1].DisplayFormat = "{0:#,##0}";
                grid1.DisplayLayout.Bands[0].Summaries[1].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["STOPCNT"];
                grid1.DisplayLayout.Bands[0].Summaries[1].Key = "STOPCNT";
                grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.TextHAlign = HAlign.Right;
                grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.FontData.SizeInPoints = 9;
                grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.BackColor = Color.FromArgb(140, 190, 230);
                grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.ForeColor = Color.Black;
                grid1.DisplayLayout.Bands[0].Summaries[1].SourceColumn.Format = "#,##0";
                grid1.DisplayLayout.Bands[0].Summaries[1].SummaryPositionColumn.Format = "#,##0";
                grid1.DisplayLayout.Bands[0].Summaries[1].SummaryDisplayArea = SummaryDisplayAreas.Bottom;
                grid1.DisplayLayout.Bands[0].Summaries[1].SummaryType = SummaryType.Sum;

                grid1.DisplayLayout.Bands[0].Summaries.Add("SUM([STATUSTIME])", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["STATUSTIME"]);
                grid1.DisplayLayout.Bands[0].Summaries[2].DisplayFormat = "{0:#,##0.00}";
                grid1.DisplayLayout.Bands[0].Summaries[2].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["STATUSTIME"];
                grid1.DisplayLayout.Bands[0].Summaries[2].Key = "STATUSTIME";
                grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.TextHAlign = HAlign.Right;
                grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.FontData.SizeInPoints = 9;
                grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.BackColor = Color.FromArgb(140, 190, 230);
                grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.ForeColor = Color.Black;
                grid1.DisplayLayout.Bands[0].Summaries[2].SourceColumn.Format = "#,##0.00";
                grid1.DisplayLayout.Bands[0].Summaries[2].SummaryPositionColumn.Format = "#,##0.00";
                grid1.DisplayLayout.Bands[0].Summaries[2].SummaryDisplayArea = SummaryDisplayAreas.Bottom;
                grid1.DisplayLayout.Bands[0].Summaries[2].SummaryType = SummaryType.Sum;


                _GridUtil.SetInitUltraGridBind(grid1);
                grid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;

                //GRID6 작업장별 비가동 현황 (상세)
                _GridUtil.InitializeGrid(this.grid2, true, true, false, "", true);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "RECDATE", "일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "STOPTYPE", "비가동구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "STOPCODE", "비가동코드", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "STARTDATE", "시작시간", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ENDDATE", "종료시간", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "STATUSTIME", "비가동시간(분)", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKERCNT", "비가동인원", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKERGS", "비가동공수", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);

                grid2.Columns["STATUSTIME"].Format = "#,##0.00";
                grid2.Columns["WORKERCNT"].Format = "#,##0";
                grid2.Columns["WORKERGS"].Format = "#,##0.00";

                _GridUtil.SetInitUltraGridBind(grid2);
                grid2.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;
                cbo_PLANTCODE_H.Select();

                rtnDtTemp = _Common.GET_BM0060_CODE("");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("STOPTYPE");  //비가동구분
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "STOPTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.Common.FillComboboxMaster(this.cbo_STOPTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");

                rtnDtTemp = GET_BM0110_CODE(Convert.ToString(this.cbo_PLANTCODE_H.Value));
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "STOPCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;
                #endregion

                #region POPUP SETTING
                //작업장
                btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });

                //비가동
                btbManager.PopUpAdd(txt_STOPCODE_H, txt_STOPNAME_H, "BM0110", new object[] { cbo_PLANTCODE_H, cbo_STOPTYPE_H, "", "" });

                #endregion
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(Common.getLangText(ex.Message, "TEXT"), Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sWorkcenterCode = txt_WORKCENTERCODE_H.Text.Trim();
                string sStopType = DBHelper.nvlString(cbo_STOPTYPE_H.Value);
                string sStopCode = txt_STOPCODE_H.Text.Trim();
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                string LS_TABIDX = string.Empty;
                if (tabControl1.SelectedTab.Index == 0) LS_TABIDX = "TAB1";
                else LS_TABIDX = "TAB2";

                rtnDtTemp = helper.FillTable("USP_PP0090_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_STOPTYPE", sStopType, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_STOPCODE", sStopCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_TAB", LS_TABIDX, DbType.String, ParameterDirection.Input));

                if (tabControl1.SelectedTab.Index == 0)
                {
                    if (helper.RSCODE == "S")
                    {
                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            _GridUtil.Grid_Clear(grid1);
                            grid1.DataSource = rtnDtTemp;
                            grid1.DataBinds(rtnDtTemp);

                            grid1.Columns["PLANTCODE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                            grid1.Columns["PLANTCODE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
                            grid1.Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;

                        }
                        else
                        {
                            _GridUtil.Grid_Clear(grid1);
                            this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        }
                    }
                    else
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    }
                }
                else if (tabControl1.SelectedTab.Index == 1)
                {
                    if (helper.RSCODE == "S")
                    {
                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            _GridUtil.Grid_Clear(grid2);
                            grid2.DataSource = rtnDtTemp;
                            grid2.DataBinds(rtnDtTemp);

                            grid2.Columns["PLANTCODE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                            grid2.Columns["PLANTCODE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
                            grid2.Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;

                            grid2.Columns["WORKCENTERCODE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                            grid2.Columns["WORKCENTERCODE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
                            grid2.Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;

                        }
                        else
                        {
                            _GridUtil.Grid_Clear(grid2);
                            this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        }
                    }
                    else
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    }
                }

            }

            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
        #endregion

        #region < METHOD AREA >
        private DataTable GET_BM0110_CODE(string PlantCode)
        {
            DBHelper helper = new DBHelper(false);
            DataTable DtTemp = new DataTable();

            try
            {
                // 비가동 내역 콤보박스.
                StringBuilder query = new StringBuilder();

                query.Remove(0, query.Length);
                query.AppendLine("   SELECT DISTINCT STOPCODE AS CODE_ID,                     ");
                query.AppendLine("          '['  + STOPCODE + '] ' +  STOPDESC AS CODE_NAME   ");
                query.AppendLine("     FROM BM0110 WHERE PLANTCODE LIKE '" + PlantCode + "%'  ");
                query.AppendLine("    ORDER BY STOPCODE                                       ");

                DtTemp = helper.FillTable(Convert.ToString(query), CommandType.Text);

                return DtTemp;
            }
            catch (Exception ex)
            {
                return DtTemp;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
        private void tabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (iCnt > 0)
                DoInquire();

            iCnt++;
        }

        private void grid1_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            DataTable dt = grid1.chkChange();
            if (dt == null)
            {
                txt_WORKCENTERCODE_H.Value = this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
                tabControl1.SelectedTab = tabControl1.Tabs[1];
                DoInquire();
                return;
            }
            foreach (DataRow drRow in ((DataTable)grid1.DataSource).GetChanges().Rows)
                switch (drRow.RowState)
                {
                    case DataRowState.Added:
                        this.ShowDialog(Common.getLangText("저장하신 후, 더블클릭해주세요.", "MSG"));
                        return;
                }
        }

        #endregion
    }
}
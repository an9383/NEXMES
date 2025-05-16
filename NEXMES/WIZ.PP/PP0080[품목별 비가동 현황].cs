#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0080
//   Form Name    : 품목별 비가동 현황
//   Name Space   : WIZ.PP
//   Created Date : 2018-01-24
//   Made By      : WIZCORE
//   Edited Date  : 
//   Edit By      :
//   Description  : 품목별 비가동 현황 조회
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
    public partial class PP0080 : WIZ.Forms.BaseMDIChildForm
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
        public PP0080()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PP0080_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID3 품목별 비가동 현황(전체)
                _GridUtil.InitializeGrid(this.grid3, false, true, false, "", true);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ERRORITEMCODE", "원인품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ERRORITEMNAME", "원인품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "STOPCNT", "비가동건수", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "STATUSTIME", "비가동시간(분)", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "WORKAMT", "비가동금액(원)", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, false, false);

                grid3.Columns["STOPCNT"].Format = "#,##0";
                grid3.Columns["STATUSTIME"].Format = "#,##0.00";
                grid3.Columns["WORKAMT"].Format = "#,###,###,##0";

                grid3.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
                grid3.DisplayLayout.Bands[0].Summaries.Add("합계", SummaryPosition.UseSummaryPositionColumn, this.grid3.DisplayLayout.Bands[0].Columns["ITEMCODE"]);
                grid3.DisplayLayout.Bands[0].Summaries[0].SourceColumn = this.grid3.DisplayLayout.Bands[0].Columns["ITEMCODE"];
                grid3.DisplayLayout.Bands[0].Summaries[0].DisplayFormat = "합계";
                grid3.DisplayLayout.Bands[0].Summaries[0].Key = "ITEMCODE";
                grid3.DisplayLayout.Bands[0].Summaries[0].Appearance.TextHAlign = HAlign.Center;
                grid3.DisplayLayout.Bands[0].Summaries[0].Appearance.FontData.SizeInPoints = 9;
                grid3.DisplayLayout.Bands[0].Summaries[0].Appearance.BackColor = Color.FromArgb(140, 190, 230);
                grid3.DisplayLayout.Bands[0].Summaries[0].Appearance.ForeColor = Color.Black;
                grid3.DisplayLayout.Bands[0].Summaries[0].SummaryDisplayArea = SummaryDisplayAreas.Bottom;


                grid3.DisplayLayout.Bands[0].Summaries.Add("SUM([STOPCNT])", SummaryPosition.UseSummaryPositionColumn, this.grid3.DisplayLayout.Bands[0].Columns["STOPCNT"]);
                grid3.DisplayLayout.Bands[0].Summaries[1].DisplayFormat = "{0:#,##0}";
                grid3.DisplayLayout.Bands[0].Summaries[1].SourceColumn = this.grid3.DisplayLayout.Bands[0].Columns["STOPCNT"];
                grid3.DisplayLayout.Bands[0].Summaries[1].Key = "STOPCNT";
                grid3.DisplayLayout.Bands[0].Summaries[1].Appearance.TextHAlign = HAlign.Right;
                grid3.DisplayLayout.Bands[0].Summaries[1].Appearance.FontData.SizeInPoints = 9;
                grid3.DisplayLayout.Bands[0].Summaries[1].Appearance.BackColor = Color.FromArgb(140, 190, 230);
                grid3.DisplayLayout.Bands[0].Summaries[1].Appearance.ForeColor = Color.Black;
                grid3.DisplayLayout.Bands[0].Summaries[1].SourceColumn.Format = "#,##0";
                grid3.DisplayLayout.Bands[0].Summaries[1].SummaryPositionColumn.Format = "#,##0";
                grid3.DisplayLayout.Bands[0].Summaries[1].SummaryDisplayArea = SummaryDisplayAreas.Bottom;
                grid3.DisplayLayout.Bands[0].Summaries[1].SummaryType = SummaryType.Sum;

                grid3.DisplayLayout.Bands[0].Summaries.Add("SUM([STATUSTIME])", SummaryPosition.UseSummaryPositionColumn, this.grid3.DisplayLayout.Bands[0].Columns["STATUSTIME"]);
                grid3.DisplayLayout.Bands[0].Summaries[2].DisplayFormat = "{0:#,##0.00}";
                grid3.DisplayLayout.Bands[0].Summaries[2].SourceColumn = this.grid3.DisplayLayout.Bands[0].Columns["STATUSTIME"];
                grid3.DisplayLayout.Bands[0].Summaries[2].Key = "STATUSTIME";
                grid3.DisplayLayout.Bands[0].Summaries[2].Appearance.TextHAlign = HAlign.Right;
                grid3.DisplayLayout.Bands[0].Summaries[2].Appearance.FontData.SizeInPoints = 9;
                grid3.DisplayLayout.Bands[0].Summaries[2].Appearance.BackColor = Color.FromArgb(140, 190, 230);
                grid3.DisplayLayout.Bands[0].Summaries[2].Appearance.ForeColor = Color.Black;
                grid3.DisplayLayout.Bands[0].Summaries[2].SourceColumn.Format = "#,##0.00";
                grid3.DisplayLayout.Bands[0].Summaries[2].SummaryPositionColumn.Format = "#,##0.00";
                grid3.DisplayLayout.Bands[0].Summaries[2].SummaryDisplayArea = SummaryDisplayAreas.Bottom;
                grid3.DisplayLayout.Bands[0].Summaries[2].SummaryType = SummaryType.Sum;


                _GridUtil.SetInitUltraGridBind(grid3);

                grid3.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;


                //GRID4 품목별 비가동 현황 (상세)
                _GridUtil.InitializeGrid(this.grid4, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid4, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "RECDATE", "일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "STOPTYPE", "비가동구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "STOPCODE", "비가동코드", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ERRORITEMCODE", "원인품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ERRORITEMNAME", "원인품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "STARTDATE", "시작시간", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ENDDATE", "종료시간", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "STATUSTIME", "비가동시간(분)", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "WORKERCNT", "비가동인원", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "WORKERGS", "비가동공수", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "WORKAMT", "비가동금액(원)", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, false, false);

                grid4.Columns["STATUSTIME"].Format = "#,##0.00";
                grid4.Columns["WORKERCNT"].Format = "#,##0";
                grid4.Columns["WORKERGS"].Format = "#,##0.00";
                grid4.Columns["WORKAMT"].Format = "#,###,###,##0";


                _GridUtil.SetInitUltraGridBind(grid4);
                grid4.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;


                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;
                cbo_PLANTCODE_H.Select();

                rtnDtTemp = _Common.GET_BM0060_CODE("");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("STOPTYPE");  //비가동구분
                WIZ.Common.FillComboboxMaster(this.cbo_STOPTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "STOPTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = GET_BM0110_CODE(Convert.ToString(this.cbo_PLANTCODE_H.Value));
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "STOPCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;
                #endregion

                #region POPUP SETTING

                //품목
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });

                #endregion
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid3);
            _GridUtil.Grid_Clear(grid4);

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sWorkcenterCode = txt_WORKCENTERCODE_H.Text.Trim();
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sStopType = DBHelper.nvlString(cbo_STOPTYPE_H.Value);
                string sStopCode = txt_STOPCODE_H.Text.Trim();
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                string LS_TABIDX = string.Empty;
                if (tabControl1.SelectedTab.Index == 2) LS_TABIDX = "TAB3";
                else LS_TABIDX = "TAB4";

                rtnDtTemp = helper.FillTable("USP_PP0080_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_STOPTYPE", sStopType, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_STOPCODE", sStopCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_TAB", LS_TABIDX, DbType.String, ParameterDirection.Input));

                if (tabControl1.SelectedTab.Index == 2)
                {
                    if (helper.RSCODE == "S")
                    {
                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            _GridUtil.Grid_Clear(grid3);
                            grid3.DataSource = rtnDtTemp;
                            grid3.DataBinds(rtnDtTemp);

                            grid3.Columns["PLANTCODE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                            grid3.Columns["PLANTCODE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
                            grid3.Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;

                        }
                        else
                        {
                            _GridUtil.Grid_Clear(grid3);
                            this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        }
                    }
                    else
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    }
                }
                else if (tabControl1.SelectedTab.Index == 3)
                {
                    if (helper.RSCODE == "S")
                    {
                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            _GridUtil.Grid_Clear(grid4);
                            grid4.DataSource = rtnDtTemp;
                            grid4.DataBinds(rtnDtTemp);

                            grid4.Columns["PLANTCODE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                            grid4.Columns["PLANTCODE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
                            grid4.Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;

                            grid4.Columns["ITEMCODE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                            grid4.Columns["ITEMCODE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
                            grid4.Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;

                        }
                        else
                        {
                            _GridUtil.Grid_Clear(grid4);
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
                query.AppendLine("   SELECT DISTINCT STOPCODE AS CODE_ID,                       ");
                query.AppendLine("          '['  + STOPCODE + '] ' +  STOPDESC AS CODE_NAME   ");
                query.AppendLine("     FROM BM0110 WHERE PLANTCODE LIKE '" + PlantCode + "%'   ");
                query.AppendLine(" ORDER BY STOPCODE                                            ");

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

        private void grid3_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (grid3.Rows.Count == 0) return;

            DataTable dt = grid3.chkChange();
            if (dt == null)
            {
                txt_ITEMCODE_H.Value = this.grid3.ActiveRow.Cells["ITEMCODE"].Value.ToString();
                tabControl1.SelectedTab = tabControl1.Tabs[3];
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
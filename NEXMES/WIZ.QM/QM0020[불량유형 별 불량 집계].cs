#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM0020
//   Form Name    : 불량유형별 불량현황
//   Name Space   : WIZ.QM
//   Created Date : 2018-01-16
//   Made By      : WIZ
//   Edited Date  : 
//   Edit By      :
//   Description  :
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.QM
{
    public partial class QM0020 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager();
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        int iCnt = 0;
        #endregion

        #region < CONSTRUCTOR >
        public QM0020()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void QM0020_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 불량유형별 불량집계 전체
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORTYPE", "불량유형", false, GridColDataType_emu.VarChar, 120, 70, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORCODE", "불량코드", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORCNT", "불량건수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY", "생산불량수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);
                grid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;


                //GRID2 불량유형별 불량집계 상세
                _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ERRORTYPE", "불량유형", false, GridColDataType_emu.VarChar, 120, 70, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ERRORCODE", "불량코드", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ERRORDESC", "불량명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "RECDATE", "발생일자", false, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 110, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 160, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "WCCODE", "생산작업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ERRORDATE", "생산불량판정일시", false, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ERRORCAUSEWKSH", "불량원인공정", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ERRORITEMCODE", "불량품목", false, GridColDataType_emu.VarChar, 120, 110, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ERRORITEMNAME", "불량품명", false, GridColDataType_emu.VarChar, 200, 140, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ERRORQTY", "생산불량수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ERRORRESULT", "생산판정결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ERRORRESULTDATE", "생산판정일시", false, GridColDataType_emu.DateTime, 180, 110, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "NOTFITRES", "부적합결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "NOTFITRESDATE", "결과등록일", false, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "NOTFITERQTY", "판정수량", false, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "NOTFITLINE", "귀책공정", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "NOTFITLINENM", "귀책공정", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "NOTFITDIV", "귀책구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "NOTFITITEM", "최종원인품목", false, GridColDataType_emu.VarChar, 120, 110, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "NOTFITITEMNM", "최종원인품명", false, GridColDataType_emu.VarChar, 200, 160, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일자", false, GridColDataType_emu.DateTime, 180, 160, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 90, 160, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일자", false, GridColDataType_emu.DateTime, 180, 160, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 90, 160, Infragistics.Win.HAlign.Left, false, false);

                _GridUtil.SetInitUltraGridBind(grid2);

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("ERRORTYPE"); //불량유형
                WIZ.Common.FillComboboxMaster(this.cbo_ERRORTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ERRORTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ERRORTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0060_CODE(""); //작업장
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "WCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-60);
                cbo_ENDDATE_H.Value = DateTime.Now;

                #endregion

                #region POPUP SETTING
                //품목
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });
                //작업장
                btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });
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
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화
            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sWorkCenterCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());
                string sErrorItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sErrorType = DBHelper.nvlString(cbo_ERRORTYPE_H.Value);

                string LS_TABIDX = string.Empty;

                if (tabControl1.SelectedTab.Index == 0) LS_TABIDX = "TAB1";
                else LS_TABIDX = "TAB2";

                if (DateCheck.CheckDate(sStartDate, sEndDate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                rtnDtTemp = helper.FillTable("USP_QM0020_S1", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ERRORITEMCODE", sErrorItemCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ERRORTYPE", sErrorType, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_TAB", LS_TABIDX, DbType.String, ParameterDirection.Input));


                if (tabControl1.SelectedTab.Index == 0)
                {
                    if (helper.RSCODE == "S")
                    {
                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            _GridUtil.Grid_Clear(grid1);
                            grid1.DataSource = UltraGridUtil.SetSubTotalUltraGrid(grid1, rtnDtTemp, "ERRORTYPE", Common.getLangText("[ 구분별 합계 ]", "TEXT"), "ERRORTYPE", "ERRORCNT,ERRORQTY", "SUM,SUM");
                            grid1.DataBinds();

                            grid1.Columns["ERRORTYPE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                            grid1.Columns["ERRORTYPE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
                            grid1.Columns["ERRORTYPE"].MergedCellStyle = MergedCellStyle.Always;
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

                            grid2.Columns["ERRORTYPE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                            grid2.Columns["ERRORTYPE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
                            grid2.Columns["ERRORTYPE"].MergedCellStyle = MergedCellStyle.Always;
                        }
                        else
                        {
                            _GridUtil.Grid_Clear(grid2);
                            this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);    // 조회할 데이터가 없습니다.
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

        #region < EVENT AREA >
        private void tabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (tabControl1.SelectedTab.Index == 0)
                cbo_ERRORTYPE_H.Text = "ALL";
        }

        private void grid1_DoubleClickCell_1(object sender, DoubleClickCellEventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            DataTable dt = grid1.chkChange();
            if (dt == null)
            {
                cbo_ERRORTYPE_H.Value = this.grid1.ActiveRow.Cells["ERRORTYPE"].Value.ToString();
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

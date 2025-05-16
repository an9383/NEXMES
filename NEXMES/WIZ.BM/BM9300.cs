#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM9300
//   Form Name    : 조업분석
//   Name Space   : WIZ.BM
//   Created Date : 2012-6-12 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM9300 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable();  // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();


        private string plantCode = string.Empty; //plantcode default 설정
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        #endregion

        #region < CONSTRUCTOR >
        public BM9300()
        {
            InitializeComponent();
            this.plantCode = CModule.GetAppSetting("Site", "10");
        }
        #endregion

        #region < FORM LOAD >
        private void BM9300_Load(object sender, EventArgs e)
        {
            BizGridManager bizGridManager = new BizGridManager(grid1);
            #region [ Grid1 셋팅 ]
            _GridUtil.InitializeGrid(grid1, false, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCODE", "비가동코드ⓟ", true, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPDESC", "비가동명", true, GridColDataType_emu.VarChar, 250, 200, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STHH", "시작(시)", true, GridColDataType_emu.VarChar, 80, 30, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STMM", "시작(분)", true, GridColDataType_emu.VarChar, 80, 30, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ENHH", "종료(시)", true, GridColDataType_emu.VarChar, 80, 30, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ENMM", "종료(분)", true, GridColDataType_emu.VarChar, 80, 30, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부ⓒ", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            grid1.ColumRowMerge = new string[] { "PLANTCODE", "STOPTYPE" };

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["STOPCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["STHH"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["STMM"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ENHH"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ENMM"].Header.Appearance.ForeColor = Color.SkyBlue;

            grid1.DisplayLayout.Bands[0].Columns["STHH"].MaskInput = "##";
            grid1.DisplayLayout.Bands[0].Columns["STMM"].MaskInput = "##";
            grid1.DisplayLayout.Bands[0].Columns["ENHH"].MaskInput = "##";
            grid1.DisplayLayout.Bands[0].Columns["ENMM"].MaskInput = "##";

            #endregion

            #region [ POPUP ]
            btbManager.PopUpAdd(txtStopCode, txtStopName, "TBM1100", new object[] { "", "", "Y" });
            bizGridManager.PopUpAdd("STOPCODE", "STOPDESC", "TBM1100", new string[] { "PLANTCODE", "", "", "Y" });
            #endregion


            #region [ 콤보박스 ]
            Common _Common = new Common();

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");     // PLANTCODE
            WIZ.Common.FillComboboxMaster(cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");     //사용여부
            WIZ.Common.FillComboboxMaster(cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            cboPlantCode_H.Value = plantCode;
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
                string ls_plantcode = DBHelper.nvlString(cboPlantCode_H.Value);
                string ls_useflag = DBHelper.nvlString(cboUseFlag_H.Value);
                string ls_stopcode = txtStopCode.Text.Trim();
                string ls_stopname = txtStopName.Text.Trim();

                grid1.DataSource = helper.FillTable("USP_BM9300Y_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("STOPNAME", ls_stopname, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("STOPCODE", ls_stopcode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("USEFLAG", ls_useflag, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["STOPCODE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["STOPDESC"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Activation.NoEdit;

            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();
                //  _GridUtil.AddRow(grid1);
                this.grid1.InsertRow();
                if (grid1.Rows.Count > 1)
                {
                    int iRows = grid1.ActiveRow.Index;

                    grid1.SetDefaultValue("PLANTCODE", grid1.Rows[iRows - 1].Cells["PLANTCODE"].Value.ToString());
                    grid1.SetDefaultValue("USEFLAG", "Y");
                }
                else
                {
                    grid1.SetDefaultValue("PLANTCODE", plantCode);
                    grid1.SetDefaultValue("USEFLAG", "Y");
                }
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.Disabled;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString());
            }

        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            grid1.DeleteRow();
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            Grid1ToolAct();
        }

        #endregion

        #region < EVENT AREA >

        private void Grid1ToolAct()
        {

            DataTable dt = grid1.chkChange();
            if (dt == null) { return; }

            DBHelper helper = new DBHelper("", true);

            try
            {

                if (ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();
                // int li_cnt = 0;

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["STOPCODE"].ToString().Trim() == "")
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("비가동 코드는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow["STHH"].ToString().Trim() == "")
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("시작(시)는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow["STMM"].ToString().Trim() == "")
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("시작(분)은 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        //if ((Convert.ToInt32(drRow["STHH"].ToString()) > Convert.ToInt32(drRow["ENHH"].ToString()))
                        //    ||((Convert.ToInt32(drRow["STHH"].ToString()) <= Convert.ToInt32(drRow["ENHH"].ToString())) &&(Convert.ToInt32(drRow["STMM"].ToString()) > Convert.ToInt32(drRow["ENMM"].ToString()))))
                        //{
                        //    this.ClosePrgFormNew();
                        //    this.ShowDialog("시작(시)와 시작(분)은 종료(시)와 종료(분)보다 작아야합니다.", Forms.DialogForm.DialogType.OK);
                        //    return;
                        //}
                        /*     if (drRow["ENHH"].ToString().Length > 2 || drRow["ENMM"].ToString().Length > 2 || drRow["STMM"].ToString().Length > 2 || drRow["STHH"].ToString().Length > 2)
                             {
                                 this.ClosePrgFormNew();
                                 this.ShowDialog("시작 시,분 ,종료 시,분은  최대 2자리까지 입력가능합니다.", Forms.DialogForm.DialogType.OK);
                                 return;
                             }*/

                        string startHH = Convert.ToString(drRow["STHH"]); //시작시
                        string startMM = Convert.ToString(drRow["STMM"]); //시작분
                        string endHH = Convert.ToString(drRow["ENHH"]); //종료시
                        string endMM = Convert.ToString(drRow["ENMM"]); //종료분

                        int startTime = Convert.ToInt32(startHH + startMM);
                        int endTime = Convert.ToInt32(endHH + endMM);

                        if (startTime >= endTime)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("시작 시간이 종료 시간보다 빠릅니다. 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM9300Y_D1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STOPCODE", Convert.ToString(drRow["STOPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STHH", Convert.ToString(drRow["STHH"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STMM", Convert.ToString(drRow["STMM"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM9300Y_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STOPCODE", Convert.ToString(drRow["STOPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STHH", Convert.ToString(drRow["STHH"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STMM", Convert.ToString(drRow["STMM"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ENHH", Convert.ToString(drRow["ENHH"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ENMM", Convert.ToString(drRow["ENMM"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM9300Y_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STOPCODE", Convert.ToString(drRow["STOPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STHH", Convert.ToString(drRow["STHH"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STMM", Convert.ToString(drRow["STMM"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ENHH", Convert.ToString(drRow["ENHH"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ENMM", Convert.ToString(drRow["ENMM"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                    //  if (helper.RSCODE == "E") {li_cnt++;}
                }

                helper.Commit();

                //   if (li_cnt == 0) { DoInquire(); }
                DoInquire();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void grid1_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                int value = 0;

                if (e.Cell.Column.ToString() == "STHH" || e.Cell.Column.ToString() == "ENHH")
                {
                    if (e.Cell.Value.ToString() == string.Empty) return;

                    value = Convert.ToInt32(e.Cell.Value);

                    if (value >= 24)
                    {
                        this.ShowDialog(Common.getLangText("입력된 숫자를 확인하세요. ( 00~23)", "MSG"), Forms.DialogForm.DialogType.OK);
                        e.Cell.Value = e.Cell.OriginalValue;
                    }
                }
                else if (e.Cell.Column.ToString() == "STMM" || e.Cell.Column.ToString() == "ENMM")
                {
                    if (e.Cell.Value.ToString() == string.Empty) return;

                    value = Convert.ToInt32(e.Cell.Value);

                    if (value >= 60)
                    {
                        this.ShowDialog(Common.getLangText("입력된 숫자를 확인하세요. ( 00~59)", "MSG"), Forms.DialogForm.DialogType.OK);
                        e.Cell.Value = e.Cell.OriginalValue;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        #region [ Grid POP UP 처리 ]



        #endregion

        #endregion


    }
}

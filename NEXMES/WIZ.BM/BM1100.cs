#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM1100
//   Form Name    : 비가동관리
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
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM1100 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable();  // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private string plantCode = string.Empty; //plantcode default 설정
        private bool inquire = false;
        #endregion

        #region < CONSTRUCTOR >
        public BM1100()
        {
            InitializeComponent();

            this.plantCode = CModule.GetAppSetting("Site", "10");
        }
        #endregion

        #region < FORM LOAD >
        private void BM1100_Load(object sender, EventArgs e)
        {
            #region [ Grid1 셋팅 ] 
            _GridUtil.InitializeGrid(grid1, false, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPTYPE", "비가동구분ⓒ", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCODE", "비가동코드", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPDESC", "비가동명", false, GridColDataType_emu.VarChar, 200, 200, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "VIEWFLAG", "현장단말기표시유무ⓒ", false, GridColDataType_emu.VarChar, 180, 30, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 200, 200, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부ⓒ", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일자", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            grid1.ColumRowMerge = new string[] { "PLANTCODE", "STOPTYPE" };

            _GridUtil.SetInitUltraGridBind(grid1);
            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["STOPCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["STOPTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
            #endregion

            #region [ POPUP ]
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtStopCode, txtStopName, "TBM1100", new object[] { cboStopType_H, "", "Y" });
            #endregion


            #region [ 콤보박스 ]
            Common _Common = new Common();

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");     // PLANTCODE
            WIZ.Common.FillComboboxMaster(cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("STOPTYPE");     // 비가동구분
            WIZ.Common.FillComboboxMaster(cboStopType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid1, "STOPTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");     //사용여부
            WIZ.Common.FillComboboxMaster(cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");     //SMS전송여부
            WIZ.UltraGridUtil.SetComboUltraGrid(grid1, "VIEWFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
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
                string ls_stoptype = DBHelper.nvlString(cboStopType_H.Value);
                string ls_useflag = DBHelper.nvlString(cboUseFlag_H.Value);
                string ls_stopcode = txtStopCode.Text.Trim();


                rtnDtTemp = helper.FillTable("USP_BM1100_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_FLAG", "S", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_STOPTYPE", ls_stoptype, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_STOPCODE", ls_stopcode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_USEFLAG", ls_useflag, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                }


                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grid1.DisplayLayout.Bands[0].Columns["STOPTYPE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["STOPTYPE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["STOPTYPE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["STOPCODE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["STOPDESC"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["VIEWFLAG"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["REMARK"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["USEFLAG"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["MAKER"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["EDITOR"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["EDITDATE"].CellAppearance.BackColor = Color.White;

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["STOPTYPE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["STOPCODE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                inquire = true;

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
                //if (inquire == false) return;
                base.DoNew();
                this.grid1.InsertRow();

                if (grid1.Rows.Count > 1)
                {
                    // 현재 선택된 그리드의 ROWS INDEX + 1로 추가된다.
                    // 그러므로 선택한 그리드의 PLANTCODE, STOPTYPE, MAX(STOPCODE) + 1로 자동 코드가 부여한다.
                    int iRows = grid1.ActiveRow.Index;

                    grid1.SetDefaultValue("PLANTCODE", grid1.Rows[iRows - 1].Cells["PLANTCODE"].Value.ToString());
                    grid1.SetDefaultValue("STOPTYPE", grid1.Rows[iRows - 1].Cells["STOPTYPE"].Value.ToString());
                    grid1.SetDefaultValue("VIEWFLAG", "Y");
                    grid1.SetDefaultValue("USEFLAG", "Y");
                }
                else
                {
                    //선택할 그리드가 없기 때문에 초기 데이터는 사용자가 직접 선택 및 입력을 한다.
                    //PLANTCODE, STOPTYPE을 선택하면 STOPCODE는 자동 부여가 된다.

                    grid1.SetDefaultValue("PLANTCODE", this.plantCode); //15-10-28 추가시 로그인 된 공장 코드로 설정 최재형 
                    grid1.SetDefaultValue("VIEWFLAG", "Y");
                    grid1.SetDefaultValue("USEFLAG", "Y");
                }
                grid1.ActiveRow.Cells["STOPCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
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
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);


            try
            {
                if (ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel) //변경된 사항을 저장하시겠습니까?
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();
                int li_cnt = 0;

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["STOPCODE"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "비가동코드는 필수 입력 항목입니다.");
                            continue;
                        }
                        if (drRow["STOPDESC"].ToString().Length > 40)
                        {
                            grid1.SetRowError(drRow, "비가동명은 최대 40자리까지 입력가능합니다.");
                            continue;
                        }
                        if (drRow["Remark"].ToString().Length > 255)
                        {
                            grid1.SetRowError(drRow, "비고는 최대 255자리까지 입력가능합니다.");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM1100_D1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOPCODE", Convert.ToString(drRow["STOPCODE"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM1100_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOPTYPE", Convert.ToString(drRow["STOPTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOPCODE", Convert.ToString(drRow["STOPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOPDESC", Convert.ToString(drRow["STOPDESC"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_VIEWFLAG", Convert.ToString(drRow["VIEWFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", Convert.ToString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKER", WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM1100_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOPTYPE", Convert.ToString(drRow["STOPTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOPCODE", Convert.ToString(drRow["STOPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOPDESC", Convert.ToString(drRow["STOPDESC"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_VIEWFLAG", Convert.ToString(drRow["VIEWFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", Convert.ToString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKER", WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                    if (helper.RSCODE == "E") { li_cnt++; }
                }

                helper.Commit();

                if (li_cnt == 0) { DoInquire(); }
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

        #region [ Grid POP UP 처리 ]
        private void grid_POP_UP()
        {
            int iRow = grid1.ActiveRow.Index;

            string sStopType = grid1.Rows[iRow].Cells["StopType"].Text.Trim();  // 비가동구분
            string sStopClass = grid1.Rows[iRow].Cells["StopClass"].Text.Trim();  // 비가동우형
            string sStopCode = grid1.Rows[iRow].Cells["StopCode"].Text.Trim();  // 비가동코드
            string sStopDesc = grid1.Rows[iRow].Cells["StopDesc"].Text.Trim();  // 비가동명
            string sUseFlag = grid1.Rows[iRow].Cells["UseFlag"].Text.Trim();  // 사용여부

            if (grid1.ActiveCell.Column.ToString() == "StopCode" || grid1.ActiveCell.Column.ToString() == "StopDesc")
            {
                PopUp_Biz _biz = new PopUp_Biz();
                //_biz.TBM1100_POP_Grid(sStopCode, sStopDesc, sStopType, sStopClass, sUseFlag, grid1, "StopCode", "StopDesc");
            }

        }
        private void grid1_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            grid_POP_UP();
        }

        private void grid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                grid_POP_UP();
            }
        }
        #endregion

        private void grid1_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {

            try
            {
                int iRows = grid1.ActiveRow.Index;
                string ls_plantcode = string.Empty;
                string ls_stoptype = string.Empty;
                string ls_stopcode = string.Empty;
                string ls_maxstopcode = string.Empty;

                ls_plantcode = DBHelper.nvlString(grid1.Rows[iRows].Cells["PLANTCODE"].Value.ToString());
                ls_stoptype = DBHelper.nvlString(grid1.Rows[iRows].Cells["STOPTYPE"].Value.ToString());
                ls_stopcode = DBHelper.nvlString(grid1.Rows[iRows].Cells["STOPCODE"].Value.ToString());

                if (ls_plantcode.Trim().Length > 0 && ls_stoptype.Trim().Length > 0 && ls_stopcode.Trim().Length == 0)
                {
                    DBHelper helper = new DBHelper(false);
                    DataTable _TmpDt = helper.FillTable("USP_BM1100_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_FLAG", "C", DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STOPTYPE", ls_stoptype, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STOPCODE", "", DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_USEFLAG", "", DbType.String, ParameterDirection.Input));

                    if (_TmpDt.Rows.Count > 0)
                    {
                        ls_maxstopcode = DBHelper.nvlString(Convert.ToString(_TmpDt.Rows[0]["MAXSTOPCODE"]));
                        if (ls_maxstopcode.Trim().Length == 0) { ls_maxstopcode = ls_stoptype + "01"; }

                        grid1.SetDefaultValue("STOPCODE", ls_maxstopcode);
                    }

                    _TmpDt.Dispose();
                    helper.Close();
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString());
            }
        }

        #endregion

        private void grid1_AfterCellListCloseUp(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            grid1.UpdateData();

            if (this.grid1.Rows.Count == 0) return;
        }

        private void grid1_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                grid1.UpdateData();

                if (this.grid1.Rows.Count == 0) return;

                if (e.Cell.Column.ToString() != "STOPTYPE") return;

                int iRows = grid1.ActiveRow.Index;

                string stoptype = string.Empty;
                string plantcode = string.Empty;
                string stopcode = string.Empty;

                if (iRows == 0)
                {
                    //그리드 row가 첫번쨰 일 경우..
                    plantcode = grid1.Rows[iRows].Cells["PLANTCODE"].Value.ToString();
                    stoptype = grid1.Rows[iRows].Cells["STOPTYPE"].Value.ToString();

                    if (plantcode.Length != 4) return;

                    GET_CODE("C", plantcode, stoptype, ref stopcode);
                    grid1.SetDefaultValue("STOPCODE", stopcode);
                }
                else
                {
                    int li_cnt = 0;

                    plantcode = Convert.ToString(grid1.Rows[iRows].Cells["PLANTCODE"].Value);
                    stoptype = Convert.ToString(grid1.Rows[iRows].Cells["STOPTYPE"].Value);

                    if (plantcode.Length != 4) return;

                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        if (stopcode == Convert.ToString(grid1.Rows[i].Cells["STOPCODE"].Value))
                        {
                            li_cnt++;
                        }
                    }

                    GET_CODE("C", plantcode, stoptype, ref stopcode);

                    if (stopcode.Length > 0)
                    {
                        if (stoptype == Convert.ToString(grid1.Rows[iRows - 1].Cells["STOPCODE"].Value).Substring(0, 1))
                        {

                            if (li_cnt >= Convert.ToInt32(stopcode.Replace(stoptype, "")))
                            {
                                string lsCnt = li_cnt.ToString();
                                string getStopCode = string.Empty;

                                if (lsCnt.Trim().Length == 1) { lsCnt = "0" + lsCnt; }

                                getStopCode = stopcode + lsCnt;

                                for (int i = 0; i < grid1.Rows.Count; i++)
                                {
                                    if (getStopCode == Convert.ToString(grid1.Rows[i].Cells["STOPCODE"].Value))
                                    {
                                        //같은게 잇다..
                                        int liCnt = 0;
                                        liCnt = Convert.ToInt32(lsCnt) + 1;
                                        lsCnt = liCnt.ToString();
                                        if (lsCnt.Trim().Length == 1) { lsCnt = "0" + lsCnt; }

                                        getStopCode = stoptype + lsCnt;

                                    }
                                }
                                grid1.SetDefaultValue("STOPCODE", getStopCode);
                            }
                            else if (li_cnt < Convert.ToInt32(stopcode.Replace(stoptype, "")))
                            {
                                if (Convert.ToInt32(Convert.ToString(grid1.Rows[iRows - 1].Cells["STOPCODE"].Value).Replace(stoptype, "")) < Convert.ToInt32(stopcode.Replace(stoptype, "")))
                                {
                                    grid1.SetDefaultValue("STOPCODE", stopcode);
                                }
                                else
                                {
                                    string lsCnt = Convert.ToString(Convert.ToInt32(Convert.ToString(grid1.Rows[iRows - 1].Cells["STOPCODE"].Value).Replace(stoptype, "")) + 1);
                                    if (lsCnt.Trim().Length == 1) { lsCnt = "0" + lsCnt; }
                                    grid1.SetDefaultValue("STOPCODE", stoptype + lsCnt);
                                }
                            }
                        }
                        else
                        {
                            int cnt = 0;

                            for (int i = 0; i < grid1.Rows.Count; i++)
                            {
                                if (stopcode.Substring(0, 1) == Convert.ToString(grid1.Rows[i].Cells["STOPTYPE"].Value).Substring(0, 1))
                                {
                                    cnt++;
                                }
                            }
                            if (Convert.ToInt32(stopcode.Substring(1, 2)) < cnt)
                            {
                                grid1.SetDefaultValue("STOPCODE", stoptype + cnt);
                            }
                            else
                            {
                                grid1.SetDefaultValue("STOPCODE", stopcode);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void GET_CODE(string flag, string plantcode, string stoptype, ref string stopcode)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                int iRows = grid1.ActiveRow.Index;

                DataTable _TmpDt = helper.FillTable("USP_BM1100_S1", CommandType.StoredProcedure
                                                               , helper.CreateParameter("AS_FLAG", "C", DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_PLANTCODE", plantcode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_STOPTYPE", stoptype, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_STOPCODE", "", DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_USEFLAG", "", DbType.String, ParameterDirection.Input));

                if (_TmpDt.Rows.Count > 0)
                {
                    stopcode = DBHelper.nvlString(Convert.ToString(_TmpDt.Rows[0]["MAXSTOPCODE"]));
                    if (stopcode.Trim().Length == 0) { stopcode = stoptype + "01"; }

                    grid1.SetDefaultValue("STOPCODE", stopcode);
                }

                _TmpDt.Dispose();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void txtStopCode_ValueChanged(object sender, EventArgs e)
        {
            string sStopCode = txtStopCode.Text;

            if (sStopCode.Length == 3 && sStopCode != "ALL")
            {
                sStopCode = sStopCode.Substring(0, 1);
                cboStopType_H.Value = sStopCode;
            }
        }

        private void txtStopName_ValueChanged(object sender, EventArgs e)
        {
            if (txtStopCode.Text.Length != 3)
                txtStopName.Text = string.Empty;
        }
    }



}

#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM1000
//   Form Name    : 불량항목 마스터
//   Name Space   : WIZ.BM
//   Created Date : 2012-03-19
//   Made By      : WIZCORE
//   Description  : 붕랼항목 관리 화면
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM1000 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();

        private string plantCode = string.Empty; //plantcode default 설정
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private bool inquire = false;
        #endregion

        #region < CONSTRUCTOR >
        public BM1000()
        {
            InitializeComponent();

            this.plantCode = CModule.GetAppSetting("Site", "10");

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtErrorCode, txtErrorName, "TBM1000", new object[] { cboErrorClass_H, cboUseFlag_H });
        }

        private void BM1000_Load(object sender, EventArgs e)
        {
            #region 그리드
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorType", "불량구분ⓒ", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorCode", "불량코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorDesc", "불량명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", true, GridColDataType_emu.VarChar, 206, 255, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부ⓒ", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일시", true, GridColDataType_emu.VarChar, 170, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일시", true, GridColDataType_emu.VarChar, 170, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);


            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            // grid1.DisplayLayout.Bands[0].Columns["ErrorType"].Header.Appearance.ForeColor = Color.Yellow;
            grid1.DisplayLayout.Bands[0].Columns["ErrorCode"].Header.Appearance.ForeColor = Color.SkyBlue;

            #endregion



            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ERRORTYPE");     //불량 유형
            WIZ.Common.FillComboboxMaster(this.cboErrorClass_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ERRORTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cboPlantCode_H.Value = plantCode;

        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                string sErrorCode = Convert.ToString(txtErrorCode.Text.Trim());
                string sErrorName = Convert.ToString(txtErrorName.Text.Trim());
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                string sErrorClass = DBHelper.nvlString(this.cboErrorClass_H.Value);
                string PLANTCODE = DBHelper.nvlString(this.cboPlantCode_H.Value);
                base.DoInquire();

                rtnDtTemp = helper.FillTable("USP_BM1000_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("Flag", "S", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ErrorCode", sErrorCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ErrorName", sErrorName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ERRORTYPE", sErrorClass, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }


                //grid1.ColumRowMerge = new string[] { "PlantCode" };

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grid1.DisplayLayout.Bands[0].Columns["ErrorType"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["ErrorType"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["ErrorType"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["ErrorCode"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["ErrorDesc"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["REMARK"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["USEFLAG"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["MAKER"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["EDITOR"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["EDITDATE"].CellAppearance.BackColor = Color.White;

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["ErrorType"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["ErrorCode"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                inquire = true;

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
                    int iRows = grid1.ActiveRow.Index;

                    grid1.SetDefaultValue("PLANTCODE", grid1.Rows[iRows - 1].Cells["PLANTCODE"].Value.ToString());
                    grid1.SetDefaultValue("ERRORTYPE", grid1.Rows[iRows - 1].Cells["ERRORTYPE"].Value.ToString());
                    grid1.SetDefaultValue("USEFLAG", "Y");
                }
                else
                {
                    grid1.SetDefaultValue("PLANTCODE", this.plantCode);
                    grid1.SetDefaultValue("USEFLAG", "Y");
                }
                grid1.ActiveRow.Cells["ErrorCode"].Activation = Activation.NoEdit;
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
            this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();
                int li_cnt = 0;
                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["ErrorTYPE"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "에러 구분은 필수 입력 항목입니다.");
                            li_cnt = 1;
                            continue;
                        }
                        if (drRow["ErrorDesc"].ToString().Length > 40)
                        {
                            grid1.SetRowError(drRow, "불량명은 최대 40자리까지 입력가능합니다.");
                            li_cnt = 1;
                            continue;
                        }
                        if (drRow["Remark"].ToString().Length > 255)
                        {
                            grid1.SetRowError(drRow, "비고는 최대 255자리까지 입력가능합니다.");
                            li_cnt = 1;
                            continue;
                        }
                    }

                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM1000_D1", CommandType.StoredProcedure
                                , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("ErrorCode", Convert.ToString(drRow["ErrorCode"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;

                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM1000_I1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ErrorCode", Convert.ToString(drRow["ErrorCode"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ErrorDesc", Convert.ToString(drRow["ErrorDesc"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ErrorType", Convert.ToString(drRow["ErrorType"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("Remark", Convert.ToString(drRow["Remark"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pMaker", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM1000_U1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ErrorCode", Convert.ToString(drRow["ErrorCode"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ErrorDesc", Convert.ToString(drRow["ErrorDesc"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ErrorType", Convert.ToString(drRow["ErrorType"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("Remark", Convert.ToString(drRow["Remark"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                    if (helper.RSCODE == "E") { li_cnt = 1; }
                }
                grid1.SetAcceptChanges("ErrorCode");


                helper.Commit();
                if (li_cnt == 0) { DoInquire(); }
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ThrowError(ex);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region [ User Method Area ] 
        private void GET_CODE(string flag, string plantcode, string errotype, ref string nErroType)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                int iRows = grid1.ActiveRow.Index;

                DataTable _TmpDt = helper.FillTable("USP_BM1000_S1", CommandType.StoredProcedure
                                                               , helper.CreateParameter("FLAG", "C", DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("PLANTCODE", plantcode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("ERRORTYPE", errotype, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("ErrorCode", "", DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("ErrorName", "", DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("UseFlag", "", DbType.String, ParameterDirection.Input));

                if (_TmpDt.Rows.Count > 0)
                {
                    //grid1.SetDefaultValue("ErrorCode", Convert.ToString(_TmpDt.Rows[0]["MAXSTOPCODE"]));
                    nErroType = Convert.ToString(_TmpDt.Rows[0]["MAXSTOPCODE"]);
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

        #endregion

        private void grid1_AfterCellListCloseUp(object sender, CellEventArgs e)
        {
            try
            {
                grid1.UpdateData();

                if (this.grid1.Rows.Count == 0) return;

                //if (e.Cell.Column.ToString() != "ERRORTYPE") return;

                //int iRows = grid1.ActiveRow.Index;
                //string errortype = string.Empty;
                //string plantcode = string.Empty;
                //string errorcode = string.Empty;

                //if (iRows == 0)
                //{
                //    //그리드 row가 첫번쨰 일 경우..
                //    plantcode = grid1.Rows[iRows].Cells["PLANTCODE"].Value.ToString();
                //    errortype = grid1.Rows[iRows].Cells["ERRORTYPE"].Value.ToString();

                //    if (plantcode.Length != 4) return;

                //    GET_CODE("C", plantcode, errortype, ref errorcode);
                //    grid1.SetDefaultValue("ERRORCODE", errorcode);
                //}
                //else
                //{
                //    int li_cnt = 0;

                //    plantcode = grid1.Rows[iRows].Cells["PLANTCODE"].Value.ToString();
                //    errortype = grid1.Rows[iRows].Cells["ERRORTYPE"].Value.ToString();

                //    if (plantcode.Length != 4) return;

                //    for (int i = 0; i < grid1.Rows.Count; i++)
                //    {
                //        if (errorcode == Convert.ToString(grid1.Rows[i].Cells["ERRORCODE"].Value))
                //        {
                //            li_cnt++;
                //        }
                //    }

                //    GET_CODE("C", plantcode, errortype, ref errorcode);

                //    if (errorcode.Length > 0)
                //    {
                //        if (li_cnt >= Convert.ToInt32(errorcode.Replace(errortype, "")))
                //        {
                //            string lsCnt = li_cnt.ToString();
                //            string getErrorCode = string.Empty;

                //            if (lsCnt.Trim().Length == 1) { lsCnt = "0" + lsCnt; }

                //            getErrorCode = errorcode + lsCnt;

                //            for (int i = 0; i < grid1.Rows.Count; i++)
                //            {
                //                if (getErrorCode == Convert.ToString(grid1.Rows[i].Cells["ERRORCODE"].Value))
                //                {
                //                    //같은게 잇다..
                //                    int liCnt = 0;
                //                    liCnt = Convert.ToInt32(lsCnt) + 1;
                //                    lsCnt = liCnt.ToString();
                //                    if (lsCnt.Trim().Length == 1) { lsCnt = "0" + lsCnt; }

                //                    getErrorCode = errortype + lsCnt;

                //                }
                //            }
                //            grid1.SetDefaultValue("ERRORCODE", getErrorCode);
                //        }
                //        else if (li_cnt < Convert.ToInt32(errorcode.Replace(errortype, "")))
                //        {
                //            if (Convert.ToInt32(Convert.ToString(grid1.Rows[iRows - 1].Cells["ERRORCODE"].Value).Replace(errortype, "")) < Convert.ToInt32(errorcode.Replace(errortype, "")))
                //            {
                //                grid1.SetDefaultValue("ERRORCODE", errorcode);
                //            }
                //            else
                //            {
                //                string lsCnt = Convert.ToString(Convert.ToInt32(Convert.ToString(grid1.Rows[iRows - 1].Cells["ERRORCODE"].Value).Replace(errortype, "")) + 1);
                //                if (lsCnt.Trim().Length == 1) { lsCnt = "0" + lsCnt; }
                //                grid1.SetDefaultValue("ERRORCODE", errortype + lsCnt);
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            try
            {
                grid1.UpdateData();

                if (this.grid1.Rows.Count == 0) return;

                if (e.Cell.Column.ToString() != "ERRORTYPE") return;

                int iRows = grid1.ActiveRow.Index;
                string errortype = string.Empty;
                string plantcode = string.Empty;
                string errorcode = string.Empty;

                if (iRows == 0)
                {
                    //그리드 row가 첫번쨰 일 경우..
                    plantcode = grid1.Rows[iRows].Cells["PLANTCODE"].Value.ToString();
                    errortype = grid1.Rows[iRows].Cells["ERRORTYPE"].Value.ToString();

                    if (plantcode.Length != 4) return;

                    GET_CODE("C", plantcode, errortype, ref errorcode);
                    grid1.SetDefaultValue("ERRORCODE", errorcode);
                }
                else
                {
                    int li_cnt = 0;

                    plantcode = grid1.Rows[iRows].Cells["PLANTCODE"].Value.ToString();
                    errortype = grid1.Rows[iRows].Cells["ERRORTYPE"].Value.ToString();

                    if (plantcode.Length != 4) return;

                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        if (errorcode == Convert.ToString(grid1.Rows[i].Cells["ERRORCODE"].Value))
                        {
                            li_cnt++;
                        }
                    }

                    GET_CODE("C", plantcode, errortype, ref errorcode);

                    if (errorcode.Length > 0)
                    {
                        if (errortype == Convert.ToString(grid1.Rows[iRows - 1].Cells["ERRORCODE"].Value).Substring(0, 1))
                        {

                            if (li_cnt >= Convert.ToInt32(errorcode.Replace(errortype, "")))
                            {
                                string lsCnt = li_cnt.ToString();
                                string getErrorCode = string.Empty;

                                if (lsCnt.Trim().Length == 1) { lsCnt = "0" + lsCnt; }

                                getErrorCode = errorcode + lsCnt;

                                for (int i = 0; i < grid1.Rows.Count; i++)
                                {
                                    if (getErrorCode == Convert.ToString(grid1.Rows[i].Cells["ERRORCODE"].Value))
                                    {
                                        //같은게 잇다..
                                        int liCnt = 0;
                                        liCnt = Convert.ToInt32(lsCnt) + 1;
                                        lsCnt = liCnt.ToString();
                                        if (lsCnt.Trim().Length == 1) { lsCnt = "0" + lsCnt; }

                                        getErrorCode = errortype + lsCnt;

                                    }
                                }
                                grid1.SetDefaultValue("ERRORCODE", getErrorCode);
                            }
                            else if (li_cnt < Convert.ToInt32(errorcode.Replace(errortype, "")))
                            {
                                if (Convert.ToInt32(Convert.ToString(grid1.Rows[iRows - 1].Cells["ERRORCODE"].Value).Replace(errortype, "")) < Convert.ToInt32(errorcode.Replace(errortype, "")))
                                {
                                    grid1.SetDefaultValue("ERRORCODE", errorcode);
                                }
                                else
                                {
                                    string lsCnt = Convert.ToString(Convert.ToInt32(Convert.ToString(grid1.Rows[iRows - 1].Cells["ERRORCODE"].Value).Replace(errortype, "")) + 1);
                                    if (lsCnt.Trim().Length == 1) { lsCnt = "0" + lsCnt; }
                                    grid1.SetDefaultValue("ERRORCODE", errortype + lsCnt);
                                }
                            }
                        }
                        else
                        {
                            int cnt = 0;

                            for (int i = 0; i < grid1.Rows.Count; i++)
                            {
                                if (errorcode.Substring(0, 1) == Convert.ToString(grid1.Rows[i].Cells["ERRORTYPE"].Value).Substring(0, 1))
                                {
                                    cnt++;
                                }
                            }
                            if (Convert.ToInt32(errorcode.Substring(1, 2)) < cnt)
                            {
                                grid1.SetDefaultValue("ERRORCODE", errortype + cnt);
                            }
                            else
                            {
                                grid1.SetDefaultValue("ERRORCODE", errorcode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {

            }
        }

        private void txtErrorCode_ValueChanged(object sender, EventArgs e)
        {
            string sErrorCode = txtErrorCode.Text;

            if (sErrorCode.Length == 3 && sErrorCode != "ALL")
            {
                sErrorCode = sErrorCode.Substring(0, 1);
                cboErrorClass_H.Value = sErrorCode;
            }
        }

        private void txtErrorName_ValueChanged(object sender, EventArgs e)
        {
            if (txtErrorCode.Text.Length != 3)
                txtErrorName.Text = string.Empty;
        }


        #region < EVENT AREA >

        #endregion

        private void gbxHeader_Click(object sender, EventArgs e)
        {

        }
    }
}
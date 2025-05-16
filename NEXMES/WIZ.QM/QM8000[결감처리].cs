#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM8000
//   Form Name    : 결감 처리
//   Name Space   : WIZ.QM
//   Created Date : 2020-07-15
//   Made By      : JEJUN
//   Description  : 결감처리 (대선주조)
//                          - 결감등록 / 조회 / 삭제 (취소)  / 결감처리 (재고소요)
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.QM
{
    public partial class QM8000 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();

        int num = 0;

        #endregion

        #region < CONSTRUCTOR >
        public QM8000()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void QM8000_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("COMPLETE_FLAG");
            Common.FillComboboxMaster(this.cbo_CLOSEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "CLOSEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

            bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "", "Y" });
            bizGridManager.PopUpAdd("ULLAGECODE", "ULLAGENAME", "BM8000", new string[] { "PLANTCODE", "", "Y" });
            bizGridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "", "", "Y" });
            bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "", "" });
            #endregion

            dtGrid = (DataTable)grid1.DataSource;
        }

        private void GridInitialize()
        {
            try
            {
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSEFLAG", "완료여부", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", false, GridColDataType_emu.VarChar, 150, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장", false, GridColDataType_emu.VarChar, 180, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REGDATE", "일자", false, GridColDataType_emu.YearMonthDay, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ULLAGESEQ", "결감순번", false, GridColDataType_emu.Integer, 120, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ULLAGECODE", "결감사유코드", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ULLAGENAME", "결감사유", false, GridColDataType_emu.VarChar, 180, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ULLAGEQTY", "결감수량", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "BTN_CLOSER", "결감처리", false, GridColDataType_emu.Button, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSEDATE", "완료일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSER", "완료자", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 500, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생성일자", false, GridColDataType_emu.YearMonthDay, 100, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 140, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", false, GridColDataType_emu.YearMonthDay, 100, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 140, false, false);

                _GridUtil.SetColumnTextHAlign(grid1, "ULLAGEQTY", Infragistics.Win.HAlign.Right);
                grid1.Columns["ULLAGEQTY"].Format = "#,##0.#";
                _GridUtil.SetColumnTextHAlign(grid1, "WORKCENTERNAME", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "ULLAGENAME", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "REMARK", Infragistics.Win.HAlign.Left);

                grid1.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Fixed = true;

                _GridUtil.SetInitUltraGridBind(grid1);

                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            base.DoInquire();

            DBHelper helper = new DBHelper(false);
            _GridUtil.Grid_Clear(grid1);

            try
            {

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sCloseFlag = Convert.ToString(cbo_CLOSEFLAG_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();


                dtGrid = helper.FillTable("USP_QM8000_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                grid1.DataSource = dtGrid;
                grid1.DataBind();

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["CLOSEFLAG"].Value) == "N")
                    {
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.BackColor = Color.LightPink;
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.ForeColor = Color.Black;
                        grid1.Rows[i].Cells["BTN_CLOSER"].Activation = Activation.AllowEdit;
                        grid1.Rows[i].Cells["REMARK"].Activation = Activation.AllowEdit;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["CLOSEFLAG"].Value) == "Y")
                    {
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.BackColor = Color.LightGreen;
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.ForeColor = Color.Black;
                        grid1.Rows[i].Cells["BTN_CLOSER"].Activation = Activation.NoEdit;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();
                helper.Close();
            }
        }

        public override void DoNew()
        {
            base.DoNew();

            DBHelper helper = new DBHelper(false);

            try
            {
                this.grid1.InsertRow();

                //사업장과 사용여부는 행 추가시 기본으로 세팅
                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                this.grid1.ActiveRow.Cells["REGDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치

                grid1.ActiveRow.Cells["CLOSEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["CLOSER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["CLOSEFLAG"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["BTN_CLOSER"].Activation = Activation.NoEdit;
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

        public override void DoDelete()
        {
            base.DoDelete();

            string sCloseFlag = DBHelper.nvlString(grid1.ActiveRow.Cells["CLOSEFLAG"].Value);

            if (sCloseFlag == "Y")
            {
                this.ShowDialog(Common.getLangText("이미 결감 처리 된 이력입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }
            else
            {
                if (this.ShowDialog(Common.getLangText("정말로 삭제 하시겠습니까?", "MSG"), Forms.DialogForm.DialogType.YESNO) == System.Windows.Forms.DialogResult.OK)
                {
                    this.grid1.DeleteRow();
                }
            }
        }

        public override void DoSave()
        {
            DataTable dtChange = grid1.chkChange();

            if (dtChange == null)
                return;

            string sPlantCode = LoginInfo.PlantCode.Trim();
            string sWorkcenterCode = string.Empty;
            string sRegDate = string.Empty;
            int iUllageSeq = 0;
            string sItemCode = string.Empty;
            string sUallageCause = string.Empty;
            double dUllageQty = 0;
            string sCloseFlag = string.Empty;
            string sRemark = string.Empty;
            string sUser = LoginInfo.UserID;

            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();

                foreach (DataRow drChange in dtChange.Rows)
                {
                    if (drChange.RowState != DataRowState.Deleted)
                    {
                        if (drChange["PLANTCODE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("사업장을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drChange["WORKCENTERCODE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("작업장을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drChange["REGDATE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("일자를 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        this.ClosePrgFormNew();

                        if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                        {
                            CancelProcess = true;
                            return;
                        }
                    }

                    switch (drChange.RowState)
                    {

                        case DataRowState.Deleted:
                            #region --- 삭제 ---
                            drChange.RejectChanges();

                            sPlantCode = Convert.ToString(drChange["PLANTCODE"]);
                            sWorkcenterCode = Convert.ToString(drChange["WORKCENTERCODE"]);
                            sRegDate = Convert.ToString(drChange["REGDATE"]);
                            iUllageSeq = Convert.ToInt32(drChange["ULLAGESEQ"]);

                            //  결감 등록 ( 처리 X )
                            helper.ExecuteNoneQuery("USP_QM8000_D1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_REGDATE", sRegDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AI_ULLAGESEQ", iUllageSeq, DbType.Int32, ParameterDirection.Input)
                              );
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region --- 추가 ---                            

                            sPlantCode = Convert.ToString(drChange["PLANTCODE"]);
                            sWorkcenterCode = Convert.ToString(drChange["WORKCENTERCODE"]);
                            sRegDate = Convert.ToDateTime(drChange["REGDATE"]).ToString("yyyy-MM-dd");
                            sItemCode = Convert.ToString(drChange["ITEMCODE"]);
                            sUallageCause = Convert.ToString(drChange["ULLAGECODE"]);
                            dUllageQty = Convert.ToDouble(drChange["ULLAGEQTY"]);
                            sRemark = Convert.ToString(drChange["REMARK"]);

                            //  결감 등록
                            helper.ExecuteNoneQuery("USP_QM8000_I1", CommandType.StoredProcedure
                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_REGDATE", sRegDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ULLAGECAUSE", sUallageCause, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AF_ULLAGEQTY", dUllageQty, DbType.Double, ParameterDirection.Input)
                              , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MAKER", sUser, DbType.String, ParameterDirection.Input)
                              );

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region --- 수정 ---

                            #endregion
                            break;
                    }

                    if (helper.RSCODE != "S")
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                        return;
                    }
                }

                grid1.SetAcceptChanges();
                helper.Commit();
                DoInquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                ClosePrgFormNew();
            }
        }
        #endregion

        #region < EVENT AREA >

        private void grid1_ClickCellButton(object sender, CellEventArgs e)
        {
            try
            {
                if (Convert.ToString(e.Cell.Row.Cells["CLOSEFLAG"].Value) == "N")
                {
                    // 처리 버튼 클릭 시에 결감 처리 하도록
                    if (e.Cell.Column.ToString() == "BTN_CLOSER")
                    {
                        if (this.ShowDialog(
                            "작업장 : " + Convert.ToString(e.Cell.Row.Cells["WORKCENTERNAME"].Value) + " \r\n" +
                            "등록일 : " + Convert.ToString(e.Cell.Row.Cells["REGDATE"].Value) + " \r\n" +
                            "품목 : " + Convert.ToString(e.Cell.Row.Cells["ITEMNAME"].Value) + " \r\n" +
                            "결감사유 : " + Convert.ToString(e.Cell.Row.Cells["ULLAGENAME"].Value) + " \r\n" +
                            "수량 : " + Convert.ToString(e.Cell.Row.Cells["ULLAGEQTY"].Value) + " \r\n" +
                            "결감 처리 하시겠습니까?"
                            , Forms.DialogForm.DialogType.YESNO) == System.Windows.Forms.DialogResult.OK)
                        {
                            DBHelper helper = new DBHelper("", true);

                            //  결감 처리 
                            helper.ExecuteNoneQuery("USP_QM8000_U1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(e.Cell.Row.Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_WORKCENTERCODE", Convert.ToString(e.Cell.Row.Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_REGDATE", Convert.ToString(e.Cell.Row.Cells["REGDATE"].Value), DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ULLAGESEQ", Convert.ToInt32(e.Cell.Row.Cells["ULLAGESEQ"].Value), DbType.Int32, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CLOSEDATE", Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CLOSER", Convert.ToString(LoginInfo.UserID), DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_REMARK", Convert.ToString(e.Cell.Row.Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_EDIOR", Convert.ToString(LoginInfo.UserID), DbType.String, ParameterDirection.Input)
                              );

                            if (helper.RSCODE == "S")
                            {
                                helper.Commit();
                            }
                            else
                            {
                                helper.Rollback();
                                throw new Exception(helper.RSMSG);
                            }

                            this.DoInquire();
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

        private void grid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.grid1.Rows.Count == 0) return;
            if (((WIZ.Control.Grid)(sender)).ActiveCell == null) return;
            //숫자 그리드 헤더 컬럼명 찾기
            if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "ULLAGEQTY")
            {
                if (e.KeyChar == '.')
                {
                    num++;

                    if (num > 1)
                    {
                        e.Handled = true;
                        return;
                    }
                }
                //숫자,백스페이스만 입력받는다.                //8:백스페이스,45:마이너스,46:소수점
                if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 27)
                {
                    MessageBox.Show(Common.getLangText("숫자만 입력 가능합니다.", "MSG"));
                    e.Handled = true;
                }
            }
        }

        #endregion

        #region < METHOD AREA >

        #endregion

    }
}

using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
#region [ Info ]
/******************************************************************
 * 1. 작성자   : 정해상
 * 2. 작성일자 : 2015-08-06
 * 3. 수정자   : 
 * 4. 수정일자 :
 * 5. 화면설명 : 작업장별 품목 조회, 등록, 삭제, 수정
******************************************************************/
#endregion

namespace WIZ.BM
{
    public partial class BM0620Y : WIZ.Forms.BaseMDIChildForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        BizTextBoxManager btbManager = new BizTextBoxManager();
        int num = 0;


        private string sPlantCode = string.Empty;
        private double UPH = -1;
        int Grid2Index = 0;

        #endregion

        #region [ 생성자 ]
        public BM0620Y()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void BM0620Y_Load(object sender, EventArgs e)
        {
            try
            {
                BizGridManager gridManager_grid1 = new BizGridManager(grid1);
                BizGridManager gridManager_grid2 = new BizGridManager(grid2);

                #region [ grid ]
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(grid1);

                _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품목명", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "CAVITY", "단위수량", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Right, true, true, "#,##0.#", "nnnnnn.n", null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "CYCLETIME", "CycleTime", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true, "#,##0", null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "UPH", "UPH", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(grid2);

                //     ///row number
                grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
                grid1.DisplayLayout.Override.RowSelectorWidth = 50;
                grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                grid2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
                grid2.DisplayLayout.Override.RowSelectorWidth = 50;
                grid2.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grid2.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                #endregion

                #region [ PopUp & ComboBox ]
                //Form Load 시 로그인 시 선택한 공장 표시
                sPlantCode = CModule.GetAppSetting("Site", "10");

                //작업장 Popup(WorkCenterCode)
                //GetWorkCenterCode();
                btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600Y", new object[] { "", "", "" });
                btbManager.PopUpAdd(txtWorkCenterCode1, txtWorkCenterName1, "TBM0600Y", new object[] { "", "", "" });

                DataTable rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");




                #endregion
            }
            catch
            {

            }
        }

        #endregion

        #region [ Toolbar Area ]
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = string.Empty;
                string sWorkCenterCode = Convert.ToString(this.txtWorkCenterCode.Text);

                if (sWorkCenterCode.Length != 6)
                {
                    //작업장코드는 6자리 이므로 6자리가 아닐 경우..
                    this.ShowDialog(Common.getLangText("작업장을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                sPlantCode = sWorkCenterCode.Substring(0, 2) + "00";

                base.DoInquire();

                //해당 작업장에 등록되지 않은 모든 품목 조회
                grid1.DataSource = helper.FillTable("USP_BM0620Y_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)         //공장
                                                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input));       //라인

                grid1.DataBinds();

                //해당 작업장에 등록된 품목 조회
                grid2.DataSource = helper.FillTable("USP_BM0620Y_S2", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)         //공장
                                                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input));       //라인

                grid2.DataBinds();

                grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].CellActivation = Activation.NoEdit;

                grid2.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["ITEMCODE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["ITEMNAME"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["UPH"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Activation.NoEdit;

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

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            UltraGridUtil.DataRowDelete(this.grid2);
            this.grid2.UpdateData();
            if (((DataTable)grid2.DataSource).GetChanges() == null)
                return;

            DBHelper helper = new DBHelper("", true);

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in ((DataTable)grid2.DataSource).GetChanges().Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM0620Y_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)                       // 공장코드
                            , helper.CreateParameter("AS_WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input));           // 품목
                            drRow.Delete();
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            string sPlantCode = Convert.ToString(drRow["PLANTCODE"]);
                            helper.ExecuteNoneQuery("USP_BM0620Y_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CYCLETIME", Convert.ToDouble(drRow["cycletime"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_UPH", Convert.ToDouble(drRow["UPH"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CAVITY", Convert.ToDouble(drRow["CAVITY"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            sPlantCode = Convert.ToString(drRow["PLANTCODE"]);

                            helper.ExecuteNoneQuery("USP_BM0620Y_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CYCLETIME", Convert.ToDouble(drRow["cycletime"]), DbType.VarNumeric, ParameterDirection.Input)
                            , helper.CreateParameter("AS_UPH", Convert.ToDouble(drRow["UPH"]), DbType.VarNumeric, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CAVITY", Convert.ToDouble(drRow["CAVITY"]), DbType.VarNumeric, ParameterDirection.Input)
                            , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }
                this.ClosePrgFormNew();
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    // 데이터가 저장 되었습니다.
                    this.ShowDialog(Common.getLangText("데이터가 저장 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);

                    DoInquire();
                }
                else
                {
                    // 데이터 등록을 실패하였습니다.
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                helper.Rollback();
            }
            finally
            {
                Grid2Index = 0;
                UPH = -1;
                helper.Close();
            }
        }
        #endregion

        #region [ User Method Area ]

        #endregion

        #region [ Event Area ]

        /// <summary>
        /// 품목 추가
        /// </summary>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grid1.Rows.Count == 0) return;

                string sPlantCode = string.Empty;
                string sWorkCenterCode = string.Empty;
                string sWorkCenterName = string.Empty;

                if (this.grid2.Rows.Count != 0)
                {
                    sPlantCode = this.grid2.ActiveRow.Cells["PLANTCODE"].Value.ToString();
                    sWorkCenterCode = this.grid2.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
                    sWorkCenterName = this.grid2.ActiveRow.Cells["WORKCENTERNAME"].Value.ToString();
                }
                else
                {
                    sPlantCode = this.txtWorkCenterCode1.Text.Substring(0, 2) + "00";
                    sWorkCenterCode = this.txtWorkCenterCode1.Text;
                    sWorkCenterName = this.txtWorkCenterName1.Text;
                }

                if (sWorkCenterCode.Length != 6)
                {
                    this.ShowDialog(Common.getLangText("작업장을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }


                this.grid2.InsertRow();
                this.grid2.ActiveRow.Cells["PLANTCODE"].Value = sPlantCode;
                this.grid2.ActiveRow.Cells["WORKCENTERCODE"].Value = sWorkCenterCode;
                this.grid2.ActiveRow.Cells["WORKCENTERNAME"].Value = sWorkCenterName;
                this.grid2.ActiveRow.Cells["ITEMCODE"].Value = this.grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
                this.grid2.ActiveRow.Cells["ITEMNAME"].Value = this.grid1.ActiveRow.Cells["ITEMNAME"].Value.ToString();
                this.grid2.ActiveRow.Cells["CAVITY"].Value = 1;
                this.grid2.ActiveRow.Cells["cycletime"].Value = 0;
                this.grid2.ActiveRow.Cells["UPH"].Value = 0;
                this.grid2.ActiveRow.Cells["USEFLAG"].Value = "Y";

                int Gird1Index = this.grid1.ActiveRow.Index - 1;
                this.grid1.DeleteRow();
                if (this.grid1.Rows.Count == 0) return;
                if (Gird1Index == -1) this.grid1.Rows[0].Activated = true;
                else this.grid1.Rows[Gird1Index].Activated = true;

                grid2.ActiveRow.Cells["PLANTCODE"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["WORKCENTERCODE"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["WORKCENTERNAME"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["ITEMCODE"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["ITEMNAME"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["UPH"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;

                grid2.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["ITEMCODE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["ITEMNAME"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["UPH"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        /// <summary>
        /// 작업장별 품목 등록 내역 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grid2.Rows.Count == 0) return;
                string sItemCode2 = this.grid2.ActiveRow.Cells["ITEMCODE"].Value.ToString();
                string sItemNme2 = this.grid2.ActiveRow.Cells["ITEMNAME"].Value.ToString();

                int Gird1Index = this.grid2.ActiveRow.Index - 1;
                this.grid2.DeleteRow();
                if (this.grid2.Rows.Count == 0)
                {
                    this.grid1.InsertRow();

                    this.grid1.ActiveRow.Cells["ITEMCODE"].Value = sItemCode2;
                    this.grid1.ActiveRow.Cells["ITEMNAME"].Value = sItemNme2;
                    return;
                }
                else
                {
                    if (Gird1Index == -1) this.grid2.Rows[0].Activated = true;
                    else this.grid2.Rows[Gird1Index].Activated = true;

                    this.grid1.InsertRow();

                    this.grid1.ActiveRow.Cells["ITEMCODE"].Value = sItemCode2;
                    this.grid1.ActiveRow.Cells["ITEMNAME"].Value = sItemNme2;
                }

                grid1.ActiveRow.Cells["ITEMCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["ITEMNAME"].Activation = Activation.NoEdit;

                grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].CellActivation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        /// <summary>
        /// Cycletime 입력 후 UPH 값 계산
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid2_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.ToString() == "CYCLETIME")
            {
                if (UPH != Convert.ToDouble(e.Cell.Row.Cells["CYCLETIME"].Value))
                {
                    e.Cell.Row.Cells["UPH"].Value = Math.Round(3600 / Convert.ToDouble(e.Cell.Row.Cells["CYCLETIME"].Value) * Convert.ToDouble(e.Cell.Row.Cells["CAVITY"].Value), 0);
                }
            }

            if (DBNull.Value.Equals(e.Cell.Row.Cells["CAVITY"].Value))
            {
                //16-08-19 이영욱실장 요청으로 주석처리 최재형
                //MessageBox.Show("단위 수량을 입력하세요.");
                e.Cell.Row.Cells["CAVITY"].Value = e.Cell.Row.Cells["CAVITY"].OriginalValue;
            }
        }

        private void txtWorkCenterName_ValueChanged(object sender, EventArgs e)
        {
            //txtWorkCenterCode1.Text = txtWorkCenterCode.Text;
            txtWorkCenterName1.Text = txtWorkCenterName.Text;

            if (txtWorkCenterCode1.Text.Trim().Length != 6)
            {
                txtWorkCenterName.Text = string.Empty;
                txtWorkCenterName1.Text = string.Empty;
            }

        }

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Column.ToString() == "UPH")
            {
                sLabel3.Focus();
            }
        }

        private void txtWorkCenterCode_ValueChanged(object sender, EventArgs e)
        {
            if (txtWorkCenterCode.Text.Trim().Length == 6)
            {
                txtWorkCenterCode1.Text = txtWorkCenterCode.Text;
                txtWorkCenterName1.Text = txtWorkCenterName.Text;


            }
            else
            {
                txtWorkCenterCode1.Text = string.Empty;
                txtWorkCenterName1.Text = string.Empty;

                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid2);

            }
        }

        private void txtWorkCenterCode1_ValueChanged(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                StringBuilder command = new StringBuilder();
                string sWKCode = txtWorkCenterCode1.Text;

                command.AppendLine("SELECT WORKCENTERCODE                             AS CODE_ID,           ");
                command.AppendLine("      WORKCENTERNAME                              AS CODE_NAME,         ");
                command.AppendLine("      CASE WHEN WORKCENTERGUBUN  = 'QM' THEN '[QM] 품질'                ");
                command.AppendLine("           WHEN WORKCENTERGUBUN  = 'PP' THEN '[PP] 생산'                ");
                command.AppendLine("      WHEN WORKCENTERGUBUN  = 'PQ' THEN '[PQ] 생산+품질' END  AS WGUBUN ");
                command.AppendLine("  FROM TBM0600Y                                                         ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                                    ");
                command.AppendLine("   AND WORKCENTERCODE = '" + sWKCode + "'                                  ");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                if (dttemp.Rows.Count > 0)
                {
                    txtWorkCenterName.Text = Convert.ToString(dttemp.Rows[0]["CODE_NAME"]);
                    txtWorkcenterGubun_B.Text = Convert.ToString(dttemp.Rows[0]["WGUBUN"]);
                }

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


        private void grid2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (this.grid1.Rows.Count == 0) return;
            if (((WIZ.Control.Grid)(sender)).ActiveCell == null) return;
            //숫자 그리드 헤더 컬럼명 찾기
            if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "CAVITY")
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
                //숫자,백스페이스만 입력받는다.
                //if (!(Char.IsDigit(e.KeyChar)) || e.KeyChar == Convert.ToChar(Keys.Back)) //8:백스페이스,45:마이너스,46:소수점
                if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 27)
                {
                    MessageBox.Show(Common.getLangText("숫자만 입력 가능합니다.", "MSG"));
                    e.Handled = true;
                }
            }
        }
    }
}

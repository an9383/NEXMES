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
    public partial class BM2000 : WIZ.Forms.BaseMDIChildForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        BizTextBoxManager btbManager = new BizTextBoxManager();


        private string sPlantCode = string.Empty;
        private double UPH = -1;
        int Grid2Index = 0;

        #endregion

        #region [ 생성자 ]
        public BM2000()
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
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 110, 110, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "BANCODE", "작업반", false, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID", "작업자", false, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "작업자명", false, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.SetInitUltraGridBind(grid1);

                _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "BANCODE", "작업반", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKERID", "작업자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKERNAME", "작업자명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "LASTDATE", "최종변경일시", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

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

                grid1.DisplayLayout.Bands[0].Columns["WORKERID"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["WORKERNAME"].CellActivation = Activation.NoEdit;

                grid2.DisplayLayout.Bands[0].Columns["WORKERID"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["WORKERNAME"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["LASTDATE"].CellActivation = Activation.NoEdit;

                #endregion

                #region [ PopUp & ComboBox ]
                //Form Load 시 로그인 시 선택한 공장 표시
                sPlantCode = CModule.GetAppSetting("Site", "10");


                //사업장(PlantCode)
                btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600Y", new object[] { "", "", "" });
                btbManager.PopUpAdd(txtWorkCenterCode1, txtWorkCenterName1, "TBM0600Y", new object[] { "", "", "" });

                //사용여부
                DataTable rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");     //사용여부
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
                grid1.DataSource = helper.FillTable("USP_BM2000_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)         //공장
                                                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)         //라인
                                                                    , helper.CreateParameter("AS_BANCODE", "", DbType.String, ParameterDirection.Input));       //반

                grid1.DataBinds();

                //해당 작업장에 등록된 품목 조회
                grid2.DataSource = helper.FillTable("USP_BM2000_S2", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)         //공장
                                                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input));       //라인

                grid2.DataBinds();

                grid1.DisplayLayout.Bands[0].Columns["WORKERID"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["WORKERNAME"].CellActivation = Activation.NoEdit;

                grid2.DisplayLayout.Bands[0].Columns["WORKERID"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["WORKERNAME"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["LASTDATE"].CellActivation = Activation.NoEdit;


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

                            helper.ExecuteNoneQuery("USP_BM2000_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)                       // 공장코드
                            , helper.CreateParameter("AS_WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKERID", Convert.ToString(drRow["WORKERID"]), DbType.String, ParameterDirection.Input));           // 품목
                            drRow.Delete();
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            string sPlantCode = Convert.ToString(drRow["PLANTCODE"]);
                            helper.ExecuteNoneQuery("USP_BM2000_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKERID", Convert.ToString(drRow["WORKERID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            sPlantCode = Convert.ToString(drRow["PLANTCODE"]);

                            helper.ExecuteNoneQuery("USP_BM2000_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKERID", Convert.ToString(drRow["WORKERID"]), DbType.String, ParameterDirection.Input)
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
        /// 작업자 추가
        /// </summary>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grid1.Rows.Count == 0) return;

                string sPlantCode = string.Empty;
                string sWorkCenterCode = string.Empty;
                string sWorkCenterName = string.Empty;

                sPlantCode = this.txtWorkCenterCode1.Text.Substring(0, 2) + "00";
                sWorkCenterCode = this.txtWorkCenterCode1.Text.ToString();
                sWorkCenterName = this.txtWorkCenterName1.Text.ToString();

                if (sWorkCenterCode.Length != 6)
                {
                    this.ShowDialog(Common.getLangText("작업장을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                if (sWorkCenterName.Length == 0)
                {
                    this.ShowDialog(Common.getLangText("작업장을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                this.grid2.InsertRow();
                this.grid2.ActiveRow.Cells["PLANTCODE"].Value = sPlantCode;
                this.grid2.ActiveRow.Cells["WORKCENTERCODE"].Value = sWorkCenterCode;
                this.grid2.ActiveRow.Cells["WORKCENTERNAME"].Value = sWorkCenterName;
                this.grid2.ActiveRow.Cells["BANCODE"].Value = this.grid1.ActiveRow.Cells["BANCODE"].Value.ToString();
                this.grid2.ActiveRow.Cells["WORKERID"].Value = this.grid1.ActiveRow.Cells["WORKERID"].Value.ToString();
                this.grid2.ActiveRow.Cells["WORKERNAME"].Value = this.grid1.ActiveRow.Cells["WORKERNAME"].Value.ToString();
                this.grid2.ActiveRow.Cells["USEFLAG"].Value = "Y";

                int Gird1Index = this.grid1.ActiveRow.Index - 1;
                this.grid1.DeleteRow();
                if (this.grid1.Rows.Count == 0) return;
                if (Gird1Index == -1) this.grid1.Rows[0].Activated = true;
                else this.grid1.Rows[Gird1Index].Activated = true;

                grid1.ActiveRow.Cells["WORKERID"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["WORKERNAME"].Activation = Activation.NoEdit;

                grid2.ActiveRow.Cells["WORKERID"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["WORKERNAME"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["LASTDATE"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        /// <summary>
        /// 작업장별 작업자 등록 내역 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grid2.Rows.Count == 0) return;
                string sPlantCode2 = Convert.ToString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                string sWorkerID2 = this.grid2.ActiveRow.Cells["WORKERID"].Value.ToString();
                string sWorkerName2 = this.grid2.ActiveRow.Cells["WORKERNAME"].Value.ToString();
                string sBanCode2 = this.grid2.ActiveRow.Cells["BANCODE"].Value.ToString();

                int Gird1Index = this.grid2.ActiveRow.Index - 1;
                this.grid2.DeleteRow();
                if (this.grid2.Rows.Count == 0)
                {
                    this.grid1.InsertRow();

                    this.grid1.ActiveRow.Cells["PLANTCODE"].Value = sPlantCode2;
                    this.grid1.ActiveRow.Cells["WORKERID"].Value = sWorkerID2;
                    this.grid1.ActiveRow.Cells["WORKERNAME"].Value = sWorkerName2;
                    this.grid1.ActiveRow.Cells["BANCODE"].Value = sBanCode2;
                    return;
                }
                else
                {
                    if (Gird1Index == -1) this.grid2.Rows[0].Activated = true;
                    else this.grid2.Rows[Gird1Index].Activated = true;

                    this.grid1.InsertRow();

                    this.grid1.ActiveRow.Cells["PLANTCODE"].Value = sPlantCode2;
                    this.grid1.ActiveRow.Cells["WORKERID"].Value = sWorkerID2;
                    this.grid1.ActiveRow.Cells["WORKERNAME"].Value = sWorkerName2;
                    this.grid1.ActiveRow.Cells["BANCODE"].Value = sBanCode2;
                }

                grid1.ActiveRow.Cells["WORKERID"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["WORKERNAME"].Activation = Activation.NoEdit;

                grid2.ActiveRow.Cells["WORKERID"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["WORKERNAME"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["LASTDATE"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        private void txtWorkCenterName_ValueChanged(object sender, EventArgs e)
        {
            txtWorkCenterName1.Text = txtWorkCenterName.Text;

            if (txtWorkCenterCode1.Text.Trim().Length != 6)
            {
                txtWorkCenterName.Text = string.Empty;
                txtWorkCenterName1.Text = string.Empty;
            }
        }

        private void txtWorkCenterCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13 && txtWorkCenterCode.Text.Trim().Length == 6)
                {
                    txtWorkCenterCode1.Text = txtWorkCenterCode.Text;
                    txtWorkCenterName1.Text = txtWorkCenterName.Text;
                }

                if (txtWorkCenterCode.Text.Trim().Length == 0)
                {
                    txtWorkCenterCode1.Text = string.Empty;
                    txtWorkCenterName1.Text = string.Empty;
                }
            }
            catch
            {
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

                command.AppendLine("SELECT WORKCENTERCODE                             AS CODE_ID, ");
                command.AppendLine("      WORKCENTERNAME                            AS CODE_NAME");
                command.AppendLine("  FROM TBM0600Y                                               ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                          ");
                command.AppendLine("   AND WORKCENTERCODE = '" + sWKCode + "'                                          ");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                //WIZ.Common.FillComboboxMaster(this.cboWorkCenterCode_H, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

                if (dttemp.Rows.Count > 0)
                {
                    txtWorkCenterName.Text = Convert.ToString(dttemp.Rows[0]["CODE_NAME"]);
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
    }
}

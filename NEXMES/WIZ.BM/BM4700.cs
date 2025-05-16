#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM4700
//   Form Name    : 작업자 마스터
//   Name Space   : WIZ.BM
//   Created Date : 2012-03-19
//   Made By      : WIZCORE
//   Description  : 작업자(Workcenter) 관리 화면
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
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
    public partial class BM4700 : WIZ.Forms.BaseMDIChildForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private string sPlantCode = string.Empty;

        #endregion

        #region [ 생성자 ]
        public BM4700()
        {
            InitializeComponent();
        }

        private void BM4700_Load(object sender, EventArgs e)
        {
            BizGridManager bizGridManager = new BizGridManager(grid1);

            #region 그리드
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 180, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ID", "지그비ID", true, GridColDataType_emu.VarChar, 100, 4, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장ⓟ", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 250, 90, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GATEWAYID", "게이트웨이ID", true, GridColDataType_emu.VarChar, 120, 110, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "VALUE", "COUNT값", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LASTDATE", "최종수집일시", true, GridColDataType_emu.VarChar, 170, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ID"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #endregion
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600Y", new object[] { cboPlantCode_H, "", "" });
            bizGridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "TBM0600Y", new string[] { "PLANTCODE", "", "", "Y" });

            sPlantCode = CModule.GetAppSetting("Site", "10");
            cboPlantCode_H.Value = sPlantCode;
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
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sZigbeeID = txtID.Text;
                string sWorkCenterCode = txtWorkCenterCode.Text;
                string sUseFlag = Convert.ToString(cboUseFlag_H.Value);

                base.DoInquire();

                grid1.DataSource = helper.FillTable("USP_BM4700_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("@AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@AS_ID", sZigbeeID, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["ID"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["VALUE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["LASTDATE"].CellActivation = Activation.NoEdit;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            base.DoNew();

            this.grid1.InsertRow();
            this.grid1.SetDefaultValue("PLANTCODE", this.sPlantCode);
            this.grid1.SetDefaultValue("USEFLAG", "Y");
            grid1.ActiveRow.Cells["VALUE"].Activation = Activation.Disabled;
            grid1.ActiveRow.Cells["LASTDATE"].Activation = Activation.Disabled;

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
                this.ClosePrgFormNew();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (Convert.ToString(drRow["ID"]).Length != 4)
                        {
                            this.ShowDialog(Common.getLangText("지그비ID를 확인하세요(4자리)", "MSG"), Forms.DialogForm.DialogType.OK); //지그비ID를 확인하세요(4자리).
                            return;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM4700_D1", CommandType.StoredProcedure
                                , helper.CreateParameter("@AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("@AS_ID", Convert.ToString(drRow["ID"]), DbType.String, ParameterDirection.Input));         // 공장코드

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            if (Convert.ToString(drRow["ID"]).Length != 4)
                            {
                                this.ShowDialog(Common.getLangText("지그비ID를 확인하세요(4자리)", "MSG"), Forms.DialogForm.DialogType.OK); //지그비ID를 확인하세요(4자리).
                                return;
                            }

                            helper.ExecuteNoneQuery("USP_BM4700_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("@AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("@AS_ID", Convert.ToString(drRow["ID"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("@AS_WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("@AS_GATEWAYID", Convert.ToString(drRow["GATEWAYID"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("@AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM4700_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("@AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("@AS_WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("@AS_ID", Convert.ToString(drRow["ID"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("@AS_GATEWAYID", Convert.ToString(drRow["GATEWAYID"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("@AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }

                }
                this.ClosePrgFormNew();
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("데이터가 저장되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);

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
                CancelProcess = true;

                helper.Close(false);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close(false);

            }
        }
        #endregion

        private void grid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        #region [ User Method Area ]
        /// <summary>
        /// 숫자입력
        /// </summary>
        /// <param name="_RecVal"></param>
        /// <returns></returns>
        public static bool _IsNumber(string _RecVal)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[^\d.]+");

            if (!regex.IsMatch(_RecVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region < EVENT AREA >
        #endregion

    }
}
#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  BM6000
//   Form Name    : 검사항목관리 조회
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
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
    public partial class BM6000 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        #endregion

        #region < CONSTRUCTOR >
        public BM6000()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtInspCode, txtInspName, "TBM6000", new object[] { "", "" }); //검사항목
        }
        #endregion

        #region 폼 로더
        private void BM6000_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  //사용유무
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            #endregion

            #region Grid MERGE
            #endregion Grid MERGE
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
                base.DoInquire();
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string MEASURECODE = this.txtInspCode.Text.Trim();    //검사 코드
                string sUseFlag = DBHelper.nvlString(cboUseFlag_H.Value);  //사용여부

                grid1.DataSource = helper.FillTable("USP_BM6000_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPCODE", MEASURECODE, DbType.String, ParameterDirection.Input)   //검사 코드   
                                                                   , helper.CreateParameter("USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)  //사용 여부
                                                                   );
                grid1.DataBinds();

                //조회시 미사용은 노란색으로 표시
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value.ToString()) == "N")
                    {
                        grid1.Rows[i].Appearance.BackColor = Color.FromArgb(254, 255, 100);
                    }

                }
                grid1.DisplayLayout.Bands[0].Columns["INSPCODE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Activation.NoEdit;
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
            try
            {
                base.DoNew();

                this.grid1.InsertRow();

                this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";

                grid1.ActiveRow.Cells["INSPCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            this.grid1.DeleteRow();

            //if (this.ShowDialog("저장시, 관련 내용 모두 변경됩니다.") == System.Windows.Forms.DialogResult.Cancel)
            //{
            //    this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
            //    return;
            //}
            //// 삭제 되지않고, 사용안함으로 업데이트
            //this.grid1.ActiveRow.Cells["USEFLAG"].Value = "N";

        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            string INSPCODE = string.Empty;
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

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        #region [ validation 체크 ]
                        if (Convert.ToString(drRow["INSPNAME"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("검사항목 명은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["INSPNAME"]).Length > 20)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("항목 명은 최대 20자리까지 입력할 수 있습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM6000_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)   //측정 코드   
                                                    , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                    );

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM6000_I1"
                                                    , CommandType.StoredProcedure
                                                    // , helper.CreateParameter("MEASURECODE", Convert.ToString(drRow["MEASURECODE"]), DbType.String, ParameterDirection.Input) DB에서 자동채번
                                                    , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INSPNAME", Convert.ToString(drRow["INSPNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INSPCODE", DbType.String, ParameterDirection.Output, '0', 30));
                            INSPCODE = helper.Parameters[4].Value.ToString();
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM6000_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INSPNAME", Convert.ToString(drRow["INSPNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            INSPCODE = Convert.ToString(this.grid1.ActiveRow.Cells["INSPCODE"].Value);
                            #endregion
                            break;
                    }
                }
                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();

                    //   DoInquire();
                    // 저장후, 기존행 active
                    DoInquire();
                    for (int i = 0; i < this.grid1.Rows.Count; i++)
                    {
                        if (Convert.ToString(this.grid1.Rows[i].Cells["INSPCODE"].Value) == INSPCODE)
                        {
                            this.grid1.Rows[i].Activated = true;
                            break;
                        }
                    }
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        private void grid1_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.ToString() != "USEFLAG")
                return;

            this.grid1.UpdateData();

            string a = e.Cell.Value.ToString();
            if (a == "N")
            {
                if (this.ShowDialog(Common.getLangText("변경 후 저장시 검사항목별 측정관리, 품목별 검사관리, 작업장 품목별 검사관리의 사용여부가 모두 미사용으로 변경됩니다. 변경하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
                    return;
                }
            }
            else
            {
                if (this.ShowDialog(Common.getLangText("변경 후 저장시 검사항목별 측정관리, 품목별 검사관리, 작업장 품목별 검사관리의 사용여부는 변경되지 않습니다. 변경하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.grid1.ActiveRow.Cells["USEFLAG"].Value = "N";
                    return;
                }
            }
        }

    }
}


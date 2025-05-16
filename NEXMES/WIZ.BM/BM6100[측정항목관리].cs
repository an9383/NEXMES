#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM6100
//   Form Name    : 측정항목관리
//   Name Space   : WIZ.BM
//   Created Date : 2017-06-15
//   Made By      : WIZCORE 남부사무소 개발팀 사원 윤근욱
//   Description  : 
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
    public partial class BM6100 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        #endregion

        #region < CONSTRUCTOR >
        public BM6100()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMesrCode, txtMesrName, "TBM6100", new object[] { "", "" }); //측정항목
        }
        #endregion

        #region < FORM LOAD >
        private void BM6100_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MESRCODE", "측정항목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MESRNAME", "측정항목명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.DateTime24, 170, 140, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.DateTime24, 170, 140, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["MESRCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["MESRNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
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
                _GridUtil.Grid_Clear(grid1);

                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
                string sMesrCode = DBHelper.nvlString(txtMesrCode.Value);    //측정항목
                string sUseFlag = DBHelper.nvlString(cboUseFlag_H.Value);   //사용여부

                rtnDtTemp = helper.FillTable("USP_BM6100_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_MESRCODE", sMesrCode, DbType.String, ParameterDirection.Input)   //측정 코드   
                                                                   , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds();
                    }
                    else
                    {
                        this.ClosePrgFormNew();
                        this.ShowDialog(Common.getLangText("조회 할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
                else if (helper.RSCODE == "E")
                {
                    this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);
                    _GridUtil.Grid_Clear(grid1);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
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

                grid1.ActiveRow.Cells["PLANTCODE"].Value = cboPlantCode_H.Value;
                grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
                grid1.ActiveRow.Cells["MESRCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {

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
                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        #region [ validation 체크 ]
                        if (Convert.ToString(drRow["PLANTCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("사업장은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["MESRNAME"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("측정항목명은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["MESRNAME"]).Length > 40)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("측정항목명은 최대 40자리까지 입력할 수 있습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            //drRow.RejectChanges();

                            //helper.ExecuteNoneQuery("USP_BM6100_D1"
                            //                        , CommandType.StoredProcedure
                            //                        , helper.CreateParameter("PLANTCODE",    WIZ.LoginInfo.PlantCode,              DbType.String, ParameterDirection.Input)
                            //                        , helper.CreateParameter("MEASURECODE",  Convert.ToString(drRow["MEASURECODE"]), DbType.String, ParameterDirection.Input));   //측정 코드   

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM6100_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MESRNAME", Convert.ToString(drRow["MESRNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM6100_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MESRCODE", Convert.ToString(drRow["MESRCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MESRNAME", Convert.ToString(drRow["MESRNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }
                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();
                    this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    CancelProcess = true;
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                ShowErrorMessage(ex);
            }
            finally
            {
                helper.Close();
                DoInquire();
            }
        }
        #endregion
    }
}


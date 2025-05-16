#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : BM3000                                                                                                                                                                          
//   Form Name    : 작업장별 비가동 내역                                                                                                                                                                   
//   Name Space   : WIZ.BM                                                                                                                                                                        
//   Created Date : 2012-03-19 (2013-07-06 신규 재 개발)                                                                                                                                                                    
//   Made By      : WIZCORE                                                                                                                                              
//   Description  : 작업장별로 발생가능 한 비가동정보를 관리 한다                                                                                                                                                           
// *---------------------------------------------------------------------------------------------*                                                                                                  
#endregion

#region <USING AREA>


using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{

    public partial class BM3000 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM3000()
        {
            InitializeComponent();

            // grid pop-up 처리를 위한 정의 (WorkCenterCode(작업장 TBM0500),비가동유형
            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("WorkCenterCode", "WorkCenterName", "TBM0600", new string[] { "PlantCode", "", "", "" });  //작업장(WC)
            gridManager.PopUpAdd("StopCode", "StopDesc", "TBM1100", new string[] { "PlantCode", "StopClass", "" });          //비가동


            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { "", "", "", "Y" });
        }

        #endregion

        #region BM3000_Load
        private void BM3000_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);


            // InitColumnUltraGrid            

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순번", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StopClass", "비가동유형", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StopCode", "비가동코드", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StopDesc", "비가동명", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakerNM", "등록자명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditorNM", "수정자명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            ///////MERGE 
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;



            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장                                                                                                                              
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("StopClass");         //비가동유형                                                                                                                                                                                  
            WIZ.Common.FillComboboxMaster(this.cboStopClass_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "StopClass", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");            //사용여부                                                                                                                 
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");



            #endregion
        }
        #endregion BM3000_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);


            try
            {
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string WorkCenterCode = txtWorkCenterCode.Text.Trim();
                string sStopClass = DBHelper.nvlString(this.cboStopClass_H.Value);
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                base.DoInquire();

                grid1.DataSource = helper.FillTable("USP_BM3000_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkCenterCode", WorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("StopClass", sStopClass, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();

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


            _GridUtil.AddRow(this.grid1);
            //this.grid1.SetDefaultValue("PlantCode", "SY");

            UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");         // 공장(사업장)
            UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkCenterCode");    // WC코드
            UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkCenterName");    // WC명
            UltraGridUtil.ActivationAllowEdit(this.grid1, "DisplayNo");         // 표시순번
            UltraGridUtil.ActivationAllowEdit(this.grid1, "StopClass");         // 비가동유형
            UltraGridUtil.ActivationAllowEdit(this.grid1, "StopCode");          // 비가동코드
            UltraGridUtil.ActivationAllowEdit(this.grid1, "StopDesc");          // 비가동명
            UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag");           // 사용유무            
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
                    return;

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "공장 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            //param = new System.Data.Common.DbParameter[5];

                            //param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input);           // 공장(사업장)
                            //param[1] = helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input);
                            //param[2] = helper.CreateParameter("StopCode", drRow["StopCode"].ToString(), DbType.String, ParameterDirection.Input);             // 정지사유
                            //param[3] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[4] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_BM3000_D1N", CommandType.StoredProcedure, param);

                            //if (param[3].Value.ToString() == "E") throw new Exception(param[4].Value.ToString());
                            helper.ExecuteNoneQuery("USP_BM3000_D1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)                     // 공장코드
                                                    , helper.CreateParameter("WorkCenterCode", Convert.ToString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)           // WorkCenter코드
                                                    , helper.CreateParameter("StopCode", Convert.ToString(drRow["StopCode"]), DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            //param = new System.Data.Common.DbParameter[8];

                            //param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input);            // 공장(사업장)
                            //param[1] = helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input);
                            //param[2] = helper.CreateParameter("StopCode", drRow["StopCode"].ToString(), DbType.String, ParameterDirection.Input);              // 정지사유
                            //param[3] = helper.CreateParameter("DisplayNo", drRow["DisplayNo"].ToString(), DbType.String, ParameterDirection.Input);            // Display No

                            //param[4] = helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input);
                            //param[5] = helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input);

                            //param[6] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[7] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_BM3000_I1N", CommandType.StoredProcedure, param);

                            //if (param[6].Value.ToString() == "E") throw new Exception(param[7].Value.ToString());
                            helper.ExecuteNoneQuery("USP_BM3000_I1N", CommandType.StoredProcedure
                                                   , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("WorkCenterCode", Convert.ToString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("StopCode", Convert.ToString(drRow["StopCode"]), DbType.String, ParameterDirection.Input)          //                                
                                                   , helper.CreateParameter("DisplayNo", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input));
                            //, helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            //param = new System.Data.Common.DbParameter[8];
                            //param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input);            // 공장(사업장)
                            //param[1] = helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input);
                            //param[2] = helper.CreateParameter("StopCode", drRow["StopCode"].ToString(), DbType.String, ParameterDirection.Input);              // 정지사유
                            //param[3] = helper.CreateParameter("DisplayNo", drRow["DisplayNo"].ToString(), DbType.String, ParameterDirection.Input);            // Display No

                            //param[4] = helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input);
                            //param[5] = helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input);

                            //param[6] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[7] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_BM3000_U1N", CommandType.StoredProcedure, param);

                            //if (param[6].Value.ToString() == "E") throw new Exception(param[7].Value.ToString());
                            helper.ExecuteNoneQuery("USP_BM3000_U1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkCenterCode", Convert.ToString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("StopCode", Convert.ToString(drRow["StopCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DisplayNo", drRow["DisplayNo"], DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"], DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));               // 수정자

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PlantCode");
                helper.Commit();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                throw (ex);
            }
            finally
            {
                helper.Close();

            }
        }
        #endregion

        #region < EVENT AREA >

        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의

        #endregion

    }
}


#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : BM2400                                                                                                                                                                          
//   Form Name    : 작업장별 투입 작업자
//   Name Space   : WIZ.BM                                                                                                                                                                        
//   Created Date : 2012-03-19 (2013-07-10 신규 재 개발)                                                                                                                                                                    
//   Made By      : WIZCORE                                                                                                                                            
//   Description  : 작업장별로 기본 작업자 정보를 관리 한다                                                                                                                                                           
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

    public partial class BM2400 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM2400()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWorkerID, txtWorkerName, "TBM0200", new object[] { cboPlantCode_H, "", "", "", "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", cboUseFlag_H });

            // grid pop-up 처리를 위한 정의 (WorkCenterCode(작업장 TBM0400),불량유형
            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("WorkerID", "WorkerName", "TBM0200", new string[] { "PlantCode", "", "", "", "", "", "" });  //작업자
            gridManager.PopUpAdd("WorkCenterCode", "WorkCenterName", "TBM0600", new string[] { "PlantCode", "", "", "" });  //작업장(WC)
            gridManager.PopUpAdd("OPCode", "OPName", "TBM0400", new string[] { "PlantCode", "", "", "" });  //공정(작업장)
            gridManager.PopUpAdd("WorkerID", "WorkerName", "TBM0200", new string[] { "PlantCode", "", "", "", "", "", "" });  //작업자
            gridManager.PopUpAdd("LineCode", "LineName", "TBM0500", new string[] { "PlantCode", "" });
        }

        #endregion

        #region BM2400_Load
        private void BM2400_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);


            // InitColumnUltraGrid            

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "공정", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null); ;
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "공정명", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineCode", "라인", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null); ;
            _GridUtil.InitColumnUltraGrid(grid1, "LineName", "라인명", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerID", "작업자ID", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerName", "작업자", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StartDate", "투입시작일시", true, GridColDataType_emu.DateTime, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EndDate", "투입종료일시", true, GridColDataType_emu.DateTime, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            ///////MERGE 
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #region Grid MERGE
            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;
            #endregion Grid MERGE

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장                                                                                                                              
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");            //사용여부                                                                                                                 
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");



            #endregion

        }
        #endregion BM2400_Load

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
                string sWorkCenterCode = txtWorkCenterCode.Text.Trim();
                string sWorkerID = txtWorkerID.Text.Trim();
                string sWorkerName = txtWorkerName.Text.Trim();
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);

                grid1.DataSource = helper.FillTable("USP_BM2400_S2N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkerID", sWorkerID, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkerName", sWorkerName, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();

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
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();

                _GridUtil.AddRow(this.grid1);
                //this.grid1.SetDefaultValue("PlantCode", "SY");

                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");           // 공장(사업장)
                UltraGridUtil.ActivationAllowEdit(this.grid1, "OPCode");              // 공정코드                
                UltraGridUtil.ActivationAllowEdit(this.grid1, "LineCode");            // 라인코드                
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkCenterCode");      // 작업장                                                 
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkerID");            // 작업자ID
                UltraGridUtil.ActivationAllowEdit(this.grid1, "StartDate");           // 시작일자
                UltraGridUtil.ActivationAllowEdit(this.grid1, "EndDate");             // 종료일자
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag");             // 사용여부
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                string sPlantCode = "";

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;
                base.DoSave();


                foreach (DataRow drRow in dt.Rows)  // .GetChanges().Rows = 변경된 Rows 만 작업
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

                            //param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input);             // 공장(사업장)
                            //param[1] = helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input);   //WorkCenter코드
                            //param[2] = helper.CreateParameter("WorkerID", drRow["WorkerID"].ToString(), DbType.String, ParameterDirection.Input);               // 작업자ID
                            //param[3] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[4] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_BM2400_D1N", CommandType.StoredProcedure, param);

                            //if (param[3].Value.ToString() == "E") throw new Exception(param[4].Value.ToString());
                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_BM2400_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkCenterCode", Convert.ToString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkerID", Convert.ToString(drRow["WorkerID"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            //param = new System.Data.Common.DbParameter[9];

                            //param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input);            // 공장(사업장)
                            //param[1] = helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input);  // WorkCenter코드
                            //param[2] = helper.CreateParameter("WorkerID", drRow["WorkerID"].ToString(), DbType.String, ParameterDirection.Input);              // 작업자ID
                            //param[3] = helper.CreateParameter("StartDate", drRow["StartDate"].ToString(), DbType.String, ParameterDirection.Input);            // 투입일시
                            //param[4] = helper.CreateParameter("EndDate", drRow["EndDate"].ToString(), DbType.String, ParameterDirection.Input);                // 종료일시

                            //param[5] = helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input);
                            //param[6] = helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input);

                            //param[7] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[8] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_BM2400_I1N", CommandType.StoredProcedure, param);

                            //if (param[7].Value.ToString() == "E") throw new Exception(param[8].Value.ToString());
                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_BM2400_I1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkCenterCode", Convert.ToString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkerID", Convert.ToString(drRow["WorkerID"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("StartDate", drRow["StartDate"], DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EndDate", drRow["EndDate"], DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            //param = new System.Data.Common.DbParameter[9];

                            //param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input);     // 공장(사업장)
                            //param[1] = helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input);           // 공정코드
                            //param[2] = helper.CreateParameter("WorkerID", drRow["WorkerID"].ToString(), DbType.String, ParameterDirection.Input);       // 작업자ID
                            //param[3] = helper.CreateParameter("StartDate", drRow["StartDate"].ToString(), DbType.String, ParameterDirection.Input);           // 투입일시
                            //param[4] = helper.CreateParameter("EndDate", drRow["EndDate"].ToString(), DbType.String, ParameterDirection.Input);       // 종료일시
                            //param[5] = helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input);
                            //param[6] = helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input);

                            //param[7] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[8] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_BM2400_U1N", CommandType.StoredProcedure, param);

                            //if (param[7].Value.ToString() == "E") throw new Exception(param[8].Value.ToString());

                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_BM2400_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkCenterCode", Convert.ToString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkerID", Convert.ToString(drRow["WorkerID"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("StartDate", Convert.ToString(drRow["StartDate"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EndDate", Convert.ToString(drRow["EndDate"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));
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
                throw ex;

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

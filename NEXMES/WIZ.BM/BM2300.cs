#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : BM2300                                                                                                                                                                          
//   Form Name    : 작업장별 기본 작업자
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

    public partial class BM2300 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM2300()
        {
            InitializeComponent();
            //    * TBM0200 : 작업자
            //*          - 1 : 작업자ID, 2 : 작업자명, param[0] : PlantCode, Param[1] : OPCOde
            //*          , Param[2] : LineCode, Param[3] : WorkCenterCode, Param[4] : UseFlag

            //   * TBM0400 : 공정(작업장) 
            //*          - 1 : OPCode, 2 : OPName, param[0] : PlantCode, param[1] : UseFlag

            // grid pop-up 처리를 위한 정의 (WorkCenterCode(작업장 TBM0400),불량유형
            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("OPCode", "OPName", "TBM0400", new string[] { "PlantCode", "", "", "" });  //공정(작업장)
            gridManager.PopUpAdd("WorkerID", "WorkerName", "TBM0200", new string[] { "PlantCode", "", "", "", "", "", "" });  //작업자


            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { "", "", "", "Y" });



        }

        #endregion

        #region BM2300_Load
        private void BM2300_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);


            // InitColumnUltraGrid            

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "공정코드", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "공정명", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerID", "작업자ID", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerName", "작업자", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakerNM", "등록자명", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditorNM", "수정자명", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

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
        #endregion BM2300_Load

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
                string sOPCode = txtOPCode.Text.Trim();
                string sWorkerID = txtWorkerID.Text.Trim();
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);

                grid1.DataSource = helper.FillTable("USP_BM2300_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkerID", sWorkerID, DbType.String, ParameterDirection.Input)
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
                this.grid1.SetDefaultValue("PlantCode", "820");

                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");   // 공장(사업장)
                UltraGridUtil.ActivationAllowEdit(this.grid1, "OPCode");      // 공정코드                
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkerID");    // 작업자ID
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag");     // 사용여부
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MakeDate");    // 등록일자
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Maker");       // 등록자
                UltraGridUtil.ActivationAllowEdit(this.grid1, "EditDate");    // 수정일자
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Editor");      // 수정자            

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
                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_BM2300_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCode", Convert.ToString(drRow["OPCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkerID", Convert.ToString(drRow["WorkerID"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_BM2300_I1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCode", Convert.ToString(drRow["OPCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkerID", Convert.ToString(drRow["WorkerID"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_BM2300_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCode", Convert.ToString(drRow["OPCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkerID", Convert.ToString(drRow["WorkerID"]), DbType.String, ParameterDirection.Input)
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
#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : BM4300                                                                                                                                                                          
//   Form Name    : 메모(알람)관리                                                                                                                                                                     
//   Name Space   : WIZ.BM                                                                                                                                                                        
//   Created Date : 2012-03-19(2013-07-01전면수정)                                                                                                                                                                      
//   Made By      : WIZCORE                                                                                                                                                
//   Description  : 각종 메모 사항및 알람을 등록  관리 화면                                                                                                                                                                
// *---------------------------------------------------------------------------------------------*                                                                                                  
#endregion


#region <USING AREA>


using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{

    public partial class BM4300 : WIZ.Forms.BaseMDIChildForm
    {

        #region <MEMBER AREA>
        // 변수나 Form에서 사용될 Class를 정의
        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        private DataTable DtChange = null;

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();

        // POP-UP 처리를 위한 관리용
        BizGridManager gridManager;

        #endregion

        #region < CONSTRUCTOR >
        public BM4300()
        {
            InitializeComponent();
            // grid pop-up 처리를 위한 정의
            gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("WorkCenterCode", "WorkCenterName", "TBM0600", new string[] { "PlantCode", "OPCode", "", "" });  //작압장(WC)
            gridManager.PopUpAdd("OPCode", "OPName", "TBM0400", new string[] { "PlantCode", "" });   //공정
            gridManager.PopUpAdd("LineCode", "LineName", "TBM0500", new string[] { "PlantCode", "" });   //라인

        }

        #endregion

        #region BM4300_Load
        private void BM4300_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            //  _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            // InitColumnUltraGrid  93 125 125 125 125 128 104 125 125 125 125 125 116 125 125 125 125 125 73 125           
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", true, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MemoID", "메모ID", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MemoTitle", "제목", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MemoDesc", "내용", true, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "AllAramFlag", "전체계시", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StartDate", "계시시작일자", true, GridColDataType_emu.YearMonthDay, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EndDate", "계시종료일자", true, GridColDataType_emu.YearMonthDay, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakerNM", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditorNM", "수정자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


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
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장                                                                                                                              
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0060_CODE("WorkCenterCode");  //라인
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WorkCenterCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");            //사용여부                                                                                                                 
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("YesNo");            //전체계시                                                                                                                 
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "AllAramFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

        }
        #endregion BM4300_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                string sUseFlag = DBHelper.nvlString(cboUseFlag_H.Value, "");
                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value, "");
                string sMemoDesc = Convert.ToString(this.txtMemoDesc_H.Value);
                /*
                              string sMemoDesc = (string)this.txtMemoDesc_H.Value;
                              if (sMemoDesc == null)
                              sMemoDesc = "";
                */
                base.DoInquire();

                grid1.DataSource = helper.FillTable("USP_BM4300_S1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("MemoDesc", sMemoDesc, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));

                grid1.DataBind();
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

                int iRow = grid1.InsertRow();
                this.grid1.SetDefaultValue("PlantCode", WIZ.LoginInfo.PlantCode);
                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode", iRow);        // 적용사업장(공장)       
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkCenterCode", iRow);   // WorkCenter코드
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MemoID", iRow);     //메세지 ID
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MemoTitle", iRow);        // 제목                  
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MemoDesc", iRow);         // 내용                  
                UltraGridUtil.ActivationAllowEdit(this.grid1, "AllAramFlag", iRow);      // 전체계시   
                UltraGridUtil.ActivationAllowEdit(this.grid1, "StartDate", iRow);        // 계시 시작 일자         
                UltraGridUtil.ActivationAllowEdit(this.grid1, "EndDate", iRow);          // 계시 종료 일자         
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag", iRow);          // 사용유무               
            }
            catch (Exception ex)
            {
                throw ex;
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
            DBHelper helper = new DBHelper("", true);

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                base.DoSave();

                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.UpdateData();

                foreach (DataRow drRow in ((DataTable)grid1.DataSource).Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM4300_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("MemoID", drRow["MemoID"].ToString(), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM4300_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MemoDesc", drRow["MemoDesc"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AllAramFlag", drRow["AllAramFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("StartDate", (drRow["StartDate"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(drRow["StartDate"]), DbType.DateTime, ParameterDirection.Input)
                                                    , helper.CreateParameter("EndDate", (drRow["EndDate"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(drRow["EndDate"]), DbType.DateTime, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;

                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM4300_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MemoID", drRow["MemoID"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MemoTitle", drRow["MemoTitle"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MemoDesc", drRow["MemoDesc"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AllAramFlag", drRow["AllAramFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("StartDate", (drRow["StartDate"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(drRow["StartDate"]), DbType.DateTime, ParameterDirection.Input)
                                                    , helper.CreateParameter("EndDate", (drRow["EndDate"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(drRow["EndDate"]), DbType.DateTime, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }

                helper.Commit();

            }
            catch (Exception ex)
            {
                helper.Rollback();
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion
    }
}

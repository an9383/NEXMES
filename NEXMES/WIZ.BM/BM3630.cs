#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : BM3630                                                                                                                                                                          
//   Form Name    : 자주 검사항목 품목별 스펙 관리 (DA)                                                                                                                                                                    
//   Name Space   : WIZ.BM                                                                                                                                                                        
//   Created Date : 2012-03-19 (2013-07-03 신규 재 개발)                                                                                                                                                                    
//   Made By      : WIZCORE                                                                                                                                               
//   Description  : 모든 검사항목의  품목별 스펙을 관리                                                                                                                                                                
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

    public partial class BM3630 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM3630()
        {
            InitializeComponent();
            // POP-UP 처리 필요 ( 조회창 : 품목, grid : 품목, 검사항목 : InspCode)
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });

            // grid pop-up 처리를 위한 정의
            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });    //품목
            gridManager.PopUpAdd("InspCode", "InspName", "TBM1500", new string[] { "InspCase", "InspType", "Y" }); //TBM1500 : 검사항목 

        }

        #endregion

        #region BM3630_Load
        private void BM3630_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);


            // InitColumnUltraGrid         84 79 86 74 100 88 93 168 100 107 80 120 80 80 120 80 80         

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장(사업장)", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);              // 공장                                              
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 177, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);               // 품목                                                
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", true, GridColDataType_emu.VarChar, 131, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);               // 품목명              
            _GridUtil.InitColumnUltraGrid(grid1, "InspCase", "검사구분", true, GridColDataType_emu.VarChar, 113, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);           // 검사구분                                             
            _GridUtil.InitColumnUltraGrid(grid1, "InspType", "검사대상", true, GridColDataType_emu.VarChar, 98, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);           // 검사유형     
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "검사항목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);           // 검사항목 
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "검사항목명", true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);         // 검사항목명              
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);          // 표시순서                                                
            _GridUtil.InitColumnUltraGrid(grid1, "SpecLSL", "하한치", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);              // 하한치                                                  
            _GridUtil.InitColumnUltraGrid(grid1, "SpecUSL", "상한치", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);              // 상한치                                                  
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);               // 단위               
            _GridUtil.InitColumnUltraGrid(grid1, "InspRequired", "검사필수여부", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);   // 검사필수여부                                            
            _GridUtil.InitColumnUltraGrid(grid1, "InspPeriod", "검사주기1", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);        // 검사주기(일/주/월)                                      
            _GridUtil.InitColumnUltraGrid(grid1, "InspCycle", "검사주기2", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);         // 검사주기(별)                                           
            _GridUtil.InitColumnUltraGrid(grid1, "InspMethod", "검사수집장비", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);     // 검사수집장비                                           
            _GridUtil.InitColumnUltraGrid(grid1, "InspCount", "검사횟수", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);          // 검사횟수                                             
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "검사정보구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);    // 검사정보구분(양호/불량 OK/NOK 확인 값입력 
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakerNM", "등록자명", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditorNM", "수정자명", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


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
            /* 콤보 처리 필요 ( 조회창 : PlantCode (공장), InspCase (검사구분)  InspType(검사대상) UseFlag(사용여부)
                               Grid : 조회창 & ,InspRequired (검사필수여부YesNo) ,InspPeriod (검사주기(일/주/월)) InspCycle(검사주기(별) ) InspMethod(검사수집장비)  
                               InspValType (검사정보구분(양호/불량 OK/NOK 확인 값입력)
            */
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장                                                                                                                              
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspCase", " MinorCode ='DA'");    //검사구분 자주검사)                                                                                                                                                                                 
            WIZ.Common.FillComboboxMaster(this.cboInspCase_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspCase", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspType");         //검사대상                                                                                                                                                                                  
            WIZ.Common.FillComboboxMaster(this.cboInspType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");            //사용여부                                                                                                                 
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("YesNo");        //검사필수여부YesNo 유형                                                                                                                                                                                  
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspRequired", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspPeriod");           //검사주기(일/주/월)                                                                                                                                                                                 
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspPeriod", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspCycle");            //검사주기(별)                                                                                                                                                                              
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspCycle", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspMethod");           //검사수집장비                                                                                                                                                                              
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspMethod", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspValType");           //검사정보구분                                                                                                                                                                              
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspValType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0130_CODE("Y");  //단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");



            #endregion

        }
        #endregion BM3630_Load

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
                string sItemCode = txtItemCode.Text.Trim();


                string sInspCase = DBHelper.nvlString(this.cboInspCase_H.Value);
                string sInspType = DBHelper.nvlString(this.cboInspType_H.Value);
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                base.DoInquire();



                grid1.DataSource = helper.FillTable("USP_BM3630_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspCase", sInspCase, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspType", sInspType, DbType.String, ParameterDirection.Input)
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

                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");        // 공장                                              
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ItemCode");         // 품목                                                
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ItemName");         // 품목명              
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspCase");         // 검사구분                                             
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspType");         // 검사유형     
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspCode");         // 검사항목 
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspName");         // 검사항목명              
                UltraGridUtil.ActivationAllowEdit(this.grid1, "DisplayNo");        // 표시순서                                                
                UltraGridUtil.ActivationAllowEdit(this.grid1, "SpecLSL");          // 하한치                                                  
                UltraGridUtil.ActivationAllowEdit(this.grid1, "SpecUSL");          // 상한치                                                  
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UnitCode");         // 단위               
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspRequired");     // 검사필수여부                                            
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspPeriod");       // 검사주기(일/주/월)                                      
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspCycle");        // 검사주기(별)                                           
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspMethod");       // 검사수집장비                                           
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspCount");        // 검사횟수                                 )             
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspValType");      // 검사정보구분(양호/불량 OK/NOK 확인 값입력             
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag");          // 사용여부

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
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)  // .GetChanges().Rows = 변경된 Rows 만 작업
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "공장(사업장) error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            //param = new System.Data.Common.DbParameter[5];
                            //param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input);         // 공장코드
                            //param[1] = helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input);           // 품목
                            //param[2] = helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input);           // 검사항목코드
                            //param[3] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[4] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_BM3630_D1N", CommandType.StoredProcedure, param);
                            //if (param[3].Value.ToString() == "E") throw new Exception(param[4].Value.ToString());

                            helper.ExecuteNoneQuery("USP_BM3630_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspCode", Convert.ToString(drRow["InspCode"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            //param = new System.Data.Common.DbParameter[16];
                            //param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input);         // 공장코드
                            //param[1] = helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input);           // 품목
                            //param[2] = helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input);           // 검사항목코드
                            //param[3] = helper.CreateParameter("DisplayNo", drRow["DisplayNo"].ToString(), DbType.String, ParameterDirection.Input);         // 표시순서
                            //param[4] = helper.CreateParameter("SpecLSL", drRow["SpecLSL"].ToString(), DbType.String, ParameterDirection.Input);             // 하한치
                            //param[5] = helper.CreateParameter("SpecUSL", drRow["SpecUSL"].ToString(), DbType.String, ParameterDirection.Input);             // 상한치
                            //param[6] = helper.CreateParameter("InspRequired", drRow["InspRequired"].ToString(), DbType.String, ParameterDirection.Input);   // 검사필수여부
                            //param[7] = helper.CreateParameter("InspPeriod", drRow["InspPeriod"].ToString(), DbType.String, ParameterDirection.Input);       // 검사주기(일/주/월)
                            //param[8] = helper.CreateParameter("InspCycle", drRow["InspCycle"].ToString(), DbType.String, ParameterDirection.Input);         // 검사주기(별)
                            //param[9] = helper.CreateParameter("InspMethod", drRow["InspMethod"].ToString(), DbType.String, ParameterDirection.Input);       // 검사수집장비
                            //param[10] = helper.CreateParameter("InspCount", drRow["InspCount"].ToString(), DbType.String, ParameterDirection.Input);        // 검사횟수
                            //param[11] = helper.CreateParameter("InspValType", drRow["InspValType"].ToString(), DbType.String, ParameterDirection.Input);    // 검사정보구분(양호/불량 OK/NOK 확인 값입력)

                            //param[12] = helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input);
                            //param[13] = helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input);

                            //param[14] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[15] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_BM3630_I1N", CommandType.StoredProcedure, param);

                            //if (param[14].Value.ToString() == "E") throw new Exception(param[15].Value.ToString());

                            helper.ExecuteNoneQuery("USP_BM3630_I1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspCode", Convert.ToString(drRow["InspCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DisplayNo", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("SpecLSL", Convert.ToString(drRow["SpecLSL"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("SpecUSL", Convert.ToString(drRow["SpecUSL"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspRequired", Convert.ToString(drRow["InspRequired"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspPeriod", Convert.ToString(drRow["InspPeriod"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspCycle", Convert.ToString(drRow["InspCycle"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspMethod", Convert.ToString(drRow["InspMethod"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspCount", Convert.ToString(drRow["InspCount"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspValType", Convert.ToString(drRow["InspValType"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            //param = new System.Data.Common.DbParameter[16];
                            //param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input);         // 공장코드
                            //param[1] = helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input);           // 품목
                            //param[2] = helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input);           // 검사항목코드
                            //param[3] = helper.CreateParameter("DisplayNo", drRow["DisplayNo"].ToString(), DbType.String, ParameterDirection.Input);         // 표시순서
                            //param[4] = helper.CreateParameter("SpecLSL", drRow["SpecLSL"].ToString(), DbType.String, ParameterDirection.Input);             // 하한치
                            //param[5] = helper.CreateParameter("SpecUSL", drRow["SpecUSL"].ToString(), DbType.String, ParameterDirection.Input);             // 상한치
                            //param[6] = helper.CreateParameter("InspRequired", drRow["InspRequired"].ToString(), DbType.String, ParameterDirection.Input);   // 검사필수여부
                            //param[7] = helper.CreateParameter("InspPeriod", drRow["InspPeriod"].ToString(), DbType.String, ParameterDirection.Input);       // 검사주기(일/주/월)
                            //param[8] = helper.CreateParameter("InspCycle", drRow["InspCycle"].ToString(), DbType.String, ParameterDirection.Input);         // 검사주기(별)
                            //param[9] = helper.CreateParameter("InspMethod", drRow["InspMethod"].ToString(), DbType.String, ParameterDirection.Input);       // 검사수집장비
                            //param[10] = helper.CreateParameter("InspCount", drRow["InspCount"].ToString(), DbType.String, ParameterDirection.Input);        // 검사횟수
                            //param[11] = helper.CreateParameter("InspValType", drRow["InspValType"].ToString(), DbType.String, ParameterDirection.Input);    // 검사정보구분(양호/불량 OK/NOK 확인 값입력)

                            //param[12] = helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input);
                            //param[13] = helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input);

                            //param[14] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[15] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_BM3630_U1N", CommandType.StoredProcedure, param);

                            //if (param[14].Value.ToString() == "E") throw new Exception(param[15].Value.ToString());

                            helper.ExecuteNoneQuery("USP_BM3630_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspCode", Convert.ToString(drRow["InspCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DisplayNo", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("SpecLSL", Convert.ToString(drRow["SpecLSL"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("SpecUSL", Convert.ToString(drRow["SpecUSL"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspRequired", Convert.ToString(drRow["InspRequired"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspPeriod", Convert.ToString(drRow["InspPeriod"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspCycle", Convert.ToString(drRow["InspCycle"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspMethod", Convert.ToString(drRow["InspMethod"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspCount", Convert.ToString(drRow["InspCount"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("InspValType", Convert.ToString(drRow["InspValType"]), DbType.String, ParameterDirection.Input)
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
                MessageBox.Show(ex.ToString());
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


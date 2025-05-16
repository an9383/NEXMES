#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : BM3500                                                                                                                                                                          
//   Form Name    : 설비 타입별 발생 고장 유형관리                                                                                                                                                                    
//   Name Space   : WIZ.BM                                                                                                                                                                        
//   Created Date : 2012-03-19 (2013-07-04 신규 재 개발)                                                                                                                                                                    
//   Made By      : WIZCORE                                                                                                                                                
//   Description  : 설비 타입별 발생 할 수 있는 고장 유형관리 한다                                                                                                                                                           
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

    public partial class BM3500 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM3500()
        {
            InitializeComponent();

            // grid pop-up 처리를 위한 정의
            //  TBM3400 : 고장 유형 정보
            //           - 1 : FaultCode, 2 : FaultName, param[0] : FaultType, param[1] : UseFlag
            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("FaultCode", "FaultName", "TBM3400", new string[] { "FaultType", "" });    //고장 유형 정보

        }

        #endregion

        #region BM3500_Load
        private void BM3500_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);


            // InitColumnUltraGrid             158 79 117 105 156 102 120 80 80 120 80 80   
            _GridUtil.InitColumnUltraGrid(grid1, "MachType", "설비유형", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);     // 설비유형
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);    // 표시순서
            _GridUtil.InitColumnUltraGrid(grid1, "FaultType", "고장유형", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);    // 고장유형
            _GridUtil.InitColumnUltraGrid(grid1, "FaultCode", "고장코드", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);    // 고장코드
            _GridUtil.InitColumnUltraGrid(grid1, "FaultName", "고장명", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);      // 고장명
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
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
            grid1.Columns["MachType"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["MachType"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["MachType"].MergedCellStyle = MergedCellStyle.Always;


            #endregion Grid MERGE

            #region 콤보박스
            /* 콤보 처리 필요 (MachType(설비유형), FaultType(고장유형), UseFlag(사용여부)
                                
                               
            */
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("MachType");  //설비유형                                                                                                                              
            WIZ.Common.FillComboboxMaster(this.cboMachType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MachType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("FaultType");         //고장유형                                                                                                                                                                                  
            WIZ.Common.FillComboboxMaster(this.cboFaultTypeCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FaultType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");            //사용여부                                                                                                                 
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");



            #endregion

        }
        #endregion BM3500_Load

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
                string sMachType = DBHelper.nvlString(this.cboMachType_H.Value);
                string sFaultType = DBHelper.nvlString(this.cboFaultTypeCode_H.Value);
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                base.DoInquire();

                grid1.DataSource = helper.FillTable("USP_BM3500_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("MachType", sMachType, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("FaultType", sFaultType, DbType.String, ParameterDirection.Input)
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
            try
            {
                base.DoNew();

                _GridUtil.AddRow(this.grid1);
                //this.grid1.SetDefaultValue("PlantCode", "SY");

                UltraGridUtil.ActivationAllowEdit(this.grid1, "MachType");     // 설비유형
                UltraGridUtil.ActivationAllowEdit(this.grid1, "DisplayNo");    // 표시순서
                UltraGridUtil.ActivationAllowEdit(this.grid1, "FaultType");    // 고장유형
                UltraGridUtil.ActivationAllowEdit(this.grid1, "FaultCode");    // 고장코드
                UltraGridUtil.ActivationAllowEdit(this.grid1, "FaultName");    // 고장명
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag");      // 사용여부                  

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
                    return;

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["MachType"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "설비유형 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM3500_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("MachType", drRow["MachType"].ToString(), DbType.String, ParameterDirection.Input)          // 설비타입코드
                                                                    , helper.CreateParameter("FaultCode", drRow["FaultCode"].ToString(), DbType.String, ParameterDirection.Input));           // 고장코드
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM3500_I1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("MachType", drRow["MachType"].ToString(), DbType.String, ParameterDirection.Input)        // 설비타입코드
                                                                    , helper.CreateParameter("FaultCode", drRow["FaultCode"].ToString(), DbType.String, ParameterDirection.Input)      // 고장코드
                                                                    , helper.CreateParameter("DisplayNo", drRow["DisplayNo"].ToString(), DbType.String, ParameterDirection.Input)      // 표시순서
                                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM3500_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("MachType", drRow["MachType"].ToString(), DbType.String, ParameterDirection.Input)         // 설비타입코드
                                                                    , helper.CreateParameter("FaultCode", drRow["FaultCode"].ToString(), DbType.String, ParameterDirection.Input)       // 고장코드
                                                                    , helper.CreateParameter("DisplayNo", drRow["DisplayNo"].ToString(), DbType.String, ParameterDirection.Input)       // 표시순서
                                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("MachType");
                helper.Commit();
            }
            catch (Exception ex)
            {
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

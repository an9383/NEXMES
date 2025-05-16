#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : BM3400                                                                                                                                                                          
//   Form Name    : 설비 고장항목 마스터                                                                                                                                                                  
//   Name Space   : WIZ.BM                                                                                                                                                                        
//   Created Date : 2012-03-19 (2013-07-05 신규 재 개발)                                                                                                                                                                    
//   Made By      : WIZCORE                                                                                                                                                
//   Description  : 설비 고장항목 마스터 정보를 관리 한다                                                                                                                                                           
// *---------------------------------------------------------------------------------------------*                                                                                                  
#endregion

#region <USING AREA>


using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.BM
{

    public partial class BM3400 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM3400()
        {
            InitializeComponent();
        }

        #endregion

        #region BM3400_Load
        private void BM3400_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);


            // InitColumnUltraGrid   150 80 121 250 80 120 80 120 80          

            _GridUtil.InitColumnUltraGrid(grid1, "FaultType", "고장유형", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);  // 고장유형
            _GridUtil.InitColumnUltraGrid(grid1, "FaultCode", "고장코드", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);  // 고장코드
            _GridUtil.InitColumnUltraGrid(grid1, "FaultName", "고장명", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);    // 고장명
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", true, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);      // 비고
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
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
            grid1.Columns["FaultType"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["FaultType"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["FaultType"].MergedCellStyle = MergedCellStyle.Always;


            #endregion Grid MERGE

            #region 콤보박스
            /* 콤보 처리 필요 (MachType(설비유형), FaultType(고장유형), UseFlag(사용여부)
                                
                               
            */
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("FaultType");         //고장유형                                                                                                                                                                                  
            WIZ.Common.FillComboboxMaster(this.cboFaultTypeCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FaultType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");            //사용여부                                                                                                                 
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");



            #endregion

        }
        #endregion BM3400_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {


                string sFaultType = DBHelper.nvlString(this.cboFaultTypeCode_H.Value);
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                base.DoInquire();
                grid1.DataSource = helper.FillTable("USP_BM3400_S1N", CommandType.StoredProcedure
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

                UltraGridUtil.ActivationAllowEdit(this.grid1, "FaultType");    // 고장유형
                UltraGridUtil.ActivationAllowEdit(this.grid1, "FaultCode");    // 고장코드
                UltraGridUtil.ActivationAllowEdit(this.grid1, "FaultName");    // 고장명
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Remark");       // 비고
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
                        if (drRow["FaultCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "고장코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM3400_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("FaultCode", drRow["FaultCode"].ToString(), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM3400_I1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("FaultCode", drRow["FaultCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("FaultType", drRow["FaultType"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("FaultName", drRow["FaultName"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM3400_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("FaultCode", drRow["FaultCode"].ToString(), DbType.String, ParameterDirection.Input)      // 고장코드
                                                                    , helper.CreateParameter("FaultType", drRow["FaultType"].ToString(), DbType.String, ParameterDirection.Input)       // 고장유형
                                                                    , helper.CreateParameter("FaultName", drRow["FaultName"].ToString(), DbType.String, ParameterDirection.Input)       // 고장명
                                                                    , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input)            // 비고
                                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("FaultCode");
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

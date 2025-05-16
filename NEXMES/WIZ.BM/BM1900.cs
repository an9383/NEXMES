
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM1900
//   Form Name    : 작업장 구성설비 관리
//   Name Space   : WIZ.BM.DLL
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*

using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;

namespace WIZ.BM
{
    public partial class BM1900 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region <CONSTRUCTOR>
        public BM1900()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager gridManager = new BizGridManager(grid1);

            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });
            gridManager.PopUpAdd("WorkCenterCode", "WorkCenterName", "TBM0600", new string[] { "PlantCode", "", "", "" });
            gridManager.PopUpAdd("OPCode", "OPname", "TBM0400", new string[] { "", "", "", "Y" });
            gridManager.PopUpAdd("MachCode", "Machname", "TBM0700", new string[] { "", "", "", "Y" });

        }

        private void BM1900_Load(object sender, EventArgs e)
        {
            #region 그리드
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachCode", "설비코드", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachName", "설비명", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", false, GridColDataType_emu.Integer, 70, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WCProdFlag", "실적수집여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 50;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;



            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  // 사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WCProdFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion
        }
        #endregion

        #region <TOOL BAR AREA>
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                base.DoInquire();
                string sWorkCenterCode = string.Empty;
                string sWorkCenterName = string.Empty;
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string sMachType = "";

                sWorkCenterCode = this.txtWorkCenterCode.Text.ToString();

                sWorkCenterName = this.txtWorkCenterName.Text.Trim();

                grid1.DataSource = helper.FillTable("USP_BM1900_S1"
                                             , CommandType.StoredProcedure
                                             , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MachType", sMachType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));



                grid1.DataBinds();

                //_Common.Grid_Column_Width(this.grid1); //grid 정리용
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

                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkCenterCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkCenterName");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MachCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Machname");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "DisplayNo");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WCProdFlag");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag");

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

                            helper.ExecuteNoneQuery("USP_BM1900_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)             // 공장코드
                                                    , helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input)   // 작업장
                                                    , helper.CreateParameter("MachCode", drRow["MachCode"].ToString(), DbType.String, ParameterDirection.Input));   // 설비

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM1900_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)          // 공장코드
                                                    , helper.CreateParameter("WorkcenterCode", drRow["WorkcenterCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MachCode", drRow["MachCode"].ToString(), DbType.String, ParameterDirection.Input)           // 설비코드
                                                    , helper.CreateParameter("DisplayNo", drRow["DisplayNo"].ToString(), DbType.String, ParameterDirection.Input)          // 표시순서
                                                    , helper.CreateParameter("WCProdFlag", drRow["WCProdFlag"].ToString(), DbType.String, ParameterDirection.Input)            // 사용유무
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)            // 사용유무
                                                    , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));              // 등록자

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM1900_U1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)         // 공장코드
                                                                   , helper.CreateParameter("WorkcenterCode", drRow["WorkcenterCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MachCode", drRow["MachCode"].ToString(), DbType.String, ParameterDirection.Input)          // 설비코드
                                                                   , helper.CreateParameter("DisplayNo", drRow["DisplayNo"].ToString(), DbType.String, ParameterDirection.Input)         // 표시순서
                                                                   , helper.CreateParameter("WCProdFlag", drRow["WCProdFlag"].ToString(), DbType.String, ParameterDirection.Input)           // 사용유무
                                                                   , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)           // 사용유무
                                                                   , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));              // 등록자

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

        #region <EVENT AREA>
        private void grid1_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            e.Row.Cells["UseFlag"].Value = "Y";
        }
        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의

        #endregion

    }
}

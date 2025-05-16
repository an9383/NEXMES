#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM3660
//   Form Name    : 일상점검항목 작업장별 스펙 관리
//   Name Space   : WIZ.BM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM3660 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >

        public BM3660()
        {
            InitializeComponent();
        }
        #endregion

        #region BM3660_Load
        private void BM3660_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            // InitColumnUltraGrid
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Plant", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장ⓟ", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명ⓟ", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목ⓟ", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명ⓟ", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "공정ⓟ", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "공정명ⓟ", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachCode", "설비코드ⓟ", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Machname", "설비명ⓟ", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OpSeq", "공정순서", false, GridColDataType_emu.VarChar, 94, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OpNo", "NO", false, GridColDataType_emu.VarChar, 94, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "점검항목ⓟ", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "점검항목명ⓟ", false, GridColDataType_emu.VarChar, 157, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCarType", "사양구분", false, GridColDataType_emu.VarChar, 157, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAManaSpec", "점검기준ⓟ", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAManaSpecNM", "점검기준명ⓟ", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAStandard", "등록형태ⓟ", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAStandardNM", "등록형태명ⓟ", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecLSL", "규격하한치", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecUSL", "규격상한치", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "점검방법", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspRequired", "검사필수여부", false, GridColDataType_emu.VarChar, 115, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspPeriod", "검사주기(일/주/월)", false, GridColDataType_emu.VarChar, 135, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCycle", "검사주기(별)", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspMethod", "검사수집장비", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCount", "검사횟수", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SampleCount", "입력샘플", false, GridColDataType_emu.Integer, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            ///////MERGE
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 50;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #region Grid MERGE
            //grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            //grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            //grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            //grid1.Columns["OPCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            //grid1.Columns["OPCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            //grid1.Columns["OPCode"].MergedCellStyle = MergedCellStyle.Always;

            //grid1.Columns["OPName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            //grid1.Columns["OPName"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            //grid1.Columns["OPName"].MergedCellStyle = MergedCellStyle.Always;

            //grid1.Columns["OpSeq"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            //grid1.Columns["OpSeq"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            //grid1.Columns["OpSeq"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion



            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspValType");  //점검방법
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspValType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO"); // 검사필수여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspRequired", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspPeriod");  //검사주기(일/주/월)
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspPeriod", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspMethod");  //수집방법
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspMethod", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0130_CODE("Y");  //단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region 팝업


            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("DAManaSpec", "DAManaSpecNM", "TBM0000", new string[] { "DAManaSpec" });
            gridManager.PopUpAdd("DAStandard", "DAStandardNM", "TBM0000", new string[] { "DAStandard" });
            gridManager.PopUpAdd("OPCode", "OPName", "TBM0000", new string[] { "LINECHKOP" });
            gridManager.PopUpAdd("WorkCenterCode", "WorkCenterName", "TBM0600", new string[] { "PlantCode", "", "", "" });
            gridManager.PopUpAdd("InspOpCode", "InspOpName", "TBM0000", new string[] { "LINECHKOP" });
            gridManager.PopUpAdd("InspCode", "InspName", "TBM1500", new string[] { "DA", "", "Y" }, new string[] { "UnitCode|UnitCode" }, new string[] { "Y" });
            gridManager.PopUpAdd("MachCode", "Machname", "TBM0700", new string[] { "", "", "", "Y" });
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0000", new string[] { "LINECHKOP" });
            btbManager.PopUpAdd(txtInspCode, txtInspCodeNM, "TBM1500", new object[] { "", "", "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, txtOPCode, "", "" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });

            #endregion
        }
        #endregion BM3660_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);                           // 공장코드 
                string sOPCode = txtOPCode.Text.Trim();                                                 // 작업장(공정)코드                                                          
                string sOPNAME = txtOPName.Text.Trim();                                                 // 작업장(공정)명                                                         
                string sWorkCenterCode = txtWorkCenterCode.Text.Trim();                                 // 작업장(공정)코드                                                          
                string sWorkCenterName = txtWorkCenterName.Text.Trim();
                string sInspCode = txtInspCode.Text.Trim();
                string sInspCodeNM = txtInspCodeNM.Text.Trim();
                string sUseFlag = DBHelper.nvlString(cboUseFlag_H.Value);
                string sItemCode = txtItemCode.Text.Trim();                      // 품목        
                base.DoInquire();

                grid1.DataSource = helper.FillTable("USP_BM3660_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("InspCode", sInspCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("InspCodeNM", sInspCodeNM, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("OPNAME", sOPNAME, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("WorkCenterName", sWorkCenterName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                ThrowError(ex);
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
                this.grid1.SetDefaultValue("PlantCode", WIZ.LoginInfo.PlantCode);

                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "OPCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "OPName");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkCenterCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkCenterName");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "OpSeq");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MachCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Machname");
                UltraGridUtil.ActivationAllowEdit(grid1, "ItemCode");
                UltraGridUtil.ActivationAllowEdit(grid1, "ItemName");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "OpNo");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspName");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "DAManaSpec");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "DAStandard");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "SpecLSL");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "SpecUSL");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspValType");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspRequired");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspPeriod");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspCycle");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspMethod");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspCount");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "DisplayNo");

            }
            catch (Exception ex)
            {
                ThrowError(ex);
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

                            helper.ExecuteNoneQuery("USP_BM3660_D1", CommandType.StoredProcedure
                                                   , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("OPCode", Convert.ToString(drRow["OPCode"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("InspCode", Convert.ToString(drRow["InspCode"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("WorkCenterCode", Convert.ToString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MachCode", Convert.ToString(drRow["MachCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM3660_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OPCode", Convert.ToString(drRow["OPCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MachCode", Convert.ToString(drRow["MachCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspCode", Convert.ToString(drRow["InspCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OpSeq", Convert.ToString(drRow["OpSeq"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OpNo", Convert.ToString(drRow["OpNo"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DAManaSpec", Convert.ToString(drRow["DAManaSpec"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DAStandard", Convert.ToString(drRow["DAStandard"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SpecLSL", Convert.ToString(drRow["SpecLSL"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SpecUSL", Convert.ToString(drRow["SpecUSL"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspRequired", Convert.ToString(drRow["InspRequired"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspPeriod", Convert.ToString(drRow["InspPeriod"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspCycle", Convert.ToString(drRow["InspCycle"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspMethod", Convert.ToString(drRow["InspMethod"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspCount", Convert.ToString(drRow["InspCount"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspValType", Convert.ToString(drRow["InspValType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DisplayNo", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"], DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UnitCode", Convert.ToString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkcenterCode", Convert.ToString(drRow["WorkcenterCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCarType", Convert.ToString(drRow["ItemCarType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Param1", DBNull.Value, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Param2", DBNull.Value, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Param3", DBNull.Value, DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM3660_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OPCode", Convert.ToString(drRow["OPCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MachCode", Convert.ToString(drRow["MachCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspCode", Convert.ToString(drRow["InspCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OpSeq", Convert.ToString(drRow["OpSeq"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OpNo", Convert.ToString(drRow["OpNo"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DAManaSpec", Convert.ToString(drRow["DAManaSpec"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DAStandard", Convert.ToString(drRow["DAStandard"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SpecLSL", Convert.ToString(drRow["SpecLSL"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SpecUSL", Convert.ToString(drRow["SpecUSL"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspRequired", Convert.ToString(drRow["InspRequired"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspPeriod", Convert.ToString(drRow["InspPeriod"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspCycle", Convert.ToString(drRow["InspCycle"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspMethod", Convert.ToString(drRow["InspMethod"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspCount", Convert.ToString(drRow["InspCount"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspValType", Convert.ToString(drRow["InspValType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DisplayNo", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"], DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UnitCode", Convert.ToString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkcenterCode", Convert.ToString(drRow["WorkcenterCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCarType", Convert.ToString(drRow["ItemCarType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Param1", DBNull.Value, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Param2", DBNull.Value, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Param3", DBNull.Value, DbType.String, ParameterDirection.Input));
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
                ThrowError(ex);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
        /// <summary>
        /// Form이 Close 되기전에 발생
        /// e.Cancel을 true로 설정 하면, Form이 close되지 않음
        /// 수정 내역이 있는지를 확인 후 저장여부를 물어보고 저장, 저장하지 않기, 또는 화면 닫기를 Cancel 함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

        }
        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Modified)
            {
                e.Command.Parameters["@Editor"].Value = this.WorkerID;
                return;
            }

            if (e.Row.RowState == DataRowState.Added)
            {
                //e.Command.Parameters["@Editor"].Value = this.WorkerID;
                e.Command.Parameters["@Maker"].Value = this.WorkerID;
                return;
            }
        }

        /// <summary>
        /// 저장처리시 오류가 발생한 경우 오류 메세지에 대한 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Errors == null) return;

            switch (((SqlException)e.Errors).Number)
            {
                // 중복
                case 2627:
                    e.Row.RowError = "데이터가 중복입니다.";
                    throw (new SException("S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion

        #region<btn3661_Click>
        private void btn3661_Click(object sender, EventArgs e)
        {
            string[] para = new string[7];

            int idx = this.grid1.ActiveRow == null ? 0 : this.grid1.ActiveRow.Index;

            // 행이 없을 경우 SKIP
            if (this.grid1.Rows.Count == 0)
            {
                this.IsShowDialog = false;
                this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                return;
            }



            // 정보 넘김(사업장, 공정, 명, 설비, 명)
            string sPlantCode = this.grid1.ActiveRow.Cells["PlantCode"].Value.ToString();
            string sOPCode = this.grid1.ActiveRow.Cells["OPCode"].Value.ToString();
            string sOPName = this.grid1.ActiveRow.Cells["OPName"].Value.ToString();
            string sMachCode = this.grid1.ActiveRow.Cells["MachCode"].Value.ToString();
            string sMachName = this.grid1.ActiveRow.Cells["MachName"].Value.ToString();
            string sWorkcentercode = this.grid1.ActiveRow.Cells["Workcentercode"].Value.ToString();
            string sWorkCenterName = this.grid1.ActiveRow.Cells["WorkCenterName"].Value.ToString();
            if (sPlantCode != "" && sOPCode != "" && sMachCode != "" && sWorkcentercode != "")
            {
                para[0] = sPlantCode;
                para[1] = sOPCode;
                para[2] = sOPName;
                para[3] = sMachCode;
                para[4] = sMachName;
                para[5] = sWorkcentercode;
                para[6] = sWorkCenterName;

                BM3661 Form = new BM3661(para);
                Form.ShowDialog();
            }
            else
            {
                this.ShowDialog(Common.getLangText("정보가 선택되지 않았습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion
    }
}


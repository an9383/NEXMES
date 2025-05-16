#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM3650
//   Form Name    : 공정검사 품목별 스펙괸리
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
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM3650 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >

        public BM3650()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { "", "" });
            btbManager.PopUpAdd(txtInspCode, txtInspCodeNM, "TBM1500", new object[] { "", "", "" });

            BizGridManager BIZPOP = new BizGridManager(grid1);

            BIZPOP.PopUpAdd("InspCode", "InspName", "TBM1500", new string[] { "QC", "", "Y" }, new string[] { "UnitCode|UnitCode" }, new string[] { "Y" });
            BIZPOP.PopUpAdd("ItemCode", "Itemname", "TBM0100", new string[] { "PlantCode", "" });
            BIZPOP.PopUpAdd("WorkCenterCode", "WorkCenterName", "TBM0600", new string[] { "PlantCode", "", "", "" });

            BIZPOP.PopUpAdd("QCStandard", "QCStandardNM", "TBM0000", new string[] { "QCStandard" });
            BIZPOP.PopUpAdd("QCSpQuality", "QCSpQualityNM", "TBM0000", new string[] { "QCSpQuality" });
            BIZPOP.PopUpAdd("QCManaSpec", "QCManaSpecNM", "TBM0000", new string[] { "QCManaSpec" });
        }
        #endregion

        #region BM3650_Load
        private void BM3650_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Plant", "공장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장ⓟ", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명ⓟ", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목ⓟ", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명ⓟ", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OpSeq", "NO", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "검사항목ⓟ", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "검사항목명ⓟ", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCManaSpec", "관리규격ⓟ", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCManaSpecNM", "관리규격명ⓟ", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCSpQuality", "특별특성ⓟ", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCSpQualityNM", "특별특성명ⓟ", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "등록형태", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecLSL", "규격하한치", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecUSL", "규격상한치", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCStandard", "측정구ⓟ", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCStandardNM", "측정구명ⓟ", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ManaLSL", "관리하한치", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ManaUSL", "관리상한치", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspRequired", "검사필수여부", false, GridColDataType_emu.VarChar, 115, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspPeriod", "검사주기(일/주/월)", false, GridColDataType_emu.VarChar, 135, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCycle", "검사주기(별)", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspMethod", "검사수집장비", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCount", "검사횟수", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SampleCount", "입력샘플", false, GridColDataType_emu.Integer, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Spcflag", "SPC여부", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;



            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0130_CODE("Y");  //단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO"); // 검사필수여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspRequired", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspValType"); // 수집형태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspValType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspPeriod");  //검사주기(일/주/월)
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspPeriod", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspMethod");  //수집방법
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspMethod", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "Spcflag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion

        }
        #endregion BM3650_Load

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

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);    // 공장코드 
                string sItemCode = txtItemCode.Text.Trim();                      // 품목                                                          
                string sInspCode = txtInspCode.Text.Trim();                      // 검사항목                                                          
                string sInspCodeNM = txtInspCodeNM.Text.Trim();                  // 검사항목 
                string sUseFlag = DBHelper.nvlString(cboUseFlag_H.Value);        // 사용여부     

                grid1.DataSource = helper.FillTable("USP_BM3650_S1"
                                           , CommandType.StoredProcedure
                                           , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("InspCode", sInspCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("InspCodeNM", sInspCodeNM, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));



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

                UltraGridUtil.ActivationAllowEdit(grid1, "PlantCode");
                UltraGridUtil.ActivationAllowEdit(grid1, "WorkCenterCode");
                UltraGridUtil.ActivationAllowEdit(grid1, "WorkCenterName");
                UltraGridUtil.ActivationAllowEdit(grid1, "ItemCode");
                UltraGridUtil.ActivationAllowEdit(grid1, "ItemName");
                UltraGridUtil.ActivationAllowEdit(grid1, "InspCode");
                UltraGridUtil.ActivationAllowEdit(grid1, "InspName");
                UltraGridUtil.ActivationAllowEdit(grid1, "OpSeq");         // NO
                UltraGridUtil.ActivationAllowEdit(grid1, "QCSpQuality");   // 특별특성
                UltraGridUtil.ActivationAllowEdit(grid1, "QCSpQualityNM");   // 특별특성
                UltraGridUtil.ActivationAllowEdit(grid1, "QCManaSpec");    // 관리규격
                UltraGridUtil.ActivationAllowEdit(grid1, "QCManaSpecNM");    // 관리규격
                UltraGridUtil.ActivationAllowEdit(grid1, "QCStandard");    // 측정구
                UltraGridUtil.ActivationAllowEdit(grid1, "QCStandardNM");    // 측정구
                UltraGridUtil.ActivationAllowEdit(grid1, "ManaLSL");       // 관리하한치
                UltraGridUtil.ActivationAllowEdit(grid1, "ManaUSL");       // 관리상한치
                UltraGridUtil.ActivationAllowEdit(grid1, "SpecLSL");       // 규격하한치 
                UltraGridUtil.ActivationAllowEdit(grid1, "SpecUSL");       // 규격상한치
                UltraGridUtil.ActivationAllowEdit(grid1, "UnitCode");       // 단위
                UltraGridUtil.ActivationAllowEdit(grid1, "InspRequired");  // 검사필수여부
                UltraGridUtil.ActivationAllowEdit(grid1, "InspPeriod");    // 검사주기(일/주/월)
                UltraGridUtil.ActivationAllowEdit(grid1, "InspCycle");     // 검사주기(별)
                UltraGridUtil.ActivationAllowEdit(grid1, "InspMethod");    // 검사수집장비  
                UltraGridUtil.ActivationAllowEdit(grid1, "InspCount");     // 검사횟수
                UltraGridUtil.ActivationAllowEdit(grid1, "InspValType");   // 검사정보구분(양호/불량 OK/NOK 확인 값입력)
                UltraGridUtil.ActivationAllowEdit(grid1, "DisplayNo");      // 표시순서
                UltraGridUtil.ActivationAllowEdit(grid1, "UseFlag");       // 사용유무   
                UltraGridUtil.ActivationAllowEdit(grid1, "Spcflag");       // 사용유무  

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

                            helper.ExecuteNoneQuery("USP_BM3650_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)         // 공장코드
                                                    , helper.CreateParameter("WorkCenterCode", DBHelper.nvlString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)           // 작업장코드
                                                    , helper.CreateParameter("ItemCode", DBHelper.nvlString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)           // 품목
                                                    , helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input));           // 관리항목

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM3650_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkCenterCode", DBHelper.nvlString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)           // 작업장코드
                                                    , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OpSeq", drRow["OpSeq"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("QCSpQuality", drRow["QCSpQuality"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("QCManaSpec", drRow["QCManaSpec"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("QCStandard", drRow["QCStandard"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ManaLSL", drRow["ManaLSL"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ManaUSL", drRow["ManaUSL"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SpecLSL", drRow["SpecLSL"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SpecUSL", drRow["SpecUSL"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspRequired", drRow["InspRequired"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspPeriod", drRow["InspPeriod"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspCycle", drRow["InspCycle"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspMethod", drRow["InspMethod"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspCount", drRow["InspCount"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspValType", drRow["InspValType"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DisplayNo", drRow["DisplayNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Spcflag", drRow["Spcflag"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("etc1", "1", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("etc2", "2", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("etc3", "3", DbType.String, ParameterDirection.Input)

                                                    // unitcode 관리 항목 추가(프로시져 변경 I1 -> I2)
                                                    , helper.CreateParameter("UnitCode", drRow["UnitCode"].ToString(), DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM3650_U1"
                                                         , CommandType.StoredProcedure
                                                         , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)        // 공장코드
                                                         , helper.CreateParameter("WorkCenterCode", DBHelper.nvlString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)           // 작업장코드
                                                         , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)          // 품목
                                                         , helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input)          // 관리항목
                                                         , helper.CreateParameter("OpSeq", drRow["OpSeq"].ToString(), DbType.String, ParameterDirection.Input)                // NO
                                                         , helper.CreateParameter("QCSpQuality", drRow["QCSpQuality"].ToString(), DbType.String, ParameterDirection.Input)    // 특별특성
                                                         , helper.CreateParameter("QCManaSpec", drRow["QCManaSpec"].ToString(), DbType.String, ParameterDirection.Input)      // 관리규격
                                                         , helper.CreateParameter("QCStandard", drRow["QCStandard"].ToString(), DbType.String, ParameterDirection.Input)      // 측정구
                                                         , helper.CreateParameter("ManaLSL", drRow["ManaLSL"].ToString(), DbType.String, ParameterDirection.Input)            // 관리하한치
                                                         , helper.CreateParameter("ManaUSL", drRow["ManaUSL"].ToString(), DbType.String, ParameterDirection.Input)            // 관리상한치
                                                         , helper.CreateParameter("SpecLSL", drRow["SpecLSL"].ToString(), DbType.String, ParameterDirection.Input)            // 규격하한치 
                                                         , helper.CreateParameter("SpecUSL", drRow["SpecUSL"].ToString(), DbType.String, ParameterDirection.Input)            // 규격상한치
                                                         , helper.CreateParameter("InspRequired", drRow["InspRequired"].ToString(), DbType.String, ParameterDirection.Input)  // 검사필수여부
                                                         , helper.CreateParameter("InspPeriod", drRow["InspPeriod"].ToString(), DbType.String, ParameterDirection.Input)      // 검사주기(일/주/월)
                                                         , helper.CreateParameter("InspCycle", drRow["InspCycle"].ToString(), DbType.String, ParameterDirection.Input)        // 검사주기(별)
                                                         , helper.CreateParameter("InspMethod", drRow["InspMethod"].ToString(), DbType.String, ParameterDirection.Input)      // 검사수집장비  
                                                         , helper.CreateParameter("InspCount", drRow["InspCount"].ToString(), DbType.String, ParameterDirection.Input)        // 검사횟수
                                                         , helper.CreateParameter("InspValType", drRow["InspValType"].ToString(), DbType.String, ParameterDirection.Input)    // 검사정보구분(양호/불량, OK/NOK, 확인, 값입력)
                                                         , helper.CreateParameter("DisplayNo", drRow["DisplayNo"].ToString(), DbType.String, ParameterDirection.Input)        // 표시순서
                                                         , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)            // 사용유무
                                                         , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)              // 수정자
                                                         , helper.CreateParameter("Spcflag", drRow["Spcflag"].ToString(), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("etc1", "1", DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("etc2", "2", DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("etc3", "3", DbType.String, ParameterDirection.Input)

                                                         // unitcode 관리 항목 추가(프로시져 변경 I1 -> I2)
                                                         , helper.CreateParameter("UnitCode", drRow["UnitCode"].ToString(), DbType.String, ParameterDirection.Input));               // 단위


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
        private void btn3650_Click(object sender, EventArgs e)
        {
            int idx = this.grid1.ActiveRow == null ? 0 : this.grid1.ActiveRow.Index;

            // 행이 없을 경우 SKIP
            if (this.grid1.Rows.Count == 0)
            {
                this.IsShowDialog = false;
                this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                return;
            }

            // 정보 넘김
            string sPlantCode = this.grid1.ActiveRow.Cells["PlantCode"].Value.ToString();
            string sWorkCenterCode = this.grid1.ActiveRow.Cells["WorkCenterCode"].Value.ToString();
            string sWorkCenterName = this.grid1.ActiveRow.Cells["WorkCenterName"].Value.ToString();
            string sItemCode = this.grid1.ActiveRow.Cells["ItemCode"].Value.ToString();
            string sItemName = this.grid1.ActiveRow.Cells["ItemName"].Value.ToString();
            if (sPlantCode != "" && sItemCode != "")
            {
                BM3651 Form = new BM3651(sPlantCode, sWorkCenterCode, sWorkCenterName, sItemCode, sItemName);
                Form.ShowDialog();
            }
            else
            {
                this.ShowDialog(Common.getLangText("정보가 선택되지 않았습니다.", "MSG"));
            }
        }
        #endregion

    }
}

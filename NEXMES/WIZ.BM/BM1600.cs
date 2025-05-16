#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM1600
//   Form Name    : 품목별 사용금형관리
//   Name Space   : WIZ.BM
//   Created Date : 2012-02-21
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.BM
{
    public partial class BM1600 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >
        public BM1600()
        {
            InitializeComponent();

            //팝업 관리

            //   - 1 : MachCode, 2 : MachName, param[0] : MachType, param[1] : MachType1
            //btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, txtOPCode, "", "" }); //라인 팝업
            //gridManager.PopUpAdd("ToolCode2", "ToolName2", "TTO0100_GetData", new string[] { "PlantCode", "", "", "", "N" }, new string[] { "ToolSeq2|Seq" });
        }
        #endregion

        #region 폼 초기화

        private void BM1600_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern            

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장(사업장)", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Moldname", "금형명", false, GridColDataType_emu.VarChar, 150, 500, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PartNo", "P/NO", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldType", "금형타입", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldType1", "금형종류(코드)", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldType2", "금형재질", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldLoc", "저장위치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "저장업체", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "업체명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeCompany", "제조사", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ModelName", "모델명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SerialNo", "자산번호(시리얼NO)", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LifeTime", "수명(년)", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Contact", "연락처", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWorker1", "작업담당자1", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWorkerNM1", "담당자1명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWorker2", "작업담당자2", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWorkerNM2", "담당자2명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TechWorker", "기술담당자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TechWorkerNM", "담당자명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BuyDate", "도입일자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BuyCost", "도입금액", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Status", "상태", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldStatus", "금형상태", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspLastDate", "최종검사일", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LimitDate", "유효일수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Cavity", "Cavity", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Designshot", "설계사용수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Workshot", "작업사용수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Totshot", "전체사용수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldUseCnt", "금형사용횟수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LastUseDate", "최근사용일", false, GridColDataType_emu.DateTime, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldAssType", "자산구분", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CarType", "차종 코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDPNO", "고객생산품목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDPNAME", "고객생산품목명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldWgt", "금형중량(kg)", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldSizeL", "SIZE(mm)가로", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldSizeW", "SIZE(mm)세로", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldSizeH", "SIZE(mm)높이", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PriceUint", "화폐단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "HKMCAssNo", "HKMC자산번호", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldManagerID", "협력사 관리자성명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldManagerTel", "협력사 관리자전화번호", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldStockerID", "보관처 관리자성명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldStockerTel", "보관처 관리자전화번호", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager gridManager = new BizGridManager(grid1);
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            gridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });     //  품목POP_UP grid
            gridManager.PopUpAdd("CustCode", "CustName", "TBM0300", new string[] { "PlantCode", "" });     //  저장업체
            gridManager.PopUpAdd("MAWorker1", "MAWorker1NM", "TBM0200", new string[] { "PlantCode", "", "", "", "" });
            gridManager.PopUpAdd("MAWorker2", "MAWorker2NM", "TBM0200", new string[] { "PlantCode", "", "", "", "" });
            gridManager.PopUpAdd("TechWorker", "TechWorkerNM", "TBM0200", new string[] { "PlantCode", "", "", "", "" });

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  // 사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTYPE");     // 금형타입 
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldType", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTYPE1");     // 분류1
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldType1", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTYPE2");     // 분류2
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldType2", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDLOC");       // 설치장소
            WIZ.Common.FillComboboxMaster(this.cboMoldLoc_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("MACHSTATUS");    // 상태  
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "Status", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDSTATUS");    // 금형상태  
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldStatus", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDASSTYPE");   // 자산구분 (HMC/KNC/협력사(자사))  
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldAssType", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("CARTYPE");       // 차종 코드(3) : HM/BH/UN/AUT/PC 등등
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CarType", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #endregion
        }
        #endregion

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
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                string sMoldLoc = DBHelper.nvlString(this.cboMoldLoc_H.Value);
                string sItemCode = txtItemCode.Text.Trim();
                string sMolodCode = txtMolode.Text.Trim();
                grid1.DataSource = helper.FillTable("USP_BM1600_S3", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MoldCode", sMolodCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)
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
                if (grid1.IsActivate)
                {
                    int iRow = _GridUtil.AddRow(this.grid1);
                    this.grid1.SetDefaultValue("PlantCode", "820");

                    UltraGridUtil.ActivationAllowEdit(grid1, "PlantCode");
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldCode");            // 금형코드 
                    UltraGridUtil.ActivationAllowEdit(grid1, "Moldname");            // 금형명 
                    UltraGridUtil.ActivationAllowEdit(grid1, "ItemCode");            // 품목코드
                    UltraGridUtil.ActivationAllowEdit(grid1, "PartNo");              // P/NO (협력사 P/NO(21) : 협력사  자체 P/NO 관리시 등록 (필수 아님) 
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldType");            // 금형타입 
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldType1");           // 분류1
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldType2");           // 분류2
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldLoc");             // 설치장소
                    UltraGridUtil.ActivationAllowEdit(grid1, "MakeCompany");         // 제조사
                    UltraGridUtil.ActivationAllowEdit(grid1, "ModelName");           // 모델명
                    UltraGridUtil.ActivationAllowEdit(grid1, "SerialNo");            // 시리얼번호
                    UltraGridUtil.ActivationAllowEdit(grid1, "LifeTime");            // 수명(단위=년)    
                    UltraGridUtil.ActivationAllowEdit(grid1, "Contact");             // 연락처
                    UltraGridUtil.ActivationAllowEdit(grid1, "MAWorker1");           // 작업담당자1 
                    UltraGridUtil.ActivationAllowEdit(grid1, "MAWorker2");           // 작업담당자2
                    UltraGridUtil.ActivationAllowEdit(grid1, "TechWorker");          // 장비기술담당자   
                    UltraGridUtil.ActivationAllowEdit(grid1, "BuyDate");             // 도입일자 
                    UltraGridUtil.ActivationAllowEdit(grid1, "BuyCost");             // 도입가격
                    UltraGridUtil.ActivationAllowEdit(grid1, "Status");              // 상태  
                    UltraGridUtil.ActivationAllowEdit(grid1, "InspLastDate");        // 최종검사일자
                    UltraGridUtil.ActivationAllowEdit(grid1, "LimitDate");           // 유효일수
                    UltraGridUtil.ActivationAllowEdit(grid1, "Cavity");              // Cavity 
                    UltraGridUtil.ActivationAllowEdit(grid1, "Designshot");          // 디자인쇼트(설계사용수)
                    UltraGridUtil.ActivationAllowEdit(grid1, "Workshot");            // 작업쇼트(작업사용수) 
                    UltraGridUtil.ActivationAllowEdit(grid1, "Totshot");             // 전체쇼트(합계사용수)
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldUseCnt");          // 금형사용횟수
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldAssType");         // 자산구분 (HMC/KNC/협력사(자사))  
                    UltraGridUtil.ActivationAllowEdit(grid1, "CarType");             // 차종 코드(3) : HM/BH/UN/AUT/PC 등등
                    UltraGridUtil.ActivationAllowEdit(grid1, "ENDPNO");              // 생산품목(자동차 ASS'y ERP 자재 마스터에 등록된 Part No )    
                    UltraGridUtil.ActivationAllowEdit(grid1, "ENDPNAME");            // 생산품목(자동차 ASS'y ERP 자재 마스터에 등록된 Part No )
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldWgt");             // 금형중량(kg)
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldSizeL");           // SIZE(mm)가로
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldSizeW");           // SIZE(mm)세로
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldSizeH");           // SIZE(mm)높이
                    UltraGridUtil.ActivationAllowEdit(grid1, "PriceUint");           // 화폐(3) : ￦$€￥  
                    UltraGridUtil.ActivationAllowEdit(grid1, "HKMCAssNo");           // 자산번호HKMC
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldManagerID");       // 1차 협력사 관리자성명
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldManagerTel");      // 1차 협력사  관리자전화번호
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldStockerID");       // 보관처 관리자성명
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldStockerTel");      // 보관처 관리자전화번호
                    UltraGridUtil.ActivationAllowEdit(grid1, "MoldStatus");          // 금형상태(추)
                    UltraGridUtil.ActivationAllowEdit(grid1, "CustCode");            // 업체코드(추)
                    UltraGridUtil.ActivationAllowEdit(grid1, "Remark");              // 비고
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            if (grid1.IsActivate) this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            if (grid1.IsActivate) Grid1ToolAct();
        }
        #endregion

        #region<Grid1ToolAct>
        private void Grid1ToolAct()
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

                DateTime LastUseDate = new DateTime();

                foreach (DataRow drRow in dt.Rows)
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
                            helper.ExecuteNoneQuery("USP_BM1600_D1N", CommandType.StoredProcedure
                            , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("MoldCode", Convert.ToString(drRow["MoldCode"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            if (drRow["LastUseDate"].ToString() == "") LastUseDate = DateTime.Now;
                            else LastUseDate = Convert.ToDateTime(drRow["LastUseDate"]);

                            helper.ExecuteNoneQuery("USP_BM1600_I3", CommandType.StoredProcedure
                            , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)     //공장(사업부)                                                    
                            , helper.CreateParameter("MoldCode", Convert.ToString(drRow["MoldCode"]), DbType.String, ParameterDirection.Input)     //금형코드
                            , helper.CreateParameter("Moldname", Convert.ToString(drRow["Moldname"]), DbType.String, ParameterDirection.Input)     //금형명
                            , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)     //품목코드
                            , helper.CreateParameter("PartNo", Convert.ToString(drRow["PartNo"]), DbType.String, ParameterDirection.Input)     //P/NO(협력사P/NO(21):협력사자체P/NO관리시등록(필수아님) 
                            , helper.CreateParameter("MoldType", Convert.ToString(drRow["MoldType"]), DbType.String, ParameterDirection.Input)     //금형타입
                            , helper.CreateParameter("MoldType1", Convert.ToString(drRow["MoldType1"]), DbType.String, ParameterDirection.Input)     //분류1
                            , helper.CreateParameter("MoldType2", Convert.ToString(drRow["MoldType2"]), DbType.String, ParameterDirection.Input)     //분류2
                            , helper.CreateParameter("MoldLoc", Convert.ToString(drRow["MoldLoc"]), DbType.String, ParameterDirection.Input)     //설치장소
                            , helper.CreateParameter("MakeCompany", Convert.ToString(drRow["MakeCompany"]), DbType.String, ParameterDirection.Input)     //제조사
                            , helper.CreateParameter("ModelName", Convert.ToString(drRow["ModelName"]), DbType.String, ParameterDirection.Input)     //모델명
                            , helper.CreateParameter("SerialNo", Convert.ToString(drRow["SerialNo"]), DbType.String, ParameterDirection.Input)     //시리얼번호
                            , helper.CreateParameter("LifeTime", Convert.ToString(drRow["LifeTime"]), DbType.String, ParameterDirection.Input)     //수명(단위=년)
                            , helper.CreateParameter("Contact", Convert.ToString(drRow["Contact"]), DbType.String, ParameterDirection.Input)     //연락처
                            , helper.CreateParameter("MAWorker1", Convert.ToString(drRow["MAWorker1"]), DbType.String, ParameterDirection.Input)     //작업담당자1
                            , helper.CreateParameter("MAWorker2", Convert.ToString(drRow["MAWorker2"]), DbType.String, ParameterDirection.Input)     //작업담당자2
                            , helper.CreateParameter("TechWorker", Convert.ToString(drRow["TechWorker"]), DbType.String, ParameterDirection.Input)     //장비기술담당자
                            , helper.CreateParameter("BuyDate", Convert.ToString(drRow["BuyDate"]), DbType.String, ParameterDirection.Input)     //도입일자
                            , helper.CreateParameter("BuyCost", Convert.ToString(drRow["BuyCost"]), DbType.String, ParameterDirection.Input)     //도입가격
                            , helper.CreateParameter("Status", Convert.ToString(drRow["Status"]), DbType.String, ParameterDirection.Input)     //상태
                            , helper.CreateParameter("InspLastDate", Convert.ToString(drRow["InspLastDate"]), DbType.String, ParameterDirection.Input)     //최종검사일자
                            , helper.CreateParameter("LimitDate", Convert.ToString(drRow["LimitDate"]), DbType.String, ParameterDirection.Input)     //유효일수
                            , helper.CreateParameter("Cavity", Convert.ToString(drRow["Cavity"]), DbType.String, ParameterDirection.Input)     //Cavity
                            , helper.CreateParameter("Designshot", Convert.ToString(drRow["Designshot"]), DbType.String, ParameterDirection.Input)     //디자인쇼트(설계사용수)
                            , helper.CreateParameter("Workshot", Convert.ToString(drRow["Workshot"]), DbType.String, ParameterDirection.Input)     //작업쇼트(작업사용수)
                            , helper.CreateParameter("Totshot", Convert.ToString(drRow["Totshot"]), DbType.String, ParameterDirection.Input)     //전체쇼트(합계사용수)
                            , helper.CreateParameter("MoldUseCnt", Convert.ToString(drRow["MoldUseCnt"]), DbType.String, ParameterDirection.Input)     //금형사용횟수
                            , helper.CreateParameter("MoldAssType", Convert.ToString(drRow["MoldAssType"]), DbType.String, ParameterDirection.Input)     //자산구분(HMC/KNC/협력사(자사))
                            , helper.CreateParameter("CarType", Convert.ToString(drRow["CarType"]), DbType.String, ParameterDirection.Input)     //차종코드(3):HM/BH/UN/AUT/PC등등
                            , helper.CreateParameter("ENDPNO", Convert.ToString(drRow["ENDPNO"]), DbType.String, ParameterDirection.Input)     //생산품목(자동차ASS'yERP자재마스터에등록된PartNo)
                            , helper.CreateParameter("ENDPNAME", Convert.ToString(drRow["ENDPNAME"]), DbType.String, ParameterDirection.Input)     //생산품목(자동차ASS'yERP자재마스터에등록된PartNo)
                            , helper.CreateParameter("MoldWgt", Convert.ToString(drRow["MoldWgt"]), DbType.String, ParameterDirection.Input)     //금형중량(kg)
                            , helper.CreateParameter("MoldSizeL", Convert.ToString(drRow["MoldSizeL"]), DbType.String, ParameterDirection.Input)     //SIZE(mm)가로
                            , helper.CreateParameter("MoldSizeW", Convert.ToString(drRow["MoldSizeW"]), DbType.String, ParameterDirection.Input)     //SIZE(mm)세로
                            , helper.CreateParameter("MoldSizeH", Convert.ToString(drRow["MoldSizeH"]), DbType.String, ParameterDirection.Input)     //SIZE(mm)높이
                            , helper.CreateParameter("PriceUint", Convert.ToString(drRow["PriceUint"]), DbType.String, ParameterDirection.Input)     //화폐(3):￦,$,€,￥
                            , helper.CreateParameter("HKMCAssNo", Convert.ToString(drRow["HKMCAssNo"]), DbType.String, ParameterDirection.Input)     //자산번호HKMC
                            , helper.CreateParameter("MoldManagerID", Convert.ToString(drRow["MoldManagerID"]), DbType.String, ParameterDirection.Input)     //1차협력사관리자성명
                            , helper.CreateParameter("MoldManagerTel", Convert.ToString(drRow["MoldManagerTel"]), DbType.String, ParameterDirection.Input)  //1차협력사관리자전화번호
                            , helper.CreateParameter("MoldStockerID", Convert.ToString(drRow["MoldStockerID"]), DbType.String, ParameterDirection.Input)  //보관처관리자성명
                            , helper.CreateParameter("MoldStockerTel", Convert.ToString(drRow["MoldStockerTel"]), DbType.String, ParameterDirection.Input)  //보관처관리자전화번호
                            , helper.CreateParameter("Remark", Convert.ToString(drRow["Remark"]), DbType.String, ParameterDirection.Input)         //비고
                            , helper.CreateParameter("MoldStatus", Convert.ToString(drRow["MoldStatus"]), DbType.String, ParameterDirection.Input)         //금형상태
                            , helper.CreateParameter("CustCode", Convert.ToString(drRow["CustCode"]), DbType.String, ParameterDirection.Input)         //저장업체
                            , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)         //사용유무                                                  
                            , helper.CreateParameter("Maker", Convert.ToString(drRow["Maker"]), DbType.String, ParameterDirection.Input));       //등록자


                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            if (drRow["LastUseDate"].ToString() == "") LastUseDate = DateTime.Now;
                            else LastUseDate = Convert.ToDateTime(drRow["LastUseDate"]);

                            helper.ExecuteNoneQuery("USP_BM1600_U3", CommandType.StoredProcedure
                             , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)     //공장(사업부)                                                    
                             , helper.CreateParameter("MoldCode", Convert.ToString(drRow["MoldCode"]), DbType.String, ParameterDirection.Input)     //금형코드
                             , helper.CreateParameter("Moldname", Convert.ToString(drRow["Moldname"]), DbType.String, ParameterDirection.Input)     //금형명
                             , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)     //품목코드
                             , helper.CreateParameter("PartNo", Convert.ToString(drRow["PartNo"]), DbType.String, ParameterDirection.Input)     //P/NO(협력사P/NO(21):협력사자체P/NO관리시등록(필수아님) 
                             , helper.CreateParameter("MoldType", Convert.ToString(drRow["MoldType"]), DbType.String, ParameterDirection.Input)     //금형타입
                             , helper.CreateParameter("MoldType1", Convert.ToString(drRow["MoldType1"]), DbType.String, ParameterDirection.Input)     //분류1
                             , helper.CreateParameter("MoldType2", Convert.ToString(drRow["MoldType2"]), DbType.String, ParameterDirection.Input)     //분류2
                             , helper.CreateParameter("MoldLoc", Convert.ToString(drRow["MoldLoc"]), DbType.String, ParameterDirection.Input)     //설치장소
                             , helper.CreateParameter("MakeCompany", Convert.ToString(drRow["MakeCompany"]), DbType.String, ParameterDirection.Input)     //제조사
                             , helper.CreateParameter("ModelName", Convert.ToString(drRow["ModelName"]), DbType.String, ParameterDirection.Input)     //모델명
                             , helper.CreateParameter("SerialNo", Convert.ToString(drRow["SerialNo"]), DbType.String, ParameterDirection.Input)     //시리얼번호
                             , helper.CreateParameter("LifeTime", Convert.ToString(drRow["LifeTime"]), DbType.String, ParameterDirection.Input)     //수명(단위=년)
                             , helper.CreateParameter("Contact", Convert.ToString(drRow["Contact"]), DbType.String, ParameterDirection.Input)     //연락처
                             , helper.CreateParameter("MAWorker1", Convert.ToString(drRow["MAWorker1"]), DbType.String, ParameterDirection.Input)     //작업담당자1
                             , helper.CreateParameter("MAWorker2", Convert.ToString(drRow["MAWorker2"]), DbType.String, ParameterDirection.Input)     //작업담당자2
                             , helper.CreateParameter("TechWorker", Convert.ToString(drRow["TechWorker"]), DbType.String, ParameterDirection.Input)     //장비기술담당자
                             , helper.CreateParameter("BuyDate", Convert.ToString(drRow["BuyDate"]), DbType.String, ParameterDirection.Input)     //도입일자
                             , helper.CreateParameter("BuyCost", Convert.ToString(drRow["BuyCost"]), DbType.String, ParameterDirection.Input)     //도입가격
                             , helper.CreateParameter("Status", Convert.ToString(drRow["Status"]), DbType.String, ParameterDirection.Input)     //상태
                             , helper.CreateParameter("InspLastDate", Convert.ToString(drRow["InspLastDate"]), DbType.String, ParameterDirection.Input)     //최종검사일자
                             , helper.CreateParameter("LimitDate", Convert.ToString(drRow["LimitDate"]), DbType.String, ParameterDirection.Input)     //유효일수
                             , helper.CreateParameter("Cavity", Convert.ToString(drRow["Cavity"]), DbType.String, ParameterDirection.Input)     //Cavity
                             , helper.CreateParameter("Designshot", Convert.ToString(drRow["Designshot"]), DbType.String, ParameterDirection.Input)     //디자인쇼트(설계사용수)
                             , helper.CreateParameter("Workshot", Convert.ToString(drRow["Workshot"]), DbType.String, ParameterDirection.Input)     //작업쇼트(작업사용수)
                             , helper.CreateParameter("Totshot", Convert.ToString(drRow["Totshot"]), DbType.String, ParameterDirection.Input)     //전체쇼트(합계사용수)
                             , helper.CreateParameter("MoldUseCnt", Convert.ToString(drRow["MoldUseCnt"]), DbType.String, ParameterDirection.Input)     //금형사용횟수
                             , helper.CreateParameter("MoldAssType", Convert.ToString(drRow["MoldAssType"]), DbType.String, ParameterDirection.Input)     //자산구분(HMC/KNC/협력사(자사))
                             , helper.CreateParameter("CarType", Convert.ToString(drRow["CarType"]), DbType.String, ParameterDirection.Input)     //차종코드(3):HM/BH/UN/AUT/PC등등
                             , helper.CreateParameter("ENDPNO", Convert.ToString(drRow["ENDPNO"]), DbType.String, ParameterDirection.Input)     //생산품목(자동차ASS'yERP자재마스터에등록된PartNo)
                             , helper.CreateParameter("ENDPNAME", Convert.ToString(drRow["ENDPNAME"]), DbType.String, ParameterDirection.Input)     //생산품목(자동차ASS'yERP자재마스터에등록된PartNo)
                             , helper.CreateParameter("MoldWgt", Convert.ToString(drRow["MoldWgt"]), DbType.String, ParameterDirection.Input)     //금형중량(kg)
                             , helper.CreateParameter("MoldSizeL", Convert.ToString(drRow["MoldSizeL"]), DbType.String, ParameterDirection.Input)     //SIZE(mm)가로
                             , helper.CreateParameter("MoldSizeW", Convert.ToString(drRow["MoldSizeW"]), DbType.String, ParameterDirection.Input)     //SIZE(mm)세로
                             , helper.CreateParameter("MoldSizeH", Convert.ToString(drRow["MoldSizeH"]), DbType.String, ParameterDirection.Input)     //SIZE(mm)높이
                             , helper.CreateParameter("PriceUint", Convert.ToString(drRow["PriceUint"]), DbType.String, ParameterDirection.Input)     //화폐(3):￦,$,€,￥
                             , helper.CreateParameter("HKMCAssNo", Convert.ToString(drRow["HKMCAssNo"]), DbType.String, ParameterDirection.Input)     //자산번호HKMC
                             , helper.CreateParameter("MoldManagerID", Convert.ToString(drRow["MoldManagerID"]), DbType.String, ParameterDirection.Input)     //1차협력사관리자성명
                             , helper.CreateParameter("MoldManagerTel", Convert.ToString(drRow["MoldManagerTel"]), DbType.String, ParameterDirection.Input)  //1차협력사관리자전화번호
                             , helper.CreateParameter("MoldStockerID", Convert.ToString(drRow["MoldStockerID"]), DbType.String, ParameterDirection.Input)  //보관처관리자성명
                             , helper.CreateParameter("MoldStockerTel", Convert.ToString(drRow["MoldStockerTel"]), DbType.String, ParameterDirection.Input)  //보관처관리자전화번호
                             , helper.CreateParameter("Remark", Convert.ToString(drRow["Remark"]), DbType.String, ParameterDirection.Input)         //비고
                             , helper.CreateParameter("MoldStatus", Convert.ToString(drRow["MoldStatus"]), DbType.String, ParameterDirection.Input)         //금형상태
                             , helper.CreateParameter("CustCode", Convert.ToString(drRow["CustCode"]), DbType.String, ParameterDirection.Input)         //저장업체
                             , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                             , helper.CreateParameter("Editor", Convert.ToString(drRow["Editor"]), DbType.String, ParameterDirection.Input));

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
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion
    }
}





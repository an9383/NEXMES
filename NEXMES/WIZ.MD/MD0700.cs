#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                                                                                                                                                                                   
//   Form ID      : MD0700                                                                                                                                                                                                                                                                                                                                           
//   Form Name    : 금형현황                                                                                                                                                                                                                                                                                                                                         
//   Name Space   : wiz.BM                                                                                                                                                                                                                                                                                                                                         
//   Created Date : 2014-05-07                                                                                                                                                                                                                                                                                                                                       
//   Made By      : WIZCORE
//   Description  :                                                                                                                                                                                                                                                                                                                                                  
// *---------------------------------------------------------------------------------------------*                                                                                                                                                                                                                                                                   
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MD
{
    public partial class MD0700 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >
        public MD0700()
        {
            InitializeComponent();

            //조회용 POP 
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "TBM1600", new object[] { cboPlantCode_H, "" }); //금형
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" }); //품목
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
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value); //사업장                                                                                                                                                                                                                                                                       
                string sMoldCode = txtMoldCode.Text;                               //금형코드                                                                                                                                                                                                                                                                                                   
                string sMoldLoc = DBHelper.nvlString(this.cboMoldLoc_H.Value);     //보관장소
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);     //사용여부
                string sItemCode = txtItemCode.Text.Trim();                        //품목

                grid1.DataSource = helper.FillTable("USP_MD0700_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)
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
                // if (helper._sConn != null) { helper._sConn.Close(); }
                helper.Close();
            }
        }
        #endregion

        #region<MD0700_Load>
        private void MD0700_Load(object sender, EventArgs e)
        {
            #region 그리드
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장(사업장)", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Moldname", "금형명", false, GridColDataType_emu.VarChar, 150, 500, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PartNo", "P/NO", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldType", "금형타입", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldType1", "금형종류(코드)", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldType2", "금형재질", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldLoc", "저장위치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "저장업체", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "업체명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeCompany", "제조사", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ModelName", "모델명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SerialNo", "자산번호(시리얼NO)", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LifeTime", "수명(년)", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Contact", "연락처", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWorker1", "작업담당자1", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWorkerNM1", "담당자1명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWorker2", "작업담당자2", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWorkerNM2", "담당자2명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TechWorker", "기술담당자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TechWorkerNM", "담당자명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BuyDate", "도입일자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BuyCost", "도입금액", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Status", "상태", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldStatus", "금형상태", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldRepSeqNo", "금형수리회수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspLastDate", "최종검사일", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LimitDate", "유효일수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Cavity", "Cavity", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Designshot", "설계사용수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Workshot", "작업사용수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Totshot", "전체사용수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldUseCnt", "금형사용횟수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LastUseDate", "최근사용일", false, GridColDataType_emu.DateTime, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldAssType", "자산구분", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldSeq", "금형SEQ", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldUseProc", "금형사용공정명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCommType", "전용/공용금형구분 ", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldFamily", "FAMILY금형", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldMultPNO", "복수금형", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SubPNO", "SUBP/NO", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldPartType", "PART구분", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASPNO", "ASP/NO", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ColorYesNo", "칼라여부", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SubPNOUsg", "USG", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SubItemCode", "협력사P/NO(21)", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CarType", "차종 코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDPNO", "고객생산품목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDPNAME", "고객생산품목명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldWgt", "금형중량(kg)", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldSizeL", "SIZE(mm)가로", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldSizeW", "SIZE(mm)세로", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldSizeH", "SIZE(mm)높이", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PriceUint", "화폐단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "HKMCAssNo", "HKMC자산번호", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldManagerID", "협력사 관리자성명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldManagerTel", "협력사 관리자전화번호", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldStockerID", "보관처 관리자성명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldStockerTel", "보관처 관리자전화번호", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            /* 2014.6.26 Lim y.j 아래를 수정,
                        _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE"   , "사업부"                    , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldCode"    , "금형코드"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "Moldname"    , "금형명"                    , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "ItemCode"    , "품목"                      , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1,"ItemName"     , "품목명"                      , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                                                        
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldType"    , "자산종류"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldType1"   , "금형종류"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldType2"   , "재질"                      , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldLoc"     , "현보관장소"                , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MakeCompany" , "제조사"                    , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "ModelName"   , "모델명"                    , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "SerialNo"    , "자산번호"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "LifeTime"    , "수명(년)"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "Contact"     , "연락처"                    , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MAWorker1"   , "작업담당자1"               , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MAWorker2"   , "작업담당자2"               , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "TechWorker"  , "장비기술담당자"            , false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "BuyDate"     , "취득일자"                  , false, GridColDataType_emu.YearMonthDay, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null); 
                        _GridUtil.InitColumnUltraGrid(grid1, "BuyCost"     , "취득가(원)"                , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "Status"      , "금형상태"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "Cavity"      , "Cavty"                     , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "Designshot"  , "금형수명(타)"              , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "Workshot"    , "작업쇼트"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "Totshot"     , "금형누적타수"              , false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldUseCnt"  , "수리후사용횟수"            , false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "LastUseDate" , "최종사용일자"              , false, GridColDataType_emu.YearMonthDay, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "InspLastDate", "최종점검일자"              , false, GridColDataType_emu.YearMonthDay, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null); 
                        _GridUtil.InitColumnUltraGrid(grid1, "LimitDate"   , "유효일수"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldAssType" , "자산구분"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                                                 
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldSeq"     , "금형SEQ"                   , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldUseProc" , "금형사용공정명"            , false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldCommType", "전용/공용금형구분 "        , false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldFamily"  , "FAMILY금형"                , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldMultPNO" , "복수금형"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "SubPNO"      , "SUBP/NO"                   , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldPartType", "PART구분"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "ASPNO"       , "ASP/NO"                    , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "ColorYesNo"  , "칼라여부"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "SubPNOUsg"   , "USG"                       , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "SubItemCode" , "협력사P/NO(21)"            , false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "CarType"     , "차종코드"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                                                    
                        _GridUtil.InitColumnUltraGrid(grid1, "ENDPNO"       , "품목"                     , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                                                          
                        _GridUtil.InitColumnUltraGrid(grid1, "ENDPNAME"     , "생산품목명"                 , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                                                    
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldWgt"      , "금형중량(kg)"             , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                                                     
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldSizeW"    , "SIZE(mm)세로"             , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                                                       
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldSizeH"    , "높이"                     , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                                                       
                        _GridUtil.InitColumnUltraGrid(grid1, "PriceUint"    , "화폐 : ￦,$,€,￥"        , false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                                          
                        _GridUtil.InitColumnUltraGrid(grid1, "HKMCAssNo"    , "자산번호HKMC"             , false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                                           
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldManagerID", "관리자성명"               , false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                              
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldManagerTel", "관리자전화번호"          , false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                         
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldStockerID" , "보관처  관리자성명"      , false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                                 
                        _GridUtil.InitColumnUltraGrid(grid1, "MoldStockerTel", "보관처  관리자전화번호"  , false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);                                                                                                                                            
                        _GridUtil.InitColumnUltraGrid(grid1, "Remark"        , "비고"                    , false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "UseFlag"       , "사용유무"                , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "MakeDate"      , "등록일자"                , false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null); 
                        _GridUtil.InitColumnUltraGrid(grid1, "Maker"         , "등록자"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
                        _GridUtil.InitColumnUltraGrid(grid1, "EditDate"      , "수정일자"                , false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null); 
                        _GridUtil.InitColumnUltraGrid(grid1, "Editor"        , "수정자"                  , false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            */
            _GridUtil.SetInitUltraGridBind(grid1);

            //row number                                                                                                                                                                                                                                                                                                                                     
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장                                                                                                                                                                                                                                                                                   
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MoldLoc");//보관장소
            WIZ.Common.FillComboboxMaster(this.cboMoldLoc_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTYPE");     // 금형타입 
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldType", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTYPE1");     // 분류1
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldType1", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTYPE2");     // 분류2
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldType2", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MACHSTATUS");    // 상태  
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "Status", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDSTATUS");    // 금형상태  
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldStatus", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDASSTYPE");   // 자산구분 (HMC/KNC/협력사(자사))  
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldAssType", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("CARTYPE");       // 차종 코드(3) : HM/BH/UN/AUT/PC 등등
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CarType", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion
        }
        #endregion

        #region grid POP UP 처리
        #endregion

        #region <METHOD AREA>*/
        // Form에서 사용할 함수나 메소드를 정의                                                                                                                                                                                                                                                                                                                      
        #endregion
    }
}


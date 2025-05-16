#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM1600Y
//   Form Name    : 품목별 사용금형관리
//   Name Space   : WIZ.BM
//   Created Date : 2012-02-21
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM1600Y : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        // 조회 후 상태 변경시 변경 값과 체크를 위한 일자 비교 등록 함수
        private string sLASTCHKDATE = ""; // 최종 보존일자
        private string sLASTASDATE = ""; // 최종 AS 일자
        private string sDISUSEDATE = ""; // 최종 폐기일자
        private string sMOLDTPYE = ""; // 금형 상태 (사용중 에서 상태가 바뀔경우 체크)
        private bool InitOpen = true;    // 최초 화면 OPEN 시 값 변경 여부 리턴 함수
        private bool BoolDoNew = false;   // 추가 시 값변경 여부 리턴함수 
        private int ImageNumber = 0;       // 가져올 이미지의 순번
        private int Imageseq = 0;       // 가져온 이미지의 순번
        private int ImageCount = 0;       // 금형의 총 이미지 수
        byte[] bImage = null;    // 이미지

        #endregion

        #region < CONSTRUCTOR >
        public BM1600Y()
        {
            InitializeComponent();

            //팝업 관리
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "" }); // 품목
            btbManager.PopUpAdd(txtItemCode_B, txtItemName_B, "TBM0100", new object[] { cboPlantCode_H, "" }); // 품목 바디
            btbManager.PopUpAdd(txtMoldCode_H, txtMoldName_H, "TBM1600", new object[] { cboPlantCode_H, "" }); //금형
        }
        #endregion

        #region 폼 초기화

        private void BM1600Y_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CARTYPE", "차종", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 130, 30, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldType1", "금형종류", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDWGT", "설비종류", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDPIECE", "금형구성수", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", false, GridColDataType_emu.VarChar, 230, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Moldname", "금형명", false, GridColDataType_emu.VarChar, 220, 500, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUS", "금형상태", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTSHOTCNT", "총타발수", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWSHOTCNT", "현재타발수", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CAVITY", "CAVITY", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "장착작업장", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "장착작업장명", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PROCINDATE", "장착일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PROCOUTDATE", "탈착일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LASTCHKDATE", "최종보전일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CHKBASECNT", "보전기준타발수", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LASTASDATE", "최종A/S 일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DISUSEFLAG", "폐기여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DISUSEDATE", "폐기일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDMETHOD", "제품공법", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDTYPE2", "금형재질", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MODLSPEC", "금형규격", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDSIZEW", "금형폭", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDSIZEH", "금형높이", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDSIZED", "금형깊이", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BUYDATE", "구입일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BUYCOST", "구입가격", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRICEUINT", "화폐단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKECOMPANY", "제조사", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MODELNAME", "모델", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SERIALNO", "SERIALNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LIFETIME", "수명", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DESIGNSHOT", "최대사용횟수", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CHKFLAG", "보전대상여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAINTWORKID", "보전담당자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAINTCONPHON", "보전담당자연락처", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDMANAGERID", "제조사담당자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDMANAGERTEL", "제조사연락처", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);


            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  // 사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");
            cboPlantCode_B.Value = CModule.GetAppSetting("Site", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("CARTYPE");  // 차종
            WIZ.Common.FillComboboxMaster(this.cboCarType_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CARTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDKIND");  // 금형 종류
            WIZ.Common.FillComboboxMaster(this.cboMoldType1_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MOLDTYPE1", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDSTATUS");  // 금형 상태
            WIZ.Common.FillComboboxMaster(this.cboMoldTpye_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.Common.FillComboboxMaster(this.cboMoldType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDWGT");  // 설비 종류
            WIZ.Common.FillComboboxMaster(this.cbo_MoldWgt_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MOLDWGT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDMETHOD");  // 제품공법
            WIZ.Common.FillComboboxMaster(this.cboMoldMethod_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MOLDMETHOD", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PRICEUNIT");  // 화페단위
            WIZ.Common.FillComboboxMaster(this.cboPriceUnit, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PRICEUNIT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");  // 폐기여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DISUSEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboDisFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboChkFlag_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, ""); // 보전 대상여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CHKFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  // 사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");

            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
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

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value); // 공장
                string sMoldType = DBHelper.nvlString(this.cboMoldType_H.Value);  // 금형상태
                string sDisFlag = DBHelper.nvlString(this.cboDisFlag_H.Value);   // 폐기여부
                string sMoldLoc = DBHelper.nvlString(this.txtMoldCode_H.Value);  // 금형코드
                string sItemCode = DBHelper.nvlString(this.txtItemCode_H.Value);  // 품목
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);   // 사용여부

                grid1.DataSource = helper.FillTable("USP_BM1600Y_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_MOLDCODE", sMoldLoc, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_MOLDTYPE", sMoldType, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_DISFLAG", sDisFlag, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                                   );
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                this.BoolDoNew = false;
            }
        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                this.BoolDoNew = true;
                this.cboPlantCode_B.Enabled = true;  // 공장
                this.cboCarType_B.Enabled = true;  // 차종
                this.cboMoldType1_B.Enabled = true;  // 금형종류
                this.txtItemCode_B.Enabled = true;  // 품목
                this.txtItemCode_B.Text = ""; ;   // 품목
                this.txtItemName_B.Enabled = true;  // 품목명
                this.txtItemName_B.Text = "";    // 품목명
                this.txtMoldCode_B.Text = "";    // 금형 코드
                this.txtMoldName_B.Text = "";    // 금형명
                this.txtWorkerCenter_B.Text = "";    // 장착 작업장
                this.txtWorkName_B.Text = "";    // 작업장 명
                this.txtProcInDate.Text = "";    // 장착일시
                this.txtProcOutDate.Text = "";    // 탈착일시
                this.txtTotShotCnt.Text = "";    // 총 타발수
                this.txtNowShotCnt.Text = "";    // 현재 타발수
                this.btnInI.Enabled = false; // 타발수 초기화 버튼 Enable
                this.cboChkFlag_B.Value = "Y";   // 보전 대상여부
                this.cboUseFlag_B.Value = "Y";   // 사용여부
                this.cboMoldTpye_B.Value = "ST";  // 금형 상태 (재고)
                this.cboMoldTpye_B.Enabled = false; // 금형 상태 (재고)
                this.carLastChkDate.Value = "";   // 최종 보전일자
                this.carLastChkDate.Enabled = false;
                this.carLastAsDate.Value = "";   // 최종 as 일자
                this.carLastAsDate.Enabled = false;
                this.carDisuseDate.Value = "";   // 폐기 일자
                this.carDisuseDate.Enabled = false;
                this.cboMoldMethod_B.Value = "";    // 제품 공법
                this.txtMoldType2.Text = "";    // 금형 재질
                this.txtChkBaseCnt.Text = "";    // 보전 기준 타발수
                this.txtMoldSpec.Text = "";    // 금형 규격
                this.txtMoldSIzeW.Text = "";    // 금형 폭
                this.txtMoldSIzeD.Text = "";    // 금형 깊이
                this.lblMoldMethod_B.Text = "";    // 금형 높이
                this.carBuyDate.Value = "";    // 구입 일자
                this.txtBuyCost.Text = "";    // 구입 가격
                this.cboPriceUnit.Value = "";    // 회폐 단위
                this.txtMakeCompony.Text = "";    // 제조사
                this.txtModelName.Text = "";    // 모델
                this.txtSerialNo.Text = "";    // 시리얼
                this.txtLifeTime.Text = "";    // 수명
                this.txtDesignShot.Text = "";    // 최대 사용횟수
                this.txtCavity.Text = "";    // CAVITY
                this.txtMoldPiece.Text = "";    // 금형 구성수
                this.txtMaintWorkid.Text = "";    // 보전 담당자
                this.txtMaintCconPhon.Text = "";    // 보전 담당자 연락처
                this.txtMoldManagerId.Text = "";    // 제조사 담당자
                this.txtMoldManagerTel.Text = "";    // 제조사 연락처
                this.pictureBox1.Image = null;  // 이미지 초기화
                ImageNumber = 0;
                ultraGroupBox1.Text = "금형 이미지";
                bImage = null;
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
            Grid1ToolAct();
        }
        #endregion

        #region<Grid1ToolAct>
        private void Grid1ToolAct()
        {
            if (!BoolDoNew && this.grid1.Rows.Count == 0)
            {
                MessageBox.Show(Common.getLangText("추가 또는 수정 대상이 존재하지 않습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DBHelper helper = new DBHelper("", true);
            try
            {

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }
                base.DoSave();

                string sPlantCode = Convert.ToString(this.cboPlantCode_B.Value);   // 공장
                string sCarType = Convert.ToString(this.cboCarType_B.Value);     // 차종
                string sMoldType1 = Convert.ToString(this.cboMoldType1_B.Value);   // 금형종류
                string sItemCode = Convert.ToString(this.txtItemCode_B.Text);     // 품목
                string s_MoldWgt = Convert.ToString(this.cbo_MoldWgt_B.Value);    // 설비종류
                string sMoldCode = Convert.ToString(this.txtMoldCode_B.Text);     // 금형코드
                string sChkFlag = Convert.ToString(this.cboChkFlag_B.Value);     // 보전 대상여부
                string sUseFlag = Convert.ToString(this.cboUseFlag_B.Value);     // 사용여부
                string sMoldTpye = Convert.ToString(this.cboMoldTpye_B.Value);    // 금형 상태
                string sLastChkDate = Convert.ToString(this.carLastChkDate.Value);   // 최종 보전일자
                string sLastAsDate = Convert.ToString(this.carLastAsDate.Value);    // 최종 as 일자

                string sDisuseDate = string.Empty;                                  // 폐기 일자
                if (sMOLDTPYE == "OU" && sMoldTpye != sMOLDTPYE)  // 폐기 상태에서 상태가 변경 되었을경우 폐기일자 없앰.
                    sDisuseDate = "";
                else sDisuseDate = Convert.ToString(this.carDisuseDate.Value);

                string sMoldMethod = Convert.ToString(this.cboMoldMethod_B.Value);  // 제품 공법
                string sMoldType2 = Convert.ToString(this.txtMoldType2.Text);      // 금형 재질
                string sChkBaseCnt = Convert.ToString(this.txtChkBaseCnt.Text);     // 보전 기준 타발수
                string sMoldSpec = Convert.ToString(this.txtMoldSpec.Text);       // 금형 규격
                string sMoldSIzeW = Convert.ToString(this.txtMoldSIzeW.Text);      // 금형 폭
                string sMoldSIzeD = Convert.ToString(this.txtMoldSIzeD.Text);      // 금형 깊이
                string sMoldSizeH = Convert.ToString(this.lblMoldMethod_B.Text);      // 금형 높이
                string sBuyDate = Convert.ToString(this.carBuyDate.Value);        // 구입 일자
                string sBuyCost = Convert.ToString(this.txtBuyCost.Text);        // 구입 가격
                string sPriceUnit = Convert.ToString(this.cboPriceUnit.Value);     // 회폐 단위
                string sMakeCompony = Convert.ToString(this.txtMakeCompony.Text);    // 제조사
                string sModelName = Convert.ToString(this.txtModelName.Text);      // 모델
                string sSerialNo = Convert.ToString(this.txtSerialNo.Text);       // 시리얼
                string sLifeTime = Convert.ToString(this.txtLifeTime.Text);       // 수명
                string sDesignShot = Convert.ToString(this.txtDesignShot.Text);     // 최대 사용횟수
                string sCavity = Convert.ToString(this.txtCavity.Text);         // CAVITY
                string sMoldPiece = Convert.ToString(this.txtMoldPiece.Text);      // 금형 구성수
                string sMaintWorkid = Convert.ToString(this.txtMaintWorkid.Text);    // 보전 담당자
                string sMaintCconPhon = Convert.ToString(this.txtMaintCconPhon.Text);  // 보전 담당자 연락처
                string sMoldManagerId = Convert.ToString(this.txtMoldManagerId.Text);  // 제조사 담당자
                string sMoldManagerTel = Convert.ToString(this.txtMoldManagerTel.Text); // 제조사 연락처

                if (sMoldTpye == "OU" && sDisuseDate == "")       // 폐기이면서 폐기일자가 없을경우 
                {
                    this.ClosePrgFormNew();
                    MessageBox.Show(Common.getLangText("폐기 일자를 등록하지 않았습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    helper.Close();
                    return;
                }
                else if (sMoldTpye == "AS" && sLastAsDate == "")  // AS 이면서 AS 일자가 없을경우
                {
                    this.ClosePrgFormNew();
                    MessageBox.Show(Common.getLangText("AS 일자를 등록하지 않았습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    helper.Close();
                    return;
                }
                else if (sMoldTpye == "CK" && sLastChkDate == "") // 보전 이면서 보전 일자가 없을경우
                {
                    this.ClosePrgFormNew();
                    MessageBox.Show(Common.getLangText("보전 일자를 등록하지 않았습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    helper.Close();
                    return;
                }


                helper.ExecuteNoneQuery("USP_BM1600Y_I1", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input) // 공장
                                        , helper.CreateParameter("AS_CARTYPE", sCarType, DbType.String, ParameterDirection.Input) // 차종
                                        , helper.CreateParameter("AS_MOLDTYPE1", sMoldType1, DbType.String, ParameterDirection.Input) // 금형종류
                                        , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input) // 품목
                                        , helper.CreateParameter("AS_MOLDWGT", s_MoldWgt, DbType.String, ParameterDirection.Input) // 설비종류
                                        , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input) // 금형코드
                                        , helper.CreateParameter("AS_CHKFLAG", sChkFlag, DbType.String, ParameterDirection.Input) // 보전 대상여부
                                        , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input) // 사용여부
                                        , helper.CreateParameter("AS_MOLDTPYE", sMoldTpye, DbType.String, ParameterDirection.Input) // 금형 상태
                                        , helper.CreateParameter("AS_LASTCHKDATE", sLastChkDate, DbType.String, ParameterDirection.Input) // 최종 보전일자
                                        , helper.CreateParameter("AS_LASTASDATE", sLastAsDate, DbType.String, ParameterDirection.Input) // 최종 as 일자
                                        , helper.CreateParameter("AS_DISUSEDATE", sDisuseDate, DbType.String, ParameterDirection.Input) // 폐기 일자
                                        , helper.CreateParameter("AS_MOLDMETHOD", sMoldMethod, DbType.String, ParameterDirection.Input) // 제품 공법
                                        , helper.CreateParameter("AS_MOLDTYPE2", sMoldType2, DbType.String, ParameterDirection.Input) // 금형 재질
                                        , helper.CreateParameter("AS_CHKBASECNT", sChkBaseCnt, DbType.String, ParameterDirection.Input) // 보전 기준 타발수
                                        , helper.CreateParameter("AS_MOLDSPEC", sMoldSpec, DbType.String, ParameterDirection.Input) // 금형 규격
                                        , helper.CreateParameter("AS_MOLDSIZEW", sMoldSIzeW, DbType.String, ParameterDirection.Input) // 금형 폭
                                        , helper.CreateParameter("AS_MOLDSIZED", sMoldSIzeD, DbType.String, ParameterDirection.Input) // 금형 폭
                                        , helper.CreateParameter("AS_MOLDSIZEH", sMoldSizeH, DbType.String, ParameterDirection.Input) // 금형 높이
                                        , helper.CreateParameter("AS_BUYDATE", sBuyDate, DbType.String, ParameterDirection.Input) // 구입 일자
                                        , helper.CreateParameter("AS_BUYCOST", sBuyCost, DbType.String, ParameterDirection.Input) // 구입 가격
                                        , helper.CreateParameter("AS_PRICEUNIT", sPriceUnit, DbType.String, ParameterDirection.Input) // 회폐 단위
                                        , helper.CreateParameter("AS_MAKECOMPONY", sMakeCompony, DbType.String, ParameterDirection.Input) // 제조사
                                        , helper.CreateParameter("AS_MODELNAME", sModelName, DbType.String, ParameterDirection.Input) // 모델
                                        , helper.CreateParameter("AS_SERIALNO", sSerialNo, DbType.String, ParameterDirection.Input) // 시리얼
                                        , helper.CreateParameter("AS_LIFETIME", sLifeTime, DbType.String, ParameterDirection.Input) // 수명
                                        , helper.CreateParameter("AS_DESIGNSHOT", sDesignShot, DbType.String, ParameterDirection.Input) // 최대 사용횟수
                                        , helper.CreateParameter("AS_CAVITY", sCavity, DbType.String, ParameterDirection.Input) // CAVITY
                                        , helper.CreateParameter("AS_MOLDPIECE", sMoldPiece, DbType.String, ParameterDirection.Input) // 금형 구성수
                                        , helper.CreateParameter("AS_MAINTWORKID", sMaintWorkid, DbType.String, ParameterDirection.Input) // 보전 담당자
                                        , helper.CreateParameter("AS_MAINTCCONPHON", sMaintCconPhon, DbType.String, ParameterDirection.Input) // 보전 담당자 연락처
                                        , helper.CreateParameter("AS_MOLDMANAGERID", sMoldManagerId, DbType.String, ParameterDirection.Input) // 제조사 담당자
                                        , helper.CreateParameter("AS_MOLDMANAGERTEL", sMoldManagerTel, DbType.String, ParameterDirection.Input) // 제조사 연락처
                                        , helper.CreateParameter("AS_WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input) // 제조사 연락처
                                        );
                // RSCODE 가 S 일경우 helper.RSMSG 로 MoldCode를 리턴함.
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ClosePrgFormNew();
                    // 데이터가 저장 되었습니다.
                    this.ShowDialog(Common.getLangText("데이터가 저장 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    DoInquire();
                    // 해당 행 선택
                    for (int i = 0; i < this.grid1.Rows.Count; i++)
                    {
                        if (this.grid1.Rows[i].Cells["MOLDCODE"].Value.ToString() == helper.RSMSG)
                        {
                            this.grid1.Rows[i].Activated = true;
                            break;
                        }
                    }
                }
                else if (helper.RSCODE == "E")
                {
                    helper.Rollback();
                    this.ClosePrgFormNew();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ClosePrgFormNew();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
        #endregion
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            this.BoolDoNew = false; // 추가 아닌 조회 후 선택 시 값 변경 이벤트 호출
            this.InitOpen = true;
            cboPlantCode_B.Value = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();  // 공장
            cboPlantCode_B.Enabled = false;
            cboCarType_B.Value = this.grid1.ActiveRow.Cells["CARTYPE"].Value.ToString();    // 차종
            cboMoldType1_B.Value = this.grid1.ActiveRow.Cells["MOLDTYPE1"].Value.ToString();  // 금형종류
            txtItemCode_B.Text = this.grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();   // 품목
            txtItemCode_B.Enabled = false;
            txtItemName_B.Text = this.grid1.ActiveRow.Cells["ITEMNAME"].Value.ToString();   // 품목명
            txtItemName_B.Enabled = false;
            cbo_MoldWgt_B.Value = this.grid1.ActiveRow.Cells["MOLDWGT"].Value.ToString();    // 설비종류
            txtMoldCode_B.Text = this.grid1.ActiveRow.Cells["MOLDCODE"].Value.ToString();   // 금형코드
            txtMoldName_B.Text = this.grid1.ActiveRow.Cells["MOLDNAME"].Value.ToString();   // 금형명
            txtWorkerCenter_B.Text = this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();  // 장착작업장
            txtWorkName_B.Text = this.grid1.ActiveRow.Cells["WORKCENTERNAME"].Value.ToString();  // 장착작업장명
            if (this.grid1.ActiveRow.Cells["PROCINDATE"].Value.ToString() != "")
            {
                DateTime ProcIndate = Convert.ToDateTime(this.grid1.ActiveRow.Cells["PROCINDATE"].Value.ToString());      // 장착일시
                txtProcInDate.Text = ProcIndate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else txtProcInDate.Text = "";
            if (this.grid1.ActiveRow.Cells["PROCOUTDATE"].Value.ToString() != "")
            {
                DateTime Procoutdate = Convert.ToDateTime(this.grid1.ActiveRow.Cells["PROCOUTDATE"].Value.ToString());      // 탈착일시
                txtProcOutDate.Text = Procoutdate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else txtProcOutDate.Text = "";
            this.sMOLDTPYE = this.grid1.ActiveRow.Cells["WORKSTATUS"].Value.ToString();
            cboMoldTpye_B.Value = this.grid1.ActiveRow.Cells["WORKSTATUS"].Value.ToString();      // 금형상태

            this.sLASTCHKDATE = this.grid1.ActiveRow.Cells["LASTCHKDATE"].Value.ToString();
            carLastChkDate.Value = this.grid1.ActiveRow.Cells["LASTCHKDATE"].Value.ToString();     // 최종보전일자

            this.sLASTASDATE = this.grid1.ActiveRow.Cells["LASTASDATE"].Value.ToString();
            carLastAsDate.Value = this.grid1.ActiveRow.Cells["LASTASDATE"].Value.ToString();      // 최종 as 일자

            this.sDISUSEDATE = this.grid1.ActiveRow.Cells["DISUSEDATE"].Value.ToString();
            carDisuseDate.Value = this.grid1.ActiveRow.Cells["DISUSEDATE"].Value.ToString();      // 폐기 일자

            txtTotShotCnt.Text = this.grid1.ActiveRow.Cells["TOTSHOTCNT"].Value.ToString();      // 총 타발수
            txtNowShotCnt.Text = this.grid1.ActiveRow.Cells["NOWSHOTCNT"].Value.ToString();      // 현재 타발수
            cboMoldMethod_B.Value = this.grid1.ActiveRow.Cells["MOLDMETHOD"].Value.ToString();      // 제품공법
            txtMoldType2.Text = this.grid1.ActiveRow.Cells["MOLDTYPE2"].Value.ToString();       // 금형재질
            txtChkBaseCnt.Text = this.grid1.ActiveRow.Cells["CHKBASECNT"].Value.ToString();      // 보전 기준 타발수
            txtMoldSpec.Text = this.grid1.ActiveRow.Cells["MODLSPEC"].Value.ToString();        // 금형 규격
            txtMoldSIzeD.Text = this.grid1.ActiveRow.Cells["MOLDSIZED"].Value.ToString();       // 금형 깊이
            txtMoldSIzeW.Text = this.grid1.ActiveRow.Cells["MOLDSIZEW"].Value.ToString();       // 금형폭
            lblMoldMethod_B.Text = this.grid1.ActiveRow.Cells["MOLDSIZEH"].Value.ToString();       // 금형 높이 
            carBuyDate.Value = this.grid1.ActiveRow.Cells["BUYDATE"].Value.ToString();         // 구입 일자
            txtBuyCost.Text = this.grid1.ActiveRow.Cells["BUYCOST"].Value.ToString();         // 구입 가격
            cboPriceUnit.Value = this.grid1.ActiveRow.Cells["PRICEUINT"].Value.ToString();       // 화페단위
            txtMakeCompony.Text = this.grid1.ActiveRow.Cells["MAKECOMPANY"].Value.ToString();     // 제조사
            txtModelName.Text = this.grid1.ActiveRow.Cells["MODELNAME"].Value.ToString();       // 모델
            txtSerialNo.Text = this.grid1.ActiveRow.Cells["SERIALNO"].Value.ToString();        // 시리얼
            txtLifeTime.Text = this.grid1.ActiveRow.Cells["LIFETIME"].Value.ToString();        // 수명
            txtDesignShot.Text = this.grid1.ActiveRow.Cells["DESIGNSHOT"].Value.ToString();      // 최대사용회수
            txtCavity.Text = this.grid1.ActiveRow.Cells["CAVITY"].Value.ToString();          // CAVITY
            cboUseFlag_B.Value = this.grid1.ActiveRow.Cells["USEFLAG"].Value.ToString();         // 사용여부
            cboChkFlag_B.Value = this.grid1.ActiveRow.Cells["CHKFLAG"].Value.ToString();         // 보전 대상여부

            txtMoldPiece.Text = this.grid1.ActiveRow.Cells["MOLDPIECE"].Value.ToString();         // 금형 구성수
            txtMaintWorkid.Text = this.grid1.ActiveRow.Cells["MAINTWORKID"].Value.ToString();       // 보전 담당자
            txtMaintCconPhon.Text = this.grid1.ActiveRow.Cells["MAINTCONPHON"].Value.ToString();      // 보전 담당자 연락처
            txtMoldManagerId.Text = this.grid1.ActiveRow.Cells["MOLDMANAGERID"].Value.ToString();     // 제조사 담당자
            txtMoldManagerTel.Text = this.grid1.ActiveRow.Cells["MOLDMANAGERTEL"].Value.ToString();    // 제조사 연락처

            this.cboPlantCode_B.Enabled = false;  // 공장
            this.cboCarType_B.Enabled = false;  // 차종
            this.cboMoldType1_B.Enabled = false;  // 금형종류
            this.txtItemCode_B.Enabled = false;  // 품목
            this.txtItemName_B.Enabled = false;  // 품목명
            this.cboMoldTpye_B.Enabled = true;   // 금형 상태 (재고)
            this.btnInI.Enabled = true;   // 타발수 초기화 버튼 활성
            this.InitOpen = false;  // 콤보박스 입력 활성화
            this.ImageNumber = 0;      // 금형 이미지 호출 수 초기화
            ultraGroupBox1.Text = "금형 이미지";
            // 이미지 표현 가장 첫 이미지 0
            FindImage(0);
        }


        private void cboMoldTpye_B_TextChanged(object sender, EventArgs e)
        {
            if (this.BoolDoNew) return; // 추가로 인한 변경 시 return
            this.InitOpen = true;
            // 사용중인 금형의 상태 변경 시 확인 메세지
            if (cboMoldTpye_B.Value.ToString() != "OK")  // OK
            {
                if (this.sMOLDTPYE == "OK")
                {
                    if (MessageBox.Show(Common.getLangText("현재 사용중인 금형의 상태를 변경 하시겠습니까?", "MSG"), "사용중 금형 상태변경", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        cboMoldTpye_B.Value = "OK";
                        return;
                    }
                }
            }
            if (cboMoldTpye_B.Value.ToString() == "AS")  // AS
            {
                carLastAsDate.Enabled = true;
                carLastChkDate.Enabled = false;
                carDisuseDate.Enabled = false;
                carLastChkDate.Value = this.sLASTCHKDATE;
                carDisuseDate.Value = this.sDISUSEDATE;
            }
            else if (cboMoldTpye_B.Value.ToString() == "CK")  // 보전
            {
                carLastAsDate.Enabled = false;
                carLastChkDate.Enabled = true;
                carDisuseDate.Enabled = false;
                carLastAsDate.Value = this.sLASTASDATE;
                carDisuseDate.Value = this.sDISUSEDATE;
            }
            else if (cboMoldTpye_B.Value.ToString() == "OU") // 폐기
            {
                carLastAsDate.Enabled = false;
                carLastChkDate.Enabled = false;
                carDisuseDate.Enabled = true;
                carLastAsDate.Value = this.sLASTASDATE;
                carLastChkDate.Value = this.sLASTCHKDATE;
            }
            else
            {
                carLastAsDate.Enabled = false;
                carLastChkDate.Enabled = false;
                carDisuseDate.Enabled = false;
                carLastAsDate.Value = this.sLASTASDATE;
                carLastChkDate.Value = this.sLASTCHKDATE;
                carDisuseDate.Value = this.sDISUSEDATE;
            }
            this.InitOpen = false;
        }

        // 타발수 초기화
        private void btnInI_Click(object sender, EventArgs e)
        {
            if (this.txtTotShotCnt.Text == "0" || this.txtTotShotCnt.Text == "" || this.txtNowShotCnt.Text == "0" || this.txtNowShotCnt.Text == "")
            {
                MessageBox.Show(Common.getLangText("초기화 할 타발수 실적 데이터가 잘못 되었거나 존재하지 않습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show(Common.getLangText("선택한 금형의 현재 타발수를 초기화 하시겠습니까 ? ", "MSG"), "현재 타발수 초기화", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            DBHelper helper = new DBHelper("", true);
            try
            {
                string plantcode = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
                string sMoldCode = this.grid1.ActiveRow.Cells["MOLDCODE"].Value.ToString();

                helper.ExecuteNoneQuery("USP_BM1600Y_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", plantcode, DbType.String, ParameterDirection.Input)     //공장(사업부)                                                    
                            , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)     //금형코드
                            , helper.CreateParameter("AS_WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input)      //작업자
                            );
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("데이터가 저장 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    DoInquire();
                    for (int i = 0; i < this.grid1.Rows.Count; i++)
                    {
                        if (this.grid1.Rows[i].Cells["MOLDCODE"].Value.ToString() == sMoldCode)
                        {
                            this.grid1.Rows[i].Activated = true;
                            break;
                        }
                    }

                }
                else if (helper.RSCODE == "E")
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        // 최종 보전 일자 변경시 일자 크기 체크
        private void carLastChkDate_TextChanged(object sender, EventArgs e)
        {
            if (this.InitOpen || sLASTCHKDATE == "" || carLastChkDate.Value.ToString() == "") return;
            if (Convert.ToInt32(sLASTCHKDATE.Replace("-", "")) > Convert.ToInt32(carLastChkDate.Value.ToString().Substring(0, 10).Replace("-", "")))
            {
                MessageBox.Show(Common.getLangText("보전 일자는 이전 실적 일자보다 이후일자로 등록해야 합니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                carLastChkDate.Value = sLASTCHKDATE;
            }

        }
        // 최종 AS 일자 변경 시 일자 크기 체크
        private void carLastAsDate_TextChanged(object sender, EventArgs e)
        {
            if (this.InitOpen || sLASTASDATE == "" || carLastAsDate.Value.ToString() == "") return;
            if (Convert.ToInt32(sLASTASDATE.Replace("-", "")) > Convert.ToInt32(carLastAsDate.Value.ToString().Substring(0, 10).Replace("-", "")))
            {
                MessageBox.Show(Common.getLangText("AS 일자는 이전 실적 일자보다 이후일자로 등록해야 합니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                carLastAsDate.Value = sLASTASDATE;
            }
        }
        // 폐기 일자 변경 시 일자 크기 체크
        private void carDisuseDate_TextChanged(object sender, EventArgs e)
        {
            if (this.InitOpen || sDISUSEDATE == "" || carDisuseDate.Value.ToString() == "") return;
            if (Convert.ToInt32(sDISUSEDATE.Replace("-", "")) > Convert.ToInt32(carDisuseDate.Value.ToString().Substring(0, 10).Replace("-", "")))
            {
                MessageBox.Show(Common.getLangText("폐기 일자는 이전 실적 일자보다 이후일자로 등록해야 합니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                carDisuseDate.Value = sDISUSEDATE;
            }
        }

        private void txtChkBaseCnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                // 숫자입력 메시지창 표현.
                MessageBox.Show(Common.getLangText("숫자만 입력하여 주십시요", "MSG"));
                e.Handled = true;
            }
        }

        private void txtBuyCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                MessageBox.Show(Common.getLangText("소수점 포함한 숫자만 입력하여 주십시요", "MSG"));
                e.Handled = true;
            }
        }

        private void btnImageIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BoolDoNew || this.grid1.Rows.Count == 0)
                {
                    MessageBox.Show(Common.getLangText("이미지를 등록할 대상이 없습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                OpenFileDialog openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp";

                if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Image image = Image.FromFile(openfiledialog.FileName);
                    string ImgPath = openfiledialog.FileName;
                    string ImgNM = openfiledialog.SafeFileName;

                    FileStream stream = new FileStream(ImgPath, FileMode.Open, FileAccess.Read);
                    BinaryReader reader = new BinaryReader(stream);
                    bImage = reader.ReadBytes((int)stream.Length);
                    reader.Close();
                    stream.Close();

                    // 이미지 표현
                    if (bImage != null)
                        pictureBox1.Image = new Bitmap(new MemoryStream(bImage));
                    pictureBox1.BringToFront();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    if (MessageBox.Show(Common.getLangText("해당 이미지로 등록하시겠습니까 ?", "MSG"), "금형 이미지 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        bImage = null;
                        pictureBox1.Image = null;
                        return;
                    }
                    // 이미지 저장
                    DBHelper helper = new DBHelper("", true);
                    try
                    {
                        helper.ExecuteNoneQuery("USP_BM1600Y_I2", CommandType.StoredProcedure
                           , helper.CreateParameter("AS_PLANTCODE", this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ITEMIMAGE", (bImage == null) ? SqlBinary.Null : bImage, DbType.Binary, ParameterDirection.Input)
                           , helper.CreateParameter("AS_MOLDCODE", this.grid1.ActiveRow.Cells["MOLDCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input)
                           );
                        if (helper.RSCODE == "S")
                        {
                            helper.Commit();
                            // 데이터가 저장 되었습니다.
                            MessageBox.Show(Common.getLangText("이미지가 등록 되었습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        // 선택한 금형 에서 호출한 이미지의 가장 마지막 seq 이미지를 호출함
                        FindImage(this.ImageCount);
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        this.ShowDialog(ex.ToString());
                    }
                    finally
                    {
                        helper.Close();
                    }

                }
            }
            catch (SException ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        // 이미지 호출
        private void FindImage(int ImageSeq)
        {
            DBHelper helper = new DBHelper("", false);
            try
            {
                // 이미지 호출
                DataTable DtPlant = helper.FillTable("USP_BM1600Y_S2", CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_NUMBER", ImageSeq, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MOLDCODE", this.grid1.ActiveRow.Cells["MOLDCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                     );
                if (DtPlant.Rows.Count > 0 && DtPlant.Rows[0]["MOLDIMG"].ToString() != string.Empty)
                {
                    byte[] bImage = null;
                    bImage = (byte[])DtPlant.Rows[0]["MOLDIMG"];
                    if (bImage != null)
                        pictureBox1.Image = new Bitmap(new MemoryStream(bImage));
                    pictureBox1.BringToFront();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Imageseq = Convert.ToInt32(DtPlant.Rows[0]["MOLDSEQ"]);
                    this.ImageCount = Convert.ToInt32(DtPlant.Rows[0]["LICOUNT"]);

                }
                else
                {
                    this.Imageseq = 0;
                    this.ImageCount = 0;
                    this.pictureBox1.Image = null;
                }
                ultraGroupBox1.Text = "금형 이미지     " + Imageseq + " / " + ImageCount;

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }

        // 다음 이미지 표현
        private void btnImageNext_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0 || this.txtMoldCode_B.Text == "" || this.Imageseq == 0)
            {
                return;
            }
            ImageNumber = ImageNumber - 1;
            FindImage(ImageNumber);
        }

        // 이전 이미지 표현
        private void btnImageBefor_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0 || this.txtMoldCode_B.Text == "" || this.Imageseq == 0)
            {
                return;
            }
            ImageNumber = ImageNumber + 1;
            FindImage(ImageNumber);
        }
        // 이미지 삭제
        private void btnImageDel_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0 || this.txtMoldCode_B.Text == "" || this.Imageseq == 0)
            {
                MessageBox.Show(Common.getLangText("이미지를 삭제할 대상이 없습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(Common.getLangText("선택한 이미지를 삭제 하시겠습니까?", "MSG"), "금형 이미지 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            // 이미지 삭제
            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("USP_BM1600Y_I3", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_NUMBER", Imageseq - 1, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_MOLDCODE", this.grid1.ActiveRow.Cells["MOLDCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                   );
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    MessageBox.Show(Common.getLangText("선택된 이미지가 삭제 되었습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // 처음 이미지 호출
                    FindImage(0);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        // 이미지 사이즈 변경
        private int PicClickCount = 0;
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (PicClickCount % 2 == 0)
            {
                this.tabControl1.Size = new System.Drawing.Size(852, 459);
                this.grid1.Size = new System.Drawing.Size(1124, 262);
            }
            else
            {
                this.tabControl1.Size = new System.Drawing.Size(50, 459);
                this.grid1.Size = new System.Drawing.Size(1124, 50);
            }

            PicClickCount = PicClickCount + 1;
        }

    }
}





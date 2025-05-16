#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0210
//   Form Name    : 반출품 반입처리(반출증 기준)
//   Name Space   : WIZ.MM
//   Created Date : 2015-09-17
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM0210 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable dtTemp = new DataTable();
        DataTable DtChange = new DataTable();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        string checkGird1IndexLotNO = "";
        UltraGridUtil _GridUtil = new UltraGridUtil();
        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private bool KeyChecked = false; // 판정값 자동 입력을 받기 위한 bool true : 정상 자동판정가능 false = 판정값비교불가

        private string sTraNo = string.Empty;
        //private string sPlantCode = LoginInfo.PlantCode;
        //private int rowindex;
        #endregion

        #region < CONSTRUCTOR >

        public MM0210()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager gridManager = new BizGridManager(grid2);

            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode, "ROH" });
            btbManager.PopUpAdd(txtWorkerId_B, txtWorkerName_B, "TBM0200", new object[] { cboPlantCode, "", "", "", "Y", "", "", "" });

            gridManager.PopUpAdd("INSPWORKER", "INSPWORKERNAME", "TBM0200", new string[] { "PlantCode", "", "", "", "" });

            this.plantCode = CModule.GetAppSetting("Site", "10");

        }
        #endregion

        #region  MM0210_Load
        private void MM0210_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성

            #region Grid 셋팅 //100 130 100 196 165 100 87 123 123 100 201 100 100 191 228 100 100
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 100, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRTDATE", "바코드발행일", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTBASEQTY", "중량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "POSEQNO", "발주순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PREINGROUPNO", "발행그룹번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTLOTNO", "업체 LOTNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PREINDATE", "가입고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "WHCODE", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGRLOCCODE", "STORAGRLOCCODE", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECIALINDATE", "SPECIALINDATE", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECIALINPERSON", "SPECIALINPERSON", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECIALINPERSONNAME", "SPECIALINPERSONNAME", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECIALINREASON", "SPECIALINREASON", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECIALINBEFORESTATUS", "SPECIALINBEFORESTATUS", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "INSPDATE", "수입검사 일자", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT", "판정결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULTNAME", "판정결과명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "LOT상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUSNAME", "LOT상태명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "VALUETYPE", "측정값구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "VALUETYPENAME", "측정값구분명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECTYPE", "SPEC적용기준", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECTYPENAME", "SPEC적용기준명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STDVALUE", "기준값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "USLVALUE", "상한값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LSLVALUE", "하한값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPRESULTVAL", "측정값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPRESULT", "판정", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPWORKER", "검사자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPWORKERNAME", "검사자명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);


            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "PRTDATE", "바코드발행일", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "PREINDATE", "가입고일자", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MATLOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTBASEQTY", "수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "SPECIALINPERSON", "특채입고자", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "SPECIALINDATE", "특채입고일자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "SPECIALINPERSONNAME", "특채입고자명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "SPECIALINREASON", "특채입고사유", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "PONO", "발주번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "POSEQNO", "발주순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid3, "PREINGROUPNO", "발행그룹번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "STOCKQTY", "수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CUSTLOTNO", "업체 LOTNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid3, "WHCODE", "창고코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "WHNAME", "창고명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "STORAGRLOCCODE", "저장위치코드", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "STORAGELOCNAME", "저장위치명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid3, "INSPDATE", "수입검사 일자", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "INSPRESULT", "판정결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "INSPRESULTNAME", "판정결과명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTSTATUS", "LOT 상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTSTATUSNAME", "LOT 상태명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid3, "SPECIALINBEFORESTATUS", "재고 이전의 상태", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid3);


            string[] arrMerCol1 = { "INSPDATE", "INSPRESULT", "INSPRESULTNAME" };
            _GridUtil.GridHeaderMerge(grid1, "A", "수입검사", arrMerCol1, null);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode.Value = plantCode;
            string sPlantCode = Convert.ToString(this.cboPlantCode.Value);

            GetOkNg();
            GetWHCODE();
            GetLotStatus();
            #endregion

        }
        #endregion  MM0210_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid3);
            DBHelper helper = new DBHelper(false);
            try
            {

                if (!CheckData())
                {
                    return;
                }
                string sPlantCode = Convert.ToString(cboPlantCode.Value);                   // 공장코드
                string sStartdate = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);
                string sEnddate = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);
                string sItemCode = this.txtItemCode_H.Text.Trim();
                string sLotStatus = Convert.ToString(this.cboLotStatus_H.Value);
                string sCoilNo = Convert.ToString(txtCoilNo_H.Text);
                string sPONO = Convert.ToString(txtPoNo_H.Text);
                string TabStatus = "";
                if (tabControl1.SelectedTab.Index == 0) TabStatus = "TAB1";
                else TabStatus = "TAB2";

                dtTemp = helper.FillTable("USP_MM0210_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("STARTDATE", sStartdate, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("ENDDATE", sEnddate, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("LOTSTATUS", sLotStatus, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("PONO", sPONO, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("COILNO", sCoilNo, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("TABSELECT", TabStatus, DbType.String, ParameterDirection.Input)
                                                         );


                this.ClosePrgFormNew();
                if (dtTemp.Rows.Count > 0)
                {
                    if (tabControl1.SelectedTab.Index == 0)
                    {
                        grid1.DataSource = dtTemp;
                        grid1.DataBinds(dtTemp);
                        if (this.checkGird1IndexLotNO != "")
                        {
                            for (int i = 0; i < this.grid1.Rows.Count; i++)
                            {
                                if (checkGird1IndexLotNO == Convert.ToString(this.grid1.Rows[i].Cells["MATLOTNO"].Value))
                                {
                                    this.grid1.Rows[i].Activated = true;
                                    this.checkGird1IndexLotNO = "";
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        grid3.DataSource = dtTemp;
                        grid3.DataBinds(dtTemp);
                    }
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    _GridUtil.Grid_Clear(grid2);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                }
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
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            if (grid1.Rows.Count == 0)
            {
                if (grid3.Rows.Count == 0)
                    return;
                else
                {
                    int k = 0;
                    for (int i = 0; i < this.grid3.Rows.Count; i++)
                    {
                        if (Convert.ToString(this.grid3.Rows[i].Cells["CHK"].Value) == "1")
                        {
                            k++;
                            break;
                        }
                    }
                    if (k == 0) return;
                }
            }
            if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {

                CancelProcess = true;
                return;
            }
            DBHelper helper = new DBHelper("", true);
            try
            {
                if (tabControl1.SelectedTab.Index == 0)
                {
                    string sPLANTCODE = Convert.ToString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    string sWORKERID = Convert.ToString(this.txtWorkerId_B.Text);
                    string sMAKER = Convert.ToString(WIZ.LoginInfo.UserID);
                    string sREMARK = Convert.ToString(txtRemark_B.Text);
                    string sMATLOTNO = Convert.ToString(this.grid1.ActiveRow.Cells["MATLOTNO"].Value);
                    string sITEMCODE = Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    string sQTY = Convert.ToString(this.grid1.ActiveRow.Cells["LOTBASEQTY"].Value);
                    string sPONO = Convert.ToString(this.grid1.ActiveRow.Cells["PONO"].Value);
                    string sPOSEQNO = Convert.ToString(this.grid1.ActiveRow.Cells["POSEQNO"].Value);
                    string sLotStatus = Convert.ToString(this.grid1.ActiveRow.Cells["LOTSTATUS"].Value);
                    string sWHCODE = Convert.ToString(this.cboWhCode_B.Value);
                    string sSTORAGELOCCODE = Convert.ToString(this.cboStoragrLocCode_B.Value);
                    string scarSpInDate = Convert.ToString(string.Format("{0:yyyy-MM-dd}", carSpInDate_B.Value));
                    string sCustCode = Convert.ToString(this.grid1.ActiveRow.Cells["CUSTCODE"].Value);
                    this.checkGird1IndexLotNO = Convert.ToString(this.grid1.ActiveRow.Cells["MATLOTNO"].Value);
                    DataTable dt = grid2.chkChange();

                    if (Convert.ToString(this.grid1.ActiveRow.Cells["LOTSTATUS"].Value) == "00" ||
                        Convert.ToString(this.grid1.ActiveRow.Cells["LOTSTATUS"].Value) == "10" ||
                        Convert.ToString(this.grid1.ActiveRow.Cells["LOTSTATUS"].Value) == "20")
                    {
                        if (this.txtWorkerId_B.Text != "")
                        {
                            helper.ExecuteNoneQuery("USP_MM0210_I1", CommandType.StoredProcedure
                                                , helper.CreateParameter("PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("WORKERID", sWORKERID, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("MAKER", sMAKER, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("REMARK", sREMARK, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("MATLOTNO", sMATLOTNO, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("QTY", sQTY, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("PONO", sPONO, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("POSEQNO", sPOSEQNO, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("WHCODE", sWHCODE, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("STORAGELOCCODE", sSTORAGELOCCODE, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("sLOTSTATUS", sLotStatus, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("SpInDate", scarSpInDate, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                               );

                        }
                        else
                        {
                            helper.Rollback();
                            this.ShowDialog(Common.getLangText("특채입고 작업자를 등록하지 않았습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (helper.RSCODE != "S")
                        {
                            //string a = helper.RSMSG;
                            //this.ShowDialog("특채입고 를 실패하였습니다.", Forms.DialogForm.DialogType.OK);
                            //15-09-30 마감일자수불체크 메세지를 위해 수정 최재형
                            helper.Rollback();
                            this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                            return;
                        }
                    }

                    // 수입검사 내역의 수정 사항이 존재 하지 않을경우.
                    if (dt == null)
                    {
                        helper.Commit();
                        this.ShowDialog(Common.getLangText("데이터가 저장되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        DoInquire();
                        return;
                    }
                    int CheckAllInspResultValueFlag = 0;
                    foreach (DataRow drRow in dt.Rows)
                    {
                        string sInspCode = Convert.ToString(drRow["INSPCODE"]);
                        string sINSPRESULTVAL = Convert.ToString(drRow["INSPRESULTVAL"]);
                        string sOKNG = Convert.ToString(drRow["INSPRESULT"]);
                        sWORKERID = Convert.ToString(drRow["INSPWORKER"]);
                        string sVALUETYPE = Convert.ToString(drRow["VALUETYPE"]); //측정항목 구분
                        string sSPECTYPE = Convert.ToString(drRow["SPECTYPE"]);  //스펙 적용 기준.
                        if (sVALUETYPE != "J")
                        {
                            if (sINSPRESULTVAL == "")
                            {
                                helper.Rollback();
                                this.ShowDialog(Common.getLangText("검사 측정값을 입력하지 않았습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }
                        }
                        if (sOKNG == "")
                        {
                            helper.Rollback();
                            this.ShowDialog(Common.getLangText("검사 판정값을 입력하지 않았습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        helper.ExecuteNoneQuery("USP_MM0210_I2", CommandType.StoredProcedure
                                               , helper.CreateParameter("PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("WORKERID", sWORKERID, DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("MAKER", sMAKER, DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("MATLOTNO", sMATLOTNO, DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("REMARK", sREMARK, DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("INSPRESULTVAL", sINSPRESULTVAL, DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("OKNG", sOKNG, DbType.String, ParameterDirection.Input)
                                              );
                        if (helper.RSCODE != "S")
                        {
                            helper.Rollback();
                            this.ShowDialog(Common.getLangText("특채입고를 실패하였습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        CheckAllInspResultValueFlag++;
                    }
                    if (CheckAllInspResultValueFlag != this.grid2.Rows.Count)
                    {
                        helper.Rollback();
                        this.ShowDialog(Common.getLangText("누락된 수입검사 내역이 존재 합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }

                }
                else
                {
                    // 특채입고 취소
                    DataTable dt = grid3.chkChange();
                    foreach (DataRow drRow in dt.Rows)
                    {
                        string sPLANTCODE = Convert.ToString(drRow["PLANTCODE"]);
                        string sMATLOTNO = Convert.ToString(drRow["MATLOTNO"]);
                        string sITEMCODE = Convert.ToString(drRow["ITEMCODE"]);
                        string sQTY = Convert.ToString(drRow["LOTBASEQTY"]);
                        string sPONO = Convert.ToString(drRow["PONO"]);
                        string sPOSEQNO = Convert.ToString(drRow["POSEQNO"]);
                        string sWHCODE = Convert.ToString(drRow["WHCODE"]);
                        string sSTORAGELOCCODE = Convert.ToString(drRow["STORAGRLOCCODE"]);

                        this.checkGird1IndexLotNO = Convert.ToString(drRow["MATLOTNO"]);

                        string sMAKER = Convert.ToString(WIZ.LoginInfo.UserID);

                        helper.ExecuteNoneQuery("USP_MM0210_I3", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", sMAKER, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MATLOTNO", sMATLOTNO, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("QTY", sQTY, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PONO", sPONO, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("POSEQNO", sPOSEQNO, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WHCODE", sWHCODE, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STORAGELOCCODE", sSTORAGELOCCODE, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                                                   );
                        if (helper.RSCODE != "S")
                        {
                            string a = helper.RSMSG;
                            helper.Rollback();
                            this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                            return;
                        }
                    }
                }
                this.ShowDialog(Common.getLangText("데이터가 저장되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                helper.Commit();

                DoInquire();
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
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

        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtStart_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtEnd_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }

        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }

        private void grid1_ClickCell(object sender, EventArgs e)
        {

            if (this.grid1.Rows.Count == 0) return;
            CheckLotStatus();

            this.txtPlantCode_B.Text = this.grid1.ActiveRow.Cells["PLANTCODE"].Text.ToString();
            this.txtpono_B.Text = this.grid1.ActiveRow.Cells["PONO"].Text.ToString();
            this.txtCoilno_B.Text = this.grid1.ActiveRow.Cells["CUSTLOTNO"].Text.ToString();
            this.txtLotNo_B.Text = this.grid1.ActiveRow.Cells["MATLOTNO"].Text.ToString();
            this.txtCustCode_B.Text = "[" + this.grid1.ActiveRow.Cells["CUSTCODE"].Text.ToString() + "] " + this.grid1.ActiveRow.Cells["CUSTNAME"].Text.ToString();
            this.txtItemCode_B.Text = this.grid1.ActiveRow.Cells["ITEMCODE"].Text.ToString();
            this.txtBaseQty_B.Text = this.grid1.ActiveRow.Cells["LOTBASEQTY"].Text.ToString();
            this.txtPreInDate_B.Text = this.grid1.ActiveRow.Cells["PREINDATE"].Text.ToString();
            this.txtInspDate_B.Text = this.grid1.ActiveRow.Cells["INSPDATE"].Text.ToString();
            this.txtOkNg_B.Text = this.grid1.ActiveRow.Cells["INSPRESULT"].Text.ToString();


            if (this.grid1.ActiveRow.Cells["WHCODE"].Text.ToString() != "")
                this.cboWhCode_B.Value = this.grid1.ActiveRow.Cells["WHCODE"].Text.ToString();
            if (this.grid1.ActiveRow.Cells["STORAGRLOCCODE"].Text.ToString() != "")
                this.cboStoragrLocCode_B.Value = this.grid1.ActiveRow.Cells["STORAGRLOCCODE"].Text.ToString();
            if (this.grid1.ActiveRow.Cells["SPECIALINDATE"].Text.ToString() != "")
                this.carSpInDate_B.Value = this.grid1.ActiveRow.Cells["SPECIALINDATE"].Text.ToString();

            this.txtWorkerId_B.Text = this.grid1.ActiveRow.Cells["SPECIALINPERSON"].Text.ToString();
            this.txtWorkerName_B.Text = this.grid1.ActiveRow.Cells["SPECIALINPERSONNAME"].Text.ToString();
            this.txtRemark_B.Text = this.grid1.ActiveRow.Cells["SPECIALINREASON"].Text.ToString();

            _GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPLANTCODE = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
                string sITEMCODE = grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
                string sMATLOTNO = grid1.ActiveRow.Cells["MATLOTNO"].Value.ToString();

                rtnDtTemp = helper.FillTable("USP_MM0210_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("MATLOTNO", sMATLOTNO, DbType.String, ParameterDirection.Input)
                                                            );

                this.ClosePrgFormNew();


                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds(rtnDtTemp);

                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);
                }

                DtChange = rtnDtTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
            if (this.grid1.ActiveRow.Cells["LOTSTATUS"].Value.ToString() == "20" || this.grid1.ActiveRow.Cells["SPECIALINBEFORESTATUS"].Value.ToString() == "20")
            {
                this.grid2.Enabled = false;
            }
            else this.grid2.Enabled = true;
        }

        private void GetLotStatus()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT MINORCODE                           AS CODE_ID, ");
                command.AppendLine("       '['+ MINORCODE +']' + CODENAME        AS CODE_NAME");
                command.AppendLine("  FROM TBM0000                                           ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND MAJORCODE = 'LOTSTATUS' ");
                command.AppendLine("   AND MINORCODE IN ('10','20','00') ");
                command.AppendLine("   AND MINORCODE <> '$'   ");
                command.AppendLine(" UNION ALL");
                command.AppendLine(" SELECT 'SP'  AS CODE_ID,");
                command.AppendLine(" '[SP]' + '특채입고완료'        AS CODE_NAME  ");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(this.cboLotStatus_H, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }

        private void GetWHCODE()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                StringBuilder command = new StringBuilder();

                //command.AppendLine("SELECT MINORCODE                           AS CODE_ID, ";
                //command.AppendLine("       '['+ MINORCODE +']' + CODENAME        AS CODE_NAME";
                //command.AppendLine("  FROM TBM0000                                           ";
                //command.AppendLine(" WHERE USEFLAG = 'Y'                                     ";
                //command.AppendLine("   AND MAJORCODE = 'WHCODE' ";
                //command.AppendLine("   AND RELCODE2  = 'MM' ";
                //command.AppendLine("   AND MINORCODE <> '$'   ";
                //command.AppendLine(" ORDER BY MINORCODE";

                command.AppendLine("SELECT MINORCODE                             AS CODE_ID, ");
                command.AppendLine("       CODENAME                              AS CODE_NAME");
                command.AppendLine("  FROM TBM0000                                           ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND MAJORCODE = 'WHCODE'                              ");
                command.AppendLine("   AND MINORCODE IN ('WH001','WH002')                    ");
                command.AppendLine(" ORDER BY MINORCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(this.cboWhCode_B, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, "");
                this.cboWhCode_B.Value = "WH001";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }

        private void GetOkNg()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT MINORCODE                           AS CODE_ID, ");
                command.AppendLine("       '['+ MINORCODE +']' + CODENAME        AS CODE_NAME");
                command.AppendLine("  FROM TBM0000                                           ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND MAJORCODE = 'OKNG' ");
                command.AppendLine("   AND RELCODE1  = 'M' ");
                command.AppendLine("   AND MINORCODE <> '$'   ");
                command.AppendLine(" ORDER BY MINORCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "INSPRESULT", dttemp, "CODE_ID", "CODE_NAME");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }
        private void cboWhCode_B_ValueChanged(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT MINORCODE                           AS CODE_ID, ");
                command.AppendLine("       '['+ MINORCODE +']' + CODENAME        AS CODE_NAME");
                command.AppendLine("  FROM TBM0000                                           ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND MAJORCODE = 'STORAGELOCCODE' ");
                command.AppendLine("   AND MINORCODE <> '$'   ");
                command.AppendLine("   AND MINORCODE like  '" + this.cboWhCode_B.Value + "%'");
                command.AppendLine(" ORDER BY MINORCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(this.cboStoragrLocCode_B, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }

        private void cboLotStatus_H_ValueChanged(object sender, EventArgs e)
        {
            if (this.cboLotStatus_H.Value.ToString() == "SP")
            {
                this.cboWhCode_B.ReadOnly = true;
                this.cboStoragrLocCode_B.ReadOnly = true;
                this.txtWorkerId_B.ReadOnly = true;
                this.txtWorkerName_B.ReadOnly = true;
                this.carSpInDate_B.ReadOnly = true;
                this.txtRemark_B.ReadOnly = true;

                this.cboWhCode_B.Enabled = false;
                this.cboStoragrLocCode_B.Enabled = false;
                this.txtWorkerId_B.Enabled = false;
                this.txtWorkerName_B.Enabled = false;
                this.carSpInDate_B.Enabled = false;
                this.txtRemark_B.Enabled = false;


                this.cboWhCode_B.Value = "WH001";
                this.txtWorkerId_B.Text = "";
                this.txtWorkerName_B.Text = "";
                this.carSpInDate_B.Value = DateTime.Now;
                this.txtRemark_B.Text = "";
            }
            else
            {
                this.cboWhCode_B.ReadOnly = false;
                this.cboStoragrLocCode_B.ReadOnly = false;
                this.txtWorkerId_B.ReadOnly = false;
                this.txtWorkerName_B.ReadOnly = false;
                this.carSpInDate_B.ReadOnly = false;
                this.txtRemark_B.ReadOnly = false;

                this.cboWhCode_B.Enabled = true;
                this.cboStoragrLocCode_B.Enabled = true;
                this.txtWorkerId_B.Enabled = true;
                this.txtWorkerName_B.Enabled = true;
                this.carSpInDate_B.Enabled = true;
                this.txtRemark_B.Enabled = true;
            }
        }
        private void CheckLotStatus()
        {
            if (Convert.ToString(this.grid1.ActiveRow.Cells["LOTSTATUS"].Value) == "10" || Convert.ToString(this.grid1.ActiveRow.Cells["LOTSTATUS"].Value) == "20" || Convert.ToString(this.grid1.ActiveRow.Cells["LOTSTATUS"].Value) == "00")
            {

                this.cboWhCode_B.ReadOnly = false;
                this.cboStoragrLocCode_B.ReadOnly = false;
                this.txtWorkerId_B.ReadOnly = false;
                this.txtWorkerName_B.ReadOnly = false;
                this.carSpInDate_B.ReadOnly = false;
                this.txtRemark_B.ReadOnly = false;

                this.cboWhCode_B.Enabled = true;
                this.cboStoragrLocCode_B.Enabled = true;
                this.txtWorkerId_B.Enabled = true;
                this.txtWorkerName_B.Enabled = true;
                this.carSpInDate_B.Enabled = true;
                this.txtRemark_B.Enabled = true;
                this.carSpInDate_B.Value = DateTime.Now;
            }
            else
            {
                this.cboWhCode_B.ReadOnly = true;
                this.cboStoragrLocCode_B.ReadOnly = true;
                this.txtWorkerId_B.ReadOnly = true;
                this.txtWorkerName_B.ReadOnly = true;
                this.carSpInDate_B.ReadOnly = true;
                this.txtRemark_B.ReadOnly = true;

                this.cboWhCode_B.Enabled = false;
                this.cboStoragrLocCode_B.Enabled = false;
                this.txtWorkerId_B.Enabled = false;
                this.txtWorkerName_B.Enabled = false;
                this.carSpInDate_B.Enabled = false;
                this.txtRemark_B.Enabled = false;

                this.cboWhCode_B.Value = "WH001";
                this.txtWorkerId_B.Text = "";
                this.txtWorkerName_B.Text = "";
                this.carSpInDate_B.Value = DateTime.Now;
                this.txtRemark_B.Text = "";
            }
        }

        private void grid2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.grid2.Rows.Count == 0) return;
            if (((WIZ.Control.Grid)(sender)).ActiveCell == null) return;
            //숫자 그리드 헤더 컬럼명 찾기
            this.grid2.UpdateData();
            // 선택한 행이 판정만 받을경우 측정값 입력을 방지.
            if (this.grid2.ActiveRow.Cells["VALUETYPE"].Value.ToString() == "J")
            {
                this.grid2.ActiveRow.Cells["INSPRESULTVAL"].Value = "";
                this.grid2.ActiveRow.Cells["INSPRESULT"].Activated = true;
                e.Handled = true;
                return;
            }
            // 소수점을 2개이상 입력시 방지 
            if (e.KeyChar == Convert.ToChar("."))
            {
                // 값이 없을경우 소수점을 바로 입력하였을때 0. 으로 소수점아래단위부터 표시
                if (this.grid2.ActiveRow.Cells["INSPRESULTVAL"].Value.ToString() == "")
                {
                    e.Handled = true;
                    this.grid2.ActiveRow.Cells["INSPRESULTVAL"].Value = "0.";
                    this.grid2.ActiveRow.Cells["INSPRESULTVAL"].SelStart = 2;
                    return;
                }
                string InspValue = this.grid2.ActiveRow.Cells["INSPRESULTVAL"].Value.ToString();
                string[] a = InspValue.Split('.');
                if (a.Length > 1)
                {
                    KeyChecked = false;
                    e.Handled = true;
                }
                else KeyChecked = true;
            }
            // 입력을 시도하는 셀의 입력 내용이 숫자 또는 . 또는 엔터 외일때 방지.
            if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "INSPRESULTVAL")
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
                {

                    // 숫자입력 메시지창 표현.
                    this.ShowDialog(Common.getLangText("숫자만 입력가능합니다.", "MSG"), DialogForm.DialogType.OK);
                    KeyChecked = false;
                    e.Handled = true;
                }
                else KeyChecked = true;
            }


            //}
        }

        private void grid2_KeyUp(object sender, KeyEventArgs e)
        {
            CheckInspValue();
        }

        private void grid2_KeyPressed(Control.Grid sender, KeyPressEventArgs e)
        {
            CheckInspValue();

        }
        // 값에따른 자동 판정 .
        private void CheckInspValue()
        {
            if (!KeyChecked) return;

            this.grid2.UpdateData();
            if (this.grid2.ActiveRow.Cells["INSPRESULTVAL"].Value.ToString() == ""
                || this.grid2.ActiveRow.Cells["INSPRESULTVAL"].Value.ToString() == "0."
                || this.grid2.ActiveRow.Cells["INSPRESULTVAL"].Value.ToString() == ".") return;
            if (this.grid2.ActiveRow.Cells["SPECTYPE"].Value.ToString() == "B") // 양쪽관리
            {
                // 상한값 USLVALUE 
                // 하한값 LSLVALUE
                if (Convert.ToDouble(this.grid2.ActiveRow.Cells["INSPRESULTVAL"].Value) <= Convert.ToDouble(this.grid2.ActiveRow.Cells["USLVALUE"].Value) &&
                    Convert.ToDouble(this.grid2.ActiveRow.Cells["INSPRESULTVAL"].Value) >= Convert.ToDouble(this.grid2.ActiveRow.Cells["LSLVALUE"].Value))
                {
                    this.grid2.ActiveRow.Cells["INSPRESULT"].Value = "1";
                }
                else this.grid2.ActiveRow.Cells["INSPRESULT"].Value = "2";
            }
            if (this.grid2.ActiveRow.Cells["SPECTYPE"].Value.ToString() == "L") // 하한관리 (하한보다 아랫값이 OK)
            {
                if (Convert.ToDouble(this.grid2.ActiveRow.Cells["INSPRESULTVAL"].Value) <= Convert.ToDouble(this.grid2.ActiveRow.Cells["LSLVALUE"].Value))
                {
                    this.grid2.ActiveRow.Cells["INSPRESULT"].Value = "1";
                }
                else this.grid2.ActiveRow.Cells["INSPRESULT"].Value = "2";
            }
            if (this.grid2.ActiveRow.Cells["SPECTYPE"].Value.ToString() == "U") // 상한관히 (상한보다 윗값이 OK)
            {
                if (Convert.ToDouble(this.grid2.ActiveRow.Cells["INSPRESULTVAL"].Value) >= Convert.ToDouble(this.grid2.ActiveRow.Cells["USLVALUE"].Value))
                {
                    this.grid2.ActiveRow.Cells["INSPRESULT"].Value = "1";
                }
                else this.grid2.ActiveRow.Cells["INSPRESULT"].Value = "2";
            }
            if (this.grid2.ActiveRow.Cells["VALUETYPE"].Value.ToString() == "J") // 선택한 행이 판정만 받을경우
            {
                this.grid2.ActiveRow.Cells["INSPRESULTVAL"].Value = "";
                this.grid2.ActiveRow.Cells["INSPRESULT"].Activated = true;
            }
        }
        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            // 선택한 행이 판정만 받을경우측정값 입력 시도 시 방지
            if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "INSPRESULTVAL")
            {
                if (this.grid2.ActiveRow.Cells["VALUETYPE"].Value.ToString() == "J")
                {
                    this.grid2.ActiveRow.Cells["INSPRESULT"].Activated = true;
                }
            }
        }

        private void grid2_ClickCell(object sender, EventArgs e)
        {
            try
            {
                // 선택한 행이 판정만 받을경우측정값 입력 시도 시 방지
                if (this.grid2.ActiveRow.Cells["VALUETYPE"].Value.ToString() == "J" && this.grid2.Enabled == true)
                {
                    this.grid2.ActiveRow.Cells["INSPRESULT"].Activated = true;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, DialogForm.DialogType.OK);
            }

        }
    }
}


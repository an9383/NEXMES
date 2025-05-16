#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  MM0270
//   Form Name    : 수입검사 대기  정보 조회
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.MM
{
    public partial class MM0270 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable[] DtGrid3;
        DataTable DtChange = null;
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        #endregion

        #region < CONSTRUCTOR >

        public MM0270()
        {
            InitializeComponent();

            this.plantCode = CModule.GetAppSetting("Site", "10");

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtCustCode_H, txtCustName_H, "TBM0300", new object[] { cboPlantCode_H, "" });

        }
        #endregion

        #region  MM0270_Load
        private void MM0270_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();

            #region TAB1 - 가입고 등록

            //거래명세서 공통
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRSNSTPRTDATE", "발행일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRSNSTNO", "거래명세서번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CNTITEM", "총 품목수", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SUMQTY", "총수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRSNSTSTATUS", "진행상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            //거래명세서 명세
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "TRSNSTPRTDATE", "라벨발행일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "TRSNSTNO", "거래명세서번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "TRSNSTNOSEQ", "거래명세서순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTQTY", "수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTCNT", "LOT편성수(EA)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);

            //lot현황
            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "OUTDATE", "라벨발행일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "TRANO", "거래명세서번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "TRANOSEQ", "거래명세서순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTQTY", "수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKEDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid3);

            #endregion

            #region TAB2 - 가입고 취소
            //거래명세서 공통
            _GridUtil.InitializeGrid(this.grid4, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid4, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "CUSTINDATE", "가입고일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "TRSNSTNO", "거래명세서번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "CNTITEM", "총 품목수", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "SUMQTY", "총수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "TRSNSTPRTDATE", "발행일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "MAKEDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid4);

            //거래명세서 명세
            _GridUtil.InitializeGrid(this.grid5, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid5, "CUSTINDATE", "가입고일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "TRSNSTNO", "거래명세서번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "TRSNSTNOSEQ", "거래명세서순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "CUSTQTY", "수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "LOTCNT", "LOT편성수(EA)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "CNTINSPLOT", "수입검사 LoT수", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "MAKEDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid5, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid5);

            //lot현황
            _GridUtil.InitializeGrid(this.grid6, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid6, "PREINDATE", "가입고일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "TRSNSTNO", "거래명세서번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "TRSNSTNOSEQ", "거래명세서순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "LOTQTY", "수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "INSPDATE", "수입검사일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "INSPRESULT", "수입검사 여부", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "MAKEDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid6, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid6);
            #endregion
            #endregion


            #region 콤보박스
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0130_CODE_1("C", "Y");  // 단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TRNSTSTATUS");  //거래명세서 진행상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TRNSTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            cboPlantCode_H.Value = plantCode;
        }
        #endregion  MM0270_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DoFind();
        }

        private void DoFind()
        {
            if (!CheckData())
            {
                return;
            }

            DBHelper helper = new DBHelper(false);

            try
            {
                //  base.DoInquire();

                string PLANTCODE = Convert.ToString(cboPlantCode_H.Value);                              // 공장코드     
                string STARTDATE = string.Format("{0:yyyy-MM-dd}", cboStartDate_H.Value);               // 시작일자
                string ENDDATE = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);
                string ITEMCODE = this.txtItemCode_H.Text;                                              // 품목
                string CUSTCODE = this.txtCustCode_H.Text;                                             // 거래처
                string TRSNSTNO = this.txtTraNo_H.Text;                                               //거래명세서번호
                string CHKTRSNST = Convert.ToString(this.chkTrano_H.Checked);    // 거래명세서번호 조회
                string LS_TABIDX = string.Empty;
                if (tabControl1.SelectedTab.Index == 0) { LS_TABIDX = "TAB1"; } else { LS_TABIDX = "TAB2"; }

                rtnDtTemp = helper.FillTable("USP_MM0270_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("TAB", LS_TABIDX, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("CHK", CHKTRSNST, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("STARTDATE", STARTDATE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ENDDATE", ENDDATE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("CUSTCODE", CUSTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TRSNSTNO", TRSNSTNO, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (LS_TABIDX == "TAB1")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);

                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid1);
                        _GridUtil.Grid_Clear(grid2);
                        _GridUtil.Grid_Clear(grid3);
                        // 조회할 데이터가 없습니다.

                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
                else
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid4.DataSource = rtnDtTemp;
                        grid4.DataBinds(rtnDtTemp);
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid4);
                        _GridUtil.Grid_Clear(grid5);
                        _GridUtil.Grid_Clear(grid6);
                        // 조회할 데이터가 없습니다.

                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
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

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Index == 0)
            {
                if (this.grid1.Rows.Count == 0) return;

            }
            else
            {
                if (this.grid4.Rows.Count == 0) return;
            }
            DBHelper helper = new DBHelper(false);

            try
            {
                string CUSTCODE = string.Empty;
                string TRSNSTNO = string.Empty;
                string ITEMCODE = this.txtItemCode_H.Text;                                 // 품목
                string LS_TABIDX = string.Empty;
                if (tabControl1.SelectedTab.Index == 0)
                {

                    LS_TABIDX = "TAB1";

                    CUSTCODE = grid1.ActiveRow.Cells["CUSTCODE"].Value.ToString();      //거래처
                    TRSNSTNO = grid1.ActiveRow.Cells["TRSNSTNO"].Value.ToString();      //거래명세서번호


                }
                else
                {
                    LS_TABIDX = "TAB2";
                    CUSTCODE = grid4.ActiveRow.Cells["CUSTCODE"].Value.ToString();      //거래처
                    TRSNSTNO = grid4.ActiveRow.Cells["TRSNSTNO"].Value.ToString();      //거래명세서번호
                }
                rtnDtTemp = helper.FillTable("USP_MM0270_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("TAB", LS_TABIDX, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("CUSTCODE", CUSTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TRSNSTNO", TRSNSTNO, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (LS_TABIDX == "TAB1")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBinds(rtnDtTemp);

                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid2);
                        _GridUtil.Grid_Clear(grid3);
                        // 조회할 데이터가 없습니다.

                        // this.ShowDialog("R00111", WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
                else
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid5.DataSource = rtnDtTemp;
                        grid5.DataBinds(rtnDtTemp);
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid5);
                        _GridUtil.Grid_Clear(grid6);
                        // 조회할 데이터가 없습니다.

                        //this.ShowDialog("R00111", WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
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

        private void grid2_ClickCell(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Index == 0)
            {
                if (this.grid2.Rows.Count == 0) return;

            }
            else
            {
                if (this.grid5.Rows.Count == 0) return;
            }
            DBHelper helper = new DBHelper(false);

            try
            {
                string CUSTCODE = string.Empty;   //거래처
                string TRSNSTNO = string.Empty;      //거래명세서번호
                string TRSNSTNOSEQ = string.Empty;     //거래명세서번호순번
                string ITEMCODE = string.Empty;         // 품목

                string LS_TABIDX = string.Empty;
                if (tabControl1.SelectedTab.Index == 0)
                {
                    LS_TABIDX = "TAB1";

                    CUSTCODE = grid2.ActiveRow.Cells["CUSTCODE"].Value.ToString();      //거래처
                    TRSNSTNO = grid2.ActiveRow.Cells["TRSNSTNO"].Value.ToString();      //거래명세서번호
                    TRSNSTNOSEQ = grid2.ActiveRow.Cells["TRSNSTNOSEQ"].Value.ToString();      //거래명세서번호순번
                    ITEMCODE = grid2.ActiveRow.Cells["ITEMCODE"].Value.ToString();         // 품목

                }
                else
                {
                    LS_TABIDX = "TAB2";

                    CUSTCODE = grid5.ActiveRow.Cells["CUSTCODE"].Value.ToString();      //거래처
                    TRSNSTNO = grid5.ActiveRow.Cells["TRSNSTNO"].Value.ToString();      //거래명세서번호
                    TRSNSTNOSEQ = grid5.ActiveRow.Cells["TRSNSTNOSEQ"].Value.ToString();      //거래명세서번호순번
                    ITEMCODE = grid5.ActiveRow.Cells["ITEMCODE"].Value.ToString();         // 품목
                }
                rtnDtTemp = helper.FillTable("USP_MM0270_S3", CommandType.StoredProcedure
                                                            , helper.CreateParameter("TAB", LS_TABIDX, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("CUSTCODE", CUSTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TRSNSTNO", TRSNSTNO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TRSNSTNOSEQ", TRSNSTNOSEQ, DbType.String, ParameterDirection.Input)
                                                            );

                this.ClosePrgFormNew();

                if (LS_TABIDX == "TAB1")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid3.DataSource = rtnDtTemp;
                        grid3.DataBinds(rtnDtTemp);

                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid3);
                        // 조회할 데이터가 없습니다.

                        // this.ShowDialog("R00111", WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
                else
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid6.DataSource = rtnDtTemp;
                        grid6.DataBinds(rtnDtTemp);
                    }
                    else
                    {

                        _GridUtil.Grid_Clear(grid6);
                        // 조회할 데이터가 없습니다.

                        //this.ShowDialog("R00111", WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
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

        #endregion

        #region save
        public override void DoSave()
        {


            string LS_TABIDX = string.Empty;
            if (tabControl1.SelectedTab.Index == 0) { LS_TABIDX = "TAB1"; } else { LS_TABIDX = "TAB2"; }
            int gridrowcnt = 0;
            string err = string.Empty;
            int cnt = 0;

            if (LS_TABIDX == "TAB1")
                gridrowcnt = this.grid1.Rows.Count;
            else
                gridrowcnt = this.grid4.Rows.Count;


            for (int i = 0; i < gridrowcnt; i++)
            {
                if (LS_TABIDX == "TAB1")
                {
                    if (grid1.Rows[i].Cells["CHK"].Value.ToString() == "True")
                    {
                        string PLANTCODE = Convert.ToString(this.cboPlantCode_H.Value);
                        string CUSTCODE = grid1.Rows[i].Cells["CUSTCODE"].Value.ToString();
                        string TRSNSTNO = grid1.Rows[i].Cells["TRSNSTNO"].Value.ToString();

                        Dosave(LS_TABIDX, PLANTCODE, CUSTCODE, TRSNSTNO, ref err);
                        if (err == "e")
                        {
                            this.ShowDialog(i + Common.getLangText("번 행에서 오류가 발생했습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        else
                        {
                            cnt++;
                        }
                    }
                }
                else
                {
                    if (grid4.Rows[i].Cells["CHK"].Value.ToString() == "True")
                    {
                        string PLANTCODE = Convert.ToString(this.cboPlantCode_H.Value);
                        string CUSTCODE = grid4.Rows[i].Cells["CUSTCODE"].Value.ToString();
                        string TRSNSTNO = grid4.Rows[i].Cells["TRSNSTNO"].Value.ToString();

                        Dosave(LS_TABIDX, PLANTCODE, CUSTCODE, TRSNSTNO, ref err);

                        if (err == "e")
                        {
                            this.ShowDialog(i + Common.getLangText("번 행에서 오류가 발생했습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        else
                        {
                            cnt++;
                        }
                    }
                }
            }

            if (err != "e")
            {
                this.ShowDialog(cnt + Common.getLangText("건이 처리되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                DoInquire();
            }

        }

        private void Dosave(string TAB, string PLANTCODE, string CUSTCODE, string TRSNSTNO, ref string err)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                helper.ExecuteNoneQuery("USP_MM0270_U1", CommandType.StoredProcedure//,ref RS_CODE, ref RS_MSG
                                                       , helper.CreateParameter("PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("CUSTCODE", CUSTCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("TRSNSTNO", TRSNSTNO, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("WORKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("TAB", TAB, DbType.String, ParameterDirection.Input));
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    err = "s";
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    err = "e";
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
                err = "e";
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region function
        // DATE CHECK
        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }
        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cboStartDate_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cboEndDate_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("조회 시작일자가 종료일자보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }

        // CONTROL CHECKBOX
        private void grid1_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            if (e.Cell.Column.ToString() != "CHK")
                return;

            this.grid1.ActiveRow.Cells["CHK"].Value = Convert.ToString(e.Cell.Value).ToUpper() == "TRUE" ? "False" : "True";
        }

        private void grid4_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            if (e.Cell.Column.ToString() != "CHK")
                return;

            this.grid4.ActiveRow.Cells["CHK"].Value = Convert.ToString(e.Cell.Value).ToUpper() == "TRUE" ? "False" : "True";
        }

        private void tabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (tabControl1.SelectedTab.Index == 0)
            {
                sLabel5.Visible = false;
            }
            else
            {
                sLabel5.Visible = true;
            }
        }
        #endregion
    }
}

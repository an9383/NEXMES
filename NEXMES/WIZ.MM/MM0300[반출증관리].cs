#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0300
//   Form Name    : 외주임가공 반출증 관리(자재)
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM0300 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable table = new DataTable();
        DataTable dtTemp = new DataTable();
        DataTable DtChange = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable dt;
        DataTable dt1;

        DataTable[] DtGrid3;
        DataTable DtChange1 = null;

        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        private string sTraNo = string.Empty;
        //private string sPlantCode = LoginInfo.PlantCode;
        private int rowindex;

        bool chk = false;

        //TEST
        //DA9999_R DA9999_Report_N;
        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();
        #endregion

        #region <CONSTRUCTOR>

        public MM0300()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode, "ROH" });
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { "C", "Y", "" });
            btbManager.PopUpAdd(txtCustCode_H, txtCustName_H, "TBM0300", new object[] { "C", "Y", "" });
            // grid 입력용 POPUP
            BizGridManager bizGridManager;
            bizGridManager = new BizGridManager(grid3);
            bizGridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "ROH" });

            this.plantCode = CModule.GetAppSetting("Site", "10");

        }
        #endregion

        #region  <MM0300_Load>
        private void MM0300_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성

            #region Grid 셋팅 //100 130 100 196 165 100 87 123 123 100 201 100 100 191 228 100 100
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotNo", "LOTNO", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StockQty", "수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHName", "창고명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "위치코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "저장위치명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTLOTNO", "자재번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처코드", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FIRSTINDATE", "최초입고일자", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotStatus", "LOT상태", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "POSEQNO", "발주순번", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.InitializeGrid(this.grid2, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STOCKQTY", "수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WHCODE", "창고코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WHNAME", "창고명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STORAGELOCCODE", "위치코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STORAGELOCNAME", "저장위치명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTLOTNO", "자재번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTCODE", "거래처코드", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FIRSTINDATE", "최초입고일자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTSTATUS", "LOT상태", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PONO", "발주번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "POSEQNO", "발주순번", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitializeGrid(this.grid4, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid4, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "TRANO", "반출증번호", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "TRATYPE", "반출증유형", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "CUSTCODE", "거래처코드", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "CUSTNAME", "거래처", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "TRADATE", "반출증등록일", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "TRAPLNDATE", "반출예정일자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "TRASTATUS", "상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "CARCARRYDATE", "상차일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "CARCARRYPERSON", "상차담당자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "OUTDATE", "출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "OUTPERSON", "출고담당자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "MAKEDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid4);
            DtChange1 = (DataTable)grid4.DataSource;

            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "TRANO", "반출증번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MATLOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTSTATUS", "상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTQTY", "수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKEDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid3);

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cboPlantCode.Value = plantCode;
            string sPlantCode = Convert.ToString(this.cboPlantCode.Value);

            rtnDtTemp = _Common.GET_BM0000_CODE("LOTSTATUS");  //LOT상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TRATYPE");  //반출구분
            WIZ.Common.FillComboboxMaster(this.cboTraType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            cboTraType.Value = "M"; // 원자재로 고정

            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "TRATYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE");  //품목구분
            WIZ.Common.FillComboboxMaster(this.cboItemType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            //rtnDtTemp = _Common.GET_TBM0800_CODE(sPlantCode);  //창고
            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE");  //창고
            WIZ.Common.FillComboboxMaster(this.cboWhCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TRASTATUS");  //LOT상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "TRASTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            table.Columns.Add(new DataColumn("PLANTCODE", typeof(string)));
            table.Columns.Add(new DataColumn("WHCODE", typeof(string)));
            table.Columns.Add(new DataColumn("WHNAME", typeof(string)));
            table.Columns.Add(new DataColumn("STORAGELOCCODE", typeof(string)));
            table.Columns.Add(new DataColumn("STORAGELOCNAME", typeof(string)));
            table.Columns.Add(new DataColumn("FIRSTINDATE", typeof(string)));
            table.Columns.Add(new DataColumn("CUSTLOTNO", typeof(string)));
            table.Columns.Add(new DataColumn("CUSTCODE", typeof(string)));
            table.Columns.Add(new DataColumn("CUSTNAME", typeof(string)));
            table.Columns.Add(new DataColumn("LOTNO", typeof(string)));
            table.Columns.Add(new DataColumn("ITEMCODE", typeof(string)));
            table.Columns.Add(new DataColumn("ITEMNAME", typeof(string)));

            table.Columns.Add(new DataColumn("UNITCODE", typeof(string)));
            table.Columns.Add(new DataColumn("STOCKQTY", typeof(string)));
            table.Columns.Add(new DataColumn("LOTSTATUS", typeof(string)));
            table.Columns.Add(new DataColumn("PONO", typeof(string)));
            table.Columns.Add(new DataColumn("POSEQNO", typeof(string)));

        }
        #endregion  MM0300_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            chk = true;

            DBHelper helper = new DBHelper(false);
            try
            {
                //base.DoInquire();

                if (tabControl1.SelectedTab.Index == 0)
                {
                    this._GridUtil.Grid_Clear(grid1);
                    this._GridUtil.Grid_Clear(grid2);
                    string sPlantCode = Convert.ToString(cboPlantCode.Value);                   // 공장코드
                    string sWHCode = Convert.ToString(cboWhCode.Value);                         // 창고코드
                    string sItemType = Convert.ToString(cboItemType.Value);                     // 품목구분 
                    string sItemCode = this.txtItemCode.Text;                                   // 품목
                    string sCoilNo = this.txtCoilNo.Text;                                       // 자재번호(코일번호에서 자재번호로 수정)
                    string sLotNo = this.txtLotNo.Text;                                         // LOTNO

                    dtTemp = helper.FillTable("USP_MM0300_S1", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                // 사업장 공장코드    
                                                             , helper.CreateParameter("WHCode", sWHCode, DbType.String, ParameterDirection.Input)                      // 사업장 공장코드    
                                                             , helper.CreateParameter("ItemType", sItemType, DbType.String, ParameterDirection.Input)                  // 품목구분
                                                             , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)                  // 품목               
                                                             , helper.CreateParameter("CoilNo", sCoilNo, DbType.String, ParameterDirection.Input)                      // 자재번호(코일번호에서 자재번호로 수정)              
                                                             , helper.CreateParameter("LotNo", sLotNo, DbType.String, ParameterDirection.Input));                      // LOTNO               



                    this.grid1.DataSource = dtTemp;
                    grid1.DataBinds(dtTemp);
                }
                else
                {
                    if (!CheckData())
                    {
                        return;
                    }

                    this._GridUtil.Grid_Clear(grid3);
                    this._GridUtil.Grid_Clear(grid4);


                    string sPlantCode = Convert.ToString(cboPlantCode.Value);                   // 공장코드
                    string sStartdate = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);
                    string sEnddate = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);
                    string sCustCode = this.txtCustCode_H.Text.Trim();
                    string sTrano = this.txtTraNo_H.Text.Trim();
                    string sChktrano = Convert.ToString(chkTrano_H.Checked);

                    dtTemp = helper.FillTable("USP_MM0300_S2", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("STARTDATE", sStartdate, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ENDDATE", sEnddate, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("TRANO", sTrano, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("CHKTRANO", sChktrano, DbType.String, ParameterDirection.Input));



                    this.ClosePrgFormNew();
                    if (dtTemp.Rows.Count > 0)
                    {
                        grid4.DataSource = dtTemp;
                        grid4.DataBinds(dtTemp);
                        DtChange1 = dtTemp;
                        DtGrid3 = new DataTable[dtTemp.Rows.Count];
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid4);
                        _GridUtil.Grid_Clear(grid3);
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
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

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            if (tabControl1.SelectedTab.Index == 0)
                tab1_save();
            else
            {
                // 데이터 추가시
                DataTable dt = grid3.chkChange();
                DBHelper helper = new DBHelper(false);
                int addsv = 0;
                if (dt != null)
                {
                    try
                    {
                        foreach (DataRow drRow in dt.Rows)
                        {
                            if (drRow.RowState == DataRowState.Added)
                            {
                                helper.ExecuteNoneQuery("USP_MM0300_I1"
                                                              , CommandType.StoredProcedure//,ref RS_CODE, ref RS_MSG
                                                              , helper.CreateParameter("@PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("@TRANO", Convert.ToString(drRow["TRANO"]), DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("@LOTQTY", Convert.ToString(drRow["LOTQTY"]), DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("@ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("@MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "S")
                                {
                                    helper.Commit();
                                    addsv++;
                                }
                                else if (helper.RSCODE == "E")
                                {
                                    this.ClosePrgFormNew();
                                    helper.Rollback();
                                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                                }
                            }

                        }
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
                    if (addsv > 0)
                    {
                        this.ShowDialog(addsv + "건이 저장되었습니다.", Forms.DialogForm.DialogType.OK);
                        DoInquire();
                        return;
                    }
                }

                // 데이터 삭제시
                int SV = 0;
                string ERROR = "S";
                for (int i = 0; i < this.grid4.Rows.Count; i++)
                {//그리드4가 체크이고
                    if (this.grid4.Rows[i].Cells["CHK"].Value.ToString() == "True")
                    {
                        for (int j = 0; j < DtGrid3[i].Rows.Count; j++)
                        { //그리드 3이 체크이면
                            if (Convert.ToString(DtGrid3[i].Rows[j]["CHK"]) == "True")
                            {
                                if (this.grid4.Rows[i].Cells["TRASTATUS"].Value.ToString() != "10")
                                {
                                    this.ShowDialog(Common.getLangText("대기 상태가 아닌 반출증이 있습니다. 반출증 상태를 확인 후, 삭제해주세요.", "MSG"), DialogForm.DialogType.OK);
                                    return;
                                }
                                else
                                {
                                    string PLANTCODE = Convert.ToString(DtGrid3[i].Rows[j]["PLANTCODE"]);
                                    string TRATYPE = this.grid4.Rows[i].Cells["TRATYPE"].Value.ToString();
                                    string TRANO = Convert.ToString(DtGrid3[i].Rows[j]["TRANO"]);
                                    string MATLOTNO = Convert.ToString(DtGrid3[i].Rows[j]["MATLOTNO"]);
                                    string ITEMCODE = Convert.ToString(DtGrid3[i].Rows[j]["ITEMCODE"]);

                                    // 삭제 실행.
                                    delete_save(PLANTCODE, TRATYPE, TRANO, MATLOTNO, ITEMCODE, ref ERROR);
                                    SV++;
                                }
                            }
                        }
                    }
                }
                if (ERROR == "S" && SV > 0)
                {
                    this.ShowDialog(SV + "건이 삭제되었습니다.", Forms.DialogForm.DialogType.OK);
                    DoInquire();
                }
                else if (ERROR == "S" && SV == 0)
                {
                    this.ShowDialog(Common.getLangText("삭제할 데이터를 선택해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                }
                else if (ERROR != "S")
                {
                    this.ShowDialog(ERROR, WIZ.Forms.DialogForm.DialogType.OK);
                }
            }
        }
        public void tab1_save()
        {
            this.grid2.UpdateData();


            if (grid2.Rows.Count < 1)
            {
                this.ShowDialog(Common.getLangText("출력 대상 데이터가 없습니다", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            if (txtCustCode.Text == "")
            {
                this.ShowDialog(Common.getLangText("반출처를 선택해주세요", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            if (cboTraType.Text == "ALL")
            {
                this.ShowDialog(Common.getLangText("반출 구분을 선택해주세요", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            bool flgTranjation_Finished_Error = false;

            DtChange = (DataTable)grid2.DataSource;
            DBHelper helper = new DBHelper("", true);
            try
            {
                //반출증 헤더 생성
                helper.ExecuteNoneQuery("USP_MM0300X_I1N", CommandType.StoredProcedure
                                        , helper.CreateParameter("PLANTCODE", Convert.ToString(DtChange.Rows[0]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("CUSTCODE", txtCustCode.Text, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("TRAPLANDATE", cboOutDate.Text, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("TRANO", DbType.String, ParameterDirection.Output, '0', 30)
                                       );

                if (helper.RSCODE == "E")
                {
                    flgTranjation_Finished_Error = true;
                    this.ShowDialog(Common.getLangText("반출증 헤더 정보 생성 중 오류가 발생했습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                }

                //반출번호 가져오기
                sTraNo = helper.Parameters[4].Value.ToString();
                string sPlantCode = Convert.ToString(cboPlantCode.Value);                   // 공장코드


                //반출증 상세 생성
                for (int i = 0; i < this.DtChange.Rows.Count; i++)
                {

                    helper.ExecuteNoneQuery("USP_MM0300X_I2N", CommandType.StoredProcedure
                                            , helper.CreateParameter("PlantCode", cboPlantCode.Value.ToString(), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("TraNo", "1", DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("LotNo", Convert.ToString(DtChange.Rows[i]["LOTNO"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("ItemCode", Convert.ToString(DtChange.Rows[i]["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("Qty", Convert.ToDouble(DtChange.Rows[i]["STOCKQTY"]), DbType.Double, ParameterDirection.Input)
                                            , helper.CreateParameter("UnitCode", Convert.ToString(DtChange.Rows[i]["UNITCODE"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("CustCode", txtCustCode.Text, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                           );

                    if (helper.RSCODE == "E")
                    {
                        flgTranjation_Finished_Error = true;
                    }

                    //LOT상태 변경시
                    if (helper.RSCODE == "O")
                    {
                        helper.Rollback();
                        this.ShowDialog(Common.getLangText("LOT 상태가 변경되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        DoInquire();
                        return;
                    }

                    //선입선출 위반시
                    if (helper.RSCODE == "X")
                    {
                        if (MessageBox.Show(Common.getLangText("선입 자재가 존재합니다.\r\n그래도 진행 하시겠습니까?", "MSG"),
                                            "선입선출체크",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question) == DialogResult.No)
                        {
                            helper.Rollback();
                            DoInquire();
                            return;
                        }

                    }

                }

                if (flgTranjation_Finished_Error == true)
                {
                    this.ShowDialog(Common.getLangText("반출증 상세 정보 생성 중 오류가 발생했습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    helper.Rollback();
                    SetStatusMessage("");
                }
                else
                {
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("데이터가 저장되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);

                    //반출증번호수 표시
                    txtOutNo.Text = sTraNo;
                    txtOutCnt.Text = Convert.ToString(DtChange.Rows.Count);

                    //반출구분 가져오기
                    string sTraType = Convert.ToString(cboTraType.Text);

                    //반출증 생성과 동시에 출력
                    if (chkPrint.Checked == true)
                    {
                        //신규발행
                        Print_Certificating(sTraNo, sTraType);
                    }

                    DoInquire();
                }

            }
            catch (SException ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowErrorMessage(ex);
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

        public void delete_save(string PLANTCODE, string TRATYPE, string TRANO, string MATLOTNO, string ITEMCODE, ref string ERROR)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                this.Focus();

                string RS_CODE = string.Empty;
                string RS_MSG = string.Empty;

                helper.ExecuteNoneQuery("USP_MM0300_D1", CommandType.StoredProcedure
                                                       , helper.CreateParameter("PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("TRATYPE", TRATYPE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("TRANO", TRANO, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("MATLOTNO", MATLOTNO, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input));
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    ERROR = helper.RSMSG;
                }

            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
                ERROR = ex.ToString();
            }
            finally
            {
                helper.Close();
            }

        }
        #endregion

        /// <summary>
        /// 신규발행
        /// </summary>
        /// <param name="sTraNo"> Certificating Number </param>
        private void Print_Certificating(string sTraNo, string TraTypeName)
        {
            string sPlantCode = Convert.ToString(cboPlantCode.Value);

            POP_MM0300X POP_MM0300X = new POP_MM0300X(sPlantCode, sTraNo, TraTypeName, "N");
            POP_MM0300X.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.grid1.Rows.Count == 0) return;
            if (grid1.ActiveRow == null) return;

            int grid1index = this.grid1.ActiveRow.Index;

            bool newLineMake = false;
            for (int i = 0; i < this.grid2.Rows.Count; i++)
            {
                if (Convert.ToString(grid1.ActiveRow.Cells["LOTNO"].Value) == Convert.ToString(grid2.Rows[i].Cells["LOTNO"].Value))
                {
                    MessageBox.Show(Common.getLangText("동일한 LOT의 발주 정보가 생성되어 있습니다.", "MSG"));
                    newLineMake = true;
                    break;
                }
            }
            if (!newLineMake)
            {

                DataRow row = table.NewRow();
                row["PLANTCODE"] = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                row["WHCODE"] = Convert.ToString(grid1.ActiveRow.Cells["WHCODE"].Value);
                row["WHNAME"] = Convert.ToString(grid1.ActiveRow.Cells["WHNAME"].Value);
                row["STORAGELOCCODE"] = Convert.ToString(grid1.ActiveRow.Cells["STORAGELOCCODE"].Value);
                row["STORAGELOCNAME"] = Convert.ToString(grid1.ActiveRow.Cells["STORAGELOCNAME"].Value);
                row["FIRSTINDATE"] = Convert.ToString(grid1.ActiveRow.Cells["FIRSTINDATE"].Value);
                row["CUSTLOTNO"] = Convert.ToString(grid1.ActiveRow.Cells["CUSTLOTNO"].Value);
                row["CUSTCODE"] = Convert.ToString(grid1.ActiveRow.Cells["CUSTCODE"].Value);
                row["CUSTNAME"] = Convert.ToString(grid1.ActiveRow.Cells["CUSTNAME"].Value);
                row["LOTNO"] = Convert.ToString(grid1.ActiveRow.Cells["LOTNO"].Value);
                row["ITEMCODE"] = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                row["ITEMNAME"] = Convert.ToString(grid1.ActiveRow.Cells["ITEMNAME"].Value);

                row["UNITCODE"] = Convert.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);
                row["STOCKQTY"] = Convert.ToString(grid1.ActiveRow.Cells["STOCKQTY"].Value);
                row["LOTSTATUS"] = Convert.ToString(grid1.ActiveRow.Cells["LOTSTATUS"].Value);
                row["PONO"] = Convert.ToString(grid1.ActiveRow.Cells["PONO"].Value);
                row["POSEQNO"] = Convert.ToString(grid1.ActiveRow.Cells["POSEQNO"].Value);


                table.Rows.Add(row);

                grid2.DataSource = table;

                string sLotNo = this.grid1.ActiveRow.Cells["LOTNO"].Value.ToString();
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if (dtTemp.Rows[i].RowState == DataRowState.Deleted) continue;
                    if (dtTemp.Rows[i]["LOTNO"].ToString() == sLotNo)
                    {
                        dtTemp.Rows[i].Delete();
                        break;
                    }
                }

                this.grid1.DataSource = dtTemp;

                if (grid1index == this.grid1.Rows.Count)
                {
                    grid1.ActiveRow = this.grid1.GetRow(ChildRow.Last);
                }
                else if (grid1index == 0)
                {
                    grid1.ActiveRow = this.grid1.GetRow(ChildRow.First);
                }
                else
                {
                    this.grid1.Rows[grid1index].Activated = true;
                }

                grid2.ActiveRow = this.grid2.GetRow(ChildRow.First);
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.grid2.Rows.Count == 0) return;
            if (grid2.ActiveRow == null) return;

            int grid2index = this.grid2.ActiveRow.Index;
            string sPOSEQNO = "";
            DataRow row = dtTemp.NewRow();
            row["PLANTCODE"] = Convert.ToString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
            row["WHCODE"] = Convert.ToString(grid2.ActiveRow.Cells["WHCODE"].Value);
            row["WHNAME"] = Convert.ToString(grid2.ActiveRow.Cells["WHNAME"].Value);
            row["STORAGELOCCODE"] = Convert.ToString(grid2.ActiveRow.Cells["STORAGELOCCODE"].Value);
            row["STORAGELOCNAME"] = Convert.ToString(grid2.ActiveRow.Cells["STORAGELOCNAME"].Value);
            row["FIRSTINDATE"] = Convert.ToString(grid2.ActiveRow.Cells["FIRSTINDATE"].Value);
            row["CUSTLOTNO"] = Convert.ToString(grid2.ActiveRow.Cells["CUSTLOTNO"].Value);
            row["CUSTCODE"] = Convert.ToString(grid2.ActiveRow.Cells["CUSTCODE"].Value);
            row["CUSTNAME"] = Convert.ToString(grid2.ActiveRow.Cells["CUSTNAME"].Value);
            row["LOTNO"] = Convert.ToString(grid2.ActiveRow.Cells["LOTNO"].Value);
            row["ITEMCODE"] = Convert.ToString(grid2.ActiveRow.Cells["ITEMCODE"].Value);
            row["ITEMNAME"] = Convert.ToString(grid2.ActiveRow.Cells["ITEMNAME"].Value);
            row["UNITCODE"] = Convert.ToString(grid2.ActiveRow.Cells["UNITCODE"].Value);
            row["STOCKQTY"] = Convert.ToString(grid2.ActiveRow.Cells["STOCKQTY"].Value);
            row["LOTSTATUS"] = Convert.ToString(grid2.ActiveRow.Cells["LOTSTATUS"].Value);
            row["PONO"] = Convert.ToString(grid2.ActiveRow.Cells["PONO"].Value);
            if (Convert.ToString(grid2.ActiveRow.Cells["POSEQNO"].Value) == "")
            {
                sPOSEQNO = "0";
            }
            else sPOSEQNO = Convert.ToString(grid2.ActiveRow.Cells["POSEQNO"].Value);
            row["POSEQNO"] = sPOSEQNO;

            dtTemp.Rows.Add(row);

            grid1.DataSource = dtTemp;
            grid1.DataBinds();


            string sLotNo = this.grid2.ActiveRow.Cells["LOTNO"].Value.ToString();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i].RowState == DataRowState.Deleted) continue;
                if (table.Rows[i]["LOTNO"].ToString() == sLotNo)
                {
                    table.Rows[i].Delete();
                    break;
                }
            }

            this.grid2.DataSource = table;

            if (grid2index == this.grid2.Rows.Count)
            {
                grid2.ActiveRow = this.grid2.GetRow(ChildRow.Last);
            }
            else if (grid2index == 0)
            {
                grid2.ActiveRow = this.grid2.GetRow(ChildRow.First);
            }
            else
            {
                this.grid2.Rows[grid2index].Activated = true;
            }

        }

        #region <METHOD AREA>

        /* private void grid4_Click(object sender, EventArgs e)
         {
             if (grid3.Rows.Count != 0)
                 if (grid4.ActiveRow.Cells["CHK"].Value.ToString() == "True")
                     grid3.DisplayLayout.Bands[0].Columns[0].SetHeaderCheckedState(grid3.Rows, true);

                 else
                     grid3.DisplayLayout.Bands[0].Columns[0].SetHeaderCheckedState(grid3.Rows, false);

             for (int i = 0; i < this.grid3.Rows.Count; i++)
             {
                 if (grid3.Rows[i].Cells["CHK"].Value.ToString() == "true")
                     if (this.ShowDialog("선택된 LOT가 존재합니다.\n 이동하시겠습니까?") != System.Windows.Forms.DialogResult.Cancel)
                     {
                         return;
                     }
             }
         }*/

        private void grid4_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            if (e.Cell.Column.ToString() != "CHK")
                return;

            this.grid4.ActiveRow.Cells["CHK"].Value = Convert.ToString(e.Cell.Value).ToUpper() == "TRUE" ? "False" : "True";
        }

        private void grid3_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            if (e.Cell.Column.ToString() != "CHK")
                return;

            this.grid3.ActiveRow.Cells["CHK"].Value = Convert.ToString(e.Cell.Value).ToUpper() == "TRUE" ? "False" : "True";
        }


        #endregion

        private void tabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (tabControl1.SelectedTab.Index == 0)
            {

                btnPrint.Visible = false;

                lblWhCode.Visible = true;
                cboWhCode.Visible = true;
                lblItemType_H.Visible = true;
                cboItemType.Visible = true;
                lblItemName.Visible = true;
                txtItemCode.Visible = true;
                txtItemName.Visible = true;
                lblCoilNo.Visible = true;
                txtCoilNo.Visible = true;
                lblLotNo.Visible = true;
                txtLotNo.Visible = true;

                //tab 2

                lblDate.Visible = false;
                dtStart_H.Visible = false;
                sLabel11.Visible = false;
                dtEnd_H.Visible = false;
                lblCustCode_H.Visible = false;
                txtCustCode_H.Visible = false;
                txtCustName_H.Visible = false;
                lblPoNo.Visible = false;
                txtTraNo_H.Visible = false;
                lblChkTraNo_H.Visible = false;
                chkTrano_H.Visible = false;

            }
            else
            {
                btnPrint.Visible = true;

                lblWhCode.Visible = false;
                cboWhCode.Visible = false;
                lblItemType_H.Visible = false;
                cboItemType.Visible = false;
                lblItemName.Visible = false;
                txtItemCode.Visible = false;
                txtItemName.Visible = false;
                lblCoilNo.Visible = false;
                txtCoilNo.Visible = false;
                lblLotNo.Visible = false;
                txtLotNo.Visible = false;

                //tab 2

                lblDate.Visible = true;
                dtStart_H.Visible = true;
                sLabel11.Visible = true;
                dtEnd_H.Visible = true;
                lblCustCode_H.Visible = true;
                txtCustCode_H.Visible = true;
                txtCustName_H.Visible = true;
                lblPoNo.Visible = true;
                txtTraNo_H.Visible = true;
                lblChkTraNo_H.Visible = true;
                chkTrano_H.Visible = true;

            }
            if (chk == true)
            {
                DoInquire();
            }
        }

        private void grid4_ClickCell(object sender, EventArgs e)
        {

            if (this.grid4.Rows.Count == 0) return;

            //_GridUtil.Grid_Clear(grid3);

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPLANTCODE = grid4.ActiveRow.Cells["PLANTCODE"].Value.ToString();      //GRID1.공장 
                string sTRANO = grid4.ActiveRow.Cells["TRANO"].Value.ToString();            //GRID1.반출번호  

                rtnDtTemp = helper.FillTable("USP_MM0300_S3", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TRANO", sTRANO, DbType.String, ParameterDirection.Input));


                this.ClosePrgFormNew();


                if (rtnDtTemp.Rows.Count > 0)
                {
                    if (DtGrid3[grid4.ActiveRow.Index] == null)
                    {
                        DtGrid3[grid4.ActiveRow.Index] = rtnDtTemp;

                        grid3.DataSource = DtGrid3[grid4.ActiveRow.Index];
                        grid3.DataBinds();
                    }
                    else
                    {
                        grid3.DataSource = DtGrid3[grid4.ActiveRow.Index];
                        grid3.DataBinds();
                    }


                }
                else
                {
                    _GridUtil.Grid_Clear(grid3);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                }
                grid3.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.NoEdit;
                grid3.DisplayLayout.Bands[0].Columns["TRANO"].CellActivation = Activation.NoEdit;
                grid3.DisplayLayout.Bands[0].Columns["MATLOTNO"].CellActivation = Activation.NoEdit;
                grid3.DisplayLayout.Bands[0].Columns["LOTSTATUS"].CellActivation = Activation.NoEdit;
                grid3.DisplayLayout.Bands[0].Columns["LOTQTY"].CellActivation = Activation.NoEdit;
                grid3.DisplayLayout.Bands[0].Columns["UNITCODE"].CellActivation = Activation.NoEdit;
                grid3.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Activation.NoEdit;
                grid3.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Activation.NoEdit;
                grid3.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Activation.NoEdit;
                grid3.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Activation.NoEdit;

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
        }
        private void grid4_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            this.grid4.UpdateData();

            if (e.Cell.Column.ToString() != "CHK") { return; }

            try
            {
                string pValue = Convert.ToString(e.Cell.Row.Cells["CHK"].Value);

                if (this.DtGrid3[e.Cell.Row.Index] == null)
                {
                    DBHelper helper = new DBHelper(false);

                    try
                    {

                        string sPLANTCODE = grid4.ActiveRow.Cells["PLANTCODE"].Value.ToString();      //GRID1.공장 
                        string sTRANO = grid4.ActiveRow.Cells["TRANO"].Value.ToString();              //GRID1.반출번호  

                        rtnDtTemp = helper.FillTable("USP_MM0300_S3", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("TRANO", sTRANO, DbType.String, ParameterDirection.Input));


                        if (helper.RSCODE == "E")
                        {
                            this.ShowDialog(helper.RSMSG);
                            return;
                        }

                        DtGrid3[e.Cell.Row.Index] = rtnDtTemp;
                    }
                    catch (Exception ex)
                    {
                        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                    }
                    finally
                    {
                        helper.Close();
                    }
                }

                for (int i = 0; i < this.DtGrid3[e.Cell.Row.Index].Rows.Count; i++)
                {
                    DtGrid3[e.Cell.Row.Index].Rows[i]["CHK"] = pValue;
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void grid3_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            this.grid3.UpdateData();

            if (e.Cell.Column.ToString() != "CHK") { return; }

            try
            {
                bool bChk = false;
                int CNT = 0;
                for (int i = 0; i < this.grid3.Rows.Count; i++)
                {
                    if (Convert.ToString(DtGrid3[grid4.ActiveRow.Index].Rows[i]["CHK"]).ToUpper() == "TRUE")
                    {
                        bChk = true;
                        break;
                        //CNT++;
                    }
                }
                //if(CNT == this.grid2.Rows.Count)
                //    bChk = true;
                if (bChk == true)
                {
                    DtChange1.Rows[this.grid4.ActiveRow.Index]["CHK"] = "True";

                }
                else
                {
                    DtChange1.Rows[this.grid4.ActiveRow.Index]["CHK"] = "False";
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        public override void DoNew()
        {
            try
            {
                //15-09-25 최재형 개체에러발생하여 추가
                if (this.grid4.Rows.Count == 0) return;
                if (grid4.ActiveRow == null) return;

                base.DoNew();
                if (this.grid4.ActiveRow.Cells["TRASTATUS"].Value.ToString() == "10")
                {
                    this.grid3.InsertRow();
                    this.grid3.ActiveRow.Cells["CHK"].Value = false;
                    this.grid3.ActiveRow.Cells["PLANTCODE"].Value = this.plantCode;
                    this.grid3.ActiveRow.Cells["TRANO"].Value = this.grid4.ActiveRow.Cells["TRANO"].Value.ToString();
                    grid3.ActiveRow.Cells["MATLOTNO"].Activation = Activation.NoEdit;
                    grid3.ActiveRow.Cells["LOTSTATUS"].Activation = Activation.NoEdit;
                    grid3.ActiveRow.Cells["LOTQTY"].Activation = Activation.NoEdit;
                    grid3.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                    grid3.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                    grid3.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                    grid3.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }

        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtStart_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtEnd_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("조회 시작일자가 종료일자보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }

        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.grid4.UpdateData();

            int CheckCnt = 0;
            if (grid4.Rows.Count < 1)
            {
                this.ShowDialog(Common.getLangText("조회된 데이터가 없습니다", "MSG"), DialogForm.DialogType.OK);
                return;
            }
            else
            {
                for (int i = 0; i < grid4.Rows.Count; i++)
                {
                    if (grid4.Rows[i].Cells["CHK"].Value.ToString().ToUpper() == "TRUE")
                        CheckCnt++;

                }

                if (CheckCnt == 0)
                {
                    this.ShowDialog(Common.getLangText("선택된 데이터가 없습니다", "MSG"), DialogForm.DialogType.OK);
                    return;
                }
            }
            //재발행
            Print();
        }

        private void Print()
        {
            DataTable dtForPrint = new DataTable();
            DataTable dtGrid = (DataTable)grid4.DataSource;

            dtForPrint.Columns.Add("TRANO", typeof(string));
            dtForPrint.Columns.Add("TRATYPE", typeof(string));


            //출력순번
            //int iPrintNum = Convert.ToInt16(cboNumber.Value);

            //if (iPrintNum > 1)
            //{
            //    for (int i = 0; i < iPrintNum - 1; i++)
            //    {
            //        dtForPrint.Rows.Add("", "", "", "", "", "", "");
            //    }
            //}

            foreach (DataRow dr_Grid in dtGrid.Rows)
            {
                if (dr_Grid["CHK"].ToString().ToUpper() != "TRUE")
                    continue;

                dtForPrint.Rows.Add(dr_Grid["TRANO"].ToString()
                                    , dr_Grid["TRATYPE"].ToString()
                                   );
            }

            POP_MM0300X POP_MM0300X = new POP_MM0300X(dtForPrint, "Y");
            POP_MM0300X.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //DBHelper helper = new DBHelper(false);
            //try
            //{
            //    rtnDtTemp = helper.FillTable("USP_DA9999_R1", CommandType.StoredProcedure
            //                                    , helper.CreateParameter("PlantCode", "1100", DbType.String, ParameterDirection.Input)             // 공장
            //                                );
            //    if (helper.RSCODE != "S")
            //    {
            //        SException ex = new SException(helper.RSCODE, null);
            //        throw ex;
            //    }

            //    if (rtnDtTemp.Rows.Count < 1)
            //    {
            //        this.ClosePrgFormNew();
            //        SException ex = new SException("R00111", null); // 조회할 데이터가 존재하지 않습니다.
            //    }
            //    else
            //    {
            //        //DA9999_R에 rtnDtTemp 데이터바인딩
            //        DA9999_Report_N = new DA9999_R();

            //        objectDataSource.DataSource = rtnDtTemp;
            //        DA9999_Report_N.DataSource = objectDataSource;
            //        viewerInstance.ReportDocument = DA9999_Report_N.Report;
            //        //viewerInstance.Parameters.Add("TraPlanDate", sTraPlanDate);

            //        //레포트 뷰어
            //        //ReportViewer.ReportSource = viewerInstance;
            //        //ReportViewer.RefreshReport();

            //        //뷰어 없이 바로 출력
            //        Telerik.Reporting.IReportDocument myReport = new DA9999_R();
            //        System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
            //        System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
            //        Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

            //        reportProcessor.PrintController = standardPrintController;
            //        printerSettings.Collate = true;

            //        reportProcessor.PrintReport(viewerInstance, printerSettings);
            //    }
            //}
            //catch (SException ex)
            //{

            //    this.ClosePrgFormNew();
            //    this.ShowErrorMessage(ex);
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            //finally
            //{
            //    this.ClosePrgFormNew();
            //    helper.Close();
            //}
        }
    }
}


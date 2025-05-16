#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD1310
//   Form Name    : 수리/보수 이력
//   Name Space   : WIZ.MD
//   Created Date : 2014-05-12
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

namespace WIZ.MD
{
    public partial class MD1310 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >
        public MD1310()
        {
            InitializeComponent();
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

                string sMoldCode = txtMoldCode.Text;                                           //금형코드
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);             // 공장코드     
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value);     // 일자 FROM                                                                                                                                                                    
                string sEnddate = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);         // 일자 TO 
                string sRepResult = DBHelper.nvlString(this.cboRepResult.Value);               //수리결과
                string sRepType = DBHelper.nvlString(this.cboRepType.Value);                   //  수리 유형

                grid1.DataSource = helper.FillTable("USP_MD1310_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   //Form3.cs   , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("RepResult", sRepResult, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("RepType", sRepType, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EndDate", sEnddate, DbType.String, ParameterDirection.Input));
                grid1.DataBind();
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

        #endregion

        #region < MD1310_Load >
        private void MD1310_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장 ", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepDate", "수리일자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Moldname", "금형명 ", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목코드", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepReqNo", "의뢰번호", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldRepSeqNo", "수리횟차", true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepBefShoot", "수리전타수", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepType", "수리유형", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepDesc", "수리내역", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepWoker", "수리작업자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepResult", "수리결과", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepCustCode", "수리업체", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "업체명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion
            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("RepType");  //수리유형
            WIZ.Common.FillComboboxMaster(this.cboRepType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "RepType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("RepResult");  //수리 결과
            WIZ.Common.FillComboboxMaster(this.cboRepResult, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "RepResult", rtnDtTemp, "CODE_ID", "CODE_NAME");


            #endregion
            #region --- POP-UP Setting ---
            // pop up 화면(gird POP-UP)

            //bizGrid = new BizGridManager(grid1);
            //bizGrid.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });     //  품목POP_UP grid
            //bizGrid.PopUpAdd("MoldCode", "MoldName", "TBM1600", new string[] { "PlantCode", "" });      // 금형 POP_UP grid

            ////조회용 POP 
            //팝업 매니저
            BizTextBoxManager btbManager = new BizTextBoxManager();
            // btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" }); //품목
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "TBM1600", new object[] { cboPlantCode_H, "" }); //금형
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


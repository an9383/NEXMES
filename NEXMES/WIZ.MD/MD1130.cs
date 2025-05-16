#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD1130
//   Form Name    : 금형 점검 실적 이력
//   Name Space   : WIZ.MD
//   Created Date : 2014-05-18
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

    public partial class MD1130 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        #endregion

        #region < CONSTRUCTOR >
        public MD1130()
        {
            InitializeComponent();
            // pop up 화면(gird POP-UP)
            //비지니스 로직 객체 생성
            BizGridManager bizGrid = new BizGridManager(grid1);
            bizGrid.PopUpAdd("MoldCode", "MoldName", "TBM1600", new string[] { "PlantCode", "" });            //금형 POP_UP grid
            //조회용 POP

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "TBM1600", new object[] { cboPlantCode_H, "" });    //금형

            // pop up 화면(gird POP-UP)
            bizGrid = new BizGridManager(grid1);
            btbManager.PopUpAdd(InspWorker, txtInspWorker, "TBM0200", new object[] { cboPlantCode_H, "", "", "", "" }); //점검자

            /*
             // pop up 화면(gird POP-UP)
             bizGrid = new BizGridManager(grid1);
             bizGrid.PopUpAdd("InspWorker", "InspWorker", "TBM0000", new string[] { "PlantCode", "" });        //점검자 POP_UP grid
             //조회용 POP
             btbManager = new BizTextBoxManager();
             btbManager.PopUpAdd(txtInspWorker, txtInspWorker, "TBM0000", new object[] { cboPlantCode_H, "" });//점검자
             */

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

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);                  // 공장코드
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value);          // 일자 FROM
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);              // 일자 TO             //점검일 시작일자
                string sMoldCode = this.txtMoldCode.Text.Trim();                                    //금형코드
                string sInspWorker = this.InspWorker.Text.Trim();                                   //점검자               //txtInspWorker.Text;


                grid1.DataSource = helper.FillTable("USP_MD1130_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("InspWorker", sInspWorker, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();

                if (helper.RSCODE != "S")
                {
                    SException ex = new SException(helper.RSCODE, null);
                    throw ex;
                }

            }
            catch (SException ex)
            {
                this.ShowErrorMessage(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //if (helper._sConn != null) { helper._sConn.Close(); }
                helper.Close();
            }
        }

        #endregion

        #region MD1130_load
        private void MD1130_Load(object sender, EventArgs e)
        {
            #region 그리드


            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDate", "점검일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldNmae", "금형명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlanReqNo", "계획번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlanInspDate", "계획일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspWorker", "점검자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResult", "점검결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "Remark(비고)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "점검항목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspNmae", "점검항목명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecLSL", "규격상한", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecUSL", "규격하한", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "점사구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspMethod", "수집장비", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResultDesc", "검사값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResult1", "항목검사결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion



            #region 콤보박스
            //사업장
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
            rtnDtTemp = _Common.GET_BM0000_CODE("InspMethod");           //검사수집장비                                                                                                                                                                              
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspMethod", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspValType");           //검사정보구분                                                                                                                                                                              
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspValType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspResult");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspResult", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion
        }
        #endregion MD1130_load

        #region grid POP UP 처리
        #endregion

        #region <METHOD AREA>*/
        // Form에서 사용할 함수나 메소드를 정의
        #endregion

    }
}

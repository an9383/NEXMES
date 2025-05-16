#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  PP0310
//   Form Name    : 작업호기(WorkCenter)별  정보 조회
//   Name Space   : WIZ.MM
//   Created Date : 
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

namespace WIZ.PP
{
    public partial class PP0310 : WIZ.Forms.BaseMDIChildForm
    {

        public PP0310()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtLineCode, txtLineName, "TBM0500", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });
        }

        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();


                string sPlantCode = cboPlantCode_H.Value.ToString();                                                // 사업장(공장)
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);                          // 생산시작일자
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);                              // 생산  끝일자
                string sWorkCenterCode = this.txtWorkCenterCode.Text.Trim();                                        // 작업장 코드
                string sOPCode = this.txtOPCode.Text.Trim();                                                        // 공정 코드
                string sLineCode = this.txtLineCode.Text.Trim();                                                    // 라인 코드
                string sItemCode = this.txtItemCode.Text.Trim();                                                    // 품목
                string sDayNight = cboShiftGb_H.Value.ToString() == "ALL" ? "" : cboShiftGb_H.Value.ToString();     // 주야 구분
                string sShiftGb = cboDaynight_H.Value.ToString() == "ALL" ? "" : cboDaynight_H.Value.ToString();    // 근무 
                string sDeptCode = Convert.ToString(cboDeptCode.Value);     //팀구분

                grid1.DataSource = helper.FillTable("USP_PP0310_S2N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DayNight", sDayNight, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ShiftGb", sShiftGb, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DeptCode", sDeptCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Param1", DBNull.Value, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Param2", DBNull.Value, DbType.String, ParameterDirection.Input));


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


        #region 폼 로더
        private void PP0310_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            //90 95 160 70 170 100 170 100 100 140 200 80 50 100 130 130 80 100 100 100 100 140 100 

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "작업장", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "작업장명", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineCode", "라인", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineName", "라인명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업라인", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업라인명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RecDate", "일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DayNight", "주야구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DayNightNM", "주야", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdQty", "설비카운트", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OrderNo", "지시번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ShiftGb", "조구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion



            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DeptCode");  //팀구분
            WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DeptCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT");
            WIZ.Common.FillComboboxMaster(this.cboDaynight_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DayNight", rtnDtTemp, "CODE_ID", "CODE_NAME");


            #endregion

            #region Grid MERGE
            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["OPCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["OPCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["OPCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["OPName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["OPName"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["OPName"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["LineCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["LineCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["LineCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["LineName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["LineName"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["LineName"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["WorkCenterCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["WorkCenterCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["WorkCenterCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["WorkCenterName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["WorkCenterName"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["WorkCenterName"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["RecDate"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["RecDate"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["RecDate"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ItemCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["itemCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["itemCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ItemName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["ItemName"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["ItemName"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["OrderNo"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["OrderNo"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["OrderNo"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["DayNight"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["DayNight"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["DayNight"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["DayNightNM"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["DayNightNM"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["DayNightNM"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ShiftGb"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["ShiftGb"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["ShiftGb"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE
        }
        #endregion

        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "ProdQty" });

        }
    }
}
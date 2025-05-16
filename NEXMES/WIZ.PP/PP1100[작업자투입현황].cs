#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  PP1100
//   Form Name    : 투입작업자 현황  정보 조회
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
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    using WIZ.Forms;

    public partial class PP1100 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>

        #endregion

        #region<CONSTRUCTOR>
        public PP1100()
        {
            InitializeComponent();

            string sUseFlag = string.Empty;
            string sLineCode = string.Empty;
            string sOPCode = string.Empty;


            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWorkerID, txtWorkerName, "TBM0200", new object[] { "", "", "", "", "" });
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, sUseFlag });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, sOPCode, sLineCode, sUseFlag });
        }
        #endregion

        #region<DoInquire>
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = cboPlantCode_H.Value.ToString();                                             // 사업장(공장)
                string sWorkerID = this.txtWorkerID.Text.Trim();                                                 // 작업자
                string sWorkerName = this.txtWorkerName.Text.Trim();
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);                       // 생산시작일자
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);                           // 생산  끝일자
                string sWorkCenterCode = this.txtWorkCenterCode.Text.Trim();                                     // 작업장 코드
                string sWorkCenterName = this.txtWorkCenterName.Text.Trim();
                string sOPCode = this.txtOPCode.Text.Trim();                                                     // 공정 코드
                string sOPName = this.txtOPName.Text.Trim();
                string sLineCode = this.txtLineCode.Text.Trim();                                                 // 라인 코드
                string sDeptCode = Convert.ToString(cboDeptCode.Value);                                          //팀구분

                grid1.DataSource = helper.FillTable("USP_PP1100_S2N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)              // 사업장(공장)    
                                                                    , helper.CreateParameter("WorkerID", sWorkerID, DbType.String, ParameterDirection.Input)                // 작업자          
                                                                    , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)              // 생산시작일자    
                                                                    , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)                  // 생산  끝일자    
                                                                    , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)    // 작업장 코드     
                                                                    , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)                    // 공정 코드                                                                         
                                                                    , helper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input)                // 라인 코드                                                                        
                                                                    , helper.CreateParameter("WorkerName", sWorkerName, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPName", sOPName, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkCenterName", sWorkCenterName, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Param1", sDeptCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Param2", DBNull.Value, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Param3", DBNull.Value, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region 폼 로더
        private void PP1100_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RecDate", "일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "WorkerName", "작업자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "공정", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "공정명", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineCode", "라인", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineName", "라인명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Status", "상태", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StartDate", "시작시간", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EndDate", "종료시간", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StatusTime", "작업시간(분)", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InWorkCenterCnt", "투입라인수", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ManHour", "실공수(분)", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "StopCode", "비가동코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotNO", "Lot No", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DayNight", "주야구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ShiftGb", "조구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UPH", "UPH", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CycleTime", "사이클타임", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerID", "작업자ID", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);



            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DeptCode");  //팀구분
            WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DeptCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region Grid MERGE

            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["WorkerID"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["WorkerID"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["WorkerID"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["WorkerName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["WorkerName"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["WorkerName"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["RecDate"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["RecDate"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["RecDate"].MergedCellStyle = MergedCellStyle.Always;

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

            #endregion Grid MERGE
        }
        #endregion
    }
}
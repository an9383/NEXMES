#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : TO00410
//   Form Name    : TOOL 변경 이력 조회
//   Name Space   : WIZ.CM.DLL
//   Created Date : 2012-12-14
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion
#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.CM
{
    public partial class TO0410 : WIZ.Forms.BaseMDIChildForm
    {

        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >

        public TO0410()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();

            //* TBM0100 : 품목
            //*          - 1 : 품목, 2 : 품목명, param[0] : PlantCode, param[1] : ItemType
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            //TTO0100 : Tool 마스터
            //           - 1 : Code  2 : CodeName, param[0] : PlantCode, param[1] : Seq, param[2] : 사용여부, param[3] : 장착여부
            btbManager.PopUpAdd(txtToolCode, txtToolName, "TTO0100", new object[] { cboPlantCode_H, "", "", "" });
        }

        private void TO0410_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "plantcode", "사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "공정", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Machname", "설비명", false, GridColDataType_emu.VarChar, 240, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "toolcode", "TOOL 코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ToolName", "TOOL명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "seq", "순번", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "itemcode", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "prodqty", "사용수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,###", "nnn,nnn,nnn", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StartDate", "변경일자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "YESNO", "장착여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            int iColCount = grid1.Columns.Count;

            _GridUtil.SetInitUltraGridBind(grid1);


            //3자리수 , 표시
            grid1.Columns["prodqty"].Format = "#,###"; //사용수량


            #region Grid MERGE
            grid1.Columns["plantcode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["plantcode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["plantcode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["OPName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["OPName"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["OPName"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["WorkCenterName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["WorkCenterName"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["WorkCenterName"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["Machname"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["Machname"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["Machname"].MergedCellStyle = MergedCellStyle.Always;


            //grid1.Columns["seq"].MergedCellContentArea    = MergedCellContentArea.VisibleRect;
            //grid1.Columns["seq"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            //grid1.Columns["seq"].MergedCellStyle          = MergedCellStyle.Always;
            #endregion Grid MERGE

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboEquip, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "YESNO", rtnDtTemp, "CODE_ID", "CODE_NAME");
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
            System.Data.Common.DbParameter[] param = new System.Data.Common.DbParameter[8];

            try
            {
                base.DoInquire();

                string sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();
                string sUsage = cboEquip.Value.ToString() == "ALL" ? "" : cboEquip.Value.ToString();
                string sItemCode = txtItemCode.Text.Trim();
                string sItemName = txtItemName.Text.Trim();
                string sToolCode = txtToolCode.Text.Trim();
                string sToolName = txtToolName.Text.Trim();
                string sStartDate = string.Format("{0:yyyy-MM-dd 00:00:00}", cbo_date.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd 23:59:59}", cbo_dateto.Value);

                param[0] = helper.CreateParameter("@STARTDATE", sStartDate, DbType.String, ParameterDirection.Input);
                param[1] = helper.CreateParameter("@ENDDATE", sEndDate, DbType.String, ParameterDirection.Input);
                param[2] = helper.CreateParameter("@TOOLCODE", sToolCode, DbType.String, ParameterDirection.Input);
                param[3] = helper.CreateParameter("@TOOLNAME", sToolName, DbType.String, ParameterDirection.Input);
                param[4] = helper.CreateParameter("@PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input);
                param[5] = helper.CreateParameter("@MACHCODE", sItemCode, DbType.String, ParameterDirection.Input);
                param[6] = helper.CreateParameter("@MACHNAME", sItemName, DbType.String, ParameterDirection.Input);
                param[7] = helper.CreateParameter("@USAGE", sUsage, DbType.String, ParameterDirection.Input);

                grid1.DataSource = helper.FillTable("USP_TO0410_S1", CommandType.StoredProcedure, param);

                DataTable dt = new DataTable();


                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                if (param != null) { param = null; }
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {

        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {

        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {

        }
        #endregion

        #region < EVENT AREA >
        /// <summary>
        /// Form이 Close 되기전에 발생
        /// e.Cancel을 true로 설정 하면, Form이 close되지 않음
        /// 수정 내역이 있는지를 확인 후 저장여부를 물어보고 저장, 저장하지 않기, 또는 화면 닫기를 Cancel 함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

        }
        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Modified)
            {
                e.Command.Parameters["@Editor"].Value = this.WorkerID;
                return;
            }

            if (e.Row.RowState == DataRowState.Added)
            {
                e.Command.Parameters["@Maker"].Value = this.WorkerID;
                return;
            }
        }

        /// <summary>
        /// 저장처리시 오류가 발생한 경우 오류 메세지에 대한 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Errors == null) return;

            switch (((SqlException)e.Errors).Number)
            {
                // 중복
                case 2627:
                    e.Row.RowError = "설비코드가 있습니다.";
                    throw (new SException("S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion

        #region<DoBaseSum>
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "prodqty" });

        }
        #endregion

        #region <METHOD AREA>

        #endregion
    }
}

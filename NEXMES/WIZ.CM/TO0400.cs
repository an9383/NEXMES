#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : TO0400
//   Form Name    : TOOL 사용 실적 조회 
//   Name Space   : WIZ.CM.DLL
//   Created Date : 2012-12-12
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
    public partial class TO0400 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >

        public TO0400()
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

        private void TO0400_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            _GridUtil.InitColumnUltraGrid(grid1, "plantcode", "사업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "toolcode", "TOOL 코드", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ToolName", "TOOL명", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "seq", "순번", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "prodqty", "사용수량", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Right, true, false, "#,###", "nnn,nnn,nnn", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Price", "단가", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false, "#,###", null, null, null, null);

            int iColCount = grid1.Columns.Count;

            _GridUtil.SetInitUltraGridBind(grid1);

            #region Grid MERGE
            grid1.Columns["plantcode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["plantcode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["plantcode"].MergedCellStyle = MergedCellStyle.Always;

            //grid1.Columns["seq"].MergedCellContentArea    = MergedCellContentArea.VisibleRect;
            //grid1.Columns["seq"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            //grid1.Columns["seq"].MergedCellStyle          = MergedCellStyle.Always;

            #endregion Grid MERGE

            ////3자리수 , 표시
            //grid1.Columns["Price"].Format   = "#,###";   //단가
            //grid1.Columns["prodqty"].Format = "#,###"; //사용수량


            #endregion


            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable();              // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
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

                string sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();
                string sItemCode = txtItemCode.Text.Trim();
                string sItemName = txtItemName.Text.Trim();
                string sToolCode = txtToolCode.Text.Trim();
                string sToolName = txtToolName.Text.Trim();
                string sStartDate = string.Format("{0:yyyy-MM-dd 00:00:00}", cbo_date.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd 23:59:59}", cbo_dateto.Value);


                grid1.DataSource = helper.FillTable("USP_TO0400_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("@STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@TOOLCODE", sToolCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@TOOLNAME", sToolName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@ITEMNAME", sItemName, DbType.String, ParameterDirection.Input));
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
            UltraGridRow ugr = grid1.DoSummaries(new string[] { "prodqty", "price" });
        }
        #endregion

        #region <METHOD AREA>

        #endregion
    }
}

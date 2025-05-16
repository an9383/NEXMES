#region < HEADER AREA >

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
    public partial class CM0800 : WIZ.Forms.BaseMDIChildForm
    {

        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >
        public CM0800()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMachCode, txtMachName, "TBM0700", new object[] { "", "", "", "" });                     //설비 팝업

        }
        #endregion

        #region<CM0800_Load>
        private void CM0800_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "MachCode", "설비코드", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "machname", "설비명", false, GridColDataType_emu.VarChar, 230, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RETDATE", "기준", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, true, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REVALUE", "배점", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QcCode", "기준", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QcValue", "배점", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RpCode", "기준", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RpValue", "배점", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EsCode", "기준", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EsValue", "배점", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MTBF", "기준", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MTBFVALUE", "배점", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MTTR", "기준", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MTTRVALUE", "배점", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SUMVALUE", "합계", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, true, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SUMCODE", "설비등급", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            //string[] sHeadColumn = { "MachCode", "machname", "RETDATE", "REVALUE", "QcCode", "QcValue", "RpCode", "RpValue", "EsCode", "EsValue", "MTBF", "MTBFVALUE", "MTTR", "MTTRVALUE", "SUMVALUE", "SUMCODE", "Remark" };


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            //그리드 머지

            //_GridUtil.GridHeaderMerge(grid1, "G0", "가동시간", sMergeColumn0, sHeadColumn);
            //_GridUtil.GridHeaderMerge(grid1, "G1", "품질영향", sMergeColumn1, sHeadColumn);
            //_GridUtil.GridHeaderMerge(grid1, "G2", "대체설비", sMergeColumn2, sHeadColumn);
            //_GridUtil.GridHeaderMerge(grid1, "G3", "환경안전영향", sMergeColumn3, sHeadColumn);
            //_GridUtil.GridHeaderMerge(grid1, "G4", "MTBF", sMergeColumn4, sHeadColumn);
            //_GridUtil.GridHeaderMerge(grid1, "G5", "MTTR", sMergeColumn5, sHeadColumn);


            //_GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 0, 1);

            //_GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 14, 16);

            //grid1.Columns["G0"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //grid1.Columns["G1"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //grid1.Columns["G2"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //grid1.Columns["G3"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //grid1.Columns["G4"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //grid1.Columns["G5"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;


            // row numbering
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("MACHGD_QC");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "QcCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MACHGD_RP");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "RpCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MACHGD_ES");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "EsCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
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

                string sMachcode = Convert.ToString(txtMachCode.Text).Trim();
                string sMachname = Convert.ToString(txtMachName.Text).Trim();
                string sDtp_date = string.Format("{0:yyyy}", cbo_date.Value);
                //string sDtp_date = cbo_date.Value.ToString().Substring(0, 4);
                //string.Format("{0:yyyy-MM-dd}", cbo_date.Value);

                grid1.DataSource = helper.FillTable("USP_CM0800_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("MACHCODE", sMachcode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MACHNAME", sMachname, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("YEAR", sDtp_date, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SPARE2", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SPARE3", "", DbType.String, ParameterDirection.Input));
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
                    e.Row.RowError = "작업자 정보가 있습니다.";
                    throw (new SException("S00099", e.Errors));
                default:
                    break;
            }
        }



        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의





        #endregion

    }
}

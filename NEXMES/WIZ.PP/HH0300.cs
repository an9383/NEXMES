#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  HH0300
//   Form Name    :  
//   Name Space   : WIZ.PP
//   Created Date : 
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

namespace WIZ.PP
{
    public partial class HH0300 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region < CONSTRUCTOR >

        public HH0300()
        {
            InitializeComponent();
        }
        #endregion

        #region  HH0300_Load
        private void HH0300_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);


            // InitColumnUltraGrid 

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODDATE", "작업일자", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHT", "주야", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ST", "C/T", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTAL", "총수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOWNOMAL", "0%이하", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOW1To5QTY", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOW1To5TIME", "잠재적비가동\r시간(분)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOW5To10QTY", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOW5To10TIME", "잠재적비가동\r시간(분)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOW10To50QTY", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOW10To50TIME", "잠재적비가동\r시간(분)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOW50To100QTY", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOW50To100TIME", "잠재적비가동\r시간(분)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOW100QTY", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOW100TIME", "잠재적비가동\r시간(분)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOWSTOP", "잠재적 비가동\r시간(분)", false, GridColDataType_emu.Double, 150, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);


            //데이터 머지 된 상태에서 그리드 컬럼 소트 기능 막기     
            grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            // string[] sMergeColumn =  { "PLANTCODE", "PRODDATE", "DAYNIGHT", "OPCODE", "OPNAME", "WORKCENTERCODE", "WORKCENTERNAME","ITEMCODE", "ITEMNAME", "ST", "TOTAL","LOWNOMAL"};
            string[] sMergeColumn = { "LOW1To5QTY", "LOW1To5TIME" };
            string[] sMergeColumn1 = { "LOW5To10QTY", "LOW1To10TIME" };
            string[] sMergeColumn2 = { "LOW10To50QTY", "LOW10To50TIME" };
            string[] sMergeColumn3 = { "LOW50To100QTY", "LOW50To100TIME" };
            string[] sMergeColumn4 = { "LOW100QTY", "LOW100TIME" };
            //   string[] sMergeColumn6 = { "LOWSTOP" };
            string[] sHeadColumn =   { "PLANTCODE", "PRODDATE", "DAYNIGHT", "OPCODE", "OPNAME", "WORKCENTERCODE", "WORKCENTERNAME",
                                       "ITEMCODE", "ITEMNAME", "ST", "TOTAL",
                                       "LOWNOMAL", "LOW1To5QTY", "LOW1To5TIME", "LOW5To10QTY", "LOW5To10TIME",
                                       "LOW10To50QTY", "LOW10To50TIME", "LOW50To100QTY","LOW50To100TIME",
                                       "LOW100QTY","LOW100TIME","LOWSTOP"};



            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion




            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DAYNIGHT", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboDayNight, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");


            #endregion


            //그리드 머지
            // _GridUtil.GridHeaderMerge(grid1, "G1", "", sMergeColumn, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G1", "1%이상~5%미만", sMergeColumn, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G2", "5%이상~10%미만", sMergeColumn1, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G3", "10%이상~50%미만", sMergeColumn2, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G4", "50%이상~100%미만", sMergeColumn3, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G5", "100%이상", sMergeColumn4, sHeadColumn);
            //   _GridUtil.GridHeaderMerge(grid1, "G7", "", sMergeColumn6, sHeadColumn);
            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 0, 11);
            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 22, 22);

            // grid1.Columns["G1"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //grid1.Columns["G1"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //grid1.Columns["G2"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //grid1.Columns["G3"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //grid1.Columns["G4"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //grid1.Columns["G5"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //   grid1.Columns["G7"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;


            //팝업창

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, txtOPCode, "", "" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });

        }
        #endregion  HH0300_Load

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
                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value.ToString());                  // 사업장 공장코드
                string sSrart = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);                         // 시작일자
                string sWorkCenterCode = this.txtWorkCenterCode.Text;                                     // 작업장
                string sOPCode = this.txtOPCode.Text.Trim();                                              // 공정              	
                string sDAYNIGHT = DBHelper.nvlString(cboDayNight.Value.ToString());
                string sItemcode = this.txtItemCode.Text.Trim();

                param[0] = helper.CreateParameter("pPLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input);                   //사업부(공장)
                param[1] = helper.CreateParameter("pSTARTDATE", sSrart, DbType.String, ParameterDirection.Input);                      //시작일자(시)
                param[2] = helper.CreateParameter("pWORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input);        //작업장
                param[3] = helper.CreateParameter("pOPCODE", sOPCode, DbType.String, ParameterDirection.Input);
                param[4] = helper.CreateParameter("pITEMCODE", sItemcode, DbType.String, ParameterDirection.Input);
                param[5] = helper.CreateParameter("pDAYNIGHT", sDAYNIGHT, DbType.String, ParameterDirection.Input);

                param[6] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                param[7] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                grid1.DataSource = helper.FillTable("USP_HH0300_S1", CommandType.StoredProcedure, param);


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
                //                e.Command.Parameters["@Editor"].Value = this.WorkerID;
                return;
            }

            if (e.Row.RowState == DataRowState.Added)
            {
                //             e.Command.Parameters["@Maker"].Value = this.WorkerID;
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
                    e.Row.RowError = "데이터가 중복입니다.";
                    throw (new SException("C:S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "TOTAL", "LOWNOMAL", "LOW1To5QTY", "LOW1To5TIME", "LOW5To10QTY", "LOW5To10TIME", "LOW10To50QTY", "LOW10To50TIME", "LOW50To100QTY", "LOW50To100TIME", "LOW100QTY", "LOW100TIME", "LOWSTOP" });

        }

        #endregion
    }
}

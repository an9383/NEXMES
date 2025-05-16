#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD1110 
//   Form Name    : 금형불출이력
//   Name Space   : WIZ.MD
//   Created Date : 2014-05-07
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

namespace WIZ.MD
{

    public partial class MD1110 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >
        public MD1110()
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
            btbManager.PopUpAdd(InspWorker, txtInspWorker, "TBM0200", new object[] { cboPlantCode_H, "", "", "", "" });
            //bizGrid.PopUpAdd("InspWorker", "InspWorker", "TBM0000", new string[] { "PlantCode", "" });        //점검자 POP_UP grid
            ////조회용 POP 
            //btbManager = new BizTextBoxManager();
            //btbManager.PopUpAdd(txtInspWorker, txtInspWorker, "TBM0000", new object[] { cboPlantCode_H, "" });//점검자

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

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);             // 공장코드     
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value);     // 일자 FROM                                                                                                                                                                    
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);         // 일자 TO             //점검일 시작일자                                                                                                                                                        
                string sMoldCode = this.txtMoldCode.Text.Trim();                               //금형코드 
                string sInspWorker = this.InspWorker.Text.Trim();                              //점검자               //txtInspWorker.Text;                                                                                                                                                            


                grid1.DataSource = helper.FillTable("USP_MD1110_S2", CommandType.StoredProcedure
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

        #region MD1110_load
        private void MD1110_Load(object sender, EventArgs e)
        {
            #region 그리드
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDate", "점검일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);//YearMonthDay, 100,Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);                          
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Moldname", "금형명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlanReqNo", "계획번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlanInspDate", "계획일자", false, GridColDataType_emu.YearMonthDay, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspWorker", "점검자", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResult", "점검결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "Remark(비고)", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            //row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);

            // 2014.6.27  임영조 추가
            rtnDtTemp = _Common.GET_BM0000_CODE("InspResult");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspResult", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion
        }
        #endregion MD1110_load

        #region grid POP UP 처리
        #endregion

        #region <METHOD AREA>*/
        // Form에서 사용할 함수나 메소드를 정의
        #endregion

    }
}

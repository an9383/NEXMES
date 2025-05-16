#region < HEADER AREA >
// *--------------------------------------------------------------------------------------------*
//   Form ID      : MD0300 
//   Form Name    : 금형불출이력
//   Name Space   : WIZ.MD
//   Created Date : 2014-04-28
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MD
{

    public partial class MD0300 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >
        public MD0300()
        {
            InitializeComponent();
            // pop up 화면(gird POP-UP)
            BizGridManager bizGrid = new BizGridManager(grid1);
            bizGrid.PopUpAdd("MoldCode", "MoldName", "TBM1600", new string[] { "PlantCode", "" });       //금형 POP_UP grid

            //조회용 POP 
            //비지니스 로직 객체 생성
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "TBM1600", new object[] { cboPlantCode_H, "" }); //금형

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

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);             //공장코드
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);     //출고일 시작일자                                                                                                                           
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);         //출고일 시작일자                                                                                                                                                        
                string sMoldCode = this.txtMoldCode.Text.Trim();                               //금형코드 
                string sOutReqType = DBHelper.nvlString(this.cboOutReqType_H.Value);           //불출구분

                grid1.DataSource = helper.FillTable("USP_MD0300_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("OutReqType", sOutReqType, DbType.String, ParameterDirection.Input));
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
                helper.Close();
            }
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
            //if (e.Row.RowState == DataRowState.Modified)
            //{
            //    e.Command.Parameters["@Editor"].Value = this.WorkerID;
            //    return;
            //}

            //if (e.Row.RowState == DataRowState.Added)
            //{
            //    e.Command.Parameters["@Editor"].Value = this.WorkerID;
            //    e.Command.Parameters["@Maker"].Value = this.WorkerID;
            //    return;
            //}
        }

        private void gbxHeader_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region MD0300_load
        private void MD0300_Load(object sender, EventArgs e)
        {
            #region 그리드
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutDate", "출고(불출)일", false, GridColDataType_emu.DateTime24, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Moldname", "금형명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutReqType", "출고구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldLoc", "출고위치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FromMoldLoc", "기존위치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutReqNo", "출고의뢰번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutWorker", "출고자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InWorkCenterCode", "작업장코드", false, GridColDataType_emu.VarChar, 165, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명  ", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OrderNo", "지시번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "불출업체", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "업체명", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            /* 
            //row number
              grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
              grid1.DisplayLayout.Override.RowSelectorWidth = 40;
              grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
              grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
             */

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");//사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("OutReqType");//출고구분
            WIZ.Common.FillComboboxMaster(this.cboOutReqType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutReqType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //불출장소(등록)
            rtnDtTemp = _Common.GET_BM0000_CODE("MoldLoc");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FromMoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion
        }
        #endregion MD0300_load

        #region grid POP UP 처리
        #endregion

        #region <METHOD AREA>*/
        // Form에서 사용할 함수나 메소드를 정의
        #endregion

    }
}

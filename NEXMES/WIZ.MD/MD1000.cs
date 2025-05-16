#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD1000
//   Form Name    : 금형점검계획
//   Name Space   : WIZ.MD
//   Created Date : 2014-05-08
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

namespace WIZ.MD
{
    public partial class MD1000 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >
        public MD1000()
        {
            InitializeComponent();

            // pop up 화면(gird POP-UP)
            BizGridManager bizGrid = new BizGridManager(grid1);
            bizGrid.PopUpAdd("MoldCode", "MoldName", "TBM1600", new string[] { "PlantCode", "" });      // 금형 POP_UP grid

            ////조회용 POP 
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
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);          //사업장 
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);  //점검예정일 시작일자                                                                                                                           
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);      //점검예정일 시작일자                                                                                                                                                        
                string sMoldCode = txtMoldCode.Text;    //금형코드


                grid1.DataSource = helper.FillTable("USP_MD1000_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input));
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
            try
            {
                base.DoNew();
                int iRow = _GridUtil.AddRow(this.grid1);
                //this.grid1.SetDefaultValue("PlantCode", "SY");

                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlanInspDate");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MoldCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Moldname");
                //UltraGridUtil.ActivationAllowEdit(this.grid1, "ItemCode"    , iRow);
                //UltraGridUtil.ActivationAllowEdit(this.grid1, "ItemName"    , iRow);
                //UltraGridUtil.ActivationAllowEdit(this.grid1, "PlanReqNo"   , iRow);
                //UltraGridUtil.ActivationAllowEdit(this.grid1, "InspDate"    , iRow);
                //UltraGridUtil.ActivationAllowEdit(this.grid1, "InspWorker"  , iRow);
                //UltraGridUtil.ActivationAllowEdit(this.grid1, "InspResult"  , iRow);
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Remark");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper(false);

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "사업장 코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제

                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_MD1000_D1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)  // 공장(사업부)
                                                   , helper.CreateParameter("PlanReqNo", drRow["PlanReqNo"].ToString(), DbType.String, ParameterDirection.Input)  // 점검계획번호 
                                                   , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)); //금형코드                                                        

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            if (drRow["PlanInspDate"].ToString() == "")
                            {
                                MessageBox.Show(Common.getLangText("점검예정일자를 입력하세요", "MSG"));
                                return;
                            }

                            helper.ExecuteNoneQuery("USP_MD1000_I1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("PlanReqNo", drRow["PlanReqNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("PlanInspDate", drRow["PlanInspDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("InspDate", drRow["InspDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("PlanWorker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("InspWorker", drRow["InspWorker"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("InspResult", drRow["InspResult"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_MD1000_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PlanReqNo", drRow["PlanReqNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PlanInspDate", drRow["PlanInspDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspDate", drRow["InspDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PlanWorker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspWorker", drRow["InspWorker"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspResult", drRow["InspResult"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PlantCode");
                helper.Commit();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                DoInquire(); //재 조회 처리
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
        }


        #endregion

        #region<MD1000_Load>
        private void MD1000_Load(object sender, EventArgs e)
        {
            #region 그리드
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlanInspDate", "점검예정일", true, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Moldname", "금형명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlanReqNo", "계획번호", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDate", "점검일자", true, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspWorker", "점검자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResult", "점검결과", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "Remark(비고)", true, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            //row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #endregion
            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion
        }
        #endregion

        #region <METHOD AREA>*/
        // Form에서 사용할 함수나 메소드를 정의
        #endregion
    }
}


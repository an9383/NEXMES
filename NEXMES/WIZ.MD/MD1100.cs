#region < HEADER AREA >

// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD1100 
//   Form Name    : 금형점검계획등록
//   Name Space   : WIZ.MD
//   Created Date : 
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
    public partial class MD1100 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >

        public MD1100()
        {
            InitializeComponent();
            //pop up 화면(gird POP-UP)
            BizGridManager bizGrid = new BizGridManager(grid1);
            bizGrid.PopUpAdd("MoldCode", "MoldName", "TBM1600", new string[] { "PlantCode", "" });             //금형 POP_UP grid
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMoldCode_H, txtMoldName_H, "TBM1600", new object[] { cboPlantCode_H, "" }); //금형(등록)
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "TBM1600", new object[] { cboPlantCode_H, "" });     //금형(조회)
        }

        #endregion

        #region  MD1100_Load
        private void MD1100_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlanInspDate", "점검예정일", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDate", "점검일", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Moldname", "금형명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlanReqNo", "계획번호", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlanWorker", "점검계획자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResult", "점검결과", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspWorker", "점검자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region 콤보박스
            //사업장(조회)
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //점검결과
            rtnDtTemp = _Common.GET_BM0000_CODE("InspResult");
            WIZ.Common.FillComboboxMaster(this.cboInspResult, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspResult", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

        }
        #endregion  MD1100_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                //DtChange.Clear();
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);          //공장코드     
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);  //시작일자                                                                                                                           
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);    //종료일자                                                                                                  
                string sMoldCode = this.txtMoldCode_H.Text.Trim();                         //금형코드     

                grid1.DataSource = helper.FillTable("USP_MD1100_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)     //사업장 공장코드    
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)     //일자 FROM          
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)         //일자 TO            
                                                                   , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input));     //금형코드           

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
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>

        public override void DoNew()
        {
            //try
            //{
            //    base.DoNew();

            //    int iRow = _GridUtil.AddRow(this.grid1, DtChange);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            if (grid1.IsActivate) this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            //SqlDBHelper helper = new SqlDBHelper(false);
            //SqlParameter[] param = null;
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper(false);

            try
            {
                //  this.txtPlanReqNo.Focus();
                base.DoSave();
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.UpdateData();

                //foreach (DataRow drRow in DtChange.Rows)
                foreach (DataRow drRow in ((DataTable)grid1.DataSource).Rows)
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

                            //  helper.ExecuteNoneQuery("USP_TMD1000_D1", CommandType.StoredProcedure
                            //, helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)    // 사업자 
                            //, helper.CreateParameter("PlanReqNo", drRow["PlanReqNo"].ToString(), DbType.String, ParameterDirection.Input)     //점검계획번호             
                            //, helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input));    // 금형코드 

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            #endregion
                            break;

                        //case DataRowState.Modified:
                        default:

                            #region 수정
                            /*
                            helper.ExecuteNoneQuery("USP_MD1100_U1", CommandType.StoredProcedure
                          , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)         // 사업장 공장코드    
                          , helper.CreateParameter("PlanReqNo", drRow["PlanReqNo"].ToString(), DbType.String, ParameterDirection.Input)         // 점검계획번호   
                          , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)           // 금형코드(금형 P/no(25) )   
                          , helper.CreateParameter("PlanInspDate", drRow["PlanInspDate"].ToString(), DbType.String, ParameterDirection.Input));  // 점검예정일자   
                         // , helper.CreateParameter("InspResult", drRow["InspResult"].ToString(), DbType.String, ParameterDirection.Input));     // 점검결과 
                            */

                            string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value);         //사업장 
                            string sPlanReqNo = this.txtPlanReqNo.Text.Trim();                       //계획번호
                            string sMoldCode = this.txtMoldCode.Text.Trim();                         //금형코드
                            string sInspDate = string.Format("{0:yyyy-MM-dd}", CboInspDate.Value);   //점검일자
                            string sInspResult = DBHelper.nvlString(this.cboInspResult.Value);       //점검결과
                            string sInspWorker = this.WorkerID.Trim();                               //점검자
                            string sRemark = this.txtRemark.Text.Trim();                             //비고

                            // UltraGridUtil.DataRowDelete(this.grid1);
                            // this.grid1.UpdateData();

                            helper.ExecuteNoneQuery("USP_MD1100_U1N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)     // 공장(사업장)          
                                                        , helper.CreateParameter("PlanReqNo", sPlanReqNo, DbType.String, ParameterDirection.Input)     // 점검계획번호
                                                        , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)       // 금형코드(금형 P/no(25) )    
                                                        , helper.CreateParameter("InspDate", sInspDate, DbType.String, ParameterDirection.Input)       // 점검일자  
                                                        , helper.CreateParameter("InspResult", sInspResult, DbType.String, ParameterDirection.Input)   // 점검결과 
                                                        , helper.CreateParameter("InspWorker", sInspWorker, DbType.String, ParameterDirection.Input)   // 점검결과 
                                                        , helper.CreateParameter("Remark", sRemark, DbType.String, ParameterDirection.Input));         // 비고            

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
                CancelProcess = true;
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                DoInquire(); //재조회 처리
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
            /*
             * if (e.Row.RowState == DataRowState.Modified)
             {
                 e.Command.Parameters["Editor"].Value = this.WorkerID;
                 return;
             }

             if (e.Row.RowState == DataRowState.Added)
             {
                 //e.Command.Parameters["@Editor"].Value = this.WorkerID;
                 e.Command.Parameters["Maker"].Value = this.WorkerID;
                 return;
             }
              */
        }

        /// <summary>
        /// 저장처리시 오류가 발생한 경우 오류 메세지에 대한 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            /*
             if (e.Errors == null) return;

            switch (((SqlException)e.Errors).Number)
            {
                // 중복
                case 2627:
                    e.Row.RowError = "데이터가 중복입니다.";
                    throw (new SException("S00099", e.Errors));
                default:
                    break;
            }
              */
        }
        #endregion
        /*       
        private void bntInsert_Click(object sender, EventArgs e)
        {
            DoInsert();
            //DoInquire(); //재 조회 처리
        }

        private void DoInsert()
        {
            //금형불출(수동) 등록 처리
            DBHelper helper = new DBHelper(false);

            string sPlantCode  = DBHelper.nvlString(this.cboPlantCode.Value);          //사업장 
            string sPlanReqNo  = this.txtPlanReqNo.Text.Trim();                        //계획번호
            string sMoldCode   = this.txtMoldCode.Text.Trim();                         //금형코드
            string sInspDate   = string.Format("{0:yyyy-MM-dd}", CboInspDate.Value);   //점검일자
            string sInspResult = DBHelper.nvlString(this.cboInspResult.Value);         //점검결과
            string sRemark     = this.txtRemark.Text.Trim();                           //비고
                      

              if (sPlantCode == "")
               {
                MessageBox.Show("사업장 정보를 입력하세요");
                return;
                }
            
               if (sPlanReqNo == "")
                {
                   MessageBox.Show("계획번호를 먼저 생성 하세요");
                   return;
               }
             
            try
            {
                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.UpdateData();
                //helper._sTran = helper._sConn.BeginTransaction();

               helper.ExecuteNoneQuery("USP_MD1100_I1N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)     // 공장(사업장)          
                                                        , helper.CreateParameter("PlanReqNo", sPlanReqNo, DbType.String, ParameterDirection.Input)     //점검계획번호
                                                        , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)       // 금형코드(금형 P/no(25) )    
                                                        , helper.CreateParameter("InspDate", sInspDate, DbType.String, ParameterDirection.Input)       // 점검일자  
                                                        , helper.CreateParameter("InspResult", sInspResult, DbType.String, ParameterDirection.Input)   // 점검결과 
                                                        , helper.CreateParameter("Remark", sRemark, DbType.String, ParameterDirection.Input));         // 비고            
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
            }
        }
        private void btnmake_Click(object sender, EventArgs e)
        {
      
            // 계획번호
            DBHelper helper = new DBHelper(false);

            string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value);  
            string TakingORDNo = string.Empty;
            string RS_CODE = string.Empty;
            string RS_MSG = string.Empty;

            if (sPlantCode == "")
            {
                MessageBox.Show("사업장 정보를 입력하세요");
                return;
            }
                

            this.grid1.UpdateData();
            //helper._sTran = helper._sConn.BeginTransaction();

            try
            {
                helper.ExecuteNoneQuery("USP_OutReqNoCreate_P2"
                                        , CommandType.StoredProcedure, ref RS_CODE, ref RS_MSG, ref TakingORDNo
                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input));


                //helper.Transaction.Commit();
                if (RS_CODE == "E") MessageBox.Show(RS_MSG);
                    txtPlanReqNo.Text = TakingORDNo.ToString();
            }

            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                 helper.Close();
            }

        }
 */

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (grid1.ActiveRow != null)
            {
                cboPlantCode.Value = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);
                this.txtPlanReqNo.Text = Convert.ToString(grid1.ActiveRow.Cells["PlanReqNo"].Value);
                txtMoldCode.Text = Convert.ToString(grid1.ActiveRow.Cells["MoldCode"].Value);
                txtMoldName.Text = Convert.ToString(grid1.ActiveRow.Cells["MoldName"].Value);
                cboInspResult.Value = Convert.ToString(grid1.ActiveRow.Cells["InspResult"].Value);
            }
        }
        //20140619추가 점검실적등록
        private void BtnMD1120_Click(object sender, EventArgs e)
        {
            bool isupdating = false;
            if (!this.grid1.IsUpdating)
            {
                this.grid1.BeginUpdate();
                isupdating = true;
            }
            int idx = this.grid1.ActiveRow == null ? 0 : this.grid1.ActiveRow.Index;

            // 행이 없을 경우 SKIP
            if (this.grid1.Rows.Count == 0)
            {
                if (isupdating) this.grid1.EndUpdate();

                this.IsShowDialog = false;
                this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                return;
            }

            if (!this.grid1.ActiveRow.Selected)
                this.grid1.ActiveRow.Selected = true;

            // 정보 넘김
            string PLANTCODE = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
            string MoldCode = this.grid1.ActiveRow.Cells["MoldCode"].Value.ToString();
            string MoldName = this.grid1.ActiveRow.Cells["MoldName"].Value.ToString();
            string ItemCode = this.grid1.ActiveRow.Cells["ItemCode"].Value.ToString();
            string ItemName = this.grid1.ActiveRow.Cells["ItemName"].Value.ToString();
            string PlanReqNo = this.grid1.ActiveRow.Cells["PlanReqNo"].Value.ToString();  //점검계획번호
            string InspDate = this.grid1.ActiveRow.Cells["InspDate"].Value.ToString();   //점검일자

            MD1120 BtnMD1120 = new MD1120(PLANTCODE, MoldCode, MoldName, ItemCode, ItemName, PlanReqNo, InspDate);

            BtnMD1120.ShowDialog();

            if (this.grid1.IsUpdating == true)
            {
                this.grid1.EndUpdate(); //화면 멈추는 현상 해결을 위한 추가부분
            }

        }

    }
}

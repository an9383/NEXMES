#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                                                                                             
//   Form ID      :  MD3000                                                                                                                                                                                                                                                    
//   Form Name    : 실사 지시 등록                                                                                                                                                                                                                                              
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

#endregion

namespace WIZ.MD
{
    public partial class MD3000 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        Common _Common = new Common();
        #endregion

        #region < CONSTRUCTOR >

        public MD3000()
        {
            InitializeComponent();

        }
        #endregion

        #region MD3000_Load
        private void MD3000_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingORDNo", "재고실사지시번호", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldLoc", "현보관장소", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingStartDate", "재고실사실 시작일", true, GridColDataType_emu.DateTime, 200, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingEndDate", "재고실사 완료일", true, GridColDataType_emu.DateTime, 200, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Status", "상태(진행, 완료)", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.DateTime, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", true, GridColDataType_emu.DateTime, 200, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion



            #region 콤보박스


            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //조회화면 사업장                                                                                                                                                                                                       
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MoldLoc");  //조회화면 현보관장소                                                                                                                                                                                                       
            WIZ.Common.FillComboboxMaster(this.cboMoldLoc_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //등록화면 사업장                                                                                                                                                                                                       
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("MoldLoc");  //등록화면 현보관장소                                                                                                                                                                                                       
            WIZ.Common.FillComboboxMaster(this.cboMoldLoc, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("Status");  //상태(진행, 완료) 
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "Status", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

        }
        #endregion  MD3000_Load

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

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);                  // 공장코드                                                                                                                                                                     
                string sTakingORDDate1 = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value);     // 일자 FROM                                                                                                                                                                    
                string sTakingORDDate2 = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);       // 일자 TO                                                                                                                                                                                                                                                                                                                                 
                string sMoldLoc = DBHelper.nvlString(this.cboMoldLoc_H.Value);                      // 보관장소                                                                                                                                                   

                grid1.DataSource = helper.FillTable("USP_MD3000_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)                        // 사업장 공장코드                                                                              
                                                                    , helper.CreateParameter("TakingORDDate1", sTakingORDDate1, DbType.String, ParameterDirection.Input)              // 일자 FROM                                                                                    
                                                                    , helper.CreateParameter("TakingORDDate2", sTakingORDDate2, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input));                          //보관장소                                                                        
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

                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.UpdateData();
                //helper.Transaction  =  helper._sConn.BeginTransaction();


                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_MD3000_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("TakingORDNo", drRow["TakingORDNo"].ToString(), DbType.String, ParameterDirection.Input)    // 재고실사지시번호                                                                   
                                                                    , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)        // 사업장(공장)                                                                       
                                                                    , helper.CreateParameter("MoldLoc", drRow["MoldLoc"].ToString(), DbType.String, ParameterDirection.Input));              // 지시작업장코드                                                                   
                            #endregion
                            break;
                        //    case DataRowState.Added:                                                                                                                                                                                                                               
                        //        #region 추가                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
                        //        #endregion                                                                                                                                                                                                                                         
                        //        break;                                                                                                                                                                                                                                             
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_MD3000_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("TakingORDNo", drRow["TakingORDNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MoldLoc", drRow["MoldLoc"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("TakingStartDate", drRow["TakingStartDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("TakingEndDate", drRow["TakingEndDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MakeDate", drRow["MakeDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }

                helper.Commit();
                DoInquire();

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region <EVENT AREA>
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
                //e.Command.Parameters["@Editor"].Value = this.WorkerID;                                                                                                                                                                                                       
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
                    e.Row.RowError = "데이터가 중복입니다.";
                    throw (new SException("S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion

        #region<EVNT>
        private void bntInsert_Click(object sender, EventArgs e)
        {
            DoInsert();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //등록화면 사업장                                                                                                                                                                                                       
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            rtnDtTemp = _Common.GET_BM0000_CODE("MoldLoc");  //등록화면 현보관장소                                                                                                                                                                                                       
            WIZ.Common.FillComboboxMaster(this.cboMoldLoc, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            txtOrderNo.Text = Convert.ToString(null);
        }

        private void DoInsert()
        {
            // 재고실사 등록 처리                                                                                                                                                                                                                                              
            DBHelper helper = new DBHelper(false);

            string sTakingORDNo = this.txtOrderNo.Text.Trim();                           // 재고실사지시번호  
            string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value);       // 공장코드     
            //     string sMakeDate = string.Format("{0:yyyy-MM-dd}", dtStart.Value);     // 재고실사 지시일자                                                                                                                                                                                                                                                                                                                                      
            string sMoldLoc = DBHelper.nvlString(this.cboMoldLoc.Value);      // 보관장소                                                                                                                                                                            

            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("사업장 정보를 입력하세요", "MSG"));
                return;
            }

            if (sMoldLoc == "")
            {
                MessageBox.Show(Common.getLangText("보관장소 정보를 입력하세요", "MSG"));
                return;
            }

            if (sTakingORDNo == "")
            {
                MessageBox.Show(Common.getLangText("지시번호를 먼저  생성 하세요", "MSG"));
                return;
            }

            try
            {
                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.UpdateData();

                helper.ExecuteNoneQuery("USP_MD3000_I1N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)              // 사업장                                                                                                       
                                                        , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)            //지시번호                                                                                                  
                                                        , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input));              //보관장소                                                                                         
                //   , helper.CreateParameter("MakeDate", sMakeDate, DbType.String, ParameterDirection.Input));       // 재고실사 지시일자  

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
            // 지시번호 생성                                                                                                                                                                                                                                                   
            DBHelper helper = new DBHelper(false);

            string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value);  // 공장코드                                                                                                                                                                                 
            string RS_CODE = string.Empty;
            string RS_MSG = string.Empty;
            string TakingORDNo = string.Empty;

            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("사업장 정보를 입력하세요", "MSG"));
                return;
            }

            this.grid1.UpdateData();
            try
            {
                helper.ExecuteNoneQuery("USP_OutReqNoCreate_P3"
                                       , CommandType.StoredProcedure, ref RS_CODE, ref RS_MSG, ref TakingORDNo
                                       , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input));


                //throw new Exception                                                                                                                                                                                                                                          
                if (RS_CODE == "E") MessageBox.Show(RS_MSG);
                txtOrderNo.Text = TakingORDNo.ToString();

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

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (grid1.ActiveRow != null)
            {
                cboPlantCode.Value = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);
                this.txtOrderNo.Text = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value);
            }
        }
        #endregion
    }
}
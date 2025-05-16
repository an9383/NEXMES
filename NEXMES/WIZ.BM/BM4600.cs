#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                                              
//   Form ID      : BM4600                                                                                                                                                                                                      
//   Form Name    : 설비보전 SMS 알림 관리                                                                                                                                                                                       
//   Name Space   : WIZ.BM                                                                                                                                                                                                    
//   Created Date :                                                                                                                                                                                                             
//   Made By      : WIZCORE                                                                                                                                                                           
//   Description  :                                                                                                                                                                                                             
// *---------------------------------------------------------------------------------------------*                                                                                                                              
#endregion

#region <USING AREA>

using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.BM
{
    public partial class BM4600 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>                                                                                                                             
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable _DtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >

        public BM4600()
        {
            InitializeComponent();
        }
        #endregion

        #region BM4600_Load
        private void BM4600_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            // InitColumnUltraGrid  90 113 105 112 147 80 80 163 98 121 98 121 

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장(사업장)", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkDate", "일자", false, GridColDataType_emu.YearMonthDay, 115, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DayNight", "주야", false, GridColDataType_emu.VarChar, 105, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerID", "작업자ID", false, GridColDataType_emu.VarChar, 112, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerName", "작업자명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DeptCode", "팀구분", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdManager", "생산담당자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachManager", "보전수신자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NightWorker", "야간근무자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EmpTelNo", "연락처", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion


            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("WorkerID", "WorkerName", "TBM0200", new string[] { "PlantCode", "", "", "", "" }); //2014.7.12 추가.

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장                                                                                                                                                        
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("DayNight");  //주야                                                                                                                                                   
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DayNight", rtnDtTemp, "CODE_ID", "CODE_NAME");  //주야                                                                                                                
            WIZ.Common.FillComboboxMaster(this.cboDayNight_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");  //예, 아니오                                                                                                                                                        
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ProdManager", rtnDtTemp, "CODE_ID", "CODE_NAME");  //생산담당자 여부                                                                                                                
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MachManager", rtnDtTemp, "CODE_ID", "CODE_NAME");  //보전수신자 여부                                                                                                 

            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");  //예, 아니오                                                                                                                                                        
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "NightWorker", rtnDtTemp, "CODE_ID", "CODE_NAME");  //야간 근무자                                                                                                                

            rtnDtTemp = _Common.GET_BM0000_CODE("DeptCode");  //부서2014.7.10 Lim yj                                                                                                                                                      

            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DeptCode", rtnDtTemp, "CODE_ID", "CODE_NAME");  //야간 근무자                                                                                                                


            #endregion

        }
        #endregion BM4600_Load

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

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);                                         // 사업장 공장코드  
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);                            // 일자 FROM
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);                                // 일자 TO                                                                                       
                string sDayNight = DBHelper.nvlString(cboDayNight_H.Value);                                           // 주.야 구분  


                grid1.DataSource = helper.FillTable("USP_BM4600_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("WorkDate_FROM", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("WorkDate_TO", sEndDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DayNight", sDayNight, DbType.String, ParameterDirection.Input));


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
                _GridUtil.AddRow(this.grid1);
                this.grid1.SetDefaultValue("PlantCode", "820");

                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");     // 사업장
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkDate");      // 일자
                UltraGridUtil.ActivationAllowEdit(this.grid1, "DayNight");      // 주야
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkerID");      // 작업자ID
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkerName");    // 작업자
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ProdManager");   // 생산담당자
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MachManager");   // 보전수신자
                UltraGridUtil.ActivationAllowEdit(this.grid1, "NightWorker");   // 야간수신자
                UltraGridUtil.ActivationAllowEdit(this.grid1, "EmpTelNo");      // 연락처                                                                                                                                                                                                                               

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
            DBHelper helper = new DBHelper("", true);


            try
            {

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                base.DoSave();


                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "공장(사업장) error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            //param = new System.Data.Common.DbParameter[6];

                            //param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input);         // 사업장코드                                                     
                            //param[1] = helper.CreateParameter("WorkDate", drRow["WorkDate"].ToString(), DbType.String, ParameterDirection.Input);           // 일자                                                     
                            //param[2] = helper.CreateParameter("DayNight", drRow["DayNight"].ToString(), DbType.String, ParameterDirection.Input);             // 주야                                                        
                            //param[3] = helper.CreateParameter("WorkerID", drRow["WorkerID"].ToString(), DbType.String, ParameterDirection.Input);             // 작업자ID                                                

                            //param[4] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[5] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            helper.ExecuteNoneQuery("USP_BM4600_D1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkDate", drRow["WorkDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DayNight", drRow["DayNight"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkerID", drRow["WorkerID"].ToString(), DbType.String, ParameterDirection.Input));

                            //if (param[4].Value.ToString() == "E") throw new Exception(param[5].Value.ToString());
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            //param = new System.Data.Common.DbParameter[12];
                            //param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input);      // 사업장                                                                      
                            //param[1] = helper.CreateParameter("WorkDate", drRow["WorkDate"].ToString(), DbType.String, ParameterDirection.Input);       // 일자                                        
                            //param[2] = helper.CreateParameter("DayNight", drRow["DayNight"].ToString(), DbType.String, ParameterDirection.Input);       // 주야                                          
                            //param[3] = helper.CreateParameter("WorkerID", drRow["WorkerID"].ToString(), DbType.String, ParameterDirection.Input);       // 작업자ID                                    
                            //param[4] = helper.CreateParameter("ProdManager", drRow["ProdManager"].ToString(), DbType.String, ParameterDirection.Input);    // 생산담당자                                    
                            //param[5] = helper.CreateParameter("MachManager", drRow["MachManager"].ToString(), DbType.String, ParameterDirection.Input);    // 보전수신자                                    
                            //param[6] = helper.CreateParameter("NightWorker", drRow["NightWorker"].ToString(), DbType.String, ParameterDirection.Input);    // 야간수신자                                    
                            //param[7] = helper.CreateParameter("EmpTelNo", drRow["EmpTelNo"].ToString(), DbType.String, ParameterDirection.Input);       // 연락처
                            //param[8] = helper.CreateParameter("Maker", drRow["Maker"].ToString(), DbType.String, ParameterDirection.Input);                 // 등록자                                                         
                            //param[9] = helper.CreateParameter("DeptCode", drRow["DeptCode"].ToString(), DbType.String, ParameterDirection.Input);        // 팀구분                                                    
                            //param[10] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[11] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            helper.ExecuteNoneQuery("USP_BM4600_I1", CommandType.StoredProcedure
                                                     , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("WorkDate", drRow["WorkDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("DayNight", drRow["DayNight"].ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("WorkerID", drRow["WorkerID"].ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("ProdManager", drRow["ProdManager"].ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("MachManager", drRow["MachManager"].ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("NightWorker", drRow["NightWorker"].ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("EmpTelNo", drRow["EmpTelNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("Maker", drRow["Maker"].ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("DeptCode", drRow["DeptCode"].ToString(), DbType.String, ParameterDirection.Input));

                            //if (param[10].Value.ToString() == "E") throw new Exception(param[11].Value.ToString()); 
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            //param = new System.Data.Common.DbParameter[12];
                            //param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input);      // 사업장                                                                       
                            //param[1] = helper.CreateParameter("WorkDate", drRow["WorkDate"].ToString(), DbType.String, ParameterDirection.Input);       // 일자                                        
                            //param[2] = helper.CreateParameter("DayNight", drRow["DayNight"].ToString(), DbType.String, ParameterDirection.Input);       // 주야                                          
                            //param[3] = helper.CreateParameter("WorkerID", drRow["WorkerID"].ToString(), DbType.String, ParameterDirection.Input);       // 작업자ID                                    
                            //param[4] = helper.CreateParameter("ProdManager", drRow["ProdManager"].ToString(), DbType.String, ParameterDirection.Input);    // 생산담당자                                    
                            //param[5] = helper.CreateParameter("MachManager", drRow["MachManager"].ToString(), DbType.String, ParameterDirection.Input);    // 보전수신자 
                            //param[6] = helper.CreateParameter("NightWorker", drRow["NightWorker"].ToString(), DbType.String, ParameterDirection.Input);    // 야간수신자                                           
                            //param[7] = helper.CreateParameter("EmpTelNo", drRow["EmpTelNo"].ToString(), DbType.String, ParameterDirection.Input);       // 연락처                                                      
                            //param[8] = helper.CreateParameter("Editor", drRow["Maker"].ToString(), DbType.String, ParameterDirection.Input);                // 등록자                                                          
                            //param[9] = helper.CreateParameter("DeptCode", drRow["DeptCode"].ToString(), DbType.String, ParameterDirection.Input);                 // 팀구분                                                    
                            //param[10] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[11] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            helper.ExecuteNoneQuery("USP_BM4600_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkDate", drRow["WorkDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DayNight", drRow["DayNight"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkerID", drRow["WorkerID"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ProdManager", drRow["ProdManager"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MachManager", drRow["MachManager"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("NightWorker", drRow["NightWorker"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("EmpTelNo", drRow["EmpTelNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DeptCode", drRow["DeptCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Editor", drRow["Maker"].ToString(), DbType.String, ParameterDirection.Input));

                            //if (param[10].Value.ToString() == "E") throw new Exception(param[11].Value.ToString());

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
                    e.Row.RowError = "데이터가 중복입니다.";
                    throw (new SException("C:S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의     
        #region grid POP UP 처리
        private void grid_POP_UP()
        {
            int iRow = this.grid1.ActiveRow.Index;
            string sPlantCode = Convert.ToString(this.grid1.Rows[iRow].Cells["PlantCode"].Value);  // 사업부 

            string sOPCode = "";            // 공정 코드
            string sLineCode = "";            // 라인 코드
            string sWorkCenterCode = "";            // 작업장 코드                                                                                                             

            string sWorkerID = this.grid1.Rows[iRow].Cells["WorkerID"].Text.Trim();      // 작업자ID                                                                                                                               
            string sWorkerName = this.grid1.Rows[iRow].Cells["WorkerName"].Text.Trim();  // 작업자                                                                                                                                 
            string sUseFlag = "";                    // 사용여부                                                                                                                                                                                                                                                                                                                                             


            if (this.grid1.ActiveCell.Column.ToString() == "WorkerID" || this.grid1.ActiveCell.Column.ToString() == "WorkerName")
            {
                PopUp_Biz _biz = new PopUp_Biz();
                //_biz.TBM0200_POP_Grid(sPlantCode, sOPCode, sLineCode, sWorkCenterCode, sWorkerID, sWorkerName, sUseFlag, grid1, "WorkerID", "WorkerName");
            }

            string sEmpTelNo = this.grid1.Rows[iRow].Cells["EmpTelNo"].Text.Trim();      // 연락처                                                                                                                               
            string sWorkerIDNew = this.grid1.Rows[iRow].Cells["WorkerID"].Text.Trim();      // 작업자ID                                                                                                                               


            if (sWorkerIDNew != sWorkerID)
            {

                _DtTemp = GET_TBM0200_EmpTelNo(sWorkerIDNew);

                if (_DtTemp.Rows.Count > 0)
                {
                    grid1.Rows[iRow].Cells["EmpTelNo"].Value = Convert.ToString(_DtTemp.Rows[0]["EmpTelNo"]); //Convert.ToString(DtTemp.Rows[0]["WorkerID"]);
                }
                else
                {
                    grid1.Rows[iRow].Cells["EmpTelNo"].Value = string.Empty;
                }
            }

        }
        private void grid1_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            grid_POP_UP();
        }

        private void grid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                grid_POP_UP();
            }

        }


        #endregion  //grid POP-UP 처리
        #endregion

        #region<GET_TBM0200_EmpTelN>
        private DataTable GET_TBM0200_EmpTelNo(string sWorkID)
        {
            DBHelper helper = new DBHelper(false);
            System.Data.Common.DbParameter[] param = new System.Data.Common.DbParameter[1];
            StringBuilder query = null;

            try
            {
                query = new StringBuilder();
                query.Remove(0, query.Length);

                query.AppendLine(" select EmpTelNo from TBM0200 where WorkerID   = @WorkerID ");

                param[0] = helper.CreateParameter("@WorkerID", sWorkID, DbType.String, ParameterDirection.Input);

                rtnDtTemp = helper.FillTable(Convert.ToString(query), CommandType.Text, param);

                return rtnDtTemp;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                helper.Close();
                if (param != null) { param = null; }
                if (query != null) { query = null; }
            }
        }
        #endregion
    }
}


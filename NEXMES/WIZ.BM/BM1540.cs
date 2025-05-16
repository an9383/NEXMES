#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                   
//   Form ID      : BM1540                                                                                                                                                                           
//   Form Name    : 완성품검사항목명 관리                                                                                                                                                              
//   Name Space   : WIZ.BM                                                                                                                                                                         
//   Created Date : 2014-07-14                                                                                                                                                                       
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

namespace WIZ.BM
{
    public partial class BM1540 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통                                                                                                                                                                                                                                                                                                    
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >
        public BM1540()
        {
            InitializeComponent();

            //팝업 관리                                                                                                                                                                              



            //   - 1 : MachCode, 2 : MachName, param[0] : MachType, param[1] : MachType1                                                                                                             
            //btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, txtOPCode, "", "" }); //라인 팝업                                                  
            //gridManager.PopUpAdd("ToolCode2", "ToolName2", "TTO0100_GetData", new string[] { "PlantCode", "", "", "", "N" }, new string[] { "ToolSeq2|Seq" });                                     
        }
        #endregion

        #region 폼 초기화

        private void BM1540_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid                                                                                                                                                                   
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType                                                                                                                      
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString,                                                                                                     
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern                                                                                                                            

            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "검사항목코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "검사항목", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDesc", "검사항목상세", false, GridColDataType_emu.VarChar, 150, 500, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspType", "검사대상", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitType", "단위종류", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("InspType");     // 검사대상                                                                                                                        
            WIZ.Common.FillComboboxMaster(this.cboInspType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0130_CODE_1("I", "Y");  // 검사단위 2014.7.22 추가
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부                                                                                                                          
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion

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
                string insptype = DBHelper.nvlString(this.cboInspType_H.Value);
                string useflag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                grid1.DataSource = helper.FillTable("USP_BM1540_S2"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("INSPTYPE", insptype, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG", useflag, DbType.String, ParameterDirection.Input));


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

                if (grid1.IsActivate)
                {

                    _GridUtil.AddRow(this.grid1);
                    //this.grid1.SetDefaultValue("PlantCode", "SY");

                    UltraGridUtil.ActivationAllowEdit(grid1, "InspCode");
                    UltraGridUtil.ActivationAllowEdit(grid1, "InspName");
                    UltraGridUtil.ActivationAllowEdit(grid1, "InspDesc");
                    UltraGridUtil.ActivationAllowEdit(grid1, "InspType");
                    UltraGridUtil.ActivationAllowEdit(grid1, "UnitCode");
                    UltraGridUtil.ActivationAllowEdit(grid1, "UseFlag");
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
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
            Grid1ToolAct();
        }
        #endregion

        #region<Grid1ToolAct>
        private void Grid1ToolAct()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);

            try
            {
                this.Focus();
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }
                base.DoSave();


                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["InspCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "지시번호 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();



                            helper.ExecuteNoneQuery("USP_BM1540_D2"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM1540_I2"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("InspCode", Convert.ToString(drRow["InspCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspName", Convert.ToString(drRow["InspName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspDesc", Convert.ToString(drRow["InspDesc"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspType", Convert.ToString(drRow["InspType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UnitCode", Convert.ToString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM1540_U2"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("InspCode", Convert.ToString(drRow["InspCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspName", Convert.ToString(drRow["InspName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspDesc", Convert.ToString(drRow["InspDesc"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspType", Convert.ToString(drRow["InspType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UnitCode", Convert.ToString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("InspCode");
                helper.Commit();

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

        #region < EVENT AREA >

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
                e.Command.Parameters["@Editor"].Value = this.WorkerID;
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
                    e.Row.RowError = "이미 정보가 존재합니다.";
                    throw (new SException("S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의                                                                                                                                                      
        // Form에서 사용할 함수나 메소드를 정의                                                                                                                                                      

        #endregion
    }
}








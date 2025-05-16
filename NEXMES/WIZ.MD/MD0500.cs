#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD0500 
//   Form Name    : 금형입고(수동)
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
    public partial class MD0500 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >

        public MD0500()
        {
            InitializeComponent();
            //pop up 화면(gird POP-UP)
            BizGridManager bizGrid = new BizGridManager(grid1);
            bizGrid.PopUpAdd("MoldCode", "MoldName", "TBM1600", new string[] { "PlantCode", "" });             //금형 POP_UP grid

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMoldCode_H, txtMoldName_H, "TBM1600", new object[] { cboPlantCode_H, "" }); //금형
            //등록용 POP 
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "TBM1600", new object[] { cboPlantCode_H, "" });     //금형

        }
        #endregion

        #region  MD0500_Load
        private void MD0500_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅

            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InDate", "입고일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Moldname", "금형명", false, GridColDataType_emu.VarChar, 160, 160, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldInType", "입고구분", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldLoc", "보관장소", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InStamp", "입고일시", true, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InWorker", "입고자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProcFlag", "재고반영", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "참조", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();

            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            //사업장(조회)
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //사업장(등록)
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //지정장소(등록)
            rtnDtTemp = _Common.GET_BM0000_CODE("MoldLoc");
            WIZ.Common.FillComboboxMaster(this.cboMoldLoc, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //입고구분(등록)
            rtnDtTemp = _Common.GET_BM0000_CODE("MoldInType");
            WIZ.Common.FillComboboxMaster(this.cboMoldInType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", ""); ;
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldInType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //반영여부  2014.6.25 임영조 추가
            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ProcFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

        }
        #endregion  MD0500_Load

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

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);                   //사업장 공장코드
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);           //시작일자                                                                                                                           
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);             //종료일자                                                                                                                                                        
                string sMoldCode = this.txtMoldCode_H.Text.Trim();                                  //금형코드 

                grid1.DataSource = helper.FillTable("USP_MD0500_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)    // 사업장 공장코드 
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)    // 일자 FROM    
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)        // 일자 TO 
                                                                   , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input));    // 금형코드
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
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper(false);

            try
            {
                this.Focus();
                base.DoSave();
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PLANTCODE"].ToString().Trim() == "")
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

                            helper.ExecuteNoneQuery("USP_MD0500_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)      // 사업장 공장코드       
                            , helper.CreateParameter("InDate", drRow["InDate"].ToString(), DbType.String, ParameterDirection.Input)         // 입고일         
                            , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input));     //금형코드(금형 P/no(25) )  

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_MD0500_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)    // 사업장 공장코드  
                            , helper.CreateParameter("InDate", drRow["InDate"].ToString(), DbType.String, ParameterDirection.Input)       // 입고일시    
                            , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)     // 금형코드       
                            , helper.CreateParameter("MoldLoc", drRow["MoldLoc"].ToString(), DbType.String, ParameterDirection.Input)      // 현보관장소
                            , helper.CreateParameter("MoldInType", drRow["MoldInType"].ToString(), DbType.String, ParameterDirection.Input)   // 금형입고구분  
                            , helper.CreateParameter("InStamp", drRow["InStamp"].ToString(), DbType.String, ParameterDirection.Input)      // 입고일시  
                            , helper.CreateParameter("InWorker", drRow["InWorker"].ToString(), DbType.String, ParameterDirection.Input)     // 입고자
                            , helper.CreateParameter("Maker ", this.WorkerID, DbType.String, ParameterDirection.Input)                    // 등록자
                            , helper.CreateParameter("MakeDate", drRow["MakeDate"].ToString(), DbType.String, ParameterDirection.Input)     // 등록일자
                            , helper.CreateParameter("ProcFlag", drRow["ProcFlag"].ToString(), DbType.String, ParameterDirection.Input)     // 반영 여부(ERP I/F TABLE등)  
                            , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input));     // Remark

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PLANTCODE");
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
                DoInquire();
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
            if (e.Row.RowState == DataRowState.Modified)
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

        #region<DoInsert>

        private void bntInsert_Click(object sender, EventArgs e)
        {
            DoInsert();
        }

        private void DoInsert()
        {
            // 금형입고(수동) 등록 처리
            DBHelper helper = new DBHelper(false);

            string sPlantCode = Convert.ToString(cboPlantCode.Value);             // 사업장 
            string sInDate = string.Format("{0:yyyy-MM-dd}", CboIndate.Value); // 입고일
            string sMoldInType = Convert.ToString(cboMoldInType_H.Value);          // 입고구분 
            string sMoldCode = this.txtMoldCode.Text.Trim();                     // 금형코드 
            string sMoldLoc = Convert.ToString(cboMoldLoc.Value);             // 지정장소
            string sRemark = this.txtRemark.Text.Trim();                       // remark  

            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("사업장 정보를 입력하세요", "MSG"));
                return;
            }

            try
            {

                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.UpdateData();

                helper.ExecuteNoneQuery("USP_MD0500_I2", CommandType.StoredProcedure
                                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)   // 공장코드    
                                                        , helper.CreateParameter("InDate", sInDate, DbType.String, ParameterDirection.Input)      // 입고일         
                                                        , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)    // 금형코드            
                                                        , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)     // 현보관장소    
                                                        , helper.CreateParameter("MoldInType", sMoldInType, DbType.String, ParameterDirection.Input)  // 금형입고구분         
                                                        , helper.CreateParameter("InStamp", sInDate, DbType.DateTime, ParameterDirection.Input)    // 입고일시            
                                                        , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input) // 등록자 
                                                        , helper.CreateParameter("Remark", sRemark, DbType.String, ParameterDirection.Input));     // 참조  

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
    }
}

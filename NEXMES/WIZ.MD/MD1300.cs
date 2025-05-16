#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  MD1300
//   Form Name    : 수리/보수 결과 등록
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
    public partial class MD1300 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        Common _Common = new Common();
        #endregion

        #region < CONSTRUCTOR >

        public MD1300()
        {
            InitializeComponent();
        }
        #endregion

        #region  MD1300_Load
        private void MD1300_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            // InitColumnUltraGrid 90 187 90 165 165 165 100 165 165 165 165 100 90 90 90 90  
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldName", "금형명", true, GridColDataType_emu.VarChar, 165, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 165, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", true, GridColDataType_emu.VarChar, 165, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldRepSeqNo", "수리차수", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepDate", "수리일자", true, GridColDataType_emu.YearMonthDay, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepType", "수리유형", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepBefShoot", "수리전타수", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepDesc", "수리내역", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepWoker", "수리작업자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepResult", "수리결과", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepCustCode", "수리업체", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "업체명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepReqNo", "수리의뢰번호", true, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepairReqDate", "수리의뢰일", true, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion
            #region pop up


            ////조회용 POP 
            //팝업 매니저
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "TBM1600", new object[] { cboPlantCode, "" });      //금형
            btbManager.PopUpAdd(txtMoldCode_H, txtMoldName_H, "TBM1600", new object[] { cboPlantCode_H, "" });  //금형
            btbManager.PopUpAdd(txtRepCustCode, txtCustName, "TBM0300", new object[] { cboPlantCode, "" });                    //수리업체
            btbManager.PopUpAdd(txtRepReqNo, txtRepairReqDate, "TMD1200", new object[] { cboPlantCode, txtMoldCode });                    //수리업체
            #endregion
            #region 콤보박스


            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("PLANTCODE");  //사업장
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("RepType");  // 등록용 수리유형
            WIZ.Common.FillComboboxMaster(this.cboRepType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "RepType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("RepResult");  //등록용 수리 결과
            WIZ.Common.FillComboboxMaster(this.cboRepResult, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "RepResult", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

        }
        #endregion  MD1300_Load

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
                string sMoldCode = txtMoldCode_H.Text;                                         //금형코드
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value);     // 일자 FROM                                                                                                                                                                    
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);         // 일자 TO     


                grid1.DataSource = helper.FillTable("USP_MD1300_S3", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)         // 사업장 공장코드    
                                                                   , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)           // 금형   
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)         // 일자 FROM          
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input));           // 일자 TO            


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

                            helper.ExecuteNoneQuery("USP_MD1300_D3", CommandType.StoredProcedure
                                                   , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)                 // 사업장(공장)    
                                                   , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)                  // 금형코드
                                                   , helper.CreateParameter("MoldRepSeqNo", drRow["MoldRepSeqNo"].ToString(), DbType.String, ParameterDirection.Input)        // 수리순번 
                                                   , helper.CreateParameter("RepReqNo", drRow["RepReqNo"].ToString(), DbType.String, ParameterDirection.Input));        // 수리순번 

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가


                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

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
                this.ShowDialog(ex.ToString());
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
        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> /*
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
        private void DoInsert()
        {
            // 등록처리
            DBHelper helper = new DBHelper(false);

            string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value);                   // 사업장 
            string sMoldCode = txtMoldCode.Text.Trim();                                        // 금형코드  
            string sMoldRepSeqNo = txtMoldRepSeqNo.Text;                                       // 차수
            string sRepDate = string.Format("{0:yyyy-MM-dd}", dtStart.Value);                  // 수리일자
            string sRepType = DBHelper.nvlString(this.cboRepType.Value);                       // 수리유형
            string sRepDesc = txtRepDesc.Text.Trim();                                          // 수리내역 
            string sRepResult = DBHelper.nvlString(this.cboRepResult.Value);                   // 수리결과
            string sRepReqNo = txtRepReqNo.Text.Trim();                                        // 수리의뢰번호
            string sRepCustCode = txtRepCustCode.Text.Trim();                                  // 수리업체 


            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("사업장 정보를 입력하세요", "MSG"));
                return;
            }
            if (sMoldCode == "")   // 금형 정보 )
            {
                MessageBox.Show(Common.getLangText("금형 정보를 입력하세요", "MSG"));
                return;
            }

            if (sRepDate == "")   // 금형 정보 )
            {
                MessageBox.Show(Common.getLangText("수리 일자를 입력하세요", "MSG"));
                return;
            }

            try
            {
                //    UltraGridUtil.DataRowDelete(this.grid1);
                //    this.grid1.UpdateData();
                // helper._sTran = helper._sConn.BeginTransaction();

                helper.ExecuteNoneQuery("USP_MD1300_I3", CommandType.StoredProcedure
                                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MoldRepSeqNo", sMoldRepSeqNo, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("RepDate", sRepDate, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("RepType", sRepType, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("RepDesc", sRepDesc, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("RepWoker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("RepResult", sRepResult, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("RepCustCode", sRepCustCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("RepReqNo", sRepReqNo, DbType.String, ParameterDirection.Input));

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
                //  DoInquire(); //재조회 처리
            }
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (grid1.ActiveRow != null)
            {
                txtMoldRepSeqNo.Text = Convert.ToString(grid1.ActiveRow.Cells["MoldRepSeqNo"].Value);
                txtRepReqNo.Text = Convert.ToString(grid1.ActiveRow.Cells["RepReqNo"].Value);
                txtMoldCode.Text = Convert.ToString(grid1.ActiveRow.Cells["MoldCode"].Value);
                txtMoldName.Text = Convert.ToString(grid1.ActiveRow.Cells["MoldName"].Value);
                dtStart.Text = Convert.ToString(grid1.ActiveRow.Cells["RepDate"].Value);
                cboRepType.Text = Convert.ToString(grid1.ActiveRow.Cells["RepType"].Value);
                cboPlantCode.Text = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                cboRepResult.Text = Convert.ToString(grid1.ActiveRow.Cells["RepResult"].Value);
                txtRepCustCode.Text = Convert.ToString(grid1.ActiveRow.Cells["RepCustCode"].Value);
                txtRepDesc.Text = Convert.ToString(grid1.ActiveRow.Cells["RepDesc"].Value);
                txtCustName.Text = Convert.ToString(grid1.ActiveRow.Cells["CustName"].Value);

            }
        }

        private void bntInsert_Click(object sender, EventArgs e)
        {
            DoInsert();

            /////등록화면 초기화//////
            txtMoldCode.Text = Convert.ToString(null);
            txtMoldName.Text = Convert.ToString(null);
            txtRepReqNo.Text = Convert.ToString(null);
            txtRepDesc.Text = Convert.ToString(null);
            txtRepCustCode.Text = Convert.ToString(null);
            txtCustName.Text = Convert.ToString(null);
            txtMoldRepSeqNo.Text = Convert.ToString(null);
            txtRepairReqDate.Text = Convert.ToString(null);

            rtnDtTemp = _Common.GET_BM0000_CODE("RepType");  // 등록용 수리유형 초기화
            WIZ.Common.FillComboboxMaster(this.cboRepType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("RepResult");  //등록용 수리 결과 초기화
            WIZ.Common.FillComboboxMaster(this.cboRepResult, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

        }

        private void bntInitializ_Click(object sender, EventArgs e)
        {
            /////등록화면 초기화//////
            txtMoldCode.Text = Convert.ToString(null);
            txtMoldName.Text = Convert.ToString(null);
            txtRepReqNo.Text = Convert.ToString(null);
            txtRepDesc.Text = Convert.ToString(null);
            txtRepCustCode.Text = Convert.ToString(null);
            txtCustName.Text = Convert.ToString(null);
            txtMoldRepSeqNo.Text = Convert.ToString(null);
            txtRepairReqDate.Text = Convert.ToString(null);

            rtnDtTemp = _Common.GET_BM0000_CODE("RepType");  // 등록용 수리유형 초기화
            WIZ.Common.FillComboboxMaster(this.cboRepType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("RepResult");  //등록용 수리 결과 초기화
            WIZ.Common.FillComboboxMaster(this.cboRepResult, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

        }
        #endregion
    }
}

#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD0600 
//   Form Name    : 금형출고(수동)
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
    public partial class MD0600 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        #endregion

        #region < CONSTRUCTOR >

        public MD0600()
        {
            InitializeComponent();
            //pop up 화면(gird POP-UP)
            BizGridManager bizGrid = new BizGridManager(grid1);
            bizGrid.PopUpAdd("MoldCode", "MoldName", "TBM1600", new string[] { "PlantCode", "" }); //금형 POP_UP grid
            string sUseFlag = string.Empty;
            string sLineCode = string.Empty;
            string sOPCode = string.Empty;

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMoldCode_H, txtMoldName_H, "TBM1600", new object[] { cboPlantCode_H, "" });                //금형(조회)
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "TBM1600", new object[] { cboPlantCode_H, "" });                    //금형(등록)
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, sOPCode, sLineCode, sUseFlag });

            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { cboPlantCode_H, "" });                    //불출업체
            btbManager.PopUpAdd(txtOutReqNo, txtOutReqDate, "TMD0200", new object[] { cboPlantCode, cboOutReqType, txtMoldCode });

        }
        #endregion

        #region  MD0600_Load
        private void MD0600_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
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


            #region 콤보박스

            //사업장(조회)
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //사업장(등록)
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            //출고구분
            rtnDtTemp = _Common.GET_BM0000_CODE("OutReqType");
            WIZ.Common.FillComboboxMaster(this.cboOutReqType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutReqType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //불출장소(등록)
            rtnDtTemp = _Common.GET_BM0000_CODE("MoldLoc");
            WIZ.Common.FillComboboxMaster(this.cboMoldLoc, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FromMoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");
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

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);             // 공장코드     
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value);     // 일자 FROM                                                                                                                                                                    
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);         // 일자 TO                                                                                                     
                string sMoldCode = this.txtMoldCode_H.Text.Trim();                             // 금형코드     

                grid1.DataSource = helper.FillTable("USP_MD0600_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)     //사업장 공장코드    
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)     //일자 FROM          
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)         //일자 TO            
                                                                   , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input));     //금형코드           
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
                this.txtOutReqNo.Focus();
                base.DoSave();
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

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
                            helper.ExecuteNoneQuery("USP_MD0600_D1", CommandType.StoredProcedure
                          , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)      // 사업장 공장코드    
                          , helper.CreateParameter("OutDate", Convert.ToDateTime(drRow["OutDate"]), DbType.String, ParameterDirection.Input)        // 출고(투입)일자               
                          , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input));     // 금형코드(금형 P/no(25) )         

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            //  helper.ExecuteNoneQuery("USP_MD0600_U1", CommandType.StoredProcedure
                            //, helper.CreateParameter("PLANTCODE"       , drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)         // 사업장 공장코드    
                            //, helper.CreateParameter("OutDate"         , drRow["OutDate"].ToString(), DbType.String, ParameterDirection.Input)           //출고(투입)일자   
                            //, helper.CreateParameter("MoldCode"        , drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)          // 금형코드(금형 P/no(25) )   
                            //, helper.CreateParameter("OutReqType"      , drRow["OutReqType"].ToString(), DbType.String, ParameterDirection.Input)        // 출고구분   
                            //, helper.CreateParameter("OutReqNo"        , drRow["OutReqNo"].ToString(), DbType.String, ParameterDirection.Input)          // 출고의뢰번호 
                            //, helper.CreateParameter("InWorkCenterCode", drRow["InWorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input)  // 투입작업장  
                            //, helper.CreateParameter("CustCode"        , drRow["CustCode"].ToString(), DbType.String, ParameterDirection.Input)          // 불출업체코드  
                            //, helper.CreateParameter("Remark"          , drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input));          //  출고관련사항(비고)                 

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

        #region<Event>
        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtCustName.Text = string.Empty;
        }

        private void txtCustName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtCustCode.Text = string.Empty;
        }

        private void txtCustCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0300();
            }
        }

        private void txtCustCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0300();
        }

        private void txtCustName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCustName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0300();
        }

        private void bntInitialize_Click(object sender, EventArgs e)
        {
            //입력값초기화
            cboPlantCode.Value = "";
            cboOutReqType.Value = "";
            cboMoldLoc.Value = "";
            txtMoldCode.Text = "";
            txtMoldName.Text = "";
            txtOutReqNo.Text = "";
            txtWorkCenterName.Text = "";
            txtWorkCenterCode.Text = "";
            txtWorkCenterName.Text = "";
            txtCustCode.Text = "";
            txtCustName.Text = "";
            txtRemark.Text = "";
        }

        private void bntInsert_Click(object sender, EventArgs e)
        {
            DoInsert();
            //DoInquire();
        }

        private void DoInsert()
        {
            //금형불출(수동) 등록 처리
            DBHelper helper = new DBHelper(false);

            string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value);                //사업장 
            string sOutDate = string.Format("{0:yyyy-MM-dd hh:mm:dd}", CboOutDate.Value);    //출고일
            string sMoldCode = this.txtMoldCode.Text.Trim();                                 //금형코드 
            string sOutReqType = DBHelper.nvlString(this.cboOutReqType.Value);               //출고구분 
            string sOutReqNo = this.txtOutReqNo.Text.Trim();                                //출고의뢰번호
            string sInWorkCenterCode = this.txtWorkCenterCode.Text.Trim();                   //투입작업장     
            string sCustCode = this.txtCustCode.Text.Trim();                                 //불출업체
            string sRemark = this.txtRemark.Text.Trim();                                  //remark  
            string sMoldLoc = DBHelper.nvlString(this.cboMoldLoc.Value);                    //출고위치


            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("사업장 정보를 입력하세요", "MSG"));
                return;
            }


            try
            {

                UltraGridUtil.DataRowDelete(this.grid1);

                this.grid1.UpdateData();

                helper.ExecuteNoneQuery("USP_MD0600_I3", CommandType.StoredProcedure
                                                       , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)     // 공장(사업장)          
                                                       , helper.CreateParameter("OutDate", sOutDate, DbType.String, ParameterDirection.Input)       // 출고(투입)일자            
                                                       , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)      // 출고구분          
                                                       , helper.CreateParameter("OutReqType", sOutReqType, DbType.String, ParameterDirection.Input)    // 금형코드(금형 P/no(25) )    
                                                       , helper.CreateParameter("OutReqNo", sOutReqNo, DbType.String, ParameterDirection.Input)      // 출고의뢰번호
                                                       , helper.CreateParameter("InWorkCenterCode", sInWorkCenterCode, DbType.String, ParameterDirection.Input)    //투입작업장 
                                                       , helper.CreateParameter("CustCode", sCustCode, DbType.String, ParameterDirection.Input)      // 불출업체코드              
                                                       , helper.CreateParameter("Remark", sRemark, DbType.String, ParameterDirection.Input)       // 출고관련 사항(비고)           
                                                       , helper.CreateParameter("OutWorker", this.WorkerID, DbType.String, ParameterDirection.Input)        // 출고자          
                                                       , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input));      //이동위치         

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
                //입력값초기화
                cboPlantCode.Value = "";
                cboOutReqType.Value = "";
                cboMoldLoc.Value = "";
                txtMoldCode.Text = "";
                txtMoldName.Text = "";
                txtOutReqNo.Text = "";
                txtOutReqDate.Text = "";
                txtWorkCenterCode.Text = "";
                txtWorkCenterName.Text = "";
                txtCustCode.Text = "";
                txtCustName.Text = "";
                txtRemark.Text = "";
            }
        }

        /*
         private void btnmake_Click(object sender, EventArgs e)
         {
             // 지시번호생성
             DBHelper helper = new DBHelper(false);

             string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value);  
             string TakingORDNo = string.Empty;
             string RS_CODE = string.Empty;
             string RS_MSG = string.Empty;
          

             this.grid1.UpdateData();
            
             try
             {
                 //helper.ExecuteNoneQuery("USP_OutReqNoCreate_P1"
                   helper.ExecuteNoneQuery("USP_ORDNoCreate_P1"
                                         , CommandType.StoredProcedure, ref RS_CODE, ref RS_MSG, ref TakingORDNo
                                         , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input));


                 //helper.Transaction.Commit();
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
                 //if (helper._sConn != null) { helper._sConn.Close(); }
                 helper.Close();
             }

         }
      */
        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (grid1.ActiveRow != null)
            {
                cboPlantCode.Value = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);  //공장코드
                this.txtMoldCode.Text = Convert.ToString(grid1.ActiveRow.Cells["MoldCode"].Value);   //금형코드
                this.txtMoldName.Text = Convert.ToString(grid1.ActiveRow.Cells["MoldName"].Value);   //금형이름
                cboOutReqType.Value = Convert.ToString(grid1.ActiveRow.Cells["OutReqType"].Value); //출고구분
                this.txtOutReqNo.Text = Convert.ToString(grid1.ActiveRow.Cells["OutReqNo"].Value);   //출고의뢰번호
                cboMoldLoc.Value = Convert.ToString(grid1.ActiveRow.Cells["MoldLoc"].Value);         //출고위치
                CboOutDate.Value = Convert.ToDateTime(grid1.ActiveRow.Cells["OutDate"].Value);
            }
        }


        #region  업체 찾기(조회조전)
        private void Search_Pop_TBM0300()
        {
            //비지니스 로직 객체 생성
            PopUp_Biz _biz = new PopUp_Biz();
            string sCustCode = txtCustCode.Text.Trim();   //업체코드
            string sCustName = txtCustName.Text.Trim();   //업체명 
            string sCustType = "V";                       //업체구분(V=Vendor) 
            string sUseFlag = "Y";                       //사용여부         

            try
            {
                _biz.BM0030_POP(sCustCode, sCustName, "", sCustType, sUseFlag, "", txtCustCode, txtCustName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion  업체 찾기(조회조전)
        #endregion
    }
}

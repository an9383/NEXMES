#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  WM3000
//   Form Name    : 재고실사지시
//   Name Space   : WIZ.WM
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

namespace WIZ.WM
{
    public partial class WM3000 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        #endregion

        #region < CONSTRUCTOR >

        public WM3000()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtWHCode, txtWHName, "TBM0800", new object[] { cboPlantCode_H, "", "", "", "" });
        }
        #endregion

        #region  WM3000_Load
        private void WM3000_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅

            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            // InitColumnUltraGrid 90 175 103 165 165 165 100 165 165 165 200 165 165 100 90 90 90 90 
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingORDNo", "지시번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingORDDate", "지시일자", false, GridColDataType_emu.YearMonthDay, 165, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingORDRemark", "재고실사사유", false, GridColDataType_emu.VarChar, 165, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingStartDate", "실사 시작일", false, GridColDataType_emu.YearMonthDay, 165, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingEndDate", "실사완료일", false, GridColDataType_emu.YearMonthDay, 165, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCode", "지시창고", false, GridColDataType_emu.VarChar, 165, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHName", "장고명", false, GridColDataType_emu.VarChar, 165, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 165, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingStartDate1", "실 시작일", false, GridColDataType_emu.YearMonthDay, 165, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingEndDate1", "실 완료일", false, GridColDataType_emu.YearMonthDay, 165, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Status", "진행상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("Status");      //진행상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "Status", rtnDtTemp, "CODE_ID", "CODE_NAME");     // 진행상태 
            WIZ.Common.FillComboboxMaster(this.cboStatus_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");  //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboUseFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");     //사용여부

            #endregion

        }
        #endregion  WM3000_Load

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
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                                     // 공장코드     
                string sTakingORDDate1 = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);                      // 일자 FROM
                string sTakingORDDate2 = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);                        // 일자 TO                                                                                       
                string sStatus = Convert.ToString(cboStatus_H.Value);                                           // 상태(진행, 완료 )     
                string sUseFlag = Convert.ToString(cboUseFlag_H.Value);                                         // 사용여부     

                grid1.DataSource = helper.FillTable("USP_WM3000_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                        // 사업장 공장코드    
                                                                    , helper.CreateParameter("TakingORDDate_FROM", sTakingORDDate1, DbType.String, ParameterDirection.Input)          // 일자 FROM          
                                                                    , helper.CreateParameter("TakingORDDate_TO", sTakingORDDate2, DbType.String, ParameterDirection.Input)            // 일자 TO            
                                                                    , helper.CreateParameter("Status", sStatus, DbType.String, ParameterDirection.Input)                              // 상태(진행, 완료 )           
                                                                    , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));                          // 사용여부 
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
            if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                return;

            DBHelper helper = new DBHelper("", true);

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
                        if (drRow["PlanNo"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "계획번호 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_WM3000_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("TakingORDNo", drRow["TakingORDNo"].ToString(), DbType.String, ParameterDirection.Input)    // 재고실사지시번호 
                                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)        // 사업장(공장)     
                                                                    , helper.CreateParameter("WHCode", drRow["WHCode"].ToString(), DbType.String, ParameterDirection.Input)              // 지시창고코드
                                                                    , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input));        // 품목                            
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            //                            param = new SqlParameter[25];
                            //
                            //                            param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                  // 사업장              
                            //                            param[1] = helper.CreateParameter("PoNo", drRow["PoNo"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                            // p/o 번호            
                            //                            param[2] = helper.CreateParameter("PoSeqNo", drRow["PoSeqNo"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                      // p/o 순번            
                            //                            param[3] = helper.CreateParameter("CustCode", drRow["CustCode"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                    // 업체                
                            //                            param[4] = helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                    // 품목                
                            //                            param[5] = helper.CreateParameter("PoOrderQty", drRow["PoOrderQty"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                // 발주량              
                            //                            param[6] = helper.CreateParameter("UnitCode", drRow["UnitCode"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                    // 단위                
                            //                            param[7] = helper.CreateParameter("PoOrderDate", drRow["PoOrderDate"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);              // 발주일              
                            //                            param[8] = helper.CreateParameter("PlanInDate", drRow["PlanInDate"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                // 입고예정일          
                            //                            param[9] = helper.CreateParameter("StockLocCode", drRow["StockLocCode"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);            // 납고위치            
                            //                            param[10] = helper.CreateParameter("LastIndate", drRow["LastIndate"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                // 최종입고일          
                            //                            param[11] = helper.CreateParameter("TotInQty", drRow["TotInQty"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                    // 입고량              
                            //                            param[12] = helper.CreateParameter("FinishFlag", drRow["FinishFlag"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                // 입고 완료 여부      
                            //                            param[13] = helper.CreateParameter("MetrialLotFlag", drRow["MetrialLotFlag"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);        // 자재 LOT 여부       
                            //                            param[14] = helper.CreateParameter("MetLotNo", drRow["MetLotNo"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                    // 대표자재 LotNo      
                            //                            param[15] = helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                      // 사용여부            
                            //                            param[16] = helper.CreateParameter("MatResultNo", drRow["MatResultNo"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);              // 성적서 번호         
                            //                            param[17] = helper.CreateParameter("MatDocYear", drRow["MatDocYear"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                // 자재 문서 년도      
                            //                            param[18] = helper.CreateParameter("MatDocNo", drRow["MatDocNo"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                    // 자재 문서 번호      
                            //                            param[19] = helper.CreateParameter("MatDocItemNo", drRow["MatDocItemNo"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);            // Item 문서 번호      
                            //                            param[20] = helper.CreateParameter("MatCanDocNo", drRow["MatCanDocNo"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);              // 취소 자재 문서 번호 
                            //                            param[21] = helper.CreateParameter("MatCanDocItemNo", drRow["MatCanDocItemNo"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);      // 취소 Item 문서 번호 
                            //                            param[22] = helper.CreateParameter("MoveType", drRow["MoveType"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                    // 이동 유형 수정일    
                            //                            param[23] = helper.CreateParameter("RS_CODE", SqlDbType.VarChar, ParameterDirection.Output, null, 1);
                            //                            param[24] = helper.CreateParameter("RS_MSG", SqlDbType.VarChar, ParameterDirection.Output, null, 200);

                            //                            SqlDBHelper.ExecuteNoneQuery("USP_ WM3000_I1", CommandType.StoredProcedure, param);

                            //                            if (param[23].Value.ToString() == "E") throw new Exception(param[24].Value.ToString());

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_WM3000_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("TakingORDNo", drRow["TakingORDNo"].ToString(), DbType.String, ParameterDirection.Input)              // 재고실사지시번호             
                                                                    , helper.CreateParameter("TakingORDRemark", drRow["TakingORDRemark"].ToString(), DbType.String, ParameterDirection.Input)      // 특이사항           
                                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)                      // 사용여부           
                                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));                                   // 수정자                                                                                                                                                                                                                 
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);

                }
                grid1.SetAcceptChanges("PlanNo");
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
                e.Command.Parameters["Editor"].Value = this.WorkerID;
                return;
            }

            if (e.Row.RowState == DataRowState.Added)
            {
                //e.Command.Parameters["@Editor"].Value = this.WorkerID;
                e.Command.Parameters["Maker"].Value = this.WorkerID;
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

        #region<METHOD AREA>
        private void bntInsert_Click(object sender, EventArgs e)
        {
            DoInsert();
            // DoInquire(); //재 조회 처리

            //***********등록 그리드 초기화부분**********//
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            txtOrderNo.Text = Convert.ToString(null);
            txtWHCode.Text = Convert.ToString(null);                       // 창고코드 
            txtWHName.Text = Convert.ToString(null);                         // 창고명 
            txtItemCode.Text = Convert.ToString(null);                       // 품목 
            txtItemName.Text = Convert.ToString(null);                       //품목명
                                                                             //  string sTakingORDDate = string.Format("{0:yyyy-MM-dd}", dtStart.Value);    // 재고실사 지시일자
            txtTakingORDRemark.Text = Convert.ToString(null);                 // 재고실사사유 
            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");  //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");         // 사용여부

        }

        private void DoInsert()
        {
            // 재고실사 등록 처리

            string sTakingORDNo = txtOrderNo.Text.Trim();                              // 재고실사지시번호
            string sPlantCode = Convert.ToString(cboPlantCode.Value);     // 사업장 
            string sWHCode = txtWHCode.Text.Trim();                                    // 창고코드  
            string sItemCode = txtItemCode.Text.Trim();                                // 품목
            string sTakingORDDate = string.Format("{0:yyyy-MM-dd}", dtStart.Value);    // 재고실사 지시일자
            string sTakingORDRemark = txtTakingORDRemark.Text.Trim();                  // 재고실사사유 
            string sUseFlag = Convert.ToString(cboUseFlag.Value);         // 사용여부

            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("사업장 정보를 입력하세요", "MSG"));
                return;
            }
            if (sWHCode == "")   // 창고 코드 SPACE 이면 전체(ALL) 를 의미(key부)
            {
                sWHCode = "ALL";
            }
            if (sItemCode == "")   // 품목 코드 SPACE 이면 전체(ALL) 를 의미(key부)
            {
                sItemCode = "ALL";
            }
            if (sTakingORDNo == "")
            {
                MessageBox.Show(Common.getLangText("지시번호를 먼자 생성 하세요", "MSG"));
                return;
            }
            DBHelper helper = new DBHelper("", true);

            try
            {
                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.UpdateData();
                //helper.Transaction = helper._sConn.BeginTransaction();
                helper.ExecuteNoneQuery("USP_WM3000_I1N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)             // 사업장              
                                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                // 사업장              
                                                        , helper.CreateParameter("WHCode", sWHCode, DbType.String, ParameterDirection.Input)                      // 지시창고코드            
                                                        , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)                  // 품목            
                                                        , helper.CreateParameter("TakingORDDate", sTakingORDDate, DbType.String, ParameterDirection.Input)        // 재고실사 지시일자              
                                                        , helper.CreateParameter("TakingORDRemark", sTakingORDRemark, DbType.String, ParameterDirection.Input)    // 재고실사사유                
                                                        , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input)                    // 발주량              
                                                        , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input));               // 등록자                                
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
            this.grid1.UpdateData();
            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("사업장 정보를 입력하세요", "MSG"));
                return;
            }
            try
            {
                if (txtOrderNo.Text == "")
                {
                    helper.ExecuteNoneQuery("USP_TakingORDNoCreate", CommandType.StoredProcedure, ref RS_CODE, ref RS_MSG, ref TakingORDNo
                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input));                // 품목         

                    //throw new Exception
                    if (RS_CODE == "E") MessageBox.Show(RS_MSG);
                    txtOrderNo.Text = TakingORDNo.ToString();
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                //if (param != null) { param = null; }
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

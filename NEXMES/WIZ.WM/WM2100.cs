#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  WM2100
//   Form Name    :  출하 지시 관리  
//   Name Space   :  WIZ.WM
//   Created Date : 
//   Made By      :  WIZCORE
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
    public partial class WM2100 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        #endregion

        #region < CONSTRUCTOR >

        public WM2100()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();

            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtDeliveryCust, txtDeliveryCustName, "TBM0301", new object[] { cboPlantCode_H, "", "" });
            btbManager.PopUpAdd(txtSoldCust, txtSoldCustName, "TBM0301", new object[] { cboPlantCode_H, "", "" });


            BizGridManager bizGrid = new BizGridManager(grid1);
            bizGrid.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });
            bizGrid.PopUpAdd("DeliveryCust", "DeliveryCustNM", "TBM0301", new string[] { "PlantCode", "", "" });
            bizGrid.PopUpAdd("SoldCust", "SoldCustNM", "TBM0301", new string[] { "PlantCode", "", "" });

        }
        #endregion

        #region  WM2100_Load
        private void WM2100_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            // InitColumnUltraGrid 90 123 116 113 186 108 129 90 139 90 128 225 90 90 90 90 90 90 137 90 122 90 90 90 
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);             //공장코드             
            _GridUtil.InitColumnUltraGrid(grid1, "DeliveryNo", "출하지시번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);         //출하지시번호         
            _GridUtil.InitColumnUltraGrid(grid1, "DeliverySeqNo", "출하지시순번", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);         //출하지시순번         
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "출하품목", false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);         //출하품목         
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "출하품명", false, GridColDataType_emu.VarChar, 110, 10, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);             //출하품목명             
            _GridUtil.InitColumnUltraGrid(grid1, "ShipPlanDate", "출하예정일", false, GridColDataType_emu.VarChar, 129, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);           //출하예정일           
            _GridUtil.InitColumnUltraGrid(grid1, "ShipDate", "출하일", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);               //출하일               
            _GridUtil.InitColumnUltraGrid(grid1, "DeliveryCust", "인도처", false, GridColDataType_emu.VarChar, 139, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);               //인도처               
            _GridUtil.InitColumnUltraGrid(grid1, "DeliveryCustNM", "인도처명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);             //인도처명             
            _GridUtil.InitColumnUltraGrid(grid1, "SoldCust", "납품처", false, GridColDataType_emu.VarChar, 128, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);               //납품처               
            _GridUtil.InitColumnUltraGrid(grid1, "SoldCustNM", "납품처 명", false, GridColDataType_emu.VarChar, 230, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);            //납품처 명            
            _GridUtil.InitColumnUltraGrid(grid1, "Location", "납품위치", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);             //납품위치             
            _GridUtil.InitColumnUltraGrid(grid1, "ShipQty", "납품수량", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);             //납품수량             
            _GridUtil.InitColumnUltraGrid(grid1, "ShipUnit", "납품단위", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);             //납품단위             
            _GridUtil.InitColumnUltraGrid(grid1, "BaseQty", "기준수량", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);             //기준수량             
            _GridUtil.InitColumnUltraGrid(grid1, "BaseUnit", "기준단위", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);             //기준단위             
            _GridUtil.InitColumnUltraGrid(grid1, "PlanWorkerID", "출고지시자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);           //출고지시자           
            _GridUtil.InitColumnUltraGrid(grid1, "PlanWorker", "지시자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);               //지시자               
            _GridUtil.InitColumnUltraGrid(grid1, "OutFlag", "출고완료여부", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);         //출고완료여부         
            _GridUtil.InitColumnUltraGrid(grid1, "OutQty", "출고수량", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);             //출고수량             
            _GridUtil.InitColumnUltraGrid(grid1, "DeliveryFlag", "출하완료여부", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);         //출하완료여부         
            _GridUtil.InitColumnUltraGrid(grid1, "DeliveryDate", "출하일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);             //출하일자             
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);             //등록일자             
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);                 //비고                     

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");  //2014.7.14 "ALL" => ""  by LIM y.j.
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("YesNo");  //출하여부
            WIZ.Common.FillComboboxMaster(this.cboOutFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");     //사용여부

            #endregion

        }
        #endregion  WM2100_Load

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

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                   // 공장코드     
                string sStartDate = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);           // 일자 FROM
                string sEndDate = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);               // 일자 TO                                                                                       
                string sOutFlag = Convert.ToString(cboOutFlag_H.Value);                       // 출하여부

                grid1.DataSource = helper.FillTable("USP_WM2100_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)          // 사업장 공장코드    
                                                                    , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)          // 일자 FROM          
                                                                    , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)              // 일자 TO            
                                                                    , helper.CreateParameter("OutFlag", sOutFlag, DbType.String, ParameterDirection.Input));            // 출하여부   
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

                            helper.ExecuteNoneQuery("USP_WM2100_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)          // 사업장(공장)     
                                                                    , helper.CreateParameter("DeliveryNo", drRow["DeliveryNo"].ToString(), DbType.String, ParameterDirection.Input)        // 출하지시번호 
                                                                    , helper.CreateParameter("DeliverySeqNo", drRow["DeliverySeqNo"].ToString(), DbType.String, ParameterDirection.Input)  // 출하지시순번     
                                                                    , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input));          // 출하품목

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가


                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_WM2100_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)              // 공장코드             
                                                                    , helper.CreateParameter("DeliveryNo", drRow["DeliveryNo"].ToString(), DbType.String, ParameterDirection.Input)            // 출하지시번호             
                                                                    , helper.CreateParameter("DeliverySeqNo", drRow["DeliverySeqNo"].ToString(), DbType.String, ParameterDirection.Input)      // 출하지시순번           
                                                                    , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)                // 출하품목  
                                                                    , helper.CreateParameter("ShipPlanDate", drRow["ShipPlanDate"].ToString(), DbType.DateTime, ParameterDirection.Input)      // 출하예정일  
                                                                    , helper.CreateParameter("ShipDate", drRow["ShipDate"].ToString(), DbType.DateTime, ParameterDirection.Input)              // 출하일  
                                                                    , helper.CreateParameter("DeliveryCust", drRow["DeliveryCust"].ToString(), DbType.String, ParameterDirection.Input)        // 인도처  
                                                                    , helper.CreateParameter("SoldCust", drRow["SoldCust"].ToString(), DbType.String, ParameterDirection.Input)                // 납품처  
                                                                    , helper.CreateParameter("Location", drRow["Location"].ToString(), DbType.String, ParameterDirection.Input)                // 저장위치  
                                                                    , helper.CreateParameter("ShipQty", drRow["ShipQty"].ToString(), DbType.String, ParameterDirection.Input)                  // 납품수량  
                                                                    , helper.CreateParameter("ShipUnit", drRow["ShipUnit"].ToString(), DbType.String, ParameterDirection.Input)                // 납품단위  
                                                                    , helper.CreateParameter("BaseQty", drRow["BaseQty"].ToString(), DbType.String, ParameterDirection.Input)                  // 기준수량  
                                                                    , helper.CreateParameter("BaseUnit", drRow["BaseUnit"].ToString(), DbType.String, ParameterDirection.Input)                // 기준수량  
                                                                    , helper.CreateParameter("PlanWorker", this.WorkerID, DbType.String, ParameterDirection.Input)                             // 기준단위
                                                                    , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input));                  // 비고  

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
                CancelProcess = true;
                helper.Rollback();
                throw (ex);
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

        #region <METHOD AREA>
        private void bntInsert_Click(object sender, EventArgs e)
        {
            DoInsert();
            // DoInquire(); //재 조회 처리
        }
        private void DoInsert()
        {
            // 재고실사 등록 처리
            //SqlParameter[] param = null;
            //param = new SqlParameter[16];

            string sPlantCode = Convert.ToString(cboPlantCode.Value);                        // 사업장 
            string sDeliveryNo = txtDeliveryNo.Text.Trim();                                  // 출하지시번호
            string sDeliverySeqNo = txtDeliverySeqNo.Text.Trim();                            // 출하지시순번  
            string sItemCode = txtItemCode.Text.Trim();                                      // 출하품목  
            string sShipPlanDate = string.Format("{0:yyyy-MM-dd}", dtShipPlanDate.Value);    // 출하예정일 지시일자
            string sDeliveryCust = txtDeliveryCust.Text.Trim();                              // 인도처  
            string sSoldCust = txtSoldCust.Text.Trim();                                      // 납품처  
            string sLocation = txtLocation.Text.Trim();                                      // 저장위치  
            string sShipQty = txtShipQty.Text.Trim();                                        // 납품수량  
            string sShipUnit = txtShipUnit.Text.Trim();                                      // 납품단위  
            string sBaseQty = txtBaseQty.Text.Trim();                                        // 기준수량  
            string sBaseUnit = txtBaseUnit.Text.Trim();                                      // 기준단위  
            string sPlanWorker = this.WorkerID;                                              // 출고지시자
            string sRemark = txtRemark.Text.Trim();                                          // 비고 

            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("사업장 정보를 입력하세요", "MSG"));
                return;
            }

            if (sDeliveryNo == "")
            {
                MessageBox.Show(Common.getLangText("출고요청번호를 먼저  생성 하세요", "MSG"));
                return;
            }
            DBHelper helper = new DBHelper("", true);
            //helper.Transaction = helper._sConn.BeginTransaction();
            try
            {

                helper.ExecuteNoneQuery("USP_WM2100_I1N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)          // 공장코드                     
                                                        , helper.CreateParameter("DeliveryNo", sDeliveryNo, DbType.String, ParameterDirection.Input)        // 출하지시번호                 
                                                        , helper.CreateParameter("DeliverySeqNo", sDeliverySeqNo, DbType.String, ParameterDirection.Input)  // 출하지시순번 
                                                        , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)            // 출하품목                 
                                                        , helper.CreateParameter("ShipPlanDate", sShipPlanDate, DbType.String, ParameterDirection.Input)    // 출하예정일                   
                                                        , helper.CreateParameter("DeliveryCust", sDeliveryCust, DbType.String, ParameterDirection.Input)    // 인도처                       
                                                        , helper.CreateParameter("SoldCust", sSoldCust, DbType.String, ParameterDirection.Input)            // 납품처                       
                                                        , helper.CreateParameter("Location", sLocation, DbType.String, ParameterDirection.Input)            // 저장위치 
                                                        , helper.CreateParameter("ShipQty", sShipQty, DbType.String, ParameterDirection.Input)              // 납품수량                     
                                                        , helper.CreateParameter("ShipUnit", sShipUnit, DbType.String, ParameterDirection.Input)            // 납품단위                     
                                                        , helper.CreateParameter("BaseQty", sBaseQty, DbType.String, ParameterDirection.Input)              // 기준수량                     
                                                        , helper.CreateParameter("BaseUnit", sBaseUnit, DbType.String, ParameterDirection.Input)            // 기준단위                     
                                                        , helper.CreateParameter("PlanWorker", sPlanWorker, DbType.String, ParameterDirection.Input)        // 출고지시자                                    
                                                        , helper.CreateParameter("Remark", sRemark, DbType.String, ParameterDirection.Input));              // 비고                         

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
                // DoInquire(); //재 조회 처리
            }

        }

        private void btnmake_Click(object sender, EventArgs e)
        {
            //// 지시번호 생성
            // 2014. 07.14 Limyj 아래로 수정
            //object[] param = new object[4];
            //string sPlantCode = Convert.ToString(cboPlantCode.Value);  // 공장코드  

            //if (sPlantCode == "")
            //{
            //    MessageBox.Show("사업장 정보를 입력하세요");
            //    return;
            //}
            //DBHelper helper = new DBHelper("", true);
            ////helper.Transaction = helper._sConn.BeginTransaction();
            //string rs_code = string.Empty;
            //string rs_msg = string.Empty;
            //string deliveryno = string.Empty;
            //int i = 0;
            //try
            //{
            //    param[0] = helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input);
            //    param[1] = helper.CreateParameter("DeliveryNo", DbType.String, ParameterDirection.Output, null, 20);
            //    param[2] = helper.CreateParameter("RS_CODE",    DbType.String, ParameterDirection.Output, null, 1);
            //    param[3] = helper.CreateParameter("RS_MSG",     DbType.String, ParameterDirection.Output, null, 500);
            //    helper.ExecuteNoneQuery("USP_WM0000_DeliveryNoCreate", CommandType.StoredProcedure, i, param);

            //    helper.Commit();

            //    if (Convert.ToString(((DbParameter)param[2]).Value) == "S")
            //    {
            //        this.txtDeliveryNo.Text = Convert.ToString(((DbParameter)param[1]).Value); 
            //    }
            //}
            //catch (Exception ex)
            //{
            //    helper.Rollback();
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    helper.Close();

            //}
            DBHelper helper = new DBHelper(false);

            string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value);// 공장코드  
            string TakingORDNo = string.Empty;
            string RS_CODE = string.Empty;
            string RS_MSG = string.Empty;

            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("사업장 정보를 입력하세요", "MSG"));
                return;
            }

            this.grid1.UpdateData();

            try
            {
                helper.ExecuteNoneQuery("USP_WM0000_DeliveryNoCreate"
                                        , CommandType.StoredProcedure, ref RS_CODE, ref RS_MSG, ref TakingORDNo
                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input));


                if (RS_CODE == "E") MessageBox.Show(RS_MSG);
                txtDeliveryNo.Text = TakingORDNo.ToString();
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
                this.txtDeliveryNo.Text = Convert.ToString(grid1.ActiveRow.Cells["DeliveryNo"].Value);
            }
        }
        #endregion
    }
}

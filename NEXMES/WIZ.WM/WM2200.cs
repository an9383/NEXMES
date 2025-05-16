#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  WM2200
//   Form Name    :  출고 확정
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
    public partial class WM2200 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >

        public WM2200()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtSoldCust, txtSoldCustName, "TBM0301", new object[] { cboPlantCode_H, "", "" });
        }
        #endregion

        #region  WM2200_Load
        private void WM2200_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            // InitColumnUltraGrid 90 123 116 113 186 108 129 90 139 90 128 225 90 90 90 90 90 90 137 90 122 90 90 90 
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);                 //공장코드             
            _GridUtil.InitColumnUltraGrid(grid1, "DeliveryNo", "출하지시번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);         //출하지시번호         
            _GridUtil.InitColumnUltraGrid(grid1, "DeliverySeqNo", "출하지시순번", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);      //출하지시순번         
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "출하품목", false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);            //출하품목         
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "출하품명", false, GridColDataType_emu.VarChar, 110, 10, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);                   //출하품목명             
            _GridUtil.InitColumnUltraGrid(grid1, "ShipPlanDate", "출하예정일", false, GridColDataType_emu.VarChar, 129, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);          //출하예정일           
            _GridUtil.InitColumnUltraGrid(grid1, "ShipDate", "출하일", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);                   //출하일               
            _GridUtil.InitColumnUltraGrid(grid1, "DeliveryCust", "인도처", false, GridColDataType_emu.VarChar, 139, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);              //인도처               
            _GridUtil.InitColumnUltraGrid(grid1, "DeliveryCustNM", "인도처명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);             //인도처명             
            _GridUtil.InitColumnUltraGrid(grid1, "SoldCust", "납품처", false, GridColDataType_emu.VarChar, 128, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);                  //납품처               
            _GridUtil.InitColumnUltraGrid(grid1, "SoldCustNM", "납품처 명", false, GridColDataType_emu.VarChar, 230, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);               //납품처 명            
            _GridUtil.InitColumnUltraGrid(grid1, "Location", "납품위치", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);                   //납품위치             
            _GridUtil.InitColumnUltraGrid(grid1, "ShipQty", "납품수량", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);                  //납품수량             
            _GridUtil.InitColumnUltraGrid(grid1, "ShipUnit", "납품단위", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);                 //납품단위             
            _GridUtil.InitColumnUltraGrid(grid1, "BaseQty", "기준수량", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);                  //기준수량             
            _GridUtil.InitColumnUltraGrid(grid1, "BaseUnit", "기준단위", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);                 //기준단위             
            _GridUtil.InitColumnUltraGrid(grid1, "PlanWorkerID", "출고지시자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);          //출고지시자           
            _GridUtil.InitColumnUltraGrid(grid1, "PlanWorker", "지시자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                //지시자               
            _GridUtil.InitColumnUltraGrid(grid1, "OutFlag", "출고완료여부", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);             //출고완료여부         
            _GridUtil.InitColumnUltraGrid(grid1, "OutQty", "출고수량", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                  //출고수량             
            _GridUtil.InitColumnUltraGrid(grid1, "DeliveryFlag", "출하완료여부", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);        //출하완료여부         
            _GridUtil.InitColumnUltraGrid(grid1, "DeliveryDate", "출하일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);             //출하일자             
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                //등록일자             
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);                       //비고                     

            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            //112 90 183 108 128 120 120 100 90 90 90 90 90 90 90 90 
            _GridUtil.InitColumnUltraGrid(grid2, "PlantCode", " 사업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);        // 공장(사업장)
            _GridUtil.InitColumnUltraGrid(grid2, "OutDate", " 출고일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);              // 출고일자
            _GridUtil.InitColumnUltraGrid(grid2, "LotNo", " 제품Lot 번호", false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);            // 제품Lot 번호
            _GridUtil.InitColumnUltraGrid(grid2, "OutType", " 출고구분", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);              // 출고구분
            _GridUtil.InitColumnUltraGrid(grid2, "DeliveryNo", " 지시번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);      // 출하지시번호
            _GridUtil.InitColumnUltraGrid(grid2, "DeliverySeqNo", " 지시순번", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);    // 출하지시순번
            _GridUtil.InitColumnUltraGrid(grid2, "CustCode", " 업체코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);         // 출고업체코드 
            _GridUtil.InitColumnUltraGrid(grid2, "CustName", " 업체", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);             // 출고업체          
            _GridUtil.InitColumnUltraGrid(grid2, "OutQty", " 출고량", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);               // 출고량 
            _GridUtil.InitColumnUltraGrid(grid2, "OutWorker", " 출고자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);              // 출고자 
            _GridUtil.InitColumnUltraGrid(grid2, "Worker", " 지시자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                 // 지시자
            _GridUtil.InitColumnUltraGrid(grid2, "OutStemp", " 출고일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);            // 출고일자 
            _GridUtil.InitColumnUltraGrid(grid2, "CarNo", " 차량번호", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);               // 차량번호
            _GridUtil.InitColumnUltraGrid(grid2, "CarDesc", " 차량상세", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);              // 차량상세
            _GridUtil.InitColumnUltraGrid(grid2, "ProcFlag", " 반영 여부", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);           // 반영 여부(ERP I/F TABLE등)
            _GridUtil.InitColumnUltraGrid(grid2, "Remark", " 참조", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);                   // 참조(ERP 전송 SEQ NO등)

            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("YesNo");  //출하여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");     //출하여부

            rtnDtTemp = _Common.GET_BM0000_CODE("OutType");  //출고구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "OutType", rtnDtTemp, "CODE_ID", "CODE_NAME");     //출고구분
            #endregion

        }
        #endregion  WM2200_Load

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
                this.txtDeliveryNo.Text = "";
                this.txtDeliverySeqNo.Text = "";
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                      // 공장코드     
                string sStartDate = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);              // 일자 FROM
                string sEndDate = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);                  // 일자 TO                                                                                       
                string sSoldCust = txtSoldCust.Text.Trim();                                      // 납품처  

                grid1.DataSource = helper.FillTable("USP_WM2200_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)          // 사업장 공장코드    
                                                                    , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)          // 일자 FROM          
                                                                    , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)              // 일자 TO            
                                                                    , helper.CreateParameter("SoldCust", sSoldCust, DbType.String, ParameterDirection.Input));          // 납품처   

                grid1.DataBinds();
                // grid2의 정보 초기화 필요

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
            DoInquire(); //재 조회 처리
        }
        private void DoInsert()
        {
        }

        private void grid1_Click(object sender, EventArgs e)
        {
            if (grid1.ActiveRow != null)
            {
                DBHelper helper = new DBHelper(false);

                string sDeliveryNo = Convert.ToString(grid1.ActiveRow.Cells["DeliveryNo"].Value);
                string sDeliverySeqNo = Convert.ToString(grid1.ActiveRow.Cells["DeliverySeqNo"].Value);

                this.txtDeliveryNo.Text = sDeliveryNo;
                this.txtDeliverySeqNo.Text = sDeliverySeqNo;

                grid2.DataSource = helper.FillTable("USP_WM2200_S2N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("DeliveryNo", sDeliveryNo, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DeliverySeqNo", sDeliverySeqNo, DbType.String, ParameterDirection.Input));
                grid2.DataBinds();
            }
        }
        private void bntFinsh_Click(object sender, EventArgs e)
        {
            DoProcess();
            //    DoInquire(); //재 조회 처리
        }


        private void DoProcess()
        {
            // 출고 확정 처리
            string sPlantCode = this.grid1.ActiveRow.Cells["PlantCode"].Value.ToString();      // 사업장 
            string sDeliveryNo = txtDeliveryNo.Text.Trim();                                    // 출하지시번호
            string sDeliverySeqNo = txtDeliverySeqNo.Text.Trim();                              // 출하지시순번  

            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("사업장 정보를 입력하세요", "MSG"));
                return;
            }

            if (sDeliveryNo == "")
            {
                MessageBox.Show(Common.getLangText("출고요청번호를 먼저 선택 하세요", "MSG"));
                return;
            }
            DBHelper helper = new DBHelper("", true);

            try
            {
                UltraGridUtil.DataRowDelete(this.grid1);
                //this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);
                this.grid1.UpdateData();
                // helper.Transaction  =  helper._sConn.BeginTransaction();

                helper.ExecuteNoneQuery("USP_WM2200_U1N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                  // 공장코드                     
                                                        , helper.CreateParameter("DeliveryNo", sDeliveryNo, DbType.String, ParameterDirection.Input)                // 출하지시번호                 
                                                        , helper.CreateParameter("DeliverySeqNo", sDeliverySeqNo, DbType.String, ParameterDirection.Input));        // 출하지시순번 

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

        private void grid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }
        #endregion
    }
}

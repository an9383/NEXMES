#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  MM1400
//   Form Name    : 재고출고의뢰 관리
//   Name Space   : WIZ.MM
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

namespace WIZ.MM
{
    public partial class MM1400 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >

        public MM1400()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode, "" });
        }
        #endregion

        #region  MM1400_Load
        private void MM1400_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            // InitColumnUltraGrid 90 100 165 200 165 90 100 80 150 100 100 200 90 90 
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutReqNo", "출고의뢰번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 165, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutReqDate", "출고의뢰일", false, GridColDataType_emu.YearMonthDay, 165, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutReqQty", "출고의뢰량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutReqType", "출고구분", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutFlag", "처리여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutQty", "출고량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutWorker", "출고자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutDate", "출고일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion



            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("OUTTYPE");      //출고구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutReqType", rtnDtTemp, "CODE_ID", "CODE_NAME");     // 출고구분 
            WIZ.Common.FillComboboxMaster(this.cboOutReqType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboOutReqType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            rtnDtTemp = _Common.GET_BM0130_CODE_1("C", "Y");     // 단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");     // 단위
            WIZ.Common.FillComboboxMaster(this.cboUnitCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");      //출고여부
            WIZ.Common.FillComboboxMaster(this.cboOutFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");     // 출고여부

            #endregion

        }
        #endregion  MM1400_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        /// 


        public void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                           // 공장코드     
                string sOutReqDate1 = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);               // 일자 FROM
                string sOutReqDate2 = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);                 // 일자 TO                                                                                       
                string sOutReqType = Convert.ToString(cboOutReqType_H.Value);                         // 출고구분)     
                string sOutFlag = Convert.ToString(cboOutFlag_H.Value);                               // 출고처리여부    

                grid1.DataSource = helper.FillTable("USP_MM1400_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                         // 공장코드      
                                                                    , helper.CreateParameter("OutReqDate_FROM", sOutReqDate1, DbType.String, ParameterDirection.Input)                 // 일자 FROM     
                                                                    , helper.CreateParameter("OutReqDate_TO", sOutReqDate2, DbType.String, ParameterDirection.Input)                   // 일자 TO       
                                                                    , helper.CreateParameter("OutReqType", sOutReqType, DbType.String, ParameterDirection.Input)                       // 출고구분)              
                                                                    , helper.CreateParameter("OutFlag", sOutFlag, DbType.String, ParameterDirection.Input));                           // 출고처리여부  
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
                this.txtOutReqNo.Focus();
                base.DoSave();
                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "사업장 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_MM1400_D1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)        // 사업부공장 
                                                    , helper.CreateParameter("OutReqNo", Convert.ToString(drRow["OutReqNo"]), DbType.String, ParameterDirection.Input)        // 출고의뢰번호(공장)     
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input));      // 품목
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_MM1400_U1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)          // 사업부공장 
                                                    , helper.CreateParameter("OutReqNo", drRow["OutReqNo"].ToString(), DbType.String, ParameterDirection.Input)          // 출고의뢰번호(공장)     
                                                    , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)          // 품목
                                                    , helper.CreateParameter("OutReqDate", drRow["OutReqDate"].ToString(), DbType.String, ParameterDirection.Input)          // 출고의뢰일             
                                                    , helper.CreateParameter("OutReqQty", drRow["OutReqQty"].ToString(), DbType.String, ParameterDirection.Input)          // 출고의뢰량           
                                                    , helper.CreateParameter("UnitCode", drRow["UnitCode"].ToString(), DbType.String, ParameterDirection.Input)          // 단위           
                                                    , helper.CreateParameter("OutReqType", drRow["OutReqType"].ToString(), DbType.String, ParameterDirection.Input));        // 출고구분           

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

        private void bntInsert_Click(object sender, EventArgs e)
        {
            DoInsert();
            this.DoInquire(); //재 조회 처리
        }

        private void DoInsert()
        {
            DBHelper helper = new DBHelper("", true);
            UltraGridUtil.DataRowDelete(this.grid1);
            this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);
            //helper.Transaction = helper._sConn.BeginTransaction();

            string sPlantCode = Convert.ToString(cboPlantCode.Value);     // 사업장 
            string sOutReqNo = txtOutReqNo.Text.Trim();                                // 출고의뢰번호
            string sItemCode = txtItemCode.Text.Trim();                                // 품목
            string sOutReqDate = string.Format("{0:yyyy-MM-dd}", dtStart.Value);       // 출고의뢰일  
            string sOutReqQty = txtOutReqQty.Text.Trim();                              // 출고의뢰량
            string sUnitCode = Convert.ToString(cboUnitCode.Value);      // 단위
            string sOutReqType = Convert.ToString(cboOutReqType.Value);   // 출고구분


            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("사업장 정보를 입력하세요", "MSG"));
                return;
            }
            if (sItemCode == "")   // 품목 코드 SPACE 이면 전체(ALL) 를 의미(key부)
            {
                MessageBox.Show(Common.getLangText("의뢰 품목을정보를 입력하세요", "MSG"));
                return;
            }
            if (sOutReqNo == "")
            {
                MessageBox.Show(Common.getLangText("의뢰번호를 먼자 생성 하세요", "MSG"));
                return;
            }

            try
            {
                helper.ExecuteNoneQuery("USP_MM1400_I1N"
                                        , CommandType.StoredProcedure
                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                  // 사업장              
                                        , helper.CreateParameter("OutReqNo", sOutReqNo, DbType.String, ParameterDirection.Input)                  // 출고의뢰번호              
                                        , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)                  // 품목 
                                        , helper.CreateParameter("OutReqDate", sOutReqDate, DbType.String, ParameterDirection.Input)                  // 출고의뢰일       
                                        , helper.CreateParameter("OutReqQty", sOutReqQty, DbType.String, ParameterDirection.Input)                  // 출고의뢰량
                                        , helper.CreateParameter("UnitCode", sUnitCode, DbType.String, ParameterDirection.Input)                  // 단위            
                                        , helper.CreateParameter("OutReqType", sOutReqType, DbType.String, ParameterDirection.Input));                // 출고구분                

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
            // 지시번호 생성
            DBHelper helper = new DBHelper("", true);

            string sPlantCode = Convert.ToString(cboPlantCode.Value);
            string RS_CODE = string.Empty;
            string RS_MSG = string.Empty;
            string TakingORDNo = string.Empty;

            this.grid1.UpdateData();
            //helper.Transaction = helper._sConn.BeginTransaction();

            try
            {

                helper.ExecuteNoneQuery("USP_OutReqNoCreate"
                                        , CommandType.StoredProcedure, ref RS_CODE, ref RS_MSG, ref TakingORDNo
                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input));


                helper.Commit();
                if (RS_CODE == "E") MessageBox.Show(RS_MSG);
                txtOutReqNo.Text = TakingORDNo.ToString();
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
                this.txtOutReqNo.Text = Convert.ToString(grid1.ActiveRow.Cells["OutReqNo"].Value);
            }
        }
        #endregion

    }
}

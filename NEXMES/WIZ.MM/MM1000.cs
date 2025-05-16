#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM1000
//   Form Name    : 블록재고 부적합 처리
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
    public partial class MM1000 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        #endregion

        #region < CONSTRUCTOR >

        public MM1000()
        {
            InitializeComponent();
        }
        #endregion

        #region  < MM1000_Load >
        private void MM1000_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "발생일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MatLotNo", "Lot번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StockQty", "불량수량", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "업체코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "업체명", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NotFitStatus", "보고상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NotFitRes", "보고결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NotFitResDesc", "보고결과상세", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NotFitResDate", "부적합 등록일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NotFitResWorker", "부적합 등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BnkStockFlag", "블록처리여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BnkStockDate", "블록처리일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BnkStockWorker", "블록처리자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PoInDate", "반품일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PoNo", "반품P/O번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PoSeqNo", "반품P/O순번", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProcFlag", "반영여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ReturnStatus", "반납여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);


            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("YesNo");      //예/아니오
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ProcFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");     //반영여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "BnkStockFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");    //블록처리여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ReturnStatus", rtnDtTemp, "CODE_ID", "CODE_NAME");    //반납여부

            rtnDtTemp = _Common.GET_BM0000_CODE("NotFitRes");  //보고결과
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "NotFitRes", rtnDtTemp, "CODE_ID", "CODE_NAME");     //보고결과

            rtnDtTemp = _Common.GET_BM0000_CODE("NotFitStatus");  //보고상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "NotFitStatus", rtnDtTemp, "CODE_ID", "CODE_NAME");     //보고상태
            #endregion

            #region --- POP-Up Setting ---
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { cboPlantCode_H, "" });
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                      // 사업장 공장코드
                string sSrart = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);                // 시작일자
                string sEnd = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);                    // 종료일자
                string sItemCode = this.txtItemCode.Text;                                        // 품목
                string sCustCode = this.txtCustCode.Text.Trim();                                 // 업체코드              	

                grid1.DataSource = helper.FillTable("USP_MM1000_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)         //사업부(공장)
                                                                    , helper.CreateParameter("NotFitResDateS", sSrart, DbType.String, ParameterDirection.Input)        //시작일자(시)
                                                                    , helper.CreateParameter("NotFitResDateE", sEnd, DbType.String, ParameterDirection.Input)          //종료일자(종)
                                                                    , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)           //품목
                                                                    , helper.CreateParameter("CustCode", sCustCode, DbType.String, ParameterDirection.Input));         //업체코드              	

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
                this.Select();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    /*   if (drRow.RowState != DataRowState.Deleted)
                       {
                           if (drRow["PlanNo"].ToString().Trim() == "")
                           {
                               grid1.SetRowError(drRow, "지시번호 error!");
                               continue;
                           }
                       }*/
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            break;
                        case DataRowState.Added:
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_MM1000_U1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)               // 공장(사업장)
                                                    , helper.CreateParameter("MatLotNo", Convert.ToString(drRow["MatLotNo"]), DbType.String, ParameterDirection.Input)                 // 자재대표Lot 번호 
                                                    , helper.CreateParameter("MakeDate", Convert.ToString(drRow["MakeDate"]), DbType.String, ParameterDirection.Input)                 // 등록일자
                                                    , helper.CreateParameter("STORAGELOCCODE", Convert.ToString(drRow["STORAGELOCCODE"]), DbType.String, ParameterDirection.Input)     // 저장위치 (창고코드)
                                                    , helper.CreateParameter("StockQty", Convert.ToDouble(drRow["StockQty"]), DbType.Double, ParameterDirection.Input)                 // 재고수량 
                                                    , helper.CreateParameter("NotFitStatus", Convert.ToString(drRow["NotFitStatus"]), DbType.String, ParameterDirection.Input)         // 부적합 보고상태
                                                    , helper.CreateParameter("NotFitRes", Convert.ToString(drRow["NotFitRes"]), DbType.String, ParameterDirection.Input)               // 부적합 보고결과 
                                                    , helper.CreateParameter("NotFitResDesc", Convert.ToString(drRow["NotFitResDesc"]), DbType.String, ParameterDirection.Input)       // 부적합 보고결과Desc. 
                                                    , helper.CreateParameter("BnkStockFlag", Convert.ToString(drRow["BnkStockFlag"]), DbType.String, ParameterDirection.Input)         // 블록재고처리여부 
                                                    , helper.CreateParameter("PoInDate", Convert.ToString(drRow["PoInDate"]), DbType.String, ParameterDirection.Input)                 // 반품의경우 PO일자
                                                    , helper.CreateParameter("PoNo", Convert.ToInt32(drRow["PoNo"]), DbType.Int32, ParameterDirection.Input)                         // 반품의 경우 P/O No  
                                                    , helper.CreateParameter("PoSeqNo", Convert.ToString(drRow["PoSeqNo"]), DbType.String, ParameterDirection.Input)                   // 반품의 경우 순번   
                                                    , helper.CreateParameter("ProcFlag", Convert.ToString(drRow["ProcFlag"]), DbType.String, ParameterDirection.Input)                 // 반영 여부(ERP I/F TABLE등)
                                                    , helper.CreateParameter("Remark", Convert.ToString(drRow["Remark"]), DbType.String, ParameterDirection.Input)                     // 참조(ERP 전송 SEQ NO등)  
                                                    , helper.CreateParameter("ReturnStatus", Convert.ToString(drRow["ReturnStatus"]), DbType.String, ParameterDirection.Input)         // 자재반납(생산창고->원재창고)
                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));                                  // 수정자  
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges();
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

    }
}

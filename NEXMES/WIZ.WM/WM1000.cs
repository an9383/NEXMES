#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  WM1000
//   Form Name    : 블록재고 부적합 처리
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
    public partial class WM1000 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();
        #endregion

        #region<CONSTRUCTOR>
        public WM1000()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            //     * TBM0100 : 품목
            //*          - 1 : 품목, 2 : 품목명, param[0] : PlantCode, param[1] : ItemType
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });

            //* TBM0600 : 작업라인
            //*          - 1 : WorkCenterCode, 2 : WorkCenterName, param[0] : PlantCode, param[1] : OPcode
            //*          , param[2] : LineCode, param[3] : UseFlag
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });

        }
        #endregion

        #region  WM1000_Load
        private void WM1000_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "생성일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "생성작업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotNo", "Lot번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotQty", "Lot수량", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
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

        }
        #endregion  WM1000_Load

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
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);                                                // 사업장 공장코드
                string sSrart = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);                                               // 시작일자
                string sEnd = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);                                                   // 종료일자
                string sItemCode = this.txtItemCode.Text;                                                                       // 품목
                string sOPtCode = this.txtWorkCenterCode.Text.Trim();                                                           // 업체코드              	           	
                grid1.DataSource = helper.FillTable("USP_WM1000_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("NotFitResDateS", sSrart.ToString().Substring(0, 10), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("NotFitResDateE", sEnd.ToString().Substring(0, 10), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("WorkCenterCode", sOPtCode, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();

            }
            catch (Exception ex)
            {
                throw ex;
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
            if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                return;
            DBHelper helper = new DBHelper("", true);

            try
            {
                this.Select();


                base.DoSave();
                foreach (DataRow drRow in dt.Rows)  // .GetChanges().Rows = 변경된 Rows 만 작업
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            break;
                        case DataRowState.Added:
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            //param = new SqlParameter[18];
                            //param[0] = helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);               // 공장(사업장)
                            //param[1] = helper.CreateParameter("MatLotNo", drRow["MatLotNo"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                 // 자재대표Lot 번호 
                            //param[2] = helper.CreateParameter("MakeDate", drRow["MakeDate"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                 // 등록일자
                            //param[3] = helper.CreateParameter("STORAGELOCCODE", drRow["STORAGELOCCODE"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);     // 저장위치 (창고코드)
                            //param[4] = helper.CreateParameter("StockQty", drRow["StockQty"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                 // 재고수량 
                            //param[5] = helper.CreateParameter("NotFitStatus", drRow["NotFitStatus"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);         // 부적합 보고상태
                            //param[6] = helper.CreateParameter("NotFitRes", drRow["NotFitRes"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);               // 부적합 보고결과 
                            //param[7] = helper.CreateParameter("NotFitResDesc", drRow["NotFitResDesc"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);       // 부적합 보고결과Desc. 
                            //param[8] = helper.CreateParameter("BnkStockFlag", drRow["BnkStockFlag"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);         // 블록재고처리여부 
                            //param[9] = helper.CreateParameter("PoInDate", drRow["PoInDate"].ToString() , SqlDbType.VarChar, ParameterDirection.Input);                 // 반품의경우 PO일자
                            //param[10] = helper.CreateParameter("PoNo", drRow["PoNo"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                         // 반품의 경우 P/O No  
                            //param[11] = helper.CreateParameter("PoSeqNo", drRow["PoSeqNo"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                   // 반품의 경우 순번   
                            //param[12] = helper.CreateParameter("ProcFlag", drRow["ProcFlag"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                 // 반영 여부(ERP I/F TABLE등)
                            //param[13] = helper.CreateParameter("Remark", drRow["Remark"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);                     // 참조(ERP 전송 SEQ NO등)  
                            //param[14] = helper.CreateParameter("ReturnStatus", drRow["ReturnStatus"].ToString(), SqlDbType.VarChar, ParameterDirection.Input);         // 자재반납(생산창고->원재창고)
                            //param[15] = helper.CreateParameter("Editor", this.WorkerID, SqlDbType.VarChar, ParameterDirection.Input);                                  // 수정자
                            //param[16] = helper.CreateParameter("RS_CODE", SqlDbType.VarChar, ParameterDirection.Output, null, 1);
                            //param[17] = helper.CreateParameter("RS_MSG", SqlDbType.VarChar, ParameterDirection.Output, null, 200);

                            //SqlDBHelper.ExecuteNoneQuery("USP_WM1000_U1N", CommandType.StoredProcedure, param);

                            //if (param[16].Value.ToString() == "E") throw new Exception(param[17].Value.ToString());
                            helper.ExecuteNoneQuery("USP_WM1000_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MatLotNo", drRow["MatLotNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MakeDate", drRow["MakeDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("STORAGELOCCODE", drRow["STORAGELOCCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("StockQty", drRow["StockQty"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("NotFitStatus", drRow["NotFitStatus"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("NotFitRes", drRow["NotFitRes"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("NotFitResDesc", drRow["NotFitResDesc"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("BnkStockFlag", drRow["BnkStockFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PoInDate", drRow["PoInDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PoNo", drRow["PoNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PoSeqNo", drRow["PoSeqNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ProcFlag", drRow["ProcFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ReturnStatus", drRow["ReturnStatus"].ToString(), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }

                helper.Commit();

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                throw ex;
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
                //                e.Command.Parameters["@Editor"].Value = this.WorkerID;
                return;
            }

            if (e.Row.RowState == DataRowState.Added)
            {
                //             e.Command.Parameters["@Maker"].Value = this.WorkerID;
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
        #region 텍스트 박스에서 팝업창에서 값 가져오기

        private void Search_Pop_Item()
        {
            //임시로 사용할 데이터테이블 생성
            DataTable _DtTemp = new DataTable();
            string sitem_cd = this.txtItemCode.Text.Trim();    // 품목
            string sitem_name = this.txtItemName.Text.Trim();  // 품목명
            string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);
            // string splantcd = "820";
            string sitemtype = "";


            try
            {

                _DtTemp = _biz.SEL_BM0010(sPlantCode, sitem_cd, sitem_name, sitemtype, "");

                if (_DtTemp.Rows.Count > 1)
                {
                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    _DtTemp = pu.OpenPopUp("Item", new string[] { sPlantCode, sitemtype, sitem_cd, sitem_name }); // 품목 조회 POP-UP창 Parameter(비가동코드, 비가동명, 비가동그룹)

                    if (_DtTemp != null && _DtTemp.Rows.Count > 0)
                    {
                        txtItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
                        txtItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
                    }
                }
                else
                {
                    if (_DtTemp.Rows.Count == 1)
                    {
                        txtItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
                        txtItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
                    }
                    else
                    {
                        MessageBox.Show(Common.getLangText("입력하신 정보는 없는 정보입니다.", "MSG"), "ERROR");
                        txtItemCode.Text = string.Empty;
                        txtItemName.Text = string.Empty;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion
        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtItemName.Text = string.Empty;
        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_Item();
            }
        }

        private void txtItemCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_Item();
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtItemCode.Text = string.Empty;
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_Item();
            }
        }

        private void txtItemName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_Item();
        }

        #endregion

        #region WorkCenter  팝업 정보 얻어오기
        private void Search_Pop_TBM0600()
        {

            string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);                            // 사업장코드  
            string sWorkCenterCode = txtWorkCenterCode.Text.Trim();      // WorkCenter코드
            string sWorkCenterName = txtWorkCenterName.Text.Trim();      // WorkCenter명
            string sOPCode = string.Empty;                               // 공정코드
            string sLineCode = string.Empty;                             // 라인  
            string sUseFlag = "Y";                                       // 사용여부

            try
            {
                _biz.BM0060_POP(sPlantCode, sWorkCenterCode, sWorkCenterName, sOPCode, sLineCode, sUseFlag, txtWorkCenterCode, txtWorkCenterName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion        //WorkCenter

        #region  업체 찾기(조회조전)
        private void Search_Pop_TBM0400()
        {
            string sOPCode = txtWorkCenterCode.Text.Trim();       //업체코드
            string sOPName = txtWorkCenterName.Text.Trim();       //업체명 
            string sOPType = "V";                         //업체구부(V=Vendor) 
            string sUseFlag = "Y";                          //사용여부
            //string sPrintCode = SqlDBHelper.gGetCode(cboPlantCode_H.SelectedValue);
            string sPrintCode = Convert.ToString(this.cboPlantCode_H.Value);

            try
            {
                _biz.BM0030_POP(sOPCode, sOPName, sOPType, sUseFlag, "", "", "", "");

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion  업체 찾기(조회조전)

        #region<METHOD AREA>
        private void sWorkCenterCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtWorkCenterName.Text = string.Empty;
        }

        private void sWorkCenterName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtWorkCenterCode.Text = string.Empty;
        }

        private void txtWorkCenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0600();
            }
        }

        private void txtWorkCenterCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0600();
        }

        private void txtWorkCenterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0600();
            }
        }

        private void txtWorkCenterName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0600();
        }

        #region grid POP UP 처리
        private void grid_POP_UP()
        {
            int iRow = this.grid1.ActiveRow.Index;
            string sPlantCode = Convert.ToString(this.grid1.Rows[iRow].Cells["PlantCode"].Value);  // 사업부
            string sItemCode = this.grid1.Rows[iRow].Cells["ItemCode"].Text.Trim();  // 품목
            string sItemname = this.grid1.Rows[iRow].Cells["Itemname"].Text.Trim();  // 품목명

            string sWorkCenterCode = this.grid1.Rows[iRow].Cells["WorkCenterCode"].Text.Trim();  // 업체코드
            string sWorkCenterName = this.grid1.Rows[iRow].Cells["WorkCenterName"].Text.Trim();  // 업체명

            if (this.grid1.ActiveCell.Column.ToString() == "ItemCode" || this.grid1.ActiveCell.Column.ToString() == "Itemname")
            {

                //                _biz.BM0010_POP_Grid(sItemCode, sItemname, sPlantCode, "", grid1, "ItemCode", "Itemname");
            }
            if (this.grid1.ActiveCell.Column.ToString() == "WorkCenterCode" || this.grid1.ActiveCell.Column.ToString() == "WorkCenterName")
            {

                //                _biz.BM0060_POP_Grid(sPlantCode, sWorkCenterCode, sWorkCenterName, "", "", "", grid1, "WorkCenterCode", "WorkCenterName");
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

        private void BtnWM1100_Click(object sender, EventArgs e)
        {
            bool isupdating = false;
            if (!this.grid1.IsUpdating)
            {
                this.grid1.BeginUpdate();
                isupdating = true;
            }
            int idx = this.grid1.ActiveRow == null ? 0 : this.grid1.ActiveRow.Index;

            // 행이 없을 경우 SKIP
            if (this.grid1.Rows.Count == 0)
            {
                if (isupdating) this.grid1.EndUpdate();

                this.IsShowDialog = false;
                this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                return;
            }

            if (!this.grid1.ActiveRow.Selected)
                this.grid1.ActiveRow.Selected = true;

            // 정보 넘김
            string ItemCode = this.grid1.ActiveRow.Cells["ItemCode"].Value.ToString();
            string ItemName = this.grid1.ActiveRow.Cells["ItemName"].Value.ToString();
            string LotNO = this.grid1.ActiveRow.Cells["LotNo"].Value.ToString();
            string InspQty = this.grid1.ActiveRow.Cells["LotQty"].Value.ToString();
            string InspWaitDate = this.grid1.ActiveRow.Cells["MakeDate"].Value.ToString();

            WM1100 Btnwm1100 = new WM1100(ItemCode, ItemName, LotNO, InspQty, InspWaitDate);
            Btnwm1100.ShowDialog();
        }
        #endregion
    }
}

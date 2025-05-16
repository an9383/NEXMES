#region <HEADER AREA>
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM2200
//   Form Name    : 자재 출고처리
//   Name Space   : WIZ.MM
//   Created Date : 2014.7.25
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion <HEADER AREA>

#region <USING AREA>
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion <USING AREA>

namespace WIZ.MM
{
    public partial class MM2200 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region <CONSTRUCTOR>
        public MM2200()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            // 창고
            //_biz.TBM0800_POP_Grid(sPlantCode, sWHCode, sWHName, sBaseWHFlag, sProdWHFlag, sMetWHFlag, sUseFlag, grid1, "WHCode", "WHName");
            btbManager.PopUpAdd(txtWHCode, txtWHName, "TBM0800", new object[] { cboPlantCode, "", "", "", "" });
            // 업체
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { cboPlantCode, "" });                    //불출업체
            // 품목
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode, "" }); //품목
            // 투입작업장
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "Y" });
        }
        #endregion

        #region  <LOAD EVENT>
        private void MM2200_Load(object sender, EventArgs e)
        {
            //GRID SETTING
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 150, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 200, 500, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCode", "창고코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHName", "창고명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "저장위치명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MatLotNo", "Lot번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StockQty", "재고수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LastDate", "최종반영일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PoNo", "P/O번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PoSeqNo", "P/O순번", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);



            grid1.Columns["CHK"].Header.CheckBoxVisibility = Infragistics.Win.UltraWinGrid.HeaderCheckBoxVisibility.Never;
            grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.None;

            //사업장 콤보박스 데이터 바인딩
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            // 출고구분
            rtnDtTemp = _Common.GET_BM0000_CODE("OUTTYPE");  //출고구분
            WIZ.Common.FillComboboxMaster(this.cboOutType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            // 단위
            rtnDtTemp = _Common.GET_BM0130_CODE_1("C", "Y");  // 단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
        }
        #endregion <LOAD EVENT>

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            StringBuilder query = null;
            try
            {
                //DtChange.Clear();
                //base.DoInquire();
                // 등록 관련 정보 Clear
                cboPlantCode.Text = "";                       // 사업장
                cboOutType.Text = "";                         // 출고구분
                txtCustCode.Text = "";                        // 불출업체코드 
                txtWorkCenterCode.Text = "";                  //투입공정
                txtRemark.Text = "";                          //참조정보 
                txtLotCnt.Text = "";
                //////////////////////////////
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value); // 사업장(공장)
                string sWHCode = this.txtWHCode.Text.Trim();                     // 창고
                string sItemCode = this.txtItemCode.Text.Trim();                 // 품목

                grid1.DataSource = helper.FillTable("USP_MM2200_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)     //사업부(공장)
                                                                   , helper.CreateParameter("WHCode", sWHCode, DbType.String, ParameterDirection.Input)           //창고
                                                                   , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input));     //품목

                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                if (query != null) { query = null; }
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
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            string RSTCODE = string.Empty;
            string RSTMSG = string.Empty;
            DBHelper helper = new DBHelper("", true);
            StringBuilder query = null;

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                txtLotCnt.Text = "";

                bool CHK = false;

                string sOutType = Convert.ToString(this.cboOutType.Value);                // 출고구분
                string sCustCode = txtCustCode.Text.Trim();                               // 불출업체코드 
                string sInWorkCenterCode = txtWorkCenterCode.Text.Trim();                 //투입공정
                string sRemark = txtRemark.Text.Trim();                                   //참조정보 

                if (sOutType == "")
                {
                    MessageBox.Show(Common.getLangText("출고구분이 선택되지 않았습니다.", "MSG"), "LOT 출고 실패");
                    return;
                }

                // OUTTYPE - 1: 공정투입 2.불량반품 3.외주사급, 4. 제품판매

                if (sOutType == "1") //공정투입인 경우 sInWorkCenterCode  Check
                {
                    if (sInWorkCenterCode == "")
                    {
                        MessageBox.Show(Common.getLangText("투입작업장이 선택되지 않았습니다.", "MSG"), "LOT 출고 실패");
                        return;
                    }
                }
                if (sOutType == "2") //2.불량반품, 외주 사급등  경우 sCustCode  Check
                {
                    if (sCustCode == "")
                    {
                        MessageBox.Show(Common.getLangText("업체가  선택되지 않았습니다.", "MSG"), "LOT 출고 실패");
                        return;
                    }
                }
                if (sOutType == "3") //3.외주사급,  sCustCode  Check
                {
                    if (sCustCode == "")
                    {
                        MessageBox.Show(Common.getLangText("업체가  선택되지 않았습니다.", "MSG"), "LOT 출고 실패");
                        return;
                    }
                }
                if (sOutType == "4") //4. 제품판매  sCustCode  Check
                {
                    if (sCustCode == "")
                    {
                        MessageBox.Show(Common.getLangText("업체가  선택되지 않았습니다.", "MSG"), "LOT 출고 실패");
                        return;
                    }
                }


                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    CHK = this.grid1.Rows[i].Cells["CHK"].Value.ToString().ToUpper() == "TRUE" ? true : false;

                    if (CHK == true)
                    {

                        helper.ExecuteNoneQuery("USP_MM2200_I1", CommandType.StoredProcedure
                                                               , helper.CreateParameter("PlantCode", Convert.ToString(this.grid1.Rows[i].Cells["PlantCode"].Value), DbType.String, ParameterDirection.Input)                           //공장(사업장)  
                                                               , helper.CreateParameter("OutType", sOutType, DbType.String, ParameterDirection.Input)                                                                                  //출고구분(기타출고)
                                                               , helper.CreateParameter("MatLotNo", Convert.ToString(this.grid1.Rows[i].Cells["MatLotNo"].Value), DbType.String, ParameterDirection.Input)                             //자재Lot 번호
                                                               , helper.CreateParameter("OutQty", Convert.ToString(this.grid1.Rows[i].Cells["StockQty"].Value), DbType.String, ParameterDirection.Input)                               //출고량
                                                               , helper.CreateParameter("UnitCode", Convert.ToString(this.grid1.Rows[i].Cells["UnitCode"].Value), DbType.String, ParameterDirection.Input)                             //단위
                                                               , helper.CreateParameter("ItemCode", Convert.ToString(this.grid1.Rows[i].Cells["ItemCode"].Value), DbType.String, ParameterDirection.Input)                             //품목
                                                               , helper.CreateParameter("WHCode", Convert.ToString(this.grid1.Rows[i].Cells["WHCode"].Value), DbType.String, ParameterDirection.Input)                                 //자재: 창고코드. 생산:공정,작업장코드    
                                                               , helper.CreateParameter("STORAGELOCCODE", Convert.ToString(this.grid1.Rows[i].Cells["STORAGELOCCODE"].Value), DbType.String, ParameterDirection.Input)                 //저장위치 (창고코드)                     
                                                               , helper.CreateParameter("InWorkCenterCode", sInWorkCenterCode, DbType.String, ParameterDirection.Input)                                                                // 투입작업장 
                                                               , helper.CreateParameter("CustCode", sCustCode, DbType.String, ParameterDirection.Input)                                                                                // 거래처
                                                               , helper.CreateParameter("Remark", sRemark, DbType.String, ParameterDirection.Input)                                                                                    // 출고관련 사항(비고) 
                                                               , helper.CreateParameter("PoNo", Convert.ToString(this.grid1.Rows[i].Cells["PoNo"].Value), DbType.String, ParameterDirection.Input)                                     // P/O 번호(ERP_RECEIVER) 
                                                               , helper.CreateParameter("PoSeqNo", Convert.ToString(this.grid1.Rows[i].Cells["PoSeqNo"].Value), DbType.String, ParameterDirection.Input)                               // P/O 순번  (ERP라인)    
                                                               , helper.CreateParameter("OutWorker", this.WorkerID, DbType.String, ParameterDirection.Input));                                                                         //  등록자  

                        helper.Commit();

                    }

                }

            }
            catch (Exception ex)
            {
                RSTCODE = "E";
                RSTMSG = ex.Message.ToString();
                helper.Rollback();
            }
            finally
            {
                helper.Close();
                if (query != null) { query = null; }

                DoInquire();
            }
        }
        #endregion

        #region <METHOD AREA>

        #endregion <METHOD AREA>

        #region <EVENT AREA>
        private void grid1_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {

            bool chk = Convert.ToString(this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value).ToUpper() == "TRUE" ? true : false;

            if (chk == true)
            {
                this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = false;
            }
            else
            {
                this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = true;
            }
            // this.grid1.UpdateGridData();

            int LotCnt = 0;
            for (int i = 0; i < this.grid1.Rows.Count; i++)
            {
                if (this.grid1.Rows[i].Cells["CHK"].Value.ToString().ToUpper() == "TRUE")
                {
                    LotCnt = LotCnt + 1;
                }
            }
            txtLotCnt.Text = Convert.ToString(LotCnt);

        }

        private void btnMM2200_1_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void btnMM2200_2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grid1.Rows.Count; i++)
            {
                this.grid1.Rows[i].Cells["CHK"].Value = false;
            }
            txtLotCnt.Text = "0";
        }


        #endregion <EVENT AREA>
    }
}

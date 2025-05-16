#region <HEADER AREA>
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM2100
//   Form Name    : 자재 입고처리
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
    public partial class MM2100 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region <CONSTRUCTOR>
        public MM2100()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWHCode, txtWHName, "TBM0800", new object[] { cboPlantCode, "", "", "", "" });
            btbManager.PopUpAdd(txtStorageLOCCode, txtStorageLOCName, "TBM0900", new object[] { cboPlantCode, txtWHCode, "", "", "" });

            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0301", new object[] { cboPlantCode_H, "", "" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });


        }
        #endregion

        #region  <LOAD EVENT>
        private void MM2100_Load(object sender, EventArgs e)
        {
            //GRID SETTING
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 150, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 200, 500, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InDate", "입고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MatLotNo", "Lot번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PoNo", "P/O번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PoSeqNo", "P/O순번", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "업체코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "업체명", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotSize", "LOT크기", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PODate", "구매발주일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotQty", "입고량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspFlag", "검사여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

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
            // 입고구분
            rtnDtTemp = _Common.GET_BM0000_CODE("INTYPE");  //입고구분
            WIZ.Common.FillComboboxMaster(this.cboInType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            //InspFlag
            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");  //검사여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
                base.DoInquire();
                cboPlantCode.Text = "";              //사업장
                cboInType.Text = "";                 // 입고구분
                txtStorageLOCCode.Text = "";         // 저장위치 (창고코드) 	
                txtStorageLOCName.Text = "";         // 저장위치이름  
                txtWHCode.Text = "";                 //창고코드
                txtWHName.Text = "";                 //창고이름

                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value); // 사업장(공장)
                string sItemCode = this.txtItemCode.Text.Trim();                 // 품목
                string sCustCode = this.txtCustCode.Text.Trim();                 // 거래선
                string sPoNo = this.txtPoNo.Text.Trim();                         // 발주번호(PONO

                grid1.DataSource = helper.FillTable("USP_MM2100_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)     //사업부(공장)
                                                                   , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)       //품목
                                                                   , helper.CreateParameter("CustCode", sItemCode, DbType.String, ParameterDirection.Input)       //거래선
                                                                   , helper.CreateParameter("PoNo", sPoNo, DbType.String, ParameterDirection.Input));             //발주번호(PoNo
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

                string sInType = Convert.ToString(this.cboInType.Value);  // 입고구분
                string sStorageLocCode = txtStorageLOCCode.Text.Trim();   // 저장위치 (창고코드) 	
                string sWHCode = txtWHCode.Text.Trim();                   //창고코드

                if (sInType == "")
                {
                    MessageBox.Show(Common.getLangText("입고구분이 선택되지 않았습니다.", "MSG"), "LOT 병합 실패");
                    return;
                }

                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    CHK = this.grid1.Rows[i].Cells["CHK"].Value.ToString().ToUpper() == "TRUE" ? true : false;

                    if (CHK == true)
                    {
                        helper.ExecuteNoneQuery("USP_MM2100_I1", CommandType.StoredProcedure
                                                               , helper.CreateParameter("PLANTCODE", Convert.ToString(this.grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("MatLotNo", Convert.ToString(this.grid1.Rows[i].Cells["MatLotNo"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("PoNo", Convert.ToString(this.grid1.Rows[i].Cells["PoNo"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("PoSeqNo", Convert.ToString(this.grid1.Rows[i].Cells["PoSeqNo"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("InType", sInType, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("CustCode", Convert.ToString(this.grid1.Rows[i].Cells["CustCode"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("LotQty", Convert.ToString(this.grid1.Rows[i].Cells["LotQty"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("UnitCode", Convert.ToString(this.grid1.Rows[i].Cells["UnitCode"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("STORAGELOCCODE", sStorageLocCode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("WHCode", sWHCode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("InspFlag", Convert.ToString(this.grid1.Rows[i].Cells["InspFlag"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("InWorker", this.WorkerID, DbType.String, ParameterDirection.Input));
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

        private void btnMM2100_1_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void btnMM2100_2_Click(object sender, EventArgs e)
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

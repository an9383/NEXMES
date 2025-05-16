#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  MM1200
//   Form Name    : 블록재고 부적합 처리 후 대체 입고된 정보 이력  조회  
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.MM
{
    public partial class MM1200 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        #endregion

        #region < CONSTRUCTOR >

        public MM1200()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { cboPlantCode_H, "", "" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
        }
        #endregion

        #region  MM1200_Load
        private void MM1200_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MatLotNo", "Lot번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StockQty", "입고수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "업체코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "업체명", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NotFitResDate", "대체입고일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "불량발생일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NotFitResWorker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

        }
        #endregion  MM1200_Load

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

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                                    // 사업장 공장코드
                string sSrart = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);                              // 시작일자
                string sEnd = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);
                string sItemCode = this.txtItemCode.Text;                                                      // 품목
                string sCustCode = this.txtCustCode.Text.Trim();                                               // 업체코드              	

                grid1.DataSource = helper.FillTable("USP_MM1200_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                         // 사업장 공장코드    
                                                                    , helper.CreateParameter("NotFitResDateS", sSrart, DbType.String, ParameterDirection.Input)                        // 일자 FROM          
                                                                    , helper.CreateParameter("NotFitResDateE", sEnd, DbType.String, ParameterDirection.Input)                          // 일자 TO            
                                                                    , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)                           // 지시번호          
                                                                    , helper.CreateParameter("CustCode", sCustCode, DbType.String, ParameterDirection.Input));                         // 지시번호          

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
        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의
        //#region 텍스트 박스에서 팝업창에서 값 가져오기

        //private void Search_Pop_Item()
        //{
        //    string sitem_cd = this.txtItemCode.Text.Trim();    // 품목
        //    string sitem_name = this.txtItemName.Text.Trim();  // 품목명
        //    string sPlantCode = Convert.ToString(cboPlantCode_H.SelectedValue);
        //    // string splantcd = "820";
        //    string sitemtype = "";


        //    try
        //    {

        //        _DtTemp = _biz.SEL_TBM0100(sPlantCode, sitem_cd, sitem_name, sitemtype);

        //        if (_DtTemp.Rows.Count > 1)
        //        {
        //            // 품목 POP-UP 창 처리
        //            PopUpManager pu = new PopUpManager();
        //            _DtTemp = pu.OpenPopUp("Item", new string[] { sPlantCode, sitemtype, sitem_cd, sitem_name }); // 품목 조회 POP-UP창 Parameter(비가동코드, 비가동명, 비가동그룹)

        //            if (_DtTemp != null && _DtTemp.Rows.Count > 0)
        //            {
        //                txtItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
        //                txtItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
        //            }
        //        }
        //        else
        //        {
        //            if (_DtTemp.Rows.Count == 1)
        //            {
        //                txtItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
        //                txtItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
        //            }
        //            else
        //            {
        //                MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
        //                txtItemCode.Text = string.Empty;
        //                txtItemName.Text = string.Empty;
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR", ex.Message);
        //    }

        //}
        //#endregion
        //private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.txtItemName.Text = string.Empty;
        //}

        //private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        Search_Pop_Item();
        //    }
        //}

        //private void txtItemCode_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Search_Pop_Item();
        //}

        //private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.txtItemCode.Text = string.Empty;
        //}

        //private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //}

        //private void txtItemName_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Search_Pop_Item();
        //}

        //#endregion

        //#region  업체 찾기(조회조전)
        //private void Search_Pop_TBM0300()
        //{
        //    string sCustCode = txtCustCode.Text.Trim();       //업체코드
        //    string sCustName = txtCustName.Text.Trim();       //업체명 
        //    string sCustType = "V";                         //업체구부(V=Vendor) 
        //    string sUseFlag = "Y";                          //사용여부
        //    string sPlantCode = cboPlantCode_H.SelectedValue.ToString() == "ALL" ? "" : cboPlantCode_H.SelectedValue.ToString();
        //    //string sPlantCode = Convert.GetTypeCode(cboPlantCode_H.SelectedValue);
        //    try
        //    {
        //        _biz.TBM0300_POP(sCustCode, sCustName, sCustType, sUseFlag, txtCustCode, txtCustName);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR", ex.Message);
        //    }

        //}
        //#endregion  업체 찾기(조회조전)
        //private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.txtCustName.Text = string.Empty;
        //}

        //private void txtCustName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.txtCustCode.Text = string.Empty;
        //}

        //private void txtCustCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        Search_Pop_TBM0300();
        //    }
        //}

        //private void txtCustCode_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Search_Pop_TBM0300();
        //}



        //private void txtCustName_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        Search_Pop_TBM0300();
        //    }
        //}

        //private void txtCustName_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Search_Pop_TBM0300();
        //}

        //#region grid POP UP 처리
        //private void grid_POP_UP()
        //{
        //    int iRow = this.grid1.ActiveRow.Index;
        //    string sPlantCode = Convert.ToString(this.grid1.Rows[iRow].Cells["PlantCode"].Value);  // 사업부
        //    string sItemCode = this.grid1.Rows[iRow].Cells["ItemCode"].Text.Trim();  // 품목
        //    string sItemname = this.grid1.Rows[iRow].Cells["Itemname"].Text.Trim();  // 품목명

        //    string sCustCode = this.grid1.Rows[iRow].Cells["CustCode"].Text.Trim();  // 업체코드
        //    string sCustName = this.grid1.Rows[iRow].Cells["CustName"].Text.Trim();  // 업체명

        //    if (this.grid1.ActiveCell.Column.ToString() == "ItemCode" || this.grid1.ActiveCell.Column.ToString() == "Itemname")
        //    {

        //        _biz.TBM0100_POP_Grid(sItemCode, sItemname, sPlantCode, "", grid1, "ItemCode", "Itemname");
        //    }
        //    if (this.grid1.ActiveCell.Column.ToString() == "CustCode" || this.grid1.ActiveCell.Column.ToString() == "CustName")
        //    {

        //        _biz.TBM0301_POP_Grid(sCustCode, sCustName, sPlantCode, "V", "", grid1, "CustCode", "CustName");
        //    }

        //}
        //private void grid1_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        //{
        //    grid_POP_UP();
        //}

        //private void grid1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        grid_POP_UP();
        //    }

        //}


        #endregion  //grid POP-UP 처리
    }
}

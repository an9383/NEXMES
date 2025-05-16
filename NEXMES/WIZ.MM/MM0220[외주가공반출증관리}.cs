#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0220
//   Form Name    : 기타입출고
//   Name Space   : WIZ.MM
//   Created Date : 2015-09-14
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM0220 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        UltraGridUtil _GridUtil = new UltraGridUtil();
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable Dt = new DataTable(); // return DataTable 공통

        private string CheckTabIndex = "";
        private string plantCode = string.Empty; //plantcode default 설정
        #endregion

        #region < CONSTRUCTOR >

        public MM0220()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCodeI, txtItemNameI, "TBM0100", new object[] { cboPlantCode, "" });
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { cboPlantCode, "", "", "Y" });

            this.plantCode = CModule.GetAppSetting("Site", "10");

        }
        #endregion

        #region  MM0220_Load
        private void MM0220_Load(object sender, EventArgs e)
        {

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            cboPlantCode.Value = plantCode;
            string sPlantCode = Convert.ToString(this.cboPlantCode.Value);

            rtnDtTemp = _Common.GET_BM0000_CODE("LOTSTATUS");  //LOT상태

            //rtnDtTemp = _Common.GET_TBM0800_CODE(sPlantCode);  //창고
            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE");  //창고

            WIZ.Common.FillComboboxMaster(this.cboWhCodeI, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboWhCodeO, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("INTYPE", "RELCODE2 = 'MM0220'");  // 입고유형
            WIZ.Common.FillComboboxMaster(this.cboTransTypeI, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("OUTTYPE", "RELCODE2 = 'MM0220'");  // 출고유형
            WIZ.Common.FillComboboxMaster(this.cboTransTypeO, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("STORAGELOCCODE", "RELCODE1 = '" + cboWhCodeI.Value + "'");  // 저장위치
            WIZ.Common.FillComboboxMaster(this.cboStoreageLocCodeI, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            #endregion

        }
        #endregion  MM0220_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {

            DoClear();

            if (txtLotNo.Text == "")
            {
                this.ShowDialog(Common.getLangText("LOT NO를 입력해주세요", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            DBHelper helper = new DBHelper(false);
            try
            {
                string sPlantCode = this.cboPlantCode.Value.ToString();
                string sLotNO = this.txtLotNo.Text = this.txtLotNo.Text.ToString();
                Dt = helper.FillTable("USP_MM0220Y_S1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@LotNo", sLotNO, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@CheckTabIndex", CheckTabIndex, DbType.String, ParameterDirection.Input)
                                                    );
                this.ClosePrgFormNew();
                if (Dt.Rows.Count == 0)
                {
                    if (CheckTabIndex == "I")
                    {
                        MessageBox.Show(Common.getLangText("기타 입고 대상 LOT NO 가 아닙니다.", "MSG"));
                    }
                    if (CheckTabIndex == "O")
                    {
                        MessageBox.Show(Common.getLangText("기타 출고 대상 LOT NO 가 아닙니다.", "MSG"));
                    }
                }
                else
                {
                    if (CheckTabIndex == "I")
                    {
                        //
                        this.txtInQty.Text = Dt.Rows[0]["LotBaseQty"].ToString();
                        this.txtLotNoI.Text = Dt.Rows[0]["MatLotNo"].ToString();
                        this.txtLotStatusI.Text = Dt.Rows[0]["LotStatus"].ToString();
                        this.txtItemCodeI.Text = Dt.Rows[0]["ItemCode"].ToString();
                        this.txtItemNameI.Text = Dt.Rows[0]["ItemName"].ToString();
                        this.txtCustCodeI.Text = Dt.Rows[0]["CustCode"].ToString();
                        this.txtCustNameI.Text = Dt.Rows[0]["CustName"].ToString();
                        this.lblCustLotNoI.Text = Dt.Rows[0]["CustLotNo"].ToString();
                        this.txtLotBaseQtyI.Text = Dt.Rows[0]["LotBaseQty"].ToString();
                        this.txtLotQtyI.Text = Dt.Rows[0]["LotQty"].ToString();
                        this.txtUnitCodeI.Text = Dt.Rows[0]["UnitCode"].ToString();
                        this.txtPreInDateI.Text = Dt.Rows[0]["PreIndate"].ToString();
                        this.txtInDateI.Text = Dt.Rows[0]["Indate"].ToString();

                    }
                    else
                    {
                        this.txtOutQty.Text = Dt.Rows[0]["LotBaseQty"].ToString();

                        this.txtLotNoO.Text = Dt.Rows[0]["MatLotNo"].ToString();
                        this.txtLotStatusO.Text = Dt.Rows[0]["LotStatus"].ToString();
                        this.txtItemCodeO.Text = Dt.Rows[0]["ItemCode"].ToString();
                        this.txtItemNameO.Text = Dt.Rows[0]["ItemName"].ToString();
                        this.txtCustCodeO.Text = Dt.Rows[0]["CustCode"].ToString();
                        this.txtCustNameO.Text = Dt.Rows[0]["CustName"].ToString();
                        this.txtCustLotNoO.Text = Dt.Rows[0]["CustLotNo"].ToString();
                        this.txtLotBaseQtyO.Text = Dt.Rows[0]["LotBaseQty"].ToString();
                        this.txtLotQtyO.Text = Dt.Rows[0]["LotQty"].ToString();
                        this.txtUnitCodeO.Text = Dt.Rows[0]["UnitCode"].ToString();
                        this.txtPreInDateO.Text = Dt.Rows[0]["PreIndate"].ToString();
                        this.txtInDateO.Text = Dt.Rows[0]["Indate"].ToString();
                        this.txtLotCloseDateO.Text = Dt.Rows[0]["LotCloseDate"].ToString();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                ClosePrgFormNew();
            }
        }

        #endregion
        #region <METHOD AREA>

        private void DoClear()
        {
            if (this.tabControl1.SelectedTab.Index == 0)
            {
                //조회내역 클리어
                txtLotNoI.Text = "";
                txtLotStatusI.Text = "";
                txtItemCodeI.Text = "";
                txtItemNameI.Text = "";
                txtCustCodeI.Text = "";
                txtCustNameI.Text = "";
                lblCustLotNoI.Text = "";
                txtLotBaseQtyI.Text = "";
                txtLotQtyI.Text = "";
                txtUnitCodeI.Text = "";
                txtPrintDateI.Text = "";
                txtPreInDateI.Text = "";
                txtInDateI.Text = "";

                //입력부분 클리어
                this.cboTransTypeI.Value = "";
                this.txtInQty.Text = "0";
                this.cboWhCodeI.Value = "";
                this.cboStoreageLocCodeI.Value = "";
                this.txtRemarkI.Text = "";

                this.CheckTabIndex = "I";
            }
            else
            {
                //조회내역 클리어
                txtLotNoO.Text = "";
                txtLotStatusO.Text = "";
                txtItemCodeO.Text = "";
                txtItemNameO.Text = "";
                txtCustCodeO.Text = "";
                txtCustNameO.Text = "";
                txtCustLotNoO.Text = "";
                txtLotBaseQtyO.Text = "";
                txtLotQtyO.Text = "";
                txtUnitCodeO.Text = "";
                txtPrintDateO.Text = "";
                txtPreInDateO.Text = "";
                txtInDateO.Text = "";
                txtLotCloseDateO.Text = "";

                //입력부분 클리어
                this.cboTransTypeO.Value = "";
                this.txtOutQty.Text = "0";

                this.cboWhCodeO.Value = "WH003"; //공정창고
                cboWhCodeO.ReadOnly = true;

                this.txtRemarkO.Text = "";
                this.txtCustCode.Text = "";
                this.txtCustName.Text = "";

                this.CheckTabIndex = "O";
            }

        }

        #endregion


        private void btnSave_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            string sPlantCode = this.cboPlantCode.Value.ToString();
            string sLotNo = "";
            string sStorageLocCode = "";
            string sTransType = "";
            string sItemCode = "";
            string sQty = "";
            string sWHCode = "";
            string sCustCode = "";
            string sLotOutType = "";
            string sRemark = "";
            string sUnitCode = "";


            string HLotno = this.txtLotNo.Text.ToString();

            //기타입고시
            if (this.CheckTabIndex == "I" && this.tabControl1.SelectedTab.Index == 0)
            {
                if (cboTransTypeI.Text == "ALL")
                {
                    MessageBox.Show(Common.getLangText("기타입고유형을 선택해주십시오.", "MSG"));
                    return;
                }

                if (cboStoreageLocCodeI.Text == "ALL")
                {
                    MessageBox.Show(Common.getLangText("저장위치를 선택해주십시오.", "MSG"));
                    return;
                }

                if (txtLotNoI.Text == "")
                {
                    MessageBox.Show(Common.getLangText("먼저 기타입고할 LOTNO를 조회해주십시오.", "MSG"));
                    return;
                }

                sQty = this.txtInQty.Text.ToString();
                if (sQty == "" || sQty == "0")
                {
                    MessageBox.Show(Common.getLangText("기타 입고 수량을 입력하지 않았습니다.", "MSG"));
                    this.txtInQty.Focus();
                    return;
                }

                if (Convert.ToInt16(txtInQty.Text) > Convert.ToInt16(txtLotBaseQtyI.Text))
                {
                    MessageBox.Show(Common.getLangText("기타입고 수량은 해당 LOTNO의 기본 수량을 초과할 수 없습니다.", "MSG"));
                    return;
                }

                //if (txtRemarkI.Text == "")
                //{
                //    MessageBox.Show(Common.getLangText("사유를 입력하지 않았습니다.", "MSG"));
                //    this.txtRemarkI.Focus();
                //    return;
                //}

                //입고 처리 하시겠습니까 ? 
                if (this.ShowDialog(Common.getLangText("입고 처리 하시겠습니까 ?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                sLotNo = Convert.ToString(txtLotNoI.Text);
                sItemCode = Convert.ToString(txtItemCodeI.Text);
                sUnitCode = Convert.ToString(txtUnitCodeI.Text);

                sTransType = Convert.ToString(cboTransTypeI.Value);
                sWHCode = Convert.ToString(cboWhCodeI.Value);
                sStorageLocCode = Convert.ToString(cboStoreageLocCodeI.Value);
                sRemark = Convert.ToString(txtRemarkI.Text);

            }

            //기타출고시
            else if (this.CheckTabIndex == "O" && this.tabControl1.SelectedTab.Index == 1)
            {

                //출고처 구분이 공정창고인 경우
                if (rdoLotOutType1.Checked)
                {
                    cboWhCodeO.Value = "WH003"; //공정창고로 자동설정
                    cboWhCodeO.ReadOnly = true;
                    sLotOutType = "50";
                }

                //출고처 구분이 사급출고인 경우
                if (rdoLotOutType2.Checked)
                {
                    //거래처 필수입력
                    if (this.txtCustCode.Text == "")
                    {
                        MessageBox.Show(Common.getLangText("기타 출고 거래처를 입력하지 않았습니다.", "MSG"));
                        this.txtCustCode.Focus();
                        return;
                    }
                    sCustCode = Convert.ToString(txtCustCodeO.Text);
                    sLotOutType = "90";
                }

                if (cboTransTypeO.Text == "ALL")
                {
                    MessageBox.Show(Common.getLangText("기타출고유형을 선택해주십시오.", "MSG"));
                    return;
                }

                if (txtLotNoO.Text == "")
                {
                    MessageBox.Show(Common.getLangText("먼저 기타출고할 LOTNO를 조회해주십시오.", "MSG"));
                    return;
                }

                //if (Convert.ToInt16(txtOutQty.Text) > Convert.ToInt16(txtLotQtyO.Text))
                //{
                //    MessageBox.Show("기타출고 수량은 해당 LOTNO의 현재 수량을 초과할 수 없습니다.");
                //    return;
                //}

                sQty = Convert.ToString(txtOutQty.Text);
                //if (sQty == "" || sQty == "0")
                //{
                //    MessageBox.Show("기타 출고 수량을 입력하지 않았습니다.");
                //    this.txtOutQty.Focus();
                //    return;
                //}

                txtOutQty.Text = sQty;

                if (txtRemarkO.Text == "")
                {
                    MessageBox.Show(Common.getLangText("사유를 입력하지 않았습니다.", "MSG"));
                    this.txtRemarkO.Focus();
                    return;
                }

                //출고 처리 하시겠습니까 ? 
                if (this.ShowDialog(Common.getLangText("출고 처리 하시겠습니까 ?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                sItemCode = Convert.ToString(txtItemCodeO.Text);
                sUnitCode = Convert.ToString(txtUnitCodeO.Text);
                sLotNo = Convert.ToString(txtLotNoO.Text);

                sTransType = Convert.ToString(cboTransTypeO.Value);
                sWHCode = Convert.ToString(cboWhCodeO.Value);
                sRemark = Convert.ToString(txtRemarkO.Text);


            }
            else
            {
                MessageBox.Show(Common.getLangText("조회를 실행하지않은 탭의 입/출고 저장기능은 실행할 수 없습니다. 해당화면에서 조회후 진행하세요.", "MSG"));
                return;
            }
            try
            {
                helper.ExecuteNoneQuery("USP_MM0220Y_I1"
                                        , CommandType.StoredProcedure
                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("LotNo", sLotNo, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("STORAGELOCCODE", sStorageLocCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("TransType", sTransType, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("Qty", sQty, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("TransGB", CheckTabIndex, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("WhCode", sWHCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("OUTCUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("LotOutType", sLotOutType, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("Remark", sRemark, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("WorkerId", this.WorkerID, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("UnitCode", sUnitCode, DbType.String, ParameterDirection.Input)
                                       );
                if (helper.RSCODE == "E")
                {
                    //this.ShowDialog("조회이후 LOT 의 상태가 변경되었습니다. 확인후 다시진행하세요.", DialogForm.DialogType.OK);
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    CancelProcess = true;
                    helper.Rollback();
                    return;

                }
                this.ShowDialog(Common.getLangText("데이터가 저장되었습니다.", "MSG"), DialogForm.DialogType.OK);  // 데이터가 저장되었습니다.
                helper.Commit();
                ClosePrgFormNew();
                DoClear();

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

        }

        private void btnResetI_Click(object sender, EventArgs e)
        {
            DoClear();
        }

        private void rdoLotOutType2_Click(object sender, EventArgs e)
        {
            txtCustCode.Text = "";
            txtCustName.Text = "";

            cboWhCodeO.Value = "";
            lblCustCode.Visible = true;
            txtCustCode.Visible = true;
            txtCustName.Visible = true;

            lblWhCodeO.Visible = false;
            cboWhCodeO.Visible = false;
        }

        private void rdoLotOutType1_Click(object sender, EventArgs e)
        {

            cboWhCodeO.Value = "WH003";
            cboWhCodeO.ReadOnly = true;

            lblCustCode.Visible = false;
            txtCustCode.Visible = false;
            txtCustName.Visible = false;

            lblWhCodeO.Visible = true;
            cboWhCodeO.Visible = true;
        }

        private void txtInQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                // 숫자입력 메시지창 표현.
                MessageBox.Show(Common.getLangText("숫자만 입력가능합니다.", "MSG"));
                e.Handled = true;
            }

            if (txtInQty.Text == "")
            {
                txtInQty.Text = "0";
            }
        }

        private void cboWhCodeI_ValueChanged(object sender, EventArgs e)
        {
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("STORAGELOCCODE", "RELCODE1 = '" + cboWhCodeI.Value + "'");  // 저장위치
            WIZ.Common.FillComboboxMaster(this.cboStoreageLocCodeI, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
        }

    }
}


#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD2040
//   Form Name    : 수입검사 취소
//   Name Space   : NEXPDA
//   Created Date : 2018-03-30
//   Made By      :
//   Edited Date  : 
//   Edit By      :
//   Description  : 재고상태의 자재를 수입검사 취소 처리하여, 수입검사 대기상태로 변경.
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
#endregion

namespace WIZ.MM
{
    public partial class PD2040 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        //UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성
        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        private string gBarCode = string.Empty;

        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public PD2040()
        {
            InitializeComponent();
        }

        #endregion

        #region < FORM LOAD >
        private void PD2040_Load(object sender, EventArgs e)
        {
            //타이틀 설정
            lblFormName.Text = lblFormName.Text + " (" + LoginInfo.PlantCode + "-" + LoginInfo.UserID + ")";

            txtInputBarCode.Select();
        }
        #endregion

        #region < USER METHOD AREA >
        private void ControlClear()
        {
            txtInputBarCode.Text = string.Empty;
            txtBarCode.Text = string.Empty;
            txtPoNo.Text = string.Empty;
            txtCustCode.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtUnitCode.Text = string.Empty;
            txtMaker.Text = string.Empty;
            txtMakeDate.Text = string.Empty;

            txtInputBarCode.Select();

            gBarCode = string.Empty;
        }

        private void ScanLogic()
        {
            try
            {
                gBarCode = txtInputBarCode.Text;

                string sPoNo = string.Empty;             //거래번호
                string sCustCode = string.Empty;             //거래처코드
                string sCustName = string.Empty;             //거래처명
                string sItemCode = string.Empty;             //품번
                string sItemName = string.Empty;             //품명
                string sQty = string.Empty;             //수량(가입고수량)
                string sUnitCode = string.Empty;             //단위
                string sMaker = string.Empty;             //라벨 발행자
                string sMakeDate = string.Empty;             //라벨 발행날자


                DataTable _dt = new DataTable();
                _dt = USP_PD2040_S1(gBarCode, ref RS_CODE, ref RS_MSG);
                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        sPoNo = Convert.ToString(_dt.Rows[0]["PONO"]);
                        sCustCode = Convert.ToString(_dt.Rows[0]["CUSTCODE"]);
                        sCustName = Convert.ToString(_dt.Rows[0]["CUSTNAME"]);
                        sItemCode = Convert.ToString(_dt.Rows[0]["ITEMCODE"]);
                        sItemName = Convert.ToString(_dt.Rows[0]["ITEMNAME"]);
                        sQty = Convert.ToString(_dt.Rows[0]["QTY"]);
                        sUnitCode = Convert.ToString(_dt.Rows[0]["UNITCODE"]);
                        sMaker = Convert.ToString(_dt.Rows[0]["WORKER"]);
                        sMakeDate = Convert.ToString(_dt.Rows[0]["INSPDATE"]);

                        txtBarCode.Text = gBarCode;
                        txtPoNo.Text = sPoNo;
                        txtCustCode.Tag = sCustCode;
                        txtCustCode.Text = sCustName;
                        txtItemCode.Text = sItemCode;
                        txtItemName.Text = sItemName;
                        txtQty.Text = sQty;
                        txtUnitCode.Text = sUnitCode;
                        txtMaker.Text = sMaker;
                        txtMakeDate.Text = sMakeDate;

                        txtInputBarCode.Text = string.Empty;
                    }
                }
                else if (RS_CODE == "E")
                {
                    gBarCode = string.Empty;
                    this.ShowDialog(Common.getLangText("[바코드 스캔] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                ControlClear();
                ShowDialog(Common.getLangText("[바코드 스캔] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
            }

        }

        private DataTable USP_PD2040_S1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD2040_S1",
                                                CommandType.StoredProcedure,
                                                helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input),
                                                helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input));

                RS_CODE = Convert.ToString(helper.RSCODE);
                RS_MSG = Convert.ToString(helper.RSMSG);

                return rtnDtTemp;
            }
            catch (Exception ex)
            {
                RS_CODE = "E";
                RS_MSG = ex.Message.ToString();
                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        public void USP_PD2040_I1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                helper.ExecuteNoneQuery("USP_PD2040_I1",
                                                CommandType.StoredProcedure,
                                                helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input),
                                                helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input),
                                                helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                RS_CODE = Convert.ToString(helper.RSCODE);
                RS_MSG = Convert.ToString(helper.RSMSG);

                if (RS_CODE == "S")
                {
                    helper.Commit();
                }
                else if (RS_CODE == "E")
                {
                    helper.Rollback();
                }
            }
            catch (Exception ex)
            {
                RS_CODE = "E";
                RS_MSG = ex.Message.ToString();
                helper.Rollback();
            }
            finally
            {
                helper.Close();
            }
        }


        #endregion

        #region < EVENT AREA >

        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlClear();
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ScanLogic();
            }
        }

        private void btnBarCode_Click(object sender, EventArgs e)
        {
            txtInputBarCode.Text = string.Empty;
            txtInputBarCode.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gBarCode == string.Empty) return;

            DialogResult result = MessageBox.Show("[" + gBarCode + "]" + Common.getLangText("수입검사 취소 하시겠습니까?", "MSG"), "수입검사 취소 처리", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result.ToString().ToUpper() != "YES")
                return;

            try
            {

                USP_PD2040_I1(gBarCode, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    ControlClear();
                    ShowDialog(Common.getLangText("[수입검사 취소 처리] 수입검사 취소 처리 정상 등록", "MSG"), DialogForm.DialogType.OK); //[수입검사 취소 처리] 수입검사 취소 처리 정상 등록

                }
                else if (RS_CODE == "E")
                {
                    ShowDialog(Common.getLangText("[수입검사 취소 처리] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                ShowDialog(Common.getLangText("[수입검사 취소 처리] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
            }
        }

        #endregion 
    }
}

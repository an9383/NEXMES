#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD2010
//   Form Name    : 수입검사 대기등록
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-30
//   Made By      : 
//   Edited Date  : 
//   Edit By      :
//   Description  : 가입고 상태의 자재를 무검사품일 경우 자재재고, 유검사품일 경우 수입검사대기 상태로 변경.
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class PD2010 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        //UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성
        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        private string gBarCode = string.Empty;
        private string gCertificate = string.Empty;
        private string sInspFlag = string.Empty; //검사구분 ( I : 검사, U : 무검사)

        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public PD2010()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM EVENT >
        private void PD2010_Load(object sender, EventArgs e)
        {
            //타이틀 설정
            lblFormName.Text = lblFormName.Text + " (" + LoginInfo.PlantCode + "-" + LoginInfo.UserID + ")";

            txtInputBarCode.Focus();
        }
        #endregion

        #region < USER METHOD AREA >
        private void ControlClear()
        {
            txtInputBarCode.Text = string.Empty;
            txtBarCode.Text = string.Empty;
            txtReportCertificate.Text = string.Empty;
            txtPoNo.Text = string.Empty;
            txtCustName.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtUnitCode.Text = string.Empty;
            txtInspType.Text = string.Empty;
            txtMaker.Text = string.Empty;
            txtMakeDate.Text = string.Empty;

            txtInputBarCode.Focus();

            gBarCode = string.Empty;
        }

        private void ScanLogic()
        {
            try
            {
                gBarCode = txtInputBarCode.Text;
                gCertificate = txtReportCertificate.Text;

                if (gBarCode == string.Empty) return;

                string sPoNo = string.Empty;             //거래번호
                string sCustCode = string.Empty;             //거래처코드
                string sCustName = string.Empty;             //거래처명
                string sItemCode = string.Empty;             //품번
                string sItemName = string.Empty;             //품명
                string sQty = string.Empty;             //수량(가입고수량)
                string sUnitCode = string.Empty;             //단위
                string sMaker = string.Empty;             //라벨 발행자
                string sMakeDate = string.Empty;             //라벨 발행날자
                string sInspFlagNm = string.Empty;             //검사유무


                DataTable _dt = new DataTable();
                _dt = USP_PD2010_S1(gBarCode, ref RS_CODE, ref RS_MSG);

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
                        sMaker = Convert.ToString(_dt.Rows[0]["MAKER"]);
                        sMakeDate = Convert.ToString(_dt.Rows[0]["MAKEDATE"]);
                        sInspFlag = Convert.ToString(_dt.Rows[0]["INSPFLAG"]);
                        sInspFlagNm = Convert.ToString(_dt.Rows[0]["INSPFLAGNM"]);

                        txtBarCode.Text = gBarCode;
                        txtPoNo.Text = sPoNo;
                        txtCustName.Tag = sCustCode;
                        txtCustName.Text = sCustName;
                        txtItemCode.Text = sItemCode;
                        txtItemName.Text = sItemName;
                        txtQty.Text = sQty;
                        txtUnitCode.Text = sUnitCode;
                        txtMaker.Text = sMaker;
                        txtMakeDate.Text = sMakeDate;
                        txtInspType.Text = sInspFlagNm;

                        txtInputBarCode.Text = string.Empty;
                    }
                    else
                    {
                        ControlClear();
                        this.ShowDialog(Common.getLangText("바코드 정보를 확인 할 수 없습니다.", "MSG"), DialogForm.DialogType.OK);
                    }
                }
                else if (RS_CODE == "E")
                {
                    ControlClear();
                    this.ShowDialog(RS_MSG, DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                ControlClear();
                this.ShowDialog(ex.Message, DialogForm.DialogType.OK);
            }
        }

        //수입검사 대기등록 대상 바코드 스캔
        private DataTable USP_PD2010_S1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD2010_S1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input));

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

        // 수입검사 대기등록(검사품)
        private void USP_PD2010_I1(string sBarCode, string sCertificate, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                helper.ExecuteNoneQuery("USP_PD2010_I1"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_CERTIFICATE", sCertificate, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                RS_CODE = helper.RSCODE;
                RS_MSG = helper.RSMSG;

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
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        //수입검사 대기등록(무검사품, 자재입고)
        private void USP_PD2010_I2(string sBarCode, string sCertificate, string sPoNo, string sItemCode, string sCustCode, string sWhCode,
                                   string sStorageLocCode, float fQty, string sUnitCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                helper.ExecuteNoneQuery("USP_PD2010_I2"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_CERTIFICATE", sCertificate, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_STORAGELOCCODE", sStorageLocCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AF_QTY", fQty, DbType.Single, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_UNITCODE", sUnitCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));


                RS_CODE = helper.RSCODE;
                RS_MSG = helper.RSMSG;

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

        private void btnBarCode_Click(object sender, EventArgs e)
        {
            txtInputBarCode.Text = string.Empty;
            txtInputBarCode.Focus();
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ScanLogic();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlClear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gBarCode == string.Empty) return;

            gCertificate = txtReportCertificate.Text;

            try
            {
                if (sInspFlag == "I")
                {
                    DialogResult result = MessageBox.Show("[" + gBarCode + "]" + Common.getLangText("수입검사 대기등록을 하시겠습니까?", "MSG"), "수입검사 대기 등록"
                                                 , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result.ToString().ToUpper() != "YES")
                        return;

                    //검사항목은 수입검사 대기등록
                    USP_PD2010_I1(gBarCode, gCertificate, ref RS_CODE, ref RS_MSG);
                }
                else
                {
                    this.ShowDialog(Common.getLangText("[" + txtItemCode.Text + "]는 무검사 품번입니다. 창고와 위치를 설정하세요.", "MSG"), Forms.DialogForm.DialogType.OK);

                    PD6040 PD6040 = new PD6040();
                    PD6040.ShowDialog();

                    //if (PD6040.pWhCode == string.Empty || PD6040.pStorageLocCode == string.Empty)
                    //{
                    //    ShowDialog(Common.getLangText("[무검사 등록] 창고 및 위치를 선택하세요.", "MSG"), Forms.DialogForm.DialogType.OK); 
                    //    return;
                    //}

                    DialogResult result2 = MessageBox.Show("[" + gBarCode + "]" + "창고: " + DBHelper.nvlString(PD6040.pStorageLocCode) + "수입검사 대기등록을 하시겠습니까?", "창고위치", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result2.ToString().ToUpper() != "YES")
                        return;


                    string sPoNo = txtPoNo.Text.Trim();
                    string sItemCode = txtItemCode.Text.Trim();
                    string sCustCode = DBHelper.nvlString(txtCustName.Tag);
                    string sWhCode = "";
                    string sStorageLocCode = DBHelper.nvlString(PD6040.pStorageLocCode);
                    string sUnitCode = txtUnitCode.Text;

                    float fQty = Convert.ToSingle(txtQty.Text.Trim());

                    //무검사항목은 재고생성 및 이력생성
                    USP_PD2010_I2(gBarCode
                                , gCertificate
                                , sPoNo
                                , sItemCode
                                , sCustCode
                                , sWhCode
                                , sStorageLocCode
                                , fQty
                                , sUnitCode
                                , ref RS_CODE
                                , ref RS_MSG);
                }

                if (RS_CODE == "S")
                {
                    ControlClear();

                    if (sInspFlag == "I")
                    {
                        this.ShowDialog(Common.getLangText("수입검사 대기 정상 등록", "MSG"), DialogForm.DialogType.OK); //수입검사 대기 정상 등록
                    }
                    else
                    {
                        this.ShowDialog(Common.getLangText("자재창고 정상 입고", "MSG"), DialogForm.DialogType.OK); //자재창고 정상 입고
                    }
                }
                else if (RS_CODE == "E")
                {
                    this.ShowDialog(Common.getLangText("[수입검사 대기등록] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("[수입검사 대기등록] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
            }
        }

        #endregion
    }
}

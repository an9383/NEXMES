#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD2030_POP
//   Form Name    : 수입검사 값 입력
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 수입검사 값 입력 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.PopUp
{
    public partial class PD2030_POP : Form
    {
        #region < MEMBER AREA >

        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        DataTable rtnDtTemp = new DataTable();

        private string _sInspCode = string.Empty;
        private string _sItemCode = string.Empty;

        public string _sInputValue = string.Empty;
        public string _sInspResult = string.Empty;
        public string _sValueType = string.Empty;

        #endregion

        #region < CONSTRUCTOR >
        public PD2030_POP(string sItemCode, string sInspCode, string sValueType)
        {
            InitializeComponent();

            _sItemCode = sItemCode;
            _sInspCode = sInspCode;
            _sValueType = sValueType;

            if (sValueType == "V")
            {
                pnlV1.Visible = true;
                pnlV2.Visible = false;

                this.Height = 364;
            }
            else if (sValueType == "J")
            {
                pnlV1.Visible = false;
                pnlV2.Visible = true;
                rdoOK.Checked = true;

                this.Height = 210;
            }
        }
        #endregion

        #region < FORM LOAD >
        private void PD2030_POP_Load(object sender, EventArgs e)
        {
            ScanLogic();

            txtInputValue.Select();
        }

        #endregion

        #region < USER METHOD AREA >

        private void ScanLogic()
        {
            try
            {
                string sInspCode = string.Empty;
                string sInspName = string.Empty;
                string sSpecTypeC = string.Empty;
                string sSpecType = string.Empty;
                string sSpecNol = string.Empty;
                string sSpecUsl = string.Empty;
                string sSpecLsl = string.Empty;

                DataTable _dt = new DataTable();
                _dt = USP_PD2031_S1(_sItemCode, _sInspCode, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        sInspCode = _sInspCode;
                        sInspName = Convert.ToString(_dt.Rows[0]["INSPNAME"]);
                        sSpecTypeC = Convert.ToString(_dt.Rows[0]["SPECTYPE"]);
                        sSpecType = Convert.ToString(_dt.Rows[0]["SPECNAME"]);
                        sSpecNol = Convert.ToString(_dt.Rows[0]["SPECNOL"]);
                        sSpecUsl = Convert.ToString(_dt.Rows[0]["SPECUSL"]);
                        sSpecLsl = Convert.ToString(_dt.Rows[0]["SPECLSL"]);

                        txtInspCode.Text = sInspCode;
                        txtInspName.Text = sInspName;
                        txtSpecTypeC.Text = sSpecTypeC;
                        txtSpecType.Text = sSpecType;
                        txtSpecNol.Text = sSpecNol;
                        txtSpecUsl.Text = sSpecUsl;
                        txtSpecLsl.Text = sSpecLsl;
                    }
                    else
                    {
                        MessageBox.Show(Common.getLangText("조회 결과가 없습니다.", "MSG"), "수입검사 등록");
                    }
                }
                else
                {
                    MessageBox.Show(RS_MSG, "수입검사 등록");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "수입검사 등록");
            }
        }

        private DataTable USP_PD2031_S1(string sItemCode, string sInspCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD2031_S1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input));

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
        #endregion

        #region < EVENT AREA >

        private void btnInputValue_Click(object sender, EventArgs e)
        {
            txtValue.Text = string.Empty;
            txtInspResult.Text = string.Empty;
            txtInspResult.BackColor = Color.Silver;
            txtInspResult.ForeColor = Color.Black;

            txtInputValue.Select();
        }

        private void txtInputValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar.ToString() == "."))
                {
                    e.Handled = true;

                    if (e.KeyChar == 13)
                    {
                        txtValue.Text = txtInputValue.Text.Trim();
                        _sInputValue = txtInputValue.Text.Trim();
                        txtInputValue.Text = string.Empty;

                        if (txtValue.Text == string.Empty) return;

                        string sSpecType = txtSpecTypeC.Text; //spectype , 스펙타입

                        float iStdValue = Convert.ToSingle(txtSpecNol.Text); //기준값
                        float iUslValue = Convert.ToSingle(txtSpecUsl.Text); //상한값
                        float iLslValue = Convert.ToSingle(txtSpecLsl.Text); //하한값
                        float iInputValue = Convert.ToSingle(txtValue.Text);

                        //입력 후 로직..
                        if (sSpecType == "B")
                        {
                            #region [ Spec 양쪽 관리 ]
                            if (iUslValue >= iInputValue && iLslValue <= iInputValue)
                            {
                                //정상범위..
                                //txtInspResult.Appearance.BackColor = Color.Silver;
                                //txtInspResult.Appearance.ForeColor = Color.Black;
                                txtInspResult.Text = "OK";
                            }
                            else
                            {
                                //비정상범위일 경우..
                                //txtInspResult.Appearance.BackColor = Color.Red;
                                //txtInspResult.Appearance.ForeColor = Color.White;
                                txtInspResult.Text = "NG";
                            }
                            #endregion
                        }
                        else if (sSpecType == "U")
                        {
                            #region [ Spec 상한관리 ]
                            if (iUslValue >= iInputValue)
                            {
                                //정상범위일 경우..
                                //txtInspResult.Appearance.BackColor = Color.Silver;
                                //txtInspResult.Appearance.ForeColor = Color.Black;
                                txtInspResult.Text = "OK";
                            }
                            else
                            {
                                //비정상범위
                                //txtInspResult.Appearance.BackColor = Color.Red;
                                //txtInspResult.Appearance.ForeColor = Color.White;
                                txtInspResult.Text = "NG";
                            }
                            #endregion
                        }
                        else if (sSpecType == "L")
                        {
                            #region [ Spec 하한관리 ]
                            if (iLslValue <= iInputValue)
                            {
                                //정상범위
                                //txtInspResult.Appearance.BackColor = Color.Silver;
                                //txtInspResult.Appearance.ForeColor = Color.Black;
                                txtInspResult.Text = "OK";
                            }
                            else
                            {
                                //비정상범위일 경우..
                                //txtInspResult.Appearance.BackColor = Color.Red;
                                //txtInspResult.Appearance.ForeColor = Color.White;
                                txtInspResult.Text = "NG";
                            }

                            #endregion
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "입력값");
            }
            finally
            {
                txtInputValue.Select();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtValue.Text == string.Empty && _sValueType == "V")
            {
                MessageBox.Show("값을 입력한 후, 진행하세요.", "수입검사 등록");
                return;
            }

            if (_sValueType == "J")
            {
                if (rdoOK.Checked)
                    txtInspResult.Text = "OK";
                else if (rdoNG.Checked)
                    txtInspResult.Text = "NG";
            }

            if (txtInspResult.Text == string.Empty)
            {
                MessageBox.Show("입력값을 확인하세요.", "수입검사 등록");
                return;
            }

            //DialogResult result = MessageBox.Show("[" + _sInspCode + "] " + Common.getLangText("검사결과를 등록하시겠습니까?", "MSG"), "수입검사 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            //if (result.ToString().ToUpper() != "YES")
            //    return;

            try
            {
                if (_sValueType == "V")
                    _sInputValue = txtValue.Text.Trim();
                else
                    _sInputValue = txtInspResult.Text.Trim();

                _sInspResult = txtInspResult.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "수입검사 등록");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}

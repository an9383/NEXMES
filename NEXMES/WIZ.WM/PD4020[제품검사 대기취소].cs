#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD4020
//   Form Name    : 제품검사 대기취소
//   Name Space   : WIZ.WM
//   Created Date : 2018-04-03
//   Made By      : 
//   Edited Date  : 
//   Edit By      :
//   Description  : 제품검사 대기 상태의 LOT을 제품가입고 상태로 변경.
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
#endregion

namespace WIZ.WM
{
    public partial class PD4020 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        private string gBarCode = string.Empty;
        private string sInspFlag = string.Empty; //검사구분 ( I : 검사, U : 무검사)

        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >

        public PD4020()
        {
            InitializeComponent();
        }

        #endregion

        #region < FORM LOAD >

        private void PD4020_Load(object sender, EventArgs e)
        {
            txtInputBarCode.Focus();
        }

        #endregion

        #region [ USER METHOD AREA ]

        private void ControlClear()
        {
            txtInputBarCode.Text = string.Empty;
            txtBarCode.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtUnitCode.Text = string.Empty;
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

                if (gBarCode == string.Empty) return;

                string sItemCode = string.Empty;    //품번
                string sItemName = string.Empty;    //품명
                string sQty = string.Empty;    //수량
                string sUnitCode = string.Empty;    //단위
                string sMakeDate = string.Empty;
                string sMaker = string.Empty;

                DataTable _dt = new DataTable();
                _dt = USP_PD4020_S1(gBarCode, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        sItemCode = Convert.ToString(_dt.Rows[0]["ITEMCODE"]);
                        sItemName = Convert.ToString(_dt.Rows[0]["ITEMNAME"]);
                        sQty = Convert.ToString(_dt.Rows[0]["NOWQTY"]);
                        sUnitCode = Convert.ToString(_dt.Rows[0]["UNITCODE"]);
                        sMaker = Convert.ToString(_dt.Rows[0]["MAKER"]);
                        sMakeDate = Convert.ToString(_dt.Rows[0]["MAKEDATE"]);

                        txtInputBarCode.Text = string.Empty;

                        txtBarCode.Text = gBarCode;
                        txtItemCode.Text = sItemCode;
                        txtItemName.Text = sItemName;
                        txtQty.Text = sQty;
                        txtUnitCode.Text = sUnitCode;
                        txtMaker.Text = sMaker;
                        txtMakeDate.Text = sMakeDate;
                    }
                    else
                    {
                        ControlClear();
                        ShowDialog(Common.getLangText("조회 결과가 없습니다.", "MSG"), DialogForm.DialogType.OK);
                    }
                }
                else
                {
                    ControlClear();
                    ShowDialog(RS_MSG, DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                ControlClear();
                ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                txtInputBarCode.Text = string.Empty;
            }
        }

        private DataTable USP_PD4020_S1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD4020_S1"
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

        private void USP_PD4020_I1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                helper.ExecuteNoneQuery("USP_PD4020_I1"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

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

        #endregion

        #region [ EVENT AREA ]

        private void btnBarCode_Click(object sender, EventArgs e)
        {
            txtInputBarCode.Text = string.Empty;
            txtInputBarCode.Focus();
        }

        private void txtInputBarCode_KeyPress(object sender, KeyPressEventArgs e)
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

            DialogResult result = MessageBox.Show("[" + gBarCode + "] 제품검사 대기취소를 하시겠습니까?", "제품검사 대기취소", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result.ToString().ToUpper() != "YES")
                return;

            try
            {
                USP_PD4020_I1(gBarCode, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    ControlClear();
                    ShowDialog(Common.getLangText("제품검사 대기취소 완료", "MSG"), DialogForm.DialogType.OK);
                }
                else if (RS_CODE == "E")
                {
                    ShowDialog(RS_MSG, DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
        }

        #endregion
    }
}

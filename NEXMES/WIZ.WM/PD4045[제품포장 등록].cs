#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD4045
//   Form Name    : 제품출고 등록
//   Name Space   : NEXPDA
//   Created Date : 2018-03-30
//   Made By      :
//   Edited Date  : 
//   Edit By      :
//   Description  : 재고상태의 제품을 제품 출고 등록 처리.
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class PD4045 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        private string gBarCode = string.Empty;

        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string _sFlag; // "Y" = 검사 후 입고, "N" = 입고 후 검사

        #endregion

        #region [ CONSTRUCTOR ]
        public PD4045()
        {
            InitializeComponent();

            SearchFlag();
        }
        #endregion

        #region < FORM LOAD >
        private void PD4045_Load(object sender, EventArgs e)
        {
            txtInputBarCode.Select();

            btbManager.PopUpAdd(txtCustCode, txtCustName, "BM0030", new object[] { LoginInfo.PlantCode, "CT", "", "" });

        }
        #endregion

        #region < USER METHOD AREA >

        private void ControlClear()
        {
            txtInputBarCode.Text = string.Empty;
            txtBarCode.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtWhCode.Text = string.Empty;
            txtWhName.Text = string.Empty;
            txtStorageLocCode.Text = string.Empty;
            txtStorageLocName.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtUnitCode.Text = string.Empty;
            txtInDate.Text = string.Empty;
            txtCustCode.Text = string.Empty;
            txtCustName.Text = string.Empty;

            txtInputBarCode.Select();

            gBarCode = string.Empty;
        }

        private void ScanLogic()
        {
            try
            {
                gBarCode = txtInputBarCode.Text;

                if (gBarCode == string.Empty) return;

                string sItemCode = string.Empty;
                string sItemName = string.Empty;
                string sQty = string.Empty;
                string sUnitCode = string.Empty;
                string sInDate = string.Empty;
                string sPackNum = string.Empty;
                string sWhCode = string.Empty;
                string sWhName = string.Empty;
                string sStorageLocCode = string.Empty;
                string sstorageLocName = string.Empty;

                DataTable _dt = new DataTable();
                _dt = USP_PD4045_S1(gBarCode, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        sItemCode = Convert.ToString(_dt.Rows[0]["ITEMCODE"]);
                        sItemName = Convert.ToString(_dt.Rows[0]["ITEMNAME"]);
                        sQty = Convert.ToString(_dt.Rows[0]["QTY"]);
                        sUnitCode = Convert.ToString(_dt.Rows[0]["UNITCODE"]);
                        sWhCode = Convert.ToString(_dt.Rows[0]["WHCODE"]);
                        sWhName = Convert.ToString(_dt.Rows[0]["WHNAME"]);
                        sStorageLocCode = Convert.ToString(_dt.Rows[0]["STORAGELOCCODE"]);
                        sstorageLocName = Convert.ToString(_dt.Rows[0]["STORAGELOCNAME"]);
                        sInDate = Convert.ToString(_dt.Rows[0]["INDATE"]);
                        sPackNum = Convert.ToString(_dt.Rows[0]["PACKNO"]);

                        txtInputBarCode.Text = string.Empty;

                        txtBarCode.Text = gBarCode;
                        txtItemCode.Text = sItemCode;
                        txtItemName.Text = sItemName;
                        txtQty.Text = sQty;
                        txtUnitCode.Text = sUnitCode;
                        txtWhCode.Text = sWhCode;
                        txtWhName.Text = sWhName;
                        txtStorageLocCode.Text = sStorageLocCode;
                        txtStorageLocName.Text = sstorageLocName;
                        txtInDate.Text = sInDate;
                        txtPackNum.Text = sPackNum;
                    }
                    else
                    {
                        ControlClear();
                        ShowDialog(Common.getLangText("조회 결과가 없습니다.", "MSG"), DialogForm.DialogType.OK);
                    }
                }
                else if (RS_CODE == "E")
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
        }

        private DataTable USP_PD4045_S1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD4045_S1"
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

        private void USP_PD4045_I2(string sBarCode, string sItemCode, string sPackNum, string sQty, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                helper.ExecuteNoneQuery("USP_PD4045_12"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_LOTNO", sBarCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_PACKNO", sPackNum, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_PACKQTY", sQty, DbType.Decimal, ParameterDirection.Input)
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

        private void SearchFlag()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = new DataTable();

                rtnDtTemp = helper.FillTable("USP_WM0000_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input));

                _sFlag = Convert.ToString(rtnDtTemp.Rows[0]["FLAG"]);
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private bool AskRelease(string sLotNo)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = new DataTable();
                rtnDtTemp = helper.FillTable("USP_PD4045_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count == 0)
                {
                    DialogResult result = MessageBox.Show("[" + gBarCode + "] 제품 검사 이력이 없습니다. 그래도 제품출고 처리 하시겠습니까?", "제품출고 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result.ToString().ToUpper() == "YES")
                        return true;
                    else
                        return false;
                }
                else
                {
                    DialogResult result = MessageBox.Show("[" + gBarCode + "] 제품출고 처리 하시겠습니까?", "제품출고 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result.ToString().ToUpper() == "YES")
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
                return false;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gBarCode == string.Empty) return;

            if (_sFlag == "Y")
            {
                DialogResult result = MessageBox.Show("[" + gBarCode + "] 제품출고 처리 하시겠습니까?", "제품출고 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result.ToString().ToUpper() != "YES")
                    return;
            }
            else if (_sFlag == "N")
            {
                if (AskRelease(gBarCode) == false)
                    return;
            }

            try
            {
                //if (txtCustCode.Text == string.Empty)
                //{
                //    ShowDialog(Common.getLangText("출고 거래처를 선택하세요.", "MSG"), DialogForm.DialogType.OK);
                //    return;
                //}

                string sItemCode = txtItemCode.Text.Trim();
                string sPackNum = txtInputPackNumber.Text.Trim();
                string sQty = txtQty.Text.Trim();

                USP_PD4045_I2(gBarCode, sItemCode, sPackNum, sQty, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    ControlClear();
                    ShowDialog(Common.getLangText("제품포장 완료", "MSG"), DialogForm.DialogType.OK);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlClear();
        }

        #endregion
    }
}

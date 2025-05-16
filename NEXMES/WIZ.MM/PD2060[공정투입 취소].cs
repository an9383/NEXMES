#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD2060
//   Form Name    : 현장출고 취소
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-30
//   Made By      : 
//   Edited Date  : 
//   Edit By      :
//   Description  : 현장출고 상태의 자재를 현장출고 취소 처리.(자재재고 상태로 변경)
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
    public partial class PD2060 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        private string gBarCode = string.Empty;

        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public PD2060()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PD2060_Load(object sender, EventArgs e)
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
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtWhCode.Text = string.Empty;
            txtWhName.Text = string.Empty;
            txtStorageLocCode.Text = string.Empty;
            txtStorageLocName.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtUnitCode.Text = string.Empty;
            txtOutWorker.Text = string.Empty;
            txtOutDate.Text = string.Empty;

            txtInputBarCode.Focus();

            gBarCode = string.Empty;
        }

        private void ScanLogic()
        {
            try
            {
                DBHelper helper = new DBHelper(false);
                gBarCode = txtInputBarCode.Text;

                if (gBarCode == string.Empty) return;

                string sItemCode = string.Empty;
                string sItemName = string.Empty;
                string sQty = string.Empty;
                string sUnitCode = string.Empty;
                string sOutWorker = string.Empty;
                string sOutDate = string.Empty;
                string sWhCode = string.Empty;
                string sWhName = string.Empty;
                string sStorageCode = string.Empty;
                string sStorageName = string.Empty;

                DataTable _dt = new DataTable();
                _dt = USP_PD2060_S1(gBarCode, ref RS_CODE, ref RS_MSG);
                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        sItemCode = DBHelper.nvlString(_dt.Rows[0]["ITEMCODE"]);
                        sItemName = DBHelper.nvlString(_dt.Rows[0]["ITEMNAME"]);
                        sQty = DBHelper.nvlString(_dt.Rows[0]["QTY"]);
                        sUnitCode = DBHelper.nvlString(_dt.Rows[0]["UNITCODE"]);
                        sWhCode = DBHelper.nvlString(_dt.Rows[0]["WHCODE"]);
                        sWhName = DBHelper.nvlString(_dt.Rows[0]["WHNAME"]);
                        sStorageCode = DBHelper.nvlString(_dt.Rows[0]["STORAGELOCCODE"]);
                        sStorageName = DBHelper.nvlString(_dt.Rows[0]["STORAGELOCNAME"]);
                        sOutWorker = DBHelper.nvlString(_dt.Rows[0]["OUTWORKER"]);
                        sOutDate = DBHelper.nvlString(_dt.Rows[0]["OUTDATE"]);


                        txtBarCode.Text = gBarCode;
                        txtItemCode.Text = sItemCode;
                        txtItemName.Text = sItemName;
                        txtQty.Text = sQty;
                        txtUnitCode.Text = sUnitCode;
                        txtWhCode.Text = sWhCode;
                        txtWhName.Text = sWhName;
                        txtStorageLocCode.Text = sStorageCode;
                        txtStorageLocName.Text = sStorageName;
                        txtOutWorker.Text = sOutWorker;
                        txtOutDate.Text = sOutDate;

                        txtInputBarCode.Text = string.Empty;
                    }
                    else
                    {
                        ControlClear();
                        this.ShowDialog(Common.getLangText("[바코드 스캔] 바코드 정보를 확인 할 수 없습니다.", "MSG"), DialogForm.DialogType.OK); //[바코드 스캔] 바코드 정보를 확인 할 수 없습니다.
                    }
                }
                else if (RS_CODE == "E")
                {
                    ControlClear();
                    this.ShowDialog(Common.getLangText("[바코드 스캔] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                ControlClear();
                this.ShowDialog(Common.getLangText("[바코드 스캔] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
            }
        }

        private DataTable USP_PD2060_S1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD2060_S1",
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

        private void USP_PD2060_I1(string sBarCode, string sItemCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {


                helper.ExecuteNoneQuery("USP_PD2060_I1",
                                                CommandType.StoredProcedure,
                                                helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input),
                                                helper.CreateParameter("AS_BARCODE", sBarCode.ToUpper(), DbType.String, ParameterDirection.Input),
                                                helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input),
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
        private void btnBarCode_Click(object sender, EventArgs e)
        {
            txtInputBarCode.Text = string.Empty;
            txtInputBarCode.Focus();
        }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gBarCode == string.Empty) return;

            DialogResult result = MessageBox.Show("[" + gBarCode + "]" + Common.getLangText("현장출고 취소 하시겠습니까?", "MSG"), "현장출고 취소", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result.ToString().ToUpper() != "YES")
                return;

            try
            {
                string sItemCode = txtItemCode.Text;

                USP_PD2060_I1(gBarCode, sItemCode, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    ControlClear();
                    this.ShowDialog(Common.getLangText("[ " + RS_MSG + " ] 현장출고 취소 완료", "MSG"), DialogForm.DialogType.OK); //[현장출고 취소] 현장출고 취소 완료
                }
                else if (RS_CODE == "E")
                {
                    this.ShowDialog(Common.getLangText("[현장출고 취소] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("[현장출고 취소] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
            }
        }

        #endregion 


    }
}

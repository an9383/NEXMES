#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD4110
//   Form Name    : 외주 발송
//   Name Space   : NEXPDA
//   Created Date : 2020-11-30
//   Made By      :
//   Edited Date  : 
//   Edit By      :
//   Description  : 
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
    public partial class PD4110 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        private string gBarCode = string.Empty;

        string LOTNO1 = "";
        string LOTNO2 = "";
        string ITEMCODE = "";
        string PONO = "";
        string QTY = "";
        string WEIGHT = "";

        string AP_H = "";
        string dt_ITEMCODE = "";
        string RE_ITEMCODE = "";
        string WORKCENTERCODE = "";
        string TOSUBCODE = "";

        double Q = 0;
        double W = 0;
        string CONVERT_NUM = "";

        string KG = "KG";
        string EA = "EA";

        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        #endregion

        #region [ CONSTRUCTOR ]
        public PD4110()
        {
            lblITEM.Text = "";
            rtnDtTemp.Columns.Add("LOTNO");
            rtnDtTemp.Columns.Add("QTY");

            txtSUMQ.Tag = "Q";
            txtSUMW.Tag = "W";

            txtInputBarCode.Focus();

            GridInit();
        }
        #endregion

        #region < FORM LOAD >
        private void PD4110_Load(object sender, EventArgs e)
        {
            txtInputBarCode.Select();
        }
        #endregion

        #region < USER METHOD AREA >

        private void ControlClear()
        {
            lblITEM.Text = "";
            LOTNO1 = "";
            LOTNO2 = "";
            ITEMCODE = "";
            AP_H = "";
            dt_ITEMCODE = "";
            Q = 0;
            W = 0;
            txtQ.Text = "";
            txtW.Text = "";
            CONVERT_NUM = "";
            WORKCENTERCODE = "";
            TOSUBCODE = "";
            txtInputBarCode.Focus();
            grid1.Items.Clear();
            rtnDtTemp.Rows.Clear();
        }

        private void GridInit()
        {
            grid1.View = View.Details;
            grid1.Columns.Clear();
            grid1.Columns.Add(new Grid.ColHeader("Check", 0, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("LOTNO", 150, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("수량", 60, HorizontalAlignment.Right, true));

        }
        private void ITEMCODE_CHK(string lotno)
        {
            DataTable dt = new DataTable();
            txtInputBarCode.Text = "";

            //로트 정보 확인
            DBHelper DBhelper = new DBHelper(false);

            if (LOTNO1 != "" && LOTNO1 == lotno)
            {
                this.ShowDialog(Common.getLangText("이미 선택된 라벨 번호입니다", "MSG"), DialogForm.DialogType.OK);
                return;
            }
        }

        private DataTable USP_PD4110_S1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD4110_S1"
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

        private void USP_PD4110_I1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                helper.ExecuteNoneQuery("USP_PD4110_I1"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)
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
                ITEMCODE_CHK(txtInputBarCode.Text);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gBarCode == string.Empty) return;

            DialogResult result = MessageBox.Show("[" + gBarCode + "] 제품출고 취소 하시겠습니까?", "제품출고 취소", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result.ToString().ToUpper() != "YES")
                return;

            try
            {
                USP_PD4110_I1(gBarCode, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    ControlClear();
                    ShowDialog(Common.getLangText("제품출고 취소 완료", "MSG"), DialogForm.DialogType.OK);
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

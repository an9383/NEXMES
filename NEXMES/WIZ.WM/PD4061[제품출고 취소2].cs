#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD4061
//   Form Name    : 제품출고 취소
//   Name Space   : NEXPDA
//   Created Date : 2018-03-30
//   Made By      :
//   Edited Date  : 
//   Edit By      :
//   Description  : 출고처리된 제품을 취소처리하여 제품재고로 재입고.
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
    public partial class PD4061 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        private string gBarCode = string.Empty;

        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        #endregion

        #region [ CONSTRUCTOR ]
        public PD4061()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PD4061_Load(object sender, EventArgs e)
        {
            txtInputBarCode.Select();
            txtInputBarCode.Focus();


            grid2.View = View.Details;
            grid2.Columns.Clear();
            grid2.Columns.Add(new Grid.ColHeader("Check", 0, HorizontalAlignment.Left, true));
            grid2.Columns.Add(new Grid.ColHeader("사업장", 0, HorizontalAlignment.Left, true));
            grid2.Columns.Add(new Grid.ColHeader("출하번호", 0, HorizontalAlignment.Left, true));
            grid2.Columns.Add(new Grid.ColHeader("출하순서", 0, HorizontalAlignment.Left, true));
            grid2.Columns.Add(new Grid.ColHeader("품목", 0, HorizontalAlignment.Left, true));
            grid2.Columns.Add(new Grid.ColHeader("고객사번호", 0, HorizontalAlignment.Left, true));
            grid2.Columns.Add(new Grid.ColHeader("수주번호", 150, HorizontalAlignment.Left, true));
            grid2.Columns.Add(new Grid.ColHeader("품명", 150, HorizontalAlignment.Left, true));
            grid2.Columns.Add(new Grid.ColHeader("수량", 150, HorizontalAlignment.Left, true));
            grid2.Columns.Add(new Grid.ColHeader("고객사이름", 150, HorizontalAlignment.Left, true));

        }
        #endregion

        #region < USER METHOD AREA >

        private void ControlClear()
        {
            txtInputBarCode.Text = string.Empty;
            txtBarCode.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtConstractNo.Text = string.Empty;
            txtCustName.Text = string.Empty;
            txtSeloutNo.Text = string.Empty;
            txtQty.Text = string.Empty;
            grid2.Items.Clear();

            txtInputBarCode.Select();
            txtInputBarCode.Focus();

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
                string sCustName = string.Empty;
                string sQty = string.Empty;
                string sUnitCode = string.Empty;
                string sOutDate = string.Empty;
                string sMaker = string.Empty;

                DataTable _dt = new DataTable();
                _dt = USP_PD4061_S1(gBarCode, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        grid2.Items.Clear();

                        for (int i = 0; i < _dt.Rows.Count; i++)
                        {
                            ListViewItem lvl = new ListViewItem();

                            lvl.SubItems.Add(_dt.Rows[i]["PLANTCODE"].ToString());
                            lvl.SubItems.Add(_dt.Rows[i]["SELOUTNO"].ToString());
                            lvl.SubItems.Add(_dt.Rows[i]["CONTRACTSEQ"].ToString());
                            lvl.SubItems.Add(_dt.Rows[i]["ITEMCODE"].ToString());
                            lvl.SubItems.Add(_dt.Rows[i]["CUSTCODE"].ToString());
                            lvl.SubItems.Add(_dt.Rows[i]["CONTRACTNO"].ToString());
                            lvl.SubItems.Add(_dt.Rows[i]["ITEMNAME"].ToString());
                            lvl.SubItems.Add(_dt.Rows[i]["SHIPQTY"].ToString());
                            lvl.SubItems.Add(_dt.Rows[i]["CUSTNAME"].ToString());
                            grid2.Items.Add(lvl);
                            grid2.EndUpdate();
                        }
                        txtInputBarCode.Text = string.Empty;
                        txtBarCode.Text = gBarCode;

                        //sItemCode = Convert.ToString(_dt.Rows[0]["ITEMCODE"]);
                        //sItemName = Convert.ToString(_dt.Rows[0]["ITEMNAME"]);
                        //sCustName = Convert.ToString(_dt.Rows[0]["CUSTNAME"]);
                        //sQty      = Convert.ToString(_dt.Rows[0]["NOWQTY"]);
                        //sUnitCode = Convert.ToString(_dt.Rows[0]["UNITCODE"]);
                        //sOutDate  = Convert.ToString(_dt.Rows[0]["OUTDATE"]);
                        //sMaker    = Convert.ToString(_dt.Rows[0]["MAKER"]);

                        //txtInputBarCode.Text = string.Empty;

                        //txtBarCode.Text  = gBarCode;
                        //txtItemCode.Text = sItemCode;
                        //txtItemName.Text = sItemName;
                        //txtCustName.Text = sCustName;
                        //txtQty.Text      = sQty;
                        //txtUnitCode.Text = sUnitCode;
                        //txtConstractNo.Text  = sOutDate;
                        //txtSeloutNo.Text    = sMaker;
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

        private DataTable USP_PD4061_S1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD4060_S1"
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

        private void USP_PD4061_I1(string sBarCode, string sSeloutNo, string sItemCode, string sQty, string sConstractNo, string sSeq, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                helper.ExecuteNoneQuery("USP_PD4060_I1"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_SELOUTNO", sSeloutNo, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_NOWQTY", sQty, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_CONSTRACTNO", sConstractNo, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_SEQ", sSeq, DbType.String, ParameterDirection.Input)
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
                ScanLogic();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gBarCode == string.Empty) return;

            DialogResult result = MessageBox.Show("[" + gBarCode + "] 제품출고 취소 하시겠습니까?", "제품출고 취소", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result.ToString().ToUpper() != "YES")
                return;

            if (txtSeloutNo.Text == string.Empty)
            {
                ShowDialog(Common.getLangText("출고 번호가 없습니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            if (txtItemCode.Text == string.Empty)
            {
                ShowDialog(Common.getLangText("출고 번호가 없습니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }


            if (txtQty.Text == string.Empty)
            {
                ShowDialog(Common.getLangText("출고 취소 수량을 없습니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            if (txtConstractNo.Text == string.Empty)
            {
                ShowDialog(Common.getLangText("수주번호가 없습니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            if (txtSeq.Text == string.Empty)
            {
                ShowDialog(Common.getLangText("수주순서가 없습니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            string sSeloutNo = txtSeloutNo.Text.Trim();
            string sItemCode = txtItemCode.Text.Trim();
            string sQty = txtQty.Text.Trim();
            string sConstractNo = txtConstractNo.Text.Trim();
            string sSeq = txtSeq.Text.Trim();

            try
            {
                USP_PD4061_I1(gBarCode, sSeloutNo, sItemCode, sQty, sConstractNo, sSeq, ref RS_CODE, ref RS_MSG);

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

        private void grid2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (grid2.Items.Count > 0)
                {

                    if (grid2.Focused == true)
                    {
                        if (grid2.FocusedItem == null)
                            return;

                        txtSeloutNo.Text = grid2.FocusedItem.SubItems[2].Text;
                        txtSeq.Text = grid2.FocusedItem.SubItems[3].Text;
                        txtItemCode.Text = grid2.FocusedItem.SubItems[4].Text;
                        txtConstractNo.Text = grid2.FocusedItem.SubItems[6].Text;
                        txtItemName.Text = grid2.FocusedItem.SubItems[7].Text;
                        txtQty.Text = grid2.FocusedItem.SubItems[8].Text;
                        txtCustName.Text = grid2.FocusedItem.SubItems[9].Text;

                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);

            }
        }
    }
}

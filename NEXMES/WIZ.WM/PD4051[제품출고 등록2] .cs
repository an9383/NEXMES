#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD4051
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
#endregion

namespace WIZ.WM
{
    public partial class PD4051 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        private string gBarCode = string.Empty;

        private string sItem = string.Empty;
        private string sCustCode = string.Empty;
        private string sCustName = string.Empty;
        private string sConstractNo = string.Empty;

        private string sCustNum = string.Empty;

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();
        //BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        //string _sFlag; // "Y" = 검사 후 입고, "N" = 입고 후 검사

        #endregion

        #region [ CONSTRUCTOR ]
        public PD4051()
        {
            InitializeComponent();

            //SearchFlag();
        }
        #endregion

        #region < FORM LOAD >
        private void PD4051_Load(object sender, EventArgs e)
        {
            txtInputBarCode.Select();
            txtInputBarCode.Focus();

            panel1.Visible = true;
            panel2.Visible = false;

            lblFormName.Visible = true;
            lblFormName2.Visible = false;

            sCustNum = "1";  //거래처 로 초기화

            // PD8000 제품일괄 출하를 안 쓰는 경우
            // LOT별 통째로 나가는 경우에는 사용 가능
            // LOT별 나누어서 사용하는 경우에 필요해서 만듬
            // 수주 기준 없이 출하를 
            // 코드마스트: SHIPSELECT
            // SHIPSELECT- AP0110 수주보여주기
            //             BM0030 거래처 기준
            //             BM0210 출하별품목거래처가 있는경우
            // 3개중에 하나만 있어야 한다.

            // btbManager.PopUpAdd(txtCustCode, txtCustName, "BM0030", new object[] { LoginInfo.PlantCode, "CT", "", "" });

            DataTable _dt2 = new DataTable();
            _dt2 = USP_BM0000_S2(ref RS_CODE, ref RS_MSG);

            string MinorCode = "";
            if (RS_CODE == "S")
            {
                if (_dt2.Rows.Count > 0)
                {
                    MinorCode = Convert.ToString(_dt2.Rows[0]["MINORCODE"]);

                    switch (MinorCode)
                    {
                        case "BM0030":
                            sCustNum = "1";

                            break;
                        case "AP0110":
                            sCustNum = "2";
                            grid2.View = View.Details;
                            grid2.Columns.Clear();
                            grid2.Columns.Add(new Grid.ColHeader("CHECK", 0, HorizontalAlignment.Left, true));
                            grid2.Columns.Add(new Grid.ColHeader("사업장", 0, HorizontalAlignment.Left, true));
                            grid2.Columns.Add(new Grid.ColHeader("고객사코드", 0, HorizontalAlignment.Left, true));
                            grid2.Columns.Add(new Grid.ColHeader("품목", 0, HorizontalAlignment.Left, true));
                            grid2.Columns.Add(new Grid.ColHeader("완료", 50, HorizontalAlignment.Center, true));
                            grid2.Columns.Add(new Grid.ColHeader("수주번호", 150, HorizontalAlignment.Left, true));
                            grid2.Columns.Add(new Grid.ColHeader("고객사이름", 150, HorizontalAlignment.Left, true));
                            grid2.Columns.Add(new Grid.ColHeader("품명", 150, HorizontalAlignment.Left, true));
                            break;
                        case "BM0210":
                            sCustNum = "3";
                            break;
                    }
                }
                else
                {
                    ControlClear();
                    ShowDialog(Common.getLangText("조회 결과가 없습니다.", "MSG"), DialogForm.DialogType.OK);

                }
            }
            else
            {
                //grid2.Columns.Add(new Grid.ColHeader("서업장", 0, HorizontalAlignment.Center, true));               
                //grid2.Columns.Add(new Grid.ColHeader("고객사코드", 100, HorizontalAlignment.Center, true));
                //grid2.Columns.Add(new Grid.ColHeader("고객사이름", 500, HorizontalAlignment.Center, true));
            }
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
            txtDivQty.Text = string.Empty;
            txtUnitCode.Text = string.Empty;
            txtInDate.Text = string.Empty;
            txtCustCode.Text = string.Empty;
            txtCustName.Text = string.Empty;
            txtConstractNo.Text = string.Empty;
            txtInputBarCode.Select();
            txtInputBarCode.Focus();
            gBarCode = string.Empty;
        }

        private DataTable USP_BM0000_S2(ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);


            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0000_S2"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_MAJORCODE", "SHIPSELECT", DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_USEFLAG", "Y", DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_SYSTEMID", "", DbType.String, ParameterDirection.Input));

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

        private void ScanLogic()
        {
            try
            {
                DBHelper helper;
                gBarCode = txtInputBarCode.Text;

                if (gBarCode == string.Empty) return;

                string sItemCode = string.Empty;
                string sItemName = string.Empty;
                string sQty = string.Empty;
                string sDivQty = string.Empty;
                string sUnitCode = string.Empty;
                string sInDate = string.Empty;
                string sWhCode = string.Empty;
                string sWhName = string.Empty;
                string sStorageLocCode = string.Empty;
                string sstorageLocName = string.Empty;

                DataTable _dt = new DataTable();
                _dt = USP_PD4051_S1(gBarCode, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        sItemCode = DBHelper.nvlString(_dt.Rows[0]["ITEMCODE"]);
                        sItemName = DBHelper.nvlString(_dt.Rows[0]["ITEMNAME"]);
                        sQty = DBHelper.nvlString(_dt.Rows[0]["QTY"]);
                        sDivQty = DBHelper.nvlString(_dt.Rows[0]["QTY"]);
                        sUnitCode = DBHelper.nvlString(_dt.Rows[0]["UNITCODE"]);
                        sWhCode = DBHelper.nvlString(_dt.Rows[0]["WHCODE"]);
                        sWhName = DBHelper.nvlString(_dt.Rows[0]["WHNAME"]);
                        sStorageLocCode = DBHelper.nvlString(_dt.Rows[0]["STORAGELOCCODE"]);
                        sstorageLocName = DBHelper.nvlString(_dt.Rows[0]["STORAGELOCNAME"]);
                        sInDate = DBHelper.nvlString(_dt.Rows[0]["INDATE"]);

                        txtInputBarCode.Text = string.Empty;

                        txtBarCode.Text = gBarCode;
                        txtItemCode.Text = sItemCode;
                        txtItemName.Text = sItemName;
                        txtQty.Text = sQty;
                        txtDivQty.Text = sQty;
                        txtUnitCode.Text = sUnitCode;
                        txtWhCode.Text = sWhCode;
                        txtWhName.Text = sWhName;
                        txtStorageLocCode.Text = sStorageLocCode;
                        txtStorageLocName.Text = sstorageLocName;
                        txtInDate.Text = sInDate;
                        sItem = sItemCode;
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

        private DataTable USP_PD4051_S1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD4051_S1"
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

        private void USP_PD4051_I1(string sBarCode, string sItemCode, string sConstractNo, string sCustCode, string sQty, string sDivQty, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {

                double iDivqty;
                double iQty;

                iQty = DBHelper.nvlDouble(sQty);
                iDivqty = DBHelper.nvlDouble(sDivQty);

                if (iDivqty == 0)
                {
                    this.ShowDialog(Common.getLangText("수량 0은 출고 할 수 없습니다.", "MSG"), DialogForm.DialogType.OK);
                    return;
                }

                if (iQty < iDivqty)
                {
                    this.ShowDialog(Common.getLangText("분할 수량이 원래 수량보다 많습니다.", "MSG"), DialogForm.DialogType.OK);
                    return;
                }


                helper.ExecuteNoneQuery("USP_PD4051_I1"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_NOWQTY", sDivQty, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_CONSTRACTNO", sConstractNo, DbType.String, ParameterDirection.Input));

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


        private DataTable USP_PD4051_S2(string sCustNum, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (sCustNum == "2")
                {
                    rtnDtTemp2 = helper.FillTable("USP_AP0110_POPS1"
                                           , CommandType.StoredProcedure
                                           , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(sItem), DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_USEFLAG", "", DbType.String, ParameterDirection.Input));
                }


                RS_CODE = Convert.ToString(helper.RSCODE);
                RS_MSG = Convert.ToString(helper.RSMSG);

                return rtnDtTemp2;
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

            try
            {
                if (txtCustCode.Text == string.Empty)
                {
                    ShowDialog(Common.getLangText("출고 거래처를 선택하세요.", "MSG"), DialogForm.DialogType.OK);
                    return;
                }

                if (txtDivQty.Text == string.Empty)
                {
                    ShowDialog(Common.getLangText("출고 수량을 입력하세요.", "MSG"), DialogForm.DialogType.OK);
                    return;
                }

                if (sCustNum == "2")
                {
                    if (txtConstractNo.Text == string.Empty)
                    {
                        ShowDialog(Common.getLangText("수주를 입력하세요.", "MSG"), DialogForm.DialogType.OK);
                        return;
                    }
                }

                string sItemCode = txtItemCode.Text.Trim();
                string sCustCode = txtCustCode.Text.Trim();
                string sQty = txtQty.Text.Trim();
                string sDivQty = txtDivQty.Text.Trim();
                string sConstractNo = txtConstractNo.Text.Trim();

                USP_PD4051_I1(gBarCode, sItemCode, sConstractNo, sCustCode, sQty, sDivQty, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    ControlClear();
                    ShowDialog(Common.getLangText("제품출고 완료", "MSG"), DialogForm.DialogType.OK);
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

        private void SerchCust(string sCustNum)
        {
            DataTable _dt3 = new DataTable();

            switch (sCustNum)
            {
                case "1":

                    break;
                case "2":
                    _dt3 = USP_PD4051_S2(sCustNum, ref RS_CODE, ref RS_MSG);
                    break;
                case "3":
                    break;
            }

            try
            {

                if (RS_CODE == "S")
                {
                    if (_dt3.Rows.Count > 0)
                    {
                        grid2.Items.Clear();

                        for (int i = 0; i < _dt3.Rows.Count; i++)
                        {
                            ListViewItem lvl = new ListViewItem();
                            lvl.SubItems.Add(_dt3.Rows[i]["PLANTCODE"].ToString());
                            lvl.SubItems.Add(_dt3.Rows[i]["CUSTCODE"].ToString());
                            lvl.SubItems.Add(_dt3.Rows[i]["ITEMCODE"].ToString());
                            lvl.SubItems.Add(_dt3.Rows[i]["CLOSEFLAG"].ToString());
                            lvl.SubItems.Add(_dt3.Rows[i]["CONTRACTNO"].ToString());
                            lvl.SubItems.Add(_dt3.Rows[i]["CUSTNAME"].ToString());
                            lvl.SubItems.Add(_dt3.Rows[i]["ITEMNAME"].ToString());
                            grid2.Items.Add(lvl);
                            grid2.EndUpdate();
                        }
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

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            lblFormName.Visible = false;
            lblFormName2.Visible = true;

            lblFormName2.Top = 4;
            lblFormName2.Left = 4;
            panel2.Top = panel1.Top;
            panel2.Left = panel1.Left;
            SerchCust(sCustNum);
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            lblFormName.Visible = true;
            lblFormName2.Visible = false;
            //grid2.Items.Clear();

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

                        txtCustCode.Text = grid2.FocusedItem.SubItems[2].Text;
                        txtConstractNo.Text = grid2.FocusedItem.SubItems[5].Text;
                        txtCustName.Text = grid2.FocusedItem.SubItems[6].Text;

                        btnPrePage_Click(sender, e);
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

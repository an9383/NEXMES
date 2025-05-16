#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD2130
//   Form Name    : 수입검사 등록
//   Name Space   : NEXPDA
//   Created Date : 2018-03-21
//   Made By      :
//   Edited Date  : 
//   Edit By      :
//   Description  : 수입검사 대기 상태의 자재를 수입검사하여 검사결과 OK = 자재입고
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
    public partial class PD2130 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        Common _Common = new Common();

        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        private string gBarCode = string.Empty;

        DataTable rtnDtTemp = new DataTable();
        DataSet rtnDsTemp = new DataSet();
        #endregion

        #region < CONSTRUCTOR >
        public PD2130()
        {
            InitializeComponent();
        }

        #endregion

        #region < FORM EVENT >
        private void PD2130_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;

            lblFormName.Visible = true;
            lblFormName2.Visible = false;

            GridInit();

            //타이틀 설정
            lblFormName.Text = lblFormName.Text + " (" + LoginInfo.PlantCode + "-" + LoginInfo.UserID + ")";
            lblFormName2.Text = lblFormName2.Text + " (" + LoginInfo.PlantCode + "-" + LoginInfo.UserID + ")";

            txtInputBarCode.Select();

        }

        private void GridInit()
        {
            grid1.View = View.Details;
            grid1.Columns.Add(new Grid.ColHeader("checkBox", 0, HorizontalAlignment.Center, false));    //품목코드
            grid1.Columns.Add(new Grid.ColHeader("품번", 90, HorizontalAlignment.Center, true));    //품목코드
            grid1.Columns.Add(new Grid.ColHeader("품명", 120, HorizontalAlignment.Center, true));    //검사코드
        }

        #endregion

        #region < USER METHOD AREA >
        private void ControlClear()
        {
            txtInputBarCode.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtItemName2.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtUnitCode.Text = string.Empty;

            grid1.Items.Clear();

            txtInputBarCode.Select();

            panel1.Visible = true;
            panel2.Visible = false;

            gBarCode = string.Empty;
        }


        private DataTable USP_PD2130_S1(string sItemCode, string sItemName, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0010_S1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMTYPE", "", DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_USEFLAG", "Y", DbType.String, ParameterDirection.Input));



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

        private DataTable USP_PD2130_S2(string sItemCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD2130_S2"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

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

        private DataTable USP_PDA_GETSTORAGECODE(string sWhCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PDA_GETSTORAGECODE"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input));

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

        private void USP_PD2130_I1(string sBarCode, string sItemCode, string sQty, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                helper.ExecuteNoneQuery("USP_PD2130_I1"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_QTY", sQty, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));


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

        private void USP_PD2130_I2(string sBarCode, string sItemCode, string sInspCode, string sInspResultVal, string sInspResult, string sSpecLSL, string sSpecUSL,
                                  ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                helper.ExecuteNoneQuery("USP_PD2130_I2"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_INSPRESULTVAL", sInspResultVal, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_INSPRESULT", sInspResult, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_SPECLSL", sSpecLSL, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_SPECUSL", sSpecUSL, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

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
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            lblFormName.Visible = true;
            lblFormName2.Visible = false;

            btnBarCode.PerformClick();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlClear();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sBarCode = DBHelper.nvlString(txtInputBarCode.Value);
                string sItemCode = DBHelper.nvlString(txtItemCode.Value);
                string sQty = DBHelper.nvlString(txtQty.Value);
                if (sBarCode == string.Empty) return;

                //string sItemCode    = txtItemCode.Text.Trim();
                //string sWhCode      = Convert.ToString(cboWhCode.Value);
                //string sStorageCode = Convert.ToString(cboStorage.Value);
                //string sResult      = string.Empty;
                //string sLastFlag    = string.Empty;


                //DialogResult result = MessageBox.Show("[" + gBarCode + "]" + Common.getLangText("수입검사 내용을 등록하시겠습니까?", "MSG"), "수입검사 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                //if (result.ToString().ToUpper() != "YES")
                //    return;

                //수입검사 공통 등록 및 결과에 따른 재고 생성(OK 일 경우 재고 생성)
                USP_PD2130_I1(gBarCode
                            , sItemCode
                            , sQty
                            , ref RS_CODE
                            , ref RS_MSG);

                //if (RS_CODE == "E")
                //{
                //    this.ShowDialog(Common.getLangText("[수입검사 결과 등록] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                //}

                //for (int i = 0; i < grid1.Items.Count; i++)
                //{
                //    string sInspCode   = grid1.Items[i].SubItems[2].Text.Trim();
                //    string sInspResult = grid1.Items[i].SubItems[12].Text.Trim();
                //    string sValueType  = grid1.Items[i].SubItems[4].Text.Trim();
                //    string sSpecLSL    = grid1.Items[i].SubItems[10].Text.Trim();
                //    string sSpecUSL    = grid1.Items[i].SubItems[9].Text.Trim();
                //    string sInspResultVal = string.Empty;

                //    if (sValueType == "V")
                //        sInspResultVal = grid1.Items[i].SubItems[5].Text.Trim();


                //    USP_PD2130_I2(gBarCode                                    //바코드
                //                , sItemCode
                //                , sInspCode
                //                , sInspResultVal
                //                , sInspResult
                //                , sSpecLSL
                //                , sSpecUSL
                //                , ref RS_CODE
                //                , ref RS_MSG);                                                                                                         
                //}

                //if (RS_CODE == "S")
                //{
                //    ControlClear();
                //    this.ShowDialog(Common.getLangText("[수입검사 결과 등록] 수입검사 정상 등록", "MSG"), DialogForm.DialogType.OK); //[수입검사 결과 등록] 수입검사 정상 등록
                //}
                //else if (RS_CODE == "E")
                //{
                //    this.ShowDialog(Common.getLangText("[수입검사 결과 등록] ", "MSG") + RS_MSG, DialogForm.DialogType.OK); 
                //}
            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("[입력값] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
            }
        }




        #endregion

        private void btnItemCode_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            lblFormName.Visible = false;
            lblFormName2.Visible = true;

            lblFormName2.Top = 4;
            lblFormName2.Left = 4;
            panel2.Top = panel1.Top;
            panel2.Left = panel1.Left;
        }

        private void btnItemName_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            lblFormName.Visible = false;
            lblFormName2.Visible = true;

            lblFormName2.Top = 4;
            lblFormName2.Left = 4;
            panel2.Top = panel1.Top;
            panel2.Left = panel1.Left;
        }

        private void call_grid1()
        {
            //검사항목 조회
            DataTable _dt = new DataTable();
            string sItemCode = DBHelper.nvlString(txtItemCode2.Value);
            string sItemName = DBHelper.nvlString(txtItemName2.Value);

            _dt = USP_PD2130_S1(sItemCode, sItemName, ref RS_CODE, ref RS_MSG);

            if (RS_CODE == "S")
            {
                grid1.Items.Clear();

                if (_dt.Rows.Count > 0)
                {
                    for (int i = 0; i < _dt.Rows.Count; i++)
                    {

                        String[] arr = new String[2];
                        arr[0] = _dt.Rows[i]["ITEMCODE"].ToString();
                        arr[1] = _dt.Rows[i]["ITEMNAME"].ToString();
                        ListViewItem lvl = new ListViewItem("");
                        //lvl.SubItems.Add(DBHelper.nvlString(_dt.Rows[i]["ITEMCODE"]));
                        //lvl.SubItems.Add(DBHelper.nvlString(_dt.Rows[i]["ITEMNAME"]));
                        lvl.SubItems.Add(arr[0]);
                        lvl.SubItems.Add(arr[1]);

                        grid1.Items.Add(lvl);
                        grid1.EndUpdate();
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            call_grid1();
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            string itemCode = grid1.SelectedItems[0].SubItems[1].Text;
            string itemName = grid1.SelectedItems[0].SubItems[2].Text;

            txtItemCode.Value = itemCode;
            txtItemName.Value = itemName;

            panel1.Visible = true;
            panel2.Visible = false;
            lblFormName.Visible = true;
            lblFormName2.Visible = false;

            btnBarCode.PerformClick();
        }
    }
}

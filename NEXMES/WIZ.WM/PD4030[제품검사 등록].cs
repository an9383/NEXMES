#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD4030
//   Form Name    : 제품검사 등록
//   Name Space   : NEXPDA
//   Created Date : 2018-04-03
//   Made By      :
//   Edited Date  : 
//   Edit By      :
//   Description  : 유검사품에 대하여 제품검사 진행 후, 제품창고 입고
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class PD4030 : WIZ.Forms.BaseMDIChildForm
    {
        #region [ MEMBER AREA ]

        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        private string gBarCode = string.Empty;

        DataTable rtnDtTemp = new DataTable();

        string _sFlag; // "Y" = 검사 후 입고, "N" = 입고 후 검사


        #endregion

        #region [ CONSTRUCTOR ]
        public PD4030()
        {
            InitializeComponent();

            SearchFlag();
        }
        #endregion

        #region < FORM LOAD >
        private void PD4030_Load(object sender, EventArgs e)
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

            if (_sFlag == "Y")
            {
                btnWhCode.Visible = true;
                btnStorage.Visible = true;
                cboWhCode.Visible = true;
                cboStorage.Visible = true;

                GetWhCode();
            }
            else
            {
                btnWhCode.Visible = false;
                btnStorage.Visible = false;
                cboWhCode.Visible = false;
                cboStorage.Visible = false;

                chkLastInsp.Visible = false;

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
            txtInspNum.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtMaker.Text = string.Empty;
            txtUnitCode.Text = string.Empty;
            txtMakeDate.Text = string.Empty;

            cboWhCode.SelectedIndex = 0;
            cboStorage.SelectedIndex = 0;

            chkLastInsp.Checked = false;

            grid1.Items.Clear();

            txtInputBarCode.Select();

            panel1.Visible = true;
            panel2.Visible = false;

            gBarCode = string.Empty;
        }

        private void GridInit()
        {
            grid1.View = View.Details;
            grid1.Columns.Add(new Grid.ColHeader("판정", 0, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("품목코드", 0, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("검사코드", 0, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("검사명", 90, HorizontalAlignment.Left, true));
            grid1.Columns.Add(new Grid.ColHeader("측정값구분", 0, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("입력값", 70, HorizontalAlignment.Right, true));
            grid1.Columns.Add(new Grid.ColHeader("SPEC적용기준", 0, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("SPEC적용기준", 0, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("기준값", 0, HorizontalAlignment.Right, true));
            grid1.Columns.Add(new Grid.ColHeader("상한값", 0, HorizontalAlignment.Right, true));
            grid1.Columns.Add(new Grid.ColHeader("하한값", 0, HorizontalAlignment.Right, true));
            grid1.Columns.Add(new Grid.ColHeader("측정값구분", 100, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("OKNG", 0, HorizontalAlignment.Right, true));
        }

        private void GetWhCode()
        {
            try
            {
                DataTable _dt = new DataTable();
                _dt = USP_PDA_GETWHCODE("WH002", ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        WIZ.Common.FillComboboxMaster(cboWhCode, _dt, "WHCODE", "WHNAME", "선택하세요", "");
                    }
                    else
                    {
                        this.ShowDialog(Common.getLangText("[창고 조회] 창고 정보를 확인하세요.", "MSG"), DialogForm.DialogType.OK);
                    }
                }
                else if (RS_CODE == "E")
                {
                    this.ShowDialog(Common.getLangText("[창고 조회] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("[창고 조회] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
            }
        }

        private void ScanLogic()
        {
            try
            {
                gBarCode = txtInputBarCode.Text;

                if (gBarCode == string.Empty) return;

                string sItemCode = string.Empty; //품번
                string sItemName = string.Empty; //품명
                string sWhName = string.Empty;
                string sLocName = string.Empty;
                string sQty = string.Empty; //수량
                string sUnitCode = string.Empty; //단위
                string sInspNum = string.Empty;
                string sMaker = string.Empty;
                string sMakeDate = string.Empty; //라벨 발행일자q


                DataTable _dt = new DataTable();
                _dt = USP_PD4030_S1(gBarCode, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        sItemCode = Convert.ToString(_dt.Rows[0]["ITEMCODE"]);
                        sItemName = Convert.ToString(_dt.Rows[0]["ITEMNAME"]);
                        //sWhName   = Convert.ToString(_dt.Rows[0]["WHNAME"]);
                        //sLocName  = Convert.ToString(_dt.Rows[0]["STORAGELOCNAME"]);
                        sQty = Convert.ToString(_dt.Rows[0]["NOWQTY"]);
                        sUnitCode = Convert.ToString(_dt.Rows[0]["UNITCODE"]);
                        sInspNum = Convert.ToString(_dt.Rows[0]["INSPNUM"]);
                        sMaker = Convert.ToString(_dt.Rows[0]["MAKER"]);
                        sMakeDate = Convert.ToString(_dt.Rows[0]["MAKEDATE"]);

                        txtInputBarCode.Text = string.Empty;

                        txtBarCode.Text = gBarCode;
                        txtItemCode.Text = sItemCode;
                        txtItemName.Text = sItemName;
                        txtQty.Text = sQty;
                        txtUnitCode.Text = sUnitCode;
                        txtInspNum.Text = sInspNum;
                        txtMaker.Text = sMaker;
                        txtMakeDate.Text = sMakeDate;
                        cboWhCode.Value = "WH0002";
                        cboStorage.Value = "WL0002";

                        //검사항목 조회
                        _dt = USP_PD4030_S2(sItemCode, ref RS_CODE, ref RS_MSG);

                        grid1.Items.Clear();

                        if (_dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < _dt.Rows.Count; i++)
                            {
                                ListViewItem lvl = new ListViewItem();
                                lvl.SubItems.Add(_dt.Rows[i]["ITEMCODE"].ToString());
                                lvl.SubItems.Add(_dt.Rows[i]["INSPCODE"].ToString());
                                lvl.SubItems.Add(_dt.Rows[i]["INSPNAME"].ToString());
                                lvl.SubItems.Add(_dt.Rows[i]["VALUETYPE"].ToString());
                                lvl.SubItems.Add(_dt.Rows[i]["INPUTVALUE"].ToString());
                                lvl.SubItems.Add(_dt.Rows[i]["SPECTYPE"].ToString());
                                lvl.SubItems.Add(_dt.Rows[i]["SPECNAME"].ToString());
                                lvl.SubItems.Add(_dt.Rows[i]["SPECNOL"].ToString());
                                lvl.SubItems.Add(_dt.Rows[i]["SPECUSL"].ToString());
                                lvl.SubItems.Add(_dt.Rows[i]["SPECLSL"].ToString());
                                lvl.SubItems.Add(_dt.Rows[i]["VALUENAME"].ToString());
                                lvl.SubItems.Add(_dt.Rows[i]["OKNG"].ToString());

                                grid1.Items.Add(lvl);
                                grid1.EndUpdate();
                            }
                        }
                    }
                    else
                    {
                        ControlClear();
                        this.ShowDialog(Common.getLangText("조회 결과가 없습니다.", "MSG"), DialogForm.DialogType.OK);
                    }
                }
                else
                {
                    this.ShowDialog(Common.getLangText(RS_MSG, "MSG"), DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                ControlClear();
                this.ShowDialog(Common.getLangText(ex.ToString(), "MSG"), DialogForm.DialogType.OK);
            }
        }

        private DataTable USP_PDA_GETWHCODE(string sWhType, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PDA_GETWHCODE"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input));

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

        private DataTable USP_PD4030_S1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD4030_S1"
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

        private DataTable USP_PD4030_S2(string sItemCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD4030_S2"
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

        private void USP_PD4030_I1(string sBarCode, string sItemCode, string sWhCode, string sStorageLocCode, string sResult, string sLastFlag, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                helper.ExecuteNoneQuery("USP_PD4030_I1"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_STORAGELOCCODE", sStorageLocCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_RESULT", sResult, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_LASTFLAG", sLastFlag, DbType.String, ParameterDirection.Input)
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

        private void USP_PD4030_I2(string sBarCode, string sItemCode, string sInspCode, string sInspResultVal, string sInspResult, string sSpecLSL, string sSpecUSL,
                                  ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                helper.ExecuteNoneQuery("USP_PD4030_I2"
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


        #endregion

        #region < EVENT AREA >

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

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            lblFormName.Visible = false;
            lblFormName2.Visible = true;
            chkLastInsp.Checked = true;

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

        private void btnClear2_Click(object sender, EventArgs e)
        {
            ControlClear();
            panel1.Visible = true;
            panel2.Visible = false;
        }


        private void cboWhCode_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sWhCode = Convert.ToString(cboWhCode.Value);

                DataTable _dt = new DataTable();
                _dt = USP_PDA_GETSTORAGECODE(sWhCode, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    WIZ.Common.FillComboboxMaster(cboStorage, _dt, "STORAGELOCCODE", "STORAGELOCNAME", "선택하세요", "");
                }
                else if (RS_CODE == "E")
                {
                    this.ShowDialog(Common.getLangText("[창고 위치 조회] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("[창고 위치 조회] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
            }
        }

        private void grid1_ItemActivate(object sender, EventArgs e)
        {
            if (grid1.SelectedIndices.Count == 0)
                return;

            string sValueType = grid1.FocusedItem.SubItems[4].Text;
            string sItemCode = txtItemCode.Text.Trim();
            string sInspCode = grid1.FocusedItem.SubItems[2].Text;

            PD4030_POP PD4030_POP = new PD4030_POP(sItemCode, sInspCode, sValueType);
            PD4030_POP.ShowDialog();

            if (PD4030_POP._sInputValue == string.Empty)
                return;

            grid1.FocusedItem.SubItems[5].Text = PD4030_POP._sInputValue;
            grid1.FocusedItem.SubItems[12].Text = PD4030_POP._sInspResult;

            if (PD4030_POP._sInspResult == "OK")
            {
                grid1.FocusedItem.BackColor = Color.White;
                grid1.FocusedItem.ForeColor = Color.Black;
            }
            else if (PD4030_POP._sInspResult == "NG")
            {
                grid1.FocusedItem.BackColor = Color.Red;
                grid1.FocusedItem.ForeColor = Color.White;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (gBarCode == string.Empty) return;

                string sItemCode = txtItemCode.Text.Trim();
                string sWhCode = Convert.ToString(cboWhCode.Value);
                string sStorageCode = Convert.ToString(cboStorage.Value);
                string sResult = string.Empty;
                float fQty = Convert.ToSingle(txtQty.Text.Trim());
                string sLastFlag = string.Empty;

                if (chkLastInsp.Checked)
                {
                    sLastFlag = "Y";

                    if (_sFlag == "Y")
                    {
                        if (sWhCode == string.Empty)
                        {
                            ShowDialog(Common.getLangText("입고 시 저장할 창고를 선택하세요.", "MSG"), DialogForm.DialogType.OK);
                            return;
                        }

                        if (sStorageCode == string.Empty)
                        {
                            ShowDialog(Common.getLangText("입고 시 저장할 위치를 선택하세요.", "MSG"), DialogForm.DialogType.OK);
                            return;

                        }
                    }
                }
                else
                    sLastFlag = "N";

                for (int i = 0; i < grid1.Items.Count; i++)
                {
                    if (grid1.Items[i].SubItems[12].Text == string.Empty)
                    {
                        //판정결과가 없을 경우..
                        this.ShowDialog(Common.getLangText("[판정결과 누락]", "MSG") + grid1.Items[i].SubItems[3].Text + Common.getLangText("판정결과가 없습니다. 입력값을 입력하세요", "MSG"), DialogForm.DialogType.OK);
                        return;
                    }
                }

                for (int i = 0; i < grid1.Items.Count; i++)
                {
                    if (grid1.Items[i].SubItems[12].Text == "NG")   //검사항목 중 NG가 있을 경우..
                    {
                        sResult = "NG";
                        break;
                    }
                    else
                        sResult = "OK";
                }

                if (sResult == string.Empty)
                {
                    //검사항목이 없을 경우..자동 OK처리..
                    sResult = "OK";
                }

                DialogResult result = MessageBox.Show("[" + gBarCode + "] 의 제품검사 내용을 등록하시겠습니까?", "제품검사 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result.ToString().ToUpper() != "YES")
                    return;

                //수입검사 공통 등록 및 결과에 따른 재고 생성(OK 일 경우 재고 생성)
                USP_PD4030_I1(gBarCode, sItemCode, sWhCode, sStorageCode, sResult, sLastFlag, ref RS_CODE, ref RS_MSG);

                if (RS_CODE != "S")
                {
                    this.ShowDialog(RS_MSG, DialogForm.DialogType.OK);
                    return;
                }

                for (int i = 0; i < grid1.Items.Count; i++)
                {
                    string sInspCode = grid1.Items[i].SubItems[2].Text.Trim();
                    string sInspResult = grid1.Items[i].SubItems[12].Text.Trim();
                    string sValueType = grid1.Items[i].SubItems[4].Text.Trim();
                    string sSpecLSL = grid1.Items[i].SubItems[10].Text.Trim();
                    string sSpecUSL = grid1.Items[i].SubItems[9].Text.Trim();
                    string sInspResultVal = string.Empty;

                    if (sValueType == "V")
                        sInspResultVal = grid1.Items[i].SubItems[5].Text.Trim();

                    USP_PD4030_I2(gBarCode, sItemCode, sInspCode, sInspResultVal, sInspResult, sSpecLSL, sSpecUSL, ref RS_CODE, ref RS_MSG);
                }

                if (RS_CODE == "S")
                {
                    ControlClear();
                    this.ShowDialog(Common.getLangText("제품검사 정상 등록", "MSG"), DialogForm.DialogType.OK);
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
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
        }

        private void chkLastInsp_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkLastInsp.Checked)
            {
                cboWhCode.Enabled = true;
                cboStorage.Enabled = true;
            }
            else
            {
                cboWhCode.Enabled = false;
                cboStorage.Enabled = false;
            }
        }

        #endregion

    }
}

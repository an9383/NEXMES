#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD2030
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
using System.Drawing;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class PD2030 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        Common _Common = new Common();

        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        private string gBarCode = string.Empty;
        private string sStorage = string.Empty;

        DataTable rtnDtTemp = new DataTable();
        DataSet rtnDsTemp = new DataSet();


        #endregion

        #region < CONSTRUCTOR >
        public PD2030()
        {
            InitializeComponent();
        }

        #endregion

        #region < FORM EVENT >
        private void PD2030_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;

            lblFormName.Visible = true;
            lblFormName2.Visible = false;

            GridInit();

            //타이틀 설정
            lblFormName.Text = lblFormName.Text + " (" + LoginInfo.PlantCode + "-" + LoginInfo.UserID + ")";
            lblFormName2.Text = lblFormName2.Text + " (" + LoginInfo.PlantCode + "-" + LoginInfo.UserID + ")";

            txtInputBARCODE.Select();
            txtStorageBARCODE.Text = "WL0001";
            chkLastInsp.Checked = true;

            DoSet(panel1);
            DoSet(panel2);
        }

        private void DoSet(System.Windows.Forms.Control con)
        {
            foreach (System.Windows.Forms.Control c in con.Controls)
            {
                switch (c.GetType().Name.ToUpper())
                {
                    case "STEXTBOX":
                        if (c.Name.Contains("BARCODE"))
                        {
                            c.BackColor = Color.FromArgb(75, 92, 118);
                            c.ForeColor = Color.Gold;
                        }
                        break;
                }
            }
        }

        private void GridInit()
        {
            grid1.View = View.Details;
            grid1.Columns.Add(new Grid.ColHeader("판정", 0, HorizontalAlignment.Center, true));    //판정
            grid1.Columns.Add(new Grid.ColHeader("품목코드", 0, HorizontalAlignment.Center, true));    //품목코드
            grid1.Columns.Add(new Grid.ColHeader("검사코드", 0, HorizontalAlignment.Center, true));    //검사코드
            grid1.Columns.Add(new Grid.ColHeader("검사명", 90, HorizontalAlignment.Left, true));    //검사명
            grid1.Columns.Add(new Grid.ColHeader("측정값구분", 0, HorizontalAlignment.Center, true));    //측정값구분
            grid1.Columns.Add(new Grid.ColHeader("입력값", 70, HorizontalAlignment.Right, true));    //입력값
            grid1.Columns.Add(new Grid.ColHeader("SPEC적용기준", 0, HorizontalAlignment.Center, true));    //SPEC적용기준          
            grid1.Columns.Add(new Grid.ColHeader("SPEC적용기준", 0, HorizontalAlignment.Center, true));    //SPEC적용기준          
            grid1.Columns.Add(new Grid.ColHeader("기준값", 0, HorizontalAlignment.Right, true));    //기준값
            grid1.Columns.Add(new Grid.ColHeader("상한값", 0, HorizontalAlignment.Right, true));    //상한값
            grid1.Columns.Add(new Grid.ColHeader("하한값", 0, HorizontalAlignment.Right, true));    //하한값
            grid1.Columns.Add(new Grid.ColHeader("측정값구분", 110, HorizontalAlignment.Center, true));    //측정값구분명
            grid1.Columns.Add(new Grid.ColHeader("OKNG", 0, HorizontalAlignment.Right, true));   //입력 후 결과
        }

        #endregion

        #region < USER METHOD AREA >
        private void ControlClear()
        {
            txtInputBARCODE.Text = string.Empty;
            txtBarCode.Text = string.Empty;
            txtPoNo.Text = string.Empty;
            txtCustCode.Text = string.Empty;
            txtCustCode.Tag = string.Empty;
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtInspNum.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtUnitCode.Text = string.Empty;
            txtMaker.Text = string.Empty;
            txtMakeDate.Text = string.Empty;
            txtStorageBARCODE.Text = "WL0001";
            txtStorageCode.Text = string.Empty;
            txtStorageName.Text = string.Empty;
            //cboWhCode.SelectedIndex  = 0;
            //cboStorage.SelectedIndex = 0;

            chkLastInsp.Checked = true;

            grid1.Items.Clear();

            txtInputBARCODE.Select();

            panel1.Visible = true;
            panel2.Visible = false;

            gBarCode = string.Empty;
        }

        //private void GetWhCode()
        //{
        //    try
        //    {
        //        DataTable _dt = new DataTable();
        //        _dt = USP_PDA_GETWHCODE("WH001", ref RS_CODE, ref RS_MSG);

        //        if (RS_CODE == "S")
        //        {
        //            if (_dt.Rows.Count > 0)
        //            {
        //                WIZ.Common.FillComboboxMaster(cboWhCode, _dt, "WHCODE", "WHNAME", "선택하세요", "");
        //            }
        //            else
        //            {
        //                this.ShowDialog(Common.getLangText("[창고 조회] 창고 정보를 확인하세요.", "MSG"), DialogForm.DialogType.OK);
        //            }
        //        }
        //        else if (RS_CODE == "E")
        //        {
        //            this.ShowDialog(Common.getLangText("[창고 조회] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        this.ShowDialog(Common.getLangText("[창고 조회] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
        //    }
        //}

        private void ScanLogic()
        {
            try
            {
                gBarCode = txtInputBARCODE.Text;

                if (gBarCode == string.Empty) return;

                string sPoNo = string.Empty;        //거래번호
                string sCustCode = string.Empty;        //거래처코드
                string sCustName = string.Empty;        //거래처명
                string sItemCode = string.Empty;        //품번
                string sItemName = string.Empty;        //품명
                string sQty = string.Empty;        //수량(가입고수량)
                string sUnitCode = string.Empty;        //단위
                string sInspNum = string.Empty;
                string sMaker = string.Empty;        //라벨 발행자
                string sMakeDate = string.Empty;        //라벨 발행날자                

                DataTable _dt = new DataTable();
                _dt = USP_PD2030_S1(gBarCode, ref RS_CODE, ref RS_MSG);

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
                        sInspNum = Convert.ToString(_dt.Rows[0]["INSPNUM"]);
                        sMaker = Convert.ToString(_dt.Rows[0]["MAKER"]);
                        sMakeDate = Convert.ToString(_dt.Rows[0]["MAKEDATE"]);

                        txtBarCode.Text = gBarCode;
                        txtPoNo.Text = sPoNo;
                        txtCustCode.Tag = sCustCode;
                        txtCustCode.Text = sCustName;
                        txtItemCode.Text = sItemCode;
                        txtItemName.Text = sItemName;
                        txtQty.Text = sQty;
                        txtUnitCode.Text = sUnitCode;
                        txtInspNum.Text = sInspNum;
                        txtMaker.Text = sMaker;
                        txtMakeDate.Text = sMakeDate;

                        //검사항목 조회
                        //_dt = USP_PD2030_S2(sItemCode, ref RS_CODE, ref RS_MSG);

                        DBHelper helper = new DBHelper(false);
                        DataSet ds = helper.FillDataSet("USP_PD2030_S2"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                        RS_CODE = Convert.ToString(helper.RSCODE);
                        RS_MSG = Convert.ToString(helper.RSMSG);

                        WIZ.Control.CmmnListView.SetData(grid1, ds);
                        //grid1.Items.Clear();

                        //if (_dt.Rows.Count > 0)
                        //{
                        //    for (int i = 0; i < _dt.Rows.Count; i++)
                        //    {
                        //        ListViewItem lvl = new ListViewItem();
                        //        lvl.SubItems.Add(_dt.Rows[i]["ITEMCODE"].ToString());
                        //        lvl.SubItems.Add(_dt.Rows[i]["INSPCODE"].ToString());
                        //        lvl.SubItems.Add(_dt.Rows[i]["INSPNAME"].ToString());
                        //        lvl.SubItems.Add(_dt.Rows[i]["VALUETYPE"].ToString());
                        //        lvl.SubItems.Add(_dt.Rows[i]["INPUTVALUE"].ToString());
                        //        lvl.SubItems.Add(_dt.Rows[i]["SPECTYPE"].ToString());
                        //        lvl.SubItems.Add(_dt.Rows[i]["SPECNAME"].ToString());                                    
                        //        lvl.SubItems.Add(_dt.Rows[i]["SPECNOL"].ToString());
                        //        lvl.SubItems.Add(_dt.Rows[i]["SPECUSL"].ToString());
                        //        lvl.SubItems.Add(_dt.Rows[i]["SPECLSL"].ToString());
                        //        lvl.SubItems.Add(_dt.Rows[i]["VALUENAME"].ToString());
                        //        lvl.SubItems.Add(_dt.Rows[i]["OKNG"].ToString());                                    

                        //        grid1.Items.Add(lvl);
                        //        grid1.EndUpdate();
                        //    }
                        //}
                    }
                    else
                    {
                        ControlClear();
                        this.ShowDialog(Common.getLangText("[수입검사 바코드 조회] 조회 결과가 없습니다.", "MSG"), DialogForm.DialogType.OK); //[수입검사 바코드 조회] 조회 결과가 없습니다
                        return;
                    }

                    txtInputBARCODE.Focus();
                }
                else if (RS_CODE == "E")
                {
                    ControlClear();
                    this.ShowDialog(Common.getLangText("[수입검사 바코드 조회] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                ControlClear();
                this.ShowDialog(Common.getLangText("[수입검사 바코드 조회] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
            }
        }

        private void GetStorage()
        {
            try
            {
                sStorage = txtStorageBARCODE.Text;

                if (sStorage == string.Empty) return;

                string sStorageName = string.Empty;

                DataTable _dt = new DataTable();
                _dt = USP_PDA_GETSTORAGECODE2(sStorage, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        sStorageName = Convert.ToString(_dt.Rows[0]["STORAGELOCNAME"]);
                        sStorage = Convert.ToString(_dt.Rows[0]["STORAGELOCCODE"]);
                        txtStorageName.Text = sStorageName;
                        txtStorageCode.Text = sStorage;
                        txtStorageBARCODE.Text = string.Empty;

                    }
                    else
                    {
                        this.ShowDialog(Common.getLangText("저장 위치 조회 ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                    }
                }
                else
                {
                    this.ShowDialog(Common.getLangText("저장 위치 조회 ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                ControlClear();
                this.ShowDialog(Common.getLangText("저장 위치 조회 ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
            }
        }

        private DataTable USP_PDA_GETSTORAGECODE2(string sStorage, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PDA_STORAGELOCCODE2"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_STORAGELOCCODE", sStorage, DbType.String, ParameterDirection.Input));

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


        //private DataTable USP_PDA_GETWHCODE(string sWhType, ref string RS_CODE, ref string RS_MSG)
        //{
        //    DBHelper helper = new DBHelper(false);

        //    try
        //    {
        //        rtnDtTemp = helper.FillTable("USP_PDA_GETWHCODE"
        //                                    , CommandType.StoredProcedure
        //                                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("AS_WHTYPE",    sWhType,             DbType.String, ParameterDirection.Input));

        //        RS_CODE = Convert.ToString(helper.RSCODE);
        //        RS_MSG = Convert.ToString(helper.RSMSG);

        //        return rtnDtTemp;
        //    }
        //    catch (Exception ex)
        //    {
        //        RS_CODE = "E";
        //        RS_MSG = ex.Message.ToString();
        //        return new DataTable();
        //    }
        //    finally
        //    {
        //        helper.Close();
        //    }
        //}

        //private DataTable USP_PDA_GETSTORAGECODE(string sWhCode, ref string RS_CODE, ref string RS_MSG)
        //{
        //    DBHelper helper = new DBHelper(false);

        //    try
        //    {
        //        rtnDtTemp = helper.FillTable("USP_PDA_GETSTORAGECODE"
        //                                    , CommandType.StoredProcedure
        //                                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("AS_WHCODE",    sWhCode,             DbType.String, ParameterDirection.Input));

        //        RS_CODE = Convert.ToString(helper.RSCODE);
        //        RS_MSG  = Convert.ToString(helper.RSMSG);

        //        return rtnDtTemp;
        //    }
        //    catch (Exception ex)
        //    {
        //        RS_CODE = "E";
        //        RS_MSG = ex.Message.ToString();
        //        return new DataTable();
        //    }
        //    finally
        //    {
        //        helper.Close();
        //    }
        //}

        private DataTable USP_PD2030_S1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD2030_S1"
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

        private DataTable USP_PD2030_S2(string sItemCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD2030_S2"
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

        // 수입검사후 재고를 저장
        private void USP_PD2030_I1(string sBarCode, string sItemCode, string sWhCode, string sStorageLocCode, string sResult, string sLastFlag, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_PD2030_I1"
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

        // 수입검사결과를 저장.
        private void USP_PD2030_I2(string sBarCode, string sItemCode, string sInspCode, string sInspResultVal, string sInspResult, string sSpecLSL, string sSpecUSL,
                                  ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_PD2030_I2"
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
            txtInputBARCODE.Text = string.Empty;
            txtInputBARCODE.Focus();
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
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

        //private void cboWhCode_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string sWhCode = Convert.ToString(cboWhCode.Value);

        //        DataTable _dt = new DataTable();
        //        _dt = USP_PDA_GETSTORAGECODE(sWhCode, ref RS_CODE, ref RS_MSG);

        //        if (RS_CODE == "S")
        //        {
        //            WIZ.Common.FillComboboxMaster(cboStorage, _dt, "STORAGELOCCODE", "STORAGELOCNAME", "선택하세요", "");
        //        }
        //        else if (RS_CODE == "E")
        //        {
        //            this.ShowDialog(Common.getLangText("[창고 위치 조회] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        this.ShowDialog(Common.getLangText("[창고 위치 조회] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
        //    }
        //}

        private void grid1_ItemActivate(object sender, EventArgs e)
        {
            if (grid1.SelectedIndices.Count == 0)
                return;

            string sValueType = grid1.FocusedItem.SubItems[4].Text; //valuetype , 측정값코드
            string sItemCode = txtItemCode.Text.Trim();
            string sInspCode = grid1.FocusedItem.SubItems[2].Text;

            PD2030_POP PD2030_POP = new PD2030_POP(sItemCode, sInspCode, sValueType);
            PD2030_POP.ShowDialog();

            if (PD2030_POP._sInputValue == string.Empty)
                return;

            grid1.FocusedItem.SubItems[5].Text = PD2030_POP._sInputValue;
            grid1.FocusedItem.SubItems[12].Text = PD2030_POP._sInspResult;

            if (PD2030_POP._sInspResult == "OK")
            {
                grid1.FocusedItem.BackColor = Color.White;
                grid1.FocusedItem.ForeColor = Color.Black;
            }
            else if (PD2030_POP._sInspResult == "NG")
            {
                grid1.FocusedItem.BackColor = Color.Red;
                grid1.FocusedItem.ForeColor = Color.White;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBHelper helper = null;
            try
            {
                if (gBarCode == string.Empty) return;

                string sItemCode = txtItemCode.Text.Trim();
                string sWhCode = "";
                string sStorageCode = DBHelper.nvlString(txtStorageCode.Text.Trim());
                string sResult = string.Empty;
                string sLastFlag = string.Empty;

                if (chkLastInsp.Checked)
                {
                    sLastFlag = "Y";

                    //if (sWhCode == string.Empty)
                    //{
                    //    ShowDialog(Common.getLangText("입고 시 저장할 창고를 선택하세요.", "MSG"), DialogForm.DialogType.OK);
                    //    return;
                    //}

                    //if (sStorageCode == string.Empty)
                    //{
                    //    ShowDialog(Common.getLangText("입고 시 저장할 위치를 선택하세요.", "MSG"), DialogForm.DialogType.OK);
                    //    return;
                    //}
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

                DialogResult result = MessageBox.Show("[" + gBarCode + "]" + Common.getLangText("수입검사 내용을 등록하시겠습니까?", "MSG"), "수입검사 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result.ToString().ToUpper() != "YES")
                    return;

                helper = new DBHelper("", true);

                helper.ExecuteNoneQuery("USP_PD2030_I1"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BARCODE", gBarCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_WHCODE", "WH0001", DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_STORAGELOCCODE", "WL0001", DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCNT", Convert.ToInt32(txtQty.Text), DbType.Int32, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_RESULT", sResult, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_LASTFLAG", sLastFlag, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "E")
                {
                    throw new Exception(Common.getLangText("[수입검사 결과 등록] ", "MSG") + helper.RSMSG);
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
                    {
                        sInspResultVal = grid1.Items[i].SubItems[5].Text.Trim();
                    }
                    else
                    {
                        sInspResultVal = "0";
                    }

                    helper.ExecuteNoneQuery("USP_PD2030_I2"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BARCODE", gBarCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_INSPRESULTVAL", sInspResultVal, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_INSPRESULT", sInspResult, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_SPECLSL", sSpecLSL, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_SPECUSL", sSpecUSL, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(Common.getLangText("[수입검사 결과 등록] ", "MSG") + helper.RSMSG);
                    }
                }

                if (RS_CODE == "S")
                {
                    helper.Commit();
                    ControlClear();
                    this.ShowDialog(Common.getLangText("[수입검사 결과 등록] 수입검사 정상 등록", "MSG"), DialogForm.DialogType.OK); //[수입검사 결과 등록] 수입검사 정상 등록
                }
                else if (RS_CODE == "E")
                {
                    new Exception(Common.getLangText("[수입검사 결과 등록] ", "MSG") + helper.RSMSG);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.Message, DialogForm.DialogType.OK);
            }
        }

        //private void chkLastInsp_CheckStateChanged(object sender, EventArgs e)
        //{
        //    if (chkLastInsp.Checked)
        //    {
        //        cboWhCode.Enabled = true;
        //        cboStorage.Enabled = true;
        //    }
        //    else
        //    {
        //        cboWhCode.Enabled = false;
        //        cboStorage.Enabled = false;
        //    }
        //}


        #endregion

        private void txtStorage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                GetStorage();
            }
        }
    }
}

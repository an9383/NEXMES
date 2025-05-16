#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD8000
//   Form Name    : 제품일괄출하
//   Name Space   : NEXPDA
//   Created Date : 2020-11-30
//   Made By      : inho.hwang
//   Edited Date  : 
//   Edit By      :
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Forms;
#endregion

namespace WIZ.WM
{
    public partial class PD8000 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        string RS_CODE = string.Empty;
        string RS_MSG = string.Empty;

        bool bFIFOEnable = false;

        string sSelItemCode = "";

        string sSelOutNo = "";
        string SHIPNO = "";

        string sPackNO = "";
        #endregion

        #region < CONSTRUCTOR >

        public PD8000()
        {
            InitializeComponent();
        }

        #endregion

        #region < FORM LOAD >
        private void PD8000_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;

            pnlResult.Visible = false;
            pnlResult.Size = new Size(257, 416);
            pnlResult.Location = new Point(37, 32);
            lblFormName.Text = lblFormName.Text + " (" + LoginInfo.PlantCode + "-" + LoginInfo.UserID + ")";

            GridInit();
        }

        private void GridInit()
        {
            //출하지시 내역
            grid1.View = View.Details;
            grid1.Columns.Clear();
            grid1.Columns.Add(new Grid.ColHeader("Check", 0, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("지시번호", 0, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("출하일자", 0, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("납품업체코드", 0, HorizontalAlignment.Left, true));
            grid1.Columns.Add(new Grid.ColHeader("납품업체", 0, HorizontalAlignment.Left, true));
            grid1.Columns.Add(new Grid.ColHeader("품목", 0, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("품명", 140, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("잔여", 50, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("적재", 50, HorizontalAlignment.Center, true));

            //스캔 바코드 내역
            grid2.View = View.Details;
            grid2.Columns.Clear();
            grid2.Columns.Add(new Grid.ColHeader("Check", 20, HorizontalAlignment.Center, true));
            grid2.Columns.Add(new Grid.ColHeader("바코드번호", 170, HorizontalAlignment.Center, true));
            //grid2.Columns.Add(new Grid.ColHeader("품목", 0, HorizontalAlignment.Left, true));
            //grid2.Columns.Add(new Grid.ColHeader("품명", 0, HorizontalAlignment.Left, true));
            grid2.Columns.Add(new Grid.ColHeader("수량", 50, HorizontalAlignment.Right, true));
            grid2.Columns.Add(new Grid.ColHeader("종류", 0, HorizontalAlignment.Center, true));

            //지시번호 클릭 시 출력
            grid3.View = View.Details;
            grid3.Columns.Clear();
            grid3.Columns.Add(new Grid.ColHeader("Check", 0, HorizontalAlignment.Center, true));
            grid3.Columns.Add(new Grid.ColHeader("일자", 80, HorizontalAlignment.Center, true));
            grid3.Columns.Add(new Grid.ColHeader("품목", 90, HorizontalAlignment.Left, true));
            grid3.Columns.Add(new Grid.ColHeader("수량", 50, HorizontalAlignment.Right, true));
            grid3.Columns.Add(new Grid.ColHeader("품명", 120, HorizontalAlignment.Center, true));
            grid3.Columns.Add(new Grid.ColHeader("출하번호", 80, HorizontalAlignment.Center, true));

            grid4.View = View.Details;
            grid4.Columns.Clear();
            grid4.Columns.Add(new Grid.ColHeader("Check", 20, HorizontalAlignment.Center, true));
            grid4.Columns.Add(new Grid.ColHeader("바코드번호", 170, HorizontalAlignment.Left, true));
            grid4.Columns.Add(new Grid.ColHeader("수량", 50, HorizontalAlignment.Right, true));
            grid4.Columns.Add(new Grid.ColHeader("종류", 0, HorizontalAlignment.Center, true));

            SetScreen();

            ControlClear();
        }

        private void SetScreen()
        {
            grid1.Size = new Size(254, 198);
            grid1.Location = new Point(37, 194);

            pnlLoc.Visible = false;
            pnlShip.Visible = true;

            DBHelper dbhelper = new DBHelper();

            //임시쿼리
            DataTable dt = dbhelper.FillTable("USP_PD8000_S1", CommandType.StoredProcedure,
                                dbhelper.CreateParameter("@PCODE", "S0", DbType.String, ParameterDirection.Input),
                                dbhelper.CreateParameter("@AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                                dbhelper.CreateParameter("@AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input));

            RS_CODE = Convert.ToString(dbhelper.RSCODE);
            RS_MSG = Convert.ToString(dbhelper.RSMSG);

            if (dt.Rows.Count > 0)
            {
                // 항목이 있으면,
                string sCode = CModule.ToString(dt.Rows[0]["REQUIRE"]);

                if (sCode == "DY")
                {
                    // 동양피스톤 선입선출 처리의 경우
                    pnlLoc.Visible = true;
                    pnlShip.Visible = false;

                    pnlLoc.Location = pnlShip.Location;
                    grid1.Location = new Point(37, 230);
                    grid1.Size = new Size(254, 162);

                    bFIFOEnable = true;
                }
            }
        }

        #endregion

        #region < USER METHOD AREA >
        private void ControlClear()
        {
            grid1.Items.Clear();
            grid2.Items.Clear();
            grid3.Items.Clear();

            sSelOutNo = "";
            SHIPNO = "";
            txtShipDate.Text = "";
            txtShipDate2.Text = "";
            txtCustCode.Text = "";
            txtLoc.Text = "";
            txtSubLot.Text = "";
        }
        #endregion

        private void sSelOutNo_Check()
        {
            try
            {
                //제품출하 지시번호 검색
                sSelItemCode = "";

                //DataTable dtsSelOutNo = new DataTable();

                DataSet ds = new DataSet();

                DBHelper DBhelper = new DBHelper(false);

                sSelOutNo = txtSelOutNo.Text.Trim();

                ////임시쿼리
                //dtsSelOutNo = DBhelper.FillTable("USP_PD8000_S1", CommandType.StoredProcedure,
                //                    DBhelper.CreateParameter("@PCODE", "S1", DbType.String, ParameterDirection.Input),
                //                    DBhelper.CreateParameter("@AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                //                    DBhelper.CreateParameter("@AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input));

                ds = DBhelper.FillDataSet("USP_PD8000_S1", CommandType.StoredProcedure,
                                    DBhelper.CreateParameter("@PCODE", "S1", DbType.String, ParameterDirection.Input),
                                    DBhelper.CreateParameter("@AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                                    DBhelper.CreateParameter("@AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input));

                RS_CODE = Convert.ToString(DBhelper.RSCODE);
                RS_MSG = Convert.ToString(DBhelper.RSMSG);

                txtLoc.Text = "";

                if (ds.Tables.Count <= 1)
                {
                    this.ShowDialog(Common.getLangText("출하지시 번호 확인 필요.", "MSG"), DialogForm.DialogType.OK);
                    txtSelOutNo.Text = "";
                    return;
                }
                if (ds.Tables[1].Rows.Count == 0)
                {
                    this.ShowDialog(Common.getLangText("출하지시 번호 확인 필요.", "MSG"), DialogForm.DialogType.OK);
                    txtSelOutNo.Text = "";
                    return;
                }
                else
                {
                    txtCustName.Text = ds.Tables[1].Rows[0]["CUSTOMERNAME"].ToString();
                    txtShipDate.Text = ds.Tables[1].Rows[0]["RECDATE"].ToString();
                    lblShipType.Text = CModule.ToString(ds.Tables[1].Rows[0]["SHIPTYPE"]);
                    txtShipDate2.Text = txtShipDate.Text;

                    if (sSelItemCode == "")
                    {
                        sSelItemCode = ds.Tables[1].Rows[0]["ITEMCODE"].ToString();
                    }

                    WIZ.Control.CmmnListView.SetData(grid1, ds);
                    //grid1.Items.Clear();

                    //for (int i = 0; i < dtsSelOutNo.Rows.Count; i++)
                    //{

                    //    //if (sSelItemCode == "")
                    //    //{
                    //    //    sSelItemCode = dtsSelOutNo.Rows[i]["ITEMCODE"].ToString();
                    //    //    bFIFOEnable = true;
                    //    //}
                    //    //else if (sSelItemCode != dtsSelOutNo.Rows[i]["ITEMCODE"].ToString())
                    //    //{
                    //    //    bFIFOEnable = false;
                    //    //    txtLoc.Text = "단일 품목일때만 가능";
                    //    //}

                    //    ListViewItem lvl = new ListViewItem(); ;
                    //    lvl.SubItems.Add(dtsSelOutNo.Rows[i]["SELOUTNO"].ToString());
                    //    lvl.SubItems.Add(dtsSelOutNo.Rows[i]["RECDATE"].ToString());
                    //    lvl.SubItems.Add(dtsSelOutNo.Rows[i]["CUSTOMERCODE"].ToString());
                    //    lvl.SubItems.Add(dtsSelOutNo.Rows[i]["CUSTOMERNAME"].ToString());
                    //    lvl.SubItems.Add(dtsSelOutNo.Rows[i]["ITEMCODE"].ToString());
                    //    lvl.SubItems.Add(dtsSelOutNo.Rows[i]["ITEMNAME"].ToString());
                    //    lvl.SubItems.Add(dtsSelOutNo.Rows[i]["PLANQTY"].ToString());
                    //    lvl.SubItems.Add(dtsSelOutNo.Rows[i]["SHIPQTY"].ToString());

                    //    grid1.Items.Add(lvl);
                    //    grid1.EndUpdate();
                    //}
                }

                //SetNextItem();  안기선수정 2022.07.04
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private bool Search(string sItemCode)
        {
            //DataTable dt = new DataTable();

            DataSet ds = new DataSet();

            DBHelper DBhelper = new DBHelper(false);

            ds = DBhelper.FillDataSet("USP_PD8000_S2", CommandType.StoredProcedure,
                                    DBhelper.CreateParameter("PCODE", "S1", DbType.String, ParameterDirection.Input),
                                    DBhelper.CreateParameter("AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                                    DBhelper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input),
                                    DBhelper.CreateParameter("AS_RELCODE1", sItemCode, DbType.String, ParameterDirection.Input),
                                    DBhelper.CreateParameter("AS_RELCODE2", "", DbType.String, ParameterDirection.Input));

            RS_CODE = Convert.ToString(DBhelper.RSCODE);
            RS_MSG = Convert.ToString(DBhelper.RSMSG);

            grid2.Items.Clear();

            if (ds.Tables.Count <= 1)
            {
                return false;
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                WIZ.Control.CmmnListView.SetData(grid2, ds);

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    ListViewItem lvl = new ListViewItem(); ;
                //    lvl.SubItems.Add(CModule.ToString(dt.Rows[i]["LOTNO"]));
                //    //lvl.SubItems.Add(dt.Rows[i]["ITEMCODE"].ToString());
                //    //lvl.SubItems.Add(dt.Rows[i]["ITEMNAME"].ToString());
                //    lvl.SubItems.Add(CModule.ToString(dt.Rows[i]["NOWQTY"]));
                //    lvl.SubItems.Add(CModule.ToString(dt.Rows[i]["BOXTYPE"]));

                //    grid2.Items.Add(lvl);
                //    grid2.EndUpdate();
                //}

                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetNextItem()
        {
            if (bFIFOEnable)
            {
                if (sSelItemCode != "")
                {
                    txtLoc.Text = "";
                    txtSubLot.Text = "";
                    txtLoc.Tag = "";

                    DataTable dt = new DataTable();

                    DBHelper DBhelper = new DBHelper(false);

                    dt = DBhelper.FillTable("USP_GETNEXTFIFO_LOC", CommandType.StoredProcedure,
                                            DBhelper.CreateParameter("@PCODE", "S1", DbType.String, ParameterDirection.Input),
                                            DBhelper.CreateParameter("@AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input),
                                            DBhelper.CreateParameter("@AS_ITEMCODE", sSelItemCode, DbType.String, ParameterDirection.Input),
                                            DBhelper.CreateParameter("@AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                            );

                    RS_CODE = Convert.ToString(DBhelper.RSCODE);
                    RS_MSG = Convert.ToString(DBhelper.RSMSG);

                    if (RS_CODE.StartsWith("S"))
                    {
                        string[] sArr = RS_MSG.Split('|');
                        txtSubLot.Text = sArr[0];
                        txtLoc.Text = sArr[1];
                        txtLoc.Tag = sArr[2];
                    }
                    else if (RS_CODE == "B")
                    {
                        return;
                    }
                    else
                    {
                        this.ShowDialog(RS_MSG, Forms.DialogForm.DialogType.OK);
                    }
                }
            }
        }

        private void ITEM_Check()
        {
            try
            {
                DataTable LOTdt = new DataTable();

                DBHelper DBhelper = new DBHelper(false);
                //상세내역 추가

                string sLOTNO = txtInputBarCode.Text.Trim();

                DataSet ds = DBhelper.FillDataSet("USP_PD8000_I1", CommandType.StoredProcedure,
                                    DBhelper.CreateParameter("@AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                                    DBhelper.CreateParameter("@AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input),
                                    DBhelper.CreateParameter("@AS_LOTNO", sLOTNO, DbType.String, ParameterDirection.Input)); //수주번호, 출하지시번호

                RS_CODE = Convert.ToString(DBhelper.RSCODE);
                RS_MSG = Convert.ToString(DBhelper.RSMSG);

                pnlResult.Visible = false;

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Columns.Contains("ITEMCODE"))
                    {
                        string sItemCode = "";
                        string sPreItemCode = "";

                        txtResult.Text = "";

                        // 처리 결과를 테이블로 받을 경우
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            sItemCode = CModule.ToString(dr["ITEMCODE"]);

                            if (sPreItemCode != sItemCode)
                            {
                                txtResult.Text += "[" + sItemCode + "] " + CModule.ToString(dr["ITEMNAME"]) + Environment.NewLine;
                            }

                            sPreItemCode = sItemCode;

                            txtResult.Text += CModule.ToString(dr["LOTNO"]) + " : " + string.Format("{0:#,###}", CModule.ToInt32(dr["ASCOUNT"])) + Environment.NewLine;
                        }

                        txtResult.Text += "위의 데이터가 처리되었습니다.";

                        pnlResult.Visible = true;
                        pnlResult.BringToFront();
                    }
                }
                txtInputBarCode.Text = "";

                if (RS_CODE == "E")
                {
                    DBhelper.Rollback();
                    throw new Exception(RS_MSG);
                }
                else
                {
                    DBhelper.Commit();
                }

                sSelOutNo_Check();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void btnFIFO_Click(object sender, EventArgs e)
        {
            SetNextItem();
        }

        private void grid1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            string sItemCode = e.Item.SubItems[5].Text;

            if (sItemCode.Trim() != "")
            {
                if (sSelItemCode != sItemCode)
                {
                    sSelItemCode = sItemCode;

                    SetNextItem();
                }
            }
        }

        #region < EVENT AREA >
        private void txtSelOutNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                sSelOutNo_Check();
            }
        }

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
                ITEM_Check();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DBHelper DBhelper = new DBHelper("", true);
            DataTable ShipNOdt = new DataTable();

            if (grid1.Items.Count == 0)
            {
                this.ShowDialog(Common.getLangText("출하지시가 없습니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            try
            {

                DialogResult result = MessageBox.Show("입력한 출하정보를 출하처리 하시겠습니까?", btnInsert.Text, MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result.ToString().ToUpper() == "YES")
                {
                    SHIPNO = "";

                    DBhelper.ExecuteNoneQuery("USP_WM0140_I5", CommandType.StoredProcedure,
                        DBhelper.CreateParameter("@PCODE", "I0", DbType.String, ParameterDirection.Input),
                        DBhelper.CreateParameter("@AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input),
                        DBhelper.CreateParameter("@AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input), //수주번호
                        DBhelper.CreateParameter("@AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input), //출하번호
                        DBhelper.CreateParameter("@AS_SHIPDATE", string.Format("{0:yyyy-MM-dd}", DateTime.Now), DbType.String, ParameterDirection.Input),
                        DBhelper.CreateParameter("@AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                    RS_CODE = Convert.ToString(DBhelper.RSCODE);
                    RS_MSG = Convert.ToString(DBhelper.RSMSG);

                    if (RS_CODE == "E")
                    {
                        throw new Exception(RS_MSG);
                    }

                    SHIPNO = RS_MSG;

                    DBhelper.ExecuteNoneQuery("USP_WM0140_I4", CommandType.StoredProcedure,
                        DBhelper.CreateParameter("@PCODE", "I1", DbType.String, ParameterDirection.Input),
                        DBhelper.CreateParameter("@AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input),
                        DBhelper.CreateParameter("@AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input), //수주번호
                        DBhelper.CreateParameter("@AS_SHIPNO", SHIPNO, DbType.String, ParameterDirection.Input), //출하번호
                        DBhelper.CreateParameter("@AS_SHIPDATE", string.Format("{0:yyyy-MM-dd}", DateTime.Now), DbType.String, ParameterDirection.Input),
                        DBhelper.CreateParameter("@AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                    RS_CODE = Convert.ToString(DBhelper.RSCODE);
                    RS_MSG = Convert.ToString(DBhelper.RSMSG);

                    if (RS_CODE == "E")
                    {
                        throw new Exception(RS_MSG);
                    }

                    DBhelper.Commit();

                    txtSelOutNo.Text = "";
                    sSelOutNo = "";

                    ControlClear();
                }
            }
            catch (Exception ex)
            {
                DBhelper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                DBhelper.Close();
            }
        }
        private void btnDEL_Click(object sender, EventArgs e)
        {
            DBHelper execHelper = new DBHelper(false);

            try
            {
                DialogResult result = MessageBox.Show("선택 항목 삭제하시겠습니까?", "", MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result.ToString().ToUpper() == "YES")
                {
                    RS_CODE = "";

                    for (int i = 0; i < grid2.Items.Count; i++)
                    {
                        if (grid2.Items[i].Checked == true)
                        {
                            string Barcode = grid2.Items[i].SubItems[1].Text;

                            execHelper.ExecuteNoneQuery("USP_PD8000_D1", CommandType.StoredProcedure,
                            execHelper.CreateParameter("@AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                            execHelper.CreateParameter("@AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input),
                            execHelper.CreateParameter("@AS_LOTNO", Barcode, DbType.String, ParameterDirection.Input));

                            RS_CODE = Convert.ToString(execHelper.RSCODE);
                            RS_MSG = Convert.ToString(execHelper.RSMSG);

                            if (RS_CODE == "E")
                            {
                                throw new Exception(RS_MSG);
                            }
                        }
                    }

                    if (RS_CODE != "")
                    {
                        panel1.Visible = true;
                        panel2.Visible = false;
                        panel3.Visible = false;
                        execHelper.Commit();
                        sSelOutNo_Check();
                    }
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                execHelper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }

        }

        private void btnDEL2_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = MessageBox.Show("항목 전체를 삭제 하시겠습니까?", "", MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result.ToString().ToUpper() == "YES")
                {
                    DBHelper execHelper = new DBHelper(false);
                    execHelper.ExecuteNoneQuery("USP_PD8000_D1", CommandType.StoredProcedure,
                            execHelper.CreateParameter("@AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                            execHelper.CreateParameter("@AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input),
                            execHelper.CreateParameter("@AS_LOTNO", "*", DbType.String, ParameterDirection.Input));

                    RS_CODE = Convert.ToString(execHelper.RSCODE);
                    RS_MSG = Convert.ToString(execHelper.RSMSG);

                    if (RS_CODE == "E")
                    {
                        execHelper.Rollback();
                        throw new Exception(RS_MSG);

                    }
                    else
                    {
                        panel1.Visible = true;
                        panel2.Visible = false;
                        panel3.Visible = false;
                        execHelper.Commit();
                        sSelOutNo_Check();
                    }
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imgButton2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            DBHelper DBhelper = new DBHelper(false);

            if (grid3.Visible == false)
            {
                grid3.Visible = true;
                grid3.Size = new Size(254, 327);
                grid3.Location = new Point(37, 65);
                grid3.BringToFront();
            }
            else
            {
                grid3.Visible = false;
            }

            if (grid3.Visible)
            {
                ds = DBhelper.FillDataSet("USP_PD8000_S1", CommandType.StoredProcedure,
                                    DBhelper.CreateParameter("@PCODE", "S3", DbType.String, ParameterDirection.Input),
                                    DBhelper.CreateParameter("@AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                                    DBhelper.CreateParameter("@AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input));


                RS_CODE = Convert.ToString(DBhelper.RSCODE);
                RS_MSG = Convert.ToString(DBhelper.RSMSG);

                grid3.Items.Clear();

                if (ds.Tables.Count <= 1)
                {
                    this.ShowDialog(Common.getLangText("출하지시 번호 확인 필요.", "MSG"), DialogForm.DialogType.OK);
                    txtSelOutNo.Text = "";
                    return;
                }

                if (ds.Tables[1].Rows.Count == 0)
                {
                    this.ShowDialog(Common.getLangText("출하지시 번호 확인 필요.", "MSG"), DialogForm.DialogType.OK);
                    txtSelOutNo.Text = "";
                    return;
                }

                else
                {
                    WIZ.Control.CmmnListView.SetData(grid3, ds);
                    //for (int i = 0; i < dt2.Rows.Count; i++)
                    //{
                    //    ListViewItem lvl2 = new ListViewItem();
                    //    lvl2.SubItems.Add(dt2.Rows[i]["RECDATE"].ToString());
                    //    lvl2.SubItems.Add(dt2.Rows[i]["ITEMCODE"].ToString());
                    //    lvl2.SubItems.Add(dt2.Rows[i]["PLANQTY"].ToString());
                    //    lvl2.SubItems.Add(dt2.Rows[i]["ITEMNAME"].ToString());
                    //    lvl2.SubItems.Add(dt2.Rows[i]["SELOUTNO"].ToString());
                    //    grid3.Items.Add(lvl2);
                    //    grid3.EndUpdate();
                    //}
                }
            }
        }

        private void grid3_ItemActivate(object sender, EventArgs e)
        {
            txtSelOutNo.Text = grid3.FocusedItem.SubItems[5].Text;
            txtSelOutNo.Focus();
            grid3.Visible = false;

            if (txtSelOutNo.Text != "")
            {
                sSelOutNo_Check();
            }
        }


        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (grid1.FocusedItem != null)
            {
                string sBarcode = grid1.FocusedItem.SubItems[5].Text;
                grid2.Items.Clear();

                if (Search(sBarcode))
                {
                    panel1.Visible = false;
                    panel2.Visible = true;
                    panel3.Visible = false;

                    panel2.Top = panel1.Top;
                    panel2.Left = panel1.Left;
                }
                else
                {
                    this.ShowDialog("선택한 바코드는 상세 정보를 볼 수가 없습니다.", DialogForm.DialogType.OK);
                }
            }
            else
            {
                this.ShowDialog("상세 정보를 확인하고 싶은 바코드를 선택하세요.", DialogForm.DialogType.OK);
            }
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            //grid2.Items.Clear();
        }

        private bool Search2(string sPackNo)
        {
            DataSet ds = new DataSet();

            DBHelper dBHelper = new DBHelper(false);

            ds = dBHelper.FillDataSet("USP_PD8000_S2", CommandType.StoredProcedure
                                                        , dBHelper.CreateParameter("PCODE", "S2", DbType.String, ParameterDirection.Input)
                                                        , dBHelper.CreateParameter("AS_USERID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                        , dBHelper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
                                                        , dBHelper.CreateParameter("AS_RELCODE1", sPackNo, DbType.String, ParameterDirection.Input)
                                                        , dBHelper.CreateParameter("AS_RELCODE2", "", DbType.String, ParameterDirection.Input));

            grid4.Items.Clear();

            if (ds.Tables.Count <= 1)
            {
                return false;
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                WIZ.Control.CmmnListView.SetData(grid4, ds);
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    ListViewItem lvl = new ListViewItem(); ;
                //    lvl.SubItems.Add(dt.Rows[i]["LOTNO"].ToString());
                //    //lvl.SubItems.Add(dt.Rows[i]["ITEMCODE"].ToString());
                //    //lvl.SubItems.Add(dt.Rows[i]["ITEMNAME"].ToString());
                //    lvl.SubItems.Add(dt.Rows[i]["PACKQTY"].ToString());
                //    lvl.SubItems.Add(dt.Rows[i]["BOXTYPE"].ToString());

                //    grid4.Items.Add(lvl);
                //    grid4.EndUpdate();
                //}

                this.sPackNO = sPackNo;

                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnNextPage2_Click(object sender, EventArgs e)
        {


            if (grid2.FocusedItem != null)
            {
                string Barcode = grid2.FocusedItem.SubItems[1].Text;
                string sBoxType = grid2.FocusedItem.SubItems[3].Text;

                if (sBoxType == "B")
                {
                    grid4.Items.Clear();

                    if (Search2(Barcode))
                    {
                        panel1.Visible = false;
                        panel2.Visible = false;
                        panel3.Visible = true;

                        panel3.Top = panel1.Top;
                        panel3.Left = panel1.Left;
                    }
                    else
                    {
                        this.ShowDialog("선택한 바코드는 상세 정보를 볼 수가 없습니다.", DialogForm.DialogType.OK);
                    }
                }
                else
                {
                    this.ShowDialog("선택한 바코드는 상세 정보를 볼 수가 없습니다.", DialogForm.DialogType.OK);
                }
            }
            else
            {
                this.ShowDialog("상세 정보를 확인하고 싶은 바코드를 선택하세요.", DialogForm.DialogType.OK);
            }
        }

        private void ExecItemList(bool bDel)
        {
            DBHelper execHelper = null;

            try
            {
                execHelper = new DBHelper("", true);

                execHelper.ExecuteNoneQuery("USP_PD8000_S2", CommandType.StoredProcedure,
                    execHelper.CreateParameter("PCODE", "D0", DbType.String, ParameterDirection.Input),
                    execHelper.CreateParameter("AS_USERID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                    execHelper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input),
                    execHelper.CreateParameter("AS_RELCODE1", sPackNO, DbType.String, ParameterDirection.Input),
                    execHelper.CreateParameter("AS_RELCODE2", "", DbType.String, ParameterDirection.Input));

                RS_CODE = execHelper.RSCODE;
                RS_MSG = execHelper.RSMSG;

                if (RS_CODE == "E")
                {
                    execHelper.Rollback();
                    throw new Exception(RS_MSG);
                }

                for (int i = 0; i < grid4.Items.Count; i++)
                {
                    bool bOK = false;

                    if (bDel)
                    {
                        // 삭제하는 경우는 체크된 친구들은 남아 있으면 안 됨
                        bOK = !grid4.Items[i].Checked;
                    }
                    else
                    {
                        // 해당 자재만 남기고 처리
                        bOK = grid4.Items[i].Checked;
                    }

                    if (bOK)
                    {
                        // 아래의 코드는 잔여 바코드에 대한 처리
                        string sBarcode = grid4.Items[i].SubItems[1].Text;

                        execHelper.ExecuteNoneQuery("USP_PD8000_S2", CommandType.StoredProcedure,
                            execHelper.CreateParameter("PCODE", "D1", DbType.String, ParameterDirection.Input),
                            execHelper.CreateParameter("AS_USERID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                            execHelper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input),
                            execHelper.CreateParameter("AS_RELCODE1", sBarcode, DbType.String, ParameterDirection.Input),
                            execHelper.CreateParameter("AS_RELCODE2", "", DbType.String, ParameterDirection.Input));

                        RS_CODE = execHelper.RSCODE;
                        RS_MSG = execHelper.RSMSG;

                        if (RS_CODE == "E")
                        {
                            execHelper.Rollback();
                            throw new Exception(RS_MSG);
                        }
                    }
                }

                execHelper.ExecuteNoneQuery("USP_PD8000_S2", CommandType.StoredProcedure,
                    execHelper.CreateParameter("PCODE", "DX", DbType.String, ParameterDirection.Input),
                    execHelper.CreateParameter("AS_USERID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                    execHelper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input),
                    execHelper.CreateParameter("AS_RELCODE1", sPackNO, DbType.String, ParameterDirection.Input),
                    execHelper.CreateParameter("AS_RELCODE2", "", DbType.String, ParameterDirection.Input));

                RS_CODE = execHelper.RSCODE;
                RS_MSG = execHelper.RSMSG;

                if (RS_CODE == "E")
                {
                    execHelper.Rollback();
                    throw new Exception(RS_MSG);
                }

                execHelper.Commit();

                sSelOutNo_Check();
                //pnlBG1.BringToFront();

                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
            }
            catch (Exception ex)
            {
                if (execHelper != null)
                {
                    execHelper.Rollback();
                }
                this.ShowDialog(ex.Message, DialogForm.DialogType.OK);

            }
        }

        private void btnDEL4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("선택한 항목만 제외 하시겠습니까?", btnDEL4.Text, MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result.ToString().ToUpper() == "YES")
            {
                ExecItemList(true);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("선택한 항목만 남겨놓고 모두 삭제하시겠습니까?", btnInsert.Text, MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result.ToString().ToUpper() == "YES")
            {
                ExecItemList(false);
            }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            //pnlBG1.BringToFront();
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void btnPrePage2_Click(object sender, EventArgs e)
        {
            //pnlBG2.BringToFront();
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void btnResultClose_Click(object sender, EventArgs e)
        {
            pnlResult.Visible = false;
        }
        #endregion

    }
}

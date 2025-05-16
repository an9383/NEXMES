#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD3050
//   Form Name    : Location 이동
//   Name Space   : NEXPDA
//   Created Date : 2020-11-26
//   Made By      : inho.hwang
//   Edited Date  : 
//   Edit By      :
//   Description  : 로케이션 이동 처리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
#endregion

namespace WIZ.MM
{
    public partial class PD3050 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        string RS_CODE = string.Empty;
        string RS_MSG = string.Empty;

        string gBarCode = string.Empty;
        string gItemCode = string.Empty;
        string sItemCode = string.Empty;             //품번
        string sItemName = string.Empty;             //품명
        string sQty = string.Empty;             //수량
        string sUnitCode = string.Empty;             //단위
        string sWhCode = string.Empty;             //창고
        string sWhName = string.Empty;             //창고이름
        string sStorageLocCode = string.Empty;             //위치
        string sStorageLocName = string.Empty;             //위치이름
        string stext = string.Empty;

        DataTable rtnDtTemp = new DataTable();

        bool bLimit = false;

        private double dLimit;
        private double dValue;
        #endregion

        #region < CONSTRUCTOR >

        public PD3050()
        {
            InitializeComponent();
        }

        protected override void SetSubData()
        {
            string s = subData["METHOD_TEXT"];
            bLimit = false;

            if (s != "")
            {
                lblLimit.Visible = true;
                txtLimit.Visible = true;
                bLimit = true;
            }
        }

        #endregion

        #region < FORM LOAD >
        private void PD3050_Load(object sender, EventArgs e)
        {
            //타이틀 설정

            panel1.Visible = true;
            panel2.Visible = false;

            lblFormName.Visible = true;
            lblFormName2.Visible = false;

            lblFormName.Text = lblFormName.Text + " (" + LoginInfo.PlantCode + "-" + LoginInfo.UserID + ")";

            txtInputBarCode.Select();

            GridInit();

            txtInputBarCode.Focus();

            search();

        }
        #endregion

        #region < USER METHOD AREA >

        private void GridInit()
        {
            grid1.View = View.Details;
            grid1.Columns.Add(new Grid.ColHeader("C", 30, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("사용자", 0, HorizontalAlignment.Center, true));
            grid1.Columns.Add(new Grid.ColHeader("품목", 0, HorizontalAlignment.Left, true));
            grid1.Columns.Add(new Grid.ColHeader("품명", 100, HorizontalAlignment.Left, true));
            grid1.Columns.Add(new Grid.ColHeader("수량", 100, HorizontalAlignment.Right, true));

            grid2.View = View.Details;
            grid2.Columns.Add(new Grid.ColHeader("C", 30, HorizontalAlignment.Center, true));
            grid2.Columns.Add(new Grid.ColHeader("LOTNO", 130, HorizontalAlignment.Center, true));
            grid2.Columns.Add(new Grid.ColHeader("품목", 0, HorizontalAlignment.Left, true));
            grid2.Columns.Add(new Grid.ColHeader("수량", 80, HorizontalAlignment.Right, true));
            grid2.Columns.Add(new Grid.ColHeader("LOC", 0, HorizontalAlignment.Right, true));

        }



        private void ControlClear()
        {
            txtInputBarCode.Text = string.Empty;
            txtBarCode.Text = string.Empty;
            txtStorageName.Text = string.Empty;
            txtStorageCode.Text = string.Empty;

            txtInputBarCode.Select();

            gBarCode = string.Empty;

        }

        //바코드 검색
        private void SONO_Check()
        {
            DataTable dtSONO = new DataTable();
            //DBHelper dbHelper = new DBHelper("", true);
            DBHelper dbHelper = new DBHelper(false);

            try
            {
                if (txtInputBarCode.Text.Trim() == "")
                {
                    return;
                }

                string sType = "I";

                sType = radioButton1.Checked ? "L" : "I";

                gBarCode = txtInputBarCode.Text.Trim();

                dtSONO = dbHelper.FillTable("CALL_BASKET", CommandType.StoredProcedure,
                        dbHelper.CreateParameter("AS_BARCODE", gBarCode, DbType.String, ParameterDirection.Input),
                        dbHelper.CreateParameter("AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                        dbHelper.CreateParameter("AS_TYPE", sType, DbType.String, ParameterDirection.Input));

                RS_CODE = DBHelper.nvlString(dbHelper.RSCODE);
                RS_MSG = DBHelper.nvlString(dbHelper.RSMSG);

                string str = RS_CODE.Trim();

                int IndexValue = str.IndexOf('|');

                if (IndexValue > 0)
                {
                    str = str.Substring(0, IndexValue);
                }

                if (RS_CODE == "E")
                {
                    throw new Exception(RS_MSG);
                }
                else
                {
                    //dbHelper.Commit();

                    string str2 = RS_CODE.Trim();
                    int index = str2.IndexOf('|') + 1;
                    string RS_TYPE = str2.Substring(index, str2.Length - index);

                    //sType -> RS_TYPE 수정
                    if (RS_TYPE == "L")
                    {
                        if (dtSONO.Rows.Count > 0)
                        {
                            txtStorageName.Text = CModule.ToString(dtSONO.Rows[0]["STORAGELOCNAME"]);
                            txtStorageCode.Text = CModule.ToString(dtSONO.Rows[0]["STORAGELOCCODE"]);

                            if (bLimit)
                            {
                                dLimit = CModule.ToDouble(dtSONO.Rows[0]["LIMIT"]);
                                dValue = CModule.ToDouble(dtSONO.Rows[0]["NOWQTY"]);

                                txtLimit.Text = dValue.ToString() + " / " + dLimit.ToString();
                            }
                        }
                        else
                        {
                            this.ShowDialog("로케이션 바코드를 확인하세요.", Forms.DialogForm.DialogType.OK);
                        }
                    }
                    else if (RS_TYPE == "I")
                    {
                        search();
                    }
                }

                txtInputBarCode.Text = "";
            }
            catch (Exception ex)
            {
                //dbHelper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }

        }

        private void search()
        {
            try
            {
                //DataTable dtSONO = new DataTable();
                DataSet ds = new DataSet();

                DBHelper helper = new DBHelper(false);

                //dtSONO = helper.FillTable("CALL_BASKET"
                //                           , CommandType.StoredProcedure
                //                           , helper.CreateParameter("AS_BARCODE", gBarCode, DbType.String, ParameterDirection.Input)
                //                           , helper.CreateParameter("AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                //                           , helper.CreateParameter("AS_TYPE", "S", DbType.String, ParameterDirection.Input));

                ds = helper.FillDataSet("USP_PD3050_S1"
                                           , CommandType.StoredProcedure
                                           , helper.CreateParameter("AS_BARCODE", gBarCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_TYPE", "S", DbType.String, ParameterDirection.Input));

                RS_CODE = Convert.ToString(helper.RSCODE);
                RS_MSG = Convert.ToString(helper.RSMSG);
                //2021-01-25
                string str = RS_CODE.Trim();

                int IndexValue = str.IndexOf('|');

                if (IndexValue > 0)
                {
                    RS_CODE = str.Substring(0, IndexValue);
                }

                if (RS_CODE == "E")
                {
                    this.ShowDialog(RS_MSG, DialogForm.DialogType.OK);
                    return;
                }

                else
                {
                    txtInputBarCode.Text = "";

                    WIZ.Control.CmmnListView.SetData(grid1, ds);

                    //grid1.Items.Clear();

                    //for (int i = 0; i < dtSONO.Rows.Count; i++)
                    //{
                    //    ListViewItem lvl = new ListViewItem(); ;
                    //    lvl.SubItems.Add(dtSONO.Rows[i]["USERID"].ToString());
                    //    lvl.SubItems.Add(dtSONO.Rows[i]["ITEMCODE"].ToString());
                    //    lvl.SubItems.Add(dtSONO.Rows[i]["ITEMNAME"].ToString());
                    //    lvl.SubItems.Add(dtSONO.Rows[i]["ITEMCOUNT"].ToString());
                    //    grid1.Items.Add(lvl);
                    //    grid1.EndUpdate();
                    //}

                    for (int i = 0; i < grid1.Items.Count; i++)
                    {
                        grid1.Items[i].Checked = true;
                    }

                    txtInputBarCode.Focus();
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }

        }
        private void details_search() // PDA 소스 확인 완료
        {
            try
            {
                if (sItemCode == "")
                {
                    this.ShowDialog(Common.getLangText("품목을 선택하세요.", "MSG"), DialogForm.DialogType.OK);
                    grid2.Items.Clear();
                    //panel1.BringToFront();
                    panel1.Visible = true;
                    panel2.Visible = false;
                    //return;
                }

                //DataTable dtWM = new DataTable();
                DataSet ds = new DataSet();

                DBHelper DBhelper = new DBHelper(false);

                //dtWM = DBhelper.FillTable("CALL_BASKET", CommandType.StoredProcedure,
                //       DBhelper.CreateParameter("AS_BARCODE", sItemCode, DbType.String, ParameterDirection.Input),
                //       DBhelper.CreateParameter("AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                //       DBhelper.CreateParameter("AS_TYPE", "D", DbType.String, ParameterDirection.Input));
                ds = DBhelper.FillDataSet("USP_PD3050_S1", CommandType.StoredProcedure,
                           DBhelper.CreateParameter("AS_BARCODE", sItemCode, DbType.String, ParameterDirection.Input),
                           DBhelper.CreateParameter("AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                           DBhelper.CreateParameter("AS_TYPE", "D", DbType.String, ParameterDirection.Input));

                RS_CODE = Convert.ToString(DBhelper.RSCODE);
                RS_MSG = Convert.ToString(DBhelper.RSMSG);

                //2021-01-25
                string str = RS_CODE.Trim();

                int IndexValue = str.IndexOf('|');

                if (IndexValue > 0)
                {
                    RS_CODE = str.Substring(0, IndexValue);
                }

                if (RS_CODE == "E")
                {
                    this.ShowDialog(RS_MSG, DialogForm.DialogType.OK);
                    return;
                }

                else
                {
                    WIZ.Control.CmmnListView.SetData(grid2, ds);
                    //grid2.Items.Clear();

                    //for (int i = 0; i < dtWM.Rows.Count; i++)
                    //{
                    //    ListViewItem lvl = new ListViewItem(); ;
                    //    lvl.SubItems.Add(dtWM.Rows[i]["LOTNO"].ToString());
                    //    lvl.SubItems.Add(dtWM.Rows[i]["ITEMCODE"].ToString());
                    //    lvl.SubItems.Add(dtWM.Rows[i]["NOWQTY"].ToString());
                    //    lvl.SubItems.Add(dtWM.Rows[i]["LOC"].ToString());

                    //    grid2.Items.Add(lvl);
                    //    grid2.EndUpdate();
                    //}

                    for (int i = 0; i < grid2.Items.Count; i++)
                    {
                        grid2.Items[i].Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
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
                SONO_Check();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int chkcnt = 0;

                for (int i = 0; i < grid1.Items.Count; i++)
                {
                    if (grid1.Items[i].Checked == true)
                        chkcnt++;
                }

                if (chkcnt == 0)
                {
                    this.ShowDialog(Common.getLangText("저장을 미선택 하였습니다..", "MSG"), DialogForm.DialogType.OK);
                    return;
                }
                if (txtStorageCode.Text == "")
                {
                    this.ShowDialog(Common.getLangText("로케이션 정보가 없습니다.", "MSG"), DialogForm.DialogType.OK);
                    return;
                }

                List<string> sListItem = new List<string>();

                for (int i = 0; i < grid1.Items.Count; i++)
                {
                    if (grid1.Items[i].Checked == true)
                    {
                        string sITEMCODE = grid1.Items[i].SubItems[2].Text;

                        sListItem.Add(sITEMCODE);
                    }
                }

                bool bOK = false;

                if (sListItem.Count > 0)
                {
                    bOK = MakeSaveData();
                }

                if (bOK)
                {
                    DBHelper execHelper = new DBHelper("", true);

                    bool bSUBOK = false;

                    for (int i = 0; i < grid2.Items.Count; i++)
                    {
                        string sITEMCODE = grid2.Items[i].SubItems[2].Text;

                        if (sListItem.Contains(sITEMCODE))
                        {
                            string sLOTNO = grid2.Items[i].SubItems[1].Text;

                            execHelper.ExecuteNoneQuery("USP_WM0100_U2", CommandType.StoredProcedure,
                            execHelper.CreateParameter("AS_BARCODE", sLOTNO, DbType.String, ParameterDirection.Input),
                            execHelper.CreateParameter("AS_LOCCODE", DBHelper.nvlString(txtStorageCode.Text), DbType.String, ParameterDirection.Input),
                            execHelper.CreateParameter("AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            RS_CODE = Convert.ToString(execHelper.RSCODE);
                            RS_MSG = Convert.ToString(execHelper.RSMSG);

                            if (RS_CODE == "N")
                            {
                                bSUBOK = true;
                            }

                            if (RS_CODE == "E")
                            {
                                execHelper.Rollback();
                                throw new Exception(RS_MSG);
                            }
                        }
                    }

                    if (bSUBOK)
                    {
                        this.ShowDialog("저장위치에 수량을 초과하여 저장되지 않은 항목이 있습니다.", DialogForm.DialogType.OK);
                    }

                    execHelper.Commit();
                    txtStorageCode.Text = "";
                    txtStorageName.Text = "";

                    search();
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }


        private bool MakeSaveData()
        {
            try
            {
                //DataTable dtWM = new DataTable();

                DBHelper DBhelper = new DBHelper(false);

                //dtWM = DBhelper.FillTable("CALL_BASKET", CommandType.StoredProcedure,
                //       DBhelper.CreateParameter("AS_BARCODE", sItemCode, DbType.String, ParameterDirection.Input),
                //       DBhelper.CreateParameter("AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                //       DBhelper.CreateParameter("AS_TYPE", "D", DbType.String, ParameterDirection.Input));

                DataSet ds = new DataSet();

                ds = DBhelper.FillDataSet("USP_PD3050_S1", CommandType.StoredProcedure,
                    DBhelper.CreateParameter("AS_BARCODE", "", DbType.String, ParameterDirection.Input),
                       DBhelper.CreateParameter("AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                       DBhelper.CreateParameter("AS_TYPE", "SS", DbType.String, ParameterDirection.Input));

                RS_CODE = CModule.ToString(DBhelper.RSCODE);
                RS_MSG = CModule.ToString(DBhelper.RSMSG);

                //2021-01-25
                string str = RS_CODE.Trim();

                if (str.StartsWith("E"))
                {
                    this.ShowDialog(RS_MSG, Forms.DialogForm.DialogType.OK);
                    return false;
                }

                else
                {
                    WIZ.Control.CmmnListView.SetData(grid2, ds);
                    //grid2.Items.Clear();

                    //for (int i = 0; i < dtWM.Rows.Count; i++)
                    //{
                    //    ListViewItem lvl = new ListViewItem(); ;
                    //    lvl.SubItems.Add(dtWM.Rows[i]["LOTNO"].ToString());
                    //    lvl.SubItems.Add(dtWM.Rows[i]["ITEMCODE"].ToString());
                    //    lvl.SubItems.Add(dtWM.Rows[i]["NOWQTY"].ToString());
                    //    lvl.SubItems.Add(dtWM.Rows[i]["LOC"].ToString());

                    //    grid2.Items.Add(lvl);
                    //    grid2.EndUpdate();
                    //}
                }

                return true;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                return false;
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            //상세내역 확인 화면으로 이동
            panel1.Visible = false;
            panel2.Visible = true;
            lblFormName.Visible = false;
            lblFormName2.Visible = true;

            lblFormName2.Top = 4;
            lblFormName2.Left = 4;
            panel2.Top = panel1.Top;
            panel2.Left = panel1.Left;
            details_search();
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            //로케이션 화면으로 이동
            panel1.Visible = true;
            panel2.Visible = false;
            lblFormName.Visible = true;
            lblFormName2.Visible = false;

            btnBarCode.PerformClick();
            grid2.Items.Clear();
            search();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            search();
        }

        private void grid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (grid1.Items.Count > 0)
                {
                    if (grid1.Focused == true)
                    {
                        sItemCode = grid1.FocusedItem.SubItems[2].Text;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);

            }
        }

        private void btnDEL1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtMD = new DataTable();
                DBHelper dbhelper = new DBHelper("", true);

                for (int i = 0; i < grid1.Items.Count; i++)
                {
                    if (grid1.Items[i].Checked == true)
                    {
                        gBarCode = grid1.Items[i].SubItems[2].Text;

                        dbhelper.ExecuteNoneQuery("CALL_BASKET", CommandType.StoredProcedure,
                         dbhelper.CreateParameter("AS_BARCODE", gBarCode, DbType.String, ParameterDirection.Input),
                         dbhelper.CreateParameter("AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                         dbhelper.CreateParameter("AS_TYPE", "MD", DbType.String, ParameterDirection.Input));

                        RS_CODE = Convert.ToString(dbhelper.RSCODE);
                        RS_MSG = Convert.ToString(dbhelper.RSMSG);

                        //2021-01-25
                        string str = RS_CODE.Trim();

                        int IndexValue = str.IndexOf('|');

                        if (IndexValue > 0)
                        {
                            RS_CODE = str.Substring(0, IndexValue);
                        }

                        if (RS_CODE == "E")
                        {
                            dbhelper.Rollback();
                            throw new Exception(RS_MSG);
                        }
                    }
                }

                dbhelper.Commit();

                search();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void btnDEL2_Click(object sender, EventArgs e)
        {
            DBHelper dbhelper = new DBHelper("", true);
            try
            {
                DataTable dtDD = new DataTable();

                for (int i = 0; i < grid2.Items.Count; i++)
                {
                    if (grid2.Items[i].Checked == true)
                    {
                        gBarCode = grid2.Items[i].SubItems[1].Text;

                        dbhelper.ExecuteNoneQuery("CALL_BASKET", CommandType.StoredProcedure,
                         dbhelper.CreateParameter("AS_BARCODE", gBarCode, DbType.String, ParameterDirection.Input),
                         dbhelper.CreateParameter("AS_USERID", LoginInfo.UserID, DbType.String, ParameterDirection.Input),
                         dbhelper.CreateParameter("AS_TYPE", "DD", DbType.String, ParameterDirection.Input));

                        RS_CODE = Convert.ToString(dbhelper.RSCODE);
                        RS_MSG = Convert.ToString(dbhelper.RSMSG);

                        if (RS_CODE == "E")
                        {
                            throw new Exception(RS_MSG);
                        }
                    }
                }

                dbhelper.Commit();
                details_search();
            }
            catch (Exception ex)
            {
                dbhelper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    #endregion
}


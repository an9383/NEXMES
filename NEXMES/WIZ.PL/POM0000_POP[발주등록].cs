#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0682
//   Form Name    : ���� ��Ȳ
//   Name Space   : WIZ.BM
//   Created Date : 2019-11-11
//   Made By      : ��������� �ֹ���
//   Description  : ���� ��Ȳ ������ ����
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.PL
{
    public partial class POM0000_POP : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable rtnDtTemp1 = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();
        DataTable rtnDtTemp3 = new DataTable();
        DataSet DSGrid1 = new DataSet();

        BizTextBoxManager btbManager = new BizTextBoxManager();

        #endregion

        #region < CONSTRUCTOR >
        public POM0000_POP()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void POM0000_POP_Load(object sender, EventArgs e)
        {
            cbo_VIEWOPTION.Items.Add("��ü");
            cbo_VIEWOPTION.Items.Add("�ʿ�");

            cbo_VIEWOPTION.Text = "��ü";

            cbo_DATE.Text = DateTime.Today.ToString("yyyy-MM-dd");

            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "POM_DATE", "��������", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "POM_CUSTNAME", "��ü��", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "POM_ITEMNAME", "ǰ���", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "COUNT", "����", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "COST", "�ݾ�", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid3, "GUBUN", "����", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "ǰ���", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "COMPONENTCODE", "ǰ���ڵ�", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid3, "COMPONENTNAME", "�����", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "UNIT", "����", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.InitColumnUltraGrid(grid3, "M", "���� ������", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "N", "���� ������", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "E", "��Ÿ ������", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.InitColumnUltraGrid(grid3, "PL_COUNT", "��ȹ��", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "PL_LACK", "��ȹ��������", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "OD_ORDERQTY", "���ַ�", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "OD_LACK", "���ִ�������", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.InitColumnUltraGrid(grid3, "POM_avg", "����ջ�뷮", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "POM_lackavg", "��մ�� ������", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "POM_etc", "���", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid3);

            btbManager.PopUpAdd(txtMOLDMAKECOMPANY, txtMCNAME, "BM0030", new object[] { 10, "", "", "" });

            #endregion

            #region < GRID LOAD >

            #endregion

            #endregion

            #region < TOOL BAR AREA >

            #endregion

            #region < EVENT AREA >

            #endregion

            #region < METHOD AREA >

            #endregion
        }

        private void grid3_ClickCell(object sender, ClickCellEventArgs e)
        {
            _GridUtil.Grid_Clear(grid2);
            DBHelper helper = new DBHelper(false);

            try
            {
                if (Convert.ToString(grid3.ActiveRow.Cells["COMPONENTNAME"].Value) != "�հ�" && Convert.ToString(grid3.ActiveRow.Cells["COMPONENTNAME"].Value) != "")
                {
                    txtITEMNAME.Text = Convert.ToString(grid3.ActiveRow.Cells["COMPONENTNAME"].Value);
                    txtUNIT.Text = Convert.ToString(grid3.ActiveRow.Cells["UNIT"].Value);
                }
                else
                {
                    txtITEMNAME.Text = "";
                    txtUNIT.Text = "";
                }

                DSGrid1 = helper.FillDataSet("USP_POM0000_POP_S2", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_ITEMCODE", grid3.ActiveRow.Cells["COMPONENTCODE"].Value, DbType.String, ParameterDirection.Input));

                if (DSGrid1.Tables[0].Rows.Count > 0)
                {
                    grid2.DataSource = DSGrid1.Tables[0];
                    grid2.DataBind();
                }
                else
                {

                }
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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (txtITEMNAME.Text == "")
                {
                    this.ShowDialog("ǰ���� �������ּ���.", Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    helper.ExecuteNoneQuery("USP_MM0000_I1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PODATE", DateTime.Today.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PLANINDATE", cbo_DATE.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CUSTCODE", txtMOLDMAKECOMPANY.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CUSTCODE2", "", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", grid3.ActiveRow.Cells["COMPONENTCODE"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AF_POQTY", txtCNT.Text, DbType.Double, ParameterDirection.Input)
                        , helper.CreateParameter("AS_COST", txtCOST.Text, DbType.Double, ParameterDirection.Input)
                        , helper.CreateParameter("AS_USEFLAG", "Y", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                    helper.ExecuteNoneQuery("USP_POM0000_POP_SAVE", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_TIME", DateTime.Now, DbType.String, ParameterDirection.Input)

                        , helper.CreateParameter("AS_POM_DATE", DateTime.Today.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_POM_PLANDATE", cbo_DATE.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_POM_VEND", txtMOLDMAKECOMPANY.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_POM_ITEM", grid3.ActiveRow.Cells["COMPONENTCODE"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_POM_UNIT", txtUNIT.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_POM_CNT", txtCNT.Text, DbType.Double, ParameterDirection.Input)
                        , helper.CreateParameter("AS_POM_COST", txtCOST.Text, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                    helper.Commit();
                    this.ShowDialog("���������� ����Ǿ����ϴ�.", Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                ClosePrgFormNew();
            }

        }

        private void btn_INQ_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            _GridUtil.Grid_Clear(grid3);
            try
            {
                rtnDtTemp1 = helper.FillTable("USP_POM0000_SUB_S1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_OPTION", cbo_VIEWOPTION.Text, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp1.Rows.Count > 0)
                {
                    grid3.Visible = false;
                    for (int i = 0; i < rtnDtTemp1.Rows.Count; i++)
                    {
                        rtnDtTemp2 = helper.FillTable("USP_POM0000_POP_S1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_ITEMCODE", rtnDtTemp1.Rows[i]["ITEMCODE"], DbType.String, ParameterDirection.Input));

                        if (rtnDtTemp2.Rows.Count > 0)
                        {
                            rtnDtTemp3.Merge(rtnDtTemp2);
                            /*
                            if (Convert.ToString(rtnDtTemp2.Rows[j]["COMPONENTNAME"]) == "")
                            {

                            }
                            else if (Convert.ToString(rtnDtTemp2.Rows[j]["M"]) != "" || Convert.ToString(rtnDtTemp2.Rows[j]["N"]) != "" || Convert.ToString(rtnDtTemp2.Rows[j]["E"]) != "")
                            {
                                int iROW = grid3.InsertRow();
                                grid3.Rows[iROW].Cells["ITEMNAME"].Value = rtnDtTemp2.Rows[j]["ITEMNAME"];
                                grid3.Rows[iROW].Cells["COMPONENTCODE"].Value = rtnDtTemp2.Rows[j]["COMPONENTCODE"];
                                grid3.Rows[iROW].Cells["COMPONENTNAME"].Value = rtnDtTemp2.Rows[j]["COMPONENTNAME"];
                                grid3.Rows[iROW].Cells["M"].Value = rtnDtTemp2.Rows[j]["M"];
                                grid3.Rows[iROW].Cells["N"].Value = rtnDtTemp2.Rows[j]["N"];
                                grid3.Rows[iROW].Cells["E"].Value = rtnDtTemp2.Rows[j]["E"];
                                grid3.Rows[iROW].Cells["OD_ORDERQTY"].Value = rtnDtTemp2.Rows[j]["OD_ORDERQTY"];
                                grid3.Rows[iROW].Cells["PL_COUNT"].Value = rtnDtTemp2.Rows[j]["PL_COUNT"];
                            }*/
                            grid3.DataSource = rtnDtTemp3;
                            grid3.DataBind();
                        }
                    }
                }
                grid3.Visible = true;
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
    }
}
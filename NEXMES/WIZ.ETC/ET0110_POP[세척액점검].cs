#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.ETC
{
    public partial class ET0110_POP : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        //DBHelper helper = new DBHelper("", true);

        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable rtnDtTemp = new DataTable();
        DataSet DSGrid1 = new DataSet();
        Common _Common = new Common();

        public Control.Grid trGrid;

        #endregion

        #region < CONSTRUCTOR >
        public ET0110_POP()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void ET0110_POP_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "CLEANDATE", "��������", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHINE", "��ôȣ��", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK1", "�������ر�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK2", "������", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK3", "�������µ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK4", "���ؼ���", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK5", "����1�ܰ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK6", "����2�ܰ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "�����", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "�����Ͻ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            dtp_STARTDATE.Value = DateTime.Today;

            rtnDtTemp = _Common.GET_BM0000_CODE("CLEANMACHINE"); // ��ô������
            WIZ.Common.FillComboboxMaster(this.cbo_MACHINE, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");

            txtCHK1.Items.Add("Ȯ��");
            txtCHK1.Items.Add("��Ȯ��");
            txtCHK1.Text = "Ȯ��";

            txtCHK4.Items.Add("1�ܰ�");
            txtCHK4.Items.Add("2�ܰ�");
            txtCHK4.Items.Add("3�ܰ�");
            txtCHK4.Text = "1�ܰ�";

            #endregion
        }

        #endregion

        #region < TOOL BAR AREA >

        #endregion

        #region < EVENT AREA >

        #endregion

        #region < METHOD AREA >

        #endregion

        private void btn_SAVE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (this.ShowDialog("���˳����� Ȯ���ϼ̽��ϱ�?", Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
                {
                    helper.ExecuteNoneQuery("USP_MD0150_POP_I", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                        , helper.CreateParameter("AS_CLEANDATE", dtp_STARTDATE.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MACHINE", cbo_MACHINE.Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CHK1", txtCHK1.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CHK2", txtCHK2.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CHK3", txtCHK3.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CHK4", txtCHK4.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CHK5", txtCHK5.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CHK6", txtCHK6.Text, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                    helper.Commit();
                    this.ShowDialog("��ô�������� �Ϸ�Ǿ����ϴ�.", Forms.DialogForm.DialogType.OK);
                    #region < INQUIRE >

                    _GridUtil.Grid_Clear(grid1);
                    cbo_BEFORE.Items.Clear();

                    DSGrid1 = helper.FillDataSet("USP_MD0150_POP_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MACHINE", cbo_MACHINE.Value, DbType.String, ParameterDirection.Input));

                    if (DSGrid1.Tables[0].Rows.Count > 0)
                    {
                        grid1.DataSource = DSGrid1.Tables[0];
                        grid1.DataBind();
                    }
                    else
                    {
                        ShowDialog(Common.getLangText("��ȸ�� �����Ͱ� �����ϴ�.", "MSG"), Forms.DialogForm.DialogType.OK);
                        _GridUtil.Grid_Clear(grid1);
                        return;
                    }

                    for (int i = 0; i < DSGrid1.Tables[1].Rows.Count; i++)
                    {
                        cbo_BEFORE.Items.Add(DSGrid1.Tables[1].Rows[i]["CLEANDATE"]);
                    }

                    #endregion
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

        private void cbo_MACHINE_ValueChanged(object sender, EventArgs e)
        {
            #region < GRID LOAD >

            DBHelper helper = new DBHelper(false);

            _GridUtil.Grid_Clear(grid1);
            cbo_BEFORE.Items.Clear();

            try
            {
                DSGrid1 = helper.FillDataSet("USP_MD0150_POP_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_MACHINE", cbo_MACHINE.Value, DbType.String, ParameterDirection.Input));

                if (DSGrid1.Tables[0].Rows.Count > 0)
                {
                    grid1.DataSource = DSGrid1.Tables[0];
                    grid1.DataBind();
                }
                else
                {
                    ShowDialog(Common.getLangText("��ȸ�� �����Ͱ� �����ϴ�.", "MSG"), Forms.DialogForm.DialogType.OK);
                    _GridUtil.Grid_Clear(grid1);
                    return;
                }

                for (int i = 0; i < DSGrid1.Tables[1].Rows.Count; i++)
                {
                    cbo_BEFORE.Items.Add(DSGrid1.Tables[1].Rows[i]["CLEANDATE"]);
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
            #endregion
        }

        private void btnLIQSAVE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (this.ShowDialog("��ô���� ��ü�ϼ̽��ϱ�?", Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
                {
                    helper.ExecuteNoneQuery("USP_MD0151_POP_I", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                        , helper.CreateParameter("AS_CLEANDATE", dtp_STARTDATE.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MACHINE", cbo_MACHINE.Value, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                    helper.Commit();
                    this.ShowDialog("��ô�ױ�ü�� �Ϸ�Ǿ����ϴ�.", Forms.DialogForm.DialogType.OK);
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
    }
}
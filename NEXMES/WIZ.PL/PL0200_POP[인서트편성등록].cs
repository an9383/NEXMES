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
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PL
{
    public partial class PL0200_POP : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        //DBHelper helper = new DBHelper("", true);

        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //�޺��ڽ� ��ü ����

        DataTable rtnDtTemp = new DataTable();
        DataSet DSGrid1 = new DataSet();

        public Control.Grid trGrid;

        #endregion

        #region < CONSTRUCTOR >
        public PL0200_POP()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PL0200_POP_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "�����", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "�����ڵ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "������", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "ó���ڵ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "ó����", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "�����ڵ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "�����", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "��뿩��", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "����Ͻ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "�����", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "�����Ͻ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "������", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "�����", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKERID", "�۾���ID", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKERNAME", "�۾��ڸ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "DEPTCODE", "�μ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "VIEWNAME", "�̴ϼ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "PASSWORD", "��й�ȣ", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "GRPID", "���ѱ׷�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "OPCODE", "�����ڵ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "�۾����ڵ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "TEAMCODE", "���ڵ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "BANCODE", "�۾���", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "CLASSCODE", "�׷��ڵ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "DAYNIGHT", "�־߱���", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "SHIFTGB", "���ڵ�", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "EMPNO", "���", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "EMPTELNO", "����ó", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "INDATE", "�Ի���", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "OUTDATE", "�����", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "LANG", "���", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "MAILID", "����", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "PHONENO", "PHONE ��ȣ", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "SYSFLAG", "�ý��ۿ���", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "MACHFLAG", "�������۾���", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "��뿩��", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "���", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "�����", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "����Ͻ�", true, GridColDataType_emu.DateTime, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "������", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "�����Ͻ�", true, GridColDataType_emu.DateTime, 100, 100, Infragistics.Win.HAlign.Center, true, true);

            _GridUtil.SetInitUltraGridBind(grid2);


            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "�����", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);

            _GridUtil.SetInitUltraGridBind(grid3);

            //1

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //�����
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("GRPID"); //���ѱ׷�
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "GRPID", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT"); //�־߱���
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DAYNIGHT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DEPTCODE"); //�μ��ڵ�
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cbo_DEPTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("BANCODE"); //���ڵ�
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "BANCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //��뿩��
            WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //2021-03-03 �������۾��� Y �̸� ����ؼ�MES, DAS ������� ��� (�������۾��ڰ� ��ȸ ����)
            // USP_DX1010_S1 �������۾��� ��ȸ - ����
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MACHFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //2

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //�����
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("GRPID"); //���ѱ׷�
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "GRPID", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT"); //�־߱���
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "DAYNIGHT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DEPTCODE"); //�μ��ڵ�
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "DEPTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cbo_DEPTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("BANCODE"); //���ڵ�
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "BANCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //��뿩��
            WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //2021-03-03 �������۾��� Y �̸� ����ؼ�MES, DAS ������� ��� (�������۾��ڰ� ��ȸ ����)
            // USP_DX1010_S1 �������۾��� ��ȸ - ����
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "MACHFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region POPUP SETTING

            //�۾���
            btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", "" });

            #endregion

            #region < GRID LOAD >

            _GridUtil.Grid_Clear(grid2); // ��ȸ�� �׸��� �ʱ�ȭ

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sWorkerId = DBHelper.nvlString(txt_WORKERID_H.Text.Trim());
                string sDeptCode = DBHelper.nvlString(cbo_DEPTCODE_H.Value);
                string sWorkerName = DBHelper.nvlString(txt_WORKERNAME_H.Text.Trim());
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                rtnDtTemp = helper.FillTable("USP_PL0200_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKERID", sWorkerId, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_DEPTCODE", sDeptCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKERNAME", sWorkerName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds(rtnDtTemp);
                }

                rtnDtTemp = helper.FillTable("USP_PL0200_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }

            #endregion
        }

        #endregion

        #region < TOOL BAR AREA >

        #endregion

        #region < EVENT AREA >

        #endregion

        #region < METHOD AREA >



        #endregion

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {

        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {

        }

        private void grid4_ClickCell(object sender, ClickCellEventArgs e)
        {

        }

        private void dtp_STARTDATE_ValueChanged(object sender, EventArgs e)
        {

        }

        private void grid3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                }
                else
                {

                }
            }
            catch
            {

            }
        }

        /*private void CALDAYWEEK() // �ְ� �����°���
        {
            DateTime dtDay = dtp_STARTDATE.Value;
            System.Globalization.CultureInfo ciCurrent = System.Threading.Thread.CurrentThread.CurrentCulture;
            DayOfWeek dwFirst = ciCurrent.DateTimeFormat.FirstDayOfWeek;
            DayOfWeek dwCal   = ciCurrent.Calendar.GetDayOfWeek(dtDay);

            int iDiff = dwCal - dwFirst;
            dtFirstDay  = dtDay.AddDays(-iDiff + 1);
            dtSecondDay = dtFirstDay.AddDays(6);
        }*/

        private void grid5_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void btn_INSERTROW_Click(object sender, EventArgs e)
        {

        }

        private void chk_DAY_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                PL0100_POP2 mbp = new PL0100_POP2();
                if (DialogResult.OK == mbp.ShowDialog())
                {
                    DSGrid1 = helper.FillDataSet("USP_PL0100_S1", CommandType.StoredProcedure);

                    if (DSGrid1.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        ShowDialog(Common.getLangText("��ȸ�� �����Ͱ� �����ϴ�.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
            }
            catch
            {

            }
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
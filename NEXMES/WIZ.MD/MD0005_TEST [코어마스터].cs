#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD0005
//   Form Name    : �ھ����
//   Name Space   : WIZ.MD
//   Created Date : 2020-10-13
//   Made By      : �ֹ���
//   Description  : �ھ����
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using WIZ.PopUp;

using Infragistics.Win.UltraWinGrid;
using System.Text;
#endregion

namespace WIZ.MD
{
    public partial class MD0005_TEST : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGrid1Manager;
        BizGridManager bizGrid2Manager;

        Common _Common = new Common();

        DataSet DSGrid1 = new DataSet();
        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();
        DataTable dtGrid2 = new DataTable();
        DataTable dtGrid3 = new DataTable();

        string CORECODE = "";
        /// <summary>
        /// N : DoNew / S : Normal
        /// </summary>
        string ModeStatus = "";

        #endregion

        #region < CONSTRUCTOR >
        public MD0005_TEST()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MD0005_TEST_Load(object sender, EventArgs e)
        {
            GridInitialize();
        }

        private void GridInitialize()
        {
            try
            {
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_Code",       "�ھ� no.",       true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_Vend",       "��ü��",         true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_CoreName",   "�ھ��",         true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_PartName",   "ǰ���",         true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_ChaSu",      "����",           true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.InitColumnUltraGrid(grid1, "Core_Area",       "������ NO.",     true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_LinkCode",   "�����ڵ�",       true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_DRevNo",     "����Rev No.",    true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_CRevNo",     "�ھ�Rev No.",    true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_SafetyQTY",  "�������",       true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_ETC1",       "�޸�",           true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                #region --- Combobox & Popup Setting ---
                                
                #endregion
            }

            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }

       
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            bNew = false;
            ClosePrgFormNew();
            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid1);

                DSGrid1 = helper.FillDataSet("USP_MD0005_UJ_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("Core_Code", "", DbType.String, ParameterDirection.Input));

                if (DSGrid1.Tables[0].Rows.Count > 0)
                {
                    grid1.DataSource = DSGrid1.Tables[0];
                    grid1.DataBinds();
                }
             
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();

                helper.Close();
            }
        }

        public override void DoNew()
        {
            ModeStatus = "N";

            try
            {
                base.DoNew();

                if (bNew)
                {
                    this.ShowDialog(Common.getLangText("�Է� ���� �ھ������� �ֽ��ϴ�.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);

                CLEAN();

                txtCORECODE.Text = "[ NEW CORECODE ]";

                grid1.UpdateData();

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {

            }
        }

        public override void DoDelete()
        {

        }

        public override void DoSave()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                //����, ����
                rtnDtTemp = helper.FillTable("USP_MD0005_UJ_SAVE", CommandType.StoredProcedure

                    , helper.CreateParameter("AS_Core_Code",        txtCORECODE.Text,       DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_Vend",        txtCOMPANYNAME.Text,    DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_CoreName",    txtCORENAME.Text,       DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_PartName",    txtITEMNAME.Text,       DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_ChaSu",       txtDEGREE.Text,         DbType.String, ParameterDirection.Input)

                    , helper.CreateParameter("AS_Core_Area",        txtLOCKERNUM.Text,      DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_LinkCode",    txtLINKAGECODE.Text,    DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_DRevNo",      txtDRAWINGNUM.Text,     DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_CRevNo",      txtCORENUM.Text,        DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_SafetyQTY",   txtSAFETYSTOCK.Text,    DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("@AS_Core_ETC1",       txtMEMO.Text,           DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "E")
                {
                    throw new Exception(helper.RSMSG);
                }

                helper.Commit();

                ModeStatus = "S";
                DoInquire();
                CLEAN();
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

        #endregion



        #region < EVENT AREA >

        #endregion



        #region < METHOD AREA >

        #endregion

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (ModeStatus == "N")
            {
                if (this.ShowDialog("�߰��� ����Ͻðڽ��ϱ�?", WIZ.Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
                {
                    ModeStatus = "S";
                    DoInquire();
                }

                if (grid1.ActiveCell == null)
                {
                    return;
                }

                try
                {
                    DBHelper helper;
                    helper = new DBHelper(false);

                    string sCoreCode = CModule.ToString(grid1.ActiveRow.Cells["Core_Code"].Value);
                    DSGrid1 = helper.FillDataSet("USP_MD0005_UJ_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("Core_Code", sCoreCode, DbType.String, ParameterDirection.Input));

                    SetMoldInfo(DSGrid1.Tables[0]);
                }
                catch (Exception ex)
                {
                    this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
                }
            }

            else
            {
                if (grid1.ActiveCell == null)
                {
                    this.ShowDialog("�� ������ ��Ȯ�ϰ� �ϼ���.", WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
                try
                {
                    DBHelper helper;
                    helper = new DBHelper(false);

                    string sCoreCode = CModule.ToString(grid1.ActiveRow.Cells["Core_Code"].Value);
                    DSGrid1 = helper.FillDataSet("USP_MD0005_UJ_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("Core_Code", sCoreCode, DbType.String, ParameterDirection.Input));


                    SetMoldInfo(DSGrid1.Tables[0]);
                }
                catch (Exception ex)
                {
                    this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
                }
            
            }
        }

        public void SetMoldInfo(DataTable DTinfo)
        {
            if (DTinfo.Rows.Count > 0)
            {
                txtCORECODE.Text = CModule.ToString(DTinfo.Rows[0]["Core_Code"]);
                txtCOMPANYNAME.Text = CModule.ToString(DTinfo.Rows[0]["Core_Vend"]);
                txtCORENAME.Text = CModule.ToString(DTinfo.Rows[0]["Core_CoreName"]);
                txtITEMNAME.Text = CModule.ToString(DTinfo.Rows[0]["Core_PartName"]);
                txtDEGREE.Text = CModule.ToString(DTinfo.Rows[0]["Core_ChaSu"]);
                txtLOCKERNUM.Text = CModule.ToString(DTinfo.Rows[0]["Core_Area"]);

                txtLINKAGECODE.Text = CModule.ToString(DTinfo.Rows[0]["Core_LinkCode"]);
                txtDRAWINGNUM.Text = CModule.ToString(DTinfo.Rows[0]["Core_DRevNo"]);
                txtCORENUM.Text = CModule.ToString(DTinfo.Rows[0]["Core_CRevNo"]);
                txtSAFETYSTOCK.Text = CModule.ToString(DTinfo.Rows[0]["Core_SafetyQTY"]);
                txtMEMO.Text = CModule.ToString(DTinfo.Rows[0]["Core_ETC1"]);
                
                //��밡�� ���� ����Ʈ
            }
            else
            {
                CLEAN();
            }

        }

        private void CLEAN()
        {
            txtCORECODE.Text = "";
            txtCOMPANYNAME.Text = "";
            txtCORENAME.Text = "";
            txtITEMNAME.Text = "";
            txtLOCKERNUM.Text = "";
            txtLINKAGECODE.Text = "";

            txtDEGREE.Text = "";
            txtDRAWINGNUM.Text = "";
            txtCORENUM.Text = "";
            txtSAFETYSTOCK.Text = "";
            txtMEMO.Text = "";
        }

        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void sLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}

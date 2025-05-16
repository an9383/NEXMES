#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0682
//   Form Name    : 수주 현황
//   Name Space   : WIZ.BM
//   Created Date : 2019-11-11
//   Made By      : 기술연구소 최문준
//   Description  : 수주 현황 정보를 관리
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
using System.Net;
#endregion

namespace WIZ.MD
{
    public partial class MD0070_POP2 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        //DBHelper helper = new DBHelper("", true);

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGrid1Manager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable dt = new DataTable();
        DataSet DSGrid1 = new DataSet();

        DataTable dtBARCORE = new DataTable();

        string btnTag = "";
        string MOLDCODE = "";
        string sSTATE = "";

        int cnt;

        #endregion

        #region < CONSTRUCTOR >
        public MD0070_POP2()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MD0100_UJ_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtBARCODE;
            txtBARCODE.Focus();
        }

        #endregion

        #region < TOOL BAR AREA >

        public override void DoSave()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                //저장, 수정
                helper.ExecuteNoneQuery("USP_MD0100_UJ_I1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_REPAIRCODE", txtREPAIRCODE.Text.Trim(), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CLEANTYPE",  sSTATE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CHANGETYPE", "", DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "E")
                {
                    throw new Exception(helper.RSMSG);
                }
                helper.Commit();

                //clear() 생성대기
                txtREPAIRCODE.Text = "";
                txtBARCODE.Text = "";
                ultraGroupBox2.Text = "";
                txtDEGREE.Text = "";
                MOLDCODE = "";

                DoInquire();
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
        public void SetMoldInfo(DataTable DTinfo)
        {
            if (DTinfo.Rows.Count > 0)
            {
                txtMOLDPRODLIST.Text = CModule.ToString(DTinfo.Rows[0]["MOLDPROD"]);
                txtDEGREE.Text       = CModule.ToString(DTinfo.Rows[0]["DEGREE"]);
                txtMOLDNAME.Text     = CModule.ToString(DTinfo.Rows[0]["MOLDNAME"]);

                checkBox3.Checked = true;

                for (int i = 0; i < Convert.ToInt32(CModule.ToString(DTinfo.Rows[0]["CAVITYNUM"])); i++)
                {
                    cbo_CVTLIST.Items.Add("CVTNo." + (i + 1));
                }
            }
            else
            {

            }
        }
        #endregion

        #region < METHOD AREA >

        #endregion

        private void txtBARCODE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region GRID SETTING 

                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                DBHelper helper = new DBHelper(false);
                DSGrid1 = helper.FillDataSet("USP_MD0002_UJ_SEL", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_MOLDCODE", txtBARCODE.Text, DbType.String, ParameterDirection.Input));

                if (DSGrid1.Tables.Count >= 2)
                {
                    _GridUtil.InitColumnUltraGrid(grid1, "SUMCOUNT", "합계", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
                    for (int i = 0; i < Convert.ToInt32(CModule.ToString(DSGrid1.Tables[1].Rows[0]["CAVITYNUM"])); i++)
                    {
                        _GridUtil.InitColumnUltraGrid(grid1, "CAVITYNo." + (i + 1), "CVT_" + (i + 1), true, GridColDataType_emu.VarChar, 70, 120, Infragistics.Win.HAlign.Left, true, true);
                    }

                    #endregion

                    SetMoldInfo(DSGrid1.Tables[1]);

                    grid1.DataSource = DSGrid1.Tables[2];
                    grid1.DataBinds();
                }
            }
        }

        private void ultraGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_CLOSE_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(cbo_CVTLIST.Text + " 봉쇄");
        }

        private void btn_OPEN_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(cbo_CVTLIST.Text + " 봉쇄");
        }

        private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key.Contains("CAVITYNO"))
            {
                grid1.ActiveRow.Cells["SUMCOUNT"].Value = DBHelper.nvlDouble(grid1.ActiveRow.Cells["SUMCOUNT"].Value) + CModule.ToDouble(e.Cell.Value);
            }
        }
    }
}

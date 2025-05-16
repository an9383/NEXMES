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
    public partial class MD0100_UJ : WIZ.Forms.BaseMDIChildForm
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

        string btnTag = "";
        string MOLDCODE = "";
        string sSTATE = "";

        #endregion

        #region < CONSTRUCTOR >
        public MD0100_UJ()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MD0100_UJ_Load(object sender, EventArgs e)
        {
            GridInitialize();

            btn_CORE_CHANGE.Tag = "CHANGE";
            btn_CORE_REPAIR.Tag = "REPAIR";
            btn_CORE_CTYPE.Tag = "CTYPE";
            btn_4M.Tag = "4M";

            this.ActiveControl = txtBARCODE;
            txtBARCODE.Focus();
        }

        private void GridInitialize()
        {
            try
            {

                #region --- Combobox & Popup Setting ---
                //DateTime.Now;

                txtBARCODE.Focus();

                #endregion
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
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
                    , helper.CreateParameter("AS_REPAIRTEXT", txtREPAIRTEXT.Text.Trim(), DbType.String, ParameterDirection.Input)
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
      
        #endregion



        #region < METHOD AREA >

        #endregion


        private void txtBARCODE_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public void Btn_Click(object sender, EventArgs e)
        {

        }

        public void Chk_Change(object sender, EventArgs e)
        {

        }


    }
}

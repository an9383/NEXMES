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

using WIZ.PopUp;
#endregion

namespace WIZ.MD
{
    public partial class MD0070_POP3 : WIZ.Forms.BaseMDIChildForm
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

        string MOLDCODE = "";
        string sSTATE = "";

        #endregion

        #region < CONSTRUCTOR >
        public MD0070_POP3(String sMOLDCODE)
        {
            InitializeComponent();
            MOLDCODE = sMOLDCODE;
        }
        #endregion

        #region < FORM LOAD >
        private void MD0070_POP3_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            txtBARCODE.Text = MOLDCODE;
            DBHelper helper = new DBHelper(false);
            DSGrid1 = helper.FillDataSet("USP_MD0001_S1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_MOLDCODE", MOLDCODE, DbType.String, ParameterDirection.Input));

            SetMoldInfo(DSGrid1.Tables[1]);
        }

        #endregion

        #region < TOOL BAR AREA >

        #endregion

        #region < EVENT AREA >
        public void SetMoldInfo(DataTable DTinfo)
        {
            if (DTinfo.Rows.Count > 0)
            {
                txtMOLDNAME.Text = CModule.ToString(DTinfo.Rows[0]["MOLDNAME"]);
                txtDEGREE.Text = CModule.ToString(DTinfo.Rows[0]["DEGREE"]);
                txtMOLDPRODLIST.Text = CModule.ToString(DTinfo.Rows[0]["MOLDPROD"]);
                txtUSESHOT.Text = CModule.ToString(DTinfo.Rows[0]["USESHOT"]);
                txtTOTALSHOT.Text = CModule.ToString(DTinfo.Rows[0]["TOALSHOT"]);
                txtMDCVT.Text = CModule.ToString(DTinfo.Rows[0]["CAVITYNUM"]);
                txtNWCVT.Text = CModule.ToString(DSGrid1.Tables[4].Rows[0]["CNT"]);
            }
            else
            {

            }
        }


        #endregion

        #region < METHOD AREA >

        #endregion

        private void btn_SAVE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);
            string USMS = "";

            if (rdb_US.Checked == true)
            {
                USMS = "Y";
            }
            else if (rdb_MS.Checked == true)
            {
                USMS = "N";
            }

            try
            {
                helper.ExecuteNoneQuery("USP_MD0070_POP3_I", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                    , helper.CreateParameter("AS_RP_WORKGB", '2', DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_RP_MOLDCODE", MOLDCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_RP_USMS", USMS, DbType.String, ParameterDirection.Input));

                helper.Commit();
                this.Close();
            }
            catch (SException ex)
            {
                CancelProcess = true;
                helper.Rollback();
                throw ex;
            }
            finally
            {

            }

        }
    }
}

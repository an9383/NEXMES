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
    public partial class MD0070_POP1 : WIZ.Forms.BaseMDIChildForm
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

        #endregion

        #region < CONSTRUCTOR >
        public MD0070_POP1(string sMOLDCODE)
        {
            InitializeComponent();
            txtBARCODE.Text = sMOLDCODE;
        }
        #endregion

        #region < FORM LOAD >
        private void MD0070_POP1_Load(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            DSGrid1 = helper.FillDataSet("USP_MD0001_S1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_MOLDCODE", txtBARCODE.Text, DbType.String, ParameterDirection.Input));

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
                txtMOLDMNO.Text = CModule.ToString(DTinfo.Rows[0]["MOLDMNO"]);
                txtDEGREE.Text = CModule.ToString(DTinfo.Rows[0]["DEGREE"]);
                txtMOLDPRODLIST.Text = CModule.ToString(DTinfo.Rows[0]["MOLDPROD"]);

                txtINSPCYCLE.Text = CModule.ToString(DTinfo.Rows[0]["INSPCYCLE"]);
                txtUSESHOT.Text = CModule.ToString(DTinfo.Rows[0]["USESHOT"]);
                txtTOTALSHOT.Text = CModule.ToString(DTinfo.Rows[0]["TOALSHOT"]);
            }
            else
            {

            }
        }
        #endregion

        #region < METHOD AREA >

        #endregion
    }
}

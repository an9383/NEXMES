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
using System.Windows.Forms;

using WIZ.PopUp;
#endregion

namespace WIZ.MD
{
    public partial class MD0060_POP1 : WIZ.Forms.BaseMDIChildForm
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

        #endregion

        #region < CONSTRUCTOR >
        public MD0060_POP1()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MD0060_POP1_Load(object sender, EventArgs e)
        {
            txtBARCODE.Focus();

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTYPE1"); //신작 증작 이관
            WIZ.Common.FillComboboxMaster(this.cbo_type, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
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
                txtMOLDPROD.Text = CModule.ToString(DTinfo.Rows[0]["MOLDPROD"]);
                txtINITIALSHOT.Text = CModule.ToString(DTinfo.Rows[0]["INITIALSHOT"]);
                txtMCNAME.Text = CModule.ToString(DTinfo.Rows[0]["MCNAME"]);
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
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DBHelper helper = new DBHelper(false);
                    DSGrid1 = helper.FillDataSet("USP_MD0060_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_QRCODE", txtBARCODE.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("Start_Date", "", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("End_Date", "", DbType.String, ParameterDirection.Input));

                    SetMoldInfo(DSGrid1.Tables[1]);
                }
            }
            catch
            {

            }
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_MD0060_POP1_I", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_TODAY", DateTime.Today.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Schedule", dateTimePicker1.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_VEND", txtMCNAME.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MOLDNAME", txtMOLDNAME.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MOLDCODE", txtBARCODE.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CHASU", txtDEGREE.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_GUBUN", cbo_type.Value, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_INSHOT", txtINITIALSHOT.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ETC1", txtETC.Text, DbType.String, ParameterDirection.Input));

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

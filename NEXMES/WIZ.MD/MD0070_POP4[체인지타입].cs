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
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.MD
{
    public partial class MD0070_POP4 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        //DBHelper helper = new DBHelper("", true);

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGrid1Manager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataSet ds = new DataSet();
        DataSet DSGrid1 = new DataSet();
        DataTable dtBARCORE = new DataTable();

        string ITEMNAME = "";

        #endregion

        #region < CONSTRUCTOR >
        public MD0070_POP4(string sMOLDCODE)
        {
            InitializeComponent();
            txtBARCODE.Text = sMOLDCODE;
        }
        #endregion

        #region < FORM LOAD >
        private void MD0070_POP4_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "금형코드", false, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            DBHelper helper = new DBHelper(false);

            try
            {
                ds = helper.FillDataSet("USP_MD0070_POP4_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_MOLDCODE", txtBARCODE.Text, DbType.String, ParameterDirection.Input));

                grid1.DataSource = ds.Tables[0];
                grid1.DataBind();

                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    listBox1.Items.Add(ds.Tables[2].Rows[i]["CAVITYNAME"] + " 봉쇄");
                }

                SetMoldInfo(ds.Tables[1]);

            }
            catch (Exception ex)
            {
            }
            finally
            {
                helper.Close();
            }

            //SetMoldInfo(DSGrid1.Tables[1]);
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
                txtORGMOLDPRODCODE.Text = CModule.ToString(DTinfo.Rows[0]["MOLDPROD"]);
                txtORGMOLDPRODNAME.Text = CModule.ToString(DTinfo.Rows[0]["ITEMNAME"]);
                txtUSERID.Text = LoginInfo.UserID;

            }
            else
            {

            }
        }
        #endregion

        #region < METHOD AREA >

        #endregion

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            txtCHNMOLDPRODCODE.Text = CModule.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            txtCHNMOLDPRODNAME.Text = CModule.ToString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("USP_MD0070_POP4_SAVE", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                    , helper.CreateParameter("AS_CHANGE_DATE", DateTime.Today.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CHANGE_MOLDCODE", txtBARCODE.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CHANGE_ORGITEM", txtORGMOLDPRODCODE.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CHANGE_CHNITEM", txtCHNMOLDPRODCODE.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CHANGE_ETC", txtETC.Text, DbType.String, ParameterDirection.Input));

                helper.Commit();
                this.Close();
            }
            catch (Exception ex)
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

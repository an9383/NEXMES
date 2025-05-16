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
        DataTable dt = new DataTable();
        DataSet DSGrid1 = new DataSet();
        DataTable dtBARCORE = new DataTable();

        string MOLDCODE = "";
        string sSTATE = "";

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

            _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "금형코드", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목",     false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명",   false, GridColDataType_emu.VarChar, 200, 200, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MD0070_POP4_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_MOLDCODE", txtBARCODE.Text, DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBind();

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
                txtMOLDNAME.Text =  CModule.ToString(DTinfo.Rows[0]["MOLDNAME"]);
                txtMOLDPRODLIST.Text = CModule.ToString(DTinfo.Rows[0]["MOLDPRODLIST"]);
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

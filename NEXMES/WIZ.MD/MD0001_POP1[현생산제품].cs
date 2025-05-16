#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0010
//   Form Name    : 품목마스터 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : 품목과 품목관련 기준정보 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >

using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;

#endregion


namespace WIZ.PopUp
{
    public partial class MD0001_POP1 : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataSet ds = new DataSet(); // return DataTable 공통
        Common _Common = new Common();
        PopUp_Biz _biz = new PopUp_Biz();


        public string MOLDCODE = "";
        public string sMOLDCODE = "";
        public string sITEMCODE = "";
        public string sITEMNAME = "";
        #endregion

        #region < CONSTRUCTOR >

        public MD0001_POP1(string sMOLDCODE)
        {
            InitializeComponent();

            MOLDCODE = sMOLDCODE;

            #region GRID SETTING

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "금형코드", false, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDNAME", "금형명", false, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DEGREE", "차수", false, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            Search();

        }
        #endregion

        #region < METHOD AREA >

        private void Search()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                ds = helper.FillDataSet("USP_MD0001_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", MOLDCODE, DbType.String, ParameterDirection.Input));
                grid1.DataSource = ds.Tables[3];
                grid1.DataBind();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region < EVENT AREA >

        private void grid1_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            try
            {
                sITEMCODE = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                sITEMNAME = Convert.ToString(grid1.ActiveRow.Cells["ITEMNAME"].Value);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SException ex)
            {

            }
            finally
            {

            }
        }
        #endregion
    }
}

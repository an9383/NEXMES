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

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WIZ;
using WIZ.PopUp;

#endregion


namespace WIZ.PL
{
    public partial class PL0110_POP_POP1 : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataSet ds = new DataSet(); // return DataTable 공통
        Common _Common = new Common();
        PopUp_Biz _biz = new PopUp_Biz();

        BizTextBoxManager btbManager = new BizTextBoxManager();

        public string CheckItem = "";
        public string CheckCUST = "";

        #endregion

        #region < CONSTRUCTOR >

        public PL0110_POP_POP1(string sCUSTCODE)
        {
            InitializeComponent();

            CheckCUST = sCUSTCODE;

            InitGrid();
        }
        #endregion

        #region < METHOD AREA >
        private void InitGrid()
        {
            try
            {
                #region GRID SETTING

                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTITEMCODE", "고객사품목코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTITEMNAME", "고객사품목명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "현재재고", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SAFESTOCK", "안전재고기준", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                DBHelper helper = new DBHelper(false);

                try
                {
                    ds = helper.FillDataSet("USP_OD0000_POP_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_CUSTCODE", CheckCUST, DbType.String, ParameterDirection.Input));

                    grid1.DataSource = ds.Tables[0];
                    grid1.DataBind();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    helper.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region < EVENT AREA >

        private void grid1_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                CheckItem = Convert.ToString(grid1.ActiveRow.Cells["CUSTITEMNAME"].Value);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SException ex)
            {
                CancelProcess = true;
                throw ex;
            }
            finally
            {

            }
        }
        #endregion
    }
}

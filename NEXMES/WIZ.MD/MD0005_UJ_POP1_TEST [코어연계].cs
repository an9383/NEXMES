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


namespace WIZ.PopUp
{
    public partial class MD0005_POP1 : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataSet ds = new DataSet(); // return DataTable 공통
        Common _Common = new Common();
        PopUp_Biz _biz = new PopUp_Biz();


        public string CORECODE = "";
        public string sMOLDCODE = "";
        public string sITEMCODE = "";
        public string sITEMNAME = "";
        #endregion

        #region < CONSTRUCTOR >

        public MD0005_POP1(string sCORECODE)
        {
            InitializeComponent();
            CORECODE = sCORECODE;
            #region GRID SETTING

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "금형코드", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDNAME", "금형명", false, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DEGREE", "차수", false, GridColDataType_emu.VarChar, 50, 120, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid2);

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
                ds = helper.FillDataSet("USP_MD0005_POP_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_MOLDCODE", "", DbType.String, ParameterDirection.Input));
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
        }

        #endregion

        #region < EVENT AREA >

        private void btn_SAVE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {

                helper.ExecuteNoneQuery("USP_MD0005_POP_SAVE", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", "", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CORECODE", CORECODE, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("@AS_SP_TYPE", "D", DbType.String, ParameterDirection.Input));

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    int index1 = listBox1.Items[i].ToString().IndexOf(":");
                    string ex1 = listBox1.Items[i].ToString().Substring(0, index1);

                    int index2 = listBox1.Items[i].ToString().IndexOf("-") + 2;
                    string ex2 = listBox1.Items[i].ToString().Substring(index2, listBox1.Items[i].ToString().Length - index2);

                    helper.ExecuteNoneQuery("USP_MD0005_POP_SAVE", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", ex1, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", ex2, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CORECODE", CORECODE, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("@AS_SP_TYPE", "I", DbType.String, ParameterDirection.Input));
                }

                helper.Commit();
                this.DialogResult = DialogResult.OK;
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
    

            #endregion

            private void grid1_ClickCell(object sender, ClickCellEventArgs e)
            {
             sMOLDCODE = CModule.ToString(grid1.ActiveRow.Cells["MOLDCODE"].Value);

            DBHelper helper = new DBHelper(false);

            try
            {
                ds = helper.FillDataSet("USP_MD0005_POP_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input));
                grid2.DataSource = ds.Tables[1];
                grid2.DataBind();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                helper.Close();
            }
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            sITEMCODE = CModule.ToString(grid2.ActiveRow.Cells["ITEMCODE"].Value);
            sITEMNAME = CModule.ToString(grid2.ActiveRow.Cells["ITEMNAME"].Value);

            try
            {
                if(!listBox1.Items.Contains(sMOLDCODE + " : " + sITEMCODE + " - " + sITEMNAME))
                    listBox1.Items.Add(sMOLDCODE + " : " + sITEMCODE + " - " + sITEMNAME);
            }
            catch
            {

            }

        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            catch
            {

            }
        }
    }
}

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
using System.Data;
using System.Windows.Forms;

#endregion


namespace WIZ.PopUp
{
    public partial class MD0001_POP : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        Common _Common = new Common();
        PopUp_Biz _biz = new PopUp_Biz();

        public string CheckItems = "";
        string sMOLDCODE = "";

        #endregion

        #region < CONSTRUCTOR >

        public MD0001_POP(string MOLDCODE)
        {
            sMOLDCODE = MOLDCODE;
            InitializeComponent();
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
                _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 80, 80, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 200, 200, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                grid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
                grid1.DisplayLayout.Override.SelectTypeCell = SelectType.ExtendedAutoDrag;
                grid1.DisplayLayout.Bands[0].Columns["CHK"].CellActivation = Activation.AllowEdit;


                _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "chk_ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "chk_ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 200, 200, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);

                DBHelper helper = new DBHelper(false);

                try
                {
                    rtnDtTemp = helper.FillTable("USP_MD0000_POP_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CONDITION", txtCONDITION.Text, DbType.String, ParameterDirection.Input));

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
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region < EVENT AREA >

        private void btn_SAVE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_MD0000_POP_SAVE", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_SP_TYPE", "D", DbType.String, ParameterDirection.Input));

                for (int grid1rowNUM = 0; grid1rowNUM < grid2.Rows.Count; grid1rowNUM++)
                {
                    helper.ExecuteNoneQuery("USP_MD0000_POP_SAVE", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(grid2.Rows[grid1rowNUM].Cells["chk_ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_SP_TYPE", "I", DbType.String, ParameterDirection.Input));
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

            #endregion
        }
        private void txtCONDITION_TextChanged(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MD0000_BM0010_POP_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CONDITION", txtCONDITION.Text, DbType.String, ParameterDirection.Input));

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
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int grid1rowNUM = 0; grid1rowNUM < grid1.Rows.Count; grid1rowNUM++)
                {
                    if (grid1.Rows[grid1rowNUM].Cells["CHK"].Value.ToString().ToUpper() == "TRUE")
                    {
                        for (int i = 0; i < grid2.Rows.Count; i++)
                        {
                            if (grid2.Rows[i].Cells["chk_ITEMCODE"].Value == grid1.Rows[grid1rowNUM].Cells["ITEMCODE"].Value)
                            {
                                grid2.Rows[i].Delete(false);
                            }
                        }

                        int iRow = grid2.InsertRow();

                        grid2.Rows[iRow].Cells["chk_ITEMCODE"].Value = DBHelper.nvlString(grid1.Rows[grid1rowNUM].Cells["ITEMCODE"].Value);
                        grid2.Rows[iRow].Cells["chk_ITEMNAME"].Value = DBHelper.nvlString(grid1.Rows[grid1rowNUM].Cells["ITEMNAME"].Value);
                    }
                }
            }
            catch
            {

            }
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            try
            {
                grid2.ActiveRow.Delete(false);
            }
            catch
            {

            }
        }
    }
}

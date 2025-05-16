#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0000_POP
//   Form Name    : 코드마스터 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-01-26
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Edited Date  : 
//   Edit By      :
//   Description  : 코드마스터 기준정보 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion


namespace WIZ.MD
{
    public partial class MD0050_POP1 : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        DataSet DSinfo = new DataSet();
        Common _Common = new Common();

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();
        string sMOLDCODE = "";

        #endregion

        #region < CONSTRUCTOR >

        public MD0050_POP1()
        {
            InitializeComponent();
        }
        #endregion

        #region < METHOD AREA >

        private void MD0050_POP1_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                DBHelper helper = new DBHelper(false);

                _GridUtil.InitializeGrid(this.grid1);

                _GridUtil.InitColumnUltraGrid(grid1, "Core_Vend", "업체명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_Code", "코어코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_CoreName", "코어명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_ChaSu", "차수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_PartName", "품목명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);


                _GridUtil.InitializeGrid(this.grid2);

                _GridUtil.InitColumnUltraGrid(grid2, "chk_InDate", "입고일자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "chk_Core_Vend", "업체명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "chk_Core_Code", "코어코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "chk_Core_CoreName", "코어명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "chk_InCnt", "입고수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "chk_COST", "단가", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "chk_PMANAGER", "승인담당자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "chk_ETC", "비고", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);

                #endregion

                #region COMBOBOX SETTING

                cbo_STARTDATE_H.Value = DateTime.Today.ToString("yyyy-MM-dd");

                DSinfo = helper.FillDataSet("USP_MD0050_POP1_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_COREVEND", "", DbType.String, ParameterDirection.Input));

                for (int i = 0; i < DSinfo.Tables[0].Rows.Count; i++)
                {
                    cbo_CoreVend.Items.Add(DSinfo.Tables[0].Rows[i]["CUSTNAME"]);
                }

                #endregion

                #region POP SETTING

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void clear()
        {

        }
        #endregion

        #region < EVENT AREA >

        #endregion

        private void cbo_CoreVend_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DBHelper helper = new DBHelper(false);

                DSinfo = helper.FillDataSet("USP_MD0050_POP1_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_COREVEND", cbo_CoreVend.Text, DbType.String, ParameterDirection.Input));

                txtPMANAGER.Text = LoginInfo.UserID;
                grid1.DataSource = DSinfo.Tables[1];
                grid1.DataBind();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            txtCORENAME.Text = CModule.ToString(grid1.ActiveRow.Cells["Core_CoreName"].Value);
        }

        private void btn_EXPECTED_Click(object sender, EventArgs e)
        {
            int iRow = grid2.InsertRow();

            grid2.Rows[iRow].Cells["chk_InDate"].Value = cbo_STARTDATE_H.Text;
            grid2.Rows[iRow].Cells["chk_Core_Vend"].Value = DBHelper.nvlString(grid1.ActiveRow.Cells["Core_Vend"].Value);
            grid2.Rows[iRow].Cells["chk_Core_Code"].Value = DBHelper.nvlString(grid1.ActiveRow.Cells["Core_Code"].Value);
            grid2.Rows[iRow].Cells["chk_Core_CoreName"].Value = DBHelper.nvlString(grid1.ActiveRow.Cells["Core_CoreName"].Value);
            grid2.Rows[iRow].Cells["chk_InCnt"].Value = txtINCNT.Text;
            grid2.Rows[iRow].Cells["chk_COST"].Value = txtCOST.Text;
            grid2.Rows[iRow].Cells["chk_PMANAGER"].Value = txtPMANAGER.Text;
            grid2.Rows[iRow].Cells["chk_ETC"].Value = txtMEMO.Text;
        }

        private void btn_ADD_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                for (int grid1rowNUM = 0; grid1rowNUM < grid2.Rows.Count; grid1rowNUM++)
                {
                    helper.ExecuteNoneQuery("USP_MD0050_POP1_SAVE", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)

                    , helper.CreateParameter("AS_IO_PRODDATE", DateTime.Now, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_IO_CoreCode", DBHelper.nvlString(grid2.Rows[grid1rowNUM].Cells["chk_Core_Code"].Value), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_IO_Count", DBHelper.nvlString(grid2.Rows[grid1rowNUM].Cells["chk_InCnt"].Value), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_IO_COST", DBHelper.nvlString(grid2.Rows[grid1rowNUM].Cells["chk_COST"].Value), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_IO_Type", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_IO_ETC1", DBHelper.nvlString(grid2.Rows[grid1rowNUM].Cells["chk_ETC"].Value), DbType.String, ParameterDirection.Input));
                }

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

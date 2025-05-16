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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WIZ;
using WIZ.PopUp;
#endregion


namespace WIZ.MD
{
    public partial class MD0052 : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        DataTable ColNameDT = new DataTable();
        Common _Common      = new Common();

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        string sMOLDCODE = "";
        string sREPAIRCODE = "";

        bool stringCVT = true;

        #endregion

        #region < CONSTRUCTOR >

        public MD0052(DataTable dt, string REPAIRCODE)
        {
            sMOLDCODE = dt.Rows[0]["MOLDCODE"].ToString();
            sREPAIRCODE = REPAIRCODE;

            InitializeComponent();
            InitGrid();
            Search();

        }
        #endregion

        #region < METHOD AREA >
        private void InitGrid()
        {
            try
            {
                #region GRID SETTING

                DBHelper helper = new DBHelper(false);


                string[] ColName;
                string HeaderName = "";
                string strSql = "";

                //테이블 검색
                //ColName지정

                if (stringCVT)
                {
                    ColName = new string[] { "기타", "A", "B", "C", "D", "E", "F", "G", "H" };
                }
                else
                {
                    ColName = new string[] { "기타", "1", "2", "3", "4", "5", "6", "7", "8" };
                }


                //금형의 유효캐비티 수정
                try
                {
                    strSql = "SELECT CAVITYNAME FROM MD0010_UJ WHERE MOLDCODE = '" + sMOLDCODE + "'";
                    ColNameDT = helper.FillTable(strSql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


                //_GridUtil.InitColumnUltraGrid(grid1, "CVT1", ColName[1], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "CVT2", ColName[2], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "CVT3", ColName[3], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "CVT4", ColName[4], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);

                //_GridUtil.InitColumnUltraGrid(grid1, "CVT5", ColName[5], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "CVT6", ColName[6], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "CVT7", ColName[7], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "CVT8", ColName[8], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);


                #endregion


                BizGridManager bizGridManager;

                #region COMBOBOX SETTING

                #endregion

                #region POP SETTING

                //bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "4", "" });



                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Search()
        {
            try
            {
                DBHelper helper = new DBHelper(false);

                rtnDtTemp = helper.FillTable("USP_MD0100_POP01_S1", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input));


                for (int j = 0 ; j < rtnDtTemp.Columns.Count; j++)
                {
                    int colcount = ColNameDT.Rows.Count + (5 + j);
                }

            }
            catch (Exception ex)
            {
                //일부러 숨김
                //MessageBox.Show(ex.ToString());
            }
        }


        private void clear()
        {

        }
        #endregion

        #region < EVENT AREA >

        private void Btn_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    Button buffer = (Button)sender;
            //    string btnTag = buffer.Tag.ToString();

            //    switch(btnTag)
            //    {
            //        case "ADD_LIST":
            //            AddList();
            //            break;

            //        case "NEW_CORE":
            //            NewCore();
            //            break;

            //        case "SEARCH":
            //            Search();
            //            break;

            //        case "SAVE":
            //            Save();
            //            break;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.ShowErrorMessage(ex);
            //}
        }

        private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            try
            {

                //grid1.DisplayLayout.Override.AllowRowSummaries = AllowRowSummaries.True;
                //grid1.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
                //grid1.DisplayLayout.Override.SummaryDisplayArea = grid1.ActiveRow.Cells["CVT1"];
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_ADD_LIST_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_SEARCH_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void btn_SAVE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {

                helper.ExecuteNoneQuery("USP_MD0100_UJ_I2", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_REPAIRCODE", sREPAIRCODE, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_COLNAME", "CORECHGTEXT", DbType.String, ParameterDirection.Input));
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString()); 
            }

            finally
            {


            }
        }


        #endregion

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

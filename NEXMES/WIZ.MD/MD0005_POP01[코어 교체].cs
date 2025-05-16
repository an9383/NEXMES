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
    public partial class MD0005_POP01 : WIZ.Forms.BasePopupForm
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

        public MD0005_POP01(DataTable dt, string REPAIRCODE)
        {
            sMOLDCODE = dt.Rows[0]["MOLDCODE"].ToString();
            sREPAIRCODE = REPAIRCODE;

            InitializeComponent();

            btn_ADD_LIST.Tag = "ADD_LIST";
            btn_SEARCH.Tag = "SEARCH";
            btn_SAVE.Tag = "SAVE";

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

                _GridUtil.InitializeGrid(this.grid1);

                _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "금형번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CORE",  "코어리스트", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CORENAME", "코어명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SUM", "합계", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Left, true, false);

                //_GridUtil.InitColumnUltraGrid(grid1, "CVT1", ColName[1], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "CVT2", ColName[2], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "CVT3", ColName[3], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "CVT4", ColName[4], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);

                //_GridUtil.InitColumnUltraGrid(grid1, "CVT5", ColName[5], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "CVT6", ColName[6], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "CVT7", ColName[7], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "CVT8", ColName[8], false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);

                for(int i = 0; i<ColNameDT.Rows.Count;i++)
                {
                    HeaderName = "CVT" + (i + 1);
                    _GridUtil.InitColumnUltraGrid(grid1, HeaderName, ColNameDT.Rows[i]["CAVITYNAME"].ToString(), false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, true);
                }

                int asdasd = ColNameDT.Columns.Count - 5;

                _GridUtil.InitColumnUltraGrid(grid1, "OTHER", "기타", false, GridColDataType_emu.Double, 50, 100, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                #endregion


                BizGridManager bizGridManager;
                bizGridManager = new BizGridManager(grid1);

                #region COMBOBOX SETTING

                #endregion

                #region POP SETTING

                //bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "4", "" });

                bizGridManager.PopUpAdd("CORE", "CORENAME", "MD0001", new string[] { "PLANTCODE", "", "Y" });


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

                grid1.DataSource = rtnDtTemp;

                for (int j = 0 ; j < rtnDtTemp.Columns.Count; j++)
                {
                    int colcount = ColNameDT.Rows.Count + (5 + j);
                    grid1.DisplayLayout.Bands[0].Columns[colcount].Hidden = true;
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
                int SUM = 0;

                SUM = DBHelper.nvlInt(grid1.ActiveRow.Cells["CVT1"].Value) +
                    DBHelper.nvlInt(grid1.ActiveRow.Cells["CVT2"].Value) +
                    DBHelper.nvlInt(grid1.ActiveRow.Cells["CVT3"].Value) +
                    DBHelper.nvlInt(grid1.ActiveRow.Cells["CVT4"].Value) +
                    DBHelper.nvlInt(grid1.ActiveRow.Cells["CVT5"].Value) +
                    DBHelper.nvlInt(grid1.ActiveRow.Cells["CVT6"].Value) +
                    DBHelper.nvlInt(grid1.ActiveRow.Cells["CVT7"].Value) +
                    DBHelper.nvlInt(grid1.ActiveRow.Cells["CVT8"].Value);

                grid1.ActiveRow.Cells["SUM"].Value = SUM;

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
                grid1.InsertRow();

                grid1.ActiveRow.Cells["MOLDCODE"].Value = sMOLDCODE;
                grid1.ActiveRow.Cells["CORE"].Value = "";
                grid1.ActiveRow.Cells["CORENAME"].Value = "";

                grid1.ActiveRow.Cells["SUM"].Value = 0;
                grid1.ActiveRow.Cells["CVT1"].Value = 0;
                grid1.ActiveRow.Cells["CVT2"].Value = 0;
                grid1.ActiveRow.Cells["CVT3"].Value = 0;
                grid1.ActiveRow.Cells["CVT4"].Value = 0;
                grid1.ActiveRow.Cells["CVT5"].Value = 0;
                grid1.ActiveRow.Cells["CVT6"].Value = 0;
                grid1.ActiveRow.Cells["CVT7"].Value = 0;
                grid1.ActiveRow.Cells["CVT8"].Value = 0;
                grid1.ActiveRow.Cells["OTHER"].Value = 0;
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
                        , helper.CreateParameter("AS_COLNAME", "CORECHGTEXT", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_TEXT", txtCORECHGTEXT.Text, DbType.String, ParameterDirection.Input));
                helper.Commit();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString()); 
            }

            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;

            try
            {
                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["CORENAME"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, Common.getLangText("코아명 미입력", "TEXT"));
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            //코어 리스트만 수정 됨
                            helper.ExecuteNoneQuery("USP_MD0020_UJ_SAVE", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_MOLDCODE", DBHelper.nvlString(drRow["MOLDCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CORE", DBHelper.nvlString(drRow["CORE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_FLAG", "D", DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            //코어리스트, 교체사유 등록
                            helper.ExecuteNoneQuery("USP_MD0020_UJ_SAVE", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_MOLDCODE", DBHelper.nvlString(drRow["MOLDCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CORE", DBHelper.nvlString(drRow["CORE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_FLAG", "I", DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            //#region 수정
                            ////코어 리스트만 수정 됨
                            //helper.ExecuteNoneQuery("USP_MD0020_UJ_SAVE", CommandType.StoredProcedure
                            //                        , helper.CreateParameter("AS_MOLDCODE", DBHelper.nvlString(drRow["MOLDCODE"]), DbType.String, ParameterDirection.Input)
                            //                        , helper.CreateParameter("AS_CORE", DBHelper.nvlString(drRow["CORE"]), DbType.String, ParameterDirection.Input)
                            //                        , helper.CreateParameter("AS_FLAG", "D", DbType.String, ParameterDirection.Input));
                            //#endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges();
                helper.Commit();
                Search();
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
    }
}

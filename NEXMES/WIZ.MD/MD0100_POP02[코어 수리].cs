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
    public partial class MD0100_POP02 : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable(); 
        Common _Common      = new Common();

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        string sMOLDCODE = "";
        string sREPAIRCODE = "";
        string sSTATE = "";

        bool stringCVT = true;

        #endregion

        #region < CONSTRUCTOR >

        public MD0100_POP02(DataTable dt, string REPAIRCODE)
        {
            sMOLDCODE = dt.Rows[0]["MOLDCODE"].ToString();
            sREPAIRCODE = REPAIRCODE;

            InitializeComponent();

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

                _GridUtil.InitializeGrid(this.grid1);

                _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 60, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "금형번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CAVITYNAME",  "캐비티명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                #endregion


                BizGridManager bizGridManager;
                bizGridManager = new BizGridManager(grid1);


                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion


                #region POP SETTING


                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddList(object sender, EventArgs e)
        {
            return;
        }

        private void Search()
        {
            clear();

            try
            {
                DBHelper helper = new DBHelper(false);

                rtnDtTemp = helper.FillTable("USP_MD0100_POP02_S1", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void clear()
        {
            chkBLOCK.Checked = false;
            chkRESTORE.Checked = false;
            chkRESTORE.Checked = false;
            txtCOREREPAIRTEXT.Text = "";
        }

        #endregion

        #region < EVENT AREA >

        public void Chk_Change(object sender, EventArgs e)
        {
           try
            {
                CheckBox eC = sender as CheckBox;

                if (eC == chkBLOCK)
                {
                    chkRESTORE.Checked = false;
                    chkKEEP.Checked = false;
                    sSTATE = "BLOCK";
                }
                if (eC == chkRESTORE)
                {
                    chkBLOCK.Checked = false;
                    chkKEEP.Checked = false;
                    sSTATE = "RESTORE";
                }
                if (eC == chkKEEP)
                {
                    chkBLOCK.Checked = false;
                    chkRESTORE.Checked = false;
                    sSTATE = "KEEP";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            try
            {

            }

            catch
            {

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
                //금형별 캐비티 사용/미사용 수정
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    try
                    {
                        if (grid1.Rows[i].Cells["CHK"].Value.ToString() == "1")
                        {
                            helper.ExecuteNoneQuery("USP_MD0010_UJ_SAVE2", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_REPAIRCODE", sREPAIRCODE, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_CAVITYNAME", grid1.Rows[i].Cells["CAVITYNAME"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_STATE", sSTATE, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_TEXT", txtCOREREPAIRTEXT.Text, DbType.String, ParameterDirection.Input));
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        MessageBox.Show(ex.ToString());
                    }
                }

                string strSql = "";

                //금형의 유효캐비티 수정
                try
                { 
                    strSql += "UPDATE MD0000_UJ";
                    strSql += " SET USECAVITY =  ";
                    strSql += "	    (SELECT COUNT(*) from MD0010_UJ";
                    strSql += "      WHERE USEFLAG = 'Y' AND MOLDCODE ='" + sMOLDCODE + "' )";
                    strSql += " WHERE MOLDCODE = '" + sMOLDCODE + "'";

                    helper.ExecuteNoneQuery(strSql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                Search();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }


        #endregion
    }
}

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
    public partial class MD0050_POP2 : WIZ.Forms.BasePopupForm
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

        public MD0050_POP2()
        {
            InitializeComponent();
            cbo_STARTDATE_H.Value = DateTime.Today;
        }
        #endregion

        #region < METHOD AREA >

        #endregion

        #region < EVENT AREA >

        private void Btn_Click(object sender, EventArgs e)
        {

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

    }
}

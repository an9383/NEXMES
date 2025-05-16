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
    public partial class MD0070_POP : WIZ.Forms.BasePopupForm
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

        public MD0070_POP()
        {
            InitializeComponent();

            Search();

        }
        #endregion

        #region < METHOD AREA >

        private void Search()
        {
            string RS_CODE = string.Empty;
            string RS_MSG = string.Empty;
            string sPlantCode = string.Empty;
            string sItemType = string.Empty;
            string sItemCode = string.Empty;
            string sItemName = string.Empty;
            string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

            DBHelper helper = new DBHelper(false);

            try
            {
                /*
                ITEMGROUP	0002	사출
                ITEMTYPE	1	    제품
                ITEMTYPE	2	    반제품-사내가공
                ITEMTYPE	3	    반제품-외주가공
                ITEMTYPE	4	    자재 및 원소재
                 */


                /*
                  SELECT A.MOLDCODE, B.ITEMCODE
                  FROM MD0002_UJ A
                  RIGHT JOIN BM0010 B ON A.ITEMCODE = B.ITEMCODE
                  WHERE B.ITEMTYPE = '1'
                */

                rtnDtTemp = helper.FillTable("USP_MD0070_POP_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

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

        #endregion

        #region < EVENT AREA >

        private void btn_SEARCH_H_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btn_SAVE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_MD0070_POP_I1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("@AS_SP_TYPE", "D", DbType.String, ParameterDirection.Input));

                for (int grid1rowNUM = 0; grid1rowNUM < grid1.Rows.Count; grid1rowNUM++)
                {
                    if (grid1.Rows[grid1rowNUM].Cells["CHK"].Value.ToString().ToUpper() == "TRUE")
                    {
                        CheckItems += DBHelper.nvlString(grid1.Rows[grid1rowNUM].Cells["ITEMCODE"].Value + "|");
                    }

                    if (grid1rowNUM == grid1.Rows.Count - 1)
                    {
                        helper.ExecuteNoneQuery("USP_MD0070_POP_TEST", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", CheckItems, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("@AS_SP_TYPE", "I", DbType.String, ParameterDirection.Input));
                    }
                }

                this.DialogResult = DialogResult.OK;
                grid1.SetAcceptChanges();
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


            /*
            try
            {
                helper.ExecuteNoneQuery("USP_MD0070_POP_I1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("@AS_SP_TYPE", "D", DbType.String, ParameterDirection.Input));

                for (int grid1rowNUM = 0; grid1rowNUM < grid1.Rows.Count; grid1rowNUM++)
                {
                    if (grid1.Rows[grid1rowNUM].Cells["CHK"].Value.ToString().ToUpper() == "TRUE")
                    {
                        helper.ExecuteNoneQuery("USP_MD0070_POP_I1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(grid1.Rows[grid1rowNUM].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("@AS_SP_TYPE", "I", DbType.String, ParameterDirection.Input));
                    }
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
            */

            #endregion

        }

        private void ultraLabel6_Click(object sender, EventArgs e)
        {

        }

        private void sTextBox2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

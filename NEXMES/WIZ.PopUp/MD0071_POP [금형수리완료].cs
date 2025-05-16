#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD0071_POP
//   Form Name    : MD0071_POP [금형수리완료]
//   Name Space   : WIZ.POPUP
//   Created Date : 2020-10-16
//   Made By      : 
//   Edited Date  : 
//   Edit By      :
//   Description  : 금형수리 완료등록을 위한 팝업창
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
using System.Data.SqlClient;

using WIZ;
using WIZ.PopUp;
using WIZ.Control;

#endregion


namespace WIZ.PopUp
{
    public partial class MD0071_POP : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        Common _Common = new Common();
        PopUp_Biz _biz = new PopUp_Biz();
        
        public string CheckItems1 = "";
        public string CheckItems2 = "";

        string sMOLDCODE = "";

        #endregion

        #region < CONSTRUCTOR >

        public MD0071_POP(string sMoldCode)
        {
            InitializeComponent();
            sMOLDCODE = sMoldCode;

            #region GRID SETTING 
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "CHK",           "선택",          false, GridColDataType_emu.CheckBox, 80, 80, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "Core_Vend",     "업체명",        true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "Core_MOLDCODE", "금형코드",      true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "Core_CoreName", "코어명",        true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "Core_LinkCode", "연계코드",      true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "Core_UseCnt",   "코어사용횟수",  true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);

            _GridUtil.SetInitUltraGridBind(grid2);

            grid2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            grid2.DisplayLayout.Override.SelectTypeCell = SelectType.ExtendedAutoDrag;
            grid2.DisplayLayout.Bands[0].Columns["CHK"].CellActivation = Activation.AllowEdit;
            
            Search(sMOLDCODE);
            #endregion

            txtMOLDCODE.Text = sMoldCode;
        }

        #endregion

        #region < METHOD AREA >

        private void Search(string sMOLDCODE)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MD0071_Test", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input));

                grid2.DataSource = rtnDtTemp;
                grid2.DataBind();

                //txtMOLDCODE.Text = sMOLDCODE;
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

        }

        #endregion

        private void ultraLabel4_Click(object sender, EventArgs e)
        {

        }

        private void sTextBox3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCoreSave_Click(object sender, EventArgs e)
        {
            CheckItems1 = "";
            CheckItems2 = "";
            for (int grid2rowNUM = 0; grid2rowNUM < grid2.Rows.Count; grid2rowNUM++)
            {
                if (grid2.Rows[grid2rowNUM].Cells["CHK"].Value.ToString().ToUpper() == "TRUE")
                {
                    CheckItems1 += DBHelper.nvlString(grid2.Rows[grid2rowNUM].Cells["Core_CoreName"].Value + "/");
                    CheckItems2 += DBHelper.nvlString(grid2.Rows[grid2rowNUM].Cells["Core_CoreName"].Value + "[" + grid2.Rows[grid2rowNUM].Cells["Core_UseCnt"].Value + "]/");
                }

                if (grid2rowNUM == grid2.Rows.Count - 1)
                {
                    txtCoreName.Text = CheckItems1.Remove(CheckItems1.Length - 1);
                    txtCount.Text = CheckItems2.Remove(CheckItems2.Length - 1);
                }
            }
        }
    }
}

#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD0070_TEST
//   Form Name    : 금형수리현황
//   Name Space   : WIZ.MD
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 금형수리현황
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;

using WIZ;
using WIZ.PopUp;

#endregion

namespace WIZ.MD
{
    public partial class MD0080 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager();
        private bool bNew = false;

        #endregion

        #region < CONSTRUCTOR >
        public MD0080()
        {
            InitializeComponent();

        }
        #endregion

        #region < FORM LOAD >
        private void MD0080_UJ_TEST_Load(object sender, EventArgs e)
        {
            #region GRID SETTING 
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PERCENT", "진척율", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "금형코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDNAME", "금형명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "DEGREE", "차수", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDTYPE1", "제작구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USESHOT", "현재 Shot 수", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INITIALSHOT", "누적 Shot 수", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCYCLE", "세척기준 Shot 수", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);

            _GridUtil.SetInitUltraGridBind(grid1);

            DoInquire();

            #endregion


            #region COMBOBOX SETTING 

            #endregion

            #region POPUP SETTING

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {
            bNew = false;
            ClosePrgFormNew();

            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid1);
                rtnDtTemp = helper.FillTable("USP_MD0080_S1", CommandType.StoredProcedure);

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
                else
                {
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();
                helper.Close();
            }
        }

        public override void DoNew()
        {

        }

        public override void DoSave()
        {

        }

        public override void DoImportExcel()
        {
            base.DoImportExcel();
            base.DoInquire();
        }

        #endregion

        #region < METHOD AREA >

        #endregion

        private void gbxBody_Click(object sender, EventArgs e)
        {

        }
        
        private void grid1_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            string sMoldCode = CModule.ToString(grid1.ActiveRow.Cells["MOLDCODE"].Value);

            try
            {
                MD0070_POP3 mbp = new MD0070_POP3(sMoldCode);
                mbp.Show();
            }
            catch
            {

            }
        }

    }
}

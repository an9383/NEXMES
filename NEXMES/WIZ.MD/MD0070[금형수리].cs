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
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;

#endregion

namespace WIZ.MD
{
    public partial class MD0070 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        Common _Common = new Common();

        string click_Moldcode = "";

        #endregion

        #region < CONSTRUCTOR >
        public MD0070()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MD0070_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "RP_LotNo", "수리LotNo.", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RP_MDCODE", "금형코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDNAME", "금형명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.InitColumnUltraGrid(grid1, "RP_INDATE", "입고일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RP_STARTDATE", "수리진행일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RP_ENDDATE", "수리완료일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RP_Workdate", "수리완료예정일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RP_INGDATE", "진행일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.InitColumnUltraGrid(grid1, "RP_WorkGB", "구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RP_MEMO", "비고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RP_CVT", "코어사용내역", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "작업일시", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "사용자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            dateTimePicker1.Value = DateTime.Today.AddDays(-30);
            dateTimePicker2.Value = DateTime.Today;

            #endregion

            #region < COMBOBOX SETTING >

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            #endregion

            #region < POPUP SETTING >

            BizGridManager bizGridManager = new BizGridManager(grid1);

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MD0070_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("Start_Date", "'" + dateTimePicker1.Value + "'", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("End_Date", "'" + dateTimePicker2.Value + "'", DbType.String, ParameterDirection.Input));

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
                helper.Close();
            }
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

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            MD0070_POP2 MDP = new MD0070_POP2();
            MDP.Show();
        }

        private void grid1_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            string sMoldCode = CModule.ToString(grid1.ActiveRow.Cells["RP_MDCode"].Value);
            string sWorkGB = CModule.ToString(grid1.ActiveRow.Cells["CODENAME"].Value);

            if (sWorkGB == "수리대기")
            {
                MD0070_POP3 MDP = new MD0070_POP3(sMoldCode);
                MDP.Show();
            }
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            if (click_Moldcode == "")
            {
                this.ShowDialog("타입을 변경 할 금형을 선택해주세요.", WIZ.Forms.DialogForm.DialogType.OK);
            }
            else
            {
                MD0070_POP4 MDP = new MD0070_POP4(click_Moldcode);
                MDP.Show();
            }
        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            click_Moldcode = CModule.ToString(grid1.ActiveRow.Cells["RP_MDCode"].Value);
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            MD0070_POP1 MDP = new MD0070_POP1(click_Moldcode);
            MDP.Show();
        }
    }
}

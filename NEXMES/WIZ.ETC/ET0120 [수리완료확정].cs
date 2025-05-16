#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : ET0020
//   Form Name    : 금형수리현황
//   Name Space   : WIZ.MD
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 금형수리현황
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.ETC
{
    public partial class ET0120 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        int CheckCount = 0;
        Common _Common = new Common();

        #endregion

        #region < CONSTRUCTOR >
        public ET0120()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void ET0020_Load(object sender, EventArgs e)
        {
            #region GRID SETTING  
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "ET13_LOT", "수리LOT", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ET13_Mold", "금형코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ET13_MoldNmae", "금형명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ET13_PartName", "현재품명", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ET13_Gubun1", "수리", false, GridColDataType_emu.CheckBox, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ET13_Gubun2", "체인지코어", false, GridColDataType_emu.CheckBox, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ET13_Gubun3", "분해세척", false, GridColDataType_emu.CheckBox, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ET13_Lock", "인터락", false, GridColDataType_emu.Button, 120, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            grid1.DisplayLayout.Override.SelectTypeCell = SelectType.ExtendedAutoDrag;
            grid1.DisplayLayout.Bands[0].Columns[0].CellActivation = Activation.AllowEdit;


            #endregion
            //COMBOBOX SETTING 

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            DBHelper helper = new DBHelper(false);
            try
            {
                ds = helper.FillDataSet("USP_PL0000_W1", CommandType.StoredProcedure);

                cbo_WORKCENTERNAME.Text = "전체";
                cbo_WORKCENTERNAME.Items.Add("전체");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        cbo_WORKCENTERNAME.Items.Add(ds.Tables[0].Rows[i]["WORKCENTERNAME"]);
                    }
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
        #endregion

        #region POPUP SETTING

        //BizGridManager bizGridManager = new BizGridManager(grid1);

        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                ds = helper.FillDataSet("USP_PL0000_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_WORKCENTERNAME", cbo_WORKCENTERNAME.Text, DbType.String, ParameterDirection.Input));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grid1.DataSource = ds.Tables[0];
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


        private void btn_PlanSave_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {

            }

        }

        private void btn_DELETE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                int cnt = 0;
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["CHK"].Value) == "선택")
                    {
                        cnt++;
                    }
                }

                if (this.ShowDialog("계획 " + cnt + "건을 삭제하시겠습니까?", WIZ.Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
                {
                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        if (Convert.ToString(grid1.Rows[i].Cells["CHK"].Value) == "선택")
                        {
                            helper.ExecuteNoneQuery("USP_PL0000_D1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PL_LOT", grid1.Rows[i].Cells["PL_LotNo"].Value, DbType.String, ParameterDirection.Input));
                        }
                    }

                    helper.Commit();
                    this.ShowDialog("계획이 삭제되었습니다.", Forms.DialogForm.DialogType.OK);
                    DoInquire();
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

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    grid1.Rows[i].Cells["CHK"].Value = "";
                }
            }
            catch
            {

            }
        }

        private void btn_PlenSave_Click(object sender, EventArgs e)
        {
            ET0120_POP mbp = new ET0120_POP();
            mbp.ShowDialog(this);
        }
    }
}

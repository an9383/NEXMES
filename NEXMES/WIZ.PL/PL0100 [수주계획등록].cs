#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PL0100
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

namespace WIZ.PL
{
    public partial class PL0100 : WIZ.Forms.BaseMDIChildForm
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
        public PL0100()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PL0100_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_LotNo", "계획LOT", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_DATE", "계획등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_MAKEPLANDAY", "생산계획일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_GUBUN", "구분", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PL_TON",            "톤 수",        false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_Vend", "고객사", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_PartName", "제품명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PL_MoldName",       "금형명",       false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_WorkCenterName", "작업장명", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PL_Degree",         "차수",         false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PL_MoldCavity",     "금형캐비티",   false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PL_CycleTime",      "사이클타임",   false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PL_Work",           "일생산수량",   false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_Count", "계획수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_State", "상태", true, GridColDataType_emu.VarChar, 40, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            grid1.DisplayLayout.Override.SelectTypeCell = SelectType.ExtendedAutoDrag;
            grid1.DisplayLayout.Bands[0].Columns[0].CellActivation = Activation.AllowEdit;

            DTP1.Value = DateTime.Today.AddDays(-365);
            DTP2.Value = DateTime.Today.AddDays(7);

            #endregion
            //COMBOBOX SETTING 

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            //rtnDtTemp = _Common.GET_BM0000_CODE("PLSTATE"); //생산계획유형
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLSTATE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_BM0145_CODE("Y"); //생산계획유형               
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "", "");

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

        #region < POPUP SETTING >

        //BizGridManager bizGridManager = new BizGridManager(grid1);

        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                ds = helper.FillDataSet("USP_PL0000_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", cbo_PLANTCODE_H.Value.ToString(), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Startdate", DTP1.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Enddate", DTP2.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
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

        public override void DoDelete()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                int cnt = 0;
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grid1.Rows[i].Cells["CHK"].Value) == true)
                    {
                        cnt++;
                    }
                }

                if (this.ShowDialog("계획 " + cnt + "건을 삭제하시겠습니까?", WIZ.Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
                {
                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grid1.Rows[i].Cells["CHK"].Value) == true)
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
                PL0110_POP mbp = new PL0110_POP();
                mbp.ShowDialog(this);
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {

            }
        }
    }
}

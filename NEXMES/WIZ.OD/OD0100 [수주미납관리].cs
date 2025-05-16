#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : OD0100
//   Form Name    : 금형수리현황
//   Name Space   : WIZ.MD
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 금형수리현황
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using WIZ.PopUp;

#endregion

namespace WIZ.OD
{
    public partial class OD0100 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        Common _Common = new Common();

        #endregion

        #region < CONSTRUCTOR >
        public OD0100()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void OD0100_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid1, "ODM_Lotno", "수주번호", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ODM_Vend", "고객사", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ODM_PartName", "제품명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ODM_OrderDate", "수주일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ODM_FixedDate", "납기일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ODM_OrderQTY", "수주수량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ODM_deliQTY", "납품수량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ODM_resiQTY", "수주잔량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ODM_PONO", "PONo.", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "NPAYREASON", "미납사유", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ODM_ETC", "비고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                dtp_SDATE.Value = DateTime.Today;

                #endregion

                #region COMBOBOX SETTING 

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("NPAYREASON"); //품목유형
                WIZ.Common.FillComboboxMaster(this.cbo_REASON_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "NPAYREASON", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                BizGridManager bizGridManager = new BizGridManager(grid1);

                #endregion
            }
            catch
            {

            }
        }
        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            DBHelper helper = new DBHelper(false);
            try
            {
                rtnDtTemp = helper.FillTable("USP_OD0100_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(cbo_PLANTCODE_H.Value), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SDATE", dtp_SDATE.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_NPAYREASON", DBHelper.nvlString(cbo_REASON_H.Value), DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
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
            DBHelper helper = new DBHelper(false);
            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["NPAYREASON"].Value) != "")
                    {
                        //저장, 수정
                        helper.ExecuteNoneQuery("USP_OD0100_I", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                          , helper.CreateParameter("AS_OD_LotNo", Convert.ToString(grid1.Rows[i].Cells["ODM_LotNo"].Value), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_OD_PoNo", Convert.ToString(grid1.Rows[i].Cells["ODM_PoNo"].Value), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_NPAYREASON", Convert.ToString(grid1.Rows[i].Cells["NPAYREASON"].Value), DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "E")
                        {
                            throw new Exception(helper.RSMSG);
                        }
                        helper.Commit();
                    }
                }
                this.ShowDialog("수주등록이 완료되었습니다.", Forms.DialogForm.DialogType.OK);
                DoInquire();
            }

            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                ClosePrgFormNew();
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

        }

        private void btn_ODEND_Click(object sender, EventArgs e)
        {

        }
    }
}

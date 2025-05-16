#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : OD0200
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
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.OD
{
    public partial class OD0200 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        Common _Common = new Common();

        #endregion

        #region < CONSTRUCTOR >
        public OD0200()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void OD0200_Load(object sender, EventArgs e)
        {
            #region GRID SETTING  
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "OD_LotNo", "수주번호", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_Vend", "고객사", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_PartName", "제품명", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_OrderDate", "수주일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_FixedDate", "납기일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_OrderQTY", "수주수량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_deliQTY", "납품수량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_UnitCost", "단가", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_Money", "금액", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_Residual", "수주잔량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_HRS", "HRS재고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_PoNo", "PONO", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_Amount", "월평균사용량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_Type", "비고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            dtp_STARTDATE.Value = DateTime.Today.AddDays(-30);
            dtp_ENDDATE.Value = DateTime.Today;

            #endregion

            #region COMBOBOX SETTING 

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            #endregion

            #region POPUP SETTING

            BizGridManager bizGridManager = new BizGridManager(grid1);

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_OD0200_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(cbo_PLANTCODE_H.Value), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_STARTDATE", dtp_STARTDATE.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ENDDATE", dtp_ENDDATE.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input));


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

        private void btn_ODEND_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                if (this.ShowDialog("해당 수주를 마감처리 하시겠습니까?", Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
                {
                    helper.ExecuteNoneQuery("USP_OD0200_SAVE", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_OD_LotNo", grid1.ActiveRow.Cells["OD_LotNo"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_OD_PoNo", grid1.ActiveRow.Cells["OD_PoNo"].Value, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }

                    this.ShowDialog("해당 수주가 마감처리 되었습니다.", Forms.DialogForm.DialogType.OK);
                    helper.Commit();
                    DoInquire();
                }
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
    }
}

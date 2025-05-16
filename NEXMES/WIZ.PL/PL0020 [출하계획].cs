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
using WIZ.PopUp;

#endregion

namespace WIZ.PL
{
    public partial class PL0020 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        int saveCount = 0;
        int saveCount2 = 0;
        int saveCount3 = 0;
        Common _Common = new Common();

        #endregion

        #region < CONSTRUCTOR >
        public PL0020()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PL0020_Load(object sender, EventArgs e)
        {
            DTP1.Value = DateTime.Today;

            #region < GRID SETTING >
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "OD_ITEMCODE", "품목코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_PartName", "품목명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_OrderQTY", "수주량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_Residual", "수주잔량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "포장전재고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PACKQTY", "포장후재고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "mRESIDUAL", "계획대비잔량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.InitColumnUltraGrid(grid1, "DAY1", Convert.ToString(DTP1.Value.AddDays(0).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAY2", Convert.ToString(DTP1.Value.AddDays(1).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAY3", Convert.ToString(DTP1.Value.AddDays(2).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAY4", Convert.ToString(DTP1.Value.AddDays(3).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAY5", Convert.ToString(DTP1.Value.AddDays(4).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAY6", Convert.ToString(DTP1.Value.AddDays(5).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAY7", Convert.ToString(DTP1.Value.AddDays(6).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.InitColumnUltraGrid(grid1, "DAY8", Convert.ToString(DTP1.Value.AddDays(7).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAY9", Convert.ToString(DTP1.Value.AddDays(8).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAY10", Convert.ToString(DTP1.Value.AddDays(9).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAY11", Convert.ToString(DTP1.Value.AddDays(10).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAY12", Convert.ToString(DTP1.Value.AddDays(11).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAY13", Convert.ToString(DTP1.Value.AddDays(12).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAY14", Convert.ToString(DTP1.Value.AddDays(13).ToString("yyyy-MM-dd")), true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "OD_LOTNO", "수주LOTNo.", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_PoNo", "수주PONo.", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_ITEMCODE", "품목코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_PartName", "품목명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_CUSTNAME", "고객사", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_OrderQTY", "수주량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_Residual", "수주잔량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_UnitCost", "단가", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_Money", "총금액", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_OrderDate", "수주일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_FixedDate", "납기일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_Amount", "평균사용량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion
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
                grid1.DataSource = null;
                _GridUtil.Grid_Clear(grid2);

                rtnDtTemp = helper.FillTable("USP_PL0020_S1", CommandType.StoredProcedure
                    //, helper.CreateParameter("AS_ITEMCODE", Convert.ToString(dt.Rows[i]["OD_ITEMCODE"]), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY1", Convert.ToString(DTP1.Value.AddDays(0).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY2", Convert.ToString(DTP1.Value.AddDays(1).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY3", Convert.ToString(DTP1.Value.AddDays(2).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY4", Convert.ToString(DTP1.Value.AddDays(3).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY5", Convert.ToString(DTP1.Value.AddDays(4).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY6", Convert.ToString(DTP1.Value.AddDays(5).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY7", Convert.ToString(DTP1.Value.AddDays(6).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY8", Convert.ToString(DTP1.Value.AddDays(7).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY9", Convert.ToString(DTP1.Value.AddDays(8).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY10", Convert.ToString(DTP1.Value.AddDays(9).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY11", Convert.ToString(DTP1.Value.AddDays(10).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY12", Convert.ToString(DTP1.Value.AddDays(11).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY13", Convert.ToString(DTP1.Value.AddDays(12).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_DAY14", Convert.ToString(DTP1.Value.AddDays(13).ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();

                    grid1.Columns[0].Header.Caption = "품목코드";
                    grid1.Columns[1].Header.Caption = "품목명";
                    grid1.Columns[2].Header.Caption = "수주량";
                    grid1.Columns[3].Header.Caption = "수주잔량";
                    grid1.Columns[4].Header.Caption = "포장전재고";
                    grid1.Columns[5].Header.Caption = "포장후재고";
                    grid1.Columns[6].Header.Caption = "계획대비잔량";

                    grid1.Columns[0].Header.Appearance.TextHAlign = HAlign.Center;
                    grid1.Columns[1].Header.Appearance.TextHAlign = HAlign.Center;
                    grid1.Columns[2].Header.Appearance.TextHAlign = HAlign.Center;
                    grid1.Columns[3].Header.Appearance.TextHAlign = HAlign.Center;
                    grid1.Columns[4].Header.Appearance.TextHAlign = HAlign.Center;
                    grid1.Columns[5].Header.Appearance.TextHAlign = HAlign.Center;
                    grid1.Columns[6].Header.Appearance.TextHAlign = HAlign.Center;

                    grid1.Columns[0].CellAppearance.TextHAlign = HAlign.Center;
                    grid1.Columns[1].CellAppearance.TextHAlign = HAlign.Center;
                    grid1.Columns[2].CellAppearance.TextHAlign = HAlign.Right;
                    grid1.Columns[3].CellAppearance.TextHAlign = HAlign.Right;
                    grid1.Columns[4].CellAppearance.TextHAlign = HAlign.Right;
                    grid1.Columns[5].CellAppearance.TextHAlign = HAlign.Right;
                    grid1.Columns[6].CellAppearance.TextHAlign = HAlign.Right;

                    for (int i = 7; i < grid1.Columns.Count; i++)
                    {
                        grid1.Columns[i].Header.Caption = Convert.ToString(DTP1.Value.AddDays(i - 7).ToString("yyyy-MM-dd"));
                        grid1.Columns[i].Header.Appearance.TextHAlign = HAlign.Center;
                        grid1.Columns[i].CellAppearance.TextHAlign = HAlign.Right;
                    }

                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        grid1.Rows[i].Activation = Activation.NoEdit;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
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

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PL0020_S2", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", grid1.ActiveRow.Cells["OD_ITEMCODE"].Value, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds();
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        private void grid1_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            try
            {
                PL0020_POP1 mbp = new PL0020_POP1(Convert.ToString(grid1.ActiveRow.Cells["OD_ITEMCODE"].Value),
                    Convert.ToString(grid1.ActiveRow.Cells["OD_PartName"].Value));
                mbp.ShowDialog(this);

                DoInquire();
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {

            }
        }

        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }
    }
}

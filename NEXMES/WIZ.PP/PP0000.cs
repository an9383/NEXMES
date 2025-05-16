#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0000
//   Form Name    : 작업지시 별 진척 현황
//   Name Space   : WIZ.AP
//   Created Date : 2017-01-01
//   Made By      : WIZ
//   Description  :
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;

using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0000 : WIZ.Forms.BaseMDIChildForm
    {
        #region< MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager();
        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region< CONSTRUCTOR >
        public PP0000()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM EVENT >
        private void PP0000_Load(object sender, EventArgs e)
        {
            #region --- Grid Setting ---
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO_H", "작업지시번호\r\nHeader", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERTYPE", "지시구분", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "지시일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시량", false, GridColDataType_emu.VarChar, 100, true, false);

            _GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ORDERQTY", Infragistics.Win.HAlign.Right);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region --- Combobox & Popup Setting ---
            dtpSDate_H.Value = DateTime.Now.AddDays(-7);
            dtpEDate_H.Value = DateTime.Now;

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            cboPlantCode_H.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("ORDERTYPE");
            WIZ.Common.FillComboboxMaster(this.cboOrderType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "", "Y" });
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", dtpSDate_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", dtpEDate_H.Value);
                string sItemCode = txtItemCode_H.Text.Trim();
                string sOrderType = Convert.ToString(cboOrderType_H.Value);

                base.DoInquire();

                grid1.DataSource = null;

                rtnDtTemp = helper.FillTable("USP_PP0000_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ORDERTYPE", sOrderType, DbType.String, ParameterDirection.Input));


                DataTable dtGrid = rtnDtTemp;

                GridInitialize(dtGrid);

                grid1.DataSource = dtGrid;
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();

                ClosePrgFormNew();
            }
        }
        #endregion

        private void GridInitialize(DataTable dtGrid)
        {
            try
            {
                #region --- Grid Setting ---
                _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO_H", "작업지시번호\r\nHeader", false, GridColDataType_emu.VarChar, 130, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERTYPE", "지시구분", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "지시일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시량", false, GridColDataType_emu.VarChar, 100, true, false);

                int iCol = dtGrid.Columns.Count - 7;

                for (int i = 0; i < iCol; i++)
                {
                    string sColCode = "STEP" + string.Format("{0:D2}", i + 1);
                    string sColName = "공정 " + string.Format("{0:D2}", i + 1) + " 단계";

                    _GridUtil.InitColumnUltraGrid(grid1, sColCode, sColName, false, GridColDataType_emu.VarChar, 220, true, false);

                    _GridUtil.SetColumnTextHAlign(grid1, sColCode, Infragistics.Win.HAlign.Left);

                    grid1.Columns[sColCode].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
                }

                grid1.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;

                _GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "ORDERQTY", Infragistics.Win.HAlign.Right);

                _GridUtil.SetInitUltraGridBind(grid1);

                #region --- Combobox & Popup Setting ---
                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("ORDERTYPE");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                #endregion
                #endregion
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
        }
    }
}
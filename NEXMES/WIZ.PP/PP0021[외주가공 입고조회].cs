#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0021
//   Form Name    : 작업지시 생성 및 확정
//   Name Space   : WIZ.AP
//   Created Date : 2017-01-01
//   Made By      :
//   Description  :
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0021 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();

        DataTable dtGrid;
        DataTable dtGrid2;

        /// <summary>
        /// 생성시 그리드 컬럼 숫자
        /// </summary>
        public int grid3Count = 0;
        #endregion

        #region < CONSTRUCTOR >
        public PP0021()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PP0021_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;
            //cbo_NEWORDERDATE_H.Value = DateTime.Now.AddDays(1);

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;


            #endregion
        }

        private void GridInitialize()
        {
            try
            {
                //grid1
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PONIO", "외주NO", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "OUTSOURCING", "외주 종류", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PODATE", "발주날짜", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANINDATE", "계획날짜", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "고객코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "QTY", "수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.SetInitUltraGridBind(grid1);



                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PONIO", "외주NO", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOT", false, GridColDataType_emu.VarChar, 140, 0, Infragistics.Win.HAlign.Left, true, false);


                _GridUtil.SetInitUltraGridBind(grid2);
                grid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;



            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            bNew = false;

            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid1);


                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();

                base.DoInquire();

                dtGrid = helper.FillTable("USP_PP0021_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input));

                if (dtGrid.Rows.Count > 0)
                {
                    grid1.DataSource = dtGrid;
                    grid1.DataBinds(dtGrid);
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();

                helper.Close();
            }
        }




        #endregion

        #region < EVENT AREA >


        #endregion

        #region < METHOD AREA >

        #endregion

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0) return;

            _GridUtil.Grid_Clear(grid2);
            DBHelper helper = new DBHelper(false);

            try
            {
                string Pono = grid1.ActiveRow.Cells["PONO"].Text; //Ponio



                dtGrid2 = helper.FillTable("USP_PP0021_S2", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PONO", Pono, DbType.String, ParameterDirection.Input));

                if (dtGrid2.Rows.Count > 0)
                {
                    grid2.DataSource = dtGrid2;
                    grid2.DataBinds(dtGrid2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }
    }
}

#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP2900
//   Form Name    : 공정재고현황
//   Name Space   : WIZ.PP
//   Created Date : 
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
    using WIZ.Forms;

    public partial class PP2900 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable dtTemp = new DataTable();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성

        BizTextBoxManager btbManager = new BizTextBoxManager();

        #endregion

        #region < CONSTRUCTOR >
        public PP2900()
        {
            InitializeComponent();
        }
        #endregion



        #region < FORM LOAD >
        private void PP2900_Load(object sender, EventArgs e)
        {

            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            //_GridUtil.InitColumnUltraGrid(grid1, "CHK",            "선택",     false, GridColDataType_emu.CheckBox, 70,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장ⓒ", false, GridColDataType_emu.VarChar,  100, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar,  180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOT NO", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품번", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고", false, GridColDataType_emu.VarChar, 200, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "재고량", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTLOTNO", "업체LOT", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 300, true, false);

            _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
            //_GridUtil.SetColumnTextHAlign(grid1, "WORKCENTERNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WHCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "NOWQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "REMARK", Infragistics.Win.HAlign.Left);

            grid1.DisplayLayout.Bands[0].Columns["NOWQTY"].Format = "#,###";

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "작업장ⓒ", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품번", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 220, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INLOTNO", "LOT NO", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INQTY", "투입량", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OUTQTY", "사용량", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "NOWQTY", "잔량", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 70, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTLOTNO", "업체LOT", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INDATE", "투입일시", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INWORKER", "투입자", false, GridColDataType_emu.VarChar, 100, true, false);

            _GridUtil.SetColumnTextHAlign(grid2, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "WORKCENTERNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "INITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "INQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "OUTQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "NOWQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "INWORKER", Infragistics.Win.HAlign.Left);

            grid2.DisplayLayout.Bands[0].Columns["INQTY"].Format = "#,###";
            grid2.DisplayLayout.Bands[0].Columns["OUTQTY"].Format = "#,###";
            grid2.DisplayLayout.Bands[0].Columns["NOWQTY"].Format = "#,###";

            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region < COMBOBOX SETTING >
            Common _Common = new Common();

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode_H.Value = "10";

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE");
            WIZ.Common.FillComboboxMaster(this.cboWhCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #region < POP-UP SETTING >

            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H.Value, "" });
            btbManager.PopUpAdd(txtWorkCenterCode_H, txtWorkCenterName_H, "TBM0600Y", new object[] { cboPlantCode_H.Value, "", "", "" });


            #endregion
        }

        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid2);

            string sPlantCode = cboPlantCode_H.Value.ToString().Trim();
            string sItemCode = txtItemCode_H.Text.Trim();
            string sWorkCenterCode = txtWorkCenterCode_H.Text.Trim();
            string sLotNo = txtLotNo.Text.Trim();
            string sCustLotNo = txtCustLot.Text.Trim();
            string sWhCode = cboWhCode.Value.ToString().Trim();
            int tabIdx = tabControl1.SelectedTab.Index;

            try
            {
                base.DoInquire();

                dtTemp = helper.FillTable("USP_PP2900_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                         //, helper.CreateParameter("WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("CUSTLOTNO", sCustLotNo, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("TABINDEX", tabIdx, DbType.Int32, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (dtTemp.Rows.Count > 0)
                    {
                        if (tabIdx == 0)
                        {
                            grid1.DataSource = dtTemp;
                            grid1.DataBinds();
                        }
                        else
                        {
                            grid2.DataSource = dtTemp;
                            grid2.DataBinds();
                        }
                    }
                    else
                    {
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
                else
                {
                    string hMSG = helper.RSMSG;
                    this.ShowDialog(hMSG, DialogForm.DialogType.OK);
                    helper.Rollback();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                this.ShowDialog(msg, WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }
        #endregion

        #region < EVENT AREA >
        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "CHK")
            {
                bool chk = Convert.ToString(this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value).ToUpper() == "1" ? true : false;

                if (chk == true)
                {
                    this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = false;
                }
                else
                {
                    this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = true;
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            int cnt = 0;

            if (grid1.Rows.Count > 0)
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (grid1.Rows[i].Cells["CHK"].Value.ToString() == "1")
                    {
                        string sPlantCode = grid1.Rows[i].Cells["PLANTCODE"].Value.ToString();
                        string sLotNo = grid1.Rows[i].Cells["LOTNO"].Value.ToString();
                        string sItemCode = grid1.Rows[i].Cells["ITEMCODE"].Value.ToString();
                        string sNowQty = grid1.Rows[i].Cells["NOWQTY"].Value.ToString();
                        string sUnitCode = grid1.Rows[i].Cells["UNITCODE"].Value.ToString();
                        string sWhCode = "WH003";

                        helper.ExecuteNoneQuery("USP_PP2900_I1", CommandType.StoredProcedure
                                                               , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_BARCODE", sLotNo, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_QTY", sNowQty, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_UNITCODE", sUnitCode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                    }
                    else
                    {
                        cnt++;
                    }

                    if (cnt == grid1.Rows.Count)
                    {
                        this.ShowDialog(Common.getLangText("자재재고로 이동할 LOT을 선택한 후 버튼을 눌러주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }

                MessageBox.Show("dd");

            }

        }

        #endregion
    }
}
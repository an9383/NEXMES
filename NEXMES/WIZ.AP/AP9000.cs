#region < FORM INFO >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP9000
//   Form Name    : 생산계획정보 조회 및 확정
//   Name Space   : WIZ.AP
//   Created Date : 2017-01-01
//   Made By      : WIZ
//   Description  : 계획 확정 시, 작업지시 생성 됨. (HEADER : TAP0100 / DETAIL : TAP0200)
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP9000 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager();
        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public AP9000()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM EVENT >
        private void AP9000_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            dtpSDate_H.Value = DateTime.Now.AddDays(-7);
            dtpEDate_H.Value = DateTime.Now;
            dtpOrderDate_S.Value = DateTime.Now;

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            cboPlantCode_H.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("ROUTERTYPE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ROUTERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboRouterType_S, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요.", "*");
            cboRouterType_S.Value = "00";

            rtnDtTemp = _Common.GET_BM0000_CODE("ORDERTYPE");
            WIZ.Common.FillComboboxMaster(this.cboOrderType_S, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요.", "*");
            cboOrderType_S.Value = "N";

            rtnDtTemp = _Common.GET_BM0000_CODE("FIXFLAG");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FIXFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboFix_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL.", "");

            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "", "Y" });
            #endregion
        }

        private void GridInitialize()
        {
            try
            {
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 60, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "FIXFLAG", "편성여부", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "생산계획일자", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "생산계획번호", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERSEQ", "SEQ.", false, GridColDataType_emu.Integer, 60, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "계획수량", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEQTY", "편성수량", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMAINQTY", "가능수량", false, GridColDataType_emu.VarChar, 80, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITNAME", "단위", false, GridColDataType_emu.VarChar, 60, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "고객사", false, GridColDataType_emu.VarChar, 200, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DUEDATE", "입고예정일자", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "FIXDATE", "편성종료일자", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 250, true, false);

                _GridUtil.SetColumnTextHAlign(grid1, "ORDERSEQ", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "ORDERQTY", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(grid1, "USEQTY", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(grid1, "REMAINQTY", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(grid1, "CUSTNAME", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "REMARK ", Infragistics.Win.HAlign.Left);

                grid1.Columns["ORDERQTY"].Format = "#,##0";
                grid1.Columns["USEQTY"].Format = "#,##0";
                grid1.Columns["REMAINQTY"].Format = "#,##0";

                grid1.Columns["ORDERNO"].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                grid1.Columns["ORDERNO"].CellAppearance.FontData.SizeInPoints = 13;

                grid1.Columns["REMAINQTY"].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                grid1.Columns["REMAINQTY"].CellAppearance.FontData.SizeInPoints = 13;
                grid1.Columns["REMAINQTY"].CellAppearance.ForeColor = Color.Red;

                grid1.Columns["CHK"].Header.Fixed = true;
                grid1.Columns["PLANTCODE"].Header.Fixed = true;
                grid1.Columns["FIXFLAG"].Header.Fixed = true;
                grid1.Columns["ORDERDATE"].Header.Fixed = true;
                grid1.Columns["ORDERNO"].Header.Fixed = true;
                grid1.Columns["ORDERSEQ"].Header.Fixed = true;

                _GridUtil.SetInitUltraGridBind(grid1);

                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOLBAR EVENT >
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
                string sFixflag = Convert.ToString(cboFix_H.Value);

                base.DoInquire();

                rtnDtTemp = helper.FillTable("USP_AP9000_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_FIXFLAG", sFixflag, DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (DBHelper.nvlString(grid1.Rows[i].Cells["FIXFLAG"].Value).Trim() == "Y")
                    {
                        grid1.Rows[i].Appearance.BackColor = Color.Pink;
                        grid1.Rows[i].Cells["ORDERNO"].Appearance.BackColor = Color.DarkRed;
                        grid1.Rows[i].Cells["ORDERNO"].Appearance.ForeColor = Color.Yellow;
                    }
                    else if (DBHelper.nvlString(grid1.Rows[i].Cells["FIXFLAG"].Value).Trim() == "N")
                    {
                        grid1.Rows[i].Appearance.BackColor = Color.SkyBlue;
                        grid1.Rows[i].Cells["ORDERNO"].Appearance.BackColor = Color.DarkBlue;
                        grid1.Rows[i].Cells["ORDERNO"].Appearance.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        grid1.Rows[i].Appearance.BackColor = Color.White;
                        grid1.Rows[i].Cells["ORDERNO"].Appearance.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
        }
        #endregion

        private void grid1_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {

        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (Convert.ToString(e.Cell.Column) == "CHK")
            {
                bool bChk = Convert.ToBoolean(grid1.ActiveRow.Cells["CHK"].Value);

                if (bChk == true)
                {
                    grid1.Rows[grid1.ActiveRow.Index].Cells["CHK"].Value = false;
                }
                else
                {
                    grid1.Rows[grid1.ActiveRow.Index].Cells["CHK"].Value = true;
                }
            }
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count <= 0)
            {
                this.ShowDialog(Common.getLangText("조회 된 생산계획 정보가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);

                return;
            }

            int iSelRows = 0;

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(grid1.Rows[i].Cells["CHK"].Value) == true) { iSelRows++; }
            }

            DialogResult result = MessageBox.Show(iSelRows.ToString() + "건의 생산계획 정보를 편성 합니다." + Environment.NewLine + "계속 진행 하시겠습니까?", "생산계획 편성 처리", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result.ToString().ToUpper() == "NO")
                return;

            DBHelper helper = new DBHelper("", true);

            try
            {
                string sOrderNO = string.Empty;
                string sOrderDate = string.Empty;
                string sRouterType = string.Empty;
                string sOrderType = string.Empty;

                int iOrderSEQ;
                int iOrderQty;
                int iOrderQty_ERP;

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grid1.Rows[i].Cells["CHK"].Value) == true)
                    {
                        sOrderNO = Convert.ToString(grid1.Rows[i].Cells["ORDERNO"].Value);
                        iOrderSEQ = DBHelper.nvlInt(grid1.Rows[i].Cells["ORDERSEQ"].Value);
                        iOrderQty_ERP = DBHelper.nvlInt(grid1.Rows[i].Cells["ORDERQTY"].Value);
                        iOrderQty = DBHelper.nvlInt(grid1.Rows[i].Cells["REMAINQTY"].Value);
                        sOrderDate = string.Format("{0:yyyy-MM-dd}", dtpOrderDate_S.Value);
                        sRouterType = Convert.ToString(cboRouterType_S.Value);
                        sOrderType = Convert.ToString(cboOrderType_S.Value);

                        if (iOrderQty > iOrderQty_ERP)
                        {
                            this.ShowDialog("[ " + sOrderNO + "(" + iOrderSEQ.ToString() + ") ] " + Common.getLangText("해당 생산계획 정보에서 \r\n지시수량이 계획수량을 초과하였습니다."), WIZ.Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        helper.ExecuteNoneQuery("USP_AP9000_I1", CommandType.StoredProcedure
                      , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_ORDERNO", sOrderNO, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AI_ORDERSEQ", iOrderSEQ, DbType.Int16, ParameterDirection.Input)
                      , helper.CreateParameter("AI_ORDERQTY", iOrderQty, DbType.Int16, ParameterDirection.Input)
                      , helper.CreateParameter("AS_ORDERDATE", sOrderDate, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_ROUTERTYPE", sRouterType, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_ORDERTYPE", sOrderType, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE != "S")
                            throw new Exception(helper.RSMSG);
                    }
                }

                helper.Commit();

                DoInquire();

                this.ShowDialog(Common.getLangText("선택한 생산계획 정보가 편성 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //선택한 생산계획 정보가 편성 되었습니다.
            }
            catch (Exception ex)
            {
                helper.Rollback();

                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void btnERPDownload_Click(object sender, EventArgs e)
        {
            //string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);

            //try
            //{
            //    //데이터를 다운로드 하시겠습니까?
            //    if (this.ShowDialog("데이터를 다운로드 하시겠습니까?", Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
            //    {
            //        DBHelper helper = new DBHelper(false);

            //        helper.ExecuteNoneQuery("ERPDN_ORDER_T1", CommandType.StoredProcedure
            //            , helper.CreateParameter("AS_PLANTCODE", DbType.String, sPlantCode));

            //        base.DoInquire();
            //    }
            //    else
            //        return;
            //}
            //catch (Exception ex)
            //{
            //    this.ShowDialog(ex.ToString());
            //}
        }
    }
}
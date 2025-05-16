using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;

namespace WIZ.PP
{
    public partial class PP6000 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        Color gridRowSelectorColor = Color.White;
        UltraGridUtil _GridUtil = new UltraGridUtil();
        private Color[] listColor = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.YellowGreen, Color.Tomato
                                                , Color.SeaGreen, Color.RoyalBlue, Color.Purple, Color.OrangeRed, Color.Navy, Color.MediumTurquoise
                                                , Color.MediumSlateBlue, Color.LightCoral, Color.Gold, Color.Silver, Color.Magenta};

        #endregion

        #region < CONSTRUCTOR >
        public PP6000()
        {
            InitializeComponent();
        }
        #endregion

        #region < PP6000_Load >
        private void PP6000_Load(object sender, EventArgs e)
        {
            #region --- 그리드 세팅 ---
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "RecDate", "수불일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DayNight", "주야구분", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OrderNo", "지시번호", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GroupKey", "그룹 LOTNO", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BoxCount", "Box수량", false, GridColDataType_emu.Integer, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StartLotNo", "첫 LOTNO", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EndLotNo", "마지막 LOTNO", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StartDate", "작업시작시간", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EndDate", "작업완료시간", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdQty", "입고수량", false, GridColDataType_emu.Integer, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            //     ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 50;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "RecDate", "수불일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DayNight", "주야구분", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PlantCode", "공장", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WorkCenterCode", "작업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WorkCenterName", "작업장명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OrderNo", "지시번호", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PlanNo", "지시번호", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "GroupKey", "그룹 LOTNO", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LotNo", "Lot", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "StartDate", "작업시작시간", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EndDate", "작업완료시간", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ProdQtyCal", "계산치", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ProdQtyReal", "실측치", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ProdQtyMan", "입력치", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ProdQty", "입고수량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MachCount", "설비카운트", false, GridColDataType_emu.Integer, 110, 100, Infragistics.Win.HAlign.Right, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WorkerNM", "작업자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ReWorkFlag", "재작업여부", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Status", "상태", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MainWorker", "메인작업자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ProcFlag", "처리상태", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Maker", "등록자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Editor", "수정자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            //     ///row number
            grid2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid2.DisplayLayout.Override.RowSelectorWidth = 50;
            grid2.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid2.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            gridRowSelectorColor = this.grid1.DisplayLayout.Override.RowSelectorAppearance.BackColor;

            uccRecDate.Value = DateTime.Now;

            SetTimeParam();

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboDayNight, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DayNight", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "DayNight", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #region 팝업 설정
            BizTextBoxManager btbManager = new BizTextBoxManager();

            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            #endregion
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();

                grid1.DataSource = helper.FillTable("USP_PP6000_S1N", CommandType.StoredProcedure
                                               , helper.CreateParameter("pPlantCode", Convert.ToString(cboPlantCode_H.Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pWorkCenterCode", Convert.ToString(txtWorkCenterCode.Text), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pWorkCenterName", Convert.ToString(txtWorkCenterName.Text), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pOrderNo", "", DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pItemCode", Convert.ToString(txtItemCode.Text), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pItemName", Convert.ToString(txtItemName.Text), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pSLot", "", DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pELot", "", DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pStartDate", Convert.ToDateTime(tseStart.Value).ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pEndDate", Convert.ToDateTime(tseEnd.Value).ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pRecDate", uccRecDate.Value.ToString().Substring(0, 10), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pDayNight", Convert.ToString(cboDayNight.Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pWorkerNM", Convert.ToString(txtWorkerNM.Text), DbType.String, ParameterDirection.Input));

                grid1.DataBinds();
                grid2.DataSource = helper.FillTable("USP_PP6000_S1N_2"
                                               , CommandType.StoredProcedure
                                               , helper.CreateParameter("pPlantCode", Convert.ToString(cboPlantCode_H.Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pWorkCenterCode", Convert.ToString(txtWorkCenterCode.Text), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pWorkCenterName", Convert.ToString(txtWorkCenterName.Text), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pOrderNo", "", DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pItemCode", Convert.ToString(txtItemCode.Text), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pItemName", Convert.ToString(txtItemName.Text), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pSLot", "", DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pELot", "", DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pStartDate", Convert.ToDateTime(tseStart.Value).ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pEndDate", Convert.ToDateTime(tseEnd.Value).ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pRecDate", uccRecDate.Value.ToString().Substring(0, 10), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pDayNight", Convert.ToString(cboDayNight.Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("pWorkerNM", Convert.ToString(txtWorkerNM.Text), DbType.String, ParameterDirection.Input));

                grid2.DataBinds();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            if (this.grid1.Focused)
            {
                this.grid1.DeleteRow();
            }
            else if (this.grid2.Focused)
            {
                this.grid2.DeleteRow();
            }
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid2.chkChange();
            if (dt == null)
                return;
            string RS_CODE = string.Empty;
            string RS_MSG = string.Empty;
            DBHelper helper = new DBHelper("", true);
            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                // UltraGridUtil.DataRowDelete(this.grid1);
                //this.grid1.UpdateData();
                //helper.Transaction = helper._sConn.BeginTransaction();

                foreach (DataRow drRow in ((DataTable)grid1.DataSource).Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlanNo"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "지시번호 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_PP6000_D1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", DBHelper.gGetCode(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("WorkCenterCode", DBHelper.gGetCode(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ItemCode", DBHelper.gGetCode(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("LotNo", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("GroupKey", DBHelper.gGetCode(drRow["GroupKey"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid2.SetRowError(drRow, "PlantCode error!");
                            continue;
                        }
                    }

                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_PP6000_D1", CommandType.StoredProcedure//, ref RS_CODE, ref RS_MSG
                                                                   , helper.CreateParameter("PlantCode", DBHelper.gGetCode(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("WorkCenterCode", DBHelper.gGetCode(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ItemCode", DBHelper.gGetCode(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("LotNo", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("GroupKey", DBHelper.gGetCode(drRow["GroupKey"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 추가/수정
                            helper.ExecuteNoneQuery("USP_PP6000_U1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", DBHelper.gGetCode(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("WorkCenterCode", DBHelper.gGetCode(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ItemCode", DBHelper.gGetCode(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("LotNo", DBHelper.gGetCode(drRow["LotNo"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("Status", DBHelper.gGetCode(drRow["Status"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ReworkFlag", DBHelper.gGetCode(drRow["ReWorkFlag"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ProdQty", DBHelper.nvlDouble(drRow["ProdQty"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ProdQtyMan", DBHelper.nvlDouble(drRow["ProdQtyMan"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ProdQtyReal", DBHelper.nvlDouble(drRow["ProdQtyReal"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ProdQtyCal", DBHelper.nvlDouble(drRow["ProdQtyCal"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("OrderNo", DBHelper.gGetCode(drRow["OrderNo"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MainWorker", DBHelper.gGetCode(drRow["MainWorker"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ProcFlag", DBHelper.gGetCode(drRow["ProcFlag"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PlanNo", DBHelper.gGetCode(drRow["PlanNo"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("GroupKey", DBHelper.gGetCode(drRow["GroupKey"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("WorkerNM", DBHelper.gGetCode(drRow["WorkerNM"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MachCount", DBHelper.nvlDouble(drRow["MachCount"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("Worker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid2.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid2.SetAcceptChanges("PlantCode");
                helper.Commit();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >



        private void btnDisChange_Click(object sender, EventArgs e)
        {
            if (btnDisChange.Text == "세로보기") // 가로보기일 경우
            {
                //grid2.Dock = DockStyle.Fill;
                grid2.Width = gbxBody.Width / 2 - 50;
                spilt.Dock = DockStyle.Left;
                grid1.Dock = DockStyle.Left;
                //gbxSave.Dock = DockStyle.Top;
                //gbxSave.Height = 177;
                btnDisChange.Text = "가로보기";
            }
            else            // 세로보기일 경우
            {
                //grid2.Dock = DockStyle.Bottom;
                grid1.Height = (gbxBody.Height / 3);
                grid1.Dock = DockStyle.Top;
                spilt.Dock = DockStyle.Top;
                //gbxSave.Dock = DockStyle.Left;
                //gbxSave.Width = 300;

                btnDisChange.Text = "세로보기";
            }
        }

        private void grid1_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            int iIdx = 0;

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                grid1.Rows[i].RowSelectorAppearance.BackColor = gridRowSelectorColor;
            }

            for (int i = 0; i < grid2.Rows.Count; i++)
            {
                grid2.Rows[i].RowSelectorAppearance.BackColor = gridRowSelectorColor;
            }

            foreach (UltraGridRow ugr in grid1.Selected.Rows)
            {
                int iColorIdx = iIdx % listColor.Length;

                ugr.RowSelectorAppearance.BackColor = listColor[iColorIdx];

                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    if (Convert.ToString(grid2.Rows[i].Cells["PlantCode"].Value) == Convert.ToString(ugr.Cells["PlantCode"].Value)
                        && Convert.ToString(grid2.Rows[i].Cells["WorkCenterCode"].Value) == Convert.ToString(ugr.Cells["WorkCenterCode"].Value)
                        && Convert.ToString(grid2.Rows[i].Cells["ItemCode"].Value) == Convert.ToString(ugr.Cells["ItemCode"].Value)
                        && Convert.ToString(grid2.Rows[i].Cells["GroupKey"].Value) == Convert.ToString(ugr.Cells["GroupKey"].Value)
                        && Convert.ToString(grid2.Rows[i].Cells["RecDate"].Value) == Convert.ToString(ugr.Cells["RecDate"].Value)
                        && Convert.ToString(grid2.Rows[i].Cells["DayNight"].Value) == Convert.ToString(ugr.Cells["DayNight"].Value))
                    {
                        // 같은 그룹이면
                        grid2.Rows[i].RowSelectorAppearance.BackColor = listColor[iColorIdx];
                    }
                }

                iIdx++;
            }
        }

        private void uccRecDate_ValueChanged(object sender, EventArgs e)
        {
            SetTimeParam();
        }

        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의
        private void SetTimeParam()
        {
            string sJuya = Convert.ToString(cboDayNight.Value);
            DateTime dt = Convert.ToDateTime(uccRecDate.Value);

            // DB에서 받아오도록 수정해야함

            switch (sJuya)
            {
                case "D":
                    tseStart.Value = new DateTime(dt.Year, dt.Month, dt.Day, 7, 30, 00);
                    tseEnd.Value = new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 00);
                    break;
                case "N":
                    tseStart.Value = new DateTime(dt.Year, dt.Month, dt.Day, 19, 30, 00);
                    dt = dt.AddDays(1);
                    tseEnd.Value = new DateTime(dt.Year, dt.Month, dt.Day, 7, 30, 00);
                    break;
                default:
                    tseStart.Value = new DateTime(dt.Year, dt.Month, dt.Day, 7, 30, 00);
                    dt = dt.AddDays(1);
                    tseEnd.Value = new DateTime(dt.Year, dt.Month, dt.Day, 7, 30, 00);
                    break;
            }

        }
        #endregion
    }
}

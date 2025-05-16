using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;


namespace WIZ.QM
{
    public partial class QM1400 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        private bool bMoveSave = false;
        private bool bInquire2 = false;

        private bool bProdFlag = false;
        private bool bOutFlag = false;
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        UltraGridRow SelDataRow = null;
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >
        public QM1400()
        {
            InitializeComponent();

            BizTextBoxManager tBizManager = new BizTextBoxManager();

            string sUseFlag = string.Empty;
            string sLineCode = string.Empty;
            string sOPCode = string.Empty;

            tBizManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "" });
            tBizManager.PopUpAdd(txtWorkCenterCode_H, txtWorkCenterName_H, "TBM0600", new object[] { cboPlantCode_H, sOPCode, sLineCode, sUseFlag });
        }
        #endregion

        #region<QM1400_Load>
        private void QM1400_Load(object sender, EventArgs e)
        {
            #region 그리드
            #region 그리드 1
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkDate", "생산일자", true, GridColDataType_emu.YearMonthDay, 100, 30, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DayNight", "주야구분", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "완성품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "완성품명", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QTY", "수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BadType", "불량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdFlag", "1차판정", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutFlag", "판정", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            //     ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            #endregion

            #region 그리드 2
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemCode", "완성품목", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LVL", "단계", true, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LVL2", "단계", true, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CompItemCode", "자품목", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Company", "업체명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "US", "U/S", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "QTY", "수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ErrorClass", "불량유형", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ErrorCode", "불량", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ErrorDesc", "불량명", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ProdFlag", "1차판정", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OutFlag", "판정", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Remark", "비고", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DSeq", "DSeq", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MakeDate", "등록일", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Maker", "등록자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EditDate", "승인일", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Editor", "승인자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CompCnt", "거래처수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SORTCOL", "SORTCOL", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            //     ///row number
            grid2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid2.DisplayLayout.Override.RowSelectorWidth = 40;
            grid2.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid2.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #endregion
            #endregion

            #region 콤보 박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("INSPKIND");   // 사내/외주
            rtnDtTemp.Rows.Add(new object[] { "", "" });
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ProdFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "OutFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT");
            WIZ.Common.FillComboboxMaster(this.cboDayNight_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DayNight", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ErrorClass");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ErrorClass", rtnDtTemp, "CODE_ID", "CODE_NAME");

            SetAuthority();

            grid2.Columns["ProdFlag"].CellActivation = bProdFlag ? Activation.AllowEdit : Activation.NoEdit;
            grid2.Columns["OutFlag"].CellActivation = bOutFlag ? Activation.AllowEdit : Activation.NoEdit;

            #region 팝업 설정            
            BizGridManager tGridManager;
            tGridManager = new BizGridManager(grid1);
            tGridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });
            tGridManager.PopUpAdd("WorkCenterCode", "WorkCenterName", "TBM0600", new string[] { "PlantCode", "", "", "" });
            BizGridManager tGridManager2;
            tGridManager2 = new BizGridManager(grid2);
            tGridManager2.PopUpAdd("ErrorCode", "ErrorDesc", "TBM2500", new string[] { "ErrorClass", "", "", "PlantCode", "ItemCode", "CompItemCode", "FALSE" }, new string[] { "ErrorClass|ErrorClass" }, new string[] { "Y" });


            #endregion

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
                if (grid2.Rows.Count > 0)
                {
                    if (((DataTable)(grid2.DataSource)).GetChanges() != null)
                    {
                        DialogResult dr = this.ShowDialog(Common.getLangText("변경된 사항이 있습니다. 저장하고 계속 진행하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.YESNOCANCEL);

                        if (dr == System.Windows.Forms.DialogResult.Cancel)
                        {
                            return;
                        }

                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            bMoveSave = true;
                            DoSave();
                            bMoveSave = false;
                        }
                    }
                }

                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);  // 공장코드
                string sWorkCenterCode = txtWorkCenterCode_H.Text;
                string sWorkCenterName = txtWorkCenterName_H.Text;
                string sItemCode = txtItemCode_H.Text;
                string sItemName = txtItemName_H.Text;
                string sStartDate = DBHelper.nvlDateTime(CboStartDate_H.Value).ToString("yyyy-MM-dd");
                string sEndDate = DBHelper.nvlDateTime(CboEndDate_H.Value).ToString("yyyy-MM-dd");
                string sDayNight = DBHelper.nvlString(cboDayNight_H.Value);

                rtnDtTemp = helper.FillTable("USP_QM1400_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("pPlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("pWorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("pWorkCenterName", sWorkCenterName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("pItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("pItemName", sItemName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("pDayNight", sDayNight, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("pStartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("pEndDate", sEndDate, DbType.String, ParameterDirection.Input));
                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();
                ((DataTable)grid2.DataSource).Rows.Clear();
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

        private void DoInquire2()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                UltraGridRow dr = SelDataRow;

                rtnDtTemp = helper.FillTable("USP_QM1400_S1", CommandType.StoredProcedure
                                                               , helper.CreateParameter("pPlantCode", Convert.ToString(dr.Cells["PlantCode"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("pWorkCenterCode", Convert.ToString(dr.Cells["WorkCenterCode"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("pItemCode", Convert.ToString(dr.Cells["ItemCode"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("pRecDate", Convert.ToString(dr.Cells["WorkDate"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("pDayNight", Convert.ToString(dr.Cells["DayNight"].Value), DbType.String, ParameterDirection.Input));

                foreach (DataRow tdr in rtnDtTemp.Rows)
                {
                    string sItemCode = Convert.ToString(tdr["CompItemCode"]);

                    DataRow[] ttdr = rtnDtTemp.Select("ItemCode = '" + sItemCode + "' ");

                    if (ttdr.Length == 1)
                    {
                        tdr["Company"] = Convert.ToString(ttdr[0]["CustName"]);
                    }
                }

                rtnDtTemp.AcceptChanges();

                grid2.DataSource = rtnDtTemp;

                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    string sOutFlag = Convert.ToString(grid2.Rows[i].Cells["OutFlag"].Value);

                    grid2.Rows[i].Cells["OutFlag"].Activation = bOutFlag ? Activation.AllowEdit : Activation.NoEdit;

                    if (sOutFlag != "")
                    {
                        grid2.Rows[i].Cells["QTY"].Activation = Activation.NoEdit;
                        grid2.Rows[i].Cells["Company"].Activation = Activation.NoEdit;
                        grid2.Rows[i].Cells["ErrorCode"].Activation = Activation.NoEdit;
                        grid2.Rows[i].Cells["ErrorDesc"].Activation = Activation.NoEdit;
                    }

                    string sItemCode = Convert.ToString(grid2.Rows[i].Cells["CompItemCode"].Value);

                    DataRow[] ttdr = rtnDtTemp.Select("ItemCode = '" + sItemCode + "' ");

                    if (ttdr.Length <= 1)
                    {
                        grid2.Rows[i].Cells["Company"].Activation = Activation.NoEdit;
                    }
                    else
                    {
                        // 선택된 품목에 연결된 공급처가 많을 경우
                        ValueList list = grid2.DisplayLayout.ValueLists.Add();

                        for (int j = 0; i < ttdr.Length; i++)
                        {
                            list.ValueListItems.Add(ttdr[i]["CustCode"], Convert.ToString(ttdr[i]["CustName"]));
                        }

                        grid2.Rows[i].Cells["Company"].ValueList = list;
                        grid2.Rows[i].Cells["Company"].Activation = Activation.AllowEdit;
                    }
                }

                grid2.DataBinds();

                ClosePrgFormNew();
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
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();

            if (grid1.Focused)
            {
                int iRow = _GridUtil.AddRow(this.grid1, (DataTable)this.grid1.DataSource);

                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkDate");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "DayNight");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkCenterCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkCenterName");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ItemCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ItemName");
            }
            else if (grid2.Focused)
            {
                if (grid2.Rows.Count >= 1)
                {
                    int iRow = _GridUtil.AddRow(this.grid2, (DataTable)this.grid2.DataSource);

                    grid2.Rows[iRow].Cells["ItemCode"].Value = grid2.Rows[iRow - 1].Cells["ItemCode"].Value;
                    grid2.Rows[iRow].Cells["LVL"].Value = grid2.Rows[iRow - 1].Cells["LVL"].Value;
                    grid2.Rows[iRow].Cells["LVL2"].Value = grid2.Rows[iRow - 1].Cells["LVL2"].Value;
                    grid2.Rows[iRow].Cells["CompItemCode"].Value = grid2.Rows[iRow - 1].Cells["CompItemCode"].Value;
                    grid2.Rows[iRow].Cells["Company"].Value = grid2.Rows[iRow - 1].Cells["Company"].Value;
                    grid2.Rows[iRow].Cells["US"].Value = grid2.Rows[iRow - 1].Cells["US"].Value;
                    grid2.Rows[iRow].Cells["CompCnt"].Value = grid2.Rows[iRow - 1].Cells["CompCnt"].Value;
                    grid2.Rows[iRow].Cells["SORTCOL"].Value = grid2.Rows[iRow - 1].Cells["SORTCOL"].Value;
                    grid2.Rows[iRow].Cells["PlantCode"].Value = grid2.Rows[iRow - 1].Cells["PlantCode"].Value;

                    UltraGridUtil.ActivationAllowEdit(this.grid2, "QTY");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "Company");

                    //if (bProdFlag)
                    //    UltraGridUtil.ActivationAllowEdit(this.grid1, "ProdFlag", iRow);
                    if (bOutFlag)
                        UltraGridUtil.ActivationAllowEdit(this.grid2, "OutFlag");
                }
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            DBHelper helper = new DBHelper(false);

            base.DoDelete();
            bool bNotDelete = false;
            string sOutFlag;
            int sProdFlag;


            try
            {
                if (grid1.Focused)
                {
                    for (int i = 0; i < grid1.Selected.Rows.Count; i++)
                    {
                        sProdFlag = Convert.ToInt32(grid1.Selected.Rows[i].Cells["ProdFlag"].Value);
                        if (sProdFlag > 0)
                        {
                            bNotDelete = true;
                            continue;
                        }
                        else
                        {
                            grid1.Selected.Rows[i--].Delete(false);
                        }
                    }

                    if (bNotDelete)
                        SetStatusBarMessage("이미 확정처리된 항목은 삭제할 수 없습니다.");
                }
                else if (grid2.Focused)
                {
                    for (int i = 0; i < grid2.Selected.Rows.Count; i++)
                    {
                        sOutFlag = Convert.ToString(grid2.Selected.Rows[i].Cells["OutFlag"].Value);
                        if (sOutFlag != "")
                        {
                            if (grid2.Selected.Rows[i].Cells["OutFlag"].Activation == Activation.NoEdit)
                            {
                                bNotDelete = true;
                                continue;
                            }
                        }

                        if (Convert.ToString(grid2.Selected.Rows[i].Cells["ProdFlag"].Value) != "")
                        {
                            if (grid2.Selected.Rows[i].Cells["ProdFlag"].Activation == Activation.NoEdit)
                            {
                                bNotDelete = true;
                                continue;
                            }
                        }

                        grid2.Selected.Rows[i].Cells["QTY"].Value = 0;
                    }

                    if (bNotDelete)
                        SetStatusBarMessage("이미 확정처리된 항목은 삭제할 수 없습니다.");
                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                this.Focus();

                if (bMoveSave)
                {
                    if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        CancelProcess = true;
                        return;
                    }
                }

                base.DoSave();

                UltraGridUtil.DataRowDelete(this.grid2);
                this.grid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

                UltraGridRow dr = SelDataRow;

                foreach (DataRow drRow in ((DataTable)grid2.DataSource).Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Modified:
                        case DataRowState.Added:
                            #region 추가/수정

                            helper.ExecuteNoneQuery("USP_QM1400_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("pPlantCode", Convert.ToString(dr.Cells["PlantCode"].Value), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pWorkDate", Convert.ToString(dr.Cells["WorkDate"].Text), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pDayNight", Convert.ToString(dr.Cells["DayNight"].Value), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pWorkCenterCode", Convert.ToString(dr.Cells["WorkCenterCode"].Value), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pItemCode", Convert.ToString(dr.Cells["ItemCode"].Value), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pComponent", Convert.ToString(drRow["CompItemCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pStep", Convert.ToInt32(drRow["LVL"]), DbType.Int32, ParameterDirection.Input)
                            , helper.CreateParameter("pCompQty", Convert.ToDouble(drRow["US"]), DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("pErrorCode", Convert.ToString(drRow["ErrorCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pQty", Convert.ToDouble(drRow["QTY"]), DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("pCustCode", Convert.ToString(drRow["Company"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pProdFlag", Convert.ToString(drRow["ProdFlag"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pOutFlag", Convert.ToString(drRow["OutFlag"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pWorker", this.WorkerID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pRemark", Convert.ToString(drRow["Remark"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pDSeq", Convert.ToInt32(drRow["DSeq"]), DbType.Int32, ParameterDirection.Input)
                            , helper.CreateParameter("pSortCol", Convert.ToString(drRow["SORTCOL"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                }

                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

                foreach (DataRow drRow in ((DataTable)grid1.DataSource).Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_QM1400_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("pPlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pWorkDate", drRow["WorkDate"], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pWorkCenterCode", Convert.ToString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pDayNight", Convert.ToString(drRow["DayNight"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pWorker", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                }

                helper.Commit();

                DoInquire2();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region 버튼 이벤트

        private void SetAuthority()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                helper.FillTable("USP_QM1400_GetAuth", CommandType.StoredProcedure
                                                     , helper.CreateParameter("pWorker", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("pValue", DbType.String, ParameterDirection.Output, "", 100));



                //string s = DBHelper.nvlString(param[1].Value);

                //bProdFlag = s[0] == '1';
                //bOutFlag = s[1] == '1';
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
        #endregion

        #region<METHOD AREA>
        private void grid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (bInquire2) return;

            try
            {
                if (e.Row != null)
                {
                    bInquire2 = true;

                    if (((DataTable)(grid2.DataSource)).GetChanges() != null)
                    {
                        DialogResult dr = this.ShowDialog(Common.getLangText("변경된 사항이 있습니다. 저장하고 계속 진행하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.YESNOCANCEL);

                        if (dr == System.Windows.Forms.DialogResult.Cancel)
                        {
                            return;
                        }

                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            bMoveSave = true;
                            DoSave();
                            bMoveSave = false;
                        }
                    }

                    bool bFind = true;

                    if (((DataTable)grid1.DataSource).Rows[e.Row.Index].RowState == DataRowState.Added)
                    {
                        foreach (UltraGridColumn dc in grid1.Columns)
                        {
                            if (dc.CellAppearance.TextHAlign != HAlign.Right)
                            {
                                if ("" == Convert.ToString(e.Row.Cells[dc.Key].Value))
                                {
                                    bFind = false;
                                    break;
                                }
                            }
                        }
                    }

                    if (bFind)
                    {
                        SelDataRow = e.Row;

                        DoInquire2();
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                bInquire2 = false;
            }
        }

        private void grid2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                //bProdFlag
                if (grid2.ActiveCell.Column.Key == "ProdFlag")
                {
                    if (bProdFlag)
                    {
                        grid2.ActiveCell.Value = "";
                    }
                }

                if (grid2.ActiveCell.Column.Key == "OutFlag")
                {
                    if (bOutFlag)
                    {
                        grid2.ActiveCell.Value = "";
                    }
                }
            }
        }

        private void grid2_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (e.Cell.Column.Key == "Company")
            {
                SetCompanyPopup(e.Cell);
            }
        }

        private void SetCompanyPopup(UltraGridCell cell)
        {
            try
            {
                if (cell.Activation == Activation.AllowEdit)
                {
                    if (cell.ValueList == null)
                    {
                        // 거래선 POP-UP 창 처리
                        PopUpManager pu = new PopUpManager();
                        DataTable DtTemp = pu.OpenPopUp("TBM300", new string[] { "", "", Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value), "V", "" }); // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)

                        if (DtTemp != null && DtTemp.Rows.Count > 0)
                        {
                            grid2.ActiveRow.Cells["Company"].Value = "[" + Convert.ToString(DtTemp.Rows[0]["CustCode"]) + "] " + Convert.ToString(DtTemp.Rows[0]["CustName"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "QTY", "BadType" });

        }
        #endregion
    }
}

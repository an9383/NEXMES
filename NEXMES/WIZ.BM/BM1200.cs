#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM1200
//   Form Name    : BOM 관리
//   Name Space   : 
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM1200 : WIZ.Forms.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        private DataTable DtChange = null;

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager;
        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        int check = 0;
        #endregion


        #region < CONSTRUCTOR >
        public BM1200()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void BM1200_Load(object sender, EventArgs e)
        {
            this.plantCode = CModule.GetAppSetting("Site", "10");

            BizGridManager bizGrid = new BizGridManager(grid1);

            bizGrid.PopUpAdd("ItemCode", "ITEMNAME", "TBM0100", new string[] { plantCode, "" });
            bizGrid.PopUpAdd("COMPONENT", "COMPONENTNAME", "TBM0100", new string[] { plantCode, "" });

            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 180, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "생산품목ⓟ", true, GridColDataType_emu.VarChar, 130, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "생산품목", true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BASEQTY", "생산수량", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "생산단위", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "COMPONENT", "하위품목ⓟ", true, GridColDataType_emu.VarChar, 130, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "COMPONENTNAME", "하위품목", true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "COMPONENTQTY", "하위부품수량", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "COMPONENTUNIT", "하위부품단위", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LGORT_IN", "입고위치", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LGORT_OUT", "출고위치", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부ⓒ", true, GridColDataType_emu.VarChar, 80, 120, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 170, 120, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 170, 120, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["COMPONENT"].Header.Appearance.ForeColor = Color.SkyBlue;

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "RN", "순번", true, GridColDataType_emu.VarChar, 40, 120, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LVL", "레벨", true, GridColDataType_emu.VarChar, 60, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "생산품목", true, GridColDataType_emu.VarChar, 130, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "생산품명", true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "BASEQTY", "생산수량", true, GridColDataType_emu.VarChar, 70, 120, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "생산단위", true, GridColDataType_emu.VarChar, 70, 120, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "COMPONENT", "투입품목", true, GridColDataType_emu.VarChar, 130, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "COMPONENTNAME", "투입품명", true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "COMPONENTQTY", "투입수량", true, GridColDataType_emu.VarChar, 70, 120, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "COMPONENTUNIT", "투입단위", true, GridColDataType_emu.VarChar, 70, 120, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LGORT_IN", "입고위치", true, GridColDataType_emu.VarChar, 160, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LGORT_OUT", "출고위치", true, GridColDataType_emu.VarChar, 160, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LASTEDITDATE", "최종변경일시", true, GridColDataType_emu.VarChar, 170, 120, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            //    grid1.DisplayLayout.Bands[0].Columns["COMPONENTQTY"].MaskInput = "#.###";
            grid1.DisplayLayout.Bands[0].Columns["COMPONENTQTY"].Format = "#,##0.000";
            grid2.DisplayLayout.Bands[0].Columns["BASEQTY"].Format = "#,##0.000";
            grid2.DisplayLayout.Bands[0].Columns["COMPONENTQTY"].Format = "#,##0.000";
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  // 사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UNITCODE");     //단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "COMPONENTUNIT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE");     //입고위치, 출고위치
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LGORT_IN", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LGORT_OUT", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "LGORT_IN", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "LGORT_OUT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion

            #region ▶ POP-UP ◀
            btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "" });
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode_H.Select();
            cboPlantCode_H.Value = plantCode;
            check = 0;
            #endregion
        }
        #endregion


        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DoFind();
        }

        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();
                check = 0;
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                string sItemCode = txtItemCode_H.Text.Trim();
                string SITEMNAME = txtItemName_H.Text.Trim();
                string LS_TABIDX = string.Empty;
                if (tabControl1.SelectedTab.Index == 0) { LS_TABIDX = "TAB1"; } else { LS_TABIDX = "TAB2"; }

                if (LS_TABIDX == "TAB2" && sItemCode == "")
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("품목을 입력한 후, 검색해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
                rtnDtTemp = helper.FillTable("USP_BM1200_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("TABIDX", LS_TABIDX, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ITEMNAME", SITEMNAME, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                //MSKWON(2015.10.01) - 오류 메세지 처리 추가
                if (helper.RSCODE.Trim() == "E")
                { // 조회 처리시 오류가 발생했을 경우
                    this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
                else
                {
                    // 성공정으로 조회 처리 했을 경우
                    if (LS_TABIDX == "TAB1")
                    {
                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            grid1.DataSource = rtnDtTemp;
                            grid1.DataBinds(rtnDtTemp);
                        }
                        else
                        {
                            _GridUtil.Grid_Clear(grid1);
                            // 조회할 데이터가 없습니다.

                            this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        DtChange = rtnDtTemp;

                        for (int i = 0; i < grid1.Columns.Count; i++)
                        {
                            grid1.Columns[grid1.Columns[i].Key].MergedCellStyle = MergedCellStyle.Never;
                        }

                        _GridUtil.SetColumnMerge(this, grid1, "PLANTCODE");
                    }
                    else
                    {
                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            grid2.DataSource = rtnDtTemp;
                            grid2.DataBinds(rtnDtTemp);

                            grid2.DisplayLayout.Bands[0].Columns["LVL"].MergedCellStyle = MergedCellStyle.Always;
                            grid2.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                            grid2.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;
                            grid2.DisplayLayout.Bands[0].Columns["BASEQTY"].MergedCellStyle = MergedCellStyle.Always;
                            grid2.DisplayLayout.Bands[0].Columns["UNITCODE"].MergedCellStyle = MergedCellStyle.Always;
                        }
                        else
                        {
                            _GridUtil.Grid_Clear(grid1);


                            this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                            return;
                        }
                    }

                    grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.NoEdit;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].CellActivation = Activation.NoEdit;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].CellActivation = Activation.NoEdit;
                    grid1.DisplayLayout.Bands[0].Columns["COMPONENT"].CellActivation = Activation.NoEdit;
                    grid1.DisplayLayout.Bands[0].Columns["COMPONENTNAME"].CellActivation = Activation.NoEdit;
                    grid1.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Activation.NoEdit;
                    grid1.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Activation.NoEdit;
                    grid1.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Activation.NoEdit;
                    grid1.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Activation.NoEdit;

                    grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellAppearance.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                throw ex;
            }
            finally
            {
                //helper.Close();
                helper.Close();
                //if (param != null) { param = null; }
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();

                //if (grid1.IsActivate)
                string LS_TABIDX = string.Empty;
                if (tabControl1.SelectedTab.Index == 0) { LS_TABIDX = "TAB1"; } else { LS_TABIDX = "TAB2"; }
                if (LS_TABIDX == "TAB1")
                {

                    // iRow = this.grid1.InsertRow();
                    this.grid1.InsertRow();
                    // int iRow = _GridUtil.AddRow(this.grid1);
                    this.grid1.SetDefaultValue("PLANTCODE", this.plantCode);
                    this.grid1.SetDefaultValue("USEFLAG", "Y");

                    grid1.ActiveRow.Cells["MAKER"].Activation = Activation.Disabled;
                    grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.Disabled;
                    grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.Disabled;
                    grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.Disabled;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            if (grid1.IsActivate) this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            if (grid1.IsActivate) Grid1ToolAct();
        }
        #endregion

        private void Grid1ToolAct()
        {

            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;

            DBHelper helper = new DBHelper("", true);

            try
            {
                string sPlantCode = "";
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();
                //   int li_cnt = 0;
                // UltraGridUtil.DataRowDelete(this.grid1);
                // this.grid1.UpdateData();

                foreach (DataRow drRow in ((DataTable)grid1.DataSource).GetChanges().Rows)  // .GetChanges().Rows = 변경된 Rows 만 작업
                {
                    int iDot = 0, iDot2 = 0;
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["ITEMCODE"].ToString().Trim() == "")
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("생산 품목을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (drRow["COMPONENT"].ToString().Trim() == "")
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("하위 구성 품목을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow["ITEMCODE"].ToString().Trim() == drRow["COMPONENT"].ToString().Trim())
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("생산 품목과 하위 구성 품목이 같을 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow.RowState == DataRowState.Added || drRow.RowState == DataRowState.Modified)
                        {
                            if (drRow["BASEQTY"].ToString().Trim() == "")
                            {
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("생산수량을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (drRow["COMPONENTQTY"].ToString().Trim() == "")
                            {
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("하위 부품 수량을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            iDot = Convert.ToString(drRow["BASEQTY"]).IndexOf('.');
                            iDot2 = Convert.ToString(drRow["COMPONENTQTY"]).IndexOf('.');

                            if (drRow["BASEQTY"].ToString().Substring(iDot + 1).Length > 3)
                            {
                                // grid1.SetRowError(drRow, "생산기준수량은 소수점 둘째 자리까지만 입력가능합니다. (예) 12.01");
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("생산기준수량은 소수점 셋째 자리까지만 입력가능합니다. (예) 12.011", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }
                            if (drRow["COMPONENTQTY"].ToString().Substring(iDot2 + 1).Length > 3)
                            {
                                //grid1.SetRowError(drRow, "하위구성부품수량은 소수점 둘째 자리까지만 입력가능합니다. (예) 12.01");
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("하위구성부품수량은 소수점 셋째 자리까지만 입력가능합니다. (예) 12.011", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            sPlantCode = Convert.ToString(drRow["PLANTCODE"]);
                            helper.ExecuteNoneQuery("USP_BM1200_D1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("COMPONENT", Convert.ToString(drRow["COMPONENT"]), DbType.String, ParameterDirection.Input));

                            drRow.Delete();
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM1200_I1", CommandType.StoredProcedure
                                                  , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("ITEMCODE", drRow["ITEMCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("COMPONENT", drRow["COMPONENT"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("BASEQTY", drRow["BASEQTY"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("UNITCODE", drRow["UNITCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("COMPONENTQTY", drRow["COMPONENTQTY"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("COMPONENTUNIT", drRow["COMPONENTUNIT"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("LGORT_IN", drRow["LGORT_IN"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("LGORT_OUT", drRow["LGORT_OUT"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("USEFLAG", drRow["USEFLAG"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                  );

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            sPlantCode = Convert.ToString(drRow["PLANTCODE"]);
                            helper.ExecuteNoneQuery("USP_BM1200_U1", CommandType.StoredProcedure
                                                  , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("ITEMCODE", drRow["ITEMCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("COMPONENT", drRow["COMPONENT"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("BASEQTY", drRow["BASEQTY"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("UNITCODE", drRow["UNITCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("COMPONENTQTY", drRow["COMPONENTQTY"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("COMPONENTUNIT", drRow["COMPONENTUNIT"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("LGORT_IN", drRow["LGORT_IN"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("LGORT_OUT", drRow["LGORT_OUT"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("USEFLAG", drRow["USEFLAG"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                  );


                            #endregion
                            break;
                    }
                    //  grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                    // if (helper.RSCODE == "E") { li_cnt = 1; }
                }
                if (helper.RSCODE != "S")
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    return;
                }
                ((DataTable)grid1.DataSource).AcceptChanges();
                helper.Commit();
                //  if (li_cnt == 0) { DoInquire(); } 
                DoInquire();

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


        private void grid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.grid1.Rows.Count == 0) return;
            if (((WIZ.Control.Grid)(sender)).ActiveCell == null) return;
            //숫자 그리드 헤더 컬럼명 찾기
            if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "BASEQTY" ||
                ((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "COMPONENTQTY")
                //숫자,백스페이스만 입력받는다.
                //if (!(Char.IsDigit(e.KeyChar)) || e.KeyChar == Convert.ToChar(Keys.Back)) //8:백스페이스,45:마이너스,46:소수점
                if (e.KeyChar == 46)
                {
                    if (check == 1)
                    {
                        e.Handled = true;
                    }
                    check = 1;
                }
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8 && e.KeyChar != 13)
            {
                this.ShowDialog(Common.getLangText("숫자만 입력 가능합니다.", "MSG"));
                e.Handled = true;
            }
        }

        private void grid1_Click(object sender, EventArgs e)
        {
            txtItemCode_H.Value = "";
            check = 0;
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            DataTable dt = grid1.chkChange();
            if (dt == null)
            {
                txtItemCode_H.Value = this.grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
                tabControl1.SelectedTab = tabControl1.Tabs[1];
                DoInquire();
                return;
            }
            foreach (DataRow drRow in ((DataTable)grid1.DataSource).GetChanges().Rows)
                switch (drRow.RowState)
                {
                    case DataRowState.Added:
                        this.ShowDialog(Common.getLangText("저장하신 후, 더블클릭해주세요.", "MSG"));
                        return;
                }


        }

        private void grid1_AfterCellActivate(object sender, EventArgs e)
        {
            check = 0;
        }

        private void grid2_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Appearance.BackColor = Color.White;
        }

        private void grid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            CustomMergedCellEvalutor CM1 = new CustomMergedCellEvalutor("LVL", "ITEMCODE");

            e.Layout.Bands[0].Columns["LVL"].MergedCellEvaluator = CM1;
            e.Layout.Bands[0].Columns["ITEMCODE"].MergedCellEvaluator = CM1;
            e.Layout.Bands[0].Columns["ITEMNAME"].MergedCellEvaluator = CM1;
            e.Layout.Bands[0].Columns["BASEQTY"].MergedCellEvaluator = CM1;
            e.Layout.Bands[0].Columns["UNITCODE"].MergedCellEvaluator = CM1;
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

            //        helper.ExecuteNoneQuery("ERPDN_BOM_T1", CommandType.StoredProcedure
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

    public class CustomMergedCellEvalutor : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
    {
        string Col1 = string.Empty;
        string Col2 = string.Empty;

        public CustomMergedCellEvalutor(string pCol1, string pCol2)
        {
            Col1 = pCol1;
            Col2 = pCol2;
        }

        public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1,
                                  Infragistics.Win.UltraWinGrid.UltraGridRow row2,
                                  Infragistics.Win.UltraWinGrid.UltraGridColumn col)
        {
            try
            {
                if (row1.GetCellValue(Col1).GetType().ToString() != "System.DBNull"
                    && row2.GetCellValue(Col1).GetType().ToString() != "System.DBNull"
                    && row1.GetCellValue(Col2).GetType().ToString() != "System.DBNull"
                    && row2.GetCellValue(Col2).GetType().ToString() != "System.DBNull")
                {
                    string value1 = (string)row1.GetCellValue(Col1);
                    string value2 = (string)row2.GetCellValue(Col1);

                    string value3 = (string)row1.GetCellValue(Col2);
                    string value4 = (string)row2.GetCellValue(Col2);

                    return (value1 + value3) == (value2 + value4);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}





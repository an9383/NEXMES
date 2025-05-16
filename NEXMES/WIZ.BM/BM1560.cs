#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID        : BM1560
//   Form Name      : 검사항목별 측정항목 관리
//   Name Space     : MHSPC.BM
//   Created Date   : 2012.10.12
//   Made By        : WIZCORE
//   Description    : 검사항목별 측정항목 관리
//   DB Table       : BM1100
//   StoreProcedure : USP_BM1560_S1(S2, I1, D1, U1)
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.BM
{
    public partial class BM1560 : WIZ.Forms.BaseMDIChildForm
    {

        #region <MEMBER AREA>
        private DataTable rtnDtTemp = new DataTable();
        private DataTable DtGrid1 = new DataTable();
        private DataTable DtGrid2 = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >
        public BM1560()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager gridManager = new BizGridManager(grid2);

            btbManager.PopUpAdd(txtLineCode, txtLineName, "TBM0500", new object[] { "", "" });
            gridManager.PopUpAdd("InspCode", "InspName", "TBM1500", new string[] { "InspCase", "InspType", "Y" }); //TBM1500 : 검사항목
        }
        #endregion

        #region<BM1560_Load>
        //폼 로드시 공장콤보박스 값 설정
        private void BM1560_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "Org Code", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetColumnMerge(this, grid1, "PLANTCODE");
            _GridUtil.SetInitUltraGridBind(grid1);
            DtGrid1 = (DataTable)this.grid1.DataSource;
            #endregion

            #region Grid2 셋팅
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", true);

            // InitColumnUltraGrid 
            _GridUtil.InitColumnUltraGrid(grid2, "SEQNO", "정렬순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "Org Code", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPITEM", "측정코드", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPITEMNAME", "측정항목", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "HIPSCTLMAJORCODE", "중점관리항목코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "HIPSCTLMINORCODE", "중점관리항목세부코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCYCLE", "검사주기", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPSPEC", "검사규격", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REVISIONCODE", "보정식코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REVISIONITEM", "보정ITEM", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REVISIONNAME", "보정식명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REVISIONFORMULA", "보정공식", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


            _GridUtil.SetColumnMerge(this, grid2, "PLANTCODE");
            _GridUtil.SetInitUltraGridBind(grid2);
            DtGrid2 = (DataTable)this.grid2.DataSource;

            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("INSPCASE");     // 검사구분
            WIZ.Common.FillComboboxMaster(this.cboInspCase_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspCase", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
                DtGrid1.Clear();
                base.DoInquire();
                string sPlantCode = string.Empty;
                string sLineCode = txtLineCode.Text.Trim();
                string sInspCode = Convert.ToString(cboInspCase_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM1560_S2N", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("InspCode", sInspCode, DbType.String, ParameterDirection.Input));
                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();
                DtGrid1 = rtnDtTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            if (grid1.ActiveRow == null)
            {

                //this.ShowDialog("C:R00210", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (this.DtGrid1.Rows.Count > 0)
            {
                base.DoNew();

                int iRow = _GridUtil.AddRow(this.grid2);
                this.grid2.ActiveRow.Cells["UseFlag"].Value = "Y";
                this.grid2.ActiveRow.Cells["PlantCode"].Value = this.grid1.ActiveRow.Cells["PlantCode"].Value;
                this.grid2.ActiveRow.Cells["InspCode"].Value = this.grid1.ActiveRow.Cells["InspCode"].Value;
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            this.grid2.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            base.DoSave();
            this.grid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);
            USP_BM1560_CRUD();
        }

        public override void DoDownloadExcel()
        {
            if (this.grid2.Rows.Count == 0)
            {

                this.ShowDialog(Common.getLangText("조회 할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            this.grid2.ExportExcel();
            base.DoDownloadExcel();
        }
        #endregion

        #region<Event>
        // grid1의 행을 선택할 때마다 grid1의 코드를 기준으로 grid2의 행이 변함.
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            if (DtGrid2 != null)
                DtGrid2.Clear();

            string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PlantCode"].Value);
            string sInspCode = DBHelper.nvlString(grid1.ActiveRow.Cells["InspCode"].Value);
            string sUseFlag = DBHelper.nvlString(cboUseFlag_H.Value);



            DataTable rtnDtTemp2 = helper.FillTable("USP_BM1560_S1N", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("InspCode", sInspCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));
            if (rtnDtTemp2 != null)
            {
                grid2.DataSource = rtnDtTemp2;
                grid2.DataBind();
                DtGrid2 = rtnDtTemp2;
            }
        }
        //검사코드 변경시 검사명 클리어
        private void txtInspCode_H_ValueChanged(object sender, EventArgs e)
        {
            txtInspName.Text = string.Empty;
        }

        private void grid2_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            System.Windows.Forms.Control txtMajorCode = new System.Windows.Forms.Control();
            System.Windows.Forms.Control txtMajorName = new System.Windows.Forms.Control();
            System.Windows.Forms.Control txtMinorCode = new System.Windows.Forms.Control();
            System.Windows.Forms.Control txtMinorName = new System.Windows.Forms.Control();
            System.Windows.Forms.Control txtFlag = new System.Windows.Forms.Control();
            System.Windows.Forms.Control txtRevisionCode = new System.Windows.Forms.Control();
            System.Windows.Forms.Control txtRevisionName = new System.Windows.Forms.Control();
            System.Windows.Forms.Control txtRevisionFormula = new System.Windows.Forms.Control();

            string sPlantCode = grid2.ActiveRow.Cells["PlantCode"].Value.ToString();
            string sMajorCode = grid2.ActiveRow.Cells["HipsCTLMajorCode"].Value.ToString();
            string sMinorCode = grid2.ActiveRow.Cells["HipsCTLMinorCode"].Value.ToString();
            string sRevisionCode = grid2.ActiveRow.Cells["RevisionCode"].Value.ToString();
        }
        #endregion

        #region grid2_KeyPress
        private void grid2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((WIZ.Control.Grid)(sender)).ActiveCell == null) return;

            string Column = ((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key;

            if (Column == "RevisionName" || Column == "RevisionFormula" || Column == "HipsCTLMinorCode")
            {
                e.Handled = true;
            }
            else if (Column == "RevisionName")
            {
                if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
                {
                    e.Handled = true;
                }
                else
                {
                    grid2.ActiveRow.Cells["RevisionCode"].Value = DBNull.Value;
                    grid2.ActiveRow.Cells["RevisionFormula"].Value = null;
                }
            }
            else if (Column == "HipsCTLMajorCode")
            {
                if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
                {
                    e.Handled = true;
                }
                else
                {
                    grid2.ActiveRow.Cells["HipsCTLMinorCode"].Value = null;
                }
            }

            //숫자만 입력 받기
            if (Column == "SeqNo")
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
                {
                    e.Handled = true;
                }
            }
        }
        #endregion

        #region <METHOD AREA>
        /// <summary>
        /// 행의 신규 등록시 오류 CHECK
        /// </summary>
        private void DoNewValidate(DataRow row)
        {
            // 입력항목에 대한 VALIDATION CHECK
            //if (row["InspCode"].ToString() == "")
            // {
            //     row.RowError = this.FormInformation.GetMessage("R00000");
            //     throw (new SException(grid1.DisplayLayout.Bands[0].Columns["InspCode"].Header.Caption, "R00000", null));
            //S }
        }
        #endregion

        #region 저장/수정/삭제
        public void USP_BM1560_CRUD()
        {
            DataTable dt = grid2.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid2.SetRowError(drRow, "사업장 코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM1560_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPNAME", Convert.ToString(drRow["INSPNAME"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 신규

                            helper.ExecuteNoneQuery("USP_BM1560_I1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPITEM", Convert.ToString(drRow["INSPITEM"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPITEMNAME", Convert.ToString(drRow["INSPITEMNAME"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("HIPSCTLMAJORCODE", Convert.ToString(drRow["HIPSCTLMAJORCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("HIPSCTLMINORCODE", Convert.ToString(drRow["HIPSCTLMINORCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UNITCODE", Convert.ToString(drRow["UNITCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPCYCLE", Convert.ToString(drRow["INSPCYCLE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPSPEC", Convert.ToString(drRow["INSPSPEC"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REVISIONCODE", Convert.ToString(drRow["REVISIONCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("SEQNO", Convert.ToString(drRow["SEQNO"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM1560_U1N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPITEM", Convert.ToString(drRow["INSPITEM"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPITEMNAME", Convert.ToString(drRow["INSPITEMNAME"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("HIPSCTLMAJORCODE", Convert.ToString(drRow["HIPSCTLMAJORCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("HIPSCTLMINORCODE", Convert.ToString(drRow["HIPSCTLMINORCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("UNITCODE", Convert.ToString(drRow["UNITCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPCYCLE", Convert.ToString(drRow["INSPCYCLE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPSPEC", Convert.ToString(drRow["INSPSPEC"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("REVISIONCODE", Convert.ToString(drRow["REVISIONCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SEQNO", Convert.ToString(drRow["SEQNO"]), DbType.String, ParameterDirection.Input));
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
    }
}

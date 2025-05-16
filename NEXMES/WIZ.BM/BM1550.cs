#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID        : BM1550
//   Form Name      : 라인별 검사항목 관리
//   Name Space     : MHSPC.BM
//   Created Date   : 2012.10.12
//   Made By        : WIZCORE
//   Description    : 라인별 검사 항목을 관리
//   DB Table       : BM1100
//   StoreProcedure : USP_BM1550_S1(S2, I1, D1, U1)
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
    public partial class BM1550 : WIZ.Forms.BaseMDIChildForm
    {

        #region <MEMBER AREA>
        private DataTable rtnDtTemp = new DataTable();
        private DataTable DtGrid1 = new DataTable();
        private DataTable DtGrid2 = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();

        #endregion

        #region < CONSTRUCTOR >
        public BM1550()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager gridManager = new BizGridManager(grid2);

            btbManager.PopUpAdd(txtLineCode, txtLineName, "TBM0500", new object[] { "", "" });
            gridManager.PopUpAdd("InspCode", "InspName", "TBM1500", new string[] { "InspCase", "InspType", "Y" }); //TBM1500 : 검사항목
        }
        #endregion

        #region<BM1550_Load>
        //폼 로드시 공장콤보박스 값 설정
        private void BM1550_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.SetColumnMerge(this, grid1, "PLANTCODE");
            _GridUtil.SetInitUltraGridBind(grid1);
            DtGrid1 = (DataTable)this.grid1.DataSource;
            #endregion

            #region Grid2 셋팅
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", true);

            // InitColumnUltraGrid 
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LINECODE", "라인", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LINENAME", "라인명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OPCODE", "공정", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OPNAME", "공정명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FCLTCode", "검사설비코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사코드", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPNAME", "검사항목", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPTYPE", "검사구분", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCYCLE", "검사주기", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPSPEC", "검사규격", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "GUBUN", "구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetColumnMerge(this, grid2, "PLANTCODE");
            _GridUtil.SetInitUltraGridBind(grid2);
            DtGrid2 = (DataTable)this.grid2.DataSource;
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sLineCode = txtLineCode.Text.Trim();
                string sUseFlag = Convert.ToString(cboUseFlag_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM1550_S2N", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input));
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
                //if (helper._sConn != null) { helper._sConn.Close(); }
                helper.Close();
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

            }

            if (this.DtGrid1.Rows.Count > 0)
            {
                base.DoNew();

                int iRow = _GridUtil.AddRow(this.grid2);
                this.grid2.ActiveRow.Cells["UseFlag"].Value = "Y";
                this.grid2.ActiveRow.Cells["PlantCode"].Value = this.grid1.ActiveRow.Cells["PlantCode"].Value;
                this.grid2.ActiveRow.Cells["LineCode"].Value = this.grid1.ActiveRow.Cells["LineCode"].Value;
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
            USP_BM0520_CRUD();
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

            string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);
            string sLineCode = Convert.ToString(grid1.ActiveRow.Cells["LineCode"].Value);
            string sUseFlag = Convert.ToString(cboUseFlag_H.Value);

            DataTable rtnDtTemp2 = helper.FillTable("USP_BM1550_S1N", CommandType.StoredProcedure
                                                          , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));
            if (rtnDtTemp2 != null)
            {
                grid2.DataSource = rtnDtTemp2;
                grid2.DataBind();
                DtGrid2 = rtnDtTemp2;
            }
        }
        //라인코드 값 수정시 텍스트 클리어
        private void txtLineCode_H_ValueChanged(object sender, EventArgs e)
        {
            this.txtLineName.Text = string.Empty;
        }
        #endregion

        #region <METHOD AREA>
        /// <summary>
        /// 행의 신규 등록시 오류 CHECK
        /// </summary>
        private void DoNewValidate(DataRow row)
        {
            // 입력항목에 대한 VALIDATION CHECK
            //if (row["InspName"].ToString() == "")
            // {
            //     row.RowError = this.FormInformation.GetMessage("R00000");
            //     throw (new SException(grid1.DisplayLayout.Bands[0].Columns["InspName"].Header.Caption, "R00000", null));
            // }
        }
        #endregion

        #region 저장/수정/삭제
        public void USP_BM0520_CRUD()
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
                        if (drRow["PLANTCODE"].ToString().Trim() == "")
                        {
                            grid2.SetRowError(drRow, "사업장 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM1550_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LINECODE", Convert.ToString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 신규

                            helper.ExecuteNoneQuery("USP_BM1550_I1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LINECODE", Convert.ToString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPNAME", Convert.ToString(drRow["INSPNAME"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCODE", Convert.ToString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("FCLTCODE", Convert.ToString(drRow["FCLTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPTYPE", Convert.ToString(drRow["INSPTYPE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPCYCLE", Convert.ToString(drRow["INSPCYCLE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPSPEC", Convert.ToString(drRow["INSPSPEC"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM1550_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LINECODE", Convert.ToString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPNAME", Convert.ToString(drRow["INSPNAME"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCODE", Convert.ToString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("FCLTCODE", Convert.ToString(drRow["FCLTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPTYPE", Convert.ToString(drRow["INSPTYPE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPCYCLE", Convert.ToString(drRow["INSPCYCLE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPSPEC", Convert.ToString(drRow["INSPSPEC"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input));
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

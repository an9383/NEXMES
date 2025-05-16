#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM1500
//   Form Name    : 검사항목명 관리
//   Name Space   : WIZ.BM
//   Created Date : 2012-02-20
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.BM
{
    public partial class BM1500 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM1500()
        {
            InitializeComponent();
        }
        #endregion

        #region 폼 초기화

        private void BM1500_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern


            _GridUtil.InitColumnUltraGrid(grid1, "InspCase", "검사구분", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "검사항목코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "검사항목", false, GridColDataType_emu.VarChar, 160, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDesc", "검사항목상세", false, GridColDataType_emu.VarChar, 180, 500, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspType", "검사대상", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitType", "단위종류", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("INSPCASE");     // 검사구분
            WIZ.Common.FillComboboxMaster(this.cboInspCase_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspCase", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspType");     // 검사대상
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0130_CODE_1("I", "Y");  // 검사단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
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
                base.DoInquire();
                string inspcase = DBHelper.nvlString(cboInspCase_H.Value);
                string insptype = Convert.ToString(txtInspName.Text);
                string useflag = DBHelper.nvlString(cboUseFlag_H.Value);


                grid1.DataSource = helper.FillTable("USP_BM1500_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("@InspCase", inspcase, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("@InspType", insptype, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("@UseFlag", useflag, DbType.String, ParameterDirection.Input));


                grid1.DataBinds();
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
            try
            {
                base.DoNew();

                if (grid1.IsActivate)
                {

                    _GridUtil.AddRow(this.grid1);
                    //this.grid1.SetDefaultValue("PlantCode", "SY");

                    UltraGridUtil.ActivationAllowEdit(grid1, "InspCase");
                    UltraGridUtil.ActivationAllowEdit(grid1, "InspCode");
                    UltraGridUtil.ActivationAllowEdit(grid1, "InspName");
                    UltraGridUtil.ActivationAllowEdit(grid1, "InspDesc");
                    UltraGridUtil.ActivationAllowEdit(grid1, "InspType");
                    UltraGridUtil.ActivationAllowEdit(grid1, "UnitCode");
                    UltraGridUtil.ActivationAllowEdit(grid1, "UnitType");
                    UltraGridUtil.ActivationAllowEdit(grid1, "UseFlag");
                    UltraGridUtil.ActivationAllowEdit(grid1, "MakeDate");
                    UltraGridUtil.ActivationAllowEdit(grid1, "Maker");
                    UltraGridUtil.ActivationAllowEdit(grid1, "EditDate");
                    UltraGridUtil.ActivationAllowEdit(grid1, "Editor");
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
            this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            Grid1ToolAct();
        }
        #endregion

        #region<Grid1ToolAct()>
        private void Grid1ToolAct()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);
            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["InspCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "검사항목코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM1500_D1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@InspCase", Convert.ToString(drRow["InspCase"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@InspCode", Convert.ToString(drRow["InspCode"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM1500_I1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("InspCase", Convert.ToString(drRow["InspCase"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspCode", Convert.ToString(drRow["InspCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspName", Convert.ToString(drRow["InspName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspDesc", Convert.ToString(drRow["InspDesc"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspType", Convert.ToString(drRow["InspType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UnitCode", Convert.ToString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MakeDate", Convert.ToString(drRow["MakeDate"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM1500_U1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("InspCase", Convert.ToString(drRow["InspCase"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspCode", Convert.ToString(drRow["InspCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspName", Convert.ToString(drRow["InspName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspDesc", Convert.ToString(drRow["InspDesc"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspType", Convert.ToString(drRow["InspType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UnitCode", Convert.ToString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("EditDate", Convert.ToString(drRow["EditDate"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("InspCode");
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
                //if (param != null) { param = null; }
            }
        }
        #endregion

        #region grid POP UP 처리
        private void grid_POP_UP()
        {
            int iRow = this.grid1.ActiveRow.Index;
            string sInspCase = Convert.ToString(this.grid1.Rows[iRow].Cells["InspCase"].Value);  //    
            string sInspType = this.grid1.Rows[iRow].Cells["InspType"].Text.Trim();  // 
            string sInspCode = this.grid1.Rows[iRow].Cells["InspCode"].Text.Trim();  //
            string sInspName = this.grid1.Rows[iRow].Cells["InspName"].Text.Trim();  // 
            string sUseFlag = this.grid1.Rows[iRow].Cells["UseFlag"].Text.Trim();  //
            string[] sParam = { };


            if (this.grid1.ActiveCell.Column.ToString() == "InspCode" || this.grid1.ActiveCell.Column.ToString() == "InspName")
            {
                PopUp_Biz _biz = new PopUp_Biz();
                //_biz.TBM1500_POP_Grid(sInspCase, sInspType, sInspCode, sInspName, sUseFlag, grid1, "InspCode", "InspName", sParam);
            }

        }
        private void grid1_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            grid_POP_UP();
        }

        private void grid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                grid_POP_UP();
            }

        }


        #endregion  //grid POP-UP 처리

        #region < EVENT AREA >

        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Modified)
            {
                e.Command.Parameters["@Editor"].Value = this.WorkerID;
                return;
            }

            if (e.Row.RowState == DataRowState.Added)
            {
                e.Command.Parameters["@Editor"].Value = this.WorkerID;
                e.Command.Parameters["@Maker"].Value = this.WorkerID;
                return;
            }
        }

        /// <summary>
        /// 저장처리시 오류가 발생한 경우 오류 메세지에 대한 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Errors == null) return;

            switch (((SqlException)e.Errors).Number)
            {
                // 중복
                case 2627:
                    e.Row.RowError = "이미 라우트 정보가 존재합니다.";
                    throw (new SException("S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion
    }
}





#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM1300
//   Form Name    : 단위마스터 관리
//   Name Space   : 
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
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
    public partial class BM1300 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM1300()
        {
            InitializeComponent();
        }
        #endregion

        #region 폼 초기화

        private void BM1300_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "UnitType", "단위구분", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순번", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", false, GridColDataType_emu.VarChar, 200, 500, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("UNITTYPE");     //PLANTCODE
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");     // 단위
            WIZ.Common.FillComboboxMaster(this.cboUnitType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");



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
                string sUnitType = DBHelper.nvlString(this.cboUnitType_H.Value);
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);


                // DBHelper 에서 파라매터를 Object 로 가져와 적용.
                grid1.DataSource = helper.FillTable("USP_BM1300_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("UnitType", sUnitType, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();
            }
            catch (Exception ex)
            {

                throw ex;
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
                    UltraGridUtil.ActivationAllowEdit(grid1, "UnitType");
                    UltraGridUtil.ActivationAllowEdit(grid1, "UnitCode");
                    UltraGridUtil.ActivationAllowEdit(grid1, "DisplayNo");
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

                foreach (DataRow drRow in dt.Rows)  // .GetChanges().Rows = 변경된 Rows 만 작업
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["UnitType"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "단위구분 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            //param = new System.Data.Common.DbParameter[3];

                            //sPlantCode = DBHelper.gGetCode(drRow["PlantCode"]);

                            //param[0] = helper.CreateParameter("UnitCode", DBHelper.nvlString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input);

                            //param[1] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[2] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_BM1300_D1N", CommandType.StoredProcedure, param);

                            //if (param[1].Value.ToString() == "E") throw new Exception(param[2].Value.ToString());

                            helper.ExecuteNoneQuery("USP_BM1300_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("UnitCode", Convert.ToString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            //param = new System.Data.Common.DbParameter[10];

                            //param[0] = helper.CreateParameter("UnitType", DBHelper.nvlString(drRow["UnitType"]), DbType.String, ParameterDirection.Input);
                            //param[1] = helper.CreateParameter("UnitCode", DBHelper.nvlString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input);
                            //param[2] = helper.CreateParameter("DisplayNo", DBHelper.nvlString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input);
                            //param[3] = helper.CreateParameter("UseFlag", DBHelper.nvlString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input);
                            //param[4] = helper.CreateParameter("MakeDate", DBHelper.nvlString(drRow["MakeDate"]), DbType.String, ParameterDirection.Input);
                            //param[5] = helper.CreateParameter("Maker", DBHelper.nvlString(drRow["Maker"]), DbType.String, ParameterDirection.Input);
                            //param[6] = helper.CreateParameter("EditDate", DBHelper.nvlString(drRow["EditDate"]), DbType.String, ParameterDirection.Input);
                            //param[7] = helper.CreateParameter("Editor", DBHelper.nvlString(drRow["Editor"]), DbType.String, ParameterDirection.Input);

                            //param[8] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[9] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);


                            //helper.ExecuteNoneQuery("USP_BM1300_I1N", CommandType.StoredProcedure, param);


                            //if (param[8].Value.ToString() == "E") throw new Exception(param[9].Value.ToString());

                            helper.ExecuteNoneQuery("USP_BM1300_I1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("UnitType", Convert.ToString(drRow["UnitType"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UnitCode", Convert.ToString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DisplayNo", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MakeDate", Convert.ToString(drRow["MakeDate"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EditDate", Convert.ToString(drRow["EditDate"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            //param = new System.Data.Common.DbParameter[10];

                            //param[0] = helper.CreateParameter("UnitType", DBHelper.nvlString(drRow["UnitType"]), DbType.String, ParameterDirection.Input);
                            //param[1] = helper.CreateParameter("UnitCode", DBHelper.nvlString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input);
                            //param[2] = helper.CreateParameter("DisplayNo", DBHelper.nvlString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input);
                            //param[3] = helper.CreateParameter("UseFlag", DBHelper.nvlString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input);
                            //param[4] = helper.CreateParameter("MakeDate", DBHelper.nvlString(drRow["MakeDate"]), DbType.String, ParameterDirection.Input);
                            //param[5] = helper.CreateParameter("Maker", DBHelper.nvlString(drRow["Maker"]), DbType.String, ParameterDirection.Input);
                            //param[6] = helper.CreateParameter("EditDate", DBHelper.nvlString(drRow["EditDate"]), DbType.String, ParameterDirection.Input);
                            //param[7] = helper.CreateParameter("Editor", DBHelper.nvlString(drRow["Editor"]), DbType.String, ParameterDirection.Input);

                            //param[8] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[9] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);


                            //helper.ExecuteNoneQuery("USP_BM1300_U1N", CommandType.StoredProcedure, param);


                            //if (param[8].Value.ToString() == "E") throw new Exception(param[9].Value.ToString());

                            helper.ExecuteNoneQuery("USP_BM1300_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("UnitType", Convert.ToString(drRow["UnitType"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UnitCode", Convert.ToString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DisplayNo", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MakeDate", Convert.ToString(drRow["MakeDate"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EditDate", Convert.ToString(drRow["EditDate"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("UnitType");
                helper.Commit();

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region grid POP UP 처리
        private void grid_POP_UP()
        {
            int iRow = this.grid1.ActiveRow.Index;
            string sPlantCode = Convert.ToString(this.grid1.Rows[iRow].Cells["PlantCode"].Value);  // 사업부    
            string sCustCode = this.grid1.Rows[iRow].Cells["CustCode"].Text.Trim();  // 업체코드
            string sCustName = this.grid1.Rows[iRow].Cells["CustName"].Text.Trim();  // 업체명


            if (this.grid1.ActiveCell.Column.ToString() == "CustCode" || this.grid1.ActiveCell.Column.ToString() == "CustName")
            {
                PopUp_Biz _biz = new PopUp_Biz();
                //_biz.TBM0300_POP_Grid(sCustCode, sCustName, "PlantCode", "C", "", grid1, "CustCode", "CustName");
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

    }
}

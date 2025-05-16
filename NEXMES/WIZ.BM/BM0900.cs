#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0900
//   Form Name    : 저장위치 관리
//   Name Space   : WIZ.BM
//   Created Date : 2012-6-12 
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
    public partial class BM0900 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        Common _Common = new Common();
        #endregion

        #region < CONSTRUCTOR >
        public BM0900()
        {
            InitializeComponent();

            //팝업 관리
            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("WHCODE", "WHNAME", "TBM0800", new string[] { "PlantCode", "", "", "", "" });
        }
        #endregion

        #region 폼 초기화

        private void BM0900_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            //164 65 150 74 154 99 120 80 100 100 110 100 
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCode", "창고", false, GridColDataType_emu.VarChar, 70, 500, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHName", "창고명", false, GridColDataType_emu.VarChar, 150, 500, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "LOC코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "저장위치명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StorageLocType", "저장위치구분", false, GridColDataType_emu.VarChar, 140, 30, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #region 콤보박스
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0080_CODE("PlantCode");           //입고창고
            WIZ.Common.FillComboboxMaster(this.cboWHCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");


            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("StorageLocType");   // 저장구분 2013.12.19 임영조 수정
            WIZ.Common.FillComboboxMaster(this.cboStorageLocType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "StorageLocType", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string sWHCode = DBHelper.nvlString(this.cboWHCode_H.Value);
                string sStorageLocType = DBHelper.nvlString(this.cboStorageLocType_H.Value);
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);

                base.DoInquire();



                grid1.DataSource = helper.FillTable("USP_BM0900_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WHCode", sWHCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("StorageLocType", sStorageLocType, DbType.String, ParameterDirection.Input)
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
                    this.grid1.SetDefaultValue("PlantCode", "820");

                    UltraGridUtil.ActivationAllowEdit(grid1, "PlantCode");
                    UltraGridUtil.ActivationAllowEdit(grid1, "WHCode");
                    UltraGridUtil.ActivationAllowEdit(grid1, "STORAGELOCCODE");
                    UltraGridUtil.ActivationAllowEdit(grid1, "STORAGELOCNAME");
                    UltraGridUtil.ActivationAllowEdit(grid1, "StorageLocType");
                    UltraGridUtil.ActivationAllowEdit(grid1, "Remark");
                    UltraGridUtil.ActivationAllowEdit(grid1, "UseFlag");
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
            if (grid1.IsActivate) Grid1ToolAct();
        }
        #endregion

        #region<Grid1ToolAct>
        private void Grid1ToolAct()
        {

            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);

            try
            {
                string sStorageLocCode = "";


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
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "공장 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            //param = new System.Data.Common.DbParameter[3];

                            //string sPlantCode = DBHelper.gGetCode(drRow["PlantCode"]);
                            //param[0] = helper.CreateParameter("WHCode", DBHelper.nvlString(drRow["WHCode"]), DbType.String, ParameterDirection.Input);
                            ////param[1] = helper.CreateParameter("StorageLocType", DBHelper.nvlInt(drRow["StorageLocType"]), DbType.String, ParameterDirection.Input);

                            //param[1] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[2] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_BM0900_D1N", CommandType.StoredProcedure, param);


                            //if (param[1].Value.ToString() == "E") throw new Exception(param[2].Value.ToString());



                            helper.ExecuteNoneQuery("USP_BM0900_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WHCode", Convert.ToString(drRow["WHCode"]), DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            //param = new System.Data.Common.DbParameter[12];

                            //param[0] = helper.CreateParameter("STORAGELOCCODE", DBHelper.nvlString(drRow["STORAGELOCCODE"]), DbType.String, ParameterDirection.Input);
                            //param[1] = helper.CreateParameter("STORAGELOCNAME", DBHelper.nvlString(drRow["STORAGELOCNAME"]), DbType.String, ParameterDirection.Input);
                            //param[2] = helper.CreateParameter("StorageLocType", DBHelper.nvlString(drRow["StorageLocType"]), DbType.String, ParameterDirection.Input);
                            //param[3] = helper.CreateParameter("WHCode", DBHelper.nvlString(drRow["WHCode"]), DbType.String, ParameterDirection.Input);
                            //param[4] = helper.CreateParameter("Remark", DBHelper.nvlString(drRow["Remark"]), DbType.String, ParameterDirection.Input);
                            //param[5] = helper.CreateParameter("UseFlag", DBHelper.nvlString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input);
                            //param[6] = helper.CreateParameter("MakeDate", DBHelper.nvlString(drRow["MakeDate"]), DbType.String, ParameterDirection.Input);
                            //param[7] = helper.CreateParameter("Maker", DBHelper.nvlString(drRow["Maker"]), DbType.String, ParameterDirection.Input);
                            //param[8] = helper.CreateParameter("EditDate", DBHelper.nvlString(drRow["EditDate"]), DbType.String, ParameterDirection.Input);
                            //param[9] = helper.CreateParameter("Editor", DBHelper.nvlString(drRow["Editor"]), DbType.String, ParameterDirection.Input);

                            //param[10] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[11] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);


                            //helper.ExecuteNoneQuery("USP_BM0900_I1N", CommandType.StoredProcedure, param);


                            //if (param[10].Value.ToString() == "E") throw new Exception(param[11].Value.ToString());
                            sStorageLocCode = Convert.ToString(drRow["STORAGELOCCODE"]);
                            helper.ExecuteNoneQuery("USP_BM0900_I1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("STORAGELOCCODE", sStorageLocCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("STORAGELOCNAME", Convert.ToString(drRow["STORAGELOCNAME"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("StorageLocType", Convert.ToString(drRow["StorageLocType"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WHCode", Convert.ToString(drRow["WHCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Remark", Convert.ToString(drRow["Remark"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MakeDate", Convert.ToString(drRow["MakeDate"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EditDate", Convert.ToString(drRow["EditDate"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            //param = new System.Data.Common.DbParameter[12];

                            //param[0] = helper.CreateParameter("STORAGELOCCODE", DBHelper.nvlString(drRow["STORAGELOCCODE"]), DbType.String, ParameterDirection.Input);
                            //param[1] = helper.CreateParameter("STORAGELOCNAME", DBHelper.nvlString(drRow["STORAGELOCNAME"]), DbType.String, ParameterDirection.Input);
                            //param[2] = helper.CreateParameter("StorageLocType", DBHelper.nvlString(drRow["StorageLocType"]), DbType.String, ParameterDirection.Input);
                            //param[3] = helper.CreateParameter("WHCode", DBHelper.nvlString(drRow["WHCode"]), DbType.String, ParameterDirection.Input);
                            //param[4] = helper.CreateParameter("Remark", DBHelper.nvlString(drRow["Remark"]), DbType.String, ParameterDirection.Input);
                            //param[5] = helper.CreateParameter("UseFlag", DBHelper.nvlString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input);
                            //param[6] = helper.CreateParameter("MakeDate", DBHelper.nvlString(drRow["MakeDate"]), DbType.String, ParameterDirection.Input);
                            //param[7] = helper.CreateParameter("Maker", DBHelper.nvlString(drRow["Maker"]), DbType.String, ParameterDirection.Input);
                            //param[8] = helper.CreateParameter("EditDate", DBHelper.nvlString(drRow["EditDate"]), DbType.String, ParameterDirection.Input);
                            //param[9] = helper.CreateParameter("Editor", DBHelper.nvlString(drRow["Editor"]), DbType.String, ParameterDirection.Input);

                            //param[10] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[11] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);


                            //helper.ExecuteNoneQuery("USP_BM0900_U1N", CommandType.StoredProcedure, param);


                            //if (param[10].Value.ToString() == "E") throw new Exception(param[11].Value.ToString());
                            sStorageLocCode = Convert.ToString(drRow["STORAGELOCCODE"]);
                            helper.ExecuteNoneQuery("USP_BM0900_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("STORAGELOCCODE", sStorageLocCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("STORAGELOCNAME", Convert.ToString(drRow["STORAGELOCNAME"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("StorageLocType", Convert.ToString(drRow["StorageLocType"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WHCode", Convert.ToString(drRow["WHCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Remark", Convert.ToString(drRow["Remark"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PlantCode");
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
            string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);  // 사업부
            string sWHCode = this.grid1.Rows[iRow].Cells["WHCode"].Text.Trim();  // 저장코드
            string sStroageLocCode = this.grid1.Rows[iRow].Cells["StroageLocCode"].Text.Trim();  // 저장코드
            string sStroageLocName = this.grid1.Rows[iRow].Cells["StroageLocName"].Text.Trim();  // 저장이름
            string sStroageLocType = this.grid1.Rows[iRow].Cells["StroageLocType"].Text.Trim();  // 저장구분

            string sUseFlag = this.grid1.Rows[iRow].Cells["UseFlag"].Text.Trim();  // 사용

            if (this.grid1.ActiveCell.Column.ToString() == "StroageLocCode" || this.grid1.ActiveCell.Column.ToString() == "StroageLocName")
            {


                PopUp_Biz _biz = new PopUp_Biz();
                //_biz.TBM0900_POP_Grid(sPlantCode, sWHCode, sStroageLocCode, sStroageLocName, sStroageLocType, sUseFlag, grid1, "StroageLocCode", "StroageLocName");
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

        #region<cboPlantCode_H_SelectedValueChanged>
        private void cboPlantCode_H_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable rtnDtTemp1 = new DataTable(); // return DataTable 공통

            rtnDtTemp1 = _Common.GET_BM0080_CODE(DBHelper.nvlString(cboPlantCode_H.Value));           //입고창고
            WIZ.Common.FillComboboxMaster(this.cboWHCode_H, rtnDtTemp1, rtnDtTemp1.Columns["CODE_ID"].ColumnName, rtnDtTemp1.Columns["CODE_NAME"].ColumnName, "ALL", "");

        }
        #endregion

    }
}

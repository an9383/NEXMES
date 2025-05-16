#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : TBM0800
//   Form Name    : 창고코드 마스터
//   Name Space   : WIZ.BM
//   Created Date : 2012-03-19
//   Made By      : WIZCORE
//   Description  : 기준정보(창고 마스터) 정보 관리 폼
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
    public partial class TBM0800 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >
        public TBM0800()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("CustCode", "CustName", "TBM0301", new string[] { "PlantCode", "V", "Y" });
        }
        #endregion

        #region 폼 초기화

        private void TBM0800_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCode", "창고코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHName", "창고명", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BaseWHFlag", "기본창고", false, GridColDataType_emu.VarChar, 80, 500, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdWHFlag", "생산창고", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MetWHFlag", "자재창고", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DeptCode", "부서", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "업체", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "업체명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TTBM0800_CODE("");           //입고창고
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");     //여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "BaseWHFlag", rtnDtTemp, "CODE_ID", "CODE_NAME"); //"BaseWHFlag", "기본창고", "ProdWHFlag", "생산창고","MetWHFlag",  "자재창고"
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ProdWHFlag", rtnDtTemp, "CODE_ID", "CODE_NAME"); //"BaseWHFlag", "기본창고", "ProdWHFlag", "생산창고","MetWHFlag",  "자재창고"
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MetWHFlag", rtnDtTemp, "CODE_ID", "CODE_NAME"); //"BaseWHFlag", "기본창고", "ProdWHFlag", "생산창고","MetWHFlag",  "자재창고"

            rtnDtTemp = _Common.GET_BM0000_CODE("DeptCode");     //부서
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DeptCode", rtnDtTemp, "CODE_ID", "CODE_NAME"); //부서

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
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string useFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                grid1.DataSource = helper.FillTable("USP_TBM0800_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("UseFlag", useFlag, DbType.String, ParameterDirection.Input));

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
                int iRow = _GridUtil.AddRow(this.grid1);
                this.grid1.SetDefaultValue("PlantCode", "820");
                UltraGridUtil.ActivationAllowEdit(grid1, "PlantCode");
                UltraGridUtil.ActivationAllowEdit(grid1, "WHCode");
                UltraGridUtil.ActivationAllowEdit(grid1, "WHName");
                UltraGridUtil.ActivationAllowEdit(grid1, "BaseWHFlag");
                UltraGridUtil.ActivationAllowEdit(grid1, "ProdWHFlag");
                UltraGridUtil.ActivationAllowEdit(grid1, "MetWHFlag");
                UltraGridUtil.ActivationAllowEdit(grid1, "DeptCode");
                UltraGridUtil.ActivationAllowEdit(grid1, "CustCode");
                UltraGridUtil.ActivationAllowEdit(grid1, "UseFlag");
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

        #region <Grid1ToolAct()>
        private void Grid1ToolAct()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);


            try
            {
                string sPlantCode = "";


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

                            // param = new System.Data.Common.DbParameter[4];

                            //sPlantCode = DBHelper.gGetCode(drRow["PlantCode"]);

                            helper.ExecuteNoneQuery("USP_TBM0800_D1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WHCode", Convert.ToString(drRow["WHCode"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            //param = new System.Data.Common.DbParameter[15];

                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_TBM0800_I1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WHCode", Convert.ToString(drRow["WHCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WHName", Convert.ToString(drRow["WHName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("BaseWHFlag", Convert.ToString(drRow["BaseWHFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ProdWHFlag", Convert.ToString(drRow["ProdWHFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MetWHFlag", Convert.ToString(drRow["MetWHFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DeptCode", Convert.ToString(drRow["DeptCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CustCode", Convert.ToString(drRow["CustCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            //param = new System.Data.Common.DbParameter[12];

                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_TBM0800_U1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WHCode", Convert.ToString(drRow["WHCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WHName", Convert.ToString(drRow["WHName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("BaseWHFlag", Convert.ToString(drRow["BaseWHFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ProdWHFlag", Convert.ToString(drRow["ProdWHFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MetWHFlag", Convert.ToString(drRow["MetWHFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DeptCode", Convert.ToString(drRow["DeptCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CustCode", Convert.ToString(drRow["CustCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

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
                this.ShowDialog(ex.ToString());
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
            string sPlantCode = Convert.ToString(this.grid1.Rows[iRow].Cells["PlantCode"].Value); // 사업부
            string sWHCode = this.grid1.Rows[iRow].Cells["WHCode"].Text.Trim();                // 창고코드
            string sWHName = this.grid1.Rows[iRow].Cells["WHName"].Text.Trim();                // 창고명
            string sBaseWHFlag = this.grid1.Rows[iRow].Cells["BaseWHFlag"].Text.Trim();            // 기본창고
            string sProdWHFlag = this.grid1.Rows[iRow].Cells["ProdWHFlag"].Text.Trim();            // 생산창고
            string sMetWHFlag = this.grid1.Rows[iRow].Cells["MetWHFlag"].Text.Trim();             // 자재창고
            string sUseFlag = this.grid1.Rows[iRow].Cells["UseFlag"].Text.Trim();               // 사용여부



            if (this.grid1.ActiveCell.Column.ToString() == "WHCode" || this.grid1.ActiveCell.Column.ToString() == "WHName")
            {

                PopUp_Biz _biz = new PopUp_Biz();
                //_biz.TTBM0800_POP_Grid(sPlantCode, sWHCode, sWHName, sBaseWHFlag, sProdWHFlag, sMetWHFlag, sUseFlag, grid1, "WHCode", "WHName");

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
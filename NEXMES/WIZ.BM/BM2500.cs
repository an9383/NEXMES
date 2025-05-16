#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : 
//   Form Name    : 
//   Name Space   : 
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>


using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{

    public partial class BM2500 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM2500()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager gridManager = new BizGridManager(grid1);

            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });

            gridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });    //품목
            gridManager.PopUpAdd("ErrorCode", "ErrorDesc", "TBM1000", new string[] { "ErrorType", "ErrorClass", "" });
        }

        #endregion

        #region BM2500_Load
        private void BM2500_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장(사업장)", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Plant", "공장(사업장)", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorType", "불량구분", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorTypeNm", "불량구분명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorClass", "불량유형", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorClassNm", "불량유형명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorCode", "불량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorDesc", "불량명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            ///////MERGE 
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;


            #region Grid MERGE
            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ItemCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["ItemCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["ItemCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ItemName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["ItemName"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["ItemName"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE



            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ERRORCLASS");     //불량 유형
            WIZ.Common.FillComboboxMaster(this.cboErrorClass_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ERRORCLASS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion

        }
        #endregion BM2500_Load

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
                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
                string sItemCode = this.txtItemCode.Text.Trim();                          //품목
                string sErrorClass = DBHelper.nvlString(this.cboErrorClass_H.Value);      //불량유형
                string sUseflag = DBHelper.nvlString(this.cboUseFlag_H.Value);            //사용여부
                grid1.DataSource = helper.FillTable("USP_BM2500_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ErrorClass", sErrorClass, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("UseFlag", sUseflag, DbType.String, ParameterDirection.Input));


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
                _GridUtil.AddRow(this.grid1);


                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ItemCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ItemName");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ErrorClass");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ErrorClassNm");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ErrorCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ErrorDesc");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "DisplayNo");      // 표시순서
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag");        // 사용유무   

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);


            try
            {
                string sPlantCode = "";

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "공장(사업장) error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            sPlantCode = Convert.ToString(drRow["PlantCode"]);

                            helper.ExecuteNoneQuery("USP_BM2500_D1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)         // 공장코드
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)         // 품목
                                                    , helper.CreateParameter("ErrorCode", Convert.ToString(drRow["ErrorCode"]), DbType.String, ParameterDirection.Input));       // 관리항목

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            // param = new System.Data.Common.DbParameter[8];
                            sPlantCode = Convert.ToString(drRow["PlantCode"]);

                            helper.ExecuteNoneQuery("USP_BM2500_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ErrorCode", Convert.ToString(drRow["ErrorCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DisplayNo", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            //param = new System.Data.Common.DbParameter[8];
                            sPlantCode = Convert.ToString(drRow["PlantCode"]);

                            helper.ExecuteNoneQuery("USP_BM2500_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)         // 공장코드
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)         // 품목
                                                    , helper.CreateParameter("ErrorCode", Convert.ToString(drRow["ErrorCode"]), DbType.String, ParameterDirection.Input)         // 불량코드
                                                    , helper.CreateParameter("DisplayNo", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)         // 표시순서
                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)         // 사용유무
                                                    , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));       // 수정자

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
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();

            }
        }
        #endregion

        #region<btn2501_Click>
        private void btn2501_Click(object sender, EventArgs e)
        {
            // 행이 없을 경우 SKIP
            if (this.grid1.Rows.Count == 0)
            {
                this.IsShowDialog = false;
                this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                return;
            }

            // 정보 넘김
            string sPlantCode = this.grid1.ActiveRow.Cells["PlantCode"].Value.ToString();
            string sItemCode = this.grid1.ActiveRow.Cells["ItemCode"].Value.ToString();
            string sItemName = this.grid1.ActiveRow.Cells["ItemName"].Value.ToString();
            if (sPlantCode != "" && sItemCode != "")
            {
                BM2501 Form = new BM2501(sPlantCode, sItemCode, sItemName);
                Form.ShowDialog();
            }
            else
            {
                this.ShowDialog(Common.getLangText("정보가 선택되지 않았습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion
    }
}

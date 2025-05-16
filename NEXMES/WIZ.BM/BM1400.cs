#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM1400
//   Form Name    : 라우터 관리
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
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM1400 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); //return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM1400()
        {
            InitializeComponent();

            //팝업 관리
            BizTextBoxManager btbManager = new BizTextBoxManager();

            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            BizGridManager gridManager = new BizGridManager(grid1);

            gridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "Y" });
            gridManager.PopUpAdd("WorkCenterCode", "WorkCenterName", "TBM0600", new string[] { "PlantCode", "OPCode", "", "" });
            gridManager.PopUpAdd("OPCode", "OPName", "TBM0400", new string[] { "PlantCode", "" });
            gridManager.PopUpAdd("LineCode", "LineName", "TBM0500", new string[] { "PlantCode", "" });
        }
        #endregion

        #region 폼 초기화

        private void BM1400_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString,  
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ROUTERTYPE", "공정유형", false, GridColDataType_emu.VarChar, 130, 500, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkNo", "공정순번", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineCode", "라인", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineName", "라인명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "공정", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "공정명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ValidFrom", "ValidFrom", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PlantCode"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ItemCode"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ROUTERTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["WorkNo"].Header.Appearance.ForeColor = Color.SkyBlue;



            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  // 사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("Rgubun");     //적용구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "Rgubun", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ROUTERTYPE"); //공정유형
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ROUTERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");


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
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                string sItemCode = txtItemCode.Text.Trim();

                grid1.DataSource = helper.FillTable("USP_BM1400_S2", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));


                grid1.DataBinds();

                grid1.DisplayLayout.Bands[0].Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["PlantCode"].MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                grid1.DisplayLayout.Bands[0].Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;

                grid1.DisplayLayout.Bands[0].Columns["ItemCode"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["ItemCode"].MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                grid1.DisplayLayout.Bands[0].Columns["ItemCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;

                grid1.DisplayLayout.Bands[0].Columns["ItemName"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["ItemName"].MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                grid1.DisplayLayout.Bands[0].Columns["ItemName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
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
                    this.grid1.SetDefaultValue("PlantCode", "820");

                    UltraGridUtil.ActivationAllowEdit(grid1, "ItemCode");
                    UltraGridUtil.ActivationAllowEdit(grid1, "PlantCode");
                    UltraGridUtil.ActivationAllowEdit(grid1, "WorkNo");
                    UltraGridUtil.ActivationAllowEdit(grid1, "Rgubun");
                    UltraGridUtil.ActivationAllowEdit(grid1, "LineCode");
                    UltraGridUtil.ActivationAllowEdit(grid1, "OPCode");
                    UltraGridUtil.ActivationAllowEdit(grid1, "WorkCenterCode");
                    UltraGridUtil.ActivationAllowEdit(grid1, "ValidFrom");
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
                            grid1.SetRowError(drRow, "사업장 코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            sPlantCode = Convert.ToString(drRow["PlantCode"]);

                            //param = new System.Data.Common.DbParameter[5];
                            //sPlantCode = DBHelper.gGetCode(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_BM1400_D1N", CommandType.StoredProcedure
                                                     , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("WorkNo", Convert.ToString(drRow["WorkNo"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            //param = new System.Data.Common.DbParameter[15];
                            helper.ExecuteNoneQuery("USP_BM1400_I1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkNo", Convert.ToString(drRow["WorkNo"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Rgubun", Convert.ToString(drRow["Rgubun"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("LineCode", Convert.ToString(drRow["LineCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OPCode", Convert.ToString(drRow["OPCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkCenterCode", Convert.ToString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ValidFrom", Convert.ToString(drRow["ValidFrom"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MakeDate", Convert.ToString(drRow["MakeDate"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            //param = new System.Data.Common.DbParameter[15];

                            helper.ExecuteNoneQuery("USP_BM1400_U1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkNo", Convert.ToString(drRow["WorkNo"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Rgubun", Convert.ToString(drRow["Rgubun"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("LineCode", Convert.ToString(drRow["LineCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OPCode", Convert.ToString(drRow["OPCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkCenterCode", Convert.ToString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ValidFrom", Convert.ToString(drRow["ValidFrom"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("EditDate", Convert.ToString(drRow["EditDate"]), DbType.String, ParameterDirection.Input)
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





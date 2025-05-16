#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM8010
//   Form Name    : 품목별 표준시간 관리
//   Name Space   : WIZ.BM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Data.SqlClient;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM8010 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM8010()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });

            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });
            gridManager.PopUpAdd("OPCode", "OPName", "TBM0400", new string[] { "PlantCode", "" });
        }
        #endregion

        #region < BM8010_Load >
        private void BM8010_Load(object sender, EventArgs e)
        {
            #region Grid
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장(사업장)", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 165, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "작업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "작업장명", false, GridColDataType_emu.VarChar, 135, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StaTime", "표준시간", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CycleTime", "Cycle Time", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SetupTime", "Setup Time", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StartDate", "시작일자", false, GridColDataType_emu.DateTime, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EndDate", "종료일자", false, GridColDataType_emu.DateTime, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StopMKTime", "정지시간", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BaseRunTime", "기본사동시간", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Cavity", "Cavity", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.SetInitUltraGridBind(grid1);



            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {


                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);             // 공장코드 
                string sItemCode = txtItemCode.Text.Trim();                               // 품목                                                          
                string sOPCode = txtOPCode.Text.Trim(); ;                                 // 공정코드  

                grid1.DataSource = helper.FillTable("USP_BM8010_S1"
                                             , CommandType.StoredProcedure
                                             , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
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
                this.grid1.SetDefaultValue("PlantCode", "S820");

                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ItemCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ItemName");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "OPCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "OPName");
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

                            helper.ExecuteNoneQuery("USP_BM8010_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OPCode", Convert.ToString(drRow["OPCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("StartDate", DBHelper.nvlDateTime(drRow["StartDate"]), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM8010_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)      //사업장
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)      //품목
                                                    , helper.CreateParameter("OPCode", Convert.ToString(drRow["OPCode"]), DbType.String, ParameterDirection.Input)      //공정코드
                                                    , helper.CreateParameter("StaTime", DBHelper.nvlDouble(drRow["StaTime"]), DbType.String, ParameterDirection.Input)      //표준시간
                                                    , helper.CreateParameter("CycleTime", DBHelper.nvlDouble(drRow["CycleTime"]), DbType.String, ParameterDirection.Input)      //사이클타임
                                                    , helper.CreateParameter("StopMKTime", DBHelper.nvlDouble(drRow["StopMKTime"]), DbType.String, ParameterDirection.Input)      //정지시간
                                                    , helper.CreateParameter("SetupTime", DBHelper.nvlDouble(drRow["SetupTime"]), DbType.String, ParameterDirection.Input)      //셋업시간
                                                    , helper.CreateParameter("BaseRunTime", DBHelper.nvlDouble(drRow["BaseRunTime"]), DbType.String, ParameterDirection.Input)      //기본사동시간
                                                    , helper.CreateParameter("StartDate", DBHelper.nvlDateTime(drRow["StartDate"]), DbType.DateTime, ParameterDirection.Input)      //시작일자
                                                    , helper.CreateParameter("EndDate", DBHelper.nvlDateTime(drRow["EndDate"]), DbType.DateTime, ParameterDirection.Input)      //종료일자
                                                    , helper.CreateParameter("Cavity", DBHelper.nvlDouble(drRow["Cavity"]), DbType.String, ParameterDirection.Input)      //Cavity      
                                                    , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));    //등록자
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM8010_U1"
                                                    , CommandType.StoredProcedure //, ref RS_CODE, ref RS_MSG
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)      //사업장
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)      //품목
                                                    , helper.CreateParameter("OPCode", Convert.ToString(drRow["OPCode"]), DbType.String, ParameterDirection.Input)      //공정코드
                                                    , helper.CreateParameter("StaTime", DBHelper.nvlDouble(drRow["StaTime"]), DbType.String, ParameterDirection.Input)      //표준시간
                                                    , helper.CreateParameter("CycleTime", DBHelper.nvlDouble(drRow["CycleTime"]), DbType.String, ParameterDirection.Input)      //사이클타임
                                                    , helper.CreateParameter("StopMKTime", DBHelper.nvlDouble(drRow["StopMKTime"]), DbType.String, ParameterDirection.Input)      //정지시간
                                                    , helper.CreateParameter("SetupTime", DBHelper.nvlDouble(drRow["SetupTime"]), DbType.String, ParameterDirection.Input)      //셋업시간
                                                    , helper.CreateParameter("BaseRunTime", DBHelper.nvlDouble(drRow["BaseRunTime"]), DbType.String, ParameterDirection.Input)      //기본사동시간
                                                    , helper.CreateParameter("StartDate", DBHelper.nvlDateTime(drRow["StartDate"]), DbType.DateTime, ParameterDirection.Input)      //시작일자
                                                    , helper.CreateParameter("EndDate", DBHelper.nvlDateTime(drRow["EndDate"]), DbType.DateTime, ParameterDirection.Input)      //종료일자
                                                    , helper.CreateParameter("Cavity", DBHelper.nvlDouble(drRow["Cavity"]), DbType.String, ParameterDirection.Input)      //Cavity      
                                                    , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));    //등록자
                            //if (RS_CODE == "E") MessageBox.Show(RS_MSG);
                            //if (RS_CODE == "S") MessageBox.Show(RS_MSG);
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

                e.Command.Parameters["@Maker"].Value = this.WorkerID;
                return;
            }
        }
        void Adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Errors == null) return;

            switch (((SqlException)e.Errors).Number)
            {
                // 중복
                case 2627:
                    e.Row.RowError = "데이터가 중복입니다.";
                    throw (new SException("S00099", e.Errors));
                default:
                    break;
            }
        }

        private void btnERPDownLoad_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);
            UltraGridUtil.DataRowDelete(this.grid1);
            this.grid1.UpdateData();

            try
            {

                helper.ExecuteNoneQuery("USP_IF0100_I1"
                                        , CommandType.StoredProcedure
                                        , helper.CreateParameter("pProgID", "ERPDownLoader", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("pReqMessage", "Download", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("pParam1", "TBM8010", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("pParam2", DBHelper.nvlString(cboPlantCode_H.Value), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("pParam3", "", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("pParam4", "", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("pUser", this.WorkerID, DbType.String, ParameterDirection.Input));

                helper.Commit();

                this.ShowDialog(Common.getLangText("정상적으로 처리되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
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

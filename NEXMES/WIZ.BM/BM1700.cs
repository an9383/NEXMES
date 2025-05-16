#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM1700
//   Form Name    : 공급업체별 품목 정보 관리
//   Name Space   : WIZ.BM
//   Created Date : 2012-03-10
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM1700 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        UltraGridUtil _GridUtil = new UltraGridUtil();

        private string plantCode = string.Empty; //plantcode default 설정
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        #endregion

        #region < CONSTRUCTOR >
        public BM1700()
        {
            InitializeComponent();

            BizGridManager bizGrid = new BizGridManager(grid1);

            this.plantCode = CModule.GetAppSetting("Site", "10");

            bizGrid.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { plantCode, "" });
            // bizGrid.PopUpAdd("CustItemCode", "CustItemName", "TBM0100Y", new string[] { "PlantCode", "" });
            bizGrid.PopUpAdd("CustCode", "CustName", "TBM0300", new string[] { "V", "", "" });

            BizTextBoxManager btbManager = new BizTextBoxManager();

            //btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { "V", "ALL","" });
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0301", new object[] { cboPlantCode_H, "V", "", "false" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
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
                string sCustCode = txtCustCode.Text;
                string sCustName = txtCustName.Text;
                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);      // 공장코드 
                string sUseFlag = DBHelper.nvlString(cboUseFlag_H.Value);        // 사용여부    
                string sItemCode = txtItemCode.Text;
                string sItemName = txtItemName.Text;

                grid1.DataSource = helper.FillTable("USP_BM1700_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("pCustCode", sCustCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pCustName", sCustName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pPlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pItemName", sItemName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pUseFlag", sUseFlag, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["CustCode"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["CustName"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["ItemCode"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["ItemName"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Activation.NoEdit;

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
            base.DoNew();

            this.grid1.InsertRow();
            this.grid1.SetDefaultValue("PlantCode", plantCode);
            this.grid1.SetDefaultValue("USEFLAG", "Y");
            this.grid1.SetDefaultValue("OutCostFlag", "D");
            grid1.ActiveRow.Cells["MAKER"].Activation = Activation.Disabled;
            grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.Disabled;
            grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.Disabled;
            grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.Disabled;

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
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("공장을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;

                        }
                        if (drRow["CustCode"].ToString().Trim() == "")
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("협력사코드을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;

                        }
                        if (drRow["ItemCode"].ToString().Trim() == "")
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("품목을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;

                        }

                        if (drRow["CUSTITEMCODE"].ToString().Length > 30)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("업체품목은 최대 30자리까지 입력가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            sPlantCode = Convert.ToString(drRow["PlantCode"].ToString());
                            helper.ExecuteNoneQuery("USP_BM1700_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("pCustCode", drRow["CustCode"].ToString(), DbType.String, ParameterDirection.Input)         // 공장코드
                            , helper.CreateParameter("pPlantCode", sPlantCode, DbType.String, ParameterDirection.Input)           // 품목
                            , helper.CreateParameter("pItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input));           // 관리항목

                            #endregion
                            break;
                        case DataRowState.Added:

                            helper.ExecuteNoneQuery("USP_BM1700_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("pCustCode", drRow["CustCode"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pPlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pOutCostFlag", drRow["OutCostFlag"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pCustItemCode", drRow["CustItemCode"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pUnitCost", drRow["UnitCost"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pUnitCode", drRow["UnitCode"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pUseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("pMaker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                            );
                            break;

                        case DataRowState.Modified:
                            #region 추가/수정

                            sPlantCode = Convert.ToString(drRow["PlantCode"].ToString());
                            string sOutCostFlag = Convert.ToString(drRow["OutCostFlag"].ToString());
                            string sUseFlag = Convert.ToString(drRow["UseFlag"].ToString());

                            helper.ExecuteNoneQuery("USP_BM1700_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("CustCode", drRow["CustCode"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("OutCostFlag", sOutCostFlag, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("CustItemCode", drRow["CustItemCode"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("UnitCost", drRow["UnitCost"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("UnitCode", drRow["UnitCode"].ToString(), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                }

                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();
                    this.DoInquire();
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                // helper.Rollback();
                helper.Close(false);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
        /// <summary>
        /// Form이 Close 되기전에 발생
        /// e.Cancel을 true로 설정 하면, Form이 close되지 않음
        /// 수정 내역이 있는지를 확인 후 저장여부를 물어보고 저장, 저장하지 않기, 또는 화면 닫기를 Cancel 함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            //if (e.Row.RowState == DataRowState.Modified)
            //{
            //    e.Command.Parameters["@Editor"].Value = this.WorkerID;
            //    return;
            //}

            //if (e.Row.RowState == DataRowState.Added)
            //{
            //    e.Command.Parameters["@Editor"].Value = this.WorkerID;
            //    e.Command.Parameters["@Maker"].Value = this.WorkerID;
            //    return;
            //}
        }

        private void gbxHeader_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region<BM1700_Load>
        private void BM1700_Load(object sender, EventArgs e)
        {
            #region 그리드
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장ⓒ", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "협력사코드ⓟ", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "협력사명ⓟ", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목ⓟ", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명ⓟ", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustItemCode", "업체품목", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutCostFlag", "유무상구분ⓒ", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCost", "단가", true, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위ⓒ", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "useFlag", "사용여부ⓒ", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.Yellow;
            grid1.DisplayLayout.Bands[0].Columns["CustCode"].Header.Appearance.ForeColor = Color.Yellow;
            grid1.DisplayLayout.Bands[0].Columns["ItemCode"].Header.Appearance.ForeColor = Color.Yellow;
            //     ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("OutCostFlag");     //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutCostFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UnitCode");  // 단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode_H.Value = plantCode;

            #endregion
        }
        #endregion

        #region grid POP UP 처리
        #endregion

        #region <METHOD AREA>*/
        // Form에서 사용할 함수나 메소드를 정의
        #endregion
    }
}

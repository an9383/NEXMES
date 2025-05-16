#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM1800
//   Form Name    : 출하품목번호 관리
//   Name Space   : WIZ.BM
//   Created Date : 2012-03-31
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM1800 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성

        private string plantCode = string.Empty; //plantcode default 설정
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        #endregion

        #region < CONSTRUCTOR >
        public BM1800()
        {
            InitializeComponent();

            this.plantCode = CModule.GetAppSetting("Site", "10");
            //팝업 관리
            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager gridManager = new BizGridManager(grid1);


            gridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { plantCode, "" });
            gridManager.PopUpAdd("CustCode", "CustName", "TBM0300", new string[] { "C", "", "" });

            btbManager = new BizTextBoxManager();

            //btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { "C", "ALL", "" });
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0301", new object[] { cboPlantCode_H, "C", "", "false" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
        }
        #endregion

        #region 폼 초기화

        private void BM1800_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern            

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장ⓒ", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "고객사코드ⓟ", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "고객사명ⓟ", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목ⓟ", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명ⓟ", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustItemCode", "고객자재번호", true, GridColDataType_emu.VarChar, 150, 500, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustItemName", "고객자재명", true, GridColDataType_emu.VarChar, 150, 500, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PackQty", "포장수량", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###,", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "포장단위ⓒ", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCost", "단가", true, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부ⓒ", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일시", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일시", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["CustCode"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ItemCode"].Header.Appearance.ForeColor = Color.SkyBlue;

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  // 사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //   rtnDtTemp = _Common.GET_TBM1300_CODE_1("C", "Y");        //  단위 
            //   WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("packunit");  // 포장단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion

            cboPlantCode_H.Value = plantCode;

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
                string sCustCode = txtCustCode.Text.Trim();
                string sItemCode = txtItemCode.Text.Trim();
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);

                grid1.DataSource = helper.FillTable("USP_BM1800_S2"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CustCode", sCustCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));

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
            try
            {
                base.DoNew();

                this.grid1.InsertRow();
                this.grid1.SetDefaultValue("PlantCode", plantCode);
                this.grid1.SetDefaultValue("USEFLAG", "Y");
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.Disabled;
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

        #region<Grid1ToolAct>
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
                //    int li_cnt = 0;
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
                            this.ShowDialog(Common.getLangText("고객사를 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;

                        }
                        if (drRow["ItemCode"].ToString().Trim() == "")
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("품목을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;

                        }
                        if (drRow["CustItemCode"].ToString().Length > 30)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("고객자재번호는 최대 30자리까지 입력가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;

                        }
                        if (drRow["CustItemName"].ToString().Length > 40)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("고객자재명은 최대 40자리까지 입력가능합니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();


                            //sPlantCode = DBHelper.gGetCode(drRow["PlantCode"]);

                            helper.ExecuteNoneQuery("USP_BM1800_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CustCode", Convert.ToString(drRow["CustCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM1800_I2"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CustCode", Convert.ToString(drRow["CustCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CustItemCode", Convert.ToString(drRow["CustItemCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CustItemName", Convert.ToString(drRow["CustItemName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PackQty", Convert.ToString(drRow["PackQty"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UnitCost", Convert.ToString(drRow["UnitCost"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UnitCode", Convert.ToString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM1800_U2"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CustCode", Convert.ToString(drRow["CustCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCode", Convert.ToString(drRow["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CustItemCode", Convert.ToString(drRow["CustItemCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CustItemName", Convert.ToString(drRow["CustItemName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PackQty", Convert.ToString(drRow["PackQty"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UnitCost", Convert.ToString(drRow["UnitCost"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UnitCode", Convert.ToString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);

                }
                grid1.SetAcceptChanges("PlantCode");
                helper.Commit();
                DoInquire();

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


        private void grid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.grid1.Rows.Count == 0) return;
            if (((WIZ.Control.Grid)(sender)).ActiveCell == null) return;
            //숫자 그리드 헤더 컬럼명 찾기
            if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "PACKQTY")
                //숫자,백스페이스만 입력받는다.
                if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != 8)
                {
                    MessageBox.Show(Common.getLangText("숫자만 입력 가능합니다.", "MSG"));
                    e.Handled = true;
                }
        }


        #endregion

    }
}





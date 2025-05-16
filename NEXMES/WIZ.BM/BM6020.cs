#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM6020
//   Form Name    : 작업장 품목별 검사항목 관리
//   Name Space   : WIZ.BM
//   Created Date : 2015-10-20
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
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM6020 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        private string sPlantCode = string.Empty;
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        #endregion

        #region < CONSTRUCTOR >
        public BM6020()
        {
            InitializeComponent();

            sPlantCode = CModule.GetAppSetting("Site", "10");

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { "", "" });
            btbManager.PopUpAdd(txtCntCode, txtCntName, "TBM0600", new object[] { "", "", "", "" });
            btbManager.PopUpAdd(txtInspCode, txtInspName, "TBM6000", new object[] { "", "" }); //검사항목

            BizGridManager bizGrid = new BizGridManager(grid3);
            bizGrid.PopUpAdd("PartNo", "PartName", "TBM0100", new string[] { "", "" });
            bizGrid.PopUpAdd("INSPCODE", "INSPNAME", "TBM6000", new string[] { "", "" }); //검사항목

        }
        #endregion

        #region 폼 초기화

        private void BM6020_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CntCode", "작업장코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CntName", "작업장명", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region Grid2 셋팅
            _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CARTYPE", "차종코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "BASEUNIT", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "GRADE", "강종", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITTHICK", "두께", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITLENGTH", "길이", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITWGT", "단위중량", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region Grid3 셋팅
            _GridUtil.InitializeGrid(this.grid3, false, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid3, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 200, 200, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid3);

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            #endregion


        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid3);
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string sCntCode = txtCntCode.Text.Trim();
                string sCntName = txtCntName.Text.Trim();
                string sItemCode = txtItemCode.Text.Trim();
                string sItemName = txtItemName.Text.Trim();


                grid1.DataSource = helper.FillTable("USP_BM6020_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKCENTERCODE", sCntCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKCENTERNAME", sCntName, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)

                                                                    );

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
            base.DoNew();
            int iRow = 0;
            if (this.grid1.Rows.Count == 0)
            {
                this.ShowDialog(Common.getLangText("먼저 작업장별 품목을 조회하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            iRow = this.grid3.InsertRow();
            this.grid3.ActiveRow.Cells["USEFLAG"].Value = "Y";
            grid3.ActiveRow.Cells["USEFLAG"].Activation = Activation.Disabled;
            grid3.ActiveRow.Cells["Maker"].Activation = Activation.Disabled;
            grid3.ActiveRow.Cells["MakeDate"].Activation = Activation.Disabled;
            grid3.ActiveRow.Cells["Editor"].Activation = Activation.Disabled;
            grid3.ActiveRow.Cells["EditDate"].Activation = Activation.Disabled;
            return;
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {

            //base.DoSave();

            this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);
            this.grid3.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

            this.Grid1ToolAct2();
        }
        #endregion     

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            this.grid3.DeleteRow();
        }

        private void Grid1ToolAct2()
        {
            DataTable dt = grid3.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);
            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                base.DoSave();


                //int i = 0; // 사용여부를 N으로 수정한 경우 메세지 표시를 위해 추가
                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["INSPCODE"].ToString().Trim() == "")
                        {
                            grid3.SetRowError(drRow, "INSPCODE error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM6020_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(grid1.ActiveRow.Cells["CNTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ITEMCODE", Convert.ToString(grid2.ActiveRow.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)

                                                    );   //측정 코드   
                            if (helper.RSCODE == "E")
                            {
                                grid3.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                            }
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM6020_I1N", CommandType.StoredProcedure
                            , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(grid1.ActiveRow.Cells["CNTCODE"].Value), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("ITEMCODE", Convert.ToString(grid2.ActiveRow.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                            );
                            if (helper.RSCODE == "E")
                            {
                                grid3.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                            }
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM6020_U1N", CommandType.StoredProcedure, false, true
                            , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(grid1.ActiveRow.Cells["CNTCODE"].Value), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("ITEMCODE", Convert.ToString(grid2.ActiveRow.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input)
                            );
                            if (helper.RSCODE == "E")
                            {
                                grid3.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                            }
                            #endregion
                            break;
                    }


                }
                grid3.SetAcceptChanges();
                helper.Commit();

                grid2_ClickCell(null, null);

            }
            catch (SException ex)
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

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                string sCntCode = Convert.ToString(this.grid1.ActiveRow.Cells["CntCode"].Value);
                string sInspCode = txtInspCode.Text;
                string sInspName = txtInspName.Text;
                string sUseFlag = DBHelper.nvlString(cboUseFlag_H.Value);
                grid2.DataSource = helper.FillTable("USP_BM6020_S3N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("WORKCENTERCODE", sCntCode, DbType.String, ParameterDirection.Input)
                                                                    );

                grid2.DataBinds();
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

        private void grid2_ClickCell(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                string sCntCode = Convert.ToString(this.grid1.ActiveRow.Cells["CntCode"].Value);
                string sItemCode = Convert.ToString(this.grid2.ActiveRow.Cells["ITEMCODE"].Value);
                string sInspCode = txtInspCode.Text;
                string sInspName = txtInspName.Text;
                string sUseFlag = DBHelper.nvlString(cboUseFlag_H.Value);
                grid3.DataSource = helper.FillTable("USP_BM6020_S2N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("CNTCODE", sCntCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPNAME", sInspName, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                                    );

                grid3.DataBinds();

                //조회시 미사용은 노란색으로 표시
                for (int i = 0; i < this.grid3.Rows.Count; i++)
                {
                    if (Convert.ToString(grid3.Rows[i].Cells["USEFLAG"].Value.ToString()) == "N")
                    {
                        grid3.Rows[i].Appearance.BackColor = Color.FromArgb(254, 255, 100);
                    }

                }
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

        private void grid3_CellChange(object sender, CellEventArgs e)
        {

            if (e.Cell.Column.ToString() != "USEFLAG")
                return;

            this.grid1.UpdateData();

            string a = e.Cell.Value.ToString();
            if (a == "N")
            {
                if (this.ShowDialog(Common.getLangText("변경 후 저장시 작업장 품목별 검사기준 관리의 사용여부가 모두 사용으로 변경되지 않습니다. 변경하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.grid3.ActiveRow.Cells["USEFLAG"].Value = "N";
                    return;
                }
            }
            else
            {
                if (this.ShowDialog(Common.getLangText("변경 후 저장시 작업장 품목별 검사기준 관리의 사용여부가 모두 미사용으로 변경됩니다. 변경하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.grid3.ActiveRow.Cells["USEFLAG"].Value = "Y";
                    return;
                }
            }
        }
    }
}
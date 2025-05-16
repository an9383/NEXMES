#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0310
//   Form Name    : 긴급지시연결
//   Name Space   : WIZ.AP
//   Created Date : 2013-01-08
//   Made By      : WIZCORE CO.,LTD
//   Description  : 긴급지시편성
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP0310 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable();  // return DataTable 공통

        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >

        public AP0310()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtProcessCode, txtProcessName, "TBM0400", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, txtProcessCode, "", "" });

            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });
            gridManager.PopUpAdd("OPCode", "OPName", "TBM0400", new string[] { "PlantCode", "" });
            gridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "TBM0600", new string[] { "PLANTCODE", "OPCODE", "", "" });
        }
        #endregion

        #region AP0310_Load
        private void AP0310_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "지시일자", false, GridColDataType_emu.YearMonthDay, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHT", "주야", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SEQNO", "지시순번", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CARTYPE", "차종", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시량", false, GridColDataType_emu.Integer, 70, 100, Infragistics.Win.HAlign.Right, true, true, "#,##0", "nnn,nnn,nnn", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "전달사항", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생성일자", false, GridColDataType_emu.DateTime24, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("CARTYPE");
            WIZ.Common.FillComboboxMaster(this.cboCarType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CARTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT");
            //WIZ.Common.FillComboboxMaster(this.cboDayNight, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DAYNIGHT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0130_CODE("Y");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion
        }
        #endregion AP0310_Load

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();

            // 그리드 행 추가
            int iRow = this.grid1.InsertRow();

            this.grid1.Rows[iRow].Cells["DAYNIGHT"].Appearance.BackColor = Color.Gold;
            this.grid1.Rows[iRow].Cells["SEQNO"].Appearance.BackColor = Color.Gold;
            this.grid1.Rows[iRow].Cells["UNITCODE"].Appearance.BackColor = Color.Gold;
            this.grid1.Rows[iRow].Cells["ORDERDATE"].Appearance.BackColor = Color.Gold;
            this.grid1.Rows[iRow].Cells["WORKCENTERCODE"].Appearance.BackColor = Color.Gold;
            this.grid1.Rows[iRow].Cells["WORKCENTERNAME"].Appearance.BackColor = Color.Gold;
            this.grid1.Rows[iRow].Cells["ITEMCODE"].Appearance.BackColor = Color.Gold;
            this.grid1.Rows[iRow].Cells["ITEMNAME"].Appearance.BackColor = Color.Gold;
            this.grid1.Rows[iRow].Cells["ORDERQTY"].Appearance.BackColor = Color.Gold;
            this.grid1.Rows[iRow].Cells["REMARK"].Appearance.BackColor = Color.Gold;

            // 행데이터 삽입
            this.grid1.Rows[iRow].Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
            this.grid1.Rows[iRow].Cells["ORDERDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
            this.grid1.Rows[iRow].Cells["ORDERQTY"].Value = 0;
            this.grid1.Rows[iRow].Cells["MAKER"].Value = WIZ.LoginInfo.UserID;
            this.grid1.Rows[iRow].Cells["DAYNIGHT"].Value = "D";
            this.grid1.Rows[iRow].Cells["SEQNO"].Value = 0;
            this.grid1.Rows[iRow].Cells["UNITCODE"].Value = "EA";

            this.grid1.Rows[iRow].Cells["PLANTCODE"].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.grid1.Rows[iRow].Cells["ORDERNO"].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.grid1.Rows[iRow].Cells["OPCODE"].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.grid1.Rows[iRow].Cells["OPNAME"].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.grid1.Rows[iRow].Cells["CARTYPE"].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.grid1.Rows[iRow].Cells["MAKER"].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.grid1.Rows[iRow].Cells["MAKEDATE"].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            if (grid1.IsActivate) this.grid1.DeleteRow();
        }

        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            base.DoInquire();

            DoFind();

            this.grid1.Columns["PLANTCODE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.grid1.Columns["ORDERDATE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.grid1.Columns["DAYNIGHT"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.grid1.Columns["SEQNO"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.grid1.Columns["ORDERNO"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.grid1.Columns["OPCODE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.grid1.Columns["OPNAME"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.grid1.Columns["WORKCENTERCODE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.grid1.Columns["WORKCENTERNAME"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.grid1.Columns["CARTYPE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.grid1.Columns["ITEMCODE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.grid1.Columns["ITEMNAME"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.grid1.Columns["ORDERQTY"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.grid1.Columns["UNITCODE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.grid1.Columns["REMARK"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.grid1.Columns["MAKER"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.grid1.Columns["MAKEDATE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            bool issuccess = true;

            this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

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
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_AP0310_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("TYPE", "D", DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ORDERNO", Convert.ToString(drRow["ORDERNO"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ORDERDATE", Convert.ToString(drRow["ORDERDATE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ORDERQTY", Convert.ToInt32(drRow["ORDERQTY"]), DbType.Int32, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REMARK", Convert.ToString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PLANNO", "긴급", DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UNITCODE", Convert.ToString(drRow["UNITCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DAYNIGHT", Convert.ToString(drRow["DAYNIGHT"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("SEQNO", Convert.ToInt32(drRow["SEQNO"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            //if (Convert.ToInt32(drRow["ORDERQTY"]) == 0)
                            //{
                            //    CancelProcess = true;
                            //    this.ShowDialog("R00129", WIZ.Forms.DialogForm.DialogType.OK);
                            //    return;
                            //}

                            if (Convert.ToString(drRow["WORKCENTERCODE"]) == "" || Convert.ToString(drRow["ITEMCODE"]) == "")
                            {
                                CancelProcess = true;
                                this.ShowDialog(Common.getLangText("작업장과 품목을 입력해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            helper.ExecuteNoneQuery("USP_AP0310_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("TYPE", "I", DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ORDERNO", Convert.ToString(drRow["ORDERNO"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ORDERDATE", Convert.ToString(drRow["ORDERDATE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE", drRow["ITEMCODE"], DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ORDERQTY", int.Parse(Convert.ToString(drRow["ORDERQTY"]), NumberStyles.AllowThousands), DbType.Int32, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PLANNO", "긴급", DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UNITCODE", Convert.ToString(drRow["UNITCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DAYNIGHT", Convert.ToString(drRow["DAYNIGHT"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("SEQNO", drRow["SEQNO"], DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_AP0310_U1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("TYPE", "U", DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ORDERNO", Convert.ToString(drRow["ORDERNO"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ORDERDATE", Convert.ToString(drRow["ORDERDATE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ORDERQTY", Convert.ToInt32(drRow["ORDERQTY"]), DbType.Int32, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REMARK", Convert.ToString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PLANNO", "긴급", DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UNITCODE", Convert.ToString(drRow["UNITCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DAYNIGHT", Convert.ToString(drRow["DAYNIGHT"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("SEQNO", Convert.ToInt32(drRow["SEQNO"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }

                    if (Convert.ToString(helper.RSCODE) == "E")
                    {
                        issuccess = false;
                        grid1.SetRowError(drRow, this.FormInformation.GetMessage(helper.RSMSG));
                    }
                }

                if (issuccess)
                {
                    grid1.SetAcceptChanges();
                    helper.Commit();

                    //this.ShowDialog("R00124", WIZ.Forms.DialogForm.DialogType.OK);

                    DoFind();
                }
            }
            catch (SException ex)
            {
                CancelProcess = true;
                helper.Rollback();
                ThrowError(ex);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region <METHOD AREA>
        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sStartDate = string.Format("{0:yyyy-MM-dd}", this.CboStartdate_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", this.CboEnddate_H.Value);
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value) == "ALL" ? "" : Convert.ToString(this.cboPlantCode_H.Value);  // 공장코드                           
                string sOPCode = txtProcessCode.Text.Trim(); ;
                string sLineCode = "";
                string sItemCode = txtItemCode.Text.Trim();
                string sWorkCenterCode = txtLineCode.Text.Trim();
                string sCarType = Convert.ToString(cboCarType.Value);

                grid1.DataSource = helper.FillTable("USP_AP0310_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCODE", sOPCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LINECODE", sLineCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CARTYPE", sCarType, DbType.String, ParameterDirection.Input)
                                                                    );

                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion
    }
}

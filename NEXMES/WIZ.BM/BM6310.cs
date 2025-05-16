#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM6310
//   Form Name    : 품목 마스터
//   Name Space   : WIZ.BM
//   Created Date : 2012-06-08
//   Made By      : WIZCORE
//   Description  : 기준정보 ( 품목 마스터 ) 정보 관리 폼 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM6310 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        BizGridManager gridManager;
        #endregion

        #region < CONSTRUCTOR >
        public BM6310()
        {
            InitializeComponent();
            gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("OPCODE", "OPNAME", "TBM0400", new string[] { "PLANTCODE", "" });
            gridManager.PopUpAdd("LINECODE", "LINENAME", "TBM0500", new string[] { "PLANTCODE", "", "OPCODE" });
            gridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "TBM0600Y", new string[] { "PLANTCODE", "OPCODE", "LINECODE", "" });

        }
        #endregion

        #region 폼 초기화

        private void BM6310_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RECEIVER", "측정기 그룹", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "RECEIVER", "계측기그룹", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASUREEQUID", "측정기", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASUREEQUNAME", "측정기명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MACHTYPE", "측정기타입", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARKS", "비고", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  // 사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
                this._GridUtil.Grid_Clear(grid1);
                this._GridUtil.Grid_Clear(grid2);
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string sSubAcqusitionNo = this.txtSubAcqusitionNo.Text.ToString();
                string sMeasureCode = this.txtMeasureCode.Text.ToString();
                //string stxtItemCode = txtWorkCenterCode_H.Text;

                grid1.DataSource = helper.FillTable("USP_BM6310_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(this.cboUseFlag.Value), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("RECEIVER", sSubAcqusitionNo, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MEASURECODE", sMeasureCode, DbType.String, ParameterDirection.Input)
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
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                this._GridUtil.Grid_Clear(grid2);
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string sMeasureCode = this.txtMeasureCode.Text.ToString();
                //string stxtItemCode = txtWorkCenterCode_H.Text;

                grid2.DataSource = helper.FillTable("USP_BM6310_S2", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(this.cboUseFlag.Value), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("RECEIVER", this.grid1.ActiveRow.Cells["RECEIVER"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("MEASURECODE", sMeasureCode, DbType.String, ParameterDirection.Input)
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
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();
            int iRow = 0;
            if (this.grid2.IsActivate)
            {
                if (this.grid1.Rows.Count == 0)
                {
                    WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm("R00111");
                    checkform.ShowDialog();
                    return;
                }
                this.grid2.UpdateData();
                for (int i = 0; i < this.grid2.Rows.Count; i++)
                {
                    if (this.grid2.Rows[i].Cells["MEASUREEQUID"].Value.ToString() == "")
                    {
                        return;
                    }
                }
                iRow = this.grid2.InsertRow();
                this.grid2.ActiveRow.Cells["PLANTCODE"].Value = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
                this.grid2.ActiveRow.Cells["RECEIVER"].Value = this.grid1.ActiveRow.Cells["RECEIVER"].Value.ToString();
                this.grid2.ActiveRow.Cells["USEFLAG"].Value = "Y";
                return;
            }
            for (int i = 0; i < this.grid1.Rows.Count; i++)
            {
                if (this.grid1.Rows[i].Cells["RECEIVER"].Value.ToString() == "")
                {
                    return;
                }
            }
            this.grid1.UpdateData();
            iRow = this.grid1.InsertRow();
            this.grid1.ActiveRow.Cells["PLANTCODE"].Value = CModule.GetAppSetting("Site", "10");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "PLANTCODE");
            iRow = this.grid2.InsertRow();
            this.grid2.ActiveRow.Cells["PLANTCODE"].Value = CModule.GetAppSetting("Site", "10");
            this.grid2.ActiveRow.Cells["USEFLAG"].Value = "Y";
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            this.grid2.DeleteRow();
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
            string sReceiver = this.grid1.ActiveRow.Cells["RECEIVER"].Value.ToString();
            string sOpCode = this.grid1.ActiveRow.Cells["OPCODE"].Value.ToString();
            string sLineCode = this.grid1.ActiveRow.Cells["LINECODE"].Value.ToString();
            string sWorkcenterCode = this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
            string sPlantCode = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();


            if (sOpCode == "")
            {
                this.ShowDialog(Common.getLangText("공정을 입력하지 않았습니다. 선택후 등록 가능합니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }
            else if (sLineCode == "")
            {
                this.ShowDialog(Common.getLangText("라인을 입력하지 않았습니다. 선택후 등록 가능합니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }
            else if (sWorkcenterCode == "")
            {
                this.ShowDialog(Common.getLangText("작업장을 입력하지 않았습니다. 선택후 등록 가능합니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }
            for (int i = 0; i < this.grid2.Rows.Count; i++)
            {
                if (this.grid2.Rows[i].Cells["MEASUREEQUID"].Value.ToString() == "")
                {
                    this.ShowDialog(Common.getLangText("측정기 ID 가 없는 행이 존재 합니다. 등록후 저장 가능합니다.", "MSG"), DialogForm.DialogType.OK);
                    return;
                }
            }


            DataTable dt = grid2.chkChange();
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
                            helper.ExecuteNoneQuery("USP_BM6310_D1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("RECEIVER", sReceiver, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MEASUREEQUID", Convert.ToString(drRow["MEASUREEQUID"]), DbType.String, ParameterDirection.Input)
                                                   );
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM6310_I1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("RECEIVER", sReceiver, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MEASUREEQUID", Convert.ToString(drRow["MEASUREEQUID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MEASUREEQUNAME", Convert.ToString(drRow["MEASUREEQUNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("LINECODE", sLineCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MACHTYPE", Convert.ToString(drRow["MACHTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("REMARKS", Convert.ToString(drRow["REMARKS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                   );
                            sReceiver = helper.RSMSG;
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM6310_U1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("RECEIVER", Convert.ToString(drRow["RECEIVER"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MEASUREEQUID", Convert.ToString(drRow["MEASUREEQUID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MEASUREEQUNAME", Convert.ToString(drRow["MEASUREEQUNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("LINECODE", sLineCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MACHTYPE", Convert.ToString(drRow["MACHTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("REMARKS", Convert.ToString(drRow["REMARKS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                   );
                            sReceiver = Convert.ToString(drRow["RECEIVER"]);
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PLANTCODE,RECEIVER");
                helper.Commit();
                DoInquire();
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (this.grid1.Rows[i].Cells["RECEIVER"].Value.ToString() == sReceiver)
                    {
                        this.grid1.Rows[i].Activated = true;
                        break;
                    }
                }
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
        private void grid1_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            if (this.grid1.Rows.Count == 0) return;
            if (e.Cell.Column.Key == "RECEIVER")
            {
                this.grid1.ActiveRow.Cells["PLANTCODE"].Selected = true;
                this.grid1.ActiveRow.Cells["PLANTCODE"].Activated = true;
            }

        }


    }
}
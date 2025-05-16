#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM6320
//   Form Name    : 측정기 마스터
//   Name Space   : WIZ.BM
//   Created Date : 2015-12-03
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM6320 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        BizGridManager gridManager;
        #endregion

        #region < CONSTRUCTOR >
        public BM6320()
        {
            InitializeComponent();
            gridManager = new BizGridManager(grid1);
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtEQUIPID, txtEQUIPIDNM, "TBM6320", new object[] { "", "" }); //측정기
        }
        #endregion

        #region 폼 초기화

        private void BM6320_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREEQUID", "측정기", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREEQUNAME", "측정기명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SERIALNO", "시리얼NO", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHTYPE", "측정기타입", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARKS", "비고", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  // 사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string sMeasureCode = this.txtEQUIPID.Text.ToString();
                string sUseFlag = Convert.ToString(this.cboUseFlag.Value);
                grid1.DataSource = helper.FillTable("USP_BM6320_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MEASURECODE", sMeasureCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(this.cboUseFlag.Value), DbType.String, ParameterDirection.Input)
                                                                    );

                grid1.DataBinds();

                //조회시 미사용은 노란색으로 표시
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value.ToString()) == "N")
                    {
                        grid1.Rows[i].Appearance.BackColor = Color.FromArgb(254, 255, 100);
                    }

                }

                grid1.DisplayLayout.Bands[0].Columns["MEASUREEQUID"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Activation.NoEdit;

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
                int iRow = 0;
                iRow = this.grid1.InsertRow();

                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = CModule.GetAppSetting("Site", "10");
                this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";

                grid1.ActiveRow.Cells["MEASUREEQUID"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }


            this.grid1.ActiveRow.Cells["PLANTCODE"].Value = CModule.GetAppSetting("Site", "10");
            this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
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
            //string sPlantCode      = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
            string sMeasureEquId = "";
            for (int i = 0; i < this.grid1.Rows.Count; i++)
            {
                if (this.grid1.Rows[i].Cells["MEASUREEQUNAME"].Value.ToString() == "")
                {
                    this.ShowDialog(Common.getLangText("측정기명이 없는 행이 존재 합니다. 등록후 저장 가능합니다.", "MSG"), DialogForm.DialogType.OK);
                    return;
                }
            }
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
                            helper.ExecuteNoneQuery("USP_BM6320_D1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MEASUREEQUID", Convert.ToString(drRow["MEASUREEQUID"]), DbType.String, ParameterDirection.Input)
                                                   );
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM6320_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MEASUREEQUID", Convert.ToString(drRow["MEASUREEQUID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MEASUREEQUNAME", Convert.ToString(drRow["MEASUREEQUNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SERIALNO", Convert.ToString(drRow["SERIALNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MACHTYPE", Convert.ToString(drRow["MACHTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("REMARKS", Convert.ToString(drRow["REMARKS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                   );
                            sMeasureEquId = helper.RSMSG;
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM6320_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MEASUREEQUID", Convert.ToString(drRow["MEASUREEQUID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MEASUREEQUNAME", Convert.ToString(drRow["MEASUREEQUNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SERIALNO", Convert.ToString(drRow["SERIALNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MACHTYPE", Convert.ToString(drRow["MACHTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("REMARKS", Convert.ToString(drRow["REMARKS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                   );
                            sMeasureEquId = helper.RSMSG;
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                helper.Commit();
                DoInquire();
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (this.grid1.Rows[i].Cells["MEASUREEQUID"].Value.ToString() == sMeasureEquId)
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
    }
}
#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM9400Y
//   Form Name    : 라인코드 마스터
//   Name Space   : WIZ.BM
//   Created Date : 2012-03-15
//   Made By      : WIZCORE
//   Description  : 기준정보 ( 라인 코드 마스터 ) 정보 관리 폼
// *---------------------------------------------------------------------------------------------*
#endregion


#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.BM
{
    public partial class BM9400Y : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성


        private bool formLoad = false;
        private bool bChk = false;
        #endregion

        #region < CONSTRUCTOR >
        public BM9400Y()
        {
            InitializeComponent();
        }
        #endregion

        #region 폼 초기화

        private void BM9400Y_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BOXSPEC", "용기코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BOXDESC", "용기명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BOXQTY", "용기당 수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "수량별 단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일시", false, GridColDataType_emu.VarChar, 180, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일시", false, GridColDataType_emu.VarChar, 180, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            //grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.Yellow;
            //grid1.DisplayLayout.Bands[0].Columns["OPCODE"].Header.Appearance.ForeColor    = Color.Yellow;
            //grid1.DisplayLayout.Bands[0].Columns["LINECODE"].Header.Appearance.ForeColor  = Color.Yellow;
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboUseFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboUseFlag.Value = "Y";
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
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag.Value);

                grid1.DataSource = helper.FillTable("USP_BM9400_S1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                    );
                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    grid1.DataBinds();
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
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

                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.Disabled;


                if (grid1.Rows.Count > 1)
                {
                    int iRows = grid1.ActiveRow.Index;

                    grid1.SetDefaultValue("PLANTCODE", grid1.Rows[iRows - 1].Cells["PLANTCODE"].Value.ToString());
                    grid1.SetDefaultValue("USEFLAG", "Y");
                }
                else
                {
                    grid1.SetDefaultValue("PLANTCODE", CModule.GetAppSetting("Site", "10"));
                    grid1.SetDefaultValue("USEFLAG", "Y");
                }


                grid1.UpdateData();


            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString());
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

                string sPlantCode = "";
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();
                int li_cnt = 0;
                string sMaker = DBHelper.nvlString(this.WorkerID);

                this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

                foreach (DataRow drRow in ((DataTable)grid1.DataSource).GetChanges().Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["BOXSPEC"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "용기 코드 는 필수 입력 항목입니다.");
                            li_cnt = 1;
                            continue;
                        }

                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            sPlantCode = Convert.ToString(drRow["PlantCode"]);

                            helper.ExecuteNoneQuery("USP_BM9400Y_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("BOXSPEC", Convert.ToString(drRow["BOXSPEC"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("EDITOR", sMaker, DbType.String, ParameterDirection.Input)
                            );

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            // 2015.12.24 mskwon 용기코드 중복건은 DB단에서 처리로 변경
                            //for (int i = 0; i < this.grid1.Rows.Count; i++)
                            //{
                            //    if (drRow["BOXSPEC"].ToString() == Convert.ToString(this.grid1.Rows[i].Cells["BOXSPEC"].Value))
                            //    {
                            //        grid1.SetRowError(drRow, "용기코드는 중복 될 수 없습니다.");
                            //        return;
                            //    }
                            //}

                            helper.ExecuteNoneQuery("USP_BM9400Y_I1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("BOXSPEC", Convert.ToString(drRow["BOXSPEC"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("BOXDESC", Convert.ToString(drRow["BOXDESC"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("BOXQTY", Convert.ToString(drRow["BOXQTY"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKER", sMaker, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REMARK", Convert.ToString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UNITCODE", Convert.ToString(drRow["UNITCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM9400Y_U1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("BOXSPEC", Convert.ToString(drRow["BOXSPEC"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("BOXDESC", Convert.ToString(drRow["BOXDESC"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("BOXQTY", Convert.ToString(drRow["BOXQTY"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKER", sMaker, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REMARK", Convert.ToString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UNITCODE", Convert.ToString(drRow["UNITCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input));
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

        private void grid1_KeyPressed(Control.Grid sender, KeyPressEventArgs e)
        {
            if (this.grid1.Rows.Count == 0) return;
            if (((WIZ.Control.Grid)(sender)).ActiveCell == null) return;
            //숫자 그리드 헤더 컬럼명 찾기
            if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "BOXQTY")
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".")))
                {
                    // 숫자입력 메시지창 표현.
                    MessageBox.Show(Common.getLangText("숫자만 입력하여 주십시요", "MSG"));
                    e.Handled = true;
                }
            }
        }

        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Appearance.BackColor = Color.White;
        }
    }
}

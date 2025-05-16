#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM3680
//   Form Name    : 현장점검기준관리
//   Name Space   : WIZ.BM
//   Created Date : 2013-12-06
//   Made By      : WIZCORE
//   Description  : 현장 점검기준을 관리한다.
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;

using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM3680 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();


        BizTextBoxManager btbManager;
        BizGridManager gridManager;

        #endregion

        #region < CONSTRUCTOR >

        public BM3680()
        {
            InitializeComponent();

            // POP-UP 처리 필요 ( 조회창 : 품목, grid : 품목, 검사항목 : InspCode)
            btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtCheckCode, txtCheckCodeNm, "TBM3680", new object[] { "", "" });

        }

        #endregion

        #region 폼 초기화

        private void BM3680_Load(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "CheckType", "점검구분", false, GridColDataType_emu.VarChar, 180, 180, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CheckCode", "점검항목코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CheckDesc", "점검항목", false, GridColDataType_emu.VarChar, 400, 500, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT", "등록형태", false, GridColDataType_emu.VarChar, 100, 200, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            #region 콤보박스

            rtnDtTemp = _Common.GET_BM0000_CODE("CHECKTYPE");      //점검구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CheckType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("INSPVALTYPE");    //등록형태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "INSPRESULT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");        //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
                string sCheckType = DBHelper.nvlString(cboCheckType.Value, "");
                string sCheckTypeNm = txtCheckTypeNm.Text.Trim();
                string sCheckCode = txtCheckCode.Text.Trim();
                string sCheckDesc = txtCheckCodeNm.Text.Trim();
                string sUseFlag = DBHelper.nvlString(cboUseFlag.Value, "");

                base.DoInquire();

                grid1.DataSource = helper.FillTable("USP_BM3680_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("CheckType", sCheckType, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CheckCode", sCheckCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CheckDesc", sCheckDesc, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));

                grid1.DataBind();

                //_Common.Grid_Column_Width(this.grid1); //grid 정리용
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

                int iRow = this.grid1.InsertRow();

                UltraGridUtil.ActivationAllowEdit(grid1, "CheckType", iRow);
                UltraGridUtil.ActivationAllowEdit(grid1, "CheckCode", iRow);
                UltraGridUtil.ActivationAllowEdit(grid1, "CheckDesc", iRow);
                UltraGridUtil.ActivationAllowEdit(grid1, "INSPRESULT", iRow);
                UltraGridUtil.ActivationAllowEdit(grid1, "DisplayNo", iRow);
                UltraGridUtil.ActivationAllowEdit(grid1, "UseFlag", iRow);

            }
            catch (Exception ex)
            {
                throw ex;
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
            DBHelper helper = new DBHelper("", true);

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                base.DoSave();

                UltraGridUtil.DataRowDelete(this.grid1);

                this.grid1.UpdateData();

                foreach (DataRow drRow in ((DataTable)grid1.DataSource).GetChanges().Rows)  // .GetChanges().Rows = 변경된 Rows 만 작업
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM3680_D1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("CheckType", Convert.ToString(drRow["CheckType"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CheckCode", Convert.ToString(drRow["CheckCode"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM3680_I1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("CheckType", Convert.ToString(drRow["CheckType"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CheckCode", Convert.ToString(drRow["CheckCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CheckDesc", Convert.ToString(drRow["CheckDesc"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPRESULT", Convert.ToString(drRow["INSPRESULT"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DisplayNo", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM3680_U1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("CheckType", Convert.ToString(drRow["CheckType"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CheckCode", Convert.ToString(drRow["CheckCode"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CheckDesc", Convert.ToString(drRow["CheckDesc"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPRESULT", Convert.ToString(drRow["INSPRESULT"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("DisplayNo", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                }

                helper.Commit();

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

/* 개발정보
  Form Name    : 품목별 프린터관리
  Created Date : 2019-12-18
  Made By      : 윤석현
  Description  : 프린터 서버 구축에 필요한 기본 정보 등록/수정
*/

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM9750 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        Common _Common = new Common();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();

        string sUserID = WIZ.LoginInfo.UserID;
        DateTime dtNow = DateTime.Now;

        #endregion

        #region < CONSTRUCTOR >

        public BM9750()
        {
            InitializeComponent();

        }
        #endregion

        #region < FORM LOAD >
        private void BM9750_Load(object sender, EventArgs e)
        {
            #region GRID SETTING
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PRINTERNAME", "프린터명", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CIP", "IP주소", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INSERTTIME", "추가날짜", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);


            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PRINTERNAME"].Header.Appearance.ForeColor = Color.SkyBlue;

            #endregion

            DataTable rtnDtTemp = new DataTable();  // return DataTable 공통

            #region COMBO BOX
            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion



            #region POPUP

            #endregion

        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 Click
        /// </summary>
        public override void DoInquire()
        {
            this._GridUtil.Grid_Clear(grid1);

            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();

                rtnDtTemp = helper.FillTable("USP_BM9750_S1", CommandType.StoredProcedure);

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();

            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }

        }
        /// <summary>
        /// ToolBar의 추가 버튼 Click
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();

                this.grid1.InsertRow();

                //사용여부는 행 추가시 기본으로 세팅
                this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                grid1.ActiveRow.Cells["INSERTTIME"].Activation = Activation.NoEdit;

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
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
            rtnDtTemp = grid1.chkChange();

            DateTime dtNow = DateTime.Now;

            if (rtnDtTemp == null)
            {
                return;
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    //필수입력항목이 입력되었는지 확인
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        #region [ validation 체크 ]
                        if (Convert.ToString(drRow["PRINTERNAME"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("프린터명은 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM9750_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PRINTERNAME", DBHelper.nvlString(drRow["PRINTERNAME"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가                            
                            helper.ExecuteNoneQuery("USP_BM9750_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PRINTERNAME", DBHelper.nvlString(drRow["PRINTERNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CIP", DBHelper.nvlString(drRow["CIP"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSERTTIME", DBHelper.nvlDateTime(drRow["INSERTTIME"]), DbType.DateTime, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM9750_U1"
                                                     , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PRINTERNAME", DBHelper.nvlString(drRow["PRINTERNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CIP", DBHelper.nvlString(drRow["CIP"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSERTTIME", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }
                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();
                    DoInquire(); //성공적으로 수행되었을 경우에만 조회
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
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
    }
}
#endregion




#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0630
//   Form Name    : 근무형태관리
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 김병수
//   Edited Date  : 
//   Edit By      :
//   Description  : 각종 근무시간의 형태를 코드화 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM0630 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0630()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0630_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 근무형태관리
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WRKTYPECODE", "근무형태코드", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WRKSTIME", "작업시작시간", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WRKETIME", "작업종료시간", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WRKHOURS", "작업시간", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP1STIME", "계획정지 시작 #1", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP1ETIME", "계획정지 종료 #1", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP1HOURS", "계획정지 시간 #1", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP2STIME", "계획정지 시작 #2", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP2ETIME", "계획정지 종료 #2", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP2HOURS", "계획정지 시간 #2", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP3STIME", "계획정지 시작 #3", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP3ETIME", "계획정지 종료 #3", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP3HOURS", "계획정지 시간 #3", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP4STIME", "계획정지 시작 #4", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP4ETIME", "계획정지 종료 #4", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP4HOURS", "계획정지 시간 #4", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP5STIME", "계획정지 시작 #5", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP5ETIME", "계획정지 종료 #5", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP5HOURS", "계획정지 시간 #5", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP6STIME", "계획정지 시작 #6", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP6ETIME", "계획정지 종료 #6", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP6HOURS", "계획정지 시간 #6", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP7STIME", "계획정지 시작 #7", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP7ETIME", "계획정지 종료 #7", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP7HOURS", "계획정지 시간 #7", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP8STIME", "계획정지 시작 #8", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP8ETIME", "계획정지 종료 #8", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP8HOURS", "계획정지 시간 #8", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP9STIME", "계획정지 시작 #9", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP9ETIME", "계획정지 종료 #9", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOP9HOURS", "계획정지 시간 #9", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "OTSTIME", "잔업 시작 시간", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "OTETIME", "잔업 종료 시간", false, GridColDataType_emu.Time24WithSpin, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "OTHOURS", "잔업 시간", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "TOTALSTIME", "전체 작업시작 시간", false, GridColDataType_emu.Time24WithSpin, 140, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "TOTALETIME", "전체 작업종료 시간", false, GridColDataType_emu.Time24WithSpin, 140, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "TOTALHOURS", "전체 작업 시간", false, GridColDataType_emu.Double, 140, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 500, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);


                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["WRKTYPECODE"].Header.Appearance.ForeColor = Color.SkyBlue;


                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("WRKTYPECODE"); //품목유형
                WIZ.Common.FillComboboxMaster(this.cbo_WRKTYPECODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WRKTYPECODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


                #endregion

                #region POPUP SETTING


                #endregion
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sWrktypeCode = DBHelper.nvlString(cbo_WRKTYPECODE_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM0630_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WRKTYPECODE", sWrktypeCode, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
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

                //사업장과 사용여부는 행 추가시 기본으로 세팅
                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
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

            //this.grid1.DeleteRow(); //BM은 삭제기능 비활성화
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
                        if (Convert.ToString(drRow["PLANTCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("사업장은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (Convert.ToString(drRow["WRKTYPECODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("근무형태코드는 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >
                            //drRow.RejectChanges();

                            //helper.ExecuteNoneQuery("USP_BM0630_D1"
                            //                        , CommandType.StoredProcedure
                            //                        , helper.CreateParameter("AS_PLANTCODE",       DBHelper.nvlString(drRow["PLANTCODE"]),  DbType.String, ParameterDirection.Input)
                            //                        , helper.CreateParameter("AS_ITEMCODE",        DBHelper.nvlString(drRow["ITEMCODE"]),   DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가                            
                            helper.ExecuteNoneQuery("USP_BM0630_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WRKTYPECODE", DBHelper.nvlString(drRow["WRKTYPECODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WRKSTIME", DBHelper.nvlString(drRow["WRKSTIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["WRKSTIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WRKETIME", DBHelper.nvlString(drRow["WRKETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["WRKETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP1STIME", DBHelper.nvlString(drRow["STOP1STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP1STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP1ETIME", DBHelper.nvlString(drRow["STOP1ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP1ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP2STIME", DBHelper.nvlString(drRow["STOP2STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP2STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP2ETIME", DBHelper.nvlString(drRow["STOP2ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP2ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP3STIME", DBHelper.nvlString(drRow["STOP3STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP3STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP3ETIME", DBHelper.nvlString(drRow["STOP3ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP3ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP4STIME", DBHelper.nvlString(drRow["STOP4STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP4STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP4ETIME", DBHelper.nvlString(drRow["STOP4ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP4ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP5STIME", DBHelper.nvlString(drRow["STOP5STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP5STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP5ETIME", DBHelper.nvlString(drRow["STOP5ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP5ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP6STIME", DBHelper.nvlString(drRow["STOP6STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP6STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP6ETIME", DBHelper.nvlString(drRow["STOP6ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP6ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP7STIME", DBHelper.nvlString(drRow["STOP7STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP7STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP7ETIME", DBHelper.nvlString(drRow["STOP7ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP7ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP8STIME", DBHelper.nvlString(drRow["STOP8STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP8STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP8ETIME", DBHelper.nvlString(drRow["STOP8ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP8ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP9STIME", DBHelper.nvlString(drRow["STOP9STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP9STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP9ETIME", DBHelper.nvlString(drRow["STOP9ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP9ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OTSTIME", DBHelper.nvlString(drRow["OTSTIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["OTSTIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OTETIME", DBHelper.nvlString(drRow["OTETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["OTETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TOTALSTIME", DBHelper.nvlString(drRow["TOTALSTIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["TOTALSTIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TOTALETIME", DBHelper.nvlString(drRow["TOTALETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["TOTALETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0630_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WRKTYPECODE", DBHelper.nvlString(drRow["WRKTYPECODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WRKSTIME", DBHelper.nvlString(drRow["WRKSTIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["WRKSTIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WRKETIME", DBHelper.nvlString(drRow["WRKETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["WRKETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP1STIME", DBHelper.nvlString(drRow["STOP1STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP1STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP1ETIME", DBHelper.nvlString(drRow["STOP1ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP1ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP2STIME", DBHelper.nvlString(drRow["STOP2STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP2STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP2ETIME", DBHelper.nvlString(drRow["STOP2ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP2ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP3STIME", DBHelper.nvlString(drRow["STOP3STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP3STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP3ETIME", DBHelper.nvlString(drRow["STOP3ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP3ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP4STIME", DBHelper.nvlString(drRow["STOP4STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP4STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP4ETIME", DBHelper.nvlString(drRow["STOP4ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP4ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP5STIME", DBHelper.nvlString(drRow["STOP5STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP5STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP5ETIME", DBHelper.nvlString(drRow["STOP5ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP5ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP6STIME", DBHelper.nvlString(drRow["STOP6STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP6STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP6ETIME", DBHelper.nvlString(drRow["STOP6ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP6ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP7STIME", DBHelper.nvlString(drRow["STOP7STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP7STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP7ETIME", DBHelper.nvlString(drRow["STOP7ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP7ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP8STIME", DBHelper.nvlString(drRow["STOP8STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP8STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP8ETIME", DBHelper.nvlString(drRow["STOP8ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP8ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP9STIME", DBHelper.nvlString(drRow["STOP9STIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP9STIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOP9ETIME", DBHelper.nvlString(drRow["STOP9ETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["STOP9ETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OTSTIME", DBHelper.nvlString(drRow["OTSTIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["OTSTIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OTETIME", DBHelper.nvlString(drRow["OTETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["OTETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TOTALSTIME", DBHelper.nvlString(drRow["TOTALSTIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["TOTALSTIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TOTALETIME", DBHelper.nvlString(drRow["TOTALETIME"]) == "" ? "" : DBHelper.nvlDateTime(drRow["TOTALETIME"]).ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EDITOR", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
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
        /// <summary>
        /// ToolBar의 엑셀업로드 버튼 Click
        /// </summary>
        public override void DoImportExcel()
        {
            base.DoImportExcel();

            BM0630_EXCEL bm0630_excel = new BM0630_EXCEL();
            bm0630_excel.ShowDialog();
            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >

        #endregion


    }
}
#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0020
//   Form Name    : 작업자마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-05
//   Made By      : WIZCORE 남부사무소 사원 김병수
//   Edited Date  : 
//   Edit By      :
//   Description  : 작업자의 기준 정보 관리
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
    public partial class BM0020 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0020()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0020_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 작업자
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID", "작업자ID", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "작업자명", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE", "부서", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "VIEWNAME", "이니셜", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PASSWORD", "비밀번호", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "GRPID", "권한그룹", true, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정코드", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "TEAMCODE", "팀코드", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "BANCODE", "작업반", true, GridColDataType_emu.VarChar, 130, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CLASSCODE", "그룹코드", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHT", "주야구분", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SHIFTGB", "조코드", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "EMPNO", "사번", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "EMPTELNO", "연락처", true, GridColDataType_emu.VarChar, 150, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "INDATE", "입사일", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "OUTDATE", "퇴사일", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "LANG", "언어", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAILID", "메일", true, GridColDataType_emu.VarChar, 170, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PHONENO", "PHONE 번호", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SYSFLAG", "시스템여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHFLAG", "설비보전작업자", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["WORKERID"].Header.Appearance.ForeColor = Color.SkyBlue;

                grid1.DisplayLayout.Bands[0].Columns["INDATE"].MaskInput = "####-##-##";
                grid1.DisplayLayout.Bands[0].Columns["OUTDATE"].MaskInput = "####-##-##";

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("GRPID"); //권한그룹
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "GRPID", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT"); //주야구분
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DAYNIGHT", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("DEPTCODE"); //부서코드
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.Common.FillComboboxMaster(this.cbo_DEPTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

                rtnDtTemp = _Common.GET_BM0000_CODE("BANCODE"); //반코드
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "BANCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //2021-03-03 설비보전작업자 Y 이면 사용해서MES, DAS 설비고장 등록 (설비보전작업자가 조회 가능)
                // USP_DX1010_S1 설비보전작업자 조회 - 참조
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MACHFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //작업자
                btbManager.PopUpAdd(txt_WORKERID_H, txt_WORKERNAME_H, "BM0020", new object[] { cbo_PLANTCODE_H, "", "" });

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
                string sWorkerId = DBHelper.nvlString(txt_WORKERID_H.Text.Trim());
                string sDeptCode = DBHelper.nvlString(cbo_DEPTCODE_H.Value);
                string sWorkerName = DBHelper.nvlString(txt_WORKERNAME_H.Text.Trim());
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM0020_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKERID", sWorkerId, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_DEPTCODE", sDeptCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKERNAME", sWorkerName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

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
                this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";

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

            this.grid1.DeleteRow(); //BM은 삭제기능 비활성화
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
                        if (Convert.ToString(drRow["WORKERID"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("작업자 ID는 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가                            
                            helper.ExecuteNoneQuery("USP_BM0020_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKERID", DBHelper.nvlString(drRow["WORKERID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKERNAME", DBHelper.nvlString(drRow["WORKERNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PASSWORD", DBHelper.nvlString(drRow["PASSWORD"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_GRPID", DBHelper.nvlString(drRow["GRPID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OPCODE", DBHelper.nvlString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DEPTCODE", DBHelper.nvlString(drRow["DEPTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TEAMCODE", DBHelper.nvlString(drRow["TEAMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BANCODE", DBHelper.nvlString(drRow["BANCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CLASSCODE", DBHelper.nvlString(drRow["CLASSCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DAYNIGHT", DBHelper.nvlString(drRow["DAYNIGHT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SHIFTGB", DBHelper.nvlString(drRow["SHIFTGB"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EMPNO", DBHelper.nvlString(drRow["EMPNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EMPTELNO", DBHelper.nvlString(drRow["EMPTELNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INDATE", DBHelper.nvlString(drRow["INDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OUTDATE", DBHelper.nvlString(drRow["OUTDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LANG", DBHelper.nvlString(drRow["LANG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAILID", DBHelper.nvlString(drRow["MAILID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PHONENO", DBHelper.nvlString(drRow["PHONENO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_VIEWNAME", DBHelper.nvlString(drRow["VIEWNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SYSFLAG", DBHelper.nvlString(drRow["SYSFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHFLAG", DBHelper.nvlString(drRow["MACHFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0020_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKERID", DBHelper.nvlString(drRow["WORKERID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKERNAME", DBHelper.nvlString(drRow["WORKERNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PASSWORD", DBHelper.nvlString(drRow["PASSWORD"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_GRPID", DBHelper.nvlString(drRow["GRPID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OPCODE", DBHelper.nvlString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DEPTCODE", DBHelper.nvlString(drRow["DEPTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TEAMCODE", DBHelper.nvlString(drRow["TEAMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BANCODE", DBHelper.nvlString(drRow["BANCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CLASSCODE", DBHelper.nvlString(drRow["CLASSCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DAYNIGHT", DBHelper.nvlString(drRow["DAYNIGHT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SHIFTGB", DBHelper.nvlString(drRow["SHIFTGB"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EMPNO", DBHelper.nvlString(drRow["EMPNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EMPTELNO", DBHelper.nvlString(drRow["EMPTELNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INDATE", DBHelper.nvlString(drRow["INDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OUTDATE", DBHelper.nvlString(drRow["OUTDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LANG", DBHelper.nvlString(drRow["LANG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAILID", DBHelper.nvlString(drRow["MAILID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PHONENO", DBHelper.nvlString(drRow["PHONENO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_VIEWNAME", DBHelper.nvlString(drRow["VIEWNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SYSFLAG", DBHelper.nvlString(drRow["SYSFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHFLAG", DBHelper.nvlString(drRow["MACHFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
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

            BM0020_EXCEL bm0020_excel = new BM0020_EXCEL();
            bm0020_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >

        #endregion

    }
}
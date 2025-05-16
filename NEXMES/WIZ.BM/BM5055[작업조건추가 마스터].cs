#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM5055
//   Form Name    : 라우터마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-04
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Edited Date  : 
//   Edit By      :
//   Description  : 라우트 정보를 관리                                     
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
    public partial class BM5055 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp2 = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM5055()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM5055_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 작업조건 메인
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "METHODCODE", "작업조건코드", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "METHODNAME", "작업조건이름", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SEQ", "순서", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SUBCODE", "적용이름", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SUBNAME", "적용수치", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "TYPE", "적용타입", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CODE1", "CODE1", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CODE2", "CODE2", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CODE3", "CODE3", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CODE4", "CODE4", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CODE5", "CODE5", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);

                //A.CODE1, A.CODE2, A.CODE3, A.CODE4, A.CODE5
                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["METHODCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["METHODNAME"].Header.Appearance.ForeColor = Color.SkyBlue;

                //_GridUtil.InitializeGrid(this.grid2, false, true, true, "", false);
                //_GridUtil.InitColumnUltraGrid(grid2, "MethodItem", "작업항목코드", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, false, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "MethodName", "작업항목이름", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "AccessPoint", "처리시점", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "AlarmPoint", "알람시점", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 90, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                //_GridUtil.SetInitUltraGridBind(grid2);

                ////필수입력 항목에 대한 음영
                //grid2.DisplayLayout.Bands[0].Columns["MethodCode"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid2.DisplayLayout.Bands[0].Columns["MethodName"].Header.Appearance.ForeColor = Color.SkyBlue;


                #endregion

                #region COMBOBOX SETTING

                //rtnDtTemp = _Common.GET_BM0000_CODE("ACCESSPOINT"); //접속여부
                //WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "AccessPoint", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                //WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //알람사용여부
                //WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseAlarm", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0000_CODE("INTERLOCK"); //진행불가여부
                //WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InterLock", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                #endregion

                #region POPUP SETTING

                //품목
                //btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });

                ////공정
                //btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });

                ////라인
                //btbManager.PopUpAdd(txt_LINECODE_H, txt_LINENAME_H, "BM0050", new object[] { cbo_PLANTCODE_H, txt_OPCODE_H, cbo_USEFLAG_H });

                ////작업장
                //btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, txt_OPCODE_H, txt_LINECODE_H, cbo_USEFLAG_H });

                DBHelper helper = new DBHelper(false);
                try
                {

                    string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                    rtnDtTemp = helper.FillTable("USP_BM5055_S1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("PTYPE", "S2", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_METHODCODE", "", DbType.String, ParameterDirection.Input));


                    WIZ.Common.FillComboboxMaster(this.cbo_ConditionCode_H, rtnDtTemp, rtnDtTemp.Columns["METHODCODE"].ColumnName, rtnDtTemp.Columns["METHODNAME"].ColumnName, "", "");
                    //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MethodCode", rtnDtTemp, "METHODCODE", "METHODNAME");

                    PopUp.PopUp_Common.SetPop(new object[] { txt_MethodCode_H, txt_MethodName_H }, "METHOD_POP");
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


                //BizGridManager gridManager = new BizGridManager(grid1); //그리드 콤보박스 객체 생성

                //gridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "", "Y" });               
                //gridManager.PopUpAdd("OPCODE", "OPNAME", "BM0040", new string[] { "PLANTCODE", "", "Y" });
                //gridManager.PopUpAdd("LINECODE", "LINENAME", "BM0050", new string[] { "PLANTCODE", "OPCODE", "Y" });
                //gridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "OPCODE", "LINECODE", "Y" });
                //gridManager.PopUpAdd("METHODCODE", "METHODNAME", "BM5000", new string[] { "PLANTCODE", "", "Y" });

                //gridManager.PopUpClosed += GridManager_PopUpClosed;
                #endregion
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void GridManager_PopUpClosed(Control.Grid grid, string sCode, string sName, bool bFindOK)
        {
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
                string sMethodCode = DBHelper.nvlString(txt_MethodCode_H.Value);
                string sMethodName = DBHelper.nvlString(txt_MethodName_H.Value);
                //string sOpCode         = DBHelper.nvlString(txt_OPCODE_H.Text.Trim());
                //string sLineCode       = DBHelper.nvlString(txt_LINECODE_H.Text.Trim());
                //string sWorkCenterCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());
                //string sConCode        = DBHelper.nvlString(tbConditionCode.Text.Trim());
                //string sConName        = DBHelper.nvlString(tbConditionName.Text.Trim());
                //string sUseFlag        = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                rtnDtTemp2 = helper.FillTable("USP_BM5055_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PTYPE", "S1", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_METHODCODE", sMethodCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_METHODNAME", sMethodName, DbType.String, ParameterDirection.Input)
                                                            );

                if (rtnDtTemp2.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp2;
                    grid1.DataBinds(rtnDtTemp2);
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
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sMethodCode = DBHelper.nvlString(cbo_ConditionCode_H.Value);
                string sMethodName = DBHelper.nvlString(cbo_ConditionCode_H.Text);

                if (sPlantCode == "")
                {
                    this.ShowDialog(Common.getLangText("사업장을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                if (sMethodCode == "" || sMethodName == "")
                {
                    this.ShowDialog(Common.getLangText("작업조건코드 콤보박스를 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }


                base.DoNew();

                this.grid1.InsertRow();

                //사업장과 사용여부는 행 추가시 기본으로 세팅
                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = cbo_PLANTCODE_H.Value;
                this.grid1.ActiveRow.Cells["METHODCODE"].Value = sMethodCode;
                this.grid1.ActiveRow.Cells["METHODNAME"].Value = sMethodName;
                //this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                grid1.ActiveRow.Cells["METHODNAME"].Activation = Activation.NoEdit;
                //grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                //grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                //grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                //grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
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

            DBHelper helper = new DBHelper("", false);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                //helper.DBConnect.BeginTransaction();

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    //필수입력항목이 입력되었는지 확인
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        #region [ validation 체크 ]
                        if (Convert.ToString(drRow["MethodCode"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("작업조건코드 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["SEQ"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("순서 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM5055_I1"
                                                   , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PTYPE", "D1", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_METHODCDOE", DBHelper.nvlString(drRow["MethodCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SEQ", DBHelper.nvlString(drRow["SEQ"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SUBCODE", "", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SUBNAME", "", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TYPE", "", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE1", "", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE2", "", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE3", "", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE4", "", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE5", "", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            helper.ExecuteNoneQuery("USP_BM5055_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PTYPE", "I1", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_METHODCDOE", DBHelper.nvlString(drRow["MethodCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SEQ", DBHelper.nvlString(drRow["SEQ"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SUBCODE", DBHelper.nvlString(drRow["SUBCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SUBNAME", DBHelper.nvlString(drRow["SUBNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TYPE", DBHelper.nvlString(drRow["TYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE1", DBHelper.nvlString(drRow["CODE1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE2", DBHelper.nvlString(drRow["CODE2"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE3", DBHelper.nvlString(drRow["CODE3"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE4", DBHelper.nvlString(drRow["CODE4"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE5", DBHelper.nvlString(drRow["CODE5"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input));

                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM5055_I1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PTYPE", "I1", DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_METHODCDOE", DBHelper.nvlString(drRow["MethodCode"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_SEQ", DBHelper.nvlString(drRow["SEQ"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_SUBCODE", DBHelper.nvlString(drRow["SUBCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_SUBNAME", DBHelper.nvlString(drRow["SUBNAME"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_TYPE", DBHelper.nvlString(drRow["TYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE1", DBHelper.nvlString(drRow["CODE1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE2", DBHelper.nvlString(drRow["CODE2"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE3", DBHelper.nvlString(drRow["CODE3"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE4", DBHelper.nvlString(drRow["CODE4"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CODE5", DBHelper.nvlString(drRow["CODE5"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }   // foreach

                //if (helper.RSCODE == "S")
                //{
                this.ClosePrgFormNew();
                //helper.Commit();
                DoInquire(); //성공적으로 수행되었을 경우에만 조회
                //}
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

            //BM5055_EXCEL BM5055_excel = new BM5055_EXCEL();
            //BM5055_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >

        #endregion

        private void txt_ITEMNAME_H_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_MethodCode_H_ValueChanged(object sender, EventArgs e)
        {
            string sMethodCode = txt_MethodCode_H.Text.Trim();

            if (sMethodCode != "")
            {
                cbo_ConditionCode_H.Value = sMethodCode;
            }
        }
    }
}
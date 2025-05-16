#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM5130
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
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM5130 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp2 = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp3 = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        //string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        string sUserID = "562";


        //FTP설정

        private bool bNew = false;
        private bool bFTPNew = false;
        //string ftpServerIP = "1.254.18.170";  //FTP서버 아이피
        string ftpServerIP = "192.168.10.39";  //FTP서버 아이피
        string ftpUserID = "wizcore";    //FTP서버 접속 아이디
        string ftpPassword = "wizcore@1234";  //FTP서버 접속 패스워드
        string ftpPort = "14123";      //FTP서버 포트
        //string ftpUserID = "wizdevftp";    //ftp서버 접속 아이디
        //string ftpPassword = "dk@wiz4085ftp";  //ftp서버 접속 패스워드
        //string ftpPort = "2038";      //ftp서버 포트


        #endregion

        #region < CONSTRUCTOR >
        public BM5130()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM5130_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

                //GRID1 알람발생리스트
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "CHK", "", false, GridColDataType_emu.CheckBox, 40, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "AlarmID", "알람순번", true, GridColDataType_emu.VarChar, 90, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "AlarmCode", "알람코드", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "AlarmMSG", "메세지", true, GridColDataType_emu.VarChar, 500, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "OrderNo", "작업지시", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //Grid2 라우터
                _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "ALARMID", "알람순번", true, GridColDataType_emu.Integer, 100, 140, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "FILENAME", "파일이름", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "FILEPATH", "파일경로", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);


                // grid3 결재라인
                _GridUtil.InitializeGrid(this.grid3, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "ActionLevel", "결재순서", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "WORKERNAME", "결재자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "WORKERID", "결재자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "MAKEDATE", "결재일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid3);

                //필수입력 항목에 대한 음영
                //grid1.DisplayLayout.Bands[0].Columns["MethodCode"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid1.DisplayLayout.Bands[0].Columns["MethodName"].Header.Appearance.ForeColor = Color.SkyBlue;

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;


                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //공정명
                btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", "" });
                //작업장명
                btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });
                //품목
                //btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });

                //공정
                //btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });

                //BizGridManager gridManager = new BizGridManager(grid1); //그리드 콤보박스 객체 생성

                //gridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "", "Y" });               
                //gridManager.PopUpAdd("OPCODE", "OPNAME", "BM0040", new string[] { "PLANTCODE", "", "Y" });
                //gridManager.PopUpAdd("LINECODE", "LINENAME", "BM0050", new string[] { "PLANTCODE", "OPCODE", "Y" });
                //gridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "OPCODE", "LINECODE", "Y" });
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
            _GridUtil.Grid_Clear(grid2);
            _GridUtil.Grid_Clear(grid3);
            sComent.Value = "";
            sTreatMent.Value = "";
            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sAlarmCode = DBHelper.nvlString(txt_OPCODE_H.Text.Trim());
                string sOpCode = DBHelper.nvlString(txt_OPNAME_H.Text.Trim());
                string sWorkCenterCode = DBHelper.nvlString(txt_OPNAME_H.Text.Trim());
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM5130_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PTYPE", "S1", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMCODE", sAlarmCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMID", "", DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("AS_USER", sUserID, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));


                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds(rtnDtTemp);
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
                //this.grid1.ActiveRow.Cells["ITEMCODE"].Value = grid1.ActiveRow.Cells["ITEMCODE"].Value;
                //this.grid1.ActiveRow.Cells["OPCODE"].Value = grid2.ActiveRow.Cells["OPCODE"].Value;
                //this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                //this.grid1.ActiveRow.Cells["USEFLAG"].Value   = "Y";

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
            //rtnDtTemp = grid1.chkChange();

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();
                string sAlarmId = DBHelper.nvlString(grid1.ActiveRow.Cells["ALARMID"].Value);
                string sComents = DBHelper.nvlString(sTreatMent.Value);
                helper.ExecuteNoneQuery("USP_BM5130_I1"
                                        , CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PTYPE", "I1", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ALARMID", sAlarmId, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ALARMCODE", "", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_USER", sUserID, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_COMENT", sComents, DbType.String, ParameterDirection.Input));
                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();
                    //DoInquire(); //성공적으로 수행되었을 경우에만 조회
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

            //BM5130_EXCEL BM5130_excel = new BM5130_EXCEL();
            //BM5130_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >

        #endregion

        private void grid1_ClickCell_1(object sender, ClickCellEventArgs e)
        {
            _GridUtil.Grid_Clear(grid2);
            _GridUtil.Grid_Clear(grid3);
            sComent.Value = "";
            string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string sAlarmCode = DBHelper.nvlString(grid1.ActiveRow.Cells["AlarmCode"].Value);
            string sOpCode = DBHelper.nvlString(grid1.ActiveRow.Cells["OPCODE"].Value);
            string sWorkCenterCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sAlarmId = DBHelper.nvlString(grid1.ActiveRow.Cells["AlarmID"].Value);
            DBHelper helper = new DBHelper(false);
            try
            {
                //파일 리스트 조회
                rtnDtTemp2 = helper.FillTable("USP_BM5130_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PTYPE", "S5", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMCODE", sAlarmCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMID", sAlarmId, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("AS_USER", sUserID, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", "Y", DbType.String, ParameterDirection.Input));

                if (rtnDtTemp2.Rows.Count > 0)
                {
                    DataRow[] dRows = rtnDtTemp2.Select();
                    sTreatMent.Value = DBHelper.nvlString(dRows[0]["ActionText"]);
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
                //_GridUtil.Grid_Clear(grid1);
            }

            call_grid3();
            call_grid2();

        }
        #region [결재]
        private void button1_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);
            int tmpApprovalTotalCount = 0;
            int tmpApprovalSuccessCount = 0;
            int tmpApprovalFailCount = 0;
            List<string> tmpFailList = new List<string>();
            try
            {
                if (this.ShowDialog(Common.getLangText("결재 완료 하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in grid1.Rows)
                {
                    if (DBHelper.nvlBoolean(row.Cells["CHK"].Value) == true)
                    {

                        string sAlarmId = DBHelper.nvlString(row.Cells["AlarmID"].Value);
                        string sAlarmCode = DBHelper.nvlString(row.Cells["AlarmCode"].Value);
                        string sComents = DBHelper.nvlString(sComent.Value);
                        helper.ExecuteNoneQuery("USP_BM5130_I1"
                                                            , CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PTYPE", "I2", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMID", sAlarmId, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMCODE", sAlarmCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USER", sUserID, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_COMENT", sComents, DbType.String, ParameterDirection.Input));
                        if (helper.RSCODE == "S")
                        {
                            ++tmpApprovalSuccessCount;
                        }
                        else
                        {
                            ++tmpApprovalFailCount;
                            tmpFailList.Add(sAlarmId);
                        }
                        ++tmpApprovalTotalCount;
                    }
                }
                if (tmpApprovalTotalCount == 0)
                {
                    this.ShowDialog("알람발생리스트에서 결재할 리스트를 체크해주세요.", Forms.DialogForm.DialogType.OK);
                    return;
                }
                else if (tmpApprovalTotalCount == tmpApprovalSuccessCount)
                {
                    this.ShowDialog("총" + tmpApprovalTotalCount + "건중 " + tmpApprovalSuccessCount + "건이 결재 완료 되었습니다.", Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    string txtFailList = "[ ";
                    foreach (string tmpF in tmpFailList)
                    {
                        txtFailList += tmpF + " ,";
                    }
                    txtFailList += " ]";
                    this.ShowDialog("총" + tmpApprovalFailCount + "건이 결재실패하였습니다. 실패한 알람순번은" + txtFailList + " 입니다.", Forms.DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                return;
            }
            finally
            {
                helper.Close();
                // _GridUtil.Grid_Clear(grid3);
                call_grid3();

            }
        }
        #endregion
        #region [결재라인클릭]
        private void grid3_ClickCell(object sender, ClickCellEventArgs e)
        {
            call_grid3_coment();
        }
        #endregion
        #region [결재취소]
        private void btn_CANCEL_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);
            int tmpApprovalTotalCancelCount = 0;
            try
            {
                if (this.ShowDialog(Common.getLangText("결재취소를 하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in grid1.Rows)
                {
                    if (DBHelper.nvlBoolean(row.Cells["CHK"].Value) == true)
                    {

                        string sAlarmId = DBHelper.nvlString(row.Cells["AlarmID"].Value);
                        string sAlarmCode = DBHelper.nvlString(row.Cells["AlarmCode"].Value);
                        string sComents = DBHelper.nvlString(sComent.Value);
                        helper.ExecuteNoneQuery("USP_BM5130_I1"
                                                            , CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PTYPE", "D1", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMID", sAlarmId, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMCODE", sAlarmCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USER", sUserID, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_COMENT", sComents, DbType.String, ParameterDirection.Input));

                        ++tmpApprovalTotalCancelCount;
                    }
                }
                if (tmpApprovalTotalCancelCount == 0)
                {
                    this.ShowDialog("알람발생리스트에서 결재취소할 리스트를 체크해주세요.", Forms.DialogForm.DialogType.OK);
                    return;
                }
                this.ShowDialog("결재취소가 완료 되었습니다.", Forms.DialogForm.DialogType.OK);
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
                call_grid3();
            }
        }
        #endregion
        #region [결재코멘트출력]
        private void call_grid3_coment()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sAlarmCode = DBHelper.nvlString(grid1.ActiveRow.Cells["AlarmCode"].Value);
                string sOpCode = DBHelper.nvlString(grid1.ActiveRow.Cells["OPCODE"].Value);
                string sWorkCenterCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sAlarmId = DBHelper.nvlString(grid1.ActiveRow.Cells["AlarmID"].Value);
                string sUserID_TMP = DBHelper.nvlString(grid3.ActiveRow.Cells["WORKERID"].Value);

                rtnDtTemp = helper.FillTable("USP_BM5130_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PTYPE", "S3", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMCODE", sAlarmCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMID", sAlarmId, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USER", sUserID_TMP, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", "Y", DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    DataRow[] drRows = rtnDtTemp.Select();
                    sComent.Value = drRows[0]["ActionText"];
                }
                else
                {
                    sComent.Value = "";
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
                //_GridUtil.Grid_Clear(grid1);
            }
        }
        #endregion
        private void call_grid3()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sAlarmCode = DBHelper.nvlString(grid1.ActiveRow.Cells["AlarmCode"].Value);
                string sOpCode = DBHelper.nvlString(grid1.ActiveRow.Cells["OPCODE"].Value);
                string sWorkCenterCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sAlarmId = DBHelper.nvlString(grid1.ActiveRow.Cells["AlarmID"].Value);

                rtnDtTemp = helper.FillTable("USP_BM5130_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PTYPE", "S2", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMCODE", sAlarmCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMID", sAlarmId, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("AS_USER", sUserID, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", "Y", DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid3.DataSource = rtnDtTemp;
                    grid3.DataBinds(rtnDtTemp);

                    grid3.DisplayLayout.Bands[0].Columns["ActionLevel"].MergedCellStyle = MergedCellStyle.Always;
                    int tmpCount = 0;
                    foreach (DataRow drRow in rtnDtTemp.Rows)
                    {
                        if (DBHelper.nvlString(drRow["MAKEDATE"]) != string.Empty)
                        {
                            grid3.Rows[tmpCount].Appearance.BackColor = Color.LightPink;
                        }
                        tmpCount++;
                    }
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
                //_GridUtil.Grid_Clear(grid1);
            }
        }

        private void call_grid2()
        {
            _GridUtil.Grid_Clear(grid2);
            string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string sAlarmCode = DBHelper.nvlString(grid1.ActiveRow.Cells["AlarmCode"].Value);
            string sOpCode = DBHelper.nvlString(grid1.ActiveRow.Cells["OPCODE"].Value);
            string sWorkCenterCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sAlarmId = DBHelper.nvlString(grid1.ActiveRow.Cells["AlarmID"].Value);
            DBHelper helper = new DBHelper(false);
            try
            {
                //파일 리스트 조회
                rtnDtTemp2 = helper.FillTable("USP_BM5130_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PTYPE", "S4", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMCODE", sAlarmCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ALARMID", sAlarmId, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("AS_USER", sUserID, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", "Y", DbType.String, ParameterDirection.Input));

                if (rtnDtTemp2.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp2;
                    grid2.DataBinds(rtnDtTemp2);
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
                //_GridUtil.Grid_Clear(grid1);
            }
        }

        #region [파일업로드버튼]
        private void btn_UPLOAD_Click(object sender, EventArgs e)
        {
            Type alarmType = null;
            try
            {
                alarmType = grid1.ActiveRow.Cells["AlarmID"].Value.GetType();
            }
            catch (Exception ex)
            {
                alarmType = null;
            }


            if (alarmType == null)
            {
                this.ShowDialog("알람발생리스중 항목을 선택해야합니다.", Forms.DialogForm.DialogType.OK);
                return;
            }
            string sExt = string.Empty;
            string[] filePath = new string[4];
            OpenFileDialog ofd = new OpenFileDialog();

            //공통코드에서 확장자 리스트를 가져와서 세팅
            rtnDtTemp = _Common.GET_BM0000_CODE("FILEEXT"); //파일 확장자리스트
            if (rtnDtTemp.Rows.Count > 0)
            {
                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    sExt += "*." + DBHelper.nvlString(drRow.ItemArray[2]) + ";";
                }

                ofd.Filter = "업로드 가능 파일(" + sExt + ")|" + sExt;
            }
            else
            {
                ofd.Filter = "업로드 가능 파일(*.*)|*.*";
            }
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DBHelper helper = new DBHelper(false);

                try
                {

                    string sPlantCode = grid1.ActiveRow.Cells["PlantCode"].Value.ToString();
                    string year = DateTime.Now.ToString("yyyy");
                    string month = DateTime.Now.ToString("MM");
                    string alarmId = grid1.ActiveRow.Cells["ALARMID"].Value.ToString();
                    //string routerType = grid2.ActiveRow.Cells["ROUTERTYPE"].Value.ToString();
                    filePath = new string[] { alarmId };

                    //sOrderNo = grid1.ActiveRow.Cells["ORDERNO"].Value.ToString();
                    FTP_MakeDir(filePath);

                    //rtnDtTemp = helper.FillTable("USP_BM0141_S1", CommandType.StoredProcedure
                    //       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    //       , helper.CreateParameter("AS_ALARMID", alarmId, DbType.String, ParameterDirection.Input)
                    //      );
                    //, helper.CreateParameter("AS_ROUTERTYPE", routerType, DbType.String, ParameterDirection.Input));

                }
                catch (Exception ex)
                {
                    this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
                }
                finally
                {
                    ClosePrgFormNew();

                    helper.Close();
                }
                //int wkRow = rtnDtTemp.Rows.Count;
                int wkRow = 1;
                //int wkRow = Convert.ToInt32(dtGrid.Rows[0]["CNT"].ToString());
                if (FTP_Upload(filePath, ofd.FileName, grid1.ActiveRow.Cells["ALARMID"].Value.ToString(), wkRow + 1) == true)
                {
                    this.ShowDialog(Common.getLangText("업로드에 성공하였습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);

                    //DoFind();

                    bFTPNew = false;
                }
                else
                {
                    this.ShowDialog(Common.getLangText("업로드에 실패하였습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                }
            }
        }
        #endregion
        /// <summary>
        /// 디렉토리 생성
        /// </summary>
        /// <param name="dirName">디렉토리명</param>
        public void FTP_MakeDir(string[] path)
        {
            FtpWebRequest reqFTP;
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    string uri = string.Empty;

                    uri = string.Format("ftp://{0}:{1}/{2}/", ftpServerIP, ftpPort, path[0]);

                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                    //디렉토리 생성 명령 실행
                    reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                    reqFTP.UseBinary = true;
                    reqFTP.UsePassive = true;
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    Stream ftpStream = response.GetResponseStream();

                    ftpStream.Close();
                    response.Close();
                }

            }
            //catch (Exception ex)
            //{
            //    return;
            //}
            catch (WebException e)
            {
                String status = ((FtpWebResponse)e.Response).StatusDescription;
                //this.ShowDialog(e.Message, Forms.DialogForm.DialogType.OK);
                return;
            }
        }
        public void DoDeleteFtpPath(string plantCode, string alarmId)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {

                helper.ExecuteNoneQuery("USP_BM5130_D1", CommandType.StoredProcedure
                                                       , helper.CreateParameter("AS_PLANTCODE", grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_ALARMID", grid2.ActiveRow.Cells["ALARMID"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_FILENAME", grid2.ActiveRow.Cells["FILENAME"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                      );

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    call_grid2();
                }
                else if (helper.RSCODE == "E")
                {
                    helper.Rollback();

                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                    return;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        public void DoSaveFtpPath(string sAlarmId, string sFilePath, string fileName, int wkRow)
        {
            DBHelper helper = new DBHelper("", true); ;

            try
            {

                helper.ExecuteNoneQuery("USP_BM5130_I2", CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_ALARMID", sAlarmId, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_FILENAME", fileName, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_FILEPATH", sFilePath, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_USER", sUserID, DbType.String, ParameterDirection.Input));


                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                }
                else if (helper.RSCODE == "E")
                {
                    helper.Rollback();

                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                    return;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                call_grid2();
            }
        }

        public Boolean FTP_Upload(string[] folder, string filename, string sAlarmId, int wkRow)
        {
            FileInfo fileInfo = new FileInfo(filename);

            string uri = String.Format("ftp://{0}:{1}/{2}/{3}", ftpServerIP, ftpPort, folder[0], fileInfo.Name);
            //string uri = String.Format("ftp://{0}:{1}/{2}", ftpServerIP, ftpPort,fileInfo.Name);
            FtpWebRequest reqFTP;

            //FtpWebRequest object 생성
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

            //아이디, 패스워드 검증
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

            //서버에 대한 연결이 소멸되지 않아야 하면 true, 소멸되어야 하면 false 
            //KeepAlive의 기본값은 원래 true임.
            reqFTP.KeepAlive = false;


            //지정한 업로드 명령을 실행
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            //전송 타입설정
            reqFTP.UseBinary = true;

            //passive모드 사용여부
            reqFTP.UsePassive = true;//usePassive;

            //서버에 파일사이즈를 알림
            reqFTP.ContentLength = fileInfo.Length;

            //버퍼사이즈 지정
            byte[] buff = new byte[2048];
            int contentLen;

            //파일 읽기
            FileStream fs = fileInfo.OpenRead();

            try
            {
                //업로드 할 파일 스트림을 가져옴.
                Stream strm = reqFTP.GetRequestStream();

                //2kb씩 파일 스트림을 읽은 후 길이 반환
                contentLen = fs.Read(buff, 0, 2048);

                //스트림을 다 읽을때까지 반복.
                while (contentLen != 0)
                {
                    //FTP에 파일을 기록
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, 2048);
                }
                strm.Close();
                fs.Close();

                string sFilePath = "";
                for (int i = 0; i < folder.Length; i++)
                {
                    sFilePath += folder[i] + '/';
                }

                //FTP_Rename(sFilePath + "/" + fileInfo.Name, opcode + fileInfo.Extension);

                DoSaveFtpPath(sAlarmId, "/" + sFilePath, fileInfo.Name, wkRow);

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }

        }

        public bool FTP_Delete(string sFileName, string plantCode, string alarmId)
        {
            try
            {
                FtpWebRequest reqFTP;
                string uri = string.Format("ftp://{0}:{1}/{2}", ftpServerIP, ftpPort, sFileName);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;

                //삭제 명령을 실행
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();


                DoDeleteFtpPath(plantCode, alarmId);

                return true;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                return false;
            }
            finally
            {
                this.ShowDialog("삭제가 완료되었습니다.", Forms.DialogForm.DialogType.OK);
            }
        }

        private void btn_DELETE_Click(object sender, EventArgs e)
        {
            if (this.ShowDialog(Common.getLangText("정말 삭제하시겠습니까?", "YESNO"), WIZ.Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
            {
                string sPlantCode = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
                string sAlarmId = grid1.ActiveRow.Cells["ALARMID"].Value.ToString();
                string filePath = grid2.ActiveRow.Cells["FILEPATH"].Value.ToString();
                string fileName = grid2.ActiveRow.Cells["FILENAME"].Value.ToString();
                FTP_Delete(filePath + fileName, sPlantCode, sAlarmId);
            }
            else
            {
                return;
            }
        }

        private void grid2_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();

            string plantCode = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
            string alarmId = grid1.ActiveRow.Cells["ALARMID"].Value.ToString();
            string filePath = grid2.ActiveRow.Cells["FILEPATH"].Value.ToString();
            string fileName = grid2.ActiveRow.Cells["FILENAME"].Value.ToString();
            string localPath = @"C:/TEMP";

            svd.FileName = fileName;
            if (DialogResult.OK == svd.ShowDialog())
            {
                FtpWebRequest reqFTP;
                try
                {
                    string uri = string.Format("ftp://{0}:{1}{2}{3}", ftpServerIP, ftpPort, filePath, fileName);
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                    //다운로드
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = true;
                    reqFTP.UsePassive = true;
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    Stream ftpStream = response.GetResponseStream();
                    //filePath = filePath.Replace("/","\\");
                    //디렉터리없으면 생성
                    //string sDirPath;
                    //sDirPath = localPath + filePath;
                    //DirectoryInfo di = new DirectoryInfo(sDirPath);
                    //if (di.Exists == false)
                    //{
                    //    di.Create();
                    //}
                    ///////
                    FileStream writeStream = new FileStream(svd.FileName, FileMode.Create);

                    int Length = 2048;
                    Byte[] buffer = new Byte[Length];
                    int bytesRead = ftpStream.Read(buffer, 0, Length);

                    while (bytesRead > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                        bytesRead = ftpStream.Read(buffer, 0, Length);
                    }
                    ////////
                    ftpStream.Close();
                    response.Close();
                    writeStream.Close();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    this.ShowDialog("다운로드 되었습니다.", Forms.DialogForm.DialogType.OK);
                    //Process.Start(localPath + filePath + fileName);
                }
            }

        }
    }
}
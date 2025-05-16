#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0120
//   Form Name    : 고장실적조회 및 도착등록/등록취소
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Configuration;
using System.Data;
using System.Text;
using WIZ.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.PP
{
    public partial class PP0120 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable rtnDtTemp = new DataTable();

        #endregion

        #region < CONSTRUCTOR >
        public PP0120()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();

            this.plantCode = CModule.GetAppSetting("Site", "10");
            btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" }); //작업장
            btbManager.PopUpAdd(txt_MACHCODE_H, txt_MACHNAME_H, "BM0070", new object[] { cbo_PLANTCODE_H, "", "", "" }); //설비                        
        }
        #endregion

        #region < FORM LOAD >
        private void PP0120_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MASTATUS", "진행상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "고장신고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAORDERNO", "고장신고번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "FAILURETYPE", "고장분류", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "FAULTWORKER", "신고자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "FAUILWORKERNAME", "신고자명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE", "고장신고일시", false, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ARRIVALDATE", "작업자도착일시", false, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE", "고장종료일시", false, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "FAULTTIME", "고장시간(초)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "고장내역", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MASTARTDATE", "수리시작일시", false, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAENDDATE", "수리종료일시", false, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MATIME", "수리시간(초)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REPAIRWORKER", "수리자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, false, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REPAIRWORKERNAME", "수리자명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "FAULTCODE", "수리사유", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 90, 120, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAINTRSORDTYPE", "발생구분", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region < COMBOBOX SETTING >

            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cbo_PLANTCODE_H.Value = CModule.GetAppSetting("Site", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("FAILURETYPE"); // 고장 분류
            WIZ.Common.FillComboboxMaster(this.cbo_FAILURETYPE_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FAILURETYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //수리고장 사유
            rtnDtTemp = _Common.GET_BM0170_CODE(DBHelper.nvlString(cbo_PLANTCODE_H.Value), "Y");
            //WIZ.Common.FillComboboxMaster(this.cbo_FAILURETYPE_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FAULTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("MAINTRSORDTYPE");  //보전작업지시구분
            WIZ.Common.FillComboboxMaster(cbo_GUBUN_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MAINTRSORDTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //설비고장 분류
            //rtnDtTemp = _Common.GET_BM0170_CODE(DBHelper.nvlString(cbo_PLANTCODE_H.Value), "Y");
            //WIZ.Common.FillComboboxMaster(this.cbo_FAULTTYPE_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");


            GetFailStatus();

            //콤보박스 시, 분 셋팅
            GetHour();
            GetMin();
            this.btnSAVE_B.Enabled = false;
            this.btnDELETE_B.Enabled = false;

            //시간
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);
            DBHelper helper = new DBHelper(false);

            try
            {
                //base.DoInquire();
                if (!CheckData())
                {
                    return;
                }

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);                  //사업장코드                                                                                          
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sWorkCenterCode = txt_WORKCENTERCODE_H.Text.Trim();
                string sStatus = Convert.ToString(cbo_FIXSTATUS_H.Value);
                string sMachCode = txt_MACHCODE_H.Text.Trim();

                rtnDtTemp = helper.FillTable("USP_PP0120_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_MASTATUS", sStatus, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_MACHCODE", sMachCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);
                    }
                    else
                    {
                        ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), DialogForm.DialogType.OK);
                    }
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());

            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoSave()
        {
            Grid1ToolAct();
        }

        public override void DoDelete()
        {
            if (this.grid1.ActiveRow.Cells["MASTATUS"].Value.ToString() != "A")
            {
                this.ShowDialog(Common.getLangText("작업대기가 아닌 데이터는 고장실적 취소 를 할수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }
            else
            {
                if (this.ShowDialog(Common.getLangText("선택한 고장실적을 취소하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                DBHelper helper = new DBHelper("", true);
                try
                {
                    string sPlantCode = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();  //사업장
                    string sMaOrderNo = this.grid1.ActiveRow.Cells["MAORDERNO"].Value.ToString();  //보전지시번호

                    helper.ExecuteNoneQuery("USP_PP0120_D1", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_MAORDERNO", sMaOrderNo, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE != "S")
                    {
                        helper.Rollback();
                        helper.Close();
                        this.ClosePrgFormNew();
                        this.ShowDialog(Common.getLangText("조회 이후 작업상태가 변경되었습니다.확인후 진행하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                        DoInquire();
                        return;
                    }
                    else if (helper.RSCODE == "S")
                    {
                        helper.Commit();
                        this.ClosePrgFormNew();
                        this.ShowDialog(Common.getLangText("데이터가 저장 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    }
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    this.ClosePrgFormNew();
                    this.ShowDialog(ex.ToString());
                }
                finally
                {
                    this.ClosePrgFormNew();
                    helper.Close();
                    DoInquire();
                }
            }
        }

        #endregion

        #region < USER METHOD AREA >
        private void GetFailStatus()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT MINORCODE                           AS CODE_ID, ");
                command.AppendLine("       '['+ MINORCODE +']' + CODENAME        AS CODE_NAME");
                command.AppendLine("  FROM BM0000                                           ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND MAJORCODE = 'FAILSTATUS' ");
                command.AppendLine("   AND RELCODE1  = 'UI' ");
                command.AppendLine("   AND MINORCODE <> '$'   ");
                command.AppendLine(" ORDER BY MINORCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(this.cbo_FIXSTATUS_H, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MASTATUS", dttemp, "CODE_ID", "CODE_NAME");
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

        private void GetHour()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dttemp = new DataTable();
                DataRow row = null;

                dttemp.Columns.Add(new DataColumn("CODE_ID", typeof(string)));
                dttemp.Columns.Add(new DataColumn("CODE_NAME", typeof(string)));

                for (int i = 0; i < 25; i++)
                {
                    row = dttemp.NewRow();  //행추가
                    row["CODE_ID"] = i.ToString("00");
                    dttemp.Rows.Add(row);
                }

                WIZ.Common.FillComboboxMaster(cbo_STARTHOUR_B, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, null);
                cbo_STARTHOUR_B.Value = DateTime.Now.Hour.ToString("00");
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

        private void GetMin()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dttemp = new DataTable();
                DataRow row = null;

                dttemp.Columns.Add(new DataColumn("CODE_ID", typeof(string)));
                dttemp.Columns.Add(new DataColumn("CODE_NAME", typeof(string)));

                for (int i = 0; i < 60; i++)
                {
                    row = dttemp.NewRow();  //행추가
                    row["CODE_ID"] = i.ToString("00");
                    dttemp.Rows.Add(row);
                }

                WIZ.Common.FillComboboxMaster(cbo_STARTMIN_B, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, null);
                cbo_STARTMIN_B.Value = DateTime.Now.Minute.ToString("00");
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

        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_STARTDATE_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_ENDDATE_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("조회 시작일자가 종료일자보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }

        private void Grid1ToolAct()
        {
            if (this.grid1.Rows.Count == 0) return;
            DBHelper helper = new DBHelper("", true);
            try
            {

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }
                base.DoSave();

                string sPlantCode = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
                string sFailureType = Convert.ToString(this.cbo_FAILURETYPE_B.Value);              // 고장 분류
                string sRemark = Convert.ToString(this.txt_FAULTREMARK_B.Text);               // 고장내역
                string sMAORDERNO = this.grid1.ActiveRow.Cells["MAORDERNO"].Value.ToString();    // 보전지시번호
                if (sRemark == "")
                {
                    this.ShowDialog(Common.getLangText("고장내역을 입력하지 않았습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                helper.ExecuteNoneQuery("USP_PP0120_U1", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_MAORDERNO", sMAORDERNO, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_FAILURETYPE", sFailureType, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input));

                // RSCODE 가 S 일경우 helper.RSMSG 로 MoldCode를 리턴함.
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("데이터가 저장 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    DoInquire();
                    // 해당 행 선택
                    for (int i = 0; i < this.grid1.Rows.Count; i++)
                    {
                        if (this.grid1.Rows[i].Cells["MAORDERNO"].Value.ToString() == sMAORDERNO)
                        {
                            this.grid1.Rows[i].Activated = true;
                            break;
                        }
                    }
                }
                else if (helper.RSCODE == "E")
                {
                    helper.Rollback();
                    this.ClosePrgFormNew();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ClosePrgFormNew();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        #endregion

        #region < EVENT AREA >
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;


            //고장내역 초기화
            cbo_STARTYYMMDD_B.Value = DateTime.Now.ToString("yyyy-MM-dd");
            cbo_STARTHOUR_B.Value = "00";
            cbo_STARTMIN_B.Value = "00";
        }

        private void grid1_ClickCell_1(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            txt_MAINTRSORDNO_B.Text = grid1.ActiveRow.Cells["MAORDERNO"].Value.ToString();
            //cbo_GUBUN_B.Value          = grid1.ActiveRow.Cells["MAINTRSORDTYPE"].Value.ToString();
            txt_FAILWORKERID_B.Text = grid1.ActiveRow.Cells["FAULTWORKER"].Value.ToString();                       // 고장 신고자
            txt_FAILWORKERNAME_B.Text = grid1.ActiveRow.Cells["FAUILWORKERNAME"].Value.ToString();                   // 고장 신고자 명
            txt_WORKCENTERCODE_B.Text = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();                    // 작업장
            txt_WORKCENTERNAME_B.Text = grid1.ActiveRow.Cells["WORKCENTERNAME"].Value.ToString();                    // 작업장 명
            txt_MACHCODE_B.Text = grid1.ActiveRow.Cells["MACHCODE"].Value.ToString();                          // 설비
            txt_MACHNAME_B.Text = grid1.ActiveRow.Cells["MACHNAME"].Value.ToString();                          // 설비 명
            txt_STARTDATE_B.Text = grid1.ActiveRow.Cells["STARTDATE"].Value.ToString();                         // 고장 신고일시
            txt_ENDDATE_B.Text = grid1.ActiveRow.Cells["ENDDATE"].Value.ToString();                           // 작업 완료 일시
            txt_FAULTTIME_B.Text = grid1.ActiveRow.Cells["FAULTTIME"].Value.ToString();                         // 고장 시간
            cbo_FAILURETYPE_B.Value = grid1.ActiveRow.Cells["FAILURETYPE"].Value.ToString();                       // 고장 분류
            txt_FAULTREMARK_B.Text = grid1.ActiveRow.Cells["REMARK"].Value.ToString();                            // 고장 내역
            string MaStartTime = grid1.ActiveRow.Cells["ARRIVALDATE"].Value.ToString();                       // 작업시작일시 (작업자 도착일시)

            //시작시간 셋팅
            if (MaStartTime != "")
            {
                DateTime sTime = Convert.ToDateTime(MaStartTime);
                cbo_STARTYYMMDD_B.Value = sTime.ToString("yyyy") + "-" + sTime.ToString("MM") + "-" + sTime.ToString("dd");
                cbo_STARTHOUR_B.Value = sTime.ToString("HH");
                cbo_STARTMIN_B.Value = sTime.ToString("mm");
            }
            else
            {
                cbo_STARTYYMMDD_B.Value = DateTime.Now.ToString("yyyy-MM-dd");
                cbo_STARTHOUR_B.Value = DateTime.Now.Hour.ToString("00");
                cbo_STARTMIN_B.Value = DateTime.Now.Minute.ToString("00");
            }
            if (this.grid1.ActiveRow.Cells["MASTATUS"].Value.ToString() == "A") // 작업대기 일때
            {
                this.btnSAVE_B.Enabled = true;
                this.btnDELETE_B.Enabled = false;
            }
            else if (this.grid1.ActiveRow.Cells["MASTATUS"].Value.ToString() == "B") // 작업중 일때
            {
                this.btnSAVE_B.Enabled = false;
                this.btnDELETE_B.Enabled = true;
            }
            else
            {
                this.btnSAVE_B.Enabled = false;
                this.btnDELETE_B.Enabled = false;
            }
            if (this.grid1.ActiveRow.Cells["MASTATUS"].Value.ToString() != "A")
            {
                this.cbo_STARTYYMMDD_B.Enabled = false;
                this.cbo_STARTHOUR_B.Enabled = false;
                this.cbo_STARTMIN_B.Enabled = false;
                this.txt_FAULTREMARK_B.Enabled = false;
            }
            else
            {
                this.cbo_STARTYYMMDD_B.Enabled = true;
                this.cbo_STARTHOUR_B.Enabled = true;
                this.cbo_STARTMIN_B.Enabled = true;
                this.txt_FAULTREMARK_B.Enabled = true;
            }
        }

        // 작업자 도착등록취소
        private void btnDELETE_B_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;
            string sStatus = this.grid1.ActiveRow.Cells["MASTATUS"].Value.ToString();
            if (sStatus != "B")
            {
                this.ShowDialog(Common.getLangText("작업중이 아닌 상태에서 도착등록 취소를 할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (this.ShowDialog(Common.getLangText("작업자 도착등록을 취소하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            DBHelper helper = new DBHelper("", true);
            try
            {
                string sMAORDERNO = this.grid1.ActiveRow.Cells["MAORDERNO"].Value.ToString();
                string sPLANTCODE = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();

                helper.ExecuteNoneQuery("USP_PP0120_U3", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAORDERNO", sMAORDERNO, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "X")
                {
                    helper.Rollback();
                    helper.Close();
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("조회 이후 작업상태가 변경되었습니다.확인후 진행하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    DoInquire();
                    return;
                }
                helper.Commit();
                this.ShowDialog(Common.getLangText("저장이 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                DoInquire();   // 재 조회
                // 작업한 데이터 선택.
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (this.grid1.Rows[i].Cells["MAORDERNO"].Value.ToString() == sMAORDERNO)
                    {
                        this.grid1.Rows[i].Activated = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

        }

        // 작업자 도착등록
        private void btnSAVE_B_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;
            string sStatus = this.grid1.ActiveRow.Cells["MASTATUS"].Value.ToString();
            if (sStatus != "A")
            {
                this.ShowDialog(Common.getLangText("작업대기가 아닌 상태에서 도착등록을 할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //입력한 작업시작시간
            DateTime eDate = Convert.ToDateTime(cbo_STARTYYMMDD_B.Value);
            string eDay = eDate.ToString("yyyy") + "-" + eDate.ToString("MM") + "-" + eDate.ToString("dd");
            string eHour = Convert.ToString(cbo_STARTHOUR_B.Value);
            string eMin = Convert.ToString(cbo_STARTMIN_B.Value);
            string eTime = eDay + " " + eHour + ":" + eMin;

            DateTime sTime = Convert.ToDateTime(this.grid1.ActiveRow.Cells["STARTDATE"].Value.ToString());
            //작업 시작시간은 고장 시작시간보다 이전 일 수 없습니다.

            if (Convert.ToDateTime(eTime) < Convert.ToDateTime(sTime))
            {
                this.ShowDialog(Common.getLangText("작업자도착일시은 고장신고일시보다 이전 일 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (this.ShowDialog(Common.getLangText("작업자 도착등록을 하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            DBHelper helper = new DBHelper("", true);
            try
            {
                string sMAORDERNO = this.grid1.ActiveRow.Cells["MAORDERNO"].Value.ToString();
                string sPLANTCODE = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
                string sREMARK = this.txt_FAULTREMARK_B.Text.Trim();

                helper.ExecuteNoneQuery("USP_PP0120_U2", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAORDERNO", sMAORDERNO, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MASTARTTIME", Convert.ToDateTime(eTime), DbType.DateTime, ParameterDirection.Input)// 작업시작시간
                                    , helper.CreateParameter("AS_REMARK", sREMARK, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "X")
                {
                    helper.Rollback();
                    helper.Close();
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("조회 이후 작업상태가 변경되었습니다.확인후 진행하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    DoInquire();
                    return;
                }
                helper.Commit();
                this.ShowDialog(Common.getLangText("저장이 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                DoInquire(); // 재 조회
                // 작업한 데이터 선택.
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (this.grid1.Rows[i].Cells["MAORDERNO"].Value.ToString() == sMAORDERNO)
                    {
                        this.grid1.Rows[i].Activated = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

        }

        #endregion
    }
}
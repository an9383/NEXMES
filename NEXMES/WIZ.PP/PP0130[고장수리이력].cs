using System;
using System.Configuration;
using System.Data;
using System.Text;
using WIZ.PopUp;
namespace WIZ.PP
{
    public partial class PP0130 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        private string plantCode = string.Empty; //plantcode default 설정
        DataTable rtnDtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();

        #endregion

        #region<CONSTRUCTOR>
        public PP0130()
        {
            InitializeComponent();

            //WIZ.PopUp.BizGridManager BIZPOP;
            //BIZPOP = new BizGridManager(grid1);
            //BIZPOP.PopUpAdd("STOPCODE", "STOPDESC", "TBM1100", new string[] { "", "", "Y" }, new string[] { "STOPTYPE", "STOPCLASS" }, new string[] { "Y" });
            //BizGridManager bizGridManager;

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txt_FAULTWORKER_B, txt_FAULTWORKERNAME_B, "BM0020", new object[] { cbo_PLANTCODE_H, "", "", "", "" }); //신고자
            btbManager.PopUpAdd(txt_REPAIRWORKER_B, txt_REPAIRWORKERNAME_B, "BM0020", new object[] { cbo_PLANTCODE_H, "", "", "", "" }); //작업자

            btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" }); //작업장
            btbManager.PopUpAdd(txt_WORKCENTERCODE_B, txt_WORKCENTERNAME_B, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" }); //작업장

            btbManager.PopUpAdd(txt_MACHCODE_H, txt_MACHNAME_H, "BM0070", new object[] { cbo_PLANTCODE_H, "", "", "" }); //설비
            btbManager.PopUpAdd(txt_MACHCODE_B, txt_MACHNAME_B, "BM0070", new object[] { cbo_PLANTCODE_H, "", "", "" }); //설비
        }
        #endregion
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        #region  PP0130_Load
        private void PP0130_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성                                                                                                                                                                              
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MASTATUS", "진행상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "고장신고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAORDERNO", "고장신고번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FAILURETYPE", "고장분류", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FAULTWORKER", "신고자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FAUILWORKERNAME", "신고자명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE", "고장신고일시", false, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ARRIVALDATE", "작업자도착일시", false, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE", "고장종료일시", false, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FAULTTIME", "고장시간(초)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "고장내역", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "MASTARTDATE", "수리시작일시", false, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAENDDATE", "수리종료일시", false, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MATIME", "수리시간(초)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REPAIRWORKER", "수리자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REPAIRWORKERNAME", "수리자명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FAULTCODE", "수리사유", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 90, 120, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAINTRSORDTYPE", "발생구분", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            _GridUtil.SetInitUltraGridBind(grid1);

            #region Grid MERGE


            #endregion Grid MERGE

            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통   
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장                                                                                                                                
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cbo_PLANTCODE_H.Value = CModule.GetAppSetting("Site", "10");

            plantCode = Convert.ToString(cbo_PLANTCODE_H.Value);

            rtnDtTemp = _Common.GET_BM0000_CODE("FAILURETYPE"); // 고장 분류
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FAILURETYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            // 작업구분 선택
            GetFailStatus();

            rtnDtTemp = _Common.GET_BM0000_CODE("MAINTRSORDTYPE");  //보전작업지시구분
            WIZ.Common.FillComboboxMaster(cbo_GUBUN_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MAINTRSORDTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //수리사유
            rtnDtTemp = _Common.GET_BM0170_CODE(DBHelper.nvlString(cbo_PLANTCODE_H.Value), "Y");
            //WIZ.Common.FillComboboxMaster(this.cbo_FAILURETYPE_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FAULTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //콤보박스 시, 분 셋팅
            GetHour();
            GetMin();

            //시간
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #endregion
        }
        #endregion  PP5200_Load


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
                WIZ.Common.FillComboboxMaster(this.cbo_MASTATUS_B, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MASTATUS", dttemp, "CODE_ID", "CODE_NAME");
                cbo_MASTATUS_B.Value = "";
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
                WIZ.Common.FillComboboxMaster(cbo_ENDHOUR_B, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, null);
                cbo_ENDHOUR_B.Value = DateTime.Now.Hour.ToString("00");
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
                WIZ.Common.FillComboboxMaster(cbo_ENDMIN_B, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, null);
                cbo_ENDMIN_B.Value = DateTime.Now.Minute.ToString("00");
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

        #region<TOOL BAR AREA >
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


                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);                  //사업장                                                                                      
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sWorkCenterCode = txt_WORKCENTERCODE_H.Text.Trim();
                string sStatus = Convert.ToString(cbo_FIXSTATUS_H.Value);
                string sMachCode = txt_MACHCODE_H.Text.Trim();
                string sFaultCode = txt_FIXREMARK_H.Text.Trim();



                rtnDtTemp = helper.FillTable("USP_PP0120_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_MASTATUS", sStatus, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_MACHCODE", sMachCode, DbType.String, ParameterDirection.Input));
                //, helper.CreateParameter("AS_FAULTCODE",      sFaultCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);
                    }
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
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
            if (grid1.Rows.Count == 0) return;

            if (this.ShowDialog(Common.getLangText("수리내역을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            //이전의 상태
            string bStatus = grid1.ActiveRow.Cells["MASTATUS"].Value.ToString();
            //변경할 상태
            string aStatus = Convert.ToString(cbo_MASTATUS_B.Value);

            //작업대기에서 작업대기로는 변경 불가
            if (bStatus == "B" && aStatus == "B")
            {
                this.ShowDialog(Common.getLangText("작업중인 상태에서 작업중 상태로 변경 불가합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업중에서 작업대기로는 변경 불가
            if (bStatus == "C" && aStatus == "B")
            {
                this.ShowDialog(Common.getLangText("수리시작 상태에서 작업중 상태로 변경 불가합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업완료에서 작업대기 또는 작업중으로 변경 불가
            if ((bStatus == "D" && aStatus == "B") || (bStatus == "D" && aStatus == "C"))
            {
                this.ShowDialog(Common.getLangText("수리완료 상태에서 이전상태로 변경 불가합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업완료인 경우 작업완료일시 필수입력
            if ((bStatus == "D" && cbo_ENDYYMMDD_B.Value == null) || (bStatus == "D" && cbo_ENDYYMMDD_B.Value == null) || (bStatus == "D" && cbo_ENDYYMMDD_B.Value == null))
            {
                this.ShowDialog(Common.getLangText("수리완료 상태 저장시 수리완료 일시는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업자 필수입력
            if (txt_REPAIRWORKER_B.Text == "")
            {
                this.ShowDialog(Common.getLangText("작업자는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업내용 필수입력
            if (txt_FAULTCODE_B.Text == "")
            {
                this.ShowDialog(Common.getLangText("수리내용은 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //입력한 작업시작시간
            DateTime sDate = Convert.ToDateTime(cbo_STARTYYMMDD_B.Value);
            string sDay = sDate.ToString("yyyy") + "-" + sDate.ToString("MM") + "-" + sDate.ToString("dd");
            string sHour = Convert.ToString(cbo_STARTHOUR_B.Value);
            string sMin = Convert.ToString(cbo_STARTMIN_B.Value);
            string sTime = sDay + " " + sHour + ":" + sMin;

            //입력한 작업종료시간
            DateTime eDate = Convert.ToDateTime(cbo_ENDYYMMDD_B.Value);
            string eDay = eDate.ToString("yyyy") + "-" + eDate.ToString("MM") + "-" + eDate.ToString("dd");
            string eHour = Convert.ToString(cbo_ENDHOUR_B.Value);
            string eMin = Convert.ToString(cbo_ENDMIN_B.Value);
            string eTime = eDay + " " + eHour + ":" + eMin;

            //작업자도착시간
            string sFailtime = Convert.ToString(grid1.ActiveRow.Cells["ARRIVALDATE"].Value);

            if (sFailtime == "")
            {
                this.ShowDialog(Common.getLangText("도착시간 값이 존재하지 않습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }
            //입력한 수리시작시간은 작업자도착시간보다 작을 수 없음
            if (Convert.ToDateTime(sTime) < Convert.ToDateTime(sFailtime))
            {
                this.ShowDialog(Common.getLangText("수리시작일시는 작업자도착일시보다 작을 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업완료시 입력한 작업종료시간은 입력한 작업시작시간보다 작을 수 없음
            if (aStatus == "D" && Convert.ToDateTime(eTime) < Convert.ToDateTime(sTime))
            {
                this.ShowDialog(Common.getLangText("수리완료일시는 수리시작일시보다 작을 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);     // 사업장
            string sMaOrderNo = Convert.ToString(grid1.ActiveRow.Cells["MAORDERNO"].Value);     // 보전작업지시번호
            string sWorker = Convert.ToString(txt_REPAIRWORKER_B.Text);                      // 작업자
            string sFaultCode = Convert.ToString(txt_FAULTCODE_B.Text);                         // 작업내용

            DBHelper helper = new DBHelper("", true);
            //helper.Transaction = helper._sConn.BeginTransaction();
            try
            {
                //작업대기에서 작업중, 작업완료로 저장시 나눠서 처리
                helper.ExecuteNoneQuery("USP_PP0130_U1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)  // 사업장
                                    , helper.CreateParameter("AS_MASTARTDATE", sTime, DbType.DateTime, ParameterDirection.Input)  // 작업시작시간
                                    , helper.CreateParameter("AS_MAENDDATE", eTime, DbType.DateTime, ParameterDirection.Input)  // 작업종료시간  
                                    , helper.CreateParameter("AS_MAORDERNO", sMaOrderNo, DbType.String, ParameterDirection.Input)  // 보전작업지시번호
                                    , helper.CreateParameter("BSTATUS", bStatus, DbType.String, ParameterDirection.Input)  // 변경전 작업상태
                                    , helper.CreateParameter("STATUS", aStatus, DbType.String, ParameterDirection.Input)  // 변경할 작업상태
                                    , helper.CreateParameter("AS_WORKER", WorkerID, DbType.String, ParameterDirection.Input)  // 수정자
                                    , helper.CreateParameter("AS_FAULTCODE", sFaultCode, DbType.String, ParameterDirection.Input)  // 작업내용
                                    , helper.CreateParameter("AS_MAWORKER", sWorker, DbType.String, ParameterDirection.Input)  // 조치자
                                    );

                //작업상태가 변경된 경우
                if (helper.RSCODE == "O")
                {
                    helper.Rollback();
                    helper.Close();
                    this.ShowDialog(Common.getLangText("조회 이후 작업상태가 변경되었습니다.확인후 진행하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    DoInquire();
                    return;
                }
                helper.Commit();
                this.ShowDialog(Common.getLangText("저장이 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                DoInquire();   // 재 조회
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (this.grid1.Rows[i].Cells["MAORDERNO"].Value.ToString() == sMaOrderNo)
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
        #endregion

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            txt_MAORDERNO_B.Text = grid1.ActiveRow.Cells["MAORDERNO"].Value.ToString();
            //cbo_GUBUN_B.Value           = grid1.ActiveRow.Cells["MAINTRSORDTYPE"].Value.ToString();    

            txt_FAULTWORKER_B.Text = grid1.ActiveRow.Cells["FAULTWORKER"].Value.ToString();
            txt_FAULTWORKERNAME_B.Text = grid1.ActiveRow.Cells["FAUILWORKERNAME"].Value.ToString();
            txt_WORKCENTERCODE_B.Text = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
            txt_WORKCENTERNAME_B.Text = grid1.ActiveRow.Cells["WORKCENTERNAME"].Value.ToString();
            txt_MACHCODE_B.Text = grid1.ActiveRow.Cells["MACHCODE"].Value.ToString();
            txt_MACHNAME_B.Text = grid1.ActiveRow.Cells["MACHNAME"].Value.ToString();

            txt_RECDATE_B.Text = grid1.ActiveRow.Cells["STARTDATE"].Value.ToString();
            txt_ENDDATE_B.Text = grid1.ActiveRow.Cells["ENDDATE"].Value.ToString();
            txt_FAULTTIME_B.Text = grid1.ActiveRow.Cells["FAULTTIME"].Value.ToString();

            txt_FAULTTYPE_B.Text = grid1.ActiveRow.Cells["FAILURETYPE"].Text.ToString();
            txt_REMARK_B.Text = grid1.ActiveRow.Cells["REMARK"].Value.ToString();

            cbo_MASTATUS_B.Value = "";
            cbo_MASTATUS_B.Value = grid1.ActiveRow.Cells["MASTATUS"].Value.ToString();

            txt_REPAIRWORKER_B.Text = grid1.ActiveRow.Cells["REPAIRWORKER"].Value.ToString();
            txt_REPAIRWORKERNAME_B.Text = grid1.ActiveRow.Cells["REPAIRWORKERNAME"].Value.ToString();
            txt_FAULTCODE_B.Text = grid1.ActiveRow.Cells["FAULTCODE"].Value.ToString();

            txt_STARTDATE_B.Text = grid1.ActiveRow.Cells["ARRIVALDATE"].Value.ToString();
            string MaStartTime = grid1.ActiveRow.Cells["MASTARTDATE"].Value.ToString();
            string MaEndTime = grid1.ActiveRow.Cells["MAENDDATE"].Value.ToString();

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
            //종료시간 셋팅
            if (MaEndTime != "")
            {
                DateTime eTime = Convert.ToDateTime(MaEndTime);
                cbo_ENDYYMMDD_B.Value = eTime.ToString("yyyy") + "-" + eTime.ToString("MM") + "-" + eTime.ToString("dd");
                cbo_ENDHOUR_B.Value = eTime.ToString("HH");
                cbo_ENDMIN_B.Value = eTime.ToString("mm");
            }
            else
            {
                cbo_ENDYYMMDD_B.Value = DateTime.Now.ToString("yyyy-MM-dd");
                cbo_ENDHOUR_B.Value = DateTime.Now.Hour.ToString("00");
                cbo_ENDMIN_B.Value = DateTime.Now.Minute.ToString("00");
            }
        }


        private void btnDELETE_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            if (this.ShowDialog(Common.getLangText("수리실적을 취소하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            //이전의 상태
            string bStatus = grid1.ActiveRow.Cells["MASTATUS"].Value.ToString();

            //수리완료는 취소 불가
            //if (bStatus == "40")
            //{
            //    this.ShowDialog(Common.getLangText("수리완료 상태에서 작업 취소가 불가합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
            //    return;
            //}

            //// 작업중인 상태는 취소 불가
            //if (bStatus == "20")
            //{
            //    this.ShowDialog(Common.getLangText("작업중 상태에서 수리실적 취소를 할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
            //    return;
            //}

            string sWorkerCenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sMachCode = Convert.ToString(grid1.ActiveRow.Cells["MACHCODE"].Value);
            string sMaOrderNo = Convert.ToString(grid1.ActiveRow.Cells["MAORDERNO"].Value);

            DBHelper helper = new DBHelper("", true);
            //helper.Transaction = helper._sConn.BeginTransaction();
            try
            {
                //업데이트 내역 모두 초기화 및 작업대기 상태로 변경
                helper.ExecuteNoneQuery("USP_PP0130_U2", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", plantCode, DbType.String, ParameterDirection.Input)          //사업장
                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkerCenterCode, DbType.String, ParameterDirection.Input)  //작업장
                                    , helper.CreateParameter("AS_MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)          //고장장(설)비코드 
                                    , helper.CreateParameter("AS_MAORDERNO", sMaOrderNo, DbType.String, ParameterDirection.Input)         //보전작업지시번호
                                    , helper.CreateParameter("AS_EDITOR", WorkerID, DbType.String, ParameterDirection.Input)           //수정자
                                    );

                //작업완료(30)인 경우 취소불가 
                if (helper.RSCODE == "O")
                {
                    helper.Rollback();
                    this.ShowDialog(Common.getLangText("조회이후 상태가 변경되었습니다. 확인후 진행하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("저장이 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                }
                DoInquire();   // 재 조회
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (this.grid1.Rows[i].Cells["MAORDERNO"].Value.ToString() == sMaOrderNo)
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

        private void cbo_MASTATUS_B_ValueChanged(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            //이전 상태
            string sStatus = grid1.ActiveRow.Cells["MASTATUS"].Value.ToString();

            //작업중으로 변경 , 작업대기로 변경
            if (Convert.ToString(cbo_MASTATUS_B.Value) == "B" || Convert.ToString(cbo_MASTATUS_B.Value) == "A")
            {
                ultraLabel1.Visible = true;
                cbo_ENDYYMMDD_B.Visible = true;
                cbo_ENDHOUR_B.Visible = true;
                cbo_ENDMIN_B.Visible = true;
                lbl_ENDHOUR_B.Visible = true;
                lbl_ENDMIN_B.Visible = true;
                btnDELETE.Visible = false;


                //이전상태가 수리완료 및 작업완료라면 변경 불가
                if (sStatus == "D" || sStatus == "E")
                {
                    //cboSTATUS.Enabled      = false;
                    cbo_STARTYYMMDD_B.Enabled = false;
                    cbo_STARTHOUR_B.Enabled = false;
                    cbo_STARTMIN_B.Enabled = false;
                    cbo_ENDYYMMDD_B.Enabled = false;
                    cbo_ENDHOUR_B.Enabled = false;
                    cbo_ENDMIN_B.Enabled = false;
                    txt_REPAIRWORKER_B.Enabled = false;
                    txt_REPAIRWORKERNAME_B.Enabled = false;
                    //txtMADESC.Enabled      = false;
                }
                else
                {
                    //모두 변경 불가
                    cbo_STARTYYMMDD_B.Enabled = false;
                    cbo_STARTHOUR_B.Enabled = false;
                    cbo_STARTMIN_B.Enabled = false;
                    cbo_ENDYYMMDD_B.Enabled = false;
                    cbo_ENDHOUR_B.Enabled = false;
                    cbo_ENDMIN_B.Enabled = false;
                    txt_REPAIRWORKER_B.Enabled = false;
                    txt_REPAIRWORKERNAME_B.Enabled = false;
                    txt_FAULTCODE_B.Enabled = false;
                }
            }
            //수리시작으로 변경
            if (Convert.ToString(cbo_MASTATUS_B.Value) == "C")
            {

                //이전상태가 수리완료, 작업완료 , 작업대기 라면 변경 불가
                if (sStatus == "D" | sStatus == "E" || sStatus == "A")
                {
                    //cboSTATUS.Enabled      = false;
                    cbo_STARTYYMMDD_B.Enabled = false;
                    cbo_STARTHOUR_B.Enabled = false;
                    cbo_STARTMIN_B.Enabled = false;
                    cbo_ENDYYMMDD_B.Enabled = false;
                    cbo_ENDHOUR_B.Enabled = false;
                    cbo_ENDMIN_B.Enabled = false;
                    txt_REPAIRWORKER_B.Enabled = false;
                    txt_REPAIRWORKERNAME_B.Enabled = false;
                    btnDELETE.Visible = false;

                }
                else if (sStatus == "B")
                {
                    ultraLabel1.Visible = false;
                    cbo_ENDYYMMDD_B.Visible = true;
                    cbo_ENDHOUR_B.Visible = true;
                    cbo_ENDMIN_B.Visible = true;
                    lbl_ENDHOUR_B.Visible = true;
                    lbl_ENDMIN_B.Visible = true;

                    cbo_STARTYYMMDD_B.Enabled = true;
                    cbo_STARTHOUR_B.Enabled = true;
                    cbo_STARTMIN_B.Enabled = true;
                    txt_REPAIRWORKER_B.Enabled = true;
                    txt_REPAIRWORKERNAME_B.Enabled = true;
                    txt_FAULTCODE_B.Enabled = true;

                    btnDELETE.Visible = false;

                }
                else
                {

                    cbo_STARTYYMMDD_B.Enabled = true;
                    cbo_STARTHOUR_B.Enabled = true;
                    cbo_STARTMIN_B.Enabled = true;
                    txt_REPAIRWORKER_B.Enabled = true;
                    txt_REPAIRWORKERNAME_B.Enabled = true;
                    txt_FAULTCODE_B.Enabled = true;

                    btnDELETE.Visible = true;

                }
            }

            //수리완료으로 변경
            if (Convert.ToString(cbo_MASTATUS_B.Value) == "D")
            {
                ultraLabel1.Visible = true;
                cbo_ENDYYMMDD_B.Visible = true;
                cbo_ENDHOUR_B.Visible = true;
                cbo_ENDMIN_B.Visible = true;
                lbl_ENDHOUR_B.Visible = true;
                lbl_ENDMIN_B.Visible = true;
                btnDELETE.Visible = false;

                //이전상태가 수리완료 , 작업종료 라면 작업내용만 입력가능
                if (sStatus == "D" || sStatus == "E")
                {
                    cbo_STARTYYMMDD_B.Enabled = false;
                    cbo_STARTHOUR_B.Enabled = false;
                    cbo_STARTMIN_B.Enabled = false;
                    cbo_ENDYYMMDD_B.Enabled = false;
                    cbo_ENDHOUR_B.Enabled = false;
                    cbo_ENDMIN_B.Enabled = false;
                    txt_REPAIRWORKER_B.Enabled = false;
                    txt_REPAIRWORKERNAME_B.Enabled = false;
                    txt_FAULTCODE_B.Enabled = true;
                }
                else if (sStatus == "C") // 수리시작
                {
                    cbo_STARTYYMMDD_B.Enabled = true;
                    cbo_STARTHOUR_B.Enabled = true;
                    cbo_STARTMIN_B.Enabled = true;
                    cbo_ENDYYMMDD_B.Enabled = true;
                    cbo_ENDHOUR_B.Enabled = true;
                    cbo_ENDMIN_B.Enabled = true;
                    txt_REPAIRWORKER_B.Enabled = true;
                    txt_REPAIRWORKERNAME_B.Enabled = true;
                    cbo_STARTYYMMDD_B.Enabled = false;
                    cbo_STARTHOUR_B.Enabled = false;
                    cbo_STARTMIN_B.Enabled = false;
                    btnDELETE.Visible = true;
                }
                else if (sStatus == "A")
                {
                    cbo_STARTYYMMDD_B.Enabled = false;
                    cbo_STARTHOUR_B.Enabled = false;
                    cbo_STARTMIN_B.Enabled = false;
                    cbo_ENDYYMMDD_B.Enabled = false;
                    cbo_ENDHOUR_B.Enabled = false;
                    cbo_ENDMIN_B.Enabled = false;
                    txt_REPAIRWORKER_B.Enabled = false;
                    txt_REPAIRWORKERNAME_B.Enabled = false;
                    btnDELETE.Visible = false;
                }
                else
                {
                    cbo_STARTYYMMDD_B.Enabled = true;
                    cbo_STARTHOUR_B.Enabled = true;
                    cbo_STARTMIN_B.Enabled = true;
                    cbo_ENDYYMMDD_B.Enabled = true;
                    cbo_ENDHOUR_B.Enabled = true;
                    cbo_ENDMIN_B.Enabled = true;
                    txt_REPAIRWORKER_B.Enabled = true;
                    txt_REPAIRWORKERNAME_B.Enabled = true;
                    txt_FAULTCODE_B.Enabled = true;
                    btnDELETE.Visible = false;

                }
            }

            if (Convert.ToString(cbo_MASTATUS_B.Value) == "E")
            {
                ultraLabel1.Visible = true;
                cbo_ENDYYMMDD_B.Visible = true;
                cbo_ENDHOUR_B.Visible = true;
                cbo_ENDMIN_B.Visible = true;
                lbl_ENDHOUR_B.Visible = true;
                lbl_ENDMIN_B.Visible = true;

                if (sStatus == "E")
                {
                    btnDELETE.Visible = false;
                }
                else
                {
                    btnDELETE.Visible = false;
                }


                cbo_STARTYYMMDD_B.Enabled = false;
                cbo_STARTHOUR_B.Enabled = false;
                cbo_STARTMIN_B.Enabled = false;
                cbo_ENDYYMMDD_B.Enabled = false;
                cbo_ENDHOUR_B.Enabled = false;
                cbo_ENDMIN_B.Enabled = false;
                txt_REPAIRWORKER_B.Enabled = false;
                txt_REPAIRWORKERNAME_B.Enabled = false;
            }

        }
    }
}

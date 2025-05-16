#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP9930
//   Form Name    : 고장실적조회 및 취소
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.PP
{


    public partial class PP9930 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>

        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        DataTable rtnDtTemp = new DataTable();

        #endregion

        #region<CONSTRUCTOR>
        public PP9930()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();

            this.plantCode = CModule.GetAppSetting("Site", "10");
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600Y", new object[] { cboPlantCode_H, "", "", "" }); //작업장
            btbManager.PopUpAdd(txtMachCode, txtMachName, "TBM0700", new object[] { "", "", "", "" }); //설비


        }
        #endregion

        #region 폼 로더
        private void PP9930_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 120, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "진행상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE", "고장신고일자", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAINTRSORDNO", "고장신고번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FAULTTYPE", "고장분류", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FAUILWORKID", "신고자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FAUILWORKNM", "신고자명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STARTTIME", "고장신고일시", false, GridColDataType_emu.VarChar, 170, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MASTARTTIME", "작업시작일시", false, GridColDataType_emu.VarChar, 170, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE", "완료일시", false, GridColDataType_emu.VarChar, 170, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FAULTTIME", "고장시간(초)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "고장내용", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "RPTSTARTDT", "수리시작일시", false, GridColDataType_emu.VarChar, 170, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RPRENDDT", "수리완료일시", false, GridColDataType_emu.VarChar, 170, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKTIME", "수리시간(초)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKERCNT",      "작업자",       false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "작업자명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MADESC", "작업내용", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "작업자", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 170, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAINTRSORDTYPE", "발생구분", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("FAILURETYPE"); // 고장 분류
            WIZ.Common.FillComboboxMaster(this.cboFailureType_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FAULTTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("MAINTRSORDTYPE");  //보전작업지시구분
            WIZ.Common.FillComboboxMaster(cboGubun, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MAINTRSORDTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            GetFailStatus();
            //콤보박스 시, 분 셋팅
            GetHour();
            GetMin();
            this.btnSave.Enabled = false;
            this.btnDelete.Enabled = false;

            //시간
            cboStartDate.Value = DateTime.Now.AddDays(-7);

            #endregion
        }
        #endregion

        private void GetFailStatus()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT MINORCODE                           AS CODE_ID, ");
                command.AppendLine("       '['+ MINORCODE +']' + CODENAME        AS CODE_NAME");
                command.AppendLine("  FROM TBM0000                                           ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND MAJORCODE = 'FAILSTATUS' ");
                command.AppendLine("   AND RELCODE1  = 'UI' ");
                command.AppendLine("   AND MINORCODE <> '$'   ");
                command.AppendLine(" ORDER BY MINORCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(this.cboFixStatus, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STATUS", dttemp, "CODE_ID", "CODE_NAME");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                WIZ.Common.FillComboboxMaster(cboSTARTHOUR, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, null);
                cboSTARTHOUR.Value = "00";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                WIZ.Common.FillComboboxMaster(cboSTARTMIN, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, null);
                cboSTARTMIN.Value = "00";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }
        #region<DoInquire>
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                //base.DoInquire();
                if (!CheckData())
                {
                    return;
                }

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);               //사업장코드                                                                                          
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cboStartDate.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEndDate.Value);
                string sWorkCenterCode = txtWorkCenterCode.Text.Trim();
                string sStatus = Convert.ToString(cboFixStatus.Value);
                string sMachCode = txtMachCode.Text.Trim();
                string sMaDesc = txtFixRemark.Text.Trim();



                rtnDtTemp = helper.FillTable("USP_PP5200_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("STATUS", sStatus, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MADESC", sMaDesc, DbType.String, ParameterDirection.Input)
                                                                    );

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);
                    }
                    else
                    {
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), DialogForm.DialogType.OK);
                    }
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
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
        #endregion

        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cboStartDate.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cboEndDate.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("조회 시작일자가 종료일자보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;


            //고장내역 초기화
            cboSTARTYYMMDD.Value = DateTime.Now.ToString("yyyy-MM-dd");
            cboSTARTHOUR.Value = "00";
            cboSTARTMIN.Value = "00";
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            if (this.grid1.ActiveRow.Cells["STATUS"].Value.ToString() != "10")
            {
                this.ShowDialog(Common.getLangText("작업대기가 아닌 데이터는 고장실적 취소 를 할수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }
            else
            {
                if (MessageBox.Show("선택한 고장실적을 취소 하시겠습니까?", "고장 실적 취소", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                DBHelper helper = new DBHelper("", true);
                try
                {
                    string sPlantCode = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
                    string sMAINTRSORDNO = this.grid1.ActiveRow.Cells["MAINTRSORDNO"].Value.ToString();// 보전지시번호

                    helper.ExecuteNoneQuery("USP_PP9930_D1", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_MAINTRSORDNO", sMAINTRSORDNO, DbType.String, ParameterDirection.Input)
                                            );
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

        /// <summary>
        /// ToolBar의 저장 버튼 : 고장 분류 및 고장내역 update
        /// </summary>
        public override void DoSave()
        {
            Grid1ToolAct();
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
                string sFailureType = Convert.ToString(this.cboFailureType_B.Value);              // 고장 분류
                string sRemark = Convert.ToString(this.txtREMARK.Text);                      // 고장내역
                string sMAINTRSORDNO = this.grid1.ActiveRow.Cells["MAINTRSORDNO"].Value.ToString();// 보전지시번호
                if (sRemark == "")
                {
                    this.ShowDialog(Common.getLangText("고장내역을 입력하지 않았습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                helper.ExecuteNoneQuery("USP_PP9930_U1", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_MAINTRSORDNO", sMAINTRSORDNO, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_FAILURETYPE", sFailureType, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input)
                                        );
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
                        if (this.grid1.Rows[i].Cells["MAINTRSORDNO"].Value.ToString() == sMAINTRSORDNO)
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

        // 도착 등록 버튼 클릭
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;
            string sStatus = this.grid1.ActiveRow.Cells["STATUS"].Value.ToString();
            if (sStatus != "10")
            {
                this.ShowDialog(Common.getLangText("작업대기가 아닌 상태에서 도착등록을 할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //입력한 작업시작시간
            DateTime eDate = Convert.ToDateTime(cboSTARTYYMMDD.Value);
            string eDay = eDate.ToString("yyyy") + "-" + eDate.ToString("MM") + "-" + eDate.ToString("dd");
            string eHour = Convert.ToString(cboSTARTHOUR.Value);
            string eMin = Convert.ToString(cboSTARTMIN.Value);
            string eTime = eDay + " " + eHour + ":" + eMin;

            DateTime sTime = Convert.ToDateTime(this.grid1.ActiveRow.Cells["STARTTIME"].Value.ToString());
            //작업 시작시간은 고장 시작시간보다 이전 일 수 없습니다.
            if (Convert.ToDateTime(eTime) < Convert.ToDateTime(sTime))
            {
                this.ShowDialog(Common.getLangText("작업 시작시간은 고장 시작시간보다 이전 일 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (MessageBox.Show("작업자 도착등록을 하시겠습니까? ", "작업자 도착등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            DBHelper helper = new DBHelper("", true);
            try
            {
                string sMAINTRSORDNO = this.grid1.ActiveRow.Cells["MAINTRSORDNO"].Value.ToString();
                string sPLANTCODE = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();

                helper.ExecuteNoneQuery("USP_PP9930_U2", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAINTRSORDNO", sMAINTRSORDNO, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MASTARTTIME", Convert.ToDateTime(eTime), DbType.DateTime, ParameterDirection.Input)// 작업시작시간
                                    , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                    );
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
                    if (this.grid1.Rows[i].Cells["MAINTRSORDNO"].Value.ToString() == sMAINTRSORDNO)
                    {
                        this.grid1.Rows[i].Activated = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        // 작업자 도착등록 취소
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;
            string sStatus = this.grid1.ActiveRow.Cells["STATUS"].Value.ToString();
            if (sStatus != "20")
            {
                this.ShowDialog(Common.getLangText("작업중이 아닌 상태에서 도착등록 취소를 할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (MessageBox.Show("작업자 도착등록을 취소 하시겠습니까? ", "작업자 도착등록 취소", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            DBHelper helper = new DBHelper("", true);
            try
            {
                string sMAINTRSORDNO = this.grid1.ActiveRow.Cells["MAINTRSORDNO"].Value.ToString();
                string sPLANTCODE = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();

                helper.ExecuteNoneQuery("USP_PP9930_U3", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAINTRSORDNO", sMAINTRSORDNO, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                    );

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
                    if (this.grid1.Rows[i].Cells["MAINTRSORDNO"].Value.ToString() == sMAINTRSORDNO)
                    {
                        this.grid1.Rows[i].Activated = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void grid1_ClickCell_1(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            txtMAINTRSORDNO.Text = grid1.ActiveRow.Cells["MAINTRSORDNO"].Value.ToString();

            cboGubun.Value = grid1.ActiveRow.Cells["MAINTRSORDTYPE"].Value.ToString();

            txtFAUILWORKID.Text = grid1.ActiveRow.Cells["FAUILWORKID"].Value.ToString();                     // 고장 신고자
            txtFAUILWORKNM.Text = grid1.ActiveRow.Cells["FAUILWORKNM"].Value.ToString();                     // 고장 신고자 명
            txtWorkCenterCode2.Text = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();                  // 작업장
            txtWorkCenterName2.Text = grid1.ActiveRow.Cells["WORKCENTERNAME"].Value.ToString();                  // 작업장 명
            txtMachCode2.Text = grid1.ActiveRow.Cells["MACHCODE"].Value.ToString();                        // 설비
            txtMachName2.Text = grid1.ActiveRow.Cells["MACHNAME"].Value.ToString();                        // 설비 명
            txtSTARTDATE.Text = grid1.ActiveRow.Cells["STARTTIME"].Value.ToString();                       // 고장 신고일시
            txtEndDate.Text = grid1.ActiveRow.Cells["ENDDATE"].Value.ToString();                         // 작업 완료 일시
            txtFAULTTIME.Text = grid1.ActiveRow.Cells["FAULTTIME"].Value.ToString();                       // 고장 시간
            cboFailureType_B.Value = grid1.ActiveRow.Cells["FAULTTYPE"].Value.ToString();                       // 고장 분류
            txtREMARK.Text = grid1.ActiveRow.Cells["REMARK"].Value.ToString();                          // 고장 내역
            txtMaWorkerName_B.Text = grid1.ActiveRow.Cells["WORKERNAME"].Value.ToString();                      // 수리 작업자
            txtFailureCont_B.Text = grid1.ActiveRow.Cells["MADESC"].Value.ToString();                          // 수리내역
            txtRPTSTARTDT_B.Text = grid1.ActiveRow.Cells["RPTSTARTDT"].Value.ToString();                      // 수리시작 일시
            txtWORKTIME_B.Text = grid1.ActiveRow.Cells["WORKTIME"].Value.ToString();                        // 수리 시간
            string MaStartTime = grid1.ActiveRow.Cells["MASTARTTIME"].Value.ToString();                     // 작업시작일시 (작업자 도착일시)
            string MaEndTime = txtRPRENDDT_B.Text = grid1.ActiveRow.Cells["RPRENDDT"].Value.ToString(); // 수리 완료 일시

            //시작시간 셋팅
            if (MaStartTime != "")
            {
                DateTime sTime = Convert.ToDateTime(MaStartTime);
                cboSTARTYYMMDD.Value = sTime.ToString("yyyy") + "-" + sTime.ToString("MM") + "-" + sTime.ToString("dd");
                cboSTARTHOUR.Value = sTime.ToString("HH");
                cboSTARTMIN.Value = sTime.ToString("mm");
            }
            else
            {
                cboSTARTYYMMDD.Value = DateTime.Now.ToString("yyyy-MM-dd");
                cboSTARTHOUR.Value = "00";
                cboSTARTMIN.Value = "00";
            }
            if (this.grid1.ActiveRow.Cells["STATUS"].Value.ToString() == "10") // 작업대기 일때
            {
                this.btnSave.Enabled = true;
                this.btnDelete.Enabled = false;
            }
            else if (this.grid1.ActiveRow.Cells["STATUS"].Value.ToString() == "20") // 작업중 일때
            {
                this.btnSave.Enabled = false;
                this.btnDelete.Enabled = true;
            }
            else
            {
                this.btnSave.Enabled = false;
                this.btnDelete.Enabled = false;
            }
            if (this.grid1.ActiveRow.Cells["STATUS"].Value.ToString() != "10")
            {
                this.cboSTARTYYMMDD.Enabled = false;
                this.cboSTARTHOUR.Enabled = false;
                this.cboSTARTMIN.Enabled = false;
            }
            else
            {
                this.cboSTARTYYMMDD.Enabled = true;
                this.cboSTARTHOUR.Enabled = true;
                this.cboSTARTMIN.Enabled = true;
            }
        }
    }
}
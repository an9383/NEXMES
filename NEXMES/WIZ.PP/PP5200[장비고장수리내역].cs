using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
namespace WIZ.PP
{
    public partial class PP5200 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        private string plantCode = string.Empty; //plantcode default 설정
        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region<CONSTRUCTOR>
        public PP5200()
        {
            InitializeComponent();

            //WIZ.PopUp.BizGridManager BIZPOP;
            //BIZPOP = new BizGridManager(grid1);
            //BIZPOP.PopUpAdd("STOPCODE", "STOPDESC", "TBM1100", new string[] { "", "", "Y" }, new string[] { "STOPTYPE", "STOPCLASS" }, new string[] { "Y" });
            //BizGridManager bizGridManager;

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtFAUILWORKID, txtFAUILWORKNM, "TBM0200", new object[] { cboPlantCode_H, "", "", "", "" }); //신고자
            btbManager.PopUpAdd(txtWorkerId, txtWorkerName, "TBM0200", new object[] { cboPlantCode_H, "", "", "", "" }); //작업자

            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600Y", new object[] { cboPlantCode_H, "", "", "" }); //작업장
            btbManager.PopUpAdd(txtWorkCenterCode2, txtWorkCenterName2, "TBM0600Y", new object[] { cboPlantCode_H, "", "", "" }); //작업장

            btbManager.PopUpAdd(txtMachCode, txtMachName, "TBM0700", new object[] { cboPlantCode_H, "", "", "" }); //설비
            btbManager.PopUpAdd(txtMachCode2, txtMachName2, "TBM0700", new object[] { cboPlantCode_H, "", "", "" }); //설비
        }
        #endregion
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        #region  PP5200_Load
        private void PP5200_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성                                                                                                                                                                              
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 120, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "진행상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE", "고장신고일자", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAINTRSORDNO", "고장신고번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
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
            _GridUtil.InitColumnUltraGrid(grid1, "MADESC", " 수리내용", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "작업자", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 170, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAINTRSORDTYPE", "발생구분", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #region Grid MERGE
            //grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;                                                                                                       
            //grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;                                                                                              
            //grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;                                                                                                                        
            //                                                                                                                                                                                            
            //grid1.Columns["RECDATE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;                                                                                                         
            //grid1.Columns["RECDATE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;                                                                                                
            //grid1.Columns["RECDATE"].MergedCellStyle = MergedCellStyle.Always;                                                                                                                          
            //                                                                                                                                                                                            
            //grid1.Columns["WORKCENTERCODE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;                                                                                                  
            //grid1.Columns["WORKCENTERCODE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;                                                                                         
            //grid1.Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;                                                                                                                   
            //                                                                                                                                                                                            
            //grid1.Columns["WORKCENTERNAME"].MergedCellContentArea = MergedCellContentArea.VisibleRect;                                                                                                  
            //grid1.Columns["WORKCENTERNAME"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;                                                                                         
            //grid1.Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;                                                                                                                   

            #endregion Grid MERGE

            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통   
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장                                                                                                                                
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");
            plantCode = Convert.ToString(cboPlantCode_H.Value);
            rtnDtTemp = _Common.GET_BM0000_CODE("FAILURETYPE");  //고장분류                                                                                                                            
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FAULTTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            // 작업구분 선택
            GetFailStatus();

            rtnDtTemp = _Common.GET_BM0000_CODE("MAINTRSORDTYPE");  //보전작업지시구분
            WIZ.Common.FillComboboxMaster(cboGubun, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            //콤보박스 시, 분 셋팅
            GetHour();
            GetMin();

            //시간
            cboStartDate.Value = DateTime.Now.AddDays(-7);

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
                command.AppendLine("  FROM TBM0000                                           ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND MAJORCODE = 'FAILSTATUS' ");
                command.AppendLine("   AND RELCODE1  = 'UI' ");
                command.AppendLine("   AND MINORCODE <> '$'   ");
                command.AppendLine(" ORDER BY MINORCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(this.cboFixStatus, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.Common.FillComboboxMaster(this.cboSTATUS, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STATUS", dttemp, "CODE_ID", "CODE_NAME");
                cboSTATUS.Value = "";
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
                WIZ.Common.FillComboboxMaster(cboENDHOUR, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, null);
                cboENDHOUR.Value = "00";
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
                WIZ.Common.FillComboboxMaster(cboENDMIN, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, null);
                cboENDMIN.Value = "00";
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

        #region<TOOL BAR AREA >
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
                          , helper.CreateParameter("MADESC", sMaDesc, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);
                    }
                    else
                    {
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK); //조회할 데이터가 없습니다.
                    }
                }
                else
                {
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
        #endregion

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            txtMAINTRSORDNO.Text = grid1.ActiveRow.Cells["MAINTRSORDNO"].Value.ToString();

            cboGubun.Value = grid1.ActiveRow.Cells["MAINTRSORDTYPE"].Value.ToString();

            txtFAUILWORKID.Text = grid1.ActiveRow.Cells["FAUILWORKID"].Value.ToString();
            txtFAUILWORKNM.Text = grid1.ActiveRow.Cells["FAUILWORKNM"].Value.ToString();
            txtWorkCenterCode2.Text = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
            txtWorkCenterName2.Text = grid1.ActiveRow.Cells["WORKCENTERNAME"].Value.ToString();
            txtMachCode2.Text = grid1.ActiveRow.Cells["MACHCODE"].Value.ToString();
            txtMachName2.Text = grid1.ActiveRow.Cells["MACHNAME"].Value.ToString();

            txtSTARTDATE.Text = grid1.ActiveRow.Cells["STARTTIME"].Value.ToString();
            txtENDDATE.Text = grid1.ActiveRow.Cells["ENDDATE"].Value.ToString();
            txtFAULTTIME.Text = grid1.ActiveRow.Cells["FAULTTIME"].Value.ToString();

            txtFAULTTYPE.Text = grid1.ActiveRow.Cells["FAULTTYPE"].Text.ToString();
            txtREMARK.Text = grid1.ActiveRow.Cells["REMARK"].Value.ToString();

            cboSTATUS.Value = "";
            cboSTATUS.Value = grid1.ActiveRow.Cells["STATUS"].Value.ToString();

            txtWorkerId.Text = grid1.ActiveRow.Cells["EDITOR"].Value.ToString();
            txtWorkerName.Text = grid1.ActiveRow.Cells["WORKERNAME"].Value.ToString();
            txtMADESC.Text = grid1.ActiveRow.Cells["MADESC"].Value.ToString();
            txtMADESC.Text = grid1.ActiveRow.Cells["MADESC"].Value.ToString();
            txtMASTARTTIME_B.Text = grid1.ActiveRow.Cells["MASTARTTIME"].Value.ToString();
            string MaStartTime = grid1.ActiveRow.Cells["RPTSTARTDT"].Value.ToString();
            string MaEndTime = grid1.ActiveRow.Cells["RPRENDDT"].Value.ToString();

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
            //종료시간 셋팅
            if (MaEndTime != "")
            {
                DateTime eTime = Convert.ToDateTime(MaEndTime);
                cboENDYYMMDD.Value = eTime.ToString("yyyy") + "-" + eTime.ToString("MM") + "-" + eTime.ToString("dd");
                cboENDHOUR.Value = eTime.ToString("HH");
                cboENDMIN.Value = eTime.ToString("mm");
            }
            else
            {
                cboENDYYMMDD.Value = DateTime.Now.ToString("yyyy-MM-dd");
                cboENDHOUR.Value = "00";
                cboENDMIN.Value = "00";
            }
        }

        private void cboSTATUS_ValueChanged(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            //이전 상태
            string sStatus = grid1.ActiveRow.Cells["STATUS"].Value.ToString();

            //작업중으로 변경 , 작업대기로 변경
            if (Convert.ToString(cboSTATUS.Value) == "20" || Convert.ToString(cboSTATUS.Value) == "10")
            {
                ultraLabel1.Visible = true;
                cboENDYYMMDD.Visible = true;
                cboENDHOUR.Visible = true;
                cboENDMIN.Visible = true;
                sLabel13.Visible = true;
                sLabel6.Visible = true;
                btnSave.Visible = false;
                btnDelete.Visible = false;
                btnReset.Visible = false;



                //이전상태가 수리완료 및 작업완료라면 변경 불가
                if (sStatus == "40" || sStatus == "50")
                {
                    //cboSTATUS.Enabled      = false;
                    cboSTARTYYMMDD.Enabled = false;
                    cboSTARTHOUR.Enabled = false;
                    cboSTARTMIN.Enabled = false;
                    cboENDYYMMDD.Enabled = false;
                    cboENDHOUR.Enabled = false;
                    cboENDMIN.Enabled = false;
                    txtWorkerId.Enabled = false;
                    txtWorkerName.Enabled = false;
                    //txtMADESC.Enabled      = false;
                }
                else
                {
                    //cboSTARTYYMMDD.Enabled = true;
                    //cboSTARTHOUR.Enabled = true;
                    //cboSTARTMIN.Enabled = true;
                    //cboENDYYMMDD.Enabled = true;
                    //cboENDHOUR.Enabled = true;
                    //cboENDMIN.Enabled = true;
                    //txtWorkerId.Enabled = true;
                    //txtWorkerName.Enabled = true;

                    //모두 변경 불가
                    cboSTARTYYMMDD.Enabled = false;
                    cboSTARTHOUR.Enabled = false;
                    cboSTARTMIN.Enabled = false;
                    cboENDYYMMDD.Enabled = false;
                    cboENDHOUR.Enabled = false;
                    cboENDMIN.Enabled = false;
                    txtWorkerId.Enabled = false;
                    txtWorkerName.Enabled = false;
                    txtMADESC.Enabled = false;
                }
            }
            //수리시작으로 변경
            if (Convert.ToString(cboSTATUS.Value) == "30")
            {

                //이전상태가 수리완료, 작업완료 , 작업대기 라면 변경 불가
                if (sStatus == "40" | sStatus == "50" || sStatus == "10")
                {
                    //cboSTATUS.Enabled      = false;
                    cboSTARTYYMMDD.Enabled = false;
                    cboSTARTHOUR.Enabled = false;
                    cboSTARTMIN.Enabled = false;
                    cboENDYYMMDD.Enabled = false;
                    cboENDHOUR.Enabled = false;
                    cboENDMIN.Enabled = false;
                    txtWorkerId.Enabled = false;
                    txtWorkerName.Enabled = false;
                    btnSave.Visible = false;
                    btnDelete.Visible = false;
                    btnReset.Visible = false;


                    //txtMADESC.Enabled      = false;
                }
                else if (sStatus == "20")
                {
                    ultraLabel1.Visible = false;
                    cboENDYYMMDD.Visible = false;
                    cboENDHOUR.Visible = false;
                    cboENDMIN.Visible = false;
                    sLabel13.Visible = false;
                    sLabel6.Visible = false;

                    cboSTARTYYMMDD.Enabled = true;
                    cboSTARTHOUR.Enabled = true;
                    cboSTARTMIN.Enabled = true;
                    txtWorkerId.Enabled = true;
                    txtWorkerName.Enabled = true;
                    txtMADESC.Enabled = true;

                    btnSave.Visible = true;
                    btnDelete.Visible = false;
                    btnReset.Visible = true;

                }
                else
                {
                    ultraLabel1.Visible = false;
                    cboENDYYMMDD.Visible = false;
                    cboENDHOUR.Visible = false;
                    cboENDMIN.Visible = false;
                    sLabel13.Visible = false;
                    sLabel6.Visible = false;

                    cboSTARTYYMMDD.Enabled = true;
                    cboSTARTHOUR.Enabled = true;
                    cboSTARTMIN.Enabled = true;
                    txtWorkerId.Enabled = true;
                    txtWorkerName.Enabled = true;
                    txtMADESC.Enabled = true;

                    btnSave.Visible = true;
                    btnDelete.Visible = true;
                    btnReset.Visible = true;

                }
            }

            //수리완료으로 변경
            if (Convert.ToString(cboSTATUS.Value) == "40")
            {
                ultraLabel1.Visible = true;
                cboENDYYMMDD.Visible = true;
                cboENDHOUR.Visible = true;
                cboENDMIN.Visible = true;
                sLabel13.Visible = true;
                sLabel6.Visible = true;
                btnSave.Visible = true;
                btnDelete.Visible = false;
                btnReset.Visible = true;


                //이전상태가 수리완료 , 작업종료 라면 작업내용만 입력가능
                if (sStatus == "40" || sStatus == "50")
                {
                    cboSTARTYYMMDD.Enabled = false;
                    cboSTARTHOUR.Enabled = false;
                    cboSTARTMIN.Enabled = false;
                    cboENDYYMMDD.Enabled = false;
                    cboENDHOUR.Enabled = false;
                    cboENDMIN.Enabled = false;
                    txtWorkerId.Enabled = false;
                    txtWorkerName.Enabled = false;
                    txtMADESC.Enabled = true;
                    btnSave.Visible = true;
                }
                else if (sStatus == "30") // 수리시작
                {
                    cboSTARTYYMMDD.Enabled = true;
                    cboSTARTHOUR.Enabled = true;
                    cboSTARTMIN.Enabled = true;
                    cboENDYYMMDD.Enabled = true;
                    cboENDHOUR.Enabled = true;
                    cboENDMIN.Enabled = true;
                    txtWorkerId.Enabled = true;
                    txtWorkerName.Enabled = true;
                    cboSTARTYYMMDD.Enabled = false;
                    cboSTARTHOUR.Enabled = false;
                    cboSTARTMIN.Enabled = false;
                    btnSave.Visible = true;
                    btnDelete.Visible = true;
                    btnReset.Visible = true;
                }
                else if (sStatus == "10")
                {
                    cboSTARTYYMMDD.Enabled = false;
                    cboSTARTHOUR.Enabled = false;
                    cboSTARTMIN.Enabled = false;
                    cboENDYYMMDD.Enabled = false;
                    cboENDHOUR.Enabled = false;
                    cboENDMIN.Enabled = false;
                    txtWorkerId.Enabled = false;
                    txtWorkerName.Enabled = false;
                    btnSave.Visible = false;
                    btnDelete.Visible = false;
                    btnReset.Visible = false;
                }
                else
                {
                    cboSTARTYYMMDD.Enabled = true;
                    cboSTARTHOUR.Enabled = true;
                    cboSTARTMIN.Enabled = true;
                    cboENDYYMMDD.Enabled = true;
                    cboENDHOUR.Enabled = true;
                    cboENDMIN.Enabled = true;
                    txtWorkerId.Enabled = true;
                    txtWorkerName.Enabled = true;
                    txtMADESC.Enabled = true;
                    btnSave.Visible = true;
                    btnDelete.Visible = false;
                    btnReset.Visible = true;

                }
            }

            if (Convert.ToString(cboSTATUS.Value) == "50")
            {
                ultraLabel1.Visible = true;
                cboENDYYMMDD.Visible = true;
                cboENDHOUR.Visible = true;
                cboENDMIN.Visible = true;
                sLabel13.Visible = true;
                sLabel6.Visible = true;

                if (sStatus == "50")
                {
                    btnSave.Visible = true;
                    btnDelete.Visible = false;
                    btnReset.Visible = false;
                }
                else
                {
                    btnSave.Visible = false;
                    btnDelete.Visible = false;
                    btnReset.Visible = false;
                }


                cboSTARTYYMMDD.Enabled = false;
                cboSTARTHOUR.Enabled = false;
                cboSTARTMIN.Enabled = false;
                cboENDYYMMDD.Enabled = false;
                cboENDHOUR.Enabled = false;
                cboENDMIN.Enabled = false;
                txtWorkerId.Enabled = false;
                txtWorkerName.Enabled = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0) return;
            string sStatus = this.grid1.ActiveRow.Cells["STATUS"].Value.ToString();

            //작업중이면 모두 초기화
            if (sStatus == "20" && (Convert.ToString(cboSTATUS.Value) == "30" || Convert.ToString(cboSTATUS.Value) == "40"))
            {
                cboSTARTYYMMDD.Value = DateTime.Now.ToString("yyyy-MM-dd");
                cboSTARTHOUR.Value = "00";
                cboSTARTMIN.Value = "00";

                cboENDYYMMDD.Value = DateTime.Now.ToString("yyyy-MM-dd");
                cboENDHOUR.Value = "00";
                cboENDMIN.Value = "00";

                txtWorkerId.Text = string.Empty;
                txtWorkerName.Text = string.Empty;
                txtMADESC.Text = string.Empty;
            }

            else if (sStatus == "30" && (Convert.ToString(cboSTATUS.Value) == "30" || Convert.ToString(cboSTATUS.Value) == "40"))
            {
                DateTime sTime = Convert.ToDateTime(this.grid1.ActiveRow.Cells["RPTSTARTDT"].Value.ToString());
                cboSTARTYYMMDD.Value = sTime.ToString("yyyy") + "-" + sTime.ToString("MM") + "-" + sTime.ToString("dd");
                cboSTARTHOUR.Value = sTime.ToString("HH");
                cboSTARTMIN.Value = sTime.ToString("mm");



                cboENDYYMMDD.Value = DateTime.Now.ToString("yyyy-MM-dd");
                cboENDHOUR.Value = "00";
                cboENDMIN.Value = "00";

                txtWorkerId.Text = this.grid1.ActiveRow.Cells["EDITOR"].Value.ToString();
                txtWorkerName.Text = this.grid1.ActiveRow.Cells["WORKERNAME"].Value.ToString();
                txtMADESC.Text = this.grid1.ActiveRow.Cells["MADESC"].Value.ToString();
            }

            //작업완료면 작업내용 초기화
            else if (sStatus == "40" || sStatus == "50")
            {
                txtMADESC.Text = this.grid1.ActiveRow.Cells["MADESC"].Value.ToString();
            }

        }

        //취소시
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            //이전의 상태
            string bStatus = grid1.ActiveRow.Cells["STATUS"].Value.ToString();

            //수리완료는 취소 불가
            if (bStatus == "40")
            {
                this.ShowDialog(Common.getLangText("수리완료 상태에서 작업 취소가 불가합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            // 작업중인 상태는 취소 불가
            if (bStatus == "20")
            {
                this.ShowDialog(Common.getLangText("작업중 상태에서 수리실적 취소를 할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            string sWorkerCenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sMachCode = Convert.ToString(grid1.ActiveRow.Cells["MACHCODE"].Value);
            string sMaintrsordno = Convert.ToString(grid1.ActiveRow.Cells["MAINTRSORDNO"].Value);

            DBHelper helper = new DBHelper("", true);
            //helper.Transaction = helper._sConn.BeginTransaction();
            try
            {
                //업데이트 내역 모두 초기화 및 작업대기 상태로 변경
                helper.ExecuteNoneQuery("USP_PP5200_U2N", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", plantCode, DbType.String, ParameterDirection.Input)  // 공장
                                    , helper.CreateParameter("WORKCENTERCODE", sWorkerCenterCode, DbType.String, ParameterDirection.Input)  // 작업장
                                    , helper.CreateParameter("MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)  // 고장장(설)비코드 
                                    , helper.CreateParameter("MAINTRSORDNO", sMaintrsordno, DbType.String, ParameterDirection.Input)  // 보전작업지시번호
                                    , helper.CreateParameter("EDITOR", WorkerID, DbType.String, ParameterDirection.Input)  // 수정자
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
                    if (this.grid1.Rows[i].Cells["MAINTRSORDNO"].Value.ToString() == sMaintrsordno)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            //이전의 상태
            string bStatus = grid1.ActiveRow.Cells["STATUS"].Value.ToString();
            //변경할 상태
            string aStatus = Convert.ToString(cboSTATUS.Value);

            //작업대기에서 작업대기로는 변경 불가
            if (bStatus == "20" && aStatus == "20")
            {
                this.ShowDialog(Common.getLangText("작업중인 상태에서 작업중 상태로 변경 불가합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업중에서 작업대기로는 변경 불가
            if (bStatus == "30" && aStatus == "20")
            {
                this.ShowDialog(Common.getLangText("수리시작 상태에서 작업중 상태로 변경 불가합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업완료에서 작업대기 또는 작업중으로 변경 불가
            if ((bStatus == "40" && aStatus == "20") || (bStatus == "40" && aStatus == "30"))
            {
                this.ShowDialog(Common.getLangText("수리완료 상태에서 이전상태로 변경 불가합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업완료인 경우 작업완료일시 필수입력
            if ((bStatus == "40" && cboENDYYMMDD.Value == null) || (bStatus == "40" && cboENDYYMMDD.Value == null) || (bStatus == "40" && cboENDYYMMDD.Value == null))
            {
                this.ShowDialog(Common.getLangText("수리완료 상태 저장시 수리완료 일시는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업자 필수입력
            if (txtWorkerId.Text == "")
            {
                this.ShowDialog(Common.getLangText("작업자는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업내용 필수입력
            if (txtMADESC.Text == "")
            {
                this.ShowDialog(Common.getLangText("수리내용은 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //입력한 작업시작시간
            DateTime sDate = Convert.ToDateTime(cboSTARTYYMMDD.Value);
            string sDay = sDate.ToString("yyyy") + "-" + sDate.ToString("MM") + "-" + sDate.ToString("dd");
            string sHour = Convert.ToString(cboSTARTHOUR.Value);
            string sMin = Convert.ToString(cboSTARTMIN.Value);
            string sTime = sDay + " " + sHour + ":" + sMin;

            //입력한 작업종료시간
            DateTime eDate = Convert.ToDateTime(cboENDYYMMDD.Value);
            string eDay = eDate.ToString("yyyy") + "-" + eDate.ToString("MM") + "-" + eDate.ToString("dd");
            string eHour = Convert.ToString(cboENDHOUR.Value);
            string eMin = Convert.ToString(cboENDMIN.Value);
            string eTime = eDay + " " + eHour + ":" + eMin;

            //작업시작시간
            string sFailtime = Convert.ToString(grid1.ActiveRow.Cells["MASTARTTIME"].Value);

            //입력한 작업시작시간은 고장시작 시간보다 작을 수 없음
            if (Convert.ToDateTime(sTime) < Convert.ToDateTime(sFailtime))
            {
                this.ShowDialog(Common.getLangText("수리시작 시간은 작업시작 시간보다 작을 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업완료시 입력한 작업종료시간은 입력한 작업시작시간보다 작을 수 없음
            if (aStatus == "40" && Convert.ToDateTime(eTime) < Convert.ToDateTime(sTime))
            {
                this.ShowDialog(Common.getLangText("수리완료 시간은 수리시작 시간보다 작을 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value); // 공장
            string sWorkerCenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sMachCode = Convert.ToString(grid1.ActiveRow.Cells["MACHCODE"].Value);
            string sMaintrsordno = Convert.ToString(grid1.ActiveRow.Cells["MAINTRSORDNO"].Value);
            string sWorker = Convert.ToString(txtWorkerId.Text);                      // 작업자
            string sMaDesc = Convert.ToString(txtMADESC.Text);                        // 작업내용

            DBHelper helper = new DBHelper("", true);
            //helper.Transaction = helper._sConn.BeginTransaction();
            try
            {
                //작업대기에서 작업중, 작업완료로 저장시 나눠서 처리
                helper.ExecuteNoneQuery("USP_PP5200_U1N", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)  // 공장
                                    , helper.CreateParameter("WORKCENTERCODE", sWorkerCenterCode, DbType.String, ParameterDirection.Input)  // 작업장
                                    , helper.CreateParameter("MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)  // 고장장(설)비코드 
                                    , helper.CreateParameter("MASTARTTIME", sTime, DbType.DateTime, ParameterDirection.Input)// 작업시작시간
                                    , helper.CreateParameter("MAENDTIME", eTime, DbType.DateTime, ParameterDirection.Input)// 작업종료시간  
                                    , helper.CreateParameter("MAINTRSORDNO", sMaintrsordno, DbType.String, ParameterDirection.Input)  // 보전작업지시번호
                                    , helper.CreateParameter("BSTATUS", bStatus, DbType.String, ParameterDirection.Input)  // 변경전 작업상태
                                    , helper.CreateParameter("STATUS", aStatus, DbType.String, ParameterDirection.Input)  // 변경할 작업상태
                                    , helper.CreateParameter("WORKER", sWorker, DbType.String, ParameterDirection.Input)  // 작업자
                                    , helper.CreateParameter("MADESC", sMaDesc, DbType.String, ParameterDirection.Input)  // 작업내용
                                    , helper.CreateParameter("EDITOR", WorkerID, DbType.String, ParameterDirection.Input)  // 수정자
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
                    if (this.grid1.Rows[i].Cells["MAINTRSORDNO"].Value.ToString() == sMaintrsordno)
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
    }
}
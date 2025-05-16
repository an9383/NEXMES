using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
namespace WIZ.PP
{
    public partial class PP5201 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        #endregion

        #region<CONSTRUCTOR>
        public PP5201()
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
        #region  PP5201_Load
        private void PP5201_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성                                                                                                                                                                              
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE", "고장신고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAINTRSORDNO", "고장신고번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FAULTTYPE", "고장분류", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FAUILWORKID", "신고자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FAUILWORKNM", "신고자명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STARTTIME", "고장신고일시", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE", "처리완료일시", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FAULTTIME", "고장시간(초)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "고장내용", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "진행상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MASTARTTIME", "작업시작일시", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAENDTIME", "작업완료일시", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKTIME", "작업시간(초)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKERCNT",      "작업자",       false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "작업자명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MADESC", "작업내용", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "작업자", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
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
            //rtnDtTemp = _Common.GET_TBM0000_CODE("FAULTTYPE");  //고장분류                                                                                                                            
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FaultType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("FAILSTATUS");  //작업상태
            WIZ.Common.FillComboboxMaster(this.cboFixStatus, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboSTATUS, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            cboSTATUS.Value = "";

            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MAINTRSORDTYPE");  //보전작업지시구분
            WIZ.Common.FillComboboxMaster(cboGubun, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            //콤보박스 시, 분 셋팅
            GetHour();
            GetMin();

            #endregion
        }
        #endregion  PP5201_Load

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



                grid1.DataSource = helper.FillTable("USP_PP5201_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("STATUS", sStatus, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MADESC", sMaDesc, DbType.String, ParameterDirection.Input)
                                                                    );


                grid1.DataBinds();

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
        //public override void DoSave()
        //{
        //    DataTable dt = grid1.chkChange();
        //    if (dt == null)
        //        return;
        //    DBHelper helper = new DBHelper("", true);

        //    grid1.PerformAction(UltraGridAction.DeactivateCell);

        //    try
        //    {
        //        if (this.ShowDialog("C:Q00009") == System.Windows.Forms.DialogResult.Cancel)
        //            return;

        //        base.DoSave();

        //        UltraGridUtil.DataRowDelete(this.grid1);
        //        this.grid1.UpdateData();
        //        //helper.Transaction = helper._sConn.BeginTransaction();

        //        foreach (DataRow drRow in dt.Rows)
        //        {
        //            if (drRow.RowState != DataRowState.Deleted)
        //            {
        //                if (drRow["PlantCode"].ToString().Trim() == "")
        //                {
        //                    grid1.SetRowError(drRow, "지시번호 error!");
        //                    continue;
        //                }
        //            }
        //            switch (drRow.RowState)
        //            {
        //                case DataRowState.Deleted:
        //                    break;
        //                case DataRowState.Added:
        //                    break;
        //                case DataRowState.Modified:
        //                    #region 수정
        //                    //param = new System.Data.Common.DbParameter[17];

        //                    helper.ExecuteNoneQuery("USP_PP5201_U1N", CommandType.StoredProcedure
        //                                            , helper.CreateParameter("PLANTCODE", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
        //                                            , helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input)            // WorkCenter코드
        //                                            , helper.CreateParameter("MachCode", drRow["MachCode"].ToString(), DbType.String, ParameterDirection.Input)            // 고장장(설)비코드 
        //                                            , helper.CreateParameter("StartDate", (drRow["StartDate"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(drRow["StartDate"]), DbType.DateTime, ParameterDirection.Input)          // 고장신고시작시간
        //                                            , helper.CreateParameter("FaultDate", (drRow["FaultDate"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(drRow["FaultDate"]), DbType.DateTime, ParameterDirection.Input)          // 고장발생일자 
        //                                            , helper.CreateParameter("EndDate", (drRow["EndDate"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(drRow["EndDate"]), DbType.DateTime, ParameterDirection.Input)          // 고장종료시간  
        //                                            , helper.CreateParameter("FaultCode", drRow["FaultCode"].ToString(), DbType.String, ParameterDirection.Input)            // 고장코드
        //                                            , helper.CreateParameter("WorkerCnt", drRow["WorkerCnt"].ToString(), DbType.String, ParameterDirection.Input)            // M/A작업인원
        //                                            , helper.CreateParameter("FaultType", drRow["FaultType"].ToString(), DbType.String, ParameterDirection.Input)            // 고장분류 (전기/기계)
        //                                            , helper.CreateParameter("ArrivalTime", (drRow["ArrivalTime"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(drRow["ArrivalTime"]), DbType.DateTime, ParameterDirection.Input)          // 보존작업자 도착 시간
        //                                            , helper.CreateParameter("@MAStartTime", (drRow["MAStartTime"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(drRow["MAStartTime"]), DbType.DateTime, ParameterDirection.Input)          // MA시작시간
        //                                            , helper.CreateParameter("@MAEndTime", (drRow["MAEndTime"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(drRow["MAEndTime"]), DbType.DateTime, ParameterDirection.Input)          // MA종료시간 
        //                                            , helper.CreateParameter("MADesc", drRow["MADesc"].ToString(), DbType.String, ParameterDirection.Input)            // MA내역
        //                                            , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)            // MA등록자 
        //                                            , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input));          // 비고

        //                    //param[15] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);                                                                        
        //                    //param[16] = helper.CreateParameter("RS_MSG",  DbType.String, ParameterDirection.Output, null, 200);                                                                      



        //                    //if (param[15].Value.ToString() == "E") throw new Exception(param[16].Value.ToString());                                                                                       

        //                    #endregion
        //                    break;
        //            }
        //            grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
        //        }
        //        grid1.SetAcceptChanges("PlantCode");
        //        helper.Commit();

        //    }
        //    catch (Exception ex)
        //    {
        //        helper.Rollback();
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        helper.Close();
        //    }
        //}
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

            txtFAULTTYPE.Text = grid1.ActiveRow.Cells["FAULTTYPE"].Value.ToString();
            txtREMARK.Text = grid1.ActiveRow.Cells["REMARK"].Value.ToString();

            cboSTATUS.Value = "";
            cboSTATUS.Value = grid1.ActiveRow.Cells["STATUS"].Value.ToString();

            txtWorkerId.Text = grid1.ActiveRow.Cells["EDITOR"].Value.ToString();
            txtWorkerName.Text = grid1.ActiveRow.Cells["WORKERNAME"].Value.ToString();
            txtMADESC.Text = grid1.ActiveRow.Cells["MADESC"].Value.ToString();

            string MaStartTime = grid1.ActiveRow.Cells["MASTARTTIME"].Value.ToString();
            string MaEndTime = grid1.ActiveRow.Cells["MAENDTIME"].Value.ToString();

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

            //작업대기로 변경
            if (Convert.ToString(cboSTATUS.Value) == "10")
            {
                ultraLabel1.Visible = true;
                cboENDYYMMDD.Visible = true;
                cboENDHOUR.Visible = true;
                cboENDMIN.Visible = true;
                sLabel13.Visible = true;
                sLabel6.Visible = true;

                //이전상태가 작업완료라면 변경 불가
                if (sStatus == "30")
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
            //작업중으로 변경
            if (Convert.ToString(cboSTATUS.Value) == "20")
            {
                //이전상태가 작업완료라면 변경 불가
                if (sStatus == "30")
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

                }
            }

            //작업완료으로 변경
            if (Convert.ToString(cboSTATUS.Value) == "30")
            {
                ultraLabel1.Visible = true;
                cboENDYYMMDD.Visible = true;
                cboENDHOUR.Visible = true;
                cboENDMIN.Visible = true;
                sLabel13.Visible = true;
                sLabel6.Visible = true;

                //이전상태가 작업완료라면 작업내용만 입력가능
                if (sStatus == "30")
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
                }
                else if (sStatus == "20")
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
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //작업대기면 모두 초기화
            if (Convert.ToString(cboSTATUS.Value) == "10")
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

            //작업중이면 작업자,작업내용 초기화
            if (Convert.ToString(cboSTATUS.Value) == "20")
            {
                txtWorkerId.Text = string.Empty;
                txtWorkerName.Text = string.Empty;
                txtMADESC.Text = string.Empty;
            }

            //작업완료면 작업내용 초기화
            if (Convert.ToString(cboSTATUS.Value) == "30")
            {
                txtMADESC.Text = string.Empty;
            }

        }

        //취소시
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            //이전의 상태
            string bStatus = grid1.ActiveRow.Cells["STATUS"].Value.ToString();

            //작업완료는 취소 불가
            if (bStatus == "30")
            {
                this.ShowDialog(Common.getLangText("작업완료 상태에서 작업 취소가 불가합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            string sPlantCode = "1100"; // 공장
            string sWorkerCenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sMachCode = Convert.ToString(grid1.ActiveRow.Cells["MACHCODE"].Value);
            string sMaintrsordno = Convert.ToString(grid1.ActiveRow.Cells["MAINTRSORDNO"].Value);

            DBHelper helper = new DBHelper("", true);
            //helper.Transaction = helper._sConn.BeginTransaction();
            try
            {
                //업데이트 내역 모두 초기화 및 작업대기 상태로 변경
                helper.ExecuteNoneQuery("USP_PP5201_U2N", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)  // 공장
                                    , helper.CreateParameter("WORKCENTERCODE", sWorkerCenterCode, DbType.String, ParameterDirection.Input)  // 작업장
                                    , helper.CreateParameter("MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)  // 고장장(설)비코드 
                                    , helper.CreateParameter("MAINTRSORDNO", sMaintrsordno, DbType.String, ParameterDirection.Input)  // 보전작업지시번호
                                    , helper.CreateParameter("EDITOR", WorkerID, DbType.String, ParameterDirection.Input)  // 수정자
                                    );

                //작업완료(30)인 경우 취소불가 
                if (helper.RSCODE == "O")
                {
                    helper.Rollback();
                    this.ShowDialog(Common.getLangText("작업완료인 경우 취소 불가합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    DoInquire();
                    return;
                }
                helper.Commit();
                this.ShowDialog(Common.getLangText("저장이 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                DoInquire();   // 재 조회


            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                DoInquire(); // 재 조회
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
            if (bStatus == "10" && aStatus == "10")
            {
                this.ShowDialog(Common.getLangText("작업대기 상태에서 작업대기 상태로 변경 불가합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업중에서 작업대기로는 변경 불가
            if (bStatus == "20" && aStatus == "10")
            {
                this.ShowDialog(Common.getLangText("작업중 상태에서 작업대기 상태로 변경 불가합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업완료에서 작업대기 또는 작업중으로 변경 불가
            if ((bStatus == "30" && aStatus == "10") || (bStatus == "30" && aStatus == "20"))
            {
                this.ShowDialog(Common.getLangText("작업완료 상태에서 이전상태로 변경 불가합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업완료인 경우 작업완료일시 필수입력
            if ((bStatus == "30" && cboENDYYMMDD.Value == null) || (bStatus == "30" && cboENDYYMMDD.Value == null) || (bStatus == "30" && cboENDYYMMDD.Value == null))
            {
                this.ShowDialog(Common.getLangText("작업완료 상태 저장시 작업완료일시는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
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
                this.ShowDialog(Common.getLangText("작업내용은 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
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

            //고장시작시간
            string sFailtime = Convert.ToString(grid1.ActiveRow.Cells["STARTTIME"].Value);

            //입력한 작업시작시간은 고장시작 시간보다 작을 수 없음
            if (Convert.ToDateTime(sTime) < Convert.ToDateTime(sFailtime))
            {
                this.ShowDialog(Common.getLangText("작업시작 시간은 고장시작 시간보다 작을 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //작업완료시 입력한 작업종료시간은 입력한 작업시작시간보다 작을 수 없음
            if (aStatus == "30" && Convert.ToDateTime(eTime) < Convert.ToDateTime(sTime))
            {
                this.ShowDialog(Common.getLangText("작업종료 시간은 작업시작 시간보다 작을 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            string sPlantCode = "1100"; // 공장
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
                helper.ExecuteNoneQuery("USP_PP5201_U1N", CommandType.StoredProcedure
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
                    this.ShowDialog(Common.getLangText("다른 사용자에 의해 작업상태가 이미 변경되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    DoInquire();
                    return;
                }
                helper.Commit();
                this.ShowDialog(Common.getLangText("저장이 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                DoInquire();   // 재 조회

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
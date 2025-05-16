#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM6500
//   Form Name    : 검사실적 후속조치등록
//   Name Space   : WIZ.BM
//   Created Date : 2015-12-02
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM6500 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();

        private string plantCode = string.Empty; //plantcode default 설정
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        #endregion

        #region < CONSTRUCTOR >

        public BM6500()
        {
            // bPopUp = true;
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { "", "" });
            btbManager.PopUpAdd(txtWorkCenterCode_H, txtWorkCenterName_H, "TBM0600Y", new object[] { cboPlantCode_H, "", "", "" });
            btbManager.PopUpAdd(txtWorkerID_B, txtWorkerNM_B, "TBM0200", new object[] { cboPlantCode_H, "", "", "", "" }); //작업자

        }
        #endregion

        #region BM6500_Load
        private void BM6500_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREPLNCODE", "검사계획번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREPLNDATE", "계획일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREPLNTYPE", "구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREFINFLAG", "검사완료여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREFINDATE", "검사완료일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MESSUREFINWORKER", "검사자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASURETOTJUD", "종합판정", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FUASTATUS", "조치상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FUASTARTIME", "조치시작일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FUAENDTIME", "조치종료일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "계획생성일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASUREPLNCODE", "검사계획번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASURECODE", "측정항목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASURENAME", "측정항목명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASUREVALUE", "측정값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "TOLVAL", "오차", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASUREJUD", "판정", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MDATE", "검사일시 ", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FUARESULT", "조치내역", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FUAWORKER", "조치자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FUAWORKERNM", "조치자명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FUATIME", "조치일시 ", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASUREPLNSEQ", "순번", false, GridColDataType_emu.VarChar, 40, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            #region 콤보박스 
            DataTable rtnDtTemp = new DataTable();
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");
            this.plantCode = CModule.GetAppSetting("Site", "10");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("USEFLAG");  // 사용유무, MES적용유무
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MEASUREFINFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MEASUREPLNTYPE");  // 검사계획 구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MEASUREPLNTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("FUASTATUS");  // 조치상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FUASTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MEASURETOTJUD");  // 종합판정여부
            WIZ.Common.FillComboboxMaster(this.cboMEASURETOTJUDFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MEASURETOTJUD", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboMEASURETOTJUDFlag.Value = "NG";

            rtnDtTemp = _Common.GET_BM0000_CODE("ORDERCLOSE");  // 완료여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MEASUREFINFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //콤보박스 시, 분 셋팅
            GetHour();
            GetMin();


            // 초중종물 검사화면(mt0100y)에서 open시,
            if (this.Tag != null)
            {
                string words = this.Tag.ToString();
                this.txtWorkCenterName_H.Text = words;
                GetOPCode();
                DoInquire();
            }
            #endregion
        }
        #endregion BM6500_Load

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            if (grid2.Rows.Count == 0) return;

            //조치일시 필수입력
            if (cboSTARTYYMMDD.Value == null)
            {
                this.ShowDialog(Common.getLangText("저장시 조치일시는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //조치자 필수입력
            if (txtWorkerNM_B.Text == "")
            {
                this.ShowDialog(Common.getLangText("조치자는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //조치내역 필수입력
            if (txtFailureCont_B.Text == "")
            {
                this.ShowDialog(Common.getLangText("조치내역은 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //입력한 후속조치시간
            DateTime sDate = Convert.ToDateTime(cboSTARTYYMMDD.Value);
            string sDay = sDate.ToString("yyyy") + "-" + sDate.ToString("MM") + "-" + sDate.ToString("dd");
            string sHour = Convert.ToString(cboSTARTHOUR.Value);
            string sMin = Convert.ToString(cboSTARTMIN.Value);
            string sTime = sDay + " " + sHour + ":" + sMin;

            string sPlantCode = plantCode; // 공장
            string sMEASUREPLNCODE = Convert.ToString(grid1.ActiveRow.Cells["MEASUREPLNCODE"].Value); //검사계획번호

            string sWorker = Convert.ToString(txtWorkerID_B.Text);                                    //조치자
            string sDesc = Convert.ToString(txtFailureCont_B.Text);                                   //조치내용
            string sMEASUREPLNSEQ = Convert.ToString(grid2.ActiveRow.Cells["MEASUREPLNSEQ"].Value);   //순번

            DateTime eTime = Convert.ToDateTime(this.grid1.ActiveRow.Cells["MEASUREFINDATE"].Value.ToString());
            //후속조치시간은 검사완료시간보다 이전 일 수 없습니다.
            if (Convert.ToDateTime(sTime) < Convert.ToDateTime(eTime))
            {
                this.ShowDialog(Common.getLangText("후속조치시간은 검사완료시간보다 이전 일 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }


            if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("USP_BM6500_U1N", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)         // 공장
                                    , helper.CreateParameter("MEASUREPLNCODE", sMEASUREPLNCODE, DbType.String, ParameterDirection.Input)    // 검사계획번호
                                    , helper.CreateParameter("FUATIME", sTime, DbType.DateTime, ParameterDirection.Input)            // 조치시작시간
                                    , helper.CreateParameter("FUAWORKER", sWorker, DbType.String, ParameterDirection.Input)            // 조치자
                                    , helper.CreateParameter("FUARESULT", sDesc, DbType.String, ParameterDirection.Input)              // 조치내역
                                    , helper.CreateParameter("EDITOR", WorkerID, DbType.String, ParameterDirection.Input)           // 수정자
                                    , helper.CreateParameter("MEASUREPLNSEQ", sMEASUREPLNSEQ, DbType.String, ParameterDirection.Input)     // 수정자
                                    );

                string sChk = Convert.ToString(this.grid1.ActiveRow.Cells["MEASUREPLNCODE"].Value);

                //이미 조치완료된 경우 저장여부 묻기
                if (helper.RSCODE == "O")
                {
                    if (MessageBox.Show(Common.getLangText("이미 조치가 완료되었습니다.\r\n그래도 수정 하시겠습니까?", "MSG"),
                                        "저장여부체크",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.No)
                    {
                        helper.Rollback();

                        //선택한 행 설정
                        DoInquire();
                        for (int i = 0; i < this.grid1.Rows.Count; i++)
                        {
                            if (Convert.ToString(this.grid1.Rows[i].Cells["MEASUREPLNCODE"].Value) == sChk)
                            {
                                this.grid1.Rows[i].Activated = true;
                                break;
                            }
                        }

                        return;
                    }

                }

                helper.Commit();
                this.ShowDialog(Common.getLangText("저장이 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                //선택한 행 설정
                DoInquire();
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(this.grid1.Rows[i].Cells["MEASUREPLNCODE"].Value) == sChk)
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

        #region <TOOL BAR AREA >

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            if (grid2.Rows.Count == 0) return;

            string sPlantCode = plantCode; // 공장
            string sMEASUREPLNCODE = Convert.ToString(grid1.ActiveRow.Cells["MEASUREPLNCODE"].Value); //검사계획번호
            string sMEASUREPLNSEQ = Convert.ToString(grid2.ActiveRow.Cells["MEASUREPLNSEQ"].Value);    //순번

            //조치시작 초기화
            string sDay = DateTime.Now.ToString("yyyy-MM-dd");
            string sHour = Convert.ToString("00");
            string sMin = Convert.ToString("00");
            string sTime = sDay + " " + sHour + ":" + sMin;

            string sWorker = "";                                    //조치자
            string sDesc = "";                                   //조치내용

            if (this.ShowDialog(Common.getLangText("선택한 조치내역을 취소하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("USP_BM6500_U2N", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)    // 공장
                                    , helper.CreateParameter("MEASUREPLNCODE", sMEASUREPLNCODE, DbType.String, ParameterDirection.Input)    // 검사계획번호
                                    , helper.CreateParameter("FUATIME", sTime, DbType.DateTime, ParameterDirection.Input)  // 조치시작시간
                                    , helper.CreateParameter("FUAWORKER", sWorker, DbType.String, ParameterDirection.Input)    // 조치자
                                    , helper.CreateParameter("FUARESULT", sDesc, DbType.String, ParameterDirection.Input)    // 조치내역
                                    , helper.CreateParameter("EDITOR", WorkerID, DbType.String, ParameterDirection.Input)    // 수정자
                                    , helper.CreateParameter("MEASUREPLNSEQ", sMEASUREPLNSEQ, DbType.String, ParameterDirection.Input)    // 수정자
                                    );

                helper.Commit();
                this.ShowDialog(Common.getLangText("취소가 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                //선택한 행 설정
                string sChk = Convert.ToString(this.grid1.ActiveRow.Cells["MEASUREPLNCODE"].Value);
                DoInquire();
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(this.grid1.Rows[i].Cells["MEASUREPLNCODE"].Value) == sChk)
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

        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string WORKCENTERCODE = txtWorkCenterCode_H.Text.Trim();
                string ITEMCODE = txtItemCode_H.Text.Trim();
                string ORDERNO = txtORDERNO.Text.Trim();        // 작업지시번호
                string MEASUREPLNCODE = txtMEASUREPLNCODE.Text.Trim(); // 검사계획번호
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_date.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_dateto.Value);
                string sFInFlag = Convert.ToString(cboMEASURETOTJUDFlag.Value);


                rtnDtTemp = helper.FillTable("USP_BM6500_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("WORKCENTERCODE", WORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ORDERNO", ORDERNO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MEASUREPLNCODE", MEASUREPLNCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("sStartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("sEndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("sFInFlag", sFInFlag, DbType.String, ParameterDirection.Input)
                                                            );

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();

                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        if (grid1.Rows[i].Cells["MEASURETOTJUD"].Value.ToString() == "NG")
                        {
                            grid1.Rows[i].Cells["MEASURETOTJUD"].Appearance.BackColor = Color.Red;
                        }
                    }
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    _GridUtil.Grid_Clear(grid2);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }


            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string MEASUREPLNCODE = grid1.ActiveRow.Cells["MEASUREPLNCODE"].Value.ToString();


                rtnDtTemp = helper.FillTable("USP_BM6500_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MEASUREPLNCODE", MEASUREPLNCODE, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds();

                    for (int i = 0; i < grid2.Rows.Count; i++)
                    {
                        if (grid2.Rows[i].Cells["MEASUREJUD"].Value.ToString() == "NG")
                        {
                            grid2.Rows[i].Cells["MEASUREJUD"].Appearance.BackColor = Color.Red;
                        }
                        grid2.Rows[i].Cells["MEASUREVALUE"].Appearance.BackColor = Color.Yellow;
                    }
                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);

                    //조치내역 초기화
                    cboSTARTYYMMDD.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    cboSTARTHOUR.Value = "00";
                    cboSTARTMIN.Value = "00";
                    txtWorkerID_B.Text = "";
                    txtWorkerNM_B.Text = "";
                    txtFailureCont_B.Text = "";
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void grid2_ClickCell(object sender, EventArgs e)
        {
            if (grid2.Rows.Count == 0) return;


            txtWorkerID_B.Text = grid2.ActiveRow.Cells["FUAWORKER"].Value.ToString();                      // 조치자
            txtWorkerNM_B.Text = grid2.ActiveRow.Cells["FUAWORKERNM"].Value.ToString();                      // 조치자명
            txtFailureCont_B.Text = grid2.ActiveRow.Cells["FUARESULT"].Value.ToString();                   // 조치내역

            string WorkTime = grid2.ActiveRow.Cells["FUATIME"].Value.ToString();                     // 조치일시
            //조치일시 셋팅
            if (WorkTime != "")
            {
                DateTime sTime = Convert.ToDateTime(WorkTime);
                cboSTARTYYMMDD.Value = sTime.ToString("yyyy") + "-" + sTime.ToString("MM") + "-" + sTime.ToString("dd");
                cboSTARTHOUR.Value = sTime.ToString("HH");
                cboSTARTMIN.Value = sTime.ToString("mm");
            }
            //조치일시 초기화
            else
            {
                cboSTARTYYMMDD.Value = DateTime.Now.ToString("yyyy-MM-dd");
                cboSTARTHOUR.Value = "00";
                cboSTARTMIN.Value = "00";
            }

        }

        /// 작업장 코드 조회
        /// </summary>
        private void GetOPCode()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sWORKCENTERCODE = string.Empty;
                string sWORKCENTERNAME = this.Tag.ToString();

                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT WORKCENTERCODE               AS WORKCENTERCODE ");
                command.AppendLine("  FROM TBM0600Y                                       ");
                command.AppendLine(" WHERE PLANTCODE LIKE '" + sPlantCode + "' + '%'      ");
                command.AppendLine("   AND WORKCENTERNAME LIKE '" + sWORKCENTERNAME + "' + '%'      ");
                command.AppendLine("   AND USEFLAG = 'Y'                                  ");
                command.AppendLine(" ORDER BY OPCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                sWORKCENTERCODE = dttemp.Rows[0]["WORKCENTERCODE"].ToString();
                txtWorkCenterCode_H.Text = sWORKCENTERCODE;
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


    }
}


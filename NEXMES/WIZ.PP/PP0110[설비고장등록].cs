#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0110
//   Form Name    : 고장실적등록
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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.PP
{
    public partial class PP0110 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable rtnDtTemp = new DataTable();

        private int ImageNumber = 0;       // 가져올 이미지의 순번
        private int Imageseq = 0;       // 가져온 이미지의 순번
        private int ImageCount = 0;       // 설비의 총 이미지 수
        #endregion

        #region < CONSTRUCTOR >

        public PP0110()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();

            this.plantCode = CModule.GetAppSetting("Site", "10");

            btbManager.PopUpAdd(txt_MACHCODE_H, txt_MACHNAME_H, "BM0070", new object[] { cbo_PLANTCODE_H, "", "", "" });         // 설비
            btbManager.PopUpAdd(txt_MACHTYPE_H, txt_MACHTYPENAME_H, "BM0071", new object[] { cbo_PLANTCODE_H, "", "", "" });         // 설비구분
            btbManager.PopUpAdd(txt_WORKCENTERCODE_B, txt_WORKCENTERNAME_B, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" }); // 작업장
            btbManager.PopUpAdd(txt_WORKERID_B, txt_WORKERNAME_B, "BM0020", new object[] { cbo_PLANTCODE_H, "", "", "", "" });     // 작업자

        }
        #endregion

        #region < FORM LOAD >
        private void PP0110_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHTYPE", "설비구분", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHSTATUS", "설비상태", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHTYPENAME", "설비구분명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKECOMPANY", "제조사", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MODELNAME", "모델명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SERIALNO", "시리얼번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CONTACT", "연락처", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LIFETIME", "수명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWORKER1", "설비담당자1", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWORKER2", "설비담당자2", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TECHWORKER", "설비기술\r\n담당자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPLASTDATE", "최종검사일시", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCYCLE", "점검주기", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CAVITY", "CAVITY", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region < COMBOBOX SETTING >
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("FAILURETYPE");
            WIZ.Common.FillComboboxMaster(this.cbo_FAULTTYPE_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            //cbo_FAULTTYPE_B.Value = "10";


            //rtnDtTemp = _Common.GET_BM0170_CODE(DBHelper.nvlString(cbo_PLANTCODE_H.Value), "Y");
            //WIZ.Common.FillComboboxMaster(this.cbo_FAULTTYPE_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            //cbo_FAULTTYPE_B.Value = "10";

            rtnDtTemp = _Common.GET_BM0000_CODE("MACHTYPE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MACHTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //콤보박스 시, 분 셋팅

            GetHour();
            GetMin();

            cbo_PLANTCODE_H.Value = plantCode;

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            //설비정보 초기화
            cbo_PLANTCODE_B.Value = "";
            txt_MACHTYPE_B.Text = "";
            txt_MACHTYPENAME_B.Text = "";
            txt_MACHCODE_B.Text = "";
            txt_MACHNAME_B.Text = "";
            txt_MAKECOMPANY_B.Text = "";
            txt_MODELNAME_B.Text = "";
            txt_SERIALNO_B.Text = "";
            txt_CONTACT_B.Text = "";
            txt_LIFETIME_B.Text = "";
            txt_MAWORKER1_B.Text = "";
            txt_MAWORKER2_B.Text = "";
            txt_TECHWORKER_B.Text = "";
            txt_INSPCYCLE_B.Text = "";
            txt_CAVITY_B.Text = "";
            txt_LASTDATE_B.Text = "";

            //고장내역 초기화
            cbo_STARTYYMMDD_B.Value = DateTime.Now.ToString("yyyy-MM-dd");
            cbo_STARTHOUR_B.Value = DateTime.Now.Hour.ToString("00");
            cbo_STARTMIN_B.Value = DateTime.Now.Minute.ToString("00");

            txt_MAINTRSORDERNO_B.Text = "";
            txt_WORKERID_B.Text = "";
            txt_WORKERNAME_B.Text = "";
            txt_WORKCENTERCODE_B.Text = "";
            txt_WORKCENTERNAME_B.Text = "";
            txt_FAILURECONT_B.Text = "";

            //이미지
            this.ImageNumber = 0;      // 설비 이미지 호출 수 초기화
            ultraGroupBox2.Text = "설비 이미지";


            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);     //사업장
                string sMachType = txt_MACHTYPE_H.Text.Trim();                  //설비구분
                string sMachCode = txt_MACHCODE_H.Text.Trim();                  //설비코드

                rtnDtTemp = helper.FillTable("USP_PP0110_S1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHTYPE", sMachType, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHCODE", sMachCode, DbType.String, ParameterDirection.Input));

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
                this.ClosePrgFormNew();
            }
        }
        #endregion

        #region < EVENT AREA >
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            //설비정보
            cbo_PLANTCODE_B.Value = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
            txt_MACHTYPE_B.Text = grid1.ActiveRow.Cells["MACHTYPE"].Value.ToString();
            txt_MACHTYPENAME_B.Text = grid1.ActiveRow.Cells["MACHTYPENAME"].Value.ToString();
            txt_MACHCODE_B.Text = grid1.ActiveRow.Cells["MACHCODE"].Value.ToString();
            txt_MACHNAME_B.Text = grid1.ActiveRow.Cells["MACHNAME"].Value.ToString();
            txt_MAKECOMPANY_B.Text = grid1.ActiveRow.Cells["MAKECOMPANY"].Value.ToString();
            txt_MODELNAME_B.Text = grid1.ActiveRow.Cells["MODELNAME"].Value.ToString();
            txt_SERIALNO_B.Text = grid1.ActiveRow.Cells["SERIALNO"].Value.ToString();
            txt_CONTACT_B.Text = grid1.ActiveRow.Cells["CONTACT"].Value.ToString();
            txt_LIFETIME_B.Text = grid1.ActiveRow.Cells["LIFETIME"].Value.ToString();
            txt_MAWORKER1_B.Text = grid1.ActiveRow.Cells["MAWORKER1"].Value.ToString();
            txt_MAWORKER2_B.Text = grid1.ActiveRow.Cells["MAWORKER2"].Value.ToString();
            txt_TECHWORKER_B.Text = grid1.ActiveRow.Cells["TECHWORKER"].Value.ToString();
            txt_INSPCYCLE_B.Text = grid1.ActiveRow.Cells["INSPCYCLE"].Value.ToString();
            txt_CAVITY_B.Text = grid1.ActiveRow.Cells["CAVITY"].Value.ToString();
            txt_LASTDATE_B.Text = grid1.ActiveRow.Cells["INSPLASTDATE"].Value.ToString();

            //고장내역 초기화
            cbo_STARTYYMMDD_B.Value = DateTime.Now.ToString("yyyy-MM-dd");
            cbo_STARTHOUR_B.Value = DateTime.Now.Hour.ToString("00");
            cbo_STARTMIN_B.Value = DateTime.Now.Minute.ToString("00");

            txt_MAINTRSORDERNO_B.Text = "";
            txt_WORKERID_B.Text = "";
            txt_WORKERNAME_B.Text = "";
            txt_WORKCENTERCODE_B.Text = "";
            txt_WORKCENTERNAME_B.Text = "";
            txt_FAILURECONT_B.Text = "";

            //이미지
            this.ImageNumber = 0;
            // 설비 이미지 호출 수 초기화

            ultraGroupBox2.Text = "설비 이미지";
            // 이미지 표현 가장 첫 이미지 0
            //FindImage(0);
            FindImage(1);
        }

        private void btnImageNext_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0 || this.txt_MACHCODE_B.Text == "" || this.Imageseq == 0)
            {
                return;
            }
            //ImageNumber = ImageNumber - 1;
            //FindImage(ImageNumber);

            if (Imageseq == ImageCount)
                return;

            Imageseq += 1;
            FindImage(Imageseq);
        }

        private void btnImageBefor_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0 || this.txt_MACHCODE_B.Text == "" || this.Imageseq == 0)
            {
                return;
            }
            //ImageNumber = ImageNumber + 1;
            //FindImage(ImageNumber);

            if (Imageseq == 1)
                return;

            Imageseq -= 1;
            FindImage(Imageseq);
        }

        private void btnSAVE_B_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            //신고일시 필수입력
            if (cbo_STARTYYMMDD_B.Value == null)
            {
                this.ShowDialog(Common.getLangText("저장시 신고일시는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //신고자 필수입력
            if (txt_WORKERNAME_B.Text == "")
            {
                this.ShowDialog(Common.getLangText("신고자는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //고장내용 필수입력
            if (txt_FAILURECONT_B.Text == "")
            {
                this.ShowDialog(Common.getLangText("고장내용은 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //입력한 작업시작시간
            DateTime sDate = Convert.ToDateTime(cbo_STARTYYMMDD_B.Value);
            string sDay = sDate.ToString("yyyy") + "-" + sDate.ToString("MM") + "-" + sDate.ToString("dd");
            string sHour = Convert.ToString(cbo_STARTHOUR_B.Value);
            string sMin = Convert.ToString(cbo_STARTMIN_B.Value);
            string sTime = sDay + " " + sHour + ":" + sMin;

            string sPlantCode = plantCode;                                                    //사업장
            string sWorkerCenterCode = Convert.ToString(txt_WORKCENTERCODE_B.Text);                  //작업장
            string sMachCode = Convert.ToString(grid1.ActiveRow.Cells["MACHCODE"].Value);    //설비
            string sWorker = Convert.ToString(txt_WORKERID_B.Text);                        //신고자
            string sDesc = Convert.ToString(txt_FAILURECONT_B.Text);                     //신고내용
            string sFaulType = Convert.ToString(cbo_FAULTTYPE_B.Value);                      //고장분류


            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("USP_PP0110_I1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)    // 공장
                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkerCenterCode, DbType.String, ParameterDirection.Input)    // 작업장
                                    , helper.CreateParameter("AS_MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)    // 고장장(설)비코드 
                                    , helper.CreateParameter("AS_STARTDATE", sTime, DbType.DateTime, ParameterDirection.Input)  // 작업시작시간
                                    , helper.CreateParameter("AS_FAULTTYPE", sFaulType, DbType.String, ParameterDirection.Input)    // 고장분류
                                    , helper.CreateParameter("AS_FAULTWORKER", sWorker, DbType.String, ParameterDirection.Input)    // 신고자
                                    , helper.CreateParameter("AS_REMARK", sDesc, DbType.String, ParameterDirection.Input)    // 고장내역
                                    , helper.CreateParameter("AS_MAKER", WorkerID, DbType.String, ParameterDirection.Input)    // 만든이
                                    , helper.CreateParameter("AS_MAORDERNO", DbType.String, ParameterDirection.Output, '0', 15));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();

                    //보전작업지시번호 표시
                    txt_MAINTRSORDERNO_B.Text = helper.Parameters[8].Value.ToString();

                    this.ShowDialog(Common.getLangText("저장이 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    return;
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

        private void btnRESET_B_Click(object sender, EventArgs e)
        {
            //고장내역 초기화
            cbo_STARTYYMMDD_B.Value = DateTime.Now.ToString("yyyy-MM-dd");
            cbo_STARTHOUR_B.Value = DateTime.Now.Hour.ToString("00");
            cbo_STARTMIN_B.Value = DateTime.Now.Minute.ToString("00");

            txt_MAINTRSORDERNO_B.Text = "";
            txt_WORKERID_B.Text = "";
            txt_WORKERNAME_B.Text = "";
            txt_WORKCENTERCODE_B.Text = "";
            txt_WORKCENTERNAME_B.Text = "";
            txt_FAILURECONT_B.Text = "";

        }

        #endregion

        #region < USER METHOD AREA >
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

                WIZ.Common.FillComboboxMaster(cbo_STARTMIN_B, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, null);
                cbo_STARTMIN_B.Value = DateTime.Now.Minute.ToString("00");
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

        // 이미지 호출
        private void FindImage(int ImageSeq)
        {
            DBHelper helper = new DBHelper("", false);
            try
            {
                // 이미지 호출
                DataTable DtPlant = helper.FillTable("USP_PP0110_S2", CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_NUMBER", ImageSeq, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MACHCODE", this.grid1.ActiveRow.Cells["MACHCODE"].Value.ToString(), DbType.String, ParameterDirection.Input));

                if (DtPlant.Rows.Count > 0 && DtPlant.Rows[0]["MACHIMG"].ToString() != string.Empty)
                {
                    byte[] bImage = null;
                    bImage = (byte[])DtPlant.Rows[0]["MACHIMG"];
                    if (bImage != null)
                        pictureBox1.Image = new Bitmap(new MemoryStream(bImage));
                    pictureBox1.BringToFront();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Imageseq = Convert.ToInt32(DtPlant.Rows[0]["MACHSEQ"]);
                    this.ImageCount = Convert.ToInt32(DtPlant.Rows[0]["LICOUNT"]);

                }
                else
                {
                    this.Imageseq = 0;
                    this.ImageCount = 0;
                    this.pictureBox1.Image = null;
                }
                ultraGroupBox2.Text = "설비 이미지     " + Imageseq + " / " + ImageCount;

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }

        #endregion
    }
}
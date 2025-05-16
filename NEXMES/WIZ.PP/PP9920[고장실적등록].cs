#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP9920
//   Form Name    : 고장실적등록
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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.PP
{


    public partial class PP9920 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>

        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        DataTable rtnDtTemp = new DataTable();

        private bool InitOpen = true;    // 최초 화면 OPEN 시 값 변경 여부 리턴 함수
        private bool BoolDoNew = false;   // 추가 시 값변경 여부 리턴함수 
        private int ImageNumber = 0;       // 가져올 이미지의 순번
        private int Imageseq = 0;       // 가져온 이미지의 순번
        private int ImageCount = 0;       // 설비의 총 이미지 수
        byte[] bImage = null;    // 이미지
        #endregion

        #region<CONSTRUCTOR>
        public PP9920()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();

            this.plantCode = CModule.GetAppSetting("Site", "10");

            btbManager.PopUpAdd(txtMachCode_H, txtMachName_H, "TBM0700", new object[] { "", "", "", "" }); //설비
            btbManager.PopUpAdd(txtMachType_H, txtMachTypeName_H, "TBM0701", new object[] { "", "", "", "" }); //설비구분
            btbManager.PopUpAdd(txtWorkcenterCode_B, txt_workerCenterName_B, "TBM0600Y", new object[] { cboPlantCode_H, "", "", "" }); //작업장
            btbManager.PopUpAdd(txtWorkerID_B, txtWorkerNM_B, "TBM0200", new object[] { cboPlantCode_H, "", "", "", "" }); //작업자

        }
        #endregion

        #region 폼 로더
        private void PP9920_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHTYPE", "설비구분", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHTYPENAME", "설비구분명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKECOMPANY", "제조사", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MODELNAME", "모델명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SERIALNO", "시리얼번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CONTACT", "연락처", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LIFETIME", "수명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWORKER1", "설비담당자(정)", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWORKER2", "설비담당자(부)", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TECHWORKER", "설비기술 담당자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPLASTDATE", "최종검사 일자", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCYCLE", "점검주기", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CAVITY", "CAVITY", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("USEFLAG");
            //WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("FAILURETYPE");
            WIZ.Common.FillComboboxMaster(this.cboFaulType_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            cboFaulType_B.Value = "10";

            //콤보박스 시, 분 셋팅
            GetHour();
            GetMin();

            cboPlantCode_H.Value = plantCode;

            #endregion
        }
        #endregion
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
                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                                     // 공장코드                                      
                string sMachType = txtMachType_H.Text.Trim();
                string sMachCode = txtMachCode_H.Text.Trim();
                //string sUseFlag  = Convert.ToString(cboUseFlag_H.Value);


                rtnDtTemp = helper.FillTable("USP_PP9920_S1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MACHTYPE", sMachType, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)
                                                    //, helper.CreateParameter("USEFLAG",   sUseFlag, DbType.String, ParameterDirection.Input)
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
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }
        #endregion

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            //설비정보
            cboPlantCode_B.Value = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
            txtMachType_B.Text = grid1.ActiveRow.Cells["MACHTYPE"].Value.ToString();
            txtMachTypeName_B.Text = grid1.ActiveRow.Cells["MACHTYPENAME"].Value.ToString();
            txtMachCode_B.Text = grid1.ActiveRow.Cells["MACHCODE"].Value.ToString();
            txtMachName_B.Text = grid1.ActiveRow.Cells["MACHNAME"].Value.ToString();
            txtMakeCompany_B.Text = grid1.ActiveRow.Cells["MAKECOMPANY"].Value.ToString();
            txtModelName_B.Text = grid1.ActiveRow.Cells["MODELNAME"].Value.ToString();
            txtSerialNo_B.Text = grid1.ActiveRow.Cells["SERIALNO"].Value.ToString();
            txtContact_B.Text = grid1.ActiveRow.Cells["CONTACT"].Value.ToString();
            txtLifeTime_B.Text = grid1.ActiveRow.Cells["LIFETIME"].Value.ToString();
            txtMaworker1_B.Text = grid1.ActiveRow.Cells["MAWORKER1"].Value.ToString();
            txtMaworker2_B.Text = grid1.ActiveRow.Cells["MAWORKER2"].Value.ToString();
            txtTechWorker_B.Text = grid1.ActiveRow.Cells["TECHWORKER"].Value.ToString();
            txtInspCycle_B.Text = grid1.ActiveRow.Cells["INSPCYCLE"].Value.ToString();
            txtCavity_B.Text = grid1.ActiveRow.Cells["CAVITY"].Value.ToString();
            txtIpLastDate_B.Text = grid1.ActiveRow.Cells["INSPLASTDATE"].Value.ToString();

            //고장내역 초기화
            cboSTARTYYMMDD.Value = DateTime.Now.ToString("yyyy-MM-dd");
            cboSTARTHOUR.Value = "00";
            cboSTARTMIN.Value = "00";

            txtMaintrSorderNo_B.Text = "";
            txtWorkerID_B.Text = "";
            txtWorkerNM_B.Text = "";
            txtWorkcenterCode_B.Text = "";
            txt_workerCenterName_B.Text = "";
            //cboFaulType_B.Text          = "";
            txtFailureCont_B.Text = "";

            //이미지
            this.ImageNumber = 0;      // 설비 이미지 호출 수 초기화
            ultraGroupBox2.Text = "설비 이미지";
            // 이미지 표현 가장 첫 이미지 0
            FindImage(0);
        }


        // 이미지 호출
        private void FindImage(int ImageSeq)
        {
            DBHelper helper = new DBHelper("", false);
            try
            {
                // 이미지 호출
                DataTable DtPlant = helper.FillTable("USP_PP9920_S2N", CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_NUMBER", ImageSeq, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MACHCODE", this.grid1.ActiveRow.Cells["MACHCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                     );
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            //신고일시 필수입력
            if (cboSTARTYYMMDD.Value == null)
            {
                this.ShowDialog(Common.getLangText("저장시 신고일시는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //신고자 필수입력
            if (txtWorkerNM_B.Text == "")
            {
                this.ShowDialog(Common.getLangText("신고자는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //고장내용 필수입력
            if (txtFailureCont_B.Text == "")
            {
                this.ShowDialog(Common.getLangText("고장내용은 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //입력한 작업시작시간
            DateTime sDate = Convert.ToDateTime(cboSTARTYYMMDD.Value);
            string sDay = sDate.ToString("yyyy") + "-" + sDate.ToString("MM") + "-" + sDate.ToString("dd");
            string sHour = Convert.ToString(cboSTARTHOUR.Value);
            string sMin = Convert.ToString(cboSTARTMIN.Value);
            string sTime = sDay + " " + sHour + ":" + sMin;

            string sPlantCode = plantCode; // 공장
            string sWorkerCenterCode = Convert.ToString(txtWorkcenterCode_B.Text);                //작업장
            string sMachCode = Convert.ToString(grid1.ActiveRow.Cells["MACHCODE"].Value);         //설비
            string sWorker = Convert.ToString(txtWorkerID_B.Text);                                //신고자
            string sDesc = Convert.ToString(txtFailureCont_B.Text);                               //신고내용
            string sFaulType = Convert.ToString(cboFaulType_B.Value);                             //고장분류


            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("USP_PP9920_I1N", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)    // 공장
                                    , helper.CreateParameter("WORKCENTERCODE", sWorkerCenterCode, DbType.String, ParameterDirection.Input)    // 작업장
                                    , helper.CreateParameter("MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)    // 고장장(설)비코드 
                                    , helper.CreateParameter("FAULTSTARTDATE", sTime, DbType.DateTime, ParameterDirection.Input)  // 작업시작시간
                                    , helper.CreateParameter("FAULTTYPE", sFaulType, DbType.String, ParameterDirection.Input)    // 고장분류
                                    , helper.CreateParameter("FAUILWORKID", sWorker, DbType.String, ParameterDirection.Input)    // 신고자
                                    , helper.CreateParameter("REMARK", sDesc, DbType.String, ParameterDirection.Input)    // 고장내역
                                    , helper.CreateParameter("MAKER", WorkerID, DbType.String, ParameterDirection.Input)    // 만든이
                                    , helper.CreateParameter("MAINTRSORDNO", DbType.String, ParameterDirection.Output, '0', 9)
                                    );

                helper.Commit();

                //보전작업지시번호 표시
                txtMaintrSorderNo_B.Text = helper.Parameters[8].Value.ToString();

                this.ShowDialog(Common.getLangText("저장이 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                //DoInquire();   // 재 조회

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //고장내역 초기화
            cboSTARTYYMMDD.Value = DateTime.Now.ToString("yyyy-MM-dd");
            cboSTARTHOUR.Value = "00";
            cboSTARTMIN.Value = "00";

            txtMaintrSorderNo_B.Text = "";
            txtWorkerID_B.Text = "";
            txtWorkerNM_B.Text = "";
            txtWorkcenterCode_B.Text = "";
            txt_workerCenterName_B.Text = "";
            txtFailureCont_B.Text = "";

        }

        private void btnImageNext_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0 || this.txtMachCode_B.Text == "" || this.Imageseq == 0)
            {
                return;
            }
            ImageNumber = ImageNumber - 1;
            FindImage(ImageNumber);
        }

        private void btnImageBefor_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0 || this.txtMachCode_B.Text == "" || this.Imageseq == 0)
            {
                return;
            }
            ImageNumber = ImageNumber + 1;
            FindImage(ImageNumber);
        }
    }
}
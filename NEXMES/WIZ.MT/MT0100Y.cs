#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  MT0100Y
//   Form Name    : 작업장별 불량현황 정보 조회
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
using System.Reflection;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MT
{
    public partial class MT0100Y : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        PopUp_Biz _biz = new PopUp_Biz();//비지니스 로직 객체 생성
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        DataTable RtTemp = new DataTable();
        private int NextBefore = 0;       // 다음 장 구분을 위한 카운트 ( 다음 : +1 , 이전 : -1 , 1분뒤 : +1)

        bool sMode = true;                              //True:Auto, False:Manual
        bool bStop = false;                             //모니터링 Timer STOP Flag
        Timer _timer;                                   //모니터링 조회 Timer
        #endregion

        #region < CONSTRUCTOR >
        public MT0100Y()
        {
            InitializeComponent();
        }
        #endregion

        private void MT0100Y_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            DoInquire();          // 데이터 테이블 조회
            SetLabelControl();    // 값 셋팅

            //_timer.Start();       // 작업장 실적 타이버 시작
            bStop = false;

            if (_timer == null)
            {
                _timer = new Timer();
                _timer.Tick += new EventHandler(_timer_Tick);
                _timer.Interval = Convert.ToInt32(nupSearchTime.Value) * 1000;
            }

            _timer.Enabled = true;

            lblTabPage.Text = Convert.ToString(NextBefore + 1) + " / " + Convert.ToString(Math.Ceiling(RtTemp.Rows.Count / 9d));
            #endregion
        }

        /// <summary>
        /// 페이지 카운트에 따른 라벨 컨트롤 값 등록
        /// </summary>
        private void SetLabelControl()
        {
            Label[] Workname = new Label[] { txtWorkName1, txtWorkName2, txtWorkName3, txtWorkName4, txtWorkName5, txtWorkName6, txtWorkName7, txtWorkName8, txtWorkName9 };
            Label[] PlnCount = new Label[] { txtPlan1, txtPlan2, txtPlan3, txtPlan4, txtPlan5, txtPlan6, txtPlan7, txtPlan8, txtPlan9 };
            Label[] InputCount = new Label[] { txtInput1, txtInput2, txtInput3, txtInput4, txtInput5, txtInput6, txtInput7, txtInput8, txtInput9 };
            Label[] Status = new Label[] { txtStatus1, txtStatus2, txtStatus3, txtStatus4, txtStatus5, txtStatus6, txtStatus7, txtStatus8, txtStatus9 };
            Label[] NGCount = new Label[] { txtNgCount1, txtNgCount2, txtNgCount3, txtNgCount4, txtNgCount5, txtNgCount6, txtNgCount7, txtNgCount8, txtNgCount9 };
            Label[] FUACount = new Label[] { lblFua1, lblFua2, lblFua3, lblFua4, lblFua5, lblFua6, lblFua7, lblFua8, lblFua9 };
            // 라벨 클리어
            for (int i = 0; i < 9; i++)
            {
                Workname[i].Text = "";
                PlnCount[i].Text = "";
                InputCount[i].Text = "";
                NGCount[i].Text = "";
                FUACount[i].Text = "";
                FUACount[i].BackColor = Color.White;
                Status[i].BackColor = Color.White;
            }
            if (RtTemp.Rows.Count > 0)
            {
                // 첫페이지 보다 모자란 데이터 조회 시 무조건 첫 페이지 
                if (RtTemp.Rows.Count < 10) NextBefore = 0;
                if (NextBefore == 0)
                {
                    // 첫 페이지 내용 표현
                    for (int i = 0; i < RtTemp.Rows.Count; i++)
                    {
                        if (i == 9) break;
                        Workname[i].Text = RtTemp.Rows[i]["WORKCENTERNAME"].ToString();
                        PlnCount[i].Text = RtTemp.Rows[i]["PLNCOUNT"].ToString();
                        InputCount[i].Text = RtTemp.Rows[i]["INPUTCOUNT"].ToString();
                        NGCount[i].Text = RtTemp.Rows[i]["NGCOUNT"].ToString();
                        FUACount[i].Text = RtTemp.Rows[i]["FAUCOUNT"].ToString();

                        if (Convert.ToInt32(RtTemp.Rows[i]["PLNCOUNT"]) == Convert.ToInt32(RtTemp.Rows[i]["INPUTCOUNT"]))
                            Status[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(195)))), ((int)(((byte)(37)))));
                        else if (Convert.ToInt32(RtTemp.Rows[i]["PLNCOUNT"]) - Convert.ToInt32(RtTemp.Rows[i]["INPUTCOUNT"]) > 1)
                            Status[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
                        else if (Convert.ToInt32(RtTemp.Rows[i]["PLNCOUNT"]) - Convert.ToInt32(RtTemp.Rows[i]["INPUTCOUNT"]) == 1)
                            Status[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(191)))), ((int)(((byte)(1)))));

                        if (Convert.ToInt32(RtTemp.Rows[i]["NGCOUNT"]) == Convert.ToInt32(RtTemp.Rows[i]["FAUCOUNT"]))
                            FUACount[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(195)))), ((int)(((byte)(37)))));
                        else if (Convert.ToInt32(RtTemp.Rows[i]["NGCOUNT"]) - Convert.ToInt32(RtTemp.Rows[i]["FAUCOUNT"]) > 1)
                            FUACount[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
                        else if (Convert.ToInt32(RtTemp.Rows[i]["NGCOUNT"]) - Convert.ToInt32(RtTemp.Rows[i]["FAUCOUNT"]) == 1)
                            FUACount[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(191)))), ((int)(((byte)(1)))));
                    }
                }
                else
                {
                    // 첫 페이지 이후 데이터 표현
                    for (int i = NextBefore * 9; i < RtTemp.Rows.Count; i++)
                    {
                        if (i == (NextBefore + 1) * 9) break;
                        Workname[i - NextBefore * 9].Text = RtTemp.Rows[i]["WORKCENTERNAME"].ToString();
                        PlnCount[i - NextBefore * 9].Text = RtTemp.Rows[i]["PLNCOUNT"].ToString();
                        InputCount[i - NextBefore * 9].Text = RtTemp.Rows[i]["INPUTCOUNT"].ToString();
                        NGCount[i - NextBefore * 9].Text = RtTemp.Rows[i]["NGCOUNT"].ToString();
                        FUACount[i - NextBefore * 9].Text = RtTemp.Rows[i]["FAUCOUNT"].ToString();

                        if (Convert.ToInt32(RtTemp.Rows[i]["PLNCOUNT"]) == Convert.ToInt32(RtTemp.Rows[i]["INPUTCOUNT"]))
                            Status[i - NextBefore * 9].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(195)))), ((int)(((byte)(37)))));
                        else if (Convert.ToInt32(RtTemp.Rows[i]["PLNCOUNT"]) - Convert.ToInt32(RtTemp.Rows[i]["INPUTCOUNT"]) > 1)
                            Status[i - NextBefore * 9].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
                        else if (Convert.ToInt32(RtTemp.Rows[i]["PLNCOUNT"]) - Convert.ToInt32(RtTemp.Rows[i]["INPUTCOUNT"]) == 1)
                            Status[i - NextBefore * 9].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(191)))), ((int)(((byte)(1)))));

                        if (Convert.ToInt32(RtTemp.Rows[i]["NGCOUNT"]) == Convert.ToInt32(RtTemp.Rows[i]["FAUCOUNT"]))
                            FUACount[i - NextBefore * 9].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(195)))), ((int)(((byte)(37)))));
                        else if (Convert.ToInt32(RtTemp.Rows[i]["NGCOUNT"]) - Convert.ToInt32(RtTemp.Rows[i]["FAUCOUNT"]) > 1)
                            FUACount[i - NextBefore * 9].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
                        else if (Convert.ToInt32(RtTemp.Rows[i]["NGCOUNT"]) - Convert.ToInt32(RtTemp.Rows[i]["FAUCOUNT"]) == 1)
                            FUACount[i - NextBefore * 9].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(191)))), ((int)(((byte)(1)))));
                    }
                }
            }
            // 현재 페이지 / 최대 페이지 표현
            lblTabPage.Text = Convert.ToString(NextBefore + 1) + " / " + Convert.ToString(Math.Ceiling(RtTemp.Rows.Count / 9d));
        }


        /// <summary>
        /// 작업장 실적 데이터 테이블 생성
        /// </summary>
        private void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {

                string sPlantCode = CModule.GetAppSetting("Site", "10");
                RtTemp = helper.FillTable("USP_MT0100Y_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

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

        /// <summary>
        /// 폼이 종료 되었을 경우 타이머 종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MT0100Y_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Stop();
            _timer.Dispose();
        }

        /// <summary>
        /// 실적 수집 타이머 틱 (1분) -> 입력 가능하도록 변경 2015-12-23 최재형
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            DoInquire();

            // 다음 페이지 자동 이동을 위한 카운트 증가
            if ((NextBefore + 1) * 9 >= RtTemp.Rows.Count) NextBefore = 0; // 최대 페이지 표현시 첫페이지로 이동
            else NextBefore = NextBefore + 1;

            SetLabelControl();
            _timer.Start();
        }

        // 다음 버튼 클릭시 
        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (RtTemp.Rows.Count == 0) return;
            if ((NextBefore + 1) * 9 >= RtTemp.Rows.Count) NextBefore = 0;
            else NextBefore = NextBefore + 1;
            SetLabelControl();
        }

        // 이전 버튼 클릭시
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (RtTemp.Rows.Count == 0) return;
            if (NextBefore == 0) NextBefore = Convert.ToInt32(Math.Ceiling(RtTemp.Rows.Count / 9d) - 1);
            else NextBefore = NextBefore - 1;
            SetLabelControl();
        }

        //진행 현황, 조치건수 선택시 화면전환 2015-12-23 서보경 추가
        private void txtStatus1_DoubleClick(object sender, EventArgs e)
        {
            // 진행현황, 조치건수 라벨 이름 
            string name = ((System.Windows.Forms.Label)sender).Name;

            // 몇번째 진행현황/ 조치건수
            int namelen = name.Length;
            int num = Convert.ToInt32(name.Substring(namelen - 1, 1));

            // 작업장 이름
            Label[] Workname = new Label[] { txtWorkName1, txtWorkName2, txtWorkName3, txtWorkName4, txtWorkName5, txtWorkName6, txtWorkName7, txtWorkName8, txtWorkName9 };

            //더블클릭한 작업장 
            string wname = Workname[num - 1].Text;

            //진행현황 클릭시
            if (name.Substring(3, 1) == "S")
            {

                // 새로 open할 화면 정보
                string sFileID = "WIZ.AP.DLL";
                string sNameSpace = "WIZ.AP";

                //자주검사 계획별 실적조회 화면 open
                Assembly assembly = Assembly.LoadFrom(Application.StartupPath + @"\" + sFileID);
                Type typeForm = assembly.GetType(sNameSpace + '.' + "AP1000", true);
                Form newForm = (Form)Activator.CreateInstance(typeForm);

                newForm.MdiParent = this.MdiParent;
                ((WIZ.Forms.BaseForm)newForm).WorkerID = this.WorkerID;
                ((WIZ.Forms.BaseForm)newForm).Lang = this.Lang;
                ((WIZ.Forms.BaseForm)newForm).IP = this.IP;

                newForm.Text = "자주검사 계획별 실적조회";

                // 더블클릭한 row의 작업장 정보 tag
                newForm.Tag = wname;
                newForm.Show();
            }

            //조치 건수 클릭시
            else if (name.Substring(3, 1) == "F")
            {

                // 새로 open할 화면 정보
                string sFileID = "WIZ.BM.DLL";
                string sNameSpace = "WIZ.BM";

                //검사실적 후속조치등록 화면 open
                Assembly assembly = Assembly.LoadFrom(Application.StartupPath + @"\" + sFileID);
                Type typeForm = assembly.GetType(sNameSpace + '.' + "BM6500", true);
                Form newForm = (Form)Activator.CreateInstance(typeForm);

                newForm.MdiParent = this.MdiParent;
                ((WIZ.Forms.BaseForm)newForm).WorkerID = this.WorkerID;
                ((WIZ.Forms.BaseForm)newForm).Lang = this.Lang;
                ((WIZ.Forms.BaseForm)newForm).IP = this.IP;

                newForm.Text = "검사실적 후속조치등록";

                // 더블클릭한 row의 작업장 정보 tag
                newForm.Tag = wname;
                newForm.Show();
            }

            this.ClosePrgFormNew();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (rdbAuto.Checked == true)
            {
                if (_timer.Enabled == false)
                {
                    _timer.Enabled = true;
                }

                bStop = false;
                _timer.Interval = Convert.ToInt32(nupSearchTime.Value * 1000);

            }
            else
            {
                if (_timer.Enabled == true)
                {
                    bStop = true;
                    _timer.Enabled = false;
                }
            }
        }
    }
}


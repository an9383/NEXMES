using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Forms;

//using WIZ.PopUp.Biz;

namespace WIZ.MT
{
    #region<Member Area>
    public partial class MT0200 : BaseMDIChildForm
    {

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        //private DataTable DtChange = null;

        private int sRColorR = 0;
        private int sRColorG = 0;
        private int sRColorB = 0;

        private int sSColorR = 0;
        private int sSColorG = 0;
        private int sSColorB = 0;

        private int sCColorR = 0;
        private int sCColorG = 0;
        private int sCColorB = 0;



        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        DataTable CboDtTemp = new DataTable();


        public MT0200()
        {

            InitializeComponent();
        }
        #endregion

        #region  MT0200_Load
        private void MT0200_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅


            sMT1_RUN.Appearance.BackColor = Color.White;
            sMT1_STOP.Appearance.BackColor = Color.White;
            sMT2_RUN.Appearance.BackColor = Color.White;
            sMT2_STOP.Appearance.BackColor = Color.White;
            sMT3_RUN.Appearance.BackColor = Color.White;
            sMT3_STOP.Appearance.BackColor = Color.White;

            sDAC1_RUN.Appearance.BackColor = Color.White;
            sDAC1_STOP.Appearance.BackColor = Color.White;
            sDAC2_RUN.Appearance.BackColor = Color.White;
            sDAC2_STOP.Appearance.BackColor = Color.White;
            sDAC3_RUN.Appearance.BackColor = Color.White;
            sDAC3_STOP.Appearance.BackColor = Color.White;

            rtnDtTemp = _Common.GET_BM0000_CODE("UTILITYSET");  //사업장


            Int32 stimer = 1000;
            timer1.Interval = stimer;
            timer1.Tick += new EventHandler(t_Tick);
            timer1.Start();
            if (rtnDtTemp.Rows.Count > 3)
            {
                sRColorR = Convert.ToInt32(rtnDtTemp.Rows[0]["RelCode1"]);
                sRColorG = Convert.ToInt32(rtnDtTemp.Rows[0]["RelCode2"]);
                sRColorB = Convert.ToInt32(rtnDtTemp.Rows[0]["RelCode3"]);

                sSColorR = Convert.ToInt32(rtnDtTemp.Rows[1]["RelCode1"]);
                sSColorG = Convert.ToInt32(rtnDtTemp.Rows[1]["RelCode2"]);
                sSColorB = Convert.ToInt32(rtnDtTemp.Rows[1]["RelCode3"]);

                sCColorR = Convert.ToInt32(rtnDtTemp.Rows[2]["RelCode1"]);
                sCColorG = Convert.ToInt32(rtnDtTemp.Rows[2]["RelCode2"]);
                sCColorB = Convert.ToInt32(rtnDtTemp.Rows[2]["RelCode3"]);

                stimer = Convert.ToInt32(rtnDtTemp.Rows[3]["RelCode1"]);

            }
            else
            {
                sRColorR = 0;
                sRColorG = 255;
                sRColorB = 0;

                sSColorR = 255;
                sSColorG = 0;
                sSColorB = 0;

                sCColorR = 255;
                sCColorG = 253;
                sCColorB = 25;


                stimer = 3000;
            }



            #endregion


        }
        #endregion MT0200_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {

        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {

        }
        #endregion

        #region<Event>
        private void MT0200_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;


                DBHelper helper = new DBHelper(false);



                try
                {
                    // base.DoInquire();
                    rtnDtTemp = helper.FillTable("USP_MT0200_S2", CommandType.StoredProcedure
                                                                 , helper.CreateParameter("TEST", DbType.Date, ParameterDirection.Output, null, 1));
                    //,helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1)
                    //,helper.CreateParameter("RS_MSG",  DbType.String, ParameterDirection.Output, null, 100));



                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        if (Convert.ToString(rtnDtTemp.Rows[0]["STATUS"]) == "R")
                        {
                            //sMT1_RUN.Appearance.BackColor = Color.FromArgb(
                            sMT1_RUN.Appearance.BackColor = Color.FromArgb(sRColorR, sRColorG, sRColorB);
                            sMT1_STOP.Appearance.BackColor = Color.White;
                        }

                        else
                        {
                            sMT1_RUN.Appearance.BackColor = Color.White;
                            sMT1_STOP.Appearance.BackColor = Color.FromArgb(sSColorR, sSColorG, sSColorB);
                        }

                    }
                    if (rtnDtTemp.Rows.Count > 1) //if (rtnDsTemp.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(rtnDtTemp.Rows[1]["STATUS"]) == "R")
                        {
                            //sMT1_RUN.Appearance.BackColor = Color.FromArgb(
                            sMT2_RUN.Appearance.BackColor = Color.FromArgb(sRColorR, sRColorG, sRColorB);
                            sMT2_STOP.Appearance.BackColor = Color.White;
                        }

                        else
                        {
                            sMT2_RUN.Appearance.BackColor = Color.White;
                            sMT2_STOP.Appearance.BackColor = Color.FromArgb(sSColorR, sSColorG, sSColorB);
                        }

                    }
                    if (rtnDtTemp.Rows.Count > 2)// if(rtnDsTemp.Tables[0].Rows.Count > 0 )
                    {
                        if (Convert.ToString(rtnDtTemp.Rows[2]["STATUS"]) == "R")
                        {
                            //sMT1_RUN.Appearance.BackColor = Color.FromArgb(
                            sMT3_RUN.Appearance.BackColor = Color.FromArgb(sRColorR, sRColorG, sRColorB);
                            sMT3_STOP.Appearance.BackColor = Color.White;
                        }

                        else
                        {
                            sMT3_RUN.Appearance.BackColor = Color.White;
                            sMT3_STOP.Appearance.BackColor = Color.FromArgb(sSColorR, sSColorG, sSColorB);
                        }

                    }

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        if (Convert.ToString(rtnDtTemp.Rows[0]["STATUS"]) == "R")
                        {
                            //sMT1_RUN.Appearance.BackColor = Color.FromArgb(
                            sDAC1_RUN.Appearance.BackColor = Color.FromArgb(sRColorR, sRColorG, sRColorB);
                            sDAC1_STOP.Appearance.BackColor = Color.White;
                        }

                        else
                        {
                            sDAC1_RUN.Appearance.BackColor = Color.White;
                            sDAC1_STOP.Appearance.BackColor = Color.FromArgb(sSColorR, sSColorG, sSColorB);
                        }

                    }

                    if (rtnDtTemp.Rows.Count > 1) // if (rtnDsTemp.Tables[1].Rows.Count > 0)
                    {
                        if (Convert.ToString(rtnDtTemp.Rows[1]["STATUS"]) == "R")
                        {
                            //sMT1_RUN.Appearance.BackColor = Color.FromArgb(
                            sDAC2_RUN.Appearance.BackColor = Color.FromArgb(sRColorR, sRColorG, sRColorB);
                            sDAC2_STOP.Text = "STOP";
                            sDAC2_STOP.Appearance.BackColor = Color.White;
                        }

                        else
                        {
                            sDAC2_RUN.Appearance.BackColor = Color.White;
                            sDAC2_STOP.Text = "STOP";
                            sDAC2_STOP.Appearance.BackColor = Color.FromArgb(sSColorR, sSColorG, sSColorB);
                        }

                    }
                    if (rtnDtTemp.Rows.Count > 2) // if (rtnDsTemp.Tables[1].Rows.Count > 0)
                    {
                        if (Convert.ToString(rtnDtTemp.Rows[2]["STATUS"]) == "R")
                        {

                            sDAC3_RUN.Appearance.BackColor = Color.FromArgb(sRColorR, sRColorG, sRColorB);
                            sDAC3_STOP.Text = "STOP";
                            sDAC3_STOP.Appearance.BackColor = Color.White;
                        }

                        else
                        {
                            sDAC3_RUN.Appearance.BackColor = Color.White;
                            sDAC3_STOP.Text = "STOP";
                            sDAC3_STOP.Appearance.BackColor = Color.FromArgb(sSColorR, sSColorG, sSColorB);
                        }

                    }

                    //시간 가져오는 부분
                    if (rtnDtTemp.Rows.Count > 0)
                        sTime.Text = DBHelper.nvlString(rtnDtTemp.Rows[0]["DAY"]) + '\n' + DBHelper.nvlString(rtnDtTemp.Rows[0]["TIME"]);
                    else
                        //sTime.Text = DBHelper.nvlString(rtnDtTemp.Rows[0]["DAY"]) + '\n' + DBHelper.nvlString(rtnDtTemp.Rows[0]["TIME"]);
                        sTime.Text = DateTime.Now.ToString();




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    helper.Close();
                    //if (param != null) { param = null; }
                }



            }
            catch
            {
            }
            finally
            {
                timer1.Enabled = true;
            }

        }

        private void MT0200_Deactivate(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void MT0200_Enter(object sender, EventArgs e)
        {
            timer1.Start();
        }
        #endregion

    }
}

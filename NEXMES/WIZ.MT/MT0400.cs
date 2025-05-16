using Infragistics.Win.Misc;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Forms;

//using WIZ.PopUp.Biz;

namespace WIZ.MT
{
    #region<Member Area>
    public partial class MT0400 : BaseMDIChildForm
    {
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        private int sRColorR = 0;
        private int sRColorG = 0;
        private int sRColorB = 0;

        private int sSColorR = 0;
        private int sSColorG = 0;
        private int sSColorB = 0;

        private int sCColorR = 0;
        private int sCColorG = 0;
        private int sCColorB = 0;

        public MT0400()
        {

            InitializeComponent();
        }
        #endregion

        #region  MT0400_Load
        private void MT0400_Load(object sender, EventArgs e)
        {
            #region
            Common _Common = new Common();
            reset();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("UTILITYSET");  //사업장


            Int32 stimer = 1000;

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
                sCColorB = 52;

            }

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");

            //cboPlantCode_H.SelectedValue = "820";\


            search();

            timer1.Interval = stimer;
            timer1.Tick += new EventHandler(t_Tick);
            timer1.Start();





            #endregion


        }
        #endregion MT0400_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        //public override void DoInquire()
        //{

        //}
        ///// <summary>
        ///// ToolBar의 신규 버튼 클릭
        ///// </summary>
        //public override void DoNew()
        //{
        //}
        ///// <summary>
        ///// ToolBar의 삭제 버튼 Click
        ///// </summary>
        //public override void DoDelete()
        //{
        //}
        ///// <summary>
        ///// ToolBar의 저장 버튼 Click
        ///// </summary>
        //public override void DoSave()
        //{

        //}
        #endregion

        #region<Event>
        private void MT0400_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            try
            {
                reset();
                timer1.Enabled = false;

                search();
                timer1.Enabled = true;

            }
            catch
            {
            }
            finally
            {



            }


        }

        private Infragistics.Win.Misc.UltraLabel getLabel(System.Windows.Forms.Control con, string sName)
        {

            Infragistics.Win.Misc.UltraLabel cTemp = null;
            if (con == null)
                return null;

            if (con.Name == sName)
            {
                return (Infragistics.Win.Misc.UltraLabel)con;
            }

            foreach (System.Windows.Forms.Control c in con.Controls)
            {
                cTemp = getLabel(c, sName);
                if (cTemp != null)
                    break;
            }

            return cTemp;
        }

        private void InitControl(System.Windows.Forms.Control con)
        {
            string[] sEmptyArr2 = { "sRUN_", "sSTOP_" };
            string[] sEmptyArr = { "HEADER" };
            if (con == null)
                return;

            foreach (System.Windows.Forms.Control c in con.Controls)
            {
                InitControl(c);

                // 초기화 코드
                if (c.GetType().Name == "UltraLabel")
                {
                    UltraLabel ul = (UltraLabel)c;

                    foreach (string s in sEmptyArr)
                    {
                        if (ul.Name.StartsWith(s))
                        {
                            ul.Text = "";


                        }
                    }

                    foreach (string a in sEmptyArr2)
                    {
                        if (ul.Name.StartsWith(a))
                        {
                            ul.Appearance.BackColor = Color.White;
                            ul.Appearance.AlphaLevel = 90;


                        }
                    }
                }
            }

            return;
        }

        private void reset()
        {
            #region

            InitControl(this);

            #endregion

        }

        private void search()
        {
            int iChk = 0;
            if (iChk == 0)
            {
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);  // 공장코드 

                DBHelper helper = new DBHelper(false);
                try
                {
                    //base.DoInquire();
                    rtnDtTemp = helper.FillTable("USP_MT0400_S1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("@PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                    if (rtnDtTemp.Rows.Count > 0)
                        sTime.Text = Convert.ToString(this.rtnDtTemp.Rows[0]["DAY"]) + '\n' + Convert.ToString(this.rtnDtTemp.Rows[0]["TIME"]);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    helper.Close();
                    //if (param != null) { param = null; }
                }
            }

            string sLabelName = "HEADER";

            string sRUN = "sRUN_";
            string sSTOP = "sSTOP_";

            if (rtnDtTemp.Rows.Count > 0)
            {

                for (int i = 0; i < 12; i++)
                {
                    if (Convert.ToString(rtnDtTemp.Rows[iChk]["WORKCENTERNAME"]) != string.Empty)
                    {
                        string sArr = Convert.ToString(rtnDtTemp.Rows[iChk]["WORKCENTERNAME"]);

                        string stmp = sLabelName + i.ToString();



                        Infragistics.Win.Misc.UltraLabel l = getLabel(this, stmp);



                        l.Text = sArr;
                        l.Visible = true;




                        //if (l.Text.Trim().Length > 5 || lR.Text.Trim().Length > 5)
                        //{
                        //    l.Font = new Font(l.Font.FontFamily, 10);
                        //    lR.Font = new Font(lR.Font.FontFamily, 10);
                        //}

                    }



                    string Rstmp = sRUN + i.ToString();
                    string Sstmp = sSTOP + i.ToString();

                    Infragistics.Win.Misc.UltraLabel Rl = getLabel(this, Rstmp);
                    Infragistics.Win.Misc.UltraLabel Sl = getLabel(this, Sstmp);

                    if (Convert.ToString(rtnDtTemp.Rows[iChk]["STATUS"]) == "R")
                    {
                        Rl.Appearance.BackColor = Color.FromArgb(sRColorR, sRColorG, sRColorB);
                        Sl.Appearance.BackColor = Color.White;
                        Rl.Appearance.AlphaLevel = 0;
                        Sl.Appearance.AlphaLevel = 90;
                        Sl.Text = "STOP";
                        Rl.Visible = true;
                        Sl.Visible = true;
                    }
                    else if (Convert.ToString(rtnDtTemp.Rows[iChk]["STATUS"]) == "S")
                    {
                        Rl.Appearance.BackColor = Color.White;
                        Sl.Appearance.BackColor = Color.FromArgb(sSColorR, sSColorG, sSColorB);
                        Sl.Appearance.AlphaLevel = 0;
                        Rl.Appearance.AlphaLevel = 90;
                        Sl.Text = "STOP";
                        Rl.Visible = true;
                        Sl.Visible = true;
                    }

                    else if (Convert.ToString(rtnDtTemp.Rows[iChk]["STATUS"]) == "C")
                    {
                        Rl.Appearance.BackColor = Color.White;
                        Sl.Appearance.BackColor = Color.FromArgb(sCColorR, sCColorG, sCColorB);
                        Sl.Text = "PLAN";
                        Rl.Appearance.AlphaLevel = 90;
                        Sl.Appearance.AlphaLevel = 0;
                        Rl.Visible = true;
                        Sl.Visible = true;
                    }


                    iChk++;

                    if (iChk == rtnDtTemp.Rows.Count)
                    {
                        for (int c = i + 1; c < 12; c++)
                        {
                            string VRstmp = sRUN + c.ToString();
                            string VSstmp = sSTOP + c.ToString();
                            string Vstmp = sLabelName + c.ToString();

                            Infragistics.Win.Misc.UltraLabel VRl = getLabel(this, VRstmp);
                            Infragistics.Win.Misc.UltraLabel VSl = getLabel(this, VSstmp);
                            Infragistics.Win.Misc.UltraLabel Vl = getLabel(this, Vstmp);


                            VRl.Visible = false;
                            VSl.Visible = false;
                            Vl.Visible = false;


                        }

                        i = 12;
                        iChk = 0;



                    }


                }
            }
        }

        private void MT0400_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }

        private void MT0400_Deactivate(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void MT0400_Enter(object sender, EventArgs e)
        {
            timer1.Start();
        }
        #endregion
    }
}



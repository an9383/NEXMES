#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MT0030
//   Form Name    : 4분할 모니터링
//   Name Space   : WIZ.MT
//   Created Date : 
//   Made By      : 
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.MT
{
    public partial class MT0030 : Forms.BaseMDIChildForm
    {
        #region [ MEMBER AREA ]
        private int iNotice;
        private int iTarget = 0;
        private int iCntWC;

        private bool bSetting = false;
        private bool bLoading = false;

        DataSet dsData = new DataSet();

        DataTable dtNotice = new DataTable();
        DataTable dtWCInfo = new DataTable();
        DataTable dtWCStatus = new DataTable();
        DataTable rtnDT = new DataTable();

        Panel pnlWC;

        MT0030_UC[] _uaMT0030 = new MT0030_UC[0];
        MT0030_UC _ucMT0030;

        Timer _timerTime;
        Timer _timerData;

        Common _cmmn = new Common();
        #endregion

        //UC_WorkCenterProdStatus[] ArrUcWc2 = new UC_WorkCenterProdStatus[24];

        //#region [ MEMBER AREA ]
        //private string sPlantCode = LoginInfo.PlantCode;
        //private int iRowCnt = 1; // 화면 Row 생성 기준
        //private int iColCnt = 1; // 화면 Column 생성 기준
        //bool bStart = false;

        //DataTable rtnDtTemp = new DataTable();
        //DataTable dtNotice = new DataTable();

        //DataSet dsData = new DataSet();

        //Timer _timerTabChange = new Timer();
        //Timer _timerDataSearch = new Timer();

        //UltraGridUtil _GridUtil = new UltraGridUtil();
        //Common _Common = new Common();

        //UC_SPC[] _ucSPC;
        //UC_CheckSheet[] _ucCheckSheet;
        //UC_WorkCenterStatus[] _ucWCStatus;
        //UC_WorkCenterCheck[] _ucWCCheck;

        //Hashtable hashXAXIS = new Hashtable();
        //Hashtable hashYAXIS = new Hashtable();
        //Hashtable hashWCData = new Hashtable();
        //#endregion

        #region [ CONSTRUCTOR ]
        public MT0030()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            bPopUp = true;
            WindowState = FormWindowState.Maximized;

            Initialization();
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
        #endregion

        #region [ FORM EVENT ]
        private void MT0030_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region [ METHOD AREA ]
        private void Initialization()
        {
            bSetting = true;
            bLoading = true;

            pnlSetting.Visible = false;
            pnlLoading.Visible = false;

            pnlSetting.BackgroundImage = Properties.Resources.MT0030_008;
            pnlLoading.BackgroundImage = Properties.Resources.MT0030_009;

            pnlSetting.BackgroundImageLayout = ImageLayout.Stretch;
            pnlLoading.BackgroundImageLayout = ImageLayout.Stretch;

            picSetting.Image = Properties.Resources.MT0030_010;
            picLoading.Image = Properties.Resources.MT0030_010;

            picSetting.SizeMode = PictureBoxSizeMode.CenterImage;
            picLoading.SizeMode = PictureBoxSizeMode.CenterImage;

            pnlSetting.Visible = true;
            pnlSetting.BringToFront();

            pnlMain.BackgroundImage = Properties.Resources.MT0030_000;
            picTitle.Image = Properties.Resources.MT0030_007;

            pnlMain.BackgroundImageLayout = ImageLayout.Stretch;
            picTitle.SizeMode = PictureBoxSizeMode.StretchImage;

            pnlWC = new Panel();
            pnlWC.BorderStyle = BorderStyle.None;
            pnlWC.BackColor = Color.Transparent;
            pnlWC.Margin = new Padding(0, 0, 0, 0);
            pnlWC.Padding = new Padding(0, 0, 0, 0);
            pnlWC.Size = new Size(1239, 984);
            pnlWC.Location = new Point(680, 0);
            pnlMain.Controls.Add(pnlWC);

            lblTime.Text = "0000-00-00 00:00:00";
            lblRunCnt.Text = "0";
            lblRunWC.Text = "(0 / 0)";
            lblStopCnt.Text = "0";
            lblStopWC.Text = "(0 / 0)";
            lblStopACnt.Text = "0";
            lblStopBCnt.Text = "0";
            lblStopCCnt.Text = "0";
            lblInCnt.Text = "0";
            lblOutCnt.Text = "0";
            lblNotice.Text = "";

            int iCycleTime = DBHelper.nvlInt(_cmmn.GET_BM0000_CODE("TIMERINTERVAL", "MINORCODE = 'SELECTTIMER'").Rows[0]["RELCODE1"]);

            if (_timerTime == null)
            {
                _timerTime = new Timer();
                _timerTime.Tick += new EventHandler(_timerTime_Tick);
                _timerTime.Interval = 1000;
            }

            if (_timerData == null)
            {
                _timerData = new Timer();
                _timerData.Tick += new EventHandler(_timerData_Tick);
                _timerData.Interval = (iCycleTime == 0 ? 3 : iCycleTime) * 1000;
            }

            _timerTime.Start();
            _timerData.Start();
        }

        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                dsData = helper.FillDataSet("USP_MT0030_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input));

                if (dsData.Tables.Count > 0)
                {
                    dtNotice = dsData.Tables[0];

                    iNotice = dtNotice.Rows.Count;

                    if (dsData.Tables.Count == 3)
                    {
                        dtWCInfo = dsData.Tables[1];
                        dtWCStatus = dsData.Tables[2];

                        if (dtWCStatus.Rows.Count > 0)
                        {
                            lblRunWC.Text = string.Format("( {0} / {1} )", Convert.ToString(dtWCStatus.Rows[0]["RUNCNT"]), Convert.ToString(dtWCStatus.Rows[0]["WCCNT"]));
                            lblRunCnt.Text = Convert.ToString(dtWCStatus.Rows[0]["RUNCNT"]);
                            lblStopWC.Text = string.Format("( {0} / {1} )", Convert.ToString(dtWCStatus.Rows[0]["STOPCNT"]), Convert.ToString(dtWCStatus.Rows[0]["WCCNT"]));
                            lblStopCnt.Text = Convert.ToString(dtWCStatus.Rows[0]["STOPCNT"]);
                            lblStopACnt.Text = Convert.ToString(dtWCStatus.Rows[0]["PLANSTOP"]);
                            lblStopBCnt.Text = Convert.ToString(dtWCStatus.Rows[0]["MACHSTOP"]);
                            lblStopCCnt.Text = Convert.ToString(dtWCStatus.Rows[0]["ETCSTOP"]);
                            lblInCnt.Text = Convert.ToString(dtWCStatus.Rows[0]["INWORKERCNT"]);
                            lblOutCnt.Text = Convert.ToString(dtWCStatus.Rows[0]["OUTWORKER"]);
                        }

                        if (bLoading)
                        {
                            bLoading = false;

                            iCntWC = dtWCInfo.Rows.Count;

                            _uaMT0030 = new MT0030_UC[iCntWC];

                            for (int i = 0; i < iCntWC; i++)
                            {
                                string sWCCode = Convert.ToString(dtWCInfo.Rows[i]["WORKCENTERCODE"]);

                                _ucMT0030 = new MT0030_UC();

                                _ucMT0030.Name = sWCCode;
                                _ucMT0030.WCData = dtWCInfo.Rows[i];
                                _ucMT0030.Location = new Point(DBHelper.nvlInt(dtWCInfo.Rows[i]["XPOINT"]), DBHelper.nvlInt(dtWCInfo.Rows[i]["YPOINT"]));

                                _uaMT0030[i] = _ucMT0030;

                                pnlWC.Controls.Add(_uaMT0030[i]);
                            }

                            pnlLoading.Visible = false;
                            pnlLoading.SendToBack();
                        }
                        else
                        {
                            for (int i = 0; i < iCntWC; i++)
                            {
                                if (!_uaMT0030[i].Name.Equals(Convert.ToString(dtWCInfo.Rows[i]["WORKCENTERCODE"])) || _uaMT0030.Length != dtWCInfo.Rows.Count)
                                {
                                    pnlLoading.Visible = true;
                                    pnlLoading.BringToFront();

                                    pnlWC.Dispose();

                                    _uaMT0030[i].Dispose();

                                    pnlWC = new Panel();
                                    pnlWC.BorderStyle = BorderStyle.None;
                                    pnlWC.BackColor = Color.Transparent;
                                    pnlWC.Margin = new Padding(0, 0, 0, 0);
                                    pnlWC.Padding = new Padding(0, 0, 0, 0);
                                    pnlWC.Size = new Size(1239, 984);
                                    pnlWC.Location = new Point(680, 0);
                                    pnlMain.Controls.Add(pnlWC);

                                    bLoading = true;

                                    return;
                                }

                                _uaMT0030[i].WCData = dtWCInfo.Rows[i];
                                _uaMT0030[i].Location = new Point(DBHelper.nvlInt(dtWCInfo.Rows[i]["XPOINT"]), DBHelper.nvlInt(dtWCInfo.Rows[i]["YPOINT"]));
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                helper.Close();

                if (bSetting)
                {
                    bSetting = false;

                    pnlSetting.Visible = false;
                    pnlSetting.SendToBack();
                }
            }
        }

        private void AddHashtable(Hashtable hash, object key, object value)
        {
            if (!hash.ContainsKey(key))
            {
                hash.Add(key, value);
            }
        }
        #endregion

        private void _timerTime_Tick(object sender, EventArgs e)
        {
            _timerTime.Stop();

            try
            {
                lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
            }
            finally
            {
                _timerTime.Start();
            }
        }

        private void _timerData_Tick(object sender, EventArgs e)
        {
            _timerData.Stop();

            try
            {
                DoFind();

                if (iNotice >= 0)
                {
                    try
                    {
                        lblNotice.Text = Convert.ToString(dtNotice.Rows[iTarget]["NOTICE"]);

                        if (iNotice > iTarget)
                        {
                            iTarget++;
                        }
                        else
                        {
                            iTarget = 0;
                        }
                    }
                    catch
                    {
                        iTarget = 0;
                    }
                }
                else
                {
                    lblNotice.Text = string.Empty;
                }
            }
            catch
            {
            }
            finally
            {
                _timerData.Start();
            }
        }

        private void pnlMain_DoubleClick(object sender, EventArgs e)
        {
            if (_timerTime != null)
            {
                _timerTime.Stop();
                _timerTime.Dispose();
            }

            if (_timerData != null)
            {
                _timerData.Stop();
                _timerData.Dispose();
            }

            this.Close();
        }
    }
}
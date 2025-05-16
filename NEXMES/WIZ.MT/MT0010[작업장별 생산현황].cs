#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MT0010
//   Form Name    : 작업장별 생산현황
//   Name Space   : WIZ.MT  
//   Created Date : 2018-01-16
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : 작업장별 실시간 생산현황 모니터링
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Forms;
#endregion

namespace WIZ.MT
{
    public partial class MT0010 : BaseMDIChildForm
    {
        #region < MEMBER AREA >



        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();          //return DataTable 공통
        DataTable _DtTemp = new DataTable();            //임시로 사용할 데이터테이블

        string SelPlantCode = string.Empty;
        string SelOpCode = string.Empty;
        string SelWorkCenterCode = string.Empty;

        MT0010_UC[] UcWC = new MT0010_UC[0];
        MT0010_UC[] PrevUcWC = new MT0010_UC[0];

        bool bStop = false;                             //모니터링 Timer STOP Flag
        int iSearchTime;

        Timer _timer;                                   //모니터링 조회 Timer

        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        #endregion

        #region < CONSTRUCTOR >
        public MT0010()
        {
            InitializeComponent();

            bPopUp = true;
            WindowState = FormWindowState.Maximized;

            //DoInquire();
        }
        #endregion

        #region < FORM LOAD >
        private void MT0010_Load(object sender, EventArgs e)
        {
            rtnDtTemp = _Common.GET_BM0000_CODE("TIMERINTERVAL", "MINORCODE = 'SELECTTIMER'");  //사업장
            iSearchTime = Convert.ToInt32(rtnDtTemp.Rows[0]["RELCODE1"]);

            if (_timer == null)
            {
                _timer = new Timer();
                _timer.Tick += new EventHandler(_timer_Tick);
                _timer.Interval = iSearchTime * 1000;
            }

            _timer.Enabled = true;

            DoInquire();
        }

        private void MT0010_Deactivate(object sender, EventArgs e)
        {
            //bStop = true;
        }

        private void MT0010_Activated(object sender, EventArgs e)
        {
            if (bStop == true)
            {
                bStop = false;
                _timer.Enabled = true;
            }
        }
        #endregion 

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            //base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MT0010_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input));
                this.ClosePrgFormNew();
                if (rtnDtTemp.Rows.Count > 0)
                {
                    DataTable DtGrid = rtnDtTemp.Clone();

                    #region ▶ 라인별 가동현황(모니터링) ◀

                    int iLineCnt = rtnDtTemp.Rows.Count;
                    int w = this.Width;
                    int h = this.Height;

                    if (pnlMain.Controls.Count == 0) // 첫번째 조회일때만 UserControl 배열 생성
                    {
                        PrevUcWC = new MT0010_UC[iLineCnt];
                        UcWC = new MT0010_UC[iLineCnt];
                    }

                    int wCnt = 10;
                    int hCnt = (iLineCnt / wCnt) + ((iLineCnt % wCnt) > 0 ? 1 : 0);

                    int x = 1;
                    int y = 1;

                    for (int i = 0; i < iLineCnt; i++)
                    {
                        bool bCompDR = false; //DataRow 비교

                        if (PrevUcWC[i] != null)
                            bCompDR = CompareDataRow(PrevUcWC[i].WCData, rtnDtTemp.Rows[i]);

                        if (bCompDR == true)
                            continue;
                        else // 첫번째 조회일때, 데이터가 변경되었을때만
                        {
                            if (UcWC[i] != null)
                                pnlMain.Controls.RemoveByKey(UcWC[i].Name);

                            string pWCCode = Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERCODE"]);

                            MT0010_UC uc = new MT0010_UC();
                            uc.Name = "UC" + pWCCode;
                            uc.WCData = rtnDtTemp.Rows[i];

                            pnlMain.Controls.Add(uc);

                            x = ((i % wCnt) * (uc.Width + 5)) + 1;
                            y = ((i / wCnt) * (uc.Height + 5)) + 1;

                            uc.Location = new Point(x, y);

                            UcWC[i] = uc;
                            PrevUcWC[i] = uc;
                        }
                    }

                    pnlMain.Refresh();
                    #endregion
                }
                else
                {
                    #region ▶ TAB별 데이터 CLEAR ◀
                    for (int i = 0; i < UcWC.Length; i++)
                    {
                        try
                        {
                            pnlMain.Controls.RemoveByKey(UcWC[i].Name);
                        }
                        catch
                        {
                            UcWC = new MT0010_UC[0];
                            break;
                        }
                    }
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);    //조회할 데이터가 없습니다.
                    #endregion
                }
            }
            catch (Exception ex)
            {
                //this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
                this.Focus();
            }
        }

        public override void DoDownloadExcel()
        {
            base.DoDownloadExcel();
        }

        #endregion

        #region < EVENT AREA >

        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Enabled = false;

            try
            {
                if (bStop == false)
                {
                    this.DoInquire();
                }
            }
            catch
            {
            }
            finally
            {
                if (bStop == false && this.IsDisposed == false)
                    _timer.Enabled = true;
            }
        }

        private void pnlMain_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblHeader_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }


        private void MT0010_FormClosing(object sender, FormClosingEventArgs e)
        {
            bStop = true;
        }

        #endregion

        #region < USER METHOD AREA >
        private bool CompareDataRow(DataRow prevRow, DataRow curRow)
        {
            bool rValue = true;

            foreach (DataColumn c in prevRow.Table.Columns)
            {
                string cName = c.ColumnName;

                if (prevRow[cName].Equals(curRow[cName]))
                    continue;
                else
                {
                    rValue = false;
                    break;
                }
            }

            return rValue;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #endregion
    }
}
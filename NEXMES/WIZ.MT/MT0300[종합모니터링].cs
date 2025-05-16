#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MT0300
//   Form Name    : 종합모니터링
//   Name Space   : WIZ.MT
//   Created Date : 2017.07.21
//   Made By      : 
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.UltraChart.Resources.Appearance;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Forms;

#endregion

namespace WIZ.MT
{
    public partial class MT0300 : BaseMDIChildForm
    {
        #region < MEMEBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();         //COMMON 객체 생성

        DataTable rtnDtTemp = new DataTable();          //return DataTable 공통

        Hashtable hashXAXIS = new Hashtable();
        Hashtable hashYAXIS = new Hashtable();
        Hashtable hashWCData = new Hashtable();

        string SelPlantCode = string.Empty;
        string SelOpCode = string.Empty;
        string SelWorkCenterCode = string.Empty;
        string sPlantCode = string.Empty;

        string TabTimerInterval = string.Empty;
        string SelectTimerInterval = string.Empty;

        DataTable DtChk = new DataTable();                            //UC_SPC 표시 체크여부확인

        UC_SPC[] Uc_Spc = new UC_SPC[0];                              //UC_SPC 배열객체 생성
        int iDisplayNum = 0;                                          //Display번호

        bool FormLoad = false;



        int inquireCnt = 0;                             //조회횟수 COUNT

        UC_WorkCenter_MT0300[] UcWC = new UC_WorkCenter_MT0300[0];
        UC_WorkCenter_MT0300 uc;

        Timer _TabTimer;                                   //탭 전환 Timer
        Timer _SelectTimer;                                //조회 Timer

        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        Color color1 = System.Drawing.ColorTranslator.FromHtml("#125EA0");
        Color color2 = System.Drawing.ColorTranslator.FromHtml("#8F4606");
        Color color3 = System.Drawing.ColorTranslator.FromHtml("#3D0F9B");
        Color color4 = System.Drawing.ColorTranslator.FromHtml("#978A02");
        Color color5 = System.Drawing.ColorTranslator.FromHtml("#099288");
        Color color6 = System.Drawing.ColorTranslator.FromHtml("#578201");
        #endregion


        #region < CONSTRUCTOR >
        public MT0300()
        {
            InitializeComponent();

            bPopUp = true;


            ultraLabel1.Appearance.BackColor = color1;
            ultraLabel2.Appearance.BackColor = color2;
            ultraLabel3.Appearance.BackColor = color3;
            ultraLabel4.Appearance.BackColor = color4;
            ultraLabel5.Appearance.BackColor = color5;
            ultraLabel6.Appearance.BackColor = color6;


        }
        #endregion


        #region < FORM EVENTS >
        private void MT0300_Load(object sender, EventArgs e)
        {
            FormLoad = true;

            #region < GRID >
            //LOT추적
            //_GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            //_GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품번", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOT NO", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "LOTBASEQTY", "기초수량", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "현재수량", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "생산지시", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "PRTWCCODE", "발행위치", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "PRTTYPE", "구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "LABELPRTDATE", "발행일시", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "CUSTLOTNO", "고객 LOT번호", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "식별표상태", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "USEBLEFLAG", "가용여부", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "LOTTYPE", "생성구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고명", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "INWHDATE", "창고입고일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "OUTWHDATE", "창고출고일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "INSPYESNO", "제품검사여부", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "INSPDATE", "제품검사일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT", "제품검사결과", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "LOTCLOSEDATE", "LOT종료일시", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            //_GridUtil.SetInitUltraGridBind(grid1);

            //grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;


            //공정재고

            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 290, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STOCK", "재고량", true, GridColDataType_emu.VarChar, 320, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FLAG", "FLAG", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            grid2.DisplayLayout.Override.DefaultRowHeight = 60;

            //자주검사 SPC분석
            DtChk.Columns.Add("PLANTCODE");
            DtChk.Columns.Add("ITEMCODE");
            DtChk.Columns.Add("ITEMNAME");
            DtChk.Columns.Add("MESRCODE");
            DtChk.Columns.Add("MESRNAME");


            #endregion


            #region < COMBOBOX >
            rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장          
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");



            rtnDtTemp = _Common.GET_BM0000_CODE("TIMERINTERVAL");  //사업장

            TabTimerInterval = rtnDtTemp.Rows[0][3].ToString();
            SelectTimerInterval = rtnDtTemp.Rows[1][3].ToString();

            #endregion

            #region < TIMER >

            if (_TabTimer == null)
            {
                _TabTimer = new Timer();
                _TabTimer.Tick += new EventHandler(_Tabtimer_Tick);
                _TabTimer.Interval = Convert.ToInt32(TabTimerInterval) * 1000;
            }

            _TabTimer.Enabled = true;

            if (_SelectTimer == null)
            {
                _SelectTimer = new Timer();
                _SelectTimer.Tick += new EventHandler(_SelectTimer_Tick);
                _SelectTimer.Interval = Convert.ToInt32(SelectTimerInterval) * 1000;
            }

            _SelectTimer.Enabled = true;

            #endregion

            utcMonitoring.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;

            DoInquire();
        }


        #endregion


        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {

            DBHelper helper = new DBHelper(false);

            try
            {
                //LOT추적
                if (utcMonitoring.SelectedTab.Index == 0)
                {
                    //rtnDtTemp = helper.FillTable("USP_MT0300_S1", CommandType.StoredProcedure
                    //                                               , helper.CreateParameter("AS_PLANTCODE", "", DbType.String, ParameterDirection.Input)
                    //                                               , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                    //                                               , helper.CreateParameter("AS_LOTNO", "", DbType.String, ParameterDirection.Input));

                    //if (rtnDtTemp.Rows.Count > 0)
                    //{
                    //    grid1.DataSource = rtnDtTemp;
                    //    grid1.DataBind();
                    //}

                    //this.grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;

                }

                //재고현황
                else if (utcMonitoring.SelectedTab.Index == 1)
                {
                    rtnDtTemp = helper.FillTable("USP_MT0300_S2", CommandType.StoredProcedure);

                    DataTable rtnDtTemp2 = new DataTable();

                    Infragistics.Win.UltraWinChart.UltraChart[] arrUltraChar1 = new Infragistics.Win.UltraWinChart.UltraChart[12];

                    arrUltraChar1[0] = ultraChartM1;
                    arrUltraChar1[1] = ultraChartM2;
                    arrUltraChar1[2] = ultraChartM3;
                    arrUltraChar1[3] = ultraChartM4;
                    arrUltraChar1[4] = ultraChartM5;
                    arrUltraChar1[5] = ultraChartM6;
                    arrUltraChar1[6] = ultraChartM7;
                    arrUltraChar1[7] = ultraChartM8;
                    arrUltraChar1[8] = ultraChartM9;
                    arrUltraChar1[9] = ultraChartM10;
                    arrUltraChar1[10] = ultraChartM11;
                    arrUltraChar1[11] = ultraChartM12;



                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                        {
                            rtnDtTemp2 = helper.FillTable("USP_MT0300_S5", CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_ITEMCODE", rtnDtTemp.Rows[i]["ITEMCODE"], DbType.String, ParameterDirection.Input));


                            arrUltraChar1[i].Visible = true;
                            arrUltraChar1[i].Series.Clear();

                            NumericSeries series = new NumericSeries();

                            series.Data.DataSource = rtnDtTemp2;
                            series.Data.LabelColumn = "FLAG";
                            series.Data.ValueColumn = "STOCK";
                            series.DataBind();

                            arrUltraChar1[i].Series.Add(series);
                            arrUltraChar1[i].Data.DataBind();
                            arrUltraChar1[i].TitleTop.Text = rtnDtTemp2.Rows[0]["ITEMCODE"].ToString();
                            arrUltraChar1[i].TitleBottom.Text = rtnDtTemp.Rows[i]["BASEUNIT"].ToString();

                        }
                    }

                    rtnDtTemp = helper.FillTable("USP_MT0300_S3", CommandType.StoredProcedure);

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        ultraChartP1.Visible = true;
                        ultraChartP1.Series.Clear();

                        NumericSeries series = new NumericSeries();

                        series.Data.DataSource = rtnDtTemp;
                        series.Data.LabelColumn = "ITEMCODE";
                        series.Data.ValueColumn = "STOCK";
                        series.DataBind();

                        ultraChartP1.Series.Add(series);
                        ultraChartP1.Data.DataBind();

                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBinds();


                    }

                    rtnDtTemp = helper.FillTable("USP_MT0300_S4", CommandType.StoredProcedure);

                    Infragistics.Win.UltraWinChart.UltraChart[] arrUltraChar2 = new Infragistics.Win.UltraWinChart.UltraChart[20];

                    arrUltraChar2[0] = ultraChartW1;
                    arrUltraChar2[1] = ultraChartW2;
                    arrUltraChar2[2] = ultraChartW3;
                    arrUltraChar2[3] = ultraChartW4;
                    arrUltraChar2[4] = ultraChartW5;
                    arrUltraChar2[5] = ultraChartW6;
                    arrUltraChar2[6] = ultraChartW7;
                    arrUltraChar2[7] = ultraChartW8;
                    arrUltraChar2[8] = ultraChartW9;
                    arrUltraChar2[9] = ultraChartW10;
                    arrUltraChar2[10] = ultraChartW11;
                    arrUltraChar2[11] = ultraChartW12;
                    arrUltraChar2[12] = ultraChartW13;
                    arrUltraChar2[13] = ultraChartW14;
                    arrUltraChar2[14] = ultraChartW15;
                    arrUltraChar2[15] = ultraChartW16;
                    arrUltraChar2[16] = ultraChartW17;
                    arrUltraChar2[17] = ultraChartW18;
                    arrUltraChar2[18] = ultraChartW19;
                    arrUltraChar2[19] = ultraChartW20;

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                        {
                            rtnDtTemp2 = helper.FillTable("USP_MT0300_S7", CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_ITEMCODE", rtnDtTemp.Rows[i]["ITEMCODE"], DbType.String, ParameterDirection.Input));


                            arrUltraChar2[i].Visible = true;
                            arrUltraChar2[i].Series.Clear();

                            NumericSeries series = new NumericSeries();

                            series.Data.DataSource = rtnDtTemp2;
                            series.Data.LabelColumn = "FLAG";
                            series.Data.ValueColumn = "STOCK";
                            series.DataBind();

                            arrUltraChar2[i].Series.Add(series);
                            arrUltraChar2[i].Data.DataBind();
                            arrUltraChar2[i].TitleTop.Text = rtnDtTemp2.Rows[0]["ITEMCODE"].ToString();
                            arrUltraChar2[i].TitleBottom.Text = rtnDtTemp.Rows[i]["BASEUNIT"].ToString();

                        }
                    }

                }


                //설비모니터링
                else if (utcMonitoring.SelectedTab.Index == 2)
                {
                    picView.Image = WIZ.MT.Properties.Resources.MCTIMAGE;

                    rtnDtTemp = helper.FillTable("USP_MT0150_S2", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", "", DbType.String, ParameterDirection.Input));
                }

                //SPC분석
                else
                {

                    rtnDtTemp = helper.FillTable("USP_QM3200_S1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input));

                }

                if (rtnDtTemp.Rows.Count > 0)
                {
                    DataTable DtGrid = rtnDtTemp.Clone();

                    if (utcMonitoring.SelectedTab.Index == 0)
                    {
                        #region < LOT추적 - TAB0 >
                        #endregion

                    }
                    else if (utcMonitoring.SelectedTab.Index == 1)
                    {
                        #region < 재고현황 - TAB1 >


                        #endregion
                    }
                    else if (utcMonitoring.SelectedTab.Index == 2)
                    {
                        #region < 설비모니터링 - TAB2 >

                        int wcCnt = rtnDtTemp.Rows.Count;

                        UcWC = new UC_WorkCenter_MT0300[wcCnt];


                        for (int i = 0; i < wcCnt; i++)
                        {
                            string pWCCode = Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERCODE"]);

                            int Xaxis = Convert.ToInt32(rtnDtTemp.Rows[i]["XAXIS"]);
                            int Yaxis = Convert.ToInt32(rtnDtTemp.Rows[i]["YAXIS"]);

                            UC_WorkCenter_MT0300 uc = new UC_WorkCenter_MT0300(hashXAXIS, hashYAXIS, hashWCData);

                            uc.Name = "UC" + pWCCode;
                            uc.WCData = rtnDtTemp.Rows[i];
                            uc.Location = new Point(Xaxis, Yaxis);

                            UcWC[i] = uc;


                            if (inquireCnt == 0) //첫번째 조회시
                            {
                                hashXAXIS.Add(uc.Name, Xaxis);
                                hashYAXIS.Add(uc.Name, Yaxis);
                                hashWCData.Add(uc.Name, uc.WCData);

                                mainPnl.Controls.Add(uc);
                            }
                            else //첫번째 이후 조회시
                            {
                                addHash(hashXAXIS, uc.Name, Xaxis);
                                addHash(hashYAXIS, uc.Name, Yaxis);
                                addHash(hashWCData, uc.Name, uc.WCData);

                                DataRow dRow = (DataRow)hashWCData[uc.Name];

                                if (!Equals(hashXAXIS[uc.Name], Xaxis) || !Equals(hashYAXIS[uc.Name], Yaxis) || !DataRowComparer.Default.Equals(dRow, rtnDtTemp.Rows[i]))
                                {
                                    mainPnl.Controls.RemoveByKey(UcWC[i].Name);
                                    mainPnl.Controls.Add(uc);

                                    hashXAXIS.Remove(uc.Name);
                                    hashYAXIS.Remove(uc.Name);
                                    hashWCData.Remove(uc.Name);

                                    hashXAXIS.Add(uc.Name, Xaxis);
                                    hashYAXIS.Add(uc.Name, Yaxis);
                                    hashWCData.Add(uc.Name, uc.WCData);
                                }
                            }
                        }

                        inquireCnt++;
                        mainPnl.Refresh();
                        UcWC[0].Dock = DockStyle.Fill;


                        #endregion
                    }
                    else
                    {
                        #region < 자주검사SPC분석 - TAB5 >
                        tvMesr.Nodes.Clear();
                        QueryResultToTreeView(tvMesr, rtnDtTemp);
                        #endregion
                    }
                }
                else
                {
                    #region < TAB별 데이터 CLEAR >
                    if (utcMonitoring.SelectedTab.Index == 0)
                    {
                        _GridUtil.Grid_Clear(grid1);
                    }
                    else if (utcMonitoring.SelectedTab.Index == 1)
                    {

                    }
                    else if (utcMonitoring.SelectedTab.Index == 2)
                    {
                        for (int i = 0; i < UcWC.Length; i++)
                        {
                            try
                            {
                                mainPnl.Controls.RemoveByKey(UcWC[i].Name);
                            }
                            catch
                            {
                                UcWC = new UC_WorkCenter_MT0300[0];
                                break;
                            }
                        }
                    }
                    else
                    {

                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }

        #endregion


        #region < GRID >

        #endregion

        #region < TABCONTROL >


        private void mainPnl_MouseEnter(object sender, EventArgs e)
        {
            if (mainPnl.Focused == false)
                mainPnl.Focus();
        }

        private void ultraTabControl2_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (FormLoad == false)
            {
                return;
            }


            if (_SelectTimer != null)
            {
                _SelectTimer.Dispose();

                _SelectTimer = new Timer();
                _SelectTimer.Tick += new EventHandler(_SelectTimer_Tick);
                _SelectTimer.Interval = Convert.ToInt32(SelectTimerInterval) * 1000;

                _SelectTimer.Enabled = true;
            }

            lblTitle.Text = Common.getLangText(utcMonitoring.SelectedTab.TabPage.Tag.ToString(), "TEXT");



            if (utcMonitoring.SelectedTab.Index == 0)
            {
                DoInquire();
            }
            else if (utcMonitoring.SelectedTab.Index == 1)
            {
                DoInquire();
            }
            else if (utcMonitoring.SelectedTab.Index == 2)
            {
                DoInquire();
            }
            else
            {
                Control_Display();
            }
        }
        #endregion

        #region < TIMER >
        private void _Tabtimer_Tick(object sender, EventArgs e)
        {
            _TabTimer.Enabled = false;

            try
            {
                if (utcMonitoring.SelectedTab.Index != utcMonitoring.Tabs.Count - 1)
                {
                    utcMonitoring.SelectedTab = utcMonitoring.Tabs[utcMonitoring.SelectedTab.Index + 1];
                }
                else
                {
                    utcMonitoring.SelectedTab = utcMonitoring.Tabs[0];
                }
            }
            catch
            {
            }
            finally
            {
                _TabTimer.Enabled = true;
            }
        }

        private void _SelectTimer_Tick(object sender, EventArgs e)
        {
            _SelectTimer.Enabled = false;

            try
            {
                if (utcMonitoring.SelectedTab.Index != 2)
                {
                    DoInquire();
                }
                else
                {
                    Control_Display();
                }
            }
            catch
            {
            }
            finally
            {
                _SelectTimer.Enabled = true;
            }
        }
        #endregion

        #region < TAB별 메소드 >

        #region < TAB3 >
        private void Binding_UC_SPC()
        {
            int Chk_Cnt = 0;

            for (int i = 0; i < DtChk.Rows.Count; i++)
            {
                Chk_Cnt++;
            }

            if (Chk_Cnt == 0)
            {
                Uc_Spc = null;
                return;
            }


            iDisplayNum = 0;

            Uc_Spc = new UC_SPC[Chk_Cnt];
            Chk_Cnt = 0;


            for (int j = 0; j < DtChk.Rows.Count; j++)
            {
                Chk_Cnt++;

                string sPlantCode = DBHelper.nvlString(DtChk.Rows[j]["PLANTCODE"].ToString());
                string sItemCode = DBHelper.nvlString(DtChk.Rows[j]["ITEMCODE"].ToString());
                string sItemName = DBHelper.nvlString(DtChk.Rows[j]["ITEMNAME"].ToString());
                string sMesrCode = DBHelper.nvlString(DtChk.Rows[j]["MESRCODE"].ToString());
                string sMesrName = DBHelper.nvlString(DtChk.Rows[j]["MESRNAME"].ToString());


                int x = 0;
                int y = 0;

                UC_SPC uc = new UC_SPC();
                //uc.PlantCode = sPlantCode;
                //uc.ItemCode = sItemCode;
                //uc.ItemName = sItemName;
                //uc.MesrCode = sMesrCode;
                //uc.MesrName = sMesrName;
                //uc.StartDate = Convert.ToString(DateTime.Now).Substring(0, 10);
                //uc.EndDate = Convert.ToString(DateTime.Now).Substring(0, 10);
                //uc.MesrType = "M";

                if (Chk_Cnt > 1)
                {
                    if ((Chk_Cnt - 1) % 2 != 0)
                    {
                        y = Uc_Spc[Chk_Cnt - 2].Location.Y + Uc_Spc[Chk_Cnt - 2].Height;
                    }
                }

                uc.Width = panel1.Width;
                uc.Height = panel1.Height / 2;
                uc.Location = new Point(x, y);

                Uc_Spc[Chk_Cnt - 1] = uc;
            }
        }


        private void Control_Display()
        {
            panel1.Refresh();
            panel1.Controls.Clear();

            if (Uc_Spc != null)
            {
                for (int i = iDisplayNum; i < Uc_Spc.Length; i++)
                {
                    panel1.Controls.Add(Uc_Spc[i]);
                }
            }
        }

        public void QueryResultToTreeView(TreeView tv, DataTable dt)
        {
            Dictionary<string, TreeNode> DicTn = new Dictionary<string, TreeNode>();
            for (int i = 1; i <= dt.Columns.Count; i++)
            {
                DataTable TempDT = getDistinct(dt, i);
                for (int k = 0; k < TempDT.Rows.Count; k++)
                {
                    string TreeNodeName = getRowName(TempDT, k, i);
                    DicTn[TreeNodeName] = new TreeNode(TempDT.Rows[k][i - 1].ToString());
                    if (i > 1)
                    {
                        string ParentName = getRowName(TempDT, k, i - 1);
                        if (string.IsNullOrEmpty(ParentName)) continue;
                        if (ParentName == TreeNodeName) continue;
                        DicTn[ParentName].Nodes.Add(DicTn[TreeNodeName]);
                    }

                    else tv.Nodes.Add(DicTn[TreeNodeName]);
                }
            }
        }

        private string getRowName(DataTable dt, int rowCnt, int colCnt)
        {
            string str = null;
            for (int i = 0; i < colCnt; i++) str += dt.Rows[rowCnt][i].ToString();
            return str;
        }

        private DataTable getDistinct(DataTable dt, int level)
        {
            string[] str = new string[level];
            for (int i = 0; i < level; i++) str[i] = dt.Columns[i].ColumnName;
            return dt.DefaultView.ToTable(true, str);
        }
        #endregion

        #endregion

        #region < FUNCTION AREA >       

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            if (_TabTimer != null)
            {
                _TabTimer.Dispose();
            }

            if (_SelectTimer != null)
            {
                _SelectTimer.Dispose();
            }

            this.Close();
        }

        #endregion




        #region <TAB2 EVENT>
        private void mainPnl_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void mainPnl_DragDrop(object sender, DragEventArgs e)
        {
            int pointX = e.X;
            int pointY = e.Y - gbxHeader.Height - 20;

            uc.Location = PointToClient(new Point(pointX, pointY));

            mainPnl.Controls.Add(uc);
        }

        private void addHash(Hashtable hash, object key, object value)
        {
            if (!hash.ContainsKey(key))
            {
                hash.Add(key, value);
            }
        }

        private void mainPnl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                ContextMenu menu = new ContextMenu();
                MenuItem item1 = new MenuItem("작업장 추가");

                item1.Click += new EventHandler(item1_Click);
                menu.MenuItems.Add(item1);

                menu.Show(mainPnl, new Point(e.X, e.Y));
            }
        }

        private void item1_Click(object sender, EventArgs e) //작업장 정보 등록
        {
            uc = new UC_WorkCenter_MT0300(hashXAXIS, hashYAXIS, hashWCData);

            int pointX = System.Windows.Forms.Control.MousePosition.X;
            int pointY = System.Windows.Forms.Control.MousePosition.Y;

            uc.Location = PointToClient(new Point(pointX, pointY));

            mainPnl.Controls.Add(uc);
        }
        #endregion

        #region <TAB3 EVENT>
        private void tvMesr_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                string[] sPathCode = new string[2];
                string[] sPathSplit = e.Node.FullPath.Split('[');

                for (int i = 1; i < sPathSplit.Length; i++)
                {
                    string[] sPathSplit2 = sPathSplit[i].Split(']');
                    sPathCode[i - 1] = sPathSplit2[0];
                }

                if (DtChk.Rows.Count > 0 && sPathSplit[1] != DtChk.Rows[0][1].ToString())
                {
                    panel1.Controls.Clear();
                    DtChk.Clear();
                }
            }


            if (e.Node.Level == 2)
            {
                string[] sPathCode = new string[6];
                string[] sPathSplit = e.Node.FullPath.Split('[');

                int ArrayIndex = 0;
                for (int i = 1; i < sPathSplit.Length; i++)
                {
                    string[] sPathSplit2 = sPathSplit[i].Split(']');
                    sPathCode[ArrayIndex] = sPathSplit2[0].Trim();
                    if (i == sPathSplit.Length - 1)
                    {
                        sPathCode[ArrayIndex + 1] = sPathSplit2[1].Substring(0, sPathSplit2[1].Length).Trim();
                    }
                    else
                    {
                        sPathCode[ArrayIndex + 1] = sPathSplit2[1].Substring(0, sPathSplit2[1].Length - 1).Trim();
                    }
                    ArrayIndex = ArrayIndex + 2;
                }

                DataRow[] arrRows = null;
                arrRows = DtChk.Select("PLANTCODE = '" + sPathCode[0] + "' AND ITEMCODE = '" + sPathCode[2] + "'" + " AND MESRCODE = '" + sPathCode[4] + "'");

                if (arrRows.Length > 0)
                {
                    for (int i = 0; i < Uc_Spc.Length; i++)
                    {
                        //if (Uc_Spc[i].PlantCode == sPathCode[0] && Uc_Spc[i].ItemCode == sPathCode[2] && Uc_Spc[i].MesrCode == sPathCode[4])
                        //{
                        //    Uc_Spc[i].PerformAction_btnMesrCnt();
                        //}
                    }
                }
                else
                {
                    if (DtChk.Rows.Count == 2)
                    {
                        DtChk.Rows.Remove(DtChk.Rows[0]);
                    }

                    DataRow dr = DtChk.NewRow();

                    dr["PLANTCODE"] = sPathCode[0];
                    dr["ITEMCODE"] = sPathCode[2];
                    dr["ITEMNAME"] = sPathCode[3];
                    dr["MESRCODE"] = sPathCode[4];
                    dr["MESRNAME"] = sPathCode[5];

                    DtChk.Rows.Add(dr);
                }

                Binding_UC_SPC();

                Control_Display();
            }
        }

        private void ultraSplitter1_Click(object sender, EventArgs e)
        {
            Control_Display();
        }

        private void ultraSplitter1_Move(object sender, EventArgs e)
        {
            Control_Display();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {

            for (int i = 0; i < Uc_Spc.Length; i++)
            {
                if (Uc_Spc[i] == null)
                {
                    break; ;
                }

                Uc_Spc[i].Width = panel1.Width;
            }
        }


        #endregion


    }
}
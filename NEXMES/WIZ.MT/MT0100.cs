#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MT0100Y
//   Form Name    : 작업장별 상태 현황(미집계 포함)
//   Name Space   : WIZ.MT
//   Created Date : 2014.08.29
//   Made By      : 여강기D
//   Description  : 경창산업 POP 화면과 동일하게 개발
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Forms;
#endregion

namespace WIZ.MT
{
    public partial class MT0100 : BaseMDIChildForm
    {
        #region < MEMEBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();         //COMMON 객체 생성

        DataSet rtnDsTemp = new DataSet();            //return DataSet 공통
        DataTable rtnDtTemp = new DataTable();          //return DataTable 공통

        DataTable _DtTemp = new DataTable();            //임시로 사용할 데이터테이블

        Hashtable hashXAXIS = new Hashtable();
        Hashtable hashYAXIS = new Hashtable();
        Hashtable hashWCData = new Hashtable();

        int inquireCnt = 0;                             //조회횟수 COUNT

        string SelPlantCode = string.Empty;
        string SelOpCode = string.Empty;
        string SelWorkCenterCode = string.Empty;

        UC_WorkCenter[] UcWC = new UC_WorkCenter[0];

        UC_WorkCenterC[] UcWCc = new UC_WorkCenterC[0];
        UC_WorkCenterC ucc;

        bool sMode = true;                              //True:Auto, False:Manual
        bool bStop = false;                             //모니터링 Timer STOP Flag
        Timer _timer;                                   //모니터링 조회 Timer

        #endregion


        #region < CONSTRUCTOR >
        public MT0100()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void MT0100Y_Load(object sender, EventArgs e)
        {
            #region ▶ Grid Setting ◀
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "RNUM", "NO", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTNAME", "사업장명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정코드", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RUNCNT", "가동라인", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDCNT", "정지라인", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWORKCNT", "무사유", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCNT", "비가동", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTALCNT", "총라인", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;  // RowSeletor Visible False

            // RNUM^0^50^0|PLANTCODE^1^120^1|PLANTNAME^2^57^0|WORKCENTERCODE^3^85^1|WORKCENTERNAME^4^65^0|ITEMCODE^5^101^0|ITEMNAME^6^130^0|ORDERNO^7^89^0|STARTDATE^8^131^0|ENDDATE^9^131^0|REASON^10^80^0|PRODQTY^11^80^0|ORDERQTY^12^80^0|WORKERNAMES^13^94^0|^^^^^|^^^^^|^^^^^
            _GridUtil.InitializeGrid(this.grid2, true, false, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "RNUM", "NO", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTNAME", "사업장명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "라인코드", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "라인명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ORDERNO", "계획번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STARTDATE", "시작시간", false, GridColDataType_emu.VarChar, 135, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ENDDATE", "종료시간", false, GridColDataType_emu.VarChar, 135, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REASON", "사유명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PRODQTY", "생산량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ORDERQTY", "계획량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ERRORITEMCODE", "부품결품", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ERRORMACHCODE", "설비고장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKERNAMES", "작업자", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            // RowSeletor Visible False
            this.grid2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            #region ▶ ComboBox Setting ◀
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("PLANTCODE", "10");
            #endregion
            cboPlantCode_H.Select();
        }

        private void MT0100_Deactivate(object sender, EventArgs e)
        {
            bStop = true;
        }

        private void MT0100_Activated(object sender, EventArgs e)
        {
            if (utcMonitoring.SelectedTab.Index == 1 && bStop == true)
            {
                bStop = false;
                _timer.Enabled = true;
            }
        }
        #endregion MT0100_Load


        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            if (Convert.ToString(this.cboPlantCode_H.Value) == string.Empty)
            {
                MessageBox.Show(Common.getLangText("사업장을 먼저 선택하세요.", "MSG"), "사업장 미선택", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value); //공장                                
                string sWorkCenterCode = Convert.ToString(txtOpCode.Tag);        //라인

                if (utcMonitoring.SelectedTab.Index == 0)
                {
                    rtnDtTemp = helper.FillTable("USP_MT0100_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input));
                }
                else if (utcMonitoring.SelectedTab.Index == 1)
                {
                    SelPlantCode = SelPlantCode.Length > 0 ? SelPlantCode : sPlantCode;
                    SelOpCode = txtOpCode.Text.Trim();

                    rtnDtTemp = helper.FillTable("USP_MT0100_S2", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input));
                }
                else if (utcMonitoring.SelectedTab.Index == 2)
                {
                    SelPlantCode = SelPlantCode.Length > 0 ? SelPlantCode : sPlantCode;
                    SelOpCode = txtOpCode.Text.Trim();

                    rtnDtTemp = helper.FillTable("USP_MT0150_S2", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input));
                }
                else
                {
                    if (SelWorkCenterCode == string.Empty) return;
                    _GridUtil.Grid_Clear(grid2);

                    rtnDtTemp = helper.FillTable("USP_MT0100_S3", CommandType.StoredProcedure
                                                 , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)      //공장
                                                 , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input));    //라인코드


                    SelWorkCenterCode = string.Empty;
                }
                _GridUtil.Grid_Clear(grid1);
                this.ClosePrgFormNew();
                if (rtnDtTemp.Rows.Count > 0)
                {
                    DataTable DtGrid = rtnDtTemp.Clone();

                    if (utcMonitoring.SelectedTab.Index == 0)
                    {
                        #region ▶ 라인별 가동현황(전체) ◀
                        // SUB-TOTAL 추가
                        // 기준 : ① PLANTCODE ② TOTAL
                        // 합계 : ① 비가동건수 ② 비가동 공수 ③ 손실 금액(원)
                        int pRNum = Convert.ToInt32(rtnDtTemp.Rows[0]["RNUM"]);
                        string pPlantCode = Convert.ToString(rtnDtTemp.Rows[0]["PLANTCODE"]);
                        string pPlantName = Convert.ToString(rtnDtTemp.Rows[0]["PLANTNAME"]);
                        string pBanCode = Convert.ToString(rtnDtTemp.Rows[0]["OPCODE"]);
                        string pBanName = Convert.ToString(rtnDtTemp.Rows[0]["OPNAME"]);

                        double pRunCnt = Convert.ToDouble(rtnDtTemp.Rows[0]["RUNCNT"]);
                        double pEndCnt = Convert.ToDouble(rtnDtTemp.Rows[0]["ENDCNT"]);
                        double pNoWorkCnt = Convert.ToDouble(rtnDtTemp.Rows[0]["NOWORKCNT"]);
                        double pStopCnt = Convert.ToDouble(rtnDtTemp.Rows[0]["STOPCNT"]);
                        double pTotalCnt = Convert.ToDouble(rtnDtTemp.Rows[0]["TOTALCNT"]);

                        double RunCnt = pRunCnt;
                        double EndCnt = pEndCnt;
                        double NoWorkCnt = pNoWorkCnt;
                        double StopCnt = pStopCnt;
                        double TotalCnt = pTotalCnt;

                        DtGrid.Rows.Add(new object[] { pRNum, pPlantCode, pPlantName, pBanCode, pBanName, pRunCnt, pEndCnt, pNoWorkCnt, pStopCnt, pTotalCnt });

                        for (int i = 1; i < rtnDtTemp.Rows.Count; i++)
                        {
                            int tRNum = Convert.ToInt32(rtnDtTemp.Rows[i]["RNUM"]);
                            string tPlantCode = Convert.ToString(rtnDtTemp.Rows[i]["PLANTCODE"]);
                            string tPlantName = Convert.ToString(rtnDtTemp.Rows[i]["PLANTNAME"]);
                            string tBanCode = Convert.ToString(rtnDtTemp.Rows[i]["OPCODE"]);
                            string tBanName = Convert.ToString(rtnDtTemp.Rows[i]["OPNAME"]);

                            double tRunCnt = Convert.ToDouble(rtnDtTemp.Rows[i]["RUNCNT"]);
                            double tEndCnt = Convert.ToDouble(rtnDtTemp.Rows[i]["ENDCNT"]);
                            double tNoWorkCnt = Convert.ToDouble(rtnDtTemp.Rows[i]["NOWORKCNT"]);
                            double tStopCnt = Convert.ToDouble(rtnDtTemp.Rows[i]["STOPCNT"]);
                            double tTotalCnt = Convert.ToDouble(rtnDtTemp.Rows[i]["TOTALCNT"]);

                            RunCnt = RunCnt + tRunCnt;
                            EndCnt = EndCnt + tEndCnt;
                            NoWorkCnt = NoWorkCnt + tNoWorkCnt;
                            StopCnt = StopCnt + tStopCnt;
                            TotalCnt = TotalCnt + tTotalCnt;

                            if (pPlantCode != tPlantCode)
                            {
                                DtGrid.Rows.Add(new object[] { null, null, null, pPlantName, " 합계 :", pRunCnt, pEndCnt, pNoWorkCnt, pStopCnt, pTotalCnt });

                                pPlantCode = Convert.ToString(rtnDtTemp.Rows[i]["PLANTCODE"]);
                                pPlantName = Convert.ToString(rtnDtTemp.Rows[i]["PLANTNAME"]);

                                pRunCnt = Convert.ToDouble(rtnDtTemp.Rows[i]["RUNCNT"]);
                                pEndCnt = Convert.ToDouble(rtnDtTemp.Rows[i]["ENDCNT"]);
                                pNoWorkCnt = Convert.ToDouble(rtnDtTemp.Rows[i]["NOWORKCNT"]);
                                pStopCnt = Convert.ToDouble(rtnDtTemp.Rows[i]["STOPCNT"]);
                                pTotalCnt = Convert.ToDouble(rtnDtTemp.Rows[i]["TOTALCNT"]);
                            }
                            else
                            {
                                pBanCode = Convert.ToString(rtnDtTemp.Rows[i]["OPCODE"]);
                                pBanName = Convert.ToString(rtnDtTemp.Rows[i]["OPNAME"]);

                                DtGrid.Rows.Add(new object[] { tRNum, tPlantCode, tPlantName, tBanCode, tBanName, tRunCnt, tEndCnt, tNoWorkCnt, tStopCnt, tTotalCnt });

                                pRunCnt = pRunCnt + tRunCnt;
                                pEndCnt = pEndCnt + tEndCnt;
                                pNoWorkCnt = pNoWorkCnt + tNoWorkCnt;
                                pStopCnt = pStopCnt + tStopCnt;
                                pTotalCnt = pTotalCnt + tTotalCnt;
                            }
                        }

                        DtGrid.Rows.Add(new object[] { null, null, null, pPlantName, " 합 계 :", pRunCnt, pEndCnt, pNoWorkCnt, pStopCnt, pTotalCnt });
                        DtGrid.Rows.Add(new object[] { null, null, null, null, "총 계 :", RunCnt, EndCnt, NoWorkCnt, StopCnt, TotalCnt });

                        grid1.DataSource = DtGrid;
                        grid1.DataBinds();

                        grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                        grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.Default;

                        grid1.DisplayLayout.Override.MergedCellAppearance.TextVAlign = VAlign.Top;
                        grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
                        #endregion
                    }
                    else if (utcMonitoring.SelectedTab.Index == 1)
                    {
                        #region ▶ 라인별 가동현황(모니터링) ◀
                        for (int i = 0; i < UcWC.Length; i++)
                        {
                            try
                            {
                                ultraTabPageControl3.Controls.RemoveByKey(UcWC[i].Name);
                            }
                            catch
                            {
                                UcWC = new UC_WorkCenter[0];
                                break;
                            }
                        }

                        int iLineCnt = rtnDtTemp.Rows.Count;

                        UcWC = new UC_WorkCenter[iLineCnt];

                        int wCnt = 5;
                        int hCnt = (iLineCnt / 5) + ((iLineCnt % 5) > 0 ? 1 : 0);

                        int x = 1;
                        int y = 1;
                        for (int i = 0; i < iLineCnt; i++)
                        {
                            string pWCCode = Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERCODE"]);

                            UC_WorkCenter uc = new UC_WorkCenter();
                            uc.Name = "UC" + pWCCode;
                            uc.WCData = rtnDtTemp.Rows[i];
                            uc.DoubleClick += new EventHandler(uc_DoubleClick);

                            ultraTabPageControl3.Controls.Add(uc);

                            uc.Location = new Point(x, y);
                            if (i == 0 || ((i + 1) % wCnt > 0))
                            {
                                x = x + uc.Width + 1;
                            }
                            else if (((i + 1) % wCnt) == 0)
                            {
                                x = 1;
                                y = y + uc.Height + 1;
                            }

                            UcWC[i] = uc;
                        }

                        ultraTabPageControl3.Refresh();
                        #endregion
                    }
                    else if (utcMonitoring.SelectedTab.Index == 2)
                    {
                        int wcCnt = rtnDtTemp.Rows.Count;

                        UcWCc = new UC_WorkCenterC[wcCnt];


                        for (int i = 0; i < wcCnt; i++)
                        {
                            string pWCCode = Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERCODE"]);

                            int Xaxis = Convert.ToInt32(rtnDtTemp.Rows[i]["XAXIS"]);
                            int Yaxis = Convert.ToInt32(rtnDtTemp.Rows[i]["YAXIS"]);

                            UC_WorkCenterC uc = new UC_WorkCenterC(hashXAXIS, hashYAXIS, hashWCData);

                            uc.Name = "UC" + pWCCode;
                            uc.WCData = rtnDtTemp.Rows[i];
                            uc.Location = new Point(Xaxis, Yaxis);

                            UcWCc[i] = uc;


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
                    }
                    else
                    {
                        #region ▶ 라인별 가동현황(라인별 상세 현황) ◀
                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBind();

                        grid2.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                        grid2.DisplayLayout.Bands[0].Columns["PLANTNAME"].MergedCellStyle = MergedCellStyle.Always;
                        grid2.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
                        grid2.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;

                        grid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                        grid2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.Default;

                        grid2.DisplayLayout.Override.MergedCellAppearance.TextVAlign = VAlign.Top;
                        grid2.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
                        #endregion
                    }
                }
                else
                {
                    #region ▶ TAB별 데이터 CLEAR ◀
                    if (utcMonitoring.SelectedTab.Index == 0)
                    {
                        _GridUtil.Grid_Clear(grid1);
                    }
                    else if (utcMonitoring.SelectedTab.Index == 1)
                    {
                        for (int i = 0; i < UcWC.Length; i++)
                        {
                            try
                            {
                                ultraTabPageControl3.Controls.RemoveByKey(UcWC[i].Name);
                            }
                            catch
                            {
                                UcWC = new UC_WorkCenter[0];
                                break;
                            }
                        }
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid2);
                    }

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);    //조회할 데이터가 없습니다.
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

        /// <summary>
        /// 라인별 가동현황(모니터링) 화면에서 라인 더블클릭 시 상세현황 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uc_DoubleClick(object sender, EventArgs e)
        {
            //SelWorkCenterCode = Convert.ToString(((UC_WorkCenter)sender).WCData["WORKCENTERCODE"]);

            //if (SelWorkCenterCode == string.Empty) return;

            //utcMonitoring.SelectedTab = utcMonitoring.Tabs[2];
            //DoInquire();
        }

        public override void DoDownloadExcel()
        {
            //base.DoDownloadExcel();

            //WIZ.REPORT.ExcelManager excel = new WIZ.REPORT.ExcelManager();

            //if (this.utcMonitoring.SelectedTab.Index == 0)
            //    excel.DownloadExcel(this.grid1, this.Name, false);
            //else if (this.utcMonitoring.SelectedTab.Index == 2)
            //    excel.DownloadExcel(this.grid2, this.Name, false);
            //else
            //    MessageBox.Show("다운로드 할 그리드를 선택하신 뒤 진행하십시오", "다운로드 대상 선택", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        #endregion


        #region < USER EVENTS >

        #region ▶ GRID ◀
        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Appearance.BackColor = Color.White;

            if (Convert.ToString(e.Row.Cells["RNUM"].Value) == string.Empty)
            {
                if (Convert.ToString(e.Row.Cells["OPCODE"].Value) != string.Empty)
                    e.Row.Cells["OPCODE"].Appearance.BackColor = Color.FromArgb(254, 252, 177);

                e.Row.Cells["OPNAME"].Appearance.BackColor = Color.FromArgb(254, 252, 177);
                e.Row.Cells["RUNCNT"].Appearance.BackColor = Color.FromArgb(254, 252, 177);
                e.Row.Cells["ENDCNT"].Appearance.BackColor = Color.FromArgb(254, 252, 177);
                e.Row.Cells["NOWORKCNT"].Appearance.BackColor = Color.FromArgb(254, 252, 177);
                e.Row.Cells["STOPCNT"].Appearance.BackColor = Color.FromArgb(254, 252, 177);
                e.Row.Cells["TOTALCNT"].Appearance.BackColor = Color.FromArgb(254, 252, 177);

                e.Row.Cells["OPCODE"].Appearance.FontData.Bold = DefaultableBoolean.True;
                e.Row.Cells["OPNAME"].Appearance.FontData.Bold = DefaultableBoolean.True;
                e.Row.Cells["RUNCNT"].Appearance.FontData.Bold = DefaultableBoolean.True;
                e.Row.Cells["ENDCNT"].Appearance.FontData.Bold = DefaultableBoolean.True;
                e.Row.Cells["NOWORKCNT"].Appearance.FontData.Bold = DefaultableBoolean.True;
                e.Row.Cells["STOPCNT"].Appearance.FontData.Bold = DefaultableBoolean.True;
                e.Row.Cells["TOTALCNT"].Appearance.FontData.Bold = DefaultableBoolean.True;

                e.Row.Cells["OPNAME"].Appearance.TextHAlign = HAlign.Right;
            }
            else
            {
                e.Row.Appearance.BackColor = Color.White;
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.False;
            }
        }


        #endregion

        #region ▶ COMBOBOX ◀


        #endregion

        #region ▶ TABCONTROL ◀
        private void ultraTabPageControl3_MouseEnter(object sender, EventArgs e)
        {
            if (ultraTabPageControl3.Focused == false)
                ultraTabPageControl3.Focus();
        }

        private void ultraTabControl2_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            switch (utcMonitoring.SelectedTab.Index)
            {
                case 0:
                case 3:
                    gbxRemark.Visible = false;
                    gbxRemark2.Visible = false;
                    gbxMAS.Visible = false;
                    bStop = true;

                    if (_timer != null)
                        _timer.Enabled = false;
                    break;
                case 1:
                    gbxRemark.Visible = true;
                    gbxRemark2.Visible = false;
                    gbxMAS.Visible = true;
                    bStop = false;

                    if (_timer == null)
                    {
                        _timer = new Timer();
                        _timer.Tick += new EventHandler(_timer_Tick);
                        _timer.Interval = Convert.ToInt32(nupSearchTime.Value) * 1000;
                    }

                    _timer.Enabled = true;
                    break;
                case 2:
                    gbxRemark.Visible = false;
                    gbxRemark2.Visible = true;
                    gbxMAS.Visible = true;
                    bStop = false;

                    if (_timer == null)
                    {
                        _timer = new Timer();
                        _timer.Tick += new EventHandler(_timer_Tick);
                        _timer.Interval = Convert.ToInt32(nupSearchTime.Value) * 1000;
                    }
                    break;
            }

            // 탭선택 시 재조회
            if (Convert.ToString(this.cboPlantCode_H.Value) != string.Empty)
                DoInquire();
        }
        #endregion

        #region ▶ TIMER ◀
        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Enabled = false;

            try
            {
                if (utcMonitoring.SelectedTab.Index == 1 && bStop == false)
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
        #endregion

        #region ▶ BUTTON ◀
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
        #endregion

        #endregion


        #region < FUNCTION AREA >
        private void txtWcCode_ButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    string[] values = { Convert.ToString(cboPlantCode_H.Value), "", "", "", "", "" };
            //    POP_TBM0600 _frmA = new POP_TBM0600(values);
            //    _frmA.ShowDialog();
            //    rtnDtTemp = (DataTable)_frmA.Tag;
            //    if (rtnDtTemp.Rows.Count > 0)
            //    {
            //        txtOpCode.Text = Convert.ToString(rtnDtTemp.Rows[0][0]);
            //        txtOpName.Text = Convert.ToString(rtnDtTemp.Rows[0][1]);
            //    }
            //    _frmA.Dispose();
            //}
            //catch
            //{
            //}
        }

        private void txtWcCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txtOpCode.Tag = null;
                txtOpCode.Text = string.Empty;
                txtOpName.Text = string.Empty;
            }
        }
        #endregion

        private void grid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SelPlantCode = Convert.ToString(e.Row.Cells["PLANTCODE"].Value);
            SelOpCode = Convert.ToString(e.Row.Cells["OPCODE"].Value);

            if (SelPlantCode == string.Empty || SelOpCode == string.Empty) return;

            cboPlantCode_H.Value = SelPlantCode;
            txtOpCode.Text = Convert.ToString(e.Row.Cells["OPCODE"].Value);
            txtOpCode.Tag = Convert.ToString(e.Row.Cells["OPCODE"].Value);
            txtOpName.Text = Convert.ToString(e.Row.Cells["OPNAME"].Value);

            utcMonitoring.SelectedTab = utcMonitoring.Tabs[1];

            //tabControl1.SelectedIndex = 1;
            DoInquire();
        }

        private void addPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ucc = new UC_WorkCenterC(hashXAXIS, hashYAXIS, hashWCData);
            DoDragDrop(ucc, DragDropEffects.Copy);
        }

        private void mainPnl_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void mainPnl_DragDrop(object sender, DragEventArgs e)
        {
            int pointX = e.X;
            int pointY = e.Y - gbxHeader.Height - 20;

            ucc.Location = PointToClient(new Point(pointX, pointY));

            mainPnl.Controls.Add(ucc);
        }

        private void addHash(Hashtable hash, object key, object value)
        {
            if (!hash.ContainsKey(key))
            {
                hash.Add(key, value);
            }
        }

    }
}
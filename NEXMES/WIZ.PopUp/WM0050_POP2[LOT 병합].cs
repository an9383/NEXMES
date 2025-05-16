using System;
using System.Data;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class WM0050_POP2 : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        private string sPlantCode = string.Empty;                   //공장
        private string sWHCode = string.Empty;                   //창고
        private string sStorageLocCode = string.Empty;                   //저장위치
        private string sItemCode = string.Empty;                   //품목
        private string sItemName = string.Empty;                   //품목명
        private string sLotNo = string.Empty;                   //LOTNO
        private string sQty = string.Empty;                   //발주량(A)
        private string sUnitCode = string.Empty;                   //단위
        DataTable DtChange1 = new DataTable();
        DataTable rtnDtTemp = new DataTable();
        Common _Common = new Common();
        private double dTotalSumQty = 0;

        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        WIZ.PopUp.DA3300_LOTC WM0050_POP2_TELDA3300_LOTC; //원자재 식별표
        WIZ.PopUp.DA3300_LOTG DA3300_LOTG; //재공품 식별표
        WIZ.PopUp.DA3300_LOTZ DA3300_LOTZ; //완제품 식별표

        WM0050_POP2_TEL WM0050_POP2_TEL;

        #endregion

        #region [ 생성자 ]

        public WM0050_POP2(string PlantCode, WIZ.Control.Grid Grid1)
        {
            InitializeComponent();
            DtChange1 = (DataTable)Grid1.DataSource;
            Extract_GridData();
            sPlantCode = PlantCode;

        }
        #endregion

        #region [ Form Load ]
        private void WM0050_POP2_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE", "입고일자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false);

            grid1.Columns["NOWQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid1);

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0080_CODE("");  //창고
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0090_CODE("");  //저장위치
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STORAGELOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            this.grid1.DataSource = DtChange1;
            this.txt_PLANTCODE_H.Value = DtChange1.Rows[0]["PLANTCODE"].ToString();
            this.txt_WCCODE_H.Text = DtChange1.Rows[0]["WHCODE"].ToString();
            this.txt_STORAGELOCCODE_H.Text = DtChange1.Rows[0]["STORAGELOCCODE"].ToString();
            this.txt_ITEMCODE_H.Text = DtChange1.Rows[0]["ITEMCODE"].ToString();
            this.txt_ITEMNAME_H.Text = DtChange1.Rows[0]["ITEMNAME"].ToString();

            double dNowQtySum = 0;

            for (int i = 0; i < DtChange1.Rows.Count; i++)
            {
                dNowQtySum = dNowQtySum + Convert.ToDouble(DtChange1.Rows[i]["NOWQTY"].ToString());
            }
            this.txt_QTY_H.Text = Convert.ToString(dNowQtySum);
            this.txt_UNITCODE_H.Text = DtChange1.Rows[0]["UNITCODE"].ToString();

            GetWHCODE();
        }

        #endregion

        #region < MATHOD AREA >
        private void Extract_GridData()
        {
            double dQty = 0;
            foreach (DataRow drGrid in DtChange1.Rows)
            {
                if (drGrid["CHK"].ToString().ToUpper() != "TRUE")
                {
                    drGrid.Delete();
                }
                else
                {
                    dQty = dQty + Convert.ToInt32(drGrid["NOWQTY"]);

                }
            }
            dTotalSumQty = dQty;
            DtChange1.AcceptChanges();
        }
        #endregion

        #region [ EVENT AREA ]
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DoPrint();
        }

        //수정필요
        private void DoPrint()
        {
            if (this.txt_LOTNO_H.Text.ToString() == "")
            {
                MessageBox.Show(Common.getLangText("병합 등록 후, 바코드 발행이 가능합니다.", "MSG"));
                return;
            }

            string sPlantCode1 = sPlantCode;             // 사업장
            string sLotno = this.txt_LOTNO_H.Text.ToString();

            //라벨출력
            SendPrint(sPlantCode, sLotno);

        }

        private void SendPrint(string sPlantCode, string sLotno)
        {
            //시리얼 열기
            //openSerial();

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_WM0050_POP2_S1"
                                                          , CommandType.StoredProcedure
                                                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("AS_LOTNO", sLotno, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rb_ZBPRINT_B.Checked == true)
                    {
                        //openSerial();

                        Thread.Sleep(500);

                        StringBuilder command = new StringBuilder();

                        command.AppendLine("^XA");
                        command.AppendLine("^LH0,0^LL500^XZ");
                        command.AppendLine("^XA");
                        command.AppendLine("^SEE:UHANGUL.DAT^FS");
                        command.AppendLine("^CW1,E:KFONT3.FNT^CI26^FS");


                        command.AppendLine("^FO" + "15, 30" + "^GB" + "680, 920, 3" + "^FS"); //전체 박스

                        command.AppendLine("^FO" + "140, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 1
                        command.AppendLine("^FO" + "300, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 2
                        command.AppendLine("^FO" + "360, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 3
                        command.AppendLine("^FO" + "420, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 4
                        command.AppendLine("^FO" + "480, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 5
                        command.AppendLine("^FO" + "540, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 6
                        command.AppendLine("^FO" + "600, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 7

                        command.AppendLine("^FO" + "15,  220" + "^GB" + "125,  1, 2" + "^FS"); //가로줄 1
                        command.AppendLine("^FO" + "300, 220" + "^GB" + "300, 1, 2" + "^FS");  //가로줄 2
                        command.AppendLine("^FO" + "300, 485" + "^GB" + "120, 1, 2" + "^FS");  //가로줄 3
                        command.AppendLine("^FO" + "480, 485" + "^GB" + "120, 1, 2" + "^FS");  //가로줄 4
                        command.AppendLine("^FO" + "300, 690" + "^GB" + "120, 1, 2" + "^FS");  //가로줄 5
                        command.AppendLine("^FO" + "480, 690" + "^GB" + "120, 1, 2" + "^FS");  //가로줄 6

                        command.AppendLine("^FO" + "625, 45" + "^A1R, 40, 40" + " ^FD" + "완제품 식별표" + "^FS");
                        command.AppendLine("^FO" + "625, 740" + "^A1R, 40, 40" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["PLANTNAME"]) + "^FS");

                        command.AppendLine("^FO" + "555, 70" + "^A1R, 30, 30" + " ^FD" + "LOT No" + "^FS");
                        command.AppendLine("^FO" + "555, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["LOTNO"]) + "^FS");

                        command.AppendLine("^FO" + "555, 530" + "^A1R, 30, 30" + " ^FD" + "입고일자" + "^FS");
                        command.AppendLine("^FO" + "555, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["INDATE"]) + "^FS");

                        command.AppendLine("^FO" + "495, 70" + "^A1R, 30, 30" + " ^FD" + "품목유형" + "^FS");
                        command.AppendLine("^FO" + "495, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMTYPE"]) + "^FS");

                        command.AppendLine("^FO" + "495, 530" + "^A1R, 30, 30" + " ^FD" + "품목코드" + "^FS");
                        command.AppendLine("^FO" + "495, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMCODE"]) + "^FS");

                        command.AppendLine("^FO" + "435, 70" + "^A1R, 30, 30" + " ^FD" + "품 목 명" + "^FS");

                        if (Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]).Length < 30)
                            command.AppendLine("^FO" + "435, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]) + "^FS");
                        else if (Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]).Length < 60)
                            command.AppendLine("^FO" + "435, 230" + "^A1R, 30, 20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]) + "^FS");
                        else
                            command.AppendLine("^FO" + "435, 230" + "^A1R, 30, 20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]) + "^FS");

                        command.AppendLine("^FO" + "375, 70" + "^A1R, 30, 30" + " ^FD" + "창 고 명" + "^FS");
                        command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["WHNAME"]) + "^FS");

                        command.AppendLine("^FO" + "375, 530" + "^A1R, 30, 30" + " ^FD" + "수    량" + "^FS");
                        command.AppendLine("^FO" + "375, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["NOWQTY"]) + "^FS");

                        command.AppendLine("^FO" + "315, 70" + "^A1R, 30, 30" + " ^FD" + "위 치 명" + "^FS");
                        command.AppendLine("^FO" + "315, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["STORAGELOCNAME"]) + "^FS");

                        //command.AppendLine("^FO" + "315, 530" + "^A1R, 30, 30" + " ^FD" + "작업장명" + "^FS";
                        //command.AppendLine("^FO" + "315, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["CUSTNAME"]) + "^FS";

                        command.AppendLine("^FO" + "190, 210" + "^BY3,4^BCR," + "80,Y,N,N" + "^FD" + Convert.ToString(rtnDtTemp.Rows[0]["LOTNO"]) + "^FS");

                        command.AppendLine("^FO" + "60, 65" + "^A1R, 30, 30" + " ^FD" + "비    고" + "^FS");
                        command.AppendLine("^FO" + "60, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["REMARK"]) + "^FS");

                        command.AppendLine("^XZ");

                        WIZ.Common.SendStringToBytePrinter("ZT410", command.ToString());

                        //byte[] b = Encoding.Default.GetBytes(command.ToString());
                        //serialPort1.Write(b, 0, b.Length);
                    }
                    else
                    {
                        //텔레릭 레포트로 출력시
                        //rtnDtTemp 데이터바인딩
                        WM0050_POP2_TEL = new WM0050_POP2_TEL();
                        objectDataSource.DataSource = rtnDtTemp;
                        WM0050_POP2_TEL.DataSource = objectDataSource;
                        viewerInstance.ReportDocument = WM0050_POP2_TEL.Report;

                        //레포트 뷰어
                        //ReportViewer.ReportSource = viewerInstance;
                        //ReportViewer.RefreshReport();

                        //뷰어 없이 바로 출력
                        Telerik.Reporting.IReportDocument myReport = new WM0050_POP2_TEL();
                        System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                        System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
                        Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

                        reportProcessor.PrintController = standardPrintController;
                        printerSettings.Collate = true;
                        reportProcessor.PrintReport(viewerInstance, printerSettings);
                    }
                }
                else
                {
                    MessageBox.Show(helper.RSMSG);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //serialPort1.Close();
                helper.Close();
            }
        }

        /// <summary>
        /// OpenSerial
        /// </summary>
        private void openSerial()
        {
            if (serialPort1.IsOpen) serialPort1.Close(); // 시리얼포트가 열려있으면 닫기 위함

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_GET_SERAILPORT"
                                                          , CommandType.StoredProcedure
                                                          , helper.CreateParameter("@AS_MACHNAME", "ZEBRA", DbType.String, ParameterDirection.Input));

                serialPort1.PortName = Convert.ToString(rtnDtTemp.Rows[0]["PORTNAME"]);
                serialPort1.BaudRate = Convert.ToInt32(rtnDtTemp.Rows[0]["BAUDRATE"]);
                serialPort1.DataBits = Convert.ToInt32(rtnDtTemp.Rows[0]["DATABITS"]);

                if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.None")
                {
                    serialPort1.Parity = Parity.None;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Even")
                {
                    serialPort1.Parity = Parity.Even;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Mark")
                {
                    serialPort1.Parity = Parity.Mark;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Odd")
                {
                    serialPort1.Parity = Parity.Odd;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Space")
                {
                    serialPort1.Parity = Parity.Space;
                }

                if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.None")
                {
                    serialPort1.StopBits = StopBits.None;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.One")
                {
                    serialPort1.StopBits = StopBits.One;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.OnePointFive")
                {
                    serialPort1.StopBits = StopBits.OnePointFive;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.Two")
                {
                    serialPort1.StopBits = StopBits.Two;
                }

                serialPort1.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //LOT 수량 계산
            DBHelper helper = new DBHelper("", true);
            string RS_MSG = string.Empty;
            string RS_CODE = string.Empty;

            DialogResult result = MessageBox.Show(Common.getLangText("LOT 병합 하시겠습니까 ?", "MSG"), Common.getLangText("LOT 병합", "MSG"), MessageBoxButtons.YesNo);
            if (result.ToString().ToUpper() == "NO") return;
            try
            {
                //저장문의 메세지 필요?
                this.grid1.UpdateData();

                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    sLotNo = this.grid1.Rows[i].Cells["LOTNO"].Value.ToString();
                    // 병합 대상 출고
                    helper.ExecuteNoneQuery("USP_WM0050_POP2_I1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_WHCODE", DBHelper.nvlString(this.cbo_WCCODE_H.Value), DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_STORAGELOCCODE", DBHelper.nvlString(this.cbo_STORAGELOCCODE_H.Value), DbType.String, ParameterDirection.Input));
                    if (helper.RSCODE != "S")
                    {
                        MessageBox.Show(Common.getLangText("LOT 병합을 실패하였습니다.", "MSG") + Environment.NewLine + helper.RSMSG, Common.getLangText("LOT 병합 실패", "MSG"));
                        helper.Rollback();
                        return;
                    }
                }
                // 신규 Lot 등록
                string sItemCode = this.txt_ITEMCODE_H.Text.ToString();
                string sInQty = this.txt_QTY_H.Text.ToString();
                string sUnitCode = this.txt_UNITCODE_H.Text.ToString();
                string sFrwhcode = this.grid1.Rows[0].Cells["WHCODE"].Value.ToString();
                string sFrStoragrLocCode = this.grid1.Rows[0].Cells["STORAGELOCCODE"].Value.ToString();



                helper.ExecuteNoneQuery("USP_WM0050_POP2_I2", CommandType.StoredProcedure
                                                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AF_INQTY", DBHelper.nvlDouble(sInQty), DbType.Double, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_FRWHCODE", sFrwhcode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_FRSTORAGELOCCODE", sFrStoragrLocCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_WHCODE", DBHelper.nvlString(this.cbo_WCCODE_H.Value), DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_STORAGELOCCODE", DBHelper.nvlString(this.cbo_STORAGELOCCODE_H.Value), DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {

                    MessageBox.Show(Common.getLangText("LOT 병합을 성공하였습니다.", "MSG"), Common.getLangText("LOT 병합 성공", "MSG"));
                    helper.Commit();
                    this.txt_LOTNO_H.Text = helper.RSMSG.ToString();

                    //등록시 발행
                    if (chk_PRINT_H.Checked == true)
                    {
                        DoPrint();
                    }
                }
                else
                {
                    MessageBox.Show(Common.getLangText("LOT 병합을 실패하였습니다.", "MSG") + Environment.NewLine + helper.RSMSG, Common.getLangText("LOT 병합 실패", "MSG"));
                    helper.Rollback();
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                RS_CODE = "E";
                MessageBox.Show(Common.getLangText("LOT 병합을 실패하였습니다.", "MSG") + Environment.NewLine + helper.RSMSG, Common.getLangText("LOT 병합 실패", "MSG"));
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        private void GetWHCODE()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT WHCODE                           AS CODE_ID, ");
                command.AppendLine("       '['+ WHCODE +']' + WHNAME        AS CODE_NAME");
                command.AppendLine("  FROM BM0080                                           ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND PLANTCODE = '" + txt_PLANTCODE_H.Value.ToString() + "' ");
                command.AppendLine("   AND WHTYPE  = 'WH002' ");
                command.AppendLine(" ORDER BY PLANTCODE, WHCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(this.cbo_WCCODE_H, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, "");
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

        private void cboWhCode_B_ValueChanged(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT STORAGELOCCODE                                 AS CODE_ID, ");
                command.AppendLine("       '['+ STORAGELOCCODE +']' + STORAGELOCNAME      AS CODE_NAME");
                command.AppendLine("  FROM BM0090                                          ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND WHCODE like  '" + this.cbo_WCCODE_H.Value + "' + '%'");
                command.AppendLine(" ORDER BY WHCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(this.cbo_STORAGELOCCODE_H, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, "");
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

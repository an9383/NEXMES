#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0000_POP
//   Form Name    : 창고 및 위치
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 창고 및 위치 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace WIZ.PopUp
{
    public partial class WM0000_POP : Form
    {
        #region < MEMBER AREA >

        private string _sFlag; // "Y" = 검사 후 입고, "N" = 입고 후 검사

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();

        DataSet rtnDsTemp = new DataSet();

        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        WM0060_POP_TEL WM0060_POP_TEL; //완제품 식별표

        #endregion

        #region < CONSTRUCTOR >
        public WM0000_POP()
        {
            InitializeComponent();
        }

        public WM0000_POP(string sItemCode, string sItemName, string sBoxQty, double dTotQty, string sFlag)
        {
            InitializeComponent();
            int iQty = 0;
            int.TryParse(sBoxQty, out iQty);

            txt_ITEMCODE.Text = sItemCode;
            txt_ITEMNAME.Text = sItemName;
            txt_BOXQTY.Text = (iQty <= 0) ? dTotQty.ToString() : sBoxQty;
            txt_LOTCNT.Text = Convert.ToString(Convert.ToInt32(dTotQty) / Convert.ToInt32(txt_BOXQTY.Text));
            txt_TOTQTY.Text = Convert.ToString(Convert.ToInt32(txt_BOXQTY.Text.Trim()) * Convert.ToInt32(txt_LOTCNT.Text.Trim()));

            _sFlag = sFlag;

            for (int i = 0; i < 4; i++)
            {
                rtnDtTemp2.Columns.Add("PLANTNAME" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("LOTNO" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("INDATE" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("ITEMTYPE" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("ITEMCODE" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("ITEMNAME" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("NOWQTY" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("WHNAME" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("STORAGELOCNAME" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("REMARK" + Convert.ToString(i + 1));
            }

            if (sFlag == "Y")
            {
                lbl_WHCODE.Visible = false;
                lbl_LOCCODE.Visible = false;
                cbo_WHCODE.Visible = false;
                cbo_LOCCODE.Visible = false;
            }
            else
            {
                lbl_WHCODE.Visible = true;
                lbl_LOCCODE.Visible = true;
                cbo_WHCODE.Visible = true;
                cbo_LOCCODE.Visible = true;

                GetWhCode();
            }
        }
        #endregion

        #region < FORM LOAD >


        #endregion

        #region < EVENT AREA >

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DoPrint(LoadPrtTarget());
        }

        private void cbo_WHCODE_ValueChanged(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                string sWhCode = Convert.ToString(cbo_WHCODE.Value);

                DataTable _dt = new DataTable();
                _dt = helper.FillTable("USP_WM0000_POP_S2", CommandType.StoredProcedure
                                                          , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    WIZ.Common.FillComboboxMaster(cbo_LOCCODE, _dt, "STORAGELOCCODE", "STORAGELOCNAME", "선택하세요", "");
                }
                else if (helper.RSCODE == "E")
                {
                    MessageBox.Show(helper.RSMSG);
                }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_sFlag == "N")
            {
                if (Convert.ToString(cbo_WHCODE.Value) == string.Empty)
                {
                    MessageBox.Show(Common.getLangText("입고 창고를 선택해주세요."));
                    return;
                }

                if (Convert.ToString(cbo_LOCCODE.Value) == string.Empty)
                {
                    MessageBox.Show(Common.getLangText("입고 위치를 선택해주세요."));
                    return;
                }
            }

            this.Close();
        }


        #endregion

        #region < USER METHOD AREA >
        private void GetWhCode()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = new DataTable();

                rtnDtTemp = helper.FillTable("USP_WM0000_POP_S3", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_WHTYPE", "WH002", DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    WIZ.Common.FillComboboxMaster(cbo_WHCODE, rtnDtTemp, "WHCODE", "WHNAME", "선택하세요", "");
                }
                else if (helper.RSCODE == "E")
                {
                    MessageBox.Show(helper.RSMSG);
                }
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

        private DataTable LoadPrtTarget()
        {
            DBHelper helper = new DBHelper(false);

            string sPlantCode = LoginInfo.PlantCode;

            try
            {
                rtnDtTemp = helper.FillTable("USP_WM0000_POP_S1", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                return rtnDtTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return rtnDtTemp;
            }
            finally
            {
                helper.Close();
            }
        }

        private void DoPrint(DataTable dtTarget)
        {
            try
            {
                if (rb_ZBPRINT_B.Checked)
                {
                    //OpenSerial();

                    for (int i = 0; i < dtTarget.Rows.Count; i++)
                    {
                        Thread.Sleep(500);

                        StringBuilder command = new StringBuilder();

                        command.AppendLine("^XA");
                        command.AppendLine("^LH0,0^LL500^XZ");
                        command.AppendLine("^XA");
                        command.AppendLine("^SEE:UHANGUL.DAT^FS");
                        command.AppendLine("^CW1,E:KFONT3.FNT^CI26^FS");


                        command.AppendLine("^FO" + "15, 30" + "^GB" + "680, 920, 3" + "^FS"); //전체 박스

                        command.AppendLine("^FO" + "140, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 1
                        //command.AppendLine("^FO" + "300, 30" + "^GB" + "1, 920, 2" + "^FS"; //세로줄 2
                        command.AppendLine("^FO" + "360, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 3
                        command.AppendLine("^FO" + "420, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 4
                        command.AppendLine("^FO" + "480, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 5
                        command.AppendLine("^FO" + "540, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 6
                        command.AppendLine("^FO" + "600, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 7

                        command.AppendLine("^FO" + "15,  220" + "^GB" + "125, 1, 2" + "^FS"); //가로줄 1
                        command.AppendLine("^FO" + "360, 220" + "^GB" + "240, 1, 2" + "^FS"); //가로줄 2
                        //command.AppendLine("^FO" + "300, 485" + "^GB" + "60,  1, 2" + "^FS"; //가로줄 3
                        command.AppendLine("^FO" + "480, 485" + "^GB" + "120, 1, 2" + "^FS"); //가로줄 4
                        //command.AppendLine("^FO" + "300, 690" + "^GB" + "60,  1, 2" + "^FS"; //가로줄 5
                        command.AppendLine("^FO" + "480, 690" + "^GB" + "120, 1, 2" + "^FS"); //가로줄 6

                        command.AppendLine("^FO" + "625, 45" + "^A1R, 40, 40" + " ^FD" + "완제품 식별표" + "^FS");
                        command.AppendLine("^FO" + "625, 740" + "^A1R, 40, 40" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["PLANTNAME"]) + "^FS");

                        command.AppendLine("^FO" + "555, 70" + "^A1R, 30, 30" + " ^FD" + "LOT No" + "^FS");
                        command.AppendLine("^FO" + "555, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["LOTNO"]) + "^FS");

                        command.AppendLine("^FO" + "555, 515" + "^A1R, 30, 30" + " ^FD" + "가입고일자" + "^FS");
                        command.AppendLine("^FO" + "555, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["TMPINDATE"]) + "^FS");

                        command.AppendLine("^FO" + "495, 70" + "^A1R, 30, 30" + " ^FD" + "품목유형" + "^FS");
                        command.AppendLine("^FO" + "495, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMTYPE"]) + "^FS");

                        command.AppendLine("^FO" + "495, 530" + "^A1R, 30, 30" + " ^FD" + "수    량" + "^FS");
                        command.AppendLine("^FO" + "495, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["NOWQTY"]) + "^FS");

                        command.AppendLine("^FO" + "435, 70" + "^A1R, 30, 30" + " ^FD" + "품목코드" + "^FS");
                        command.AppendLine("^FO" + "435, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]) + "^FS");

                        command.AppendLine("^FO" + "375, 70" + "^A1R, 30, 30" + " ^FD" + "품 목 명" + "^FS");
                        if (Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]).Length < 30)
                            command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]) + "^FS");
                        else if (Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]).Length < 60)
                            command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]) + "^FS");
                        else
                            command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]) + "^FS");


                        command.AppendLine("^FO" + "225, 210" + "^BY3,4^BCR," + "80,Y,N,N" + "^FD" + Convert.ToString(rtnDtTemp.Rows[i]["LOTNO"]) + "^FS");

                        command.AppendLine("^FO" + "60, 65" + "^A1R, 30, 30" + " ^FD" + "비    고" + "^FS");
                        command.AppendLine("^FO" + "60, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["REMARK"]) + "^FS");

                        command.AppendLine("^XZ");

                        WIZ.Common.SendStringToBytePrinter("ZT410", command.ToString());

                        //byte[] b = Encoding.Default.GetBytes(command.ToString());
                        //serialPort1.Write(b, 0, b.Length);
                    }

                    //serialPort1.Close();
                }
                else if (rb_NMPRINT_B.Checked)
                {
                    int iPrintCnt = 1;
                    int iColCnt = 0;

                    DataRow dRow = rtnDtTemp2.NewRow();


                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    {
                        dRow["PLANTNAME" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["PLANTNAME"];
                        dRow["LOTNO" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["LOTNO"];
                        dRow["INDATE" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["TMPINDATE"];
                        dRow["ITEMTYPE" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["ITEMTYPE"];
                        dRow["ITEMCODE" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["ITEMCODE"];
                        dRow["ITEMNAME" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["ITEMNAME"];
                        dRow["NOWQTY" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["NOWQTY"];
                        dRow["WHNAME" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["WHNAME"];
                        dRow["STORAGELOCNAME" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["STORAGELOCNAME"];
                        dRow["REMARK" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["REMARK"];

                        if (iPrintCnt == rtnDtTemp.Rows.Count || iPrintCnt % 4 == 0)
                        {
                            rtnDtTemp2.Rows.Add(dRow);

                            //텔레릭 레포트로 출력시
                            //rtnDtTemp 데이터바인딩
                            WM0060_POP_TEL = new WM0060_POP_TEL();
                            objectDataSource.DataSource = rtnDtTemp2;
                            WM0060_POP_TEL.DataSource = objectDataSource;
                            viewerInstance.ReportDocument = WM0060_POP_TEL.Report;

                            //레포트 뷰어
                            //ReportViewer.ReportSource = viewerInstance;
                            //ReportViewer.RefreshReport();

                            //뷰어 없이 바로 출력
                            Telerik.Reporting.IReportDocument myReport = new WM0060_POP_TEL();
                            System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                            System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
                            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

                            reportProcessor.PrintController = standardPrintController;
                            printerSettings.Collate = true;
                            reportProcessor.PrintReport(viewerInstance, printerSettings);

                            rtnDtTemp2.Rows.RemoveAt(0);
                            iColCnt = -1;
                        }

                        iPrintCnt++;
                        iColCnt++;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }

        private void WM0000_POP_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateLotStatus();
        }

        private void OpenSerial()
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

        private void UpdateLotStatus()
        {
            DBHelper helper = new DBHelper("", true);

            string sWhCode = Convert.ToString(cbo_WHCODE.Value);
            string sLocCode = Convert.ToString(cbo_LOCCODE.Value);

            try
            {
                helper.ExecuteNoneQuery("USP_WM0000_POP_U1", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_LOCCODE", sLocCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_FLAG", _sFlag, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE != "S")
                {
                    helper.Rollback();
                    MessageBox.Show(helper.RSMSG);
                }
                else
                {
                    helper.Commit();
                }
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



        #endregion


    }
}

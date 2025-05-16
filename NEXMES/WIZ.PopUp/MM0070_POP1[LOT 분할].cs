using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class MM0070_POP1 : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();
        private string sPlantCode = string.Empty;                   //공장
        private string sWHCode = string.Empty;                   //창고
        private string sStorageLocCode = string.Empty;                   //저장위치
        private string sItemCode = string.Empty;                   //품목
        private string sItemName = string.Empty;                   //품목명
        private string sLotNo = string.Empty;                   //LOTNO
        private string sQty = string.Empty;                   //발주량(A)
        private string sUnitCode = string.Empty;                   //단위
        private string DevideCount = string.Empty;
        private int DivisionQty = 0;
        private double TotalQty = 0;
        private double LotQty = 0;
        private double LotRMQty = 0;
        private double InputValue = 0;

        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        DataTable rtnDtTemp2 = new DataTable();

        MM0000_POP_TEL MM0000_POP_TEL;
        DataRow dRow;

        int _chkCnt = 0;
        int _printCnt = 1;
        int _columnCnt = 0;

        #endregion

        #region [ 생성자 ]
        public MM0070_POP1()
        {
            InitializeComponent();
        }

        public MM0070_POP1(DataRow drRow)
        {
            InitializeComponent();

            sPlantCode = Convert.ToString(drRow["PLANTCODE"]);
            sWHCode = Convert.ToString(drRow["WHCODE"]);
            sStorageLocCode = Convert.ToString(drRow["STORAGELOCCODE"]);
            sItemCode = Convert.ToString(drRow["ITEMCODE"]);
            sItemName = Convert.ToString(drRow["ITEMNAME"]);
            sLotNo = Convert.ToString(drRow["LOTNO"]);
            sQty = Convert.ToString(drRow["NOWQTY"]);
            sUnitCode = Convert.ToString(drRow["UNITCODE"]);

            txt_PLANTCODE_H.Text = sPlantCode;
            txt_WHCODE_H.Text = sWHCode;
            txt_STORAGELOCCODE_H.Text = sStorageLocCode;
            txt_ITEMCODE_H.Text = sItemCode;
            txt_ITEMNAME_H.Text = sItemName;
            txt_LOTNO_H.Text = sLotNo;
            txt_QRY_H.Text = sQty;
            txt_UNITCODE_H.Text = sUnitCode;
            DevideCount = "First";

            for (int i = 0; i < 4; i++)
            {
                rtnDtTemp2.Columns.Add("PLANTNAME" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("LOTNO" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("TMPINDATE" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("ITEMTYPE" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("ITEMCODE" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("ITEMNAME" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("PONO" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("LOTBASEQTY" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("CUSTCODE" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("CUSTNAME" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("REMARK" + Convert.ToString(i + 1));
            }

        }
        #endregion

        #region [ FORM LOAD ]
        private void MM0070_POP1_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성

            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOT No", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "QTY", "수량", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false);

            grid1.Columns["QTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid1);

            txt_DIVISIONQTY_H.Select();

        }

        #endregion

        #region [ METHOD AREA ]
        /// <summary>
        /// 숫자입력
        /// </summary>
        /// <param name="_RecVal"></param>
        /// <returns></returns>
        public static bool _IsNumber(string _RecVal)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[^\d.]+");

            if (!regex.IsMatch(_RecVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region [ EVENT AREA ]
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLotDivide_Click(object sender, EventArgs e)
        {
            if (txt_DIVISIONQTY_H.Text == "0")
            {
                MessageBox.Show(Common.getLangText("분할수량이 0입니다.", "MSG"), Common.getLangText("분할 갯수 입력", "MSG"));
                txt_DIVISIONQTY_H.Text = string.Empty;
                return;
            }


            // 분할 갯수에 입력된 문자열을 숫자로 변환시도하여 숫자(정수)가 아닐 시 오류 return
            if (Int32.TryParse(txt_DIVISIONQTY_H.Text, out DivisionQty) == false)
            {
                MessageBox.Show(Common.getLangText("분할 갯수를 정확히 입력해 주세요.", "MSG"), Common.getLangText("분할 갯수 입력", "MSG"));
                return;
            }

            if (Convert.ToInt32(txt_DIVISIONQTY_H.Text) == this.grid1.Rows.Count)
            {
                MessageBox.Show(Common.getLangText("분할 수량 만큼 이미 분할 되어있습니다.", "MSG"), Common.getLangText("중복 분할", "MSG"));
                return;
            }
            else if (this.grid1.Rows.Count != 0)
            {
                DialogResult result = MessageBox.Show(Common.getLangText("이전 작업을 취소하고 다시 분할 하시겠습니까 ?", "MSG"), Common.getLangText("중복 분할 확인", "MSG"), MessageBoxButtons.YesNo);

                if (result.ToString().ToUpper() == "NO")
                {
                    return;
                }
                else
                {
                    //이전수량 초기화
                    txt_REMAINQTY_H.Text = "";
                    InputValue = 0;
                }
            }

            this._GridUtil.Grid_Clear(grid1);
            //LOT 수량 계산
            TotalQty = Convert.ToDouble(txt_QRY_H.Text);             // 대상수량
            DivisionQty = Convert.ToInt16(txt_DIVISIONQTY_H.Text);  // 분할수량
            LotQty = Math.Round((TotalQty / DivisionQty), 3);                // 분할된 수량
            LotRMQty = Math.Round((TotalQty % DivisionQty), 3);                // 분할된 나머지




            //첫째행은 자신의 LOTNO
            this.grid1.InsertRow();
            this.grid1.ActiveRow.Cells["CHK"].Value = true;
            this.grid1.ActiveRow.Cells["LotNo"].Value = txt_LOTNO_H.Text;
            this.grid1.ActiveRow.Cells["Qty"].Value = LotQty;
            this.grid1.ActiveRow.Cells["UnitCode"].Value = txt_UNITCODE_H.Text;
            UltraGridUtil.ActivationAllowEdit(this.grid1, "Qty");



            //분할된 신규Row 생성
            for (int i = 1; i < DivisionQty; i++)
            {
                this.grid1.InsertRow();

                //LOT NO 채번 필요
                this.grid1.ActiveRow.Cells["CHK"].Value = true;
                this.grid1.Rows[i].Cells["Qty"].Value = LotQty;
                this.grid1.Rows[i].Cells["UnitCode"].Value = txt_UNITCODE_H.Text;
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Qty");
            }

            //나머지 잔량은 마지막 Row 처리
            if (LotRMQty != 0)
            {
                //this.grid1.InsertRow();

                //LOT NO 채번 필요
                this.grid1.ActiveRow.Cells["CHK"].Value = true;
                this.grid1.ActiveRow.Cells["Qty"].Value = TotalQty - (LotQty * (DivisionQty - 1));
                this.grid1.ActiveRow.Cells["UnitCode"].Value = txt_UNITCODE_H.Text;
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Qty");
            }
            //else
            //{
            //    this.grid1.InsertRow();

            //    //LOT NO 채번 필요
            //    //this.grid1.ActiveRow.Cells["LotNo"].Value    = sSql;
            //    this.grid1.ActiveRow.Cells["Qty"].Value      = txtQty.Text;
            //    this.grid1.ActiveRow.Cells["UnitCode"].Value = txtUnitCode.Text;
            //}

            for (int i = 0; i < this.grid1.Rows.Count; i++)
            {
                InputValue = InputValue + Convert.ToDouble(this.grid1.Rows[i].Cells["Qty"].Value);
            }
            txt_INPUTVALUESUM_H.Text = Convert.ToString(InputValue);
        }

        private void txtDivisionQty_TextChanged(object sender, EventArgs e)
        {
            if (txt_DIVISIONQTY_H.Text.Length > 0)
            {

                string value = txt_DIVISIONQTY_H.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txt_DIVISIONQTY_H.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txt_DIVISIONQTY_H.Text = txt_DIVISIONQTY_H.Text.Remove(txt_DIVISIONQTY_H.Text.Length - 1, 1);
                        txt_DIVISIONQTY_H.Select(txt_DIVISIONQTY_H.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txt_DIVISIONQTY_H.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txt_DIVISIONQTY_H.SelectionStart = txt_DIVISIONQTY_H.Text.Length;
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count < 3)
            {
                MessageBox.Show(Common.getLangText("분할 가능한 최소 수량입니다.삭제를 할 수 없습니다.", "MSG"));
                return;
            }
            else if (this.grid1.Rows[0].Activated == true)
            {
                MessageBox.Show(Common.getLangText("분할 될 대상 LOT 는 삭제 할 수 없습니다.", "MSG"));
                return;
            }
            int a = 0;
            for (int i = 0; i < this.grid1.Rows.Count; i++)
            {
                if (this.grid1.Rows[i].Activated == true)
                {
                    a++;
                    break;
                }
            }
            if (a != 0) this.grid1.DeleteRow();
            else
            {
                this.grid1.Rows[2].Activated = true;
                this.grid1.DeleteRow();
            }
            SetInputSumQty();
            txt_DIVISIONQTY_H.Text = Convert.ToString(this.grid1.Rows.Count);
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            DoPrint();
        }

        //수정 필요
        private void DoPrint()
        {
            int cnt = 0;
            if (grid1.Rows.Count == 0) return;

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                if (grid1.Rows[i].Cells["LotNo"].Value.ToString() == "")
                {
                    MessageBox.Show(Common.getLangText("분할 등록 후, 바코드 발행이 가능합니다.", "MSG"));
                    return;
                }
            }

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                if (grid1.Rows[i].Cells["CHK"].Value.ToString() == "True")
                    _chkCnt++;
            }

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                if (grid1.Rows[i].Cells["CHK"].Value.ToString() == "True")
                {
                    string sPlantCode1 = sPlantCode;             // 공장코드
                    string sLotno = grid1.Rows[i].Cells["LotNo"].Value.ToString();

                    //라벨출력
                    SendPrint(sPlantCode, sLotno);
                }
                else
                {
                    cnt++;
                }

            }

            _printCnt = 1;
            _chkCnt = 0;

            if (cnt == grid1.Rows.Count)
            {
                MessageBox.Show(Common.getLangText("바코드 발행할 데이터를 선택 후, 버튼을 눌러주세요.", "MSG"));
                return;
            }
        }

        private void SendPrint(string sPlantCode, string sLotno)
        {
            //시리얼 열기
            //openSerial();

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_MM0070_POP1_S1"
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


                        command.AppendLine("^FO" + "15, 30" + "^GB" + "680, 920, 3" + "^FS");  //전체 박스

                        command.AppendLine("^FO" + "140, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 1
                        command.AppendLine("^FO" + "300, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 2
                        command.AppendLine("^FO" + "360, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 3
                        command.AppendLine("^FO" + "420, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 4
                        command.AppendLine("^FO" + "480, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 5
                        command.AppendLine("^FO" + "540, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 6
                        command.AppendLine("^FO" + "600, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 7

                        command.AppendLine("^FO" + "15,  220" + "^GB" + "125, 1, 2" + "^FS"); //가로줄 1
                        command.AppendLine("^FO" + "300, 220" + "^GB" + "300, 1, 2" + "^FS"); //가로줄 2
                        command.AppendLine("^FO" + "300, 485" + "^GB" + "60,  1, 2" + "^FS"); //가로줄 3
                        command.AppendLine("^FO" + "480, 485" + "^GB" + "120, 1, 2" + "^FS"); //가로줄 4
                        command.AppendLine("^FO" + "300, 690" + "^GB" + "60,  1, 2" + "^FS"); //가로줄 5
                        command.AppendLine("^FO" + "480, 690" + "^GB" + "120, 1, 2" + "^FS"); //가로줄 6

                        command.AppendLine("^FO" + "625, 45" + "^A1R, 40, 40" + " ^FD" + "원자재 식별표" + "^FS");
                        command.AppendLine("^FO" + "625, 740" + "^A1R, 40, 40" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["PLANTNAME"]) + "^FS");

                        command.AppendLine("^FO" + "555, 70" + "^A1R, 30, 30" + " ^FD" + "LOT No" + "^FS");
                        command.AppendLine("^FO" + "555, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["LOTNO"]) + "^FS");

                        command.AppendLine("^FO" + "555, 515" + "^A1R, 30, 30" + " ^FD" + "가입고일자" + "^FS");
                        command.AppendLine("^FO" + "555, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["TMPINDATE"]) + "^FS");

                        command.AppendLine("^FO" + "495, 70" + "^A1R, 30, 30" + " ^FD" + "품목유형" + "^FS");
                        command.AppendLine("^FO" + "495, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMTYPE"]) + "^FS");

                        command.AppendLine("^FO" + "495, 530" + "^A1R, 30, 30" + " ^FD" + "수    량" + "^FS");
                        command.AppendLine("^FO" + "495, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["LOTBASEQTY"]) + "^FS");

                        command.AppendLine("^FO" + "435, 70" + "^A1R, 30, 30" + " ^FD" + "품목코드" + "^FS");
                        command.AppendLine("^FO" + "435, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMCODE"]) + "^FS");

                        command.AppendLine("^FO" + "375, 70" + "^A1R, 30, 30" + " ^FD" + "품 목 명" + "^FS");

                        if (Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]).Length < 30)
                            command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]) + "^FS");
                        else if (Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]).Length < 60)
                            command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]) + "^FS");
                        else
                            command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]) + "^FS");


                        command.AppendLine("^FO" + "315, 70" + "^A1R, 30, 30" + " ^FD" + "발주번호" + "^FS");
                        command.AppendLine("^FO" + "315, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["PONO"]) + "^FS");

                        command.AppendLine("^FO" + "315, 530" + "^A1R, 30, 30" + " ^FD" + "업 체 명" + "^FS");
                        command.AppendLine("^FO" + "315, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["CUSTNAME"]) + "^FS");

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
                        if (_printCnt == 1 || _printCnt % 4 == 1)
                            dRow = rtnDtTemp2.NewRow();


                        for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                        {
                            dRow["PLANTNAME" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["PLANTNAME"];
                            dRow["LOTNO" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["LOTNO"];
                            dRow["TMPINDATE" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["TMPINDATE"];
                            dRow["ITEMTYPE" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["ITEMTYPE"];
                            dRow["ITEMCODE" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["ITEMCODE"];
                            dRow["ITEMNAME" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["ITEMNAME"];
                            dRow["PONO" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["PONO"];
                            dRow["LOTBASEQTY" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["LOTBASEQTY"];
                            dRow["CUSTCODE" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["CUSTCODE"];
                            dRow["CUSTNAME" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["CUSTNAME"];
                            dRow["REMARK" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["REMARK"];

                            if (_printCnt == _chkCnt || _printCnt % 4 == 0)
                            {
                                rtnDtTemp2.Rows.Add(dRow);

                                //텔레릭 레포트로 출력시
                                //rtnDtTemp 데이터바인딩
                                MM0000_POP_TEL = new MM0000_POP_TEL();
                                objectDataSource.DataSource = rtnDtTemp2;
                                MM0000_POP_TEL.DataSource = objectDataSource;
                                viewerInstance.ReportDocument = MM0000_POP_TEL.Report;

                                //레포트 뷰어
                                //ReportViewer.ReportSource = viewerInstance;
                                //ReportViewer.RefreshReport();

                                //뷰어 없이 바로 출력
                                Telerik.Reporting.IReportDocument myReport = new MM0000_POP_TEL();
                                System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                                System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
                                Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

                                reportProcessor.PrintController = standardPrintController;
                                printerSettings.Collate = true;
                                reportProcessor.PrintReport(viewerInstance, printerSettings);

                                rtnDtTemp2.Rows.RemoveAt(0);
                                _columnCnt = -1;
                            }

                            _printCnt++;
                            _columnCnt++;
                        }
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


        // 등록 분할 수량 Sum 자동 입력.
        private void SetInputSumQty()
        {
            if (this.grid1.Rows.Count != 0)
            {
                this.grid1.UpdateData();
                InputValue = 0;
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (this.grid1.Rows[i].Cells["Qty"].Value.ToString() == "")
                    {
                        continue;
                    }
                    InputValue = InputValue + Convert.ToDouble(this.grid1.Rows[i].Cells["Qty"].Value);
                }
                txt_INPUTVALUESUM_H.Text = Convert.ToString(InputValue);
                txt_REMAINQTY_H.Text = Convert.ToString(Convert.ToDouble(txt_QRY_H.Text) - Convert.ToDouble(txt_INPUTVALUESUM_H.Text));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DevideCount != "First")
            {
                MessageBox.Show(Common.getLangText("이미 분할된 LOT 입니다.", "MSG"));
                return;
            }
            double sum = 0;
            for (int i = 0; i < this.grid1.Rows.Count; i++)
            {
                if (this.grid1.Rows[i].Cells["Qty"].Value.ToString() == "")
                {
                    MessageBox.Show(Common.getLangText("분할 수량을 입력하지 않은 행이 존재합니다. 확인후 진행하세요.", "MSG"));
                    return;
                }
                sum = sum + Convert.ToDouble(this.grid1.Rows[i].Cells["QTY"].Value);
            }

            if (sum > Convert.ToDouble(this.txt_QRY_H.Text))
            {
                MessageBox.Show(Common.getLangText("등록수량이 분할대상수량보다 많습니다.\r\n등록수량을 분할대상수량과 일치시켜 주세요.", "MSG"));
                return;
            }
            else if (sum < Convert.ToDouble(this.txt_QRY_H.Text))
            {
                MessageBox.Show(Common.getLangText("등록수량이 분할대상수량보다 적습니다.\r\n등록수량을 분할대상수량과 일치시켜 주세요.", "MSG"));
                return;
            }

            DialogResult result = MessageBox.Show(Common.getLangText("LOT 분할 하시겠습니까 ?", "MSG"), Common.getLangText("LOT 분할", "MSG"), MessageBoxButtons.YesNo);
            if (result.ToString().ToUpper() == "NO") return;

            DBHelper helper = new DBHelper("", true);
            string RS_MSG = string.Empty;
            string RS_CODE = string.Empty;

            try
            {
                this.grid1.UpdateData();

                int iInseqNo = 1;
                for (int i = 1; i < this.grid1.Rows.Count; i++)
                {
                    helper.ExecuteNoneQuery("USP_MM0070_POP1_U1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_LOTNO", DBHelper.nvlString(this.txt_LOTNO_H.Text), DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AF_QTY", DBHelper.nvlDouble(this.grid1.Rows[i].Cells["QTY"].Value), DbType.Double, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AI_INSEQNO", iInseqNo, DbType.Int32, ParameterDirection.Input));
                    if (helper.RSCODE != "S")
                    {
                        MessageBox.Show(Common.getLangText("LOT 분할을 실패하였습니다.", "MSG") + Environment.NewLine + helper.RSMSG, Common.getLangText("LOT 분할 실패", "MSG"));
                        helper.Rollback();
                        return;
                    }
                    this.grid1.Rows[i].Cells["LotNo"].Value = helper.RSMSG;
                    iInseqNo++;
                }


                helper.ExecuteNoneQuery("USP_MM0070_POP1_U2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_LOTNO", DBHelper.nvlString(this.txt_LOTNO_H.Text), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AF_QTY", DBHelper.nvlDouble(this.grid1.Rows[0].Cells["QTY"].Value), DbType.Double, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {


                    MessageBox.Show(Common.getLangText("LOT 분할을 완료하였습니다.", "MSG"), Common.getLangText("LOT 분할 성공", "MSG"));
                    helper.Commit();
                    DevideCount = "Commit";
                    //등록시 발행
                    if (chk_PRINT_H.Checked == true)
                    {
                        DoPrint();
                    }
                }
                else
                {
                    MessageBox.Show(Common.getLangText("LOT 분할을 실패하였습니다.", "MSG") + Environment.NewLine + helper.RSMSG, Common.getLangText("LOT 분할 실패", "MSG"));
                    helper.Rollback();
                    DevideCount = "First";
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                RS_CODE = "E";
                RS_MSG = ex.Message.ToString();
                DevideCount = "First";
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        private void txtDivisionQty_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (this.grid1.Rows.Count == 0) return;
            //숫자 그리드 헤더 컬럼명 찾기
            this.grid1.UpdateData();
            if (e.KeyChar == Convert.ToChar("."))
            {
                // . 만 입력시 0. 으로 처리
                if (this.grid1.ActiveRow.Cells["Qty"].Value.ToString() == "")
                {
                    e.Handled = true;
                    this.grid1.ActiveRow.Cells["Qty"].Value = "0.";
                    this.grid1.ActiveRow.Cells["Qty"].SelStart = 2;
                    return;
                }
                // . 을 두개 이상 입력시 방지
                string InspValue = this.grid1.ActiveRow.Cells["Qty"].Value.ToString();
                string[] a = InspValue.Split('.');
                if (a.Length > 1) e.Handled = true;
            }
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                // 숫자입력 메시지창 표현.
                if (this.grid1.ActiveCell.Column.Key == "Qty")
                {
                    MessageBox.Show(Common.getLangText("숫자만 입력하여 주십시요", "MSG"));
                }
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SetInputSumQty();
            }
            //}
        }

        private void grid1_Click(object sender, EventArgs e)
        {
            SetInputSumQty();
        }


        private void grid1_ClickCell(object sender, EventArgs e)
        {
            //SetInputSumQty();
        }

        private void grid1_Leave(object sender, EventArgs e)
        {
            SetInputSumQty();
        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            SetInputSumQty();
        }
    }
}

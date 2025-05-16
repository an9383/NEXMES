using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class POP_MM0500 : WIZ.Forms.BasePopupForm
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
        #endregion

        #region [ 생성자 ]
        public POP_MM0500()
        {
            InitializeComponent();
        }

        public POP_MM0500(DataRow drRow)
        {
            InitializeComponent();

            sPlantCode = Convert.ToString(drRow["PLANTCODE"]);
            sWHCode = Convert.ToString(drRow["WHCODE"]);
            sStorageLocCode = Convert.ToString(drRow["STORAGELOCCODE"]);
            sItemCode = Convert.ToString(drRow["ITEMCODE"]);
            //sItemName      = Convert.ToString(drRow["ITEMNAME"]);
            sLotNo = Convert.ToString(drRow["LOTNO"]);
            sQty = Convert.ToString(drRow["STOCKQTY"]);
            sUnitCode = Convert.ToString(drRow["UNITCODE"]);

            txtPlantCode.Text = sPlantCode;
            txtWhCode.Text = sWHCode;
            txtStorageLocCode.Text = sStorageLocCode;
            txtItemCode.Text = sItemCode;
            //txtItemName.Text      = sItemName;
            txtLotNo.Text = sLotNo;
            txtQty.Text = sQty;
            txtUnitCode.Text = sUnitCode;
            DevideCount = "First";

        }
        #endregion

        #region [ Form Load ]
        private void POP_MM0500_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성

            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotNo", "LOTNO", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Qty", "수량", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            txtDivisionQty.Focus();

            //try
            //{
            //    #region --- Grid1 Summary ---
            //    this.grid1.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            //    this.grid1.DisplayLayout.Bands[0].Summaries.Add("합계", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["CHK"]);
            //    this.grid1.DisplayLayout.Bands[0].Summaries[0].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["CHK"];
            //    this.grid1.DisplayLayout.Bands[0].Summaries[0].DisplayFormat = "합계";
            //    this.grid1.DisplayLayout.Bands[0].Summaries[0].Key = "CHK";
            //    this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.TextHAlign = HAlign.Center;
            //    this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.FontData.SizeInPoints = 9;
            //    this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.BackColor = Color.FromArgb(255, 228, 225);
            //    this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.ForeColor = Color.Black;
            //    this.grid1.DisplayLayout.Bands[0].Summaries[0].SummaryDisplayArea = SummaryDisplayAreas.Top;

            //    this.grid1.DisplayLayout.Bands[0].Summaries.Add(" ", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["LotNo"]);
            //    this.grid1.DisplayLayout.Bands[0].Summaries[1].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["LotNo"];
            //    this.grid1.DisplayLayout.Bands[0].Summaries[1].DisplayFormat = "{0:#,##0}";
            //    this.grid1.DisplayLayout.Bands[0].Summaries[1].Key = "LotNo";
            //    this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.TextHAlign = HAlign.Center;
            //    this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.FontData.SizeInPoints = 9;
            //    this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.BackColor = Color.FromArgb(255, 228, 225);
            //    this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.ForeColor = Color.Black;
            //    this.grid1.DisplayLayout.Bands[0].Summaries[1].SummaryDisplayArea = SummaryDisplayAreas.Top;

            //    this.grid1.DisplayLayout.Bands[0].Summaries.Add("SUM([Qty])", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["Qty"]);
            //    this.grid1.DisplayLayout.Bands[0].Summaries[2].DisplayFormat = "{0:#,##0}";
            //    this.grid1.DisplayLayout.Bands[0].Summaries[2].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["Qty"];
            //    this.grid1.DisplayLayout.Bands[0].Summaries[2].Key = "Qty";
            //    this.grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.TextHAlign = HAlign.Right;
            //    this.grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.FontData.SizeInPoints = 10;
            //    this.grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.BackColor = Color.FromArgb(255, 228, 225);
            //    this.grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.ForeColor = Color.Black;
            //    this.grid1.DisplayLayout.Bands[0].Summaries[2].SourceColumn.Format = "#,##0";
            //    this.grid1.DisplayLayout.Bands[0].Summaries[2].SummaryPositionColumn.Format = "#,##0";
            //    this.grid1.DisplayLayout.Bands[0].Summaries[2].SummaryDisplayArea = SummaryDisplayAreas.Top;
            //    this.grid1.DisplayLayout.Bands[0].Summaries[2].SummaryType = SummaryType.Sum;

            //    this.grid1.DisplayLayout.Bands[0].Summaries.Add(" ", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["UnitCode"]);
            //    this.grid1.DisplayLayout.Bands[0].Summaries[3].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["UnitCode"];
            //    this.grid1.DisplayLayout.Bands[0].Summaries[3].DisplayFormat = "{0:#,##0}";
            //    this.grid1.DisplayLayout.Bands[0].Summaries[3].Key = "UnitCode";
            //    this.grid1.DisplayLayout.Bands[0].Summaries[3].Appearance.TextHAlign = HAlign.Center;
            //    this.grid1.DisplayLayout.Bands[0].Summaries[3].Appearance.FontData.SizeInPoints = 9;
            //    this.grid1.DisplayLayout.Bands[0].Summaries[3].Appearance.BackColor = Color.FromArgb(255, 228, 225);
            //    this.grid1.DisplayLayout.Bands[0].Summaries[3].Appearance.ForeColor = Color.Black;
            //    this.grid1.DisplayLayout.Bands[0].Summaries[3].SummaryDisplayArea = SummaryDisplayAreas.Top;
            //    #endregion --- Grid1 Summary ---
            //}
            //catch (Exception ex)
            //{

            //}

        }

        #endregion

        #region [ User Method Area ]
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

        #region [ Event Area ]
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLotDivide_Click(object sender, EventArgs e)
        {
            //if (this.grid1.Rows.Count == 0) return;

            if (txtDivisionQty.Text == "0")
            {
                MessageBox.Show("분할수량이 0입니다.", "분할 갯수 입력");
                txtDivisionQty.Text = string.Empty;
                return;
            }


            // 분할 갯수에 입력된 문자열을 숫자로 변환시도하여 숫자(정수)가 아닐 시 오류 return
            if (Int32.TryParse(txtDivisionQty.Text, out DivisionQty) == false)
            {
                MessageBox.Show("분할 갯수를 정확히 입력해 주세요.", "분할 갯수 입력");
                return;
            }

            if (Convert.ToInt32(txtDivisionQty.Text) == this.grid1.Rows.Count)
            {
                MessageBox.Show("분할 수량 만큼 이미 분할 되어있습니다.", "중복 분할");
                return;
            }
            else if (this.grid1.Rows.Count != 0)
            {
                DialogResult result = MessageBox.Show("이전 작업을 취소하고 다시 분할 하시겠습니까 ?", "중복 분할 확인", MessageBoxButtons.YesNo);

                if (result.ToString().ToUpper() == "NO")
                {
                    return;
                }
                else
                {
                    //이전수량 초기화
                    InputValue = 0;
                }
            }

            this._GridUtil.Grid_Clear(grid1);
            //LOT 수량 계산
            TotalQty = Convert.ToDouble(txtQty.Text);             // 대상수량
            DivisionQty = Convert.ToInt16(txtDivisionQty.Text);  // 분할수량
            LotQty = Math.Round((TotalQty / DivisionQty), 3);                // 분할된 수량
            LotRMQty = Math.Round((TotalQty % DivisionQty), 3);                // 분할된 나머지




            //첫째행은 자신의 LOTNO
            this.grid1.InsertRow();
            this.grid1.ActiveRow.Cells["CHK"].Value = true;
            this.grid1.ActiveRow.Cells["LotNo"].Value = txtLotNo.Text;
            this.grid1.ActiveRow.Cells["Qty"].Value = LotQty;
            this.grid1.ActiveRow.Cells["UnitCode"].Value = txtUnitCode.Text;
            UltraGridUtil.ActivationAllowEdit(this.grid1, "Qty");



            //분할된 신규Row 생성
            for (int i = 1; i < DivisionQty; i++)
            {
                this.grid1.InsertRow();

                //LOT NO 채번 필요
                this.grid1.ActiveRow.Cells["CHK"].Value = true;
                this.grid1.Rows[i].Cells["Qty"].Value = LotQty;
                this.grid1.Rows[i].Cells["UnitCode"].Value = txtUnitCode.Text;
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Qty");
            }

            //나머지 잔량은 마지막 Row 처리
            if (LotRMQty != 0)
            {
                //this.grid1.InsertRow();

                //LOT NO 채번 필요
                this.grid1.ActiveRow.Cells["CHK"].Value = true;
                this.grid1.ActiveRow.Cells["Qty"].Value = TotalQty - (LotQty * (DivisionQty - 1));
                this.grid1.ActiveRow.Cells["UnitCode"].Value = txtUnitCode.Text;
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
            txtInputValueSum.Text = Convert.ToString(InputValue);
        }

        private void txtDivisionQty_TextChanged(object sender, EventArgs e)
        {
            if (txtDivisionQty.Text.Length > 0)
            {

                string value = txtDivisionQty.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txtDivisionQty.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txtDivisionQty.Text = txtDivisionQty.Text.Remove(txtDivisionQty.Text.Length - 1, 1);
                        txtDivisionQty.Select(txtDivisionQty.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txtDivisionQty.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txtDivisionQty.SelectionStart = txtDivisionQty.Text.Length;
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count < 3)
            {
                MessageBox.Show("분할 가능한 최소 수량입니다.삭제를 할 수 없습니다.");
                return;
            }
            else if (this.grid1.Rows[0].Activated == true)
            {
                MessageBox.Show("분할 될 대상 LOT 는 삭제 할 수 없습니다.");
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
            txtDivisionQty.Text = Convert.ToString(this.grid1.Rows.Count);
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
                    MessageBox.Show("분할 등록 후, 바코드 발행이 가능합니다.");
                    return;
                }
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
            if (cnt == grid1.Rows.Count)
            {
                MessageBox.Show("바코드 발행할 데이터를 선택 후, 버튼을 눌러주세요.");
                return;
            }
        }

        private void SendPrint(string PlantCode, string Lotno)
        {
            //시리얼 열기
            //openSerial();

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_POP_WM0500_S1"
                                                          , CommandType.StoredProcedure
                                                          , helper.CreateParameter("PLANTCODE", PlantCode, DbType.String, ParameterDirection.Input)
                                                          //    , helper.CreateParameter("PONO", PoNo, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("LOTNO", Lotno, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    {
                        StringBuilder command = new StringBuilder();
                        command.AppendLine("^XA");
                        command.AppendLine("^LH0,0^LL500^XZ");
                        command.AppendLine("^XA");
                        command.AppendLine("^SEE:UHANGUL.DAT^FS");
                        command.AppendLine("^CW1,E:KFONT3.FNT^CI26^FS");

                        command.AppendLine("^FO" + "20,30" + "^GB" + "200,900,2" + "^FS");       //왼쪽 박스
                        command.AppendLine("^FO" + "165,30" + "^GB" + "1,900,2" + "^FS");        //세로1
                        command.AppendLine("^FO" + "20,210" + "^GB" + "200,1,2" + "^FS");        //가로1

                        command.AppendLine("^FO" + "165,50" + "^A1R,50,35" + " ^FD" + "업 체 명" + "^FS");
                        command.AppendLine("^FO" + "100,50" + "^A1R,50,35" + " ^FD" + "특    이" + "^FS");
                        command.AppendLine("^FO" + "40,50" + "^A1R,50,35" + " ^FD" + "사    항" + "^FS");
                        command.AppendLine("^FO" + "165,250" + "^A1R,50,35" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["CUSTNAME"]) + "^FS");  //거래처

                        //2,3 or 3,4
                        command.AppendLine("^FO" + "250, 200" + "^BY3,4^BCR," + "80,Y,N,N" + "^FD" + Convert.ToString(rtnDtTemp.Rows[i]["BARCODE"]) + "^FS");    //바코드(1D)

                        command.AppendLine("^FO" + "335,30" + "^GB" + "300,900,2" + "^FS");       //오른쪽 박스
                        command.AppendLine("^FO" + "335,210" + "^GB" + "300,1,2" + "^FS");         //가로1
                        command.AppendLine("^FO" + "335,530" + "^GB" + "300,1,2" + "^FS");         //가로2
                        command.AppendLine("^FO" + "335,700" + "^GB" + "300,1,2" + "^FS");         //가로3
                        command.AppendLine("^FO" + "580,30" + "^GB" + "1,900,2" + "^FS");        //입고일자 밑 줄
                        command.AppendLine("^FO" + "520,30" + "^GB" + "1,900,2" + "^FS");        //품목 밑 줄
                        command.AppendLine("^FO" + "465,30" + "^GB" + "1,900,2" + "^FS");        //품목명 밑 줄
                        command.AppendLine("^FO" + "385,30" + "^GB" + "1,900,2" + "^FS");        //수량 밑 줄

                        command.AppendLine("^FO" + "580,50" + "^A1R,50,35" + " ^FD" + "일    자" + "^FS");
                        command.AppendLine("^FO" + "520,50" + "^A1R,50,35" + " ^FD" + "품    번" + "^FS");
                        command.AppendLine("^FO" + "465,50" + "^A1R,50,35" + " ^FD" + "품    명" + "^FS");
                        command.AppendLine("^FO" + "400,50" + "^A1R,50,35" + " ^FD" + "수    량" + "^FS");
                        command.AppendLine("^FO" + "330,50" + "^A1R,50,35" + " ^FD" + "소재LOT" + "^FS");

                        command.AppendLine("^FO" + "580,550" + "^A1R,50,35" + " ^FD" + "순    번" + "^FS");
                        command.AppendLine("^FO" + "520,550" + "^A1R,50,35" + " ^FD" + "저장위치" + "^FS");
                        command.AppendLine("^FO" + "465,550" + "^A1R,50,35" + " ^FD" + "구    분" + "^FS");
                        command.AppendLine("^FO" + "400,550" + "^A1R,50,35" + " ^FD" + "납품일자" + "^FS");
                        command.AppendLine("^FO" + "360,550" + "^A1R,20,20" + " ^FD" + "소재자재구분" + "^FS");
                        command.AppendLine("^FO" + "335,570" + "^A1R,20,20" + " ^FD" + "차종/기종" + "^FS");

                        command.AppendLine("^FO" + "590,270" + "^A1R,30,30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["PRTDATE"]) + "^FS");
                        command.AppendLine("^FO" + "520,215" + "^A1R,60,35" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]) + "^FS");
                        command.AppendLine("^FO" + "480,215" + "^A1R,20,20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]) + "^FS");
                        command.AppendLine("^FO" + "380,300" + "^A1R,70,70" + " ^FD" + string.Format("{0:#,##0}", Convert.ToInt32(rtnDtTemp.Rows[i]["QTY"])) + "^FS");
                        //command.AppendLine("^FO" + "345,250" + "^A1R,30,30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["CUSTLOTNO"]) + "^FS";

                        command.AppendLine("^FO" + "580,760" + "^A1R,50,50" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["BARCODE"]).Substring(10, 3) + "^FS");

                        command.AppendLine("^FO" + "640,100" + "^A1R,50,50" + " ^FD" + "제품식별표" + "^FS");
                        command.AppendLine("^FO" + "640,700" + "^A1R,50,50" + " ^FD" + "대신정공" + "^FS");
                        command.AppendLine("^XZ");

                        WIZ.Common.SendStringToBytePrinter("ZT410", command.ToString());

                        //byte[] b = Encoding.Default.GetBytes(command.ToString());
                        //serialPort1.Write(b, 0, b.Length);


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
        //수정 필요
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DevideCount != "First")
            {
                MessageBox.Show("이미 분할된 LOT 입니다.");
                return;
            }
            double sum = 0;
            for (int i = 0; i < this.grid1.Rows.Count; i++)
            {
                if (this.grid1.Rows[i].Cells["Qty"].Value.ToString() == "")
                {
                    MessageBox.Show("분할 수량을 입력하지 않은 행이 존재합니다. 확인후 진행하세요.");
                    return;
                }
                sum = sum + Convert.ToDouble(this.grid1.Rows[i].Cells["QTY"].Value);
            }

            if (sum != Convert.ToDouble(this.txtQty.Text))
            {
                MessageBox.Show("분할 대상의 수량과 분할수량의 합이 일치하지 않습니다. 확인후 진행하세요");
                return;
            }
            DialogResult result = MessageBox.Show("LOT 분할 하시겠습니까 ?", "LOT 분할", MessageBoxButtons.YesNo);
            if (result.ToString().ToUpper() == "NO") return;

            DBHelper helper = new DBHelper("", true);
            string RS_MSG = string.Empty;
            string RS_CODE = string.Empty;

            try
            {
                this.grid1.UpdateData();

                int InseqNo = 1;
                for (int i = 1; i < this.grid1.Rows.Count; i++)
                {
                    helper.ExecuteNoneQuery("POP_WM0500_U1", CommandType.StoredProcedure
                                                           , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("LOTNO", Convert.ToString(this.txtLotNo.Text), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("QTY", Convert.ToString(this.grid1.Rows[i].Cells["QTY"].Value), DbType.String, ParameterDirection.Input) // 수정
                                                           , helper.CreateParameter("WORKERID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("INSEQNO", InseqNo, DbType.String, ParameterDirection.Input)
                                                           );
                    if (helper.RSCODE != "S")
                    {
                        MessageBox.Show("LOT 분할을 실패하였습니다." + Environment.NewLine + helper.RSMSG, "LOT 분할 실패");
                        helper.Rollback();
                        return;
                    }
                    this.grid1.Rows[i].Cells["LotNo"].Value = helper.RSMSG;
                    InseqNo++;
                }


                helper.ExecuteNoneQuery("POP_WM0500_U2", CommandType.StoredProcedure
                                                           , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("LOTNO", Convert.ToString(this.txtLotNo.Text), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("QTY", Convert.ToString(this.grid1.Rows[0].Cells["QTY"].Value), DbType.String, ParameterDirection.Input) // 수정
                                                           , helper.CreateParameter("WORKERID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                           );

                if (helper.RSCODE == "S")
                {


                    MessageBox.Show("LOT 분할을 완료하였습니다.", "LOT 분할 성공");
                    helper.Commit();
                    DevideCount = "Commit";
                    //this.txtLotNo.Text = helper.RSMSG.ToString();
                    //등록시 발행
                    if (chkPrint.Checked == true)
                    {
                        DoPrint();
                    }
                }
                else
                {
                    MessageBox.Show("LOT 병합을 실패하였습니다." + Environment.NewLine + helper.RSMSG, "LOT 병합 실패");
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
                    MessageBox.Show("숫자만 입력하여 주십시요");
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
                txtInputValueSum.Text = Convert.ToString(InputValue);
                textBox2.Text = Convert.ToString(Convert.ToDouble(txtQty.Text) - Convert.ToDouble(txtInputValueSum.Text));
            }
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

using System;
using System.Data;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class POP_MM0510 : WIZ.Forms.BasePopupForm
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
        private int sPlusQty = 0;
        private int DivisionQty = 0;
        private int TotalQty = 0;
        private int LotQty = 0;
        private int LotRMQty = 0;

        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();


        WIZ.PopUp.ProductTab_R ProductTab_R; //제품 식별표 

        #endregion

        #region [ 생성자 ]

        public POP_MM0510(string PlantCode, WIZ.Control.Grid Grid1)
        {
            InitializeComponent();
            DtChange1 = (DataTable)Grid1.DataSource;
            Extract_GridData();
            sPlantCode = PlantCode;

        }
        #endregion

        #region [ Form Load ]
        private void POP_MM0510_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고코드/명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "창고코드/명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "위치코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "위치코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FIRSTINDATE", "최초입고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTLOTNO", "COILNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목/명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목/명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "수량", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "LOT상태", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "POSEQNO", "발주순번", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ROWSEQ", "순번", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            rtnDtTemp = _Common.GET_BM0000_CODE("LOTSTATUS");  //품목구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            GetWHCODE();

            this.grid1.DataSource = DtChange1;
            this.cboPlantCode.Value = DtChange1.Rows[0]["PLANTCODE"].ToString();
            this.txtWhCode.Text = "[" + DtChange1.Rows[0]["WHCODE"].ToString() + "] " + DtChange1.Rows[0]["WHNAME"].ToString();
            //this.txtStorageLocCode.Text = "[" + DtChange1.Rows[0]["STORAGELOCCODE"].ToString() + "] " + DtChange1.Rows[0]["STORAGELOCNAME"].ToString();
            this.txtItemCode.Text = DtChange1.Rows[0]["ITEMCODE"].ToString();
            this.txtItemName.Text = DtChange1.Rows[0]["ITEMNAME"].ToString();
            double StockQtySum = 0;
            for (int i = 0; i < DtChange1.Rows.Count; i++)
            {
                StockQtySum = StockQtySum + Convert.ToDouble(DtChange1.Rows[i]["STOCKQTY"].ToString());
            }
            this.txtQty.Text = Convert.ToString(StockQtySum);
            this.txtUnitCode.Text = DtChange1.Rows[0]["UNITCODE"].ToString();
        }

        #endregion

        #region < Method Area >
        private void Extract_GridData()
        {
            Int32 iQty = 0;
            foreach (DataRow drGrid in DtChange1.Rows)
            {
                if (drGrid["CHK"].ToString().ToUpper() != "1")
                {
                    drGrid.Delete();
                }
                else
                {
                    iQty = iQty + Convert.ToInt32(drGrid["STOCKQTY"]);

                }
            }
            sPlusQty = iQty;
            DtChange1.AcceptChanges();
        }
        #endregion < Method Area >


        #region [ User Method Area ]

        #endregion

        #region [ Event Area ]
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DoPrint();
        }
        //수정 필요
        private void DoPrint()
        {
            int cnt = 0;

            if (this.txtLotNo.Text.ToString() == "")
            {
                MessageBox.Show("병합 등록 후, 바코드 발행이 가능합니다.");
                return;
            }


            string sPlantCode1 = sPlantCode;             // 공장코드
            string sLotno = this.txtLotNo.Text.ToString();

            //라벨출력
            SendPrint(sPlantCode, sLotno);

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

                    //텔레릭 레포트로 출력시
                    //rtnDtTemp 데이터바인딩
                    ProductTab_R = new WIZ.PopUp.ProductTab_R();
                    objectDataSource.DataSource = rtnDtTemp;
                    ProductTab_R.DataSource = objectDataSource;
                    viewerInstance.ReportDocument = ProductTab_R.Report;

                    //레포트 뷰어
                    //ReportViewer.ReportSource = viewerInstance;
                    //ReportViewer.RefreshReport();

                    //뷰어 없이 바로 출력
                    Telerik.Reporting.IReportDocument myReport = new WIZ.PopUp.ProductTab_R();
                    System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                    System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
                    Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

                    reportProcessor.PrintController = standardPrintController;
                    printerSettings.Collate = true;
                    reportProcessor.PrintReport(viewerInstance, printerSettings);

                    //for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    //{
                    //    StringBuilder command = new StringBuilder();
                    //    command.AppendLine("^XA";
                    //    command.AppendLine("^LH0,0^LL500^XZ";
                    //    command.AppendLine("^XA";
                    //    command.AppendLine("^SEE:UHANGUL.DAT^FS";
                    //    command.AppendLine("^CW1,E:KFONT3.FNT^CI26^FS";

                    //    command.AppendLine("^FO" + "20,30" + "^GB" + "200,900,2" + "^FS";       //왼쪽 박스
                    //    command.AppendLine("^FO" + "165,30" + "^GB" + "1,900,2" + "^FS";        //세로1
                    //    command.AppendLine("^FO" + "20,210" + "^GB" + "200,1,2" + "^FS";        //가로1

                    //    command.AppendLine("^FO" + "165,50" + "^A1R,50,35" + " ^FD" + "업 체 명" + "^FS";
                    //    command.AppendLine("^FO" + "100,50" + "^A1R,50,35" + " ^FD" + "특    이" + "^FS";
                    //    command.AppendLine("^FO" + "40,50" + "^A1R,50,35" + " ^FD" + "사    항" + "^FS";
                    //    command.AppendLine("^FO" + "165,250" + "^A1R,50,35" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["CUSTNAME"]) + "^FS";  //거래처

                    //    //2,3 or 3,4
                    //    command.AppendLine("^FO" + "250, 200" + "^BY3,4^BCR," + "80,Y,N,N" + "^FD" + Convert.ToString(rtnDtTemp.Rows[i]["BARCODE"]) + "^FS";    //바코드(1D)

                    //    command.AppendLine("^FO" + "335,30" + "^GB" + "300,900,2" + "^FS";       //오른쪽 박스
                    //    command.AppendLine("^FO" + "335,210" + "^GB" + "300,1,2" + "^FS";         //가로1
                    //    command.AppendLine("^FO" + "335,530" + "^GB" + "300,1,2" + "^FS";         //가로2
                    //    command.AppendLine("^FO" + "335,700" + "^GB" + "300,1,2" + "^FS";         //가로3
                    //    command.AppendLine("^FO" + "580,30" + "^GB" + "1,900,2" + "^FS";        //입고일자 밑 줄
                    //    command.AppendLine("^FO" + "520,30" + "^GB" + "1,900,2" + "^FS";        //품목 밑 줄
                    //    command.AppendLine("^FO" + "465,30" + "^GB" + "1,900,2" + "^FS";        //품목명 밑 줄
                    //    command.AppendLine("^FO" + "385,30" + "^GB" + "1,900,2" + "^FS";        //수량 밑 줄

                    //    command.AppendLine("^FO" + "580,50" + "^A1R,50,35" + " ^FD" + "일    자" + "^FS";
                    //    command.AppendLine("^FO" + "520,50" + "^A1R,50,35" + " ^FD" + "품    번" + "^FS";
                    //    command.AppendLine("^FO" + "465,50" + "^A1R,50,35" + " ^FD" + "품    명" + "^FS";
                    //    command.AppendLine("^FO" + "400,50" + "^A1R,50,35" + " ^FD" + "수    량" + "^FS";
                    //    command.AppendLine("^FO" + "330,50" + "^A1R,50,35" + " ^FD" + "소재LOT" + "^FS";

                    //    command.AppendLine("^FO" + "580,550" + "^A1R,50,35" + " ^FD" + "순    번" + "^FS";
                    //    command.AppendLine("^FO" + "520,550" + "^A1R,50,35" + " ^FD" + "저장위치" + "^FS";
                    //    command.AppendLine("^FO" + "465,550" + "^A1R,50,35" + " ^FD" + "구    분" + "^FS";
                    //    command.AppendLine("^FO" + "400,550" + "^A1R,50,35" + " ^FD" + "납품일자" + "^FS";
                    //    command.AppendLine("^FO" + "360,550" + "^A1R,20,20" + " ^FD" + "소재자재구분" + "^FS";
                    //    command.AppendLine("^FO" + "335,570" + "^A1R,20,20" + " ^FD" + "차종/기종" + "^FS";

                    //    command.AppendLine("^FO" + "590,270" + "^A1R,30,30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["PRTDATE"]) + "^FS";
                    //    command.AppendLine("^FO" + "520,215" + "^A1R,60,35" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]) + "^FS";
                    //    command.AppendLine("^FO" + "480,215" + "^A1R,20,20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]) + "^FS";
                    //    command.AppendLine("^FO" + "380,300" + "^A1R,70,70" + " ^FD" + string.Format("{0:#,##0}", Convert.ToInt32(rtnDtTemp.Rows[i]["QTY"])) + "^FS";
                    //    //command.AppendLine("^FO" + "345,250" + "^A1R,30,30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["CUSTLOTNO"]) + "^FS";

                    //    command.AppendLine("^FO" + "580,760" + "^A1R,50,50" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["BARCODE"]).Substring(10, 3) + "^FS";

                    //    command.AppendLine("^FO" + "640,100" + "^A1R,50,50" + " ^FD" + "제품식별표" + "^FS";
                    //    command.AppendLine("^FO" + "640,700" + "^A1R,50,50" + " ^FD" + "대신정공" + "^FS";
                    //    command.AppendLine("^XZ";

                    //    byte[] b = Encoding.Default.GetBytes(command);
                    //    serialPort1.Write(b, 0, b.Length);


                    //}
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
            //LOT 수량 계산
            DBHelper helper = new DBHelper("", true);
            string RS_MSG = string.Empty;
            string RS_CODE = string.Empty;

            DialogResult result = MessageBox.Show("LOT 병합 하시겠습니까 ?", "LOT 병합", MessageBoxButtons.YesNo);
            if (result.ToString().ToUpper() == "NO") return;
            try
            {
                this.grid1.UpdateData();

                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    sLotNo = this.grid1.Rows[i].Cells["LOTNO"].Value.ToString();
                    // 병합 대상 출고
                    helper.ExecuteNoneQuery("POP_WM0510_I1", CommandType.StoredProcedure
                                                           , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("WORKERID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("WHCODE", Convert.ToString(this.cboWhCode.Value), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("STORAGELOCCODE", Convert.ToString(this.cboStorageLocCode.Value), DbType.String, ParameterDirection.Input)
                                                           );
                    if (helper.RSCODE != "S")
                    {
                        MessageBox.Show("LOT 병합을 실패하였습니다." + Environment.NewLine + helper.RSMSG, "LOT 병합 실패");

                        helper.Rollback();
                        return;
                    }
                }
                // 신규 Lot 등록
                string sItemCode = this.txtItemCode.Text.ToString();
                string sInQty = this.txtQty.Text.ToString();
                string sUnitCode = this.txtUnitCode.Text.ToString();
                string sFrwhcode = this.grid1.Rows[0].Cells["WHCODE"].Value.ToString();
                string sFrStoragrLocCode = this.grid1.Rows[0].Cells["STORAGELOCCODE"].Value.ToString();
                string sCustCode = this.grid1.Rows[0].Cells["CUSTCODE"].Value.ToString();


                helper.ExecuteNoneQuery("POP_WM0510_I2", CommandType.StoredProcedure
                                                       , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("WORKERID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("INQTY", sInQty, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("UNITCODE", sUnitCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("FRWHCODE", sFrwhcode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("FRSTORAGELOCCODE", sFrStoragrLocCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("WHCODE", Convert.ToString(this.cboWhCode.Value), DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("STORAGELOCCODE", Convert.ToString(this.cboStorageLocCode.Value), DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                                       );

                if (helper.RSCODE == "S")
                {

                    MessageBox.Show("LOT 병합을 완료하였습니다.", "LOT 병합 성공");
                    helper.Commit();
                    this.txtLotNo.Text = helper.RSMSG.ToString();

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
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                RS_CODE = "E";
                MessageBox.Show("LOT 병합을 실패하였습니다." + Environment.NewLine + helper.RSMSG, "LOT 병합 실패");
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

                command.AppendLine("SELECT MINORCODE                           AS CODE_ID, ");
                command.AppendLine("       '['+ MINORCODE +']' + CODENAME        AS CODE_NAME");
                command.AppendLine("  FROM TBM0000                                           ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND MAJORCODE = 'WHCODE' ");
                //command.AppendLine("   AND RELCODE2  = 'WM' ";
                command.AppendLine("   AND MINORCODE <> '$'   ");
                command.AppendLine(" ORDER BY MINORCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(this.cboWhCode, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, "");
                this.cboWhCode.Value = "WH008";
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

                command.AppendLine("SELECT MINORCODE                           AS CODE_ID, ");
                command.AppendLine("       '['+ MINORCODE +']' + CODENAME        AS CODE_NAME");
                command.AppendLine("  FROM TBM0000                                           ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND MAJORCODE = 'STORAGELOCCODE' ");
                command.AppendLine("   AND MINORCODE <> '$'   ");
                command.AppendLine("   AND MINORCODE like  '" + this.cboWhCode.Value + "%'");
                command.AppendLine(" ORDER BY MINORCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(this.cboStorageLocCode, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, "");
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

#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0010
//   Form Name    : 자재식별표 재발행
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-19
//   Made By      : 
//   Edited Date  : 
//   Edit By      :
//   Description  : 식별표 재발행
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA > 
using System;
using System.Data;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.MM
{
    public partial class MM0010 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private string plantCode = string.Empty; //plantcode default 설정       

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp2 = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        MM0000_POP_TEL MM0000_POP_TEL; //원자재 식별표
        DataRow dRow;

        int _chkCnt = 0;
        int _printCnt = 1;
        int _columnCnt = 0;

        #endregion

        #region < CONSTRUCTOR >

        public MM0010()
        {
            InitializeComponent();

            BizTextBoxManager btbManager;
            btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });
            btbManager.PopUpAdd(txt_WHCODE_H, txt_WHNAME_H, "BM0080", new object[] { cbo_PLANTCODE_H, "", "" });

            this.plantCode = CModule.GetAppSetting("Site", "10");

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

        #region  < FORM LOAD >
        private void MM0010_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TMPINDATE", "가입고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "POSEQNO", "순번", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TMPINGROUPNO", "발주그룹번호", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고코드", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "창고명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "위치코드", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "위치명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTBASEQTY", "최초 수량", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "현재 수량", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "LOT상태", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRINTSEQ", "재발행횟수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false);

            grid1.Columns["LOTBASEQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region < COMBOBOX SETTING >

            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = plantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("LOTSTATUS");  //LOT상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0080_CODE("");  //창고
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0090_CODE(""); // 저장위치
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STORAGELOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-5);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            if (!CheckData())
            {
                return;
            }
            try
            {
                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);                          // 사업장
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);           // 가입고 시작일자
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);             // 가입고 완료일자
                string sItemCode = this.txt_ITEMCODE_H.Text.Trim();                                  // 품목
                string sWhCode = this.txt_WHCODE_H.Text.Trim();                                    // 창고코드
                string sPoNo = this.txt_PONO_H.Text.Trim();                                      // 발주번호
                string sLotNO = this.txt_LOTNO_H.Text.Trim();                                     // LOT번호
                string SCHKLOT = Convert.ToString(chk_LOTNO_H.Checked);


                rtnDtTemp = helper.FillTable("USP_MM0010_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_LOTNO", sLotNO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_CHKLOT", SCHKLOT, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
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


        #region < EVENT AREA >

        private void btn_PRINT_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (grid1.ActiveCell != null)
                {
                    string sLotNO = DBHelper.nvlString(grid1.ActiveRow.Cells["LOTNO"].Value);

                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("exec USP_CALLPRINT_I1 ");
                    sSQL.Append("  @AS_PLANTCODE = '" + DBHelper.nvlString(cbo_PLANTCODE_H.Value) + "' ");
                    sSQL.Append(", @AS_LOTNO = '" + sLotNO + "' ");
                    sSQL.Append(", @AS_WORKCENTERCODE = '" + "WC0000" + "' ");
                    sSQL.Append(", @AS_CIP = '' ");
                    sSQL.Append(", @AS_REISSUE = 'R' ");

                    helper.ExecuteNoneQuery(sSQL.ToString());
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

        private void btn_PRINT_H_Click(object sender, EventArgs e)
        {

        }

        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }

        private void grid1_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "CHK")
            {
                bool chk = Convert.ToString(this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value).ToUpper() == "1" ? true : false;

                if (chk == true)
                {
                    this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = false;
                }
                else
                {
                    this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = true;
                }
            }
        }

        #endregion


        #region < USER METHOD AREA >

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
                serialPort1.Close();
                return;
            }
        }

        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_STARTDATE_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_ENDDATE_H.Value));
            if (sSrart > sEnd)
            {
                // this.ShowDialog("시작일자를 종료일자보다 이전으로 선택해주십시오.", Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }

        private void SendPrint(string sPlantCode, string sPoNo, string sLotno, string sRemark)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_MM0010_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_LOTNO", sLotno, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rb_ZBPRINT_B.Checked == true)
                    {
                        Thread.Sleep(500);

                        StringBuilder command = new StringBuilder();

                        switch (helper.DBConnect.Database.ToString())
                        {
                            case "DAEHWA":

                                command.AppendLine("^XA");
                                command.AppendLine("^MMT");
                                command.AppendLine("^PW639");
                                command.AppendLine("^LL0759");
                                command.AppendLine("^LS0");
                                command.AppendLine("^SEE:UHANGUL.DAT^FS");
                                command.AppendLine("^CW1,E:KFONT3.FNT^CI26^FS");
                                command.AppendLine("^FO21,27^GB612,718,4^FS");
                                command.AppendLine("^FT200,86^A1N,44,55^FH^FD자재식별표^FS");

                                command.AppendLine("^FT57,170^A1N,34,33^FH^FD품명^FS");
                                command.AppendLine("^FT179,170^A1N,34,33^FH^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]) + "^FS");

                                command.AppendLine("^FT57,272^A1N,34,33^FH^FD차종^FS");
                                command.AppendLine("^FT221,272^A1N,34,33^FH^FD" + Convert.ToString(rtnDtTemp.Rows[0]["CARTYPE"]) + "^FS");

                                command.AppendLine("^FT360,272^A1N,34,33^FH^FD수량^FS");
                                command.AppendLine("^FT495,272^A1N,34,33^FH^FD" + Convert.ToString(rtnDtTemp.Rows[0]["LOTBASEQTY"]) + " " +
                                                                                  Convert.ToString(rtnDtTemp.Rows[0]["UNITCODE"]) + "^FS");

                                command.AppendLine("^FT30,374^A1N,34,33^FH^FDLOT NO^FS");
                                command.AppendLine("^FT275,374^A1N,34,33^FH^FD" + Convert.ToString(rtnDtTemp.Rows[0]["LOTNO"]) + "^FS");


                                command.AppendLine("^FT30,472^A1N,34,33^FH^FD입고일자^FS");
                                command.AppendLine("^FT275,472^A1N,34,33^FH^FD" + Convert.ToString(rtnDtTemp.Rows[0]["TMPINDATE"]) + "^FS");

                                command.AppendLine("^FT45,566^A1N,34,33^FH^FD입고처^FS");
                                command.AppendLine("^FT275,566^A1N,34,33^FH^FD" + Convert.ToString(rtnDtTemp.Rows[0]["CUSTNAME"]) + "^FS");

                                command.AppendLine("^BY2,2,80^FT120,701^B3N,N,,Y,N");
                                command.AppendLine("^FD" + Convert.ToString(rtnDtTemp.Rows[0]["LOTNO"]) + "^FS");

                                command.AppendLine("^FO162,108^GB0,487,6^FS");
                                command.AppendLine("^FO320,206^GB0,105,5^FS");
                                command.AppendLine("^FO484,206^GB0,105,5^FS");
                                command.AppendLine("^FO21,506^GB610,0,7^FS");
                                command.AppendLine("^FO21,406^GB610,0,7^FS");
                                command.AppendLine("^FO21,306^GB610,0,7^FS");
                                command.AppendLine("^FO21,206^GB610,0,7^FS");
                                command.AppendLine("^FO21,106^GB613,0,6^FS");
                                command.AppendLine("^FO21,593^GB610,0,6^FS");
                                command.AppendLine("^PQ1,0,1,Y^XZ");


                                break;

                            default:
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

                                break;

                        }

                        WIZ.Common.SendStringToBytePrinter("ZT410", command.ToString());

                        //byte[] b = Encoding.Default.GetBytes(command.ToString());
                        //serialPort1.Write(b, 0, b.Length);

                        DBHelper helper2 = new DBHelper("", true);
                        string RS_MSG = string.Empty;
                        string RS_CODE = string.Empty;

                        try
                        {
                            helper2.ExecuteNoneQuery("USP_MM0010_U1", CommandType.StoredProcedure
                                                                    , helper2.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(rtnDtTemp.Rows[0]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper2.CreateParameter("AS_LOTNO", DBHelper.nvlString(rtnDtTemp.Rows[0]["LOTNO"]), DbType.String, ParameterDirection.Input)
                                                                    , helper2.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                                                                    , helper2.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                        }
                        catch (Exception ex)
                        {
                            helper2.Rollback();
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            helper2.Close();
                        }
                    }
                    //일반프린터로 발행시..
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

                            DBHelper helper3 = new DBHelper("", true);
                            string RS_MSG = string.Empty;
                            string RS_CODE = string.Empty;

                            try
                            {
                                helper3.ExecuteNoneQuery("USP_MM0010_U1", CommandType.StoredProcedure
                                                                        , helper3.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(rtnDtTemp.Rows[0]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                        , helper3.CreateParameter("AS_LOTNO", DBHelper.nvlString(rtnDtTemp.Rows[0]["LOTNO"]), DbType.String, ParameterDirection.Input)
                                                                        , helper3.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                                                                        , helper3.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            }
                            catch (Exception ex)
                            {
                                helper3.Rollback();
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                helper3.Close();
                            }
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
                serialPort1.Close();
                helper.Close();
            }
        }

        #endregion 
    }
}
#endregion

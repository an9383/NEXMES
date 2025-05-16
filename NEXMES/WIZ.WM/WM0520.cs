#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0520
//   Form Name    : 신규 LOT 생성 (식별표 포함)
//   Name Space   : WIZ.WM
//   Created Date : 2015-09-17
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Configuration;
using System.Data;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0520 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        UltraGridUtil _GridUtil = new UltraGridUtil();
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable Dt = new DataTable(); // return DataTable 공통

        private string plantCode = string.Empty; //plantcode default 설정
        private string sPlantCode = string.Empty;
        private string sMatLotNo = string.Empty;
        #endregion

        #region < CONSTRUCTOR >

        public WM0520()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode, "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600Y", new object[] { "", "Y", "" });
            btbManager.PopUpAdd(txtWorkerID, txtWorkerNM, "TBM0200", new object[] { cboPlantCode, "", "", "", "Y", "", "", "" });

            this.plantCode = CModule.GetAppSetting("Site", "10");

            txtUnitCode.MaxLength = 2;

        }
        #endregion

        #region  WM0520_Load
        private void WM0520_Load(object sender, EventArgs e)
        {

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");

            cboPlantCode.Value = plantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("LOTSTATUS");  //LOT상태

            //rtnDtTemp = _Common.GET_TBM0800_CODE(sPlantCode);  //창고
            //GetWHCODE();

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE", "MINORCODE = 'WH008'");
            WIZ.Common.FillComboboxMaster(this.cboWhCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");



            rtnDtTemp = _Common.GET_BM0000_CODE("STORAGELOCCODE", "RELCODE1 = '" + cboWhCode.Value + "'");  // 저장위치
            WIZ.Common.FillComboboxMaster(this.cboStoreageLocCodeI, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");

            #endregion

            cboIndate_H.Value = DateTime.Now;

            cboWhCode.Value = "WH008";
        }
        #endregion  WM0520_Load

        #region <TOOL BAR AREA >

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DBHelper helper = new DBHelper("", true);
            string RS_MSG = string.Empty;
            string RS_CODE = string.Empty;

            string sPlantCode = Convert.ToString(cboPlantCode.Value);
            string sWORKCENTERCODE = Convert.ToString(txtWorkCenterCode.Text);
            string sItemCode = Convert.ToString(txtItemCode_H.Text);
            string sQty = Convert.ToString(txtQty.Text);
            string sUnitCode = Convert.ToString(txtUnitCode.Text);
            string sWHCode = Convert.ToString(cboWhCode.Value);
            string sStorageLocCode = Convert.ToString(cboStoreageLocCodeI.Value);
            string sWorkerID = Convert.ToString(txtWorkerID.Text);
            string sOrderNo = Convert.ToString(txtOrderNo.Text);
            string sIndate = Convert.ToString(cboIndate_H.Value);

            // 사용자가 직접 입력하지 않고 팝업을 통해 선택함
            // 선택하지 않은 경우는 작업지시 자동채번
            if (sOrderNo == "")
            {
                sOrderNo = "X";
            }

            if (sWORKCENTERCODE == "")
            {
                this.ShowDialog(Common.getLangText("작업장을 선택하세요.", "MSG"), Forms.DialogForm.DialogType.YESNO);
                return;
            }

            if (sPlantCode == "")
            {
                this.ShowDialog(Common.getLangText("공장을 선택하세요.", "MSG"), Forms.DialogForm.DialogType.YESNO);
                return;
            }

            if (cboIndate_H.Text == "")
            {
                this.ShowDialog(Common.getLangText("입고일을 선택하세요.", "MSG"), Forms.DialogForm.DialogType.YESNO);
                return;
            }

            if (sWORKCENTERCODE == "")
            {
                this.ShowDialog(Common.getLangText("발주처를 선택하세요.", "MSG"), Forms.DialogForm.DialogType.YESNO);
                return;
            }

            if (sItemCode == "")
            {
                this.ShowDialog(Common.getLangText("품목을 선택하세요.", "MSG"), Forms.DialogForm.DialogType.YESNO);
                return;
            }

            if (sQty == "" || sQty == "0")
            {
                this.ShowDialog(Common.getLangText("수량을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.YESNO);
                return;
            }

            if (sUnitCode == "")
            {
                this.ShowDialog(Common.getLangText("단위를 입력하세요.", "MSG"), Forms.DialogForm.DialogType.YESNO);
                return;
            }

            if (sWHCode == "ALL")
            {
                this.ShowDialog(Common.getLangText("창고를 선택하세요.", "MSG"), Forms.DialogForm.DialogType.YESNO);
                return;
            }

            if (sStorageLocCode == "ALL")
            {
                this.ShowDialog(Common.getLangText("저장위치를 선택하세요.", "MSG"), Forms.DialogForm.DialogType.YESNO);
                return;
            }

            if (sWorkerID == "")
            {
                sWorkerID = this.WorkerID;
            }

            try
            {
                DialogResult result = this.ShowDialog(Common.getLangText("신규 LOT 생성 하시겠습니까?", "MSG"), Forms.DialogForm.DialogType.YESNO);
                if (result.ToString().ToUpper() == "CANCEL") return;

                helper.ExecuteNoneQuery("USP_WM0520_I1", CommandType.StoredProcedure
                                                       , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("WORKCENTERCODE", sWORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("QTY", sQty, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("UNITCODE", sUnitCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("WHCODE", sWHCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("STORAGELOCCODE", sStorageLocCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("WORKERID", sWorkerID, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("INDATE", sIndate, DbType.String, ParameterDirection.Input)
                                                       );

                if (helper.RSCODE == "S")
                {
                    //신규 LOT번호
                    txtLotNo.Text = helper.RSMSG;
                    sMatLotNo = Convert.ToString(txtLotNo.Text);

                    helper.Commit();
                    this.ShowDialog(Common.getLangText("신규 LOT 생성을 완료하였습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                    //등록시 발행
                    if (chkPrint.Checked == true)
                    {
                        //DoPrint();
                        SendPrint(sPlantCode, sMatLotNo);
                    }

                }
                else
                {
                    helper.Rollback();
                    MessageBox.Show(helper.RSMSG, "신규 LOT 생성 실패");
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                RS_CODE = "E";
                RS_MSG = ex.Message.ToString();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion
        #region <METHOD AREA>

        #endregion

        private void txtInQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                // 숫자입력 메시지창 표현.
                this.ShowDialog(Common.getLangText("숫자만 입력 가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                e.Handled = true;
            }

        }

        private void cboWhCodeI_ValueChanged(object sender, EventArgs e)
        {
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("STORAGELOCCODE", "RELCODE1 = '" + cboWhCode.Value + "'");  // 저장위치
            WIZ.Common.FillComboboxMaster(this.cboStoreageLocCodeI, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
        }

        private void SendPrint(string PlantCode, string Lotno)
        {
            //시리얼 열기
            //openSerial();

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_WM0520_S1"
                                                          , CommandType.StoredProcedure
                                                          , helper.CreateParameter("PLANTCODE", PlantCode, DbType.String, ParameterDirection.Input)
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

        private void txtUnitCode_KeyPress(object sender, KeyPressEventArgs e)
        {

            string str = e.KeyChar.ToString().ToUpper();
            char[] ch = str.ToCharArray();
            e.KeyChar = ch[0];

            if (!(char.IsLetter(e.KeyChar)) && e.KeyChar != 8)
            {
                this.ShowDialog(Common.getLangText("영문자만 입력 가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                e.Handled = true;
            }
        }

        private void txtUnitCode_Leave(object sender, EventArgs e)
        {
            if (txtUnitCode.Text.Length == 0)
                return;
            Regex regex = new Regex(@"[a-zA-Z]");
            Boolean ismatch = regex.IsMatch(txtUnitCode.Text);
            if (!ismatch)
            {
                this.ShowDialog(Common.getLangText("영문자만 입력 가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                txtUnitCode.Text = "";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtLotNo.Text == "")
            {
                this.ShowDialog(Common.getLangText("먼저 LOT을 생성하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }
            //DoPrint();
            SendPrint(plantCode, sMatLotNo);
        }

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
                command.AppendLine("   AND MINORCODE  = 'WH008' ");
                command.AppendLine("   AND MINORCODE <> '$'   ");
                command.AppendLine(" ORDER BY MINORCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(this.cboWhCode, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, "");
                //this.cboWhCode.Value = "WH005";
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

        private void GetWORKCNETERNAME()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string PLANTCODE = Convert.ToString(this.cboPlantCode.Value);
                string WORKCENTERCODE = this.txtWorkCenterCode.Text.Trim();

                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT DISTINCT dbo.FN_Translate('KO', WORKCENTERNAME,'BM0600Y') AS WORKCENTERNAME ");
                command.AppendLine("  FROM TBM0600Y  WITH (NOLOCK)                                         ");
                command.AppendLine(" WHERE 1=1                                                            ");
                command.AppendLine("   AND PlantCode = '" + PLANTCODE + "'                                ");
                command.AppendLine("   AND WORKCENTERCODE = '" + WORKCENTERCODE + "'                                  ");


                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                if (dttemp.Rows.Count > 0)
                {
                    this.txtWorkCenterName.Text = dttemp.Rows[0]["WORKCENTERNAME"].ToString();
                }

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
        private void GetITEMNAME()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string PLANTCODE = Convert.ToString(this.cboPlantCode.Value);
                string ITEMCODE = this.txtItemCode_H.Text.Trim();

                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT DISTINCT  dbo.FN_Translate('KO', ITEMNAME,'BM0100Y') AS ITEMNAME ");
                command.AppendLine("  FROM TBM0100Y  WITH (NOLOCK)                             ");
                command.AppendLine(" WHERE 1=1                                                  ");
                command.AppendLine("   AND ITEMCODE = '" + ITEMCODE + "'                        ");
                command.AppendLine("   AND PlantCode = '" + PLANTCODE + "'                     ");


                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                if (dttemp.Rows.Count > 0)
                {
                    this.txtItemName_H.Text = dttemp.Rows[0]["ITEMNAME"].ToString();
                }

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
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            try
            {
                POP_WM0520 POP_WM0520 = new POP_WM0520();
                POP_WM0520.ShowDialog();

                if (POP_WM0520.Tag != null)
                {
                    string[] words = POP_WM0520.Tag.ToString().Split(',');
                    this.cboPlantCode.Value = words[0];
                    this.txtOrderNo.Text = words[1];
                    this.txtItemCode_H.Text = words[2];
                    this.txtWorkCenterCode.Text = words[3];
                    this.txtUnitCode.Text = words[4];
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {

            }
        }

        //private void txtWORKCENTERCODE_TextChanged(object sender, EventArgs e)
        //{
        //    GetWORKCNETERNAME();
        //}

        private void txtItemCode_H_TextChanged(object sender, EventArgs e)
        {
            GetITEMNAME();
        }

        private void ultraButton1_Click_1(object sender, EventArgs e)
        {
            txtOrderNo.Text = string.Empty;
            txtWorkCenterCode.Text = string.Empty;
            txtWorkCenterName.Text = string.Empty;
            txtItemCode_H.Text = string.Empty;
            txtItemName_H.Text = string.Empty;
            txtUnitCode.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtWorkerID.Text = string.Empty;
            txtWorkerNM.Text = string.Empty;
        }

        private void txtWorkCenterCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                GetWORKCNETERNAME();
            }
        }
    }
}


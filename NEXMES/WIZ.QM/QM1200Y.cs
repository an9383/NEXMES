#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  QM1200Y
//   Form Name    : 자재LOT(발행) 정보 관리
//   Name Space   : WIZ.MM
//   Created Date : 
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
using System.Windows.Forms;

#endregion

namespace WIZ.QM
{
    public partial class QM1200Y : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        #endregion

        #region < CONSTRUCTOR >

        public QM1200Y()
        {
            InitializeComponent();


        }
        #endregion

        #region  QM1200Y_Load
        private void QM1200Y_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRTDATE", "수불일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "POSEQNO", "순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO", "불량 LOTNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTSIZE", "불량 수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PREINDATE", "판정일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT", "판정결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            string[] arrMerCol1 = { "INSPDATE", "INSPRESULT" };

            _GridUtil.GridHeaderMerge(grid1, "A", "수입검사", arrMerCol1, null);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.plantCode = CModule.GetAppSetting("Site", "10");
            cboPlantCode_H.Value = plantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("LOTSTATUS");  //LOT상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            //BizTextBoxManager btbManager;
            //btbManager = new BizTextBoxManager();
            //btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "ROH" });
            //btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0310Y", new object[] { "", "" });



        }
        #endregion  QM1200Y_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            base.DoInquire();

        }

        #endregion

        public override void DoReport()
        {
            //base.DoReport();
            btnMM0010_Click(null, null);
        }

        #region<btnMM0010_Click>
        private void btnMM0010_Click(object sender, EventArgs e)
        {
            int cnt = 0;

            if (grid1.Rows.Count == 0) return;

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                if (grid1.Rows[i].Cells["CHK"].Value.ToString() == "True")
                {
                    string sPlantCode = grid1.Rows[i].Cells["PLANTCODE"].Value.ToString();
                    string sPoNo = grid1.Rows[i].Cells["PONO"].Value.ToString();
                    string sLotno = grid1.Rows[i].Cells["MATLOTNO"].Value.ToString();
                    //string sCHK          = Convert(
                    //라벨출력
                    SendPrint(sPlantCode, sPoNo, sLotno);
                }
                else
                {
                    cnt++;
                }
            }
            if (cnt == grid1.Rows.Count)
            {
                this.ShowDialog(Common.getLangText("재발행할 데이터를 선택 후, 버튼을 눌러주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
        }
        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txtItemCode.Tag = null;
                txtItemCode.Text = string.Empty;
                txtItemName.Text = string.Empty;
            }
        }

        private void txtItemCode_ButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    string[] values = { Convert.ToString(cboPlantCode_H.Value), "" };
            //    POP_TBM0100 _frmA = new POP_TBM0100(values);
            //    _frmA.ShowDialog();
            //    rtnDtTemp = (DataTable)_frmA.Tag;
            //    if (rtnDtTemp.Rows.Count > 0)
            //    {
            //        txtItemCode.Text = Convert.ToString(rtnDtTemp.Rows[0][0]);
            //        txtItemName.Text = Convert.ToString(rtnDtTemp.Rows[0][1]);
            //    }
            //    _frmA.Dispose();
            //}
            //catch
            //{
            //}
        }
        private void SendPrint(string PlantCode, string PoNo, string Lotno)
        {
            //시리얼 열기
            //openSerial();

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_QM1200YY_S2"
                                                          , CommandType.StoredProcedure
                                                          , helper.CreateParameter("PLANTCODE", PlantCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("PONO", PoNo, DbType.String, ParameterDirection.Input)
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

                        command.AppendLine("^FO" + "580,50" + "^A1R,50,35" + " ^FD" + "입고일자" + "^FS");
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
                        command.AppendLine("^FO" + "345,250" + "^A1R,30,30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["CUSTLOTNO"]) + "^FS");

                        command.AppendLine("^FO" + "580,760" + "^A1R,50,50" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["BARCODE"]).Substring(10, 3) + "^FS"); //순번

                        command.AppendLine("^FO" + "640,100" + "^A1R,50,50" + " ^FD" + "부품식별표" + "^FS");
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

        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cboPlanIndate1_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cboPlanIndate2_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("조회 시작일자가 종료일자보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }

        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }
        #endregion

        private void txtCustCode_ButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    string[] values = { "", "" };
            //    POP_TBM0310Y _frmA = new POP_TBM0310Y(values);
            //    _frmA.ShowDialog();
            //    rtnDtTemp = (DataTable)_frmA.Tag;
            //    if (rtnDtTemp.Rows.Count > 0)
            //    {
            //        txtCustCode.Text = Convert.ToString(rtnDtTemp.Rows[0][0]);
            //        txtCustName.Text = Convert.ToString(rtnDtTemp.Rows[0][1]);
            //    }
            //    _frmA.Dispose();
            //}
            //catch
            //{
            //}
        }

        private void txtCustCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txtCustCode.Tag = null;
                txtCustCode.Text = string.Empty;
                txtCustName.Text = string.Empty;
            }
        }
    }
}

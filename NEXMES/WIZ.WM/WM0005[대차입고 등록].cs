#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0005
//   Form Name    : 제품입고 등록
//   Name Space   : WIZ.WM
//   Created Date : 2018-04-10
//   Made By      : 
//   Edited Date  : 
//   Edit By      :
//   Description  : 제품입고 시, 라벨 교체 및 박스당 수량 입력
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

namespace WIZ.WM
{
    public partial class WM0005 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA > 
        UltraGridUtil _GridUtil = new UltraGridUtil();

        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();

        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        int _chkCnt = 0;
        int _printCnt = 1;
        int _columnCnt = 0;
        DataRow dRow;
        WM0060_POP_TEL WM0060_POP_TEL; //완제품 식별표
        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        string _sFlag; // "Y" = 검사 후 입고, "N" = 입고 후 검사

        #endregion

        #region < CONSTRUCTOR >
        public WM0005()
        {
            InitializeComponent();

            //SearchFlag();
        }
        #endregion

        #region < FORM LOAD >
        private void WM0005_Load(object sender, EventArgs e)
        {
            #region GRID SETTING

            _GridUtil.InitializeGrid(grid1, true, true, false, "", false);

            //_GridUtil.InitColumnUltraGrid(grid1, "CHK",       "선택",     false, GridColDataType_emu.CheckBox,    70, 100, Infragistics.Win.HAlign.Center, true,  true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "입고창고", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOC", "입고위치", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "입고일시", false, GridColDataType_emu.DateTime24, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region COMBOBOX SETTING
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-30);
            cbo_ENDDATE_H.Value = DateTime.Now;
            txt_ITEMCODE_H.Value = "CARRIER";
            txt_ITEMNAME_H.Value = "CARRIER";
            txtLOTNO.Select();

            #endregion

            #region POPUP SETTING
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "4", "" });  // 품목

            #endregion

        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");
                string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sLotNo = DBHelper.nvlString(txtLOTNO.Text.Trim());

                rtnDtTemp = helper.FillTable("USP_WM0005_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >

        private void btnBoxIn_Click(object sender, EventArgs e)
        {
            if (txtLOTNO.Text == "")
            {
                ShowDialog(Common.getLangText("입고 할 대차 LOT정보가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            string sItemCode1 = string.Empty;
            string sItemCode2 = string.Empty;

            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_WM0005_I2", CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_WORKCENTERCODE", "WC0000", DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", "FRAME", DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_LOTNO", txtLOTNO.Value.ToString(), DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE != "S")
                {
                    helper.Rollback();
                    ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    return;
                }

                helper.Commit();

            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
                return;
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
                txtLOTNO.Text = "";
                DoInquire();


            }

        }


        #endregion

        #region < USER METHOD AREA >
        private void btn_PRINT_H_Click(object sender, EventArgs e)
        {
            //int unChkCnt = 0;

            //if (grid1.Rows.Count == 0) return;

            //MM0010_POP MM0010_POP = new MM0010_POP();
            //MM0010_POP.ShowDialog();

            //if (MM0010_POP._sRemark == string.Empty)
            //    return;

            //string sRemark = MM0010_POP._sRemark;

            if (txtFrameNo.Text == "")
            {
                ShowDialog(Common.getLangText("출력 할 대차정보가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            SendPrint(cbo_PLANTCODE_H.Value.ToString(), txtFrameNo.Text);

            //for (int i = 0; i < grid1.Rows.Count; i++)
            //{
            //    if (grid1.Rows[i].Cells["CHK"].Value.ToString() == "1")
            //        _chkCnt++;
            //}

            //for (int i = 0; i < grid1.Rows.Count; i++)
            //{
            //    if (grid1.Rows[i].Cells["CHK"].Value.ToString() == "1")
            //    {
            //        string sPlantCode = grid1.Rows[i].Cells["PLANTCODE"].Value.ToString();
            //        string sLotno = grid1.Rows[i].Cells["LOTNO"].Value.ToString();

            //        SendPrint(sPlantCode, sLotno, sRemark);
            //    }
            //    else
            //    {
            //        unChkCnt++;
            //    }

            //    _printCnt = 1;
            //    _chkCnt = 0;

            //    if (unChkCnt == grid1.Rows.Count)
            //    {
            //        this.ShowDialog(Common.getLangText("재발행할 데이터를 선택 후, 버튼을 눌러주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            //        return;
            //    }

            //}
        }

        private void SendPrint(string sPlantCode, string sLotno)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                //DataTable rtnDtTemp = helper.FillTable("USP_WM0005_S2", CommandType.StoredProcedure
                //                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                //                       , helper.CreateParameter("AS_LOTNO", sLotno, DbType.String, ParameterDirection.Input));


                if (rb_ZBPRINT_B.Checked == true)
                {
                    openSerial();

                    if (!serialPort1.IsOpen)
                    {
                        return;
                    }

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
                    command.AppendLine("^FO" + "625, 740" + "^A1R, 40, 40" + " ^FD" + Convert.ToString(cbo_PLANTCODE_H.Value) + "^FS");

                    command.AppendLine("^FO" + "555, 70" + "^A1R, 30, 30" + " ^FD" + "LOT No" + "^FS");
                    command.AppendLine("^FO" + "555, 230" + "^A1R, 30, 30" + " ^FD" + txtFrameNo.Text.Trim() + "^FS");

                    //command.AppendLine("^FO" + "555, 515" + "^A1R, 30, 30" + " ^FD" + "입고일자" + "^FS");
                    //command.AppendLine("^FO" + "555, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["INDATE"]) + "^FS");

                    //command.AppendLine("^FO" + "495, 70" + "^A1R, 30, 30" + " ^FD" + "품목유형" + "^FS");
                    //command.AppendLine("^FO" + "495, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMTYPE"]) + "^FS");

                    command.AppendLine("^FO" + "495, 530" + "^A1R, 30, 30" + " ^FD" + "수    량" + "^FS");
                    command.AppendLine("^FO" + "495, 700" + "^A1R, 30, 30" + " ^FD" + "1" + "^FS");

                    command.AppendLine("^FO" + "435, 70" + "^A1R, 30, 30" + " ^FD" + "품목코드" + "^FS");
                    command.AppendLine("^FO" + "435, 230" + "^A1R, 30, 30" + " ^FD" + txt_ITEMCODE_H.Text.Trim() + "^FS");

                    //command.AppendLine("^FO" + "375, 70" + "^A1R, 30, 30" + " ^FD" + "품 목 명" + "^FS");
                    //if (Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]).Length < 30)
                    //    command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]) + "^FS");
                    //else if (Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]).Length < 60)
                    //    command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]) + "^FS");
                    //else
                    //    command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]) + "^FS");

                    command.AppendLine("^FO" + "225, 210" + "^BY3,4^BCR," + "80,Y,N,N" + "^FD" + txtFrameNo.Text.Trim() + "^FS");

                    //command.AppendLine("^FO" + "60, 65" + "^A1R, 30, 30" + " ^FD" + "비    고" + "^FS");
                    //command.AppendLine("^FO" + "60, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["REMARK"]) + "^FS");

                    command.AppendLine("^XZ");

                    //WIZ.Common.SendStringToBytePrinter("ZT410", command.ToString());

                    byte[] b = Encoding.Default.GetBytes(command.ToString());
                    serialPort1.Write(b, 0, b.Length);
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

        #endregion 

    }
}
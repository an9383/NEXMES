#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : POP_MM0001Y
//   Form Name    : 자재 가입고 처리
//   Name Space   : WIZ.POPUP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : MM0000Y에서 가입고 버튼 CLICK시 POPUP 호출
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

#endregion

namespace WIZ.PopUp
{
    public partial class POP_MM0001Y : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >
        private string sPlantCode = string.Empty;                   //공장
        private string sPoNo = string.Empty;                   //거래번호(PONO)
        private string sPoOrderDate = string.Empty;                   //발주일
        private string sPoSeqNo = string.Empty;                   //거래순번(POSEQ)
        private string sPlanInDate = string.Empty;                   //입고예정일자
        private string sCustCode = string.Empty;                   //거래처
        private string sCustName = string.Empty;                   //거래처명
        private string sItemCode = string.Empty;                   //품목
        private string sItemName = string.Empty;                   //품목명
        private string sMaterialgrade = string.Empty;                   //재질
        private string sItemSpec = string.Empty;                   //규격
        private string sItemType = string.Empty;                   //품목분류
        private string sUnitCode = string.Empty;                   //단위
        private string sPoOrderQty = string.Empty;                   //발주량(A)
        private string sGaTotInQty = string.Empty;                   //총 가입고 중량(B)
        private string sTotInQty = string.Empty;                   //입고 중량
        private string sReInQty = string.Empty;                   //입고 잔량(A-B)
        private string sPreInGroupNo = string.Empty;

        UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성

        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        #endregion

        #region < CONSTRUCTOR >
        public POP_MM0001Y()
        {
            InitializeComponent();
        }

        public POP_MM0001Y(DataRow drRow)
        {
            InitializeComponent();

            sPlantCode = Convert.ToString(drRow["PLANTCODE"]);
            sPoNo = Convert.ToString(drRow["PONO"]);
            sPoOrderDate = Convert.ToString(drRow["POORDERDATE"]);
            sPoSeqNo = Convert.ToString(drRow["POSEQNO"]);
            sPlanInDate = Convert.ToString(drRow["PLANINDATE"]).Substring(0, 10);
            sCustCode = Convert.ToString(drRow["CUSTCODE"]);
            sCustName = Convert.ToString(drRow["CUSTNAME"]);
            sItemCode = Convert.ToString(drRow["ITEMCODE"]);
            sItemName = Convert.ToString(drRow["ITEMNAME"]);
            sMaterialgrade = Convert.ToString(drRow["MATERIALGRADE"]);
            sItemSpec = Convert.ToString(drRow["ITEMSPEC"]);
            sItemType = Convert.ToString(drRow["ITEMTYPE"]);
            //sItemTypeCode  = Convert.ToString(drRow["ITEMTYPECODE"]);
            sUnitCode = Convert.ToString(drRow["UNITCODE"]);
            sPoOrderQty = Convert.ToString(drRow["POORDERQTY"]);
            sGaTotInQty = Convert.ToString(drRow["TOTGAINQTY"]);
            sTotInQty = Convert.ToString(drRow["TOTINQTY"]);
            sReInQty = Convert.ToString(drRow["REINQTY"]);


            txtPONo.Text = sPoNo;
            txtPOSeq.Text = sPoSeqNo;
            txtPlanInDate.Text = sPlanInDate;
            txtCustName.Text = sCustName;
            txtItemCode.Text = sItemCode;
            txtItemName.Text = sItemName;
            txtMaterialgrade.Text = sMaterialgrade;
            txtItemSpec.Text = sItemSpec;
            txtItemType.Text = sItemType;
            txtUnitCode.Text = sUnitCode;
            txtPoOrderQty.Text = sPoOrderQty;    //발주수량(A)
            txtStockQty.Text = sTotInQty;      //입고수량
            txtTotInQty.Text = sGaTotInQty;    //총 가입고 수량(B)
            txtReInQty.Text = sReInQty;       //입고잔량(A-B)

            lblNotice.ForeColor = Color.Red;

            if (sUnitCode == "EA")
                lblInputQty.Text = "가입고 수량";

            if (sItemType == "3")
            {
                lblInputCnt.Visible = false;
                txtInputCnt.Visible = false;
            }
        }
        #endregion

        #region < FORM EVENT >
        private void POP_MM0001Y_Load(object sender, EventArgs e)
        {
            #region < GRID >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO", "바코드", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTBASEQTY", "수량", true, GridColDataType_emu.Integer, 70, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            this.grid1.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            this.grid1.DisplayLayout.Bands[0].Summaries.Add("합계", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["MATLOTNO"]);
            this.grid1.DisplayLayout.Bands[0].Summaries[0].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["MATLOTNO"];
            this.grid1.DisplayLayout.Bands[0].Summaries[0].DisplayFormat = "합계";
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Key = "MATLOTNO";
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.TextHAlign = HAlign.Center;
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.FontData.SizeInPoints = 9;
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.BackColor = Color.FromArgb(255, 228, 225);
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.ForeColor = Color.Black;
            this.grid1.DisplayLayout.Bands[0].Summaries[0].SummaryDisplayArea = SummaryDisplayAreas.Top;


            this.grid1.DisplayLayout.Bands[0].Summaries.Add("SUM([LOTBASEQTY])", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["LOTBASEQTY"]);
            this.grid1.DisplayLayout.Bands[0].Summaries[1].DisplayFormat = "{0:#,##0}";
            this.grid1.DisplayLayout.Bands[0].Summaries[1].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["LOTBASEQTY"];
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Key = "LOTBASEQTY";
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.TextHAlign = HAlign.Right;
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.FontData.SizeInPoints = 10;
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.BackColor = Color.FromArgb(255, 228, 225);
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.ForeColor = Color.Black;
            this.grid1.DisplayLayout.Bands[0].Summaries[1].SourceColumn.Format = "#,##0";
            this.grid1.DisplayLayout.Bands[0].Summaries[1].SummaryPositionColumn.Format = "#,##0";
            this.grid1.DisplayLayout.Bands[0].Summaries[1].SummaryDisplayArea = SummaryDisplayAreas.Top;
            this.grid1.DisplayLayout.Bands[0].Summaries[1].SummaryType = SummaryType.Sum;

            #endregion 

        }

        #endregion

        #region < USER METHOD AREA >
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

        /// <summary>
        /// 식별표 발행, 닫기 버튼 클릭 시 발주번호 상태 변경 로직 
        /// </summary>
        private void UpdateFinishFlag()
        {
            int iPoOrderQty = Convert.ToInt32(txtPoOrderQty.Text);  //발주수량
            int iTotInQty = Convert.ToInt32(txtTotInQty.Text);      //가입고수량
            string sFinishFlag = string.Empty;

            //업데이트 시 가입고 수량이 0인 경우..
            if (iTotInQty == 0)
            {
                return;
            }

            if (iPoOrderQty <= iTotInQty)
            {
                //발주수량 <= 가입고 수량일 경우.. 발주완료 처리..
                sFinishFlag = "F";
            }
            else
            {
                //그 외..진행상태
                sFinishFlag = "I";
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_POP_MM0000Y_U1"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_POSEQNO", sPoSeqNo, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_FINISHFLAG", sFinishFlag, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                }
                else
                {
                    helper.Rollback();
                    MessageBox.Show(helper.RSMSG);
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

        /// <summary>
        /// 발행그룹번호 채번
        /// </summary>
        private void PreInGroupNo()
        {
            DBHelper getGroupNo = new DBHelper(false);

            try
            {
                /*
                DataTable rtnDtTemp = getGroupNo.FillTable("USP_CREATE_SEQ"
                                                          , CommandType.StoredProcedure
                                                          , getGroupNo.CreateParameter("@AS_HEADER", "G", DbType.String, ParameterDirection.Input)
                                                          , getGroupNo.CreateParameter("@AS_YMD",    DateTime.Now.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                                                          , getGroupNo.CreateParameter("@AS_SUBDATA", "",  DbType.String, ParameterDirection.Input)
                                                          , getGroupNo.CreateParameter("@RS_SEQDATA",    DbType.String, ParameterDirection.Output, null, 200));
                                                          //, getGroupNo.CreateParameter("@RS_MSG",             DbType.String, ParameterDirection.Output, null, 200)); 
                */
                StringBuilder command = new StringBuilder();
                command.AppendLine("BEGIN");
                command.AppendLine(" DECLARE @MATLOTNO VARCHAR(15), @RS_MSG VARCHAR(100) ");
                command.AppendLine(" EXEC USP_CREATE_SEQ 'G', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', NULL, @MATLOTNO OUTPUT, @RS_MSG OUTPUT ");
                command.AppendLine(" SELECT @MATLOTNO AS MATLOTNO, @RS_MSG AS RS_MSG ");
                command.AppendLine("END");

                DataTable rtnDtTemp = getGroupNo.FillTable(command.ToString());

                if (Convert.ToString(rtnDtTemp.Rows[0][0]) != "NONE")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        sPreInGroupNo = Convert.ToString(rtnDtTemp.Rows[0]["COLUMN1"]);
                    }
                }
                else
                {
                    MessageBox.Show(getGroupNo.RSMSG);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                getGroupNo.Close();
            }
        }

        private void SendPrint(string PlantCode, string PoNo, string PreInGroupNo)
        {
            //시리얼 열기
            //openSerial();

            DBHelper helper = new DBHelper(false);
            DataTable rtnDtTemp2 = new DataTable();

            DataTable rtnDtTemp = helper.FillTable("USP_POP_MM0000Y_S2", CommandType.StoredProcedure
                                                                        , helper.CreateParameter("AS_PLANTCODE", PlantCode, DbType.String, ParameterDirection.Input)
                                                                        , helper.CreateParameter("AS_PONO", PoNo, DbType.String, ParameterDirection.Input)
                                                                        , helper.CreateParameter("AS_PREINGROUPNO", PreInGroupNo, DbType.String, ParameterDirection.Input));

            //DataTable rtnDtTemp = helper.FillTable("USP_POP_MM0000Y_S2", CommandType.StoredProcedure);
            try
            {

                for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                {
                    if (helper.RSCODE == "S")
                    {
                        StringBuilder command = new StringBuilder();
                        command.AppendLine("^XA");
                        command.AppendLine("^LH0,0^LL500^XZ");
                        command.AppendLine("^XA");
                        command.AppendLine("^SEE:UHANGUL.DAT^FS");
                        command.AppendLine("^CW1,E:KFONT3.FNT^CI26^FS");

                        command.AppendLine("^FO" + "530,20" + "^A0,25,20" + "^FD" + "-" + Convert.ToString(rtnDtTemp.Rows[i]["SEQNO"]) + "-" + "^FS");
                        command.AppendLine("^FO" + "195,50" + "^A0,55,35" + "^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]) + "^FS");
                        command.AppendLine("^FO" + "550,120" + "^A0,55,35" + "^FD" + Convert.ToString(rtnDtTemp.Rows[i]["UNITCODE"]) + "^FS");
                        command.AppendLine("^FO" + "450,120" + "^A0,50,35" + "^FD" + "( " + Convert.ToString(rtnDtTemp.Rows[i]["QTY"]) + " )" + "^FS");
                        command.AppendLine("^FO" + "195,120" + "^A0,50,30" + "^FD" + Convert.ToString(rtnDtTemp.Rows[i]["PRTDATE"]) + "^FS");

                        command.AppendLine("^FO" + "35, 20");
                        command.AppendLine("^BQN, 2,6^FDMM,A" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]) + "^FS");

                        command.AppendLine("^XZ");

                        WIZ.Common.SendStringToBytePrinter("ZT410", command.ToString());

                        //byte[] b = Encoding.Default.GetBytes(command.ToString());
                        //serialPort1.Write(b, 0, b.Length);
                    }
                    else
                    {
                        MessageBox.Show(helper.RSMSG);
                    }
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

        #endregion

        #region < EVENT AREA >
        private void btnClose_Click(object sender, EventArgs e)
        {
            UpdateFinishFlag();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustLotNo.Text = string.Empty;
            txtInputQty.Text = string.Empty;
            txtInputCnt.Text = string.Empty;
            txtMatLotNo1.Text = string.Empty;
            txtMatLotNo2.Text = string.Empty;
        }

        private void txtInputQty_TextChanged(object sender, EventArgs e)
        {
            if (txtInputQty.Text.Length > 0)
            {

                string value = txtInputQty.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txtInputQty.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txtInputQty.Text = txtInputQty.Text.Remove(txtInputQty.Text.Length - 1, 1);
                        txtInputQty.Select(txtInputQty.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txtInputQty.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txtInputQty.SelectionStart = txtInputQty.Text.Length;
            }
        }

        private void txtInputCnt_TextChanged(object sender, EventArgs e)
        {
            if (txtInputCnt.Text.Length > 0)
            {

                string value = txtInputCnt.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txtInputCnt.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txtInputCnt.Text = txtInputCnt.Text.Remove(txtInputCnt.Text.Length - 1, 1);
                        txtInputCnt.Select(txtInputCnt.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txtInputCnt.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txtInputCnt.SelectionStart = txtInputCnt.Text.Length;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                string sCustLotNo = txtCustLotNo.Text;
                string sMatLotNo1 = string.Empty;
                string sMatLotNo2 = string.Empty;
                string sWhCode = "WH001";
                string sStorageLocCode = Convert.ToString(cboStorage.Value);

                if (txtInputQty.Text == string.Empty)
                {
                    MessageBox.Show("가입고 중량을 입력하세요.");
                    return;
                }

                if (txtInputCnt.Text == string.Empty && sItemType == "4")
                {
                    MessageBox.Show("입고수량을 입력하세요.");
                    return;
                }

                if (grid1.Rows.Count == 0)
                {
                    MessageBox.Show("입고 수량 입력 후 엔터를 눌러주세요.");
                    return;
                }

                int iCnt;

                if (sItemType == "4")
                    iCnt = Convert.ToInt32(txtInputCnt.Text);  //가입고 수량

                int iPoOrderQty = Convert.ToInt32(txtPoOrderQty.Text);                //발주량

                int iInQty = Convert.ToInt32(txtInputQty.Text.Replace(",", ""));      //가입고 중량
                int inqty = iInQty;
                int iGaTotInqty = Convert.ToInt32(txtTotInQty.Text.Replace(",", "")); //총가입고량



                if (iPoOrderQty < iGaTotInqty + iInQty)
                {
                    DialogResult result = MessageBox.Show("가입고 수량이 발주량을 초과됩니다." + Environment.NewLine + "진행하시겠습니까?", "가입고 중량 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result.ToString().ToUpper() == "NO")
                        return;
                }

                string sInQty = string.Empty;

                PreInGroupNo(); //발행그룹번호 채번

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    sInQty = Convert.ToString(grid1.Rows[i].Cells["LOTBASEQTY"].Value).Replace(",", "");

                    helper.ExecuteNoneQuery("USP_POP_MM0000Y_I1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_POORDERDATE", sPoOrderDate, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_POSEQNO", sPoSeqNo, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_PREINGROUPNO", sPreInGroupNo, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_CUSTLOTNO", sCustLotNo, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_INQTY", sInQty, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_UNITCODE", sUnitCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_STORAGELOCCODE", sStorageLocCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                    if (i == 0)
                    {
                        sMatLotNo1 = helper.RSMSG;
                        grid1.Rows[i].Cells["MATLOTNO"].Value = sMatLotNo1;
                    }
                    else
                    {
                        sMatLotNo2 = helper.RSMSG;
                        grid1.Rows[i].Cells["MATLOTNO"].Value = sMatLotNo2;
                    }
                }

                if (helper.RSCODE == "S")
                {
                    helper.Commit();

                    if (chkPrint.Checked == false)
                        return;

                    txtMatLotNo1.Text = sMatLotNo1;
                    txtMatLotNo2.Text = sMatLotNo2;
                    txtTotInQty.Text = Convert.ToString(iGaTotInqty + inqty);
                    txtReInQty.Text = Convert.ToString(Convert.ToInt32(txtPoOrderQty.Text.Replace(",", "")) - iGaTotInqty - inqty);
                    UpdateFinishFlag();

                    SendPrint(sPlantCode, sPoNo, sPreInGroupNo);

                }
                else if (helper.RSCODE == "E")
                {
                    helper.Rollback();
                    MessageBox.Show(helper.RSMSG);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                helper.Rollback();
            }
            finally
            {
                helper.Close();
            }
        }

        /// <summary>
        /// 가입고 중량 및 입고수량을 입력 했을 시 바코드 발행 수량을 그리드에 표시한다.
        /// 나머지는 마지막 수량에 모두 더 해 준다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void txtInputCnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    int iInQty;

                    if (sItemType == "3") //원자재
                    {
                        if (txtInputQty.Text == string.Empty)
                            return;

                        _GridUtil.Grid_Clear(grid1);

                        iInQty = Convert.ToInt32(txtInputQty.Text.Replace(",", ""));

                        this.grid1.InsertRow();

                        grid1.ActiveRow.Cells["LOTBASEQTY"].Value = Convert.ToInt32(iInQty);
                    }
                    else if (sItemType == "4") //외주품
                    {
                        if (txtInputCnt.Text == string.Empty)
                            return;
                        if (txtInputQty.Text == string.Empty)
                            return;

                        _GridUtil.Grid_Clear(grid1);

                        iInQty = Convert.ToInt32(txtInputQty.Text.Replace(",", ""));
                        int iCnt = Convert.ToInt32(txtInputCnt.Text.Replace(",", ""));

                        int num_MOD = iInQty % iCnt;             // 가입고중량 / 입고수량 을 나눈 나머지    1000 % 3 = 1
                        int num_share = iInQty / iCnt;           // 가입고중량 / 입고수량                  1000 / 3 = 333

                        for (int i = 0; i < iCnt; i++)
                        {
                            iInQty = iInQty - num_share;

                            if (i == iCnt - 1)
                            {
                                num_share = num_share + num_MOD;
                            }

                            this.grid1.InsertRow();

                            grid1.ActiveRow.Cells["LOTBASEQTY"].Value = Convert.ToInt32(num_share);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion
    }
}

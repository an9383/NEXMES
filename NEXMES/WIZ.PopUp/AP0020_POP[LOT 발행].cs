#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0020_POP
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
using System.Text;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace WIZ.PopUp
{
    public partial class AP0020_POP : Form
    {
        #region < MEMBER AREA >

        string sItemName = string.Empty;
        string sItemSpec = string.Empty;
        string sCarType = string.Empty;
        string sLotCnt = string.Empty;
        string sLotNo = string.Empty;
        string sOderDate = string.Empty;

        int _printCnt = 1;
        int _columnCnt = 0;
        AP0020_POP_TEL AP0020_POP_TEL; //제품 식별표
        DataTable rtnDtTemp2 = new DataTable();
        Common _Common = new Common();
        DataRow dRow;

        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        #endregion

        #region < CONSTRUCTOR >
        public AP0020_POP()
        {
            InitializeComponent();
        }

        public AP0020_POP(string sItemCode, string sItemName, string sBoxQty, double dTotQty, DataRow tmpDr)
        {
            InitializeComponent();

            int iQty = 0;
            int.TryParse(sBoxQty, out iQty);

            for (int i = 0; i < 6; i++)
            {
                rtnDtTemp2.Columns.Add("ITEMNAME" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("MATGRADE" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("COLORNAME" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("CARTYPE" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("NOWQTY" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("LOTNO" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("TMPINDATE" + Convert.ToString(i + 1));
            }

            sOderDate = tmpDr["ORDERDATE"].ToString();
            txt_ITEMCODE.Text = sItemCode;
            txt_ITEMNAME.Text = sItemName;
            txt_BOXQTY.Text = (iQty <= 0) ? dTotQty.ToString() : sBoxQty;

            //if (txt_BOXQTY.Text == "" || txt_BOXQTY.Text == "0")
            //{
            //    txt_BOXQTY.Text = "1";
            //    txt_LOTCNT.Text = Convert.ToString(Convert.ToInt32(dTotQty) / Convert.ToInt32(txt_BOXQTY.Text));
            //}
            //else
            //{
            //    txt_LOTCNT.Text = Convert.ToString(Convert.ToInt32(dTotQty) / Convert.ToInt32(txt_BOXQTY.Text));
            //}


            //txt_TOTQTY.Text   = Convert.ToString(Convert.ToInt32(txt_BOXQTY.Text.Trim()) * Convert.ToInt32(txt_LOTCNT.Text.Trim()));
            //txt_PRTCNT.Text   = txt_LOTCNT.Text;

            txtCarType.Text = tmpDr["CARTYPE"].ToString();
            txtLOTNO.Text = tmpDr["ORDERNO"].ToString();

            // 대화산업 설정
            DBHelper helper = new DBHelper(true);

            if (helper.DBConnect.Database.ToString() == "DAEHWA")
            {
                ultraPanel4.Visible = true;

                DataTable dtSpec = new DataTable();
                string strSql = "";

                strSql += " SELECT BM.GRADE AS GRADE, BM.COLORNAME, BM.MATERIALGRADE AS MATERIALGRADE, PP.LOTNO AS LOTNO ";  // TEST
                strSql += "  FROM AP0020 AP join BM0010 BM ON AP.ITEMCODE = BM.ITEMCODE ";
                strSql += "  LEFT OUTER join PP0012 PP ON PP.ORDERNO = AP.ORDERNO ";
                strSql += "  WHERE AP.PLANTCODE = '" + WIZ.LoginInfo.PlantCode + "'";
                strSql += "  AND AP.ITEMCODE = '" + sItemCode + "'";

                dtSpec = helper.FillTable(strSql);
                txtColor.Text = dtSpec.Rows[0]["COLORNAME"].ToString();
                txtMatGrade.Text = dtSpec.Rows[0]["MATERIALGRADE"].ToString();
                txtLOTNO.Text = dtSpec.Rows[0]["LOTNO"].ToString();
            }
            else
            {
                ultraPanel4.Visible = false;
            }
            ultraPanel3.Visible = !ultraPanel4.Visible;

        }
        #endregion

        #region < FORM LOAD >


        #endregion

        #region < EVENT AREA >
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (txt_BOXQTY.Text != "" || txt_BOXQTY.Text != "0")
            {
                int total_qty = Convert.ToInt32(txt_TOTQTY.Text.Trim());
                int box_qty = Convert.ToInt32(txt_BOXQTY.Text.Trim());

                if (total_qty % box_qty == 0)
                {
                    int cal = total_qty / box_qty;
                    txt_PRTCNT.Text = Convert.ToString(Convert.ToInt32(cal));
                }
                else
                {
                    int cal = (total_qty / box_qty) + 1;
                    txt_PRTCNT.Text = Convert.ToString(Convert.ToInt32(cal));
                }
            }
        }
        private void txt_TOTQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ultraButton1.PerformClick();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int iCNT = 0;
            int.TryParse(txt_PRTCNT.Text, out iCNT);

            if (iCNT <= 0)
            {
                MessageBox.Show("발행수량 확인하세요");
                return;
            }

            DoPrint(iCNT);

            _printCnt = 1;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region < USER METHOD AREA >

        private void DoPrint(int iCNT)
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                int total_qty = Convert.ToInt32(txt_TOTQTY.Text.Trim());
                int box_qty = Convert.ToInt32(txt_BOXQTY.Text.Trim());
                int lotqty = 0;

                if (_printCnt == 1 || _printCnt % 6 == 1)
                    dRow = rtnDtTemp2.NewRow();

                for (int i = 0; i < iCNT; i++)
                {
                    Thread.Sleep(500);

                    if (total_qty > box_qty)
                    {
                        lotqty = box_qty;
                        total_qty = total_qty - box_qty;
                    }
                    else
                    {
                        lotqty = total_qty;
                    }

                    //LOTNO 생성
                    DataTable pLOTdt = new DataTable();

                    try
                    {
                        pLOTdt = helper.FillTable("CALL_CREATE_NEXTSEQ"
                        , CommandType.StoredProcedure
                        , helper.CreateParameter("@AS_HEADER", "LOT", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("@AS_YMD", DateTime.Now.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("@AS_SUBDATA", txtLOTNO.Text.ToString(), DbType.String, ParameterDirection.Input));

                        sLotNo = pLOTdt.Rows[0]["LOTNO"].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return;
                    }

                    DataTable rtnDtTemp = new DataTable();
                    rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                    DataRow[] dArr = rtnDtTemp.Select("CODE_NAME_ORG = '대화산업' ");
                    {
                        //LOT발행이 아닌 선 발행시 재공창고 입고
                        DBHelper Insert_helper = new DBHelper("", true);
                        try
                        {
                            Insert_helper.ExecuteNoneQuery("USP_WM0000_I3"
                            , CommandType.StoredProcedure
                            , helper.CreateParameter("@AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("@AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("@AS_ITEMCODE", txt_ITEMCODE.Text, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("@AS_NOWQTY", lotqty, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("@AS_LOTSTATUS", "50", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("@AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));


                            if (Insert_helper.RSCODE == "S")
                            {
                                Insert_helper.Commit();
                            }
                            else
                            {
                                Insert_helper.Rollback();
                                MessageBox.Show(Insert_helper.RSMSG);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            Insert_helper.Rollback();
                            return;
                        }

                    }

                    //ZEBRA ZT 시리즈 
                    if (rb_ZBPRINT_B.Checked == true)
                    {
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
                                command.AppendLine("^FO21,27^GB612,718,5^FS");
                                command.AppendLine("^FT40,79^A1N,44,55^FH^FD완제품 식별표^FS");
                                command.AppendLine("^FT495,80^A1N,34,33^FH^FD대화산업^FS");
                                command.AppendLine("^FT57,156^A1N,34,33^FH^FD품명^FS");

                                if (txt_ITEMNAME.Text.Length > 13)
                                {

                                    int max = Convert.ToInt32(txt_ITEMNAME.Text.Length) - 13;
                                    string str = txt_ITEMNAME.Text.ToString();
                                    string str2 = txt_ITEMNAME.Text.ToString();

                                    string SubStr = str.Substring(0, 12);
                                    string SubStr2 = str2.Substring(13, max);

                                    command.AppendLine("^FT180,136^A1N,34,33^FH^FD" + SubStr + "^FS");
                                    command.AppendLine("^FT180,176^A1N,34,33^FH^FD" + SubStr2 + "^FS");
                                }
                                else
                                {
                                    command.AppendLine("^FT180,156^A1N,34,33^FH^FD" + txt_ITEMNAME.Text.ToString() + "^FS");
                                }

                                command.AppendLine("^FT57,258^A1N,34,33^FH^FD재질^FS");
                                command.AppendLine("^FT180,258^A1N,34,33^FH^FD" + txtMatGrade.Text.ToString() + "^FS");

                                command.AppendLine("^FT353,258^A1N,34,33^FH^FD색상^FS");
                                command.AppendLine("^FT475,258^A1N,34,33^FH^FD" + txtColor.Text.ToString() + "^FS");

                                command.AppendLine("^FT57,359^A1N,34,33^FH^FD차종^FS");
                                command.AppendLine("^FT180,359^A1N,34,33^FH^FD" + txtCarType.Text.ToString() + "^FS");

                                command.AppendLine("^FT353,359^A1N,34,33^FH^FD수량^FS");
                                command.AppendLine("^FT475,359^A1N,34,33^FH^FD" + Convert.ToString(lotqty) + " EA^FS");

                                command.AppendLine("^FT27,462^A1N,34,33^FH^FDLOT NO^FS");
                                command.AppendLine("^FT285,460^A1N,34,33^FH^FD" + sLotNo + "^FS");

                                command.AppendLine("^FT27,555^A1N,34,33^FH^FD생산일자^FS");
                                //command.AppendLine("^FT285,566^A1N,34,33^FH^FD2020-01-13^FS");

                                command.AppendLine("^BY2,2,80^FT80,701^B3N,N,,Y,N");
                                command.AppendLine("^FD" + txtLOTNO.Text.ToString() + "^FS");

                                command.AppendLine("^FO162,95^GB0,500,6^FS");
                                command.AppendLine("^FO320,195^GB0,200,5^FS");
                                command.AppendLine("^FO460,195^GB0,200,5^FS");
                                command.AppendLine("^FO460,593^GB0,153,5^FS");

                                command.AppendLine("^FO21,92^GB613,0,7^FS");
                                command.AppendLine("^FO21,192^GB610,0,7^FS");
                                command.AppendLine("^FO21,293^GB610,0,6^FS");
                                command.AppendLine("^FO21,393^GB610,0,6^FS");
                                command.AppendLine("^FO21,493^GB610,0,6^FS");
                                command.AppendLine("^FO21,593^GB610,0,6^FS");

                                command.AppendLine("^PQ1,0,1,Y^XZ");
                                break;
                            default:
                                command.AppendLine("^XA");
                                command.AppendLine("^MMT");
                                command.AppendLine("^PW639");
                                command.AppendLine("^LL0759");
                                command.AppendLine("^LS0");
                                command.AppendLine("^SEE:UHANGUL.DAT^FS");
                                command.AppendLine("^CW1,E:KFONT3.FNT^CI26^FS");
                                command.AppendLine("^FO21,27^GB612,718,4^FS");
                                command.AppendLine("^FT208,79^A1N,44,55^FH^FD부품식별표^FS");

                                command.AppendLine("^FT57,156^A1N,34,33^FH^FD품명^FS");
                                if (txt_ITEMNAME.Text.Length > 13)
                                {

                                    int max = Convert.ToInt32(txt_ITEMNAME.Text.Length) - 13;
                                    string str = txt_ITEMNAME.Text.ToString();
                                    string str2 = txt_ITEMNAME.Text.ToString();

                                    string SubStr = str.Substring(0, 12);
                                    string SubStr2 = str2.Substring(13, max);

                                    command.AppendLine("^FT179,156^A1N,34,33^FH^FD" + SubStr + "\\" + "&" + SubStr2 + "^FS");
                                }
                                else
                                {
                                    command.AppendLine("^FT179,156^A1N,34,33^FH^FD" + txt_ITEMNAME.Text.ToString() + "^FS");
                                }

                                command.AppendLine("^FT57,258^A1N,34,33^FH^FD사양^FS");
                                //command.AppendLine("^FT175,258^A1N,34,33^FH^FD" + txtITEMSPEC.Text.ToString() + "^FS");

                                command.AppendLine("^FT57,359^A1N,34,33^FH^FD차종^FS");
                                command.AppendLine("^FT221,359^A1N,34,33^FH^FD" + txtCarType.Text.ToString() + "^FS");

                                command.AppendLine("^FT353,359^A1N,34,33^FH^FD수량^FS");
                                command.AppendLine("^FT505,359^A1N,34,33^FH^FD" + Convert.ToString(lotqty) + " EA^FS");

                                command.AppendLine("^FT57,462^A1N,34,33^FH^FDLOT^FS");
                                command.AppendLine("^FT285,460^A1N,34,33^FH^FD" + txtLOTNO.Text.ToString() + "^FS");

                                command.AppendLine("^FT27,566^A1N,34,33^FH^FD생산일자^FS");
                                //command.AppendLine("^FT285,566^A1N,34,33^FH^FD2020-01-13^FS");

                                command.AppendLine("^BY3,2,80^FT64,701^B3N,N,,Y,N");
                                command.AppendLine("^FD" + txtLOTNO.Text.ToString() + "^FS");

                                command.AppendLine("^FO162,95^GB0,500,6^FS");
                                command.AppendLine("^FO320,295^GB0,105,5^FS");
                                command.AppendLine("^FO484,295^GB0,105,5^FS");
                                command.AppendLine("^FO21,493^GB610,0,6^FS");
                                command.AppendLine("^FO21,393^GB610,0,6^FS");
                                command.AppendLine("^FO21,293^GB610,0,6^FS");
                                command.AppendLine("^FO21,192^GB610,0,7^FS");
                                command.AppendLine("^FO21,92^GB613,0,7^FS");
                                command.AppendLine("^FO21,593^GB610,0,6^FS");
                                command.AppendLine("^PQ1,0,1,Y^XZ");
                                break;
                        }

                        string a = command.ToString();

                        WIZ.Common.SendStringToBytePrinter("ZT410", command.ToString());
                    }


                    //일반 프린터
                    else
                    {
                        //for (int i = 0; i < iCNT; i++)
                        switch (helper.DBConnect.Database.ToString())
                        {
                            case "DAEHWA":

                                dRow["ITEMNAME" + Convert.ToString(_columnCnt + 1)] = txt_ITEMNAME.Text;
                                dRow["MATGRADE" + Convert.ToString(_columnCnt + 1)] = txtMatGrade.Text;
                                dRow["COLORNAME" + Convert.ToString(_columnCnt + 1)] = txtColor.Text;
                                dRow["CARTYPE" + Convert.ToString(_columnCnt + 1)] = txtCarType.Text;
                                dRow["NOWQTY" + Convert.ToString(_columnCnt + 1)] = Convert.ToString(lotqty) + " EA";
                                dRow["LOTNO" + Convert.ToString(_columnCnt + 1)] = sLotNo;
                                dRow["TMPINDATE" + Convert.ToString(_columnCnt + 1)] = sOderDate;

                                if (_printCnt == iCNT || _printCnt % 6 == 0)
                                {
                                    rtnDtTemp2.Rows.Add(dRow);

                                    //텔레릭 레포트로 출력시
                                    //rtnDtTemp 데이터바인딩

                                    AP0020_POP_TEL = new AP0020_POP_TEL();
                                    objectDataSource.DataSource = rtnDtTemp2;
                                    AP0020_POP_TEL.DataSource = objectDataSource;
                                    viewerInstance.ReportDocument = AP0020_POP_TEL.Report;

                                    //레포트 뷰어
                                    //ReportViewer.ReportSource = viewerInstance;
                                    //ReportViewer.RefreshReport();

                                    //뷰어 없이 바로 출력
                                    Telerik.Reporting.IReportDocument myReport = new AP0020_POP_TEL();
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

                                break;


                            default:
                                break;

                        }
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

        #endregion


    }
}

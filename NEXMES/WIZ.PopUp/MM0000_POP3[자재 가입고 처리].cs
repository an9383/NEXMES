#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0000_POP3
//   Form Name    : 자재 가입고 처리
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-03-21
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Description  : MM0000에서 가입고 버튼 Click시 POPUP 호출
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
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;


#endregion

namespace WIZ.PopUp
{
    public partial class MM0000_POP3 : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >
        private string sPlantCode = string.Empty;                   //사업장
        private string sPoNo = string.Empty;                   //거래번호(PONO)  
        private string sPoSeqNo = string.Empty;                   //거래순번(POSEQ)     
        private string sCustCode = string.Empty;                   //거래처
        private string sCustName = string.Empty;                   //거래처명
        private string sItemCode = string.Empty;                   //품목
        private string sItemName = string.Empty;                   //품목명
        private string sPoQty = string.Empty;                   //발주량(A)
        private string sPoDate = string.Empty;                   //발주일
        private string sPlanInDate = string.Empty;                   //입고예정일자
        private string sMaterialgrade = string.Empty;                   //재질
        private string sItemSpec = string.Empty;                   //규격
        private string sItemType = string.Empty;                   //품목분류
        private string sUnitCode = string.Empty;                   //단위     
        private string sTmpInQty = string.Empty;                   //총 가입고 중량(B)
        private string sInQty = string.Empty;                   //입고 중량
        private string sReInQty = string.Empty;                   //입고 잔량(A-B)
        private string sTmpInGroupNo = string.Empty;

        UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성
        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable();
        MM0000_POP3_TEL MM0000_POP3_TEL;

        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        #endregion

        #region < CONSTRUCTOR >
        public MM0000_POP3()
        {
            InitializeComponent();
        }

        public MM0000_POP3(DataRow drRow)
        {
            InitializeComponent();

            sPlantCode = Convert.ToString(drRow["PLANTCODE"]);
            sPoNo = Convert.ToString(drRow["PONO"]);
            //sPoDate        = Convert.ToString(drRow["PODATE"]);
            //sPoSeqNo       = Convert.ToString(drRow["POSEQNO"]);
            //sPlanInDate    = Convert.ToString(drRow["PLANINDATE"]);
            //sCustCode      = Convert.ToString(drRow["CUSTCODE"]);
            //sCustName      = Convert.ToString(drRow["CUSTNAME"]);
            sItemCode = Convert.ToString(drRow["ITEMCODE"]);
            //sItemName      = Convert.ToString(drRow["ITEMNAME"]);
            //sMaterialgrade = Convert.ToString(drRow["MATERIALGRADE"]);
            //sItemSpec      = Convert.ToString(drRow["ITEMSPEC"]);
            //sItemType      = Convert.ToString(drRow["ITEMTYPENAME"]);
            //sUnitCode      = Convert.ToString(drRow["UNITCODE"]);
            sPoQty = Convert.ToString(drRow["ITEMCNT"]);
            //sTmpInQty      = Convert.ToString(drRow["TMPINQTY"]);
            //sInQty         = Convert.ToString(drRow["INQTY"]);
            //sReInQty       = Convert.ToString(drRow["REINQTY"]);


            txt_PONO_B.Text = sPoNo;
            txt_POSEQ_B.Text = sPoSeqNo;
            txt_PLANINDATE_B.Text = sPlanInDate;
            txt_CUSTNAME_B.Text = sCustName;
            txt_ITEMCODE_B.Text = sItemCode;
            txt_ITEMNAME_B.Text = sItemName;
            txt_MATERIAL_B.Text = sMaterialgrade;
            txt_ITEMSPEC_B.Text = sItemSpec;
            txt_ITEMTYPE_B.Text = sItemType;
            txt_UNITCODE_B.Text = sUnitCode;
            txt_POQTY_B.Text = sPoQty;         //발주수량(A)
            txt_STOCKQTY_B.Text = sInQty;         //입고수량
            txt_TMPINQTY_B.Text = sTmpInQty;      //총 가입고 수량(B)
            txt_REINQTY_B.Text = sReInQty;       //입고잔량(A-B)

            lbl_NOTICE_B.ForeColor = Color.Red;
        }
        #endregion

        #region < FORM EVENT >
        private void MM0000_POP3_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTLOTNO", "거래처 LOTNO", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTBASEQTY", "수량", true, GridColDataType_emu.Integer, 70, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            this.grid1.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            this.grid1.DisplayLayout.Bands[0].Summaries.Add("합계", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["LOTNO"]);
            this.grid1.DisplayLayout.Bands[0].Summaries[0].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["LOTNO"];
            this.grid1.DisplayLayout.Bands[0].Summaries[0].DisplayFormat = "합계";
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Key = "LOTNO";
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.TextHAlign = HAlign.Center;
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.FontData.SizeInPoints = 9;
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.BackColor = Color.FromArgb(255, 228, 225);
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.ForeColor = Color.Black;
            this.grid1.DisplayLayout.Bands[0].Summaries[0].SummaryDisplayArea = SummaryDisplayAreas.Top;

            this.grid1.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            this.grid1.DisplayLayout.Bands[0].Summaries.Add("", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["CUSTLOTNO"]);
            this.grid1.DisplayLayout.Bands[0].Summaries[1].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["CUSTLOTNO"];
            this.grid1.DisplayLayout.Bands[0].Summaries[1].DisplayFormat = " ";
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Key = "CUSTLOTNO";
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.TextHAlign = HAlign.Center;
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.FontData.SizeInPoints = 9;
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.BackColor = Color.FromArgb(255, 228, 225);
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.ForeColor = Color.Black;
            this.grid1.DisplayLayout.Bands[0].Summaries[1].SummaryDisplayArea = SummaryDisplayAreas.Top;


            this.grid1.DisplayLayout.Bands[0].Summaries.Add("SUM([LOTBASEQTY])", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["LOTBASEQTY"]);
            this.grid1.DisplayLayout.Bands[0].Summaries[2].DisplayFormat = "{0:#,##0}";
            this.grid1.DisplayLayout.Bands[0].Summaries[2].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["LOTBASEQTY"];
            this.grid1.DisplayLayout.Bands[0].Summaries[2].Key = "LOTBASEQTY";
            this.grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.TextHAlign = HAlign.Right;
            this.grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.FontData.SizeInPoints = 10;
            this.grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.BackColor = Color.FromArgb(255, 228, 225);
            this.grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.ForeColor = Color.Black;
            this.grid1.DisplayLayout.Bands[0].Summaries[2].SourceColumn.Format = "#,##0";
            this.grid1.DisplayLayout.Bands[0].Summaries[2].SummaryPositionColumn.Format = "#,##0";
            this.grid1.DisplayLayout.Bands[0].Summaries[2].SummaryDisplayArea = SummaryDisplayAreas.Top;
            this.grid1.DisplayLayout.Bands[0].Summaries[2].SummaryType = SummaryType.Sum;

            #endregion

            #region < COMBOBOX SETTING >

            #endregion

        }

        protected override void SetSubData()
        {
            DataRow dr = subData["METHOD_TYPE", "SUBLOTNAME"];

            if (dr != null)
            {
                string sColName = CModule.ToString(dr["RELCODE1"]);

                lblSubLot.Text = sColName;
            }
        }

        #endregion

        #region < METHOD AREA >
        /// <summary>
        /// 식별표 발행, 닫기 버튼 클릭 시 발주번호 상태 변경 로직 
        /// </summary>
        private void UpdateFinishFlag()
        {
            int iPoQty = Convert.ToInt32(txt_POQTY_B.Text);            //발주수량
            int iTotInQty = Convert.ToInt32(txt_TMPINQTY_B.Text);      //가입고수량
            string sFinishFlag = string.Empty;

            //업데이트 시 가입고 수량이 0인 경우..
            if (iTotInQty == 0)
            {
                return;
            }

            if (iPoQty <= iTotInQty)
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
                helper.ExecuteNoneQuery("USP_MM0000_POP3_U1"
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
                helper.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }

        /// <summary>
        /// 발주그룹번호 채번
        /// </summary>
        private void TmpInGroupNo()
        {
            DBHelper helper = new DBHelper(false);

            string sNowDate = DateTime.Now.ToString("yyyy-MM-dd");

            try
            {
                StringBuilder command = new StringBuilder();
                command.AppendLine("BEGIN");
                command.AppendLine(" DECLARE @LOTNO NVARCHAR(20), @RS_MSG VARCHAR(100) ");
                command.AppendLine(" EXEC USP_CREATE_NEXTSEQ 'PG', '" + sNowDate + "', '*', @LOTNO OUTPUT, @RS_MSG OUTPUT ");
                command.AppendLine(" SELECT @LOTNO AS LOTNO , @RS_MSG AS RS_MSG;");
                command.AppendLine("END");

                DataTable rtnDtTemp = helper.FillTable(command.ToString());

                if (Convert.ToString(rtnDtTemp.Rows[0][0]) != "NONE")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        sTmpInGroupNo = Convert.ToString(rtnDtTemp.Rows[0]["LOTNO"]);
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
                helper.Close();
            }
        }

        private void SendPrint(string sPlantCode, string sPoNo, string sTmpInGroupNo)
        {
            DBHelper helper = new DBHelper(false);
            DataTable rtnDtTemp2 = new DataTable();

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_MM0000_POP3_S1", CommandType.StoredProcedure
                                                  , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("AS_TMPINGROUPNO", sTmpInGroupNo, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    // Zebra 프린터로 발행시..
                    if (rb_ZBPRINT_B.Checked == true)
                    {
                        StringBuilder command = new StringBuilder();

                        switch (helper.DBConnect.Database.ToString())
                        {
                            case "P2001": // 대선주조 프린터 서버 
                            case "P2032":
                                try
                                {
                                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                                    {
                                        string sLotNO = DBHelper.nvlString(rtnDtTemp.Rows[i]["LOTNO"].ToString());

                                        StringBuilder sSQL = new StringBuilder();
                                        sSQL.Append("exec USP_CALLPRINT_I1 ");
                                        sSQL.Append("  @AS_PLANTCODE = '" + DBHelper.nvlString(sPlantCode) + "' ");
                                        sSQL.Append(", @AS_LOTNO = '" + sLotNO + "' ");
                                        sSQL.Append(", @AS_WORKCENTERCODE = '" + "WC0000" + "' ");
                                        sSQL.Append(", @AS_CIP = ''"); // IP 설정 필요함.
                                        sSQL.Append(", @AS_REISSUE = 'R' ");

                                        helper.ExecuteNoneQuery(sSQL.ToString());
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                break;
                            case "DAEHWA":
                                for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                                {
                                    Thread.Sleep(1000);

                                    command.Length = 0;

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
                                    command.AppendLine("^FT179,170^A1N,34,33^FH^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]) + "^FS");

                                    command.AppendLine("^FT57,272^A1N,34,33^FH^FD차종^FS");
                                    command.AppendLine("^FT221,272^A1N,34,33^FH^FD" + Convert.ToString(rtnDtTemp.Rows[i]["CARTYPE"]) + "^FS");

                                    command.AppendLine("^FT360,272^A1N,34,33^FH^FD수량^FS");
                                    command.AppendLine("^FT495,272^A1N,34,33^FH^FD" + Convert.ToString(rtnDtTemp.Rows[i]["LOTBASEQTY"]) + " " +
                                                                                      Convert.ToString(rtnDtTemp.Rows[i]["UNITCODE"]) + "^FS");

                                    command.AppendLine("^FT30,374^A1N,34,33^FH^FDLOT NO^FS");
                                    command.AppendLine("^FT275,374^A1N,34,33^FH^FD" + Convert.ToString(rtnDtTemp.Rows[i]["LOTNO"]) + "^FS");


                                    command.AppendLine("^FT30,472^A1N,34,33^FH^FD입고일자^FS");
                                    command.AppendLine("^FT275,472^A1N,34,33^FH^FD" + Convert.ToString(rtnDtTemp.Rows[i]["TMPINDATE"]) + "^FS");

                                    command.AppendLine("^FT45,566^A1N,34,33^FH^FD입고처^FS");
                                    command.AppendLine("^FT275,566^A1N,34,33^FH^FD" + Convert.ToString(rtnDtTemp.Rows[i]["CUSTNAME"]) + "^FS");

                                    command.AppendLine("^BY2,2,80^FT120,701^B3N,N,,Y,N");
                                    command.AppendLine("^FD" + Convert.ToString(rtnDtTemp.Rows[i]["LOTNO"]) + "^FS");

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

                                    WIZ.Common.SendStringToBytePrinter("ZT410", command.ToString());
                                }
                                break;
                            default:

                                for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                                {
                                    Thread.Sleep(1000);

                                    command.Length = 0;
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
                                    command.AppendLine("^FO" + "625, 740" + "^A1R, 40, 40" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["PLANTNAME"]) + "^FS");

                                    command.AppendLine("^FO" + "555, 70" + "^A1R, 30, 30" + " ^FD" + "LOT No" + "^FS");
                                    command.AppendLine("^FO" + "555, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["LOTNO"]) + "^FS");

                                    command.AppendLine("^FO" + "555, 515" + "^A1R, 30, 30" + " ^FD" + "가입고일자" + "^FS");
                                    command.AppendLine("^FO" + "555, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["TMPINDATE"]) + "^FS");

                                    command.AppendLine("^FO" + "495, 70" + "^A1R, 30, 30" + " ^FD" + "품목유형" + "^FS");
                                    command.AppendLine("^FO" + "495, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMTYPE"]) + "^FS");

                                    command.AppendLine("^FO" + "495, 530" + "^A1R, 30, 30" + " ^FD" + "수    량" + "^FS");
                                    command.AppendLine("^FO" + "495, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["LOTBASEQTY"]) + "^FS");

                                    command.AppendLine("^FO" + "435, 70" + "^A1R, 30, 30" + " ^FD" + "품목코드" + "^FS");
                                    command.AppendLine("^FO" + "435, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]) + "^FS");

                                    command.AppendLine("^FO" + "375, 70" + "^A1R, 30, 30" + " ^FD" + "품 목 명" + "^FS");

                                    if (Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]).Length < 30)
                                        command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]) + "^FS");
                                    else if (Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]).Length < 60)
                                        command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]) + "^FS");
                                    else
                                        command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]) + "^FS");


                                    command.AppendLine("^FO" + "315, 70" + "^A1R, 30, 30" + " ^FD" + "발주번호" + "^FS");
                                    command.AppendLine("^FO" + "315, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["PONO"]) + "^FS");

                                    command.AppendLine("^FO" + "315, 530" + "^A1R, 30, 30" + " ^FD" + "업 체 명" + "^FS");
                                    command.AppendLine("^FO" + "315, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["CUSTNAME"]) + "^FS");

                                    command.AppendLine("^FO" + "190, 210" + "^BY3,4^BCR," + "80,Y,N,N" + "^FD" + Convert.ToString(rtnDtTemp.Rows[i]["LOTNO"]) + "^FS");

                                    command.AppendLine("^FO" + "60, 65" + "^A1R, 30, 30" + " ^FD" + "비    고" + "^FS");
                                    command.AppendLine("^FO" + "60, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["REMARK"]) + "^FS");

                                    command.AppendLine("^XZ");

                                    WIZ.Common.SendStringToBytePrinter("ZT410", command.ToString());
                                }
                                break;
                        }
                    }
                    //일반프린터로 발행시..
                    else
                    {
                        int iPrintCnt = 1;
                        int iColCnt = 0;

                        DataRow dRow = rtnDtTemp2.NewRow();

                        for (int i = 0; i < 4; i++)
                        {
                            rtnDtTemp2.Columns.Add("PLANTNAME" + Convert.ToString(i + 1));
                            rtnDtTemp2.Columns.Add("LOTNO" + Convert.ToString(i + 1));
                            rtnDtTemp2.Columns.Add("CUSTLOTNO" + Convert.ToString(i + 1));
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

                        for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                        {
                            dRow["PLANTNAME" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["PLANTNAME"];
                            dRow["LOTNO" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["LOTNO"];
                            dRow["CUSTLOTNO" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["CUSTLOTNO"];
                            dRow["TMPINDATE" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["TMPINDATE"];
                            dRow["ITEMTYPE" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["ITEMTYPE"];
                            dRow["ITEMCODE" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["ITEMCODE"];
                            dRow["ITEMNAME" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["ITEMNAME"];
                            dRow["PONO" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["PONO"];
                            dRow["LOTBASEQTY" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["LOTBASEQTY"];
                            dRow["CUSTCODE" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["CUSTCODE"];
                            dRow["CUSTNAME" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["CUSTNAME"];
                            dRow["REMARK" + Convert.ToString(iColCnt + 1)] = rtnDtTemp.Rows[i]["REMARK"];

                            if (iPrintCnt == rtnDtTemp.Rows.Count || iPrintCnt % 4 == 0)
                            {
                                rtnDtTemp2.Rows.Add(dRow);

                                //텔레릭 레포트로 출력시
                                //rtnDtTemp 데이터바인딩
                                MM0000_POP3_TEL = new MM0000_POP3_TEL();
                                objectDataSource.DataSource = rtnDtTemp2;
                                MM0000_POP3_TEL.DataSource = objectDataSource;
                                viewerInstance.ReportDocument = MM0000_POP3_TEL.Report;

                                //레포트 뷰어
                                //ReportViewer.ReportSource = viewerInstance;
                                //ReportViewer.RefreshReport();

                                //뷰어 없이 바로 출력
                                Telerik.Reporting.IReportDocument myReport = new MM0000_POP3_TEL();
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
                helper.Close();
            }
        }

        /// <summary>
        /// OpenSerial
        /// </summary>
        private void openSerial()
        {
            if (SerialPortPrint.IsOpen) SerialPortPrint.Close(); // 시리얼포트가 열려있으면 닫기 위함

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_GET_SERAILPORT"
                                                      , CommandType.StoredProcedure
                                                      , helper.CreateParameter("@AS_MACHNAME", "ZEBRA", DbType.String, ParameterDirection.Input));

                SerialPortPrint.PortName = Convert.ToString(rtnDtTemp.Rows[0]["PORTNAME"]);
                SerialPortPrint.BaudRate = Convert.ToInt32(rtnDtTemp.Rows[0]["BAUDRATE"]);
                SerialPortPrint.DataBits = Convert.ToInt32(rtnDtTemp.Rows[0]["DATABITS"]);

                if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.None")
                {
                    SerialPortPrint.Parity = Parity.None;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Even")
                {
                    SerialPortPrint.Parity = Parity.Even;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Mark")
                {
                    SerialPortPrint.Parity = Parity.Mark;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Odd")
                {
                    SerialPortPrint.Parity = Parity.Odd;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Space")
                {
                    SerialPortPrint.Parity = Parity.Space;
                }

                if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.None")
                {
                    SerialPortPrint.StopBits = StopBits.None;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.One")
                {
                    SerialPortPrint.StopBits = StopBits.One;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.OnePointFive")
                {
                    SerialPortPrint.StopBits = StopBits.OnePointFive;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.Two")
                {
                    SerialPortPrint.StopBits = StopBits.Two;
                }

                SerialPortPrint.Open();

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
            _GridUtil.Grid_Clear(grid1);
            txt_INPUTQTY_B.Text = string.Empty;
            txt_INPUTCNT_B.Text = string.Empty;
            txt_STDMATLOTNO_B.Text = string.Empty;
            txt_ENDMATLOTNO_B.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                string sLotNo1 = string.Empty;
                string sLotNo2 = string.Empty;

                if (txt_INPUTQTY_B.Text == string.Empty)
                {
                    MessageBox.Show(Common.getLangText("가입고 수(중)량을 입력하세요.", "MSG"));
                    return;
                }

                if (txt_INPUTCNT_B.Text == string.Empty)
                {
                    MessageBox.Show(Common.getLangText("입고수량을 입력하세요.", "MSG"));
                    return;
                }

                if (txt_PLANINDATE_B.Text == string.Empty)
                {
                    MessageBox.Show(Common.getLangText("입고일자를 입력하세요.", "MSG"));
                    return;
                }

                if (Regex.IsMatch(txt_PLANINDATE_B.Text, @"^(19|20)\d{2}" + "-" + "(0[1-9]|1[012])" + "-" + "(0[1-9]|[12][0-9]|3[0-1])$") == false)
                {
                    MessageBox.Show(Common.getLangText("입고일자 형식을 yyyy-MM-dd 형태로 입력하세요", "MSG"));
                    return;
                }

                if (grid1.Rows.Count == 0)
                {
                    MessageBox.Show(Common.getLangText("입고 수량 입력 후 엔터를 눌러주세요.", "MSG"));
                    return;
                }

                int iPoQty = Convert.ToInt32(txt_POQTY_B.Text);                          //발주량
                int iCnt = Convert.ToInt32(txt_INPUTCNT_B.Text);                         //가입고 수량
                int iInQty = Convert.ToInt32(txt_INPUTQTY_B.Text.Replace(",", ""));      //가입고 중량
                int inqty = iInQty;
                int iGaTotInqty = Convert.ToInt32(txt_TMPINQTY_B.Text.Replace(",", "")); //총가입고량



                if (iPoQty < iGaTotInqty + iInQty)
                {
                    MessageBox.Show(Common.getLangText("가입고량이 발주량을 초과합니다.", "MSG"));
                    return;
                }

                string sInQty = string.Empty;
                string sRemark = string.Empty;
                string sFinishFlag = string.Empty;
                string sCustLotNo = string.Empty;

                TmpInGroupNo(); //발주그룹번호 채번

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    sInQty = Convert.ToString(grid1.Rows[i].Cells["LOTBASEQTY"].Value).Replace(",", "");
                    sRemark = Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value);
                    sFinishFlag = (i + 1) == grid1.Rows.Count ? "Y" : "N";
                    sCustLotNo = Convert.ToString(grid1.Rows[i].Cells["CUSTLOTNO"].Value);

                    helper.ExecuteNoneQuery("USP_MM0000_POP3_I1"
                                           , CommandType.StoredProcedure
                                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_PODATE", sPoDate, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_POSEQNO", sPoSeqNo, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_TMPINGROUPNO", sTmpInGroupNo, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_CUSTLOTNO", sCustLotNo, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_INQTY", sInQty, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_UNITCODE", sUnitCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_INDATE", txt_PLANINDATE_B.Text, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_FINISHFLAG", sFinishFlag, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                           );

                    if (i == 0)
                    {
                        sLotNo1 = helper.RSMSG;
                        sLotNo2 = helper.RSMSG;
                        grid1.Rows[i].Cells["LOTNO"].Value = sLotNo1;
                    }
                    else
                    {
                        sLotNo2 = helper.RSMSG;
                        grid1.Rows[i].Cells["LOTNO"].Value = sLotNo2;
                    }
                }

                if (helper.RSCODE == "S")
                {
                    helper.Commit();

                    txt_STDMATLOTNO_B.Text = sLotNo1;
                    txt_ENDMATLOTNO_B.Text = sLotNo2;
                    txt_TMPINQTY_B.Text = Convert.ToString(iGaTotInqty + inqty);
                    txt_REINQTY_B.Text = Convert.ToString(Convert.ToInt32(txt_POQTY_B.Text.Replace(",", "")) - iGaTotInqty - inqty);
                    UpdateFinishFlag();

                    if (chk_PRINT_B.Checked == true)
                    {
                        SendPrint(sPlantCode, sPoNo, sTmpInGroupNo);
                    }

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
                    if (txt_INPUTCNT_B.Text == string.Empty)
                        return;
                    if (txt_INPUTQTY_B.Text == string.Empty)
                        return;

                    _GridUtil.Grid_Clear(grid1);

                    int iInQty = Convert.ToInt32(txt_INPUTQTY_B.Text.Replace(",", ""));
                    int iCnt = Convert.ToInt32(txt_INPUTCNT_B.Text.Replace(",", ""));

                    int num_MOD = iInQty % iCnt;             // 가입고중량 / 입고수량 을 나눈 나머지    1000 % 3 = 1
                    int num_share = iInQty / iCnt;           // 가입고중량 / 입고수량                  1000 / 3 = 333

                    for (int i = 0; i < iCnt + 1; i++)
                    {
                        iInQty = iInQty - num_share;

                        if (i == iCnt)
                        {
                            num_share = num_MOD;
                            if (num_share == 0) break;
                        }

                        this.grid1.InsertRow();
                        grid1.ActiveRow.Cells["LOTBASEQTY"].Value = Convert.ToInt32(num_share);

                        if (txt_CustLotNo.Text.Trim().Length > 0)
                        {
                            grid1.ActiveRow.Cells["CUSTLOTNO"].Value = txt_CustLotNo.Text.Trim();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_PRINT_B_Click(object sender, EventArgs e)
        {
            if (sPlantCode == string.Empty)
            {
                MessageBox.Show(Common.getLangText("사업장이 선택되지 않았습니다.", "MSG"));
            }
            else if (sPoNo == string.Empty)
            {
                MessageBox.Show(Common.getLangText("발주번호가 올바르지 않습니다.", "MSG"));
            }
            else if (sTmpInGroupNo == string.Empty)
            {
                MessageBox.Show(Common.getLangText("발행그룹번호가 올바르지 않습니다.", "MSG"));
            }

            //SendPrint(sPlantCode, sPoNo, sTmpInGroupNo);
        }
        #endregion

        #region < 미사용>
        private void txtInputQty_TextChanged(object sender, EventArgs e)
        {
            if (txt_INPUTQTY_B.Text.Length > 0)
            {

                string value = txt_INPUTQTY_B.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txt_INPUTQTY_B.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txt_INPUTQTY_B.Text = txt_INPUTQTY_B.Text.Remove(txt_INPUTQTY_B.Text.Length - 1, 1);
                        txt_INPUTQTY_B.Select(txt_INPUTQTY_B.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txt_INPUTQTY_B.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txt_INPUTQTY_B.SelectionStart = txt_INPUTQTY_B.Text.Length;
            }
        }

        private void txtInputCnt_TextChanged(object sender, EventArgs e)
        {
            if (txt_INPUTCNT_B.Text.Length > 0)
            {

                string value = txt_INPUTCNT_B.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txt_INPUTCNT_B.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txt_INPUTCNT_B.Text = txt_INPUTCNT_B.Text.Remove(txt_INPUTCNT_B.Text.Length - 1, 1);
                        txt_INPUTCNT_B.Select(txt_INPUTCNT_B.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txt_INPUTCNT_B.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txt_INPUTCNT_B.SelectionStart = txt_INPUTCNT_B.Text.Length;
            }
        }

        //불필요
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


    }
}

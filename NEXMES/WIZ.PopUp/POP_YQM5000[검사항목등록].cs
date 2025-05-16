using System;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace WIZ.PopUp
{
    public partial class POP_YQM5000 : WIZ.Forms.BasePopupForm
    {
        string[] argument;

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        //임시로 사용할 데이터테이블 생성
        DataTable rtnDtTable = new DataTable();

        //sParam[0] : PLANTCODE
        string[] sParam;

        StringBuilder Sql = new StringBuilder();
        string[] sKey = new string[3];
        #endregion
        public POP_YQM5000(string[] param)
        {
            sParam = param;
            InitializeComponent();
            argument = new string[param.Length];

            Common _Common = new Common();

            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
        }

        private void POP_YQM5000_Load(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                var _with1 = cboAuto.Items;
                _with1.Clear();
                _with1.Add("M :" + "수동입력");//Msg_Lang("수동입력", "Manual Input", "1", this.Name));
                _with1.Add("S :" + "반자동입력");//Msg_Lang("반자동입력", "Semi-Auto Input", "2", this.Name));
                _with1.Add("L :" + "로트입력");//Msg_Lang("로트입력", "Lot No. Input"));

                _with1.Add("M4:" + "수동입력(아크하이트1)");//Msg_Lang("수동입력(아크하이트1)", "Manual Input(Arc Height1)", "1", this.Name));
                _with1.Add("M6:" + "수동입력(아크하이트2)");//Msg_Lang("수동입력(아크하이트2)", "Manual Input(Arc Height2)", "1", this.Name));
                _with1.Add("M8:" + "수동입력(아크하이트1+2)");//Msg_Lang("수동입력(아크하이트1+2)", "Manual Input(Arc Height1+2)", "1", this.Name));
                _with1.Add("M5:" + "수동입력(카바레이지1)");//Msg_Lang("수동입력(카바레이지1)", "Manual Input(Coverage1)", "1", this.Name));
                _with1.Add("M7:" + "수동입력(카바레이지2)");//Msg_Lang("수동입력(카바레이지2)", "Manual Input(Coverage2)", "1", this.Name));
                _with1.Add("M9:" + "수동입력(카바레이지1+2)");//Msg_Lang("수동입력(카바레이지1+2)", "Manual Input(Coverage1+2)", "1", this.Name));
                _with1.Add("S4:" + "반자동입력(아크하이트1)");//Msg_Lang("반자동입력(아크하이트1)", "Semi-Auto Input(Arc Height1)", "2", this.Name));
                _with1.Add("S6:" + "반자동입력(아크하이트2)");//Msg_Lang("반자동입력(아크하이트2)", "Semi-Auto Input(Arc Height2)", "2", this.Name));
                _with1.Add("S8:" + "반자동입력(아크하이트1+2)");//Msg_Lang("반자동입력(아크하이트1+2)", "Semi-Auto Input(Arc Height1+2)", "2", this.Name));
                _with1.Add("S5:" + "반자동입력(카바레이지1)");//Msg_Lang("반자동입력(카바레이지1)", "Semi-Auto Input(Coverage1)", "2", this.Name));
                _with1.Add("S7:" + "반자동입력(카바레이지2)");//Msg_Lang("반자동입력(카바레이지2)", "Semi-Auto Input(Coverage2)", "2", this.Name));
                _with1.Add("S9:" + "반자동입력(카바레이지1+2)");//Msg_Lang("반자동입력(카바레이지1+2)", "Semi-Auto Input(Coverage1+2)", "2", this.Name));

                _with1.Add("A1:" + "가열온도 자동입력");//Msg_Lang("가열온도 자동입력", "Heat Temperature Auto Input", "3", this.Name));
                _with1.Add("A2:" + "소입온도 자동입력");//Msg_Lang("소입온도 자동입력", "Quenting Temperature Auto Input", "4", this.Name));
                _with1.Add("A5:" + "뜨임입구온도 자동입력");//Msg_Lang("뜨임입구온도 자동입력", "Tempering Front Temperature Auto Input", "5", this.Name));
                _with1.Add("A3:" + "뜨임출구온도 자동입력");//Msg_Lang("뜨임출구온도 자동입력", "Tempering Rear Temperature Auto Input", "0", this.Name));
                _with1.Add("A4:" + "도장온도 자동입력");//Msg_Lang("도장온도 자동입력", "Coating Temperature Auto Input", "6", this.Name));
                _with1.Add("A8:" + "핫셋칭온도 자동입력");//Msg_Lang("핫셋칭온도 자동입력", "Hot Setting Temperature Auto Input", "7", this.Name));
                _with1.Add("A6:" + "전처리온도 자동입력");//Msg_Lang("전처리온도 자동입력", "Phosphate Temperature Auto Input", "8", this.Name));
                _with1.Add("A7:" + "수절건조온도 자동입력");//Msg_Lang("수절건조온도 자동입력", "Water Cut Oven Temperature Auto Input", "9", this.Name));

                _with1.Add("AA:" + "쇼트AMP1-1 자동입력");//Msg_Lang("쇼트AMP1-1 자동입력", "Shot AMP#1-1 Auto Input", "A", this.Name));
                _with1.Add("AB:" + "쇼트AMP1-2 자동입력");//Msg_Lang("쇼트AMP1-2 자동입력", "Shot AMP#1-2 Auto Input", "B", this.Name));
                _with1.Add("AC:" + "쇼트AMP1-3 자동입력");//Msg_Lang("쇼트AMP1-3 자동입력", "Shot AMP#1-3 Auto Input", "C", this.Name));
                _with1.Add("AD:" + "쇼트AMP1-4 자동입력");//Msg_Lang("쇼트AMP1-4 자동입력", "Shot AMP#1-4 Auto Input", "D", this.Name));
                _with1.Add("AE:" + "쇼트AMP2-1 자동입력");//Msg_Lang("쇼트AMP2-1 자동입력", "Shot AMP#2-1 Auto Input", "E", this.Name));
                _with1.Add("AF:" + "쇼트AMP2-2 자동입력");//Msg_Lang("쇼트AMP2-2 자동입력", "Shot AMP#2-2 Auto Input", "F", this.Name));
                _with1.Add("AG:" + "쇼트AMP2-3 자동입력");//Msg_Lang("쇼트AMP2-3 자동입력", "Shot AMP#2-3 Auto Input", "G", this.Name));
                _with1.Add("AH:" + "쇼트AMP2-4 자동입력");//Msg_Lang("쇼트AMP2-4 자동입력", "Shot AMP#2-4 Auto Input", "H", this.Name));

                _with1.Add("B1:" + "재료경 일괄입력");//Msg_Lang("재료경 일괄입력", "Material Width Batch Input", "I", this.Name));
                _with1.Add("B2:" + "절단장 일괄입력");//Msg_Lang("절단장 일괄입력", "Material Length Batch Input", "J", this.Name));
                _with1.Add("BA:" + "평균값 산출입력");//Msg_Lang("평균값 산출입력", "Calculate Average Input", "K", this.Name));
                _with1.Add("BB:" + "최소값 산출입력");//Msg_Lang("최소값 산출입력", "Calculate Minimun Input", "L", this.Name));
                //
                _with1.Add("CZ:" + "사이드로드 관리항목");//Msg_Lang("사이드로드 관리항목", "Sideload Coil Item", "M", this.Name));
                //
                _with1.Add("#1:" + "아이포밍 1차항목");//Msg_Lang("아이포밍 1차항목", "For 1st Eyeforming Item", "N", this.Name));
                //.Add("#2:" & Msg_Lang("아이포밍 2차항목", "For 2nd Eyeforming Item", "O", Me.Name))

                //K9 승용에어용
                if (Convert.ToString(cboPlantCode_H.SelectedValue) == "A")
                {
                    _with1.Add("K1:" + "FRT Lower Ring 체결력");//Msg_Lang("FRT Lower Ring 체결력"     , "LOWER_FORCE2"));
                    _with1.Add("K2:" + "FRT Lower Ring 변위량");//Msg_Lang("FRT Lower Ring 변위량"     , "LOWER_BYUNWI2"));
                    _with1.Add("K3:" + "FRT Upper Ring 체결력");//Msg_Lang("FRT Upper Ring 체결력"      , "UPPER_FORCE2"));
                    _with1.Add("K4:" + "FRT Upper Ring 변위량");//Msg_Lang("FRT Upper Ring 변위량"      , "UPPER_BYUNWI2"));
                    _with1.Add("K5:" + "FRT Piston Ring 체결력");//Msg_Lang("FRT Piston Ring 체결력"     , "PISTON_FORCE2"));
                    _with1.Add("K6:" + "FRT Piston Ring 변위량");//Msg_Lang("FRT Piston Ring 변위량"     , "PISTON_BYUNWI2"));
                    _with1.Add("K7:" + "FRT PRV 체결토크");//Msg_Lang("FRT PRV 체결토크"           , "PRV_VALVE_TQ"));
                    _with1.Add("K8:" + "FRT PRV 커넥터 체결토크");//Msg_Lang("FRT PRV 커넥터 체결토크"     , "AIR_CON_TQ"));
                    _with1.Add("K9:" + "FRT Hex nut 체결토크");//Msg_Lang("FRT Hex nut 체결토크"       , "HEX_NUT_TQ"));
                    _with1.Add("KA:" + "FRT 누기량");//Msg_Lang("FRT 누기량"                  , "DAMP_AMT"));
                    _with1.Add("KB:" + "RR Air Connector 체결토크");//Msg_Lang("RR Air Connector 체결토크"    , "RR_CON_TQ"));
                    _with1.Add("KC:" + "RR Piston Ring 체결력");//Msg_Lang("RR Piston Ring 체결력"       , "PISTON_FORCE2"));
                    _with1.Add("KD:" + "RR Piston Ring 변위량");//Msg_Lang("RR Piston Ring 변위량"        , "PISTON_BYUNWI2"));
                    _with1.Add("KE:" + "RR Cap Ring 체결력");//Msg_Lang("RR Cap Ring 체결력"           , "CAP_FORCE2"));
                    _with1.Add("KF:" + "RR Cap Ring 변위량");//Msg_Lang("RR Cap Ring 변위량"           , "CAP_BYUNWI2"));
                    _with1.Add("KG:" + "RR 누기량");//Msg_Lang("RR 누기량"                    , "DAMP_AMT"));
                }

                Sql.Length = 0;
                Sql.AppendLine("select distinct upper(IAUTO) || ':' || IITEM_MEMO");
                Sql.AppendLine(" from INSP_ITEM");
                Sql.AppendLine(" where IAUTO like 'r%' or IAUTO like 'R%'");
                Sql.AppendLine("   and plantcode = '" + Convert.ToString(cboPlantCode_H.SelectedValue) + "'");
                Sql.AppendLine(" order by 1");
                int dbRowCnt = 0;
                rtnDtTable = helper.FillTable(Sql.ToString(), CommandType.Text);
                if (rtnDtTable.Rows.Count > 0)
                {
                    dbRowCnt = 0;
                    var _with2 = cboAuto;
                    while (!(dbRowCnt == rtnDtTable.Rows.Count))
                    {
                        _with2.Items.Add(rtnDtTable.Rows[dbRowCnt][1]);

                        dbRowCnt += 1;
                    }
                    _with2.SelectedIndex = 0;
                }
                sKey = sParam[0].ToString().Split('|');

                dbRowCnt = 0;
                Sql.Length = 0;
                Sql.AppendLine(" Select PROCESS_CD, IPROCESS_NAME  From PROCESS ");
                Sql.AppendLine(" Where  IPROCESS_CD like '" + sKey[0].ToString().Substring(0, 2) + "%'");
                Sql.AppendLine("   and  PLANTCODE = '" + Convert.ToString(cboPlantCode_H.SelectedValue) + "'");
                rtnDtTable = helper.FillTable(Sql.ToString(), CommandType.Text);

                if (rtnDtTable.Rows.Count > 0)
                {
                    var _with3 = cboProcessCd;
                    _with3.Items.Clear();
                    _with3.Items.Add("00000 " + "전체");
                    while (!(dbRowCnt == rtnDtTable.Rows.Count))
                    {
                        _with3.Items.Add(rtnDtTable.Rows[dbRowCnt]["Process_cd"] + " " + rtnDtTable.Rows[dbRowCnt]["Iprocess_name"]);

                        dbRowCnt += 1;
                    }
                    int tX = 0;
                    tX = _with3.FindString(sKey[2]);
                    if (tX > 0)
                    {
                        _with3.SelectedIndex = tX;
                    }
                }

                var _with4 = cboTerm;
                _with4.Items.Clear();
                _with4.Items.Add("L8:" + "로트당 8회");//  Msg_Lang("로트당 8회"    , "8 per LOT"));
                _with4.Items.Add("L5:" + "로트당 5회");//  Msg_Lang("로트당 5회"    , "5 per LOT"));
                _with4.Items.Add("L3:" + "로트당 3회");//  Msg_Lang("로트당 3회"    , "3 per LOT"));
                _with4.Items.Add("L2:" + "로트당 2회");//  Msg_Lang("로트당 2회"    , "2 per LOT"));
                _with4.Items.Add("L1:" + "로트당 1회");//  Msg_Lang("로트당 1회"    , "1 per LOT"));
                _with4.Items.Add("S1:" + "작업조당 1회");//Msg_Lang("작업조당 1회"  , "1 per Shift"));
                _with4.Items.Add("D1:" + "매일 1회");//  Msg_Lang("매일 1회"      , "1 per Day"));
                _with4.Items.Add("W1:" + "1주당 1회");//  Msg_Lang("1주당 1회"     , "1 per 1 Week"));
                _with4.Items.Add("W2:" + "2주당 1회");//  Msg_Lang("2주당 1회"     , "1 per 2 Week"));
                _with4.Items.Add("W3:" + "3주당 1회");//  Msg_Lang("3주당 1회"     , "1 per 3 Week"));
                _with4.Items.Add("E3:" + "30분당 1회");//  Msg_Lang("30분당 1회"    , "1 per 30 Minute"));
                _with4.SelectedIndex = 0;

                Data_Display();

                //신규둥록인 경우 품목,항목번호를 입력할 수 있게 함
                if (sKey[1] == "0")
                {
                    tProcessCd.Enabled = true;
                    //자동으로 최종+1 순번뜨게 함
                    Sql.Length = 0;
                    Sql.AppendLine("select nvl(max(IITEM_NO),0)+1 from INSP_ITEM");
                    Sql.AppendLine(" where IPROCESS_CD = '" + tProcessCd.Text.ToString() + "'");
                    Sql.AppendLine("   and IITEM_NO < 90000");
                    rtnDtTable = helper.FillTable(Sql.ToString(), CommandType.Text);

                    if (rtnDtTable.Rows.Count == 0)
                    {
                        tItemNo.Text = "1";
                    }
                    else
                    {
                        tItemNo.Text = rtnDtTable.Rows[0][0].ToString();
                    }
                    tItemNo.Enabled = true;
                    tValidDate.Text = "20991231";
                    //cboProcessCd.SelectedIndex = 0;
                    cboAuto.SelectedIndex = 0;
                    cboBlind.SelectedIndex = 1;
                }
                else
                {
                    tProcessCd.Enabled = true;
                    tItemNo.Enabled = true;
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
        private void Data_Display()
        {
            Init();

            DBHelper helper = new DBHelper(false);
            BtnDelete.Enabled = false;


            try
            {
                Sql.Length = 0;
                Sql.AppendLine(" Select * From INSP_ITEM ");
                Sql.AppendLine(" Where  iprocess_cd = '" + sKey[0] + "' and ");
                Sql.AppendLine("        iitem_no = " + sKey[1]);
                rtnDtTable = helper.FillTable(Sql.ToString(), CommandType.Text);

                if (rtnDtTable.Rows.Count > 0)
                {
                    DataRow Dr = null;
                    Dr = rtnDtTable.Rows[0];
                    tProcessCd.Text = CString(Dr["iprocess_cd"]);
                    tItemNo.Text = CString(Dr["iitem_no"]);
                    tItemMemo.Text = CString(Dr["iitem_memo"]);
                    tValidDate.Text = CString(Dr["ivalid_date"]);
                    tPrtSeq.Text = CString(Dr["iprt_seq"]);
                    tMethod.Text = CString(Dr["imethod"]);
                    tUnit.Text = CString(Dr["iunit"]);
                    cboProcessCd.SelectedIndex = cboProcessCd.FindString(CString(Dr["process_cd"]));
                    cboAuto.SelectedIndex = cboAuto.FindString(CString(Dr["IAUTO"]));
                    tEMemo.Text = CString(Dr["iITEM_EMEMO"]);
                    if ((Dr["IITEM_KMEMO"]) != null)
                    {
                        tKMemo.Text = CString(Kor_Show(Dr["iITEM_KMEMO"].ToString()));
                    }
                    cboBlind.SelectedIndex = cboBlind.FindString(CString(Dr["IBLIND"]));

                    if ((Dr["ITYPE"].ToString().Substring(1, 1) == "1"))
                    {
                        chkSec1.Checked = true;
                    }
                    else
                    {
                        chkSec1.Checked = false;
                    }
                    if (Dr["ITYPE"].ToString().Substring(2, 1) == "1")
                    {
                        chkSec2.Checked = true;
                    }
                    else
                    {
                        chkSec2.Checked = false;
                    }
                    if (Dr["ITYPE"].ToString().Substring(3, 1) == "1")
                    {
                        chkSec3.Checked = true;
                    }
                    else
                    {
                        chkSec3.Checked = false;
                    }
                    if (Dr["ITYPE"].ToString().Substring(4, 1) == "1")
                    {
                        chkSec4.Checked = true;
                    }
                    else
                    {
                        chkSec4.Checked = false;
                    }

                    cboTerm.SelectedIndex = cboTerm.FindString(Dr["ITERM"].ToString());

                    BtnDelete.Enabled = true;
                }
                else
                {
                    tProcessCd.Text = sKey[0];
                }

                switch (tProcessCd.Text.ToString().Substring(0, 2))
                {
                    case "02":
                        chkSec1.Text = "일반";
                        //一般"
                        chkSec2.Text = "열간SLC";
                        //"热卷SLC"
                        chkSec3.Text = "냥간SLC";
                        //"冷卷SLC"
                        chkSec4.Text = "미니블록";
                        //"中凸形"
                        break;
                    case "06":
                        chkSec1.Text = "중실";
                        chkSec2.Text = "PIPE";
                        chkSec3.Text = "T/B";
                        chkSec4.Text = "";
                        break;
                    default:
                        chkSec1.Text = "";
                        chkSec2.Text = "";
                        chkSec3.Text = "";
                        chkSec4.Text = "";
                        break;
                }

            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex);
            }
            finally
            {
                helper.Close();
            }
        }
        private void Init()
        {
            tProcessCd.Text = "";
            tItemNo.Text = "";
            tItemMemo.Text = "";
            tValidDate.Text = "";
            tPrtSeq.Text = "";
            tMethod.Text = "";
            tUnit.Text = "";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string Result = "";
            DBHelper helper = new DBHelper("", true);
            //helper.Connection.BeginTransaction();
            try
            {
                DialogResult dr = MessageBox.Show("삭제 하시겠습니까?" + Convert.ToChar(10) + "Are you going to delete?", "", MessageBoxButtons.YesNoCancel);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    Sql.Length = 0;
                    Sql.AppendLine(" update INSP_ITEM set IVALID_DATE = '" + Convert.ToString(DateTime.Now.AddDays(-1).ToString("yyyyMMdd")) + "'");
                    Sql.AppendLine(" where iprocess_cd = '" + tProcessCd.Text.Trim() + "' and ");
                    Sql.AppendLine("   and PLANTCODE   = '" + Convert.ToString(cboPlantCode_H.SelectedValue) + "'");
                    Sql.AppendLine("       iitem_no = " + tItemNo.Text.ToString());
                    helper.ExecuteNoneQuery(Sql.ToString(), CommandType.Text);
                    MessageBox.Show("삭제 하였습니다" + Convert.ToChar(10) + "Data is deleted");
                    this.Dispose();
                    helper.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("삭제 실패 하였습니다" + Convert.ToChar(10) + "Fail to delete");
                helper.Rollback();
            }
            finally
            {
                helper.Close();
            }
        }
        private void BtnWrite_Click(object sender, EventArgs e)
        {
            string Result = "";
            if (tItemMemo.Text.Trim() == "")
            {
                tItemMemo.Focus();
                //sMsg = Msg_Lang("내용을 반드시 입력하세요...", "Missing Memo", "T1", this.Name);
                MessageBox.Show("내용을 반드시 입력하세요...", "Missing Memo");
                return;
            }

            if (tValidDate.Text.Trim() == "" || tValidDate.Text.Trim() == null)
            {
                tValidDate.Text = "29991231";
            }

            if (tPrtSeq.Text.Trim() == "" || tPrtSeq.Text.Trim() == null)
            {
                tPrtSeq.Focus();
                MessageBox.Show("출력순서를 반드시 입력하세요..." + "Missing Seq.");
                return;
            }

            DBHelper helper = new DBHelper("", true);
            // helper.Connection.BeginTransaction();

            try
            {
                string tType = null;
                switch (tProcessCd.Text.ToString().Substring(0, 2))
                {
                    case "02":
                        tType = "C";
                        break;
                    case "06":
                        tType = "S";
                        break;
                    default:
                        tType = " ";
                        break;
                }
                if (tType != " ")
                {
                    tType += (chkSec1.Checked ? "1" : "0");
                    tType += (chkSec2.Checked ? "1" : "0");
                    tType += (chkSec3.Checked ? "1" : "0");
                    tType += (chkSec4.Checked ? "1" : "0");
                }

                string tAuto = cboAuto.Text.ToString().Substring(0, 2).Trim();
                if (tAuto.ToString().Substring(0, 1).ToUpper() == "R")
                {
                    if (tProcessCd.Text.ToString().Substring(0, 2) == "66")
                    {
                        tAuto = tAuto.ToLower();
                    }
                    else
                    {
                        tAuto = tAuto.ToUpper();
                    }
                }

                if (BtnDelete.Enabled == false)
                {
                    int item_no = 0;

                    Sql.Length = 0;
                    Sql.AppendLine(" select nvl(max(iitem_no),0) + 1 as item_no   from INSP_ITEM ");
                    Sql.AppendLine(" where  iprocess_cd = '" + tProcessCd.Text.Trim() + "' ");
                    Sql.AppendLine("   and  IITEM_NO < 90000");
                    Sql.AppendLine("   and  PLANTCODE = '" + Convert.ToString(cboPlantCode_H.SelectedValue) + "'");
                    rtnDtTable = helper.FillTable(Sql.ToString(), CommandType.Text);

                    item_no = Convert.ToInt32(rtnDtTable.Rows[0]["item_no"]);


                    Sql.Length = 0;
                    Sql.AppendLine("Insert into INSP_ITEM");
                    Sql.AppendLine("       (iprocess_cd, iitem_no, iitem_memo, ");
                    Sql.AppendLine("        imethod, ivalid_date, iprt_seq, iunit, process_cd, IAUTO, ");
                    Sql.AppendLine("        IITEM_EMEMO, IITEM_KMEMO, IBLIND, ITYPE, ITERM )");
                    Sql.AppendLine(" Values('" + tProcessCd.Text.Trim() + "',");
                    Sql.AppendLine("         " + item_no + " , '" + tItemMemo.Text.Trim() + "',");
                    Sql.AppendLine("        '" + tMethod.Text.Trim() + "', '" + tValidDate.Text.Trim() + "',");
                    Sql.AppendLine("         " + cVal(tPrtSeq.Text.ToString()) + ",'" + tUnit.Text.Trim() + "',");
                    Sql.AppendLine("        '" + cboProcessCd.Text.ToString().Substring(0, 5) + "',");
                    Sql.AppendLine("        '" + tAuto + "', ");
                    Sql.AppendLine("        '" + tEMemo.Text.Trim() + "', ");
                    Sql.AppendLine("        '" + tKMemo.Text.Trim() + "', ");//Kor_Save(tKMemo.Text.Trim) + "',"; //!!
                    Sql.AppendLine("        '" + cboBlind.Text.ToString().Substring(0, 1) + "',");
                    Sql.AppendLine("        '" + tType + "',");
                    Sql.AppendLine("        '" + cboTerm.Text.ToString().Substring(0, 2) + "' )");
                }
                else
                {
                    Sql.Length = 0;
                    Sql.AppendLine("Update INSP_ITEM");
                    Sql.AppendLine("   Set iitem_memo = '" + tItemMemo.Text.Trim() + "',");
                    Sql.AppendLine("       imethod = '" + tMethod.Text.Trim() + "',");
                    Sql.AppendLine("       ivalid_date = '" + tValidDate.Text.Trim() + "',");
                    Sql.AppendLine("       iprt_seq =  " + cVal(tPrtSeq.Text.ToString()) + " ,");
                    Sql.AppendLine("       iunit = '" + tUnit.Text.Trim() + "', ");
                    Sql.AppendLine("       process_cd = '" + cboProcessCd.Text.ToString().Substring(0, 5) + "', ");
                    Sql.AppendLine("       IAUTO = '" + tAuto + "',");
                    Sql.AppendLine("       iitem_ememo = '" + tEMemo.Text.Trim() + "',");
                    Sql.AppendLine("       iitem_kmemo = '" + tKMemo.Text.Trim() + "',");//Kor_Save(tKMemo.Text.Trim) + "',"; //!!
                    Sql.AppendLine("       IBLIND = '" + cboBlind.Text.ToString().Substring(0, 1) + "',");
                    Sql.AppendLine("       ITYPE = '" + tType + "',");
                    Sql.AppendLine("       ITERM = '" + cboTerm.Text.ToString().Substring(0, 2) + "'");
                    Sql.AppendLine(" where iprocess_cd = '" + tProcessCd.Text.Trim() + "' and ");
                    Sql.AppendLine("       iitem_no = " + tItemNo.Text);
                }
                helper.ExecuteNoneQuery(Sql.ToString(), CommandType.Text);
                helper.Commit();
                MessageBox.Show("검사 항목을 등록했습니다." + Convert.ToChar(10) + "Inspect item is saved.");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("검사 항목 등록시 오류가 발생했습니다." + Convert.ToChar(10) + "An error occurs to save.");
                helper.Rollback();
                //MessageBox.Show(sMsg + Strings.Chr(10) + Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                helper.Close();
            }
        }






        public string CString(object Tmp)
        {
            string functionReturnValue = null;
            try
            {
                if (Tmp == null)
                {
                    Tmp = "";
                }

                functionReturnValue = (Convert.ToString(Tmp).Replace("'", " "));

                if (functionReturnValue == null)
                {
                    functionReturnValue = "";
                }

            }
            catch (Exception ex)
            {
                functionReturnValue = "";
            }
            return functionReturnValue;
        }
        public string Kor_Show(string tHan)
        {
            string tH = null;
            string tX = null;
            int tL = 0;
            int iX = 0;
            string tRet = "";

            if (string.IsNullOrEmpty(tHan.Trim()))
                goto Exit_T;

            try
            {
                //LF값처리($A로 바뀌어 들어가있지 않은 자료들 때문에...)
                string[] xHan = null;
                int iY = 0;
                xHan = tHan.Trim().Split(Convert.ToChar(10));

                for (iY = 0; iY <= xHan.Length - 1; iY++)
                {
                    iX = 1;
                    tL = xHan[iY].Length;

                    string yHan = "";
                    //임시방
                    while (iX <= tL)
                    {
                        switch (xHan[iY].ToString().Substring(iX - 1, 1))
                        {
                            case "*":
                                iX += 1;
                                tH = xHan[iY].ToString().Substring(iX - 1, 4);
                                tX = Convert.ToString(Convert.ToInt32(tH, 16));
                                iX += 4;
                                break;
                            case "$":
                                iX += 1;
                                //LF값 먼저 처리($A)
                                if (xHan[iY].ToString().Substring(iX - 1, 1) == "A" & xHan[iY].ToString().Substring(iX, 1) == "*" || xHan[iY].ToString().Substring(iX, 1) == "$")
                                {
                                    tX = Convert.ToString(Convert.ToChar(10));
                                    iX += 1;
                                }
                                else
                                {
                                    tH = xHan[iY].ToString().Substring(iX - 1, 2);
                                    tX = Convert.ToString((Convert.ToInt32(tH, 16)));
                                    iX += 2;
                                }
                                break;
                            default:
                                tH = xHan[iY].ToString().Substring(iX - 1, 1);
                                tX = tH;
                                iX += 1;
                                break;
                        }
                        yHan += tX;
                    }

                    tRet += yHan + Convert.ToChar(10);
                }

            }
            catch (Exception ex)
            {
                tRet = "";
            }
        Exit_T:

            return tRet.Trim();
        }
        public double cVal(object tStr)
        {
            double functionReturnValue = 0;
            try
            {
                if (tStr == null)
                {
                    tStr = "";
                    //Else
                    //   tStr = tStr.Trim
                }

                string Temp = Convert.ToString(tStr);

                //메뉴에서 선택된 언어가 아닌 실제 PC의 값을 가져와야 되므로...
                string sSep = null;
                sSep = System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator;
                //체코는 천단위 구분자를 .로 유럽은 ,로 사용
                Temp = Temp.ToString().Replace(sSep, "");
                sSep = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyGroupSeparator;
                Temp = Temp.ToString().Replace(sSep, "");

                sSep = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol;
                //통화기호 삭제
                Temp = Temp.ToString().Replace(sSep, "");

                sSep = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
                //유럽은 소숫점을 ,로사용
                Temp = Temp.ToString().Replace(sSep, "");
                sSep = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;
                Temp = Temp.ToString().Replace(sSep, "");

                Temp = Temp.ToString().Replace(sSep, "");
                Temp = Temp.ToString().Replace(sSep, "");
                Temp = Temp.ToString().Replace(sSep, "");
                Temp = Temp.ToString().Replace(sSep, "");

                if (Temp == null)
                {
                    functionReturnValue = 0;
                }
                else if (string.IsNullOrEmpty(Temp))
                {
                    functionReturnValue = 0;
                }
                else
                {
                    functionReturnValue = Convert.ToDouble(Temp);
                }

            }
            catch (Exception ex)
            {
                functionReturnValue = 0;
            }
            return functionReturnValue;
        }

        //DB의 헥사 한글변환
        //public string Kor_Save(string tHan)
        //{
        //    string tH = null;
        //    string tX = null;
        //    string tZ = null;
        //    int tL = tHan.Length;
        //    int iX = 0;
        //    string tRet = "";

        //    for (iX = 1; iX <= tL; iX++)
        //    {
        //        tH = tHan.ToString().Substring(iX, 1);
        //        //If tH >= "가" Then
        //        //    tX = "*"
        //        //Else
        //        //    tX = "$"
        //        //End If
        //        //tX &= Hex(AscW(tH))
        //        tZ = Conversion.Hex(String.AscW(tH));
        //        if (bKorean(tZ) & tZ.Length > 3)
        //        {
        //            tX = "*" + tZ;
        //        }
        //        else if (tH == "*")
        //        {
        //            tX = "$" + tZ;
        //        }
        //        else
        //        {
        //            tX = tH;
        //        }
        //        tRet += tX;
        //    }

        //    return tRet.Trim();
        //}
        private void BtnSign1_Click(object sender, EventArgs e)
        {
            tUnit.Text += ((System.Windows.Forms.Button)(sender)).Text.ToString();
        }



    }
}

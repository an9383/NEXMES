using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class POP_YQM5030 : WIZ.Forms.BasePopupForm
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
        StringBuilder Sql2 = new StringBuilder();
        string[] sKey = new string[3];
        private string[] aSql = new string[50];
        int j = 0;
        #endregion

        public POP_YQM5030(string[] param)
        {
            InitializeComponent();
            sParam = param;
            argument = new string[param.Length];

        }

        private void POP_YQM5030_Load(object sender, EventArgs e)
        {

            if (sParam[0].ToString() == "Z")
            {
                INITAIL.Visible = true;
                cboAlpha.Visible = true;
            }
            else
            {
                INITAIL.Visible = false;
                cboAlpha.Visible = false;
            }

            //Combo_Display("PRODUCT_GB", this.cboSection, false);
            //-- Section 구분

            string sAlpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int iCnt = 0;
            for (iCnt = 1; iCnt <= 26; iCnt++)
            {
                var _with1 = cboAlpha.Items;
                _with1.Add(sAlpha.ToString().Substring(iCnt - 1, 1));
            }

            var _with2 = cboSection.Items;
            _with2.Add("00 " + "관리자");//, "Manager", "@-C1"));
            _with2.Add("99 해당사항없슴");
            //cboSection.SelectedIndex = 0;
            //cboIadmin.SelectedIndex = 0;
            //cboAlpha.SelectedIndex = 0;

            InitTextBox();
            this.Tag = sParam[1].ToString();

            if (this.Tag.ToString() == "")
            {
                BtnDelete.Enabled = false;
            }
            else
            {
                string[] sKEY = this.Tag.ToString().Split('|');
                //FindCombo(cboSection, sKEY[0]);
                tSabeon.Text = sKEY[1].ToString().Replace(".", "");
                cboIadmin.Text = sKEY[2];
                tName.Text = sKEY[3];
                tDept_Name.Text = sKEY[4];
                cboAlpha.Text = sKEY[5];
                BtnDelete.Enabled = true;
            }
            Common _Common = new Common();
            rtnDtTable = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTable, rtnDtTable.Columns["CODE_ID"].ColumnName, rtnDtTable.Columns["CODE_NAME"].ColumnName, "ALL", "");

        }
        private void InitTextBox()
        {
            tSabeon.Text = "";
            tName.Text = "";
        }

        private void BtnWrite_Click(System.Object sender, System.EventArgs e)
        {
            if (tSabeon.Text.ToString().Trim() == "" || tName.Text.ToString().Trim() == "")
            {
                MessageBox.Show("해당하는 사원이 없습니다" + Convert.ToChar(10) + "There is no Employee");

                return;
            }
            if (Convert.ToString(cboPlantCode_H.Value) == "")
            {
                MessageBox.Show("사업장을 입력 하세요 ");
                return;
            }
            DBHelper helper = new DBHelper("", true);
            //helper.Transaction = helper._sConn.BeginTransaction(); 

            string Result = "";
            int iDx = -1;
            string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
            try
            {

                if (sPlantCode == "A" || sPlantCode == "1100" || sPlantCode == "K" ||
                    sPlantCode == "J" || sPlantCode == "L" || sPlantCode == "N")
                {
                    Sql.Length = 0;
                    Sql.AppendLine(" SELECT COUNT(*) AS CNT FROM WORKER ");
                    Sql.AppendLine(" WHERE  SABEON = '" + tSabeon.Text + "'");
                    rtnDtTable = helper.FillTable(Sql.ToString(), CommandType.Text);

                    if (rtnDtTable.Rows[0]["CNT"].ToString() == "0")
                    {
                        Sql.Length = 0;
                        Sql.AppendLine(" INSERT INTO WORKER ");
                        Sql.AppendLine("         ( PLANTCODE, SABEON, IADMIN, SECTION, HNAME");
                        if (sPlantCode == "A" || sPlantCode == "K" ||
                            sPlantCode == "J" || sPlantCode == "L" || sPlantCode == "N")
                        {
                            Sql.AppendLine("  , DEPT_NAME");
                        }
                        if (sPlantCode == "J")
                        {
                            Sql.AppendLine("  , DEPT_CD");
                        }
                        Sql.AppendLine(" )");
                        Sql.AppendLine("  VALUES ('" + sPlantCode.ToString() + "',");
                        Sql.AppendLine("          '" + tSabeon.Text.ToString().Trim() + "', ");
                        Sql.AppendLine("          '" + cboIadmin.Text.ToString() + "', ");
                        Sql.AppendLine("          '" + cboSection.Text.ToString().Substring(0, 2) + "',");
                        Sql.AppendLine("          '" + tName.Text.ToString().Trim() + "'");
                        if (sPlantCode == "A" || sPlantCode == "K" ||
                            sPlantCode == "J" || sPlantCode == "L" || sPlantCode == "N")
                        {
                            Sql.AppendLine("     , '" + tDept_Name.Text.ToString().Trim() + "' ");
                        }
                        if (sPlantCode == "J")
                        {
                            Sql.AppendLine("  , '0000'");
                        }
                        Sql.AppendLine(" )");
                    }
                    else
                    {
                        Sql.Length = 0;
                        Sql.AppendLine(" UPDATE WORKER ");
                        Sql.AppendLine(" SET    IADMIN = '" + cboIadmin.Text.ToString() + "', ");
                        Sql.AppendLine("        SECTION = '" + cboSection.Text.ToString().Substring(0, 2) + "', ");
                        Sql.AppendLine("        HNAME = '" + tName.Text.ToString().Trim() + "'");
                        if (sPlantCode == "A" || sPlantCode == "K" ||
                            sPlantCode == "J" || sPlantCode == "L" || sPlantCode == "N")
                        {
                            Sql.AppendLine("  , DEPT_NAME = '" + tDept_Name.Text.ToString().Trim() + "' ");
                        }
                        Sql.AppendLine(" WHERE  SABEON = '" + tSabeon.Text.ToString() + "'");
                        Sql.AppendLine("   and  PLANTCODE = '" + sPlantCode.ToString() + "'");
                    }
                }
                else
                {
                    Sql.Length = 0;
                    Sql.AppendLine(" Delete From Insp_Worker ");
                    Sql.AppendLine(" Where  sabeon = '" + tSabeon.Text.ToString() + "'");
                    Sql.AppendLine("        plantcode = '" + sPlantCode.ToString() + "'");

                    iDx += 1;
                    Array.Resize(ref aSql, iDx + 1);
                    aSql[iDx] = Sql.ToString();

                    Sql2.Length = 0;
                    Sql2.AppendLine(" INSERT INTO Insp_Worker ");
                    Sql2.AppendLine("         (PLANTCODE, SABEON, HNAME, INAME, DEPT, IADMIN, SECTION  )");
                    Sql2.AppendLine("  VALUES ( '" + sPlantCode.ToString() + "',");
                    Sql2.AppendLine("           '" + tSabeon.Text.ToString().Trim() + "',");
                    Sql2.AppendLine("           '" + ConvertText(tName.Text.ToString().Trim()) + "',");
                    //중국만 이름 발음기호로 영문자 첫자로 검색기능 넣음
                    if (sPlantCode == "Z")
                    {
                        Sql2.AppendLine("        '" + cboAlpha.Text.ToString().Substring(0, 1) + "',");
                    }
                    else
                    {
                        Sql2.AppendLine("        '',");
                    }
                    Sql2.AppendLine("           '" + tDept_Name.Text.ToString().Trim() + "',");
                    Sql2.AppendLine("           '" + cboIadmin.Text.ToString().Trim() + "' ,");
                    Sql2.AppendLine("           '" + cboSection.Text.ToString().Substring(0, 2) + "') ");
                }
                helper.ExecuteNoneQuery(Sql.ToString());
                helper.ExecuteNoneQuery(Sql2.ToString());
                helper.Commit();
                MessageBox.Show("확인" + Convert.ToChar(10) + " O K ");
                this.Dispose();

                InitTextBox();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show("실패 하였습니다" + Convert.ToChar(10) + "ERROR", "@-Q4");
            }
            finally
            {
                helper.Close();
            }
        }


        public void Combo_Display(string sGroup, ComboBox cbo, bool bAll, string LineGB = "")
        {
            int i = 0;
            string[] AGroup = sGroup.ToString().Split(',');
            string strGroup = "";
            DBHelper helper = new DBHelper(false);

            //천안공정 코일라인 공정 구분하도록 LineGB 사용(S일 경우 코일라인으로 볼 수 있게)
            try
            {
                for (i = 0; i <= AGroup.Length - 1; i++)
                {
                    strGroup += (strGroup.ToString().Length == 0 ? "" : ",") + "'" + AGroup[i] + "'";
                }

                int dbRowCnt = 0;

                Sql.Length = 0;
                Sql.AppendLine("Select m_code, m_name ");
                Sql.AppendLine("  From mgr_code ");
                Sql.AppendLine(" Where mgr_group in (" + strGroup + ")");
                if (LineGB == "S" && strGroup.ToString().Replace("'", "") == "PRODUCT_GB")
                {
                    Sql.AppendLine("   And ( use_gb ='S' OR M_CODE IN ('02', '00') )");
                    // --- 코일S/P, 소재가공
                }
                else
                {
                    Sql.AppendLine("   and use_gb = 'Y'");
                }
                Sql.AppendLine(" Order by m_code");
                rtnDtTable = helper.FillTable(Sql.ToString(), CommandType.Text);

                if (rtnDtTable.Rows.Count > 0)
                {
                    var _with1 = cbo;
                    _with1.Items.Clear();
                    //   If bAll Then .Items.Add(GetIniFileString(sCountry, "ALL", "전체", "lang.ini"))
                    if (bAll)
                        _with1.Items.Add("00 " + "전체");//, "ALL", "@-AALL"));
                    while (!(dbRowCnt == rtnDtTable.Rows.Count))
                    {
                        _with1.Items.Add(rtnDtTable.Rows[dbRowCnt]["m_code"].ToString() + " " + rtnDtTable.Rows[dbRowCnt]["m_name"]);

                        dbRowCnt += 1;
                    }
                    _with1.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void BtnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Dispose();
        }
        private void BtnDelete_Click(System.Object sender, System.EventArgs e)
        {
            string sResult = null;
            string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
            if (Convert.ToString(cboPlantCode_H.Value) == "")
            {
                MessageBox.Show("사업장을 입력 하세요 ");
                return;
            }
            DBHelper helper = new DBHelper("", true);
            //helper.Transaction = helper._sConn.BeginTransaction(); 

            try
            {
                //삭제하니까 복구하기 어려워 대신 퇴사일자를 넣어 스마트패드에 안나오게 함 2013.11.11
                DialogResult dr = MessageBox.Show("삭제 하시겠습니까?" + Convert.ToChar(10) + "Are you going to delete?", "", MessageBoxButtons.YesNoCancel);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    if (sPlantCode == "C")
                    {
                        Sql.Length = 0;
                        //Sql = Sql & " DELETE FROM WORKER "
                        Sql.AppendLine("update WORKER set TOISA_DATE = to_date('" + DateTime.Now.ToString("yyyyMmdd") + "','YYYYMMDD')");
                        Sql.AppendLine(" WHERE  SABEON='" + tSabeon.Text.ToString().Trim() + "'");
                    }
                    else if (sPlantCode == "A" || sPlantCode == "K" ||
                    sPlantCode == "J" || sPlantCode == "L" || sPlantCode == "N")
                    {
                        Sql.Length = 0;
                        //Sql = Sql & " DELETE FROM WORKER "
                        Sql.AppendLine("update WORKER set OUT_DATE = '" + DateTime.Now.ToString("yyyyMmdd") + "'");
                        Sql.AppendLine(" WHERE  SABEON='" + tSabeon.Text.ToString().Trim() + "'");
                    }
                    else
                    {
                        Sql.Length = 0;
                        //Sql = Sql & " DELETE FROM Insp_Worker"
                        Sql.AppendLine("update INSP_WORKER set OUT_DATE = '" + DateTime.Now.ToString("yyyyMmdd") + "'");
                        Sql.AppendLine(" WHERE  SABEON='" + tSabeon.Text.ToString().Trim() + "'");
                    }
                    helper.ExecuteNoneQuery(Sql.ToString());
                    helper.Commit();
                    MessageBox.Show("삭제 하였습니다" + Convert.ToChar(10) + "Data is deleted");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show("삭제 실패 하였습니다" + Convert.ToChar(10) + "Fail to delete", "@-Q4");
            }
            finally
            {
                helper.Close();
            }

        }
        public void FindCombo(ComboBox ComboBox, string Content)
        {
            int i = 0;

            ComboBox.SelectedIndex = -1;

            if (Content.ToString().Length == 0)
                return;

            for (i = 0; i <= ComboBox.Items.Count - 1; i++)
            {
                if (ComboBox.Items[i].ToString() == ("*" + Content + "*"))
                {
                    ComboBox.SelectedIndex = i;
                    return;
                }
            }
        }
        public string ConvertText(string tmp)
        {
            string functionReturnValue = null;

            try
            {
                //-- DataBase 에 "'"를 넣기 위함..
                tmp = tmp.ToString().Replace("'", " ");

                if (string.IsNullOrEmpty(tmp))
                {
                    functionReturnValue = " ";
                }
                else
                {
                    functionReturnValue = tmp;
                }
            }
            catch (Exception ex)
            {
                functionReturnValue = " ";
            }
            return functionReturnValue;

        }

        private void POP_YQM5030_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Tag = rtnDtTable;
        }

    }
}

using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class POP_YQM5010 : WIZ.Forms.BasePopupForm
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
        #endregion
        public POP_YQM5010(string[] param)
        {
            sParam = param;
            InitializeComponent();
            argument = new string[param.Length];

            Common _Common = new Common();

            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");


        }

        private void POP_YQM5010_Load(object sender, EventArgs e)
        {

            GirdSet();
            LoadFormSet();

        }
        private void GirdSet()
        {
            _GridUtil.InitializeGrid(this.Spread1);

            _GridUtil.InitColumnUltraGrid(Spread1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Spread1, "IPROCESS_CD", "검사공정코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Spread1, "IPROCESS_NAME", "검사공정명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Spread1, "IITEM_NO", "검사항목코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Spread1, "IITEM_MEMO", "검사항목명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Spread1, "INSP_SPEC", "기준값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Spread1, "Min", "하한값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Spread1, "Max", "상한값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Spread1, "Check", "Check", false, GridColDataType_emu.CheckBox, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(Spread1);

            _GridUtil.InitializeGrid(this.Spread2);

            _GridUtil.InitColumnUltraGrid(Spread2, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Spread2, "ITEM_CD", "제품코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Spread2, "ITEM_NAME", "제품목명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Spread2, "Check", "Check", false, GridColDataType_emu.CheckBox, 60, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(Spread2);
        }

        private void LoadFormSet()
        {
            DBHelper helper = new DBHelper(false);
            //주안만 제품 세부구분 해달라고 해서 추가
            try
            {

                if (sParam[0].ToString() == "A") cboWork.Visible = true;
                else cboWork.Visible = false;

                Sql.Length = 0;
                Sql.AppendLine(" Select * From Insp_process ");
                Sql.AppendLine(" Order by iprocess_cd ");
                rtnDtTable = helper.FillTable(Sql.ToString(), CommandType.Text);

                int dbRowCnt = 0;
                while (!(rtnDtTable.Rows.Count == dbRowCnt))
                {
                    var _with1 = cboiProcess_Cd.Items;
                    _with1.Add(rtnDtTable.Rows[dbRowCnt]["iprocess_cd"] + " " + rtnDtTable.Rows[dbRowCnt]["iprocess_name"]);
                    dbRowCnt = dbRowCnt + 1;
                }
                cboiProcess_Cd.SelectedIndex = 0;

                Sql.Length = 0;
                Sql.AppendLine(" Select * From mgr_code  ");
                Sql.AppendLine(" where  MGR_GROUP = 'PRODUCT_GB' and USE_GB in ('Y','M')");
                Sql.AppendLine(" Order by M_CODE ");

                //Ds = Conn.GetDataset(sConn, System.Data.Sql);

                dbRowCnt = 0;

                while (!(rtnDtTable.Rows.Count == dbRowCnt))
                {
                    var _with2 = cboSection.Items;
                    _with2.Add(rtnDtTable.Rows[dbRowCnt]["M_CODE"] + " " + rtnDtTable.Rows[dbRowCnt]["M_NAME"]);
                    dbRowCnt = dbRowCnt + 1;
                }
                cboSection.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                helper.Close();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {

                int dbRowCnt = 0;
                DataRow Dr = null;

                Sql.Length = 0;
                Sql.AppendLine(" SELECT A.PLANTCODE ,A.IPROCESS_CD, IPROCESS_NAME, IITEM_NO, IITEM_MEMO ");
                Sql.AppendLine(" FROM   INSP_PROCESS A, INSP_ITEM B");
                Sql.AppendLine(" WHERE  A.IPROCESS_CD = B.IPROCESS_CD");
                Sql.AppendLine("    AND A.PLANTCODE   = '" + sParam[0].ToString() + "'");
                Sql.AppendLine("    AND A.IPROCESS_CD = '" + cboiProcess_Cd.Text.ToString().Substring(0, 4) + "'");
                Sql.AppendLine("   and b.IVALID_DATE >= '" + String.Format(DateTime.Now.ToString("yyyyMMdd")) + "'");
                Sql.AppendLine(" ORDER BY IPRT_SEQ");
                rtnDtTable = helper.FillTable(Sql.ToString(), CommandType.Text);
                this.Spread1.DataSource = rtnDtTable;

                //이미 품목까지 넣었으면 같이 규격까지 조회해줌
                if (!string.IsNullOrEmpty(txtProduct_Cd.Text.Trim()))
                {
                    STD_VALUE_Click(null, null);
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
        private void STD_VALUE_Click(object sender, EventArgs e)
        {
            DataRow Dr = null;
            int iRow = 0;

            DBHelper helper = new DBHelper(false);
            try
            {
                Sql.Length = 0;
                Sql.AppendLine(" SELECT * FROM INSP_SPEC ");
                Sql.AppendLine(" WHERE IPROCESS_CD = '" + cboiProcess_Cd.Text.ToString().Substring(0, 4) + "'  AND  ");
                Sql.AppendLine("       PRODUCT_CD = '" + txtProduct_Cd.Text.Trim() + "'");
                Sql.AppendLine("    AND PLANTCODE   = '" + sParam[0].ToString() + "'");
                Sql.AppendLine("   and SVALID_DATE >= '" + String.Format(DateTime.Now.ToString("yyyyMMdd")) + "'");

                rtnDtTable = helper.FillTable(Sql.ToString(), CommandType.Text);

                if (rtnDtTable.Rows.Count == 0)
                {
                    string sMsg = "해당하는 제품이 없습니다" + Convert.ToChar(10) + "No data to query";
                    MessageBox.Show(sMsg);
                    return;
                }
                else
                {
                    this.Spread1.DataSource = rtnDtTable;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                helper.Close();
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                Sql.Length = 0;
                Sql.AppendLine(" SELECT  DISTINCT PLANTCODE, PRODUCT_CD, PRODUCT_NAME  FROM PRODUCT ");
                Sql.AppendLine(" WHERE PRODUCT_CD LIKE '" + tProduct_Cd.Text.Trim() + "%'");
                if (sParam[0].ToString() == "J")
                {
                    Sql.AppendLine(" and SECTION = '" + cboSection.Text.ToString().Substring(0, 2) + "'");
                }
                else
                {
                    Sql.AppendLine(" and PRODUCT_GB = '" + cboSection.Text.ToString().Substring(0, 2) + "'");
                }
                //주안은 제품 세부구분 조건추가
                if (sParam[0].ToString() == "A")
                {
                    if (cboWork.SelectedIndex > 0)
                    {
                        Sql.AppendLine(" and WORK_VOLUME = " + cboWork.Text.ToString().Substring(0, 1));
                    }
                }
                if (!string.IsNullOrEmpty(tProduct_Name.Text.Trim()))
                {
                    Sql.AppendLine(" and PRODUCT_NAME LIKE '" + tProduct_Name.Text.Trim() + "%' ");
                }
                Sql.AppendLine(" ORDER BY PRODUCT_CD ");
                rtnDtTable = helper.FillTable(Sql.ToString(), CommandType.Text);
                this.Spread2.DataSource = rtnDtTable;

                if (rtnDtTable.Rows.Count == 0)
                {
                    string sMsg = "검색된 품목이 없어 복사기능이 작동하지 않습니다.";
                    MessageBox.Show(sMsg);
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

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            int iRow = 0;
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

            try
            {
                for (iRow = 0; iRow < this.Spread1.Rows.Count; iRow++)
                {
                    if (Convert.ToBoolean(this.Spread1.Rows[iRow].Cells["8"].Value) == true)
                    {
                        INSERT_INSP_SPEC(this.Spread1.Rows[iRow].Cells[1].Value.ToString().Trim(),
                                         Convert.ToInt32(this.Spread1.Rows[iRow].Cells[3].Value.ToString().Trim()),
                                         this.Spread1.Rows[iRow].Cells[5].Value.ToString().Trim(),
                                         CDouble(this.Spread1.Rows[iRow].Cells[6].Value),
                                         CDouble(this.Spread1.Rows[iRow].Cells[7].Value));
                    }
                }
            }
            catch (Exception ex)
            {
            }
            MessageBox.Show("입력 하였습니다" + Convert.ToChar(10) + "Data is Enrolled");
        }
        // grid1 , 0 :"PLANTCODE",          grid2 , 0 :"PlantCode", 
        // grid1 , 1 :"IPROCESS_CD",        grid2 , 1 :"ITEM_CD", 
        // grid1 , 2 :"IPROCESS_NAME",      grid2 , 2 :"ITEM_NAME",
        // grid1 , 3 :"IITEM_NO",           grid2 , 3 :"Check", 
        // grid1 , 4 :"IITEM_MEMO",    
        // grid1 , 5 :"INSP_SPEC",     
        // grid1 , 6 :"Min",           
        // grid1 , 7 :"Max",           
        // grid1 , 8 :"Check",         

        private void INSERT_INSP_SPEC(string IPROCESS_CD, int IITEM_NO, string ISPEC_MEMO, double IMIN, double IMAX)
        {
            int irow = 0;
            DBHelper helper = new DBHelper(false);
            try
            {
                DataSet Ts = new DataSet();
                Sql.Append("select PRODUCT_CD from INSP_SPEC");
                Sql.AppendLine(" WHERE IPROCESS_CD = '" + IPROCESS_CD.Trim() + "'");
                Sql.AppendLine("   and IITEM_NO = " + IITEM_NO);
                rtnDtTable = helper.FillTable(Sql.ToString(), CommandType.Text);

                string xProductCD = null;
                //var _with1 = Spread2.ActiveSheet;
                for (irow = 0; irow <= this.Spread2.Rows.Count; irow++)
                {
                    if (Convert.ToBoolean(this.Spread2.Rows[irow].Cells[3].Value) == true)
                    {
                        StringBuilder aSql = new StringBuilder();

                        xProductCD = this.Spread2.Rows[irow].Cells[1].Value.ToString().Trim();
                        if (Ts.Tables[0].Select("PRODUCT_CD = '" + xProductCD + "'").Length > 0)
                        {
                            aSql.AppendLine("UPDATE INSP_SPEC");
                            aSql.AppendLine(" SET ISPEC_MEMO = '" + ISPEC_MEMO.Trim() + "'");
                            aSql.AppendLine("   , IMIN = " + IMIN);
                            aSql.AppendLine("   , IMAX = " + IMAX);
                            aSql.AppendLine("   , SVALID_DATE = '29991231'");
                            aSql.AppendLine(" WHERE PRODUCT_CD = '" + xProductCD + "'");
                            aSql.AppendLine("   AND IPROCESS_CD = '" + IPROCESS_CD + "'");
                            aSql.AppendLine("   AND IITEM_NO = " + IITEM_NO);
                        }
                        else
                        {
                            aSql.AppendLine(" INSERT INTO INSP_SPEC ");
                            aSql.AppendLine("        ( PRODUCT_CD, IPROCESS_CD, IITEM_NO, ISPEC_MEMO, ");
                            aSql.AppendLine("          IMIN, IMAX, SVALID_DATE )");
                            aSql.AppendLine(" VALUES ( '" + xProductCD + "', ");
                            aSql.AppendLine("          '" + IPROCESS_CD.Trim() + "',");
                            aSql.AppendLine("           " + IITEM_NO + ", ");
                            aSql.AppendLine("          '" + ISPEC_MEMO.Trim() + "',");
                            aSql.AppendLine("           " + IMIN + ",");
                            aSql.AppendLine("           " + IMAX + ",");
                            aSql.AppendLine("          '29991231')");
                        }
                        helper.ExecuteNoneIFSP(aSql.ToString(), CommandType.Text);
                    }
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
        private void cboSection_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            //주안만 제품 세부구분 해달라고 해서 추가
            if (sParam[0].ToString() == "A")
            {
                Sql.Length = 0;
                Sql.AppendLine("Select substr(m_code,2,1) m_code, m_name ");
                Sql.AppendLine("  From mgr_code ");
                Sql.AppendLine(" Where mgr_group = 'WORK_VOLUME'");
                switch (cboSection.Text.ToString().Substring(0, 2))
                {
                    case "02":
                        Sql.AppendLine(" and m_code like 'C%' ");
                        //-- 코일
                        break;
                    case "06":
                        Sql.AppendLine(" and m_code like 'S%' ");
                        //-- STB
                        break;
                    case "10":
                        Sql.AppendLine(" and m_code like 'H%' ");
                        //-- 선형
                        break;
                }
                // Sql &= "   and m_code like '" & IIf(Mid(cboSection.SelectedItem, 1, 2) = "02", "C", "S") & "%' "
                Sql.AppendLine("   and use_gb = 'Y'");
                Sql.AppendLine(" Order by m_code");

                rtnDtTable = helper.FillTable(Sql.ToString(), CommandType.Text);
                if (rtnDtTable.Rows.Count > 0)
                {
                    var _with1 = cboWork;
                    _with1.Items.Clear();
                    _with1.Items.Add("전체"); // (Msg_Lang("전체", "ALL", "@-AALL"));
                    int dbRowCnt = 0;
                    while (!(dbRowCnt == rtnDtTable.Rows.Count))
                    {
                        _with1.Items.Add(rtnDtTable.Rows[dbRowCnt]["m_code"] + " " + rtnDtTable.Rows[dbRowCnt]["m_name"]);

                        dbRowCnt += 1;
                    }
                    _with1.SelectedIndex = 0;
                }
            }

        }
        public double CDouble(object Tmp)
        {
            if (DBNull.Value.Equals(Tmp))
            {
                Tmp = 0;
            }
            return Convert.ToDouble(Tmp.ToString().Replace(",", ""));
        }
    }
}

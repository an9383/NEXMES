using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class POP_TBM9100_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public POP_TBM9100_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void POP_TBM9100_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 150, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITTYPE", "장비유형ⓒ", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TERMINALID", "장비ID", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TERMINALNM", "장비명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IPADDRESS", "장비IP", true, GridColDataType_emu.IPv4Address, 140, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRINTER", "프린터유무", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["TERMINALID"].Header.Appearance.ForeColor = Color.SkyBlue;

            #endregion

            #region [ Combo Box ]
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            ////사용여부
            //rtnDtTemp = _Common.GET_TBM0000_CODE("UseFlag");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("ItemType"); //품목구분
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("INSPTYPE"); //검사구분
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "INSPFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("OPHEADER"); //품목대분류
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MAJORITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("WHCODE"); //창고코드
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion
        }
        #endregion


        #region [ Uesr Method Area ]
        /// <summary>
        /// 엑셀 파일 가져오기
        /// </summary>
        /// <param name="sFilePath"></param>
        /// <returns></returns>
        private DataTable GetExcel(string sFilePath)
        {
            string oledbConnStr = string.Empty;

            if (sFilePath.IndexOf(".xlsx") > -1)
            {
                // 엑셀 2007 이상
                oledbConnStr = "Provider=Microsoft.JET.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties='Excel 12.0';HDR=NO;IMEX=1'";

                //oledbConnStr = "Provider=Microsoft.JET.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties=\"Excel 12.0\"";
            }
            else
            {
                // 엑셀 2003 및 이하 버전
                //oledbConnStr = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties=\"Excel 8.0\"";

                //oledbConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=No'"; 기존 사용
                oledbConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
            }

            DataTable dtExcel = null;
            OleDbDataAdapter adt = null;

            using (OleDbConnection con = new OleDbConnection(oledbConnStr))
            {
                con.Open();

                DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string sheetName = dt.Rows[0]["TABLE_NAME"].ToString();             //엑셀 첫 번째 시트명
                string sQuery = string.Format(" SELECT * FROM [{0}] ", sheetName);  //조회 쿼리

                dtExcel = new DataTable();
                adt = new OleDbDataAdapter(sQuery, con);
                adt.Fill(dtExcel);
            }

            return dtExcel;
        }

        /// <summary>
        /// 엑셀업로드
        /// </summary>
        private void INSERT_SAVE()
        {
            DBHelper helper = new DBHelper(false);
            DBHelper helper_Excel = new DBHelper(false);

            if (grid1.Rows.Count == 0)
            {
                MessageBox.Show("업로드할 내용이 없습니다. 확인하세요.");
                return;
            }

            string PLANTCODE = string.Empty;
            string ITTYPE = string.Empty;
            string TERMINALID = string.Empty;
            string TERMINALNM = string.Empty;
            string IPADDRESS = string.Empty;
            string PRINTER = string.Empty;
            string USEFLAG = string.Empty;

            string excelUploadType = string.Empty;

            int iOK = 0;
            int iNG = 0;

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    PLANTCODE = Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value);
                    ITTYPE = Convert.ToString(grid1.Rows[i].Cells["ITTYPE"].Value);
                    TERMINALID = Convert.ToString(grid1.Rows[i].Cells["TERMINALID"].Value);
                    TERMINALNM = Convert.ToString(grid1.Rows[i].Cells["TERMINALNM"].Value);
                    IPADDRESS = Convert.ToString(grid1.Rows[i].Cells["IPADDRESS"].Value);
                    PRINTER = Convert.ToString(grid1.Rows[i].Cells["PRINTER"].Value);
                    USEFLAG = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);


                    if (PLANTCODE == string.Empty)// || plantcode.Length != 2) // || getvalues("PLANTCODE",plantcode) == false)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.");
                        return;
                    }
                    if (ITTYPE == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 장비유형를 확인하세요.");
                        return;
                    }
                    if (TERMINALID == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 장비ID를 확인하세요.");
                        return;
                    }

                    //if (ITEMTYPE == string.Empty || getvalues("ITEMTYPE", ITEMTYPE) == false)
                    //{
                    //    MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 품목구분을 확인하세요.");
                    //    return;
                    //} 
                    //if (ITEMTYPE == "ROH" && UNITWGT == string.Empty)
                    //{
                    //    MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 단위 중량을 확인하세요.");
                    //    return;
                    //}
                    //if (getvalues("INSPTYPE", Convert.ToString(grid1.Rows[i].Cells["INSPFLAG"].Value)) == false)
                    //{
                    //    MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 검사 구분을 확인하세요.");
                    //    return;
                    //}
                    //if (getvalues("WHCODE", Convert.ToString(grid1.Rows[i].Cells["WHCODE"].Value)) == false)
                    //{
                    //    MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 창고를 확인하세요.");
                    //    return;
                    //}
                    //if (getvalues("UseFlag", Convert.ToString(grid1.Rows[i].Cells["UseFlag"].Value)) == false)
                    //{
                    //    MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 사용 여부를 확인하세요.");
                    //    return;
                    //} 
                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "TBM9100", DbType.String, ParameterDirection.Input));

                if (helper_Excel.RSCODE == "S")
                {
                    if (excelUpType.Rows.Count > 0)
                    {
                        excelUploadType = Convert.ToString(excelUpType.Rows[0]["UPLOADTYPE"]);
                    }
                }

                if (excelUploadType == "R")
                {
                    DataTable DtGrid1 = (DataTable)grid1.DataSource;

                    //Row별 Commit
                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        helper.ExecuteNoneQuery("USP_POP_BM9100_I1"
                                          , CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITTYPE", Convert.ToString(grid1.Rows[i].Cells["ITTYPE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_TERMINALID", Convert.ToString(grid1.Rows[i].Cells["TERMINALID"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_TERMINALNM", Convert.ToString(grid1.Rows[i].Cells["TERMINALNM"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_IPADDRESS", Convert.ToString(grid1.Rows[i].Cells["IPADDRESS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PRINTER", Convert.ToString(grid1.Rows[i].Cells["PRINTER"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_USEFLAG", Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "S")
                        {
                            helper.Commit();
                            iOK++;
                        }
                        else
                        {
                            helper.Rollback();
                            iNG++;
                            grid1.SetRowError(DtGrid1.Rows[i], helper.RSMSG, helper.RSCODE);
                        }
                    }

                    MessageBox.Show("엑셀업로드 총 " + grid1.Rows.Count + "건 중 " + iOK.ToString() + "성공, " + iNG.ToString() + "실패하였습니다.");

                }
                else
                {
                    int iRow = 0;
                    DataTable DtGrid1 = (DataTable)grid1.DataSource;

                    //전체 Commit
                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        helper.ExecuteNoneQuery("USP_POP_BM9100_I1"
                                          , CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITTYPE", Convert.ToString(grid1.Rows[i].Cells["ITTYPE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_TERMINALID", Convert.ToString(grid1.Rows[i].Cells["TERMINALID"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_TERMINALNM", Convert.ToString(grid1.Rows[i].Cells["TERMINALNM"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_IPADDRESS", Convert.ToString(grid1.Rows[i].Cells["IPADDRESS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PRINTER", Convert.ToString(grid1.Rows[i].Cells["PRINTER"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_USEFLAG", Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "E")
                        {
                            grid1.SetRowError(DtGrid1.Rows[i], helper.RSMSG, helper.RSCODE);
                            iRow = i;
                            break;
                        }
                        iRow = i;
                    }

                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();
                        _GridUtil.Grid_Clear(grid1);
                        MessageBox.Show((iRow + 1).ToString() + "건이 정상적으로 등록되었습니다.");
                    }
                    else
                    {
                        helper.Rollback();
                        MessageBox.Show((iRow + 1).ToString() + "번째 줄에서 오류가 발생하였습니다." + Environment.NewLine + helper.RSMSG);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                helper.Rollback();
            }
            finally
            {
                helper_Excel.Close();
                helper.Close();
            }
        }
        #endregion

        #region [ Event Area ]
        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = "EXCEL|*.xls|ALL|*.*";

                if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //엑셀 파일 READ
                    DataTable dtExcelImport = GetExcel(openfiledialog.FileName);

                    //대상 GRID DataTable 복사(구조o, 데이터x)
                    DataTable dtTarget = ((DataTable)this.grid1.DataSource).Clone();

                    //엑셀파일에서 READ 된 DataTable로 등록할 데이터 DataTable에 저장
                    for (int i = 1; i < dtExcelImport.Rows.Count; i++)
                    {
                        DataRow drTarget = dtTarget.NewRow();
                        drTarget["PLANTCODE"] = Convert.ToString(dtExcelImport.Rows[i][0]);
                        drTarget["ITTYPE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["TERMINALID"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["TERMINALNM"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["IPADDRESS"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["PRINTER"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["USEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][6]);

                        dtTarget.Rows.Add(drTarget);
                    }

                    this.grid1.DataSource = dtTarget;
                    this.grid1.DataBind();

                    _DtChange1 = (DataTable)this.grid1.DataSource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("엑셀수작업 등록 양식이 잘못되었습니다." + Environment.NewLine +
                                "양식다운을 하신 뒤에 작업을 진행하십시오." + Environment.NewLine +
                                "오류내용: " + ex.Message);
            }
        }

        private void btnFileDown_Click(object sender, EventArgs e)
        {
            _GridUtil.ExportExcel(this.grid1);
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcelUpload_Click(object sender, EventArgs e)
        {
            INSERT_SAVE();
        }

    }
}

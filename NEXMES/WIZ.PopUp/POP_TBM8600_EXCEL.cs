using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class POP_TBM8600_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public POP_TBM8600_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void POP_TBM8600_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 170, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "위치ⓒ", false, GridColDataType_emu.VarChar, 90, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PASSAGE", "통로", false, GridColDataType_emu.VarChar, 50, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "L_R", "L/R", false, GridColDataType_emu.VarChar, 50, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "COL", "열", false, GridColDataType_emu.VarChar, 50, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAN", "단", false, GridColDataType_emu.VarChar, 50, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SEQ", "순번", false, GridColDataType_emu.VarChar, 50, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PALLETNO", "Pallet No", true, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BOOKING", "위치예약유무", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용유무", false, GridColDataType_emu.VarChar, 100, true, true);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["STORAGELOCCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["PASSAGE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["L_R"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["COL"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["DAN"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["SEQ"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["USEFLAG"].Header.Appearance.ForeColor = Color.SkyBlue;

            #endregion

            #region [ Combo Box ]
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
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
            string STORAGELOCCODE = string.Empty;
            string PASSAGE = string.Empty;
            string L_R = string.Empty;
            string COL = string.Empty;
            string DAN = string.Empty;
            string SEQ = string.Empty;
            string BOOKING = string.Empty;
            string USEFLAG = string.Empty;

            string excelUploadType = string.Empty;

            int iOK = 0;
            int iNG = 0;

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    PLANTCODE = Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value);
                    STORAGELOCCODE = Convert.ToString(grid1.Rows[i].Cells["STORAGELOCCODE"].Value);
                    PASSAGE = Convert.ToString(grid1.Rows[i].Cells["PASSAGE"].Value);
                    L_R = Convert.ToString(grid1.Rows[i].Cells["L_R"].Value);
                    COL = Convert.ToString(grid1.Rows[i].Cells["COL"].Value);
                    DAN = Convert.ToString(grid1.Rows[i].Cells["DAN"].Value);
                    SEQ = Convert.ToString(grid1.Rows[i].Cells["SEQ"].Value);
                    BOOKING = Convert.ToString(grid1.Rows[i].Cells["BOOKING"].Value);
                    USEFLAG = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);


                    if (PLANTCODE == string.Empty)// || plantcode.Length != 2) // || getvalues("PLANTCODE",plantcode) == false)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.");
                        return;
                    }
                    if (STORAGELOCCODE == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 위치를 확인하세요.");
                        return;
                    }
                    if (PASSAGE == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 통로를 확인하세요.");
                        return;
                    }
                    if (L_R == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 L/R를 확인하세요.");
                        return;
                    }
                    if (COL == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 열을 확인하세요.");
                        return;
                    }
                    if (DAN == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 단을 확인하세요.");
                        return;
                    }
                    if (SEQ == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 순번을 확인하세요.");
                        return;
                    }
                    //if (BOOKING == string.Empty)
                    //{
                    //    MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 위치예약여부를 확인하세요.");
                    //    return;
                    //}
                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "TBM0900", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_POP_BM8600_I1"
                                          , CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STORAGELOCCODE", Convert.ToString(grid1.Rows[i].Cells["STORAGELOCCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PASSAGE", Convert.ToString(grid1.Rows[i].Cells["PASSAGE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_L_R", Convert.ToString(grid1.Rows[i].Cells["L_R"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_COL", Convert.ToString(grid1.Rows[i].Cells["COL"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_DAN", Convert.ToString(grid1.Rows[i].Cells["DAN"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_SEQ", Convert.ToString(grid1.Rows[i].Cells["SEQ"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PALLETNO", Convert.ToString(grid1.Rows[i].Cells["PALLETNO"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_BOOKING", Convert.ToString(grid1.Rows[i].Cells["PRINTER"].Value), DbType.String, ParameterDirection.Input)
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
                        helper.ExecuteNoneQuery("USP_POP_BM8600_I1"
                                        , CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STORAGELOCCODE", Convert.ToString(grid1.Rows[i].Cells["STORAGELOCCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PASSAGE", Convert.ToString(grid1.Rows[i].Cells["PASSAGE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_L_R", Convert.ToString(grid1.Rows[i].Cells["L_R"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_COL", Convert.ToString(grid1.Rows[i].Cells["COL"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_DAN", Convert.ToString(grid1.Rows[i].Cells["DAN"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_SEQ", Convert.ToString(grid1.Rows[i].Cells["SEQ"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PALLETNO", Convert.ToString(grid1.Rows[i].Cells["PALLETNO"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_BOOKING", Convert.ToString(grid1.Rows[i].Cells["BOOKING"].Value), DbType.String, ParameterDirection.Input)
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
                        drTarget["STORAGELOCCODE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["PASSAGE"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["L_R"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["COL"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["DAN"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["SEQ"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["PALLETNO"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["BOOKING"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["USEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][9]);

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

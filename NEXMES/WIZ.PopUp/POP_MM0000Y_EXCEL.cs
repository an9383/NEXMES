#region < USING AREA >
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.PopUp
{
    public partial class POP_MM0000Y_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region < CONSTRUCTOR >
        public POP_MM0000Y_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void POP_MM0000Y_EXCEL_Load(object sender, EventArgs e)
        {
            #region ▶ GRID
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 170, 130, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 170, 130, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "POQTY", "발주량", false, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Right, true, true, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PODATE", "발주일(YYYY-MM-DD)", false, GridColDataType_emu.YearMonthDay, 120, 15, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANINDATE", "입고예정일(YYYY-MM-DD)", false, GridColDataType_emu.YearMonthDay, 120, 15, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["POQTY"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["PODATE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["PLANINDATE"].Header.Appearance.ForeColor = Color.SkyBlue;

            #endregion

            #region ▶ COMBOBOX
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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

            if (sFilePath.IndexOf(".xlsx") > 0)
            {
                // 엑셀 2007 이상

                oledbConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=NO'";

            }
            else
            {
                // 엑셀 2003 및 이하 버전

                oledbConnStr = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";

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
            DBHelper helper = new DBHelper("", true);
            DBHelper helper_Excel = new DBHelper(false);

            if (grid1.Rows.Count == 0)
            {
                MessageBox.Show("업로드할 내용이 없습니다. 확인하세요.");
                return;
            }

            string plantcode = string.Empty;
            string custcode = string.Empty;
            string itemcode = string.Empty;
            string poorderqty = string.Empty;
            string poorderdate = string.Empty;
            string planindate = string.Empty;
            string excelUploadType = string.Empty;

            int iPoordertQty = 0;

            int iOK = 0;
            int iNG = 0;

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    plantcode = Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value);
                    custcode = Convert.ToString(grid1.Rows[i].Cells["CUSTCODE"].Value);
                    itemcode = Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value);
                    poorderqty = Convert.ToString(grid1.Rows[i].Cells["POQTY"].Value);
                    poorderdate = Convert.ToString(grid1.Rows[i].Cells["PODATE"].Value);
                    planindate = Convert.ToString(grid1.Rows[i].Cells["PLANINDATE"].Value);


                    if (plantcode == string.Empty || plantcode.Length != 2)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 공장을 확인하세요.");
                        return;
                    }
                    if (custcode == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 거래처를 확인하세요.");
                        return;
                    }
                    if (itemcode == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 품목을 확인하세요.");
                        return;
                    }
                    if (Int32.TryParse(poorderqty, out iPoordertQty) == false)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 발주수량을 확인하세요.");
                        return;
                    }
                    //if (poorderdate == string.Empty)
                    //{
                    //    MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 발주일자를 확인하세요.");
                    //    return;
                    //}
                    //if (planindate == string.Empty)
                    //{
                    //    MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 입고예정일자를 확인하세요.");
                    //    return;
                    //}
                }

                poorderdate = poorderdate.Substring(0, 10);
                planindate = planindate.Substring(0, 10);

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "MM0000", DbType.String, ParameterDirection.Input));

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
                    for (int i = 0; i < DtGrid1.Rows.Count; i++)
                    {
                        helper.ExecuteNoneQuery("USP_POP_MM0000_I1", CommandType.StoredProcedure
                                               , helper.CreateParameter("PLANTCODE", Convert.ToString(DtGrid1.Rows[i]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("CUSTCODE", Convert.ToString(DtGrid1.Rows[i]["CUSTCODE"]), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("ITEMCODE", Convert.ToString(DtGrid1.Rows[i]["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("POORDERQTY", Convert.ToString(DtGrid1.Rows[i]["POQTY"]), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("POORDERDATE", Convert.ToString(DtGrid1.Rows[i]["PODATE"]), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("PLANINDATE", Convert.ToString(DtGrid1.Rows[i]["PLANINDATE"]), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

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
                    for (int i = 0; i < DtGrid1.Rows.Count; i++)
                    {
                        helper.ExecuteNoneQuery("USP_POP_MM0000_I1"
                                                , CommandType.StoredProcedure
                                                , helper.CreateParameter("PLANTCODE", Convert.ToString(DtGrid1.Rows[i]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("CUSTCODE", Convert.ToString(DtGrid1.Rows[i]["CUSTCODE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("ITEMCODE", Convert.ToString(DtGrid1.Rows[i]["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("POORDERQTY", Convert.ToString(DtGrid1.Rows[i]["POQTY"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("POORDERDATE", Convert.ToString(DtGrid1.Rows[i]["PODATE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("PLANINDATE", Convert.ToString(DtGrid1.Rows[i]["PLANINDATE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                        if (helper.RSCODE == "E")
                        {
                            grid1.SetRowError(DtGrid1.Rows[i], helper.RSMSG, helper.RSCODE);
                            iRow = i;
                            break;
                        }

                        iRow++;
                    }

                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();
                        _GridUtil.Grid_Clear(grid1);
                        MessageBox.Show((iRow).ToString() + "건이 정상적으로 등록되었습니다.");
                    }
                    else
                    {
                        helper.Rollback();
                        MessageBox.Show((iRow).ToString() + "번째 줄에서 오류가 발생하였습니다." + Environment.NewLine + helper.RSMSG);
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
                txtFile.Text = string.Empty;
            }
        }
        #endregion

        #region [ Event Area ]
        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = "EXCEL 97 - 2003 통합문서|*.xls|EXCEL 통합문서|*.xlsx|ALL|*.*";

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
                        drTarget["CUSTCODE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["ITEMCODE"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["POQTY"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["PODATE"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["PLANINDATE"] = Convert.ToString(dtExcelImport.Rows[i][5]);

                        dtTarget.Rows.Add(drTarget);
                    }

                    this.grid1.DataSource = dtTarget;
                    this.grid1.DataBind();

                    txtFile.Text = openfiledialog.FileName;

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcelUpload_Click(object sender, EventArgs e)
        {
            INSERT_SAVE();
        }
    }
}

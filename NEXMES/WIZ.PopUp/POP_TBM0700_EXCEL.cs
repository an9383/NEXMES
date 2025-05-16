using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class POP_TBM0700_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public POP_TBM0700_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void POP_TBM0700_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 170, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비코드", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHTYPE", "설비구분", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKECOMPANY", "제조사", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MODELNAME", "모델명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SERIALNO", "제조시리얼번호", false, GridColDataType_emu.VarChar, 220, 220, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용유무(Y/N)", false, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["MACHTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;

            #endregion

            #region [ Combo Box ]
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("MachType");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MachType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            ////사용여부
            //rtnDtTemp = _Common.GET_TBM0000_CODE("UseFlag");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //GetWorkCenterCode();
            //#endregion

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
            DBHelper helper = new DBHelper("", true);
            DBHelper helper_Excel = new DBHelper(false);

            if (grid1.Rows.Count == 0)
            {
                MessageBox.Show("업로드할 내용이 없습니다. 확인하세요.");
                return;
            }

            string plantcode = string.Empty;
            string MACHCODE = string.Empty;
            string MACHNAME = string.Empty;
            string machtype = string.Empty;
            string MAKECOMPANY = string.Empty;
            string MODELNAME = string.Empty;
            string SERIALNO = string.Empty;
            string USEFLAG = string.Empty;

            string excelUploadType = string.Empty;

            int iOK = 0;
            int iNG = 0;

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    plantcode = Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value);
                    MACHCODE = Convert.ToString(grid1.Rows[i].Cells["MACHCODE"].Value);
                    MACHNAME = Convert.ToString(grid1.Rows[i].Cells["MACHNAME"].Value);
                    machtype = Convert.ToString(grid1.Rows[i].Cells["MACHTYPE"].Value);
                    MAKECOMPANY = Convert.ToString(grid1.Rows[i].Cells["MAKECOMPANY"].Value);
                    MODELNAME = Convert.ToString(grid1.Rows[i].Cells["MODELNAME"].Value);
                    SERIALNO = Convert.ToString(grid1.Rows[i].Cells["SERIALNO"].Value);
                    USEFLAG = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);

                    if (plantcode == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 공장을 확인하세요.");
                        return;
                    }
                    if (machtype == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 설비유형를 확인하세요.");
                        return;
                    }
                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "TBM0700", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_POP_BM0700_I1"
                                                , CommandType.StoredProcedure
                                                , helper.CreateParameter("PLANTCODE", Convert.ToString(DtGrid1.Rows[i]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("MACHCODE", Convert.ToString(DtGrid1.Rows[i]["MACHCODE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("MACHNAME", Convert.ToString(DtGrid1.Rows[i]["MACHNAME"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("MACHTYPE", Convert.ToString(DtGrid1.Rows[i]["MACHTYPE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("MAKECOMPANY", Convert.ToString(DtGrid1.Rows[i]["MAKECOMPANY"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("MODELNAME", Convert.ToString(DtGrid1.Rows[i]["MODELNAME"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("SERIALNO", Convert.ToString(DtGrid1.Rows[i]["SERIALNO"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("USEFLAG", Convert.ToString(DtGrid1.Rows[i]["USEFLAG"]), DbType.String, ParameterDirection.Input)
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
                        helper.ExecuteNoneQuery("USP_POP_BM0700_I1"
                                                , CommandType.StoredProcedure
                                                , helper.CreateParameter("PLANTCODE", Convert.ToString(DtGrid1.Rows[i]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("MACHCODE", Convert.ToString(DtGrid1.Rows[i]["MACHCODE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("MACHNAME", Convert.ToString(DtGrid1.Rows[i]["MACHNAME"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("MACHTYPE", Convert.ToString(DtGrid1.Rows[i]["MACHTYPE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("MAKECOMPANY", Convert.ToString(DtGrid1.Rows[i]["MAKECOMPANY"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("MODELNAME", Convert.ToString(DtGrid1.Rows[i]["MODELNAME"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("SERIALNO", Convert.ToString(DtGrid1.Rows[i]["SERIALNO"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("USEFLAG", Convert.ToString(DtGrid1.Rows[i]["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "E")
                        {
                            grid1.SetRowError(DtGrid1.Rows[i], helper.RSMSG, helper.RSCODE);
                            iRow = i;
                            break;
                        }
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
                        drTarget["MACHCODE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["MACHNAME"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["MACHTYPE"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["MAKECOMPANY"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["MODELNAME"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["SERIALNO"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["USEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][7]);

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
#endregion
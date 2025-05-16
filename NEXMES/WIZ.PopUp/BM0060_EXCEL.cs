using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class BM0060_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        Common _Common = new Common(); //콤보박스 객체 생성
        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public BM0060_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void BM0060_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 150, 130, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정코드", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인코드", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "DISPLAYNO", "표시순번", true, GridColDataType_emu.VarChar, 90, 130, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "SUBCODE", "대표코드", true, GridColDataType_emu.VarChar, 90, 130, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PRINTERNAME", "출력프린터", true, GridColDataType_emu.VarChar, 250, 130, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PRINT_IP", "프린터 IP", true, GridColDataType_emu.VarChar, 250, 130, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "DASFORM", "DAS수동실적", true, GridColDataType_emu.VarChar, 110, 130, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDFLAG", "금형사용여부", true, GridColDataType_emu.VarChar, 110, 130, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WBTFLAG", "단말기노출사용여부", true, GridColDataType_emu.VarChar, 110, 130, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "DETFLAG", "세부공정사용여부", true, GridColDataType_emu.VarChar, 110, 130, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 130, Infragistics.Win.HAlign.Left, true, true);

            _GridUtil.SetInitUltraGridBind(grid1);

            //필수입력 항목에 대한 음영
            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["OPCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["OPNAME"].Header.Appearance.ForeColor = Color.SkyBlue;

            #endregion

            #region COMBOBOX SETTING

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MOLDFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WBTFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DASFORM", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DETFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");


            //rtnDtTemp = _Common.GET_BM0000_CODE("PRINTFORM"); //출력양식
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PRINTFORM", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #region POPUP SETTING

            BizGridManager bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("LINECODE", "LINENAME", "BM0050", new string[] { "PLANTCODE", "", "Y" });
            bizGridManager.PopUpAdd("OPCODE", "OPNAME", "BM0040", new string[] { "PLANTCODE", "", "Y" });
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
            DBHelper helper = new DBHelper(false);
            DBHelper helper_Excel = new DBHelper(false);

            if (grid1.Rows.Count == 0)
            {
                MessageBox.Show(Common.getLangText("업로드할 내용이 없습니다. 확인하세요.", "MSG"));
                return;
            }

            string sPlantCode = string.Empty;
            string sOpCode = string.Empty;
            string sOpName = string.Empty;
            string sLineCode = string.Empty;
            string sLineName = string.Empty;
            string sWorkcenterName = string.Empty;
            string sDisplayNo = string.Empty;
            string sZbFlag = string.Empty;
            string sMoldFlag = string.Empty;
            string sWbtFlag = string.Empty;
            string sRemark = string.Empty;
            string sUseFlag = string.Empty;

            string excelUploadType = string.Empty;

            int iOK = 0;
            int iNG = 0;

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    sPlantCode = Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value);
                    sOpCode = Convert.ToString(grid1.Rows[i].Cells["OPCODE"].Value);
                    sOpName = Convert.ToString(grid1.Rows[i].Cells["OPNAME"].Value);
                    sLineCode = Convert.ToString(grid1.Rows[i].Cells["LINECODE"].Value);
                    sLineName = Convert.ToString(grid1.Rows[i].Cells["LINENAME"].Value);
                    sWorkcenterName = Convert.ToString(grid1.Rows[i].Cells["WORKCENTERNAME"].Value);
                    sDisplayNo = Convert.ToString(grid1.Rows[i].Cells["DISPLAYNO"].Value);
                    sMoldFlag = Convert.ToString(grid1.Rows[i].Cells["MOLDFLAG"].Value);
                    sWbtFlag = Convert.ToString(grid1.Rows[i].Cells["WBTFLAG"].Value);
                    sRemark = Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value);
                    sUseFlag = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);

                    if (sPlantCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.", "MSG"));
                        return;
                    }
                    if (sOpCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 공정코드를 확인하세요.", "MSG"));
                        return;
                    }
                    if (sLineCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 라인코드를 확인하세요.", "MSG"));
                        return;
                    }

                }
                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "BM0060", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_BM0060_EXCEL_I1", CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_OPCODE", Convert.ToString(grid1.Rows[i].Cells["OPCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_OPNAME", Convert.ToString(grid1.Rows[i].Cells["OPNAME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_LINECODE", Convert.ToString(grid1.Rows[i].Cells["LINECODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_LINENAME", Convert.ToString(grid1.Rows[i].Cells["LINENAME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WORKCENTERNAME", Convert.ToString(grid1.Rows[i].Cells["WORKCENTERNAME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AI_DISPLAYNO", Convert.ToString(grid1.Rows[i].Cells["DISPLAYNO"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PRINTNAME", Convert.ToString(grid1.Rows[i].Cells["PRINTERNAME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PRINT_IP", Convert.ToString(grid1.Rows[i].Cells["PRINT_IP"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_DASFORM", Convert.ToString(grid1.Rows[i].Cells["DASFORM"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_SUBCODE", Convert.ToString(grid1.Rows[i].Cells["SUBCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_MOLDFLAG", Convert.ToString(grid1.Rows[i].Cells["MOLDFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WBTFLAG", Convert.ToString(grid1.Rows[i].Cells["WBTFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_DETFLAG", Convert.ToString(grid1.Rows[i].Cells["DETFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_REMARK", Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_USEFLAG", Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

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
                    MessageBox.Show(Common.getLangText("엑셀업로드 총 " + grid1.Rows.Count + "건 중 " + iOK.ToString() + "성공, " + iNG.ToString() + "실패하였습니다.", "MSG"));

                }
                else
                {
                    int iRow = 0;
                    DataTable DtGrid1 = (DataTable)grid1.DataSource;

                    //전체 Commit
                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        helper.ExecuteNoneQuery("USP_BM0060_EXCEL_I1", CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_OPCODE", Convert.ToString(grid1.Rows[i].Cells["OPCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_OPNAME", Convert.ToString(grid1.Rows[i].Cells["OPNAME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_LINECODE", Convert.ToString(grid1.Rows[i].Cells["LINECODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_LINENAME", Convert.ToString(grid1.Rows[i].Cells["LINENAME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WORKCENTERNAME", Convert.ToString(grid1.Rows[i].Cells["WORKCENTERNAME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AI_DISPLAYNO", Convert.ToString(grid1.Rows[i].Cells["DISPLAYNO"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PRINTNAME", Convert.ToString(grid1.Rows[i].Cells["PRINTERNAME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PRINT_IP", Convert.ToString(grid1.Rows[i].Cells["PRINT_IP"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_DASFORM", Convert.ToString(grid1.Rows[i].Cells["DASFORM"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_SUBCODE", Convert.ToString(grid1.Rows[i].Cells["SUBCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_MOLDFLAG", Convert.ToString(grid1.Rows[i].Cells["MOLDFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WBTFLAG", Convert.ToString(grid1.Rows[i].Cells["WBTFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_DETFLAG", Convert.ToString(grid1.Rows[i].Cells["DETFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_REMARK", Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_USEFLAG", Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

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
                        MessageBox.Show(Common.getLangText((iRow + 1).ToString() + "건이 정상적으로 등록되었습니다.", "MSG"));
                    }
                    else
                    {
                        helper.Rollback();
                        MessageBox.Show(Common.getLangText((iRow + 1).ToString() + "번째 줄에서 오류가 발생하였습니다." + Environment.NewLine + helper.RSMSG, "MSG"));
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
                openfiledialog.Filter = "EXCEL 파일|*.xl*";

                if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //엑셀 파일 READ
                    DataTable dtExcelImport = GetExcel(openfiledialog.FileName);

                    //대상 GRID DataTable 복사(구조o, 데이터x)
                    DataTable dtTarget = ((DataTable)this.grid1.DataSource).Clone();

                    //엑셀파일에서 READ 된 DataTable로 등록할 데이터 DataTable에 저장
                    for (int i = 2; i < dtExcelImport.Rows.Count; i++)
                    {
                        DataRow drTarget = dtTarget.NewRow();

                        drTarget["PLANTCODE"] = Convert.ToString(dtExcelImport.Rows[i][0]);
                        drTarget["WORKCENTERNAME"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["OPCODE"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["OPNAME"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["LINECODE"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["LINENAME"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["DISPLAYNO"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["SUBCODE"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["PRINTERNAME"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["PRINT_IP"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        drTarget["DASFORM"] = Convert.ToString(dtExcelImport.Rows[i][10]);
                        drTarget["MOLDFLAG"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                        drTarget["WBTFLAG"] = Convert.ToString(dtExcelImport.Rows[i][12]);
                        drTarget["DETFLAG"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        drTarget["USEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][14]).Trim();
                        drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][15]);

                        if (DBHelper.nvlString(drTarget["USEFLAG"]) == "")
                        {
                            drTarget["USEFLAG"] = "Y";
                        }

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
                MessageBox.Show(Common.getLangText("엑셀수작업 등록 양식이 잘못되었습니다." + Environment.NewLine +
                                "양식다운을 하신 뒤에 작업을 진행하십시오." + Environment.NewLine +
                                "오류내용: " + ex.Message, "MSG"));
            }
        }
        #endregion


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

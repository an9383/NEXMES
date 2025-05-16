using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIZ.Control;

namespace WIZ.PopUp
{
    public partial class AP0129_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public AP0129_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void AP0129_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "SAVEBUTTON", "삭제", true, GridColDataType_emu.Button, 50, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SHIPNO", "출하번호", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTQTY", "수주수량", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
            _GridUtil.InitColumnUltraGrid(grid1, "DUEDATE", "출하지시일자", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PACKQTY", "출하수량", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
            _GridUtil.InitColumnUltraGrid(grid1, "CURNM", "통화단위", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RATE", "환율", false, GridColDataType_emu.Float, 80, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "COST", "매출단가", false, GridColDataType_emu.Float, 80, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTALCOST", "매출금액(외화)", false, GridColDataType_emu.Double, 110, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTALCOST2", "매출금액(원화)", false, GridColDataType_emu.Double, 110, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "VAT", "부가세", false, GridColDataType_emu.Float, 80, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MONEYDUEDATE", "회수예정일", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INCOMEDATE", "회수일", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PONO", "구매번호", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "BLNO", "BL번호", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CERTI", "신고필증", false, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PHOTO", "포토", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PHOTO2", "포토(원화)", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MASK", "마스크", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MASK2", "마스크(원화)", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "FRAME", "프레임", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "FRAME2", "프레임(원화)", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "COATING", "코팅", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "COATING2", "코팅(원화)", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CLEANSING", "세정", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CLEANSING2", "세정(원화)", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ETC", "기타", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ETC2", "기타(원화)", false, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["COST"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["PONO"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["BLNO"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["CERTI"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["PHOTO"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["MASK"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["FRAME"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["COATING"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["CLEANSING"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ETC"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["DUEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["MONEYDUEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["INCOMEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;


            #endregion

            #region [ Combo Box ]
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE"); //품목유형
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0130_CODE("Y"); //단위               
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("INSPTYPE"); //수입검사여부               
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "INSPFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");


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
            DBHelper helper = new DBHelper(false);
            DBHelper helper_Excel = new DBHelper(false);

            if (grid1.Rows.Count == 0)
            {
                MessageBox.Show(Common.getLangText("업로드할 내용이 없습니다. 확인하세요.", "MSG"));
                return;
            }

            string sSavebutton = string.Empty;
            string sContractNo = string.Empty;
            string sShipNo = string.Empty;
            string sItemCode = string.Empty;
            string sCurCode = string.Empty;
            string sDueDate = string.Empty;
            string sBlno = string.Empty;
            string sCerti = string.Empty;
            string sRate = string.Empty;
            string sPackQty = string.Empty;
            string sCost = string.Empty;
            string sPoNo = string.Empty;
            string sPhoto = string.Empty;
            string sMask = string.Empty;
            string sFrame = string.Empty;
            string sCoating = string.Empty;
            string sCleansing = string.Empty;
            string sEtc = string.Empty;
            string sMoneyDueDate = string.Empty;
            string sIncomeDate = string.Empty;

            string excelUploadType = string.Empty;

            int iOK = 0;
            int iNG = 0;

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    sSavebutton = Convert.ToString(grid1.Rows[i].Cells["SAVEBUTTON"].Value);
                    sContractNo = Convert.ToString(grid1.Rows[i].Cells["CONTRACTNO"].Value);
                    sItemCode = Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value);
                    sCurCode = Convert.ToString(grid1.Rows[i].Cells["CURNM"].Value);
                    sDueDate = Convert.ToString(grid1.Rows[i].Cells["DUEDATE"].Value);
                    sBlno = Convert.ToString(grid1.Rows[i].Cells["BLNO"].Value);
                    sPackQty = Convert.ToString(grid1.Rows[i].Cells["PACKQTY"].Value);
                    sShipNo = Convert.ToString(grid1.Rows[i].Cells["SHIPNO"].Value);
                    sCost = Convert.ToString(grid1.Rows[i].Cells["COST"].Value);
                    sPoNo = Convert.ToString(grid1.Rows[i].Cells["PONO"].Value);
                    sCerti = Convert.ToString(grid1.Rows[i].Cells["CERTI"].Value);
                    sPhoto = Convert.ToString(grid1.Rows[i].Cells["PHOTO"].Value);
                    sMask = Convert.ToString(grid1.Rows[i].Cells["MASK"].Value);
                    sFrame = Convert.ToString(grid1.Rows[i].Cells["FRAME"].Value);
                    sCoating = Convert.ToString(grid1.Rows[i].Cells["COATING"].Value);
                    sCleansing = Convert.ToString(grid1.Rows[i].Cells["CLEANSING"].Value);
                    sEtc = Convert.ToString(grid1.Rows[i].Cells["ETC"].Value);
                    sMoneyDueDate = Convert.ToString(grid1.Rows[i].Cells["MONEYDUEDATE"].Value);
                    sIncomeDate = Convert.ToString(grid1.Rows[i].Cells["INCOMEDATE"].Value);


                    //if (sPlantCode == string.Empty)
                    //{
                    //    MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.", "MSG"));
                    //    return;
                    //}
                    if (sItemCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 품목을 확인하세요.", "MSG"));
                        return;
                    }
                    //if (sItemName == string.Empty)
                    //{
                    //    MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 품명을 확인하세요.", "MSG"));
                    //    return;
                    //}
                    //if (sItemType == string.Empty)
                    //{
                    //    MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 품목구분을 확인하세요.", "MSG"));
                    //    return;
                    //}

                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "AP0129", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_SA0000_EXCEL_I2", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", "10", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CONTRACTNO", sContractNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHIPNO", sShipNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_DUEDATE", sDueDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CURNM", sCurCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PACKQTY", sPackQty, DbType.Decimal, ParameterDirection.Input)
                            , helper.CreateParameter("AF_COST", sCost, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_BLNO", sBlno, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CERTI", sCerti, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AF_PHOTO", sPhoto, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_MASK", sMask, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_FRAME", sFrame, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_COATING", sCoating, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_CLEANSING", sCleansing, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_ETC", sEtc, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MONEYDUEDATE", sMoneyDueDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_INCOMEDATE", sIncomeDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", "SYSTEM", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_SA0000_EXCEL_I2", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", "10", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CONTRACTNO", sContractNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHIPNO", sShipNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_DUEDATE", sDueDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CURNM", sCurCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PACKQTY", sPackQty, DbType.Decimal, ParameterDirection.Input)
                            , helper.CreateParameter("AF_COST", sCost, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_BLNO", sBlno, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CERTI", sCerti, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AF_PHOTO", sPhoto, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_MASK", sMask, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_FRAME", sFrame, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_COATING", sCoating, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_CLEANSING", sCleansing, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AF_ETC", sEtc, DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MONEYDUEDATE", sMoneyDueDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_INCOMEDATE", sIncomeDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", "SYSTEM", DbType.String, ParameterDirection.Input));

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
                    txtFile.Text = openfiledialog.FileName;

                    //대상 GRID DataTable 복사(구조o, 데이터x)
                    DataTable dtTarget = ((DataTable)this.grid1.DataSource).Clone();

                    //엑셀파일에서 READ 된 DataTable로 등록할 데이터 DataTable에 저장
                    for (int i = 1; i < dtExcelImport.Rows.Count; i++)
                    {
                        DataRow drTarget = dtTarget.NewRow();
                        drTarget["SAVEBUTTON"] = DBHelper.nvlString(dtExcelImport.Rows[i][0]);
                        drTarget["CONTRACTNO"] = DBHelper.nvlString(dtExcelImport.Rows[i][1]);
                        drTarget["SHIPNO"] = DBHelper.nvlString(dtExcelImport.Rows[i][2]);
                        drTarget["ITEMCODE"] = DBHelper.nvlString(dtExcelImport.Rows[i][3]);
                        drTarget["CONTRACTQTY"] = DBHelper.nvlString(dtExcelImport.Rows[i][4]);
                        drTarget["DUEDATE"] = DBHelper.nvlString(dtExcelImport.Rows[i][5]);
                        drTarget["PACKQTY"] = DBHelper.nvlString(dtExcelImport.Rows[i][6]);
                        drTarget["CURNM"] = DBHelper.nvlString(dtExcelImport.Rows[i][7]);
                        drTarget["RATE"] = DBHelper.nvlString(dtExcelImport.Rows[i][8]);
                        drTarget["COST"] = DBHelper.nvlString(dtExcelImport.Rows[i][9]);
                        drTarget["MONEYDUEDATE"] = DBHelper.nvlString(dtExcelImport.Rows[i][13]);
                        drTarget["INCOMEDATE"] = DBHelper.nvlString(dtExcelImport.Rows[i][14]);
                        drTarget["PONO"] = DBHelper.nvlString(dtExcelImport.Rows[i][15]);
                        drTarget["BLNO"] = DBHelper.nvlString(dtExcelImport.Rows[i][16]);
                        drTarget["CERTI"] = DBHelper.nvlString(dtExcelImport.Rows[i][17]);
                        drTarget["PHOTO"] = DBHelper.nvlString(dtExcelImport.Rows[i][18]);
                        drTarget["MASK"] = DBHelper.nvlString(dtExcelImport.Rows[i][20]);
                        drTarget["FRAME"] = DBHelper.nvlString(dtExcelImport.Rows[i][22]);
                        drTarget["COATING"] = DBHelper.nvlString(dtExcelImport.Rows[i][24]);
                        drTarget["CLEANSING"] = DBHelper.nvlString(dtExcelImport.Rows[i][26]);
                        drTarget["ETC"] = DBHelper.nvlString(dtExcelImport.Rows[i][28]);

                        //drTarget["REMARK"] = DBHelper.nvlString(dtExcelImport.Rows[i][18]);

                        //if (DBHelper.nvlString(drTarget["USEFLAG"]) == "")
                        //{
                        //    drTarget["USEFLAG"] = "Y";
                        //}

                        dtTarget.Rows.Add(drTarget);
                    }

                    this.grid1.DataSource = dtTarget;
                    this.grid1.DataBind();

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


        /*private void btnFileOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = "EXCEL|*.xls|ALL|*.*";

                if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //엑셀 파일 READ
                    DataTable dtExcelImport = GetExcel(openfiledialog.FileName);

                    string itemcode = string.Empty;
                    string inspflag = string.Empty;
                    string whcode = string.Empty;
                    string useflag = string.Empty;

                    //대상 GRID DataTable 복사(구조o, 데이터x)
                    DataTable dtTarget = ((DataTable)this.grid1.DataSource).Clone();

                    //엑셀파일에서 READ 된 DataTable로 등록할 데이터 DataTable에 저장
                    for (int i = 1; i < dtExcelImport.Rows.Count; i++)
                    {
                        DataRow drTarget = dtTarget.NewRow();

                        itemcode = Convert.ToString(dtExcelImport.Rows[i][3]) + Convert.ToString(dtExcelImport.Rows[i][2]);

                        if (Convert.ToString(dtExcelImport.Rows[i][1]) == "ROH" || Convert.ToString(dtExcelImport.Rows[i][1]) == "ROH4" || Convert.ToString(dtExcelImport.Rows[i][1]) == "ROH2")//원자재,구매품,부품
                        {
                            inspflag = "I";
                            whcode = "WH001";
                        }
                        else if (Convert.ToString(dtExcelImport.Rows[i][1]) == "HALB")//반제품
                        {
                            inspflag = "U";
                            whcode = "WH002";
                        }
                        else if (Convert.ToString(dtExcelImport.Rows[i][1]) == "FERT")//완제품
                        {
                            inspflag = "I";
                            whcode = "WH003";
                        }
                        else
                        {
                            whcode = Convert.ToString(dtExcelImport.Rows[i][10]);
                            inspflag = Convert.ToString(dtExcelImport.Rows[i][12]);
                        }

                        if (Convert.ToString(dtExcelImport.Rows[i][28]) == "")
                        {
                            useflag = "Y";
                        }
                        else
                        {
                            useflag = Convert.ToString(dtExcelImport.Rows[i][28]);
                        }

                        drTarget["PLANTCODE"] = Convert.ToString(dtExcelImport.Rows[i][0]);
                        drTarget["ITEMTYPE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["MAJORITEMTYPE"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["ProdItemCode"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        //  drTarget["ITEMCODE"]       = itemcode;
                        drTarget["ITEMNAME"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["BASEUNIT"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["UNITWGT"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["UNITCOST"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["MAKECOMPANY"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        drTarget["WHCODE"] = whcode;// Convert.ToString(dtExcelImport.Rows[i][10]);
                        drTarget["LOCCODE"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                        drTarget["INSPFLAG"] = inspflag;//Convert.ToString(dtExcelImport.Rows[i][12]);
                        drTarget["ITEMSPEC"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        drTarget["MATERIALGRADE"] = Convert.ToString(dtExcelImport.Rows[i][14]);
                        drTarget["MAXSTOCK"] = Convert.ToString(dtExcelImport.Rows[i][15]);
                        drTarget["SAFESTOCK"] = Convert.ToString(dtExcelImport.Rows[i][16]);
                        drTarget["CHANGEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][17]);
                        drTarget["CHANGETIME"] = Convert.ToString(dtExcelImport.Rows[i][18]);
                        drTarget["MINORDERQTY"] = Convert.ToString(dtExcelImport.Rows[i][19]);
                        drTarget["ORDERQTY"] = Convert.ToString(dtExcelImport.Rows[i][20]);
                        drTarget["MAXORDERQTY"] = Convert.ToString(dtExcelImport.Rows[i][21]);
                        drTarget["ASGNCODE"] = Convert.ToString(dtExcelImport.Rows[i][22]);
                        drTarget["ASGNNAME"] = Convert.ToString(dtExcelImport.Rows[i][23]);
                        drTarget["ASGNSPHONE"] = Convert.ToString(dtExcelImport.Rows[i][24]);
                        drTarget["ASGNSEMAIL"] = Convert.ToString(dtExcelImport.Rows[i][25]);
                        drTarget["ASGNFAXNO"] = Convert.ToString(dtExcelImport.Rows[i][26]);
                        drTarget["ASGNADDRESS"] = Convert.ToString(dtExcelImport.Rows[i][27]);
                        drTarget["USEFLAG"] = useflag;//Convert.ToString(dtExcelImport.Rows[i][28]);
                        drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][29]);


                        
                        //drTarget["PLANTCODE"]      = Convert.ToString(dtExcelImport.Rows[i][0]);
                        //drTarget["ITEMTYPE"]       = Convert.ToString(dtExcelImport.Rows[i][1]);
                        //drTarget["ITEMCODE"] = itemcode;
                        //drTarget["ITEMNAME"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        //drTarget["BASEUNIT"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        //drTarget["INSPFLAG"] = inspflag;//Convert.ToString(dtExcelImport.Rows[i][12]);
                        //drTarget["MATERIALGRADE"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        //drTarget["ITEMSPEC"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        //drTarget["CARTYPE"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        //drTarget["SAFESTOCK"] = Convert.ToString(dtExcelImport.Rows[i][16]);
                        //drTarget["UNITWGT"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        //drTarget["UNITCOST"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        //drTarget["ASGNCODE"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        //drTarget["USEFLAG"] = useflag;//Convert.ToString(dtExcelImport.Rows[i][28]);
                        //drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                        //drTarget["MAKER"] = Convert.ToString(dtExcelImport.Rows[i][12]);
                        //drTarget["MAKEDATE"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        //drTarget["EDITOR"] = Convert.ToString(dtExcelImport.Rows[i][14]);
                        //drTarget["EDITDATE"] = Convert.ToString(dtExcelImport.Rows[i][15]);
                        

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
        */
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

        //콤보값 존재 확인 조회
        private bool getvalues(string Macode, string Micode)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT CODENAME");
                command.AppendLine("  FROM TBM0000                     ");
                command.AppendLine(" WHERE USEFLAG = 'Y'");
                command.AppendLine("   and MAJORCODE = '" + Macode + "'");
                command.AppendLine("   and MINORCODE = '" + Micode + "'");
                //  command.AppendLine(" ORDER BY WORKCENTERCODE";

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                if (dttemp.Rows.Count > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                helper.Close();
            }
        }
    }
}

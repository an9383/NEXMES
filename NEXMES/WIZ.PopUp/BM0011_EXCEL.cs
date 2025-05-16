using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class BM0011_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public BM0011_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void BM0011_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목유형", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAXSTOCK", "적정재고", true, GridColDataType_emu.VarChar, 80, 140, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SAFESTOCK", "안전재고", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCOST", "단가", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITWGT", "단위중량", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPFLAG", "수입검사여부", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITLENGTH", "길이", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITTHICK", "두께", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITWIDTH", "폭", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "GRADE", "강종", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMSPEC", "규격", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MATERIALGRADE", "재질", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CARTYPE", "차종", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 90, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["UNITCODE"].Header.Appearance.ForeColor = Color.SkyBlue;

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

            string sPlantCode = string.Empty;
            string sItemCode = string.Empty;
            string sItemName = string.Empty;
            string sItemType = string.Empty;
            string sMaxStock = string.Empty;
            string sSafeStock = string.Empty;
            string sUnitCode = string.Empty;
            string sUnitCost = string.Empty;
            string sUnitWgt = string.Empty;
            string sInspFlag = string.Empty;
            string sUnitLength = string.Empty;
            string sUnitThick = string.Empty;
            string sUnitWidth = string.Empty;
            string sGrade = string.Empty;
            string sItemSpec = string.Empty;
            string sMaterialGrade = string.Empty;
            string sCarType = string.Empty;
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
                    sItemCode = Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value);
                    sItemName = Convert.ToString(grid1.Rows[i].Cells["ITEMNAME"].Value);
                    sItemType = Convert.ToString(grid1.Rows[i].Cells["ITEMTYPE"].Value);
                    sMaxStock = Convert.ToString(grid1.Rows[i].Cells["MAXSTOCK"].Value);
                    sSafeStock = Convert.ToString(grid1.Rows[i].Cells["SAFESTOCK"].Value);
                    sUnitCode = Convert.ToString(grid1.Rows[i].Cells["UNITCODE"].Value);
                    sUnitCost = Convert.ToString(grid1.Rows[i].Cells["UNITCOST"].Value);
                    sUnitWgt = Convert.ToString(grid1.Rows[i].Cells["UNITWGT"].Value);
                    sInspFlag = Convert.ToString(grid1.Rows[i].Cells["INSPFLAG"].Value);
                    sUnitLength = Convert.ToString(grid1.Rows[i].Cells["UNITLENGTH"].Value);
                    sUnitThick = Convert.ToString(grid1.Rows[i].Cells["UNITTHICK"].Value);
                    sUnitWidth = Convert.ToString(grid1.Rows[i].Cells["UNITWIDTH"].Value);
                    sGrade = Convert.ToString(grid1.Rows[i].Cells["GRADE"].Value);
                    sItemSpec = Convert.ToString(grid1.Rows[i].Cells["ITEMSPEC"].Value);
                    sMaterialGrade = Convert.ToString(grid1.Rows[i].Cells["MATERIALGRADE"].Value);
                    sCarType = Convert.ToString(grid1.Rows[i].Cells["CARTYPE"].Value);
                    sRemark = Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value);
                    sUseFlag = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);


                    if (sPlantCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.", "MSG"));
                        return;
                    }
                    if (sItemCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 품목을 확인하세요.", "MSG"));
                        return;
                    }
                    if (sItemName == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 품명을 확인하세요.", "MSG"));
                        return;
                    }
                    if (sItemType == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 품목구분을 확인하세요.", "MSG"));
                        return;
                    }

                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "BM0011", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_BM0011_EXCEL_I1", CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMNAME", Convert.ToString(grid1.Rows[i].Cells["ITEMNAME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMTYPE", Convert.ToString(grid1.Rows[i].Cells["ITEMTYPE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_MAXSTOCK", Convert.ToString(grid1.Rows[i].Cells["MAXSTOCK"].Value), DbType.Double, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_SAFESTOCK", Convert.ToString(grid1.Rows[i].Cells["SAFESTOCK"].Value), DbType.Double, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITCODE", Convert.ToString(grid1.Rows[i].Cells["UNITCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_UNITCOST", Convert.ToString(grid1.Rows[i].Cells["UNITCOST"].Value), DbType.Double, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITWGT", Convert.ToString(grid1.Rows[i].Cells["UNITWGT"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_INSPFLAG", Convert.ToString(grid1.Rows[i].Cells["INSPFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITLENGTH", Convert.ToString(grid1.Rows[i].Cells["UNITLENGTH"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITTHICK", Convert.ToString(grid1.Rows[i].Cells["UNITTHICK"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITWIDTH", Convert.ToString(grid1.Rows[i].Cells["UNITWIDTH"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_GRADE", Convert.ToString(grid1.Rows[i].Cells["GRADE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMSPEC", Convert.ToString(grid1.Rows[i].Cells["ITEMSPEC"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_MATERIALGRADE", Convert.ToString(grid1.Rows[i].Cells["MATERIALGRADE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_CARTYPE", Convert.ToString(grid1.Rows[i].Cells["CARTYPE"].Value), DbType.String, ParameterDirection.Input)
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
                        helper.ExecuteNoneQuery("USP_BM0011_EXCEL_I1", CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMNAME", Convert.ToString(grid1.Rows[i].Cells["ITEMNAME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMTYPE", Convert.ToString(grid1.Rows[i].Cells["ITEMTYPE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_MAXSTOCK", Convert.ToString(grid1.Rows[i].Cells["MAXSTOCK"].Value), DbType.Double, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_SAFESTOCK", Convert.ToString(grid1.Rows[i].Cells["SAFESTOCK"].Value), DbType.Double, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITCODE", Convert.ToString(grid1.Rows[i].Cells["UNITCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_UNITCOST", Convert.ToString(grid1.Rows[i].Cells["UNITCOST"].Value), DbType.Double, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITWGT", Convert.ToString(grid1.Rows[i].Cells["UNITWGT"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_INSPFLAG", Convert.ToString(grid1.Rows[i].Cells["INSPFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITLENGTH", Convert.ToString(grid1.Rows[i].Cells["UNITLENGTH"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITTHICK", Convert.ToString(grid1.Rows[i].Cells["UNITTHICK"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITWIDTH", Convert.ToString(grid1.Rows[i].Cells["UNITWIDTH"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_GRADE", Convert.ToString(grid1.Rows[i].Cells["GRADE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMSPEC", Convert.ToString(grid1.Rows[i].Cells["ITEMSPEC"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_MATERIALGRADE", Convert.ToString(grid1.Rows[i].Cells["MATERIALGRADE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_CARTYPE", Convert.ToString(grid1.Rows[i].Cells["CARTYPE"].Value), DbType.String, ParameterDirection.Input)
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
                    txtFile.Text = openfiledialog.FileName;

                    //대상 GRID DataTable 복사(구조o, 데이터x)
                    DataTable dtTarget = ((DataTable)this.grid1.DataSource).Clone();

                    //엑셀파일에서 READ 된 DataTable로 등록할 데이터 DataTable에 저장
                    for (int i = 1; i < dtExcelImport.Rows.Count; i++)
                    {
                        DataRow drTarget = dtTarget.NewRow();
                        drTarget["PLANTCODE"] = DBHelper.nvlString(dtExcelImport.Rows[i][0]);
                        drTarget["ITEMCODE"] = DBHelper.nvlString(dtExcelImport.Rows[i][1]);
                        drTarget["ITEMNAME"] = DBHelper.nvlString(dtExcelImport.Rows[i][2]);
                        drTarget["ITEMTYPE"] = DBHelper.nvlString(dtExcelImport.Rows[i][3]);
                        drTarget["MAXSTOCK"] = DBHelper.nvlString(dtExcelImport.Rows[i][4]);
                        drTarget["SAFESTOCK"] = DBHelper.nvlString(dtExcelImport.Rows[i][5]);
                        drTarget["UNITCODE"] = DBHelper.nvlString(dtExcelImport.Rows[i][6]);
                        drTarget["UNITCOST"] = DBHelper.nvlString(dtExcelImport.Rows[i][7]);
                        drTarget["UNITWGT"] = DBHelper.nvlString(dtExcelImport.Rows[i][8]);
                        drTarget["INSPFLAG"] = DBHelper.nvlString(dtExcelImport.Rows[i][9]);
                        drTarget["UNITLENGTH"] = DBHelper.nvlString(dtExcelImport.Rows[i][10]);
                        drTarget["UNITTHICK"] = DBHelper.nvlString(dtExcelImport.Rows[i][11]);
                        drTarget["UNITWIDTH"] = DBHelper.nvlString(dtExcelImport.Rows[i][12]);
                        drTarget["GRADE"] = DBHelper.nvlString(dtExcelImport.Rows[i][13]);
                        drTarget["ITEMSPEC"] = DBHelper.nvlString(dtExcelImport.Rows[i][14]);
                        drTarget["MATERIALGRADE"] = DBHelper.nvlString(dtExcelImport.Rows[i][15]);
                        drTarget["CARTYPE"] = DBHelper.nvlString(dtExcelImport.Rows[i][16]);
                        drTarget["USEFLAG"] = DBHelper.nvlString(dtExcelImport.Rows[i][17]).Trim();
                        drTarget["REMARK"] = DBHelper.nvlString(dtExcelImport.Rows[i][18]);

                        if (DBHelper.nvlString(drTarget["USEFLAG"]) == "")
                        {
                            drTarget["USEFLAG"] = "Y";
                        }

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

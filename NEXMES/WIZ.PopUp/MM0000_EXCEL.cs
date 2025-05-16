#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0000_EXCEL
//   Form Name    : 발주정보 등록 엑셀 업로드
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-30
//   Made By      : 
//   Edited Date  : 
//   Edit By      :
//   Description  : 발주정보 등록 엑셀 업로드
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.PopUp
{
    public partial class MM0000_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region < CONSTRUCTOR >
        public MM0000_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MM0000_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PODATE", "발주일", true, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANINDATE", "입고예정일", true, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처ⓒ", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "POQTY", "발주량(ⓐ)", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["PODATE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["PLANINDATE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["POQTY"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["USEFLAG"].Header.Appearance.ForeColor = Color.SkyBlue;


            #endregion

            #region [ Combo Box ]
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            BizGridManager bizGridManager;

            bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "4", "" });
            bizGridManager.PopUpAdd("CUSTCODE", "CUSTNAME", "BM0030", new string[] { "PLANTCODE", "VD", "" });


            #endregion

        }
        #endregion


        #region < USER METHOD AREA >
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
            //string sPoNo           = string.Empty;
            string sPoDate = string.Empty;
            string sPlanIndate = string.Empty;
            string sCustCode = string.Empty;
            string sItemCode = string.Empty;
            string sPoQty = string.Empty;
            //string sInQty          = string.Empty;
            //string sTmpInQty       = string.Empty;
            //string sReInQty        = string.Empty;
            //string sFinishFlag     = string.Empty;
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
                    //sPoNo          = Convert.ToString(grid1.Rows[i].Cells["PONO"].Value);
                    sPoDate = Convert.ToString(grid1.Rows[i].Cells["PODATE"].Value);
                    sPlanIndate = Convert.ToString(grid1.Rows[i].Cells["PLANINDATE"].Value);
                    sCustCode = Convert.ToString(grid1.Rows[i].Cells["CUSTCODE"].Value);
                    sItemCode = Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value);
                    sPoQty = Convert.ToString(grid1.Rows[i].Cells["POQTY"].Value);
                    //sInQty         = Convert.ToString(grid1.Rows[i].Cells["INQTY"].Value);
                    //sTmpInQty      = Convert.ToString(grid1.Rows[i].Cells["TMPINQTY"].Value);
                    //sReInQty       = Convert.ToString(grid1.Rows[i].Cells["REINQTY"].Value);
                    //sFinishFlag    = Convert.ToString(grid1.Rows[i].Cells["FINISHFLAG"].Value);
                    sRemark = Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value);
                    sUseFlag = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);


                    if (sPlantCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.", "MSG"));
                        return;
                    }
                    if (sPoDate == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 발주일을 확인하세요.", "MSG"));
                        return;
                    }
                    if (sPlanIndate == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 입고예정일을 확인하세요.", "MSG"));
                        return;
                    }
                    if (sCustCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 거래처를 확인하세요.", "MSG"));
                        return;
                    }
                    if (sItemCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 품목을 확인하세요.", "MSG"));
                        return;
                    }
                    if (sPoQty == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 발주량을 확인하세요.", "MSG"));
                        return;
                    }
                    if (sUseFlag == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 사용여부를 확인하세요.", "MSG"));
                        return;
                    }

                }

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
                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        helper.ExecuteNoneQuery("USP_MM0000_EXCEL_I1", CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               //, helper.CreateParameter("AS_PONO",       Convert.ToString(grid1.Rows[i].Cells["PONO"].Value),        DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PODATE", Convert.ToString(grid1.Rows[i].Cells["PODATE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PLANINDATE", Convert.ToString(grid1.Rows[i].Cells["PLANINDATE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_CUSTCODE", Convert.ToString(grid1.Rows[i].Cells["CUSTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_POQTY", Convert.ToString(grid1.Rows[i].Cells["POQTY"].Value), DbType.Double, ParameterDirection.Input)
                                               //, helper.CreateParameter("AF_INQTY",      Convert.ToString(grid1.Rows[i].Cells["INQTY"].Value),       DbType.Double, ParameterDirection.Input)
                                               //, helper.CreateParameter("AF_TMPINQTY",   Convert.ToString(grid1.Rows[i].Cells["TMPINQTY"].Value),    DbType.Double, ParameterDirection.Input)
                                               //, helper.CreateParameter("AS_FINISHFLAG", Convert.ToString(grid1.Rows[i].Cells["FINISHFLAG"].Value),  DbType.String, ParameterDirection.Input)
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
                        helper.ExecuteNoneQuery("USP_MM0000_EXCEL_I1", CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               //, helper.CreateParameter("AS_PONO",       Convert.ToString(grid1.Rows[i].Cells["PONO"].Value),        DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PODATE", Convert.ToString(grid1.Rows[i].Cells["PODATE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PLANINDATE", Convert.ToString(grid1.Rows[i].Cells["PLANINDATE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_CUSTCODE", Convert.ToString(grid1.Rows[i].Cells["CUSTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_POQTY", Convert.ToString(grid1.Rows[i].Cells["POQTY"].Value), DbType.Double, ParameterDirection.Input)
                                               //, helper.CreateParameter("AF_INQTY",      Convert.ToString(grid1.Rows[i].Cells["INQTY"].Value),       DbType.Double, ParameterDirection.Input)
                                               //, helper.CreateParameter("AF_TMPINQTY",   Convert.ToString(grid1.Rows[i].Cells["TMPINQTY"].Value),    DbType.Double, ParameterDirection.Input)
                                               //, helper.CreateParameter("AS_FINISHFLAG", Convert.ToString(grid1.Rows[i].Cells["FINISHFLAG"].Value),  DbType.String, ParameterDirection.Input)
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

        #region < EVENT AREA >
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
                    for (int i = 1; i < dtExcelImport.Rows.Count; i++)
                    {
                        DataRow drTarget = dtTarget.NewRow();
                        drTarget["PLANTCODE"] = Convert.ToString(dtExcelImport.Rows[i][0]);
                        drTarget["PODATE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["PLANINDATE"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["CUSTCODE"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["CUSTNAME"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["ITEMCODE"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["ITEMNAME"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["POQTY"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["USEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][9]).Trim();

                        if (Convert.ToString(drTarget["USEFLAG"]) == "")
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

        private void btnFileDown_Click(object sender, EventArgs e)
        {
            _GridUtil.ExportExcel(this.grid1);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcelUpload_Click(object sender, EventArgs e)
        {
            INSERT_SAVE();
        }
        #endregion

    }
}

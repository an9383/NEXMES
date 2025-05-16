using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class BM0030_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public BM0030_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void BM0030_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //GRID1 품목

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTTYPE", "거래처구분", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTENAME", "업체명", true, GridColDataType_emu.VarChar, 150, 140, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTOMER", "거래처\r\n주고객사", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BIZSTARTDATE", "거래시작일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BIZENDDATE", "거래종료일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BIZREQNO", "사업자\r\n등록번호", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CMPPOSTNO", "회사 우편번호", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BIZPOSTNO", "사업장\r\n우편번호", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BIZCLASS", "업태", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BIZTYPE", "종목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PHONE", "전화번호", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ADDRESS", "주소", true, GridColDataType_emu.VarChar, 330, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNNAME", "담당자 이름", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNPSTN", "담당자 직위", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNFAXNO", "담당자\r\nFAX번호", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNSPHONE", "담당자\r\n휴대폰번호", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTCOSTFLAG", "유상사급유무", true, GridColDataType_emu.VarChar, 50, 50, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 90, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            //필수입력 항목에 대한 음영
            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["CUSTTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;

            #endregion

            #region [ Combo Box ]
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("CUSTTYPE"); //거래처유형
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CUSTTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
                //oledbConnStr = "Provider=Microsoft.JET.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties='Excel 12.0';HDR=NO;IMEX=1'";
                oledbConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=NO'";

                //oledbConnStr = "Provider=Microsoft.JET.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties=\"Excel 12.0\"";
            }
            else
            {
                // 엑셀 2003 및 이하 버전
                //oledbConnStr = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties=\"Excel 8.0\"";

                //oledbConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=No'"; 기존 사용
                //oledbConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";

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
            string sCustType = string.Empty;
            string sCustName = string.Empty;
            string sCusteName = string.Empty;
            string sCustOmer = string.Empty;
            string sBizStartDate = string.Empty;
            string sBizEndDate = string.Empty;
            string sBizReqNo = string.Empty;
            string sCmpPostNo = string.Empty;
            string sBizPostNo = string.Empty;
            string sBizClass = string.Empty;
            string sBizType = string.Empty;
            string sPhone = string.Empty;
            string sAddress = string.Empty;
            string sAsgnName = string.Empty;
            string sAsgnPstn = string.Empty;
            string sAsgnFaxNo = string.Empty;
            string sAsgnPhone = string.Empty;
            string sOutCostFlag = string.Empty;
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
                    sCustType = Convert.ToString(grid1.Rows[i].Cells["CUSTTYPE"].Value);
                    sCustName = Convert.ToString(grid1.Rows[i].Cells["CUSTNAME"].Value);
                    sCusteName = Convert.ToString(grid1.Rows[i].Cells["CUSTENAME"].Value);
                    sCustOmer = Convert.ToString(grid1.Rows[i].Cells["CUSTOMER"].Value);
                    sBizStartDate = Convert.ToString(grid1.Rows[i].Cells["BIZSTARTDATE"].Value);
                    sBizEndDate = Convert.ToString(grid1.Rows[i].Cells["BIZENDDATE"].Value);
                    sBizReqNo = Convert.ToString(grid1.Rows[i].Cells["BIZREQNO"].Value);
                    sCmpPostNo = Convert.ToString(grid1.Rows[i].Cells["CMPPOSTNO"].Value);
                    sBizPostNo = Convert.ToString(grid1.Rows[i].Cells["BIZPOSTNO"].Value);
                    sBizClass = Convert.ToString(grid1.Rows[i].Cells["BIZCLASS"].Value);
                    sBizType = Convert.ToString(grid1.Rows[i].Cells["BIZTYPE"].Value);
                    sPhone = Convert.ToString(grid1.Rows[i].Cells["PHONE"].Value);
                    sAddress = Convert.ToString(grid1.Rows[i].Cells["ADDRESS"].Value);
                    sAsgnName = Convert.ToString(grid1.Rows[i].Cells["ASGNNAME"].Value);
                    sAsgnPstn = Convert.ToString(grid1.Rows[i].Cells["ASGNPSTN"].Value);
                    sAsgnFaxNo = Convert.ToString(grid1.Rows[i].Cells["ASGNFAXNO"].Value);
                    sAsgnPhone = Convert.ToString(grid1.Rows[i].Cells["ASGNSPHONE"].Value);
                    sOutCostFlag = Convert.ToString(grid1.Rows[i].Cells["OUTCOSTFLAG"].Value);
                    sRemark = Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value);
                    sUseFlag = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);

                    if (sPlantCode == string.Empty)// || plantcode.Length != 2) // || getvalues("PLANTCODE",plantcode) == false)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.", "MSG"));
                        return;
                    }
                    if (sCustType == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 거래처 유형을 확인하세요.", "MSG"));
                        return;
                    }
                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "BM0030", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_BM0030_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTTYPE", Convert.ToString(grid1.Rows[i].Cells["CUSTTYPE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTNAME", Convert.ToString(grid1.Rows[i].Cells["CUSTNAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTENAME", Convert.ToString(grid1.Rows[i].Cells["CUSTENAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTOMER", Convert.ToString(grid1.Rows[i].Cells["CUSTOMER"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZSTARTDATE", Convert.ToString(grid1.Rows[i].Cells["BIZSTARTDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZENDDATE", Convert.ToString(grid1.Rows[i].Cells["BIZENDDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZREQNO", Convert.ToString(grid1.Rows[i].Cells["BIZREQNO"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CMPPOSTNO", Convert.ToString(grid1.Rows[i].Cells["CMPPOSTNO"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZPOSTNO", Convert.ToString(grid1.Rows[i].Cells["BIZPOSTNO"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZCLASS", Convert.ToString(grid1.Rows[i].Cells["BIZCLASS"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZTYPE", Convert.ToString(grid1.Rows[i].Cells["BIZTYPE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PHONE", Convert.ToString(grid1.Rows[i].Cells["PHONE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ADDRESS", Convert.ToString(grid1.Rows[i].Cells["ADDRESS"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ASGNNAME", Convert.ToString(grid1.Rows[i].Cells["ASGNNAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ASGNPSTN", Convert.ToString(grid1.Rows[i].Cells["ASGNPSTN"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ASGNFAXNO", Convert.ToString(grid1.Rows[i].Cells["ASGNFAXNO"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ASGNSPHONE", Convert.ToString(grid1.Rows[i].Cells["ASGNSPHONE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OUTCOSTFLAG", Convert.ToString(grid1.Rows[i].Cells["OUTCOSTFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DateTime.Now, DbType.DateTime, ParameterDirection.Input));


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
                        helper.ExecuteNoneQuery("USP_BM0030_I1"
                                                                                            , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTTYPE", Convert.ToString(grid1.Rows[i].Cells["CUSTTYPE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTNAME", Convert.ToString(grid1.Rows[i].Cells["CUSTNAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTENAME", Convert.ToString(grid1.Rows[i].Cells["CUSTENAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTOMER", Convert.ToString(grid1.Rows[i].Cells["CUSTOMER"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZSTARTDATE", Convert.ToString(grid1.Rows[i].Cells["BIZSTARTDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZENDDATE", Convert.ToString(grid1.Rows[i].Cells["BIZENDDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZREQNO", Convert.ToString(grid1.Rows[i].Cells["BIZREQNO"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CMPPOSTNO", Convert.ToString(grid1.Rows[i].Cells["CMPPOSTNO"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZPOSTNO", Convert.ToString(grid1.Rows[i].Cells["BIZPOSTNO"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZCLASS", Convert.ToString(grid1.Rows[i].Cells["BIZCLASS"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZTYPE", Convert.ToString(grid1.Rows[i].Cells["BIZTYPE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PHONE", Convert.ToString(grid1.Rows[i].Cells["PHONE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ADDRESS", Convert.ToString(grid1.Rows[i].Cells["ADDRESS"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ASGNNAME", Convert.ToString(grid1.Rows[i].Cells["ASGNNAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ASGNPSTN", Convert.ToString(grid1.Rows[i].Cells["ASGNPSTN"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ASGNFAXNO", Convert.ToString(grid1.Rows[i].Cells["ASGNFAXNO"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ASGNSPHONE", Convert.ToString(grid1.Rows[i].Cells["ASGNSPHONE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OUTCOSTFLAG", Convert.ToString(grid1.Rows[i].Cells["OUTCOSTFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DateTime.Now, DbType.DateTime, ParameterDirection.Input));

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
                    for (int i = 1; i < dtExcelImport.Rows.Count; i++)
                    {
                        DataRow drTarget = dtTarget.NewRow();

                        drTarget["PLANTCODE"] = Convert.ToString(dtExcelImport.Rows[i][0]);
                        drTarget["CUSTNAME"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["CUSTTYPE"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["CUSTENAME"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["CUSTOMER"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["BIZSTARTDATE"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["BIZENDDATE"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["BIZREQNO"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["CMPPOSTNO"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["BIZPOSTNO"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        drTarget["BIZCLASS"] = Convert.ToString(dtExcelImport.Rows[i][10]);
                        drTarget["BIZTYPE"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                        drTarget["PHONE"] = Convert.ToString(dtExcelImport.Rows[i][12]);
                        drTarget["ADDRESS"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        drTarget["ASGNNAME"] = Convert.ToString(dtExcelImport.Rows[i][14]);
                        drTarget["ASGNPSTN"] = Convert.ToString(dtExcelImport.Rows[i][15]);
                        drTarget["ASGNFAXNO"] = Convert.ToString(dtExcelImport.Rows[i][16]);
                        drTarget["ASGNSPHONE"] = Convert.ToString(dtExcelImport.Rows[i][17]);
                        drTarget["OUTCOSTFLAG"] = Convert.ToString(dtExcelImport.Rows[i][18]);
                        drTarget["USEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][19]).Trim();
                        drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][20]);

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

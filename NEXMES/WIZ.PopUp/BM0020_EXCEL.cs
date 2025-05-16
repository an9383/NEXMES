using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class BM0020_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public BM0020_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void BM0020_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERID", "작업자ID", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "작업자명", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE", "부서", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PASSWORD", "비밀번호", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "GRPID", "권한그룹", true, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정코드", true, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TEAMCODE", "팀코드", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BANCODE", "작업반코드", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CLASSCODE", "그룹코드", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHT", "주야구분", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SHIFTGB", "조코드", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EMPNO", "사번", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EMPTELNO", "연락처", true, GridColDataType_emu.VarChar, 150, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE", "입사일", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTDATE", "퇴사일", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LANG", "언어", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAILID", "메일", true, GridColDataType_emu.VarChar, 170, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PHONENO", "PHONE 번호", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SYSFLAG", "시스템여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 130, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            //필수입력 항목에 대한 음영
            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["WORKERID"].Header.Appearance.ForeColor = Color.SkyBlue;

            grid1.DisplayLayout.Bands[0].Columns["INDATE"].MaskInput = "####-##-##";
            grid1.DisplayLayout.Bands[0].Columns["OUTDATE"].MaskInput = "####-##-##";

            #endregion

            #region [ Combo Box ]
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("GRPID"); // 그룹코드
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "GRPID", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT"); // 주야구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DAYNIGHT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DEPTCODE"); // 부서코드
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("BANCODE"); //반코드
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "BANCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
            string sWorkerId = string.Empty;
            string sWorkerName = string.Empty;
            string sPassWord = string.Empty;
            string sGrpId = string.Empty;
            string sOpCode = string.Empty;
            string sWorkcenterCode = string.Empty;
            string sDeptCode = string.Empty;
            string sTeamCode = string.Empty;
            string sBanCode = string.Empty;
            string sClassCode = string.Empty;
            string sDayNight = string.Empty;
            string sShiftGb = string.Empty;
            string sEmpNo = string.Empty;
            string sEmptelNo = string.Empty;
            string sInDate = string.Empty;
            string sOutDate = string.Empty;
            string sLang = string.Empty;
            string sMailId = string.Empty;
            string sPhoneNo = string.Empty;
            string sSysFlag = string.Empty;
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
                    sWorkerId = Convert.ToString(grid1.Rows[i].Cells["WORKERID"].Value);
                    sWorkerName = Convert.ToString(grid1.Rows[i].Cells["WORKERNAME"].Value);
                    sPassWord = Convert.ToString(grid1.Rows[i].Cells["PASSWORD"].Value);
                    sGrpId = Convert.ToString(grid1.Rows[i].Cells["GRPID"].Value);
                    sOpCode = Convert.ToString(grid1.Rows[i].Cells["OPCODE"].Value);
                    sWorkcenterCode = Convert.ToString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value);
                    sDeptCode = Convert.ToString(grid1.Rows[i].Cells["DEPTCODE"].Value);
                    sTeamCode = Convert.ToString(grid1.Rows[i].Cells["TEAMCODE"].Value);
                    sBanCode = Convert.ToString(grid1.Rows[i].Cells["BANCODE"].Value);
                    sClassCode = Convert.ToString(grid1.Rows[i].Cells["CLASSCODE"].Value);
                    sDayNight = Convert.ToString(grid1.Rows[i].Cells["DAYNIGHT"].Value);
                    sShiftGb = Convert.ToString(grid1.Rows[i].Cells["SHIFTGB"].Value);
                    sEmpNo = Convert.ToString(grid1.Rows[i].Cells["EMPNO"].Value);
                    sEmptelNo = Convert.ToString(grid1.Rows[i].Cells["EMPTELNO"].Value);
                    sInDate = Convert.ToString(grid1.Rows[i].Cells["INDATE"].Value);
                    sOutDate = Convert.ToString(grid1.Rows[i].Cells["OUTDATE"].Value);
                    sLang = Convert.ToString(grid1.Rows[i].Cells["LANG"].Value);
                    sMailId = Convert.ToString(grid1.Rows[i].Cells["MAILID"].Value);
                    sPhoneNo = Convert.ToString(grid1.Rows[i].Cells["PHONENO"].Value);
                    sSysFlag = Convert.ToString(grid1.Rows[i].Cells["SYSFLAG"].Value);
                    sRemark = Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value);
                    sUseFlag = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);

                    if (sPlantCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.", "MSG"));
                        return;
                    }
                    if (sWorkerId == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 작업자 ID를 확인하세요.", "MSG"));
                        return;
                    }
                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "BM0020", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_BM0020_EXCEL_I1", CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WORKERID", Convert.ToString(grid1.Rows[i].Cells["WORKERID"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WORKERNAME", Convert.ToString(grid1.Rows[i].Cells["WORKERNAME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PASSWORD", Convert.ToString(grid1.Rows[i].Cells["PASSWORD"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_GRPID", Convert.ToString(grid1.Rows[i].Cells["GRPID"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_OPCODE", Convert.ToString(grid1.Rows[i].Cells["OPCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WORKCENTERCODE", Convert.ToString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_DEPTCODE", Convert.ToString(grid1.Rows[i].Cells["DEPTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_TEAMCODE", Convert.ToString(grid1.Rows[i].Cells["TEAMCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_BANCODE", Convert.ToString(grid1.Rows[i].Cells["BANCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_CLASSCODE", Convert.ToString(grid1.Rows[i].Cells["CLASSCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_DAYNIGHT", Convert.ToString(grid1.Rows[i].Cells["DAYNIGHT"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_SHIFTGB", Convert.ToString(grid1.Rows[i].Cells["SHIFTGB"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_EMPNO", Convert.ToString(grid1.Rows[i].Cells["EMPNO"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_EMPTELNO", Convert.ToString(grid1.Rows[i].Cells["EMPTELNO"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_INDATE", Convert.ToString(grid1.Rows[i].Cells["INDATE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_OUTDATE", Convert.ToString(grid1.Rows[i].Cells["OUTDATE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_LANG", Convert.ToString(grid1.Rows[i].Cells["LANG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_MAILID", Convert.ToString(grid1.Rows[i].Cells["MAILID"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PHONENO", Convert.ToString(grid1.Rows[i].Cells["PHONENO"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_SYSFLAG", Convert.ToString(grid1.Rows[i].Cells["SYSFLAG"].Value), DbType.String, ParameterDirection.Input)
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
                        helper.ExecuteNoneQuery("USP_BM0020_EXCEL_I1", CommandType.StoredProcedure
                                                 , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_WORKERID", Convert.ToString(grid1.Rows[i].Cells["WORKERID"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_WORKERNAME", Convert.ToString(grid1.Rows[i].Cells["WORKERNAME"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_PASSWORD", Convert.ToString(grid1.Rows[i].Cells["PASSWORD"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_GRPID", Convert.ToString(grid1.Rows[i].Cells["GRPID"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_OPCODE", Convert.ToString(grid1.Rows[i].Cells["OPCODE"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_WORKCENTERCODE", Convert.ToString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_DEPTCODE", Convert.ToString(grid1.Rows[i].Cells["DEPTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_TEAMCODE", Convert.ToString(grid1.Rows[i].Cells["TEAMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_BANCODE", Convert.ToString(grid1.Rows[i].Cells["BANCODE"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_CLASSCODE", Convert.ToString(grid1.Rows[i].Cells["CLASSCODE"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_DAYNIGHT", Convert.ToString(grid1.Rows[i].Cells["DAYNIGHT"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_SHIFTGB", Convert.ToString(grid1.Rows[i].Cells["SHIFTGB"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_EMPNO", Convert.ToString(grid1.Rows[i].Cells["EMPNO"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_EMPTELNO", Convert.ToString(grid1.Rows[i].Cells["EMPTELNO"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_INDATE", Convert.ToString(grid1.Rows[i].Cells["INDATE"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_OUTDATE", Convert.ToString(grid1.Rows[i].Cells["OUTDATE"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_LANG", Convert.ToString(grid1.Rows[i].Cells["LANG"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_MAILID", Convert.ToString(grid1.Rows[i].Cells["MAILID"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_PHONENO", Convert.ToString(grid1.Rows[i].Cells["PHONENO"].Value), DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_SYSFLAG", Convert.ToString(grid1.Rows[i].Cells["SYSFLAG"].Value), DbType.String, ParameterDirection.Input)
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
                    for (int i = 1; i < dtExcelImport.Rows.Count; i++)
                    {
                        DataRow drTarget = dtTarget.NewRow();

                        drTarget["PLANTCODE"] = Convert.ToString(dtExcelImport.Rows[i][0]);
                        drTarget["WORKERID"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["WORKERNAME"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["DEPTCODE"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["PASSWORD"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["GRPID"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["OPCODE"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["WORKCENTERCODE"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["TEAMCODE"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["BANCODE"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        drTarget["CLASSCODE"] = Convert.ToString(dtExcelImport.Rows[i][10]);
                        drTarget["DAYNIGHT"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                        drTarget["SHIFTGB"] = Convert.ToString(dtExcelImport.Rows[i][12]);
                        drTarget["EMPNO"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        drTarget["EMPTELNO"] = Convert.ToString(dtExcelImport.Rows[i][14]);
                        drTarget["INDATE"] = Convert.ToString(dtExcelImport.Rows[i][15]);
                        drTarget["OUTDATE"] = Convert.ToString(dtExcelImport.Rows[i][16]);
                        drTarget["LANG"] = Convert.ToString(dtExcelImport.Rows[i][17]);
                        drTarget["MAILID"] = Convert.ToString(dtExcelImport.Rows[i][18]);
                        drTarget["PHONENO"] = Convert.ToString(dtExcelImport.Rows[i][19]);
                        drTarget["SYSFLAG"] = Convert.ToString(dtExcelImport.Rows[i][20]);
                        drTarget["USEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][21]).Trim();
                        drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][22]);

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

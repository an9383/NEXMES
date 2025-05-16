using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class BM0630_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public BM0630_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void BM0630_EXCEL_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WRKTYPECODE", "근무형태코드", true, GridColDataType_emu.VarChar, 130, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WRKSTIME", "작업시작시간", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WRKETIME", "작업종료시간", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WRKHOURS", "작업시간", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP1STIME", "계획정지 시작 #1", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP1ETIME", "계획정지 종료 #1", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP1HOURS", "계획정지 시간 #1", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP2STIME", "계획정지 시작 #2", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP2ETIME", "계획정지 종료 #2", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP2HOURS", "계획정지 시간 #2", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP3STIME", "계획정지 시작 #3", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP3ETIME", "계획정지 종료 #3", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP3HOURS", "계획정지 시간 #3", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP4STIME", "계획정지 시작 #4", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP4ETIME", "계획정지 종료 #4", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP4HOURS", "계획정지 시간 #4", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP5STIME", "계획정지 시작 #5", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP5ETIME", "계획정지 종료 #5", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP5HOURS", "계획정지 시간 #5", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP6STIME", "계획정지 시작 #6", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP6ETIME", "계획정지 종료 #6", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP6HOURS", "계획정지 시간 #6", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP7STIME", "계획정지 시작 #7", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP7ETIME", "계획정지 종료 #7", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP7HOURS", "계획정지 시간 #7", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP8STIME", "계획정지 시작 #8", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP8ETIME", "계획정지 종료 #8", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP8HOURS", "계획정지 시간 #8", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP9STIME", "계획정지 시작 #9", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP9ETIME", "계획정지 종료 #9", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STOP9HOURS", "계획정지 시간 #9", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "OTSTIME", "잔업 시작 시간", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "OTETIME", "잔업 종료 시간", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "OTHOURS", "잔업 시간", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTALSTIME", "전체작업\r\n시작시간", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTALETIME", "전체작업\r\n종료시간", true, GridColDataType_emu.Time24WithSpin, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTALHOURS", "전체\r\n작업시간", true, GridColDataType_emu.Integer, 80, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, true, true);

            _GridUtil.SetInitUltraGridBind(grid1);


            //필수입력 항목에 대한 음영
            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["WRKTYPECODE"].Header.Appearance.ForeColor = Color.SkyBlue;


            _GridUtil.SetColumnTextHAlign(grid1, "WRKTYPECODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "REMARK", Infragistics.Win.HAlign.Left);

            _GridUtil.SetColumnTextHAlign(grid1, "WRKHOURS", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "STOP1HOURS", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "STOP2HOURS", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "STOP3HOURS", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "STOP4HOURS", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "STOP5HOURS", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "STOP6HOURS", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "STOP7HOURS", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "STOP8HOURS", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "STOP9HOURS", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "OTHOURS", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "TOTALHOURS", Infragistics.Win.HAlign.Right);



            #region COMBOBOX SETTING
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WRKTYPECODE"); //근무형태코드  
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WRKTYPECODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
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
            string sWrktypeCode = string.Empty;
            string sWrksTime = string.Empty;
            string sWrkeTIME = string.Empty;
            string sWrkHours = string.Empty;
            string sStop1sTime = string.Empty;
            string sStop1eTime = string.Empty;
            string sStop1Hours = string.Empty;
            string sStop2sTime = string.Empty;
            string sStop2eTime = string.Empty;
            string sStop2Hours = string.Empty;
            string sStop3sTime = string.Empty;
            string sStop3eTime = string.Empty;
            string sStop3Hours = string.Empty;
            string sStop4sTime = string.Empty;
            string sStop4eTime = string.Empty;
            string sStop4Hours = string.Empty;
            string sStop5sTime = string.Empty;
            string sStop5eTime = string.Empty;
            string sStop5Hours = string.Empty;
            string sStop6sTime = string.Empty;
            string sStop6eTime = string.Empty;
            string sStop6Hours = string.Empty;
            string sStop7sTime = string.Empty;
            string sStop7eTime = string.Empty;
            string sStop7Hours = string.Empty;
            string sStop8sTime = string.Empty;
            string sStop8eTime = string.Empty;
            string sStop8Hours = string.Empty;
            string sStop9sTime = string.Empty;
            string sStop9eTime = string.Empty;
            string sStop9Hours = string.Empty;
            string sOtsTime = string.Empty;
            string sOteTime = string.Empty;
            string sOtHours = string.Empty;
            string sTotalsTime = string.Empty;
            string sTotaleTime = string.Empty;
            string sTotalHours = string.Empty;



            string excelUploadType = string.Empty;

            int iOK = 0;
            int iNG = 0;

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    sPlantCode = Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value);
                    sWrktypeCode = Convert.ToString(grid1.Rows[i].Cells["WRKTYPECODE"].Value);

                    if (sPlantCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.", "MSG"));
                        return;
                    }
                    if (sWrktypeCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 근무형태코드를 확인하세요.", "MSG"));
                        return;
                    }

                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "BM0630", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_BM0630_EXCEL_I1", CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WRKTYPECODE", Convert.ToString(grid1.Rows[i].Cells["WRKTYPECODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WRKSTIME", Convert.ToString(grid1.Rows[i].Cells["WRKSTIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WRKETIME", Convert.ToString(grid1.Rows[i].Cells["WRKETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_WRKHOURS", Convert.ToString(grid1.Rows[i].Cells["WRKHOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP1STIME", Convert.ToString(grid1.Rows[i].Cells["STOP1STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP1ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP1ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP1HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP1HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP2STIME", Convert.ToString(grid1.Rows[i].Cells["STOP2STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP2ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP2ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP2HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP2HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP3STIME", Convert.ToString(grid1.Rows[i].Cells["STOP3STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP3ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP3ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP3HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP3HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP4STIME", Convert.ToString(grid1.Rows[i].Cells["STOP4STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP4ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP4ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP4HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP4HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP5STIME", Convert.ToString(grid1.Rows[i].Cells["STOP5STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP5ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP5ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP5HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP5HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP6STIME", Convert.ToString(grid1.Rows[i].Cells["STOP6STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP6ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP6ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP6HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP6HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP7STIME", Convert.ToString(grid1.Rows[i].Cells["STOP7STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP7ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP7ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP7HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP7HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP8STIME", Convert.ToString(grid1.Rows[i].Cells["STOP8STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP8ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP8ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP8HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP8HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP9STIME", Convert.ToString(grid1.Rows[i].Cells["STOP9STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP9ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP9ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP9HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP9HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_OTSTIME", Convert.ToString(grid1.Rows[i].Cells["OTSTIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_OTETIME", Convert.ToString(grid1.Rows[i].Cells["OTETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_OTHOURS", Convert.ToString(grid1.Rows[i].Cells["OTHOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_TOTALSTIME", Convert.ToString(grid1.Rows[i].Cells["TOTALSTIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_TOTALETIME", Convert.ToString(grid1.Rows[i].Cells["TOTALETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_TOTALHOURS", Convert.ToString(grid1.Rows[i].Cells["TOTALHOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_REMARK", Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
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
                        helper.ExecuteNoneQuery("USP_BM0630_EXCEL_I1", CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WRKTYPECODE", Convert.ToString(grid1.Rows[i].Cells["WRKTYPECODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WRKSTIME", Convert.ToString(grid1.Rows[i].Cells["WRKSTIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WRKETIME", Convert.ToString(grid1.Rows[i].Cells["WRKETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_WRKHOURS", Convert.ToString(grid1.Rows[i].Cells["WRKHOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP1STIME", Convert.ToString(grid1.Rows[i].Cells["STOP1STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP1ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP1ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP1HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP1HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP2STIME", Convert.ToString(grid1.Rows[i].Cells["STOP2STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP2ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP2ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP2HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP2HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP3STIME", Convert.ToString(grid1.Rows[i].Cells["STOP3STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP3ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP3ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP3HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP3HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP4STIME", Convert.ToString(grid1.Rows[i].Cells["STOP4STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP4ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP4ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP4HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP4HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP5STIME", Convert.ToString(grid1.Rows[i].Cells["STOP5STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP5ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP5ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP5HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP5HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP6STIME", Convert.ToString(grid1.Rows[i].Cells["STOP6STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP6ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP6ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP6HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP6HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP7STIME", Convert.ToString(grid1.Rows[i].Cells["STOP7STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP7ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP7ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP7HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP7HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP8STIME", Convert.ToString(grid1.Rows[i].Cells["STOP8STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP8ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP8ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP8HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP8HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP9STIME", Convert.ToString(grid1.Rows[i].Cells["STOP9STIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STOP9ETIME", Convert.ToString(grid1.Rows[i].Cells["STOP9ETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_STOP9HOURS", Convert.ToString(grid1.Rows[i].Cells["STOP9HOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_OTSTIME", Convert.ToString(grid1.Rows[i].Cells["OTSTIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_OTETIME", Convert.ToString(grid1.Rows[i].Cells["OTETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_OTHOURS", Convert.ToString(grid1.Rows[i].Cells["OTHOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_TOTALSTIME", Convert.ToString(grid1.Rows[i].Cells["TOTALSTIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_TOTALETIME", Convert.ToString(grid1.Rows[i].Cells["TOTALETIME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AF_TOTALHOURS", Convert.ToString(grid1.Rows[i].Cells["TOTALHOURS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_REMARK", Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
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
                        drTarget["WRKTYPECODE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["WRKSTIME"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["WRKETIME"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["WRKHOURS"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["STOP1STIME"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["STOP1ETIME"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["STOP1HOURS"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["STOP2STIME"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["STOP2ETIME"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        drTarget["STOP2HOURS"] = Convert.ToString(dtExcelImport.Rows[i][10]);
                        drTarget["STOP3STIME"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                        drTarget["STOP3ETIME"] = Convert.ToString(dtExcelImport.Rows[i][12]);
                        drTarget["STOP3HOURS"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        drTarget["STOP4STIME"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        drTarget["STOP4ETIME"] = Convert.ToString(dtExcelImport.Rows[i][14]);
                        drTarget["STOP4HOURS"] = Convert.ToString(dtExcelImport.Rows[i][15]);
                        drTarget["STOP5STIME"] = Convert.ToString(dtExcelImport.Rows[i][16]);
                        drTarget["STOP5ETIME"] = Convert.ToString(dtExcelImport.Rows[i][17]);
                        drTarget["STOP5HOURS"] = Convert.ToString(dtExcelImport.Rows[i][18]);
                        drTarget["STOP6STIME"] = Convert.ToString(dtExcelImport.Rows[i][19]);
                        drTarget["STOP6ETIME"] = Convert.ToString(dtExcelImport.Rows[i][20]);
                        drTarget["STOP6HOURS"] = Convert.ToString(dtExcelImport.Rows[i][21]);
                        drTarget["STOP7STIME"] = Convert.ToString(dtExcelImport.Rows[i][22]);
                        drTarget["STOP7ETIME"] = Convert.ToString(dtExcelImport.Rows[i][23]);
                        drTarget["STOP7HOURS"] = Convert.ToString(dtExcelImport.Rows[i][24]);
                        drTarget["STOP8STIME"] = Convert.ToString(dtExcelImport.Rows[i][25]);
                        drTarget["STOP8ETIME"] = Convert.ToString(dtExcelImport.Rows[i][26]);
                        drTarget["STOP8HOURS"] = Convert.ToString(dtExcelImport.Rows[i][27]);
                        drTarget["STOP9STIME"] = Convert.ToString(dtExcelImport.Rows[i][28]);
                        drTarget["STOP9ETIME"] = Convert.ToString(dtExcelImport.Rows[i][29]);
                        drTarget["STOP9HOURS"] = Convert.ToString(dtExcelImport.Rows[i][30]);
                        drTarget["OTSTIME"] = Convert.ToString(dtExcelImport.Rows[i][31]);
                        drTarget["OTETIME"] = Convert.ToString(dtExcelImport.Rows[i][32]);
                        drTarget["OTHOURS"] = Convert.ToString(dtExcelImport.Rows[i][33]);
                        drTarget["TOTALSTIME"] = Convert.ToString(dtExcelImport.Rows[i][34]);
                        drTarget["TOTALETIME"] = Convert.ToString(dtExcelImport.Rows[i][35]);
                        drTarget["TOTALHOURS"] = Convert.ToString(dtExcelImport.Rows[i][36]);

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

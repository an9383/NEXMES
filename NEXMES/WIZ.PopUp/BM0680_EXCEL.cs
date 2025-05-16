using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class BM0680_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public BM0680_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void BM0680_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //GRID1

            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "금형코드", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDNAME", "금형명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDTYPE", "금형타입", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDTYPE1", "분류1", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDTYPE2", "분류2", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDWH", "창고코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDWHNAME", "창고명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDLOC", "위치코드", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDLOCNAME", "위치명", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKECOMPANY", "제조사", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MODELNAME", "모델명", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "SERIALNO", "시리얼번호", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "LIFETIME", "수명", true, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CONTACT", "연락처", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWORKER1", "작업담당자1", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWORKER2", "작업담당자2", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TECHWORKER", "장비기술담당자", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "BUYDATE", "도입일자", true, GridColDataType_emu.YearMonthDay, 120, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "BUYCOST", "도입가격", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "상태", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPLASTDATE", "최종검사일자", true, GridColDataType_emu.YearMonthDay, 120, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "LIMITDATE", "유효일자", true, GridColDataType_emu.YearMonthDay, 120, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CAVITY", "CAVITY", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "DESIGNSHOT", "설계쇼트수", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "OVERMNGCNT", "관리쇼트수", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDSUMCNT", "누적쇼트수", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDUSECNT", "현재쇼트수", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true);

            //필수입력 항목에 대한 음영
            grid1.DisplayLayout.Bands[0].Columns["MOLDCODE"].Header.Appearance.ForeColor = Color.SkyBlue;

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region [ Combo Box ]
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            BizGridManager gridManager = new BizGridManager(grid1); //그리드 콤보박스 객체 생성
            gridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "", "", "Y" });

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
            string sMoldCode = string.Empty;
            string sMoldName = string.Empty;
            string sItemCode = string.Empty;
            string sMachCode = string.Empty;
            string sMoldType = string.Empty;
            string sMoldType1 = string.Empty;
            string sMoldType2 = string.Empty;
            string sMoldWh = string.Empty;
            string sMoldLoc = string.Empty;
            string sCustCode = string.Empty;
            string sMakeCompany = string.Empty;
            string sModelName = string.Empty;
            string sSerialNo = string.Empty;
            string sLifeTime = string.Empty;
            string sContact = string.Empty;
            string sMaWorker1 = string.Empty;
            string sMaWorker2 = string.Empty;
            string sTechWorker = string.Empty;
            string sBuyDate = string.Empty;
            string sBuyCost = string.Empty;
            string sStatus = string.Empty;
            string sInspLastDate = string.Empty;
            string sLimitDate = string.Empty;
            string sCavity = string.Empty;
            string sDesignShot = string.Empty;
            string sOverMngCnt = string.Empty;
            string sMoldSumCnt = string.Empty;
            string sMoldUseCnt = string.Empty;
            string sUseFlag = string.Empty;
            string sRemark = string.Empty;

            string excelUploadType = string.Empty;

            int iOK = 0;
            int iNG = 0;

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    sPlantCode = LoginInfo.PlantCode;
                    sMoldCode = Convert.ToString(grid1.Rows[i].Cells["MOLDCODE"].Value);
                    sMoldName = Convert.ToString(grid1.Rows[i].Cells["MOLDNAME"].Value);
                    sItemCode = Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value);
                    sMachCode = Convert.ToString(grid1.Rows[i].Cells["MACHCODE"].Value);
                    sMoldType = Convert.ToString(grid1.Rows[i].Cells["MOLDTYPE"].Value);
                    sMoldType1 = Convert.ToString(grid1.Rows[i].Cells["MOLDTYPE1"].Value);
                    sMoldType2 = Convert.ToString(grid1.Rows[i].Cells["MOLDTYPE2"].Value);
                    sMoldWh = Convert.ToString(grid1.Rows[i].Cells["MOLDWH"].Value);
                    sMoldLoc = Convert.ToString(grid1.Rows[i].Cells["MOLDLOC"].Value);
                    sCustCode = Convert.ToString(grid1.Rows[i].Cells["CUSTCODE"].Value);
                    sMakeCompany = Convert.ToString(grid1.Rows[i].Cells["MAKECOMPANY"].Value);
                    sModelName = Convert.ToString(grid1.Rows[i].Cells["MODELNAME"].Value);
                    sSerialNo = Convert.ToString(grid1.Rows[i].Cells["SERIALNO"].Value);
                    sLifeTime = Convert.ToString(grid1.Rows[i].Cells["LIFETIME"].Value);
                    sContact = Convert.ToString(grid1.Rows[i].Cells["CONTACT"].Value);
                    sMaWorker1 = Convert.ToString(grid1.Rows[i].Cells["MAWORKER1"].Value);
                    sMaWorker2 = Convert.ToString(grid1.Rows[i].Cells["MAWORKER2"].Value);
                    sTechWorker = Convert.ToString(grid1.Rows[i].Cells["TECHWORKER"].Value);
                    sBuyDate = Convert.ToString(grid1.Rows[i].Cells["BUYDATE"].Value);
                    sBuyCost = Convert.ToString(grid1.Rows[i].Cells["BUYCOST"].Value);
                    sStatus = Convert.ToString(grid1.Rows[i].Cells["STATUS"].Value);
                    sInspLastDate = Convert.ToString(grid1.Rows[i].Cells["INSPLASTDATE"].Value);
                    sLimitDate = Convert.ToString(grid1.Rows[i].Cells["LIMITDATE"].Value);
                    sCavity = Convert.ToString(grid1.Rows[i].Cells["CAVITY"].Value);
                    sDesignShot = Convert.ToString(grid1.Rows[i].Cells["DESIGNSHOT"].Value);
                    sOverMngCnt = Convert.ToString(grid1.Rows[i].Cells["OVERMNGCNT"].Value);
                    sMoldSumCnt = Convert.ToString(grid1.Rows[i].Cells["MOLDSUMCNT"].Value);
                    sMoldUseCnt = Convert.ToString(grid1.Rows[i].Cells["MOLDUSECNT"].Value);
                    sUseFlag = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);
                    sRemark = Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value);

                    if (sMoldCode == string.Empty)// || plantcode.Length != 2) // || getvalues("PLANTCODE",plantcode) == false)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 금형코드를 확인하세요.", "MSG"));
                        return;
                    }
                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "BM0680", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_BM0680_EXCEL_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDCODE", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDNAME", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDNAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHCODE", DBHelper.nvlString(grid1.Rows[i].Cells["MACHCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDTYPE", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDTYPE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDTYPE1", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDTYPE1"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDTYPE2", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDTYPE2"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDWH", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDWH"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDLOC", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDLOC"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTCODE", DBHelper.nvlString(grid1.Rows[i].Cells["CUSTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKECOMPANY", DBHelper.nvlString(grid1.Rows[i].Cells["MAKECOMPANY"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MODELNAME", DBHelper.nvlString(grid1.Rows[i].Cells["MODELNAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SERIALNO", DBHelper.nvlString(grid1.Rows[i].Cells["SERIALNO"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LIFETIME", DBHelper.nvlString(grid1.Rows[i].Cells["LIFETIME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CONTACT", DBHelper.nvlString(grid1.Rows[i].Cells["CONTACT"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER1", DBHelper.nvlString(grid1.Rows[i].Cells["MAWORKER1"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER2", DBHelper.nvlString(grid1.Rows[i].Cells["MAWORKER2"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TECHWORKER", DBHelper.nvlString(grid1.Rows[i].Cells["TECHWORKER"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BUYDATE", DBHelper.nvlString(grid1.Rows[i].Cells["BUYDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BUYCOST", DBHelper.nvlString(grid1.Rows[i].Cells["BUYCOST"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STATUS", DBHelper.nvlString(grid1.Rows[i].Cells["STATUS"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPLASTDATE", DBHelper.nvlString(grid1.Rows[i].Cells["INSPLASTDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LIMITDATE", DBHelper.nvlString(grid1.Rows[i].Cells["LIMITDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CAVITY", DBHelper.nvlString(grid1.Rows[i].Cells["CAVITY"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DESIGNSHOT", DBHelper.nvlString(grid1.Rows[i].Cells["DESIGNSHOT"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OVERMNGCNT", DBHelper.nvlString(grid1.Rows[i].Cells["OVERMNGCNT"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDSUMCNT", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDSUMCNT"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDUSECNT", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDUSECNT"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(grid1.Rows[i].Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(grid1.Rows[i].Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));


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
                        helper.ExecuteNoneQuery("USP_BM0680_EXCEL_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDCODE", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDNAME", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDNAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHCODE", DBHelper.nvlString(grid1.Rows[i].Cells["MACHCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDTYPE", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDTYPE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDTYPE1", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDTYPE1"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDTYPE2", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDTYPE2"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDWH", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDWH"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDLOC", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDLOC"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTCODE", DBHelper.nvlString(grid1.Rows[i].Cells["CUSTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKECOMPANY", DBHelper.nvlString(grid1.Rows[i].Cells["MAKECOMPANY"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MODELNAME", DBHelper.nvlString(grid1.Rows[i].Cells["MODELNAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SERIALNO", DBHelper.nvlString(grid1.Rows[i].Cells["SERIALNO"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LIFETIME", DBHelper.nvlString(grid1.Rows[i].Cells["LIFETIME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CONTACT", DBHelper.nvlString(grid1.Rows[i].Cells["CONTACT"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER1", DBHelper.nvlString(grid1.Rows[i].Cells["MAWORKER1"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER2", DBHelper.nvlString(grid1.Rows[i].Cells["MAWORKER2"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TECHWORKER", DBHelper.nvlString(grid1.Rows[i].Cells["TECHWORKER"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BUYDATE", DBHelper.nvlString(grid1.Rows[i].Cells["BUYDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BUYCOST", DBHelper.nvlString(grid1.Rows[i].Cells["BUYCOST"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STATUS", DBHelper.nvlString(grid1.Rows[i].Cells["STATUS"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPLASTDATE", DBHelper.nvlString(grid1.Rows[i].Cells["INSPLASTDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LIMITDATE", DBHelper.nvlString(grid1.Rows[i].Cells["LIMITDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CAVITY", DBHelper.nvlString(grid1.Rows[i].Cells["CAVITY"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DESIGNSHOT", DBHelper.nvlString(grid1.Rows[i].Cells["DESIGNSHOT"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OVERMNGCNT", DBHelper.nvlString(grid1.Rows[i].Cells["OVERMNGCNT"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDSUMCNT", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDSUMCNT"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDUSECNT", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDUSECNT"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(grid1.Rows[i].Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(grid1.Rows[i].Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

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

                        drTarget["MOLDCODE"] = Convert.ToString(dtExcelImport.Rows[i][0]);
                        drTarget["MOLDNAME"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["ITEMCODE"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["ITEMNAME"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["MACHCODE"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["MACHNAME"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["MOLDTYPE"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["MOLDTYPE1"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["MOLDTYPE2"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["MOLDWH"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        drTarget["MOLDWHNAME"] = Convert.ToString(dtExcelImport.Rows[i][10]);
                        drTarget["MOLDLOC"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                        drTarget["MOLDLOCNAME"] = Convert.ToString(dtExcelImport.Rows[i][12]);
                        drTarget["CUSTCODE"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        drTarget["CUSTNAME"] = Convert.ToString(dtExcelImport.Rows[i][14]);
                        drTarget["MAKECOMPANY"] = Convert.ToString(dtExcelImport.Rows[i][15]);
                        drTarget["MODELNAME"] = Convert.ToString(dtExcelImport.Rows[i][16]);
                        drTarget["SERIALNO"] = Convert.ToString(dtExcelImport.Rows[i][17]);
                        drTarget["LIFETIME"] = Convert.ToString(dtExcelImport.Rows[i][18]);
                        drTarget["CONTACT"] = Convert.ToString(dtExcelImport.Rows[i][19]);
                        drTarget["MAWORKER1"] = Convert.ToString(dtExcelImport.Rows[i][20]);
                        drTarget["MAWORKER2"] = Convert.ToString(dtExcelImport.Rows[i][21]);
                        drTarget["TECHWORKER"] = Convert.ToString(dtExcelImport.Rows[i][22]);
                        drTarget["BUYDATE"] = Convert.ToString(dtExcelImport.Rows[i][23]);
                        drTarget["BUYCOST"] = Convert.ToString(dtExcelImport.Rows[i][24]);
                        drTarget["STATUS"] = Convert.ToString(dtExcelImport.Rows[i][25]);
                        drTarget["INSPLASTDATE"] = Convert.ToString(dtExcelImport.Rows[i][26]);
                        drTarget["LIMITDATE"] = Convert.ToString(dtExcelImport.Rows[i][27]);
                        drTarget["CAVITY"] = Convert.ToString(dtExcelImport.Rows[i][28]);
                        drTarget["DESIGNSHOT"] = Convert.ToString(dtExcelImport.Rows[i][29]);
                        drTarget["OVERMNGCNT"] = Convert.ToString(dtExcelImport.Rows[i][30]);
                        drTarget["MOLDSUMCNT"] = Convert.ToString(dtExcelImport.Rows[i][31]);
                        drTarget["MOLDUSECNT"] = Convert.ToString(dtExcelImport.Rows[i][32]);
                        drTarget["USEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][33]);
                        drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][34]);

                        if (Convert.ToString(drTarget["USEFLAG"]) == "")
                        {
                            drTarget["USEFLAG"] = "Y";
                        };

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
            _GridUtil.ExportExcel(grid1);
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

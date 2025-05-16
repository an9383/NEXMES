using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class BM0070_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public BM0070_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void BM0070_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //GRID1 품목

            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHTYPE", "설비타입", true, GridColDataType_emu.VarChar, 100, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODFLAG", "실적수집장비여부", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKECOMPANY", "제조사", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MODELNAME", "모델명", true, GridColDataType_emu.VarChar, 140, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SERIALNO", "시리얼번호", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LIFETIME", "수명", true, GridColDataType_emu.Integer, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CONTACT", "연락처", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHCASE", "설비구분", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHLOC", "설치장소", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWORKER1", "작업담당자-정", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWORKER2", "작업담당자-부", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TECHWORKER", "장비기술담당자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BUYDATE", "도입일자", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BUYCOST", "도입가격", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "상태", true, GridColDataType_emu.VarChar, 80, 10, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPLASTDATE", "최종검사일자", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LIMITDATE", "유효일수", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CAVITY", "CAVITY", true, GridColDataType_emu.Integer, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DESIGNSHOT", "디자인쇼트", true, GridColDataType_emu.Integer, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKSHOT", "작업쇼트", true, GridColDataType_emu.Integer, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTSHOT", "전체쇼트", true, GridColDataType_emu.Integer, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDUSECNT", "금형사용횟수", true, GridColDataType_emu.Integer, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LASTUSEDATE", "최종사용일자", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "FAILURFLAG", "고장실적등록가능유무", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCYCLE", "설비점검주기", true, GridColDataType_emu.Integer, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ALRAMCYCLE", "점검알람주기", true, GridColDataType_emu.Integer, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 90, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            //필수입력 항목에 대한 음영
            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;

            #endregion

            #region [ Combo Box ]
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MACHTYPE"); //설비타입
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MACHTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
            string sMachName = string.Empty;
            string sMachType = string.Empty;
            string sWorkcenterCode = string.Empty;
            string sProdFlag = string.Empty;
            string sMakeCompany = string.Empty;
            string sModelName = string.Empty;
            string sSerialNo = string.Empty;
            string sLifeTime = string.Empty;
            string sContact = string.Empty;
            string sMachCase = string.Empty;
            string sMachLoc = string.Empty;
            string sMaWorker1 = string.Empty;
            string sMaWorker2 = string.Empty;
            string sTechWorker = string.Empty;
            string sBuyDate = string.Empty;
            string sBuyCost = string.Empty;
            string sStatus = string.Empty;
            string sInsplastDate = string.Empty;
            string sLimitDate = string.Empty;
            string sCavity = string.Empty;
            string sDesignShot = string.Empty;
            string sWorkShot = string.Empty;
            string sTotShot = string.Empty;
            string sMolduseCnt = string.Empty;
            string sLastUseDate = string.Empty;
            string sFailUrFlag = string.Empty;
            string sInspCycle = string.Empty;
            string sAlramCycle = string.Empty;
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
                    sMachName = Convert.ToString(grid1.Rows[i].Cells["MACHNAME"].Value);
                    sMachType = Convert.ToString(grid1.Rows[i].Cells["MACHTYPE"].Value);
                    sWorkcenterCode = Convert.ToString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value);
                    sProdFlag = Convert.ToString(grid1.Rows[i].Cells["PRODFLAG"].Value);
                    sMakeCompany = Convert.ToString(grid1.Rows[i].Cells["MAKECOMPANY"].Value);
                    sModelName = Convert.ToString(grid1.Rows[i].Cells["MODELNAME"].Value);
                    sSerialNo = Convert.ToString(grid1.Rows[i].Cells["SERIALNO"].Value);
                    sLifeTime = Convert.ToString(grid1.Rows[i].Cells["LIFETIME"].Value);
                    sContact = Convert.ToString(grid1.Rows[i].Cells["CONTACT"].Value);
                    sMachCase = Convert.ToString(grid1.Rows[i].Cells["MACHCASE"].Value);
                    sMachLoc = Convert.ToString(grid1.Rows[i].Cells["MACHLOC"].Value);
                    sMaWorker1 = Convert.ToString(grid1.Rows[i].Cells["MAWORKER1"].Value);
                    sMaWorker2 = Convert.ToString(grid1.Rows[i].Cells["MAWORKER2"].Value);
                    sTechWorker = Convert.ToString(grid1.Rows[i].Cells["TECHWORKER"].Value);
                    sBuyDate = Convert.ToString(grid1.Rows[i].Cells["BUYDATE"].Value);
                    sBuyCost = Convert.ToString(grid1.Rows[i].Cells["BUYCOST"].Value);
                    sStatus = Convert.ToString(grid1.Rows[i].Cells["STATUS"].Value);
                    sInsplastDate = Convert.ToString(grid1.Rows[i].Cells["INSPLASTDATE"].Value);
                    sLimitDate = Convert.ToString(grid1.Rows[i].Cells["LIMITDATE"].Value);
                    sCavity = Convert.ToString(grid1.Rows[i].Cells["CAVITY"].Value);
                    sDesignShot = Convert.ToString(grid1.Rows[i].Cells["DESIGNSHOT"].Value);
                    sWorkShot = Convert.ToString(grid1.Rows[i].Cells["WORKSHOT"].Value);
                    sTotShot = Convert.ToString(grid1.Rows[i].Cells["TOTSHOT"].Value);
                    sMolduseCnt = Convert.ToString(grid1.Rows[i].Cells["MOLDUSECNT"].Value);
                    sLastUseDate = Convert.ToString(grid1.Rows[i].Cells["LASTUSEDATE"].Value);
                    sFailUrFlag = Convert.ToString(grid1.Rows[i].Cells["FAILURFLAG"].Value);
                    sInspCycle = Convert.ToString(grid1.Rows[i].Cells["INSPCYCLE"].Value);
                    sAlramCycle = Convert.ToString(grid1.Rows[i].Cells["ALRAMCYCLE"].Value);
                    sRemark = Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value);
                    sUseFlag = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);

                    if (sPlantCode == string.Empty)// || plantcode.Length != 2) // || getvalues("PLANTCODE",plantcode) == false)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.", "MSG"));
                        return;
                    }
                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "BM0070", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_BM0070_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHNAME", DBHelper.nvlString(grid1.Rows[i].Cells["MACHNAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHTYPE", DBHelper.nvlString(grid1.Rows[i].Cells["MACHTYPE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PRODFLAG", DBHelper.nvlString(grid1.Rows[i].Cells["PRODFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKECOMPANY", DBHelper.nvlString(grid1.Rows[i].Cells["MAKECOMPANY"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MODELNAME", DBHelper.nvlString(grid1.Rows[i].Cells["MODELNAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SERIALNO", DBHelper.nvlString(grid1.Rows[i].Cells["SERIALNO"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_LIFETIME", DBHelper.nvlString(grid1.Rows[i].Cells["LIFETIME"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CONTACT", DBHelper.nvlString(grid1.Rows[i].Cells["CONTACT"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHCASE", DBHelper.nvlString(grid1.Rows[i].Cells["MACHCASE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHLOC", DBHelper.nvlString(grid1.Rows[i].Cells["MACHLOC"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER1", DBHelper.nvlString(grid1.Rows[i].Cells["MAWORKER1"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER2", DBHelper.nvlString(grid1.Rows[i].Cells["MAWORKER2"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TECHWORKER", DBHelper.nvlString(grid1.Rows[i].Cells["TECHWORKER"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BUYDATE", DBHelper.nvlString(grid1.Rows[i].Cells["BUYDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_BUYCOST", DBHelper.nvlString(grid1.Rows[i].Cells["BUYCOST"].Value), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STATUS", DBHelper.nvlString(grid1.Rows[i].Cells["STATUS"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPLASTDATE", DBHelper.nvlString(grid1.Rows[i].Cells["INSPLASTDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LIMITDATE", DBHelper.nvlString(grid1.Rows[i].Cells["LIMITDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_CAVITY", DBHelper.nvlString(grid1.Rows[i].Cells["CAVITY"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_DESIGNSHOT", DBHelper.nvlString(grid1.Rows[i].Cells["DESIGNSHOT"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_WORKSHOT", DBHelper.nvlString(grid1.Rows[i].Cells["WORKSHOT"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_TOTSHOT", DBHelper.nvlString(grid1.Rows[i].Cells["TOTSHOT"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_MOLDUSECNT", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDUSECNT"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LASTUSEDATE", DBHelper.nvlString(grid1.Rows[i].Cells["LASTUSEDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_FAILURFLAG", DBHelper.nvlString(grid1.Rows[i].Cells["FAILURFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_INSPCYCLE", DBHelper.nvlString(grid1.Rows[i].Cells["INSPCYCLE"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_ALRAMCYCLE", DBHelper.nvlString(grid1.Rows[i].Cells["ALRAMCYCLE"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(grid1.Rows[i].Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(grid1.Rows[i].Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DateTime.Now, DbType.DateTime, ParameterDirection.Input)); ;


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
                        helper.ExecuteNoneQuery("USP_BM0070_I1"
                                                  , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHNAME", DBHelper.nvlString(grid1.Rows[i].Cells["MACHNAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHTYPE", DBHelper.nvlString(grid1.Rows[i].Cells["MACHTYPE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PRODFLAG", DBHelper.nvlString(grid1.Rows[i].Cells["PRODFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKECOMPANY", DBHelper.nvlString(grid1.Rows[i].Cells["MAKECOMPANY"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MODELNAME", DBHelper.nvlString(grid1.Rows[i].Cells["MODELNAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SERIALNO", DBHelper.nvlString(grid1.Rows[i].Cells["SERIALNO"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_LIFETIME", DBHelper.nvlString(grid1.Rows[i].Cells["LIFETIME"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CONTACT", DBHelper.nvlString(grid1.Rows[i].Cells["CONTACT"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHCASE", DBHelper.nvlString(grid1.Rows[i].Cells["MACHCASE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHLOC", DBHelper.nvlString(grid1.Rows[i].Cells["MACHLOC"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER1", DBHelper.nvlString(grid1.Rows[i].Cells["MAWORKER1"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER2", DBHelper.nvlString(grid1.Rows[i].Cells["MAWORKER2"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TECHWORKER", DBHelper.nvlString(grid1.Rows[i].Cells["TECHWORKER"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BUYDATE", DBHelper.nvlString(grid1.Rows[i].Cells["BUYDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_BUYCOST", DBHelper.nvlString(grid1.Rows[i].Cells["BUYCOST"].Value), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STATUS", DBHelper.nvlString(grid1.Rows[i].Cells["STATUS"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPLASTDATE", DBHelper.nvlString(grid1.Rows[i].Cells["INSPLASTDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LIMITDATE", DBHelper.nvlString(grid1.Rows[i].Cells["LIMITDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_CAVITY", DBHelper.nvlString(grid1.Rows[i].Cells["CAVITY"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_DESIGNSHOT", DBHelper.nvlString(grid1.Rows[i].Cells["DESIGNSHOT"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_WORKSHOT", DBHelper.nvlString(grid1.Rows[i].Cells["WORKSHOT"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_TOTSHOT", DBHelper.nvlString(grid1.Rows[i].Cells["TOTSHOT"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_MOLDUSECNT", DBHelper.nvlString(grid1.Rows[i].Cells["MOLDUSECNT"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LASTUSEDATE", DBHelper.nvlString(grid1.Rows[i].Cells["LASTUSEDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_FAILURFLAG", DBHelper.nvlString(grid1.Rows[i].Cells["FAILURFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_INSPCYCLE", DBHelper.nvlString(grid1.Rows[i].Cells["INSPCYCLE"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_ALRAMCYCLE", DBHelper.nvlString(grid1.Rows[i].Cells["ALRAMCYCLE"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(grid1.Rows[i].Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(grid1.Rows[i].Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DateTime.Now, DbType.DateTime, ParameterDirection.Input)); ;

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
                        drTarget["MACHNAME"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["MACHTYPE"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["WORKCENTERCODE"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["WORKCENTERNAME"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["PRODFLAG"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["MAKECOMPANY"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["MODELNAME"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["SERIALNO"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["LIFETIME"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        drTarget["CONTACT"] = Convert.ToString(dtExcelImport.Rows[i][10]);
                        drTarget["MACHCASE"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                        drTarget["MACHLOC"] = Convert.ToString(dtExcelImport.Rows[i][12]);
                        drTarget["MAWORKER1"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        drTarget["MAWORKER2"] = Convert.ToString(dtExcelImport.Rows[i][14]);
                        drTarget["TECHWORKER"] = Convert.ToString(dtExcelImport.Rows[i][15]);
                        drTarget["BUYDATE"] = Convert.ToString(dtExcelImport.Rows[i][16]);
                        drTarget["BUYCOST"] = Convert.ToString(dtExcelImport.Rows[i][17]);
                        drTarget["STATUS"] = Convert.ToString(dtExcelImport.Rows[i][18]);
                        drTarget["INSPLASTDATE"] = Convert.ToString(dtExcelImport.Rows[i][19]);
                        drTarget["LIMITDATE"] = Convert.ToString(dtExcelImport.Rows[i][20]);
                        drTarget["CAVITY"] = Convert.ToString(dtExcelImport.Rows[i][21]);
                        drTarget["DESIGNSHOT"] = Convert.ToString(dtExcelImport.Rows[i][22]);
                        drTarget["WORKSHOT"] = Convert.ToString(dtExcelImport.Rows[i][23]);
                        drTarget["TOTSHOT"] = Convert.ToString(dtExcelImport.Rows[i][24]);
                        drTarget["MOLDUSECNT"] = Convert.ToString(dtExcelImport.Rows[i][25]);
                        drTarget["LASTUSEDATE"] = Convert.ToString(dtExcelImport.Rows[i][26]);
                        drTarget["FAILURFLAG"] = Convert.ToString(dtExcelImport.Rows[i][27]);
                        drTarget["INSPCYCLE"] = Convert.ToString(dtExcelImport.Rows[i][28]);
                        drTarget["ALRAMCYCLE"] = Convert.ToString(dtExcelImport.Rows[i][29]);
                        drTarget["USEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][30]).Trim();
                        drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][31]);

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

using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class BM0550_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public BM0550_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void BM0550_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //GRID1 품목

            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TARGETTYPE", "목표치구분", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TARGETCLASS", "폭표치유형", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE", "부서", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BANCODE", "반", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TEAMCODE", "팀", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "M01", "1월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "M02", "2월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "M03", "3월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "M04", "4월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "M05", "5월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "M06", "6월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "M07", "7월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "M08", "8월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "M09", "9월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "M10", "10월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "M11", "11월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "M12", "12월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "Y00", "년목표치", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 130, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            //필수입력 항목에 대한 음영
            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;


            #endregion

            #region COMBOBOX SETTING
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TARGETTYPE"); //목표치구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TARGETTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TARGETCLASS"); //목표치유형
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TARGETCLASS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DEPTCODE"); //부서
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("BANCODE"); //반
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "BANCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TEAMCODE"); //팀
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TEAMCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            BizGridManager gridManager = new BizGridManager(grid1); //그리드 콤보박스 객체 생성
                                                                    //품목
            gridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "", "Y" });
            //공정
            gridManager.PopUpAdd("OPCODE", "OPNAME", "BM0040", new string[] { "PLANTCODE", "", "Y" });
            //라인
            gridManager.PopUpAdd("LINECODE", "LINENAME", "BM0050", new string[] { "PLANTCODE", "OPCODE", "Y" });
            //작업장
            gridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "OPCODE", "LINECODE", "Y" });
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
            string sTargetType = string.Empty;
            string sTargetClass = string.Empty;
            string sItemCode = string.Empty;
            string sOpCode = string.Empty;
            string sLindCode = string.Empty;
            string sWorkcenterCode = string.Empty;
            string sDeptCode = string.Empty;
            string sBanCode = string.Empty;
            string sTeamCode = string.Empty;
            string sM01 = string.Empty;
            string sM02 = string.Empty;
            string sM03 = string.Empty;
            string sM04 = string.Empty;
            string sM05 = string.Empty;
            string sM06 = string.Empty;
            string sM07 = string.Empty;
            string sM08 = string.Empty;
            string sM09 = string.Empty;
            string sM10 = string.Empty;
            string sM11 = string.Empty;
            string sM12 = string.Empty;
            string sY00 = string.Empty;
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
                    sTargetType = Convert.ToString(grid1.Rows[i].Cells["TARGETTYPE"].Value);
                    sTargetClass = Convert.ToString(grid1.Rows[i].Cells["TARGETCLASS"].Value);
                    sOpCode = Convert.ToString(grid1.Rows[i].Cells["OPCODE"].Value);
                    sItemCode = Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value);
                    sLindCode = Convert.ToString(grid1.Rows[i].Cells["LINECODE"].Value);
                    sWorkcenterCode = Convert.ToString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value);
                    sDeptCode = Convert.ToString(grid1.Rows[i].Cells["DEPTCODE"].Value);
                    sBanCode = Convert.ToString(grid1.Rows[i].Cells["BANCODE"].Value);
                    sTeamCode = Convert.ToString(grid1.Rows[i].Cells["TEAMCODE"].Value);
                    sM01 = Convert.ToString(grid1.Rows[i].Cells["M01"].Value);
                    sM02 = Convert.ToString(grid1.Rows[i].Cells["M02"].Value);
                    sM03 = Convert.ToString(grid1.Rows[i].Cells["M03"].Value);
                    sM04 = Convert.ToString(grid1.Rows[i].Cells["M04"].Value);
                    sM05 = Convert.ToString(grid1.Rows[i].Cells["M05"].Value);
                    sM06 = Convert.ToString(grid1.Rows[i].Cells["M06"].Value);
                    sM07 = Convert.ToString(grid1.Rows[i].Cells["M07"].Value);
                    sM08 = Convert.ToString(grid1.Rows[i].Cells["M08"].Value);
                    sM09 = Convert.ToString(grid1.Rows[i].Cells["M09"].Value);
                    sM10 = Convert.ToString(grid1.Rows[i].Cells["M10"].Value);
                    sM11 = Convert.ToString(grid1.Rows[i].Cells["M11"].Value);
                    sM12 = Convert.ToString(grid1.Rows[i].Cells["M12"].Value);
                    sY00 = Convert.ToString(grid1.Rows[i].Cells["Y00"].Value);
                    sRemark = Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value);
                    sUseFlag = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);

                    if (sPlantCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.", "MSG"));
                        return;
                    }
                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "BM0550", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_BM0550_I1"
                                                    , CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_TARGETTYPE", DBHelper.nvlString(grid1.Rows[i].Cells["TARGETTYPE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_TARGETCLASS", DBHelper.nvlString(grid1.Rows[i].Cells["TARGETCLASS"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_OPCODE", DBHelper.nvlString(grid1.Rows[i].Cells["OPCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_LINECODE", DBHelper.nvlString(grid1.Rows[i].Cells["LINECODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_DEPTCODE", DBHelper.nvlString(grid1.Rows[i].Cells["DEPTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_BANCODE", DBHelper.nvlString(grid1.Rows[i].Cells["BANCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_TEAMCODE", DBHelper.nvlString(grid1.Rows[i].Cells["TEAMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M01", DBHelper.nvlString(grid1.Rows[i].Cells["M01"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M02", DBHelper.nvlString(grid1.Rows[i].Cells["M02"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M03", DBHelper.nvlString(grid1.Rows[i].Cells["M03"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M04", DBHelper.nvlString(grid1.Rows[i].Cells["M04"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M05", DBHelper.nvlString(grid1.Rows[i].Cells["M05"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M06", DBHelper.nvlString(grid1.Rows[i].Cells["M06"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M07", DBHelper.nvlString(grid1.Rows[i].Cells["M07"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M08", DBHelper.nvlString(grid1.Rows[i].Cells["M08"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M09", DBHelper.nvlString(grid1.Rows[i].Cells["M09"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M10", DBHelper.nvlString(grid1.Rows[i].Cells["M10"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M11", DBHelper.nvlString(grid1.Rows[i].Cells["M11"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M12", DBHelper.nvlString(grid1.Rows[i].Cells["M12"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_Y00", DBHelper.nvlString(grid1.Rows[i].Cells["Y00"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(grid1.Rows[i].Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(grid1.Rows[i].Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
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
                        helper.ExecuteNoneQuery("USP_BM0550_I1"
                                                    , CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_TARGETTYPE", DBHelper.nvlString(grid1.Rows[i].Cells["TARGETTYPE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_TARGETCLASS", DBHelper.nvlString(grid1.Rows[i].Cells["TARGETCLASS"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_OPCODE", DBHelper.nvlString(grid1.Rows[i].Cells["OPCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_LINECODE", DBHelper.nvlString(grid1.Rows[i].Cells["LINECODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_DEPTCODE", DBHelper.nvlString(grid1.Rows[i].Cells["DEPTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_BANCODE", DBHelper.nvlString(grid1.Rows[i].Cells["BANCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_TEAMCODE", DBHelper.nvlString(grid1.Rows[i].Cells["TEAMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M01", DBHelper.nvlString(grid1.Rows[i].Cells["M01"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M02", DBHelper.nvlString(grid1.Rows[i].Cells["M02"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M03", DBHelper.nvlString(grid1.Rows[i].Cells["M03"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M04", DBHelper.nvlString(grid1.Rows[i].Cells["M04"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M05", DBHelper.nvlString(grid1.Rows[i].Cells["M05"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M06", DBHelper.nvlString(grid1.Rows[i].Cells["M06"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M07", DBHelper.nvlString(grid1.Rows[i].Cells["M07"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M08", DBHelper.nvlString(grid1.Rows[i].Cells["M08"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M09", DBHelper.nvlString(grid1.Rows[i].Cells["M09"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M10", DBHelper.nvlString(grid1.Rows[i].Cells["M10"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M11", DBHelper.nvlString(grid1.Rows[i].Cells["M11"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_M12", DBHelper.nvlString(grid1.Rows[i].Cells["M12"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_Y00", DBHelper.nvlString(grid1.Rows[i].Cells["Y00"].Value), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(grid1.Rows[i].Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(grid1.Rows[i].Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
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
                        drTarget["TARGETTYPE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["TARGETCLASS"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["ITEMCODE"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["ITEMNAME"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["OPCODE"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["OPNAME"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["LINECODE"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["LINENAME"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["WORKCENTERCODE"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        drTarget["WORKCENTERNAME"] = Convert.ToString(dtExcelImport.Rows[i][10]);
                        drTarget["DEPTCODE"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                        drTarget["BANCODE"] = Convert.ToString(dtExcelImport.Rows[i][12]);
                        drTarget["TEAMCODE"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        drTarget["M01"] = Convert.ToString(dtExcelImport.Rows[i][14]);
                        drTarget["M02"] = Convert.ToString(dtExcelImport.Rows[i][15]);
                        drTarget["M03"] = Convert.ToString(dtExcelImport.Rows[i][16]);
                        drTarget["M04"] = Convert.ToString(dtExcelImport.Rows[i][17]);
                        drTarget["M05"] = Convert.ToString(dtExcelImport.Rows[i][18]);
                        drTarget["M06"] = Convert.ToString(dtExcelImport.Rows[i][19]);
                        drTarget["M07"] = Convert.ToString(dtExcelImport.Rows[i][20]);
                        drTarget["M08"] = Convert.ToString(dtExcelImport.Rows[i][21]);
                        drTarget["M09"] = Convert.ToString(dtExcelImport.Rows[i][22]);
                        drTarget["M10"] = Convert.ToString(dtExcelImport.Rows[i][23]);
                        drTarget["M11"] = Convert.ToString(dtExcelImport.Rows[i][24]);
                        drTarget["M12"] = Convert.ToString(dtExcelImport.Rows[i][25]);
                        drTarget["Y00"] = Convert.ToString(dtExcelImport.Rows[i][26]);
                        drTarget["USEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][27]).Trim();
                        drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][28]);

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

using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class BM0560_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        Common _Common = new Common();

        #endregion

        #region [ 생성자 ]
        public BM0560_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void BM0560_EXCEL_Load(object sender, EventArgs e)
        {
            #region GRID SETTING

            //GRID1 실적수집장비
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ID", "지그비 ID", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "GATEWAYID", "GATEWAY ID", true, GridColDataType_emu.VarChar, 100, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 150, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "VALUE", "COUNTER 값", true, GridColDataType_emu.Integer, 100, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "상태정보", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PROCTYPE", "처리종류", true, GridColDataType_emu.VarChar, 130, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비코드", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", true, GridColDataType_emu.VarChar, 150, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LASTDATE", "최종 수집일자", true, GridColDataType_emu.DateTime, 180, 80, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 90, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            //필수입력 항목에 대한 음영
            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ID"].Header.Appearance.ForeColor = Color.SkyBlue;

            #endregion

            #region COMBOBOX SETTING

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("STATUS"); //상태정보
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PROCTYPE"); //처리종류
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PROCTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region POPUP SETTING

            BizGridManager bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "Y" });
            bizGridManager.PopUpAdd("MACHCODE", "MACHNAME", "BM0070", new string[] { "PLANTCODE", "", "Y" });

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
            string sId = string.Empty;
            string sGatewayId = string.Empty;
            string sWorkcenterCode = string.Empty;
            string sWorkcenterName = string.Empty;
            string sValue = string.Empty;
            string sStatus = string.Empty;
            string sProcType = string.Empty;
            string sMachCode = string.Empty;
            string sMachName = string.Empty;
            string sLastDate = string.Empty;
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
                    sId = Convert.ToString(grid1.Rows[i].Cells["ID"].Value);
                    sGatewayId = Convert.ToString(grid1.Rows[i].Cells["GATEWAYID"].Value);
                    sWorkcenterCode = Convert.ToString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value);
                    sWorkcenterName = Convert.ToString(grid1.Rows[i].Cells["WORKCENTERNAME"].Value);
                    sValue = Convert.ToString(grid1.Rows[i].Cells["VALUE"].Value);
                    sStatus = Convert.ToString(grid1.Rows[i].Cells["STATUS"].Value);
                    sProcType = Convert.ToString(grid1.Rows[i].Cells["PROCTYPE"].Value);
                    sMachCode = Convert.ToString(grid1.Rows[i].Cells["MACHCODE"].Value);
                    sMachName = Convert.ToString(grid1.Rows[i].Cells["MACHNAME"].Value);
                    sLastDate = Convert.ToString(grid1.Rows[i].Cells["LASTDATE"].Value);
                    sRemark = Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value);
                    sUseFlag = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);

                    if (sPlantCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.", "MSG"));
                        return;
                    }

                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "BM0560", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_BM0560_EXCEL_I1", CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ID", Convert.ToString(grid1.Rows[i].Cells["ID"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_GATEWAYID", Convert.ToString(grid1.Rows[i].Cells["GATEWAYID"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WORKCENTERCODE", Convert.ToString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AI_VALUE", Convert.ToString(grid1.Rows[i].Cells["VALUE"].Value), DbType.Int32, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STATUS", Convert.ToString(grid1.Rows[i].Cells["STATUS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PROCTYPE", Convert.ToString(grid1.Rows[i].Cells["PROCTYPE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_MACHCODE", Convert.ToString(grid1.Rows[i].Cells["MACHCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_LASTDATE", Convert.ToString(grid1.Rows[i].Cells["LASTDATE"].Value), DbType.String, ParameterDirection.Input)
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
                        helper.ExecuteNoneQuery("USP_BM0560_EXCEL_I1", CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ID", Convert.ToString(grid1.Rows[i].Cells["ID"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_GATEWAYID", Convert.ToString(grid1.Rows[i].Cells["GATEWAYID"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WORKCENTERCODE", Convert.ToString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AI_VALUE", Convert.ToString(grid1.Rows[i].Cells["VALUE"].Value), DbType.Int32, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_STATUS", Convert.ToString(grid1.Rows[i].Cells["STATUS"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_PROCTYPE", Convert.ToString(grid1.Rows[i].Cells["PROCTYPE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_MACHCODE", Convert.ToString(grid1.Rows[i].Cells["MACHCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_LASTDATE", Convert.ToString(grid1.Rows[i].Cells["LASTDATE"].Value), DbType.String, ParameterDirection.Input)
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
                        drTarget["ID"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["GATEWAYID"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["WORKCENTERCODE"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["WORKCENTERNAME"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["VALUE"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["STATUS"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["PROCTYPE"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["MACHCODE"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["MACHNAME"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        drTarget["LASTDATE"] = Convert.ToString(dtExcelImport.Rows[i][10]);
                        drTarget["USEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][11]).Trim();
                        drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][12]);

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
#endregion
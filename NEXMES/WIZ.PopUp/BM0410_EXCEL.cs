using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class BM0410_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public BM0410_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void BM0410_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅

            //GRID1
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사항목", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "VALUETYPE", "검사값구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECTYPE", "관리구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "검사단위", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECNOL", "기준값", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "IMG", "이미지", true, GridColDataType_emu.Image, 0, 0, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            //필수입력 항목에 대한 음영
            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["INSPCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["INSPNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["VALUETYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["SPECTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["UNITCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["SPECNOL"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["SPECUSL"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["SPECLSL"].Header.Appearance.ForeColor = Color.SkyBlue;

            #endregion

            #region [ Combo Box ]
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("VALUETYPE");  //검사값구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "VALUETYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("SPECTYPE"); //관리구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "SPECTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0130_CODE("Y"); //단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");


            BizGridManager gridManager = new BizGridManager(grid1); //그리드 콤보박스 객체 생성
            //품목
            gridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "", "Y" });

            //검사항목
            gridManager.PopUpAdd("INSPCODE", "INSPNAME", "BM0170", new string[] { "PLANTCODE", "Y" });
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
            string sInspCode = string.Empty;
            string sValueType = string.Empty;
            string sUnitCode = string.Empty;
            string sSpecType = string.Empty;
            string sSpecNol = string.Empty;
            string sSpecUsl = string.Empty;
            string sSpecLsl = string.Empty;
            string sRemark = string.Empty;
            string sUseFlag = string.Empty;
            byte[] bImage = null;
            string excelUploadType = string.Empty;

            int iOK = 0;
            int iNG = 0;

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    sPlantCode = Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value);
                    sItemCode = Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value);
                    sInspCode = Convert.ToString(grid1.Rows[i].Cells["INSPCODE"].Value);
                    sValueType = Convert.ToString(grid1.Rows[i].Cells["VALUETYPE"].Value);
                    sUnitCode = Convert.ToString(grid1.Rows[i].Cells["UNITCODE"].Value);
                    sSpecType = Convert.ToString(grid1.Rows[i].Cells["SPECTYPE"].Value);
                    sSpecNol = Convert.ToString(grid1.Rows[i].Cells["SPECNOL"].Value);
                    sSpecUsl = Convert.ToString(grid1.Rows[i].Cells["SPECUSL"].Value);
                    sSpecLsl = Convert.ToString(grid1.Rows[i].Cells["SPECLSL"].Value);
                    sRemark = Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value);
                    sUseFlag = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);
                    bImage = ConvertImageToByteArray(Properties.Resources.Default_Image);


                    if (sPlantCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.", "MSG"));
                        return;
                    }
                    if (sItemCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 품목를 확인하세요.", "MSG"));
                        return;
                    }
                    if (sInspCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 검사항목을 확인하세요.", "MSG"));
                        return;
                    }

                    #region [ validation 체크 ]
                    if (sValueType == "")
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 검사값 구분을 확인하세요.", "MSG"));
                        return;
                    }

                    //검사값구분이 값일경우
                    if (sValueType != "J")
                    {
                        if (sSpecType == "")
                        {
                            MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 관리구분을 확인하세요.", "MSG"));
                            return;
                        }

                        if (sUnitCode == "")
                        {
                            MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 단위를 확인하세요.", "MSG"));
                            return;
                        }

                        if (sSpecNol == "")
                        {
                            MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 기준값을 확인하세요.", "MSG"));
                            return;
                        }

                        //하한관리가 아니면 상한값은 필수입력
                        if (sSpecUsl == "" && sSpecType != "L")
                        {
                            MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 상한값을 확인하세요.", "MSG"));
                            return;
                        }

                        //상한관리가 아니면 하한값은 필수입력
                        if (sSpecLsl == "" && sSpecType != "U")
                        {
                            MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 하한값을 확인하세요.", "MSG"));
                            return;
                        }

                        if (sSpecType != "L" && Convert.ToDouble(sSpecUsl) < Convert.ToDouble(sSpecNol))
                        {
                            MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 상한값은 기준값보다 낮을 수 없습니다.", "MSG"));
                            return;
                        }

                        if (sSpecType != "U" && Convert.ToDouble(sSpecLsl) > Convert.ToDouble(sSpecNol))
                        {
                            MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 하한값은 상한값보다 클 수 없습니다.", "MSG"));
                            return;
                        }
                    }
                    else
                    {
                        grid1.Rows[i].Cells["SPECTYPE"].Value = "";
                        grid1.Rows[i].Cells["UNITCODE"].Value = "";
                        grid1.Rows[i].Cells["SPECNOL"].Value = "";
                        grid1.Rows[i].Cells["SPECUSL"].Value = "";
                        grid1.Rows[i].Cells["SPECLSL"].Value = "";
                    }

                    #endregion

                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "BM0410", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_BM0410_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPCODE", Convert.ToString(grid1.Rows[i].Cells["INSPCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_VALUETYPE", Convert.ToString(grid1.Rows[i].Cells["VALUETYPE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_UNITCODE", Convert.ToString(grid1.Rows[i].Cells["UNITCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SPECTYPE", Convert.ToString(grid1.Rows[i].Cells["SPECTYPE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_SPECNOL", Convert.ToString(grid1.Rows[i].Cells["SPECNOL"].Value), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_SPECUSL", Convert.ToString(grid1.Rows[i].Cells["SPECUSL"].Value), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_SPECLSL", Convert.ToString(grid1.Rows[i].Cells["SPECLSL"].Value), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AB_IMG", bImage, DbType.Binary, ParameterDirection.Input)
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
                        helper.ExecuteNoneQuery("USP_BM0410_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPCODE", Convert.ToString(grid1.Rows[i].Cells["INSPCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_VALUETYPE", Convert.ToString(grid1.Rows[i].Cells["VALUETYPE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_UNITCODE", Convert.ToString(grid1.Rows[i].Cells["UNITCODE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SPECTYPE", Convert.ToString(grid1.Rows[i].Cells["SPECTYPE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_SPECNOL", Convert.ToString(grid1.Rows[i].Cells["SPECNOL"].Value), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_SPECUSL", Convert.ToString(grid1.Rows[i].Cells["SPECUSL"].Value), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_SPECLSL", Convert.ToString(grid1.Rows[i].Cells["SPECLSL"].Value), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AB_IMG", bImage, DbType.Binary, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
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
                        drTarget["ITEMCODE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["ITEMNAME"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["INSPCODE"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["INSPNAME"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["VALUETYPE"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["SPECTYPE"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["UNITCODE"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["SPECNOL"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["SPECLSL"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        drTarget["SPECUSL"] = Convert.ToString(dtExcelImport.Rows[i][10]);
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
        //GRID1 각종 구분별 컬럼 편집여부 결정
        private void grid1_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.ToString() == "VALUETYPE")
            {
                if (e.Cell.Column.Editor.Value.ToString() != "J")
                {
                    grid1.ActiveRow.Cells["SPECTYPE"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["UNITCODE"].Activation = Activation.AllowEdit;
                }
                else
                {
                    grid1.ActiveRow.Cells["SPECNOL"].Value = DBNull.Value;
                    grid1.ActiveRow.Cells["SPECUSL"].Value = DBNull.Value;
                    grid1.ActiveRow.Cells["SPECLSL"].Value = DBNull.Value;
                    grid1.ActiveRow.Cells["SPECTYPE"].Value = "";
                    grid1.ActiveRow.Cells["UNITCODE"].Value = "";

                    grid1.ActiveRow.Cells["SPECTYPE"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;

                }
            }

            else if (e.Cell.Column.ToString() == "SPECTYPE")
            {
                if (e.Cell.Column.Editor.Value.ToString() == "U")
                {
                    grid1.ActiveRow.Cells["SPECLSL"].Value = DBNull.Value;

                    grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.NoEdit;
                }
                else if (e.Cell.Column.Editor.Value.ToString() == "L")
                {
                    grid1.ActiveRow.Cells["SPECUSL"].Value = DBNull.Value;

                    grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.AllowEdit;
                }
                else if (e.Cell.Column.Editor.Value.ToString() == "B")
                {
                    grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.AllowEdit;
                }
            }
        }

        //GRID1 각종 구분별 컬럼 편집여부 결정
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (grid1.ActiveRow.Cells["VALUETYPE"].Value.ToString() != "J")
            {
                grid1.ActiveRow.Cells["SPECTYPE"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["UNITCODE"].Activation = Activation.AllowEdit;
            }
            else
            {
                grid1.ActiveRow.Cells["SPECNOL"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["SPECUSL"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["SPECLSL"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["SPECTYPE"].Value = "";
                grid1.ActiveRow.Cells["UNITCODE"].Value = "";

                grid1.ActiveRow.Cells["SPECTYPE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;

            }

            if (grid1.ActiveRow.Cells["SPECTYPE"].Value.ToString() == "U")
            {
                grid1.ActiveRow.Cells["SPECLSL"].Value = DBNull.Value;

                grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.NoEdit;
            }
            else if (grid1.ActiveRow.Cells["SPECTYPE"].Value.ToString() == "L")
            {
                grid1.ActiveRow.Cells["SPECUSL"].Value = DBNull.Value;

                grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.AllowEdit;
            }
            else if (grid1.ActiveRow.Cells["SPECTYPE"].Value.ToString() == "B")
            {
                grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.AllowEdit;
            }
        }

        #region < 이미지 Default >

        #region ConvertImageToByteArray
        public byte[] ConvertImageToByteArray(Image theImage)
        {
            MemoryStream ms = new MemoryStream();
            byte[] pByte;

            theImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            pByte = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(pByte, 0, (int)ms.Length);
            ms.Close();
            return pByte;
        }
        #endregion

        #region BYTE[]를 이미지로 변환
        public Image ConvertByteArrayToImage(byte[] pByte)
        {
            MemoryStream ms = new MemoryStream();

            Image theImage = null;

            try
            {
                ms.Position = 0;

                ms.Write(pByte, 0, (int)pByte.Length);

                theImage = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return theImage;
        }
        #endregion

        #endregion
    }
}

#region < USING AREA >
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
#endregion

namespace WIZ.PopUp
{
    public partial class POP_WM4000_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable dtGrid1 = new DataTable();
        DateTime makeDate = new DateTime();

        #endregion

        #region < CONSTRUCTOR >
        public POP_WM4000_EXCEL(DateTime makedate)
        {
            InitializeComponent();

            this.makeDate = makedate;
        }
        #endregion

        #region < FORM LOAD >
        private void POP_MM0000Y_EXCEL_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 80, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME",  "거래처명", false, GridColDataType_emu.VarChar, 150, true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",  "품명",     false, GridColDataType_emu.VarChar, 150, true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "D", "D", false, GridColDataType_emu.Double, 60, true, false);

            for (int i = 1; i <= 30; i++)
            {
                _GridUtil.InitColumnUltraGrid(grid1, "D_" + i.ToString("#,###0"), "D+" + i.ToString("#,###0"), false, GridColDataType_emu.Double, 60, 100, Infragistics.Win.HAlign.Right, true, true, "#,###0", null, null, null, null);
            }

            //_GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 180, true, false);

            _GridUtil.SetColumnTextHAlign(grid1, "CUSTNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "CUSTNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "D", Infragistics.Win.HAlign.Right);

            //grid1.DisplayLayout.Bands[0].Columns["PLANINDATE"].Header.Appearance.ForeColor  = Color.Yellow;

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region < COMBOBOX SETTING >
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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

            if (sFilePath.IndexOf(".xlsx") > -1)
            {
                // 엑셀 2007 이상
                oledbConnStr = "Provider=Microsoft.JET.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties='Excel 12.0';HDR=NO;IMEX=1'";
            }
            else
            {
                // 엑셀 2003 및 이하 버전
                //oledbConnStr = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties=\"Excel 8.0\"";
                oledbConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
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
            DBHelper helper = new DBHelper("", true);
            bool issuccess = true;



            try
            {
                this.grid1.UpdateData();
                dtGrid1 = (DataTable)grid1.DataSource;
                // 진행중 
                this.ShowProgressForm("C00007");
                // 업데이트 데이터       

                //string Check = "Default";
                string ls_itemcode = string.Empty, ls_plantcode = string.Empty;
                string ls_custcode = string.Empty, ls_basedt = string.Empty;
                string ls_ChkItem = string.Empty, ls_maker = string.Empty;
                string ls_plandate = string.Empty, ls_planprodqty = string.Empty;

                #region ▶ 엑셀 저장용 DataSourcd = dtGirid1 
                foreach (DataRow drRow in this.dtGrid1.Rows)
                {
                    ls_plantcode = Convert.ToString(drRow["PLANTCODE"]);
                    ls_itemcode = Convert.ToString(drRow["ITEMCODE"]);
                    ls_custcode = Convert.ToString(drRow["CUSTCODE"]);
                    ls_basedt = string.Format("{0:yyyy-MM-dd}", (makeDate.AddDays(-1)));
                    ls_ChkItem = this.GetChkItem(WIZ.LoginInfo.PlantCode, ls_custcode, ls_itemcode);
                    ls_maker = this.WorkerID;

                    //거래처별 품목 확인 메세지 수정
                    //if (ls_ChkItem != "")
                    //{
                    //    MessageBox.Show(ls_ChkItem);
                    //    helper.Rollback();
                    //    return;
                    //}

                    drRow.RowError = "";

                    if (drRow.RowState == DataRowState.Unchanged) continue;

                    helper.ExecuteNoneQuery("USP_WM4000Y_I0", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_CUSTCODE", ls_custcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_BASEDT", ls_basedt, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MAKER", ls_maker, DbType.String, ParameterDirection.Input));

                    if (Convert.ToString(helper.RSCODE) == "E")
                    {
                        issuccess = false;
                        drRow.RowError = this.FormInformation.GetMessage(helper.RSMSG);
                        continue;
                    }

                    string colid = String.Empty;

                    for (int i = 0; i <= 30; i++)
                    {
                        //if (i == -1) { colid = "D_N"; }
                        if (i == 0) { colid = "D"; }
                        else { colid = "D_" + i.ToString("##"); }

                        ls_plandate = string.Format("{0:yyyy-MM-dd}", (makeDate.AddDays(i)));
                        ls_planprodqty = Convert.ToString(Convert.ToDouble(DBHelper.nvlString(drRow[colid], "0")));

                        helper.ExecuteNoneQuery("USP_WM4000Y_I1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_CUSTCODE", ls_custcode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_PLANDATE", ls_plandate, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_PLANPRODQTY", ls_planprodqty, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_MAKER", ls_maker, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_BASEDT", ls_basedt, DbType.String, ParameterDirection.Input));

                        if (Convert.ToString(helper.RSCODE) == "E")
                        {
                            string a = helper.RSMSG;
                            issuccess = false;
                            drRow.RowError = this.FormInformation.GetMessage(helper.RSMSG);
                            MessageBox.Show(helper.RSMSG);
                            return;
                        }
                        if (Convert.ToString(helper.RSCODE) == "O")
                        {
                            string msg = helper.RSMSG;
                            issuccess = false;
                            MessageBox.Show(msg);
                        }
                    }
                    //Check = "DtGird1";
                }

                if (issuccess)
                {
                    helper.Commit();
                    this.ClosePrgFormNew();
                    MessageBox.Show("정상적으로 처리되었습니다.");
                }


            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        private string GetChkItem(string as_plantcode, string as_custcode, string as_itemcode)
        {
            // 2015-07-02 서보경 고객사별 출하 품목 체크 수정(관련 거래처코드도 체크 가능)
            DBHelper helper = new DBHelper(false);
            DataTable dtTemp = new DataTable();
            string RS_CODE = string.Empty, RS_MSG = string.Empty;
            try
            {

                dtTemp = helper.FillTable("USP_WM4000Y_ITEMCHK", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", as_plantcode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_CUSTCODE", as_custcode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", as_itemcode, DbType.String, ParameterDirection.Input));

                if (Convert.ToString(helper.RSMSG) != "")
                {
                    return Convert.ToString(helper.RSMSG);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
            return "";
        }
        #endregion

        #region < EVENT AREA >
        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = "EXCEL|*.xls|ALL|*.*";

                if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //엑셀 파일 READ
                    DataTable dtExcelImport = GetExcel(openfiledialog.FileName);

                    //대상 GRID DataTable 복사(구조o, 데이터x)
                    DataTable dtTarget = ((DataTable)grid1.DataSource).Clone();

                    //엑셀파일에서 READ 된 DataTable로 등록할 데이터 DataTable에 저장
                    for (int i = 1; i < dtExcelImport.Rows.Count; i++)
                    {
                        DataRow drTarget = dtTarget.NewRow();

                        drTarget["PLANTCODE"] = Convert.ToString(WIZ.LoginInfo.PlantCode.Trim());
                        drTarget["CUSTCODE"] = Convert.ToString(dtExcelImport.Rows[i][0]);
                        //drTarget["CUSTNAME"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["ITEMCODE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        //drTarget["ITEMNAME"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["D"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["D_1"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["D_2"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["D_3"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["D_4"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["D_5"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["D_6"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["D_7"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        drTarget["D_8"] = Convert.ToString(dtExcelImport.Rows[i][10]);
                        drTarget["D_9"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                        drTarget["D_10"] = Convert.ToString(dtExcelImport.Rows[i][12]);
                        drTarget["D_11"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        drTarget["D_12"] = Convert.ToString(dtExcelImport.Rows[i][14]);
                        drTarget["D_13"] = Convert.ToString(dtExcelImport.Rows[i][15]);
                        drTarget["D_14"] = Convert.ToString(dtExcelImport.Rows[i][16]);
                        drTarget["D_15"] = Convert.ToString(dtExcelImport.Rows[i][17]);
                        drTarget["D_16"] = Convert.ToString(dtExcelImport.Rows[i][18]);
                        drTarget["D_17"] = Convert.ToString(dtExcelImport.Rows[i][19]);
                        drTarget["D_18"] = Convert.ToString(dtExcelImport.Rows[i][20]);
                        drTarget["D_19"] = Convert.ToString(dtExcelImport.Rows[i][21]);
                        drTarget["D_20"] = Convert.ToString(dtExcelImport.Rows[i][22]);
                        drTarget["D_21"] = Convert.ToString(dtExcelImport.Rows[i][23]);
                        drTarget["D_22"] = Convert.ToString(dtExcelImport.Rows[i][24]);
                        drTarget["D_23"] = Convert.ToString(dtExcelImport.Rows[i][25]);
                        drTarget["D_24"] = Convert.ToString(dtExcelImport.Rows[i][26]);
                        drTarget["D_25"] = Convert.ToString(dtExcelImport.Rows[i][27]);
                        drTarget["D_26"] = Convert.ToString(dtExcelImport.Rows[i][28]);
                        drTarget["D_27"] = Convert.ToString(dtExcelImport.Rows[i][29]);
                        drTarget["D_28"] = Convert.ToString(dtExcelImport.Rows[i][30]);
                        drTarget["D_29"] = Convert.ToString(dtExcelImport.Rows[i][31]);
                        drTarget["D_30"] = Convert.ToString(dtExcelImport.Rows[i][32]);

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
        #endregion
    }
}

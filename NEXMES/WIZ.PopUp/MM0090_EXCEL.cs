#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0090_EXCEL
//   Form Name    : 재고실사 입력 엑셀 업로드
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-30
//   Made By      : 
//   Edited Date  : 
//   Edit By      :
//   Description  : 재고실사 입력 엑셀 업로드
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
#endregion

namespace WIZ.PopUp
{
    public partial class MM0090_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        public DataTable dtTemp = new DataTable();
        private string _sWhType;

        #endregion

        #region < CONSTRUCTOR >
        public MM0090_EXCEL()
        {
            InitializeComponent();
        }

        public MM0090_EXCEL(DataTable dtGrid, string sWhType)
        {
            InitializeComponent();

            dtTemp = dtGrid;
            _sWhType = sWhType;
        }
        #endregion

        #region < FORM LOAD >
        private void MM0090_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BARCODE", "LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "지시창고 & 지시작업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "전산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGQTY", "실사수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "실사반영사유", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ROWSEQ", "ROWSEQ", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Left, false, true);
            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DataSource = dtTemp;

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "BARCODE", "LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WHCODE", "지시창고 & 지시작업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "NOWQTY", "전산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TAKINGQTY", "실사수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "실사반영사유", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "ROWSEQ", "ROWSEQ", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Left, false, true);
            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region [ Combo Box ]
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            BizGridManager bizGridManager;

            bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "4", "" });

            GetWhCode("");

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
            string sLotNo = string.Empty;
            string sWhCode = string.Empty;
            string sItemCode = string.Empty;
            string sUnitCode = string.Empty;
            string sStockQty = string.Empty;
            string sTakingQty = string.Empty;

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    sPlantCode = Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value);
                    sLotNo = Convert.ToString(grid1.Rows[i].Cells["BARCODE"].Value);
                    sWhCode = Convert.ToString(grid1.Rows[i].Cells["WHCODE"].Value);
                    sItemCode = Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value);
                    sUnitCode = Convert.ToString(grid1.Rows[i].Cells["UNITCODE"].Value);
                    sStockQty = Convert.ToString(grid1.Rows[i].Cells["NOWQTY"].Value);
                    sTakingQty = Convert.ToString(grid1.Rows[i].Cells["TAKINGQTY"].Value);

                    if (sPlantCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 사업장을 확인하세요.", "MSG"));
                        return;
                    }

                    if (sLotNo == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 LOT NO를 확인하세요.", "MSG"));
                        return;
                    }

                    if (sWhCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 지시창고 & 작업장을 확인하세요.", "MSG"));
                        return;
                    }

                    if (sItemCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 품목을 확인하세요.", "MSG"));
                        return;
                    }

                    if (sUnitCode == string.Empty)
                    {
                        MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 단위를 확인하세요.", "MSG"));
                        return;
                    }

                    //if (sStockQty == string.Empty)
                    //{
                    //    MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 전산수량을 확인하세요.","MSG"));
                    //    return;
                    //}

                    //if (sTakingQty == string.Empty)
                    //{
                    //    MessageBox.Show(Common.getLangText(Convert.ToString(i + 1) + "번째 열의 실사수량을 확인하세요.", "MSG"));
                    //    return;
                    //}

                }

                dtTemp = (DataTable)grid1.DataSource;
                this.Close();

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

        private void GetWhCode(string sWhType)
        {
            DBHelper helper = new DBHelper(false);


            try
            {
                rtnDtTemp = helper.FillTable("USP_MM0090_S5", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input));

                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
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
                        drTarget["PLANTCODE"] = LoginInfo.PlantCode;
                        drTarget["BARCODE"] = Convert.ToString(dtExcelImport.Rows[i][0]);
                        drTarget["WHCODE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["ITEMCODE"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["NOWQTY"] = Convert.ToString(dtExcelImport.Rows[i][3]);

                        if (Convert.ToString(dtExcelImport.Rows[i][4]) == string.Empty)
                            drTarget["TAKINGQTY"] = 0;
                        else
                            drTarget["TAKINGQTY"] = Convert.ToString(dtExcelImport.Rows[i][4]);

                        DBHelper helper = new DBHelper(false);

                        try
                        {
                            rtnDtTemp = helper.FillTable("USP_MM0090_EXCEL_S1", CommandType.StoredProcedure
                                                                              , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                                              , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(dtExcelImport.Rows[i][2]), DbType.String, ParameterDirection.Input));

                            if (rtnDtTemp.Rows.Count > 0)
                            {
                                drTarget["ITEMNAME"] = Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]);
                                drTarget["UNITCODE"] = Convert.ToString(rtnDtTemp.Rows[0]["UNITCODE"]);
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
            finally
            {
                GetWhCode("");
            }
        }

        private void btnFileDown_Click(object sender, EventArgs e)
        {
            //GetWhCode("111");
            grid2.DataSource = grid1.DataSource;
            _GridUtil.ExportExcel(grid2);
            //GetWhCode("");
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

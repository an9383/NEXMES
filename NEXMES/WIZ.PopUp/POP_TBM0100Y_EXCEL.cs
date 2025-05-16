using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class POP_TBM0100Y_EXCEL : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        #region [ 생성자 ]
        public POP_TBM0100Y_EXCEL()
        {
            InitializeComponent();
        }
        #endregion

        #region [ Form Load ]
        private void POP_TBM0100Y_EXCEL_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            /*
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목구분", true, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "MAJORITEMTYPE", "품목대분류", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdItemCode", "생산품목", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 160, 160, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BASEUNIT", "기본단위", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "UNITWGT", "단위중량", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCOST", "단가", true, GridColDataType_emu.Integer, 90, 90, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKECOMPANY", "제조사", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOCCODE", "위치", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPFLAG", "검사구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMSPEC", "규격", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MATERIALGRADE", "재질", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAXSTOCK", "적정재고", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SAFESTOCK", "안전재고", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CHANGEFLAG", "주요품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CHANGETIME", "교체주기", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MINORDERQTY", "최소 발주수량", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "고정 발주수량", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAXORDERQTY", "최대 발주수량", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNCODE", "구매처", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNNAME", "구매처 담당자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNSPHONE", "구매처 담당 전화번호", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNSEMAIL", "구매처 담당 E-MAIL", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNFAXNO", "구매처 담당 FAX NO", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNADDRESS", "구매처 주소", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.Yellow;
            grid1.DisplayLayout.Bands[0].Columns["ITEMTYPE"].Header.Appearance.ForeColor = Color.Yellow;
            //grid1.DisplayLayout.Bands[0].Columns["MAJORITEMTYPE"].Header.Appearance.ForeColor = Color.Yellow;
            grid1.DisplayLayout.Bands[0].Columns["ProdItemCode"].Header.Appearance.ForeColor = Color.Yellow;
            grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.Yellow;
            */


            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 190, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목구분", true, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 160, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BASEUNIT", "기본단위", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPFLAG", "검사구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MATERIALGRADE", "재질", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMSPEC", "규격", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CARTYPE", "차종", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SAFESTOCK", "안전재고", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITWGT", "단위중량", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCOST", "단가", true, GridColDataType_emu.Integer, 90, 90, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNCODE", "구매처", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 170, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.SkyBlue;

            #endregion

            #region [ Combo Box ]
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            ////사용여부
            //rtnDtTemp = _Common.GET_TBM0000_CODE("UseFlag");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");


            //rtnDtTemp = _Common.GET_TBM0000_CODE("ItemType"); //품목구분
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            //rtnDtTemp = _Common.GET_TBM0000_CODE("INSPTYPE"); //검사구분
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "INSPFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("OPHEADER"); //품목대분류
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MAJORITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("WHCODE"); //창고코드
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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

                //oledbConnStr = "Provider=Microsoft.JET.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties=\"Excel 12.0\"";
                oledbConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=NO'";
            }
            else
            {
                // 엑셀 2003 및 이하 버전
                //oledbConnStr = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties=\"Excel 8.0\"";

                //oledbConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=No'"; 기존 사용
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
            DBHelper helper = new DBHelper(false);
            DBHelper helper_Excel = new DBHelper(false);

            if (grid1.Rows.Count == 0)
            {
                MessageBox.Show("업로드할 내용이 없습니다. 확인하세요.");
                return;
            }

            string plantcode = string.Empty;
            string ITEMTYPE = string.Empty;
            string itemcode = string.Empty;
            string ITEMNAME = string.Empty;
            string BASEUNIT = string.Empty;
            string INSPFLAG = string.Empty;
            string MATERIALGRADE = string.Empty;
            string ITEMSPEC = string.Empty;
            string CARTYPE = string.Empty;
            string SAFESTOCK = string.Empty;
            string UNITWGT = string.Empty;
            string UNITCOST = string.Empty;
            string ASGNCODE = string.Empty;
            string excelUploadType = string.Empty;

            int iOK = 0;
            int iNG = 0;

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    plantcode = Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value);
                    ITEMTYPE = Convert.ToString(grid1.Rows[i].Cells["ITEMTYPE"].Value);
                    itemcode = Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value);
                    ITEMNAME = Convert.ToString(grid1.Rows[i].Cells["ITEMNAME"].Value);
                    BASEUNIT = Convert.ToString(grid1.Rows[i].Cells["BASEUNIT"].Value);
                    INSPFLAG = Convert.ToString(grid1.Rows[i].Cells["INSPFLAG"].Value);
                    MATERIALGRADE = Convert.ToString(grid1.Rows[i].Cells["MATERIALGRADE"].Value);
                    ITEMSPEC = Convert.ToString(grid1.Rows[i].Cells["ITEMSPEC"].Value);
                    CARTYPE = Convert.ToString(grid1.Rows[i].Cells["CARTYPE"].Value);
                    SAFESTOCK = Convert.ToString(grid1.Rows[i].Cells["SAFESTOCK"].Value);
                    UNITWGT = Convert.ToString(grid1.Rows[i].Cells["UNITWGT"].Value);
                    UNITCOST = Convert.ToString(grid1.Rows[i].Cells["UNITCOST"].Value);
                    ASGNCODE = Convert.ToString(grid1.Rows[i].Cells["ASGNCODE"].Value);


                    if (plantcode == string.Empty)// || plantcode.Length != 2) // || getvalues("PLANTCODE",plantcode) == false)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 공장을 확인하세요.");
                        return;
                    }
                    if (ITEMTYPE == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 품목구분을 확인하세요.");
                        return;
                    }
                    if (itemcode == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 품목을 확인하세요.");
                        return;
                    }
                    if (ITEMNAME == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 품명을 확인하세요.");
                        return;
                    }
                    if (BASEUNIT == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 기본단위를 확인하세요.");
                        return;
                    }
                    if (INSPFLAG == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 검사구분을 확인하세요.");
                        return;
                    }
                    if (SAFESTOCK == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 안전재고를 확인하세요.");
                        return;
                    }
                    if (UNITCOST == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 단가를 확인하세요.");
                        return;
                    }
                    if (ASGNCODE == string.Empty)
                    {
                        MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 구매처를 확인하세요.");
                        return;
                    }


                    //if (ITEMTYPE == string.Empty || getvalues("ITEMTYPE", ITEMTYPE) == false)
                    //{
                    //    MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 품목구분을 확인하세요.");
                    //    return;
                    //} 
                    //if (ITEMTYPE == "ROH" && UNITWGT == string.Empty)
                    //{
                    //    MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 단위 중량을 확인하세요.");
                    //    return;
                    //}
                    //if (getvalues("INSPTYPE", Convert.ToString(grid1.Rows[i].Cells["INSPFLAG"].Value)) == false)
                    //{
                    //    MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 검사 구분을 확인하세요.");
                    //    return;
                    //}
                    //if (getvalues("WHCODE", Convert.ToString(grid1.Rows[i].Cells["WHCODE"].Value)) == false)
                    //{
                    //    MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 창고를 확인하세요.");
                    //    return;
                    //}
                    //if (getvalues("UseFlag", Convert.ToString(grid1.Rows[i].Cells["UseFlag"].Value)) == false)
                    //{
                    //    MessageBox.Show(Convert.ToString(i + 1) + "번째 열의 사용 여부를 확인하세요.");
                    //    return;
                    //} 
                }

                DataTable excelUpType = helper_Excel.FillTable("USP_EXCELUPLOADTYPE_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_FORMID", "TBM0100Y", DbType.String, ParameterDirection.Input));

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
                        helper.ExecuteNoneQuery("USP_POP_BM0100_I1"
                                          , CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMTYPE", Convert.ToString(grid1.Rows[i].Cells["ITEMTYPE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMNAME", Convert.ToString(grid1.Rows[i].Cells["ITEMNAME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_BASEUNIT", Convert.ToString(grid1.Rows[i].Cells["BASEUNIT"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_INSPFLAG", Convert.ToString(grid1.Rows[i].Cells["INSPFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_MATERIALGRADE", Convert.ToString(grid1.Rows[i].Cells["MATERIALGRADE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMSPEC", Convert.ToString(grid1.Rows[i].Cells["ITEMSPEC"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_CARTYPE", Convert.ToString(grid1.Rows[i].Cells["CARTYPE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_SAFESTOCK", Convert.ToString(grid1.Rows[i].Cells["SAFESTOCK"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITWGT", Convert.ToString(grid1.Rows[i].Cells["UNITWGT"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITCOST", Convert.ToString(grid1.Rows[i].Cells["UNITCOST"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ASGNCODE", Convert.ToString(grid1.Rows[i].Cells["ASGNCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));

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

                    MessageBox.Show("엑셀업로드 총 " + grid1.Rows.Count + "건 중 " + iOK.ToString() + "성공, " + iNG.ToString() + "실패하였습니다.");

                }
                else
                {
                    int iRow = 0;
                    DataTable DtGrid1 = (DataTable)grid1.DataSource;

                    //전체 Commit
                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        helper.ExecuteNoneQuery("USP_POP_BM0100_I1"
                                          , CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMTYPE", Convert.ToString(grid1.Rows[i].Cells["ITEMTYPE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMNAME", Convert.ToString(grid1.Rows[i].Cells["ITEMNAME"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_BASEUNIT", Convert.ToString(grid1.Rows[i].Cells["BASEUNIT"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_INSPFLAG", Convert.ToString(grid1.Rows[i].Cells["INSPFLAG"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_MATERIALGRADE", Convert.ToString(grid1.Rows[i].Cells["MATERIALGRADE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ITEMSPEC", Convert.ToString(grid1.Rows[i].Cells["ITEMSPEC"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_CARTYPE", Convert.ToString(grid1.Rows[i].Cells["CARTYPE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_SAFESTOCK", Convert.ToString(grid1.Rows[i].Cells["SAFESTOCK"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITWGT", Convert.ToString(grid1.Rows[i].Cells["UNITWGT"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_UNITCOST", Convert.ToString(grid1.Rows[i].Cells["UNITCOST"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_ASGNCODE", Convert.ToString(grid1.Rows[i].Cells["ASGNCODE"].Value), DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));

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
                        MessageBox.Show((iRow + 1).ToString() + "건이 정상적으로 등록되었습니다.");
                    }
                    else
                    {
                        helper.Rollback();
                        MessageBox.Show((iRow + 1).ToString() + "번째 줄에서 오류가 발생하였습니다." + Environment.NewLine + helper.RSMSG);
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
                openfiledialog.Filter = "EXCEL|*.xls|ALL|*.*";

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
                        drTarget["ITEMTYPE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["ITEMCODE"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["ITEMNAME"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        drTarget["BASEUNIT"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        drTarget["INSPFLAG"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["MATERIALGRADE"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["ITEMSPEC"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["CARTYPE"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["SAFESTOCK"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        drTarget["UNITWGT"] = Convert.ToString(dtExcelImport.Rows[i][10]);
                        drTarget["UNITCOST"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                        drTarget["ASGNCODE"] = Convert.ToString(dtExcelImport.Rows[i][12]);
                        //drTarget["USEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        //drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][14]);
                        drTarget["MAKER"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        //drTarget["MAKEDATE"] = Convert.ToString(dtExcelImport.Rows[i][16]);

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


        /*private void btnFileOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = "EXCEL|*.xls|ALL|*.*";

                if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //엑셀 파일 READ
                    DataTable dtExcelImport = GetExcel(openfiledialog.FileName);

                    string itemcode = string.Empty;
                    string inspflag = string.Empty;
                    string whcode = string.Empty;
                    string useflag = string.Empty;

                    //대상 GRID DataTable 복사(구조o, 데이터x)
                    DataTable dtTarget = ((DataTable)this.grid1.DataSource).Clone();

                    //엑셀파일에서 READ 된 DataTable로 등록할 데이터 DataTable에 저장
                    for (int i = 1; i < dtExcelImport.Rows.Count; i++)
                    {
                        DataRow drTarget = dtTarget.NewRow();

                        itemcode = Convert.ToString(dtExcelImport.Rows[i][3]) + Convert.ToString(dtExcelImport.Rows[i][2]);

                        if (Convert.ToString(dtExcelImport.Rows[i][1]) == "ROH" || Convert.ToString(dtExcelImport.Rows[i][1]) == "ROH4" || Convert.ToString(dtExcelImport.Rows[i][1]) == "ROH2")//원자재,구매품,부품
                        {
                            inspflag = "I";
                            whcode = "WH001";
                        }
                        else if (Convert.ToString(dtExcelImport.Rows[i][1]) == "HALB")//반제품
                        {
                            inspflag = "U";
                            whcode = "WH002";
                        }
                        else if (Convert.ToString(dtExcelImport.Rows[i][1]) == "FERT")//완제품
                        {
                            inspflag = "I";
                            whcode = "WH003";
                        }
                        else
                        {
                            whcode = Convert.ToString(dtExcelImport.Rows[i][10]);
                            inspflag = Convert.ToString(dtExcelImport.Rows[i][12]);
                        }

                        if (Convert.ToString(dtExcelImport.Rows[i][28]) == "")
                        {
                            useflag = "Y";
                        }
                        else
                        {
                            useflag = Convert.ToString(dtExcelImport.Rows[i][28]);
                        }

                        drTarget["PLANTCODE"] = Convert.ToString(dtExcelImport.Rows[i][0]);
                        drTarget["ITEMTYPE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                        drTarget["MAJORITEMTYPE"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                        drTarget["ProdItemCode"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        //  drTarget["ITEMCODE"]       = itemcode;
                        drTarget["ITEMNAME"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                        drTarget["BASEUNIT"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["UNITWGT"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        drTarget["UNITCOST"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        drTarget["MAKECOMPANY"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        drTarget["WHCODE"] = whcode;// Convert.ToString(dtExcelImport.Rows[i][10]);
                        drTarget["LOCCODE"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                        drTarget["INSPFLAG"] = inspflag;//Convert.ToString(dtExcelImport.Rows[i][12]);
                        drTarget["ITEMSPEC"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        drTarget["MATERIALGRADE"] = Convert.ToString(dtExcelImport.Rows[i][14]);
                        drTarget["MAXSTOCK"] = Convert.ToString(dtExcelImport.Rows[i][15]);
                        drTarget["SAFESTOCK"] = Convert.ToString(dtExcelImport.Rows[i][16]);
                        drTarget["CHANGEFLAG"] = Convert.ToString(dtExcelImport.Rows[i][17]);
                        drTarget["CHANGETIME"] = Convert.ToString(dtExcelImport.Rows[i][18]);
                        drTarget["MINORDERQTY"] = Convert.ToString(dtExcelImport.Rows[i][19]);
                        drTarget["ORDERQTY"] = Convert.ToString(dtExcelImport.Rows[i][20]);
                        drTarget["MAXORDERQTY"] = Convert.ToString(dtExcelImport.Rows[i][21]);
                        drTarget["ASGNCODE"] = Convert.ToString(dtExcelImport.Rows[i][22]);
                        drTarget["ASGNNAME"] = Convert.ToString(dtExcelImport.Rows[i][23]);
                        drTarget["ASGNSPHONE"] = Convert.ToString(dtExcelImport.Rows[i][24]);
                        drTarget["ASGNSEMAIL"] = Convert.ToString(dtExcelImport.Rows[i][25]);
                        drTarget["ASGNFAXNO"] = Convert.ToString(dtExcelImport.Rows[i][26]);
                        drTarget["ASGNADDRESS"] = Convert.ToString(dtExcelImport.Rows[i][27]);
                        drTarget["USEFLAG"] = useflag;//Convert.ToString(dtExcelImport.Rows[i][28]);
                        drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][29]);


                        
                        //drTarget["PLANTCODE"]      = Convert.ToString(dtExcelImport.Rows[i][0]);
                        //drTarget["ITEMTYPE"]       = Convert.ToString(dtExcelImport.Rows[i][1]);
                        //drTarget["ITEMCODE"] = itemcode;
                        //drTarget["ITEMNAME"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                        //drTarget["BASEUNIT"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                        //drTarget["INSPFLAG"] = inspflag;//Convert.ToString(dtExcelImport.Rows[i][12]);
                        //drTarget["MATERIALGRADE"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        //drTarget["ITEMSPEC"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        //drTarget["CARTYPE"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        //drTarget["SAFESTOCK"] = Convert.ToString(dtExcelImport.Rows[i][16]);
                        //drTarget["UNITWGT"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                        //drTarget["UNITCOST"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                        //drTarget["ASGNCODE"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                        //drTarget["USEFLAG"] = useflag;//Convert.ToString(dtExcelImport.Rows[i][28]);
                        //drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                        //drTarget["MAKER"] = Convert.ToString(dtExcelImport.Rows[i][12]);
                        //drTarget["MAKEDATE"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                        //drTarget["EDITOR"] = Convert.ToString(dtExcelImport.Rows[i][14]);
                        //drTarget["EDITDATE"] = Convert.ToString(dtExcelImport.Rows[i][15]);
                        

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
        */
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

        //콤보값 존재 확인 조회
        private bool getvalues(string Macode, string Micode)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT CODENAME");
                command.AppendLine("  FROM TBM0000                                                ");
                command.AppendLine(" WHERE USEFLAG = 'Y'");
                command.AppendLine("   and MAJORCODE = '" + Macode + "'");
                command.AppendLine("   and MINORCODE = '" + Micode + "'");
                //  command.AppendLine(" ORDER BY WORKCENTERCODE";

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                if (dttemp.Rows.Count > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                helper.Close();
            }
        }

    }
}

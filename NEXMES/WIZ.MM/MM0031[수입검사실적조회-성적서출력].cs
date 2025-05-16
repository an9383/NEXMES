#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0030
//   Form Name    : 수입검사대기현황조회
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-21
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM0031 : WIZ.Forms.BaseMDIChildForm
    {
        Thread trSelectPrintContents;

        #region < MEMBER AREA > 
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager();
        Common _Common = new Common();
        bool xlsVer = true;
        DataTable rtnDtTemp = new DataTable();
        //Microsoft.Office.Interop.Excel.Application excelApp = null;
        //Microsoft.Office.Interop.Excel.Workbook wb = null;
        //Microsoft.Office.Interop.Excel.Worksheet ws1 = null; //sheet1
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        #endregion

        #region < CONSTRUCTOR >
        public MM0031()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MM0031_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            //그리드 객체 생성
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPDATE", "검사일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SEQNO", "차수", true, GridColDataType_emu.VarChar, 50, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTINSPRESULT", "종합검사결과", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사항목", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT", "검사결과", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPVALUE", "검사값", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "검사자", true, GridColDataType_emu.VarChar, 90, 130, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "검사일시", true, GridColDataType_emu.DateTime, 180, 130, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            string[] arrMerCol1 = { "INSPCODE", "INSPNAME", "INSPRESULT", "INSPVALUE", "SPECLSL", "SPECUSL" };

            _GridUtil.GridHeaderMerge(grid1, "A", "개별판정", arrMerCol1, null);
            //_GridUtil.SetColumnMerge(this,grid1, "SEQNO");
            #endregion

            #region < COMBOBOX SETTING >
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("OKNG");  //종합검사결과
            WIZ.Common.FillComboboxMaster(this.cbo_TOTINSPRESULT_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            #endregion

            #region < POPUP SETTING >
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });
            #endregion

        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");
                string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");
                string sLotNo = DBHelper.nvlString(txt_LOTNO_H.Text.Trim());
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sTotInspResult = DBHelper.nvlString(cbo_TOTINSPRESULT_H.Value);

                rtnDtTemp = helper.FillTable("USP_MM0030_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_INSPRESULT", sTotInspResult, DbType.String, ParameterDirection.Input));
                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                grid1.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                grid1.DisplayLayout.Bands[0].Columns["TOTINSPRESULT"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["TOTINSPRESULT"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                grid1.DisplayLayout.Bands[0].Columns["INSPDATE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["INSPDATE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;


                grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                grid1.DisplayLayout.Bands[0].Columns["SEQNO"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["SEQNO"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (grid1.Rows[i].Cells["TOTINSPRESULT"].Value.ToString() == "NG")
                    {
                        grid1.Rows[i].Cells["TOTINSPRESULT"].Appearance.BackColor = Color.LightPink;
                    }
                    else
                    {
                        grid1.Rows[i].Cells["TOTINSPRESULT"].Appearance.BackColor = Color.DarkCyan;
                        grid1.Rows[i].Cells["TOTINSPRESULT"].Appearance.ForeColor = Color.White;
                    }

                    if (grid1.Rows[i].Cells["INSPRESULT"].Value.ToString() == "NG")
                    {
                        grid1.Rows[i].Cells["INSPRESULT"].Appearance.BackColor = Color.LightPink;
                    }
                    else
                    {
                        grid1.Rows[i].Cells["INSPRESULT"].Appearance.BackColor = Color.DarkCyan;
                        grid1.Rows[i].Cells["INSPRESULT"].Appearance.ForeColor = Color.White;
                    }
                }

            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
        #endregion
        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();

            }
        }

        private void btn_PRINT_PC_Click(object sender, EventArgs e)
        {
            if (grid1.ActiveCell == null)
            {
                return;
            }

            DBHelper helper;
            helper = new DBHelper(false);

            try
            {
                string sLotNo = DBHelper.nvlString(grid1.ActiveRow.Cells["LOTNO"].Value);
                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);

                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("exec USP_CALLPRINT_I1 ");
                sSQL.Append("  @AS_PLANTCODE = '" + sPlantCode + "'");
                sSQL.Append(", @AS_LOTNO = '" + sLotNo + "' ");
                sSQL.Append(", @AS_WORKCENTERCODE = '" + "MM0031" + "' ");
                sSQL.Append(", @AS_CIP = '' ");

                helper.ExecuteNoneQuery(sSQL.ToString());
            }

            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
        }
        //private void btn_PRINT_PC_Click(object sender, EventArgs e)
        //{


        //    if (grid1.ActiveCell == null)
        //        return;

        //    for (int grid1rowNUM = 0; grid1rowNUM < grid1.Rows.Count; grid1rowNUM++)
        //    {
        //        //if (grid1.Rows[grid1rowNUM].Cells["CHK"].Value.ToString() == "1")
        //        //{
        //        //    this.ShowDialog("일괄출가 불가 항목", WIZ.Forms.DialogForm.DialogType.OK);
        //        //    return;
        //        //}
        //    }

        //    string sFileName = string.Empty;
        //    string sUserName = string.Empty;

        //    DBHelper helper;
        //    helper = new DBHelper(false);

        //    DataTable TUserName = new DataTable(); //로그인 작업자 이름 확인
        //    TUserName = helper.FillTable("select WORKERNAME FROM TSY0030 WITH (NOLOCK) where WORKERID = '" + WIZ.LoginInfo.UserID + "' ");

        //    uint processId = 0;

        //    try
        //    {
        //        excelApp = new Microsoft.Office.Interop.Excel.Application();

        //        //수입검사 실적조회 그리드 내용
        //        string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
        //        string sInspDate = DBHelper.nvlString(grid1.ActiveRow.Cells["INSPDATE"].Value);
        //        string sLotNo = DBHelper.nvlString(grid1.ActiveRow.Cells["LOTNO"].Value);
        //        string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
        //        string sItemName = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
        //        string sSeqNo = DBHelper.nvlString(grid1.ActiveRow.Cells["SEQNO"].Value);
        //        string sTotInspResult = DBHelper.nvlString(grid1.ActiveRow.Cells["TOTINSPRESULT"].Value);
        //        string sInspCode = DBHelper.nvlString(grid1.ActiveRow.Cells["INSPCODE"].Value);
        //        string sInspName = DBHelper.nvlString(grid1.ActiveRow.Cells["INSPNAME"].Value);
        //        string sInspResult = DBHelper.nvlString(grid1.ActiveRow.Cells["INSPRESULT"].Value);
        //        string sInspValue = DBHelper.nvlString(grid1.ActiveRow.Cells["INSPVALUE"].Value);
        //        string sSpeclsl = DBHelper.nvlString(grid1.ActiveRow.Cells["SPECLSL"].Value);
        //        string sSpecusl = DBHelper.nvlString(grid1.ActiveRow.Cells["SPECUSL"].Value);
        //       // string sItemSpec = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMSPEC"].Value);
        //        string sMakeDate = DBHelper.nvlString(grid1.ActiveRow.Cells["MAKEDATE"].Value);
        //       // string sIndate = DBHelper.nvlString(grid1.ActiveRow.Cells["INDATE"].Value);
        //        //string sLotQty = DBHelper.nvlString(grid1.ActiveRow.Cells["LOTQTY"].Value);
        //        sUserName = DBHelper.nvlString(grid1.ActiveRow.Cells["MAKER"].Value);


        //        sFileName = "GENOSS1.xls";
        //        wb = excelApp.Workbooks.Open(Application.StartupPath + "\\EXCEL\\" + sFileName);
        //       // wb = excelApp.Workbooks.Open(Application.StartupPath + @"\" + sFileName);
        //        ws1 = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel.Worksheet;
        //        Microsoft.Office.Interop.Excel.Range rng = ws1.UsedRange;   //현재 시트에서 사용중인 범위
        //        object[,] data = rng.Value; //범위의 데이터

        //        //LOT 정보
        //        ws1.Cells[2, 3] = sItemName;
        //        ws1.Cells[2, 15] = sInspDate;
        //        ws1.Cells[3, 3] = sItemCode;
        //        ws1.Cells[3, 15] = sUserName;
        //        ws1.Cells[4, 3] = sLotNo;
        //        ws1.Cells[24, 14] = DateTime.Now.ToString();

        //        //(1)검사항목===============================================
        //        DataTable dtproc1 = helper.FillTable("USP_MM0031_S2", CommandType.StoredProcedure
        //                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
        //                                                            , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
        //                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
        //                                                            , helper.CreateParameter("AS_INSPRESULT", sTotInspResult, DbType.String, ParameterDirection.Input));

        //        for (int i = 0; i < dtproc1.Rows.Count; i++)
        //        {
        //            ws1.Cells[8 + i, 2] = dtproc1.Rows[i]["INSPNAME"].ToString();
        //            ws1.Cells[8 + i, 3] = dtproc1.Rows[i]["REMARK"].ToString();
        //            ws1.Cells[8 + i, 7] = dtproc1.Rows[i]["INSPRESULT"].ToString();
        //        }
        //        ws1.Cells[2, 11] = DBHelper.nvlDateTime(dtproc1.Rows[0]["TMPINDATE"]);
        //        ws1.Cells[3, 7] = DBHelper.nvlString(dtproc1.Rows[0]["ITEMSPEC"]);
        //        ws1.Cells[3, 7] = DBHelper.nvlString(dtproc1.Rows[0]["ITEMSPEC"]);
        //        ws1.Cells[21, 13] = DBHelper.nvlString(dtproc1.Rows[0]["TOTINSPRESULT"]);



        //        //페이지 세팅
        //        ws1.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4; // A4로 설정
        //        ws1.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape; //가로로 출력

        //        if (xlsVer)
        //        {
        //            //ws1.PrintOutEx(Type.Missing, Type.Missing, Type.Missing, Type.Missing,"Microsoft Print to PDF", Type.Missing, Type.Missing, Type.Missing);  
        //            ws1.PrintOut(1, 1, 1, false); // (시작 페이지 번호, 마지막 페이지 번호, 출력 장 수, 프리뷰 활성 유/무)

        //            // Clean up
        //            wb.Close(0);
        //            excelApp.Quit();
        //            processId = 0;
        //            GetWindowThreadProcessId(new IntPtr(excelApp.Hwnd), out processId);
        //            excelApp.Quit();
        //            ReleaseExcelObject(ws1);
        //            ReleaseExcelObject(wb);
        //            ReleaseExcelObject(excelApp);

        //            excelApp = null;
        //            wb = null;

        //            if (processId != 0)
        //            {
        //                System.Diagnostics.Process excelProcess = System.Diagnostics.Process.GetProcessById((int)processId);
        //                excelProcess.CloseMainWindow();
        //                excelProcess.Refresh();
        //                excelProcess.Kill();
        //            }
        //        }//  if (xlsVer)
        //    }
        //    catch (Exception ex)
        //    {
        //        if (processId != 0)
        //        {
        //            System.Diagnostics.Process excelProcess = System.Diagnostics.Process.GetProcessById((int)processId);
        //            excelProcess.CloseMainWindow();
        //            excelProcess.Refresh();
        //            excelProcess.Kill();
        //        }
        //        this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
        //    }
        //}
    }
}
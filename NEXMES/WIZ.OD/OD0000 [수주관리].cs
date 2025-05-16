#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : OD0000
//   Form Name    : 금형수리현황
//   Name Space   : WIZ.MD
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 금형수리현황
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WIZ.PopUp;
using Excel = Microsoft.Office.Interop.Excel;

#endregion

namespace WIZ.OD
{
    public partial class OD0000 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();

        DataSet DSgrid1 = new DataSet();
        DataSet DSgrid2 = new DataSet();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        Common _Common = new Common();

        string file_path = "";
        int odtype = 0;

        #endregion

        #region < CONSTRUCTOR >
        public OD0000()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void OD0000_Load(object sender, EventArgs e)
        {
            #region GRID SETTING  
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "상태", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "고객사", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_date", "수주일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_LotNO", "수주LOT", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD1_CHA", "차수", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "CHK", "상태", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_LotNo", "수주LOT", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTCODE", "고객사코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME", "고객사명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_OrderDate", "발주일", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_FixedDate", "납기일", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_PartName", "품목명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_OrderQTY", "발주량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_UnitCost", "단가", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_Money", "금액", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_Residual", "잔량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_HRS", "HRS재고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_Amount", "평균사용량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_PoNo", "발주고유번호", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_Type", "유형", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD_ETC3", "비고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid3, "CHK", "품목유무", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "OD3_PartName", "품목명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "OD3_PoNo", "발주고유번호", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "OD3_OrderQTY", "발주량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "OD3_UnitCost", "단가", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "OD3_Money", "금액", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "OD3_ETC4", "비고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid3);

            _GridUtil.InitializeGrid(this.grid4, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid4, "OD_ITEMCODE", "품목코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "OD_PartName", "품목명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "OD_OrderQTY", "총수량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "OD_MONEY", "총금액", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "OD_ETC", "비고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid4);

            DTP1.Value = DateTime.Today.AddDays(-30);
            DTP2.Value = DateTime.Today;

            #endregion

            #region < COMBOBOX SETTING  >

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            #endregion

            #region < POPUP SETTING >

            //BizGridManager bizGridManager = new BizGridManager(grid1);

            #endregion
        }

        private void GridSetting()
        {
        }
        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid2);
            _GridUtil.Grid_Clear(grid3);
            _GridUtil.Grid_Clear(grid4);

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_OD0000_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("RS_SDate", DTP1.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("RS_EDate", DTP2.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input));


                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
                else
                {
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoNew()
        {

        }

        public override void DoSave()
        {

        }

        public override void DoImportExcel()
        {
            base.DoImportExcel();
            base.DoInquire();
        }

        #endregion

        #region < METHOD AREA >

        #endregion

        private void gbxBody_Click(object sender, EventArgs e)
        {

        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            // 그리드2번에 등록된 수주현황 보여주기 
            DBHelper helper = new DBHelper(false);

            if (grid1.ActiveCell == null)
            {
                return;
            }

            try
            {
                _GridUtil.Grid_Clear(grid2);
                _GridUtil.Grid_Clear(grid3);
                _GridUtil.Grid_Clear(grid4);

                string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);
                string sLOTNO = CModule.ToString(grid1.ActiveRow.Cells["OD_LotNO"].Value);

                rtnDtTemp = helper.FillTable("USP_OD0000_S2", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("RS_LotNo", sLOTNO, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds();
                }
                else
                {
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                /*
                // 그리드 3번에 미등록 품목명 보여주기 
                rtnDtTemp = helper.FillTable("USP_OD0000_S3", CommandType.StoredProcedure
                    , helper.CreateParameter("RS_LotNo", sLOTNO, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid3.DataSource = rtnDtTemp;
                    grid3.DataBinds();
                }
                else
                {
                    return;
                }
                */

                // 그리드 4번에 등록된 수주현황의 단가 집계 보여주기 

                rtnDtTemp = helper.FillTable("USP_OD0000_S4", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_LOTNO", sLOTNO, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid4.DataSource = rtnDtTemp;
                    grid4.DataBinds();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void btn_path_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file_path = openFileDialog1.FileName;
                txtFILEPATH.Text = file_path;
            }
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            if (txtFILEPATH.Text == "")
            {
                this.ShowDialog("파일경로를 선택해주세요.", Forms.DialogForm.DialogType.OK);
            }
            else
            {
                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid2);
                _GridUtil.Grid_Clear(grid3);
                _GridUtil.Grid_Clear(grid4);

                Excel.Application excelApp = null;
                Excel.Workbook workBook = null;
                Excel.Worksheet workSheet = null;

                DataTable table = new DataTable();

                try
                {
                    DBHelper helper = new DBHelper(false);
                    rtnDtTemp = helper.FillTable("USP_OD0000_S5", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_SEARCHDATE", DateTime.Today.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input));

                    string cnt = Convert.ToString(rtnDtTemp.Rows[0]["cnt"]);

                    string path = openFileDialog1.FileName;// 엑셀 파일 경로 

                    string str = "";
                    double? dou = 0;
                    int dgv = 0;

                    excelApp = new Excel.Application();       // 엑셀 어플리케이션 생성 
                    workBook = excelApp.Workbooks.Open(path); // 워크북 열기 
                    workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기 
                    Excel.Range range = workSheet.UsedRange;  // 사용중인 셀 범위를 가져오기

                    grid2.Visible = false;
                    for (int row = 6; row <= range.Rows.Count; row++) // 가져온 행 만큼 반복 
                    {
                        grid2.InsertRow();
                        grid2.Rows[dgv].Cells["CHK"].Value = "조회";
                        grid2.Rows[dgv].Cells["OD_LotNo"].Value = "OD" + DateTime.Today.ToString("yyyyMMdd") + "A" + cnt;
                        grid2.Rows[dgv].Cells["CUSTCODE"].Value = "CT0001";
                        grid2.Rows[dgv].Cells["CUSTNAME"].Value = "HRS";
                        grid2.Rows[dgv].Cells["OD_OrderDate"].Value = (string)(range.Cells[row, 1] as Excel.Range).Value2;
                        grid2.Rows[dgv].Cells["OD_FixedDate"].Value = (string)(range.Cells[row, 3] as Excel.Range).Value2;
                        grid2.Rows[dgv].Cells["OD_PartName"].Value = (string)(range.Cells[row, 4] as Excel.Range).Value2;
                        grid2.Rows[dgv].Cells["OD_PoNo"].Value = (string)(range.Cells[row, 12] as Excel.Range).Value2;
                        grid2.Rows[dgv].Cells["OD_Type"].Value = (string)(range.Cells[row, 13] as Excel.Range).Value2;
                        grid2.Rows[dgv].Cells["OD_OrderQTY"].Value = (range.Cells[row, 5] as Excel.Range).Value2;
                        grid2.Rows[dgv].Cells["OD_UnitCost"].Value = (range.Cells[row, 7] as Excel.Range).Value2;
                        grid2.Rows[dgv].Cells["OD_Money"].Value = (range.Cells[row, 8] as Excel.Range).Value2;
                        grid2.Rows[dgv].Cells["OD_Residual"].Value = (range.Cells[row, 9] as Excel.Range).Value2;
                        grid2.Rows[dgv].Cells["OD_HRS"].Value = (range.Cells[row, 10] as Excel.Range).Value2;
                        grid2.Rows[dgv].Cells["OD_Amount"].Value = (range.Cells[row, 11] as Excel.Range).Value2;

                        dgv++;
                        #region 구버전
                        /*for (int column = 1; column <= 15; column++) // 가져온 열 만큼 반복                      
                        {
                            if (column == 1)
                            {
                                grid2.InsertRow();
                            }
                            if ((column == 2 || column == 5 || column == 6 || column == 7 || column == 8 || column == 9 || column == 10 || column == 11 || column == 14) == false)
                            {
                                str = (string)(range.Cells[row, column] as Excel.Range).Value2; // 셀 데이터 가져옴
                                if (column == 1)
                                {
                                    grid2.Rows[dgv].Cells["OD2_State"].Value = "조회";
                                    grid2.Rows[dgv].Cells["OD2_LotNo"].Value = "OD" + DateTime.Today.ToString("yyyyMMdd") + "A" + cnt;
                                    grid2.Rows[dgv].Cells["OD2_date"].Value = DateTime.Today.ToString("yyyy-MM-dd");
                                    grid2.Rows[dgv].Cells["OD2_Vend"].Value = "HRS";
                                    grid2.Rows[dgv].Cells["OD2_OrderDate"].Value = str;
                                }
                                else if (column == 3)
                                {
                                    grid2.Rows[dgv].Cells["OD2_FixedDate"].Value = str;
                                }
                                else if (column == 4)
                                {
                                    grid2.Rows[dgv].Cells["OD2_PartName"].Value = str;
                                }
                                else if (column == 12)
                                {
                                    grid2.Rows[dgv].Cells["OD2_PoNo"].Value = str;
                                }
                                else if (column == 13)
                                {
                                    grid2.Rows[dgv].Cells["OD2_Type"].Value = str;
                                }
                            }

                            if ((column == 5 || column == 7 || column == 8 || column == 9 || column == 10 || column == 11) == true)
                            {
                                dou = (range.Cells[row, column] as Excel.Range).Value2; // 셀 데이터 가져옴
                                if (column == 5)
                                {
                                    grid2.Rows[dgv].Cells["OD2_OrderQTY"].Value = dou;
                                }
                                else if (column == 7)
                                {
                                    grid2.Rows[dgv].Cells["OD2_UnitCost"].Value = dou;
                                }
                                else if (column == 8)
                                {
                                    grid2.Rows[dgv].Cells["OD2_Money"].Value = dou;
                                }
                                else if (column == 9)
                                {
                                    grid2.Rows[dgv].Cells["OD2_Residual"].Value = dou;
                                }
                                else if (column == 10)
                                {
                                    grid2.Rows[dgv].Cells["OD2_HRS"].Value = dou;
                                }
                                else if (column == 11)
                                {
                                    grid2.Rows[dgv].Cells["OD2_Amount"].Value = dou;
                                }
                            }

                            if (column == 14)
                            {
                                dgv++;
                            }
                        }*/
                        #endregion
                    }
                    workBook.Close(true); // 워크북 닫기 
                    excelApp.Quit(); // 엑셀 어플리케이션 종료
                    grid2.Visible = true;
                }
                catch (Exception ex)
                {
                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
                finally
                {
                    ReleaseObject(workSheet);
                    ReleaseObject(workBook);
                    ReleaseObject(excelApp);
                }
            }
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj); // 액셀 객체 해제
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
                GC.Collect(); // 가비지 수집
            }
        }

        private void btn_MSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid2.Rows.Count > 0)
                {
                    if (this.ShowDialog("작업하던 사항이 있습니다. 초기화하시겠습니까?", Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
                    {
                        _GridUtil.Grid_Clear(grid1);
                        _GridUtil.Grid_Clear(grid2);
                        _GridUtil.Grid_Clear(grid3);
                        _GridUtil.Grid_Clear(grid4);
                    }

                    OD0000_POP mbp = new OD0000_POP();
                    mbp.trGrid = grid2;
                    mbp.ShowDialog();
                }
                else
                {
                    OD0000_POP mbp = new OD0000_POP();
                    mbp.trGrid = grid2;
                    mbp.ShowDialog();
                }
            }
            catch
            {

            }
        }


        private void btn_Check_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            _GridUtil.Grid_Clear(grid3);
            try
            {
                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    DSgrid1 = helper.FillDataSet("USP_OD0000_S6", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_SearchPoNo", grid2.Rows[i].Cells["OD_PoNo"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMNAME", grid2.Rows[i].Cells["OD_PartName"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CUSTCODE", grid2.Rows[i].Cells["CUSTCODE"].Value, DbType.String, ParameterDirection.Input));

                    if (DSgrid1.Tables[0].Rows.Count > 0)
                    {
                        grid2.Rows[i].Cells["CHK"].Value = "중복";
                    }
                    else if (DSgrid1.Tables[1].Rows.Count == 0)
                    {
                        int iRow = grid3.InsertRow();

                        //그리드 2에 품목마스터에 없는 품목이라 저장불가 상태를 보여줌
                        grid2.Rows[i].Cells["CHK"].Value = "저장불가";

                        //그리드 3에 품목마스터에 없는 품목을 보여줌(수주내용 기반)
                        grid3.Rows[iRow].Cells["CHK"].Value = "없음";
                        grid3.Rows[iRow].Cells["OD3_PartName"].Value = grid2.Rows[i].Cells["OD_PartName"].Value;
                        grid3.Rows[iRow].Cells["OD3_PoNo"].Value = grid2.Rows[i].Cells["OD_PoNo"].Value;
                        grid3.Rows[iRow].Cells["OD3_OrderQTY"].Value = grid2.Rows[i].Cells["OD_OrderQTY"].Value;
                        grid3.Rows[iRow].Cells["OD3_UnitCost"].Value = grid2.Rows[i].Cells["OD_UnitCost"].Value;
                        grid3.Rows[iRow].Cells["OD3_Money"].Value = grid2.Rows[i].Cells["OD_Money"].Value;
                        grid3.Rows[iRow].Cells["OD3_ETC4"].Value = grid2.Rows[i].Cells["OD_ETC3"].Value;
                    }
                    else
                    {
                        grid2.Rows[i].Cells["CHK"].Value = "저장가능";
                    }
                }
                this.ShowDialog("수주검사가 완료되었습니다.", Forms.DialogForm.DialogType.OK);
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            if (grid2.Rows.Count <= 0)
            {
                this.ShowDialog("등록할 내용이 없습니다.", Forms.DialogForm.DialogType.OK);
            }

            else if (this.ShowDialog("수주검사를 하셨습니까?", Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
            {
                try
                {
                    for (int j = 0; j < grid2.Rows.Count; j++)
                    {
                        if (Convert.ToString(grid2.Rows[j].Cells["CHK"].Value) == "저장가능")
                        {
                            if (Convert.ToString(grid2.Rows[j].Cells["OD_LotNo"].Value).Contains("A"))
                            {
                                odtype = 0;
                            }
                            else if (Convert.ToString(grid2.Rows[j].Cells["OD_LotNo"].Value).Contains("M"))
                            {
                                odtype = 1;
                            }

                            //저장, 수정
                            helper.ExecuteNoneQuery("USP_OD0000_SAVE", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                              , helper.CreateParameter("AS_OD_LotNo", grid2.Rows[j].Cells["OD_LotNo"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OD_Vend", grid2.Rows[j].Cells["CUSTCODE"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OD_OrderDate", grid2.Rows[j].Cells["OD_OrderDate"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OD_FixedDate", grid2.Rows[j].Cells["OD_FixedDate"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OD_PartName", grid2.Rows[j].Cells["OD_PartName"].Value, DbType.String, ParameterDirection.Input)

                              , helper.CreateParameter("AS_OD_OrderQTY", Convert.ToInt32(grid2.Rows[j].Cells["OD_OrderQTY"].Value), DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OD_UnitCost", grid2.Rows[j].Cells["OD_UnitCost"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OD_Money", grid2.Rows[j].Cells["OD_Money"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OD_Residual", grid2.Rows[j].Cells["OD_Residual"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OD_HRS", grid2.Rows[j].Cells["OD_HRS"].Value, DbType.String, ParameterDirection.Input)

                              , helper.CreateParameter("AS_OD_Amount", grid2.Rows[j].Cells["OD_Amount"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OD_PoNo", grid2.Rows[j].Cells["OD_PoNo"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OD_Type", grid2.Rows[j].Cells["OD_Type"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OD_ETC1", odtype, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OD_ETC3", grid2.Rows[j].Cells["OD_ETC3"].Value, DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE == "E")
                            {
                                throw new Exception(helper.RSMSG);
                            }
                            helper.Commit();
                        }
                    }
                    this.ShowDialog("수주등록이 완료되었습니다.", Forms.DialogForm.DialogType.OK);
                    DoInquire();
                }

                catch (Exception ex)
                {
                    helper.Rollback();
                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
                finally
                {
                    helper.Close();
                    ClosePrgFormNew();
                }
            }
        }

    }
}

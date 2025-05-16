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
    public partial class OD0010 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        DataSet DSgrid = new DataSet();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        Common _Common = new Common();

        string file_path = "";

        #endregion

        #region < CONSTRUCTOR >
        public OD0010()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void OD0000_Load(object sender, EventArgs e)
        {
            GridSetting();

            DTP1.Value = DateTime.Today.AddDays(-30);
            DTP2.Value = DateTime.Today;

            #endregion

            #region COMBOBOX SETTING 

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            #endregion

            #region POPUP SETTING

            //BizGridManager bizGridManager = new BizGridManager(grid1);

            #endregion
        }

        private void GridSetting()
        {
            #region GRID SETTING  
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "OD1_Chk", "상태", true, GridColDataType_emu.VarChar, 30, 100, Infragistics.Win.HAlign.Center, true, false); // 등록상태
            _GridUtil.InitColumnUltraGrid(grid1, "OD1_Vend", "고객사", true, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, true, false);  // 고객사       
            _GridUtil.InitColumnUltraGrid(grid1, "OD1_date", "등록일자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);  // 등록일자 
            _GridUtil.InitColumnUltraGrid(grid1, "OD1_LotNo", "수주LOT", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);  // 수주고유번호
            _GridUtil.InitColumnUltraGrid(grid1, "OD1_cha", "차수", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false);  // 등록 차수

            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "OD2_State", "상태", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_LotNo", "수주LOT", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_date", "등록일자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.InitColumnUltraGrid(grid2, "OD2_PartName", "품목명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_OrderDate", "요청일", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_Degree", "차수", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_Num", "번호", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_Type", "구분", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_Vend", "거래처명", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.InitColumnUltraGrid(grid2, "OD2_OrderQTY", "지시량", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_Residual", "잔량", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_UnitQTY", "단위수량", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_Materialcode", "거래처자재코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_Label", "라벨사양", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.InitColumnUltraGrid(grid2, "OD2_H", "H/Free", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_B", "B/Free", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_Rohs", "Rohs Free", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_PartCode", "품목코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OD2_VendPartCode", "거래처자재코드명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid2);


            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid3, "OD3_PartName", "품목명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false); // 사용자 입력
            _GridUtil.InitColumnUltraGrid(grid3, "OD3_OrderQTY", "발주량", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false); // 사용자 입력
            _GridUtil.InitColumnUltraGrid(grid3, "OD3_UnitCost", "단가", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false); // 사용자 입력
            _GridUtil.InitColumnUltraGrid(grid3, "OD3_Money", "금액", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false); // 바코드
            _GridUtil.InitColumnUltraGrid(grid3, "OD3_ETC4", "비고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false); // 바코드

            _GridUtil.SetInitUltraGridBind(grid3);


            _GridUtil.InitializeGrid(this.grid4, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid4, "OD4_PartName", "수주형태", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false); // 사용자 입력
            _GridUtil.InitColumnUltraGrid(grid4, "OD4_OrderQTY", "총수량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false); // 사용자 입력
            _GridUtil.InitColumnUltraGrid(grid4, "OD4_Money", "총금액", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false); // 사용자 입력
            _GridUtil.InitColumnUltraGrid(grid4, "OD4_ETC5", "비고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false); // 바코드

            _GridUtil.SetInitUltraGridBind(grid4);
        }
        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

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
                string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);
                string sMoldCode = CModule.ToString(grid1.ActiveRow.Cells["OD1_LotNo"].Value);
                {

                    try
                    {
                        rtnDtTemp = helper.FillTable("USP_OD0000_S2", CommandType.StoredProcedure
                            , helper.CreateParameter("RS_LotNo", sMoldCode, DbType.String, ParameterDirection.Input));


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
            }
            catch (Exception ex)
            {
                //this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
            }


            // 그리드 3번에 미등록 품목명 보여주기 
            _GridUtil.Grid_Clear(grid3);
            //DBHelper helper = new DBHelper(false);

            if (grid1.ActiveCell == null)
            {
                return;
            }

            try
            {
                string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);
                string sMoldCode = CModule.ToString(grid1.ActiveRow.Cells["OD1_LotNo"].Value);

                try
                {
                    rtnDtTemp = helper.FillTable("USP_OD0000_S3", CommandType.StoredProcedure
                        , helper.CreateParameter("RS_LotNo", sMoldCode, DbType.String, ParameterDirection.Input));


                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid3.DataSource = rtnDtTemp;
                        grid3.DataBinds();
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
            catch (Exception ex)
            {
                //this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
            }

            // 그리드 4번에 등록된 수주현황의 단가 집계 보여주기 
            _GridUtil.Grid_Clear(grid4);
            //DBHelper helper = new DBHelper(false);

            if (grid1.ActiveCell == null)
            {
                return;
            }

            try
            {
                string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);
                string sMoldCode = CModule.ToString(grid1.ActiveRow.Cells["OD1_LotNo"].Value);

                try
                {
                    rtnDtTemp = helper.FillTable("USP_OD0000_S4", CommandType.StoredProcedure
                        , helper.CreateParameter("RS_LotNo", sMoldCode, DbType.String, ParameterDirection.Input));


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
            catch (Exception ex)
            {
                //this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
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

                    string path = openFileDialog1.FileName;// 엑셀 파일 저장 경로 

                    string str = "";
                    double? dou = 0;
                    int dgv = 0;

                    excelApp = new Excel.Application();       // 엑셀 어플리케이션 생성 
                    workBook = excelApp.Workbooks.Open(path); // 워크북 열기 
                    workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기 
                    Excel.Range range = workSheet.UsedRange;  // 사용중인 셀 범위를 가져오기

                    for (int row = 2; row <= range.Rows.Count; row++) // 가져온 행 만큼 반복 
                    {
                        for (int column = 1; column <= 16; column++) // 가져온 열 만큼 반복 
                        {
                            if (column == 1)
                            {
                                grid2.InsertRow();
                            }
                            if ((column == 1 || column == 2 || column == 3 || column == 5 || column == 6 || column == 10 || column == 11 || column == 12 || column == 13 || column == 14 || column == 15 || column == 16) == true)
                            {
                                str = (string)(range.Cells[row, column] as Excel.Range).Value2; // 셀 데이터 가져옴
                                if (column == 1)
                                {
                                    grid2.Rows[dgv].Cells["OD2_State"].Value = "조회";
                                    //grid2.Rows[dgv].Cells["OD2_LotNo"].Value = "OD" + DateTime.Today.ToString("yyyyMMdd") + "A";
                                    //grid2.Rows[dgv].Cells["OD2_date"].Value  = DateTime.Today.ToString("yyyy-MM-dd");
                                    grid2.Rows[dgv].Cells["OD2_Partname"].Value = str;
                                }
                                else if (column == 2)
                                {
                                    grid2.Rows[dgv].Cells["OD2_OrderDate"].Value = str;
                                }
                                else if (column == 3)
                                {
                                    grid2.Rows[dgv].Cells["OD2_Degree"].Value = str;
                                }
                                else if (column == 5)
                                {
                                    grid2.Rows[dgv].Cells["OD2_Type"].Value = str;
                                }
                                else if (column == 6)
                                {
                                    grid2.Rows[dgv].Cells["OD2_Vend"].Value = str;
                                }
                                else if (column == 10)
                                {
                                    grid2.Rows[dgv].Cells["OD2_Materialcode"].Value = str;
                                }
                                else if (column == 11)
                                {
                                    grid2.Rows[dgv].Cells["OD2_Label"].Value = str;
                                }
                                else if (column == 12)
                                {
                                    grid2.Rows[dgv].Cells["OD2_H"].Value = str;
                                }
                                else if (column == 13)
                                {
                                    grid2.Rows[dgv].Cells["OD2_B"].Value = str;
                                }
                                else if (column == 14)
                                {
                                    grid2.Rows[dgv].Cells["OD2_Rohs"].Value = str;
                                }
                                else if (column == 15)
                                {
                                    grid2.Rows[dgv].Cells["OD2_PartCode"].Value = str;
                                }
                                else if (column == 16)
                                {
                                    grid2.Rows[dgv].Cells["OD2_VendPartCode"].Value = str;
                                }
                            }

                            if ((column == 4 || column == 7 || column == 8 || column == 9) == true)
                            {
                                dou = (range.Cells[row, column] as Excel.Range).Value2; // 셀 데이터 가져옴
                                if (column == 4)
                                {
                                    grid2.Rows[dgv].Cells["OD2_Num"].Value = dou;
                                }
                                else if (column == 7)
                                {
                                    grid2.Rows[dgv].Cells["OD2_OrderQTY"].Value = dou;
                                }
                                else if (column == 8)
                                {
                                    grid2.Rows[dgv].Cells["OD2_Residual"].Value = dou;
                                }
                                else if (column == 9)
                                {
                                    grid2.Rows[dgv].Cells["OD2_UnitQTY"].Value = dou;
                                }
                            }

                            if (column == 16)
                            {
                                dgv++;
                            }
                        }
                    }

                    workBook.Close(true); // 워크북 닫기 
                    excelApp.Quit(); // 엑셀 어플리케이션 종료
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
            if (grid2.Rows.Count > 0)
            {
                if (Convert.ToString(grid2.Rows[0].Cells["OD2_LotNo"].Value).Contains("A"))
                {
                    if (this.ShowDialog("작업하던 사항이 있습니다. 초기화하시겠습니까?", Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
                    {
                        grid1.DataSource = null;
                        grid2.DataSource = null;
                        grid3.DataSource = null;
                        grid4.DataSource = null;

                        GridSetting();

                        try
                        {
                            OD0000_POP mbp = new OD0000_POP();
                            mbp.trGrid = grid2;
                            mbp.crGrid = grid3;
                            mbp.ShowDialog(this);
                        }

                        catch
                        {

                        }
                    }
                }
                else
                {
                    try
                    {
                        OD0000_POP mbp = new OD0000_POP();
                        mbp.trGrid = grid2;
                        mbp.crGrid = grid3;
                        mbp.ShowDialog(this);
                    }

                    catch
                    {

                    }
                }
            }
            else
            {
                try
                {
                    OD0000_POP mbp = new OD0000_POP();
                    mbp.trGrid = grid2;
                    mbp.crGrid = grid3;
                    mbp.ShowDialog(this);
                }

                catch
                {

                }
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

        private void btn_Check_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            for (int i = 0; i < grid2.Rows.Count; i++)
            {
                try
                {
                    rtnDtTemp = helper.FillTable("USP_OD0000_S6", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_SearchPoNo", grid2.Rows[i].Cells["OD2_PoNo"].Value, DbType.String, ParameterDirection.Input));


                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid2.Rows[i].Cells["OD2_State"].Value = "중복";
                    }
                    else
                    {
                        return;
                    }


                    DSgrid = helper.FillDataSet("USP_OD0000_POP_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_SEARCHWORD", "", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMNAME", grid2.Rows[i].Cells["OD2_PartName"].Value, DbType.String, ParameterDirection.Input));


                    if (DSgrid.Tables[0].Rows.Count > 0)
                    {
                        int iRow = grid3.InsertRow();
                        grid3.Rows[iRow].Cells["OD3_PartName"].Value = grid2.Rows[i].Cells["OD2_PartName"].Value;
                        grid3.Rows[iRow].Cells["OD3_OrderQTY"].Value = grid2.Rows[i].Cells["OD2_OrderQTY"].Value;
                        grid3.Rows[iRow].Cells["OD3_UnitCost"].Value = grid2.Rows[i].Cells["OD2_UnitCost"].Value;
                        grid3.Rows[iRow].Cells["OD3_Money"].Value = grid2.Rows[i].Cells["OD2_Money"].Value;
                        grid3.Rows[iRow].Cells["OD3_ETC4"].Value = grid2.Rows[i].Cells["OD2_ETC3"].Value;
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
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            int StateCheck = 0;
            if (grid2.Rows.Count <= 0)
            {
                this.ShowDialog("등록할 내용이 없습니다.", Forms.DialogForm.DialogType.OK);
            }
            else
            {
                try
                {
                    for (int i = 0; i < grid2.Rows.Count; i++)
                    {
                        if (Convert.ToString(grid2.Rows[i].Cells["OD2_State"].Value) == "중복")
                        {
                            this.ShowDialog(grid2.Rows[i].Cells["OD2_LotNo"].Value + "이(가) 중복입니다. 확인 후 다시 저장해주세요", Forms.DialogForm.DialogType.OK);
                            StateCheck++;
                        }
                    }

                    for (int j = 0; j < grid2.Rows.Count; j++)
                    {
                        if (StateCheck == 0)
                        {
                            //저장, 수정
                            rtnDtTemp = helper.FillTable("USP_OD0000_SAVE", CommandType.StoredProcedure

                                , helper.CreateParameter("AS_OD_LotNo", grid2.Rows[j].Cells["OD2_LotNo"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_date", grid2.Rows[j].Cells["OD2_date"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_Vend", grid2.Rows[j].Cells["OD2_Vend"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_OrderDate", grid2.Rows[j].Cells["OD2_OrderDate"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_FixedDate", grid2.Rows[j].Cells["OD2_FixedDate"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_PartName", grid2.Rows[j].Cells["OD2_PartName"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_OrderQTY", grid2.Rows[j].Cells["OD2_OrderQTY"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_UnitCost", grid2.Rows[j].Cells["OD2_UnitCost"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_Money", grid2.Rows[j].Cells["OD2_Money"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_Residual", grid2.Rows[j].Cells["OD2_Residual"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_HRS", grid2.Rows[j].Cells["OD2_HRS"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_Amount", grid2.Rows[j].Cells["OD2_Amount"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_PoNo", grid2.Rows[j].Cells["OD2_PoNo"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_Type", grid2.Rows[j].Cells["OD2_Type"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OD_ETC1", grid2.Rows[j].Cells["OD2_ETC3"].Value, DbType.String, ParameterDirection.Input));

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

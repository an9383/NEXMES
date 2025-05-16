#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0500
//   Form Name    : 자재LOT 합병/분할
//   Name Space   : WIZ.WM
//   Created Date : 2015/09/08
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0500 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        Common _Common = new Common();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        string OldItemCode = string.Empty;  // 선택한 품목
        int LotCnt = 0;                     // LOT 선택 갯수
        #endregion

        #region < CONSTRUCTOR >

        public WM0500()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            // TBM0100 : 품목
            // 1 : 품목, 2 : 품목명, param[0] : PlantCode, param[1] : ItemType
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode, "" });
        }
        #endregion

        #region  WM0500_Load
        private void WM0500_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성

            #region Grid 셋팅 //100 100 200 170 100 100 130 80 100 117 100 220 100 250 100 100
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemType", "품목구분명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCode", "창고코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHName", "창고명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "위치코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "위치", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Qty", "수량", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StockQty", "중량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FIRSTINDATE", "최초입고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTCODE", "거래처코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME", "출고거래처명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemName", "품명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTLOTNO", "코일번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LotNo", "LOTNO", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "StockQty", "중량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LotStatus", "LOT상태", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PONO", "발주번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "POSEQNO", "발주순번", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WHCode", "창고코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WHName", "창고명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STORAGELOCCODE", "위치코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STORAGELOCNAME", "저장위치명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region 콤보박스
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            this.cboPlantCode.Value = "1100";
            string sPlantCode = Convert.ToString(this.cboPlantCode.Value);

            rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE");  //품목구분
            WIZ.Common.FillComboboxMaster(this.cboItemType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ItemType", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE");  //창고
            WIZ.Common.FillComboboxMaster(this.cboWhCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCode", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("LOTSTATUS");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "LotStatus", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

        }
        #endregion  WM0500_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            this._GridUtil.Grid_Clear(grid1);
            this._GridUtil.Grid_Clear(grid2);
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode.Value);                   // 공장코드
                string sWHCode = Convert.ToString(cboWhCode.Value);                      // 창고코드
                string sItemType = Convert.ToString(cboItemType.Value);                    // 품목구분 
                string sItemCode = this.txtItemCode.Text;                                  // 품목
                string sLotNo = this.txtLotNo.Text;                                     // LOTNO

                grid1.DataSource = helper.FillTable("USP_WM0500_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                 // 사업장 공장코드    
                                                                    , helper.CreateParameter("WHCode", sWHCode, DbType.String, ParameterDirection.Input)                    // 사업장 공장코드    
                                                                    , helper.CreateParameter("ItemType", sItemType, DbType.String, ParameterDirection.Input)                  // 품목구분
                                                                    , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)                  // 품목               
                                                                    , helper.CreateParameter("LotNo", sLotNo, DbType.String, ParameterDirection.Input));                   // LOTNO               



                grid1.DataBinds();
                this.ClosePrgFormNew();
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

        private void cboPlantCode_H_TextChanged(object sender, EventArgs e)
        {
            DataTable dttemp = new DataTable();
            string sPlantCode = Convert.ToString(this.cboPlantCode.Value);

            dttemp = _Common.GET_BM0080_CODE(sPlantCode); // 창고
            WIZ.Common.FillComboboxMaster(this.cboWhCode, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
        }

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            //확인 필요
            bool chk = Convert.ToString(this.grid2.Rows[this.grid2.ActiveRow.Index].Cells["CHK"].Value).ToUpper() == "1" ? true : false;
            LotCnt = 0;
            //DataTable table = new DataTable();

            if (chk == true)
            {
                this.grid2.Rows[this.grid2.ActiveRow.Index].Cells["CHK"].Value = false;

                //선택되지 않은 행을 테이블에서 삭제
                //table.Rows.RemoveAt(grid2.ActiveRow.Index);
            }
            else
            {
                //품목 선택된 정보가 동일한지를 check 하여 동일한 경우만 선택 되도록 한다.2014.7.23 yjlim 추가
                if ((Convert.ToString(this.grid2.Rows[this.grid2.ActiveRow.Index].Cells["ITEMCODE"].Value) == OldItemCode) || (OldItemCode == ""))
                {
                    this.grid2.Rows[this.grid2.ActiveRow.Index].Cells["CHK"].Value = true;
                    OldItemCode = Convert.ToString(this.grid2.Rows[this.grid2.ActiveRow.Index].Cells["ITEMCODE"].Value);  // 선택 품목

                    //선택된 행을 테이블에 삽입
                    //table.Rows.Add(grid2.ActiveRow);

                }
                else
                {
                    this.ShowDialog(Common.getLangText("다른 품목은 LOT분할 또는 병합할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            //this.grid2.UpdateGridData();

            for (int i = 0; i < this.grid2.Rows.Count; i++)
            {
                if (this.grid2.Rows[i].Cells["CHK"].Value.ToString().ToUpper() == "1")
                {
                    LotCnt = LotCnt + 1;
                }
            }
        }

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            this._GridUtil.Grid_Clear(grid2);
            OldItemCode = "";
            //분할 또는 병합할 품목별로 LOT별 grid2 조회
            DBHelper helper = new DBHelper(false);
            try
            {
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);                   // 공장
                string sWHCode = Convert.ToString(grid1.ActiveRow.Cells["WHCODE"].Value);                      // 창고
                string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);                    // 품목
                string sItemType = Convert.ToString(grid1.ActiveRow.Cells["ITEMTYPE"].Value);
                string sStorageLocCOde = Convert.ToString(grid1.ActiveRow.Cells["STORAGELOCCODE"].Value);
                string sLotNO = this.txtLotNo.Text.ToString();

                grid2.DataSource = helper.FillTable("USP_WM0500_S2N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                // 공장    
                                                                    , helper.CreateParameter("WHCode", sWHCode, DbType.String, ParameterDirection.Input)                     // 창고
                                                                    , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("@ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("@LOTNO", sLotNO, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("STORAGELOCCODE", sStorageLocCOde, DbType.String, ParameterDirection.Input)
                                                                    );                // 품목               

                grid2.DataBinds();
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

        private void btnLotMerger_Click(object sender, EventArgs e)
        {

            if (LotCnt < 2)
            {
                this.ShowDialog(Common.getLangText("동일품목이 2개 이상 선택된 경우 병합가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            int iCheckRowCount = 0;
            string sFirstItemCode = string.Empty;
            bool flgItemDuplicated = true;

            this.grid2.UpdateData();
            DataTable DTChange1 = (DataTable)this.grid2.DataSource;

            foreach (DataRow drGrid in DTChange1.Rows)
            {
                if (drGrid["CHK"].ToString().ToUpper() != "1")
                    continue;

                iCheckRowCount = iCheckRowCount + 1;
                if (iCheckRowCount == 1)
                {
                    sFirstItemCode = drGrid["ItemCode"].ToString();
                }
                else
                {
                    if (sFirstItemCode != drGrid["ItemCode"].ToString())
                    {
                        flgItemDuplicated = false;
                    }
                }
            }


            POP_MM0510 pop_mm0510 = new POP_MM0510(this.cboPlantCode.Value.ToString(), this.grid2);
            pop_mm0510.ShowDialog();
            DoInquire();
        }

        private void btnLotDivision_Click(object sender, EventArgs e)
        {

            if (LotCnt != 1)
            {
                this.ShowDialog(Common.getLangText("품목이 1개 선택된 경우 분할가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            DataTable dtTarget = ((DataTable)this.grid2.DataSource);
            DataRow[] drRow = dtTarget.Select();
            int i = 0;
            string ChkCheckRow = "NONCHK";
            for (i = 0; i < this.grid2.Rows.Count; i++)
            {
                if (this.grid2.Rows[i].Cells["CHK"].Value.ToString() == "1")
                {
                    ChkCheckRow = "CHK";
                    break;
                }
            }
            if (ChkCheckRow == "NONCHK")
            {
                this.ShowDialog(Common.getLangText("품목이 선택된 경우 분할 가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }
            POP_MM0500 pop_MM0500 = new POP_MM0500(drRow[i]);
            pop_MM0500.ShowDialog();
            DoInquire();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int cnt = 0;

            if (grid2.Rows.Count == 0) return;

            for (int i = 0; i < grid2.Rows.Count; i++)
            {
                if (grid2.Rows[i].Cells["CHK"].Value.ToString() == "1")
                {
                    string sPlantCode = grid2.Rows[i].Cells["PLANTCODE"].Value.ToString();
                    // string sPoNo       = grid2.Rows[i].Cells["PONO"].Value.ToString();
                    string sLotno = grid2.Rows[i].Cells["LotNo"].Value.ToString();

                    //라벨출력
                    SendPrint(sPlantCode, sLotno);
                }
                else
                {
                    cnt++;
                }
            }
            if (cnt == grid2.Rows.Count)
            {
                this.ShowDialog(Common.getLangText("바코드 발행 할 데이터를 선택 후, 버튼을 눌러주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
        }

        private void SendPrint(string PlantCode, string Lotno)
        {
            //공정이동표로 발행시 사용
            //DBHelper helper = new DBHelper(false);

            //try
            //{
            //    DataTable rtnDtTemp = helper.FillTable("USP_POP_WM0500_S1"
            //                                              , CommandType.StoredProcedure
            //                                              , helper.CreateParameter("PLANTCODE", PlantCode, DbType.String, ParameterDirection.Input)
            //                                          //    , helper.CreateParameter("PONO", PoNo, DbType.String, ParameterDirection.Input)
            //                                              , helper.CreateParameter("LOTNO", Lotno, DbType.String, ParameterDirection.Input));

            //    if (helper.RSCODE == "S")
            //    {

            //        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
            //        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();
            //        WM0500_R wm0500_r = new WM0500_R();

            //        objectDataSource.DataSource = rtnDtTemp;
            //        viewerInstance.ReportDocument = wm0500_r.Report;

            //        //ReportViewer rv = new ReportViewer();
            //        //rv.reportViewer1.ReportSource = viewerInstance;
            //        //rv.reportViewer1.RefreshReport();
            //        //rv.ShowDialog();

            //        System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
            //        System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
            //        Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

            //        reportProcessor.PrintController = standardPrintController;
            //        printerSettings.Collate = true;

            //        reportProcessor.PrintReport(viewerInstance, printerSettings);
            //    }
            //    else
            //    {
            //        MessageBox.Show(helper.RSMSG);
            //    }


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    helper.Close();
            //}

            //지브라로 제품식별표 발행시
            //시리얼 열기
            //openSerial();

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_POP_WM0500_S1"
                                                          , CommandType.StoredProcedure
                                                          , helper.CreateParameter("PLANTCODE", PlantCode, DbType.String, ParameterDirection.Input)
                                                          //    , helper.CreateParameter("PONO", PoNo, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("LOTNO", Lotno, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    {
                        StringBuilder command = new StringBuilder();
                        command.AppendLine("^XA");
                        command.AppendLine("^LH0,0^LL500^XZ");
                        command.AppendLine("^XA");
                        command.AppendLine("^SEE:UHANGUL.DAT^FS");
                        command.AppendLine("^CW1,E:KFONT3.FNT^CI26^FS");

                        command.AppendLine("^FO" + "20,30" + "^GB" + "200,900,2" + "^FS");       //왼쪽 박스
                        command.AppendLine("^FO" + "165,30" + "^GB" + "1,900,2" + "^FS");        //세로1
                        command.AppendLine("^FO" + "20,210" + "^GB" + "200,1,2" + "^FS");        //가로1

                        command.AppendLine("^FO" + "165,50" + "^A1R,50,35" + " ^FD" + "업 체 명" + "^FS");
                        command.AppendLine("^FO" + "100,50" + "^A1R,50,35" + " ^FD" + "특    이" + "^FS");
                        command.AppendLine("^FO" + "40,50" + "^A1R,50,35" + " ^FD" + "사    항" + "^FS");
                        command.AppendLine("^FO" + "165,250" + "^A1R,50,35" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["CUSTNAME"]) + "^FS");  //거래처

                        //2,3 or 3,4
                        command.AppendLine("^FO" + "250, 200" + "^BY3,4^BCR," + "80,Y,N,N" + "^FD" + Convert.ToString(rtnDtTemp.Rows[i]["BARCODE"]) + "^FS");    //바코드(1D)

                        command.AppendLine("^FO" + "335,30" + "^GB" + "300,900,2" + "^FS");       //오른쪽 박스
                        command.AppendLine("^FO" + "335,210" + "^GB" + "300,1,2" + "^FS");         //가로1
                        command.AppendLine("^FO" + "335,530" + "^GB" + "300,1,2" + "^FS");         //가로2
                        command.AppendLine("^FO" + "335,700" + "^GB" + "300,1,2" + "^FS");         //가로3
                        command.AppendLine("^FO" + "580,30" + "^GB" + "1,900,2" + "^FS");        //입고일자 밑 줄
                        command.AppendLine("^FO" + "520,30" + "^GB" + "1,900,2" + "^FS");        //품목 밑 줄
                        command.AppendLine("^FO" + "465,30" + "^GB" + "1,900,2" + "^FS");        //품목명 밑 줄
                        command.AppendLine("^FO" + "385,30" + "^GB" + "1,900,2" + "^FS");        //수량 밑 줄

                        command.AppendLine("^FO" + "580,50" + "^A1R,50,35" + " ^FD" + "일    자" + "^FS");
                        command.AppendLine("^FO" + "520,50" + "^A1R,50,35" + " ^FD" + "품    번" + "^FS");
                        command.AppendLine("^FO" + "465,50" + "^A1R,50,35" + " ^FD" + "품    명" + "^FS");
                        command.AppendLine("^FO" + "400,50" + "^A1R,50,35" + " ^FD" + "수    량" + "^FS");
                        command.AppendLine("^FO" + "330,50" + "^A1R,50,35" + " ^FD" + "소재LOT" + "^FS");

                        command.AppendLine("^FO" + "580,550" + "^A1R,50,35" + " ^FD" + "순    번" + "^FS");
                        command.AppendLine("^FO" + "520,550" + "^A1R,50,35" + " ^FD" + "저장위치" + "^FS");
                        command.AppendLine("^FO" + "465,550" + "^A1R,50,35" + " ^FD" + "구    분" + "^FS");
                        command.AppendLine("^FO" + "400,550" + "^A1R,50,35" + " ^FD" + "납품일자" + "^FS");
                        command.AppendLine("^FO" + "360,550" + "^A1R,20,20" + " ^FD" + "소재자재구분" + "^FS");
                        command.AppendLine("^FO" + "335,570" + "^A1R,20,20" + " ^FD" + "차종/기종" + "^FS");

                        command.AppendLine("^FO" + "590,270" + "^A1R,30,30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["PRTDATE"]) + "^FS");
                        command.AppendLine("^FO" + "520,215" + "^A1R,60,35" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]) + "^FS");
                        command.AppendLine("^FO" + "480,215" + "^A1R,20,20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]) + "^FS");
                        command.AppendLine("^FO" + "380,300" + "^A1R,70,70" + " ^FD" + string.Format("{0:#,##0}", Convert.ToInt32(rtnDtTemp.Rows[i]["QTY"])) + "^FS");
                        //command.AppendLine("^FO" + "345,250" + "^A1R,30,30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["CUSTLOTNO"]) + "^FS";

                        command.AppendLine("^FO" + "580,760" + "^A1R,50,50" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["BARCODE"]).Substring(10, 3) + "^FS");

                        command.AppendLine("^FO" + "640,100" + "^A1R,50,50" + " ^FD" + "제품식별표" + "^FS");
                        command.AppendLine("^FO" + "640,700" + "^A1R,50,50" + " ^FD" + "대신정공" + "^FS");
                        command.AppendLine("^XZ");

                        WIZ.Common.SendStringToBytePrinter("ZT410", command.ToString());

                        //byte[] b = Encoding.Default.GetBytes(command.ToString());
                        //serialPort1.Write(b, 0, b.Length);


                    }
                }
                else
                {
                    MessageBox.Show(helper.RSMSG);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //serialPort1.Close();
                helper.Close();
            }
        }

        /// <summary>
        /// OpenSerial
        /// </summary>
        private void openSerial()
        {
            if (serialPort1.IsOpen) serialPort1.Close(); // 시리얼포트가 열려있으면 닫기 위함

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_GET_SERAILPORT"
                                                          , CommandType.StoredProcedure
                                                          , helper.CreateParameter("@AS_MACHNAME", "ZEBRA", DbType.String, ParameterDirection.Input));

                serialPort1.PortName = Convert.ToString(rtnDtTemp.Rows[0]["PORTNAME"]);
                serialPort1.BaudRate = Convert.ToInt32(rtnDtTemp.Rows[0]["BAUDRATE"]);
                serialPort1.DataBits = Convert.ToInt32(rtnDtTemp.Rows[0]["DATABITS"]);

                if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.None")
                {
                    serialPort1.Parity = Parity.None;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Even")
                {
                    serialPort1.Parity = Parity.Even;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Mark")
                {
                    serialPort1.Parity = Parity.Mark;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Odd")
                {
                    serialPort1.Parity = Parity.Odd;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Space")
                {
                    serialPort1.Parity = Parity.Space;
                }

                if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.None")
                {
                    serialPort1.StopBits = StopBits.None;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.One")
                {
                    serialPort1.StopBits = StopBits.One;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.OnePointFive")
                {
                    serialPort1.StopBits = StopBits.OnePointFive;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.Two")
                {
                    serialPort1.StopBits = StopBits.Two;
                }

                serialPort1.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}



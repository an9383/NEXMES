#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0021
//   Form Name    : 작업지시 편성 정보 조회
//   Name Space   : WIZ.AP
//   Created Date : 2018-01-16
//   Made By      : WIZ
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
using System.Text;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP0021 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        //Thread trSelectPrintContents;

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager();
        Common _Common = new Common();
        DataTable dtGrid;
        //bool xlsVer = true;
        DataTable rtnDtTemp = new DataTable();
        //Microsoft.Office.Interop.Excel.Application excelApp = null;
        //Microsoft.Office.Interop.Excel.Workbook wb = null;
        //Microsoft.Office.Interop.Excel.Worksheet ws1 = null; //sheet1
        //[DllImport("user32.dll", SetLastError = true)]
        //static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        string sMethod = "";

        #endregion

        #region < CONSTRUCTOR >
        public AP0021()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP0021_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID2 작업지시
                //_GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 60, 10, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ORDERTYPE", "작지구분", false, GridColDataType_emu.VarChar, 80, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "지시일자", false, GridColDataType_emu.VarChar, 80, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 130, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ORDERSTATUS", "진행상태", false, GridColDataType_emu.VarChar, 100, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 90, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정", false, GridColDataType_emu.VarChar, 150, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CARTYPE", "차종", false, GridColDataType_emu.VarChar, 200, false, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시수량", false, GridColDataType_emu.Double, 100, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산수량", false, GridColDataType_emu.Double, 100, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 300, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "UNITPACK", "BOX수량", false, GridColDataType_emu.Double, 300, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ITEMSPEC", "사양", false, GridColDataType_emu.VarChar, 300, true, false);

                //_GridUtil.SetColumnTextHAlign(grid1, "WORKCENTERNAME", Infragistics.Win.HAlign.Left);
                //_GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Left);
                //_GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
                //_GridUtil.SetColumnTextHAlign(grid1, "ORDERQTY", Infragistics.Win.HAlign.Right);
                //_GridUtil.SetColumnTextHAlign(grid1, "PRODQTY", Infragistics.Win.HAlign.Right);
                //_GridUtil.SetColumnTextHAlign(grid1, "REMARK", Infragistics.Win.HAlign.Left);
                //_GridUtil.SetColumnTextHAlign(grid1, "UNITPACK", Infragistics.Win.HAlign.Right);
                //_GridUtil.SetColumnTextHAlign(grid1, "ITEMSPEC", Infragistics.Win.HAlign.Left);

                //grid1.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
                //grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

                //grid1.Columns["ORDERQTY"].Format = "#,##0";
                //grid1.Columns["PRODQTY"].Format = "#,##0";
                //grid1.Columns["UNITPACK"].Format = "#,##0";

                ////grid1.DisplayLayout.Bands[0].Columns["CHK"].Header.Fixed = true;
                ////grid1.DisplayLayout.Bands[0].Columns["ORDERNO"].Header.Fixed = true;
                ////grid1.DisplayLayout.Bands[0].Columns["ORDERSTATUS"].Header.Fixed = true;

                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANNO", "계획지시번호", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "계획지시일자", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANQTY", "계획수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SETQTY", "편성수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKQTY", "작업수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "FRAMEID", "프레임", false, GridColDataType_emu.VarChar, 90, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MASKID", "마스크", false, GridColDataType_emu.VarChar, 90, 0, Infragistics.Win.HAlign.Left, true, false);

                grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["PLANQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;


                _GridUtil.SetInitUltraGridBind(grid1);
                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;


                rtnDtTemp = _Common.GET_BM0000_CODE("ORDERTYPE");
                WIZ.Common.FillComboboxMaster(this.cbo_ORDERTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");


                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;
                #endregion

                #region POPUP SETTING

                //btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", "" });                        //공정
                btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });    //작업장
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });                    //품목
                #endregion
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        protected override void SetSubData()
        {
            sMethod = subData["METHOD_TYPE"];

            if (sMethod == "DANAWA")
            {
                lblOPCODE_H.Text = "거래처";
                rtnDtTemp = _Common.GET_BM0030_CODE("");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OPCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "", "", "" });    //거래처
                this.grid1.Columns["OPCODE"].Header.Caption = "거래처";
            }
            else
            {
                rtnDtTemp = _Common.GET_BM0040_CODE("");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OPCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", "", "" });    //작업장
            }
        }

        #endregion

        #region < TOOL BAR AREA >

        /// <summary>
        /// /// ToolBar의 조회 버튼 클릭
        /// /// </summary>
        public override void DoInquire()
        {


            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid1);

                //string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                //string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                //string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                //string sWorkcenterCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());
                //string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                //string sOrderType = DBHelper.nvlString(cbo_ORDERTYPE_H.Value);

                //if (DateCheck.CheckDate(sStartDate, sEndDate) == false)
                //{
                //    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                //    return;
                //}

                //rtnDtTemp = helper.FillTable("USP_AP0020_S1", CommandType.StoredProcedure
                //          , helper.CreateParameter("AS_PCODE", sMethod == "DANAWA" ? "S1" : "", DbType.String, ParameterDirection.Input)
                //          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                //          , helper.CreateParameter("AS_SDATE", sStartDate, DbType.String, ParameterDirection.Input)
                //          , helper.CreateParameter("AS_EDATE", sEndDate, DbType.String, ParameterDirection.Input)
                //          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                //          , helper.CreateParameter("AS_ITEMNAME", txt_ITEMNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                //          , helper.CreateParameter("AS_OPCODE", txt_OPCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                //          , helper.CreateParameter("AS_OPNAME", txt_OPNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                //          , helper.CreateParameter("AS_WORKCENTERCODE", txt_WORKCENTERCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                //          , helper.CreateParameter("AS_WORKCENTERNAME", txt_WORKCENTERNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                //          , helper.CreateParameter("AS_ORDERTYPE", sOrderType, DbType.String, ParameterDirection.Input)) ;

                ////grid1.DataSource = UltraGridUtil.SetSubTotalUltraGrid(grid1, rtnDtTemp, "WORKCENTERCODE", Common.getLangText("[ 작업장별 합계 ]", "TEXT"), "WORKCENTERNAME", "ORDERQTY,PRODQTY", "SUM,SUM");
                //grid1.DataSource = rtnDtTemp;  
                //grid1.DataBinds();

                //grid1.DataBinds(rtnDtTemp);

                //for (int i = 0; i < grid1.Rows.Count; i++)
                //{
                //    if (Convert.ToString(grid1.Rows[i].Cells["ORDERSTATUS"].Value) == "진행")
                //    {
                //        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.BackColor = Color.ForestGreen;
                //        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.ForeColor = Color.Yellow;
                //    }
                //    else if (Convert.ToString(grid1.Rows[i].Cells["ORDERSTATUS"].Value) == "종료")
                //    {
                //        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.BackColor = Color.Pink;
                //        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.ForeColor = Color.Red;
                //    }
                //    else if (Convert.ToString(grid1.Rows[i].Cells["WORKCENTERNAME"].Value) == "[ 작업장별 합계 ]")
                //    {
                //        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.BackColor = Color.Transparent;
                //        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.ForeColor = Color.Black;
                //    }
                //    else
                //    {
                //        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.BackColor = Color.SkyBlue;
                //        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.ForeColor = Color.Black;
                //    }
                //}


                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();

                base.DoInquire();

                if (sPlantCode == string.Empty)
                    return;

                dtGrid = helper.FillTable("USP_AP0012_S3", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                grid1.DataSource = dtGrid;
                grid1.DataBinds(dtGrid);

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();
                helper.Close();
            }
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {

        }
        #endregion

        #region < EVENT AREA >

        private void btn_Print_Click(object sender, EventArgs e)
        {
            int iCnt = 0;

            foreach (UltraGridRow dr in grid1.Rows)
            {
                if (CModule.ToBool(dr.Cells["CHK"].Value))
                {
                    iCnt++;
                }
            }

            if (iCnt == 0)
            {
                this.ShowDialog("선택한 건이 없습니다.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (this.ShowDialog(Common.getLangText(iCnt.ToString() + " 건을 출력하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            DBHelper helper;
            helper = new DBHelper("", true);

            try
            {
                iCnt = 0;

                foreach (UltraGridRow dr in grid1.Rows)
                {
                    if (CModule.ToBool(dr.Cells["CHK"].Value))
                    {
                        string sOrderNO = DBHelper.nvlString(grid1.ActiveRow.Cells["ORDERNO"].Value);
                        string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);

                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("exec USP_CALLPRINT_I1 ");
                        sSQL.Append("  @AS_PLANTCODE = '" + sPlantCode + "'");
                        sSQL.Append(", @AS_LOTNO = '" + sOrderNO + "' ");
                        sSQL.Append(", @AS_WORKCENTERCODE = '" + WIZ.LoginInfo.UserID + "' ");
                        sSQL.Append(", @AS_CIP = '' ");

                        helper.ExecuteNoneQuery(sSQL.ToString());

                        iCnt++;
                    }
                }

                if (iCnt > 0)
                {
                    helper.Commit();
                    this.ShowDialog(iCnt.ToString() + " 건에 대해 출력 명령을 내렸습니다.", WIZ.Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }


        //private void btn_Print_Click(object sender, EventArgs e)
        //{
        //    if (grid1.ActiveCell == null)
        //    {
        //        return;
        //    }


        //    //원본
        //    //string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
        //    //string sOrderNO = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);

        //    //POP_WorkOrder POP_WorkOrder = new POP_WorkOrder(sPlantCode, sOrderNO);
        //    //POP_WorkOrder.ShowDialog();

        //    string sFileName = string.Empty;
        //    string sUserName = string.Empty;
        //    string ORGName = string.Empty;

        //    DBHelper helper;
        //    helper = new DBHelper(false);

        //    DataTable TUserName = new DataTable(); //로그인 작업자 이름 확인
        //    TUserName = helper.FillTable("select WORKERNAME FROM TSY0030 WITH (NOLOCK) where WORKERID = '" + WIZ.LoginInfo.UserID + "' ");

        //    rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //출력물 양식 확인을 위한 사업장 확인
        //    ORGName = helper.DBConnect.Database.ToString();
        //    //ORGName = DBHelper.nvlString(rtnDtTemp.Rows[0]["CODE_NAME_ORG"]);

        //    try
        //    {
        //        excelApp = new Microsoft.Office.Interop.Excel.Application();
        //        //작업지시 조회 그리드 내용
        //        string sOrderNO = DBHelper.nvlString(grid1.ActiveRow.Cells["ORDERNO"].Value);
        //        string sWorkcenterCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
        //        string sWorkcenterNAME = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERNAME"].Value);
        //        string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
        //        string sItemName = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
        //        string sItemType = DBHelper.nvlString(grid1.ActiveRow.Cells["CARTYPE"].Value);
        //        string sLotNum = DBHelper.nvlString(grid1.ActiveRow.Cells["ORDERNO"].Value);
        //        double dOrderQty = DBHelper.nvlDouble(grid1.ActiveRow.Cells["ORDERQTY"].Value);
        //        sUserName = DBHelper.nvlString(TUserName.Rows[0]["WORKERNAME"]);

        //        //2 ~ 4 공정

        //        switch (ORGName)
        //        {
        //            case "DAEHWA":
        //                {
        //                    sFileName = "DAEHWA01.xls";
        //                    wb = excelApp.Workbooks.Open(Application.StartupPath + "\\EXCEL\\" + sFileName);
        //                    ws1 = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel.Worksheet;
        //                    Microsoft.Office.Interop.Excel.Range rng = ws1.UsedRange;   //현재 시트에서 사용중인 범위
        //                    object[,] data = rng.Value; //범위의 데이터


        //                    ws1.Cells[6, 5] = sItemType;
        //                    ws1.Cells[9, 5] = sItemName;
        //                    ws1.Cells[12, 5] = sItemCode;
        //                    ws1.Cells[15, 5] = sLotNum;
        //                    ws1.Cells[18, 5] = string.Format("{0:#,###}", dOrderQty);

        //                    int[] qrLocation = FindRow(data, "QRCODE");  //엑셀안에 'QRCODE' 부분 찾아서 좌표 리턴    

        //                    float fLeft = 0;
        //                    float fTop = 0;
        //                    //end data 가져오기
        //                    if (qrLocation != null)
        //                    {
        //                        Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)ws1.Cells[qrLocation[0], qrLocation[1]];
        //                        fLeft = (float)((double)oRange.Left);
        //                        fTop = (float)((double)oRange.Top);
        //                    }


        //                    string startPath = Application.StartupPath + "\\";
        //                    QRCodeEncoder qr = new QRCodeEncoder();
        //                    qr.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
        //                    Image img = qr.Encode(sLotNum);
        //                    img.Save(startPath + ".png");

        //                    ws1.Shapes.AddPicture(startPath + ".png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, fLeft, fTop, 100, 100);

        //                    File.Delete(startPath + ".png");



        //                    //페이지 세팅
        //                    ws1.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4; // A4로 설정
        //                    ws1.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape; //가로로 출력


        //                    //sFileName = "DAEHWA02.xls";
        //                    //wb = excelApp.Workbooks.Open(Application.StartupPath + "\\EXCEL\\" + sFileName);
        //                    //ws1 = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel.Worksheet;

        //                    //ws1.Cells[5, 26] = sUserName;
        //                    //ws1.Cells[6, 3] = sItemType;
        //                    //ws1.Cells[6, 5] = sItemName;
        //                    //ws1.Cells[6, 11] = sItemCode;
        //                    //ws1.Cells[6, 22] = string.Format("{0:#,###}", dOrderQty);
        //                    //ws1.Cells[6, 26] = sLotNum;

        //                    ////페이지 세팅
        //                    //ws1.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4; // A4로 설정
        //                    //ws1.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape; //가로로 출력
        //                }
        //                break;

        //            //case "제노스":
        //            //    {

        //            //    }
        //            //    break;

        //            default:
        //                Old_Print();
        //                break;
        //        }

        //        if (xlsVer)
        //        {
        //            //ws1.PrintOutEx(Type.Missing, Type.Missing, Type.Missing, Type.Missing,"Microsoft Print to PDF", Type.Missing, Type.Missing, Type.Missing);  
        //            ws1.PrintOut(1, 1, 1, false); // (시작 페이지 번호, 마지막 페이지 번호, 출력 장 수, 프리뷰 활성 유/무)

        //            // Clean up
        //            wb.Close(0);
        //            excelApp.Quit();
        //            uint processId = 0;
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

        //        }
        //    }


        //    catch (Exception ex)
        //    {
        //        this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
        //    }
        //}

        static int[] FindRow(object[,] array, string elem)
        {
            int rowCount = array.GetLength(0),
             colCount = array.GetLength(1);
            int[] returnVal = new int[2];
            for (int rowIndex = 1; rowIndex < rowCount; rowIndex++)
            {
                for (int colIndex = 1; colIndex < colCount; colIndex++)
                {
                    if (Convert.ToString(array[rowIndex, colIndex]) == elem)
                    {
                        returnVal.SetValue(rowIndex, 0);
                        returnVal.SetValue(colIndex, 1);
                        //returnVal[0] = rowIndex;
                        //returnVal[1] = colIndex;
                        return returnVal;
                    }
                }
            }
            return null;
        }

        private void btn_PRINT_WM_Click(object sender, EventArgs e)
        {

            //if (grid1.ActiveRow == null)
            //    return;

            //DataRow dr = (grid1.ActiveRow.ListObject as DataRowView).Row;

            //string sOrderNO = DBHelper.nvlString(grid1.ActiveRow.Cells["ORDERNO"].Value);
            //string sWorkcenterCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            //string sWorkcenterNAME = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERNAME"].Value);
            //string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            //string sItemName = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
            //string sItemType = DBHelper.nvlString(grid1.ActiveRow.Cells["CARTYPE"].Value);
            //string sLotNum = DBHelper.nvlString(grid1.ActiveRow.Cells["ORDERNO"].Value);
            //double dOrderQty = DBHelper.nvlDouble(grid1.ActiveRow.Cells["ORDERQTY"].Value);
            //double PRODQTY = DBHelper.nvlDouble(grid1.ActiveRow.Cells["PRODQTY"].Value);
            //string sBoxQty = DBHelper.nvlString(grid1.ActiveRow.Cells["UNITPACK"].Value);

            //AP0021_POP AP0021_pop = new AP0021_POP(sItemCode, sItemName, sBoxQty, PRODQTY, dr);
            //AP0021_pop.ShowDialog();
        }

        private void Old_Print()
        {
            //xlsVer = false; //엑셀 형식 출력물 확인

            ////if (grid1.Rows.Count == 0)
            ////{
            ////    this.ShowDialog(Common.getLangText("데이터 출력을 실패하였습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            ////    return;
            ////}

            //string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
            //string sOrderNO = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);

            //POP_WorkOrder POP_WorkOrder = new POP_WorkOrder(sPlantCode, sOrderNO);
            //POP_WorkOrder.ShowDialog();
        }
        #endregion

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (grid1.ActiveRow != null)
            {
                if (e.Cell.Column.Key == "CHK")
                {
                    bool bValue = DBHelper.nvlBoolean(e.Cell.Value);

                    e.Cell.Value = !bValue;
                }
            }
        }
    }
}
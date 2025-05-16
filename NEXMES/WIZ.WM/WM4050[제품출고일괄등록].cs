#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM4050
//   Form Name    : 제품출고 일괄등록
//   Name Space   : WIZ.WM
//   Created Date : 2020-05-07
//   Made By      : inho.hwang
//   Edited Date  : 
//   Edit By      :
//   Description  : 제품출고 일괄등록
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA > 
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;

#endregion

namespace WIZ.WM
{
    public partial class WM4050 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private string plantCode = string.Empty; //plantcode default 설정  

        DataTable Grid1D = new DataTable();
        DataTable Grid2D = new DataTable();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp2 = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        #endregion

        #region < CONSTRUCTOR >

        public WM4050()
        {
            InitializeComponent();

            BizTextBoxManager btbManager;
            btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });
            btbManager.PopUpAdd(txt_WHCODE_H, txt_WHNAME_H, "BM0080", new object[] { cbo_PLANTCODE_H, "", "" });
            btbManager.PopUpAdd(txt_CUSTCODE_H, txt_CUSTNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "", "", "" });

            this.plantCode = CModule.GetAppSetting("Site", "10");

            for (int i = 0; i < 4; i++)
            {
                rtnDtTemp2.Columns.Add("PLANTNAME" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("LOTNO" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("CUSTLOTNO" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("TMPINDATE" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("ITEMTYPE" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("ITEMCODE" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("ITEMNAME" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("PONO" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("LOTBASEQTY" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("CUSTCODE" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("CUSTNAME" + Convert.ToString(i + 1));
                rtnDtTemp2.Columns.Add("REMARK" + Convert.ToString(i + 1));
            }
        }
        #endregion

        #region  < FORM LOAD >
        private void WM4050_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE", "입고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            // _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            // _GridUtil.InitColumnUltraGrid(grid1, "CUSTLOTNO", "거래처 LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, false, false);
            // _GridUtil.InitColumnUltraGrid(grid1, "POSEQNO", "순번", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, false);
            // _GridUtil.InitColumnUltraGrid(grid1, "TMPINGROUPNO", "발주그룹번호", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "수량", true, GridColDataType_emu.VarChar, 80, 90, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고코드", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "창고명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "위치코드", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "위치명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false);
            // _GridUtil.InitColumnUltraGrid(grid1, "LOTBASEQTY", "최초 수량", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, false, false);
            // _GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "현재 수량", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, false);
            // _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "LOT상태", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
            // _GridUtil.InitColumnUltraGrid(grid1, "PRINTSEQ", "재발행횟수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            // _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            // _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, false, false);
            // _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false);
            // _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, false, false);
            // _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false);

            // grid1.Columns["LOTBASEQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region < COMBOBOX SETTING >

            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = plantCode;

            // rtnDtTemp = _Common.GET_BM0000_CODE("LOTSTATUS");  //LOT상태
            // WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0080_CODE("");  //창고
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0090_CODE(""); // 저장위치
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STORAGELOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0030_CODE(""); // 출고거래처
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CUSTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-5);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #endregion
        }

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
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);           // 입고 시작일자
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);              //  입고 완료일자

                string QURTY = string.Empty;


                rtnDtTemp = helper.FillTable("USP_WM4050_S1", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.Int16, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.Int16, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.Int16, ParameterDirection.Input));



                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds(rtnDtTemp);

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

        /// <summary>
        /// ToolBar의 출력 버튼 클릭
        /// </summary>
        #region < EVENT AREA >
        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            Grid1D = grid1.chkChange();

            DBHelper helper = new DBHelper("", true);

            if (this.ShowDialog(Common.getLangText("출고처리 하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            base.DoSave();

            string WHCODE = DBHelper.nvlString(txt_WHCODE_H.Text.Trim());
            string CUSTCODE = DBHelper.nvlString(txt_CUSTCODE_H.Text.Trim());


            foreach (DataRow drRow1 in Grid1D.Rows)
            {

                DBHelper.nvlString(drRow1["CHK"]);

                //grid1 체크 박스 확인
                if (DBHelper.nvlString(drRow1["CHK"]) == "1")
                {
                    try
                    {


                        helper.ExecuteNoneQuery("USP_PD4050_I1"
                                                , CommandType.StoredProcedure
                                                , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow1["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_BARCODE", DBHelper.nvlString(drRow1["LOTNO"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow1["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                //, helper.CreateParameter("AS_WHCODE", WHCODE, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_CUSTCODE", CUSTCODE, DbType.String, ParameterDirection.Input)
                                                //, helper.CreateParameter("AS_LOTQTY", DBHelper.nvlString(drRow1["LOTQTY"]), DbType.Int32, ParameterDirection.Input));
                                                //, helper.CreateParameter("AS_RESULT", "OK", DbType.String, ParameterDirection.Input)
                                                //, helper.CreateParameter("AS_LASTFLAG", "Y", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input));


                        if (helper.RSCODE == "S")
                        {
                            this.ClosePrgFormNew();
                            helper.Commit();
                            DoInquire(); //성공적으로 수행되었을 경우에만 조회
                        }
                        else if (helper.RSCODE == "E")
                        {
                            this.ClosePrgFormNew();
                            helper.Rollback();
                            this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        CancelProcess = true;
                        helper.Rollback();
                        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                    }

                }
            }
        }
        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }
        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_STARTDATE_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_ENDDATE_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog("시작일자를 종료일자보다 이전으로 선택해주십시오.", Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }
        private void grid1_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            //if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "CHK")
            //{
            //    bool chk = Convert.ToString(this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value).ToUpper() == "1" ? true : false;

            //    if (chk == true)
            //    {
            //        this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = false;
            //    }
            //    else
            //    {
            //        this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = true;
            //    }
            //}


        }
        private void grid1_CellChange(object sender, CellEventArgs e)
        {
            string ITEMCODE = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            object chk = "";


            if (grid1.ActiveRow.Cells["CHK"].Value.ToString() == "1")
            {
                chk = 0;
            }
            else if (grid1.ActiveRow.Cells["CHK"].Value.ToString() == "0")
            {
                chk = 1;
            }

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                if (grid1.Rows[i].Cells["ITEMCODE"].Value.ToString() == ITEMCODE)
                {
                    grid1.Rows[i].Cells["CHK"].Value = chk;
                }
            }

        }


    }
    #endregion
}
#endregion
#endregion
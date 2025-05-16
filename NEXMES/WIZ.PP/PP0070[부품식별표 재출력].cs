#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0070
//   Form Name    : 부품식별표 재출력
//   Name Space   : WIZ.PP
//   Created Date : 2018-01-17
//   Made By      : WIZCORE
//   Edited Date  : 
//   Edit By      :
//   Description  : 부품식별표 재출력
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0070 : WIZ.Forms.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable();
        DataTable _DtTemp = new DataTable();

        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        PopUp_Biz _biz = new PopUp_Biz();

        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성
        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자

        #endregion

        #region < CONSTRUCTOR >
        public PP0070()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PP0070_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "지시일자", false, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품번", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "LOT 수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false);

                grid1.Columns["ORDERQTY"].Format = "#,##0";
                grid1.Columns["LOTQTY"].Format = "#,##0";

                _GridUtil.SetInitUltraGridBind(grid1);

                //GRID2
                _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "LOTBASEQTY", "등록수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "LOTQTY", "현재수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일자", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false);

                grid2.Columns["LOTBASEQTY"].Format = "#,##0";
                grid2.Columns["LOTQTY"].Format = "#,##0";

                _GridUtil.SetInitUltraGridBind(grid2);
                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //공장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0130_CODE("Y");   //단위
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;
                #endregion

                #region POPUP SETTING
                //품목
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });

                //작업장
                btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });
                #endregion
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DoFind();
        }

        public void DoFind(int iRow = 0)
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantcode = Convert.ToString(cbo_PLANTCODE_H.Value);                               //공장
                string sStartDate = Convert.ToDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");      //생산시작일자
                string sEndDate = Convert.ToDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");        //생산  끝일자
                string sWorkCenterCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());                  //작업장코드                
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());                        //품목

                if (Common.DateCheck.CheckDate(sStartDate, sEndDate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                rtnDtTemp = helper.FillTable("USP_PP0070_S1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", sPlantcode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();

                    //grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;                    
                    //grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
                    //grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
                    //grid1.DisplayLayout.Bands[0].Columns["ORDERDATE"].MergedCellStyle = MergedCellStyle.Always;
                    //grid1.DisplayLayout.Bands[0].Columns["ORDERNO"].MergedCellStyle = MergedCellStyle.Always;

                    //grid1.DisplayLayout.Override.MergedCellAppearance.TextVAlign = VAlign.Top;
                    //grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    //grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.Default;                    
                    //grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
                    //grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

                    if (iRow >= 0)
                        grid1.ActiveRow = grid1.Rows[iRow];
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);    //조회할 데이터가 없습니다.
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

        #region < EVENT AREA >
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (grid1.ActiveRow == null) return;

            DBHelper helper = new DBHelper(false);

            try
            {

                string sPlantcode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);   //공장
                string sOrderNo = DBHelper.nvlString(grid1.ActiveRow.Cells["ORDERNO"].Value);     // 지시번호

                rtnDtTemp = helper.FillTable("USP_PP0070_S2", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", sPlantcode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds();
                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);
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
        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            Common.CustomMergedCellEvalutor CM1 = new Common.CustomMergedCellEvalutor("WORKCENTERCODE", "ORDERDATE");

            e.Layout.Bands[0].Columns["ORDERDATE"].MergedCellEvaluator = CM1;
        }

        private void btnRegLOT_Click(object sender, EventArgs e)
        {
            if (grid1.ActiveRow == null) return;

            int iRow = grid1.ActiveRow.Index;
            string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string sOrderNo = DBHelper.nvlString(grid1.ActiveRow.Cells["ORDERNO"].Value);

            WIZ.PopUp.POP_PP6130 pop_pp6130 = new POP_PP6130(sPlantCode, sOrderNo);
            pop_pp6130.ShowDialog();

            DoFind(iRow);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (grid1.ActiveRow == null) return;
            if (grid2.ActiveRow == null) return;

            grid2.UpdateData();

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable DtLOT = (DataTable)grid2.DataSource;
                DataTable DtPRT = DtLOT.Clone();

                for (int i = 0; i < DtLOT.Rows.Count; i++)
                {
                    string sChk = DBHelper.nvlString(DtLOT.Rows[i]["CHK"]);

                    if (sChk == "True")
                        DtPRT.ImportRow(DtLOT.Rows[i]);
                }

                DataTable DtPreview = new DataTable();
                for (int i = 0; i < DtPRT.Rows.Count; i++)
                {
                    string sPlantcode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);       //공장
                    string sWorkCenterCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);  //작업장
                    string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);        //품번
                    string sLotNo = DBHelper.nvlString(DtPRT.Rows[i]["LOTNO"]);                         //LOTNO

                    rtnDtTemp = helper.FillTable("USP_PP0070_S3", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPlantcode, DbType.String, ParameterDirection.Input)     // 공장
                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)     // 작업장
                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)     // 품번
                                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));   // LOTNO

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        if (DtPreview.Rows.Count == 0)
                            DtPreview = rtnDtTemp.Clone();

                        DtPreview.ImportRow(rtnDtTemp.Rows[0]);
                    }
                }

                if (DtPreview.Rows.Count > 0)
                {
                    Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
                    Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();
                    WIZ.PopUp.PP6130_R pp6130_r = new PP6130_R();

                    objectDataSource.DataSource = DtPreview;
                    pp6130_r.DataSource = objectDataSource;
                    viewerInstance.ReportDocument = pp6130_r.Report;

                    WIZ.PopUp.POP_ReportViewer rv = new POP_ReportViewer();
                    rv.reportViewer1.ReportSource = viewerInstance;
                    rv.reportViewer1.RefreshReport();

                    rv.ShowDialog();
                }
                else
                {
                    this.ShowDialog(Common.getLangText("LOT 등록 정보가 존재하지 않습니다.", "MSG"), DialogForm.DialogType.OK);
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

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            bool chk = Convert.ToString(this.grid2.Rows[this.grid2.ActiveRow.Index].Cells["CHK"].Value).ToUpper() == "1" ? true : false;

            if (chk == true)
            {
                this.grid2.Rows[this.grid2.ActiveRow.Index].Cells["CHK"].Value = false;
            }
            else
            {
                this.grid2.Rows[this.grid2.ActiveRow.Index].Cells["CHK"].Value = true;
            }
        }
        #endregion
    }
}


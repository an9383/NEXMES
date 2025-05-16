#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP7700
//   Form Name    : 품목별 월 UPH 현황
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP7700 : WIZ.Forms.BaseMDIChildForm
    {

        #region < MEMBER AREA >        
        // return DataTable 
        DataTable rtnDtTemp = new DataTable();
        DataTable _DtTemp = new DataTable();

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();

        BizTextBoxManager btbManager;
        Configuration appconfig;
        #endregion


        #region < CONSTRUCTOR >
        public PP7700()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENT >
        private void PP7700_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTNAME", "사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "라인", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "라인명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BASECT", "기준CT", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CT", "실CT", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BASEUPH", "기준UPH", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UPH", "실UPH", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UPPH", "UPPH", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PQ", "생산량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RH", "공수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###,##0.00", null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");
            appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this.cboPlantCode_H.Value = CModule.GetAppSetting("PLANTCODE", "10");

            cboYear_H.Value = DateTime.Now;
            #endregion
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

        private void DoFind(string SelParam = "")
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                 //공장                
                string sMonth = Convert.ToDateTime(cboYear_H.Value).ToString("yyyyMM"); //조회년도
                string sWorkCenterCode = txtWcCode.Text.Trim();                                  //라인코드                
                string sItemCode = txtItemCode.Text.Trim();

                //USP_PP7700_S2 에서 USP_PP7700_S1으로 수정 / 사유 : USP_PP7700_S2가 없음! / 수정자 : 윤근욱
                rtnDtTemp = helper.FillTable("USP_PP7700_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MONTH", sMonth, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    #region ▶ 품목별 월 UPH 현황(라인별) ◀
                    DataTable DtGrid = rtnDtTemp.Clone();

                    int pDataCnt = 1;
                    string pPlantName = Convert.ToString(rtnDtTemp.Rows[0]["PLANTNAME"]);
                    string pWorkCenterCode = Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERCODE"]);
                    string pWorkCenterName = Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERNAME"]);
                    string pItemCode = Convert.ToString(rtnDtTemp.Rows[0]["ITEMCODE"]);
                    string pItemName = Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]);

                    double pBaseUPH = Convert.ToDouble(rtnDtTemp.Rows[0]["BASEUPH"]);
                    double pBaseCT = Convert.ToDouble(rtnDtTemp.Rows[0]["BASECT"]);
                    double pUPH = Convert.ToDouble(rtnDtTemp.Rows[0]["UPH"]);
                    double pCT = Convert.ToDouble(rtnDtTemp.Rows[0]["CT"]);
                    double pUPPH = Convert.ToDouble(rtnDtTemp.Rows[0]["UPPH"]);
                    double pPQ = Convert.ToDouble(rtnDtTemp.Rows[0]["PQ"]);
                    double pRH = Convert.ToDouble(rtnDtTemp.Rows[0]["RH"]);

                    int DataCnt = 1;

                    double BaseUPH = pBaseUPH;
                    double BaseCT = pBaseCT;
                    double UPH = pUPH;
                    double UPPH = pUPPH;
                    double CT = pCT;
                    double PQ = pPQ;
                    double RH = pRH;

                    DtGrid.Rows.Add(new object[] { pPlantName, pWorkCenterCode, pWorkCenterName, pItemCode, pItemName, pBaseUPH, pBaseCT, pUPH, pUPPH, pCT, pPQ, pRH });

                    for (int i = 1; i < rtnDtTemp.Rows.Count; i++)
                    {
                        string tPlantName = Convert.ToString(rtnDtTemp.Rows[i]["PLANTNAME"]);
                        string tWorkCenterCode = Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERCODE"]);
                        string tWorkCenterName = Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERNAME"]);
                        string tItemCode = Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]);
                        string tItemName = Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]);

                        double tBaseUPH = Convert.ToDouble(rtnDtTemp.Rows[i]["BASEUPH"]);
                        double tBaseCT = Convert.ToDouble(rtnDtTemp.Rows[i]["BASECT"]);
                        double tUPH = Convert.ToDouble(rtnDtTemp.Rows[i]["UPH"]);
                        double tUPPH = Convert.ToDouble(rtnDtTemp.Rows[i]["UPPH"]);
                        double tCT = Convert.ToDouble(rtnDtTemp.Rows[i]["CT"]);
                        double tPQ = Convert.ToDouble(rtnDtTemp.Rows[i]["PQ"]);
                        double tRH = Convert.ToDouble(rtnDtTemp.Rows[i]["RH"]);

                        DataCnt = DataCnt + 1;
                        BaseUPH = BaseUPH + tBaseUPH;
                        BaseCT = BaseCT + tBaseCT;
                        UPH = UPH + tUPH;
                        UPPH = UPPH + tUPPH;
                        CT = CT + tCT;
                        PQ = PQ + tPQ;
                        RH = RH + tRH;

                        if (pPlantName != tPlantName)
                        {
                            DtGrid.Rows.Add(new object[] { null, null, null, null, pPlantName + " 합계 :", pBaseUPH, pBaseCT, pUPH, pUPPH, pCT, pPQ, pRH });

                            pPlantName = Convert.ToString(rtnDtTemp.Rows[i]["PLANTNAME"]);

                            pDataCnt = 1;
                            pBaseUPH = Convert.ToDouble(rtnDtTemp.Rows[i]["BASEUPH"]);
                            pBaseCT = Convert.ToDouble(rtnDtTemp.Rows[i]["BASECT"]);
                            pUPH = Convert.ToDouble(rtnDtTemp.Rows[i]["UPH"]);
                            pUPPH = Convert.ToDouble(rtnDtTemp.Rows[i]["UPPH"]);
                            pCT = Convert.ToDouble(rtnDtTemp.Rows[i]["CT"]);
                            pPQ = Convert.ToDouble(rtnDtTemp.Rows[i]["PQ"]);
                            pRH = Convert.ToDouble(rtnDtTemp.Rows[i]["RH"]);
                        }
                        else
                        {
                            DtGrid.Rows.Add(new object[] { tPlantName, tWorkCenterCode, tWorkCenterName, tItemCode, tItemName, tBaseUPH, tBaseCT, tUPH, tUPPH, tCT, tPQ, tRH });

                            pDataCnt = pDataCnt + 1;
                            pBaseUPH = pBaseUPH + tBaseUPH;
                            pBaseCT = pBaseCT + tBaseCT;
                            pUPH = pUPH + tUPH;
                            pUPPH = pUPPH + tUPPH;
                            pCT = pCT + tCT;
                            pPQ = pPQ + tPQ;
                            pRH = pRH + tRH;
                        }
                    }

                    DtGrid.Rows.Add(new object[] { null, null, null, null, pPlantName + " 합계 :", null, null, Math.Round(pPQ / pRH, 4), null, Math.Round(pRH * 3600 / pPQ, 4), pPQ, pRH });
                    DtGrid.Rows.Add(new object[] { null, null, null, null, "총 계 :", null, null, Math.Round(PQ / RH, 4), null, Math.Round(RH * 3600 / PQ, 4), PQ, RH });

                    grid1.DataSource = DtGrid;
                    grid1.DataBinds();

                    grid1.DisplayLayout.Bands[0].Columns["PLANTNAME"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;

                    grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

                    grid1.DisplayLayout.Override.MergedCellAppearance.TextVAlign = VAlign.Top;
                    grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
                    #endregion
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //조회할 데이터가 없습니다.
                    return;
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
        }

        public override void DoDownloadExcel()
        {
            WIZ.REPORT.ExcelManager excel = new WIZ.REPORT.ExcelManager();
            excel.DownloadExcel(this.grid1, this.Name, false);
        }

        #endregion


        #region < EVENT AREA >
        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            Common.CustomMergedCellEvalutor CM1 = new Common.CustomMergedCellEvalutor("RECDATE", "TPRODQTY");

            //15-11-24 화면조회가 되지 않아 주석처리 최재형
            //e.Layout.Bands[0].Columns["RECDATE"].MergedCellEvaluator = CM1;            
        }

        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Appearance.BackColor = Color.White;

            if (Convert.ToString(e.Row.Cells["PLANTNAME"].Value) == string.Empty)
            {
                e.Row.Appearance.BackColor = Color.FromArgb(254, 252, 177);
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.True;
                e.Row.Cells["BANNAME"].Appearance.TextHAlign = HAlign.Right;
            }
            else
            {
                e.Row.Appearance.BackColor = Color.White;
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.False;
            }
        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txtItemCode.Tag = null;
                txtItemCode.Text = string.Empty;
                txtItemName.Text = string.Empty;
            }
        }

        private void txtWorkCenterCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txtWcCode.Tag = null;
                txtWcCode.Text = string.Empty;
                txtWcName.Text = string.Empty;
            }
        }

        private void txtItemCode_ButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    string[] values = { Convert.ToString(cboPlantCode_H.Value), "" };
            //    POP_TBM0100 _frmA = new POP_TBM0100( values );
            //    _frmA.ShowDialog();
            //    rtnDtTemp = (DataTable)_frmA.Tag;
            //    if (rtnDtTemp.Rows.Count > 0)
            //    {
            //        txtItemCode.Text = Convert.ToString(rtnDtTemp.Rows[0][0]);
            //        txtItemName.Text = Convert.ToString(rtnDtTemp.Rows[0][1]);
            //    }
            //    _frmA.Dispose();
            //}
            //catch
            //{
            //}
        }

        private void txtWcCode_ButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    string[] values = { Convert.ToString(cboPlantCode_H.Value), "", "", "" ,"" ,"" };
            //    POP_TBM0600 _frmA = new POP_TBM0600( values );
            //    _frmA.ShowDialog();
            //    rtnDtTemp = (DataTable)_frmA.Tag;
            //    if (rtnDtTemp.Rows.Count > 0)
            //    {
            //        txtWcCode.Text = Convert.ToString(rtnDtTemp.Rows[0][0]);
            //        txtWcName.Text = Convert.ToString(rtnDtTemp.Rows[0][1]);
            //    }
            //    _frmA.Dispose();
            //}
            //catch
            //{
            //}
        }
        #endregion

        #region < USER FUNCTIONS >
        #endregion
    }
}


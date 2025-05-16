#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0700
//   Form Name    : 작업호기(WorkCenter)별  실적 정보 조회
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
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion


namespace WIZ.PP
{
    public partial class PP6100Y : WIZ.Forms.BaseMDIChildForm
    {
        UltraGridUtil _GridUtil = new UltraGridUtil();          //그리드 객체
        Common _Common = new Common();                 //Common 객체
        BizTextBoxManager btbManager = new BizTextBoxManager();      //팝업 매니저
        PopUp_Biz _biz = new PopUp_Biz();              //팝업 비지니스 로직 객체 생성
        DataSet rtnDsTemp = new DataSet();                //return DataSet 공통
        DataTable rtnDtTemp = new DataTable();              //return DataTable 공통
        DataTable _DtTemp = new DataTable();              //임시로 사용할 데이터테이블 생성

        private string plantCode = string.Empty; //plantcode default 설정
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public PP6100Y()
        {
            InitializeComponent();
        }

        private void PP6100Y_Load(object sender, EventArgs e)
        {
            #region ▶ Grid Setting ◀

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);
            _GridUtil.InitColumnUltraGrid(grid1, "NUM", "NO", false, GridColDataType_emu.VarChar, 40, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTNAME", "사업장명", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODDATE", "생산일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STANUPH", "기준UPH", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STANPROD", "기준생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RUNTIME", "가동시간(분)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODPER", "달성률(%)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            #endregion

            #region ▶ ComboBox Setting ◀
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");

            plantCode = CModule.GetAppSetting("Site", "10");
            cboPlantCode_H.Value = plantCode;
            CboStartDate_H.Value = DateTime.Now;
            CboEndDate_H.Value = DateTime.Now;
            #endregion
        }

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string ls_plantcode = Convert.ToString(cboPlantCode_H.Value);                 //공장
                string ls_wccode = Convert.ToString(txtWcCode.Tag);         //라인코드                
                string ls_sdate = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value);    //조회일자(시작)
                string ls_edate = string.Format("{0:yyyy-MM-dd}", CboEndDate_H.Value);        //조회일자(종료)

                if (Common.DateCheck.CheckDate(ls_sdate, ls_edate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                base.DoInquire();

                //rtnDtTemp = helper.FillTable("USP_PP6100Y_S2", CommandType.StoredProcedure
                rtnDtTemp = helper.FillTable("USP_PP6100Y_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WCCODE", ls_wccode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_SDATE", ls_sdate, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_EDATE", ls_edate, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    DataTable DtGrid = rtnDtTemp.Clone();

                    #region ▶ CAPA대비 실적(부서별-일) ◀
                    /*
                    int pRNum = Convert.ToInt32(rtnDtTemp.Rows[0]["NUM"]);
                    string pPlantCode      = Convert.ToString(rtnDtTemp.Rows[0]["PLANTCODE"]);
                    string pPlantName      = Convert.ToString(rtnDtTemp.Rows[0]["PLANTNAME"]);
                    string pBanCode        = Convert.ToString(rtnDtTemp.Rows[0]["BANCODE"]);
                    string pBanName        = Convert.ToString(rtnDtTemp.Rows[0]["BANNAME"]);
                    string pWorkCenterCode = Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERCODE"]);
                    string pWorkCenterName = Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERNAME"]);
                    string pItemCode       = Convert.ToString(rtnDtTemp.Rows[0]["ITEMCODE"]);
                    string pItemName       = Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]);
                    string pProdDate       = Convert.ToString(rtnDtTemp.Rows[0]["PRODDATE"]);
                    string pStanUPH        = Convert.ToString(rtnDtTemp.Rows[0]["STANUPH"]);

                    double pNoStanProd = Convert.ToDouble(rtnDtTemp.Rows[0]["STANPROD"]);
                    double pNoRunTime  = Convert.ToDouble(rtnDtTemp.Rows[0]["RUNTIME"]);
                    double pNoProdQty  = Convert.ToDouble(rtnDtTemp.Rows[0]["PRODQTY"]);
                    double pNoProdPer  = Convert.ToDouble(rtnDtTemp.Rows[0]["PRODPER"]);

                    double NoStanProd = pNoStanProd;
                    double NoRunTime  = pNoRunTime;
                    double NoProdQty  = pNoProdQty;
                    double NoProdPer  = pNoProdPer;

                    DtGrid.Rows.Add(new object[] { pRNum, pPlantCode, pPlantName, pBanCode, pBanName,pWorkCenterCode, pWorkCenterName, pItemCode, pItemName, pProdDate, pStanUPH, pNoStanProd, pNoRunTime, pNoProdQty, pNoProdPer });

                    for (int i = 1; i < rtnDtTemp.Rows.Count; i++)
                    {
                        int tRNum = Convert.ToInt32(rtnDtTemp.Rows[i]["NUM"]);
                        string tPlantCode      = Convert.ToString(rtnDtTemp.Rows[i]["PLANTCODE"]);
                        string tPlantName      = Convert.ToString(rtnDtTemp.Rows[i]["PLANTNAME"]);
                        string tBanCode        = Convert.ToString(rtnDtTemp.Rows[i]["BANCODE"]);
                        string tBanName        = Convert.ToString(rtnDtTemp.Rows[i]["BANNAME"]);
                        string tWorkCenterCode = Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERCODE"]);
                        string tWorkCenterName = Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERNAME"]);
                        string tItemCode       = Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]);
                        string tItemName       = Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]);
                        string tProdDate       = Convert.ToString(rtnDtTemp.Rows[i]["PRODDATE"]);
                        string tStanUPH        = Convert.ToString(rtnDtTemp.Rows[i]["STANUPH"]);

                        double tNoStanProd = Convert.ToDouble(rtnDtTemp.Rows[i]["STANPROD"]);
                        double tNoRunTime  = Convert.ToDouble(rtnDtTemp.Rows[i]["RUNTIME"]);
                        double tNoProdQty  = Convert.ToDouble(rtnDtTemp.Rows[i]["PRODQTY"]);
                        double tNoProdPer  = Convert.ToDouble(rtnDtTemp.Rows[i]["PRODPER"]);
                            
                        NoStanProd = NoStanProd + tNoStanProd;
                        NoRunTime  = NoRunTime  + tNoRunTime;
                        NoProdQty  = NoProdQty + tNoProdQty;
                        NoProdPer  = NoProdPer + tNoProdPer;

                        if (pBanCode != tBanCode)
                        {
                            //달성률     : 생산수량 / 기준 생산수량( ( 가동시간 / CT ) * 100 )
                            //pNoProdPer : pNoProdQty / pNoStanProd * 100
                            if (pNoProdQty * pNoStanProd == 0) pNoProdPer = 0;
                            else pNoProdPer = pNoProdQty / pNoStanProd * 100;
                            DtGrid.Rows.Add(new object[] { null, null, null, null, pBanName + " 합계 :", null, null, null, null, null, null, pNoStanProd, pNoRunTime, pNoProdQty, pNoProdPer });

                            pBanCode = Convert.ToString(rtnDtTemp.Rows[i]["BANCODE"]);
                            pBanName = Convert.ToString(rtnDtTemp.Rows[i]["BANNAME"]);

                            pNoStanProd = Convert.ToDouble(rtnDtTemp.Rows[i]["STANPROD"]);
                            pNoRunTime  = Convert.ToDouble(rtnDtTemp.Rows[i]["RUNTIME"]);
                            pNoProdQty  = Convert.ToDouble(rtnDtTemp.Rows[i]["PRODQTY"]);
                            pNoProdPer  = Convert.ToDouble(rtnDtTemp.Rows[i]["PRODPER"]);

                            DtGrid.Rows.Add(new object[] { tRNum, tPlantCode, tPlantName, tBanCode, tBanName, tWorkCenterCode, tWorkCenterName, tItemCode, tItemName, tProdDate, tStanUPH, tNoStanProd, tNoRunTime, tNoProdQty, tNoProdPer });

                        }
                        else
                        {
                            pBanCode = Convert.ToString(rtnDtTemp.Rows[i]["BANCODE"]);

                            DtGrid.Rows.Add(new object[] { tRNum, tPlantCode, tPlantName, tBanCode, tBanName, tWorkCenterCode, tWorkCenterName, tItemCode, tItemName, tProdDate, tStanUPH, tNoStanProd, tNoRunTime, tNoProdQty, tNoProdPer });

                            pNoStanProd = pNoStanProd + tNoStanProd;
                            pNoRunTime  = pNoRunTime + tNoRunTime;
                            pNoProdQty  = pNoProdQty + tNoProdQty;
                            pNoProdPer  = pNoProdPer + tNoProdPer;
                        }
                    }
                    //달성률     : 생산수량 / 기준 생산수량( ( 가동시간 / CT ) * 100 )
                    //pNoProdPer : pNoProdQty / pNoStanProd * 100
                    if (pNoProdQty * pNoStanProd == 0) pNoProdPer = 0;
                    else pNoProdPer = pNoProdQty / pNoStanProd * 100;
                    DtGrid.Rows.Add(new object[] { null, null, null, null, pBanName + " 합계 :", null, null, null, null, null, null, pNoStanProd, pNoRunTime, pNoProdQty, pNoProdPer });

                    if (NoProdQty * NoStanProd == 0) NoProdPer = 0;
                    else NoProdPer = NoProdQty / NoStanProd * 100;
                    DtGrid.Rows.Add(new object[] { null, null, null, null, "총  계 :", null, null, null, null, null, null, NoStanProd, NoRunTime, NoProdQty, NoProdPer });

                    grid2.DataSource = DtGrid;
                    grid2.DataBinds();

                    grid2.DisplayLayout.Bands[0].Columns["PLANTNAME"].MergedCellStyle = MergedCellStyle.Always;
                    grid2.DisplayLayout.Bands[0].Columns["BANNAME"].MergedCellStyle = MergedCellStyle.Always;
                    grid2.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid2.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;

                    grid2.DisplayLayout.Override.MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Top;
                    grid2.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;

                    grid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    grid2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;
                        * */
                    #endregion
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }

        public override void DoDownloadExcel()
        {
            //base.DoDownloadExcel();

            WIZ.REPORT.ExcelManager excel = new WIZ.REPORT.ExcelManager();

            excel.DownloadExcel(this.grid1, this.Name, false);
        }

        #endregion

        #region < EVENT AREA >
        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (Convert.ToString(e.Row.Cells["NUM"].Value) == string.Empty)
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

        private void txtWcCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txtWcCode.Tag = null;
                txtWcCode.Text = string.Empty;
                txtWcName.Text = string.Empty;
            }
        }
        #endregion

        #region < METHOD AREA >
        private DataTable GET_TBM0000_CODE_N(string MajorCode, string sSql)
        {
            DataTable Dt = new DataTable();

            DBHelper helper = new DBHelper(false);

            try
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine(" SELECT MINORCODE                             AS CODE_ID,     ");
                query.AppendLine("        '['  || MinorCode || '] '||  CodeName AS CODE_NAME,   ");
                query.AppendLine("        RelCode1, RelCode2, RelCode3, RelCode4, RelCode5,     ");
                query.AppendLine("        DisplayNo                             AS DisplayNo    ");
                query.AppendLine("   FROM TBM0000                                               ");
                query.AppendLine("  WHERE MajorCode = '" + MajorCode.ToUpper() + "'             ");
                query.AppendLine("    AND MinorCode <> '$'                                      ");
                query.AppendLine("    " + sSql + "                                              ");
                query.AppendLine("    AND UseFlag ='Y'                                          ");
                query.AppendLine("  ORDER BY DisplayNo                                          ");

                Dt = helper.FillTable(Convert.ToString(query), CommandType.Text);

                return Dt;
            }
            catch
            {
                return Dt;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion
    }
}

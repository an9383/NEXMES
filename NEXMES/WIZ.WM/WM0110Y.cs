#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0110Y
//   Form Name    : 제품검사 & 입고처리
//   Name Space   : WIZ.WM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0110Y : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        DataTable _dttmp = new DataTable();
        DataTable _TempDt = new DataTable();
        DataTable _rtnTmpDt1 = new DataTable();
        DataTable _rtnTmpDt2 = new DataTable();
        DataTable _rtnTmpDt3 = new DataTable();
        DataTable _rtnTmpDt4 = new DataTable();
        DataTable _rtnTmpDt5 = new DataTable();

        DataRow row = null;


        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();


        WIZ.PopUp.ProductTab_R ProductTab_R; //제품 식별표
        WIZ.PopUp.ProductTab_R2 ProductTab_R2; //제품 식별표  

        Image returnImage;

        int layoutCnt = 0;

        int cnt = 0;
        int cnt2 = 1;
        int chkCnt = 0;
        #endregion

        public WM0110Y()
        {
            InitializeComponent();

            //for (int i = 0; i < 8; i++)
            //{
            //    _rtnTmpDt5.Columns.Add("ITEMCODE"     + Convert.ToString(i + 1));
            //    _rtnTmpDt5.Columns.Add("ITEMNAME"     + Convert.ToString(i + 1));
            //    _rtnTmpDt5.Columns.Add("QTY"          + Convert.ToString(i + 1));
            //    _rtnTmpDt5.Columns.Add("UNITCODE"     + Convert.ToString(i + 1));
            //    _rtnTmpDt5.Columns.Add("LOTNO"        + Convert.ToString(i + 1));
            //    _rtnTmpDt5.Columns.Add("ITEMIMG"      + Convert.ToString(i + 1));
            //    _rtnTmpDt5.Columns.Add("CARTYPE"      + Convert.ToString(i + 1));
            //    _rtnTmpDt5.Columns.Add("PRODDATE"     + Convert.ToString(i + 1));
            //}
        }

        private void WM0110Y_Load(object sender, EventArgs e)
        {
            try
            {
                GridInit();
                DoClear("");

                //사업장
                _TempDt = _Common.GET_BM0000_CODE("PLANTCODE");
                //--

                dtpTab3Sdate.Value = DateTime.Now;
                dtpTab3Edate.Value = DateTime.Now;
            }
            catch
            {
            }
        }

        private void GridInit()
        {
            //-- Grid1
            try
            {
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOT NO", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "기초 수량", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "LOT 수량", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단  위", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPYN", "검사여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(grid1);
            }
            catch
            {
            }
            //--

            //-- Grid2
            try
            {
                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "검사품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "검사LOT", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "MEASURECODE", "측정코드", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "MEASURENAME", "측정항목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "MEASURETYPE", "측정타입", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "MEASURETYPENAME", "측정타입명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "INSPQTY", "불량수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "OKRESULT", "OK", false, GridColDataType_emu.CheckBox, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "NGRESULT", "NG", false, GridColDataType_emu.CheckBox, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(grid2);
            }
            catch
            {
            }
            //--

            //-- Grid3
            try
            {
                _GridUtil.InitializeGrid(grid3, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid3, "CHK", "선택", false, GridColDataType_emu.CheckBox, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "검사 품목", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "검사 품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "LOTNO", "LOT NO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "LOTQTY", "LOT수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "REMQTY", "검사수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "INSPRESULT", "검사결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "INSPDATE", "검사일시", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(grid3);
            }
            catch
            {
            }
            //--

            //-- Grid4
            try
            {
                _GridUtil.InitializeGrid(grid4, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid4, "INITEMCODE", "입고 품번", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid4, "INITEMNAME", "입고 품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid4, "INLOTNO", "입고 LOT", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid4, "INLOTQTY", "입고 수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid4, "INLOTUNIT", "입고 단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid4, "OUTITEMCODE", "완제품 품번", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid4, "OUTITEMNAME", "완제품 품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid4, "OUTLOTNO", "완제품 LOT", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid4, "OUTLOTQTY", "박스당 수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid4, "OUTLOTUNIT", "완제품 단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid4, "MAKER", "입고자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid4, "MAKEDATE", "입고일시", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(grid4);
            }
            catch
            {
            }
            //--

            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("VALUETYPE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "MEASURETYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
        }

        private void DoClear()
        {
        }

        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            base.DoInquire();
            DBHelper helper = new DBHelper(false);

            try
            {
                string sTabIdx = tabControl1.SelectedIndex.ToString();

                if (sTabIdx == "0")
                {
                    DoFind();
                }

                if (sTabIdx == "1")
                {
                    Tab2DoFind();
                }

                if (sTabIdx == "2")
                {
                    Tab3DoFind();
                }


            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #region ▶ TAB1 
        /// <summary>
        /// 검사대상 바코드 스캔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    string ls_barcode = txtBarCode.Text.Trim().ToUpper();
                    if (ls_barcode.Trim().Length > 0) { _ScanLogic(ls_barcode); }
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }

        /// <summary>
        /// TAB1 화면 초기화
        /// </summary>
        /// <param name="AS_FLAG"></param>
        private void DoClear(string AS_FLAG)
        {
            if (AS_FLAG == "TAB1" || AS_FLAG == "")
            {
                txtBarCode.Text = string.Empty;
                txtBarCode.Focus();
                txtTab1ItemCode.Text = string.Empty;
                txtTab1ItemName.Text = string.Empty;

                txtTab1LotNo.Text = string.Empty;
                txtTab1LotQty.Text = string.Empty;
                txtTab1LotUnit.Text = string.Empty;
                txtLotResult.Text = string.Empty;

                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid2);
                lblMsg.Text = "검사 대상 LOT를 SCAN 하세요!";
            }

            if (AS_FLAG == "TAB2" || AS_FLAG == "")
            {
                txtTab2BoxQty.Text = "0";
                txtTab2ItemCode.Text = string.Empty;
                txtTab2ItemName.Text = string.Empty;

                _GridUtil.Grid_Clear(grid3);
            }

            if (AS_FLAG == "TAB3" || AS_FLAG == "")
            {
                _GridUtil.Grid_Clear(grid4);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AS_BARCODE"></param>
        private void _ScanLogic(string AS_BARCODE)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string ls_plantcode = WIZ.LoginInfo.PlantCode.Trim();
                btnResult.Text = "판정 결과 저장";

                _TempDt = helper.FillTable("USP_WM0110Y_S1", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_BARCODE", AS_BARCODE, DbType.String, ParameterDirection.Input));
                if (_TempDt.Rows.Count > 0)
                {
                    string ls_itemcode = Convert.ToString(_TempDt.Rows[0]["ITEMCODE"]);
                    string ls_lotqty = Convert.ToString(_TempDt.Rows[0]["STOCKQTY"]);
                    string ls_remqty = Convert.ToString(_TempDt.Rows[0]["NOWQTY"]);
                    string ls_unitcode = Convert.ToString(_TempDt.Rows[0]["UNITCODE"]);
                    string ls_inspresult = Convert.ToString(_TempDt.Rows[0]["INSPYN"]);
                    string ls_worker = WIZ.LoginInfo.UserID.Trim();

                    if (txtTab1ItemCode.Text.Trim().Length == 0)
                    {
                        txtTab1ItemCode.Text = ls_itemcode;
                        txtTab1ItemName.Text = Convert.ToString(_TempDt.Rows[0]["ITEMNAME"]);
                    }

                    if (ls_itemcode != txtTab1ItemCode.Text.Trim())
                    {
                        lblMsg.Text = "검사 대상 등록 품목과 다른 품목이 SCAN 되었습니다.";
                        return;
                    }

                    helper.ExecuteNoneQuery("USP_WM0110Y_I1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_FLAG", "INSERT", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_LOTNO", AS_BARCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_LOTQTY", ls_lotqty, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_REMQTY", ls_remqty, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_UNITCODE", ls_unitcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_INSPRESULT", ls_inspresult, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKER", ls_worker, DbType.String, ParameterDirection.Input));



                    if (helper.RSCODE == "S")
                    {
                        lblMsg.Text = "LOT[" + AS_BARCODE + "]를 스캔 하였습니다.";
                        helper.Commit();
                        DoFind();
                    }
                    else
                    {
                        helper.Rollback();
                        lblMsg.Text = helper.RSMSG.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                lblMsg.Text = ex.Message.ToString();
            }
            finally
            {
                helper.Close();
                ScanReady();
            }
        }

        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);

            try
            {


                string ls_plantcode = WIZ.LoginInfo.PlantCode.Trim();

                _rtnTmpDt1 = helper.FillTable("USP_WM0110Y_S2", CommandType.StoredProcedure
                                                              , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("AS_ITEMCODE", string.Empty, DbType.String, ParameterDirection.Input));


                grid1.DataSource = _rtnTmpDt1;
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message.ToString();
            }
            finally
            {
                helper.Close();
            }
        }

        private void ScanReady()
        {
            txtBarCode.Text = string.Empty;
            txtBarCode.Focus();
        }

        private void grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                int iRows = e.Row.Index;

                string ls_plantcode = WIZ.LoginInfo.PlantCode.Trim();
                string ls_itemcode = Convert.ToString(grid1.Rows[iRows].Cells["ITEMCODE"].Value);
                string ls_lotno = Convert.ToString(grid1.Rows[iRows].Cells["LOTNO"].Value);

                txtTab1LotQty.Text = Convert.ToString(grid1.Rows[iRows].Cells["NOWQTY"].Value);
                txtTab1LotNo.Text = ls_lotno.Trim();
                txtTab1LotUnit.Text = Convert.ToString(grid1.Rows[iRows].Cells["UNITCODE"].Value);

                _rtnTmpDt2 = helper.FillTable("USP_WM0120Y_S1", CommandType.StoredProcedure
                                                              , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("AS_LOTNO", ls_lotno, DbType.String, ParameterDirection.Input));
                if (_rtnTmpDt2.Rows.Count == 0)
                    btnResult.Text = "제품 입고";

                grid2.DataSource = _rtnTmpDt2;
                grid2.DataBinds();

                txtLotResult.Text = "OK";

                lblMsg.Text = "선택한 LOT[" + ls_lotno + "]를 판정 처리 하시기 바랍니다.";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message.ToString();
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DoClear("TAB1");
        }

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "OKRESULT")
            {
                this.grid2.Rows[e.Cell.Row.Index].Cells["OKRESULT"].Value = true;
                this.grid2.Rows[e.Cell.Row.Index].Cells["NGRESULT"].Value = false;
            }
            else if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "NGRESULT")
            {
                this.grid2.Rows[e.Cell.Row.Index].Cells["NGRESULT"].Value = true;
                this.grid2.Rows[e.Cell.Row.Index].Cells["OKRESULT"].Value = false;
            }

        }

        private void grid2_AfterHeaderCheckStateChanged(object sender, AfterHeaderCheckStateChangedEventArgs e)
        {
            if (e.Column.GetHeaderCheckedState(e.Rows) == CheckState.Checked)
                return;


            for (int i = 0; i < grid2.Rows.Count; i++)
            {
                if (Convert.ToString(e.Column) == "OKRESULT")
                    grid2.Rows[i].Cells["NGRESULT"].Value = false;
                else
                    grid2.Rows[i].Cells["OKRESULT"].Value = false;
            }
        }

        private void grid2_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {

                grid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);
                string ls_ng = string.Empty;
                int li_ng = 0;
                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    ls_ng = Convert.ToString(grid2.Rows[i].Cells["NGRESULT"].Value);
                    if (ls_ng.Trim().ToUpper() == "TRUE") { li_ng++; }
                }

                if (li_ng > 0) { txtLotResult.Text = "NG"; } else { txtLotResult.Text = "OK"; }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message.ToString();
            }
            finally
            {
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            //if (grid2.Rows.Count < 1) { return; }

            if (this.ShowDialog(Common.getLangText("판정 결과를 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel) { return; }

            grid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

            string ls_ng = string.Empty, ls_ok = string.Empty;
            int licnt1 = 0, licnt2 = 0;

            for (int i = 0; i < grid2.Rows.Count; i++)
            {
                ls_ng = Convert.ToString(grid2.Rows[i].Cells["NGRESULT"].Value);
                ls_ok = Convert.ToString(grid2.Rows[i].Cells["OKRESULT"].Value);

                if (ls_ng.Trim().ToUpper() == "TRUE")
                {
                    if (Convert.ToString(grid2.Rows[i].Cells["INSPQTY"].Value).Trim() == "" || Convert.ToString(grid2.Rows[i].Cells["INSPQTY"].Value).Trim() == "0")
                    {
                        ShowDialog(Convert.ToString(grid2.Rows[i].Cells["MEASURENAME"].Value)
                            + Common.getLangText("검사항목의 판정 결과가 NG이나 수량이 0 입니다. NG 수량이 0보다 커야 합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }

                if (ls_ng.Trim().ToUpper() == "TRUE" && ls_ok.Trim().ToUpper() == "TRUE") { licnt1++; }
                if (ls_ng.Trim().ToUpper() == "FALSE" && ls_ok.Trim().ToUpper() == "FALSE") { licnt2++; }
            }

            if (licnt1 > 0)
            {
                ShowDialog(Common.getLangText("둘다 판정 처리 된 항목이 존재 합니다. 양품 또는 불량 중 하나만 판정 처리 되어야 합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (licnt2 > 0)
            {
                ShowDialog(Common.getLangText("판정이 안된 항목이 존재 합니다. 양품 또는 불량 중 하나는 판정 처리 되어야 합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            DBHelper helper = new DBHelper(false);

            try
            {

                string AS_PLANTCODE = WIZ.LoginInfo.PlantCode.Trim();
                string AS_ITEMCODE = txtTab1ItemCode.Text.Trim();
                string AS_LOTNO = txtTab1LotNo.Text.Trim();
                string AS_MAKER = WIZ.LoginInfo.UserID.Trim();

                string AS_MEASURECODE = string.Empty, AS_MEASURETYPE = string.Empty, AS_INSPQTY = string.Empty, AS_OKRESULT = string.Empty;
                string AS_NGRESULT = string.Empty, AS_INSPCODE = string.Empty;
                int iErrCnt = 0;




                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    AS_INSPCODE = Convert.ToString(grid2.Rows[i].Cells["INSPCODE"].Value);
                    AS_MEASURECODE = Convert.ToString(grid2.Rows[i].Cells["MEASURECODE"].Value);
                    AS_MEASURETYPE = Convert.ToString(grid2.Rows[i].Cells["MEASURETYPE"].Value);
                    AS_INSPQTY = Convert.ToString(grid2.Rows[i].Cells["INSPQTY"].Value);
                    AS_OKRESULT = Convert.ToString(grid2.Rows[i].Cells["OKRESULT"].Value).ToUpper();
                    AS_NGRESULT = Convert.ToString(grid2.Rows[i].Cells["NGRESULT"].Value).ToUpper();

                    helper.ExecuteNoneQuery("USP_WM0120Y_I1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", AS_PLANTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", AS_ITEMCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_LOTNO", AS_LOTNO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_INSPCODE", AS_INSPCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MEASURECODE", AS_MEASURECODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MEASURETYPE", AS_MEASURETYPE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_INSPQTY", AS_INSPQTY, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OKRESULT", AS_OKRESULT, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_NGRESULT", AS_NGRESULT, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MAKER", AS_MAKER, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E") { iErrCnt++; }
                }

                if (iErrCnt > 0)
                {
                    helper.Rollback();
                    ShowDialog(Common.getLangText("판정결과 등록 중 오류가 발생했습니다. 담당자에게 확인 바랍니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
                else
                {
                    String ls_result = string.Empty;
                    ls_result = txtLotResult.Text.Trim();
                    helper.ExecuteNoneQuery("USP_WM0120Y_I2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", AS_PLANTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", AS_ITEMCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_LOTNO", AS_LOTNO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_RESULT", ls_result, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MAKER", AS_MAKER, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE.ToString().Trim() == "S")
                    {
                        helper.Commit();
                        Application.DoEvents();

                        lblMsg.Text = "LOT[" + AS_LOTNO + "]의 판정 결과[" + txtLotResult.Text.Trim() + "]를 저장 하였습니다.";

                        txtTab1LotNo.Text = string.Empty;
                        txtTab1LotQty.Text = string.Empty;
                        txtTab1LotUnit.Text = string.Empty;
                        txtLotResult.Text = string.Empty;
                        _GridUtil.Grid_Clear(grid2);
                        DoFind();
                        ScanReady();
                    }
                    else
                    {
                        helper.Rollback();
                        ShowDialog(Common.getLangText("판정결과 등록 중 오류가 발생했습니다. 담당자에게 확인 바랍니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
                helper.Rollback();
            }
            finally
            {
                helper.Close();
                btnResult.Text = "판정 결과 저장";
            }
        }
        #endregion

        private void Tab2DoFind()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                string ls_plantcode = WIZ.LoginInfo.PlantCode.Trim();
                string ls_itemcode = txtTab2ItemCode.Text.Trim();

                _rtnTmpDt3 = helper.FillTable("USP_WM0110Y_S3", CommandType.StoredProcedure
                                                              , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input));


                grid3.DataSource = _rtnTmpDt3;
                grid3.DataBinds();
                Application.DoEvents();

                if (grid3.Rows.Count == 0)
                {
                    this.ClosePrgFormNew();
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void txtTab2ItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txtTab2ItemCode.Tag = null;
                txtTab2ItemCode.Text = string.Empty;
                txtTab2ItemName.Text = string.Empty;
            }
        }

        private void txtTab2ItemCode_ButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable _dtTemp = new DataTable();
            //    string ls_plantcode = WIZ.LoginInfo.PlantCode.Trim();
            //    string[] values = { ls_plantcode, "FERT" };

            //    POP_TBM0100 _frmA = new POP_TBM0100(values);

            //    _frmA.ShowDialog();
            //    _dtTemp = (DataTable)_frmA.Tag;
            //    if (_dtTemp.Rows.Count > 0)
            //    {
            //        txtTab2ItemCode.Text = Convert.ToString(_dtTemp.Rows[0][0]);
            //        txtTab2ItemName.Text = Convert.ToString(_dtTemp.Rows[0][1]);
            //    }
            //    _frmA.Dispose();
            //    _dtTemp.Dispose();
            //}
            //catch
            //{
            //}
        }

        /// <summary>
        /// 자제창고 입고 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTab2MatIn_Click(object sender, EventArgs e)
        {
            if (grid3.Rows.Count == 0)
            {
                ShowDialog(Common.getLangText("입고 할 제품이 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            string ls_itemcode1 = string.Empty;
            string ls_itemcode2 = string.Empty;
            int iNg = 0;

            for (int i = 0; i < grid3.Rows.Count; i++)
            {
                if (Convert.ToString(grid3.Rows[i].Cells["CHK"].Value).ToUpper() == "TRUE")
                {
                    ls_itemcode1 = Convert.ToString(grid3.Rows[i].Cells["ITEMCODE"].Value);

                    if (ls_itemcode2.Trim().Length == 0) { ls_itemcode2 = ls_itemcode1.Trim(); }
                    if (ls_itemcode1 != ls_itemcode2) { iNg++; }
                }
            }

            if (iNg > 0)
            {
                ShowDialog(Common.getLangText("한개 이상의 품번이 체크 되었습니다. 입고시 한 종류의 품번만 가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            int iCnt = 0;

            decimal dLotQty = 0, dBoxQty = 0;
            string lsChk = string.Empty;
            for (int i = 0; i < grid3.Rows.Count; i++)
            {
                lsChk = Convert.ToString(grid3.Rows[i].Cells["CHK"].Value).ToUpper();
                if (lsChk == "TRUE")
                {
                    iCnt++;
                    dLotQty += Convert.ToDecimal(grid3.Rows[i].Cells["REMQTY"].Value);
                }
            }

            if (iCnt == 0)
            {
                ShowDialog(Common.getLangText("입고 할 LOT를 선택하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //포장 수량
            dBoxQty = Convert.ToDecimal(DBHelper.nvlString(txtTab2BoxQty.Text.Trim(), "0"));
            if (dBoxQty == 0)
            {
                ShowDialog(Common.getLangText("입고 박스 수량이 0보다 커야 합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (dBoxQty > dLotQty)
            {
                ShowDialog(Common.getLangText("입고 박스 수량보다 입고량이 더 작습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (this.ShowDialog(Common.getLangText("제품 입고 처리 하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel) { return; }

            if ((dLotQty % dBoxQty).ToString() != "0")
            {
                ShowDialog(Common.getLangText("포장 수량만큼 입고 후 잔량이 발생하게 됩니다.", "MSG"), Forms.DialogForm.DialogType.OK);
            }

            string ls_prockey = DateTime.Now.ToString("yyyyMMddhhmmss");
            string ls_plantcode = WIZ.LoginInfo.PlantCode.Trim();
            string ls_worker = WIZ.LoginInfo.UserID.Trim();
            string ls_itemcode = txtTab2ItemCode.Text.Trim();
            string ls_boxqty = txtTab2BoxQty.Text.Trim();
            DBHelper helper = new DBHelper(false);
            int iErrorCnt = 0;

            //제품입고 LOT 저장 처리
            try
            {

                string ls_chk = string.Empty, ls_initemcode = string.Empty;
                string ls_inlot = string.Empty, ls_inlotqty = string.Empty;

                for (int i = 0; i < grid3.Rows.Count; i++)
                {
                    ls_chk = Convert.ToString(grid3.Rows[i].Cells["CHK"].Value).ToUpper();

                    if (ls_chk.Trim() == "TRUE")
                    {
                        ls_initemcode = Convert.ToString(grid3.Rows[i].Cells["ITEMCODE"].Value).ToUpper();
                        ls_inlot = Convert.ToString(grid3.Rows[i].Cells["LOTNO"].Value).ToUpper();
                        ls_inlotqty = Convert.ToString(grid3.Rows[i].Cells["REMQTY"].Value).ToUpper();

                        helper.ExecuteNoneQuery("USP_WM0130Y_I1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PROCKEY", ls_prockey, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_INITEMCODE", ls_initemcode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_INLOT", ls_inlot, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_INLOTQTY", ls_inlotqty, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_WORKER", ls_worker, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "E") { iErrorCnt++; }
                    }
                }

                if (iErrorCnt == 0)
                {
                    helper.Commit();
                    Application.DoEvents();
                }
                else
                {
                    helper.Rollback();
                    helper.Close();
                    ShowDialog(Common.getLangText("제품 입고 처리 중 오류가 발생했습니다. 담당자에게 확인하시기 바랍니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
            }
            finally
            {
                if (helper != null) { helper.Close(); }
            }

            DBHelper helper2 = new DBHelper(false);

            ///제품 입고 lot 연결 처리
            try
            {
                if (iErrorCnt == 0)
                {
                    helper2.ExecuteNoneQuery("USP_WM0130Y_I2", CommandType.StoredProcedure
                                                             , helper2.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper2.CreateParameter("AS_PROCKEY", ls_prockey, DbType.String, ParameterDirection.Input)
                                                             , helper2.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                                                             , helper2.CreateParameter("AS_BOXQTY", ls_boxqty, DbType.String, ParameterDirection.Input)
                                                             , helper2.CreateParameter("AS_WORKER", ls_worker, DbType.String, ParameterDirection.Input));

                    if (helper2.RSCODE == "E")
                    {
                        helper2.Rollback();
                        ShowDialog(Common.getLangText("제품 입고 처리 중 오류가 발생했습니다. 담당자에게 확인하시기 바랍니다.", "MSG")
                            + helper2.RSMSG, Forms.DialogForm.DialogType.OK);
                    }
                    else
                    {
                        helper2.Commit();
                        ShowDialog(Common.getLangText("제품 입고 처리 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        _LabelPrint(ls_prockey);
                        Tab2DoFind();
                        txtTab2BoxQty.Text = "0";
                    }
                }
            }
            catch
            {
            }
            finally
            {
                helper2.Close();
            }
        }

        private void _LabelPrint(string AS_PROCKEY)
        {
            DBHelper helper = new DBHelper(false);


            try
            {

                if (AS_PROCKEY.Trim().Length == 0) { return; }


                _dttmp = helper.FillTable("USP_WM0130Y_S1", CommandType.StoredProcedure
                                                          , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("AS_PROCKEY", AS_PROCKEY, DbType.String, ParameterDirection.Input));


                if (_dttmp.Rows.Count > 0)
                {
                    for (int i = 0; i < _dttmp.Rows.Count; i++)
                    {
                        SendPrint(LoginInfo.PlantCode, Convert.ToString(_dttmp.Rows[i]["LOTNO"]));
                    }
                }
                else
                {
                }
                Application.DoEvents();

                //cnt2 = 1;
                //chkCnt = 0;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void txtTab2BoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                ShowDialog(Common.getLangText("숫자만 입력 가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                e.Handled = true;
                txtTab2BoxQty.Text = "0";
            }
        }

        private void SendPrint(string AS_PLANTCODE, string AS_LOTNO)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_WM0520_S1", CommandType.StoredProcedure
                                                                      , helper.CreateParameter("PLANTCODE", AS_PLANTCODE, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("LOTNO", AS_LOTNO, DbType.String, ParameterDirection.Input));

                //if(cnt2 == 1 || cnt2 % 8 == 1)
                //    row = _rtnTmpDt5.NewRow();

                //row["ITEMCODE"     + Convert.ToString(cnt + 1)] = rtnDtTemp.Rows[0]["ITEMCODE"];
                //row["ITEMNAME"     + Convert.ToString(cnt + 1)] = rtnDtTemp.Rows[0]["ITEMNAME"];
                //row["QTY"          + Convert.ToString(cnt + 1)] = rtnDtTemp.Rows[0]["QTY"];
                //row["UNITCODE"     + Convert.ToString(cnt + 1)] = rtnDtTemp.Rows[0]["UNITCODE"];
                //row["LOTNO"        + Convert.ToString(cnt + 1)] = rtnDtTemp.Rows[0]["LOTNO"];
                //row["PRODDATE"     + Convert.ToString(cnt + 1)] = rtnDtTemp.Rows[0]["PRODDATE"];
                //row["CARTYPE"      + Convert.ToString(cnt + 1)] = rtnDtTemp.Rows[0]["CARTYPE"];

                //row["ITEMIMG"      + Convert.ToString(cnt + 1)] = rtnDtTemp.Rows[0]["ITEMIMG"];

                //byte[] ImageByte = (byte[])rtnDtTemp.Rows[0][5]; 

                //MemoryStream ms = new MemoryStream(ImageByte); 
                //returnImage = Image.FromStream(ms);

                //row["ITEMIMG" + Convert.ToString(cnt + 1)] = returnImage;



                //if (cnt2 == _dttmp.Rows.Count || cnt2 % 8 == 0)
                //{
                //    _rtnTmpDt5.Rows.Add(row);

                if (helper.RSCODE == "S")
                {
                    //텔레릭 레포트로 출력시
                    //rtnDtTemp 데이터바인딩
                    ProductTab_R = new WIZ.PopUp.ProductTab_R();
                    objectDataSource.DataSource = rtnDtTemp;
                    ProductTab_R.DataSource = objectDataSource;
                    viewerInstance.ReportDocument = ProductTab_R.Report;

                    //레포트 뷰어
                    //ReportViewer.ReportSource = viewerInstance;
                    //ReportViewer.RefreshReport();

                    //뷰어 없이 바로 출력
                    Telerik.Reporting.IReportDocument myReport = new WIZ.PopUp.ProductTab_R();
                    System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                    System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
                    Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

                    reportProcessor.PrintController = standardPrintController;
                    printerSettings.Collate = true;
                    reportProcessor.PrintReport(viewerInstance, printerSettings);
                }
                else
                {
                    ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }

                //    _rtnTmpDt5.Rows.RemoveAt(0);

                //    cnt = -1;
                //}

                //cnt++;
                //cnt2++;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        //private void SendPrint(string AS_PLANTCODE, string AS_LOTNO)
        //{
        //    //시리얼 열기
        //    //openSerial();

        //    DBHelper helper = new DBHelper(false);

        //    try
        //    {
        //        DataTable rtnDtTemp = helper.FillTable("USP_WM0520_S1", CommandType.StoredProcedure
        //                                                              , helper.CreateParameter("PLANTCODE", AS_PLANTCODE, DbType.String, ParameterDirection.Input)
        //                                                              , helper.CreateParameter("LOTNO",     AS_LOTNO,     DbType.String, ParameterDirection.Input));

        //        if (helper.RSCODE == "S")
        //        {
        //            //텔레릭 레포트로 출력시
        //            //rtnDtTemp 데이터바인딩
        //            ProductTab_R = new WIZ.PopUp.ProductTab_R();
        //            objectDataSource.DataSource = rtnDtTemp;
        //            ProductTab_R.DataSource = objectDataSource;
        //            viewerInstance.ReportDocument = ProductTab_R.Report;

        //            //레포트 뷰어
        //            //ReportViewer.ReportSource = viewerInstance;
        //            //ReportViewer.RefreshReport();

        //            //뷰어 없이 바로 출력
        //            Telerik.Reporting.IReportDocument myReport = new WIZ.PopUp.ProductTab_R();
        //            System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
        //            System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
        //            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

        //            reportProcessor.PrintController = standardPrintController;
        //            printerSettings.Collate = true;
        //            reportProcessor.PrintReport(viewerInstance, printerSettings);

        //            //for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
        //            //{
        //            //    StringBuilder command = new StringBuilder();
        //            //    command.AppendLine("^XA";
        //            //    command.AppendLine("^LH0,0^LL500^XZ";
        //            //    command.AppendLine("^XA";
        //            //    command.AppendLine("^SEE:UHANGUL.DAT^FS";
        //            //    command.AppendLine("^CW1,E:KFONT3.FNT^CI26^FS";

        //            //    command.AppendLine("^FO" + "20,30" + "^GB" + "200,900,2" + "^FS";       //왼쪽 박스
        //            //    command.AppendLine("^FO" + "165,30" + "^GB" + "1,900,2" + "^FS";        //세로1
        //            //    command.AppendLine("^FO" + "20,210" + "^GB" + "200,1,2" + "^FS";        //가로1

        //            //    command.AppendLine("^FO" + "165,50" + "^A1R,50,35" + " ^FD" + "업 체 명" + "^FS";
        //            //    command.AppendLine("^FO" + "100,50" + "^A1R,50,35" + " ^FD" + "특    이" + "^FS";
        //            //    command.AppendLine("^FO" + "40,50"  + "^A1R,50,35" + " ^FD" + "사    항" + "^FS";
        //            //    command.AppendLine("^FO" + "165,250" + "^A1R,50,35" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["CUSTNAME"]) + "^FS";  //거래처

        //            //    //2,3 or 3,4
        //            //    command.AppendLine("^FO" + "250, 200" + "^BY3,4^BCR," + "80,Y,N,N" + "^FD" + Convert.ToString(rtnDtTemp.Rows[i]["BARCODE"]) + "^FS";    //바코드(1D)

        //            //    command.AppendLine("^FO" + "335,30" + "^GB" + "300,900,2" + "^FS";      //오른쪽 박스
        //            //    command.AppendLine("^FO" + "335,210" + "^GB" + "300,1,2" + "^FS";       //가로1
        //            //    command.AppendLine("^FO" + "335,530" + "^GB" + "300,1,2" + "^FS";       //가로2
        //            //    command.AppendLine("^FO" + "335,700" + "^GB" + "300,1,2" + "^FS";       //가로3
        //            //    command.AppendLine("^FO" + "580,30" + "^GB" + "1,900,2" + "^FS";        //입고일자 밑 줄
        //            //    command.AppendLine("^FO" + "520,30" + "^GB" + "1,900,2" + "^FS";        //품목 밑 줄
        //            //    command.AppendLine("^FO" + "465,30" + "^GB" + "1,900,2" + "^FS";        //품목명 밑 줄
        //            //    command.AppendLine("^FO" + "385,30" + "^GB" + "1,900,2" + "^FS";        //수량 밑 줄

        //            //    command.AppendLine("^FO" + "580,50" + "^A1R,50,35" + " ^FD" + "일    자" + "^FS";
        //            //    command.AppendLine("^FO" + "520,50" + "^A1R,50,35" + " ^FD" + "품    번" + "^FS";
        //            //    command.AppendLine("^FO" + "465,50" + "^A1R,50,35" + " ^FD" + "품    명" + "^FS";
        //            //    command.AppendLine("^FO" + "400,50" + "^A1R,50,35" + " ^FD" + "수    량" + "^FS";
        //            //    command.AppendLine("^FO" + "330,50" + "^A1R,50,35" + " ^FD" + "소재LOT" + "^FS";

        //            //    command.AppendLine("^FO" + "580,550" + "^A1R,50,35" + " ^FD" + "순    번" + "^FS";
        //            //    command.AppendLine("^FO" + "520,550" + "^A1R,50,35" + " ^FD" + "저장위치" + "^FS";
        //            //    command.AppendLine("^FO" + "465,550" + "^A1R,50,35" + " ^FD" + "구    분" + "^FS";
        //            //    command.AppendLine("^FO" + "400,550" + "^A1R,50,35" + " ^FD" + "납품일자" + "^FS";
        //            //    command.AppendLine("^FO" + "360,550" + "^A1R,20,20" + " ^FD" + "소재자재구분" + "^FS";
        //            //    command.AppendLine("^FO" + "335,570" + "^A1R,20,20" + " ^FD" + "차종/기종" + "^FS";

        //            //    command.AppendLine("^FO" + "590,270" + "^A1R,30,30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["PRTDATE"]) + "^FS";
        //            //    command.AppendLine("^FO" + "520,215" + "^A1R,60,35" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]) + "^FS";
        //            //    command.AppendLine("^FO" + "480,215" + "^A1R,20,20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]) + "^FS";
        //            //    command.AppendLine("^FO" + "380,300" + "^A1R,70,70" + " ^FD" + string.Format("{0:#,##0}", Convert.ToInt32(rtnDtTemp.Rows[i]["QTY"])) + "^FS";                        

        //            //    command.AppendLine("^FO" + "580,760" + "^A1R,50,50" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[i]["BARCODE"]).Substring(8,3) + "^FS";

        //            //    command.AppendLine("^FO" + "640,100" + "^A1R,50,50" + " ^FD" + "제품식별표" + "^FS";
        //            //    command.AppendLine("^FO" + "640,700" + "^A1R,50,50" + " ^FD" + "대신정공" + "^FS";
        //            //    command.AppendLine("^XZ";

        //            //    byte[] b = Encoding.Default.GetBytes(command);
        //            //    serialPort1.Write(b, 0, b.Length);
        //            //}
        //        }
        //        else
        //        {
        //            ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
        //    }
        //    finally
        //    {
        //        serialPort1.Close();
        //        helper.Close();
        //    }
        //}

        /// <summary>
        /// OpenSerial
        /// </summary>
        private void openSerial()
        {
            if (serialPort1.IsOpen) serialPort1.Close(); // 시리얼포트가 열려있으면 닫기 위함

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_GET_SERAILPORT", CommandType.StoredProcedure
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
                ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }

        private void txtTab3ItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txtTab3ItemCode.Tag = null;
                txtTab3ItemCode.Text = string.Empty;
                txtTab3ItemName.Text = string.Empty;
            }
        }

        private void txtTab3ItemCode_ButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable _dtTemp = new DataTable();
            //    string ls_plantcode = WIZ.LoginInfo.PlantCode.Trim();
            //    string[] values = { ls_plantcode, "FERT" };

            //    POP_TBM0100 _frmA = new POP_TBM0100(values);

            //    _frmA.ShowDialog();
            //    _dtTemp = (DataTable)_frmA.Tag;
            //    if (_dtTemp.Rows.Count > 0)
            //    {
            //        txtTab3ItemCode.Text = Convert.ToString(_dtTemp.Rows[0][0]);
            //        txtTab3ItemName.Text = Convert.ToString(_dtTemp.Rows[0][1]);
            //    }
            //    _frmA.Dispose();
            //    _dtTemp.Dispose();
            //}
            //catch
            //{
            //}
        }


        private void Tab3DoFind()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                string ls_sdate = string.Format("{0:yyyy-MM-dd}", dtpTab3Sdate.Value);
                string ls_edate = string.Format("{0:yyyy-MM-dd}", dtpTab3Edate.Value);
                string ls_itemcode = txtTab3ItemCode.Text.Trim();
                string ls_plantcode = WIZ.LoginInfo.PlantCode.Trim();

                _rtnTmpDt4 = helper.FillTable("USP_WM0110Y_S4", CommandType.StoredProcedure
                                                              , helper.CreateParameter("AS_SDATE", ls_sdate, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("AS_EDATE", ls_edate, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input));

                grid4.DataSource = _rtnTmpDt4;
                grid4.DataBinds();

                //grid4.DisplayLayout.Bands[0].Columns["INITEMCODE"].MergedCellStyle  = MergedCellStyle.Always;
                //grid4.DisplayLayout.Bands[0].Columns["INITEMNAME"].MergedCellStyle  = MergedCellStyle.Always;
                grid4.DisplayLayout.Bands[0].Columns["INLOTNO"].MergedCellStyle = MergedCellStyle.Always;
                //grid4.DisplayLayout.Bands[0].Columns["INLOTQTY"].MergedCellStyle    = MergedCellStyle.Always;
                //grid4.DisplayLayout.Bands[0].Columns["INLOTUNIT"].MergedCellStyle   = MergedCellStyle.Always;
                //grid4.DisplayLayout.Bands[0].Columns["OUTITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                //grid4.DisplayLayout.Bands[0].Columns["OUTITEMNAME"].MergedCellStyle = MergedCellStyle.Always;

                Application.DoEvents();

                if (grid4.Rows.Count == 0)
                {
                    this.ClosePrgFormNew();
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void grid4_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            e.Row.Appearance.BackColor = Color.White;
        }

        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            CustomMergedCellEvalutor CM1 = new CustomMergedCellEvalutor("INITEMCODE", "INITEMNAME");

            e.Layout.Bands[0].Columns["INITEMCODE"].MergedCellEvaluator = CM1;
            e.Layout.Bands[0].Columns["INITEMNAME"].MergedCellEvaluator = CM1;
            e.Layout.Bands[0].Columns["INLOTNO"].MergedCellEvaluator = CM1;
            e.Layout.Bands[0].Columns["INLOTQTY"].MergedCellEvaluator = CM1;
            e.Layout.Bands[0].Columns["INLOTUNIT"].MergedCellEvaluator = CM1;
            e.Layout.Bands[0].Columns["OUTITEMCODE"].MergedCellEvaluator = CM1;
            e.Layout.Bands[0].Columns["OUTITEMNAME"].MergedCellEvaluator = CM1;
        }

        private void button1_Click(object sender, EventArgs e) //식별표 발행 TEST
        {
            SendPrint("10", "OR17030300710X001");
        }

        private void grid3_ClickCell(object sender, ClickCellEventArgs e)
        {
            string sLotNo = "";
            if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "CHK")
            {
                sLotNo = Convert.ToString(this.grid3.ActiveRow.Cells["LOTNO"].Value);
                for (int i = 0; i < this.grid3.Rows.Count; i++)
                {
                    if (sLotNo == Convert.ToString(grid3.Rows[i].Cells["LOTNO"].Value))
                    {
                        if (Convert.ToString(this.grid3.Rows[i].Cells["CHK"].Value) == "True")
                        {
                            this.grid3.Rows[i].Cells["CHK"].Value = false;
                        }
                        else this.grid3.Rows[i].Cells["CHK"].Value = true;
                    }
                }
            }
        }

        //private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        //{         
        //    if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "OKRESULT")
        //    {
        //        this.grid2.Rows[e.Cell.Row.Index].Cells["OKRESULT"].Value = true;
        //        this.grid2.Rows[e.Cell.Row.Index].Cells["NGRESULT"].Value = false;
        //    }
        //    else if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "NGRESULT")
        //    {
        //        this.grid2.Rows[e.Cell.Row.Index].Cells["NGRESULT"].Value = true;
        //        this.grid2.Rows[e.Cell.Row.Index].Cells["OKRESULT"].Value = false;
        //    }

        //}

        #region ▶ CustomMergedCellEvalutor Class
        /*
        public class CustomMergedCellEvalutor : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            string Col1 = string.Empty;
            string Col2 = string.Empty;

            public CustomMergedCellEvalutor(string pCol1, string pCol2)
            {
                Col1 = pCol1;
                Col2 = pCol2;
            }

            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1,
                                      Infragistics.Win.UltraWinGrid.UltraGridRow row2,
                                      Infragistics.Win.UltraWinGrid.UltraGridColumn col)
            {
                try
                {
                    if (row1.GetCellValue(Col1).GetType().ToString() != "System.DBNull"
                        && row2.GetCellValue(Col1).GetType().ToString() != "System.DBNull"
                        && row1.GetCellValue(Col2).GetType().ToString() != "System.DBNull"
                        && row2.GetCellValue(Col2).GetType().ToString() != "System.DBNull")
                    {
                        string value1 = (string)row1.GetCellValue(Col1);
                        string value2 = (string)row2.GetCellValue(Col1);

                        string value3 = (string)row1.GetCellValue(Col2);
                        string value4 = (string)row2.GetCellValue(Col2);

                        return (value1 + value3) == (value2 + value4);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }

        }*/
        #endregion

        private void grid4_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //if(layoutCnt == 0)
            //{
            //    UltraGridLayout layout = e.Layout;
            //    UltraGridBand band = layout.Bands[0];

            //    band.SortedColumns.Clear();

            //    UltraGridColumn lotQtyCol = band.Columns["OUTLOTQTY"];
            //    band.Summaries.Add(SummaryType.Sum, lotQtyCol);

            //    band.Override.SummaryDisplayArea = SummaryDisplayAreas.Bottom;

            //    layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;

            //    band.SortedColumns.Add("INLOTNO", false, true);
            //    layout.Bands[0].SummaryFooterCaption = "합계";
            //}

            //layoutCnt++;             
        }

        private void grid2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //    return;

        }
    }
}
